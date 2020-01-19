Imports YoutubeExplode
Imports YoutubeExplode.Models
Imports YoutubeExplode.Models.MediaStreams
Imports Xabe.FFmpeg
Public Class VideoEntry
    Private Client As New YoutubeClient
    Public VideoStreams As IReadOnlyList(Of VideoStreamInfo)
    Public MuxedStreams As IReadOnlyCollection(Of MuxedStreamInfo)
    Public AudioStreams As IReadOnlyCollection(Of AudioStreamInfo)
    Public UiTaskfactory As TaskFactory = New TaskFactory(TaskScheduler.FromCurrentSynchronizationContext)
    Public MyVideo As Video
    <CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1009:DeclareEventHandlersCorrectly")>
    Public Event DisposingData(Control As Control)
    Private QualBox As DomainUpDown
    Public IsDownloading As Boolean = False
    Public Sub New(Vid As Video)
        InitializeComponent()
        MyVideo = Vid
        GetQualities(Vid)
        Dim DlThread As New Threading.Thread(Sub()
                                                 Dim xclient As New Net.WebClient
                                                 Dim Img As Image = Image.FromStream(New IO.MemoryStream(xclient.DownloadData(Vid.Thumbnails.MediumResUrl)))
                                                 PbArtwork.Image = Img
                                             End Sub)
        PbArtwork.Image = My.Resources.Loading1
        DlThread.Start()
        lblChannel.Text = Vid.Author
        LblDuration.Text = Vid.Duration.ToString
        LblLikes.Text = Math.Round((Vid.Statistics.LikeCount / (Vid.Statistics.LikeCount + Vid.Statistics.DislikeCount)) * 100, 2) & "% Liked"
        LblTitle.Text = Vid.Title
        lblUploaded.Text = String.Format("{0}/{1}/{2}", Vid.UploadDate.Day, Vid.UploadDate.Month, Vid.UploadDate.Year)
        PbProgress.Hide()
    End Sub
    Public Async Sub GetQualities(vid As Video)
        QualBox = New DomainUpDown With {
            .Location = DudPlacholder.Location,
            .BackColor = DudPlacholder.BackColor,
            .ForeColor = DudPlacholder.ForeColor,
            .BorderStyle = BorderStyle.None,
            .Size = DudPlacholder.Size,
            .Name = "DudQualities"}




        Dim InfoStreams As MediaStreamInfoSet = Await Client.GetVideoMediaStreamInfosAsync(vid.Id)
        VideoStreams = InfoStreams.Video
        MuxedStreams = InfoStreams.Muxed
        AudioStreams = InfoStreams.Audio
        Dim qualiychk As New List(Of String)
        For Each qual In InfoStreams.Video
            Dim chstr As String = qual.VideoQualityLabel
            If Not qualiychk.Contains(chstr) Then
                qualiychk.Add(chstr)
                QualBox.Items.Add(qual.VideoQualityLabel)
            End If
        Next
        QualBox.SelectedIndex = 0
        DudPlacholder.Hide()
        DudPlacholder.Dispose()
        Me.Controls.Add(QualBox)
    End Sub
    Private Sub PbIcnYoutube_Click(sender As Object, e As EventArgs) Handles PbIcnYoutube.Click
        Process.Start(MyVideo.GetUrl)
    End Sub

    Private Sub VideoEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Public Sub DisposeData()
        Client = Nothing
        If Not IsNothing(Me) Then
            Me.Dispose()
        End If
        RaiseEvent DisposingData(Me)
    End Sub
    Private Sub PbBtnClose_Click(sender As Object, e As EventArgs) Handles PbBtnClose.Click
        DisposeData()
    End Sub

    Private Sub btnDownload_Click(sender As Object, e As EventArgs) Handles btnDownload.Click
        If Not IsNothing(QualBox) Then
            If Not IsDownloading Then
                IsDownloading = True
                Dim DownloaderThread As New Threading.Thread(AddressOf DownloadVideo)
                DownloaderThread.Start()
            End If
        End If
    End Sub


    Public Async Sub DownloadVideo()
        If IsNothing(AudioStreams) Then
            Throw New Exception("No Audio")
        End If

        Dim MXAS As Integer = 0
        Dim bestAudioStream As AudioStreamInfo = AudioStreams.Where(Function(x)
                                                                        If IsNothing(x) Then
                                                                            Console.WriteLine("NOTHING")
                                                                        End If
                                                                        If x.Bitrate > MXAS Then
                                                                            MXAS = x.Bitrate
                                                                            Return True
                                                                        Else
                                                                            Return False
                                                                        End If
                                                                    End Function).Last()
        Dim SelectedVideoStream As VideoStreamInfo = VideoStreams.Where(Function(x)
                                                                            Return x.VideoQualityLabel = QualBox.Items(QualBox.SelectedIndex)
                                                                        End Function).First

        If IsNothing(SelectedVideoStream) Then
            Throw New Exception("No stream")
        End If

        Dim VideoDownloader As Task = DlVid(SelectedVideoStream)
        Dim AudioDownloader As Task = DlAudio(bestAudioStream)

        Do Until AudioDownloader.IsCompleted
        Loop
        Console.WriteLine("Audio Downloaded")
        Do Until VideoDownloader.IsCompleted
        Loop
        Console.WriteLine("Video Downloaded")


        Dim vidext As String = SelectedVideoStream.VideoEncoding.ToString
        Dim SourceVideo As String = $"VideoCache\{ScrubFilename(MyVideo.Title)}.{vidext}"
        Dim audioext As String = "unknown"
        Select Case bestAudioStream.AudioEncoding
            Case MediaStreams.AudioEncoding.Aac
                audioext = "aac"
            Case MediaStreams.AudioEncoding.Opus
                audioext = "opus"
            Case MediaStreams.AudioEncoding.Vorbis
                audioext = "vorbis"
        End Select
        Dim SourceAudio As String = $"AudioCache\{ScrubFilename(MyVideo.Title)}.{audioext}"



        Dim output As String = $"Videos\{ScrubFilename(MyVideo.Title)}.{VideoLogic.DefaultExtension}"
        If IO.File.Exists(output) Then
            IO.File.Delete(output)
        End If
        Dim result As Model.IConversionResult = Await Conversion.AddAudio(SourceVideo, SourceAudio, output).UseHardwareAcceleration(Enums.HardwareAccelerator.cuvid, Enums.VideoCodec.H264_nvenc, Enums.VideoCodec.H264_nvenc).Start()
        Console.WriteLine("Download Complete")
    End Sub

    Private Async Function DlVid(Vid As VideoStreamInfo) As Task
        Dim ext As String = Vid.VideoEncoding.ToString
        Dim Name As String = $"VideoCache\{ScrubFilename(MyVideo.Title)}.{ext}"
        If IO.File.Exists(Name) Then
            Exit Function
            IO.File.Delete(Name)
        End If
        Await Client.DownloadMediaStreamAsync(Vid, Name)
    End Function
    Private Async Function DlAudio(Au As AudioStreamInfo) As Task
        Dim ext As String = "unknown"
        Select Case Au.AudioEncoding
            Case MediaStreams.AudioEncoding.Aac
                ext = "aac"
            Case MediaStreams.AudioEncoding.Opus
                ext = "opus"
            Case MediaStreams.AudioEncoding.Vorbis
                ext = "vorbis"
        End Select
        Dim Name As String = $"AudioCache\{ScrubFilename(MyVideo.Title)}.{ext}"
        If IO.File.Exists(Name) Then
            Exit Function
            IO.File.Delete(Name)
        End If
        Await Client.DownloadMediaStreamAsync(Au, Name)
    End Function


    Async Sub x()
#Region "Old Code"

        If False Then



            Await UiTaskfactory.StartNew(Sub()
                                             PbProgress.Value = 0
                                             PbProgress.Step = 1
                                             PbProgress.Maximum = 3
                                             PbProgress.Show()
                                         End Sub)
            Console.WriteLine("Streams fetched")





            Dim auinfo = MuxedStreams.Where(Function(x)
                                                Dim qualtxt As String = QualBox.Text
                                                If qualtxt.Contains(x.VideoQualityLabel) Then
                                                    Return True
                                                Else
                                                    Return False
                                                End If
                                            End Function)(0)
            If Not IsNothing(auinfo) Then
                Await UiTaskfactory.StartNew(Sub()
                                                 PbProgress.PerformStep()
                                             End Sub)


                Console.WriteLine("Video stream fetched")
                Console.WriteLine(auinfo)
                Dim ext As String = auinfo.VideoEncoding.ToString
                Console.WriteLine("ext: {0}", ext)
                Console.WriteLine("Downloading...")
                Dim Filename As String = ""
                Filename = ScrubFilename(MyVideo.Title)
                Try
                    If IO.File.Exists("Downloads\" & Filename & "." & ext) Then
                        IO.File.Delete("Downloads\" & Filename & "." & ext)
                    End If
                    If Not IO.File.Exists("Downloads\" & Filename & "." & ext) Then
                        Await Client.DownloadMediaStreamAsync(auinfo, "Downloads\" & Filename & "." & ext)
                    End If
                Catch ex As Exception
                    Console.WriteLine(ex.Message)
                End Try
                Await UiTaskfactory.StartNew(Sub()
                                                 PbProgress.PerformStep()
                                             End Sub)
                Dim NewExt As String = ""
                Dim VideoConversion As IConversion = Conversion.Convert($"Downloads\{Filename}.{ext}", $"Videos\{Filename}.{VideoLogic.DefaultExtension}")
                Await VideoConversion.Start
                Await UiTaskfactory.StartNew(Sub()
                                                 PbProgress.PerformStep()
                                                 PbProgress.Hide()
                                             End Sub)
            End If

        End If
#End Region

    End Sub


    Public Function ScrubFilename(Filename As String)
        Return Filename.Replace("/", "").Replace("\", "").Replace("|", "").Replace("?", "").Replace("<", "").Replace(">", "").Replace(":", "").Replace("""", "").Replace("*", "")
    End Function
End Class
