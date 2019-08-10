Public Class HomeMenuControl
    Private Sub ShadeMusicIcon(sender As Object, e As EventArgs) Handles PbBtnMusic.MouseMove
        If PbBtnMusic.Tag = 0 Then
            PbBtnMusic.Tag = 1
            PbBtnMusic.Image = My.Resources.MusicDownloadericon_Blue_MouseOver
        End If
    End Sub
    Public Sub DeshadeMusicIcon() Handles PbBtnMusic.MouseLeave
        PbBtnMusic.Tag = 0
        PbBtnMusic.Image = My.Resources.MusicDownloadericon_Blue
    End Sub

    Private Sub ShadeVideoIcon(sender As Object, e As EventArgs) Handles PbBtnVideo.MouseMove
        If PbBtnMusic.Tag = 0 Then
            PbBtnMusic.Tag = 1
            PbBtnVideo.Image = My.Resources.VideoDownloaderMenuicon_Blue_MouseOver
        End If
    End Sub
    Public Sub DeshadeVideoIcon() Handles PbBtnVideo.MouseLeave
        PbBtnMusic.Tag = 0
        PbBtnVideo.Image = My.Resources.VideoDownloaderMenuicon_Blue
    End Sub
    Private Sub ShadeSettingsIcon(sender As Object, e As EventArgs) Handles PbBtnSettings.MouseMove
        If PbBtnMusic.Tag = 0 Then
            PbBtnMusic.Tag = 1
            PbBtnSettings.Image = My.Resources.SettingsmenuIcon_Blue_MouseOver
        End If
    End Sub
    Public Sub DeshadeSettingsIcon() Handles PbBtnSettings.MouseLeave
        PbBtnMusic.Tag = 0
        PbBtnSettings.Image = My.Resources.SettingsmenuIcon_Blue
    End Sub
    Private Sub ShadeExitIcon(sender As Object, e As EventArgs) Handles PbBtnExit.MouseMove
        If PbBtnMusic.Tag = 0 Then
            PbBtnMusic.Tag = 1
            PbBtnExit.Image = My.Resources.ExitMenuicon_Blue_MouseOver
        End If
    End Sub
    Public Sub DeshadeExitIcon() Handles PbBtnExit.MouseLeave
        PbBtnMusic.Tag = 0
        PbBtnExit.Image = My.Resources.ExitMenuicon_Blue
    End Sub

    Private Sub HomeMenuControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.BackgroundImage = Nothing
    End Sub

    Private Sub PbBtnGithub_Click(sender As Object, e As EventArgs) Handles PbBtnGithub.Click
        Process.Start("https://github.com/ShimmyMySherbet/YoutubeDownloader")
    End Sub

    Private Sub PbBtnMusic_Click(sender As Object, e As EventArgs) Handles PbBtnMusic.Click
        DownloaderInterface.SetInterface(DownloaderInterface.InterfaceScreen.MusicInterface)
    End Sub

    Private Sub PbBtnVideo_Click(sender As Object, e As EventArgs) Handles PbBtnVideo.Click
        DownloaderInterface.SetInterface(DownloaderInterface.InterfaceScreen.VideoInterface)
    End Sub

    Private Sub PbBtnSettings_Click(sender As Object, e As EventArgs) Handles PbBtnSettings.Click
        DownloaderInterface.SetInterface(DownloaderInterface.InterfaceScreen.SettingsInterface)
    End Sub

    Private Sub PbBtnExit_Click(sender As Object, e As EventArgs) Handles PbBtnExit.Click
        End
    End Sub
End Class
