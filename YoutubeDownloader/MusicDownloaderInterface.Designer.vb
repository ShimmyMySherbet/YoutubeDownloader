﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MusicDownloaderinterface
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
        Me.components = New System.ComponentModel.Container()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.CMSClear = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ClearFailuresToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClearDownloadedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.BtnDownloadAll = New System.Windows.Forms.Button()
        Me.CMSDownloadAll = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.BTNRestartfailures = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResetFailedItemsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FlowItems = New System.Windows.Forms.FlowLayoutPanel()
        Me.BtnGo = New System.Windows.Forms.Button()
        Me.txturl = New System.Windows.Forms.TextBox()
        Me.PbOpenOutput = New System.Windows.Forms.PictureBox()
        Me.PbBtnBack = New System.Windows.Forms.PictureBox()
        Me.ClearUnusedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1.SuspendLayout()
        Me.CMSClear.SuspendLayout()
        Me.CMSDownloadAll.SuspendLayout()
        CType(Me.PbOpenOutput, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PbBtnBack, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Button5)
        Me.GroupBox1.Controls.Add(Me.Button4)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.BtnDownloadAll)
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(114, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(668, 38)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(175, 141)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Manage"
        '
        'Button5
        '
        Me.Button5.ContextMenuStrip = Me.CMSClear
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Location = New System.Drawing.Point(6, 106)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(162, 23)
        Me.Button5.TabIndex = 4
        Me.Button5.Text = "Clear List"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'CMSClear
        '
        Me.CMSClear.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ClearFailuresToolStripMenuItem, Me.ClearDownloadedToolStripMenuItem, Me.ClearUnusedToolStripMenuItem})
        Me.CMSClear.Name = "CMSClear"
        Me.CMSClear.Size = New System.Drawing.Size(181, 92)
        '
        'ClearFailuresToolStripMenuItem
        '
        Me.ClearFailuresToolStripMenuItem.Name = "ClearFailuresToolStripMenuItem"
        Me.ClearFailuresToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ClearFailuresToolStripMenuItem.Text = "Clear Failures"
        '
        'ClearDownloadedToolStripMenuItem
        '
        Me.ClearDownloadedToolStripMenuItem.Name = "ClearDownloadedToolStripMenuItem"
        Me.ClearDownloadedToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ClearDownloadedToolStripMenuItem.Text = "Clear Downloaded"
        '
        'Button4
        '
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Location = New System.Drawing.Point(6, 77)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(162, 23)
        Me.Button4.TabIndex = 3
        Me.Button4.Text = "Load List"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Location = New System.Drawing.Point(6, 48)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(162, 23)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "Export List"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'BtnDownloadAll
        '
        Me.BtnDownloadAll.ContextMenuStrip = Me.CMSDownloadAll
        Me.BtnDownloadAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnDownloadAll.Location = New System.Drawing.Point(7, 19)
        Me.BtnDownloadAll.Name = "BtnDownloadAll"
        Me.BtnDownloadAll.Size = New System.Drawing.Size(162, 23)
        Me.BtnDownloadAll.TabIndex = 1
        Me.BtnDownloadAll.Text = "Download All With MP3 Tags"
        Me.BtnDownloadAll.UseVisualStyleBackColor = True
        '
        'CMSDownloadAll
        '
        Me.CMSDownloadAll.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BTNRestartfailures, Me.ResetFailedItemsToolStripMenuItem})
        Me.CMSDownloadAll.Name = "CMSDownloadAll"
        Me.CMSDownloadAll.Size = New System.Drawing.Size(169, 48)
        '
        'BTNRestartfailures
        '
        Me.BTNRestartfailures.Name = "BTNRestartfailures"
        Me.BTNRestartfailures.Size = New System.Drawing.Size(168, 22)
        Me.BTNRestartfailures.Text = "Restart Failures"
        '
        'ResetFailedItemsToolStripMenuItem
        '
        Me.ResetFailedItemsToolStripMenuItem.Name = "ResetFailedItemsToolStripMenuItem"
        Me.ResetFailedItemsToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.ResetFailedItemsToolStripMenuItem.Text = "Reset Failed Items"
        '
        'FlowItems
        '
        Me.FlowItems.AllowDrop = True
        Me.FlowItems.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.FlowItems.AutoScroll = True
        Me.FlowItems.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.FlowItems.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.FlowItems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FlowItems.Location = New System.Drawing.Point(24, 38)
        Me.FlowItems.Name = "FlowItems"
        Me.FlowItems.Size = New System.Drawing.Size(638, 437)
        Me.FlowItems.TabIndex = 8
        '
        'BtnGo
        '
        Me.BtnGo.BackColor = System.Drawing.Color.Transparent
        Me.BtnGo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnGo.Location = New System.Drawing.Point(668, 10)
        Me.BtnGo.Name = "BtnGo"
        Me.BtnGo.Size = New System.Drawing.Size(49, 23)
        Me.BtnGo.TabIndex = 7
        Me.BtnGo.Text = "Go"
        Me.BtnGo.UseVisualStyleBackColor = False
        '
        'txturl
        '
        Me.txturl.AcceptsReturn = True
        Me.txturl.BackColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txturl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txturl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(114, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.txturl.Location = New System.Drawing.Point(24, 12)
        Me.txturl.Name = "txturl"
        Me.txturl.Size = New System.Drawing.Size(638, 20)
        Me.txturl.TabIndex = 6
        '
        'PbOpenOutput
        '
        Me.PbOpenOutput.BackColor = System.Drawing.Color.Transparent
        Me.PbOpenOutput.Image = Global.YoutubeDownloader.My.Resources.Resources.Music_Notes_Blue
        Me.PbOpenOutput.Location = New System.Drawing.Point(818, 3)
        Me.PbOpenOutput.Name = "PbOpenOutput"
        Me.PbOpenOutput.Size = New System.Drawing.Size(25, 23)
        Me.PbOpenOutput.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PbOpenOutput.TabIndex = 11
        Me.PbOpenOutput.TabStop = False
        '
        'PbBtnBack
        '
        Me.PbBtnBack.BackColor = System.Drawing.Color.Transparent
        Me.PbBtnBack.Image = Global.YoutubeDownloader.My.Resources.Resources.BackArrow_Blue
        Me.PbBtnBack.Location = New System.Drawing.Point(-2, 3)
        Me.PbBtnBack.Name = "PbBtnBack"
        Me.PbBtnBack.Size = New System.Drawing.Size(26, 29)
        Me.PbBtnBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PbBtnBack.TabIndex = 0
        Me.PbBtnBack.TabStop = False
        '
        'ClearUnusedToolStripMenuItem
        '
        Me.ClearUnusedToolStripMenuItem.Name = "ClearUnusedToolStripMenuItem"
        Me.ClearUnusedToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ClearUnusedToolStripMenuItem.Text = "Clear Unused"
        '
        'MusicDownloaderinterface
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controls.Add(Me.PbBtnBack)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.FlowItems)
        Me.Controls.Add(Me.BtnGo)
        Me.Controls.Add(Me.txturl)
        Me.Controls.Add(Me.PbOpenOutput)
        Me.DoubleBuffered = True
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(114, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.Name = "MusicDownloaderinterface"
        Me.Size = New System.Drawing.Size(855, 487)
        Me.GroupBox1.ResumeLayout(False)
        Me.CMSClear.ResumeLayout(False)
        Me.CMSDownloadAll.ResumeLayout(False)
        CType(Me.PbOpenOutput, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PbBtnBack, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Button5 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents BtnDownloadAll As Button
    Friend WithEvents FlowItems As FlowLayoutPanel
    Friend WithEvents BtnGo As Button
    Friend WithEvents txturl As TextBox
    Friend WithEvents PbOpenOutput As PictureBox
    Friend WithEvents PbBtnBack As PictureBox
    Friend WithEvents CMSDownloadAll As ContextMenuStrip
    Friend WithEvents BTNRestartfailures As ToolStripMenuItem
    Friend WithEvents ResetFailedItemsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CMSClear As ContextMenuStrip
    Friend WithEvents ClearFailuresToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ClearDownloadedToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ClearUnusedToolStripMenuItem As ToolStripMenuItem
End Class
