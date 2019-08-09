<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class HomeMenuControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.PbLogo = New System.Windows.Forms.PictureBox()
        Me.PbBtnGithub = New System.Windows.Forms.PictureBox()
        Me.MouseOverAnimator = New System.ComponentModel.BackgroundWorker()
        Me.PbBtnExit = New System.Windows.Forms.PictureBox()
        Me.PbBtnSettings = New System.Windows.Forms.PictureBox()
        Me.PbBtnVideo = New System.Windows.Forms.PictureBox()
        Me.PbBtnMusic = New System.Windows.Forms.PictureBox()
        CType(Me.PbLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PbBtnGithub, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PbBtnExit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PbBtnSettings, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PbBtnVideo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PbBtnMusic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PbLogo
        '
        Me.PbLogo.BackColor = System.Drawing.Color.Transparent
        Me.PbLogo.Image = Global.YoutubeDownloader.My.Resources.Resources.TopBanner1_Blue
        Me.PbLogo.Location = New System.Drawing.Point(3, 3)
        Me.PbLogo.Name = "PbLogo"
        Me.PbLogo.Size = New System.Drawing.Size(234, 46)
        Me.PbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PbLogo.TabIndex = 4
        Me.PbLogo.TabStop = False
        '
        'PbBtnGithub
        '
        Me.PbBtnGithub.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PbBtnGithub.BackColor = System.Drawing.Color.Transparent
        Me.PbBtnGithub.Image = Global.YoutubeDownloader.My.Resources.Resources.Github_Blue
        Me.PbBtnGithub.Location = New System.Drawing.Point(3, 458)
        Me.PbBtnGithub.Name = "PbBtnGithub"
        Me.PbBtnGithub.Size = New System.Drawing.Size(37, 35)
        Me.PbBtnGithub.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PbBtnGithub.TabIndex = 5
        Me.PbBtnGithub.TabStop = False
        '
        'PbBtnExit
        '
        Me.PbBtnExit.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PbBtnExit.BackColor = System.Drawing.Color.Transparent
        Me.PbBtnExit.Image = Global.YoutubeDownloader.My.Resources.Resources.ExitMenuicon_Blue
        Me.PbBtnExit.Location = New System.Drawing.Point(463, 253)
        Me.PbBtnExit.Name = "PbBtnExit"
        Me.PbBtnExit.Size = New System.Drawing.Size(186, 175)
        Me.PbBtnExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PbBtnExit.TabIndex = 3
        Me.PbBtnExit.TabStop = False
        '
        'PbBtnSettings
        '
        Me.PbBtnSettings.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PbBtnSettings.BackColor = System.Drawing.Color.Transparent
        Me.PbBtnSettings.Image = Global.YoutubeDownloader.My.Resources.Resources.SettingsmenuIcon_Blue
        Me.PbBtnSettings.Location = New System.Drawing.Point(255, 253)
        Me.PbBtnSettings.Name = "PbBtnSettings"
        Me.PbBtnSettings.Size = New System.Drawing.Size(186, 175)
        Me.PbBtnSettings.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PbBtnSettings.TabIndex = 2
        Me.PbBtnSettings.TabStop = False
        '
        'PbBtnVideo
        '
        Me.PbBtnVideo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PbBtnVideo.BackColor = System.Drawing.Color.Transparent
        Me.PbBtnVideo.Image = Global.YoutubeDownloader.My.Resources.Resources.VideoDownloaderMenuicon_Blue
        Me.PbBtnVideo.Location = New System.Drawing.Point(463, 72)
        Me.PbBtnVideo.Name = "PbBtnVideo"
        Me.PbBtnVideo.Size = New System.Drawing.Size(186, 175)
        Me.PbBtnVideo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PbBtnVideo.TabIndex = 1
        Me.PbBtnVideo.TabStop = False
        '
        'PbBtnMusic
        '
        Me.PbBtnMusic.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PbBtnMusic.BackColor = System.Drawing.Color.Transparent
        Me.PbBtnMusic.Image = Global.YoutubeDownloader.My.Resources.Resources.MusicDownloadericon_Blue
        Me.PbBtnMusic.Location = New System.Drawing.Point(255, 72)
        Me.PbBtnMusic.Name = "PbBtnMusic"
        Me.PbBtnMusic.Size = New System.Drawing.Size(186, 175)
        Me.PbBtnMusic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PbBtnMusic.TabIndex = 0
        Me.PbBtnMusic.TabStop = False
        '
        'HomeMenuControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.BackgroundImage = Global.YoutubeDownloader.My.Resources.Resources.GreyBacker1
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controls.Add(Me.PbBtnExit)
        Me.Controls.Add(Me.PbBtnSettings)
        Me.Controls.Add(Me.PbBtnMusic)
        Me.Controls.Add(Me.PbBtnVideo)
        Me.Controls.Add(Me.PbBtnGithub)
        Me.Controls.Add(Me.PbLogo)
        Me.DoubleBuffered = True
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(114, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.Name = "HomeMenuControl"
        Me.Size = New System.Drawing.Size(871, 496)
        CType(Me.PbLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PbBtnGithub, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PbBtnExit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PbBtnSettings, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PbBtnVideo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PbBtnMusic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PbLogo As PictureBox
    Friend WithEvents PbBtnGithub As PictureBox
    Friend WithEvents MouseOverAnimator As System.ComponentModel.BackgroundWorker
    Friend WithEvents PbBtnExit As PictureBox
    Friend WithEvents PbBtnSettings As PictureBox
    Friend WithEvents PbBtnVideo As PictureBox
    Friend WithEvents PbBtnMusic As PictureBox
End Class
