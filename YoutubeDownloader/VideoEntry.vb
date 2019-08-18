Imports YoutubeExplode
Imports YoutubeExplode.Models
Imports YoutubeExplode.Models.MediaStreams
Imports Xabe.FFmpeg
Public Class VideoEntry
    Private Client As New YoutubeClient
    Public VideoStreams As IReadOnlyList(Of VideoStreamInfo)
    Public MuxedStreams As IReadOnlyCollection(Of MuxedStreamInfo)
    Public UiTaskfactory As TaskFactory = New TaskFactory(TaskScheduler.FromCurrentSynchronizationContext)
    Public MyVideo As Video
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
        MuxedStreams = InfoStreams.Muxed
        VideoStreams = InfoStreams.Video
        Dim qualiychk As New List(Of String)
        For Each qual In InfoStreams.Muxed
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

    End Sub
    Public Function ScrubFilename(Filename As String)
        Return Filename.Replace("/", "").Replace("\", "").Replace("|", "").Replace("?", "").Replace("<", "").Replace(">", "").Replace(":", "").Replace("""", "").Replace("*", "")
    End Function
End Class
