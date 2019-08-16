Imports YoutubeExplode
Imports YoutubeExplode.Models
Imports YoutubeExplode.Models.MediaStreams
Public Class VideoEntry
    Private Client As New YoutubeClient
    Public VideoStreams As IReadOnlyList(Of VideoStreamInfo)
    Public MyVideo As Video
    Public Event DisposingData(Control As Control)
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
        Dim NewBox As New DomainUpDown With {
            .Location = DudPlacholder.Location,
            .BackColor = DudPlacholder.BackColor,
            .ForeColor = DudPlacholder.ForeColor,
            .BorderStyle = BorderStyle.None,
            .Size = DudPlacholder.Size,
            .Name = "DudQualities"}




        Dim InfoStreams As MediaStreamInfoSet = Await Client.GetVideoMediaStreamInfosAsync(vid.Id)
        VideoStreams = InfoStreams.Video
        Dim qualiychk As New List(Of String)
        For Each qual In InfoStreams.Video
            Dim chstr As String = qual.VideoQualityLabel & qual.Framerate
            If Not qualiychk.Contains(chstr) Then
                qualiychk.Add(chstr)
                NewBox.Items.Add(qual.VideoQualityLabel & "p @ " & qual.Framerate & "fps")
            End If
        Next
        NewBox.SelectedIndex = 0
        DudPlacholder.Hide()
        DudPlacholder.Dispose()
        Me.Controls.Add(NewBox)
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

End Class
