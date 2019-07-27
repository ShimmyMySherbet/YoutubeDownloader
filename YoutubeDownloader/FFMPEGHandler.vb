Imports Xabe.FFmpeg
Public Class FFMPEGHandler
    Public Sub New()

    End Sub
    Public Async Sub ConvertAudio(Infile As String, Outfile As String, bitrate As Double)
        Dim AudioConversion As IConversion = Conversion.Convert(Infile, Outfile)
        AudioConversion.UseHardwareAcceleration(Enums.HardwareAccelerator.Auto, Enums.VideoCodec.H264_cuvid, Enums.VideoCodec.H264_cuvid)
        Await AudioConversion.Start()
    End Sub
End Class
