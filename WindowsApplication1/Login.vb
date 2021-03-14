Imports MySql.Data.MySqlClient
Imports System
Imports System.IO
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Drawing.Graphics
Imports System.Text
Imports System.Net.NetworkInformation
Imports System.Security.Cryptography
Imports System.Reflection
Imports System.Globalization

Public Class Login

    Dim con As New Mysql
    Dim res_login As MySqlDataReader
    Dim print As New printClass
    Public username As String
    Public password As String
    Public DateData As Date
    Public LangG As String
    Public permiss_pos_system As Boolean = False
    Public permiss_closing_bill As Boolean = False
    Public permiss_profile_shop As Boolean = False
    Public permiss_manage_tb As Boolean = False
    Public permiss_manage_prd As Boolean = False
    Public permiss_setting_other As Boolean = False
    Public permiss_report As Boolean = False
    Public permiss_user As Boolean = False
    Public permiss_stock As Boolean = False
    Public select_page As String = "pos_system"
    Public close_page As Boolean = True
    Public query_ok_audit_defalut As Boolean = False
    Public id_rop As Integer = 0
    Public audit_cash As Boolean = False
    Public maxTable As Integer = 0
    Public maxUser As Integer = 0
    Public Expire As Date
    Public p() As Process
    Public OpenId As String
    Public Id_RopBill As Integer = 0
    Public Str_Ropbill As String = ""
    Public SelectDate As Boolean = False
    Public Formname As String = "home1"
    Public printer_trybill As String = ""
    Public printer_payment As String = ""
    Public printer_rpt_front As String = ""
    Public printer_rpt_backend As String = ""
    Dim func As New func
    Private Sub SplashScreen3_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If con.mysql_connect() = True Then
                func.CheckVersion()
                MyNewSub()
                Label_alert.Text = ""
                Label_name.Text = ""
                TextBox_Username.Focus()
                Dim fol As String = folderImg()
                Dim pi As Bitmap
                pi = New Bitmap(fol & "none.png")
                resizes(pi)
                'Check Licences

                If checkLicense() = False Then
                    putLicense.ShowDialog()
                End If

                Dim selrect As New Rectangle(0, 0, 152, 152)
                CropEllipse(selrect, pic_user)
                pathreport()
                GetTypeCalPrice()


            Else
                Me.Close()
            End If
        Catch ex As Exception
            '  MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Public Function pathreport()
        'โหลดข้อมูล Tabspage1
        Dim path_file_copy_server As String = ""
        Dim objReader As New System.IO.StreamReader("active_fol.bat", Encoding.UTF8)
        Dim TextLine() As String
        Do While objReader.Peek() <> -1
            TextLine = objReader.ReadLine().ToString.Trim.Split("=")
            If TextLine(0).ToString.Trim = "ServerReport" Then
                path_file_copy_server = TextLine(1).ToString.Trim
            End If
        Loop
        objReader.Close()
        Return path_file_copy_server
    End Function
    Public use_client As String = ""
    Public cal_format As String = ""
    Public service_st As Boolean = False
    Public service_val As Integer = 0
    Public vat_all_status As String = ""
    Public vat_all_val As Integer = 0

    Public Sub GetTypeCalPrice()
        'โหลดข้อมูล Tabspage1
        Dim path_file_copy_server As String = ""
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

            use_client = use_c(1).ToString.Trim
            cal_format = cal_f(1).ToString.Trim
            service_st = CBool(sv_st(1).ToString.Trim)
            service_val = CInt(sv_val(1).ToString.Trim)
            vat_all_status = v_all_st(1).ToString.Trim
            vat_all_val = CInt(v_all_val(1).ToString.Trim)

        Loop
        objReader.Close()
    End Sub
    Sub MyNewSub()
        BackColor = Color.Silver
        TransparencyKey = BackColor
    End Sub
    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        KillP()
        KillLogin()
        Me.Close()
    End Sub
    Private Sub btn_reset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        clearForm()
    End Sub
    Private Sub btn_login_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_login.Click
        Check_user()
        GetTypeCalPrice()

    End Sub
    Private Sub TextBox_Pwd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox_Pwd.Click
        Try
            'p = Process.GetProcessesByName("osk")
            'If p.Count > 0 Then
            '    ' Process is running
            '    Array.ForEach(p, Sub(p1 As Process) p1.Kill())
            '    System.Diagnostics.Process.Start("osk.exe")
            'Else
            '    ' Process is not running
            '    System.Diagnostics.Process.Start("osk.exe")
            'End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub TextBox_Pwd_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox_Pwd.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            Check_user()
            GetTypeCalPrice()
        End If
    End Sub
    Public Sub clearForm()
        TextBox_Username.Text = ""
        TextBox_Pwd.Text = ""
        Label_alert.Text = ""
        Label_name.Text = ""
        pic_user.Hide()
        pic_user.Image = Nothing
        TextBox_Username.Focus()
    End Sub
    Private Sub GetName_Printer()
        Dim objReader As New System.IO.StreamReader("printer.txt", Encoding.UTF8)
        Dim TextLine() As String
        Do While objReader.Peek() <> -1
            TextLine = objReader.ReadLine().ToString.Trim.Split("=")
            If "trybill" = TextLine(0).ToString.Trim Then
                printer_trybill = TextLine(1).ToString
            End If
            If "inv" = TextLine(0).ToString.Trim Then
                printer_payment = TextLine(1).ToString
            End If
            If "rpt_front" = TextLine(0).ToString.Trim Then
                printer_rpt_front = TextLine(1).ToString
            End If
            If "rpt_backend" = TextLine(0).ToString.Trim Then
                printer_rpt_backend = TextLine(1).ToString
            End If
        Loop
        objReader.Close()
    End Sub
    Public alert_sendcaptain As Integer = 0
    Function GetAlert_SendCaptain()
        Dim objReader As New System.IO.StreamReader("setting_closeday.bat", Encoding.UTF8)
        Dim TextLine() As String
        Do While objReader.Peek() <> -1
            TextLine = objReader.ReadLine().ToString.Trim.Split("=")
            If "alertsendcaptain" = TextLine(0).ToString.Trim Then
                alert_sendcaptain = TextLine(1).ToString
            End If
        Loop
        objReader.Close()
        Return alert_sendcaptain
    End Function
    Public switchLangPrintCaptain As Integer = 0
    Public switchLangPrintTrybill As Integer = 0
    Public switchLangPrintPayment As Integer = 0
    Function GetAlert_switchLangPrintCaptain()
        Dim objReader As New System.IO.StreamReader("setting_closeday.bat", Encoding.UTF8)
        Dim TextLine() As String
        Do While objReader.Peek() <> -1
            TextLine = objReader.ReadLine().ToString.Trim.Split("=")
            If "dialogLangCaptain" = TextLine(0).ToString.Trim Then
                switchLangPrintCaptain = TextLine(1).ToString

            End If
        Loop
        objReader.Close()
        Return switchLangPrintCaptain
    End Function
    Function dialog_switchLangPrintTryBill()
        Dim objReader As New System.IO.StreamReader("setting_closeday.bat", Encoding.UTF8)
        Dim TextLine() As String
        Do While objReader.Peek() <> -1
            TextLine = objReader.ReadLine().ToString.Trim.Split("=")
            If "dialogLangTrybill" = TextLine(0).ToString.Trim Then
                switchLangPrintTrybill = TextLine(1).ToString

            End If
        Loop
        objReader.Close()
        Return switchLangPrintTrybill
    End Function
    Function dialog_switchLangPrintPayment()
        Dim objReader As New System.IO.StreamReader("setting_closeday.bat", Encoding.UTF8)
        Dim TextLine() As String
        Do While objReader.Peek() <> -1
            TextLine = objReader.ReadLine().ToString.Trim.Split("=")
            If "dialogLangPayment" = TextLine(0).ToString.Trim Then
                switchLangPrintPayment = TextLine(1).ToString

            End If
        Loop
        objReader.Close()
        Return switchLangPrintPayment
    End Function
    Public Sub Check_user()
        If TextBox_Username.Text <> "" And TextBox_Pwd.Text <> "" Then
            runfrist()
            runfrist_H()
            Dim chk As Integer = con.mysql_num_rows(con.mysql_query("select * from pos_user where username='" & TextBox_Username.Text & "' and password='" & TextBox_Pwd.Text & "' and enable_emp='1' "))
            If chk > 0 Then
                If InsertLogin() = True Then
                    'Get Printer Name
                    GetName_Printer()
                    SetLangu()
                    GetAlert_SendCaptain()
                    GetAlert_switchLangPrintCaptain()
                    dialog_switchLangPrintTryBill()
                    dialog_switchLangPrintPayment()
                    If permiss_stock = True And permiss_pos_system = True Or permiss_setting_other = True Then
                        form_switch_system.ShowDialog()
                    ElseIf permiss_setting_other = True And permiss_stock = False And permiss_pos_system = False Then
                        select_page = "back_system"
                    Else
                        select_page = "pos_system"
                    End If

                    If select_page = "pos_system" And permiss_pos_system = True Then
                        'Check ว่ามีการเลือกวันที่ในระบบหรือยัง
                        Dim qty1 As MySqlDataReader = con.mysql_query("SELECT * FROM pos_closebill limit 1")
                        Dim g As String = "0"
                        While qty1.Read()
                            If qty1.GetString("DateSel") <> "0" Then
                                g = "1"
                            Else
                                g = "0"
                            End If
                        End While

                        If g = "0" Then
                            form_selectdate.Show()
                        Else
                            DateData = CDate(qty1.GetString("create_date"))

                            If CInt(DateData.ToString("yyyy")) > 2450 Then
                                DateData = DateAdd(DateInterval.Year, -543, DateData)
                                'Else
                                ' DateData = DateData.ToString("yyyy-MM-dd")
                            End If
                            SelectDate = True
                        End If

                        If SelectDate = True Then
                            '//เช็คว่ามีเงินทอนในการเปิดรอบหรือยัง เมื่อมีการตั้งค่าใช้งานระบบนับเงินหลังบ้าน
                            '///หาว่าเปิดใช้งานระบบนับเงินหรือไหม->เช็คว่ามีการปิดรอบของวันนนั้นหรือยัง
                            Dim res_sp As MySqlDataReader
                            res_sp = con.mysql_query("select audit_money_action from pos_shop")
                            res_sp.Read()
                            'เช็คว่ามีข้อมูลวันเวลาในระบบ
                            Dim res_time As MySqlDataReader = con.mysql_query("select create_date from pos_closebill order by id_ropbill asc ")
                            res_time.Read()
                            Dim date_dt As Date = res_time.GetString("create_date")
                            Dim year As Integer = 0
                            If CInt(date_dt.ToString("yyyy")) > 2485 Then
                                year = CInt(date_dt.ToString("yyyy")) - 543
                            Else
                                year = CInt(date_dt.ToString("yyyy"))
                            End If
                            date_dt = year & date_dt.ToString("-MM-dd")
                            If CInt(res_sp.GetString("audit_money_action")) = 1 Then  'เช็คว่าเปิดใช้งานระบบนับเงินหรือไม่ 1 คือ เปิด 0 คือ ปิด
                                audit_cash = True
                                'หารอบที่เรียงลำดับน้อยสุดไปมากสุดที่ยังไม่ปิดรอบและเอามาเพียงรอบแรก ล่าสุดเพียงรอบเดียว 0 คือ ปิด ,1 เปิด
                                Dim num_chk As Integer
                                Dim num_adu As Integer
                                num_chk = con.mysql_num_rows(con.mysql_query("select * from pos_audit where machine_aud='" & getMacAddress() & "' ORDER BY id_aud DESC"))
                                If num_chk > 0 Then 'มีข้อมูลในระบบ
                                    'หาว่ามีรอบนี้ วันนี้ ในระบบหรือยัง เป็น record เงินทอน สถานะเป้น 0
                                    Dim rop As MySqlDataReader = con.mysql_query("select * from pos_audit where type_aud='0' and rop_date_aud LIKE '%" & date_dt.ToString("yyyy-MM-dd") & "%' and machine_aud='" & getMacAddress() & "' order by id_aud DESC Limit 1 ")
                                    num_adu = con.mysql_num_rows(con.mysql_query("select * from pos_audit where type_aud='0' and rop_date_aud LIKE '%" & date_dt.ToString("yyyy-MM-dd") & "%' and machine_aud='" & getMacAddress() & "' "))
                                    'ถ้า num_adu มากกว่า 0 คือ มีข้อมูลในระบบไม่ต้องแสดงข้อมูล ถ้าไม่มี ให้แสดง แบบฟอร์มเพื่อกรอกยอดเงินอทอน
                                    If num_adu > 0 Then 'มีข้อมูลเปิดรอบในระบบแล้ว
                                        While rop.Read()
                                            index.Label_Rop.Text = "(รอบที่ " & CInt(rop.GetString("id_ropbill_aud")) & ")"
                                            Id_RopBill = CInt(rop.GetString("id_aud"))
                                            Str_Ropbill = rop.GetString("name_rop_aud")
                                        End While
                                        KillP()
                                        index.Show()
                                    Else 'ยังไม่มีข้อมูลเปิดรอบในระบบแล้ว
                                        Dim res_c As MySqlDataReader = con.mysql_query("SELECT COUNT(*) AS count1 FROM pos_audit WHERE  machine_aud='" & getMacAddress() & "' and rop_date_aud LIKE '%" & date_dt.ToString("yyyy-MM-dd") & "%' order by id_aud desc")
                                        res_c.Read()
                                        id_rop = (CInt(res_c.GetString("count1")) + 1)
                                        form_ropbill_audit_default.Label_show.Text = "รอบที่ " & (CInt(res_c.GetString("count1")) + 1) & " วันที่" & date_dt.ToString("dd/MM/yyyy")
                                        index.Label_Rop.Text = "รอบที่ " & (CInt(res_c.GetString("count1")) + 1)
                                        KillP()
                                        form_ropbill_audit_default.ShowDialog()
                                        'เช็คว่าหน้านั้นบันทึกข้อมูลเร็จหรือยัง?
                                        If query_ok_audit_defalut = True Then
                                            Dim rop_n As MySqlDataReader = con.mysql_query("select * from pos_audit where type_aud='0' and rop_date_aud LIKE '%" & date_dt.ToString("yyyy-MM-dd") & "%' and machine_aud='" & getMacAddress() & "' order by id_aud DESC Limit 1 ")
                                            While rop_n.Read()
                                                Id_RopBill = CInt(rop_n.GetString("id_aud"))
                                                Str_Ropbill = rop_n.GetString("name_rop_aud")
                                            End While
                                            query_ok_audit_defalut = False
                                            KillP()
                                            index.Show()
                                        End If
                                    End If
                                Else 'ไม่มีข้อมูลในระบบเลย
                                    id_rop = 1
                                    form_ropbill_audit_default.Label_show.Text = "รอบที่ 1" & " วันที่" & date_dt.ToString("dd/MM/yyyy")
                                    index.Label_Rop.Text = "รอบที่ 1"
                                    KillP()
                                    form_ropbill_audit_default.ShowDialog()
                                    'เช็คว่าหน้านั้นบันทึกข้อมูลเร็จหรือยัง?
                                    If query_ok_audit_defalut = True Then
                                        Dim rop_n1 As MySqlDataReader = con.mysql_query("select * from pos_audit where type_aud='0' and rop_date_aud LIKE '%" & date_dt.ToString("yyyy-MM-dd") & "%' and machine_aud='" & getMacAddress() & "' order by id_aud DESC Limit 1 ")
                                        While rop_n1.Read()
                                            Id_RopBill = CInt(rop_n1.GetString("id_aud"))
                                            Str_Ropbill = rop_n1.GetString("name_rop_aud")
                                        End While
                                        query_ok_audit_defalut = False
                                        index.Show()
                                    End If
                                End If
                            Else 'ส่วนการทำงานของระบบ ที่ไม่มีการเปิดใช้ระบบนับเงิน
                                audit_cash = False
                                'เช็คว่ามีข้อมูลเปิดรอบในระบบไว้หรือยัง โดยดูมี่ type_aud = 0 เปืด 1 = ปิด
                                Dim num_adu1 As Integer = con.mysql_num_rows(con.mysql_query("select * from pos_audit where type_aud='0' and rop_date_aud LIKE '%" & date_dt.ToString("yyyy-MM-dd") & "%' and machine_aud='" & getMacAddress() & "' and counter_money='close' "))
                                If num_adu1 > 0 Then 'มีเปิดรอบระบบในระบบแล้ว
                                    Dim rop_n1 As MySqlDataReader = con.mysql_query("select * from pos_audit where type_aud='0' and rop_date_aud LIKE '%" & date_dt.ToString("yyyy-MM-dd") & "%' and machine_aud='" & getMacAddress() & "' and counter_money='close' order by id_aud DESC Limit 1 ")
                                    While rop_n1.Read()
                                        Id_RopBill = CInt(rop_n1.GetString("id_aud"))
                                        Str_Ropbill = rop_n1.GetString("name_rop_aud")
                                        index.Label_Rop.Text = "รอบที่ " & CInt(rop_n1.GetString("id_ropbill_aud"))
                                    End While
                                    KillP()
                                    index.Show()
                                Else
                                    form_ropbill_default.ShowDialog()
                                End If
                                If query_ok_audit_defalut = True Then 'เช็คว่ามีการเปิดรอบแล้วหรือยัง
                                    Dim rop_n1 As MySqlDataReader = con.mysql_query("select * from pos_audit where type_aud='0' and rop_date_aud LIKE '%" & date_dt.ToString("yyyy-MM-dd") & "%' and machine_aud='" & getMacAddress() & "' and counter_money='close'  order by id_aud DESC Limit 1 ")
                                    While rop_n1.Read()
                                        Id_RopBill = CInt(rop_n1.GetString("id_aud"))
                                        Str_Ropbill = rop_n1.GetString("name_rop_aud")
                                    End While
                                    query_ok_audit_defalut = False
                                    index.Show()
                                    KillP()
                                End If
                            End If
                        End If
                    ElseIf select_page = "stock" And permiss_stock = True Then
                        Dim qty1 As MySqlDataReader = con.mysql_query("SELECT * FROM pos_closebill limit 1")
                        qty1.Read()
                        DateData = qty1.GetString("create_date")
                        If CInt(DateData.ToString("yyyy")) > 2450 Then
                            DateData = DateAdd(DateInterval.Year, -543, DateData)
                        End If
                        qty1.Close()
                    ElseIf (select_page = "back_system" And permiss_setting_other = True) Or permiss_report = True Then
                        runfrist()
                        runfrist_H()

                        Admin_index.Show()
                        KillP()
                    End If
                    'Refresh_CreditOc(Login.DateData.ToString("yyyy-MM-dd"))
                End If
            Else
                Label_alert.Text = "**Username Or Password IS Wrong..! OR User Is Enable"
                TextBox_Pwd.Focus()
            End If

        ElseIf TextBox_Username.Text = "" Then
            Label_alert.Text = "Please input username"
            TextBox_Username.Focus()
        ElseIf TextBox_Pwd.Text = "" Then
            Label_alert.Text = "Please input password"
            TextBox_Pwd.Focus()
        End If
    End Sub
    Public Function InsertLogin()
        Dim p As Boolean = True
        Dim i As Integer = con.mysql_num_rows(con.mysql_query("SELECT * FROM pos_user_active WHERE name_user='" & username & "' and act_type='pc' "))
        If i > 0 Then
            MessageBox.Show("User " & username & " is Online Please Check Login.!", "Login Message Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            p = False
        Else
            Dim res_user As MySqlDataReader = con.mysql_query("select * from pos_user where username='" & TextBox_Username.Text & "' and password='" & TextBox_Pwd.Text & "' LIMIT 1")
            res_user.Read()
            username = TextBox_Username.Text 'set value username
            password = TextBox_Pwd.Text 'set value password
            If res_user.GetString("lang") = "" Then
                LangG = "TH"
            Else
                LangG = res_user.GetString("lang")
            End If
            Dim res_p As MySqlDataReader = con.mysql_query("select * from pos_user_permission_match where id_user='" & res_user.GetString("id") & "'")
            While res_p.Read()
                'set permission menu
                If CInt(res_p.GetString("POS_system")) = 1 Then
                    permiss_pos_system = True
                End If
                If CInt(res_p.GetString("closing_bill")) = 1 Then
                    permiss_closing_bill = True
                End If
                If CInt(res_p.GetString("profile_shop")) = 1 Then
                    permiss_profile_shop = True
                End If
                If CInt(res_p.GetString("manage_tb")) = 1 Then
                    permiss_manage_tb = True
                End If
                If CInt(res_p.GetString("manage_prd")) = 1 Then
                    permiss_manage_prd = True
                End If
                If CInt(res_p.GetString("setting_other")) = 1 Then
                    permiss_setting_other = True
                End If
                If CInt(res_p.GetString("report")) = 1 Then
                    permiss_report = True
                End If
                If CInt(res_p.GetString("user")) = 1 Then
                    permiss_user = True
                End If
                If CInt(res_p.GetString("stock")) = 1 Then
                    permiss_stock = True
                End If
            End While
            Me.Hide()
            con.mysql_query("INSERT INTO pos_user_active (name_user,act_type) VALUES('" & username & "','pc')")
            p = True
        End If
        Return p
    End Function
    Public Sub KillLogin()
        Dim i As Integer = con.mysql_num_rows(con.mysql_query("SELECT * FROM pos_user_active WHERE name_user='" & username & "' and act_type='pc' "))
        If i > 0 Then
            con.mysql_query("DELETE FROM pos_user_active  WHERE name_user='" & username & "' and act_type='pc'")
        End If
        index.Timer2.Stop()
    End Sub
    Public Sub KillP()
        Try
            p = Process.GetProcessesByName("osk")
            If p.Count > 0 Then
                ' Process is running
                Array.ForEach(p, Sub(p1 As Process) p1.Kill())
            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub TextBox_Username_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox_Username.Click
        Try
            'p = Process.GetProcessesByName("osk")
            'If p.Count > 0 Then
            '    ' Process is running
            '    Array.ForEach(p, Sub(p1 As Process) p1.Kill())
            '    System.Diagnostics.Process.Start("osk.exe")
            'Else
            '    ' Process is not running
            '    System.Diagnostics.Process.Start("osk.exe")
            'End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub TextBox_Username_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox_Username.TextChanged
        Try
            res_login = con.mysql_query("select name_img,name,surname from pos_user where username='" & TextBox_Username.Text & "' ")
            Dim img As String = ""
            While res_login.Read()
                If res_login.GetString("name_img") <> "" Then
                    img = res_login.GetString("name_img")
                End If
            End While
            Dim fol As String = folderImg()
            If img <> "" Then
                pic_user.Show()
                Label_name.Visible = True
                Label_name.Text = res_login.GetString("name") & " " & res_login.GetString("surname")

                Dim pi As Bitmap
                pi = New Bitmap(fol & res_login.GetString("name_img"))
                resizes(pi)

                Dim selrect As New Rectangle(0, 0, 152, 152)
                CropEllipse(selrect, pic_user)
            Else
                Label_name.Text = ""
                Label_name.Visible = False
                Dim pi As Bitmap
                '  pi = New Bitmap(fol & "avatar\none.png")
                pi = New Bitmap("avatar\none.png")
                resizes(pi)
                Dim selrect As New Rectangle(0, 0, 152, 152)
                CropEllipse(selrect, pic_user)
            End If
        Catch ex As Exception
            ' MsgBox(ex.Message.ToString)
        End Try
    End Sub
    Public Function folderImg()
        'GET FOLDER IMAGES
        Dim fulltextIMG As String = ""
        Try
            Dim objReader As New System.IO.StreamReader("active_fol.bat", Encoding.UTF8)
            Dim TextLine() As String
            Do While objReader.Peek() <> -1
                TextLine = objReader.ReadLine().ToString.Trim.Split("=")
                If TextLine(0).ToString.Trim = "folderAvatar" Then
                    fulltextIMG &= TextLine(1).ToString.Trim
                End If
            Loop
            objReader.Close()
            objReader.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
        Return fulltextIMG
    End Function
    Private Sub resizes(ByVal bt As Bitmap)
        Try
            Dim bm_source As New Bitmap(bt)

            ' Make a bitmap for the result.
            Dim bm_dest As New Bitmap(152, 152)

            ' Make a Graphics object for the result Bitmap.
            Dim gr_dest As Graphics = Graphics.FromImage(bm_dest)

            ' Copy the source image into the destination bitmap.
            gr_dest.DrawImage(bm_source, 0, 0, bm_dest.Width + 1, bm_dest.Height + 1)

            ' Display the result.
            pic_user.Image = bm_dest
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub CropEllipse(ByVal EllipseRect As Rectangle, ByVal PicBox As PictureBox)
        Try


            'Create a new bitmap the same size as the EllipseRect
            Using workBmp As New Bitmap(EllipseRect.Width, EllipseRect.Height)

                'Create a new rectangle that the x,y are 0 and the width and height are the same as the EllipseRect
                Dim destrect As New Rectangle(0, 0, EllipseRect.Width, EllipseRect.Height)

                'Create a graphics object from the workBmp bitmap
                Using grx As Graphics = Graphics.FromImage(workBmp)

                    'Draw the PicBox image onto the workBmp bitmap
                    grx.DrawImage(PicBox.Image, destrect, EllipseRect, GraphicsUnit.Pixel)

                    'Create another new bitmap the size of EllipseRect
                    Using overlay As New Bitmap(EllipseRect.Width, EllipseRect.Height)

                        'Create a graphics object from the overlay bitmap
                        Using olgrx As Graphics = Graphics.FromImage(overlay)

                            'Fill the overlay bitmap with an odd color that will be used to indicate the transparent area
                            olgrx.Clear(Color.FromArgb(255, 64, 0, 64))

                            'Fill in an elipse that is the same size as the EllipseRect
                            olgrx.FillEllipse(Brushes.White, destrect)
                        End Using

                        'Make the white elipse transparent so that when drawn onto the workBmp we only see the elipse shape of the image with a solid color around it
                        overlay.MakeTransparent(Color.White)

                        'Draw the overlay bitmap on top of the workBmp which has the PicBox image already drawn on it
                        grx.DrawImage(overlay, 0, 0)
                    End Using
                End Using

                'Now the odd color that we used to indicate the transparent color is set to transparent.This leaves you the elipse shape of the PicBox image
                workBmp.MakeTransparent(Color.FromArgb(255, 64, 0, 64))

                'Now there is a chance that the PicBox image contained the same color we used to indicate the transparent color
                'so we need to make sure that color is filled back in. Since it was set transparent we can just draw it back on top
                'of a matching elipse size that is the color of the odd color used to indicate the transparent color.

                'Create the new backdrop bitmap the size of EllipseRect
                Using backdrop As New Bitmap(EllipseRect.Width, EllipseRect.Height)

                    'Create the graphics object from the backdrop bitmap
                    Using bdgrx As Graphics = Graphics.FromImage(backdrop)

                        'Fill an elipse the same size as our elipse image of the PicBox image with the color we used to indicate the transparent color
                        bdgrx.FillEllipse(New SolidBrush(Color.FromArgb(255, 64, 0, 64)), destrect)

                        'Draw the elipse image of the PicBox image on top of the elipse we just made of the odd transparent color
                        bdgrx.DrawImage(workBmp, 0, 0)
                    End Using

                    'Set the PicBox image to the finished rounded ellipse image
                    PicBox.Image = New Bitmap(backdrop)
                End Using

            End Using
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Function checkLicense()
        ' Try
        Dim res_Licen As MySqlDataReader
        Dim license As String = ""
        Dim license_hotel_name As String = ""
        res_Licen = con.mysql_query("SELECT * FROM main_system WHERE system_id='1'")
        While res_Licen.Read()
            license = res_Licen.GetString("system_license").Replace("-", " ")
            license_hotel_name = res_Licen.GetString("system_name")
        End While

        If license <> "" Then
            Dim [source] As String = license.Substring(0, 28)
            Dim n As String = ""
            Using md5Hash As MD5 = MD5.Create()
                n = GetMd5Hash(md5Hash, source).ToUpper().Substring(10, 5)
            End Using

            If n = license.Substring(30, 5) Then
                Dim pattarn As String = ""
                Select Case license.Replace(" ", "").Substring(24, 1)
                    Case "1"
                        pattarn = "RNNNDDUUNNDDNDNDRDRNDNNN"
                        Exit Select
                    Case "3"
                        pattarn = "DDRUNNNNDDNDRNNUDNDNRDNN"
                        Exit Select
                    Case "4"
                        pattarn = "DNNNNDRDNNDNRNNUDNUDNRDD"
                        Exit Select
                    Case "5"
                        pattarn = "DDNRNNRNNUUNNDDNRNDNNDDD"
                        Exit Select
                    Case "7"
                        pattarn = "NUDDNNNRUNNDDNDDNRDDNNRN"
                        Exit Select
                    Case "9"
                        pattarn = "DRUNRNRNNNUDNDNNDDDNDDNN"
                        Exit Select
                    Case "0"
                        pattarn = "NDNUNNRUNDDNDDNNDRDNNRND"
                        Exit Select
                    Case "A"
                        pattarn = "RNDDNRNNNDNDNDRDNDUNUNDN"
                        Exit Select
                    Case "B"
                        pattarn = "DNURRNNNRNNDNNNUDDDNNDDD"
                        Exit Select
                    Case "C"
                        pattarn = "NRNNUDNRNRNDDNNDDNDUDNDN"
                        Exit Select
                    Case "E"
                        pattarn = "DNDDNNNRNRNUNDDNRNUNNDDD"
                        Exit Select
                    Case "F"
                        pattarn = "NUNDNDNNNURDNNDNRNDDDNRD"
                        Exit Select
                    Case "T"
                        pattarn = "RDNDNNDNUNDNNRNDDRNDDNUN"
                        Exit Select
                    Case "H"
                        pattarn = "NDDNNNNUNDNDNRDNRNDDRDUN"
                        Exit Select
                    Case "J"
                        pattarn = "NUDNNRNNNDNDNNDDDRURDNND"
                        Exit Select
                End Select

                Dim key, cn, cd, cr, cu As String
                Dim i As Integer = 0
                cn = ""
                cd = ""
                cr = ""
                cu = ""
                key = license.Replace(" ", "").Substring(0, 25)
                For Each c As Char In pattarn
                    Select Case c
                        Case "N"
                            cn &= key.Substring(i, 1)
                            Exit Select
                        Case "D"
                            cd &= key.Substring(i, 1)
                            Exit Select
                        Case "R"
                            cr &= key.Substring(i, 1)
                            Exit Select
                        Case "U"
                            cu &= key.Substring(i, 1)
                            Exit Select
                    End Select
                    i += 1
                Next
                source = license_hotel_name
                n = ""
                Using md5Hash As MD5 = MD5.Create()
                    n = GetMd5Hash(md5Hash, source).ToUpper().Substring(0, 11)
                End Using
                Dim dm As Boolean = False
                If cn <> n Then
                    MsgBox("License is not valid. Shop name")
                    Return False
                Else
                    If cn.IndexOf("Demo") = n.IndexOf("Demo") Then
                        dm = True
                    Else
                        dm = False
                    End If
                End If

                Expire = CDate(cd.Substring(6, 2) & " /" & cd.Substring(4, 2) & "/" & cd.Substring(0, 4))
                maxTable = CInt(cr)
                maxUser = CInt(cu)
                'ส่งค่าวันที่ให้เช็คว่าหมดอายุหรือยัง
                Dim ExpireNew As Date
                If CInt(Expire.ToString("yyyy")) > 2450 Then
                    ExpireNew = Expire.ToString("dd/MM/") & CInt(Expire.ToString("yyyy")) - 543
                Else
                    ExpireNew = Expire.ToString("dd/MM/yyyy")
                End If

                If Expire1(ExpireNew, dm) = False Then
                    Return False
                Else
                    AlertExpire(ExpireNew)
                    Return True
                End If
            Else
                Return False
            End If
        Else
            Return False
        End If
        '  Catch ex As Exception
        '    MsgBox(ex.Message.ToString)
        ' End Try
    End Function
    Public Function Expire1(ByVal Expire, ByVal dm)
        Dim b As Boolean = False
        If dm = True Then
            Dim dtime As Date = Now.Date.ToString("dd/MM/yyyy")
            Dim Dtime1 As Date
            If CInt(dtime.ToString("yyyy")) > 2450 Then
                Dtime1 = dtime.ToString("dd/MM/") & CInt(dtime.ToString("yyyy")) - 543
            Else
                Dtime1 = dtime.ToString("dd/MM/") & CInt(dtime.ToString("yyyy"))
            End If
            If DateDiff(DateInterval.Day, Dtime1, Expire) = 0 Then
                b = False
            ElseIf DateDiff(DateInterval.Day, Dtime1, Expire) < 0 Then
                b = False
            ElseIf DateDiff(DateInterval.Day, Dtime1, Expire) > 0 Then
                b = True
            End If
        Else
            Dim res_closeday As MySqlDataReader = con.mysql_query("SELECT create_date AS create_date FROM pos_closebill WHERE id_ropbill='1'")
            res_closeday.Read()
            Dim dtime As Date = res_closeday.GetString("create_date")
            Dim Dtime1 As Date
            If CInt(dtime.ToString("yyyy")) > 2450 Then
                Dtime1 = dtime.ToString("dd/MM/") & CInt(dtime.ToString("yyyy")) - 543
            Else
                Dtime1 = dtime.ToString("dd/MM/") & CInt(dtime.ToString("yyyy"))
            End If

            If DateDiff(DateInterval.Day, Dtime1, Expire) = 0 Then
                b = False
            ElseIf DateDiff(DateInterval.Day, Dtime1, Expire) < 0 Then
                b = False
            ElseIf DateDiff(DateInterval.Day, Dtime1, Expire) > 0 Then
                b = True
            End If
        End If
        Return b
    End Function
    Public Sub AlertExpire(ByVal Expire)
        Dim b As Boolean = False
        Dim res_closeday As MySqlDataReader = con.mysql_query("SELECT create_date AS create_date FROM pos_closebill WHERE id_ropbill='1'")
        res_closeday.Read()
        Dim dtime As Date = res_closeday.GetString("create_date")
        Dim Dtime1 As Date
        If CInt(dtime.ToString("yyyy")) > 2014 Then
            Dtime1 = dtime.ToString("dd/MM/") & CInt(dtime.ToString("yyyy")) - 543
        Else
            Dtime1 = dtime.ToString("dd/MM/") & CInt(dtime.ToString("yyyy"))
        End If
        If DateDiff(DateInterval.Day, Dtime1, Expire) = 6 Or DateDiff(DateInterval.Day, Dtime1, Expire) = 7 Then
            Dim u As MySqlDataReader = con.mysql_query("SELECT alert_7 FROM pos_shop")
            u.Read()
            If CInt(u.GetString("alert_7")) = 0 Then
                con.mysql_query("UPDATE pos_shop SET alert_7='1'")
                MessageBox.Show("Licence is Expire in 7 Day (Expire : " & Expire & ") ,Please Contact Support.! ", "Licence Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        ElseIf DateDiff(DateInterval.Day, Dtime1, Expire) = 14 Or DateDiff(DateInterval.Day, Dtime1, Expire) = 15 Then
            Dim u As MySqlDataReader = con.mysql_query("SELECT alert_15 FROM pos_shop")
            u.Read()
            If CInt(u.GetString("alert_15")) = 0 Then
                con.mysql_query("UPDATE pos_shop SET alert_15='1'")
                MessageBox.Show("Licence is Expire in 14 Day (Expire : " & Expire & ") , Please Contact Support.!", "Licence Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        ElseIf DateDiff(DateInterval.Day, Dtime1, Expire) = 30 Then
            Dim u As MySqlDataReader = con.mysql_query("SELECT alert_1m FROM pos_shop")
            u.Read()
            If CInt(u.GetString("alert_1m")) = 0 Then
                con.mysql_query("UPDATE pos_shop SET alert_1m='1'")
                MessageBox.Show("Licence is Expire in 1 Month (Expire : " & Expire & ") , Please Contact Support.!", "Licence Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub
    Shared Function GetMd5Hash(ByVal md5Hash As MD5, ByVal input As String) As String
        Dim data As Byte() = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input))
        Dim sBuilder As New StringBuilder()
        Dim i As Integer
        For i = 0 To data.Length - 1
            sBuilder.Append(data(i).ToString("x2"))
        Next i
        Return sBuilder.ToString()
    End Function

    Public DataTableAll As MySqlDataReader
    Public IdG As String
    Public DataGropPrd As MySqlDataReader
    Public DataSubGropPrd As MySqlDataReader
    Public DataResPrd As MySqlDataReader
    Public NumDataResPrd As Integer = 0
    Private Sub runfrist()
        Try
            DataTableAll = con.mysql_query("select *,pos_table_system.id AS id_tb from pos_table_system ORDER BY pos_table_system.id ASC")
            DataGropPrd = con.mysql_query("select * from pos_catprd WHERE id_status_sales='1' order by id asc")
            IdG = DtsubG()
            DataSubGropPrd = con.mysql_query("select * from pos_catsubprd  Where ref_id_cat='" & IdG & "' and id_status_sales='1' order by id asc LIMIT 0,7")
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
    Public Function DtsubG()
        Dim IdG1 As String = "0"
        Try
            Dim DataGropPrd1 As MySqlDataReader = con.mysql_query("select * from pos_catprd WHERE id_status_table='1' and id_status_sales='1' order by id asc limit 1")
            While DataGropPrd1.Read()
                IdG1 = DataGropPrd1.GetString("id")
            End While
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
        Return IdG1
    End Function
    ' FORM TAKEHOME
    Dim IdG_H As String
    Public DataGropPrd_H As MySqlDataReader
    Public DataSubGropPrd_H As MySqlDataReader
    Public DataResPrd_H As MySqlDataReader
    Private Sub runfrist_H()
        Try
            DataGropPrd_H = con.mysql_query("select * from pos_catprd WHERE id_status_sales='1' order by id asc")
            IdG_H = DtsubG_H()
            DataSubGropPrd_H = con.mysql_query("select * from pos_catsubprd  Where ref_id_cat='" & IdG_H & "' and id_status_sales='1' order by id asc LIMIT 0,7")
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
    Public Function DtsubG_H()
        Dim IdG1 As String = "0"
        Try
            Dim DataGropPrd1 As MySqlDataReader = con.mysql_query("select * from pos_catprd WHERE id_status_sales='1' order by id asc limit 1")
            While DataGropPrd1.Read()
                IdG1 = DataGropPrd1.GetString("id")
            End While
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
        Return IdG1
    End Function
    Public Sub QtyPrd_H()
        Dim StrSQL As String = ""
        StrSQL += "select *,IFNULL(pos_product_condition.ref_id_ingredients,'0')  AS indre,pos_product_condition.ref_id_size AS ref_id_size "
        StrSQL += ",pos_product_condition.price_condition AS price_condition from pos_product  "
        StrSQL += " LEFT JOIN  pos_product_condition  ON pos_product.id=pos_product_condition.ref_id_prd"
        StrSQL += " where pos_product.id_status_sales='1' Group by pos_product.id order by pos_product.id asc"
        DataResPrd_H = con.mysql_query(StrSQL)
    End Sub
    ' END FORM TAKEHOME
    Public Sub QtyPrd()
        Dim StrSQL As String = ""
        StrSQL += "select *,IFNULL(pos_product_condition.ref_id_ingredients,'0')  AS indre,pos_product_condition.ref_id_size AS ref_id_size "
        StrSQL += ",pos_product_condition.price_condition AS price_condition from pos_product  LEFT JOIN  pos_product_condition "
        StrSQL += " ON pos_product.id=pos_product_condition.ref_id_prd"
        StrSQL += " where pos_product.id_status_sales='1' Group by pos_product.id order by pos_product.id asc"
        NumDataResPrd = con.mysql_num_rows(con.mysql_query(StrSQL))
        DataResPrd = con.mysql_query(StrSQL)
    End Sub
    Public Sub SetLangu()
        If LangG = "EN" Then
            index.btn_home1.Text = "Home"
            index.reserv1.Text = "Reservation"
            index.tk_home1.Text = "Take To Home"
            index.report1.Text = "Report"
            index.close_rop1.Text = "Billing Period"
            index.close_day1.Text = "Summary Sales"
            index.btn_seting.Text = "Setting"
            index.logout1.Text = "Logout"
            index.edit_p.Text = "Profile"
            index.VoidBill.Text = "View Bill"
        Else
            index.btn_home1.Text = "หน้าหลัก"
            index.reserv1.Text = " จองโต๊ะอาหาร "
            index.tk_home1.Text = " ซื้อกลับบ้าน "
            index.report1.Text = " รายงาน "
            index.close_rop1.Text = "ปิดรอบกะ"
            index.close_day1.Text = "ยอดขายทั้งหมดของวัน"
            index.btn_seting.Text = "ตั้งค่าระบบ"
            index.logout1.Text = "ออกจากระบบ"
            index.edit_p.Text = "ข้อมูลส่วนตัว"
            index.VoidBill.Text = " เรียกดูบิล "
        End If
        con.mysql_query("UPDATE pos_user SET lang='" & LangG & "' WHERE username='" & username & "' and password='" & password & "'")
    End Sub
    Public Function getMacAddress()
        Dim nics() As NetworkInterface = NetworkInterface.GetAllNetworkInterfaces()
        ' Return nics(1).GetPhysicalAddress.ToString
        Return "0"
    End Function

    Private Sub TextBox_Username_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox_Username.Leave
        KillP()
    End Sub
    Private Sub TextBox_Pwd_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox_Pwd.Leave
        KillP()
    End Sub

    Private Sub pic_setting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pic_setting.Click
        setting_host.ShowDialog()
    End Sub

    Private Sub btn_backend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_backend.Click
        If TextBox_Username.Text <> "" And TextBox_Pwd.Text <> "" Then
            runfrist()
            runfrist_H()
            Dim chk As Integer = con.mysql_num_rows(con.mysql_query("select * from pos_user where username='" & TextBox_Username.Text & "' and password='" & TextBox_Pwd.Text & "' and enable_emp='1' "))
            If chk > 0 Then
                If InsertLogin() = True Then
                    If permiss_setting_other = True Then
                        Admin_index.Show()
                    Else
                        KillLogin()
                        MessageBox.Show("คุณไม่มีสิทธิในการเข้าใชังานระบบตั้งค่าค่ะ ติดต่อ Admin", "Message Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.Show()
                    End If
                End If
            Else
                Label_alert.Text = "Username Or Password IS Wrong..! OR User Is Enable"
                TextBox_Pwd.Focus()
            End If
        ElseIf TextBox_Username.Text = "" Then
            Label_alert.Text = "Please input username"
            TextBox_Username.Focus()
        ElseIf TextBox_Pwd.Text = "" Then
            Label_alert.Text = "Please input password"
            TextBox_Pwd.Focus()
        End If
    End Sub
    Public Sub Refresh_CreditOc(ByVal datesystem)
        Dim datesystem_new As Date = datesystem
        Dim c As Integer = con.mysql_num_rows(con.mysql_query("select * from pos_payment_oc where status_oc='1' AND type_oc <> 'onetime';"))
        If c > 0 Then
            Dim str_q As String = ""
            Dim qry As MySqlDataReader = con.mysql_query("select * from pos_payment_oc where status_oc='1' AND type_oc <> 'onetime';")

            While qry.Read

                If datesystem_new.ToString("dd") = qry.GetDateTime("date_oc").ToString("dd") Then
                    con.mysql_query("UPDATE pos_payment_oc SET credit_oc ='" & qry.GetDouble("fix_credit_oc") & "' where id_oc='" & qry.GetString("id_oc") & "'; " _
                                    & "INSERT INTO pos_payment_oc_history (ref_id_oc,ref_name_oc,amount_oc_his,remark_oc_his,create_oc_his,date_oc_his) VALUES(" _
                                    & "'" & qry.GetString("id_oc") & "','" & qry.GetString("name_oc") & "','" & qry.GetDouble("fix_credit_oc") & "'," _
                                    & "'Plus Credit By System','System','" & DateData.ToString("yyyy-MM-dd H:mm:ss") & "');")

                End If
            End While


        End If

    End Sub

End Class

