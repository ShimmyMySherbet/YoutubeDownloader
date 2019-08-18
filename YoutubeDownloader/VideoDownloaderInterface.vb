Imports YoutubeExplode.Models
Imports YoutubeExplode
Public Class VideoDownloaderInterface
    Dim Youtube As New YoutubeClient
    Dim Webclient As New Net.WebClient
    Public SpotifyNotAvalableException As New Exception
    Public Spotify As SpotifyApiBridge
    Public Event PlaylistLoadComplete()
    Public Event LoadControls(Controls As Control)
    Public UiThread As Threading.Thread
    Public UiTaskScehule As TaskScheduler
    Public UiTaskfactory As TaskFactory
    Private Sub PbBtnBack_Click(sender As Object, e As EventArgs) Handles PbBtnBack.Click
        DownloaderInterface.SetInterface(DownloaderInterface.InterfaceScreen.MainInterface)
    End Sub

    Private Sub BtnGo_Click(sender As Object, e As EventArgs) Handles BtnGo.Click
        ParseEntryText(txturl.Text)
    End Sub
    Public Sub ParseEntryText(Txt As String)
        If IsUrl(Txt) Then
            'url
            Dim url As String = Txt
            If url.ToLower.StartsWith("https://www.youtube.com/playlist?") Then
                Dim playlistid As String = Txt.Remove(0, "https://www.youtube.com/playlist?list=".Length)
                FetchVideosFromPlaylist(playlistid)
            ElseIf url.ToLower.Contains("&list=") Then

                Dim urlparts As List(Of String) = url.Split("&").ToList
                Dim listid As String = ""
                For Each part In urlparts
                    If part.ToLower.StartsWith("list=") Then
                        listid = part.Remove(0, "list=".Length)
                    End If
                Next

                Dim res As DialogResult = MessageBox.Show(Me, "The video you have entered is part of a playlist. Would you like to load the entire playlist?", "Playlist", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

                If res = DialogResult.Yes Then
                    'load playlist
                    FetchVideosFromPlaylist(listid)
                ElseIf res = DialogResult.No Then
                    FetchVideoFromUrl(Txt)
                End If
            Else


                FetchVideoFromUrl(Txt)

            End If


        Else
            'term
            FetchVideoFromTerm(Txt)
        End If
    End Sub

    Private Sub Flow_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles FlowItems.DragEnter
        If (e.Data.GetDataPresent(DataFormats.Text)) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub
    Private Sub Flow_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles FlowItems.DragDrop
        ParseEntryText(e.Data.GetData(DataFormats.Text).ToString)
    End Sub

    Async Sub FetchVideoFromUrl(url As String)
        Dim Vid As Video = Await GetYoutubeVideo(url)
        Dim UiControl As New VideoEntry(Vid)
        AddHandler UiControl.DisposingData, Sub(x As Control)
                                                FlowItems.Controls.Remove(x)
                                            End Sub
        FlowItems.Controls.Add(UiControl)
    End Sub



    Async Sub FetchVideosFromPlaylist(PlaylistID As String)
        Dim Playlist As Playlist = Await Youtube.GetPlaylistAsync(PlaylistID)
        Dim BackgroundThread As New Threading.Thread(AddressOf BackgroundPlaylistDownload)
        BackgroundThread.Start(Playlist)
        txturl.Enabled = False
        BtnGo.Enabled = False
    End Sub
    Public Sub ReEnableUrlFeed() Handles Me.PlaylistLoadComplete
        txturl.Enabled = True
        BtnGo.Enabled = True
    End Sub


    Public Sub BackgroundPlaylistDownload(Playlist As Playlist)
        For Each video In Playlist.Videos
            Dim UiControl As New VideoEntry(video)
            AddHandler UiControl.DisposingData, Sub(x As Control)
                                                    FlowItems.Controls.Remove(x)
                                                End Sub
            UiTaskfactory.StartNew(Sub()
                                       FlowItems.Controls.Add(UiControl)
                                       UiControl.BackColor = SystemColors.Control
                                   End Sub)
        Next
        RaiseEvent PlaylistLoadComplete()
    End Sub

    Async Sub FetchVideoFromTerm(Term As String)
        Dim Vid As Video = Await SearchVideos(Term)
        Dim UiControl As New VideoEntry(Vid)
        AddHandler UiControl.DisposingData, Sub(x As Control)
                                                FlowItems.Controls.Remove(x)
                                            End Sub
        FlowItems.Controls.Add(UiControl)
    End Sub

    Public Async Function GetYoutubeVideo(Url As String) As Task(Of Video)
        Dim VideoID As String = YoutubeClient.ParseVideoId(Url)
        Dim Video As Video = Await Youtube.GetVideoAsync(VideoID)
        Return Video
    End Function


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

    Private Sub VideoDownloaderInterface_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.BackgroundImage = My.Resources.GreyBacker1
        'FlowItems.BackgroundImage = My.Resources.GreyBacker1
    End Sub
    Private Sub TxtUrlEnter(sender As Object, e As KeyEventArgs) Handles txturl.KeyDown
        If e.KeyData = Keys.Return Then
            BtnGo.PerformClick()
        End If
    End Sub

    Private Sub PbOpenOutput_Click(sender As Object, e As EventArgs) Handles PbOpenOutput.Click
        Dim resp As String = IO.Directory.GetCurrentDirectory
        If Not resp.EndsWith("\") Then
            resp = resp & "\"
        End If
        Process.Start(resp & "Videos")
    End Sub
End Class
