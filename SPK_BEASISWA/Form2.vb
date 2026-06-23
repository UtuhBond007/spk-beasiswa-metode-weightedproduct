Public Class Form2

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Label3.Visible = True
        Label4.Visible = True
        PictureBox2.Visible = True
        PictureBox3.Visible = False
        PictureBox4.Visible = False
        PictureBox5.Visible = False
        PictureBox6.Visible = False
        PictureBox7.Visible = False
        PictureBox9.Visible = False
        CrystalReportViewer1.Visible = False
        CrystalReportViewer4.Visible = False
        CrystalReportViewer2.Visible = False
        CrystalReportViewer3.Visible = False
        CrystalReportViewer5.Visible = False
        Label5.Visible = False
        Label6.Visible = False
        Label7.Visible = False
        Label8.Visible = False
        Label9.Visible = False
        Label10.Visible = False
        Label11.Visible = False
        Label12.Visible = False
        PictureBox10.Visible = False
        PictureBox8.Visible = False
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        CrystalReportViewer5.Visible = False
        Label3.Visible = False
        Label4.Visible = False
        PictureBox2.Visible = False
        PictureBox3.Visible = True
        PictureBox4.Visible = True
        PictureBox5.Visible = False
        PictureBox6.Visible = False
        PictureBox7.Visible = False
        PictureBox9.Visible = False
        CrystalReportViewer1.Visible = False
        CrystalReportViewer2.Visible = False
        CrystalReportViewer4.Visible = False
        CrystalReportViewer3.Visible = False
        Label5.Visible = True
        Label6.Visible = True
        Label7.Visible = False
        Label8.Visible = False
        Label9.Visible = False
        Label10.Visible = False
        Label11.Visible = False
        Label12.Visible = False
        PictureBox10.Visible = False
        PictureBox8.Visible = False
    End Sub

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PictureBox3.Visible = False
        PictureBox4.Visible = False
        PictureBox5.Visible = False
        PictureBox6.Visible = False
        PictureBox7.Visible = False
        PictureBox8.Visible = False
        PictureBox9.Visible = False
        PictureBox10.Visible = False
        CrystalReportViewer1.Visible = False
        CrystalReportViewer2.Visible = False
        CrystalReportViewer3.Visible = False
        CrystalReportViewer4.Visible = False
        CrystalReportViewer5.Visible = False
        Label5.Visible = False
        Label6.Visible = False
        Label7.Visible = False
        Label8.Visible = False
        Label9.Visible = False
        Label10.Visible = False
        Label11.Visible = False
        Label12.Visible = False
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        CrystalReportViewer5.Visible = False
        Label11.Visible = False
        Label12.Visible = False
        PictureBox10.Visible = False
        PictureBox8.Visible = False
        Label3.Visible = False
        Label4.Visible = False
        Label5.Visible = False
        Label6.Visible = False
        Label7.Visible = True
        Label8.Visible = True
        Label9.Visible = False
        Label10.Visible = False
        CrystalReportViewer1.Visible = False
        CrystalReportViewer2.Visible = False
        CrystalReportViewer4.Visible = False
        CrystalReportViewer3.Visible = False
        PictureBox2.Visible = False
        PictureBox3.Visible = False
        PictureBox4.Visible = False
        PictureBox5.Visible = True
        PictureBox6.Visible = True
        PictureBox7.Visible = False
        PictureBox9.Visible = False
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Label11.Visible = False
        Label12.Visible = False
        PictureBox10.Visible = False
        PictureBox8.Visible = False
        CrystalReportViewer1.Visible = False
        CrystalReportViewer2.Visible = False
        CrystalReportViewer3.Visible = False
        CrystalReportViewer4.Visible = False
        CrystalReportViewer5.Visible = False
        Form5.Show()
    End Sub

    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.Click
        CrystalReportViewer2.Visible = True
    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        Form3.Show()
    End Sub

    Private Sub PictureBox5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox5.Click
        Form4.Show()
    End Sub

    Private Sub PictureBox6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox6.Click
        CrystalReportViewer3.Visible = True
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        CrystalReportViewer1.Visible = True
        PictureBox7.Visible = False
        PictureBox9.Visible = False
        Label9.Visible = False
        Label10.Visible = False
        Label11.Visible = False
        Label12.Visible = False
        PictureBox10.Visible = False
        CrystalReportViewer5.Visible = False
        PictureBox8.Visible = False
    End Sub

    Private Sub PictureBox7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
        Form1.Show()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Label3.Visible = False
        Label4.Visible = False
        Label5.Visible = False
        Label6.Visible = False
        Label7.Visible = False
        Label8.Visible = False

        PictureBox2.Visible = False
        PictureBox3.Visible = False
        PictureBox4.Visible = False
        PictureBox5.Visible = False
        PictureBox6.Visible = False

    End Sub

    Private Sub PictureBox10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Form7.Show()
    End Sub

    Private Sub PictureBox8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Form8.Show()
    End Sub

    Private Sub PictureBox9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Form9.Show()
    End Sub

    Private Sub PictureBox8_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrystalReportViewer1.Load
        Me.CrystalReportViewer1.ReportSource = New laporan_hasil_ranking
    End Sub

    Private Sub Button6_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        CrystalReportViewer5.Visible = False
        Label3.Visible = False
        Label4.Visible = False
        PictureBox2.Visible = False
        PictureBox3.Visible = False
        PictureBox4.Visible = False
        PictureBox5.Visible = False
        PictureBox6.Visible = False
        CrystalReportViewer1.Visible = False
        CrystalReportViewer3.Visible = False
        CrystalReportViewer4.Visible = False
        Label5.Visible = False
        Label6.Visible = False
        Label7.Visible = False
        Label8.Visible = False
        PictureBox7.Visible = True
        PictureBox8.Visible = True
        PictureBox9.Visible = True
        PictureBox10.Visible = True
        Label9.Visible = True
        Label10.Visible = True
        Label11.Visible = True
        Label12.Visible = True
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        If MsgBox("Keluar dari Program?", vbYesNo + vbInformation, "Perhatian") = vbYes Then
            Close()
        End If
    End Sub

    Private Sub PictureBox9_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox9.Click
        Form11.Show()
    End Sub

    Private Sub CrystalReportViewer2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrystalReportViewer2.Load
        Me.CrystalReportViewer2.ReportSource = New laporan_kriteria
    End Sub

    Private Sub CrystalReportViewer3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrystalReportViewer3.Load
        Me.CrystalReportViewer3.ReportSource = New laporan_alternatif
    End Sub

    Private Sub CrystalReportViewer4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrystalReportViewer4.Load
        Me.CrystalReportViewer4.ReportSource = New laporan_admin
    End Sub

    Private Sub PictureBox7_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox7.Click
        CrystalReportViewer4.Visible = True
        PictureBox8.Visible = False
        PictureBox10.Visible = False
        Label11.Visible = False
        Label12.Visible = False
    End Sub

    Private Sub PictureBox10_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox10.Click
        Form13.Show()
    End Sub

    Private Sub CrystalReportViewer5_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrystalReportViewer5.Load
        Me.CrystalReportViewer5.ReportSource = New laporan_data_siswa
    End Sub

    Private Sub PictureBox8_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox8.Click
        CrystalReportViewer5.Visible = True
    End Sub
End Class