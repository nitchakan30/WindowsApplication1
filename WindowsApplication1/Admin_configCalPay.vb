Imports MySql.Data.MySqlClient
Imports System
Imports System.IO
Imports System.Text
Imports System.Collections.Generic
Imports System.Management
Public Class Admin_configCalPay
    Dim con As New Mysql
    Private Sub close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_close.Click
        Me.Close()
    End Sub

    Private Sub btn_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_save.Click
        'Save To Db
        Dim str As String = "UPDATE pos_shop SET vat='" & CInt(vat_val_server.Text) & "'," _
        & "vat_status='" & vat_st_server.Text & "',service_chg='" & service_val_server.Text & "'," _
        & "service_status='" & service_st_server.Text & "',cal_format='" & txt_format_server.Text & "';"
        con.mysql_query(str)

        'SAVE to File client
        Dim str_use_client As String = ""
        Dim str_service_st_client As Boolean
        If use_client.Checked = True Then
            str_use_client = "com"
        Else
            str_use_client = "server"
        End If
        If service_st_client.Text = "none" Then
            str_service_st_client = False
        ElseIf service_st_client.Text = "inc" Then
            str_service_st_client = False
        ElseIf service_st_client.Text = "exc" Then
            str_service_st_client = True
        End If

        File.WriteAllText("setting_calpay.bat", String.Empty)
        Dim FILE_NAME As String = "setting_calpay.bat"
        Dim i As Integer
        Dim aryText(0) As String
        aryText(0) = "use_client=" & str_use_client & ",cal_format=" & txt_format_client.Text & ",service_st=" & str_service_st_client & ",service_val=" & service_val_client.Text & ",vat_all_status=" & vat_st_client.Text & ",vat_allval=" & vat_val_client.Text
        Dim objWriter As New System.IO.StreamWriter(FILE_NAME, True)
        For i = 0 To 0
            objWriter.WriteLine(aryText(i))
        Next
        objWriter.Close()
        objWriter.Dispose()
        MsgBox("บันทึกเรียบร้อย", MsgBoxStyle.Information)

    End Sub
    Private Sub Load_Detail()
        clear()
        Dim objReader As New System.IO.StreamReader("setting_calpay.bat", Encoding.UTF8)
        Dim TextLine() As String
        Dim use_c() As String
        Dim cal_f() As String
        Dim sv_st() As String
        Dim sv_val() As String
        Dim v_all_st() As String
        Dim v_all_val() As String
        Do While objReader.Peek() <> -1
            TextLine = objReader.ReadLine().ToString.Trim.Split(",")

            use_c = TextLine(0).ToString.Trim.Split("=")
            cal_f = TextLine(1).ToString.Trim.Split("=")
            sv_st = TextLine(2).ToString.Trim.Split("=")
            sv_val = TextLine(3).ToString.Trim.Split("=")
            v_all_st = TextLine(4).ToString.Trim.Split("=")
            v_all_val = TextLine(5).ToString.Trim.Split("=")
            If use_c(1).ToString.Trim = "com" Then
                use_client.CheckState = CheckState.Checked
            Else
                use_client.CheckState = CheckState.Unchecked
            End If
            txt_format_client.Text = cal_f(1).ToString.Trim
            If CInt(sv_val(1).ToString.Trim) > 0 And CBool(sv_st(1).ToString.Trim) = True Then
                service_st_client.Text = "exc"
            ElseIf CInt(sv_val(1).ToString.Trim) > 0 And CBool(sv_st(1).ToString.Trim) = False Then
                service_st_client.Text = "inc"
            Else
                service_st_client.Text = "none"
            End If
            service_val_client.Text = CInt(sv_val(1).ToString.Trim)
            vat_st_client.Text = v_all_st(1).ToString.Trim
            vat_val_client.Text = CInt(v_all_val(1).ToString.Trim)

        Loop
        objReader.Close()
        objReader.Dispose()
    End Sub

    Private Sub Admin_configCalPay_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Load_Detail()
    End Sub
    Private Sub clear()
        use_client.Checked = False
        txt_format_client.Text = ""
        service_st_client.Text = ""
        service_val_client.Text = "0"
        vat_st_client.Text = ""
        vat_val_client.Text = "0"
    End Sub
End Class