Imports YoutubeDownloader.DownloaderInterface
Public Class SettingsMenuControl
    Public AllowUpdates As Boolean = False
    Private RenderImage As Image = Nothing

    Public Sub New()
        InitializeComponent()
        NudMaxDiff.Value = TrackLogic.MaxDurationDifferance
        NudMaxRet.Value = TrackLogic.MaxDownloadRetries

        TxtVideoExt.Text = SQLClient.GetSettingsValue("Video_DefaultExtension")
        TxtSpotifyClient.Text = SQLClient.GetSettingsValue("Spotify_ID")
        Dim sectxt As String = ""
        For i As Integer = 1 To SQLClient.GetSettingsValue("Spotify_Secret").Length
            sectxt = sectxt & "~"
        Next
        txtSpotifySecret.Text = sectxt

        CbUseBackground.Checked = SQLClient.GetSettingsValue("Interface_UseCustomBackground")
        TBTransparency.Value = SQLClient.GetSettingsValue("Interface_BackgroundTransparency")
        Dim inps As String = SQLClient.GetSettingsValue("Interface_BackgroundColour")
        Console.WriteLine(inps)

        Dim selected As String = SQLClient.GetSettingsValue("Interface_Style")
        If DudTheme.Items.Contains(selected) Then
            DudTheme.Text = selected
            DudTheme.SelectedItem = selected
            DudTheme.SelectedIndex = DudTheme.Items.IndexOf(selected)
        Else
            selected = "Complete"
            DudTheme.Text = selected
            DudTheme.SelectedItem = selected
            DudTheme.SelectedIndex = DudTheme.Items.IndexOf(selected)
        End If




        VideoLogic.DefaultExtension = TxtVideoExt.Text

        Dim imgs As String = SQLClient.GetSettingsValue("Interface_BackgroundImage")
        If imgs.Length > 1 Then
            RenderImage = Image.FromStream(New IO.MemoryStream(System.Convert.FromBase64String(imgs)))
        End If

        Dim vals As New List(Of String)
        For Each RGBPlace In inps.Split(",")
            vals.Add(RGBPlace.Trim(" "))
        Next
        Dim bkg As Color = Color.FromArgb(255, vals(0), vals(1), vals(2))
        PbBackgroundColour.BackColor = bkg
        Redraw()
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
        PatchSetting("Music_MaxTrackDifference", NudMaxDiff.Value)
    End Sub

    Private Sub NudMaxRet_ValueChanged(sender As Object, e As EventArgs) Handles NudMaxRet.ValueChanged
        PatchSetting("Music_MaxRetires", NudMaxRet.Value)
    End Sub


    Public Sub PatchSetting(Key As String, Value As String)
        If AllowUpdates Then
            DownloaderInterface.SQLClient.UpdateSettingsKey(Key, Value)
        Else
            Console.WriteLine("Patch ignored; Patches are currently disabled.")
        End If
    End Sub

    Private Sub TBTransparency_Scroll(sender As Object, e As EventArgs) Handles TBTransparency.Scroll
        lbltrans.Text = $"Background Transparency: {TBTransparency.Value}%"
        Redraw()
    End Sub

    Public Sub Redraw()
        If Not IsNothing(RenderImage) Then
            Dim Renderer As New BackgroundRenderer(PbBackgroundColour.BackColor, RenderImage, TBTransparency.Value)
            PbPreview.Image = Renderer.Render
        Else
            Dim Renderer As New BackgroundRenderer(PbBackgroundColour.BackColor, New Bitmap(PbPreview.Size.Width, PbPreview.Size.Height), TBTransparency.Value)
            PbPreview.Image = Renderer.Render
        End If
    End Sub

    Private Sub BtnSetBackground_Click(sender As Object, e As EventArgs) Handles BtnSetBackground.Click
        Dim res As DialogResult = CDColour.ShowDialog
        If res = DialogResult.OK Then
            PbBackgroundColour.BackColor = CDColour.Color
        End If
        Redraw()
    End Sub

    Private Sub BtnSelectImage_Click(sender As Object, e As EventArgs) Handles BtnSelectImage.Click
        Dim res As DialogResult = OFDImage.ShowDialog
        If res = DialogResult.OK Then
            RenderImage = Image.FromFile(OFDImage.FileName)
        End If
        Redraw()
    End Sub

    Private Sub ApplyBase() Handles BtnSave.Click
        LoadInt()

        PatchSetting("Interface_UseCustomBackground", CbUseBackground.Checked.ToString)
        PatchSetting("Interface_BackgroundTransparency", TBTransparency.Value)
        PatchSetting("Interface_BackgroundColour", $"{PbBackgroundColour.BackColor.R}, {PbBackgroundColour.BackColor.G}, {PbBackgroundColour.BackColor.B}")
        PatchSetting("Interface_Style", DudTheme.Text)

        If IsNothing(RenderImage) Then
            PatchSetting("Interface_BackgroundImage", "")
        Else
            Dim mems As New IO.MemoryStream
            RenderImage.Save(mems, Imaging.ImageFormat.Png)
            mems.Flush()
            Dim savestr As String = Convert.ToBase64String(mems.ToArray)
            PatchSetting("Interface_BackgroundImage", savestr)
        End If
    End Sub
    Public Sub LoadInt()
        If CbUseBackground.Checked Then
            Dim rndimg As Image = Nothing
            If Not IsNothing(RenderImage) Then
                Dim Renderer As New BackgroundRenderer(PbBackgroundColour.BackColor, RenderImage, TBTransparency.Value)
                rndimg = Renderer.Render
            Else
                Dim Renderer As New BackgroundRenderer(PbBackgroundColour.BackColor, New Bitmap(PbPreview.Size.Width, PbPreview.Size.Height), TBTransparency.Value)
                rndimg = Renderer.Render
            End If


            MusicInterface.FlowItems.BackColor = Color.Transparent
            VideoInterface.FlowItems.BackColor = Color.Transparent
            MusicInterface.FlowItems.BackgroundImage = Nothing
            VideoInterface.FlowItems.BackgroundImage = Nothing

            Me.BackgroundImage = rndimg
            MusicInterface.BackgroundImage = rndimg
            VideoInterface.BackgroundImage = rndimg
            MainInterface.BackgroundImage = rndimg
            Dim DefaultBackColor As Color = Color.FromArgb(255, 44, 47, 51)
            Select Case DudTheme.Text
                Case "Complete"
                    MusicInterface.FlowItems.BackColor = Color.Transparent
                    VideoInterface.FlowItems.BackColor = Color.Transparent

                    MusicInterface.GroupBox1.BackColor = Color.Transparent
                    VideoInterface.GroupBox1.BackColor = Color.Transparent

                    MusicInterface.FlowItems.BackgroundImage = Nothing
                    VideoInterface.FlowItems.BackgroundImage = Nothing
                Case "Partial - Default"
                    MusicInterface.FlowItems.BackColor = DefaultBackColor
                    VideoInterface.FlowItems.BackColor = DefaultBackColor

                    MusicInterface.GroupBox1.BackColor = Color.Transparent
                    VideoInterface.GroupBox1.BackColor = Color.Transparent

                    MusicInterface.FlowItems.BackgroundImage = My.Resources.GreyBacker1
                    VideoInterface.FlowItems.BackgroundImage = My.Resources.GreyBacker1
                Case "Partial - Solid"
                    MusicInterface.FlowItems.BackColor = DefaultBackColor
                    VideoInterface.FlowItems.BackColor = DefaultBackColor

                    MusicInterface.GroupBox1.BackColor = Color.Transparent
                    VideoInterface.GroupBox1.BackColor = Color.Transparent

                    MusicInterface.FlowItems.BackgroundImage = Nothing
                    VideoInterface.FlowItems.BackgroundImage = Nothing
                Case "Drop - Default"
                    MusicInterface.FlowItems.BackColor = DefaultBackColor
                    VideoInterface.FlowItems.BackColor = DefaultBackColor

                    MusicInterface.GroupBox1.BackColor = DefaultBackColor
                    VideoInterface.GroupBox1.BackColor = DefaultBackColor

                    MusicInterface.FlowItems.BackgroundImage = My.Resources.GreyBacker1
                    VideoInterface.FlowItems.BackgroundImage = My.Resources.GreyBacker1
                Case "Drop - Solid"
                    MusicInterface.FlowItems.BackColor = DefaultBackColor
                    VideoInterface.FlowItems.BackColor = DefaultBackColor

                    MusicInterface.GroupBox1.BackColor = DefaultBackColor
                    VideoInterface.GroupBox1.BackColor = DefaultBackColor

                    MusicInterface.FlowItems.BackgroundImage = Nothing
                    VideoInterface.FlowItems.BackgroundImage = Nothing

            End Select


        Else
            Me.BackgroundImage = Nothing
            MainInterface.BackgroundImage = Nothing
            MusicInterface.FlowItems.BackgroundImage = My.Resources.GreyBacker1
            VideoInterface.BackgroundImage = My.Resources.GreyBacker1
            MusicInterface.FlowItems.BackgroundImage = My.Resources.GreyBacker1
            VideoInterface.BackgroundImage = My.Resources.GreyBacker1

        End If
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        PbBackgroundColour.BackColor = Color.FromArgb(255, 44, 47, 51)
        RenderImage = Nothing
        TBTransparency.Value = 100
        lbltrans.Text = "Background Transparency: 100%"
        ApplyBase()
        Redraw()
    End Sub
    Public Sub ApplyThemes()
        LoadInt()
    End Sub

    Private Sub DudTheme_SelectedItemChanged(sender As Object, e As EventArgs) Handles DudTheme.SelectedItemChanged
    End Sub

    Private Sub TxtVideoExt_TextChanged(sender As Object, e As EventArgs) Handles TxtVideoExt.TextChanged
        If Not BtnSaveChanges.Visible Then
            BtnSaveChanges.Show()
        End If
    End Sub

    Private Sub TxtSpotifyClient_TextChanged(sender As Object, e As EventArgs) Handles TxtSpotifyClient.TextChanged
        If Not BtnSaveChanges.Visible Then
            BtnSaveChanges.Show()
        End If
    End Sub

    Private Sub txtSpotifySecret_TextChanged(sender As Object, e As EventArgs) Handles txtSpotifySecret.TextChanged
        If Not BtnSaveChanges.Visible Then
            BtnSaveChanges.Show()
        End If
    End Sub

    Private Sub BtnSaveChanges_Click(sender As Object, e As EventArgs) Handles BtnSaveChanges.Click
        PatchSetting("Video_DefaultExtension", TxtVideoExt.Text)
        PatchSetting("Spotify_ID", TxtSpotifyClient.Text)
        If Not txtSpotifySecret.Text.Contains("~") Then
            PatchSetting("Spotify_Secret", txtSpotifySecret.Text)
        End If
        BtnSaveChanges.Hide()
    End Sub

    Private Sub SettingsMenuControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BtnSaveChanges.Hide()
    End Sub

    Private Sub BtnInstallTypes_Click(sender As Object, e As EventArgs) Handles BtnInstallTypes.Click
        Dim proc As New ProcessStartInfo With {.FileName = "YouTubeDownloader.exe", .Arguments = "-install", .UseShellExecute = True, .Verb = "runas"}
        Try
            Process.Start(proc)
        Catch ex As Exception
        End Try
    End Sub
End Class
