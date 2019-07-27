Imports SpotifyAPI
Imports SpotifyAPI.Web
Imports SpotifyAPI.Web.Models
Imports SpotifyAPI.Web.Auth
Imports YoutubeDownloader.ProgramConfigurationBase
Public Class SpotifyApiBridge
    Public Spotify As SpotifyWebAPI
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
    Public Function GetSpotifyTrack(Video As YoutubeExplode.Models.Video) As FullTrack
        Dim MexMedia As MexMediaInfo = MexMediaInfo.FromMediaTitle(Video.Title)
        Dim VideoDuration As Double = Video.Duration.TotalMilliseconds
        Dim YearOfRelease As UShort = Video.UploadDate.Year
        Dim SearchString As String = ""
        If MexMedia.Artist <> "" Then
            SearchString = MexMedia.Artist & " " & MexMedia.Name
        Else
            SearchString = MexMedia.Name
        End If
        Dim SearchResults As SearchItem = Spotify.SearchItems(SearchString, Enums.SearchType.Track)
        Dim SelectedResult As FullTrack = Nothing
        For Each item In SearchResults.Tracks.Items
            If IsNothing(SelectedResult) Then
                Dim TrackDuration As Double = item.DurationMs
                Dim DurationDifferance As Double = GetIntgralDifferance(VideoDuration, TrackDuration)
                If DurationDifferance < TrackLogic.MaxDurationDifferance Then
                    '/*todo: Create further verification logic/*'
                    SelectedResult = item
                End If
            End If
        Next
        Return SelectedResult
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
