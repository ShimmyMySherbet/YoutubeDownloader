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

    Private Sub ett(sender As Object, e As EventArgs)

    End Sub

    Private Sub PbBtnMusic_Click(sender As Object, e As EventArgs)

    End Sub
End Class
