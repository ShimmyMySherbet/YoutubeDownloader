<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SettingsMenu
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.NudTrackDifference = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.NudTrackRetries = New System.Windows.Forms.NumericUpDown()
        Me.BtnUpdateFfmpeg = New System.Windows.Forms.Button()
        Me.BtnClearCache = New System.Windows.Forms.Button()
        Me.BtnSaveChanges = New System.Windows.Forms.Button()
        CType(Me.NudTrackDifference, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudTrackRetries, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(135, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Max Track Difference: (ms)"
        '
        'NudTrackDifference
        '
        Me.NudTrackDifference.Increment = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.NudTrackDifference.Location = New System.Drawing.Point(16, 30)
        Me.NudTrackDifference.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.NudTrackDifference.Name = "NudTrackDifference"
        Me.NudTrackDifference.Size = New System.Drawing.Size(132, 20)
        Me.NudTrackDifference.TabIndex = 1
        Me.NudTrackDifference.Value = New Decimal(New Integer() {5000, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(148, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Max Track Download Retries:"
        '
        'NudTrackRetries
        '
        Me.NudTrackRetries.Location = New System.Drawing.Point(16, 74)
        Me.NudTrackRetries.Name = "NudTrackRetries"
        Me.NudTrackRetries.Size = New System.Drawing.Size(132, 20)
        Me.NudTrackRetries.TabIndex = 3
        Me.NudTrackRetries.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'BtnUpdateFfmpeg
        '
        Me.BtnUpdateFfmpeg.Location = New System.Drawing.Point(16, 100)
        Me.BtnUpdateFfmpeg.Name = "BtnUpdateFfmpeg"
        Me.BtnUpdateFfmpeg.Size = New System.Drawing.Size(132, 23)
        Me.BtnUpdateFfmpeg.TabIndex = 4
        Me.BtnUpdateFfmpeg.Text = "Update FFMPEG"
        Me.BtnUpdateFfmpeg.UseVisualStyleBackColor = True
        '
        'BtnClearCache
        '
        Me.BtnClearCache.Location = New System.Drawing.Point(16, 124)
        Me.BtnClearCache.Name = "BtnClearCache"
        Me.BtnClearCache.Size = New System.Drawing.Size(132, 23)
        Me.BtnClearCache.TabIndex = 5
        Me.BtnClearCache.Text = "Clear Cache"
        Me.BtnClearCache.UseVisualStyleBackColor = True
        '
        'BtnSaveChanges
        '
        Me.BtnSaveChanges.Location = New System.Drawing.Point(16, 158)
        Me.BtnSaveChanges.Name = "BtnSaveChanges"
        Me.BtnSaveChanges.Size = New System.Drawing.Size(132, 23)
        Me.BtnSaveChanges.TabIndex = 6
        Me.BtnSaveChanges.Text = "Save Changes"
        Me.BtnSaveChanges.UseVisualStyleBackColor = True
        '
        'SettingsMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(176, 192)
        Me.Controls.Add(Me.BtnSaveChanges)
        Me.Controls.Add(Me.BtnClearCache)
        Me.Controls.Add(Me.BtnUpdateFfmpeg)
        Me.Controls.Add(Me.NudTrackRetries)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.NudTrackDifference)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "SettingsMenu"
        Me.Text = "Settings"
        CType(Me.NudTrackDifference, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudTrackRetries, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents NudTrackDifference As NumericUpDown
    Friend WithEvents Label2 As Label
    Friend WithEvents NudTrackRetries As NumericUpDown
    Friend WithEvents BtnUpdateFfmpeg As Button
    Friend WithEvents BtnClearCache As Button
    Friend WithEvents BtnSaveChanges As Button
End Class
