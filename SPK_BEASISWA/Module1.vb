Imports System.Data.OleDb
Module Module1

    Public Koneksi As New OleDbConnection("provider=microsoft.jet.oledb.4.0;data source=spk_beasiswa.mdb")
    Public PerintahDatabase As OleDbCommand
    Public DataAdapter As OleDbDataAdapter
    Public DataSet As DataSet
    Public DataReader As OleDbDataReader
    Public SimpanDataKriteria As String
    Public SqlQuery As String

    Sub konek()
        If Koneksi.State = ConnectionState.Closed Then
            Koneksi.Open()
        End If
    End Sub

End Module
