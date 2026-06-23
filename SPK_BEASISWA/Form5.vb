Imports System.Data.OleDb

Public Class Form5

    Sub jumlahdata()
        SqlQuery = "select & from alternatif order by Kode_Alternatif asc"
        DataGridView1.Refresh()
        TextBox1.Text = DataGridView1.RowCount - 1
    End Sub

    Sub TampilkanHasil()
        SqlQuery = "select * from hasil order by `Hasil` Desc"
        DataGridView3.Columns.Clear()
        DataGridView3.Columns.Add("", "Kode_Alternatif")
        DataGridView3.Columns.Add("", "Nama_Alternatif")
        DataGridView3.Columns.Add("", "Hasil")
        PerintahDatabase = New OleDbCommand(SqlQuery, Koneksi)
        Try
            DataReader = PerintahDatabase.ExecuteReader
            Dim i As Integer = 0
            While DataReader.Read
                DataGridView3.Rows.Add()
                DataGridView3.Item(0, i).Value = DataReader(0)
                SqlQuery = "select * from alternatif where `Kode_Alternatif`='" & DataReader(0) & "'"
                PerintahDatabase = New OleDbCommand(SqlQuery, Koneksi)
                Try
                    Dim DataReader2 As OleDbDataReader = PerintahDatabase.ExecuteReader
                    While DataReader2.Read
                        DataGridView3.Item(1, i).Value = DataReader2(1)
                    End While
                    DataReader2.Close()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
                DataGridView3.Item(2, i).Value = DataReader(1)
                i += 1
            End While
            DataReader.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Dim Perhitungan As New Hasil_WP
    Private Sub Periksa(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Mengisi Bobot
        Dim dataBobotSementara As New List(Of Bobot)
        SqlQuery = "select * from kriteria"
        PerintahDatabase = New OleDbCommand(SqlQuery, Koneksi)
        DataReader = PerintahDatabase.ExecuteReader
        While DataReader.Read
            Dim bobotSementara As New Bobot
            bobotSementara.kode = DataReader(0)
            bobotSementara.nama = DataReader(1)
            bobotSementara.bobot = DataReader(2)
            If DataReader(3).ToString.ToLower = "biaya" Then
                bobotSementara.atribut = False
            Else
                bobotSementara.atribut = True
            End If

            dataBobotSementara.Add(bobotSementara)
        End While
        DataReader.Close()
        Perhitungan.JumlahKriteria = dataBobotSementara.Count
        Perhitungan.DataBobot = dataBobotSementara.ToArray

        'mengisi data alternatif
        Dim dataAlternatifSementara As New List(Of Alternatif)
        SqlQuery = "select * from alternatif"
        PerintahDatabase = New OleDbCommand(SqlQuery, Koneksi)
        DataReader = PerintahDatabase.ExecuteReader
        While DataReader.Read
            Dim AlternatifSementara As New Alternatif
            AlternatifSementara.kode = DataReader(0)
            SqlQuery = "select * from data_kriteria where `Kode_Alternatif`='" & DataReader(0) & "'"
            PerintahDatabase = New OleDbCommand(SqlQuery, Koneksi)
            Dim DataReader2 As OleDbDataReader = PerintahDatabase.ExecuteReader
            Dim dataKriteriaSementara As New List(Of Kriteria)
            While DataReader2.Read
                Dim satuanKriteria As New Kriteria
                satuanKriteria.kode = DataReader2(1)
                satuanKriteria.nilai = DataReader2(3)
                dataKriteriaSementara.Add(satuanKriteria)
            End While
            DataReader2.Close()
            AlternatifSementara.kriteria = dataKriteriaSementara.ToArray

            dataAlternatifSementara.Add(AlternatifSementara)
        End While
        DataReader.Close()
        Perhitungan.JumlahAlternatif = dataAlternatifSementara.Count
        Perhitungan.DataAlternatif = dataAlternatifSementara.ToArray
        Perhitungan.CariWP()

        TampilkanAlternatif()
        TampilkanPerbaikanBobot()
        Call jumlahdata()
        TextBox1.Visible = True
        Label1.Visible = True
    End Sub

    Private Function sumBobot(ByVal nilai As Bobot())
        Dim hasil As Double = 0
        For Each item As Bobot In nilai
            hasil += item.bobot
        Next
        Return hasil
    End Function

    Sub TampilkanPerbaikanBobot()
        DataGridView2.Columns.Clear()
        DataGridView2.Columns.Add("bobot", "Bobot")
        DataGridView2.Columns.Add("perbaikan", "Perbaikan Bobot")
        For i As Integer = 0 To UBound(Perhitungan.DataBobot)
            DataGridView2.Rows.Add()
            DataGridView2.Item("bobot", i).Value = Perhitungan.DataBobot(i).kode
            DataGridView2.Item("perbaikan", i).Value = Math.Round(Perhitungan.DataBobot(i).bobot / sumBobot(Perhitungan.DataBobot), 2)
        Next
    End Sub

    Sub TampilkanAlternatif()
        DataGridView1.Columns.Clear()
        DataGridView1.Columns.Add("no", "No")
        DataGridView1.Columns.Add("kode", "Kode")
        DataGridView1.Columns.Add("alternatif", "Nama_Alternatif")
        For j As Integer = 0 To UBound(Perhitungan.DataBobot)
            DataGridView1.Columns.Add(Perhitungan.DataBobot(j).kode, Perhitungan.DataBobot(j).nama & "(" & Perhitungan.DataBobot(j).bobot & ")")
        Next
        DataGridView1.Columns.Add("hasils", "Hasil S")
        DataGridView1.Columns.Add("hasilv", "Hasil V")
        DataGridView1.Columns.Add("hasil", "Hasil")

        Dim i As Integer = 0
        For Each item As Alternatif In Perhitungan.DataAlternatif
            DataGridView1.Rows.Add()
            DataGridView1.Item("no", i).Value = i + 1
            DataGridView1.Item("kode", i).Value = item.kode
            SqlQuery = "select * from alternatif where `Kode_Alternatif`='" & item.kode & "'"
            PerintahDatabase = New OleDbCommand(SqlQuery, Koneksi)
            Try
                DataReader = PerintahDatabase.ExecuteReader
                While DataReader.Read
                    DataGridView1.Item("alternatif", i).Value = DataReader(1)
                End While
                DataReader.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            DataGridView1.Item("hasils", i).Value = item.hasilS
            DataGridView1.Item("hasilv", i).Value = item.hasilV
            DataGridView1.Item("hasil", i).Value = item.hasil * 100
            For j As Integer = 0 To UBound(Perhitungan.DataAlternatif(i).kriteria)
                With Perhitungan.DataAlternatif(i)
                    DataGridView1.Item(.kriteria(j).kode, i).Value = .kriteria(j).nilai
                End With
            Next

            i += 1
        Next
    End Sub

    Private Sub frmHasil_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        konek()
        Label1.Visible = False
        TextBox1.Visible = False
    End Sub

    Private Sub Simpan(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If DataGridView1.RowCount > 1 Then
            Try
                SimpanDataKriteria = "delete from hasil"
                PerintahDatabase = New OleDbCommand(SimpanDataKriteria, Koneksi)
                PerintahDatabase.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            For i As Integer = 0 To DataGridView1.RowCount - 2
                SimpanDataKriteria = "insert into data_hasil(`No`,`Kode`,`Nama_Alternatif`,`Hasil S`,`Hasil V`,`Hasil`) values('" & DataGridView1.Item("No", i).Value & "','" & DataGridView1.Item("Kode", i).Value & "','" & DataGridView1.Item("alternatif", i).Value & "','" & DataGridView1.Item("hasils", i).Value & "','" & DataGridView1.Item("hasilv", i).Value & "','" & DataGridView1.Item("hasil", i).Value & "')"
                PerintahDatabase = New OleDbCommand(SimpanDataKriteria, Koneksi)
                Try
                    PerintahDatabase.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            Next

            For i As Integer = 0 To DataGridView1.RowCount - 2
                SqlQuery = "insert into hasil(`Kode_Alternatif`,`Hasil`) values('" & DataGridView1.Item("kode", i).Value & "','" & DataGridView1.Item("hasil", i).Value & "')"
                PerintahDatabase = New OleDbCommand(SqlQuery, Koneksi)
                Try
                    PerintahDatabase.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            Next
            MsgBox("Data Tersimpan")
        End If

    End Sub



    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Call TampilkanHasil()
    End Sub


    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Hide()
        Form6.Show()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.Close()
        Form2.Label3.Visible = True
        Form2.Label4.Visible = True
        Form2.PictureBox2.Visible = True
        Form2.PictureBox3.Visible = False
        Form2.PictureBox4.Visible = False
        Form2.PictureBox5.Visible = False
        Form2.PictureBox6.Visible = False
        Form2.Label5.Visible = False
        Form2.Label6.Visible = False
        Form2.Label7.Visible = False
        Form2.Label8.Visible = False
        Form2.Show()
    End Sub
End Class