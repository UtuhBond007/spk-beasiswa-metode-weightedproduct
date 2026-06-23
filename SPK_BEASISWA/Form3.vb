Imports System.Data.OleDb
Public Class Form3

    Public Koneksi As New OleDbConnection("provider=microsoft.jet.oledb.4.0;data source=spk_beasiswa.mdb")
    Public PerintahDatabase As OleDbCommand
    Public DataAdapter As OleDbDataAdapter
    Public DataSet As DataSet
    Public DataReader As OleDbDataReader
    Public SqlQuery As String

    Sub konek()
        If Koneksi.State = ConnectionState.Closed Then
            Koneksi.Open()
        End If
    End Sub

    Sub tampilData()
        DataAdapter = New OleDbDataAdapter("select * from kriteria order by `Kode_Kriteria` Asc", Koneksi)
        DataSet = New DataSet
        DataAdapter.Fill(DataSet, "kriteria")
        DataGridView1.DataSource = DataSet.Tables(0)
    End Sub

    Private Sub bersih()
        txt_bobot.Text = String.Empty
        txt_kode.Text = String.Empty
        txt_nama.Text = String.Empty
    End Sub

    Private Sub aktifteks()
        txt_bobot.ReadOnly = False
        txt_kode.ReadOnly = False
        txt_nama.ReadOnly = False
        cb_atribut.Enabled = True
    End Sub

    Private Sub nonaktifteks()
        txt_bobot.ReadOnly = True
        txt_kode.ReadOnly = True
        txt_nama.ReadOnly = True
        cb_atribut.Enabled = False
    End Sub

    Private Sub aktifbtn()
        btn_tambah.Enabled = True
        btn_hapus.Enabled = False
        btn_batal.Enabled = False
        btn_ubah.Enabled = False
        btn_simpan.Enabled = False
        btn_ubah.Text = "&Ubah"
    End Sub

    Private Sub nonaktifbtn()
        btn_tambah.Enabled = False
        btn_hapus.Enabled = False
        btn_batal.Enabled = True
        btn_ubah.Enabled = False
        btn_simpan.Enabled = True
    End Sub

    Private Sub Mulai(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        konek()
        tampilData()

        nonaktifteks()
        aktifbtn()
    End Sub

    Private Sub Baru(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_tambah.Click
        txt_kode.Enabled = True
        txt_kode.Clear()
        txt_nama.Clear()
        txt_bobot.Clear()
        txt_kode.Focus()
        nonaktifbtn()
        aktifteks()
    End Sub

    Private Sub Simpan(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_simpan.Click
        SqlQuery = "insert into kriteria(`Kode_Kriteria`,`Nama_Kriteria`,`Bobot`,`Atribut`) values('" & txt_kode.Text & "','" & txt_nama.Text & "','" & txt_bobot.Text & "','" & cb_atribut.Text & "')"
        If txt_kode.Text <> "" And txt_nama.Text <> "" And Val(txt_bobot.Text) > 0 Then
            Try
                PerintahDatabase = New OleDbCommand(SqlQuery, Koneksi)
                PerintahDatabase.ExecuteNonQuery()
                MsgBox("Data Berhasil Ditambahkan", vbInformation, "Perhatian")
                tampilData()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
        txt_bobot.Text = ""
        txt_kode.Text = ""
        txt_nama.Text = ""
        cb_atribut.Text = ""

        aktifbtn()
        bersih()
        nonaktifteks()
    End Sub

    Private Sub Edit(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ubah.Click
        If btn_ubah.Text = "&Ubah" Then
            btn_ubah.Text = "&Update"
            btn_batal.Enabled = True
            aktifteks()
        ElseIf btn_ubah.Text = "&Update" Then
            SqlQuery = "update kriteria set `Nama_Kriteria`='" & txt_nama.Text & "',`Bobot`='" & txt_bobot.Text & "',`Atribut`='" & cb_atribut.Text & "' where `Kode_Kriteria`='" & txt_kode.Text & "'"
            If txt_kode.Text <> "" And txt_nama.Text <> "" And Val(txt_bobot.Text) > 0 Then
                Try
                    PerintahDatabase = New OleDbCommand(SqlQuery, Koneksi)
                    PerintahDatabase.ExecuteNonQuery()
                    MsgBox("Data Berhasil Diubah", vbInformation, "Perhatian")
                    tampilData()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
            aktifbtn()
            bersih()
        End If
        txt_bobot.Text = ""
        txt_kode.Text = ""
        txt_nama.Text = ""
        cb_atribut.Text = ""
    End Sub

    Private Sub Hapus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_hapus.Click
        SqlQuery = "delete from kriteria where `Kode_Kriteria`='" & txt_kode.Text & "'"
        If txt_kode.Text <> "" And txt_nama.Text <> "" And Val(txt_bobot.Text) > 0 Then
            Try
                PerintahDatabase = New OleDbCommand(SqlQuery, Koneksi)
                PerintahDatabase.ExecuteNonQuery()
                MsgBox("Data Berhasil Dihapus", vbInformation, "Perhatian")
                tampilData()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
        txt_bobot.Text = ""
        txt_kode.Text = ""
        txt_nama.Text = ""
        cb_atribut.Text = ""
    End Sub

    Private Sub Keluar(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_keluar.Click
        Me.Close()
        Form2.Show()
    End Sub

    Private Sub TampilKeTextBoxKetikaKlikDataGrid(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        nonaktifteks()
        btn_ubah.Enabled = True
        txt_kode.Text = DataGridView1.Item(0, e.RowIndex).Value
        txt_nama.Text = DataGridView1.Item(1, e.RowIndex).Value
        txt_bobot.Text = DataGridView1.Item(2, e.RowIndex).Value
        cb_atribut.Text = DataGridView1.Item(3, e.RowIndex).Value
        btn_hapus.Enabled = True
        btn_batal.Enabled = False
        btn_simpan.Enabled = False
    End Sub

    Private Sub btn_batal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_batal.Click
        aktifbtn()
        bersih()
        nonaktifteks()
    End Sub

End Class