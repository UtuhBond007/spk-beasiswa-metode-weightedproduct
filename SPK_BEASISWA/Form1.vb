Imports System.Data.SqlClient
Imports System.Configuration

Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Form2.Show()
        Me.Hide()
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If CheckBox1.Checked Then
            TextBox2.PasswordChar = ""
        Else
            TextBox2.PasswordChar = "*"
        End If

    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        If MsgBox("Keluar dari Program?", vbYesNo + vbInformation, "Perhatian") = vbYes Then
            Me.Close()
        End If
    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            MessageBox.Show("Username atau Password Kosong", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim database As New System.Data.OleDb.OleDbConnection
            database.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= spk_beasiswa.mdb;Persist Security Info=False"

            Try
                Dim access As String = "SELECT * FROM login WHERE Username = '" & TextBox1.Text & "' AND Password = '" & TextBox2.Text & "'"
                Dim dbaccess As New System.Data.OleDb.OleDbCommand(access)

                dbaccess.Connection = database
                database.Open()

                Dim accessreader As System.Data.OleDb.OleDbDataReader = dbaccess.ExecuteReader()
                If accessreader.Read Then
                    MsgBox("Login Berhasil", vbInformation, "Perhatian")
                    Form10.Show()
                    Me.Hide()
                Else
                    MessageBox.Show("Username atau Password Salah", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    TextBox1.Text = ""
                    TextBox2.Text = ""
                End If
            Catch ex As Exception

            End Try
        End If
        TextBox1.Text = ""
        TextBox2.Text = ""
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            TextBox2.PasswordChar = ""
        Else
            TextBox2.PasswordChar = "*"
        End If
    End Sub
End Class
