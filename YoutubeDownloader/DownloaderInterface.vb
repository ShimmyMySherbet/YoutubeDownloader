Public Class DownloaderInterface
    Public Shared MusicInterface As MusicDownloaderinterface
    Public Shared VideoInterface As Object
    Public Shared SettingsInterface As SettingsMenuControl
    Public Shared MainInterface As HomeMenuControl
    Public Enum InterfaceScreen
        MainInterface = 0
        MusicInterface = 1
        VideoInterface = 2
        SettingsInterface = 3
    End Enum
    Public Sub MyLoad() Handles MyBase.Load
        MusicInterface = New MusicDownloaderinterface
        VideoInterface = New Object
        SettingsInterface = New SettingsMenuControl
        MainInterface = New HomeMenuControl
        MusicInterface.Dock = DockStyle.Fill
        'VideoInterface.Dock = DockStyle.Fill
        SettingsInterface.Dock = DockStyle.Fill
        MainInterface.Dock = DockStyle.Fill
        MusicInterface.Tag = InterfaceScreen.MusicInterface
        'VideoInterface.Tag = InterfaceScreen.VideoInterface
        SettingsInterface.Tag = InterfaceScreen.SettingsInterface
        MainInterface.Tag = InterfaceScreen.MainInterface
        Me.Controls.Add(MusicInterface)
        'Me.Controls.Add(VideoInterface)
        Me.Controls.Add(SettingsInterface)
        Me.Controls.Add(MainInterface)
        SetInterface(InterfaceScreen.MainInterface)
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
End Class
