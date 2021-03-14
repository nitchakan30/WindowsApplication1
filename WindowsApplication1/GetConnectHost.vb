Imports System
Imports System.IO

Public Class GetConnectHost

    Public Function getConnect()
        Dim strline As String       'ใช้สำหรับอ่านไฟล์ที่ละบรรทัด
        Dim strtext() As String     'ใช้สำหรับเก็บข้อความแบบ array
        Dim delim As Char() = ":"
        Dim txtNew As String = ""
        'D:\WORK_POS\POSsystem\WindowsApplication1\
        Dim i As Integer = 0
        Dim st As StreamReader = New StreamReader("Connector.txt") 'Parth file ที่อ่านข้อมูลเข้ามา

        While st.Peek <> -1
            strline = st.ReadLine()
            strtext = strline.Split(delim)
            If i > 0 Then
                txtNew &= ";"
            End If
            i = i + 1
            txtNew &= strtext(0) & "=" & strtext(1)
        End While
        txtNew.Substring(0, txtNew.Length - 1)

        Return txtNew
    End Function
End Class