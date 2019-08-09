Public Class DownloaderInterface
    Public Shared MusicInterface As MusicDownloaderinterface
    Public Sub MyLoad() Handles MyBase.Load
        'MusicInterface = New MusicDownloaderinterface
        'MusicInterface.Dock = DockStyle.Fill
        'Me.Controls.Add(MusicInterface)
        Dim pp As New HomeMenuControl
        pp.Dock = DockStyle.Fill
        Me.Controls.Add(pp)
    End Sub

End Class
