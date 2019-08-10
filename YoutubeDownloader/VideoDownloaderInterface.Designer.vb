<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VideoDownloaderInterface
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
        CType(Me.PbBtnBack, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PbBtnBack
        '
        Me.PbBtnBack.BackColor = System.Drawing.Color.Transparent
        Me.PbBtnBack.Image = Global.YoutubeDownloader.My.Resources.Resources.BackArrow_Blue
        Me.PbBtnBack.Location = New System.Drawing.Point(3, 0)
        Me.PbBtnBack.Name = "PbBtnBack"
        Me.PbBtnBack.Size = New System.Drawing.Size(26, 29)
        Me.PbBtnBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PbBtnBack.TabIndex = 1
        Me.PbBtnBack.TabStop = False
        '
        'VideoDownloaderInterface
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Controls.Add(Me.PbBtnBack)
        Me.DoubleBuffered = True
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(114, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.Name = "VideoDownloaderInterface"
        Me.Size = New System.Drawing.Size(855, 487)
        CType(Me.PbBtnBack, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PbBtnBack As PictureBox
End Class
