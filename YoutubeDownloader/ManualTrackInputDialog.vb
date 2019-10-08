Public Class ManualTrackInputDialog
    <CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1009:DeclareEventHandlersCorrectly")>
    Public Event DataSubmitted(Track As String, Artist As String)
    Public Sub New(track As String, artist As String)
        InitializeComponent()
        txtTrack.Text = track
        TxtArtist.Text = artist
    End Sub
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        RaiseEvent DataSubmitted(txtTrack.Text, TxtArtist.Text)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class
