<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Downloader
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.TxtUrl = New System.Windows.Forms.TextBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.PbImage = New System.Windows.Forms.PictureBox()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.LblLength = New System.Windows.Forms.Label()
        Me.LblLikes = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnPlay = New System.Windows.Forms.Button()
        Me.lblPreview = New System.Windows.Forms.LinkLabel()
        Me.lblspotifyAlbum = New System.Windows.Forms.Label()
        Me.lblspotifyArtist = New System.Windows.Forms.Label()
        Me.lblspotifyName = New System.Windows.Forms.Label()
        Me.pbSpotify = New System.Windows.Forms.PictureBox()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.PbImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.pbSpotify, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TxtUrl
        '
        Me.TxtUrl.Location = New System.Drawing.Point(12, 3)
        Me.TxtUrl.Name = "TxtUrl"
        Me.TxtUrl.Size = New System.Drawing.Size(354, 20)
        Me.TxtUrl.TabIndex = 0
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(372, 3)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch.TabIndex = 1
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'PbImage
        '
        Me.PbImage.Location = New System.Drawing.Point(527, 19)
        Me.PbImage.Name = "PbImage"
        Me.PbImage.Size = New System.Drawing.Size(240, 190)
        Me.PbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PbImage.TabIndex = 2
        Me.PbImage.TabStop = False
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Location = New System.Drawing.Point(9, 19)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(27, 13)
        Me.lblTitle.TabIndex = 3
        Me.lblTitle.Text = "Title"
        '
        'LblLength
        '
        Me.LblLength.AutoSize = True
        Me.LblLength.Location = New System.Drawing.Point(9, 75)
        Me.LblLength.Name = "LblLength"
        Me.LblLength.Size = New System.Drawing.Size(47, 13)
        Me.LblLength.TabIndex = 4
        Me.LblLength.Text = "Duration"
        '
        'LblLikes
        '
        Me.LblLikes.AutoSize = True
        Me.LblLikes.Location = New System.Drawing.Point(9, 48)
        Me.LblLikes.Name = "LblLikes"
        Me.LblLikes.Size = New System.Drawing.Size(38, 13)
        Me.LblLikes.TabIndex = 5
        Me.LblLikes.Text = "Rating"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.PbImage)
        Me.GroupBox1.Controls.Add(Me.LblLength)
        Me.GroupBox1.Controls.Add(Me.LblLikes)
        Me.GroupBox1.Controls.Add(Me.lblTitle)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 29)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(773, 215)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Youtube"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnPlay)
        Me.GroupBox2.Controls.Add(Me.lblPreview)
        Me.GroupBox2.Controls.Add(Me.lblspotifyAlbum)
        Me.GroupBox2.Controls.Add(Me.lblspotifyArtist)
        Me.GroupBox2.Controls.Add(Me.lblspotifyName)
        Me.GroupBox2.Controls.Add(Me.pbSpotify)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 250)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(773, 215)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Spotify"
        '
        'btnPlay
        '
        Me.btnPlay.Location = New System.Drawing.Point(12, 122)
        Me.btnPlay.Name = "btnPlay"
        Me.btnPlay.Size = New System.Drawing.Size(112, 23)
        Me.btnPlay.TabIndex = 7
        Me.btnPlay.Text = "Play"
        Me.btnPlay.UseVisualStyleBackColor = True
        '
        'lblPreview
        '
        Me.lblPreview.AutoSize = True
        Me.lblPreview.Location = New System.Drawing.Point(9, 106)
        Me.lblPreview.Name = "lblPreview"
        Me.lblPreview.Size = New System.Drawing.Size(45, 13)
        Me.lblPreview.TabIndex = 6
        Me.lblPreview.TabStop = True
        Me.lblPreview.Text = "Preview"
        '
        'lblspotifyAlbum
        '
        Me.lblspotifyAlbum.AutoSize = True
        Me.lblspotifyAlbum.Location = New System.Drawing.Point(9, 76)
        Me.lblspotifyAlbum.Name = "lblspotifyAlbum"
        Me.lblspotifyAlbum.Size = New System.Drawing.Size(36, 13)
        Me.lblspotifyAlbum.TabIndex = 5
        Me.lblspotifyAlbum.Text = "Album"
        '
        'lblspotifyArtist
        '
        Me.lblspotifyArtist.AutoSize = True
        Me.lblspotifyArtist.Location = New System.Drawing.Point(9, 50)
        Me.lblspotifyArtist.Name = "lblspotifyArtist"
        Me.lblspotifyArtist.Size = New System.Drawing.Size(30, 13)
        Me.lblspotifyArtist.TabIndex = 4
        Me.lblspotifyArtist.Text = "Artist"
        '
        'lblspotifyName
        '
        Me.lblspotifyName.AutoSize = True
        Me.lblspotifyName.Location = New System.Drawing.Point(9, 25)
        Me.lblspotifyName.Name = "lblspotifyName"
        Me.lblspotifyName.Size = New System.Drawing.Size(63, 13)
        Me.lblspotifyName.TabIndex = 3
        Me.lblspotifyName.Text = "Song Name"
        '
        'pbSpotify
        '
        Me.pbSpotify.Location = New System.Drawing.Point(573, 9)
        Me.pbSpotify.Name = "pbSpotify"
        Me.pbSpotify.Size = New System.Drawing.Size(200, 200)
        Me.pbSpotify.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbSpotify.TabIndex = 2
        Me.pbSpotify.TabStop = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(685, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(100, 23)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "Update FFMPEG"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Downloader
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 470)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.TxtUrl)
        Me.Name = "Downloader"
        Me.Text = "Downloader"
        CType(Me.PbImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.pbSpotify, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TxtUrl As TextBox
    Friend WithEvents btnSearch As Button
    Friend WithEvents PbImage As PictureBox
    Friend WithEvents lblTitle As Label
    Friend WithEvents LblLength As Label
    Friend WithEvents LblLikes As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents lblPreview As LinkLabel
    Friend WithEvents lblspotifyAlbum As Label
    Friend WithEvents lblspotifyArtist As Label
    Friend WithEvents lblspotifyName As Label
    Friend WithEvents pbSpotify As PictureBox
    Friend WithEvents btnPlay As Button
    Friend WithEvents Button1 As Button
End Class
