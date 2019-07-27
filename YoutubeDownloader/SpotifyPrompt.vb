Imports System.Windows.Forms
Public Class SpotifyPrompt
    Private WithEvents BaseForm As SpotifyPromptEntry
    Dim Dataent As Boolean = False
    Private Sub LoadPrompt() Handles MyBase.Load
        BaseForm = New SpotifyPromptEntry()
        BaseForm.Dock = DockStyle.Fill
        Me.Controls.Add(BaseForm)
    End Sub
    Private Sub DataEntered() Handles BaseForm.DataSubmitted
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Dataent = True
        Me.Close()
    End Sub
    Private Sub DataSkipped() Handles BaseForm.DataSkiped
        Me.DialogResult = System.Windows.Forms.DialogResult.Ignore
        Me.Close()
    End Sub
    Private Sub closingd() Handles MyBase.Closing
        If Dataent Then
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Else
            Me.DialogResult = System.Windows.Forms.DialogResult.Ignore
        End If
    End Sub
End Class
