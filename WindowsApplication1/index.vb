Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Text
Imports System.Drawing
Imports System.Drawing.Drawing2D
Public Class index
    Public ReservationP As Boolean = False
    Dim mw As MoveWindows
    Public Gohome As Boolean = False
    Public num_invoice_before_pay As String
    Dim con As New Mysql
    Friend ishomeopen As Boolean = True
    Public Add_order As Boolean = False
    Public Function loadCompany()
        Dim str As String = ""
        Dim res_c As MySqlDataReader = con.mysql_query("SELECT * FROM pos_shop")
        While res_c.Read
            str = res_c.GetString("name_th") & " (" & res_c.GetString("name_en") & ")"
        End While
        Return str
    End Function

    Private Sub index_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CloseForm()

        Me.DoubleBuffered = True
        mw = New MoveWindows(Panel1)
        ishomeopen = True
        If CheckOpenSystemTakehomeonly() = True Then
            btn_home1.Enabled = False
            reserv1.Enabled = False
            tk_home1.Enabled = Login.permiss_pos_system
            report1.Visible = Login.permiss_report
            gohome_list.MdiParent = Me
            gohome_list.Show()
            gohome_list.WindowState = FormWindowState.Minimized
            gohome_list.WindowState = FormWindowState.Maximized
            Login.Formname = "gohome_list"
        Else
            btn_home1.Enabled = Login.permiss_pos_system
            reserv1.Enabled = Login.permiss_pos_system
            tk_home1.Enabled = Login.permiss_pos_system
            report1.Visible = Login.permiss_report
            home1.MdiParent = Me
            home1.Show()
            home1.WindowState = FormWindowState.Minimized
            home1.WindowState = FormWindowState.Maximized
            Login.Formname = "home1"
        End If
        'Check Permission Menu
        ' close_rop1.Visible = Login.permiss_closing_bill
        ' close_day1.Visible = Login.permiss_closing_bill
        ' btn_seting.Visible = Login.permiss_setting_other
        btn_seting.Visible = False
        ShowUser_StatusBar()
        If Login.LangG = "TH" Then
            DMY.Text = "ประจำวันที่ :" & Login.DateData.ToString("dd/MM/yyyy")
        Else
            DMY.Text = "Date :" & Login.DateData.ToString("dd/MM/yyyy")
        End If
        'LOAD ภาษา
        Login.SetLangu()
        Login.Refresh_CreditOc(Login.DateData.ToString("yyyy-MM-dd"))
        Timer2.Start()
    End Sub
   
    Private Sub btn_mini_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mini.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
    Private Sub btn_maxsize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_maxsize.Click
        If Me.WindowState = FormWindowState.Maximized Then
            Me.WindowState = FormWindowState.Normal
        Else
            Me.WindowState = FormWindowState.Maximized
        End If

    End Sub
    Private Sub btn_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_close.Click
        Dim result As Integer = MessageBox.Show("Exit Program ?", "Exit Program", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
        If result = DialogResult.OK Then
            Login.KillLogin()
            Me.Dispose()
            Me.Close()
            Login.Close()
        End If
        Login.KillP()
    End Sub
    Public Sub openCloseMenu(ByRef page)
        CloseForm()
        If ishomeopen = False Then
           ' home1.Close()
        End If
        page.MdiParent = Me
        page.Show()
        page.WindowState = FormWindowState.Minimized
        page.WindowState = FormWindowState.Maximized
        
    End Sub
    
    Private Sub logout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub
    Private Sub opentb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ReservationP = False
        home1.Change_Tb = False
        Gohome = False
        Login.OpenId = ""
        home1.ShowOpen = "1"
        home1.Number_Tb = "Table No.  Option"
        home1.Panel_Ontb.Hide()
        home1.Panel_Reservation.Hide()
        home1.Panel3.Show()
        home1.Panel1.Show()
        home1.ShowTable("All", 0)
        opentable.Loadchk = False
    End Sub
    Private Sub reserv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ReservationP = True
        home1.Change_Tb = False
        Gohome = False
        home1.Panel_Ontb.Hide()
        home1.Panel1.Hide()
        home1.Panel3.Hide()
        home1.Panel_Reservation.Show()
        home1.ShowReservation()
        home1.ShowTable("All", 0)

    End Sub
    Private Sub take_home_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub SwitchToSettingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Admin_index.Show()
        Me.Hide()
    End Sub

    Private Sub btn_seting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_seting.Click
        'home1.Timer1.Stop()
        ' home1.Timer1.Dispose()
        Admin_index.Show()
        opentakehome.SendOrder1 = "0"
        Login.KillP()
        Me.Hide()
    End Sub
    Private Sub btn_home_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CloseForm()
        home1.Change_Tb = False
        Gohome = False
        ReservationP = False
        ' openCloseMenu(home1)
        ishomeopen = True
        home1.MdiParent = Me
        home1.Show()
        home1.WindowState = FormWindowState.Minimized
        home1.WindowState = FormWindowState.Maximized
        Login.Formname = "home1"
    End Sub

    Private Sub take_home1_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CloseForm()
        ReservationP = False
        home1.Change_Tb = False
        Gohome = True
        home1.Hide()
        'openCloseMenu(opentable)
        opentable.MdiParent = Me
        opentable.Show()
        opentable.WindowState = FormWindowState.Minimized
        opentable.WindowState = FormWindowState.Maximized
        Login.Formname = "opentable"
    End Sub
    Public Sub ShowUser_StatusBar()

        Dim date1 As Date = Date.Now
        Dim objReader As New System.IO.StreamReader("cn.bat", Encoding.UTF8)
        Dim TextLine() As String
        Dim fulltext As String = ""

        Do While objReader.Peek() <> -1
            TextLine = objReader.ReadLine().ToString.Trim.Split(":")
            If TextLine(0).ToString.Trim = "Database" Then
                fulltext &= TextLine(1).ToString.Trim
            End If
        Loop

        db_name.Text = "DB.Name : " & fulltext
        user_show.Text = "Username : " & Login.username & " (Login :" & date1.ToString("HH:mm") & ")"
        company_name.Text = "Coompany Name : " & loadCompany()

        stock_index.db_name.Text = "DB.Name : " & fulltext
        stock_index.user_show.Text = "Username : " & Login.username & " (Login :" & date1.ToString("HH:mm") & ")"
        stock_index.company_name.Text = "Coompany Name : " & loadCompany()
        Dim title_shop As MySqlDataReader = con.mysql_query("select IFNULL(system_name,'BEECOME POS') as name_onfront from main_system")
        title_shop.Read()
        Label1.Text = title_shop.GetString("name_onfront")
        title_shop.Close()
    End Sub
    Private Sub tk_home_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CloseForm()
        ReservationP = False
        home1.Change_Tb = False
        Gohome = True
        home1.Hide()
        'openCloseMenu(opentable)
        opentable.MdiParent = Me
        opentable.Show()
        opentable.WindowState = FormWindowState.Minimized
        opentable.WindowState = FormWindowState.Maximized
        Login.Formname = "opentable"

    End Sub

    Private Sub view_listhome_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        gohome_list.ShowDialog()
    End Sub
    'Grendient
    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Me.SetStyle(System.Windows.Forms.ControlStyles.DoubleBuffer, True)
        Me.SetStyle(System.Windows.Forms.ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(System.Windows.Forms.ControlStyles.ResizeRedraw, True)
        Me.SetStyle(System.Windows.Forms.ControlStyles.UserPaint, True)
    End Sub

    Private Sub MenuStrip1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MenuStrip1.Paint
        'Fill Panel with gradient colors Red and Blue
        Dim rect As New System.Drawing.Rectangle(0, 0, MenuStrip1.Width, MenuStrip1.Height)
        Dim g As Graphics = e.Graphics
        Dim gradientBrush As New LinearGradientBrush(New Point(0, MenuStrip1.Height), New Point(0, 0), System.Drawing.ColorTranslator.FromHtml("#BBBDBF"), Color.White)
        g.FillRectangle(gradientBrush, rect)
    End Sub
    Public Sub CloseForm()
        If Login.Formname = "home1" Then
            home1.Close()
        ElseIf Login.Formname = "gohome_list" Then
            gohome_list.Close()
        ElseIf Login.Formname = "opentable" Then
            opentable.Close()
        ElseIf Login.Formname = "opentakehome" Then
            opentakehome.Close()
        ElseIf Login.Formname = "form_ropday" Then
            form_ropday.Close()
        ElseIf Login.Formname = "Admin_Report" Then
            Admin_Report.Close()
        ElseIf Login.Formname = "payment" Then
            payment.Close()
        ElseIf Login.Formname = "form_voidbill" Then
            form_voidbill.Close()
        ElseIf Login.Formname = "payment_gohome" Then
            payment_gohome.Close()
        End If
    End Sub
    Private Sub btn_home1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_home1.Click
        CloseForm()
        home1.Change_Tb = False
        Gohome = False
        ReservationP = False
        'openCloseMenu(home1)
        ishomeopen = True
        home1.MdiParent = Me
        home1.Show()
        home1.WindowState = FormWindowState.Minimized
        home1.WindowState = FormWindowState.Maximized
        Login.OpenId = ""
        opentakehome.SendOrder1 = "0"
        Login.Formname = "home1"
        ' Login.KillP()
        '  home1.Timer1.Start()
    End Sub

    Private Sub reserv1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles reserv1.Click
        CloseForm()
        ishomeopen = True
        home1.MdiParent = Me
        home1.Show()
        home1.WindowState = FormWindowState.Minimized
        home1.WindowState = FormWindowState.Maximized
        Login.Formname = "home1"
        ReservationP = True
        Login.OpenId = 0
        home1.Change_Tb = False
        home1.Label_Reserv.Text = "Table No. Reservation Null"
        Gohome = False
        home1.Panel_Ontb.Hide()
        home1.Panel1.Hide()
        home1.Panel3.Hide()
        home1.Panel_Reservation.Show()
        home1.ShowReservation()
        home1.ShowTable("All", 0)
        opentakehome.SendOrder1 = "0"
        ' Login.KillP()
    End Sub

    Private Sub tk_home1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tk_home1.Click
        ' home1.Timer1.Stop()
        '  home1.Timer1.Dispose()
        '  gohome_list.LoadList()
        Login.OpenId = 0
        Gohome = True
        If Login.Formname = "gohome_list" Then
        Else
            CloseForm()
            gohome_list.MdiParent = Me
            gohome_list.Show()
            gohome_list.WindowState = FormWindowState.Minimized
            gohome_list.WindowState = FormWindowState.Maximized
        End If
        opentakehome.SendOrder1 = "0"
        Login.Formname = "gohome_list"
    End Sub
    Private Sub logout1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles logout1.Click
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
        Login.id_rop = 0
        Login.KillLogin()
        Me.Dispose()
        Me.Close()
        Login.Show()
        'Login.KillP()
    End Sub
    Private Sub MenuStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub
    Private Sub report1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles report1.Click
        If Login.Formname = "Admin_Report" Then
        Else
            CloseForm()
            Admin_Report.MdiParent = Me
            Admin_Report.Show()
            Admin_Report.WindowState = FormWindowState.Minimized
            Admin_Report.WindowState = FormWindowState.Maximized
        End If
        'home1.Timer1.Stop()
        'home1.Timer1.Dispose()
        opentakehome.SendOrder1 = "0"
        Login.KillP()
        Login.Formname = "Admin_Report"
    End Sub

    Private Sub close_rop1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles close_rop1.Click
        'home1.Timer1.Stop()
        'home1.Timer1.Dispose()
        form_ropbill.ShowDialog()
        opentakehome.SendOrder1 = "0"
        Login.KillP()
    End Sub

    Private Sub close_day1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles close_day1.Click
        If Login.Formname = "form_ropday" Then
        Else
            CloseForm()
            form_ropday.MdiParent = Me
            form_ropday.Show()
            form_ropday.WindowState = FormWindowState.Minimized
            form_ropday.WindowState = FormWindowState.Maximized
        End If
        ' home1.Timer1.Stop()
        ' home1.Timer1.Dispose()
        opentakehome.SendOrder1 = "0"
        Login.KillP()
        Login.Formname = "form_ropday"
    End Sub

    Private Sub btn_th_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_th.Click
        Login.SetLangu()
        Login.LangG = "TH"
        home1.Switch_lang()
    End Sub

    Private Sub btn_eng_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_eng.Click
        Login.SetLangu()
        Login.LangG = "EN"
        home1.Switch_lang()
    End Sub

    Private Sub VoidBill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VoidBill.Click
        If Login.Formname = "form_voidbill" Then
        Else
            CloseForm()
            form_voidbill.MdiParent = Me
            form_voidbill.Show()
            form_voidbill.WindowState = FormWindowState.Minimized
            form_voidbill.WindowState = FormWindowState.Maximized
        End If
        ' home1.Timer1.Stop()
        ' home1.Timer1.Dispose()
        ' home1.Close()
        opentakehome.SendOrder1 = "0"
        Login.KillP()
        Login.Formname = "form_voidbill"
    End Sub

    Private Sub edit_profile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles edit_profile.Click
        user_edit.ShowDialog()
    End Sub

    Private Sub edit_p_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles edit_p.Click
        user_edit.ShowDialog()
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        ToolStripStatusLabel1.Text = Date.Now.ToString("HH:mm:ss tt")
        '  Time.Text = Date.Now.ToString("h:mm:ss tt")
    End Sub
    Public Function getNameTable(ByVal id As Integer)
        Dim res_nameTb As MySqlDataReader
        Dim Str As String = ""
        res_nameTb = con.mysql_query("select number from pos_table_system where id ='" & id & "' ")
        While res_nameTb.Read
            Str = res_nameTb.GetString("number")
        End While
        res_nameTb.Close()
        Return Str
    End Function
    Public Function CheckOpenSystemTakehomeonly()
        'โหลดข้อมูล Tabspage1
        Dim g As Boolean = False
        Dim objReader As New System.IO.StreamReader("setting_system.bat", Encoding.UTF8)
        Dim TextLine() As String
        Do While objReader.Peek() <> -1
            TextLine = objReader.ReadLine().ToString.Trim.Split("=")
            If TextLine(0).ToString.Trim = "onoff_takehome" Then
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
    Public Function onoff_rongbill()
        'โหลดข้อมูล Tabspage1
        Dim g As Boolean = False
        Dim objReader As New System.IO.StreamReader("setting_system.bat", Encoding.UTF8)
        Dim TextLine() As String
        Do While objReader.Peek() <> -1
            TextLine = objReader.ReadLine().ToString.Trim.Split("=")
            If TextLine(0).ToString.Trim = "onoff_rongbill" Then
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
  
    Private Sub Panel1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel1.DoubleClick
        If Me.WindowState = FormWindowState.Maximized Then
            Me.WindowState = FormWindowState.Normal
        Else
            Me.WindowState = FormWindowState.Maximized
        End If
    End Sub
End Class