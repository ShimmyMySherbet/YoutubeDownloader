Imports SpotifyAPI
Imports SpotifyAPI.Web
Imports SpotifyAPI.Web.Models
Imports SpotifyAPI.Web.Auth
Imports YoutubeExplode
Imports YoutubeExplode.Models
Imports System.Threading
Public Class SpotifyApiBridge
    Public Spotify As SpotifyWebAPI
    Public YoutubeClient As New YoutubeClient
    Public Sub New(ClientID As String, ClientSecret As String)
        StartApi(ClientID, ClientSecret)
    End Sub
    Private Async Sub StartApi(ClientID As String, ClientSecret As String)
        Dim auth As Auth.CredentialsAuth = New Auth.CredentialsAuth(ClientID, ClientSecret)
        Dim token As Models.Token = Await auth.GetToken()
        Spotify = New SpotifyWebAPI() With {
            .TokenType = token.TokenType,
            .AccessToken = token.AccessToken
        }
    End Sub
    Public Function SearchMusic(Query As String) As SearchItem
        Return Spotify.SearchItems(Query, Enums.SearchType.Track)
    End Function
    Public Function GetSpotifyTrack(Video As YoutubeExplode.Models.Video, Optional ByVal MexDataOverride As MexMediaInfo = Nothing,
                                    Optional DurationDataOverride As TimeSpan = Nothing,
                                    Optional UseDurationOverride As Boolean = False) As FullTrack
        Dim MexMedia As MexMediaInfo = Nothing
        If Not IsNothing(Video) Then
            MexMedia = MexMediaInfo.FromMediaTitle(Video.Title)
        End If
        If Not IsNothing(MexDataOverride) Then
            MexMedia = MexDataOverride
        End If
        Dim VideoDuration As Double = Video.Duration.TotalMilliseconds
        If UseDurationOverride Then
            Console.WriteLine("dur override")
            VideoDuration = DurationDataOverride.TotalMilliseconds
        End If
        Dim YearOfRelease As UShort = Video.UploadDate.Year
        Dim SearchString As String = ""
        Dim performAlternativeSearch As Boolean = False
        If MexMedia.Artist = "" Then
            performAlternativeSearch = True
        End If
        Dim SelectedResult As FullTrack = Nothing
        Console.WriteLine(Video.Author)
        If performAlternativeSearch Then
            Console.WriteLine("Running alt search")
            If Video.Author.EndsWith("- Topic") Then
                SearchString = Video.Author.Replace("- Topic", "").Trim(" ") & " " & MexMedia.Name
            Else
                SearchString = Video.Author & " " & MexMedia.Name
            End If

            Console.WriteLine("Alt Search: {0}", SearchString)


            Dim AlternativeSearchResults As SearchItem = Spotify.SearchItems(SearchString, Enums.SearchType.Track, 2)
            For Each item In AlternativeSearchResults.Tracks.Items
                If IsNothing(SelectedResult) Then
                    Dim TrackDuration As Double = item.DurationMs
                    Dim DurationDifferance As Double = GetIntgralDifferance(VideoDuration, TrackDuration)
                    If DurationDifferance < TrackLogic.MaxDurationDifferance Then
                        SelectedResult = item
                    End If
                End If
            Next
        End If



        If MexMedia.Artist <> "" Then
            SearchString = MexMedia.Artist & " " & MexMedia.Name
        Else
            SearchString = MexMedia.Name
            performAlternativeSearch = True
        End If
        Console.WriteLine("Running main search")
        Dim SearchResults As SearchItem = Spotify.SearchItems(SearchString, Enums.SearchType.Track)

        For Each item In SearchResults.Tracks.Items
            If IsNothing(SelectedResult) Then
                Dim TrackDuration As Double = item.DurationMs
                Dim DurationDifferance As Double = GetIntgralDifferance(VideoDuration, TrackDuration)
                If DurationDifferance < TrackLogic.MaxDurationDifferance Then
                    SelectedResult = item
                End If
            End If
        Next


        If IsNothing(SelectedResult) Then

            If MexMedia.Artist <> "" Then
                Dim Redmedianame As String = MexMedia.Name
                If MexMedia.Name.ToLower.Contains("ft") Or MexMedia.Name.ToLower.Contains("feat") Then
                    Dim resp As String = MexMedia.Name.ToLower.Replace("ft", vbNewLine).Replace("feat", vbNewLine)
                    Redmedianame = resp.Split(vbNewLine)(0)
                End If

                Dim RedmediaArtist As String = MexMedia.Artist
                If MexMedia.Artist.ToLower.Contains("ft") Or MexMedia.Artist.ToLower.Contains("feat") Then
                    Dim resp As String = MexMedia.Artist.ToLower.Replace("ft", vbNewLine).Replace("feat", vbNewLine)
                    RedmediaArtist = resp.Split(vbNewLine)(0)
                End If

                Dim FtSearchname As String = RedmediaArtist & " " & Redmedianame


                Dim FtSearchResults As SearchItem = Spotify.SearchItems(FtSearchname, Enums.SearchType.Track)
                For Each item In FtSearchResults.Tracks.Items
                    If IsNothing(SelectedResult) Then
                        Dim TrackDuration As Double = item.DurationMs
                        Dim DurationDifferance As Double = GetIntgralDifferance(VideoDuration, TrackDuration)
                        If DurationDifferance < TrackLogic.MaxDurationDifferance Then
                            SelectedResult = item
                        End If
                    End If
                Next
            Else

                Dim Redmedianame As String = MexMedia.Name
                If MexMedia.Name.ToLower.Contains("ft") Or MexMedia.Name.ToLower.Contains("feat") Then
                    Dim resp As String = MexMedia.Name.ToLower.Replace("ft", vbNewLine).Replace("feat", vbNewLine)
                    Redmedianame = resp.Split(vbNewLine)(0)
                End If

                Dim searchpatten1 As String = Video.Author.Split("-")(0) & " " & Redmedianame
                Dim searchpatten2 As String = Redmedianame

                Dim p1SearchResults As SearchItem = Spotify.SearchItems(searchpatten1, Enums.SearchType.Track)
                For Each item In p1SearchResults.Tracks.Items
                    If IsNothing(SelectedResult) Then
                        Dim TrackDuration As Double = item.DurationMs
                        Dim DurationDifferance As Double = GetIntgralDifferance(VideoDuration, TrackDuration)
                        If DurationDifferance < TrackLogic.MaxDurationDifferance Then
                            SelectedResult = item
                        End If
                    End If
                Next


                If IsNothing(SelectedResult) Then
                    Dim p2SearchResults As SearchItem = Spotify.SearchItems(searchpatten2, Enums.SearchType.Track)
                    For Each item In p2SearchResults.Tracks.Items
                        If IsNothing(SelectedResult) Then
                            Dim TrackDuration As Double = item.DurationMs
                            Dim DurationDifferance As Double = GetIntgralDifferance(VideoDuration, TrackDuration)
                            If DurationDifferance < TrackLogic.MaxDurationDifferance Then
                                SelectedResult = item
                            End If
                        End If
                    Next
                End If



            End If
        End If



        Return SelectedResult
    End Function

    Public Async Function GetYoutubeTrack(Track As FullTrack) As Task(Of Video)

        Console.WriteLine($"[GetYoutubeTrack] Track Length: {Track.DurationMs / 1000} seconds")

        Dim MaxTrackDiff As Double = TrackLogic.MaxDurationDifferance
        Dim ArtistStrings As New List(Of String)
        Track.Artists.ForEach(Sub(x)
                                  ArtistStrings.Add(x.Name)
                              End Sub)
        Dim Searchterm As String = $"{String.Join(" & ", ArtistStrings)} - {Track.Name}"
        Console.WriteLine($"[GetYoutubeTrack] Term: {Searchterm}")
        Dim TrackDuration As Double = Track.DurationMs
        Console.WriteLine("[GetYoutubeTrack] Getting tracks from youtube...")
        Dim cts = New CancellationTokenSource()
        Dim ct As CancellationToken = cts.Token

        Dim Videos As IReadOnlyList(Of Video) = Await YoutubeClient.SearchVideosAsync(Searchterm, 1)
        Console.WriteLine("[GetYoutubeTrack] Sorting tracks from youtube...")
        If Not IsNothing(Videos) Then

            Console.WriteLine($"[GetYoutubeTrack] Recieved {Videos.Count} results.")

            Dim SelectedVideo As Video = Nothing
            For Each vid In Videos
                Console.WriteLine(vid.Title)
                If IsNothing(SelectedVideo) Then
                    Dim VideoDuration As Double = vid.Duration.TotalMilliseconds
                    Console.WriteLine($"[GetYoutubeTrack] Track Length: {VideoDuration / 1000} seconds")

                    Dim Diff As Double = GetIntgralDifferance(TrackDuration, VideoDuration)
                    Console.WriteLine($"[GetYoutubeTrack] Track Differance: {Diff}")
                    If Not Diff > MaxTrackDiff Then
                        SelectedVideo = vid
                        Exit For
                    End If
                End If
            Next
            If IsNothing(SelectedVideo) Then
                Console.WriteLine("Failed to find track.")
            Else
                Console.WriteLine($"Found track: {SelectedVideo.Title}")
            End If
            Return SelectedVideo
        Else
            Console.WriteLine("[GetYoutubeTrack] Search returned null.")
            Return Nothing
        End If
    End Function



    Public Function GetIntgralDifferance(left As Double, right As Double) As Double
        If left = right Then
            Return 0
        Else
            If left < right Then
                Return right - left
            Else
                Return left - right
            End If
        End If
    End Function
End Class
Public Class TempSpotifyobj
    Dim YoutubeClient As New YoutubeClient
    Public Async Function GetYoutubeTrack(Track As FullTrack) As Task(Of Video)

        Console.WriteLine($"[GetYoutubeTrack] Track Length: {Track.DurationMs / 1000} seconds")

        Dim MaxTrackDiff As Double = TrackLogic.MaxDurationDifferance
        Dim ArtistStrings As New List(Of String)
        Track.Artists.ForEach(Sub(x)
                                  ArtistStrings.Add(x.Name)
                              End Sub)
        Dim Searchterm As String = $"{String.Join(" & ", ArtistStrings)} - {Track.Name}"
        Console.WriteLine($"[GetYoutubeTrack] Term: {Searchterm}")
        Dim TrackDuration As Double = Track.DurationMs
        Console.WriteLine("[GetYoutubeTrack] Getting tracks from youtube...")
        Dim cts = New CancellationTokenSource()
        Dim ct As CancellationToken = cts.Token

        Dim Videos As IReadOnlyList(Of Video) = Await YoutubeClient.SearchVideosAsync(Searchterm, 1)
        Console.WriteLine("[GetYoutubeTrack] Sorting tracks from youtube...")
        If Not IsNothing(Videos) Then

            Console.WriteLine($"[GetYoutubeTrack] Recieved {Videos.Count} results.")

            Dim SelectedVideo As Video = Nothing
            For Each vid In Videos
                Console.WriteLine(vid.Title)
                If IsNothing(SelectedVideo) Then
                    Dim VideoDuration As Double = vid.Duration.TotalMilliseconds
                    Console.WriteLine($"[GetYoutubeTrack] Track Length: {VideoDuration / 1000} seconds")

                    Dim Diff As Double = GetIntgralDifferance(TrackDuration, VideoDuration)
                    Console.WriteLine($"[GetYoutubeTrack] Track Differance: {Diff}")
                    If Not Diff > MaxTrackDiff Then
                        SelectedVideo = vid
                        Exit For
                    End If
                End If
            Next
            If IsNothing(SelectedVideo) Then
                Console.WriteLine("Failed to find track.")
            Else
                Console.WriteLine($"Found track: {SelectedVideo.Title}")
            End If
            Return SelectedVideo
        Else
            Console.WriteLine("[GetYoutubeTrack] Search returned null.")
            Return Nothing
        End If
    End Function
    Public Function GetIntgralDifferance(left As Double, right As Double) As Double
        If left = right Then
            Return 0
        Else
            If left < right Then
                Return right - left
            Else
                Return left - right
            End If
        End If
    End Function
End Class