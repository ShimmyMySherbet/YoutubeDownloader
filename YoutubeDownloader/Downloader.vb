Imports YoutubeExplode
Imports YoutubeExplode.Models
Imports SpotifyAPI.Web
Imports Xabe.FFmpeg
Public Class Downloader
    Public SpotifyNotAvalableException As New Exception
    Dim Spotify As SpotifyApiBridge
    Public Sub Main() Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        Console.WriteLine("loading...")
        If Environment.GetCommandLineArgs.Count > 2 Then
            Spotify = New SpotifyApiBridge(Environment.GetCommandLineArgs(1), Environment.GetCommandLineArgs(2))
        End If
        Console.WriteLine("finished.")
    End Sub
    Public Enum QueryType
        Unknown = 0
        Url = 1
        SearchTerm = 2
    End Enum
    Dim Youtube As New YoutubeClient
    Dim Webclient As New Net.WebClient
    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Console.WriteLine(IsUrl(TxtUrl.Text))
        If IsUrl(TxtUrl.Text) Then
            FetchVideoFromUrl(TxtUrl.Text)
        Else
            FetchVideoFromTerm(TxtUrl.Text)
        End If
    End Sub

    Async Sub FetchVideoFromUrl(url As String)
        Dim Vid As Video = Await GetYoutubeVideo(url)
        SetYoutubeVideoData(Vid)
        Dim SpotifyResult As Models.FullTrack = Spotify.GetSpotifyTrack(Vid)
        SetSpotifyData(SpotifyResult)
    End Sub
    Async Sub FetchVideoFromTerm(Term As String)
        Dim Vid As Video = Await SearchVideos(Term)
        SetYoutubeVideoData(Vid)
        Dim SpotifyResult As Models.FullTrack = Spotify.GetSpotifyTrack(Vid)
        SetSpotifyData(SpotifyResult)
    End Sub

    Public Async Function GetYoutubeVideo(Url As String) As Task(Of Video)
        Dim VideoID As String = YoutubeClient.ParseVideoId(Url)
        Dim Video As Video = Await Youtube.GetVideoAsync(VideoID)
        Return Video
    End Function

    Public Sub SetYoutubeVideoData(Video As Video)
        LblLength.Text = Video.Duration.TotalSeconds & "sec"
        Console.WriteLine($"{Video.Duration.TotalSeconds}")
        lblTitle.Text = Video.Title
        LblLikes.Text = Video.Statistics.LikeCount & ":" & Video.Statistics.DislikeCount
        Dim MyThumbnail As Image = Bitmap.FromStream(New IO.MemoryStream(Webclient.DownloadData(Video.Thumbnails.MediumResUrl)))
        PbImage.Image = MyThumbnail
    End Sub
    Public Sub SetSpotifyData(Track As Models.FullTrack)
        If IsNothing(Track) Then
            lblspotifyAlbum.Text = Nothing
            lblspotifyArtist.Text = Nothing
            lblspotifyName.Text = Nothing
            lblPreview.Text = Nothing
            pbSpotify.Image = Nothing
        Else
            lblspotifyAlbum.Text = "Album: " & Track.Album.Name
            lblspotifyArtist.Text = "Artist: " & Track.Artists(0).Name
            lblspotifyName.Text = "Song: " & Track.Name
            lblPreview.Tag = Track.PreviewUrl
            Console.WriteLine("Tract Duration: {0} ms", Track.DurationMs)
            Dim CoverUrl As String = Track.Album.Images(0).Url
            Dim MyThumbnail As Image = Bitmap.FromStream(New IO.MemoryStream(Webclient.DownloadData(CoverUrl)))

            pbSpotify.Image = MyThumbnail
        End If
    End Sub
    Public Async Function SearchVideos(Term As String) As Task(Of Video)
        Dim Results As IReadOnlyList(Of Video) = Await Youtube.SearchVideosAsync(Term, 1)
        If Results.Count <> 0 Then
            Return (Results(0))
        Else
            Return Nothing
        End If
    End Function

    Public Function IsUrl(Term As String) As Boolean
        If Term.ToLower.StartsWith("www.") Then
            Term = "http://" & Term
        End If
        Return Uri.IsWellFormedUriString(Term, UriKind.Absolute)
    End Function


    Private Sub LblPreview_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblPreview.LinkClicked
        Try
            Process.Start(lblPreview.Text)
        Catch ex As Exception
        End Try
    End Sub

    Dim MyAudioState As PlayState = 0
    Private Enum PlayState
        idle = 0
        Loading = 1
        Playing = 2
    End Enum
    Dim AudioPlaying As Boolean = False
    Private Sub BtnPlay_Click(sender As Object, e As EventArgs) Handles btnPlay.Click
        If btnPlay.Text = "Stop" Then
            AudioPlaying = False
            My.Computer.Audio.Stop()
            btnPlay.Text = "Play"
        ElseIf btnPlay.Text = "Play" Then
            DownloadAudio(lblPreview.Tag)
        End If
    End Sub
    Dim WaitThread As New Threading.Thread(Sub(Duration As Double)
                                               Console.WriteLine(Duration)
                                               Threading.Thread.Sleep(Duration)
                                               btnPlay.Text = "Play"
                                               AudioPlaying = False
                                               'My.Computer.Audio.Stop()
                                           End Sub)


    Public Async Sub DownloadAudio(url As String)
        Try
            Dim address As Uri
            Dim filename As String = ""
            address = New Uri(url)
            filename = System.IO.Path.GetFileName(address.LocalPath)
            Dim MyClient As New Net.WebClient
            If Not IO.File.Exists("audiocache\" & filename) Then
                btnPlay.Text = "Downloading..."
                IO.File.WriteAllBytes("audiocache\" & filename, MyClient.DownloadData(url))
            End If
            If Not IO.File.Exists("audiocache\" & filename & ".wav") Then
                btnPlay.Text = "Converting..."
                Dim AudioConversion As IConversion = Conversion.Convert("audiocache\" & filename, "audiocache\" & filename & ".wav")
                AudioConversion.UseHardwareAcceleration(Enums.HardwareAccelerator.Auto, Enums.VideoCodec.H264_cuvid, Enums.VideoCodec.H264_cuvid)
                Await AudioConversion.Start()
            End If
            Dim mediainfo As TagLib.File = TagLib.File.Create("audiocache\" & filename & ".wav")
            btnPlay.Text = "Stop"
            AudioPlaying = True
            My.Computer.Audio.Play("audiocache\" & filename & ".wav", AudioPlayMode.Background)
            WaitThread.Start(mediainfo.Properties.Duration.TotalMilliseconds)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FFmpeg.GetLatestVersion()
        MessageBox.Show("FFMPEG has been updated")
    End Sub
End Class

Public Class MexMediaInfo
    Public Artist As String
    Public Name As String
    Sub New(Artst As String, Song As String)
        Artist = Artst
        Name = Song
    End Sub
    Public Shared Function FromMediaTitle(Title As String) As MexMediaInfo
        If Title.Contains("-") Then
            Dim ArtistName As String = ""
            Dim SongName As String = ""
            Dim IsArtist As Boolean = True
            Dim isInBracket As Boolean = False
            Dim isInparenthesis As Boolean = False
            For Each cha As Char In Title
                Dim chas As String = cha.ToString
                If IsArtist Then
                    If isInBracket Or isInparenthesis Then
                        If chas = "]" Then
                            isInBracket = False
                        ElseIf chas = ")" Then
                            isInparenthesis = False
                        End If
                    Else
                        If chas = "[" Then
                            isInBracket = True
                        ElseIf chas = "(" Then
                            isInparenthesis = True
                        ElseIf chas = "-" Then
                            IsArtist = False
                        Else
                            ArtistName = ArtistName & chas
                        End If
                    End If
                Else
                    If isInBracket Or isInparenthesis Then
                        If chas = "]" Then
                            isInBracket = False
                        ElseIf chas = ")" Then
                            isInparenthesis = False
                        End If
                    Else
                        If chas = "[" Then
                            isInBracket = True
                        ElseIf chas = "(" Then
                            isInparenthesis = True
                        Else
                            SongName = SongName & chas
                        End If
                    End If
                End If
            Next
            ArtistName = ArtistName.Trim(" ")
            SongName = SongName.Trim(" ")
            Dim MyResInfo As New MexMediaInfo(ArtistName, SongName)
            Return MyResInfo
        Else
            Dim ScrubbedTitle As String = ""
            Dim isInBracket As Boolean = False
            Dim isInparenthesis As Boolean = False
            For Each cha As Char In Title
                Dim chas As String = cha.ToString
                If isInBracket Or isInparenthesis Then
                    If chas = "]" Then
                        isInBracket = False
                    ElseIf chas = ")" Then
                        isInparenthesis = False
                    End If
                Else
                    If chas = "[" Then
                        isInBracket = True
                    ElseIf chas = "(" Then
                        isInparenthesis = True
                    Else
                        ScrubbedTitle = ScrubbedTitle & chas
                    End If
                End If
            Next
            ScrubbedTitle = ScrubbedTitle.Trim(" ")
            Return New MexMediaInfo("", ScrubbedTitle)
        End If
    End Function
End Class