<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AudioTrimDialog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AudioTrimDialog))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.TbStart = New System.Windows.Forms.TrackBar()
        Me.NudStart = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.NudEnd = New System.Windows.Forms.NumericUpDown()
        Me.TbEnd = New System.Windows.Forms.TrackBar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnLables = New System.Windows.Forms.FlowLayoutPanel()
        Me.tslbloriginal = New System.Windows.Forms.Label()
        Me.Tslblnew = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.TbStart, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudStart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.NudEnd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TbEnd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnLables.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(500, 216)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'TbStart
        '
        Me.TbStart.Location = New System.Drawing.Point(3, 23)
        Me.TbStart.Name = "TbStart"
        Me.TbStart.Size = New System.Drawing.Size(625, 45)
        Me.TbStart.TabIndex = 1
        '
        'NudStart
        '
        Me.NudStart.Location = New System.Drawing.Point(9, 53)
        Me.NudStart.Name = "NudStart"
        Me.NudStart.Size = New System.Drawing.Size(120, 20)
        Me.NudStart.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Time In Secconds:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.NudStart)
        Me.GroupBox1.Controls.Add(Me.TbStart)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(114, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(634, 88)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Start Time"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.NudEnd)
        Me.GroupBox2.Controls.Add(Me.TbEnd)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(114, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.GroupBox2.Location = New System.Drawing.Point(12, 122)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(634, 88)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "End Time"
        '
        'NudEnd
        '
        Me.NudEnd.Location = New System.Drawing.Point(9, 53)
        Me.NudEnd.Name = "NudEnd"
        Me.NudEnd.Size = New System.Drawing.Size(120, 20)
        Me.NudEnd.TabIndex = 5
        '
        'TbEnd
        '
        Me.TbEnd.Location = New System.Drawing.Point(3, 23)
        Me.TbEnd.Name = "TbEnd"
        Me.TbEnd.Size = New System.Drawing.Size(625, 45)
        Me.TbEnd.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Time In Secconds:"
        '
        'pnLables
        '
        Me.pnLables.BackColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.pnLables.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnLables.Controls.Add(Me.tslbloriginal)
        Me.pnLables.Controls.Add(Me.Tslblnew)
        Me.pnLables.Location = New System.Drawing.Point(0, 0)
        Me.pnLables.Name = "pnLables"
        Me.pnLables.Padding = New System.Windows.Forms.Padding(7, 3, 3, 0)
        Me.pnLables.Size = New System.Drawing.Size(654, 21)
        Me.pnLables.TabIndex = 11
        '
        'tslbloriginal
        '
        Me.tslbloriginal.AutoSize = True
        Me.tslbloriginal.Location = New System.Drawing.Point(10, 3)
        Me.tslbloriginal.Name = "tslbloriginal"
        Me.tslbloriginal.Size = New System.Drawing.Size(135, 13)
        Me.tslbloriginal.TabIndex = 0
        Me.tslbloriginal.Text = "Original Length: 0 Seconds"
        '
        'Tslblnew
        '
        Me.Tslblnew.AutoSize = True
        Me.Tslblnew.Location = New System.Drawing.Point(151, 3)
        Me.Tslblnew.Name = "Tslblnew"
        Me.Tslblnew.Size = New System.Drawing.Size(122, 13)
        Me.Tslblnew.TabIndex = 1
        Me.Tslblnew.Text = "New Length: 0 Seconds"
        '
        'AudioTrimDialog
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(650, 247)
        Me.Controls.Add(Me.pnLables)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(114, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AudioTrimDialog"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Trim Audio"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.TbStart, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudStart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.NudEnd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TbEnd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnLables.ResumeLayout(False)
        Me.pnLables.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents TbStart As TrackBar
    Friend WithEvents NudStart As NumericUpDown
    Friend WithEvents Label3 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents NudEnd As NumericUpDown
    Friend WithEvents TbEnd As TrackBar
    Friend WithEvents Label1 As Label
    Friend WithEvents pnLables As FlowLayoutPanel
    Friend WithEvents tslbloriginal As Label
    Friend WithEvents Tslblnew As Label
End Class
