Public Class SettingsMenuControl
    Private Sub PbBtnBack_Click(sender As Object, e As EventArgs) Handles PbBtnBack.Click
        DownloaderInterface.SetInterface(DownloaderInterface.InterfaceScreen.MainInterface)
    End Sub

End Class
