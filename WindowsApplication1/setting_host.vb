Imports MySql.Data.MySqlClient
Imports System
Imports System.IO
Imports System.Text
Imports System.Collections.Generic
Public Class setting_host
    Dim con As New Mysql
    Private Sub setting_host_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Load_DetailServer()
        Load_DetailFile()
    End Sub
    Private Sub Load_DetailServer()
        'โหลดข้อมูล Tabspage1
        Dim objReader As New System.IO.StreamReader("cn.bat", Encoding.UTF8)
        Dim TextLine() As String
        Do While objReader.Peek() <> -1
            TextLine = objReader.ReadLine().ToString.Trim.Split(":")
            If TextLine(0).ToString.Trim = "Server" Then
                server.Text = TextLine(1).ToString.Trim
            ElseIf TextLine(0).ToString.Trim = "User Id" Then
                user_id.Text = TextLine(1).ToString.Trim
            ElseIf TextLine(0).ToString.Trim = "Password" Then
                password.Text = TextLine(1).ToString.Trim
            ElseIf TextLine(0).ToString.Trim = "Port" Then
                port.Text = TextLine(1).ToString.Trim
            ElseIf TextLine(0).ToString.Trim = "Database" Then
                databaase.Text = TextLine(1).ToString.Trim
            End If
        Loop
        objReader.Close()

        Dim objReader1 As New System.IO.StreamReader("cn-front.bat", Encoding.UTF8)
        Dim TextLine1() As String
        Do While objReader1.Peek() <> -1
            TextLine1 = objReader1.ReadLine().ToString.Trim.Split(":")
            If TextLine1(0).ToString.Trim = "Server" Then
                server_f.Text = TextLine1(1).ToString.Trim
            ElseIf TextLine1(0).ToString.Trim = "User Id" Then
                user_id_f.Text = TextLine1(1).ToString.Trim
            ElseIf TextLine1(0).ToString.Trim = "Password" Then
                password_f.Text = TextLine1(1).ToString.Trim
            ElseIf TextLine1(0).ToString.Trim = "Port" Then
                port_f.Text = TextLine1(1).ToString.Trim
            ElseIf TextLine1(0).ToString.Trim = "Database" Then
                databaase_f.Text = TextLine1(1).ToString.Trim
            End If
        Loop
        objReader1.Close()
    End Sub
    Private Sub Load_DetailFile()
        'โหลดข้อมูล Tabspage1
        Dim objReader As New System.IO.StreamReader("active_fol.bat", Encoding.UTF8)
        Dim TextLine() As String
        Do While objReader.Peek() <> -1
            TextLine = objReader.ReadLine().ToString.Trim.Split("=")

            If TextLine(0).ToString.Trim = "folderAvatar" Then
                avatar.Text = TextLine(1).ToString.Trim
            ElseIf TextLine(0).ToString.Trim = "folderProduct" Then
                img_product.Text = TextLine(1).ToString.Trim
            ElseIf TextLine(0).ToString.Trim = "folderSystem" Then
                img_system.Text = TextLine(1).ToString.Trim
            ElseIf TextLine(0).ToString.Trim = "folderExcel" Then
                file_export.Text = TextLine(1).ToString.Trim
            ElseIf TextLine(0).ToString.Trim = "folderFileUpdate" Then
                File_Update.Text = TextLine(1).ToString.Trim
            ElseIf TextLine(0).ToString.Trim = "ServerReport" Then
                Server_Report.Text = TextLine(1).ToString.Trim
            End If
        Loop
        objReader.Close()
    End Sub

    Private Sub save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles save.Click
        Try
            'File Server Writer
        File.WriteAllText("cn.bat", String.Empty)
        Dim FILE_NAME As String = "cn.bat"
        Dim i As Integer
        Dim aryText(4) As String
        aryText(0) = "Server:" & server.Text
        aryText(1) = "User Id:" & user_id.Text
        aryText(2) = "Password:" & password.Text
        aryText(3) = "Port:" & port.Text
        aryText(4) = "Database:" & databaase.Text
        Dim objWriter As New System.IO.StreamWriter(FILE_NAME, True)
        For i = 0 To 4
            objWriter.WriteLine(aryText(i))
        Next
        objWriter.Close()

        ' file Folder Link Images noting
        File.WriteAllText("active_fol.bat", String.Empty)
        Dim FILE_NAME1 As String = "active_fol.bat"
        Dim j As Integer
            Dim aryText1(5) As String
            aryText1(0) = "folderAvatar=" & avatar.Text
            aryText1(1) = "folderProduct=" & img_product.Text
            aryText1(2) = "folderSystem=" & img_system.Text
            aryText1(3) = "folderExcel=" & file_export.Text
            aryText1(4) = "folderFileUpdate=" & File_Update.Text
            aryText1(5) = "ServerReport=" & Server_Report.Text
        Dim objWriter1 As New System.IO.StreamWriter(FILE_NAME1, True)
            For j = 0 To 5
                objWriter1.WriteLine(aryText1(j))
            Next
            objWriter1.Close()

            'Setting Connect Front
            File.WriteAllText("cn-front.bat", String.Empty)
            Dim FILE_NAME2 As String = "cn-front.bat"
            Dim k As Integer
            Dim aryText2(4) As String
            aryText2(0) = "Server:" & server_f.Text
            aryText2(1) = "User Id:" & user_id_f.Text
            aryText2(2) = "Password:" & password_f.Text
            aryText2(3) = "Port:" & port_f.Text
            aryText2(4) = "Database:" & databaase_f.Text
            Dim objWriter2 As New System.IO.StreamWriter(FILE_NAME2, True)
            For k = 0 To 4
                objWriter2.WriteLine(aryText2(k))
            Next
            objWriter2.Close()

        If con.mysql_connect() = True Then
            MsgBox("Connect is Success Fully.")
            Me.Close()
        Else
            MsgBox("Error Cannot Connect!")
            End If
        Catch ex As Exception
            ' MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cancel.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim folderDlg As New FolderBrowserDialog
        folderDlg.ShowNewFolderButton = True
        If (folderDlg.ShowDialog() = DialogResult.OK) Then
            avatar.Text = folderDlg.SelectedPath
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim folderDlg As New FolderBrowserDialog
        folderDlg.ShowNewFolderButton = True
        If (folderDlg.ShowDialog() = DialogResult.OK) Then
            img_system.Text = folderDlg.SelectedPath
        End If
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim folderDlg As New FolderBrowserDialog
        folderDlg.ShowNewFolderButton = True
        If (folderDlg.ShowDialog() = DialogResult.OK) Then
            img_product.Text = folderDlg.SelectedPath
        End If
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim folderDlg As New FolderBrowserDialog
        folderDlg.ShowNewFolderButton = True
        If (folderDlg.ShowDialog() = DialogResult.OK) Then
            file_export.Text = folderDlg.SelectedPath
        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim folderDlg As New FolderBrowserDialog
        folderDlg.ShowNewFolderButton = True
        If (folderDlg.ShowDialog() = DialogResult.OK) Then
            File_Update.Text = folderDlg.SelectedPath
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim folderDlg As New FolderBrowserDialog
        folderDlg.ShowNewFolderButton = True
        If (folderDlg.ShowDialog() = DialogResult.OK) Then
            Server_Report.Text = folderDlg.SelectedPath
        End If
    End Sub
End Class