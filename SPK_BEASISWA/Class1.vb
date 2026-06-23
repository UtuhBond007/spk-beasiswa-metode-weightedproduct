Imports System.Math

Public Module strukturdata
    Public Structure Bobot
        Dim bobot As Double
        Dim atribut As Boolean
        Dim kode As String
        Dim nama As String
    End Structure

    Public Structure Kriteria
        Dim kode As String
        Dim nilai As String
    End Structure

    Public Structure Alternatif
        Dim kode As String
        Dim nama As String
        Dim kriteria() As Kriteria
        Dim hasilS As Double
        Dim hasilV As Double
        Dim hasil As Double
    End Structure

End Module

Public Class Hasil_WP
    Private JlhKriteria As Integer = 0
    Private JlhAlternatif As Integer = 0
    Public DataBobot() As Bobot
    Public DataAlternatif() As Alternatif
    'Public Analisa As String = ""

    WriteOnly Property JumlahKriteria()
        Set(ByVal value)
            JlhKriteria = value
            Console.WriteLine("Jumlah Kriteria = " & JlhKriteria)
        End Set
    End Property

    WriteOnly Property JumlahAlternatif()
        Set(ByVal value)
            JlhAlternatif = value
            Console.WriteLine("Jumlah Alternatif = " & JlhAlternatif)
        End Set
    End Property

    Sub TampilKriteria()
        'Analisa &= "Data Kriteria" & vbCrLf
        For i As Integer = 0 To DataAlternatif(0).kriteria.Count - 1
            'Analisa &= DataAlternatif(0).kriteria(i).kode & "( " & DataBobot(i).bobot & " ) Attribut : " & Attribut(DataBobot(i).atribut) & vbCrLf
        Next
        'Analisa &= "Jumlah Bobot : " & sumBobot(DataBobot) & vbCrLf & vbCrLf
    End Sub

    Sub tampilAlternatif()
        'Analisa &= "Data Alternatif" & vbCrLf
        For i As Integer = 0 To UBound(DataAlternatif)
            'Analisa &= "Alternatif " & i & ": " & DataAlternatif(i).kode & vbCrLf
            For j As Integer = 0 To UBound(DataAlternatif(i).kriteria)
                'Analisa &= vbTab & "Kriteria " & j & ": " & DataAlternatif(i).kriteria(j).kode & "= " & DataAlternatif(i).kriteria(j).nilai & vbCrLf
            Next
        Next
        'Analisa &= vbCrLf
    End Sub

    Function Attribut(ByVal data As Boolean) As String
        If data Then
            Return "Keuntungan"
        Else
            Return "Biaya"
        End If
    End Function

    Sub CariWP()
        'Analisa = ""
        Dim bobotBaru() As Double = Nothing
        Dim skorAlternatif() As Double = Nothing
        Dim perangkingan() As Double = Nothing

        If JlhKriteria > 0 Then
            If DataBobot.Length > 0 Then
                If JlhAlternatif > 0 Then
                    If DataAlternatif.Length = JlhAlternatif Then
                        'Koding Untuk Perbaiki Bobot
                        Console.WriteLine("Menghitung Bobot Baru")
                        'Analisa &= "Menghitung Bobot Baru" & vbCrLf
                        Dim nilaiBobotSementara As New List(Of Double)
                        For Each item As Bobot In DataBobot
                            If item.atribut = True Then
                                nilaiBobotSementara.Add(Round(item.bobot / sumBobot(DataBobot), 2))
                                Console.WriteLine("Bobot = " & item.bobot & "/" & sumBobot(DataBobot) & "=" & (Round(item.bobot / sumBobot(DataBobot), 2)))
                                'Analisa &= "Bobot = " & item.bobot & "/" & sumBobot(DataBobot) & "=" & (Round(item.bobot / sumBobot(DataBobot), 2)) & vbCrLf
                            Else
                                nilaiBobotSementara.Add(Round((item.bobot / sumBobot(DataBobot)) * -1, 2))
                                Console.WriteLine("Bobot = " & item.bobot & "/" & sumBobot(DataBobot) & "*-1=" & (Round((item.bobot / sumBobot(DataBobot)) * -1, 2)))
                                'Analisa &= "Bobot = " & item.bobot & "/" & sumBobot(DataBobot) & "*-1=" & (Round((item.bobot / sumBobot(DataBobot)) * -1, 2)) & vbCrLf
                            End If
                        Next
                        bobotBaru = nilaiBobotSementara.ToArray

                        'Menghitung nilai atau skor alternatif
                        Console.WriteLine("Menghitung nilai atau skor alternatif")
                        'Analisa &= vbCrLf
                        'Analisa &= "Menghitung nilai atau skor alternatif" & vbCrLf
                        Dim nilaiSkorAlternatifSementara As New List(Of Double)
                        For Each SatuanAlternatif As Alternatif In DataAlternatif
                            Dim nilaiSkorSatuanAlternatif As Double = 1
                            Dim j As Integer = 0
                            Console.Write("S?=")
                            'Analisa &= "S?="

                            For Each SatuanKriteria As Kriteria In SatuanAlternatif.kriteria
                                nilaiSkorSatuanAlternatif *= (SatuanKriteria.nilai ^ bobotBaru(j))
                                'Console.Write("(" & SatuanKriteria.nilai & "^" & bobotBaru(j) & ")")
                                Console.Write("(" & (SatuanKriteria.nilai ^ bobotBaru(j)) & ")")
                                'Analisa &= "(" & (SatuanKriteria.nilai ^ bobotBaru(j)) & ")"
                                j += 1
                            Next
                            nilaiSkorAlternatifSementara.Add(Round(nilaiSkorSatuanAlternatif, 4))
                            Console.WriteLine("=" & Round(nilaiSkorSatuanAlternatif, 4))
                            'Analisa &= "=" & Round(nilaiSkorSatuanAlternatif, 4) & vbCrLf
                        Next
                        skorAlternatif = nilaiSkorAlternatifSementara.ToArray

                        For j As Integer = 0 To UBound(DataAlternatif)
                            DataAlternatif(j).hasilS = skorAlternatif(j)
                        Next

                        'Menentukan Perangkingan jurusan atau alternatif yang terbaik dari setiap alternatif
                        Console.WriteLine("Menentukan Perangkingan jurusan atau alternatif yang terbaik dari setiap alternatif")
                        'Analisa &= vbCrLf
                        'Analisa &= "Menentukan Perangkingan jurusan atau alternatif yang terbaik dari setiap alternatif" & vbCrLf

                        Dim perangkinganSementara As New List(Of Double)
                        For Each SatuanSkorAlternatif As Double In skorAlternatif
                            perangkinganSementara.Add(Round(SatuanSkorAlternatif / sumArray(skorAlternatif), 4))
                            Console.WriteLine("V?=" & SatuanSkorAlternatif & "/" & sumArray(skorAlternatif) & "=" & (SatuanSkorAlternatif / sumArray(skorAlternatif)))
                            'Analisa &= "V?=" & SatuanSkorAlternatif & "/" & sumArray(skorAlternatif) & "=" & (SatuanSkorAlternatif / sumArray(skorAlternatif)) & vbCrLf
                        Next
                        perangkingan = perangkinganSementara.ToArray

                        For j As Integer = 0 To UBound(DataAlternatif)
                            DataAlternatif(j).hasilV = perangkingan(j)
                        Next

                        'Mengisi nilai perangkingan ke variabel DataAlternatif
                        Dim i As Integer = 0
                        For Each nilai As Double In perangkingan
                            DataAlternatif(i).hasil = nilai
                            i += 1
                        Next
                    Else
                        MsgBox("Data Alternatif dengan Jumlah Alternatif Tidak Sama!")
                    End If
                Else
                    MsgBox("Jumlah Alternatif Belum Diisi")
                End If
            Else
                MsgBox("Bobot Belum Diisi!")
            End If
        Else
            MsgBox("Jumlah Kriteria Belum Diisi")
        End If
    End Sub

    Private Function sumBobot(ByVal nilai As Bobot())
        Dim hasil As Double = 0
        For Each item As Bobot In nilai
            hasil += item.bobot
        Next
        Return hasil
    End Function

    Private Function sumArray(ByVal nilaiArray() As Double)
        Dim hasil As Double = 0
        For Each Item As Double In nilaiArray
            hasil += Item
        Next
        Return hasil
    End Function
End Class
