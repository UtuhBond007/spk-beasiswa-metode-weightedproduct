Imports System.Data.OleDb
Public Class Form13

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
        DataAdapter = New OleDbDataAdapter("select * from data_siswa order by `Kode_Siswa` Asc", Koneksi)
        DataSet = New DataSet
        DataAdapter.Fill(DataSet, "data_siswa")
        DataGridView1.DataSource = DataSet.Tables(0)
    End Sub

    Sub aktifteks()
        txt_agama.ReadOnly = False
        txt_alamatortu.ReadOnly = False
        txt_alamats.ReadOnly = False
        txt_alamatwali.ReadOnly = False
        txt_jk.ReadOnly = False
        txt_jurusan.ReadOnly = False
        txt_kelas.ReadOnly = False
        txt_kode.ReadOnly = False
        txt_namaayah.ReadOnly = False
        txt_namaibu.ReadOnly = False
        txt_namas.ReadOnly = False
        txt_namawali.ReadOnly = False
        txt_nisn.ReadOnly = False
        txt_pekerjaanayah.ReadOnly = False
        txt_pekerjaanibu.ReadOnly = False
        txt_pekerjaanwali.ReadOnly = False
        txt_teleponortu.ReadOnly = False
        txt_telepons.ReadOnly = False
        txt_teleponwali.ReadOnly = False
        txt_ttl.ReadOnly = False
    End Sub

    Sub nonaktifteks()
        txt_agama.ReadOnly = True
        txt_alamatortu.ReadOnly = True
        txt_alamats.ReadOnly = True
        txt_alamatwali.ReadOnly = True
        txt_jk.ReadOnly = True
        txt_jurusan.ReadOnly = True
        txt_kelas.ReadOnly = True
        txt_kode.ReadOnly = True
        txt_namaayah.ReadOnly = True
        txt_namaibu.ReadOnly = True
        txt_namas.ReadOnly = True
        txt_namawali.ReadOnly = True
        txt_nisn.ReadOnly = True
        txt_pekerjaanayah.ReadOnly = True
        txt_pekerjaanibu.ReadOnly = True
        txt_pekerjaanwali.ReadOnly = True
        txt_teleponortu.ReadOnly = True
        txt_telepons.ReadOnly = True
        txt_teleponwali.ReadOnly = True
        txt_ttl.ReadOnly = True
    End Sub

    Sub aktifbutton()
        btn_batal.Enabled = True
        btn_hapus.Enabled = True
        btn_simpan.Enabled = True
        btn_tutup.Enabled = True
        btn_ubah.Enabled = True
    End Sub

    Sub nonaktifbutton()
        btn_batal.Enabled = False
        btn_hapus.Enabled = False
        btn_simpan.Enabled = False
        btn_ubah.Enabled = False
    End Sub

    Sub bersih()
        txt_agama.Text = String.Empty
        txt_alamatortu.Text = String.Empty
        txt_alamats.Text = String.Empty
        txt_alamatwali.Text = String.Empty
        txt_jk.Text = String.Empty
        txt_jurusan.Text = String.Empty
        txt_kelas.Text = String.Empty
        txt_kode.Text = String.Empty
        txt_namaayah.Text = String.Empty
        txt_namaibu.Text = String.Empty
        txt_namas.Text = String.Empty
        txt_namawali.Text = String.Empty
        txt_nisn.Text = String.Empty
        txt_pekerjaanayah.Text = String.Empty
        txt_pekerjaanibu.Text = String.Empty
        txt_pekerjaanwali.Text = String.Empty
        txt_teleponortu.Text = String.Empty
        txt_telepons.Text = String.Empty
        txt_teleponwali.Text = String.Empty
        txt_ttl.Text = String.Empty
    End Sub

    Private Sub btn_simpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_simpan.Click

        SqlQuery = "insert into data_siswa(`Kode_Siswa`,`Nama_Siswa`,`NISN`,`TTL`,`Jenis_Kelamin`,`Agama`,`Jurusan`,`Kelas`,`Alamat`,`Telepon`,`Nama_Ayah`,`Nama_Ibu`,`Alamat_Ortu`,`Telepon_Ortu`,`Pekerjaan_Ayah`,`Pekerjaan_Ibu`,`Nama_Wali`,`Pekerjaan_Wali`,`Alamat_Wali`,`Telepon_Wali`) values('" & txt_kode.Text & "','" & txt_namas.Text & "','" & txt_nisn.Text & "','" & txt_ttl.Text & "','" & txt_jk.Text & "','" & txt_agama.Text & "','" & txt_jurusan.Text & "','" & txt_kelas.Text & "','" & txt_alamats.Text & "','" & txt_telepons.Text & "','" & txt_namaayah.Text & "','" & txt_namaibu.Text & "','" & txt_alamatortu.Text & "','" & txt_teleponortu.Text & "','" & txt_pekerjaanayah.Text & "','" & txt_pekerjaanibu.Text & "','" & txt_namawali.Text & "','" & txt_pekerjaanwali.Text & "','" & txt_alamatwali.Text & "','" & txt_teleponwali.Text & "')"
        If txt_kode.Text <> "" And txt_namas.Text <> "" And txt_nisn.Text <> "" Then
            Try
                PerintahDatabase = New OleDbCommand(SqlQuery, Koneksi)
                PerintahDatabase.ExecuteNonQuery()
                MsgBox("Data Berhasil Ditambahkan", vbInformation, "Perhatian")
                tampilData()
                bersih()
                nonaktifbutton()
                nonaktifteks()
                btn_tambah.Enabled = True
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub Form13_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        konek()
        tampilData()
        nonaktifteks()
        nonaktifbutton()
    End Sub

    Private Sub btn_tambah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_tambah.Click
        aktifbutton()
        aktifteks()
        txt_kode.Focus()
        btn_tambah.Enabled = False
    End Sub

    Private Sub btn_batal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_batal.Click
        nonaktifbutton()
        nonaktifteks()
        bersih()
        btn_tambah.Enabled = True
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        txt_kode.Text = DataGridView1.Item(0, e.RowIndex).Value
        txt_namas.Text = DataGridView1.Item(1, e.RowIndex).Value
        txt_nisn.Text = DataGridView1.Item(2, e.RowIndex).Value
        txt_ttl.Text = DataGridView1.Item(3, e.RowIndex).Value
        txt_jk.Text = DataGridView1.Item(4, e.RowIndex).Value
        txt_agama.Text = DataGridView1.Item(5, e.RowIndex).Value
        txt_jurusan.Text = DataGridView1.Item(6, e.RowIndex).Value
        txt_kelas.Text = DataGridView1.Item(7, e.RowIndex).Value
        txt_alamats.Text = DataGridView1.Item(8, e.RowIndex).Value
        txt_telepons.Text = DataGridView1.Item(9, e.RowIndex).Value
        txt_namaayah.Text = DataGridView1.Item(10, e.RowIndex).Value
        txt_namaibu.Text = DataGridView1.Item(11, e.RowIndex).Value
        txt_alamatortu.Text = DataGridView1.Item(12, e.RowIndex).Value
        txt_teleponortu.Text = DataGridView1.Item(13, e.RowIndex).Value
        txt_pekerjaanayah.Text = DataGridView1.Item(14, e.RowIndex).Value
        txt_pekerjaanibu.Text = DataGridView1.Item(15, e.RowIndex).Value
        txt_namawali.Text = DataGridView1.Item(16, e.RowIndex).Value
        txt_pekerjaanwali.Text = DataGridView1.Item(17, e.RowIndex).Value
        txt_alamatwali.Text = DataGridView1.Item(18, e.RowIndex).Value
        txt_teleponwali.Text = DataGridView1.Item(19, e.RowIndex).Value
        btn_ubah.Enabled = True
        btn_hapus.Enabled = True
        btn_batal.Enabled = True
    End Sub

    Private Sub btn_ubah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ubah.Click
        If btn_ubah.Text = "&Ubah" Then
            btn_ubah.Text = "&Update"
            btn_batal.Enabled = True
            aktifteks()
        ElseIf btn_ubah.Text = "&Update" Then
            SqlQuery = "update data_siswa set `Nama_Siswa`='" & txt_namas.Text & "',`NISN`='" & txt_nisn.Text & "',`TTL`='" & txt_ttl.Text & "',`Jenis_Kelamin`='" & txt_jk.Text & "',`Agama`='" & txt_agama.Text & "',`Jurusan`='" & txt_jurusan.Text & "',`Kelas`='" & txt_kelas.Text & "',`Alamat`='" & txt_alamats.Text & "',`Telepon`='" & txt_telepons.Text & "',`Nama_Ayah`='" & txt_namaayah.Text & "',`Nama_Ibu`='" & txt_namaibu.Text & "',`Alamat_Ortu`='" & txt_alamatortu.Text & "',`Telepon_Ortu`='" & txt_teleponortu.Text & "',`Pekerjaan_Ayah`='" & txt_pekerjaanayah.Text & "',`Pekerjaan_Ibu`='" & txt_pekerjaanibu.Text & "',`Nama_Wali`='" & txt_namawali.Text & "',`Pekerjaan_Wali`='" & txt_pekerjaanwali.Text & "',`Alamat_Wali`='" & txt_alamatwali.Text & "',`Telepon_Wali`='" & txt_teleponwali.Text & "' where `Kode_Siswa`='" & txt_kode.Text & "'"
            If txt_kode.Text <> "" And txt_namas.Text <> "" And txt_nisn.Text <> "" Then
                Try
                    PerintahDatabase = New OleDbCommand(SqlQuery, Koneksi)
                    PerintahDatabase.ExecuteNonQuery()
                    MsgBox("Data Berhasil Diubah", vbInformation, "Perhatian")
                    tampilData()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
            aktifbutton()
            bersih()
            nonaktifbutton()
            nonaktifteks()
            btn_ubah.Refresh()
        End If
    End Sub

    Private Sub btn_hapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_hapus.Click
        SqlQuery = "delete from data_siswa where `Kode_Siswa`='" & txt_kode.Text & "'"
        If txt_kode.Text <> "" And txt_namas.Text <> "" Then
            Try
                PerintahDatabase = New OleDbCommand(SqlQuery, Koneksi)
                PerintahDatabase.ExecuteNonQuery()
                MsgBox("Data Berhasil Dihapus", vbInformation, "Perhatian")
                tampilData()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            bersih()
        End If
    End Sub

    Private Sub btn_tutup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_tutup.Click
        Me.Hide()
        Form2.Show()
    End Sub
End Class