Public Class DownloaderInterface
    Public Shared MusicInterface As MusicDownloaderinterface
    Public Sub MyLoad() Handles MyBase.Load
        MusicInterface = New MusicDownloaderinterface
        MusicInterface.Dock = DockStyle.Fill
        Me.Controls.Add(MusicInterface)
    End Sub

End Class
