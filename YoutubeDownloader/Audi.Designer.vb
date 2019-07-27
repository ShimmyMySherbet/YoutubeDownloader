<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Audi
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
        Me.lblYTtitle = New System.Windows.Forms.Label()
        Me.LblAlbum = New System.Windows.Forms.Label()
        Me.LblArtist = New System.Windows.Forms.Label()
        Me.BtnPlayAudio = New System.Windows.Forms.Button()
        Me.lblytChannel = New System.Windows.Forms.Label()
        Me.lblSpotifySong = New System.Windows.Forms.Label()
        Me.Pbicon2 = New System.Windows.Forms.PictureBox()
        Me.PbIcon1 = New System.Windows.Forms.PictureBox()
        Me.PbArtwork = New System.Windows.Forms.PictureBox()
        Me.PbBtnClose = New System.Windows.Forms.PictureBox()
        Me.PbProgress = New System.Windows.Forms.ProgressBar()
        Me.btnDownload = New System.Windows.Forms.Button()
        Me.BackgroundDownloader = New System.ComponentModel.BackgroundWorker()
        CType(Me.Pbicon2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PbIcon1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PbArtwork, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PbBtnClose, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblYTtitle
        '
        Me.lblYTtitle.AutoSize = True
        Me.lblYTtitle.Location = New System.Drawing.Point(26, 3)
        Me.lblYTtitle.Name = "lblYTtitle"
        Me.lblYTtitle.Size = New System.Drawing.Size(100, 13)
        Me.lblYTtitle.TabIndex = 1
        Me.lblYTtitle.Text = "Youtube Video Title"
        '
        'LblAlbum
        '
        Me.LblAlbum.AutoSize = True
        Me.LblAlbum.Location = New System.Drawing.Point(55, 80)
        Me.LblAlbum.Name = "LblAlbum"
        Me.LblAlbum.Size = New System.Drawing.Size(71, 13)
        Me.LblAlbum.TabIndex = 2
        Me.LblAlbum.Text = "Spotify Album"
        '
        'LblArtist
        '
        Me.LblArtist.AutoSize = True
        Me.LblArtist.Location = New System.Drawing.Point(55, 61)
        Me.LblArtist.Name = "LblArtist"
        Me.LblArtist.Size = New System.Drawing.Size(65, 13)
        Me.LblArtist.TabIndex = 3
        Me.LblArtist.Text = "Spotify Artist"
        '
        'BtnPlayAudio
        '
        Me.BtnPlayAudio.Location = New System.Drawing.Point(51, 100)
        Me.BtnPlayAudio.Name = "BtnPlayAudio"
        Me.BtnPlayAudio.Size = New System.Drawing.Size(86, 23)
        Me.BtnPlayAudio.TabIndex = 4
        Me.BtnPlayAudio.Text = "Play"
        Me.BtnPlayAudio.UseVisualStyleBackColor = True
        '
        'lblytChannel
        '
        Me.lblytChannel.AutoSize = True
        Me.lblytChannel.Location = New System.Drawing.Point(32, 21)
        Me.lblytChannel.Name = "lblytChannel"
        Me.lblytChannel.Size = New System.Drawing.Size(119, 13)
        Me.lblytChannel.TabIndex = 5
        Me.lblytChannel.Text = "Youtube Video Channel"
        '
        'lblSpotifySong
        '
        Me.lblSpotifySong.AutoSize = True
        Me.lblSpotifySong.Location = New System.Drawing.Point(55, 43)
        Me.lblSpotifySong.Name = "lblSpotifySong"
        Me.lblSpotifySong.Size = New System.Drawing.Size(67, 13)
        Me.lblSpotifySong.TabIndex = 8
        Me.lblSpotifySong.Text = "Spotify Song"
        '
        'Pbicon2
        '
        Me.Pbicon2.Location = New System.Drawing.Point(3, 23)
        Me.Pbicon2.Name = "Pbicon2"
        Me.Pbicon2.Size = New System.Drawing.Size(20, 20)
        Me.Pbicon2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Pbicon2.TabIndex = 7
        Me.Pbicon2.TabStop = False
        '
        'PbIcon1
        '
        Me.PbIcon1.Location = New System.Drawing.Point(3, 2)
        Me.PbIcon1.Name = "PbIcon1"
        Me.PbIcon1.Size = New System.Drawing.Size(20, 20)
        Me.PbIcon1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PbIcon1.TabIndex = 6
        Me.PbIcon1.TabStop = False
        '
        'PbArtwork
        '
        Me.PbArtwork.Location = New System.Drawing.Point(444, 3)
        Me.PbArtwork.Name = "PbArtwork"
        Me.PbArtwork.Size = New System.Drawing.Size(163, 143)
        Me.PbArtwork.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PbArtwork.TabIndex = 0
        Me.PbArtwork.TabStop = False
        '
        'PbBtnClose
        '
        Me.PbBtnClose.Image = Global.YoutubeDownloader.My.Resources.Resources.CloseEntry
        Me.PbBtnClose.Location = New System.Drawing.Point(3, 124)
        Me.PbBtnClose.Name = "PbBtnClose"
        Me.PbBtnClose.Size = New System.Drawing.Size(21, 20)
        Me.PbBtnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PbBtnClose.TabIndex = 9
        Me.PbBtnClose.TabStop = False
        '
        'PbProgress
        '
        Me.PbProgress.Location = New System.Drawing.Point(51, 129)
        Me.PbProgress.Maximum = 40
        Me.PbProgress.Name = "PbProgress"
        Me.PbProgress.Size = New System.Drawing.Size(361, 15)
        Me.PbProgress.TabIndex = 10
        '
        'btnDownload
        '
        Me.btnDownload.Location = New System.Drawing.Point(143, 100)
        Me.btnDownload.Name = "btnDownload"
        Me.btnDownload.Size = New System.Drawing.Size(86, 23)
        Me.btnDownload.TabIndex = 11
        Me.btnDownload.Text = "Download"
        Me.btnDownload.UseVisualStyleBackColor = True
        '
        'BackgroundDownloader
        '
        Me.BackgroundDownloader.WorkerReportsProgress = True
        '
        'Audi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.btnDownload)
        Me.Controls.Add(Me.PbProgress)
        Me.Controls.Add(Me.PbBtnClose)
        Me.Controls.Add(Me.lblSpotifySong)
        Me.Controls.Add(Me.Pbicon2)
        Me.Controls.Add(Me.PbIcon1)
        Me.Controls.Add(Me.lblytChannel)
        Me.Controls.Add(Me.BtnPlayAudio)
        Me.Controls.Add(Me.LblArtist)
        Me.Controls.Add(Me.LblAlbum)
        Me.Controls.Add(Me.lblYTtitle)
        Me.Controls.Add(Me.PbArtwork)
        Me.Name = "Audi"
        Me.Size = New System.Drawing.Size(608, 147)
        CType(Me.Pbicon2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PbIcon1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PbArtwork, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PbBtnClose, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PbArtwork As PictureBox
    Friend WithEvents lblYTtitle As Label
    Friend WithEvents LblAlbum As Label
    Friend WithEvents LblArtist As Label
    Friend WithEvents BtnPlayAudio As Button
    Friend WithEvents lblytChannel As Label
    Friend WithEvents PbIcon1 As PictureBox
    Friend WithEvents Pbicon2 As PictureBox
    Friend WithEvents lblSpotifySong As Label
    Friend WithEvents PbBtnClose As PictureBox
    Friend WithEvents PbProgress As ProgressBar
    Friend WithEvents btnDownload As Button
    Friend WithEvents BackgroundDownloader As System.ComponentModel.BackgroundWorker
End Class
