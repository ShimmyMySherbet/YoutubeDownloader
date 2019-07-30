Imports NAudio.Wave
Imports YoutubeExplode.Models
Imports Xabe.FFmpeg
Public Class Audi
    Dim Downloading As Boolean = False
    Public Video As YoutubeExplode.Models.Video
    Public SpotifyTrack As SpotifyAPI.Web.Models.FullTrack
    Public MexData As MexMediaInfo
    Public WebClient As New Net.WebClient

    Public UiThread As Threading.Thread
    Public UiTaskScehule As TaskScheduler
    Public UiTaskfactory As TaskFactory = New TaskFactory(TaskScheduler.FromCurrentSynchronizationContext)

    Private OutputDevice As WaveOutEvent
    Private AudioFile As AudioFileReader

    Private Client As New YoutubeExplode.YoutubeClient

    Public Event DisposingData(Control As Control)

    Public SongTitle As String
    Public SongArtist As String

    Public IsFromPlaylist As Boolean

    Private WithEvents WorkaroundTimer As New Timer With {.Interval = 100}

#Region "Thread Glicth Woraround"
    'Strange glitch from when a video was added from a playlist, whenever the thread would attempt to add a task to the UI Thread's Task factory,
    'The calling thread would immediatley exit with no error or stop code.
    'try catches yeiled no result
    Private Enum PipeType
        Setup = 0
        Progress = 1
        Close = 2
        idle = -1
        Finish = 4
        TriggerError = -10
        TriggerWarning = -9
    End Enum
    Dim TypePipe As PipeType = -1
    Public Sub WorkaroundTick() Handles WorkaroundTimer.Tick
        Select Case TypePipe
            Case PipeType.Progress
                PbProgress.PerformStep()
            Case PipeType.Finish
                PbProgress.Value = PbProgress.Maximum
                WorkaroundTimer.Stop()
            Case PipeType.TriggerError
                PbProgress.Value = PbProgress.Maximum
                WorkaroundTimer.Stop()
                ProgressbarModification.SetState(PbProgress, 2)
            Case PipeType.TriggerWarning
                PbProgress.Value = 3
                ProgressbarModification.SetState(PbProgress, 3)
        End Select
        TypePipe = -1
    End Sub
#End Region


    Public Sub New(Data As AudioControlData)
        InitializeComponent()
        PbProgress.Hide()
        Video = Data.Video
        SpotifyTrack = Data.SpotifyTrack
        MexData = Data.MexData
        IsFromPlaylist = Data.IsFromPlaylist
        lblYTtitle.Text = Data.Video.Title
        lblytChannel.Text = Data.Video.Author
        PbIcon1.Image = My.Resources.YouTube
        Dim IconUrl As String = ""
        If IsNothing(Data.SpotifyTrack) Then
            BtnPlayAudio.Hide()
            LblArtist.Text = Data.MexData.Artist
            lblSpotifySong.Text = Data.MexData.Name
            SongArtist = Data.MexData.Artist
            SongTitle = Data.MexData.Name
            LblAlbum.Text = ""
            IconUrl = Data.Video.Thumbnails.MediumResUrl
        Else
            Console.WriteLine(Data.SpotifyTrack.Album.ReleaseDate)
            Pbicon2.Image = My.Resources.Spotify
            LblAlbum.Text = "Album: " & Data.SpotifyTrack.Album.Name
            LblArtist.Text = "Artist: " & Data.SpotifyTrack.Artists(0).Name
            SongArtist = Data.SpotifyTrack.Artists(0).Name
            lblSpotifySong.Text = "Song: " & Data.SpotifyTrack.Name
            SongTitle = Data.SpotifyTrack.Name
            IconUrl = Data.SpotifyTrack.Album.Images(0).Url
            If Data.SpotifyTrack.PreviewUrl = "" Then
                BtnPlayAudio.Hide()
            End If
        End If
        If IconUrl = "" Then
            PbArtwork.Image = My.Resources.YouTube
        Else
            PbArtwork.Image = My.Resources.Loading1
            Dim Artworkdownloadthread As New Threading.Thread(Sub(Url As String)
                                                                  Dim MyClient As New Net.WebClient
                                                                  Dim resimage As Image = Image.FromStream(New IO.MemoryStream(MyClient.DownloadData(Url)))
                                                                  PbArtwork.Image = resimage
                                                              End Sub)
            Artworkdownloadthread.Start(IconUrl)
        End If
    End Sub
    Public Async Sub getVideoBack()
        Video = Await Client.GetVideoAsync(Video.Id)
        PbArtwork.Show()
    End Sub
    Private Sub BtnPlayAudio_Click(sender As Object, e As EventArgs) Handles BtnPlayAudio.Click
        If BtnPlayAudio.Text = "Play" Then
            Dim DownloadThread As New Threading.Thread(AddressOf DownloadAudio)
            DownloadThread.Start(SpotifyTrack.PreviewUrl)
        ElseIf BtnPlayAudio.Text = "Stop" Then
            OutputDevice.Stop()
        End If
    End Sub
    Public Sub DownloadAudio(url As String)
        If url <> "" Then
            Dim address As Uri
            Dim filename As String = ""
            address = New Uri(url)
            filename = System.IO.Path.GetFileName(address.LocalPath)
            If Not IO.File.Exists("AudioCache\" & filename) Then
                BtnPlayAudio.Text = "Downloading..."
                IO.File.WriteAllBytes("AudioCache\" & filename, WebClient.DownloadData(url))
            End If
            If IsNothing(OutputDevice) Then
                OutputDevice = New WaveOutEvent()
                AddHandler OutputDevice.PlaybackStopped, Sub()
                                                             BtnPlayAudio.Text = "Play"
                                                             AudioFile.Position = 0
                                                         End Sub
            End If
            If IsNothing(AudioFile) Then
                AudioFile = New AudioFileReader("AudioCache\" & filename)
                OutputDevice.Init(AudioFile)
            End If
            BtnPlayAudio.Text = "Stop"
            OutputDevice.Play()
        End If
    End Sub
    Public Sub DisposeData()
        Video = Nothing
        SpotifyTrack = Nothing
        MexData = Nothing
        If Not IsNothing(WebClient) Then
            WebClient.Dispose()
        End If
        If Not IsNothing(OutputDevice) Then
            OutputDevice.Dispose()
        End If
        If Not IsNothing(AudioFile) Then
            AudioFile.Dispose()
        End If
        If Not IsNothing(Me) Then
            Me.Dispose()
        End If
        RaiseEvent DisposingData(Me)
    End Sub
    Private Sub PbBtnClose_Click(sender As Object, e As EventArgs) Handles PbBtnClose.Click
        DisposeData()
    End Sub
    Public Sub InvokeTrackDownload()
        If Not Downloading Then
            Console.WriteLine("Invoker starting download")
            Dim DownloadThread As New Threading.Thread(AddressOf DownloadTrack)
            DownloadThread.Start()
        Else
            Console.WriteLine("Invokerfailed to start download: Already downloading")

        End If
    End Sub





    Private Event ShowDat()
    Public Async Sub SD() Handles Me.ShowDat
        Await Me.UiTaskfactory.StartNew(Sub()
                                            Downloading = True
                                            PbProgress.Maximum = 5
                                            PbProgress.Value = 0
                                            PbProgress.Step = 1
                                            PbProgress.Show()
                                        End Sub)

    End Sub

    Private Event progress()
    Public Async Sub SPD() Handles Me.progress
        Await Me.UiTaskfactory.StartNew(Sub()
                                            PbProgress.PerformStep()
                                        End Sub)
    End Sub
    Private Event Hideprog()
    Public Async Sub SPHD() Handles Me.progress
        Await Me.UiTaskfactory.StartNew(Sub()
                                            PbProgress.Hide()
                                        End Sub)
    End Sub





    Private Async Sub DownloadTrack()
        Console.WriteLine("Starting download...")
        Downloading = True
        If Not IsFromPlaylist Then
            Await UiTaskfactory.StartNew(Sub()
                                             PbProgress.Maximum = 5
                                             PbProgress.Value = 0
                                             PbProgress.Step = 1
                                             PbProgress.Show()
                                         End Sub)
        End If



        Dim VideoID As String = Client.ParseVideoId(Video.GetUrl)
        Console.WriteLine("Downloading video with id of {0}", VideoID)
        If Not IsFromPlaylist Then
            Await UiTaskfactory.StartNew(Sub()
                                             PbProgress.PerformStep()
                                         End Sub)
        Else
            TypePipe = PipeType.Progress
        End If

        Dim SteaminfoSet As MediaStreams.MediaStreamInfoSet = Await Client.GetVideoMediaStreamInfosAsync(VideoID)
        If Not IsFromPlaylist Then
            Await UiTaskfactory.StartNew(Sub()
                                             PbProgress.PerformStep()
                                         End Sub)
        Else
            TypePipe = PipeType.Progress
        End If


        Console.WriteLine("Streams fetched")
        Dim auinfo = SteaminfoSet.Audio(0)
        Console.WriteLine("Audio stream fetched")
        Console.WriteLine(auinfo.Bitrate)
        Dim ext As String = "unknown"
        Select Case auinfo.AudioEncoding
            Case MediaStreams.AudioEncoding.Aac
                ext = "aac"
            Case MediaStreams.AudioEncoding.Opus
                ext = "opus"
            Case MediaStreams.AudioEncoding.Vorbis
                ext = "vorbis"
        End Select

        Console.WriteLine("ext: {0}", ext)
        Console.WriteLine("Downloading...")

        Dim Filename As String = ""
        If SongArtist = "" Then
            Filename = Video.Title
        Else
            Filename = SongArtist & " - " & SongTitle
        End If
        Filename = ScrubFilename(Filename)

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
        If Not IsFromPlaylist Then
            Await UiTaskfactory.StartNew(Sub()
                                             PbProgress.PerformStep()
                                         End Sub)
        Else
            TypePipe = PipeType.Progress


        End If


        Dim DownloadTries As Integer = 0

RetryDownload:
        DownloadTries = DownloadTries + 1
        Dim ExitedWithError As Boolean = False
        Try
            Dim Mp3Out As String = "Music\" & Filename & ".mp3"
            If IO.File.Exists(Mp3Out) Then
                IO.File.Delete(Mp3Out)
            End If
            Console.WriteLine("Conversion Start")
            Dim AudioConversion As IConversion = Conversion.Convert("Downloads\" & Filename & "." & ext, Mp3Out)
            AudioConversion.SetAudioBitrate(auinfo.Bitrate)
            AudioConversion.UseHardwareAcceleration(Enums.HardwareAccelerator.Auto, Enums.VideoCodec.H264_cuvid, Enums.VideoCodec.H264_cuvid)
            Dim result As Model.IConversionResult = Await AudioConversion.Start()
            If Not IsFromPlaylist Then

                Await UiTaskfactory.StartNew(Sub()
                                                 PbProgress.PerformStep()
                                             End Sub)
            Else
                TypePipe = PipeType.Progress


            End If


            Console.WriteLine("Completed Integer {0} secconds", result.Duration.TotalSeconds)
            If result.Success Then
                Console.WriteLine("Conversion Successfull.")
            Else
                Console.WriteLine("Conversion Failiure.")
            End If
            Console.WriteLine("Conversion Finished  ")

            Dim ID3File As TagLib.File = TagLib.File.Create(Mp3Out)
            TagLib.Id3v2.Tag.DefaultVersion = 3
            TagLib.Id3v2.Tag.ForceDefaultVersion = True
            ID3File.Tag.Title = SongTitle
            ID3File.Tag.AlbumArtists = {SongArtist}
            If Not IsNothing(SpotifyTrack) Then
                ID3File.Tag.Album = SpotifyTrack.Album.Name
                ID3File.Tag.Year = SpotifyTrack.Album.ReleaseDate.Split("-")(0)
                Dim ImageFile As String = "ImageCache\" & Filename & ".jpeg"
                PbArtwork.Image.Save(ImageFile)
                Dim picture As TagLib.Picture = New TagLib.Picture(ImageFile)
                'create Id3v2 Picture Frame
                Dim albumCoverPictFrame As New TagLib.Id3v2.AttachedPictureFrame(picture)
                albumCoverPictFrame.MimeType = System.Net.Mime.MediaTypeNames.Image.Jpeg
                'set the type of picture (front cover)
                albumCoverPictFrame.Type = TagLib.PictureType.FrontCover
                'Id3v2 allows more than one type of image, just one needed
                Dim pictFrames() As TagLib.IPicture = {albumCoverPictFrame}
                ID3File.Tag.Pictures = pictFrames 'set the pictures in the tag
            End If


            ID3File.Save()

            If Not IsFromPlaylist Then
                Await UiTaskfactory.StartNew(Sub()
                                                 PbProgress.PerformStep()
                                             End Sub)
                Threading.Thread.Sleep(500)
                Await UiTaskfactory.StartNew(Sub()
                                                 PbProgress.Hide()
                                             End Sub)
            Else
                TypePipe = PipeType.Finish
            End If
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            Console.WriteLine(ex.StackTrace)
            Console.WriteLine(ex.Source)
            ExitedWithError = True
        End Try
        If ExitedWithError Then
            If DownloadTries >= ProgramConfigurationBase.TrackLogic.MaxDownloadRetries Then
                If IsFromPlaylist Then
                    TypePipe = PipeType.TriggerError
                Else
                    Await UiTaskfactory.StartNew(Sub()
                                                     PbProgress.Value = PbProgress.Maximum
                                                     WorkaroundTimer.Stop()
                                                     ProgressbarModification.SetState(PbProgress, 2)
                                                 End Sub)
                End If
            Else
                If IsFromPlaylist Then
                    TypePipe = PipeType.TriggerWarning
                Else
                    Await UiTaskfactory.StartNew(Sub()
                                                     PbProgress.Value = 3
                                                     ProgressbarModification.SetState(PbProgress, 3)
                                                 End Sub)
                End If
                Console.WriteLine("AN ERROR OCCOURED! RETRYING DOWNLOAD.")
                Threading.Thread.Sleep(2000)
                GoTo RetryDownload
            End If
        End If
        Downloading = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnDownload.Click
        If Not Downloading Then
            If IsFromPlaylist Then
                PbProgress.Maximum = 5
                PbProgress.Value = 0
                PbProgress.Step = 1
                ProgressbarModification.SetState(PbProgress, 1)
                PbProgress.Show()
                WorkaroundTimer.Start()
            End If
            Dim DownloadThread As New Threading.Thread(AddressOf DownloadTrack)
            DownloadThread.Start()
        End If
    End Sub


    Public Sub WorkerComplete() Handles BackgroundDownloader.RunWorkerCompleted
        PbProgress.Hide()
    End Sub
    Public Sub Workerprogress() Handles BackgroundDownloader.ProgressChanged
        PbProgress.PerformStep()
    End Sub

    Private Sub PbIcon1_Click(sender As Object, e As EventArgs) Handles PbIcon1.Click
        Process.Start(Video.GetUrl)
    End Sub

    Private Sub Pbicon2_Click(sender As Object, e As EventArgs) Handles Pbicon2.Click
        If Not IsNothing(SpotifyTrack) Then
            If SpotifyTrack.Uri <> "" Then
                Process.Start(SpotifyTrack.Uri)
            End If
        End If
    End Sub

    Public Function ScrubFilename(Filename As String)
        Return Filename.Replace("/", "").Replace("\", "").Replace("|", "").Replace("?", "").Replace("<", "").Replace(">", "").Replace(":", "").Replace("""", "").Replace("*", "")
    End Function


End Class
Public Class AudioControlData
    Public Video As YoutubeExplode.Models.Video
    Public SpotifyTrack As SpotifyAPI.Web.Models.FullTrack
    Public MexData As MexMediaInfo
    Public IsFromPlaylist As Boolean = False
    Public Sub New(Vid As YoutubeExplode.Models.Video, Track As SpotifyAPI.Web.Models.FullTrack, TitleData As MexMediaInfo, Optional Playlist As Boolean = False)
        Video = Vid
        SpotifyTrack = Track
        MexData = TitleData
        IsFromPlaylist = Playlist
    End Sub
End Class