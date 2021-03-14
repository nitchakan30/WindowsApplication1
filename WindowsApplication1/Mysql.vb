Imports System.Net.WebRequestMethods
Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Text
Imports System.ComponentModel

Public Class Mysql
    Dim MysqlConn As MySqlConnection
    Dim mycommand As MySqlCommand
    Dim status As Boolean = False
    Public database As String = ""
    Public server As String = ""
    Public nameDb As String = ""
    Public Function mysql_connect()
        Try
            MysqlConn = New MySqlConnection()
            MysqlConn.ConnectionString = getDbConn().ToString()
            MysqlConn.Open()
            Return True
        Catch myerror As MySqlException
            Select Case myerror.Number
                Case 1041 : MsgBox("Error: Server error")
                Case 1044 : MsgBox("Error: DB Error")
                Case 1045 : MsgBox("Error: Access denied")
                Case 1049 : MsgBox("Error: DB Error - Check the DB Name")
                Case Else
                    MsgBox("Error: " & Err.Number)
            End Select
            MessageBox.Show(myerror.Message)
            Return False
        End Try
    End Function

    Public Sub mysql_close()
        MysqlConn.Close()
        MysqlConn.Dispose()
    End Sub

    Public Function mysql_query(ByVal sql)
        status = mysql_connect()
        Dim txtArr() As String
        Dim reader As MySqlDataReader
        mycommand = New MySqlCommand(sql, MysqlConn)
        txtArr = sql.ToString.ToLower.Trim.Split(" ")
        If status = True Then
            Try
                If txtArr(0).Trim.ToLower = "select".ToLower Then
                    reader = mycommand.ExecuteReader()
                    Return reader
                Else
                    mycommand.ExecuteNonQuery()
                    Return True
                End If
            Catch e As MySqlException
                If txtArr(0).Trim.ToLower = "select".ToLower Then
                    mysql_close()
                    mysql_connect()
                    mycommand = New MySqlCommand(sql, MysqlConn)
                    reader = mycommand.ExecuteReader()
                    Return reader
                Else
                    'mycommand.ExecuteNonQuery()
                    Return False
                End If
            End Try
        Else
            Return False
        End If
        mysql_close()
    End Function

    Public Function mysql_num_rows(ByVal obj)
        Dim count As Integer = 0
        While (obj.Read())
            count += 1
        End While
        Return count
    End Function

    Public Function getDbConn()
        Dim objReader As New System.IO.StreamReader("cn.bat", Encoding.UTF8)
        Dim TextLine() As String
        Dim fulltext As String = ""

        fulltext &= "Persist Security Info=False;"
        Do While objReader.Peek() <> -1
            TextLine = objReader.ReadLine().ToString.Trim.Split(":")
            If TextLine(0).ToString.Trim = "Server" Then
                fulltext &= "Server=" & TextLine(1).ToString.Trim
                server = TextLine(1).ToString.Trim
            ElseIf TextLine(0).ToString.Trim = "Port" Then
                fulltext &= ";Port=" & TextLine(1).ToString.Trim
            ElseIf TextLine(0).ToString.Trim = "Database" Then
                fulltext &= ";Database=" & TextLine(1).ToString.Trim
                database = TextLine(1).ToString.Trim
            ElseIf TextLine(0).ToString.Trim = "User Id" Then
                fulltext &= ";User Id=" & TextLine(1).ToString.Trim
            ElseIf TextLine(0).ToString.Trim = "Password" Then
                fulltext &= ";Password=" & TextLine(1).ToString.Trim
            End If
        Loop
        fulltext &= ";Character Set=utf8;pooling=false"
        objReader.Close()
        Return fulltext
    End Function
End Class
