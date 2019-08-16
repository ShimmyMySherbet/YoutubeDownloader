<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VideoEntry
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.LblTitle = New System.Windows.Forms.Label()
        Me.lblChannel = New System.Windows.Forms.Label()
        Me.LblLikes = New System.Windows.Forms.Label()
        Me.LblDuration = New System.Windows.Forms.Label()
        Me.btnDownload = New System.Windows.Forms.Button()
        Me.PbProgress = New System.Windows.Forms.ProgressBar()
        Me.PbFolder = New System.Windows.Forms.PictureBox()
        Me.PbIcnYoutube = New System.Windows.Forms.PictureBox()
        Me.PbBtnClose = New System.Windows.Forms.PictureBox()
        Me.PbArtwork = New System.Windows.Forms.PictureBox()
        Me.lblUploaded = New System.Windows.Forms.Label()
        Me.DudPlacholder = New System.Windows.Forms.DomainUpDown()
        CType(Me.PbFolder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PbIcnYoutube, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PbBtnClose, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PbArtwork, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LblTitle
        '
        Me.LblTitle.AutoSize = True
        Me.LblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTitle.Location = New System.Drawing.Point(29, 3)
        Me.LblTitle.Name = "LblTitle"
        Me.LblTitle.Size = New System.Drawing.Size(72, 15)
        Me.LblTitle.TabIndex = 12
        Me.LblTitle.Text = "{Video Title}"
        '
        'lblChannel
        '
        Me.lblChannel.AutoSize = True
        Me.lblChannel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChannel.Location = New System.Drawing.Point(56, 29)
        Me.lblChannel.Name = "lblChannel"
        Me.lblChannel.Size = New System.Drawing.Size(95, 15)
        Me.lblChannel.TabIndex = 13
        Me.lblChannel.Text = "{Video Channel}"
        '
        'LblLikes
        '
        Me.LblLikes.AutoSize = True
        Me.LblLikes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblLikes.Location = New System.Drawing.Point(56, 45)
        Me.LblLikes.Name = "LblLikes"
        Me.LblLikes.Size = New System.Drawing.Size(98, 15)
        Me.LblLikes.TabIndex = 14
        Me.LblLikes.Text = "{Likes}:{Dislikes}"
        '
        'LblDuration
        '
        Me.LblDuration.AutoSize = True
        Me.LblDuration.Location = New System.Drawing.Point(402, 127)
        Me.LblDuration.Name = "LblDuration"
        Me.LblDuration.Size = New System.Drawing.Size(85, 13)
        Me.LblDuration.TabIndex = 15
        Me.LblDuration.Text = "{Video Duration}"
        '
        'btnDownload
        '
        Me.btnDownload.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDownload.Location = New System.Drawing.Point(59, 103)
        Me.btnDownload.Name = "btnDownload"
        Me.btnDownload.Size = New System.Drawing.Size(86, 23)
        Me.btnDownload.TabIndex = 17
        Me.btnDownload.Text = "Download"
        Me.btnDownload.UseVisualStyleBackColor = True
        '
        'PbProgress
        '
        Me.PbProgress.Location = New System.Drawing.Point(59, 131)
        Me.PbProgress.Maximum = 40
        Me.PbProgress.Name = "PbProgress"
        Me.PbProgress.Size = New System.Drawing.Size(334, 13)
        Me.PbProgress.TabIndex = 18
        '
        'PbFolder
        '
        Me.PbFolder.Image = Global.YoutubeDownloader.My.Resources.Resources.Folder_Blue
        Me.PbFolder.Location = New System.Drawing.Point(26, 127)
        Me.PbFolder.Name = "PbFolder"
        Me.PbFolder.Size = New System.Drawing.Size(21, 20)
        Me.PbFolder.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PbFolder.TabIndex = 19
        Me.PbFolder.TabStop = False
        '
        'PbIcnYoutube
        '
        Me.PbIcnYoutube.Image = Global.YoutubeDownloader.My.Resources.Resources.YouTube
        Me.PbIcnYoutube.Location = New System.Drawing.Point(3, 3)
        Me.PbIcnYoutube.Name = "PbIcnYoutube"
        Me.PbIcnYoutube.Size = New System.Drawing.Size(20, 20)
        Me.PbIcnYoutube.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PbIcnYoutube.TabIndex = 11
        Me.PbIcnYoutube.TabStop = False
        '
        'PbBtnClose
        '
        Me.PbBtnClose.Image = Global.YoutubeDownloader.My.Resources.Resources.CloseEntry
        Me.PbBtnClose.Location = New System.Drawing.Point(3, 127)
        Me.PbBtnClose.Name = "PbBtnClose"
        Me.PbBtnClose.Size = New System.Drawing.Size(21, 20)
        Me.PbBtnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PbBtnClose.TabIndex = 10
        Me.PbBtnClose.TabStop = False
        '
        'PbArtwork
        '
        Me.PbArtwork.Location = New System.Drawing.Point(405, 3)
        Me.PbArtwork.Name = "PbArtwork"
        Me.PbArtwork.Size = New System.Drawing.Size(203, 122)
        Me.PbArtwork.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PbArtwork.TabIndex = 1
        Me.PbArtwork.TabStop = False
        '
        'lblUploaded
        '
        Me.lblUploaded.AutoSize = True
        Me.lblUploaded.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUploaded.Location = New System.Drawing.Point(56, 62)
        Me.lblUploaded.Name = "lblUploaded"
        Me.lblUploaded.Size = New System.Drawing.Size(84, 15)
        Me.lblUploaded.TabIndex = 20
        Me.lblUploaded.Text = "{Upload Date}"
        '
        'DudPlacholder
        '
        Me.DudPlacholder.BackColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.DudPlacholder.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DudPlacholder.ForeColor = System.Drawing.Color.FromArgb(CType(CType(114, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.DudPlacholder.Location = New System.Drawing.Point(233, 109)
        Me.DudPlacholder.Name = "DudPlacholder"
        Me.DudPlacholder.Size = New System.Drawing.Size(153, 16)
        Me.DudPlacholder.TabIndex = 21
        Me.DudPlacholder.Text = "Loading Qualities..."
        '
        'VideoEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.Controls.Add(Me.DudPlacholder)
        Me.Controls.Add(Me.lblUploaded)
        Me.Controls.Add(Me.PbFolder)
        Me.Controls.Add(Me.PbProgress)
        Me.Controls.Add(Me.btnDownload)
        Me.Controls.Add(Me.LblDuration)
        Me.Controls.Add(Me.LblLikes)
        Me.Controls.Add(Me.lblChannel)
        Me.Controls.Add(Me.LblTitle)
        Me.Controls.Add(Me.PbIcnYoutube)
        Me.Controls.Add(Me.PbBtnClose)
        Me.Controls.Add(Me.PbArtwork)
        Me.DoubleBuffered = True
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(114, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.Name = "VideoEntry"
        Me.Size = New System.Drawing.Size(608, 147)
        CType(Me.PbFolder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PbIcnYoutube, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PbBtnClose, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PbArtwork, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PbArtwork As PictureBox
    Friend WithEvents PbBtnClose As PictureBox
    Friend WithEvents PbIcnYoutube As PictureBox
    Friend WithEvents LblTitle As Label
    Friend WithEvents lblChannel As Label
    Friend WithEvents LblLikes As Label
    Friend WithEvents LblDuration As Label
    Friend WithEvents btnDownload As Button
    Friend WithEvents PbProgress As ProgressBar
    Friend WithEvents PbFolder As PictureBox
    Friend WithEvents lblUploaded As Label
    Friend WithEvents DudPlacholder As DomainUpDown
End Class
