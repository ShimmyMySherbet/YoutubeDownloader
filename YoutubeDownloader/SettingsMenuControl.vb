Public Class SettingsMenuControl
    Public Sub New()
        InitializeComponent()
        NudMaxDiff.Value = TrackLogic.MaxDurationDifferance
        NudMaxRet.Value = TrackLogic.MaxDownloadRetries
    End Sub


    Private Sub PbBtnBack_Click(sender As Object, e As EventArgs) Handles PbBtnBack.Click
        DownloaderInterface.SetInterface(DownloaderInterface.InterfaceScreen.MainInterface)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles BtnClearCache.Click
        For Each file In IO.Directory.GetFiles("audiocache")
            Try
                IO.File.Delete(file)
            Catch ex As Exception
            End Try
        Next
        For Each file In IO.Directory.GetFiles("Downloads")
            Try
                IO.File.Delete(file)
            Catch ex As Exception
            End Try
        Next
        For Each file In IO.Directory.GetFiles("ImageCache")
            Try
                IO.File.Delete(file)
            Catch ex As Exception
            End Try
        Next
        MessageBox.Show("Cache Cleared.")
    End Sub

    Private Sub BtnUpdateFFMpeg_Click(sender As Object, e As EventArgs) Handles BtnUpdateFFMpeg.Click
        Xabe.FFmpeg.FFmpeg.GetLatestVersion()
        MessageBox.Show("FFMPEG Updated.")
    End Sub

    Private Sub NudMaxDiff_ValueChanged(sender As Object, e As EventArgs) Handles NudMaxDiff.ValueChanged
        DownloaderInterface.SQLClient.UpdateSettingsKey("Music_MaxTrackDifference", NudMaxDiff.Value)
    End Sub

    Private Sub NudMaxRet_ValueChanged(sender As Object, e As EventArgs) Handles NudMaxRet.ValueChanged
        DownloaderInterface.SQLClient.UpdateSettingsKey("Music_MaxRetires", NudMaxRet.Value)
    End Sub
End Class
