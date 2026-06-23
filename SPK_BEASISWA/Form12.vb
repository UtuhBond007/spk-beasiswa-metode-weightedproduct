Public Class Form12

    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrystalReportViewer1.Load
        Me.CrystalReportViewer1.ReportSource = New data_hasil
    End Sub
End Class