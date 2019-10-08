Public Class AudioTrimDialog
    <CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1009:DeclareEventHandlersCorrectly")>
    Public Event DataSubmitted(StartTime As TimeSpan, EndTime As TimeSpan)
    Public Sub New(TrackLengthInSecconds As Integer)
        InitializeComponent()
        TbStart.Maximum = TrackLengthInSecconds
        TbEnd.Maximum = TrackLengthInSecconds
        NudEnd.Maximum = TrackLengthInSecconds
        NudStart.Maximum = TrackLengthInSecconds
        NudEnd.Value = TrackLengthInSecconds
        TbEnd.Value = TrackLengthInSecconds
        tslbloriginal.Text = "Original Length: " & TrackLengthInSecconds & " Secconds"
        Tslblnew.Text = "New Length: " & TrackLengthInSecconds & " Secconds"
    End Sub
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Console.WriteLine("S: {0}", NudStart.Value)
        Console.WriteLine("E: {0}", NudEnd.Value)
        RaiseEvent DataSubmitted(TimeSpan.FromSeconds(NudStart.Value), TimeSpan.FromSeconds(NudEnd.Value))
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Enum EventCaller
        Scroller = 1
        Numeric = 2
    End Enum
    Enum Eventside
        Starter = 1
        Ender = 2
    End Enum
    Public Sub BalanceValues(C As EventCaller, E As Eventside)
        If NudEnd.Value < NudStart.Value Then
            If C = EventCaller.Numeric Then
                If E = Eventside.Ender Then
                    TbStart.Value = NudEnd.Value
                    NudStart.Value = NudEnd.Value
                Else
                    NudEnd.Value = NudStart.Value
                    TbEnd.Value = NudStart.Value
                End If
            Else
                If E = Eventside.Ender Then
                    TbStart.Value = TbEnd.Value
                    NudStart.Value = TbEnd.Value
                Else
                    NudEnd.Value = TbStart.Value
                    TbEnd.Value = TbStart.Value
                End If
            End If
        End If
        If C = EventCaller.Numeric Then
            TbStart.Value = NudStart.Value
            TbEnd.Value = NudEnd.Value
        Else
            NudStart.Value = TbStart.Value
            NudEnd.Value = TbEnd.Value
        End If
        TsLblNew.Text = "New Length: " & NudEnd.Value - NudStart.Value & " Secconds"
    End Sub

    Private Sub TbStart_Scroll(sender As Object, e As EventArgs) Handles TbStart.Scroll
        Console.WriteLine("scroll")
        BalanceValues(EventCaller.Scroller, Eventside.Starter)
    End Sub

    Private Sub NudStart_ValueChanged(sender As Object, e As EventArgs) Handles NudStart.ValueChanged
        BalanceValues(EventCaller.Numeric, Eventside.Starter)
    End Sub

    Private Sub NudEnd_ValueChanged(sender As Object, e As EventArgs) Handles NudEnd.ValueChanged
        BalanceValues(EventCaller.Numeric, Eventside.Ender)
    End Sub

    Private Sub TbEnd_Scroll(sender As Object, e As EventArgs) Handles TbEnd.Scroll
        BalanceValues(EventCaller.Scroller, Eventside.Ender)
    End Sub
End Class
