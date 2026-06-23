Imports System.Data.OleDb
Public Class Form11

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
        DataAdapter = New OleDbDataAdapter("select * from login order by `Kode_Admin` Asc", Koneksi)
        DataSet = New DataSet
        DataAdapter.Fill(DataSet, "login")
        DataGridView1.DataSource = DataSet.Tables(0)
    End Sub

    Private Sub bersih()
        txt_username.Text = String.Empty
        txt_kode.Text = String.Empty
        txt_nama.Text = String.Empty
    End Sub

    Private Sub aktifteks()
        txt_username.ReadOnly = False
        txt_kode.ReadOnly = False
        txt_nama.ReadOnly = False
        txt_password.Enabled = True
    End Sub

    Private Sub nonaktifteks()
        txt_username.ReadOnly = True
        txt_kode.ReadOnly = True
        txt_nama.ReadOnly = True
        txt_password.Enabled = False
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

    Private Sub TampilKeTextBoxKetikaKlikDataGrid(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        nonaktifteks()
        btn_ubah.Enabled = True
        txt_kode.Text = DataGridView1.Item(0, e.RowIndex).Value
        txt_nama.Text = DataGridView1.Item(1, e.RowIndex).Value
        txt_username.Text = DataGridView1.Item(2, e.RowIndex).Value
        txt_password.Text = DataGridView1.Item(3, e.RowIndex).Value
        btn_hapus.Enabled = True
        btn_batal.Enabled = False
        btn_simpan.Enabled = False
    End Sub

    Private Sub Baru(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_tambah.Click
        txt_kode.Enabled = True
        txt_kode.Clear()
        txt_nama.Clear()
        txt_username.Clear()
        txt_kode.Focus()
        nonaktifbtn()
        aktifteks()
    End Sub

    Private Sub btn_simpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_simpan.Click
        SqlQuery = "insert into login(`Kode_Admin`,`Nama_Admin`,`Username`,`Password`) values('" & txt_kode.Text & "','" & txt_nama.Text & "','" & txt_username.Text & "','" & txt_password.Text & "')"
        If txt_kode.Text <> "" And txt_nama.Text <> "" And txt_username.Text <> "" And txt_password.Text <> "" Then
            Try
                PerintahDatabase = New OleDbCommand(SqlQuery, Koneksi)
                PerintahDatabase.ExecuteNonQuery()
                MsgBox("Data Berhasil Ditambahkan", vbInformation, "Perhatian")
                tampilData()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

        aktifbtn()
        bersih()
        nonaktifteks()
    End Sub

    Private Sub btn_batal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_batal.Click
        aktifbtn()
        bersih()
        nonaktifteks()
    End Sub

    Private Sub btn_hapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_hapus.Click
        SqlQuery = "delete from login where `Kode_Admin`='" & txt_kode.Text & "'"
        If txt_kode.Text <> "" And txt_nama.Text <> "" And txt_username.Text <> "" And txt_password.Text <> "" Then
            Try
                PerintahDatabase = New OleDbCommand(SqlQuery, Koneksi)
                PerintahDatabase.ExecuteNonQuery()
                MsgBox("Data Berhasil Dihapus", vbInformation, "Perhatian")
                tampilData()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub btn_keluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_keluar.Click
        Me.Close()
        Form2.Show()
    End Sub

    Private Sub btn_ubah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ubah.Click
        If btn_ubah.Text = "&Ubah" Then
            btn_ubah.Text = "&Update"
            btn_batal.Enabled = True
            aktifteks()
        ElseIf btn_ubah.Text = "&Update" Then
            SqlQuery = "update login set `Nama_Admin`='" & txt_nama.Text & "',`Username`='" & txt_username.Text & "',`Password`='" & txt_password.Text & "' where `Kode_Admin`='" & txt_kode.Text & "'"
            If txt_kode.Text <> "" And txt_nama.Text <> "" And txt_username.Text <> "" And txt_password.Text <> "" Then
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
    End Sub
End Class