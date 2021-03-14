Imports MySql.Data.MySqlClient
Public Class Admin_ConfigTBONOFF
    Dim ac As New Admin_ClassMain
    Dim cn As New GetConnectHost
    Dim ServerString As String = cn.getConnect()  '"Server=localhost;User Id=root;Password=root;Port=3306;Database=pos;"
    Dim SqlConnection As MySqlConnection = New MySqlConnection

    Dim arr_OnTb As String = "0"

    Private Sub Admin_ConfigTBONOFF_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Connect To SERVER 
        SqlConnection.ConnectionString = ServerString
        Try
            If SqlConnection.State = ConnectionState.Closed Then
                SqlConnection.Open()
                'MsgBox("Connections is successfully")
            Else
                SqlConnection.Close()
                MsgBox("Connections is closed")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        loadData() 'แสดงข้อมูล
    End Sub
    Private Sub Admin_ConfigTBONOFF_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        SqlConnection.Close()
    End Sub

    Private Sub Admin_ConfigTBONOFF_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        SqlConnection.Close()
    End Sub
    Public Sub loadData()
        Dim cmd5 As MySqlCommand = New MySqlCommand()
        With cmd5
            .CommandText = "SELECT * FROM pos_table_onoff WHERE id='0'"
            .CommandType = CommandType.Text
            .Connection = SqlConnection
            .ExecuteNonQuery()
        End With

        Dim reader As MySqlDataReader = cmd5.ExecuteReader()
        While reader.Read()
            If reader.GetString("status_tb") = "0" Then
                SetOff_TB()
            Else
                SetOn_TB()
            End If
        End While
        reader.Close()
    End Sub
    Public Sub InsertFiled(ByRef SQLStatement As String, ByVal msgShow As String)
        Dim cmd1 As MySqlCommand = New MySqlCommand
        With cmd1
            .CommandText = SQLStatement
            .CommandType = CommandType.Text
            .Connection = SqlConnection
            .ExecuteNonQuery()
        End With
        If msgShow <> "" Then
            MsgBox(msgShow)
        End If

    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub
    Public Sub SetOff_TB()
        btnOnTBOpen.BackColor = Color.DarkGray
        btnOnTBOff.BackColor = Color.Red
        arr_OnTb = "0"
    End Sub
    Public Sub SetOn_TB()
        btnOnTBOpen.BackColor = Color.LimeGreen
        btnOnTBOff.BackColor = Color.DarkGray
        arr_OnTb = "1"
    End Sub

    Private Sub btnOnTBOff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOnTBOff.Click
        SetOff_TB()
        InsertFiled("UPDATE pos_table_onoff SET status_tb='" & arr_OnTb & "' WHERE id='0' ", "Update Data Complete")
    End Sub

    Private Sub btnOnTBOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOnTBOpen.Click
        SetOn_TB()
        InsertFiled("UPDATE pos_table_onoff SET status_tb='" & arr_OnTb & "' WHERE id='0' ", "Update Data Complete")
    End Sub
End Class