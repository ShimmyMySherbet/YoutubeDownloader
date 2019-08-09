Imports YoutubeExplode
Imports YoutubeExplode.Models
Imports SpotifyAPI.Web
Imports Xabe.FFmpeg
Public Class MusicDownloaderinterface
    Dim Youtube As New YoutubeClient
    Dim Webclient As New Net.WebClient
    Public SpotifyNotAvalableException As New Exception
    Public Spotify As SpotifyApiBridge
    Public Event PlaylistLoadComplete()
    Public Event LoadControls(Controls As Control)
    Public UiThread As Threading.Thread
    Public UiTaskScehule As TaskScheduler
    Public UiTaskfactory As TaskFactory
    Private Sub BtnGo_Click(sender As Object, e As EventArgs) Handles BtnGo.Click



        If IsUrl(txturl.Text) Then
            'url
            Dim url As String = txturl.Text
            If url.ToLower.StartsWith("https://www.youtube.com/playlist?") Then
                Dim playlistid As String = txturl.Text.Remove(0, "https://www.youtube.com/playlist?list=".Length)
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
                    FetchVideoFromUrl(txturl.Text)
                End If
            Else


                FetchVideoFromUrl(txturl.Text)

            End If


        Else
            'term
            FetchVideoFromTerm(txturl.Text)
        End If
    End Sub
    Public Sub Main() Handles MyBase.Load
        If Not IO.Directory.Exists("Music") Then
            IO.Directory.CreateDirectory("Music")
        End If
        If Not IO.Directory.Exists("AudioCache") Then
            IO.Directory.CreateDirectory("AudioCache")
        End If
        If Not IO.Directory.Exists("ImageCache") Then
            IO.Directory.CreateDirectory("ImageCache")
        End If
        If Not IO.Directory.Exists("Downloads") Then
            IO.Directory.CreateDirectory("Downloads")
        End If
        If Not IO.File.Exists("ffmpeg.exe") Then
            Console.WriteLine("Getting FFMPEG...")
            Xabe.FFmpeg.FFmpeg.GetLatestVersion()
        End If
        Dim SpotifyID As String = ""
        Dim SpotifySecret As String = ""
        If Not IO.File.Exists("config.ini") Then
            Dim Res As DialogResult = SpotifyPrompt.ShowDialog()
            If Res = DialogResult.Ignore Then
                Console.WriteLine("Input Ignored; generating blank file...")
                IO.File.WriteAllLines("config.ini", {"#Auto-generated config file.", "SpotifyClientId=", "SpotifyClientSecret="})
            End If
        End If
        Dim Reader As New IniReader("Config.ini")
        SpotifyID = Reader.GetValue("SpotifyClientId")
        SpotifySecret = Reader.GetValue("SpotifyClientSecret")
        Console.WriteLine("ID: " & SpotifyID)
        Console.WriteLine("Secret: " & SpotifySecret)

        CheckForIllegalCrossThreadCalls = False
        UiThread = Threading.Thread.CurrentThread
        UiTaskScehule = TaskScheduler.FromCurrentSynchronizationContext
        UiTaskfactory = New TaskFactory(UiTaskScehule)
        Console.WriteLine("loading...")
        If SpotifyID <> "" Then
            If SpotifySecret <> "" Then
                Spotify = New SpotifyApiBridge(SpotifyID, SpotifySecret)
            End If
        End If

        Console.WriteLine("finished.")
        LoadUIElements()
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        Me.SetStyle(ControlStyles.Selectable, True)
        Me.SetStyle(ControlStyles.UserPaint, True)
        Me.DoubleBuffered = True
    End Sub

    Public Sub LoadUIElements()
        Me.BackgroundImage = My.Resources.GreyBacker1
        FlowItems.BackgroundImage = My.Resources.GreyBacker1


    End Sub




    Public Sub InvalidateOnScrol() Handles FlowItems.Scroll
        Application.DoEvents()
    End Sub
    Protected Overrides Sub OnScroll(ByVal se As ScrollEventArgs)
        Me.Invalidate()
        MyBase.OnScroll(se)
    End Sub






    Public Enum QueryType
        Unknown = 0
        Url = 1
        SearchTerm = 2
    End Enum


    Async Sub FetchVideoFromUrl(url As String)
        Dim Vid As Video = Await GetYoutubeVideo(url)
        Dim SpotifyResult As Models.FullTrack = Spotify.GetSpotifyTrack(Vid)
        Dim MexData As MexMediaInfo = MexMediaInfo.FromMediaTitle(Vid.Title)
        Dim UiControlData As New AudioControlData(Vid, SpotifyResult, MexData)
        Dim UiControl As New Audi(UiControlData)
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
            Dim SpotifyResult As Models.FullTrack = Spotify.GetSpotifyTrack(video)
            Dim MexData As MexMediaInfo = MexMediaInfo.FromMediaTitle(video.Title)
            Dim UiControlData As New AudioControlData(video, SpotifyResult, MexData, True)
            Dim UiControl As New Audi(UiControlData)
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
        Dim SpotifyResult As Models.FullTrack = Spotify.GetSpotifyTrack(Vid)
        Dim MexData As MexMediaInfo = MexMediaInfo.FromMediaTitle(Vid.Title)
        Dim UiControlData As New AudioControlData(Vid, SpotifyResult, MexData)
        Dim UiControl As New Audi(UiControlData)
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

    Private Sub TxtUrlEnter(sender As Object, e As KeyEventArgs) Handles txturl.KeyDown
        If e.KeyData = Keys.Return Then
            BtnGo.PerformClick()
        End If
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim res As DialogResult = MessageBox.Show(Me, "By clearing the current list, you will loose all current progress. Proceed?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2)
        If res = DialogResult.Yes Then
            Do Until FlowItems.Controls.OfType(Of Audi).Count = 0
                For Each control In FlowItems.Controls.OfType(Of Audi)
                    control.DisposeData()
                Next
            Loop
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles BtnDownloadAll.Click
        Dim startt As New Threading.Thread(Sub()
                                               For Each item In FlowItems.Controls.OfType(Of Audi)
                                                   Threading.Thread.Sleep(800)
                                                   item.btnDownload.PerformClick()
                                               Next
                                           End Sub)
        startt.Start()


    End Sub

    Private Sub PbSettings_Click(sender As Object, e As EventArgs) Handles PbSettings.Click
        SettingsMenu.Show()
        SettingsMenu.BringToFront()
    End Sub

    Private Sub PbOpenOutput_Click(sender As Object, e As EventArgs) Handles PbOpenOutput.Click
        Dim resp As String = IO.Directory.GetCurrentDirectory
        If Not resp.EndsWith("\") Then
            resp = resp & "\"
        End If
        Process.Start(resp & "Music")
    End Sub
End Class
Public Class IniReader
    Public FileKeys As New List(Of KeyValuePair(Of String, String))
    Public Sub New(Inifile As String)
        For Each line In IO.File.ReadAllLines(Inifile)
            If Not line = "" And Not line.StartsWith("#") Then
                If line.Contains("=") Then
                    Dim arg1 As String = line.Split("=")(0)
                    Dim arg2 As String = line.Remove(0, arg1.Length + 1)
                    FileKeys.Add(New KeyValuePair(Of String, String)(arg1, arg2))
                Else
                    FileKeys.Add(New KeyValuePair(Of String, String)(line, ""))
                End If
            End If
        Next
    End Sub
    Public Function GetValue(Key As String) As String
        Dim ret As String = Nothing
        For Each entry In FileKeys
            If entry.Key.ToLower = Key.ToLower Then
                ret = entry.Value
            End If
        Next
        Return ret
    End Function
    Public Function FileContainsKey(Key As String) As Boolean
        Dim ret As String = Nothing
        For Each entry In FileKeys
            If entry.Key.ToLower = Key.ToLower Then
                ret = entry.Value
            End If
        Next
        Return Not IsNothing(ret)
    End Function
End Class