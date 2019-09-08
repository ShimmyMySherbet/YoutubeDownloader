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
        If Not IO.File.Exists("ffmpeg.exe") Then
            Console.WriteLine("Getting FFMPEG...")
            Xabe.FFmpeg.FFmpeg.GetLatestVersion()
        End If
        Console.WriteLine("checking data...")

        If IO.File.Exists("data") Then
            SQLClient = New SqliteClientBridge("data")
        Else
            CreateNewDatabaseFile()
            SQLClient = New SqliteClientBridge("data")
        End If
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
    End Sub
    Public Sub CreateNewDatabaseFile()
        Console.WriteLine("creating database file...")

        Dim SpotifyP As New SpotifyPrompt()
        Dim res As DialogResult = SpotifyP.ShowDialog
        Dim Commands As New List(Of String) From {"CREATE TABLE Settings (Key text, Value text)",
            "CREATE TABLE History (type text, title text, url text, id int)",
            "CREATE UNIQUE INDEX ""SettingsIndex"" ON ""Settings"" (""Key"");",
            "CREATE UNIQUE INDEX ""HistoryIndex"" ON ""History"" (""id"");",
            "Insert into 'settings' Values('Music_MaxRetires', '5')",
            "Insert into 'settings' Values('Music_MaxTrackDifference', '5000')",
            "Insert into 'settings' Values('Video_DefaultExtension', 'webm')",
            "Insert into 'settings' Values('Interface_UseCustomBackground', 'False')",
            "Insert into 'settings' Values('Interface_BackgroundTransparency', '100')",
            "Insert into 'settings' Values('Interface_BackgroundImage', '')",
            "Insert into 'settings' Values('Interface_BackgroundColour', '44, 47, 51')",
            "Insert into 'settings' Values('Interface_Style', 'Complete')"}
        If res = DialogResult.OK Then
            Commands.Add(String.Format("Insert into 'settings' Values('{0}', '{1}')", "Spotify_ID", SpotifyData.ClientID))
            Commands.Add(String.Format("Insert into 'settings' Values('{0}', '{1}')", "Spotify_Secret", SpotifyData.ClientSecret))
        End If
        Dim myconn As New SQLite.SQLiteConnection("Data Source=data")
        myconn.Open()
        For Each Cmd In Commands
            Dim CMMD As New SQLite.SQLiteCommand(Cmd, myconn)
            CMMD.ExecuteNonQuery()
        Next
        myconn.Close()
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
            TrackLogic.MaxDownloadRetries = SQLClient.TryGetSettingsValue("Music_MaxRetires")
            TrackLogic.MaxDurationDifferance = SQLClient.TryGetSettingsValue("Music_MaxTrackDifference")
        Else
            Console.WriteLine("SQL client is nothing.")
        End If
    End Sub
End Class
