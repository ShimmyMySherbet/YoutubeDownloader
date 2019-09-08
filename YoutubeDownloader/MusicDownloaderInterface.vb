Imports YoutubeExplode
Imports YoutubeExplode.Models
Imports SpotifyAPI.Web
Imports SpotifyAPI.Web.Models
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
        ParseEntryText(txturl.Text)
    End Sub


    Public Enum LinkType
        PluginSupported = -2
        Unknown = -1
        YoutubeVideo = 1
        YoutubePlaylist = 2
        YoutubeVideoPlaylist = 3
        SpotifyTrack = 4
        SpotifyAlbum = 5
        SpotifyPlaylist = 6
        SpotifyArtist = 7
    End Enum
    Public Function GetLinkType(Link As String) As LinkType
        Dim url As String = Link.ToLower
        If url.Contains("youtube.com/") Then
            If url.StartsWith("https://www.youtube.com/playlist?") Then
                Return LinkType.YoutubePlaylist
            ElseIf url.Contains("&list=") Then
                Return LinkType.YoutubeVideoPlaylist
            ElseIf url.Contains("watch?") Then
                Return LinkType.YoutubeVideo
            Else
                Return LinkType.Unknown
            End If
        ElseIf url.Contains("spotify.com/") Then
            If url.Contains("/track/") Then
                Return LinkType.SpotifyTrack
            ElseIf url.Contains("/album/") Then
                Return LinkType.SpotifyAlbum
            ElseIf url.Contains("/artist/") Then
                Return LinkType.SpotifyArtist
            ElseIf url.Contains("/playlist/") Then
                Return LinkType.SpotifyPlaylist
            Else
                Return LinkType.Unknown
            End If
        Else
            If DownloaderInterface.PluginManager.PluginsLoaded <> 0 Then
                If DownloaderInterface.PluginManager.UrlSupported(Link) Then
                    Return LinkType.PluginSupported
                Else
                    Return LinkType.Unknown
                End If
            Else
                Return LinkType.Unknown
            End If
        End If
    End Function
    Public Sub ParseEntryText(Txt As String)
        If IsUrl(Txt) Then
            'url
            Console.WriteLine("isUrl")
            Dim UrlType As LinkType = GetLinkType(Txt)
            Console.WriteLine($"Video Type: {UrlType.ToString}")
            Select Case UrlType
                Case LinkType.YoutubeVideo
                    FetchVideoFromUrl(Txt)
                Case LinkType.YoutubePlaylist
                    Dim playlistid As String = Txt.Remove(0, "https://www.youtube.com/playlist?list=".Length)
                    FetchVideosFromPlaylist(playlistid)
                Case LinkType.YoutubeVideoPlaylist
                    Dim urlparts As List(Of String) = Txt.Split("&").ToList
                    Dim listid As String = ""
                    For Each part In urlparts
                        If part.ToLower.StartsWith("list=") Then
                            listid = part.Remove(0, "list=".Length)
                        End If
                    Next
                    Dim res As DialogResult = MessageBox.Show(Me, "The video you have entered is part of a playlist. Would you like to load the entire playlist?", "Playlist", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                    If res = DialogResult.Yes Then
                        FetchVideosFromPlaylist(listid)
                    ElseIf res = DialogResult.No Then
                        FetchVideoFromUrl(Txt)
                    End If
                Case LinkType.SpotifyTrack
                    FetchVideoFromTrack(Txt)
                Case LinkType.SpotifyPlaylist
                    FetchVideosFromSpotifyPlaylist(Txt)
                Case LinkType.SpotifyAlbum
                    FetchVideosFromSpotifyAlbum(Txt)
                Case LinkType.PluginSupported
                    For Each res In DownloaderInterface.PluginManager.QueryByURL(Txt)
                        Fromterm(res)
                    Next
                Case Else
                    MessageBox.Show("Unsupported type.")
            End Select
        Else
            Fromterm(txturl.Text)
        End If
    End Sub
    Public Async Sub Fromterm(term As String)
        Dim Dep As AudioControlData = Await GetSpotifyDataFromterm(term)
        If IsNothing(Dep) Then
            Dep = Await GetYoutubeDataFromterm(term)
        End If
        Dim UiControl As New AudioEntry(Dep)
        AddHandler UiControl.DisposingData, Sub(x As Control)
                                                FlowItems.Controls.Remove(x)
                                            End Sub
        FlowItems.Controls.Add(UiControl)
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

    Public Sub Main() Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        UiThread = Threading.Thread.CurrentThread
        UiTaskScehule = TaskScheduler.FromCurrentSynchronizationContext
        UiTaskfactory = New TaskFactory(UiTaskScehule)
        Console.WriteLine("loading...")
        Console.WriteLine("ID: {0}", SpotifyData.ClientID)
        Console.WriteLine("sec: {0}", SpotifyData.ClientSecret)
        If SpotifyData.ClientID <> "" Then
            If SpotifyData.ClientSecret <> "" Then
                Spotify = New SpotifyApiBridge(SpotifyData.ClientID, SpotifyData.ClientSecret)
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
        Dim UiControl As New AudioEntry(UiControlData)
        AddHandler UiControl.DisposingData, Sub(x As Control)
                                                FlowItems.Controls.Remove(x)
                                            End Sub
        FlowItems.Controls.Add(UiControl)
    End Sub
    Async Sub FetchVideoFromTrack(url As String, Optional trackOverride As FullTrack = Nothing)
        Dim Mytrack As FullTrack = Nothing
        If IsNothing(trackOverride) Then
            Dim SpotifyTrackID As String = url.Split("/")(url.Split("/").Count - 1)
            Console.WriteLine("ID: " & SpotifyTrackID)
            Mytrack = Await Spotify.Spotify.GetTrackAsync(SpotifyTrackID)
        Else
            Mytrack = trackOverride
        End If
        Console.WriteLine("Recieved Track.")
        Dim Vid As Video = Await Spotify.GetYoutubeTrack(Mytrack)
        If Not IsNothing(Vid) Then
            Dim UiControlData As New AudioControlData(Vid, Mytrack, New MexMediaInfo(Mytrack.Artists(0).Name, Mytrack.Name))
            Dim UiControl As New AudioEntry(UiControlData)
            AddHandler UiControl.DisposingData, Sub(x As Control)
                                                    FlowItems.Controls.Remove(x)
                                                End Sub
            FlowItems.Controls.Add(UiControl)
        End If
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
            Dim UiControl As New AudioEntry(UiControlData)
            AddHandler UiControl.DisposingData, Sub(x As Control)
                                                    FlowItems.Controls.Remove(x)
                                                End Sub
            UiTaskfactory.StartNew(Sub()
                                       FlowItems.Controls.Add(UiControl)
                                   End Sub)
        Next
        RaiseEvent PlaylistLoadComplete()
    End Sub
    Async Sub FetchVideosFromSpotifyPlaylist(Playlist As String)
        Dim SpotifyPlaylistID As String = Playlist.Split("/")(Playlist.Split("/").Count - 1)
        Dim pls As FullPlaylist = Await Spotify.Spotify.GetPlaylistAsync(SpotifyPlaylistID)
        If Not IsNothing(pls) Then
            For Each track In pls.Tracks.Items
                FetchVideoFromTrack("", track.Track)
            Next
        End If
    End Sub
    Async Sub FetchVideosFromSpotifyAlbum(Album As String)
        Dim AlbumID As String = Album.Split("/")(Album.Split("/").Count - 1)
        Dim al As FullAlbum = Await Spotify.Spotify.GetAlbumAsync(AlbumID)
        If Not IsNothing(al) Then
            For Each track In al.Tracks.Items
                FetchVideoFromTrack("", Spotify.Spotify.GetTrack(track.Id))
            Next
        End If
    End Sub
    Dim DlTracks As New List(Of FullTrack)
    Dim dlip As Boolean = False
    Dim ip As Timer
    Public Sub BackgroundSpotifyPlaylistLoad(playlist As FullPlaylist)
        For Each track In playlist.Tracks.Items
            DlTracks.Add(track.Track)
        Next
        ip = New Timer With {.Interval = 500}
        AddHandler ip.Tick, AddressOf UId
        ip.Start()
        RaiseEvent PlaylistLoadComplete()
    End Sub
    Public Async Sub UId()
        If Not dlip Then
            dlip = True
            Console.WriteLine("getting yt track")
            Dim mt As Video = Await Spotify.GetYoutubeTrack(DlTracks(0))
            Console.WriteLine("ret")
            If Not IsNothing(mt) Then
                Console.WriteLine(mt.Title)
            End If
            dlip = False
        End If
    End Sub
    Async Function GetYoutubeDataFromterm(Term As String) As Task(Of AudioControlData)
        Dim Vid As Video = Await SearchVideos(Term)
        Dim SpotifyResult As Models.FullTrack = Spotify.GetSpotifyTrack(Vid)
        Dim MexData As MexMediaInfo = MexMediaInfo.FromMediaTitle(Vid.Title)
        Dim UiControlData As New AudioControlData(Vid, SpotifyResult, MexData)
        Return UiControlData
    End Function
    Public Async Function GetSpotifyDataFromterm(term As String) As Task(Of AudioControlData)
        Dim si As SearchItem = Spotify.SearchMusic(term)
        Dim sr As FullTrack = si.Tracks.Items(0)
        Dim yti As Video = Await Spotify.GetYoutubeTrack(sr)
        Dim UiControlData As New AudioControlData(yti, sr, New MexMediaInfo(sr.Artists(0).Name, sr.Name))
        Return UiControlData
    End Function
    Async Sub FetchVideoFromTerm(Term As String)
        Dim Vid As Video = Await SearchVideos(Term)
        Dim SpotifyResult As Models.FullTrack = Spotify.GetSpotifyTrack(Vid)
        Dim MexData As MexMediaInfo = MexMediaInfo.FromMediaTitle(Vid.Title)
        Dim UiControlData As New AudioControlData(Vid, SpotifyResult, MexData)
        Dim UiControl As New AudioEntry(UiControlData)
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
            Do Until FlowItems.Controls.OfType(Of AudioEntry).Count = 0
                For Each control In FlowItems.Controls.OfType(Of AudioEntry)
                    control.DisposeData()
                Next
            Loop
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles BtnDownloadAll.Click
        Dim startt As New Threading.Thread(Sub()
                                               For Each item In FlowItems.Controls.OfType(Of AudioEntry)
                                                   Threading.Thread.Sleep(800)
                                                   item.btnDownload.PerformClick()
                                               Next
                                           End Sub)
        startt.Start()


    End Sub

    Private Sub PbSettings_Click(sender As Object, e As EventArgs)
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

    Private Sub PbBtnBack_Click(sender As Object, e As EventArgs) Handles PbBtnBack.Click
        DownloaderInterface.SetInterface(DownloaderInterface.InterfaceScreen.MainInterface)
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