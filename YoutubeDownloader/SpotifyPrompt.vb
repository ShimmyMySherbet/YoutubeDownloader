Imports System.Windows.Forms
Public Class SpotifyPrompt
    Private WithEvents CredentialsScreen As New SpotifyPromptEntry With {.Dock = DockStyle.Fill}
    Private WithEvents SelectScreen As New CredentialPrompt With {.Dock = DockStyle.Fill}
    Public Dataent As Boolean
    Public PublicCredentials As Boolean
    Private Sub LoadPrompt() Handles MyBase.Load
        Me.Controls.Add(SelectScreen)
        Me.Controls.Add(CredentialsScreen)
        CredentialsScreen.Hide()
    End Sub
    Private Sub DataEntered() Handles CredentialsScreen.DataSubmitted
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Dataent = True
        PublicCredentials = False
        Me.Close()
    End Sub
    Private Sub Back() Handles CredentialsScreen.GoBack
        SelectScreen.Show()
        CredentialsScreen.Hide()
    End Sub
    Private Sub Forward() Handles SelectScreen.UsePrivateCredentials
        SelectScreen.Hide()
        CredentialsScreen.Show()
    End Sub
    Private Sub GoPublic() Handles SelectScreen.UsePublicCredentials
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        PublicCredentials = True
        Dataent = True
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
