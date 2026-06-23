Imports System.Data.OleDb
Public Class Form4

    Sub tampilData()
        DataGridView1.Columns.Clear()
        SqlQuery = "select * from alternatif order by `Kode_Alternatif`"
        PerintahDatabase = New OleDbCommand(SqlQuery, Koneksi)
        DataReader = PerintahDatabase.ExecuteReader
        Dim i As Integer = 0
        While DataReader.Read
            If i = 0 Then
                DataGridView1.Columns.Add("", "Kode_Alternatif")
                DataGridView1.Columns.Add("", "Nama_Alternatif")
            End If
            DataGridView1.Rows.Add()
            DataGridView1.Item(0, i).Value = DataReader(0)
            DataGridView1.Item(1, i).Value = DataReader(1)
            SqlQuery = "select * from kriteria order by `Kode_Kriteria`"
            PerintahDatabase = New OleDbCommand(SqlQuery, Koneksi)
            Dim DataReader2 As OleDbDataReader = PerintahDatabase.ExecuteReader
            Dim j As Integer = 0
            While DataReader2.Read
                If i = 0 Then
                    DataGridView1.Columns.Add("", DataReader2(1))
                End If
                SqlQuery = "select * from data_kriteria where `Kode_Alternatif`='" & DataReader(0) & "' and `Kode_Kriteria`='" & DataReader2(0) & "'"
                PerintahDatabase = New OleDbCommand(SqlQuery, Koneksi)
                Dim DataReader3 As OleDbDataReader = PerintahDatabase.ExecuteReader
                While DataReader3.Read
                    DataGridView1.Item(j + 2, i).Value = DataReader3(2) & "(" & DataReader3(3) & ")"
                End While
                DataReader3.Close()
                j += 1
            End While
            DataReader2.Close()
            i += 1
        End While
        DataReader.Close()
    End Sub

    Private Sub Mulai(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        konek()
        tampilData()
        btnaktif()
        nonaktifteks()
    End Sub

    Private Sub bersih()
        txt_kode.Text = String.Empty
        txt_nama.Text = String.Empty
    End Sub

    Private Sub Baru(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_tambah.Click
        txt_kode.Enabled = True
        txt_kode.Focus()
        txt_kode.Clear()
        txt_nama.Clear()
        DataGridView2.Columns.Clear()

        btnnonaktif()
        aktifteks()
    End Sub

    Private Sub CekKriteria(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cek.Click
        If txt_kode.Text <> "" And txt_nama.Text <> "" Then
            SqlQuery = "select * from kriteria order by `Kode_Kriteria` Asc"
            PerintahDatabase = New OleDbCommand(SqlQuery, Koneksi)
            DataReader = PerintahDatabase.ExecuteReader
            DataGridView2.Columns.Clear()
            DataGridView2.Columns.Add("", "Kode_Kriteria")
            DataGridView2.Columns.Add("", "Nama_Kriteria")
            DataGridView2.Columns.Add("", "Nilai_Huruf")
            DataGridView2.Columns.Add("", "Nilai_Angka")
            Dim i As Integer = 0
            While DataReader.Read
                DataGridView2.Rows.Add()
                DataGridView2.Item(0, i).Value = DataReader(0)
                DataGridView2.Item(1, i).Value = DataReader(1)
                SqlQuery = "select * from data_kriteria where `Kode_Alternatif`='" & txt_kode.Text & "' and `Kode_Kriteria`='" & DataReader(0) & "'"
                PerintahDatabase = New OleDbCommand(SqlQuery, Koneksi)
                Dim DataReader2 As OleDbDataReader = PerintahDatabase.ExecuteReader
                While DataReader2.Read
                    DataGridView2.Item(2, i).Value = DataReader2(2)
                    DataGridView2.Item(3, i).Value = DataReader2(3)
                End While
                DataReader2.Close()
                i += 1
            End While
            DataReader.Close()
            txt_kode.Enabled = False
        Else
            MsgBox("Harap Isi Kode dan Nama Alternatif!")
        End If
    End Sub

    Private Sub MengisiTextBoxKetikaDataGridDiKlik(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex < DataGridView1.RowCount - 1 Then
            txt_kode.Text = DataGridView1.Item(0, e.RowIndex).Value
            txt_nama.Text = DataGridView1.Item(1, e.RowIndex).Value
            txt_kode.Enabled = False
            Call CekKriteria(sender, e)
        End If

        btn_tambah.Enabled = False
        btn_simpan.Enabled = False
        btn_batal.Enabled = True
        btn_cek.Enabled = False
        btn_keluar.Enabled = True
        btn_ubah.Enabled = True
        btn_hapus.Enabled = True

    End Sub

    Private Sub Keluar(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_keluar.Click
        Me.Close()
        Form2.Show()
    End Sub

    Private Sub Simpan(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_simpan.Click
        If txt_kode.Text <> "" And txt_nama.Text <> "" Then
            If cekDataKriteria() = True Then
                SqlQuery = "insert into alternatif(`Kode_Alternatif`,`Nama_Alternatif`) values('" & txt_kode.Text & "','" & txt_nama.Text & "')"
                PerintahDatabase = New OleDbCommand(SqlQuery, Koneksi)
                Try
                    PerintahDatabase.ExecuteNonQuery()
                    For i As Integer = 0 To DataGridView2.RowCount - 2
                        SqlQuery = "insert into data_kriteria(`Kode_Alternatif`,`Kode_Kriteria`,`Nilai_Huruf`,`Nilai_Angka`) values ('" & _
                        txt_kode.Text & "','" & DataGridView2.Item(0, i).Value & "','" & _
                        DataGridView2.Item(2, i).Value & "','" & DataGridView2.Item(3, i).Value & "')"
                        PerintahDatabase = New OleDbCommand(SqlQuery, Koneksi)
                        Try
                            PerintahDatabase.ExecuteNonQuery()
                        Catch ex As Exception
                            MsgBox(ex.Message)
                            SqlQuery = "delete from alternatif where `Kode_Alternatif`='" & txt_kode.Text & "'"
                            PerintahDatabase = New OleDbCommand(SqlQuery, Koneksi)
                            PerintahDatabase.ExecuteNonQuery()
                        End Try
                    Next
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
                MsgBox("Data Berhasil Disimpan", vbInformation, "Perhatian")
                tampilData()

                btnaktif()

                nonaktifteks()
                txt_kode.Clear()
                txt_nama.Clear()
            End If
        Else
            MsgBox("Isilah Kode Alternatif dan Nama Alternatif")
        End If
        tampilData()

        btnaktif()
        nonaktifteks()
        txt_kode.Clear()
        txt_nama.Clear()
    End Sub

    Function cekDataKriteria() As Boolean
        Dim hasil As Boolean = True
        If DataGridView2.RowCount > 0 Then
            For i As Integer = 0 To DataGridView2.RowCount - 2
                If DataGridView2.Item(2, i).Value = "" Then
                    MsgBox("Nilai_Huruf, kriteria " & DataGridView2.Item(1, i).Value & " belum diisi")
                    hasil = False
                    GoTo selesai
                ElseIf Val(DataGridView2.Item(3, i).Value) < 1 Then
                    MsgBox("Nilai_Angka, kriteria " & DataGridView2.Item(1, i).Value & " harus lebih besar dari pada nol")
                    hasil = False
                    GoTo selesai
                End If
            Next
        Else
            MsgBox("Klik Cek Kriteria!")
            hasil = False
        End If
selesai:
        Return hasil
    End Function

    Sub HapusDb()
        SqlQuery = "delete from alternatif where `Kode_Alternatif`='" & txt_kode.Text & "'"
        PerintahDatabase = New OleDbCommand(SqlQuery, Koneksi)
        PerintahDatabase.ExecuteNonQuery()

        SqlQuery = "delete from data_kriteria where `Kode_Alternatif`='" & txt_kode.Text & "'"
        PerintahDatabase = New OleDbCommand(SqlQuery, Koneksi)
        PerintahDatabase.ExecuteNonQuery()
    End Sub

    Private Sub Hapus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_hapus.Click
        If txt_kode.Text <> "" And txt_nama.Text <> "" Then
            Try
                HapusDb()
                MsgBox("Data Berhasil Dihapus", vbInformation, "Perhatian")
                tampilData()
                Call Baru(sender, e)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            MsgBox("Isilah Kode Alternatif dan Nama Alternatif")
        End If
    End Sub

    Private Sub Edit(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ubah.Click
        If btn_ubah.Text = "&Ubah" Then
            btn_ubah.Text = "&Update"
            btn_batal.Enabled = True

            aktifteks()
        ElseIf btn_ubah.Text = "&Update" Then
            If txt_kode.Text <> "" And txt_nama.Text <> "" Then
                If cekDataKriteria() = True Then
                    Try
                        HapusDb()
                        Call Simpan(sender, e)
                        tampilData()
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                End If
            Else
                MsgBox("Isilah Kode Alternatif dan Nama Alternatif")
            End If

            btnaktif()
            nonaktifteks()
            txt_kode.Clear()
            txt_nama.Clear()
        End If
    End Sub

    Private Sub CariAlternatifBerdasarkanKodeAlternatif(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_kode.KeyPress
        If Asc(e.KeyChar) = 13 Then
            SqlQuery = "select * from alternatif where `Kode_Alternatif`='" & txt_kode.Text & "'"
            PerintahDatabase = New OleDbCommand(SqlQuery, Koneksi)
            DataReader = PerintahDatabase.ExecuteReader
            DataReader.Read()
            If DataReader.HasRows Then
                txt_kode.Text = DataReader(0)
                txt_nama.Text = DataReader(1)
                txt_kode.Enabled = False
                txt_nama.Focus()
                Call CekKriteria(sender, e)
            Else
                txt_kode.Enabled = False
                txt_nama.Focus()
                Call CekKriteria(sender, e)
            End If
        End If
    End Sub

    Private Sub aktifteks()
        txt_kode.ReadOnly = False
        txt_nama.ReadOnly = False
    End Sub

    Private Sub nonaktifteks()
        txt_kode.ReadOnly = True
        txt_nama.ReadOnly = True
    End Sub

    Private Sub btnaktif()
        btn_tambah.Enabled = True
        btn_batal.Enabled = False
        btn_cek.Enabled = False
        btn_hapus.Enabled = False
        btn_simpan.Enabled = False
        btn_ubah.Enabled = False
    End Sub

    Private Sub btnnonaktif()
        btn_tambah.Enabled = False
        btn_batal.Enabled = True
        btn_cek.Enabled = True
        btn_hapus.Enabled = False
        btn_simpan.Enabled = True
        btn_ubah.Enabled = False
    End Sub

    Private Sub btn_batal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_batal.Click
        nonaktifteks()
        btnaktif()

        txt_kode.Clear()
        txt_nama.Clear()
    End Sub

    Private Sub txt_kode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_kode.TextChanged
        txt_kode.ReadOnly = False
    End Sub
End Class