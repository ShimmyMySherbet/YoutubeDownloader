Public Class SpotifyPromptEntry
    Public Event GoBack()
    Public Event DataSubmitted()


    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start(LinkLabel1.Text)
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Process.Start(LinkLabel2.Text)
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        MessageBox.Show(Me, "1) Go to Spotify Developers section.
2) Login or sign up to create new applications and manage your Spotify credentials to authenticate your API requests.
3) Create new app.
When you register an application on your account, two credentials are created for you – Client ID and Client Secret.", "How To Get A Spotify Client ID And Secret.", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        If TxtClientID.Text <> "" Then
            If txtClientSecret.Text <> "" Then
                SpotifyData.ClientID = TxtClientID.Text
                SpotifyData.ClientSecret = txtClientSecret.Text
                RaiseEvent DataSubmitted()
            Else
                Errorprovider.SetError(txtClientSecret, "Field cannot be empty")
            End If
        Else
            Errorprovider.SetError(TxtClientID, "Field cannot be empty")
        End If
    End Sub

    Private Sub TxtClientID_TextChanged(sender As Object, e As EventArgs) Handles TxtClientID.TextChanged
        Errorprovider.Clear()
    End Sub

    Private Sub txtClientSecret_TextChanged(sender As Object, e As EventArgs) Handles txtClientSecret.TextChanged
        Errorprovider.Clear()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        RaiseEvent GoBack()
    End Sub
End Class
