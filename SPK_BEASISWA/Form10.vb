Public Class Form10

    Sub loading()
        Me.ProgressBar1.Value = ProgressBar1.Value + 1
        If ProgressBar1.Value >= 100 Then
            Timer1.Stop()
            Form2.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.ProgressBar1.Value = ProgressBar1.Value + 1
        If ProgressBar1.Value >= 100 Then
            Timer1.Stop()
            Form2.Show()
            Me.Hide()
            ProgressBar1.Update()
        End If
    End Sub
End Class