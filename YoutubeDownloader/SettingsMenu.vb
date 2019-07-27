Public Class SettingsMenu
    Private Sub SettingsMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BtnUpdateFfmpeg_Click(sender As Object, e As EventArgs) Handles BtnUpdateFfmpeg.Click
        Xabe.FFmpeg.FFmpeg.GetLatestVersion()
        MessageBox.Show("FFMPEG Updated.")
    End Sub

    Private Sub BtnClearCache_Click(sender As Object, e As EventArgs) Handles BtnClearCache.Click
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
End Class