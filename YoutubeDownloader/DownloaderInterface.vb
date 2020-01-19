Public Class DownloaderInterface
    Public Shared MusicInterface As MusicDownloaderinterface
    Public Shared VideoInterface As VideoDownloaderInterface
    Public Shared SettingsInterface As SettingsMenuControl
    Public Shared MainInterface As HomeMenuControl
    Public Shared SQLClient As SqliteClientBridge

    Public Shared PluginManager As New Plugins.PluginManager
    Public Enum InterfaceScreen
        MainInterface = 0
        MusicInterface = 1
        VideoInterface = 2
        SettingsInterface = 3
    End Enum
    Public Sub MyLoad() Handles MyBase.Load
        Console.WriteLine("Loading...")
        Console.WriteLine($"Load Directory: {Environment.CurrentDirectory}")
        Dim startargl As List(Of String) = IO.Path.GetDirectoryName(Reflection.Assembly.GetExecutingAssembly().CodeBase).Split("\").ToList
        startargl.RemoveAt(0)
        ChDir(String.Join("\", startargl))
        Console.WriteLine($"New Working Directory: {Environment.CurrentDirectory}")

        If Environment.GetCommandLineArgs.Contains("-install") Then
            If IsRunningAsAdmin() Then
                InstallFileExtension()
                MessageBox.Show(SplashEntry, "File extension '.ytdl' installed.")
                End
            Else
                MessageBox.Show(SplashEntry, "This task requires Admin permissions.")
                End
            End If
        End If



        If Not IO.Directory.Exists("x86") Then
            IO.Directory.CreateDirectory("x86")
        End If
        If Not IO.Directory.Exists("x64") Then
            IO.Directory.CreateDirectory("x64")
        End If
        If Not IO.File.Exists("x86\SQLite.Interop.dll") Then
            IO.File.WriteAllBytes("x86\SQLite.Interop.dll", IO.File.ReadAllBytes("x86\SQLite.Interop.86.dll"))
        End If
        If Not IO.File.Exists("x64\SQLite.Interop.dll") Then
            IO.File.WriteAllBytes("x64\SQLite.Interop.dll", IO.File.ReadAllBytes("x86\SQLite.Interop.64.dll"))
        End If

        If Not IO.Directory.Exists("Music") Then
            IO.Directory.CreateDirectory("Music")
        End If
        If Not IO.Directory.Exists("Plugins") Then
            IO.Directory.CreateDirectory("Plugins")
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
        If Not IO.Directory.Exists("Videos") Then
            IO.Directory.CreateDirectory("Videos")
        End If
        If Not IO.Directory.Exists("VideoCache") Then
            IO.Directory.CreateDirectory("VideoCache")
        End If

        If Not IO.File.Exists("ffmpeg.exe") Then
            Console.WriteLine("Getting FFMPEG...")
            SplashEntry.Status = "; Downloading FFMPEG"
            Dim DownloadClient As New FFMPEGDownloaderClient
            DownloadClient.ForceGCOnCompletion = True
            DownloadClient.Start()
            Do While DownloadClient.Downloading
                SplashEntry.Status = $"; Downloading FFMPEG: {DownloadClient.DownloadPercentage}%  {DownloadClient.DownloadedSizeString}/{DownloadClient.DownloadSizeString} ({DownloadClient.DownloadPercentage}%) {DownloadClient.DownloadSpeedString}"
            Loop
            If DownloadClient.HasError Then
                MessageBox.Show($"Failed to download FFMPEG: {vbNewLine} {DownloadClient.Error.Message} {vbNewLine} Try downloading FFMpeg through the settings menu later, or you can manually download ffmpeg.exe and ffmprobe.exe and place them next to YoutubeDownloader.exe.")
            End If
            SplashEntry.Status = ""
        End If
        Console.WriteLine("checking data...")

        If IO.File.Exists("data") Then
            SQLClient = New SqliteClientBridge("data")
        Else
            CreateNewDatabaseFile()
            SQLClient = New SqliteClientBridge("data")
        End If
        Console.WriteLine("refreshing data...")
        RefreshDataFile()
        Console.WriteLine("loading data...")
        LoadSettings()
        Console.WriteLine("Creating interface...")
        MusicInterface = New MusicDownloaderinterface
        VideoInterface = New VideoDownloaderInterface
        MainInterface = New HomeMenuControl
        SettingsInterface = New SettingsMenuControl
        MusicInterface.Dock = DockStyle.Fill
        VideoInterface.Dock = DockStyle.Fill
        SettingsInterface.Dock = DockStyle.Fill
        MainInterface.Dock = DockStyle.Fill
        MusicInterface.Tag = InterfaceScreen.MusicInterface
        VideoInterface.Tag = InterfaceScreen.VideoInterface
        SettingsInterface.Tag = InterfaceScreen.SettingsInterface
        MainInterface.Tag = InterfaceScreen.MainInterface
        Console.WriteLine("Adding Instance")
        Me.Controls.Add(MusicInterface)
        Me.Controls.Add(VideoInterface)
        Me.Controls.Add(SettingsInterface)
        Me.Controls.Add(MainInterface)
        SetInterface(InterfaceScreen.MainInterface)
        SettingsInterface.AllowUpdates = True
        SettingsInterface.ApplyThemes()
        Console.WriteLine(SpotifyData.ClientID)
        PluginManager.LoadPlugins()
        If Environment.GetCommandLineArgs.Count <> 1 Then
            Dim LoadFiles As List(Of String) = Environment.GetCommandLineArgs.ToList
            LoadFiles.RemoveAt(0)
            For Each file In LoadFiles
                file = file.Replace("""", "")
                If IO.File.Exists(file) Then
                    Console.WriteLine("file exists")
                    MusicInterface.AutoLoadFiles.Add(file)
                End If
            Next
        End If



        'This token is valid for read-only operations.
        GeniusAPI.Init("AHxAt52xqrwjGmL-L6XeXa7kDSXayMAPIl3ajWHEjtz5O2jOZK2Ae6cj52pYza4W")
    End Sub

    Public Sub Shownd() Handles MyBase.Shown
        MusicInterface.HandleAutos()
    End Sub

    <CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities")>
    Public Sub CreateNewDatabaseFile()
        Console.WriteLine("creating database file...")

        Dim SpotifyP As New SpotifyPrompt()
        Console.WriteLine("Showing firststart dialog")
        Dim res As DialogResult = SpotifyP.ShowDialog
        Console.WriteLine("data submitted")

        Dim Commands As New List(Of String) From {"CREATE TABLE Settings (Key text, Value text)",
            "CREATE UNIQUE INDEX ""SettingsIndex"" ON ""Settings"" (""Key"");",
            "Insert into 'settings' Values('Music_MaxRetires', '5')",
            "Insert into 'settings' Values('Music_MaxTrackDifference', '5000')",
            "Insert into 'settings' Values('Video_DefaultExtension', 'webm')",
            "Insert into 'settings' Values('Music_DefaultExtension', 'mp3')",
            "Insert into 'settings' Values('Interface_UseCustomBackground', 'False')",
            "Insert into 'settings' Values('Interface_BackgroundTransparency', '100')",
            "Insert into 'settings' Values('Interface_BackgroundImage', '')",
            "Insert into 'settings' Values('Interface_BackgroundColour', '44, 47, 51')",
            "Insert into 'settings' Values('Interface_Style', 'Complete')"}
        If res = DialogResult.OK Then
            If SpotifyP.PublicCredentials Then
                Commands.Add("Insert into 'settings' Values('Spotify_UsePublicCredentials', 'True')")
            Else
                Commands.Add("Insert into 'settings' Values('Spotify_UsePublicCredentials', 'False')")
                Commands.Add(String.Format("Insert into 'settings' Values('{0}', '{1}')", "Spotify_ID", SpotifyData.ClientID))
                Commands.Add(String.Format("Insert into 'settings' Values('{0}', '{1}')", "Spotify_Secret", SpotifyData.ClientSecret))
            End If
        End If
        Dim myconn As New SQLite.SQLiteConnection("Data Source=data")
        myconn.Open()
        For Each Cmd In Commands
            Dim CMMD As New SQLite.SQLiteCommand(Cmd, myconn)
            CMMD.ExecuteNonQuery()
        Next
        myconn.Close()
    End Sub

    Public Sub RefreshDataFile()
        If Not SQLClient.SettingsKeyExists("Music_MaxRetires") Then
            SQLClient.UpdateSettingsKey("Music_MaxRetires", 5)
        End If
        If Not SQLClient.SettingsKeyExists("Music_MaxTrackDifference") Then
            SQLClient.UpdateSettingsKey("Music_MaxTrackDifference", 5000)
        End If
        If Not SQLClient.SettingsKeyExists("Video_DefaultExtension") Then
            SQLClient.UpdateSettingsKey("Video_DefaultExtension", "webm")
        End If
        If Not SQLClient.SettingsKeyExists("Music_DefaultExtension") Then
            SQLClient.UpdateSettingsKey("Music_DefaultExtension", "mp3")
        End If
        If Not SQLClient.SettingsKeyExists("Interface_UseCustomBackground") Then
            SQLClient.UpdateSettingsKey("Interface_UseCustomBackground", "false")
        End If
        If Not SQLClient.SettingsKeyExists("Interface_BackgroundTransparency") Then
            SQLClient.UpdateSettingsKey("Interface_BackgroundTransparency", "100")
        End If
        If Not SQLClient.SettingsKeyExists("Interface_BackgroundImage") Then
            SQLClient.UpdateSettingsKey("Interface_BackgroundImage", "")
        End If
        If Not SQLClient.SettingsKeyExists("Interface_BackgroundColour") Then
            SQLClient.UpdateSettingsKey("Interface_BackgroundColour", "44, 47, 51")
        End If
        If Not SQLClient.SettingsKeyExists("Interface_Style") Then
            SQLClient.UpdateSettingsKey("Interface_Style", "Complete")
        End If
        If Not SQLClient.SettingsKeyExists("Music_EmbedLyrics") Then
            SQLClient.UpdateSettingsKey("Music_EmbedLyrics", "True")
        End If
        If Not SQLClient.SettingsKeyExists("Spotify_ID") Then
            SQLClient.UpdateSettingsKey("Spotify_ID", "")
        End If
        If Not SQLClient.SettingsKeyExists("Spotify_Secret") Then
            SQLClient.UpdateSettingsKey("Spotify_Secret", "")
        End If
        If Not SQLClient.SettingsKeyExists("Spotify_UsePublicCredentials") Then
            SQLClient.UpdateSettingsKey("Spotify_UsePublicCredentials", "True")
        End If
    End Sub
    Public Shared Sub RenewSpotifyToken()
        Dim RenThread As New Threading.Thread(Sub()
                                                  Dim NewClient As New SpotifyApiBridge(SpotifyData.ClientID, SpotifyData.ClientSecret)
                                                  Do Until NewClient.Ready
                                                      Threading.Thread.Sleep(100)
                                                  Loop
                                                  MusicInterface.Spotify = NewClient
                                              End Sub)
        RenThread.Start()
    End Sub
    Public Shared Sub SetInterface(Intf As InterfaceScreen)
        DownloaderInterface.SuspendLayout()
        For Each int As Control In DownloaderInterface.Controls
            If int.Tag = Intf Then
                int.Show()
            Else
                int.Hide()
            End If
        Next
        DownloaderInterface.ResumeLayout()
    End Sub
    Public Sub LoadSettings()
        If Not IsNothing(SQLClient) Then
            SpotifyData.ClientID = SQLClient.TryGetSettingsValue("Spotify_ID")
            SpotifyData.ClientSecret = SQLClient.TryGetSettingsValue("Spotify_Secret")
            If SQLClient.TryGetSettingsValue("Spotify_UsePublicCredentials") Then
                Dim data As KeyValuePair(Of String, String) = GetRandomPublicCredentials()
                SpotifyData.ClientID = data.Key
                SpotifyData.ClientSecret = data.Value
            End If
            TrackLogic.MaxDownloadRetries = SQLClient.TryGetSettingsValue("Music_MaxRetires")
            TrackLogic.MaxDurationDifferance = SQLClient.TryGetSettingsValue("Music_MaxTrackDifference")
            TrackLogic.Extension = SQLClient.TryGetSettingsValue("Music_DefaultExtension").ToLower
            TrackLogic.AttachLyrics = SQLClient.TryGetSettingsValue("Music_EmbedLyrics")
        Else
            Console.WriteLine("SQL client is nothing.")
        End If
    End Sub
End Class
