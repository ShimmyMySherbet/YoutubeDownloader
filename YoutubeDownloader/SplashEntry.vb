Public NotInheritable Class SplashEntry
    Public Shared Status As String = ""
    Public Sub StartAnimation() Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        Dim Renderthread As New Threading.Thread(Sub()
                                                     Do While Me.Visible
                                                         LblStatus.Text = $"Loading{Status}"
                                                         Threading.Thread.Sleep(500)
                                                         LblStatus.Text = $"Loading{Status}."
                                                         Threading.Thread.Sleep(500)
                                                         LblStatus.Text = $"Loading{Status}.."
                                                         Threading.Thread.Sleep(500)
                                                         LblStatus.Text = $"Loading{Status}..."
                                                         Threading.Thread.Sleep(500)
                                                     Loop
                                                 End Sub)
        AddHandler Me.FormClosed, Sub()
                                      Renderthread.Abort()
                                  End Sub
        Renderthread.Start()
    End Sub
End Class
