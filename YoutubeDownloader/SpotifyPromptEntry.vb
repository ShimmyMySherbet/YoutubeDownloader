Public Class SpotifyPromptEntry
    <CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1009:DeclareEventHandlersCorrectly")>
    Public Event DataSkiped()
    <CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1009:DeclareEventHandlersCorrectly")>
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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim res As DialogResult = MessageBox.Show(Me, "Are you sure you want to skip this stage? Doing so will disable all usage of spotify, meaning you won't be able to get any media information for music. If you wish to add this later, you can enter the values in the settings menu. Continue?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If res = DialogResult.Yes Then
            RaiseEvent DataSkiped()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        End
    End Sub
End Class
