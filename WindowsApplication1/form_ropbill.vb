Imports MySql.Data.MySqlClient
Imports System
Imports System.IO
Imports System.Text
Imports System.Collections.Generic
Imports System.Management
Public Class form_ropbill
    Dim con As New Mysql
    Dim ac As New Admin_ClassMain
    Public close_chk As Boolean = False
    Public id_ropclose As Integer = 0
    Dim action_open As Boolean = False
    Dim print As New printClass
    Public Money_CloseRop As Double = 0.0
    Private Sub form_ropbill_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Login.audit_cash = True Then
            create_rop_audit()
        Else
            create_rop()
        End If
        FlowLayoutPanel1.PerformLayout()
    End Sub
    Public Sub create_rop()
        ' FlowLayoutPanel1.Controls.Clear()
        Dim year As Integer
        If CInt(Login.DateData.ToString("yyyy")) > 2480 Then
            year = CInt(Login.DateData.ToString("yyyy")) - 543
        Else
            year = CInt(Login.DateData.ToString("yyyy"))
        End If
        Dim dt_n As DateTime = year & Login.DateData.ToString("-MM-dd")
        Dim count_check As Integer = con.mysql_num_rows(con.mysql_query("select * from pos_audit where  machine_aud='" & Login.getMacAddress() & "' and rop_date_aud LIKE '%" & dt_n.ToString("yyyy-MM-dd") & "%' and counter_money='close' and type_aud='0' ORDER BY id_aud DESC"))
        If count_check > 0 Then
            FlowLayoutPanel1.Controls.Clear()
            LoadRop()
        Else
            Dim count As Integer = con.mysql_num_rows(con.mysql_query("select * from pos_audit where  machine_aud='" & Login.getMacAddress() & "' and rop_date_aud LIKE '%" & dt_n.ToString("yyyy-MM-dd") & "%' and counter_money='close' and type_aud='1' ORDER BY id_aud DESC"))
            If count = 0 Then
                Dim j As Integer = 0
                Dim query_number As MySqlDataReader = con.mysql_query("select IFNULL(id_ropbill_aud,'0') AS id_ropbill_aud from pos_audit where machine_aud='" & Login.getMacAddress() & "' and rop_date_aud LIKE '%" & dt_n.ToString("yyyy-MM-dd") & "%' order by id_aud DESC limit 1")
                query_number.Read()
                If CInt(query_number.GetString("id_ropbill_aud")) = 0 Then
                    j = 0
                Else
                    j = CInt(query_number.GetString("id_ropbill_aud"))
                End If
                Dim Button1 As New Button
                Button1.Name = "BtnName"
                Button1.Width = "291"
                Button1.Height = "61"
                Button1.FlatStyle = FlatStyle.System
                Button1.Font = New Font(FontFamily.GenericSansSerif, 12.0F, FontStyle.Bold)
                Button1.Tag = "open_" & j
                Button1.Text = "เปิดรอบที่ " & j & " วันที่" & dt_n.ToString("dd/MM/yyyy")
                FlowLayoutPanel1.Controls.Add(Button1)
                AddHandler Button1.Click, AddressOf OpenRopBill
            Else
                Dim j As Integer = 0
                Dim query_number As MySqlDataReader = con.mysql_query("select IFNULL(id_ropbill_aud,'0') AS id_ropbill_aud from pos_audit where machine_aud='" & Login.getMacAddress() & "' and rop_date_aud LIKE '%" & dt_n.ToString("yyyy-MM-dd") & "%' order by id_aud DESC limit 1")
                query_number.Read()
                If CInt(query_number.GetString("id_ropbill_aud")) = 0 Then
                    j = 0
                Else
                    j = CInt(query_number.GetString("id_ropbill_aud"))
                End If
                Dim res_c1 As MySqlDataReader = con.mysql_query("SELECT * FROM pos_audit WHERE  machine_aud='" & Login.getMacAddress() & "' and rop_date_aud LIKE '%" & dt_n.ToString("yyyy-MM-dd") & "%' and type_aud='1' and counter_money='close' ORDER BY id_aud DESC LIMIT 1")
                While res_c1.Read()
                    Dim Button1 As New Button
                    Button1.Name = "BtnName"
                    Button1.Width = "291"
                    Button1.Height = "61"
                    Button1.FlatStyle = FlatStyle.System
                    Button1.Font = New Font(FontFamily.GenericSansSerif, 12.0F, FontStyle.Bold)
                    Button1.Tag = "open_" & (j + 1)
                    Button1.Text = "เปิดรอบที่ " & (j + 1) & " วันที่" & dt_n.ToString("dd/MM/yyyy")
                    FlowLayoutPanel1.Controls.Add(Button1)
                    AddHandler Button1.Click, AddressOf OpenRopBill
                End While
            End If
            LoadRop()
        End If
        Label1.Text = "ปิดรอบบิลวันที่ " & Login.DateData.ToString("dd/MM/yyyy")
    End Sub
    Private Sub LoadRop()
        Dim year As Integer
        If CInt(Login.DateData.ToString("yyyy")) > 2480 Then
            year = CInt(Login.DateData.ToString("yyyy")) - 543
        Else
            year = CInt(Login.DateData.ToString("yyyy"))
        End If
        Dim dt_n As DateTime = year & Login.DateData.ToString("-MM-dd")
        Dim count As Integer = con.mysql_num_rows(con.mysql_query("select * from pos_audit where  machine_aud='" & Login.getMacAddress() & "' and rop_date_aud LIKE '%" & dt_n.ToString("yyyy-MM-dd") & "%' ORDER BY id_aud DESC"))
        Dim i As Integer = 0
        Dim res As MySqlDataReader = con.mysql_query("select * from pos_audit where  machine_aud='" & Login.getMacAddress() & "' and rop_date_aud LIKE '%" & dt_n.ToString("yyyy-MM-dd") & "%'  ORDER BY id_aud DESC")
        While res.Read()
            Dim Button1 As New Button
            If res.GetString("type_aud") = "1" Then
                Button1.Enabled = False
            Else
                Button1.Enabled = True
            End If
            Button1.Name = "BtnName" & i
            If count > 3 Then
                Button1.Width = "276"
                Button1.Height = "61"
            Else
                Button1.Width = "291"
                Button1.Height = "61"
            End If
            'Button1.Anchor = AnchorStyles.Left + AnchorStyles.Right + AnchorStyles.Top
            Button1.FlatStyle = FlatStyle.System
            Button1.Font = New Font(FontFamily.GenericSansSerif, 12.0F, FontStyle.Bold)
            Button1.Tag = res.GetString("id_aud") & "_" & res.GetString("name_rop_aud")
            Button1.Text = "ปิด " & res.GetString("name_rop_aud")
            FlowLayoutPanel1.Controls.Add(Button1)
            AddHandler Button1.Click, AddressOf CloseBill
            i += 1
        End While
    End Sub

    Private Sub OpenRopBill(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim hb As Button = CType(sender, Button)
        Dim bill() As String = hb.Tag.ToString.Split("_")
        Dim Check_Value As Boolean = False
        Dim result2 As DialogResult = MessageBox.Show("คุณมั่นใจใช่ไหมที่จะ" & hb.Text & "?", _
            "ยืนยันการเปิดรอบบิล", _
            MessageBoxButtons.YesNo, _
            MessageBoxIcon.Question)
        If result2 = DialogResult.Yes Then
            Dim year As Integer
            If CInt(Login.DateData.ToString("yyyy")) > 2480 Then
                year = CInt(Login.DateData.ToString("yyyy")) - 543
            Else
                year = CInt(Login.DateData.ToString("yyyy"))
            End If
            Dim dt_n As DateTime = year & Login.DateData.ToString("-MM-dd")
            Dim count As Integer = con.mysql_num_rows(con.mysql_query("select * from pos_audit where  machine_aud='" & Login.getMacAddress() & "' and rop_date_aud LIKE '%" & dt_n.ToString("yyyy-MM-dd") & "%' and money_aud='0' and counter_money='close' ORDER BY id_aud DESC"))
            Dim i As Integer = 0
            Dim str As String = ""
            If count = 0 Then
                Dim query_number As Integer = con.mysql_num_rows(con.mysql_query("select IFNULL(id_ropbill_aud,'0') AS id_ropbill_aud from pos_audit where machine_aud='" & Login.getMacAddress() & "' and rop_date_aud LIKE '%" & dt_n.ToString("yyyy-MM-dd") & "%' order by id_aud DESC "))
                If query_number > 0 Then
                    Dim j As Integer = 0
                    Dim query_number1 As MySqlDataReader = con.mysql_query("select IFNULL(id_ropbill_aud,'0') AS id_ropbill_aud from pos_audit where machine_aud='" & Login.getMacAddress() & "' and rop_date_aud LIKE '%" & dt_n.ToString("yyyy-MM-dd") & "%' order by id_aud DESC limit 1")
                    query_number1.Read()
                    If CInt(query_number1.GetString("id_ropbill_aud")) = 0 Then
                        j = 1
                    Else
                        j = CInt(query_number1.GetString("id_ropbill_aud")) + 1
                    End If
                    str &= "INSERT INTO pos_audit (id_ropbill_aud,name_rop_aud,rop_date_aud,type_aud,money_aud,action_by_aud,machine_aud,counter_money)" _
               & " VALUES('" & j & "','รอบที่ " & j & " วันที่" & dt_n.ToString("dd/MM/yyyy") & "','" & dt_n.ToString("yyyy-MM-dd HH:mm:ss") & "','0','0','" & Login.username & "','" & Login.getMacAddress & "','close');"
                Else
                    str &= "INSERT INTO pos_audit (id_ropbill_aud,name_rop_aud,rop_date_aud,type_aud,money_aud,action_by_aud,machine_aud,counter_money)" _
               & " VALUES('1','รอบที่ 1 วันที่" & dt_n.ToString("dd/MM/yyyy") & "','" & dt_n.ToString("yyyy-MM-dd HH:mm:ss") & "','0','0','" & Login.username & "','" & Login.getMacAddress & "','close');"
                End If
            Else
                Dim j As Integer = 0
                Dim query_number As MySqlDataReader = con.mysql_query("select IFNULL(id_ropbill_aud,'0') AS id_ropbill_aud from pos_audit where machine_aud='" & Login.getMacAddress() & "' and rop_date_aud LIKE '%" & dt_n.ToString("yyyy-MM-dd") & "%' order by id_aud DESC limit 1")
                query_number.Read()
                If CInt(query_number.GetString("id_ropbill_aud")) = 0 Then
                    j = 1
                Else
                    j = CInt(query_number.GetString("id_ropbill_aud")) + 1
                End If
                Dim res_c As MySqlDataReader = con.mysql_query("SELECT * FROM pos_audit WHERE  machine_aud='" & Login.getMacAddress() & "' and rop_date_aud LIKE '%" & dt_n.ToString("yyyy-MM-dd") & "%' and money_aud='0' and counter_money='close' ORDER BY id_aud DESC LIMIT 1")
                While res_c.Read()
                    If CInt(res_c.GetString("type_aud")) = 1 Then
                        str &= "INSERT INTO pos_audit (id_ropbill_aud,name_rop_aud,rop_date_aud,type_aud,money_aud,action_by_aud,machine_aud,counter_money)" _
                 & " VALUES('" & j & "','รอบที่ " & j & " วันที่ " & dt_n.ToString("dd/MM/yyyy") & "','" & dt_n.ToString("yyyy-MM-dd HH:mm:ss") & "','0','0','" & Login.username & "','" & Login.getMacAddress & "','close');"
                    End If
                End While
            End If
            If con.mysql_query(str) = True Then
                Dim qty As MySqlDataReader = con.mysql_query("select * from pos_audit where machine_aud='" & Login.getMacAddress() & "' and rop_date_aud LIKE '%" & dt_n.ToString("yyyy-MM-dd") & "%' and money_aud='0' and counter_money='close' ORDER BY id_aud DESC LIMIT 1")
                While qty.Read()
                    Login.Id_RopBill = CInt(qty.GetString("id_aud"))
                    Login.Str_Ropbill = qty.GetString("name_rop_aud")
                End While
            Else
                MsgBox("ไม่สามารถเปิดรอบได้ กรูณาติดต่อ Admin")
                Login.Id_RopBill = 0
                Login.Str_Ropbill = "Error..!"
            End If
            FlowLayoutPanel1.Controls.Clear()
            LoadRop()
        End If
    End Sub
    Private Sub create_rop_audit()
        FlowLayoutPanel1.Controls.Clear()
        Dim year As Integer
        If CInt(Login.DateData.ToString("yyyy")) > 2450 Then
            year = CInt(Login.DateData.ToString("yyyy")) - 543
        Else
            year = CInt(Login.DateData.ToString("yyyy"))
        End If
        Dim dt_n As DateTime = year & Login.DateData.ToString("-MM-dd")
        Dim count As Integer = con.mysql_num_rows(con.mysql_query("select * from pos_audit where  machine_aud='" & Login.getMacAddress() & "' and rop_date_aud LIKE '%" & dt_n.ToString("yyyy-MM-dd") & "%' ORDER BY id_aud DESC"))
        Dim res As MySqlDataReader = con.mysql_query("select * from pos_audit where  machine_aud='" & Login.getMacAddress() & "' and rop_date_aud LIKE '%" & dt_n.ToString("yyyy-MM-dd") & "%' ORDER BY id_aud DESC")
        Dim i As Integer = 0
        While res.Read()
            Dim Button1 As New Button
            If res.GetString("type_aud") = "1" Then
                Button1.Enabled = False
            Else
                Button1.Enabled = True
            End If
            Button1.Name = "BtnName" & i
            If count > 3 Then
                Button1.Width = "276"
                Button1.Height = "61"
            Else
                Button1.Width = "291"
                Button1.Height = "61"
            End If
            'Button1.Anchor = AnchorStyles.Left + AnchorStyles.Right + AnchorStyles.Top
            Button1.FlatStyle = FlatStyle.System
            Button1.Font = New Font(FontFamily.GenericSansSerif, 12.0F, FontStyle.Bold)
            Button1.Tag = res.GetString("id_aud") & "_" & res.GetString("name_rop_aud")
            Button1.Text = "ปิด" & res.GetString("name_rop_aud")
            FlowLayoutPanel1.Controls.Add(Button1)
            AddHandler Button1.Click, AddressOf CloseBill_Audit
            i += 1
        End While
        Label1.Text = "ปิดรอบบิลวันที่ " & Login.DateData.ToString("dd/MM/yyyy")
    End Sub
    Private Sub CloseBill(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim hb As Button = CType(sender, Button)
        Dim bill() As String = hb.Tag.ToString.Split("_")

        Dim Check_Value As Boolean = False
        Dim result2 As DialogResult = MessageBox.Show("คุณมั่นใจใช่ไหมที่จะปิด" & hb.Text & "?", _
            "ยืนยันการปิดรอบบิล", _
            MessageBoxButtons.YesNo, _
            MessageBoxIcon.Question)
        If result2 = DialogResult.Yes Then
            form_ropbill_close.not_countMoney = True
            form_ropbill_close.Label_Show.Text = hb.Text
            ' form_ropbill_audit_close.not_countMoney = True
            id_ropclose = bill(0)
            form_ropbill_close.ShowDialog()
            If close_chk = True Then

            End If

        End If
    End Sub
    Public return_check_closeday As Boolean = False
    Private Sub CloseBill_Audit(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim hb As Button = CType(sender, Button)
        Dim bill() As String = hb.Tag.ToString.Split("_")
        Dim Check_Value As Boolean = False
        Dim name_btn As String = hb.Name.ToString
        
        '' Dim check_close_sale As Integer = con.mysql_num_rows(con.mysql_query("SELECT * FROM pos_order_list where status_pay='no' and status_sd_captain<>'void' and DAY(create_date)='" & Login.DateData.ToString("dd") & "' and MONTH(create_date)='" & Login.DateData.ToString("MM") & "' and YEAR(create_date)='" & Login.DateData.ToString("yyyy") & "';"))
        ' If check_close_sale > 0 Then
        'MessageBox.Show("ไม่สามารถปิดรอบได้ มียอดยังค้างชำระ กรุณาตรวจสอบด้วยค่ะ.!", "Message Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ' Else
        Dim result2 As DialogResult = MessageBox.Show("คุณมั่นใจใช่ไหมที่จะปิด" & hb.Text & "?", _
       "ยืนยันการปิดรอบบิล", _
       MessageBoxButtons.YesNo, _
       MessageBoxIcon.Question)
        If result2 = DialogResult.Yes Then
            form_ropbill_audit_close.Label_Show.Text = hb.Text
            id_ropclose = bill(0)
            form_ropbill_audit_close.Label1.Text = ""
            form_ropbill_audit_close.ShowDialog()
            print.OpenCashDrawer()
            If close_chk = True Then
                form_ropbill_processbar.id1 = bill(0)
                form_ropbill_processbar.name1 = bill(1)
                form_ropbill_processbar.Money_CloseRop = Money_CloseRop
                form_ropbill_processbar.ShowDialog()

            End If
        End If
        ' End If
    End Sub
    Private Sub btn_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_close.Click
        Me.Close()
    End Sub
    Public Sub OpenLoginNew()
        Login.permiss_pos_system = False
        Login.permiss_closing_bill = False
        Login.permiss_profile_shop = False
        Login.permiss_manage_tb = False
        Login.permiss_manage_prd = False
        Login.permiss_setting_other = False
        Login.permiss_report = False
        Login.permiss_user = False
        Login.permiss_stock = False
        Login.audit_cash = False
        Login.SelectDate = False
        Login.id_rop = 0
        index.Dispose()
        Me.Close()
        Login.Show()
        Login.KillP()
        Login.KillLogin()
    End Sub
    Public Function CheckInputcash_balance()
        'โหลดข้อมูล Tabspage1
        Dim g As Boolean = False
        Dim objReader As New System.IO.StreamReader("setting_closeday.bat", Encoding.UTF8)
        Dim TextLine() As String
        Do While objReader.Peek() <> -1
            TextLine = objReader.ReadLine().ToString.Trim.Split("=")
            If TextLine(0).ToString.Trim = "inputcash_balance" Then
                If TextLine(1).ToString.Trim = 0 Then
                    g = False
                Else
                    g = True
                End If
            End If
        Loop
        objReader.Dispose()
        objReader.Close()
        Return g
    End Function
    Public Function CheckPrintcloseday()
        'โหลดข้อมูล Tabspage1
        Dim g As Boolean = False
        Dim objReader As New System.IO.StreamReader("setting_closeday.bat", Encoding.UTF8)
        Dim TextLine() As String
        Do While objReader.Peek() <> -1
            TextLine = objReader.ReadLine().ToString.Trim.Split("=")
            If TextLine(0).ToString.Trim = "printcloseday" Then
                If TextLine(1).ToString.Trim = 0 Then
                    g = False
                Else
                    g = True
                End If
            End If
        Loop
        objReader.Dispose()
        objReader.Close()
        Return g
    End Function
    Public Function CheckPrintcloserop()
        'โหลดข้อมูล Tabspage1
        Dim g As Boolean = False
        Dim objReader As New System.IO.StreamReader("setting_closeday.bat", Encoding.UTF8)
        Dim TextLine() As String
        Do While objReader.Peek() <> -1
            TextLine = objReader.ReadLine().ToString.Trim.Split("=")
            If TextLine(0).ToString.Trim = "printcloserop" Then
                If TextLine(1).ToString.Trim = 0 Then
                    g = False
                Else
                    g = True
                End If
            End If
        Loop
        objReader.Dispose()
        objReader.Close()
        Return g
    End Function
    Public Function CheckPrintclosedaysummary()
        'โหลดข้อมูล Tabspage1
        Dim g As Boolean = False
        Dim objReader As New System.IO.StreamReader("setting_closeday.bat", Encoding.UTF8)
        Dim TextLine() As String
        Do While objReader.Peek() <> -1
            TextLine = objReader.ReadLine().ToString.Trim.Split("=")
            If TextLine(0).ToString.Trim = "printclosedaysummary" Then
                If TextLine(1).ToString.Trim = 0 Then
                    g = False
                Else
                    g = True
                End If
            End If
        Loop
        objReader.Dispose()
        objReader.Close()
        Return g
    End Function
    Public Function CheckPrintcloseropsummary()
        'โหลดข้อมูล Tabspage1
        Dim g As Boolean = False
        Dim objReader As New System.IO.StreamReader("setting_closeday.bat", Encoding.UTF8)
        Dim TextLine() As String
        Do While objReader.Peek() <> -1
            TextLine = objReader.ReadLine().ToString.Trim.Split("=")
            If TextLine(0).ToString.Trim = "printcloseropsummary" Then
                If TextLine(1).ToString.Trim = 0 Then
                    g = False
                Else
                    g = True
                End If
            End If
        Loop
        objReader.Dispose()
        objReader.Close()
        Return g
    End Function
    Public Function CheckPrintInventory()
        'โหลดข้อมูล Tabspage1
        Dim g As Boolean = False
        Dim objReader As New System.IO.StreamReader("setting_closeday.bat", Encoding.UTF8)
        Dim TextLine() As String
        Do While objReader.Peek() <> -1
            TextLine = objReader.ReadLine().ToString.Trim.Split("=")
            If TextLine(0).ToString.Trim = "printinventory" Then
                If TextLine(1).ToString.Trim = 0 Then
                    g = False
                Else
                    g = True
                End If
            End If
        Loop
        objReader.Dispose()
        objReader.Close()
        Return g
    End Function
End Class