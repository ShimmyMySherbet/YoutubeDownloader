<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AudioEntry
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing Then
                Try
                    AudioFile.Dispose()
                    OutputDevice.Dispose()
                Catch ex As Exception
                End Try
            End If
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
        Me.components = New System.ComponentModel.Container()
        Me.lblYTtitle = New System.Windows.Forms.Label()
        Me.LblAlbum = New System.Windows.Forms.Label()
        Me.LblArtist = New System.Windows.Forms.Label()
        Me.BtnPlayAudio = New System.Windows.Forms.Button()
        Me.lblytChannel = New System.Windows.Forms.Label()
        Me.lblSpotifySong = New System.Windows.Forms.Label()
        Me.PbProgress = New System.Windows.Forms.ProgressBar()
        Me.btnDownload = New System.Windows.Forms.Button()
        Me.BackgroundDownloader = New System.ComponentModel.BackgroundWorker()
        Me.FlowButtons = New System.Windows.Forms.FlowLayoutPanel()
        Me.PbBtnEditMex = New System.Windows.Forms.PictureBox()
        Me.PbCrop = New System.Windows.Forms.PictureBox()
        Me.PbBtnClose = New System.Windows.Forms.PictureBox()
        Me.Pbicon2 = New System.Windows.Forms.PictureBox()
        Me.PbIcon1 = New System.Windows.Forms.PictureBox()
        Me.PbArtwork = New System.Windows.Forms.PictureBox()
        Me.CMSArtwork = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TSMIPasteArtwork = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMIRemoveArtwork = New System.Windows.Forms.ToolStripMenuItem()
        Me.FlowButtons.SuspendLayout()
        CType(Me.PbBtnEditMex, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PbCrop, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PbBtnClose, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pbicon2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PbIcon1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PbArtwork, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMSArtwork.SuspendLayout()
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
        Me.LblAlbum.Location = New System.Drawing.Point(59, 80)
        Me.LblAlbum.Name = "LblAlbum"
        Me.LblAlbum.Size = New System.Drawing.Size(71, 13)
        Me.LblAlbum.TabIndex = 2
        Me.LblAlbum.Text = "Spotify Album"
        '
        'LblArtist
        '
        Me.LblArtist.AutoSize = True
        Me.LblArtist.Location = New System.Drawing.Point(59, 61)
        Me.LblArtist.Name = "LblArtist"
        Me.LblArtist.Size = New System.Drawing.Size(65, 13)
        Me.LblArtist.TabIndex = 3
        Me.LblArtist.Text = "Spotify Artist"
        '
        'BtnPlayAudio
        '
        Me.BtnPlayAudio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnPlayAudio.Location = New System.Drawing.Point(3, 3)
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
        Me.lblSpotifySong.Location = New System.Drawing.Point(59, 43)
        Me.lblSpotifySong.Name = "lblSpotifySong"
        Me.lblSpotifySong.Size = New System.Drawing.Size(67, 13)
        Me.lblSpotifySong.TabIndex = 8
        Me.lblSpotifySong.Text = "Spotify Song"
        '
        'PbProgress
        '
        Me.PbProgress.Location = New System.Drawing.Point(70, 125)
        Me.PbProgress.Maximum = 40
        Me.PbProgress.Name = "PbProgress"
        Me.PbProgress.Size = New System.Drawing.Size(368, 15)
        Me.PbProgress.TabIndex = 10
        '
        'btnDownload
        '
        Me.btnDownload.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDownload.Location = New System.Drawing.Point(95, 3)
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
        'FlowButtons
        '
        Me.FlowButtons.Controls.Add(Me.BtnPlayAudio)
        Me.FlowButtons.Controls.Add(Me.btnDownload)
        Me.FlowButtons.Location = New System.Drawing.Point(59, 96)
        Me.FlowButtons.Name = "FlowButtons"
        Me.FlowButtons.Size = New System.Drawing.Size(297, 27)
        Me.FlowButtons.TabIndex = 13
        '
        'PbBtnEditMex
        '
        Me.PbBtnEditMex.Image = Global.YoutubeDownloader.My.Resources.Resources.ModifyData_Blue
        Me.PbBtnEditMex.Location = New System.Drawing.Point(47, 124)
        Me.PbBtnEditMex.Name = "PbBtnEditMex"
        Me.PbBtnEditMex.Size = New System.Drawing.Size(20, 20)
        Me.PbBtnEditMex.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PbBtnEditMex.TabIndex = 14
        Me.PbBtnEditMex.TabStop = False
        '
        'PbCrop
        '
        Me.PbCrop.Image = Global.YoutubeDownloader.My.Resources.Resources.CropAudio_Blue
        Me.PbCrop.Location = New System.Drawing.Point(25, 124)
        Me.PbCrop.Name = "PbCrop"
        Me.PbCrop.Size = New System.Drawing.Size(20, 20)
        Me.PbCrop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PbCrop.TabIndex = 12
        Me.PbCrop.TabStop = False
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
        Me.PbArtwork.ContextMenuStrip = Me.CMSArtwork
        Me.PbArtwork.Location = New System.Drawing.Point(444, 3)
        Me.PbArtwork.Name = "PbArtwork"
        Me.PbArtwork.Size = New System.Drawing.Size(163, 143)
        Me.PbArtwork.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PbArtwork.TabIndex = 0
        Me.PbArtwork.TabStop = False
        '
        'CMSArtwork
        '
        Me.CMSArtwork.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMIPasteArtwork, Me.TSMIRemoveArtwork})
        Me.CMSArtwork.Name = "CMSArtwork"
        Me.CMSArtwork.Size = New System.Drawing.Size(201, 70)
        '
        'TSMIPasteArtwork
        '
        Me.TSMIPasteArtwork.Name = "TSMIPasteArtwork"
        Me.TSMIPasteArtwork.Size = New System.Drawing.Size(200, 22)
        Me.TSMIPasteArtwork.Text = "Paste Artwork"
        '
        'TSMIRemoveArtwork
        '
        Me.TSMIRemoveArtwork.Name = "TSMIRemoveArtwork"
        Me.TSMIRemoveArtwork.Size = New System.Drawing.Size(200, 22)
        Me.TSMIRemoveArtwork.Text = "Remove pasted Artwork"
        '
        'AudioEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.PbBtnEditMex)
        Me.Controls.Add(Me.FlowButtons)
        Me.Controls.Add(Me.PbCrop)
        Me.Controls.Add(Me.PbProgress)
        Me.Controls.Add(Me.PbBtnClose)
        Me.Controls.Add(Me.lblSpotifySong)
        Me.Controls.Add(Me.Pbicon2)
        Me.Controls.Add(Me.PbIcon1)
        Me.Controls.Add(Me.lblytChannel)
        Me.Controls.Add(Me.LblArtist)
        Me.Controls.Add(Me.LblAlbum)
        Me.Controls.Add(Me.lblYTtitle)
        Me.Controls.Add(Me.PbArtwork)
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(114, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.Name = "AudioEntry"
        Me.Size = New System.Drawing.Size(608, 147)
        Me.FlowButtons.ResumeLayout(False)
        CType(Me.PbBtnEditMex, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PbCrop, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PbBtnClose, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pbicon2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PbIcon1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PbArtwork, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMSArtwork.ResumeLayout(False)
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
    Friend WithEvents PbCrop As PictureBox
    Friend WithEvents FlowButtons As FlowLayoutPanel
    Friend WithEvents PbBtnEditMex As PictureBox
    Friend WithEvents CMSArtwork As ContextMenuStrip
    Friend WithEvents TSMIPasteArtwork As ToolStripMenuItem
    Friend WithEvents TSMIRemoveArtwork As ToolStripMenuItem
End Class
