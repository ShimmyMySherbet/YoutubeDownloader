Public Class CredentialPrompt
    Public Event UsePublicCredentials()
    Public Event UsePrivateCredentials()
    Private Sub BtnCan_Click(sender As Object, e As EventArgs) Handles BtnCan.Click
        End
    End Sub

    Private Sub BtnPublic_Click(sender As Object, e As EventArgs) Handles BtnPublic.Click
        RaiseEvent UsePublicCredentials()
    End Sub

    Private Sub BtnPrivate_Click(sender As Object, e As EventArgs) Handles BtnPrivate.Click
        RaiseEvent UsePrivateCredentials()
    End Sub
End Class
