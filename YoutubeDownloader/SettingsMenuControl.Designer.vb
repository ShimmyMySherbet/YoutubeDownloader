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
        CType(Me.PbBtnBack, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudMaxDiff, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudMaxRet, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.BtnUpdateFFMpeg.Location = New System.Drawing.Point(25, 155)
        Me.BtnUpdateFFMpeg.Name = "BtnUpdateFFMpeg"
        Me.BtnUpdateFFMpeg.Size = New System.Drawing.Size(175, 23)
        Me.BtnUpdateFFMpeg.TabIndex = 5
        Me.BtnUpdateFFMpeg.Text = "Update FFMPEG"
        Me.BtnUpdateFFMpeg.UseVisualStyleBackColor = True
        '
        'BtnClearCache
        '
        Me.BtnClearCache.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnClearCache.Location = New System.Drawing.Point(25, 126)
        Me.BtnClearCache.Name = "BtnClearCache"
        Me.BtnClearCache.Size = New System.Drawing.Size(175, 23)
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
        Me.NudMaxDiff.Location = New System.Drawing.Point(25, 65)
        Me.NudMaxDiff.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.NudMaxDiff.Minimum = New Decimal(New Integer() {100, 0, 0, 0})
        Me.NudMaxDiff.Name = "NudMaxDiff"
        Me.NudMaxDiff.Size = New System.Drawing.Size(149, 16)
        Me.NudMaxDiff.TabIndex = 6
        Me.NudMaxDiff.Value = New Decimal(New Integer() {5000, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(149, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Max Track Length Differance:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(133, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(20, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "ms"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(25, 88)
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
        Me.NudMaxRet.Location = New System.Drawing.Point(25, 104)
        Me.NudMaxRet.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.NudMaxRet.Name = "NudMaxRet"
        Me.NudMaxRet.Size = New System.Drawing.Size(149, 16)
        Me.NudMaxRet.TabIndex = 10
        Me.NudMaxRet.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'SettingsMenuControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controls.Add(Me.NudMaxRet)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.NudMaxDiff)
        Me.Controls.Add(Me.BtnUpdateFFMpeg)
        Me.Controls.Add(Me.BtnClearCache)
        Me.Controls.Add(Me.PbBtnBack)
        Me.DoubleBuffered = True
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(114, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.Name = "SettingsMenuControl"
        Me.Size = New System.Drawing.Size(871, 496)
        CType(Me.PbBtnBack, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudMaxDiff, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudMaxRet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PbBtnBack As PictureBox
    Friend WithEvents BtnUpdateFFMpeg As Button
    Friend WithEvents BtnClearCache As Button
    Friend WithEvents NudMaxDiff As NumericUpDown
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents NudMaxRet As NumericUpDown
End Class
