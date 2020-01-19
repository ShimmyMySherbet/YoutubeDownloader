Imports System.IO
Imports System.Net
Public Class FFMPEGDownloaderClient
    Public FileStream As Stream
    Private _Downloading As Boolean = False
    Private _HasEx As Boolean = False
    Private _Ex As Exception
    Private _IsDownloadingBytes As Boolean = False
    Private _DownloadComplete As Boolean = False
    Private _stat As DownloadStatus = DownloadStatus.Idle
    Public ForceGCOnCompletion As Boolean = False
    Public ReadOnly Property Status As DownloadStatus
        Get
            Return _stat
        End Get
    End Property
    Public ReadOnly Property HasError As Boolean
        Get
            Return _HasEx
        End Get
    End Property
    Public ReadOnly Property [Error] As Exception
        Get
            Return _Ex
        End Get
    End Property
    Public ReadOnly Property Downloading As Boolean
        Get
            If _IsDownloadingBytes Then
                Return _Downloading
            Else
                If _DownloadComplete Then
                    Return False
                Else
                    Return True
                End If
            End If
        End Get
    End Property
    Public Sub Start()
        If Not _Downloading Then
            Dim dlt As New Threading.Thread(AddressOf Downloader)
            _Downloading = True
            _stat = DownloadStatus.PreparingDownload
            dlt.Start()
        End If
    End Sub
    Public ReadOnly Property DownloadedBytes As Long
        Get
            If _IsDownloadingBytes Then
                Return FileStream.Length
            Else
                Return 0
            End If
        End Get
    End Property
    Public ReadOnly Property DownloadPercentage As Double
        Get
            If _IsDownloadingBytes Then
                Return Math.Round((DownloadedBytes / DownloadSize) * 100, 2)
            Else
                If _DownloadComplete Then
                    Return 100
                Else
                    Return 0
                End If
            End If
        End Get
    End Property
    Private _DownloadLength As Long
    Public ReadOnly Property DownloadSize As Long
        Get
            If _IsDownloadingBytes Then
                Return _DownloadLength
            Else
                If _DownloadComplete Then
                    Return _DownloadLength
                Else
                    Return -1
                End If
            End If
        End Get
    End Property
    Private _BytesPerSec As Long = 0
    Public ReadOnly Property DownloadSpeed As Long
        Get
            Return _BytesPerSec
        End Get
    End Property
    Public ReadOnly Property DownloadSpeedString As String
        Get
            Dim dls As Long = DownloadSpeed
            Select Case True
                Case dls > (1024 * 1024 * 1024)
                    Dim gbps As Double = Math.Round(dls / (1024 * 1024 * 1024), 2)
                    Return $"{gbps}gbp/s"
                Case dls > (1024 * 1024)
                    Dim mbps As Double = Math.Round(dls / (1024 * 1024), 2)
                    Return $"{mbps}mbp/s"
                Case dls > (1024)
                    Dim kbps As Double = Math.Round(dls / (1024), 2)
                    Return $"{kbps}kbp/s"
                Case Else
                    Return $"{dls}bp/s"
            End Select
        End Get
    End Property
    Public ReadOnly Property DownloadSizeString As String
        Get
            Dim dls As Long = DownloadSize
            Select Case True
                Case dls > (1024 * 1024 * 1024)
                    Dim gbps As Double = Math.Round(dls / (1024 * 1024 * 1024), 2)
                    Return $"{gbps}gb"
                Case dls > (1024 * 1024)
                    Dim mbps As Double = Math.Round(dls / (1024 * 1024), 2)
                    Return $"{mbps}mb"
                Case dls > (1024)
                    Dim kbps As Double = Math.Round(dls / (1024), 2)
                    Return $"{kbps}kb"
                Case Else
                    Return $"{dls}b"
            End Select
        End Get
    End Property
    Public ReadOnly Property DownloadedSizeString As String
        Get
            Dim dls As Long = DownloadedBytes
            Select Case True
                Case dls > (1024 * 1024 * 1024)
                    Dim gbps As Double = Math.Round(dls / (1024 * 1024 * 1024), 2)
                    Return $"{gbps}gb"
                Case dls > (1024 * 1024)
                    Dim mbps As Double = Math.Round(dls / (1024 * 1024), 2)
                    Return $"{mbps}mb"
                Case dls > (1024)
                    Dim kbps As Double = Math.Round(dls / (1024), 2)
                    Return $"{kbps}kb"
                Case Else
                    Return $"{dls}b"
            End Select
        End Get
    End Property
    Private Sub DownloadSpeedRecorder()
        Dim Last As Long = DownloadedBytes
        Do While _IsDownloadingBytes
            Threading.Thread.Sleep(500)
            Dim cur As Long = DownloadedBytes
            Dim bytes As Long = cur - Last
            _BytesPerSec = bytes * 2
            Last = cur
        Loop
        _BytesPerSec = 0
    End Sub
    Private Sub StartSpeedCounter()
        Dim DlSp As New Threading.Thread(AddressOf DownloadSpeedRecorder)
        DlSp.Start()
    End Sub
    Public Sub Cancel()
        DownloadLinkRequest.Abort()
    End Sub
    Dim DownloadLinkRequest As HttpWebRequest
    Private Sub Downloader()
        _stat = DownloadStatus.PreparingDownload
        _Downloading = True
        Try
            DownloadLinkRequest = WebRequest.Create("https://ffmpeg.zeranoe.com/builds/win32/static/ffmpeg-latest-win32-static.zip")
            With DownloadLinkRequest
                .Method = "GET"
            End With
            If Not IO.Directory.Exists("FFcache") Then
                IO.Directory.CreateDirectory("FFcache")
            End If
            If File.Exists("FFcache\ffmpeg.zip") Then
                File.Delete("FFcache\ffmpeg.zip")
            End If
            Using responce As HttpWebResponse = DownloadLinkRequest.GetResponse
                _DownloadLength = responce.ContentLength
                Using IOs As New MemoryStream
                    _stat = DownloadStatus.Downloading
                    FileStream = IOs
                    _IsDownloadingBytes = True
                    StartSpeedCounter()
                    responce.GetResponseStream.CopyTo(IOs)
                    _IsDownloadingBytes = False
                    IOs.Flush()
                    FileStream.Flush()
                    Using WriteStream As New FileStream("FFcache\ffmpeg.zip", FileMode.OpenOrCreate)
                        IOs.Position = 0
                        IOs.CopyTo(WriteStream)
                        WriteStream.Flush()
                        WriteStream.Close()
                    End Using
                    IOs.Close()
                End Using
                responce.Close()
            End Using
            If Not FileStream Is Nothing Then
                FileStream.Dispose()
            End If
            _stat = DownloadStatus.ExtractingFiles
            Using fl As Compression.ZipArchive = Compression.ZipFile.OpenRead("FFcache\ffmpeg.zip")
                If File.Exists("ffmpeg.exe") Then
                    File.Delete("ffmpeg.exe")
                End If
                Using FFmain As New FileStream("FFmpeg.exe", FileMode.OpenOrCreate)
                    Using inner As Stream = fl.GetEntry("ffmpeg-latest-win32-static/bin/ffmpeg.exe").Open
                        inner.CopyTo(FFmain)
                        inner.Close()
                        FFmain.Close()
                    End Using
                End Using
                If File.Exists("FFprobe.exe") Then
                    File.Delete("FFprobe.exe")
                End If
                Using FFProbe As New FileStream("FFprobe.exe", FileMode.OpenOrCreate)
                    Using inner As Stream = fl.GetEntry("ffmpeg-latest-win32-static/bin/ffprobe.exe").Open
                        inner.CopyTo(FFProbe)
                        inner.Close()
                        FFProbe.Close()
                    End Using
                End Using

            End Using
            _HasEx = False
        Catch ex As Exception
            _HasEx = True
            _Ex = ex
        End Try
        If File.Exists("FFcache\ffmpeg.zip") Then
            File.Delete("FFcache\ffmpeg.zip")
        End If
        If Directory.Exists("FFcache") Then
            Directory.Delete("FFcache")
        End If
        _IsDownloadingBytes = False
        If ForceGCOnCompletion Then
            _stat = DownloadStatus.ReleasingResources
            GC.Collect()
            GC.WaitForFullGCComplete()
            GC.WaitForPendingFinalizers()
        End If
        _DownloadComplete = True
        _Downloading = False
        _stat = DownloadStatus.Complete
    End Sub
    Public Enum DownloadStatus
        Idle = -1
        PreparingDownload = 0
        Downloading = 1
        ExtractingFiles = 2
        Complete = 3
        ReleasingResources = 4
    End Enum
End Class