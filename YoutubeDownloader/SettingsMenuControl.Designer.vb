<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SettingsMenuControl
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
        Me.PbBtnBack = New System.Windows.Forms.PictureBox()
        Me.BtnUpdateFFMpeg = New System.Windows.Forms.Button()
        Me.BtnClearCache = New System.Windows.Forms.Button()
        Me.NudMaxDiff = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.NudMaxRet = New System.Windows.Forms.NumericUpDown()
        Me.GbMusic = New System.Windows.Forms.GroupBox()
        Me.PnMusic = New System.Windows.Forms.Panel()
        Me.RBWav = New System.Windows.Forms.RadioButton()
        Me.RbFlac = New System.Windows.Forms.RadioButton()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.RBMp3 = New System.Windows.Forms.RadioButton()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.BtnSaveChanges = New System.Windows.Forms.Button()
        Me.BtnInstallTypes = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtSpotifySecret = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtSpotifyClient = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtVideoExt = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.DudTheme = New System.Windows.Forms.DomainUpDown()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.PbBackgroundColour = New System.Windows.Forms.PictureBox()
        Me.BtnSetBackground = New System.Windows.Forms.Button()
        Me.PbPreview = New System.Windows.Forms.PictureBox()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.lbltrans = New System.Windows.Forms.Label()
        Me.TBTransparency = New System.Windows.Forms.TrackBar()
        Me.CbUseBackground = New System.Windows.Forms.CheckBox()
        Me.BtnSelectImage = New System.Windows.Forms.Button()
        Me.CDColour = New System.Windows.Forms.ColorDialog()
        Me.OFDImage = New System.Windows.Forms.OpenFileDialog()
        CType(Me.PbBtnBack, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudMaxDiff, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudMaxRet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GbMusic.SuspendLayout()
        Me.PnMusic.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PbBackgroundColour, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PbPreview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TBTransparency, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PbBtnBack
        '
        Me.PbBtnBack.BackColor = System.Drawing.Color.Transparent
        Me.PbBtnBack.Image = Global.YoutubeDownloader.My.Resources.Resources.BackArrow_Blue
        Me.PbBtnBack.Location = New System.Drawing.Point(3, 3)
        Me.PbBtnBack.Name = "PbBtnBack"
        Me.PbBtnBack.Size = New System.Drawing.Size(26, 29)
        Me.PbBtnBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PbBtnBack.TabIndex = 1
        Me.PbBtnBack.TabStop = False
        '
        'BtnUpdateFFMpeg
        '
        Me.BtnUpdateFFMpeg.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnUpdateFFMpeg.Location = New System.Drawing.Point(3, 338)
        Me.BtnUpdateFFMpeg.Name = "BtnUpdateFFMpeg"
        Me.BtnUpdateFFMpeg.Size = New System.Drawing.Size(256, 23)
        Me.BtnUpdateFFMpeg.TabIndex = 5
        Me.BtnUpdateFFMpeg.Text = "Update FFMPEG"
        Me.BtnUpdateFFMpeg.UseVisualStyleBackColor = True
        '
        'BtnClearCache
        '
        Me.BtnClearCache.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnClearCache.Location = New System.Drawing.Point(3, 309)
        Me.BtnClearCache.Name = "BtnClearCache"
        Me.BtnClearCache.Size = New System.Drawing.Size(256, 23)
        Me.BtnClearCache.TabIndex = 4
        Me.BtnClearCache.Text = "Clear Cache"
        Me.BtnClearCache.UseVisualStyleBackColor = True
        '
        'NudMaxDiff
        '
        Me.NudMaxDiff.BackColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.NudMaxDiff.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.NudMaxDiff.ForeColor = System.Drawing.Color.FromArgb(CType(CType(114, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.NudMaxDiff.Increment = New Decimal(New Integer() {500, 0, 0, 0})
        Me.NudMaxDiff.Location = New System.Drawing.Point(9, 20)
        Me.NudMaxDiff.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.NudMaxDiff.Minimum = New Decimal(New Integer() {100, 0, 0, 0})
        Me.NudMaxDiff.Name = "NudMaxDiff"
        Me.NudMaxDiff.Size = New System.Drawing.Size(213, 16)
        Me.NudMaxDiff.TabIndex = 6
        Me.NudMaxDiff.Value = New Decimal(New Integer() {5000, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(149, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Max Track Length Differance:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(114, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(20, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "ms"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(117, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Max Download Retries:"
        '
        'NudMaxRet
        '
        Me.NudMaxRet.BackColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.NudMaxRet.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.NudMaxRet.ForeColor = System.Drawing.Color.FromArgb(CType(CType(114, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.NudMaxRet.Location = New System.Drawing.Point(9, 58)
        Me.NudMaxRet.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.NudMaxRet.Name = "NudMaxRet"
        Me.NudMaxRet.Size = New System.Drawing.Size(213, 16)
        Me.NudMaxRet.TabIndex = 10
        Me.NudMaxRet.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'GbMusic
        '
        Me.GbMusic.Controls.Add(Me.PnMusic)
        Me.GbMusic.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.GbMusic.ForeColor = System.Drawing.Color.FromArgb(CType(CType(114, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.GbMusic.Location = New System.Drawing.Point(97, 47)
        Me.GbMusic.Name = "GbMusic"
        Me.GbMusic.Size = New System.Drawing.Size(268, 393)
        Me.GbMusic.TabIndex = 11
        Me.GbMusic.TabStop = False
        Me.GbMusic.Text = "Downloading"
        '
        'PnMusic
        '
        Me.PnMusic.Controls.Add(Me.RBWav)
        Me.PnMusic.Controls.Add(Me.RbFlac)
        Me.PnMusic.Controls.Add(Me.Label7)
        Me.PnMusic.Controls.Add(Me.RBMp3)
        Me.PnMusic.Controls.Add(Me.BtnClearCache)
        Me.PnMusic.Controls.Add(Me.FlowLayoutPanel1)
        Me.PnMusic.Controls.Add(Me.Label9)
        Me.PnMusic.Controls.Add(Me.Label6)
        Me.PnMusic.Controls.Add(Me.txtSpotifySecret)
        Me.PnMusic.Controls.Add(Me.Label5)
        Me.PnMusic.Controls.Add(Me.TxtSpotifyClient)
        Me.PnMusic.Controls.Add(Me.Label4)
        Me.PnMusic.Controls.Add(Me.TxtVideoExt)
        Me.PnMusic.Controls.Add(Me.NudMaxDiff)
        Me.PnMusic.Controls.Add(Me.BtnUpdateFFMpeg)
        Me.PnMusic.Controls.Add(Me.Label2)
        Me.PnMusic.Controls.Add(Me.NudMaxRet)
        Me.PnMusic.Controls.Add(Me.Label1)
        Me.PnMusic.Controls.Add(Me.Label3)
        Me.PnMusic.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnMusic.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.PnMusic.Location = New System.Drawing.Point(3, 20)
        Me.PnMusic.Name = "PnMusic"
        Me.PnMusic.Size = New System.Drawing.Size(262, 370)
        Me.PnMusic.TabIndex = 0
        '
        'RBWav
        '
        Me.RBWav.AutoSize = True
        Me.RBWav.Location = New System.Drawing.Point(121, 221)
        Me.RBWav.Name = "RBWav"
        Me.RBWav.Size = New System.Drawing.Size(50, 17)
        Me.RBWav.TabIndex = 35
        Me.RBWav.TabStop = True
        Me.RBWav.Text = "WAV"
        Me.RBWav.UseVisualStyleBackColor = True
        '
        'RbFlac
        '
        Me.RbFlac.AutoSize = True
        Me.RbFlac.Location = New System.Drawing.Point(64, 221)
        Me.RbFlac.Name = "RbFlac"
        Me.RbFlac.Size = New System.Drawing.Size(51, 17)
        Me.RbFlac.TabIndex = 34
        Me.RbFlac.TabStop = True
        Me.RbFlac.Text = "FLAC"
        Me.RbFlac.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 203)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(69, 13)
        Me.Label7.TabIndex = 33
        Me.Label7.Text = "Audio Format"
        '
        'RBMp3
        '
        Me.RBMp3.AutoSize = True
        Me.RBMp3.Location = New System.Drawing.Point(9, 221)
        Me.RBMp3.Name = "RBMp3"
        Me.RBMp3.Size = New System.Drawing.Size(47, 17)
        Me.RBMp3.TabIndex = 32
        Me.RBMp3.TabStop = True
        Me.RBMp3.Text = "MP3"
        Me.RBMp3.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.BtnSaveChanges)
        Me.FlowLayoutPanel1.Controls.Add(Me.BtnInstallTypes)
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 244)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(271, 63)
        Me.FlowLayoutPanel1.TabIndex = 31
        '
        'BtnSaveChanges
        '
        Me.BtnSaveChanges.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSaveChanges.Location = New System.Drawing.Point(3, 37)
        Me.BtnSaveChanges.Name = "BtnSaveChanges"
        Me.BtnSaveChanges.Size = New System.Drawing.Size(256, 23)
        Me.BtnSaveChanges.TabIndex = 17
        Me.BtnSaveChanges.Text = "Save Changes"
        Me.BtnSaveChanges.UseVisualStyleBackColor = True
        '
        'BtnInstallTypes
        '
        Me.BtnInstallTypes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnInstallTypes.Location = New System.Drawing.Point(3, 8)
        Me.BtnInstallTypes.Name = "BtnInstallTypes"
        Me.BtnInstallTypes.Size = New System.Drawing.Size(108, 23)
        Me.BtnInstallTypes.TabIndex = 31
        Me.BtnInstallTypes.Text = "Install File Types"
        Me.BtnInstallTypes.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(184, 21)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(20, 13)
        Me.Label9.TabIndex = 30
        Me.Label9.Text = "ms"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 161)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(105, 13)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Spotify Client Secret:"
        '
        'txtSpotifySecret
        '
        Me.txtSpotifySecret.BackColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtSpotifySecret.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSpotifySecret.ForeColor = System.Drawing.Color.FromArgb(CType(CType(114, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.txtSpotifySecret.Location = New System.Drawing.Point(9, 177)
        Me.txtSpotifySecret.Name = "txtSpotifySecret"
        Me.txtSpotifySecret.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtSpotifySecret.Size = New System.Drawing.Size(213, 20)
        Me.txtSpotifySecret.TabIndex = 15
        Me.txtSpotifySecret.Text = "?"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 121)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(85, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Spotify Client ID:"
        '
        'TxtSpotifyClient
        '
        Me.TxtSpotifyClient.BackColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TxtSpotifyClient.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtSpotifyClient.ForeColor = System.Drawing.Color.FromArgb(CType(CType(114, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.TxtSpotifyClient.Location = New System.Drawing.Point(9, 137)
        Me.TxtSpotifyClient.Name = "TxtSpotifyClient"
        Me.TxtSpotifyClient.Size = New System.Drawing.Size(213, 20)
        Me.TxtSpotifyClient.TabIndex = 13
        Me.TxtSpotifyClient.Text = "?"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 79)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(123, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Default Video Extension:"
        '
        'TxtVideoExt
        '
        Me.TxtVideoExt.BackColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TxtVideoExt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtVideoExt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(114, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.TxtVideoExt.Location = New System.Drawing.Point(6, 95)
        Me.TxtVideoExt.Name = "TxtVideoExt"
        Me.TxtVideoExt.Size = New System.Drawing.Size(213, 20)
        Me.TxtVideoExt.TabIndex = 11
        Me.TxtVideoExt.Text = "webm"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Panel1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(114, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(437, 47)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(273, 393)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Interface"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.DudTheme)
        Me.Panel1.Controls.Add(Me.btnReset)
        Me.Panel1.Controls.Add(Me.PbBackgroundColour)
        Me.Panel1.Controls.Add(Me.BtnSetBackground)
        Me.Panel1.Controls.Add(Me.PbPreview)
        Me.Panel1.Controls.Add(Me.BtnSave)
        Me.Panel1.Controls.Add(Me.lbltrans)
        Me.Panel1.Controls.Add(Me.TBTransparency)
        Me.Panel1.Controls.Add(Me.CbUseBackground)
        Me.Panel1.Controls.Add(Me.BtnSelectImage)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Panel1.Location = New System.Drawing.Point(3, 20)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(267, 370)
        Me.Panel1.TabIndex = 0
        '
        'DudTheme
        '
        Me.DudTheme.BackColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.DudTheme.ForeColor = System.Drawing.Color.FromArgb(CType(CType(114, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.DudTheme.Items.Add("Complete")
        Me.DudTheme.Items.Add("Partial - Default")
        Me.DudTheme.Items.Add("Partial - Solid")
        Me.DudTheme.Items.Add("Drop - Default")
        Me.DudTheme.Items.Add("Drop - Solid")
        Me.DudTheme.Location = New System.Drawing.Point(7, 232)
        Me.DudTheme.Name = "DudTheme"
        Me.DudTheme.Size = New System.Drawing.Size(256, 20)
        Me.DudTheme.TabIndex = 24
        Me.DudTheme.Text = "Complete"
        '
        'btnReset
        '
        Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReset.Location = New System.Drawing.Point(7, 313)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(256, 23)
        Me.btnReset.TabIndex = 23
        Me.btnReset.Text = "Reset to Defaults"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'PbBackgroundColour
        '
        Me.PbBackgroundColour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PbBackgroundColour.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.PbBackgroundColour.Location = New System.Drawing.Point(223, 203)
        Me.PbBackgroundColour.Name = "PbBackgroundColour"
        Me.PbBackgroundColour.Size = New System.Drawing.Size(40, 22)
        Me.PbBackgroundColour.TabIndex = 22
        Me.PbBackgroundColour.TabStop = False
        '
        'BtnSetBackground
        '
        Me.BtnSetBackground.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSetBackground.Location = New System.Drawing.Point(7, 203)
        Me.BtnSetBackground.Name = "BtnSetBackground"
        Me.BtnSetBackground.Size = New System.Drawing.Size(210, 23)
        Me.BtnSetBackground.TabIndex = 21
        Me.BtnSetBackground.Text = "Set Background Colour"
        Me.BtnSetBackground.UseVisualStyleBackColor = True
        '
        'PbPreview
        '
        Me.PbPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PbPreview.Location = New System.Drawing.Point(7, 69)
        Me.PbPreview.Name = "PbPreview"
        Me.PbPreview.Size = New System.Drawing.Size(256, 128)
        Me.PbPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PbPreview.TabIndex = 20
        Me.PbPreview.TabStop = False
        '
        'BtnSave
        '
        Me.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSave.Location = New System.Drawing.Point(8, 342)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(255, 23)
        Me.BtnSave.TabIndex = 18
        Me.BtnSave.Text = "Apply/Save"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'lbltrans
        '
        Me.lbltrans.AutoSize = True
        Me.lbltrans.Location = New System.Drawing.Point(6, 26)
        Me.lbltrans.Name = "lbltrans"
        Me.lbltrans.Size = New System.Drawing.Size(165, 13)
        Me.lbltrans.TabIndex = 18
        Me.lbltrans.Text = "Background Transparency: 100%"
        '
        'TBTransparency
        '
        Me.TBTransparency.Location = New System.Drawing.Point(4, 42)
        Me.TBTransparency.Maximum = 100
        Me.TBTransparency.Name = "TBTransparency"
        Me.TBTransparency.Size = New System.Drawing.Size(260, 45)
        Me.TBTransparency.TabIndex = 19
        Me.TBTransparency.Value = 100
        '
        'CbUseBackground
        '
        Me.CbUseBackground.AutoSize = True
        Me.CbUseBackground.Location = New System.Drawing.Point(9, 6)
        Me.CbUseBackground.Name = "CbUseBackground"
        Me.CbUseBackground.Size = New System.Drawing.Size(144, 17)
        Me.CbUseBackground.TabIndex = 0
        Me.CbUseBackground.Text = "Use Custom Background"
        Me.CbUseBackground.UseVisualStyleBackColor = True
        '
        'BtnSelectImage
        '
        Me.BtnSelectImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSelectImage.Location = New System.Drawing.Point(8, 284)
        Me.BtnSelectImage.Name = "BtnSelectImage"
        Me.BtnSelectImage.Size = New System.Drawing.Size(256, 23)
        Me.BtnSelectImage.TabIndex = 18
        Me.BtnSelectImage.Text = "Select Background Image"
        Me.BtnSelectImage.UseVisualStyleBackColor = True
        '
        'CDColour
        '
        Me.CDColour.Color = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(51, Byte), Integer))
        '
        'OFDImage
        '
        Me.OFDImage.Filter = "Images|*.jpg;*.jpeg;*.png:*.tiff;*.bmp"
        '
        'SettingsMenuControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GbMusic)
        Me.Controls.Add(Me.PbBtnBack)
        Me.DoubleBuffered = True
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(114, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.Name = "SettingsMenuControl"
        Me.Size = New System.Drawing.Size(871, 496)
        CType(Me.PbBtnBack, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudMaxDiff, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudMaxRet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GbMusic.ResumeLayout(False)
        Me.PnMusic.ResumeLayout(False)
        Me.PnMusic.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PbBackgroundColour, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PbPreview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TBTransparency, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PbBtnBack As PictureBox
    Friend WithEvents BtnUpdateFFMpeg As Button
    Friend WithEvents BtnClearCache As Button
    Friend WithEvents NudMaxDiff As NumericUpDown
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents NudMaxRet As NumericUpDown
    Friend WithEvents GbMusic As GroupBox
    Friend WithEvents PnMusic As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents TxtVideoExt As TextBox
    Friend WithEvents BtnSaveChanges As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents txtSpotifySecret As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TxtSpotifyClient As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents BtnSave As Button
    Friend WithEvents lbltrans As Label
    Friend WithEvents TBTransparency As TrackBar
    Friend WithEvents BtnSelectImage As Button
    Friend WithEvents CbUseBackground As CheckBox
    Friend WithEvents Label9 As Label
    Friend WithEvents PbBackgroundColour As PictureBox
    Friend WithEvents BtnSetBackground As Button
    Friend WithEvents PbPreview As PictureBox
    Friend WithEvents btnReset As Button
    Friend WithEvents CDColour As ColorDialog
    Friend WithEvents OFDImage As OpenFileDialog
    Friend WithEvents DudTheme As DomainUpDown
    Friend WithEvents BtnInstallTypes As Button
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents RBWav As RadioButton
    Friend WithEvents RbFlac As RadioButton
    Friend WithEvents Label7 As Label
    Friend WithEvents RBMp3 As RadioButton
End Class
