Imports MySql.Data.MySqlClient
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports System.IO
Imports System.Text
Imports System.Threading

Public Class home1
    Dim con As New Mysql
    Dim con_timer As New MysqlTimer
    Dim print As New printClass
    Dim ac As New Admin_ClassMain
    Public Number_Tb As String
    Public ShowOpen As Boolean = False
    Dim Sum1 As Double
    ' Public Add_order As Boolean = False
    Public Change_Tb As Boolean = False
    Dim ChangeID As String
    Dim sizeTb As Integer
    Dim maxpage As Integer
    Dim currentpage As Integer = 1
    Dim count_btn As Integer = 0
    Public cn_voidtb As Boolean = False
    Friend confirm_dialogvoid As Boolean = False
    Private Sub home1_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        index.ishomeopen = False
    End Sub
    Private Sub home1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DoubleBuffered = True
        Panel3.Hide()
        Panel_Ontb.Hide()
        Panel_Reservation.Hide()
        create_btn_location()
        ShowListView_Order()
        Switch_lang()

    End Sub
    Friend Sub Switch_lang()
        If Login.LangG = "EN" Then
            btn_openTb.Text = "Open Table"
            btn_reserv.Text = "Reservations Table"
            Label_order_list.Text = "List Table Is Open"
            btn_Addorder.Text = "Add Order"
            btn_void.Text = "Void"
            btn_changTb.Text = "Move"
            btn_jointb.Text = "Join"
            btn_supptb.Text = "Separate"
            btn_payment.Text = "Payment"
            btn_sendagain.Text = "Print Again"
            btn_tb_detail.Text = "Menu Table"
            Label13.Text = "Date:"
            Label6.Text = "Time Start:"
            Label7.Text = "Time End:"
            Label10.Text = "Name"
            Label11.Text = "People"
            btn_add_reserv.Text = "Save"
            btn_calcle_reserv.Text = "Cancel"
            Label1.Text = "Product List"
            Label2.Text = "Reservation List"
            Label3.Text = "Adult : "
            Label5.Text = "Child : "
            Label12.Text = "Cover : "
            Label15.Text = "Room :"
            Label16.Text = "Remark : "
        Else
            btn_openTb.Text = "เปิดโต๊ะอาหาร"
            btn_reserv.Text = "จองโต๊ะอาหาร"
            Label_order_list.Text = "รายการโต๊ะที่เปิดใช้"
            btn_Addorder.Text = "เพิ่มรายการ"
            btn_void.Text = "ยกเลิกโต๊ะ"
            btn_changTb.Text = "ย้ายโต๊ะ"
            btn_jointb.Text = "รวมโต๊ะ"
            btn_supptb.Text = "แยกโต๊ะ"
            btn_payment.Text = "รับชำระเงิน"
            btn_sendagain.Text = "พิมพ์ส่งครัวใหม่"
            btn_tb_detail.Text = "คลิกเลือกเมนูจัดการ"
            Label13.Text = "วันที่"
            Label6.Text = "เวลาเริ่ม"
            Label7.Text = "เวลาสิ้นสุด"
            Label10.Text = "ชื่อจอง"
            Label11.Text = "จำนวนคน"
            btn_add_reserv.Text = "เพิ่มการจอง"
            btn_calcle_reserv.Text = "ยกเลิก"
            Label1.Text = "รายการสินค้า"
            Label2.Text = "รายการจอง"
            Label3.Text = "ผู้ใหญ่ : "
            Label5.Text = "เด็ก : "
            Label12.Text = "รวม : "
            Label15.Text = "เลขห้อง :"
            Label16.Text = "เพิ่มเติม : "

        End If
    End Sub
    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Panel3.Show()
    End Sub

    Private Sub btn_cancle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancle.Click
        Login.OpenId = ""
        Panel3.Hide()
        ' Timer1.Start()
    End Sub

    Private Sub btn_cn_gohome_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cn_gohome.Click
        index.Add_order = False
        index.Gohome = False
        Login.OpenId = ""
        Panel_Ontb.Hide()
        Panel_Reservation.Hide()
        Panel1.Show()
        ' Timer1.Start()
    End Sub
    Private Sub btn_reserv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_reserv.Click
        index.ReservationP = True
        index.Gohome = False
        Panel_Reservation.Show()
        If Login.OpenId <> "" And index.ReservationP = True Then
            Label_Reserv.Text = "Table No. " & index.getNameTable(Login.OpenId) & " Reservation"
            ReserbIDCh = Login.OpenId
            Panel3.Hide()
        End If
        Panel1.Hide()
        Panel_Ontb.Hide()
        ShowReservation()
    End Sub

    Private Sub btn_openTb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_openTb.Click
        index.Gohome = False
        index.Add_order = False
        opentable.btnopen.Enabled = True
        If ShowOpen = True Then
            Panel1.Hide()
            Panel_Reservation.Hide()
            Panel_Ontb.Show()
            opentable.Loadchk = False
        ElseIf ShowOpen = False And Login.OpenId <> "" Then
            Me.Close()
            index.CloseForm()
            opentable.MdiParent = index
            opentable.Show()
            opentable.WindowState = FormWindowState.Minimized
            opentable.WindowState = FormWindowState.Maximized
            Login.Formname = "opentable"

            Try
                con.mysql_query("update pos_table_system set remark_tb='' where id='" & Login.OpenId & "'")
            Catch ex As Exception
                MsgBox(ex)
            End Try

        ElseIf ShowOpen = False And Login.OpenId = "" Then
            If Login.LangG = "TH" Then
                MessageBox.Show("กรุณาเลือกโต๊ะด้วยค่ะ.!", "ข้อความแจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                MessageBox.Show("Please Selected Table.!", "Message Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

    Private Sub btn_tb_on_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub
    Private Sub TabControl1_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) ' Handles TabControl1.DrawItem

        'Firstly we'll define some parameters.
        Dim CurrentTab As TabPage = TabControl1.TabPages(e.Index)
        Dim ItemRect As Rectangle = TabControl1.GetTabRect(e.Index)
        Dim FillBrush As New SolidBrush(System.Drawing.ColorTranslator.FromHtml("#041830"))
        Dim TextBrush As New SolidBrush(Color.White)
        Dim sf As New StringFormat
        sf.Alignment = StringAlignment.Center
        sf.LineAlignment = StringAlignment.Center

        'If we are currently painting the Selected TabItem we'll 
        'change the brush colors and inflate the rectangle.
        If CBool(e.State And DrawItemState.Selected) Then
            FillBrush.Color = ColorTranslator.FromHtml("#D95F00")
            TextBrush.Color = Color.White
            ItemRect.Inflate(2, 2)
        End If

        'Set up rotation for left and right aligned tabs
        If TabControl1.Alignment = TabAlignment.Left Or TabControl1.Alignment = TabAlignment.Right Then
            Dim RotateAngle As Single = 90
            If TabControl1.Alignment = TabAlignment.Left Then RotateAngle = 270
            Dim cp As New PointF(ItemRect.Left + (ItemRect.Width \ 2), ItemRect.Top + (ItemRect.Height \ 2))
            e.Graphics.TranslateTransform(cp.X, cp.Y)
            e.Graphics.RotateTransform(RotateAngle)
            ItemRect = New Rectangle(-(ItemRect.Height \ 2), -(ItemRect.Width \ 2), ItemRect.Height, ItemRect.Width)
        End If

        'Next we'll paint the TabItem with our Fill Brush
        e.Graphics.FillRectangle(FillBrush, ItemRect)

        'Now draw the text.
        e.Graphics.DrawString(CurrentTab.Text, e.Font, TextBrush, RectangleF.op_Implicit(ItemRect), sf)

        'Reset any Graphics rotation
        e.Graphics.ResetTransform()

        'Finally, we should Dispose of our brushes.
        FillBrush.Dispose()
        TextBrush.Dispose()

    End Sub

    Public Sub create_btn_location()
        TabControl1.Dispose()
        Panel5.Controls.Clear()
        TabControl1 = New TabControl
        TabControl1.Dock = DockStyle.Fill
        TabControl1.DrawMode = DrawMode.OwnerDrawFixed
        TabControl1.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold)
        TabControl1.ItemSize = New Size(280, 35)
        TabControl1.Margin = New Padding(150, 50, 150, 50)
        AddHandler TabControl1.Click, AddressOf TabControl1_Click
        AddHandler TabControl1.DrawItem, AddressOf TabControl1_DrawItem

        Dim Str As String
        Dim res_location As MySqlDataReader
        Dim i As Integer = 1
        Dim id_lo As String
        res_location = con.mysql_query("select * from pos_table_location where status<>'0' order by id asc")
        While res_location.Read()
            Dim newTab As New TabPage()
            If res_location.GetString("id") <> "" Then
                newTab.Cursor = Cursors.Hand
                newTab.Name = "Tabs_" & i
                '  newTab.Height = 45
                'newTab.Width = 130
                newTab.AutoScroll = True
                newTab.ForeColor = Color.Black
                newTab.ToolTipText = res_location.GetString("description")
                If Login.LangG = "TH" Then
                    Str = res_location.GetString("name_th")
                Else
                    Str = res_location.GetString("name_en")
                End If
                If res_location.GetString("name_en") = "All" Then
                    id_lo = "All"
                Else
                    id_lo = res_location.GetString("id")
                End If
                newTab.Tag = id_lo
                newTab.Text = Str
                TabControl1.TabPages.Add(newTab)
            End If
            i += 1
        End While
        Panel5.Controls.Add(TabControl1)
        res_location.Close()
    End Sub
    Dim ct As Integer = 1
    Dim tt As Integer = 1
    Dim c(3) As String
    Dim cN(3) As String
    Dim cN1(3) As String
    Public Sub ShowTable(ByVal id As String, ByVal Tabsid As Integer)
        ' LOAD SHOW TABLE
        ct = 1
        tt = 1
        'TabsLaout.Controls.Clear()
        Dim res_tb As MySqlDataReader
        Dim res_tb1 As MySqlDataReader

        Dim n As Integer = 1
        Dim groupID As Integer = 0

        Dim yy As Integer = Login.DateData.ToString("yyyy")
        Dim year As Integer = 0
        If yy > 2450 Then
            year = yy - 543
        Else
            year = yy
        End If
        TabControl1.TabPages.Item(Tabsid).Controls.Clear()
        If id <> "All" Then
            Panel_Page.Visible = False
            count_btn = 0
            Dim Str_sql As String
            Str_sql = " SELECT *,pos_table_system.id AS id_tb,pos_table_system.status AS idst,pos_table_system.number as number " _
                & " FROM pos_table_layout LEFT JOIN pos_table_system ON " _
                & "pos_table_system.id = pos_table_layout.room_no " _
                & " LEFT JOIN pos_status_table ON pos_status_table.id = pos_table_system.status " _
                & " WHERE floor='" & id & "'" _
                & " and (((pos_table_system.status ='1' OR pos_table_system.status ='2') AND pos_table_layout.type ='Button') OR pos_table_layout.type ='PictureBox' OR pos_table_layout.type = 'Label') "
            res_tb = con_timer.mysql_query(Str_sql)
            While res_tb.Read()
                If res_tb.GetString("type") = "Label" Then
                    Dim lbl As New Label
                    lbl.Name = res_tb.GetString("name")
                    lbl.Text = res_tb.GetString("text")
                    c = res_tb.GetString("color").Split(",")
                    lbl.ForeColor = Color.FromArgb(255, c(0), c(1), c(2))
                    If res_tb.GetString("font_bold") = "True" And res_tb.GetString("font_italic") = "False" Then
                        lbl.Font = New Font(res_tb.GetString("font_famiry"), CByte(res_tb.GetString("font_size")), FontStyle.Bold)
                    ElseIf res_tb.GetString("font_bold") = "False" And res_tb.GetString("font_italic") = "True" Then
                        lbl.Font = New Font(res_tb.GetString("font_famiry"), CByte(res_tb.GetString("font_size")), FontStyle.Italic)
                    ElseIf res_tb.GetString("font_bold") = "True" And res_tb.GetString("font_italic") = "True" Then
                        lbl.Font = New Font(res_tb.GetString("font_famiry"), CByte(res_tb.GetString("font_size")), FontStyle.Italic Or FontStyle.Bold)
                    ElseIf res_tb.GetString("font_bold") = "False" And res_tb.GetString("font_italic") = "False" Then
                        lbl.Font = New Font(res_tb.GetString("font_famiry"), CByte(res_tb.GetString("font_size")), FontStyle.Regular)
                    End If
                    lbl.Top = res_tb.GetInt32("y")
                    lbl.Left = res_tb.GetInt32("x")
                    lbl.Width = res_tb.GetInt32("w")
                    lbl.Height = res_tb.GetInt32("h")
                    TabControl1.TabPages.Item(Tabsid).Controls.Add(lbl)
                    tt += 1
                ElseIf res_tb.GetString("type") = "Button" Then
                    Dim dold As Date = year & Login.DateData.ToString("-MM-dd")
                    Dim dplus As Date = DateAdd(DateInterval.Day, 1, dold)
                    Dim res_resvTB As MySqlDataReader
                    Dim Str_rec As String = "select * from pos_reserv_tb Where rf_id_tb='" & res_tb.GetString("id_tb") & "' and " _
                        & " ( st_time>='" & year & Login.DateData.ToString("-MM-dd") & Date.Now.ToString(" HH:mm:ss") & "' and st_time<='" & dplus.ToString("yyyy-MM-dd 00:00:00") & "' ) and st_confirm='0'"
                    res_resvTB = con_timer.mysql_query(Str_rec)
                    Dim rf_str As String = ""
                    Dim i As Integer = 0
                    While res_resvTB.Read()
                        If i = 0 Then
                            If Login.LangG = "TH" Then
                                rf_str = "จอง: "
                            Else
                                rf_str = "Reserv: "
                            End If
                            i += 1
                        Else
                            rf_str &= "             "
                        End If

                        rf_str &= "(" & CDate(res_resvTB.GetString("st_time")).ToString("HH:mm") & ")" & " - " & "(" & CDate(res_resvTB.GetString("ed_time")).ToString("HH:mm") & ")" & vbCrLf

                    End While
                    res_resvTB.Close()
                    Dim btn As New Button
                    btn.Text = res_tb.GetString("number")
                    btn.Name = res_tb.GetString("id_tb")
                    btn.Width = res_tb.GetInt32("w")
                    btn.Height = res_tb.GetInt32("h")
                    btn.Top = res_tb.GetInt32("y")
                    btn.Left = res_tb.GetInt32("x")
                    btn.FlatStyle = FlatStyle.Flat
                    If res_tb.GetString("status") = 1 Then
                        cN = res_tb.GetString("color").Split(",")
                        btn.ForeColor = Color.FromArgb(255, cN(0), cN(1), cN(2))
                        If res_tb.GetString("font_bold") = "True" And res_tb.GetString("font_italic") = "False" Then
                            btn.Font = New Font(res_tb.GetString("font_famiry"), CByte(res_tb.GetString("font_size")), FontStyle.Bold)
                        ElseIf res_tb.GetString("font_bold") = "False" And res_tb.GetString("font_italic") = "True" Then
                            btn.Font = New Font(res_tb.GetString("font_famiry"), CByte(res_tb.GetString("font_size")), FontStyle.Italic)
                        ElseIf res_tb.GetString("font_bold") = "True" And res_tb.GetString("font_italic") = "True" Then
                            btn.Font = New Font(res_tb.GetString("font_famiry"), CByte(res_tb.GetString("font_size")), FontStyle.Italic Or FontStyle.Bold)
                        ElseIf res_tb.GetString("font_bold") = "False" And res_tb.GetString("font_italic") = "False" Then
                            btn.Font = New Font(res_tb.GetString("font_famiry"), CByte(res_tb.GetString("font_size")), FontStyle.Regular)
                        End If
                        btn.Text = res_tb.GetString("number") & vbCrLf & "(Empty)" & vbCrLf & rf_str
                        btn.Tag = "Empty_" & res_tb.GetString("id_tb") & "_" & "" & "_" & ""
                        If CInt(res_tb.GetString("idst")) = CInt(res_tb.GetString("status")) Then
                            Dim c() As String = res_tb.GetString("st_color").Split(",")
                            btn.BackColor = Color.FromArgb(255, c(0), c(1), c(2))
                        End If
                    ElseIf res_tb.GetString("status") = 2 Then
                        cN = res_tb.GetString("color").Split(",")
                        btn.ForeColor = Color.FromArgb(255, cN(0), cN(1), cN(2))
                        If res_tb.GetString("font_bold") = "True" And res_tb.GetString("font_italic") = "False" Then
                            btn.Font = New Font(res_tb.GetString("font_famiry"), CByte(res_tb.GetString("font_size")), FontStyle.Bold)
                        ElseIf res_tb.GetString("font_bold") = "False" And res_tb.GetString("font_italic") = "True" Then
                            btn.Font = New Font(res_tb.GetString("font_famiry"), CByte(res_tb.GetString("font_size")), FontStyle.Italic)
                        ElseIf res_tb.GetString("font_bold") = "True" And res_tb.GetString("font_italic") = "True" Then
                            btn.Font = New Font(res_tb.GetString("font_famiry"), CByte(res_tb.GetString("font_size")), FontStyle.Italic Or FontStyle.Bold)
                        ElseIf res_tb.GetString("font_bold") = "False" And res_tb.GetString("font_italic") = "False" Then
                            btn.Font = New Font(res_tb.GetString("font_famiry"), CByte(res_tb.GetString("font_size")), FontStyle.Regular)
                        End If
                        If CInt(res_tb.GetString("idst")) = CInt(res_tb.GetString("status")) Then
                            Dim c() As String = res_tb.GetString("st_color").Split(",")
                            btn.BackColor = Color.FromArgb(255, c(0), c(1), c(2))
                        End If
                        If Change_Tb = True And Login.OpenId = res_tb.GetString("id_tb") Then
                            btn.Text = res_tb.GetString("number") & vbCrLf & "(Open)" & vbCrLf & "---This---"
                            btn.Font = New Font(btn.Font.FontFamily, 8, FontStyle.Bold)
                            btn.Tag = res_tb.GetString("id_tb")
                            btn.BackColor = Color.Orange
                        Else
                            If res_tb.GetString("id_join_tb") <> 0 Then
                                btn.Text = res_tb.GetString("number") & " " & "(Open)" & vbCrLf & "Join :" & index.getNameTable(res_tb.GetString("id_join_tb")) & vbCrLf & res_tb.GetString("remark_tb")
                                btn.Tag = "Open_" & res_tb.GetString("id_join_tb") & "_" & "" & "_" & "" & "_" & "แยกโต๊ะ" & "_" & res_tb.GetString("id_tb")
                            Else
                                btn.Text = res_tb.GetString("number") & vbCrLf & "(Open)" & vbCrLf & res_tb.GetString("remark_tb")
                                btn.Tag = "Open_" & res_tb.GetString("id_tb") & "_" & "" & "_" & "" & "_" & "รวมโต๊ะ" & "_0"
                            End If
                        End If
                    Else
                        cN = res_tb.GetString("color").Split(",")
                        btn.ForeColor = Color.FromArgb(255, cN(0), cN(1), cN(2))
                        If res_tb.GetString("font_bold") = "True" And res_tb.GetString("font_italic") = "False" Then
                            btn.Font = New Font(res_tb.GetString("font_famiry"), CByte(res_tb.GetString("font_size")), FontStyle.Bold)
                        ElseIf res_tb.GetString("font_bold") = "False" And res_tb.GetString("font_italic") = "True" Then
                            btn.Font = New Font(res_tb.GetString("font_famiry"), CByte(res_tb.GetString("font_size")), FontStyle.Italic)
                        ElseIf res_tb.GetString("font_bold") = "True" And res_tb.GetString("font_italic") = "True" Then
                            btn.Font = New Font(res_tb.GetString("font_famiry"), CByte(res_tb.GetString("font_size")), FontStyle.Italic Or FontStyle.Bold)
                        ElseIf res_tb.GetString("font_bold") = "False" And res_tb.GetString("font_italic") = "False" Then
                            btn.Font = New Font(res_tb.GetString("font_famiry"), CByte(res_tb.GetString("font_size")), FontStyle.Regular)
                        End If
                        If CInt(res_tb.GetString("idst")) = CInt(res_tb.GetString("status")) Then
                            Dim c() As String = res_tb.GetString("st_color").Split(",")
                            btn.BackColor = Color.FromArgb(255, c(0), c(1), c(2))
                        End If
                        btn.Tag = "close"

                        btn.Font = New Font(btn.Font.FontFamily, 11, FontStyle.Bold)
                        btn.Text = res_tb.GetString("number") & vbCrLf & "(Close)"
                    End If
                    TabControl1.TabPages.Item(Tabsid).Controls.Add(btn)
                    AddHandler btn.Click, AddressOf Table_Click
                ElseIf res_tb.GetString("type") = "PictureBox" Then
                    'GET FOLDER IMG
                    Dim objReader As New System.IO.StreamReader("active_fol.bat", Encoding.UTF8)
                    Dim TextLine() As String
                    Dim fulltextIMG As String = ""

                    Do While objReader.Peek() <> -1
                        TextLine = objReader.ReadLine().ToString.Trim.Split("=")
                        If TextLine(0).ToString.Trim = "folderSystem" Then
                            fulltextIMG &= TextLine(1).ToString.Trim
                        End If
                    Loop

                    Dim pic As New PictureBox
                    pic.ImageLocation = fulltextIMG & res_tb.GetString("name")
                    pic.Name = "pic" & ct
                    ct += 1
                    pic.Width = res_tb.GetString("w")
                    pic.Height = res_tb.GetString("h")
                    pic.SizeMode = PictureBoxSizeMode.StretchImage
                    pic.Left = 10
                    pic.Top = 10
                    pic.Top = res_tb.GetInt32("y")
                    pic.Left = res_tb.GetInt32("x")

                    TabControl1.TabPages.Item(Tabsid).Controls.Add(pic)
                End If
                count_btn += 1
            End While
            res_tb.Close()
        Else
            Panel_Page.Visible = True
            count_btn = 1
            TextBox_PageFD.Text = currentpage & "/" & maxpage
            Dim Str_sql1 As String = ""
            Dim it As Integer = (currentpage - 1) * sizeTb
            Str_sql1 = " select *,pos_table_system.id AS id_tb,pos_status_table.id AS idst from pos_table_system  LEFT JOIN pos_status_table ON pos_status_table.id = pos_table_system.status WHERE (pos_table_system.status='1' or pos_table_system.status='2') ORDER BY pos_table_system.number ASC LIMIT " & it & "," & sizeTb & ";"
            res_tb1 = con_timer.mysql_query(Str_sql1)

            Dim FlowLaout As New FlowLayoutPanel
            FlowLaout.Name = "Flow_location"
            FlowLaout.FlowDirection = FlowDirection.LeftToRight
            FlowLaout.Dock = DockStyle.Fill
            FlowLaout.AutoScroll = True
            FlowLaout.Padding = New System.Windows.Forms.Padding(5)
            TabControl1.TabPages.Item(Tabsid).Controls.Add(FlowLaout)
            Dim res_color As MySqlDataReader = con_timer.mysql_query("SELECT all_color,all_font,all_font_size,all_bold,all_italic FROM pos_shop")
            res_color.Read()
            Dim dold As Date = year & Login.DateData.ToString("-MM-dd")
            Dim dplus As Date = DateAdd(DateInterval.Day, 1, dold)

            While res_tb1.Read()
                Dim res_resvTB As MySqlDataReader
                Dim Str_rec As String = "select * from pos_reserv_tb Where rf_id_tb='" & res_tb1.GetString("id_tb") & "' and " _
                & "(st_time>='" & year & Login.DateData.ToString("-MM-dd") & Date.Now.ToString(" HH:mm:ss") & "' and st_time<='" & dplus.ToString("yyyy-MM-dd 00:00:00") & "' )  and st_confirm='0' "

                res_resvTB = con_timer.mysql_query(Str_rec)
                Dim rf_str As String = ""
                Dim i As Integer = 0
                While res_resvTB.Read()
                    If i = 0 Then
                        If Login.LangG = "TH" Then
                            rf_str = "จอง: "
                        Else
                            rf_str = "Reserv: "
                        End If
                        i += 1
                    Else
                        rf_str &= "             "
                    End If
                    rf_str &= "(" & CDate(res_resvTB.GetString("st_time")).ToString("HH:mm") & ")" & " - " & "(" & CDate(res_resvTB.GetString("ed_time")).ToString("HH:mm") & ")" & vbCrLf

                End While
                res_resvTB.Close()
                Dim Button_tb = New Button
                If CInt(res_tb1.GetString("status")) = 1 Then
                    If CInt(res_tb1.GetString("idst")) = CInt(res_tb1.GetString("status")) Then
                        Dim c() As String = res_tb1.GetString("st_color").Split(",")
                        Button_tb.BackColor = Color.FromArgb(255, c(0), c(1), c(2))
                    End If
                    Button_tb.Text = res_tb1.GetString("number") & vbCrLf & "(Empty)" & vbCrLf & rf_str
                    Button_tb.Tag = "Empty_" & res_tb1.GetString("id_tb") & "_" & "" & "_" & ""
                ElseIf CInt(res_tb1.GetString("status")) = 2 Then
                    Button_tb.Font = New Font(Button_tb.Font.FontFamily, 9, FontStyle.Bold)
                    If Change_Tb = True And Login.OpenId = res_tb1.GetString("id_tb") Then
                        Button_tb.Text = res_tb1.GetString("number") & vbCrLf & "(Open)" & vbCrLf & "---This---"
                        Button_tb.Tag = res_tb1.GetString("id_tb")
                        Button_tb.BackColor = Color.Orange
                    Else
                        If CInt(res_tb1.GetString("id_join_tb")) <> 0 Then
                            Button_tb.Text = res_tb1.GetString("number") & " " & "(Open)" & vbCrLf & "Join :" & index.getNameTable(res_tb1.GetString("id_join_tb")) & vbCrLf & res_tb1.GetString("remark_tb")
                            Button_tb.Tag = "Open_" & res_tb1.GetString("id_join_tb") & "_" & "" & "_" & "" & "_" & "แยกโต๊ะ" & "_" & res_tb1.GetString("id_tb")
                            'Button_tb.Tag = "Open_" & res_tb1.GetString("id_tb") & "_" & "" & "_" & "" & "_" & "แยกโต๊ะ" & "_" & res_tb1.GetString("id_tb")
                        Else
                            Button_tb.Text = res_tb1.GetString("number") & vbCrLf & "(Open)" & vbCrLf & res_tb1.GetString("remark_tb")
                            Button_tb.Tag = "Open_" & res_tb1.GetString("id_tb") & "_" & "" & "_" & "" & "_" & "รวมโต๊ะ" & "_0"
                        End If
                    End If
                    If CInt(res_tb1.GetString("idst")) = CInt(res_tb1.GetString("status")) Then
                        Dim c() As String = res_tb1.GetString("st_color").Split(",")
                        Button_tb.BackColor = Color.FromArgb(255, c(0), c(1), c(2))
                    End If

                ElseIf CInt(res_tb1.GetString("status")) = 0 Then
                    If CInt(res_tb1.GetString("idst")) = CInt(res_tb1.GetString("status")) Then
                        Dim c() As String = res_tb1.GetString("st_color").Split(",")
                        Button_tb.BackColor = Color.FromArgb(255, c(0), c(1), c(2))
                    End If
                    Button_tb.Tag = "close"
                    Button_tb.ForeColor = Color.Black
                    Button_tb.Font = New Font(Button_tb.Font.FontFamily, 11, FontStyle.Bold)
                    Button_tb.Text = res_tb1.GetString("number") & vbCrLf & "(Close)"

                End If

                Button_tb.Width = 180
                Button_tb.FlatStyle = FlatStyle.Flat
                Button_tb.FlatAppearance.BorderSize = 0
                Button_tb.FlatAppearance.MouseOverBackColor = Color.Blue
                Button_tb.Cursor = Cursors.Hand
                Button_tb.Name = "Button_TB" & count_btn
                Button_tb.Height = 86
                Button_tb.TextAlign = ContentAlignment.TopCenter
                Button_tb.Padding = New System.Windows.Forms.Padding(10)
                cN1 = res_color.GetString("all_color").Split(",")
                Button_tb.ForeColor = Color.FromArgb(255, cN1(0), cN1(1), cN1(2))
                If res_color.GetString("all_bold") = "True" And res_color.GetString("all_italic") = "False" Then
                    Button_tb.Font = New Font(res_color.GetString("all_font"), CByte(res_color.GetString("all_font_size")), FontStyle.Bold)
                ElseIf res_color.GetString("all_bold") = "False" And res_color.GetString("all_italic") = "True" Then
                    Button_tb.Font = New Font(res_color.GetString("all_font"), CByte(res_color.GetString("all_font_size")), FontStyle.Italic)
                ElseIf res_color.GetString("all_bold") = "True" And res_color.GetString("all_italic") = "True" Then
                    Button_tb.Font = New Font(res_color.GetString("all_font"), CByte(res_color.GetString("all_font_size")), FontStyle.Italic Or FontStyle.Bold)
                ElseIf res_color.GetString("all_bold") = "False" And res_color.GetString("all_italic") = "False" Then
                    Button_tb.Font = New Font(res_color.GetString("all_font"), CByte(res_color.GetString("all_font_size")), FontStyle.Regular)
                End If
                FlowLaout.Controls.Add(Button_tb)
                If Change_Tb = True Then
                    AddHandler Button_tb.Click, AddressOf TB_Change
                Else
                    AddHandler Button_tb.Click, AddressOf Table_Click
                End If
                n += 1
                count_btn += 1
            End While
            res_color.Close()
            res_tb1.Close()
        End If
    End Sub
    Private Sub home1_ResizeEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.ResizeEnd
        Dim tl As Integer
        tl = TabControl1.Controls.IndexOfKey("Tabs_1")

        For i As Integer = 0 To TabControl1.Controls.Item(tl).Controls.Count - 1
            TabControl1.Controls.Item(tl).Controls.Item(i).Width = TabControl1.Width / TabControl1.Controls.Item(tl).Controls.Count
        Next
    End Sub

    Private Sub home1_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        Try
            'resize Group
            Dim tl As Integer
            tl = TabControl1.Controls.IndexOfKey("Tabs_1")

            sizeTb = Math.Floor(CDbl(TabControl1.Controls.Item(tl).Width / 185)) * Math.Floor(CDbl(TabControl1.Controls.Item(tl).Height / 91))
            Dim Str_sql1 As String = ""
            Dim res_tb1 As MySqlDataReader
            Str_sql1 = "select COUNT(*) AS cout from pos_table_system WHERE (status<>'3' and status<>'0') ORDER BY pos_table_system.id ASC;"
            res_tb1 = con.mysql_query(Str_sql1)
            res_tb1.Read()
            maxpage = Math.Ceiling((res_tb1.GetString("cout")) / sizeTb)
            res_tb1.Close()
            currentpage = 1
            ShowTable("All", 0)
        Catch ex As Exception

        End Try
    End Sub
    Public Tb_Id_OldJoin As Integer = 0
    Private Sub Table_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        ' Handle your Button clicks here
        ' Timer1.Stop()
        'Timer1.Dispose()
        index.Gohome = False
        Dim b As Button = CType(sender, Button)
        Dim words As String() = b.Tag.ToString.Split(New Char() {"_"c})

        If words(0) = "Open" Then
            Dim str As String = index.getNameTable(words(1))
            'index.ReservationP = False
            If words(4) = "แยกโต๊ะ" Or words(4) = "Separate" Then
                btn_jointb.Enabled = False
                btn_supptb.Enabled = True
                home1_menu.btn_jointb.Enabled = False
                home1_menu.btn_supptb.Enabled = True
            Else
                btn_jointb.Enabled = True
                btn_supptb.Enabled = False
                home1_menu.btn_jointb.Enabled = True
                home1_menu.btn_supptb.Enabled = False
                'btn_jointb.Text = words(4)
                If Login.LangG = "EN" Then
                    btn_jointb.Text = "Join"
                    home1_menu.btn_jointb.Text = "Join"
                Else
                    btn_jointb.Text = "รวมโต๊ะ"
                    home1_menu.btn_jointb.Text = "รวมโต๊ะ"
                End If
            End If
            Panel1.Hide()
            Panel_Reservation.Hide()
            Login.OpenId = words(1)
            Tb_Id_OldJoin = words(5)
            opentable.ID_TB_JOIN_OLD = words(5)
            ShowOpen = True
            Number_Tb = "Table No. " & str & " Option"
            Label_tb_select.Text = "Table No. " & str & " Option"
            payment.Label_Num_Pay.Text = "Table No. " & str & " Option"
            opentable.Label_tb_select.Text = "Table No. " & str & " Option"
            ' ListView_food.Items.Clear()
            Load_Product_list()
            Panel_Ontb.Show()

        ElseIf words(0) = "Empty" Then
            'MsgBox(Change_Tb)
            Dim str As String = index.getNameTable(words(1))
            Login.OpenId = words(1)
            ShowOpen = False
            Tb_Id_OldJoin = 0
            Label_tb.Text = "Table No. " & str & " Option"
            Number_Tb = "Table No. " & str & " Option"
            payment.Label_Num_Pay.Text = "Table No. " & str & " Option"
            opentable.Label_tb_select.Text = "Table No. " & str & " Option"
            If index.ReservationP = True Then
                Label_Reserv.Text = "Table No. " & str & " Reservation"
                ReserbIDCh = Login.OpenId
                Panel3.Hide()
                Panel1.Hide()
                Panel_Ontb.Hide()
                Panel_Reservation.Show()
            Else
                If Change_Tb = True Then

                Else
                    Panel1.Show()
                    Panel3.Show()
                    Panel_Ontb.Hide()
                End If
                Panel_Reservation.Hide()
            End If
        End If

        If TabControl1.SelectedIndex = 0 Then
            Dim pp As FlowLayoutPanel
            Dim bb As Button
            pp = TabControl1.SelectedTab.Controls.Item(TabControl1.SelectedTab.Controls.IndexOfKey("Flow_location"))
            For n As Integer = 0 To pp.Controls.Count - 1
                bb = pp.Controls.Item(n)
                'bb = pp.Controls.Item(pp.Controls.IndexOfKey("Button_TB" & n))
                bb.FlatAppearance.BorderSize = 0
            Next
            b.FlatAppearance.BorderSize = 2
            b.FlatAppearance.BorderColor = Color.Orange
        Else
            Dim bb As Button
            Dim t As TabPage = TabControl1.TabPages.Item(TabControl1.SelectedIndex)
            For n As Integer = 0 To t.Controls.Count - 1
                If TypeOf t.Controls.Item(n) Is Button Then
                    bb = t.Controls.Item(n)
                    bb.FlatAppearance.BorderSize = 0
                End If
            Next
            b.FlatAppearance.BorderSize = 2
            b.FlatAppearance.BorderColor = Color.Orange
        End If
    End Sub
    Private Sub Head_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim hb As Button = CType(sender, Button)
        Dim id_location As String = hb.Tag.ToString
    End Sub

    Public Sub ShowListView_Order()
        ' LOAD SHOW TABLE
        ListView_OrderList.Items.Clear()
        Dim str As String = ""
        If Login.DateData.ToString("yyyy") > 2450 Then
            str = (Login.DateData.ToString("yyyy") - 543) & Login.DateData.ToString("-MM-dd")
        Else
            str = Login.DateData.ToString("yyyy-MM-dd")
        End If
        'Dim Str_sql As String = "SELECT *,SUM(price) AS sum1,pos_table_system.id AS idTb FROM pos_order_list " _
        '& "RIGHT JOIN pos_table_system ON pos_table_system.id=pos_order_list.rf_id_table " _
        '& " WHERE  status_pay='no' and (pos_order_list.create_date LIKE '%" & str & "%')  and status_sd_captain='yes' and status_open<>'gohome' Group by rf_id_table "
        'Dim res_or As MySqlDataReader = con.mysql_query(Str_sql)
        'Dim n As Integer = 0
        'Dim itmx As New ListViewItem
        'While res_or.Read
        '    itmx = ListView_OrderList.Items.Add(res_or.GetString("idTb"), n)
        '    itmx.SubItems.Add(res_or.GetString("number"))
        '    itmx.SubItems.Add(res_or.GetString("prs"))
        '    itmx.SubItems.Add(res_or.GetString("sum1"))
        '    n += 1
        'End While

        Dim Str_sql As String = "SELECT * from pos_table_system where status=2;"
        Dim res_or As MySqlDataReader = con.mysql_query(Str_sql)
        Dim n As Integer = 0
        Dim itmx As New ListViewItem
        While res_or.Read
            itmx = ListView_OrderList.Items.Add(res_or.GetString("id"), n)
            itmx.SubItems.Add(res_or.GetString("number"))
            itmx.SubItems.Add(getPrs(res_or.GetString("id")))
            itmx.SubItems.Add(getSumprice(res_or.GetString("id")))
            n += 1
        End While
        res_or.Close()
    End Sub
    Public Function getPrs(ByVal idtb)
        Dim x As String = "0"
        Dim Str_sql As String = "SELECT adult,child FROM pos_order_list_prs " _
       & " WHERE rf_id_table='" & idtb & "' limit 1; "
        Dim res_or As MySqlDataReader = con.mysql_query(Str_sql)
        While res_or.Read()
            x = res_or.GetInt32("adult") + res_or.GetInt32("child")
        End While
        res_or.Close()
        Return x
    End Function
    Public Function getSumprice(ByVal idtb)
        Dim p As String = "0.0"
        Dim Str_sql As String = "SELECT SUM(price) AS sum1 FROM pos_order_list " _
        & " WHERE  status_pay='no' and rf_id_table='" & idtb & "' and status_open<>'gohome' Group by rf_id_table "
        Dim res_or As MySqlDataReader = con.mysql_query(Str_sql)
        While res_or.Read()
            p = res_or.GetString("sum1")
        End While
        res_or.Close()
        Return p
    End Function
    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        If ListView_OrderList.SelectedItems.Count > 0 Then
            If ListView_OrderList.SelectedIndices(0) > 0 Then
                ListView_OrderList.Items.Item(ListView_OrderList.SelectedIndices(0) - 1).Selected = True
                ListView_OrderList.Focus()
            End If
        Else
            ListView_OrderList.Items.Item(0).Selected = True
            ListView_OrderList.Focus()
        End If
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        If ListView_OrderList.SelectedItems.Count > 0 Then
            If ListView_OrderList.SelectedIndices(0) < ListView_OrderList.Items.Count - 1 Then
                ListView_OrderList.Items.Item(ListView_OrderList.SelectedIndices(0) + 1).Selected = True
                ListView_OrderList.Focus()
            End If
        Else
            ListView_OrderList.Items.Item(ListView_OrderList.Items.Count - 1).Selected = True
            ListView_OrderList.Focus()
        End If
    End Sub

    Private Sub btn_select_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_select.Click
        If ListView_OrderList.SelectedIndices.Count = 0 Then
            Exit Sub
        End If
        If ListView_OrderList.Items.Count > 0 Then
            TextBox_SumIndex.Text = ListView_OrderList.Items(ListView_OrderList.FocusedItem.Index).SubItems(3).Text()
        End If

        Panel1.Hide()
        Panel_Reservation.Hide()
        Panel_Ontb.Show()
        Label_tb_select.Text = "Table No. " & ListView_OrderList.Items(ListView_OrderList.SelectedIndices(0)).SubItems(1).Text() & " Option"
        Login.OpenId = ListView_OrderList.Items(ListView_OrderList.SelectedIndices(0)).SubItems(0).Text()
        Load_Product_list()
    End Sub
    Public Sub Load_Product_list()
        opentable.Loadchk = True
        If ListView_food.Items.Count > 0 Then
            ListView_food.Items.Clear()
        End If
        Dim size_n As String
        Dim rf_id_con As String
        Dim y As Integer = 0
        Dim yearNew As Integer
        If CInt(Login.DateData.ToString("yyyy")) > 2450 Then
            yearNew = CInt(Login.DateData.ToString("yyyy")) - 543
        Else
            yearNew = CInt(Login.DateData.ToString("yyyy"))
        End If
        Dim dNow As Date = yearNew & "-" & Login.DateData.ToString("MM-dd")

        Dim str1 As String = "SELECT pos_order_list.id_ord AS id_ord,pos_order_list.status_sd_captain AS status_sd_captain," _
        & "pos_order_list.rf_id_prd AS rf_id_prd,pos_order_list.rf_id_con As rf_id_con,pos_order_list.name_ord AS name_ord," _
        & "pos_order_list.name_ord_en AS name_ord_en," _
        & "pos_order_list.prs AS prs,pos_order_list.remark AS remark,pos_order_list.ref_id_join AS ref_id_join," _
        & "SUM(pos_order_list.amt) AS samt,SUM(pos_order_list.price) AS sprice,pos_table_system.id AS idTb,IFNULL(pos_product_size.name_th,0) AS name_size," _
        & "pos_order_list.ref_cat_id as ref_cat_id,pos_order_list.ref_catsubprd as ref_catsubprd,pos_order_list.name_th_cat as name_th_cat,pos_order_list.name_en_cat as name_en_cat," _
        & "pos_order_list.name_th_catsubprd as name_th_catsubprd,pos_order_list.name_en_catsubprd as name_en_catsubprd,pos_order_list.ord_vat as ord_vat,pos_order_list.ord_vat_st as ord_vat_st," _
        & "pos_order_list.prd_type_dis_id as prd_type_dis_id,pos_order_list.prd_type_dis_en as prd_type_dis_en,pos_order_list.prd_type_dis_th as prd_type_dis_th," _
        & "IFNULL(un.name_th,'') as cond " _
        & " FROM pos_order_list  INNER JOIN pos_table_system ON pos_table_system.id=pos_order_list.rf_id_table " _
        & " LEFT JOIN pos_product_condition ON pos_order_list.rf_id_con =  pos_product_condition.id " _
        & " LEFT JOIN pos_product_ingredients ON pos_product_ingredients.id  =  pos_product_condition.ref_id_ingredients" _
        & " LEFT JOIN pos_product_size ON pos_product_size.id =  pos_product_condition.ref_id_size" _
        & " LEFT JOIN `pos_product_unit` un ON un.id = `pos_product_condition`.ref_id_unit" _
        & " WHERE  pos_order_list.status_pay='no' and (pos_order_list.create_date LIKE '%" & dNow.ToString("yyyy-MM-dd") & "%') and pos_order_list.status_sd_captain<>'void' and " _
        & "pos_order_list.status_open<>'gohome' and (pos_order_list.rf_id_table='" & Login.OpenId & "' or pos_order_list.ref_id_join='" & Login.OpenId & "')" _
        & " GROUP BY pos_order_list.rf_id_prd,pos_order_list.rf_id_con,pos_order_list.name_ord order by id_ord asc"

        'TextBox1.Text = str1
        Dim res_listView As MySqlDataReader = con.mysql_query(str1)
        Dim itmx1 As New ListViewItem
        While res_listView.Read
            itmx1 = ListView_food.Items.Add(res_listView.GetString("status_sd_captain"), y)
            itmx1.SubItems.Add(res_listView.GetString("id_ord"))
            itmx1.SubItems.Add(res_listView.GetString("rf_id_prd"))
            If res_listView.GetString("rf_id_con") <> "0" Then
                rf_id_con = res_listView.GetString("rf_id_con")
            Else
                rf_id_con = ""
            End If
            itmx1.SubItems.Add(rf_id_con)
            itmx1.SubItems.Add(res_listView.GetString("name_ord"))
            itmx1.SubItems.Add(res_listView.GetString("name_ord_en"))
            If res_listView.GetString("name_size") <> "0" Or res_listView.GetString("cond") <> "" Then
                If res_listView.GetString("name_size") <> "0" Then
                    size_n = res_listView.GetString("name_size")
                Else
                    size_n = res_listView.GetString("cond")
                End If
            Else
                size_n = ""
            End If
            itmx1.SubItems.Add(size_n)
            itmx1.SubItems.Add(res_listView.GetString("samt"))
            itmx1.SubItems.Add(res_listView.GetDecimal("sprice").ToString("#,##0.00"))
            itmx1.SubItems.Add(res_listView.GetString("remark"))
            itmx1.SubItems.Add(res_listView.GetString("ref_cat_id"))
            itmx1.SubItems.Add(res_listView.GetString("ref_catsubprd"))
            itmx1.SubItems.Add(res_listView.GetString("name_th_cat"))
            itmx1.SubItems.Add(res_listView.GetString("name_en_cat"))
            itmx1.SubItems.Add(res_listView.GetString("name_th_catsubprd"))
            itmx1.SubItems.Add(res_listView.GetString("name_en_catsubprd"))
            itmx1.SubItems.Add(res_listView.GetString("ord_vat"))
            itmx1.SubItems.Add(res_listView.GetString("ord_vat_st"))
            itmx1.SubItems.Add(res_listView.GetString("prd_type_dis_id"))
            itmx1.SubItems.Add(res_listView.GetString("prd_type_dis_en"))
            itmx1.SubItems.Add(res_listView.GetString("prd_type_dis_th"))
            If res_listView.GetString("status_sd_captain").ToLower = "yes" Then
                itmx1.ForeColor = Color.Green
            Else
                itmx1.ForeColor = Color.Black
            End If
            y += 1
        End While
        res_listView.Close()
        'Query Void Order list
        Dim year As String = ""
        If CInt(Login.DateData.ToString("yyyy")) > 2450 Then
            year = CInt(Login.DateData.ToString("yyyy")) - 543
        Else
            year = Login.DateData.ToString("yyyy")
        End If
        Dim res_listViewV As MySqlDataReader = con.mysql_query("SELECT pos_order_list.id_ord AS id_ord,pos_order_list.status_sd_captain AS status_sd_captain," _
       & "pos_order_list.rf_id_prd AS rf_id_prd,pos_order_list.rf_id_con As rf_id_con,pos_order_list.name_ord AS name_ord," _
        & "pos_order_list.name_ord_en AS name_ord_en," _
        & "pos_order_list.prs AS prs,pos_order_list.remark AS remark,pos_order_list.ref_id_join AS ref_id_join," _
       & "SUM(pos_order_list.amt) AS samt,SUM(pos_order_list.price) AS sprice,pos_table_system.id AS idTb,IFNULL(pos_product_size.name_th,0) AS name_size," _
       & "pos_order_list.ref_cat_id as ref_cat_id,pos_order_list.ref_catsubprd as ref_catsubprd,pos_order_list.name_th_cat as name_th_cat,pos_order_list.name_en_cat as name_en_cat," _
       & "pos_order_list.name_th_catsubprd as name_th_catsubprd,pos_order_list.name_en_catsubprd as name_en_catsubprd,pos_order_list.ord_vat as ord_vat,pos_order_list.ord_vat_st as ord_vat_st," _
       & "pos_order_list.prd_type_dis_id as prd_type_dis_id,pos_order_list.prd_type_dis_en as prd_type_dis_en,pos_order_list.prd_type_dis_th as prd_type_dis_th" _
       & ",IFNULL(un.name_th,'-') as cond " _
       & "  FROM pos_order_list  INNER JOIN pos_table_system ON pos_table_system.id=pos_order_list.rf_id_table " _
       & " LEFT JOIN pos_product_condition ON pos_order_list.rf_id_con =  pos_product_condition.id " _
       & " LEFT JOIN pos_product_ingredients ON pos_product_ingredients.id  =  pos_product_condition.ref_id_ingredients" _
       & " LEFT JOIN pos_product_size ON pos_product_size.id =  pos_product_condition.ref_id_size" _
       & " LEFT JOIN `pos_product_unit` un ON un.id = `pos_product_condition`.ref_id_unit" _
        & " WHERE  pos_order_list.status_pay='no' and  pos_order_list.status_sd_captain='void' and pos_order_list.status_open<>'gohome' and (pos_order_list.rf_id_table='" & Login.OpenId & "' or pos_order_list.ref_id_join='" & Login.OpenId & "') and " _
       & " DAY(pos_order_list.create_date)='" & Login.DateData.ToString("dd") & "' and MONTH(pos_order_list.create_date)='" & Login.DateData.ToString("MM") & "' and YEAR(pos_order_list.create_date)='" & year & "' " _
       & " GROUP BY pos_order_list.rf_id_prd,pos_order_list.rf_id_con,pos_order_list.name_ord")

        While res_listViewV.Read
            Dim size_v As String = ""
            itmx1 = ListView_food.Items.Add("voidp", CInt(ListView_food.Items.Count) + 1)
            itmx1.SubItems.Add(res_listViewV.GetString("id_ord"))
            itmx1.SubItems.Add(res_listViewV.GetString("rf_id_prd"))
            If res_listViewV.GetString("rf_id_con") <> "0" Then
                rf_id_con = res_listViewV.GetString("rf_id_con")
            Else
                rf_id_con = ""
            End If
            itmx1.SubItems.Add(rf_id_con)
            itmx1.SubItems.Add(res_listViewV.GetString("name_ord"))
            itmx1.SubItems.Add(res_listViewV.GetString("name_ord_en"))
            If res_listViewV.GetString("name_size") <> "0" Or res_listViewV.GetString("cond") <> "" Then
                If res_listViewV.GetString("name_size") <> "0" Then
                    size_v = res_listViewV.GetString("name_size")
                Else
                    size_v = res_listViewV.GetString("cond")
                End If
            Else
                size_v = ""
            End If
            itmx1.SubItems.Add(size_v)
            itmx1.SubItems.Add(res_listViewV.GetString("samt"))
            itmx1.SubItems.Add(res_listViewV.GetDecimal("sprice").ToString("#,##0.00"))
            itmx1.SubItems.Add(res_listViewV.GetString("remark"))
            itmx1.SubItems.Add(res_listViewV.GetString("ref_cat_id"))
            itmx1.SubItems.Add(res_listViewV.GetString("ref_catsubprd"))
            itmx1.SubItems.Add(res_listViewV.GetString("name_th_cat"))
            itmx1.SubItems.Add(res_listViewV.GetString("name_en_cat"))
            itmx1.SubItems.Add(res_listViewV.GetString("name_th_catsubprd"))
            itmx1.SubItems.Add(res_listViewV.GetString("name_en_catsubprd"))
            itmx1.SubItems.Add(res_listViewV.GetString("ord_vat"))
            itmx1.SubItems.Add(res_listViewV.GetString("ord_vat_st"))
            itmx1.SubItems.Add(res_listViewV.GetString("prd_type_dis_id"))
            itmx1.SubItems.Add(res_listViewV.GetString("prd_type_dis_en"))
            itmx1.SubItems.Add(res_listViewV.GetString("prd_type_dis_th"))
            ListView_food.Items(CInt(ListView_food.Items.Count) - 1).ForeColor = Color.Red

        End While
        res_listViewV.Close()
        If Login.LangG = "EN" Then
            ListView_food.Columns(4).Text = "Name"
            ListView_food.Columns(6).Text = "Size/unit"
            ListView_food.Columns(7).Text = "Qty"
            ListView_food.Columns(8).Text = "Price"
            ListView_food.Columns(9).Text = "Remark"
            ListView_food.Columns(4).Width = 0
            ListView_food.Columns(5).Width = 100
        Else
            ListView_food.Columns(4).Text = "ชื่อรายการ"
            ListView_food.Columns(6).Text = "ขนาด"
            ListView_food.Columns(7).Text = "จำนวน"
            ListView_food.Columns(8).Text = "ราคา"
            ListView_food.Columns(9).Text = "เพิ่มเติม"
            ListView_food.Columns(4).Width = 100
            ListView_food.Columns(5).Width = 0
        End If

        calsum() ' คำนวณราคารวม
        opentable.ShowCover(Login.OpenId, txt_adult, txt_child, txt_cover, txt_roomnum, txt_remark)
    End Sub
    Public Sub calsum()
        Dim Summary As Double = 0.0
        Dim Summary_void As Double = 0.0
        Dim Sumnew As Double = 0.0
        ' Dim res_price As MySqlDataReader
        Dim sql_price As String = ""
        Dim vat As Double = 0.0
        Dim service_chg As Double = opentable.CalServiceCh()
        For x As Integer = 0 To ListView_food.Items.Count - 1
            If ListView_food.Items(x).SubItems(0).Text.ToLower = "void" Or ListView_food.Items(x).SubItems(0).Text.ToLower = "voidp" Then
                Summary_void += (CDbl(ListView_food.Items(x).SubItems(8).Text))
            Else
                Summary += (CDbl(ListView_food.Items(x).SubItems(8).Text))
            End If
        Next
        If Summary_void > Summary Then
            Sumnew = Summary_void - Summary
        Else
            Sumnew = Summary - Summary_void
        End If
        'MsgBox(Sumnew)
        TextBox_SumIndex.Text = Summary.ToString("#,##0.00")
        Sumnew = 0
    End Sub
    Private Sub btn_up_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_up.Click
        If ListView_food.SelectedItems.Count > 0 Then
            If ListView_food.SelectedIndices(0) > 0 Then
                ListView_food.Items.Item(ListView_food.SelectedIndices(0) - 1).Selected = True
                ListView_food.Focus()
                If ListView_food.Items(ListView_food.SelectedIndices(0)).SubItems(0).Text() = "void" Then

                ElseIf ListView_food.Items(ListView_food.SelectedIndices(0)).SubItems(0).Text() = "yes" Then

                End If
            End If
        Else
            ListView_food.Items.Item(0).Selected = True
            ListView_food.Focus()

            If ListView_food.Items(ListView_food.SelectedIndices(0)).SubItems(0).Text() = "void" Then

            ElseIf ListView_food.Items(ListView_food.SelectedIndices(0)).SubItems(0).Text() = "yes" Then

            End If
        End If
    End Sub

    Private Sub btn_drow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_drow.Click
        If ListView_food.SelectedItems.Count > 0 Then
            If ListView_food.SelectedIndices(0) < ListView_food.Items.Count - 1 Then
                ListView_food.Items.Item(ListView_food.SelectedIndices(0) + 1).Selected = True
                ListView_food.Focus()
                If ListView_food.Items(ListView_food.SelectedIndices(0)).SubItems(0).Text() = "void" Then

                ElseIf ListView_food.Items(ListView_food.SelectedIndices(0)).SubItems(0).Text() = "yes" Then

                End If
            End If
        Else
            ListView_food.Items.Item(ListView_food.Items.Count - 1).Selected = True
            ListView_food.Focus()
            If ListView_food.Items(ListView_food.SelectedIndices(0)).SubItems(0).Text() = "void" Then

            ElseIf ListView_food.Items(ListView_food.SelectedIndices(0)).SubItems(0).Text() = "yes" Then

            End If
        End If
    End Sub
    Private Sub btn_Addorder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Addorder.Click
        Try
            index.CloseForm()
            index.Add_order = True
            Me.Close()
            opentable.MdiParent = index
            opentable.Show()
            opentable.WindowState = FormWindowState.Minimized
            opentable.WindowState = FormWindowState.Maximized
            opentable.btnopen.Enabled = True
            opentable.Load_Product_list()
            Login.Formname = "opentable"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Function getIDTb(ByVal Name1 As String)
        Dim pt As String = "0"
        Dim res1 As MySqlDataReader = con.mysql_query("select * from pos_table_system where number='" & Name1 & "'")
        While res1.Read
            pt = res1.GetString("id")
        End While
        res1.Close()
        Return pt
    End Function

    Private Sub btn_changTb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_changTb.Click
        opentable_movetb.ShowDialog()
    End Sub

    Private Sub TB_Change(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' Timer1.Stop()
        ' Timer1.Dispose()
        Dim Ch As Button = CType(sender, Button)
        Dim Name As String = Ch.Name.ToString
        Dim words As String() = Ch.Tag.ToString.Split(New Char() {"_"c})
        ChangeID = words(1)

        If TabControl1.SelectedIndex = 0 Then
            Dim pp As FlowLayoutPanel
            Dim bb As Button
            pp = TabControl1.SelectedTab.Controls.Item(TabControl1.SelectedTab.Controls.IndexOfKey("Flow_location"))
            For n As Integer = 0 To pp.Controls.Count - 1
                bb = pp.Controls.Item(n)
                'bb = pp.Controls.Item(pp.Controls.IndexOfKey("Button_TB" & n))
                bb.FlatAppearance.BorderSize = 0
            Next
            Ch.FlatAppearance.BorderSize = 2
            Ch.FlatAppearance.BorderColor = Color.DarkOrange
        Else
            Dim bb As Button
            Dim t As TabPage = TabControl1.TabPages.Item(TabControl1.SelectedIndex)
            For n As Integer = 0 To t.Controls.Count - 1
                If TypeOf t.Controls.Item(n) Is Button Then
                    bb = t.Controls.Item(n)
                    bb.FlatAppearance.BorderSize = 0
                End If
            Next
            Ch.FlatAppearance.BorderSize = 2
            Ch.FlatAppearance.BorderColor = Color.DarkOrange
        End If
    End Sub
    Private Sub btn_payment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_payment.Click
        Try
            If ListView_food.Items.Count > 0 And CInt(TextBox_SumIndex.Text) > 0 Then
                ' payment.TextBox_Total.Text = TextBox_SumIndex.Text
                Dim itmx1 As New ListViewItem
                Dim v As Integer = 1
                Dim vats As Double = 0
                Dim price_new As Double = 0
                payment.number_invoice_new = ac.CreateBillOntb(Login.OpenId) 'สร้าง number invoice ส่งค่าเลขที่โต๊ะเพื่อให้เช็ค
                Dim h As Integer = con.mysql_num_rows(con.mysql_query("SELECT * FROM pos_order_list where rf_id_invoice='0' and status_pay='no' and (rf_id_table='" & Login.OpenId & "' or ref_id_join='" & Login.OpenId & "') order by id_ord desc; "))
                If h > 0 Then
                    Dim str As String = ""
                    Dim g As MySqlDataReader = con.mysql_query("select id as id from pos_invoice_temp where namber_inv='" & payment.number_invoice_new & "';")
                    g.Read()
                    con.mysql_query("UPDATE pos_order_list SET rf_id_invoice='" & g.GetString("id") & "' where (rf_id_table='" & Login.OpenId & "' or ref_id_join='" & Login.OpenId & "') and rf_id_invoice='0' and status_pay='no';")
                End If
                If txt_roomnum.Text.ToString <> "" Then
                    payment.rf_payment_type = 3
                    payment.des_payment = txt_roomnum.Text.ToString
                    payment.ihno = txt_roomnum.Tag.ToString
                    payment.TextBox_TypePay.Text = "INROOM: " & txt_roomnum.Text.ToString
                End If
                Me.Close()
                index.CloseForm()
                payment.MdiParent = index
                payment.Show()
                payment.WindowState = FormWindowState.Minimized
                payment.WindowState = FormWindowState.Maximized
                Login.Formname = "payment"
                payment.Btn_Enter.Enabled = True
                payment.page = "home1"
                payment.s1()
                'payment.cal_list_price()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Function vat_prd_cal(ByVal id_prd, ByRef price)
        Dim u As Double = 0.0
        Dim vat_cal As MySqlDataReader = con.mysql_query("SELECT prd_vat,prd_vatstatus FROM pos_product where id='" & id_prd.ToString & "'  ")
        While vat_cal.Read()
            If CInt(vat_cal.GetString("prd_vatstatus")) = 0 Then
                u = 0
            ElseIf CInt(vat_cal.GetString("prd_vatstatus")) = 1 Then
                u = price - ((price * 100) / CInt(vat_cal.GetString("prd_vat") + 100))
            ElseIf CInt(vat_cal.GetString("prd_vatstatus")) = 2 Then
                u = price * (CInt(vat_cal.GetString("prd_vat")) / 100)
            End If
        End While
        Return u
    End Function

    Public Function vat_prd(ByVal id_prd)
        Dim y As Integer = 0
        Dim res_vat As MySqlDataReader = con.mysql_query("SELECT prd_vat FROM pos_product where id='" & id_prd.ToString & "' limit 1 ")
        While res_vat.Read()
            y = CInt(res_vat.GetString("prd_vat"))
        End While
        res_vat.Close()
        Return y
    End Function
    Public Function vat_in_ex(ByVal id_prd)
        Dim str As String = ""
        Dim res_svat As MySqlDataReader = con.mysql_query("SELECT prd_vatstatus FROM pos_product where id='" & id_prd.ToString & "'")
        While res_svat.Read()
            If res_svat.GetString("prd_vatstatus") = "1" Then
                str = "1"
            ElseIf res_svat.GetString("prd_vatstatus") = "2" Then
                str = "2"
            ElseIf res_svat.GetString("prd_vatstatus") = "0" Then
                str = "0"
            End If
        End While
        res_svat.Close()
        Return str
    End Function
    Private Sub TextBox_Name_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox_Name.Click
        'Login.p = Process.GetProcessesByName("osk")
        'If Login.p.Count > 0 Then
        '    ' Process is running
        '    Array.ForEach(Login.p, Sub(p1 As Process) p1.Kill())
        '    System.Diagnostics.Process.Start("osk.exe")
        'Else
        '    ' Process is not running
        '    System.Diagnostics.Process.Start("osk.exe")
        'End If
    End Sub

    Private Sub btn_calcle_reserv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_calcle_reserv.Click
        index.ReservationP = False
        Panel_Ontb.Hide()
        Panel_Reservation.Hide()
        Panel1.Show()
        'index.openCloseMenu(Me)
        clearReserv()
        Login.KillP()
        ' Timer1.Start()
        btn_add_reserv.Text = "เพิ่มการจอง"
        ComboBox_ETime.Enabled = False
        ComboBox_ETimeEnd.Enabled = False
    End Sub
    Public Sub clearReserv()
        TextBox_Name.Clear()
        TextBox_Prs.Clear()
        ComboBox_STime.SelectedIndex = 0
        ComboBox_STimeEnd.SelectedIndex = 0
        ComboBox_ETime.SelectedIndex = 0
        ComboBox_ETimeEnd.SelectedIndex = 0
    End Sub

    Private Sub btn_add_reserv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_add_reserv.Click
        Dim date1 As String = DateTimePicker_Reserv.Value.ToShortDateString
        Dim wDate As String() = date1.ToString.Split(New Char() {"/"c})
        Dim y As Integer = 0
        If CInt(wDate(2)) > 2450 Then
            y = wDate(2) - 543
        Else
            y = wDate(2)
        End If
        Dim DateNSt As String = y & "-" & wDate(1) & "-" & wDate(0) & " " & ComboBox_STime.SelectedItem & ":" & ComboBox_STimeEnd.SelectedItem & ":00"
        Dim DateNEd As String = y & "-" & wDate(1) & "-" & wDate(0) & " " & ComboBox_ETime.SelectedItem & ":" & ComboBox_ETimeEnd.SelectedItem & ":00"
        If ReservIDUpdate > 0 Then
            If TextBox_Name.Text <> "" And DateNSt <> "" And DateNEd <> "" Then
                If ReserbIDCh <> 0 Then
                    ReserbIDCh = ReserbIDCh
                Else
                    ReserbIDCh = ReservIDTBUp
                End If

                Dim up_1 As Boolean = con.mysql_query("UPDATE pos_reserv_tb SET name='" & TextBox_Name.Text & "',prs='" & TextBox_Prs.Text & "',st_time='" & DateNSt & "'" _
                & ",ed_time='" & DateNEd & "',rf_id_tb='" & ReserbIDCh & "'  WHERE id='" & ReservIDUpdate & "'")
                If up_1 = True Then
                    If Login.LangG = "TH" Then
                        MessageBox.Show("อัพเดตการจองเรียบร้อย", "ข้อความแจ้งการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Reservation Update Complete", "Message Alert", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                    ReservIDUpdate = 0
                    ReservIDTBUp = 0
                    ReserbIDCh = 0
                    Login.OpenId = 0
                    clearReserv()
                    ShowReservation()
                    ShowTable("All", 0)
                    btn_add_reserv.Text = "เพิ่มการจอง"
                End If
            Else
                MessageBox.Show("Error Please Input Data", "Message Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            If TextBox_Name.Text <> "" And DateNSt <> "" And DateNEd <> "" And CInt(Login.OpenId) > 0 Then
                Dim qr As Boolean = con.mysql_query("INSERT INTO pos_reserv_tb (name,prs,st_time,ed_time,rf_id_tb,create_by) VALUES(" _
                & "'" & TextBox_Name.Text & "','" & TextBox_Prs.Text & "','" & DateNSt & "','" & DateNEd & "','" & Login.OpenId & "','" & Login.username & "')")
                If qr = True Then
                    If Login.LangG = "TH" Then
                        MessageBox.Show("จองเรียบร้อย", "ข้อความแจ้งการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Reservation Complete", "Message Alert", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                    clearReserv()
                    Login.OpenId = 0
                    ReserbIDCh = 0
                    Label_Reserv.Text = "Table No. Reservation"
                    ShowReservation()
                    ShowTable("All", 0)
                    btn_add_reserv.Text = "เพิ่มการจอง"
                End If
            Else
                MessageBox.Show("Error Please Input Data", "Message Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub
    Public Sub ShowReservation()
        If ListView_Reserv.Items.Count > 0 Then
            ListView_Reserv.Items.Clear()
        End If
        Dim date1 As String = DateTimePicker_Reserv.Value.ToShortDateString
        Dim wDate As String() = date1.ToString.Split(New Char() {"/"c})
        Dim year As Integer = 0
        If CInt(wDate(2)) > 2450 Then
            year = CInt(wDate(2)) - 543
        Else
            year = CInt(wDate(2))
        End If
        'Date Login
        Dim dLogin As Date
        If CInt(Login.DateData.ToString("yyyy")) > 2450 Then
            dLogin = CInt(Login.DateData.ToString("yyyy")) - 543 & Login.DateData.ToString("-MM-dd")
        Else
            dLogin = Login.DateData.ToString("yyyy-MM-dd")
        End If
        Dim dateSelcet As Date = year & "-" & wDate(1) & "-" & wDate(0)
        Dim res_reserv As MySqlDataReader = con.mysql_query("select *,IFNULL(pos_table_system.number,'0')AS number1,IFNULL(pos_table_system.status,'1') as status from pos_reserv_tb INNER JOIN pos_table_system ON  pos_table_system.id = pos_reserv_tb.rf_id_tb " _
        & " where YEAR(st_time)='" & year & "' and MONTH(st_time)='" & wDate(1) & "'  and DAY(st_time)='" & wDate(0) & "' and st_confirm='0'")
        Dim itmx2 As New ListViewItem
        Dim n As Integer = 1
        While res_reserv.Read()
            Dim dDateN As String = ""
            If res_reserv.GetString("st_time") <> "" Then
                dDateN = CDate(res_reserv.GetString("st_time")).ToString("dd/MM") & " " & CDate(res_reserv.GetString("st_time")).ToString("HH:mm") & "-" & CDate(res_reserv.GetString("ed_time")).ToString("HH:mm")
            End If
            itmx2 = ListView_Reserv.Items.Add(res_reserv.GetString("id"), n)
            itmx2.SubItems.Add(res_reserv.GetString("name"))
            itmx2.SubItems.Add(res_reserv.GetString("number1"))
            itmx2.SubItems.Add(res_reserv.GetString("prs"))
            itmx2.SubItems.Add(dDateN)
            If CInt(res_reserv.GetString("status")) = 2 Or (dLogin.ToString("yyyy-MM-dd") <> dateSelcet.ToString("yyyy-MM-dd")) Then
                itmx2.ForeColor = Color.Gray
                btn_confirm.Enabled = False
            Else
                btn_confirm.Enabled = True
            End If
            n += 1
        End While
    End Sub
    Private Sub DateTimePicker_Reserv_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker_Reserv.ValueChanged
        ShowReservation()
    End Sub

    Private Sub btn_up1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_up1.Click
        If ListView_Reserv.SelectedItems.Count > 0 Then
            If ListView_Reserv.SelectedIndices(0) > 0 Then
                ListView_Reserv.Items.Item(ListView_Reserv.SelectedIndices(0) - 1).Selected = True
                ListView_Reserv.Focus()
            End If
        Else
            ListView_Reserv.Items.Item(0).Selected = True
            ListView_Reserv.Focus()
        End If
    End Sub

    Private Sub btn_drow1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_drow1.Click
        If ListView_Reserv.SelectedItems.Count > 0 Then
            If ListView_Reserv.SelectedIndices(0) < ListView_food.Items.Count - 1 Then
                ListView_Reserv.Items.Item(ListView_Reserv.SelectedIndices(0) + 1).Selected = True
                ListView_Reserv.Focus()
            End If
        Else
            ListView_Reserv.Items.Item(ListView_Reserv.Items.Count - 1).Selected = True
            ListView_Reserv.Focus()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cal_resv.Click
        If ListView_Reserv.SelectedItems.Count > 0 Then
            Dim result As Integer = MessageBox.Show("Are You Cancle Reservation?", "Cancle Reservation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                Dim Del As Boolean = con.mysql_query("DELETE FROM pos_reserv_tb WHERE id='" & ListView_Reserv.Items.Item(ListView_Reserv.SelectedIndices(0)).SubItems(0).Text & "'")
                If Del = True Then
                    If Login.LangG = "TH" Then
                        MessageBox.Show("ยกเลิกการจองเรียบร้อย", "ข้อความแจ้งการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Cancel Complete", "Message Alert", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                    ShowReservation()
                    ShowTable("All", 0)
                End If
            End If
        Else
            MsgBox("กรุณาเลือกรายการที่จะลบด้วยค่ะ")
        End If
    End Sub
    Dim ReservIDUpdate As Integer = 0
    Dim ReservIDTBUp As Integer = 0
    Dim ReserbIDCh As Integer = 0
    Private Sub btn_edit_reserv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_edit_reserv.Click
        If ListView_Reserv.SelectedItems.Count > 0 Then
            If ListView_Reserv.Items.Item(ListView_Reserv.SelectedIndices(0)).SubItems(0).Text <> "" Then
                btn_add_reserv.Text = "แก้ไข"
                Dim read_update As MySqlDataReader = con.mysql_query("select * from pos_reserv_tb  LEFT JOIN pos_table_system ON  pos_table_system.id=pos_reserv_tb.rf_id_tb " _
                 & " where pos_reserv_tb.id='" & ListView_Reserv.Items.Item(ListView_Reserv.SelectedIndices(0)).SubItems(0).Text & "'")
                While read_update.Read
                    ReservIDTBUp = read_update.GetString("rf_id_tb")
                    ReservIDUpdate = read_update.GetString("id")
                    TextBox_Name.Text = read_update.GetString("name")
                    TextBox_Prs.Text = read_update.GetString("prs")
                    DateTimePicker_Reserv.Text = CDate(read_update.GetString("st_time").ToString)
                    ComboBox_STime.SelectedItem = CDate(read_update.GetString("st_time").ToString).ToString("HH")
                    ComboBox_STimeEnd.SelectedItem = CDate(read_update.GetString("st_time").ToString).ToString("mm")
                    ComboBox_ETime.SelectedItem = CDate(read_update.GetString("ed_time").ToString).ToString("HH")
                    ComboBox_ETimeEnd.SelectedItem = CDate(read_update.GetString("ed_time").ToString).ToString("mm")
                    Label_Reserv.Text = "Table No. " & read_update.GetString("number") & " Reservation"
                End While
            End If
        End If
    End Sub

    Private Sub TB_ChangeReserv(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If index.ReservationP = True Then
            Dim Ch As Button = CType(sender, Button)
            Dim Name As String = Ch.Name.ToString
            Dim words As String() = Ch.Tag.ToString.Split(New Char() {"_"c})
            ReserbIDCh = words(1)
            Login.OpenId = words(1)
            ' Dim pp As Button
            ' For i As Integer = 0 To btn_can_reserv.Controls.Count - 1
            'pp = btn_can_reserv.Controls.Item(i)
            'pp.FlatAppearance.BorderSize = 0
            'Next
            Ch.FlatAppearance.BorderSize = 2
            Ch.FlatAppearance.BorderColor = Color.Blue
        Else

        End If
    End Sub

    Private Sub TextBox_Prs_Click(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TextBox_Prs.Click
        keyborad_number.text1 = "TextBox_Prs_Reserv"
        keyborad_number.ShowDialog()
    End Sub

    Private Sub btn_gohome_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        index.CloseForm()
        index.ReservationP = False
        Change_Tb = False
        index.Gohome = True
        Me.Hide()
        'index.openCloseMenu(opentable)
        opentable.MdiParent = index
        opentable.Show()
        opentable.WindowState = FormWindowState.Minimized
        opentable.WindowState = FormWindowState.Maximized
        Login.Formname = "opentable"
    End Sub

    Private Sub btn_jointb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_jointb.Click
        If btn_jointb.Text = "รวมโต๊ะ" Or btn_jointb.Text = "Join" Then
            opentable_jointb.ShowDialog()
        End If
    End Sub
    Private Sub btn_viewall_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        opentable_viewlistall.Pr_Page = "home1"
        opentable_viewlistall.ShowDialog()
    End Sub

    Private Sub btn_void_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_void.Click
        confirm_void.page = "voidtb"
        confirm_void.ShowDialog()
        If cn_voidtb = True Then
            If Login.LangG = "TH" Then
                If Tb_Id_OldJoin = Login.OpenId Then  '==== โต๊ะที่ย้ายเป็นโต๊ะ Head ในการรวมดต๊ะ===='
                    ConfirmDialog.TextBox1.Text = "เตือนค่ะ คุณได้รวมโต๊ะไว้ซึ่งโต๊ะนี้เป็นโต๊ะหลักที่ตั้งรวม ข้อมูลทั้งหมดที่ทำการรวมโต๊ะทั้งหมดจะโดนยกลเลิกไปด้วย คุณมั่นใจใช่ไหมที่จะยกเลิกโต๊ะนี้?"
                Else
                    ConfirmDialog.TextBox1.Text = "คุณมั่นใจใช่ไหมที่จะยกเลิกโต๊ะนี้?"
                End If
                ConfirmDialog.ShowDialog()
            Else
                If Tb_Id_OldJoin = Login.OpenId Then  '==== โต๊ะที่ย้ายเป็นโต๊ะ Head ในการรวมดต๊ะ===='
                    ConfirmDialog.TextBox1.Text = "Table Is Select Active Head, Delete Data All Table Is Join Head. Are You Sure Cancel this All Table Is Join?"
                Else
                    ConfirmDialog.TextBox1.Text = "Are You Sure Cancel this Table?"
                End If
                ConfirmDialog.ShowDialog()
            End If
            If confirm_dialogvoid = True Then
                If voidReson.ShowDialog() Then
                    If voidReson.EnterT = True Then
                        'Print Void And Return Stock =='
                        'Query Group of Product for void
                        Dim ID_TB As Integer = 0
                        If Tb_Id_OldJoin <> Login.OpenId And Tb_Id_OldJoin > 0 Then '==== เข้าเงื่อนไขที่มีการรวมโต๊ะ===='
                            ID_TB = Tb_Id_OldJoin
                            PrintVoidJoin(ID_TB)
                        ElseIf Tb_Id_OldJoin = Login.OpenId Then  '==== โต๊ะที่ย้ายเป็นโต๊ะ Head ในการรวมดต๊ะ===='
                            ID_TB = Login.OpenId
                            PrintVoidJoinIsHead(ID_TB)
                        ElseIf Tb_Id_OldJoin = 0 And Login.OpenId > 0 Then '==== เข้าเงื่อนไขที่ไม่่มีการรวมโต๊ะไว้====='
                            ID_TB = Login.OpenId
                            PrintVoidNoJoin()
                        End If
                        '=== Query Date For Return Stock ==='
                        Dim query_prd As MySqlDataReader = con.mysql_query("SELECT * FROM pos_order_list WHERE rf_id_table='" & ID_TB & "' and status_pay='no'")
                        While query_prd.Read()
                            If query_prd.GetString("status_sd_captain") <> "void" Then
                                opentable.returnStock(query_prd.GetString("rf_id_prd"), query_prd.GetString("rf_id_con"), query_prd.GetString("amt"))
                            End If
                        End While
                        ' UPDATE TABLE ORDER LIST
                        Dim StringU As String = ""
                        StringU &= "Delete FROM pos_order_list WHERE rf_id_table='" & ID_TB & "' and status_pay='no';"
                        If Tb_Id_OldJoin <> Login.OpenId And Tb_Id_OldJoin > 0 Then '==== เข้าเงื่อนไขที่มีการรวมโต๊ะ===='
                            StringU &= "UPDATE pos_table_system SET update_by='" & Login.username & "',status='1',id_join_tb='0',invoice_number='0',remark_tb='-' WHERE id='" & ID_TB & "';"
                            Dim t As Integer = con.mysql_num_rows(con.mysql_query("select * from pos_table_system where id_join_tb='" & Login.OpenId & "';"))
                            If t = 1 Then
                                StringU &= "UPDATE pos_order_list SET ref_id_join='0' where rf_id_table='" & Login.OpenId & "';"
                                StringU &= "UPDATE pos_table_system SET update_by='" & Login.username & "',id_join_tb='0' where id='" & Login.OpenId & "';"
                            End If
                        ElseIf Tb_Id_OldJoin = Login.OpenId Then  '==== โต๊ะที่ย้ายเป็นโต๊ะ Head ในการรวมดต๊ะ===='
                            Dim qy_delinv0 As MySqlDataReader = con.mysql_query("select rf_id_invoice from pos_order_list where (rf_id_table='" & ID_TB & "' or ref_id_join='" & ID_TB & "') and status_pay='no';")
                            While qy_delinv0.Read
                                StringU &= "DELETE FROM pos_invoice_temp WHERE id ='" & qy_delinv0.GetString("rf_id_invoice") & "';"
                            End While
                            StringU &= "UPDATE pos_order_list SET rf_id_invoice='0',ref_id_join='0' where ref_id_join='" & ID_TB & "' and status_pay='no';" '=== update รายการที่มีการร่วมโต๊ะอยู๋ให้ รวมโต๊ะเท่า0 และ เลข invoice=0=='
                            StringU &= "UPDATE pos_table_system SET update_by='" & Login.username & "',id_join_tb='0',status='1',invoice_number='0',remark_tb='-' WHERE id='" & ID_TB & "';"
                            StringU &= "UPDATE pos_table_system SET update_by='" & Login.username & "',id_join_tb='0',status='2',invoice_number='0',remark_tb='-' WHERE id_join_tb='" & ID_TB & "' and id<>'" & ID_TB & "';"
                        ElseIf Tb_Id_OldJoin = 0 And Login.OpenId > 0 Then '==== เข้าเงื่อนไขที่ไม่่มีการรวมโต๊ะไว้====='
                            StringU &= "DELETE FROM pos_invoice_temp WHERE namber_inv = (select IFNULL(invoice_number,'0') as namber_inv from pos_table_system where id='" & ID_TB & "');" _
                            & "UPDATE pos_table_system SET status='1',update_by='" & Login.username & "',invoice_number='0',id_join_tb='0' WHERE id='" & ID_TB & "'; "
                        End If

                        Dim queryOrd As Boolean = con.mysql_query(StringU)
                        If queryOrd = True Then 'CHECK QUERY VOID
                            ' UPDATE TABLE TABLE_SYSEM
                            cn_voidtb = False
                            Label_tb_select.Text = "Table No. Option"
                            Label_tb.Text = "Table No. Option"
                            Label_Reserv.Text = "Table No. Reservation"
                            opentable.Label_tb_select.Text = "Table No.  Option"
                            If Login.LangG = "TH" Then
                                MessageBox.Show("ยกเลิกโต๊ะนี้เรียบร้อย.", "ข้อความแจ้งการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else
                                MessageBox.Show("Cancel Table Comple.", "Message Alert Action System", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If
                            voidReson.EnterT = False
                            confirm_dialogvoid = False
                            Login.OpenId = ""
                            ShowListView_Order()
                            ShowTable(TabControl1.SelectedTab.Tag, TabControl1.SelectedIndex)
                            Panel_Ontb.Hide()
                            Panel_Reservation.Hide()
                            Panel1.Show()
                        End If

                    End If
                End If
            End If
        End If
    End Sub
    Public Sub PrintVoidNoJoin()
        If ListView_food.Items.Count > 0 Then
            Dim array_print As New ArrayList
            Dim array_idtemp As New ArrayList
            Dim array_sendcap As New ArrayList
            Dim array_namecat As New ArrayList
            Dim array_print_onoff As New ArrayList
            array_print.Clear()
            array_idtemp.Clear()
            array_sendcap.Clear()
            array_namecat.Clear()
            array_print_onoff.Clear()
            Dim dateNew As DateTime
            Dim year As Integer = 0
            If CInt(Login.DateData.ToString("yyyy")) > 2450 Then
                year = CInt(Login.DateData.ToString("yyyy")) - 543
            Else
                year = CInt(Login.DateData.ToString("yyyy"))
            End If
            dateNew = year & Login.DateData.ToString("-MM-dd") & Now.ToString(" HH:mm:ss")
            Try
                Dim array_countGroup As New ArrayList
                array_countGroup.Clear()

                For x As Integer = 0 To ListView_food.Items.Count - 1
                    If ListView_food.Items(x).SubItems(0).Text().ToLower = "yes" Or ListView_food.Items(x).SubItems(0).Text().ToLower = "no" Then
                        Dim v As Boolean = False
                        Dim printername_v As String = ""
                        Dim copy2captain As String = ""
                        Dim id_ref_temp As String = ""
                        Dim print_onoff As String = ""

                        For u As Integer = 0 To array_print.Count - 1
                            If opentable.Get_printer_subgroup(ListView_food.Items(x).SubItems(11).Text()) = array_print(u).ToString Then
                                v = True
                            End If
                        Next
                        If v = False Then
                            array_countGroup.Add(ListView_food.Items(x).SubItems(11).Text())
                            print_onoff = opentable.Get_printer_ONOFF_subgroup(ListView_food.Items(x).SubItems(11).Text())
                            printername_v = opentable.Get_printer_subgroup(ListView_food.Items(x).SubItems(11).Text())
                            copy2captain = opentable.Get_CopySendcaptain_subgroup(ListView_food.Items(x).SubItems(11).Text())
                            id_ref_temp = "P" & Login.DateData.ToString("dd") & Login.DateData.ToString("MM") & Login.DateData.ToString("yy") & Format(DateAndTime.Now, "HH") & Format(DateAndTime.Now, "mm") & Format(DateAndTime.Now, "ss") & "0" & x
                            array_print.Add(printername_v)
                            array_idtemp.Add(id_ref_temp)
                            array_sendcap.Add(copy2captain)
                            array_namecat.Add(ListView_food.Items(x).SubItems(12).Text())
                            array_print_onoff.Add(print_onoff)
                        End If
                    End If
                Next
                Dim g As Integer = 1
                For t As Integer = 0 To array_print.Count - 1
                    For j As Integer = 0 To ListView_food.Items.Count - 1
                        If ListView_food.Items(j).SubItems(0).Text().ToLower = "yes" Or ListView_food.Items(j).SubItems(0).Text().ToLower = "no" Then
                            If array_print(t).ToString = opentable.Get_printer_subgroup(ListView_food.Items(j).SubItems(11).Text()) Then
                                Dim rf_id_prd As String = ListView_food.Items(j).SubItems(2).Text()
                                Dim rf_id_con As String = ListView_food.Items(j).SubItems(3).Text()
                                Dim name_ord As String = ListView_food.Items(j).SubItems(4).Text().Replace("'", "\'")
                                Dim name_ord_en As String = ListView_food.Items(j).SubItems(5).Text().Replace("'", "\'")
                                Dim amt As String = ListView_food.Items(j).SubItems(7).Text()
                                Dim price As String = ListView_food.Items(j).SubItems(8).Text()
                                Dim remark As String = ListView_food.Items(j).SubItems(9).Text().Replace("'", "\'")
                                con.mysql_query("INSERT INTO pos_temp_print (rf_id_prd,rf_id_con,name_ord,name_ord_en,amt,price,prs,rf_id_table,status_sd_captain,status_pay,status_open,remark,create_date,code_gohome,name_cat_en,name_cat_th,id_ref_temp)" _
                                    & " VALUES('" & rf_id_prd & "','" & rf_id_con & "','" & name_ord & "','" & name_ord_en & "'," _
                                    & "'" & amt & "','" & price & "','1','" & Login.OpenId & "'," _
                                    & "'void','no','ontb','" & remark & "'," _
                                    & "'" & Login.DateData.ToString("yyyy-MM-dd") & Date.Now.ToString(" HH:mm:ss") & "','0','" & ListView_food.Items(j).SubItems(12).Text() & "','" & ListView_food.Items(j).SubItems(13).Text() & "','" & array_idtemp(t).ToString & "')")
                                g += 1
                            End If
                        End If
                    Next
                Next


                'For Print To Printer
                For h As Integer = 0 To array_print.Count - 1
                    If array_print_onoff(h) <> "0" Or array_print_onoff(h) <> 0 Then
                        Dim WorkerThread As Thread
                        Dim W As New worker
                        Thread.Sleep(1000)
                        W.setSendCaptainCancel(Login.OpenId, "ontb", index.getNameTable(Login.OpenId), dateNew.ToString("dd/MM/yyyy"), "0", Login.username, array_print(h).ToString, array_idtemp(h).ToString)
                        WorkerThread = New Thread(AddressOf W.Start)    'Create our Worker thread and tell it that when we start it it should call our Worker's Start() method
                        WorkerThread.Start()
                        If Login.LangG = "TH" Then
                            dialog_complete.Label_Dialog.Text = "ยกเลิกรายการของ " & array_namecat(h).ToString & " เรียบร้อยแล้วค่ะ"
                            dialog_complete.ShowDialog()
                        Else
                            dialog_complete.Label_Dialog.Text = "Cancel order " & array_namecat(h).ToString & " Complete."
                            dialog_complete.ShowDialog()
                        End If
                    End If
                Next
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString())
            End Try
        End If
    End Sub
    Public Sub PrintVoidJoin(ByVal id)
        Try
            Dim dateNew As DateTime
            Dim year As Integer = 0
            If CInt(Login.DateData.ToString("yyyy")) > 2450 Then
                year = CInt(Login.DateData.ToString("yyyy")) - 543
            Else
                year = CInt(Login.DateData.ToString("yyyy"))
            End If
            dateNew = year & Login.DateData.ToString("-MM-dd") & Now.ToString(" HH:mm:ss")
            Dim array_print As New ArrayList
            Dim array_idtemp As New ArrayList
            Dim array_sendcap As New ArrayList
            Dim array_namecat As New ArrayList
            Dim array_countGroup As New ArrayList
            Dim array_print_onoff As New ArrayList
            array_print.Clear()
            array_idtemp.Clear()
            array_sendcap.Clear()
            array_namecat.Clear()
            array_countGroup.Clear()
            array_print_onoff.Clear()
            Dim p As Integer = con.mysql_num_rows(con.mysql_query("SELECT * FROM pos_order_list WHERE rf_id_table='" & id & "' and status_pay='no';"))
            If p > 0 Then
                Dim QORDPrd As MySqlDataReader = con.mysql_query("SELECT * FROM pos_order_list WHERE rf_id_table='" & id & "' and status_pay='no' AND status_sd_captain<>'void' GROUP BY ref_catsubprd ORDER BY ref_catsubprd ASC;")
                Dim QORDPrd_Insert As MySqlDataReader = con.mysql_query("SELECT * FROM pos_order_list WHERE rf_id_table='" & id & "' and status_pay='no' AND status_sd_captain<>'void' ORDER BY ref_catsubprd ASC;")
                Dim x As Integer = 0
                Dim str As String = ""

                While QORDPrd.Read()

                    Dim v As Boolean = False
                    Dim printername_v As String = ""
                    Dim copy2captain As String = ""
                    Dim id_ref_temp As String = ""
                    Dim print_onoff As String = ""

                    For u As Integer = 0 To array_print.Count - 1
                        If opentable.Get_printer_subgroup(QORDPrd.GetString("ref_catsubprd")) = array_print(u).ToString Then
                            v = True
                        End If
                    Next

                    If v = False Then
                        array_countGroup.Add(QORDPrd.GetString("ref_catsubprd"))
                        print_onoff = opentable.Get_printer_ONOFF_subgroup(QORDPrd.GetString("ref_catsubprd"))
                        printername_v = opentable.Get_printer_subgroup(QORDPrd.GetString("ref_catsubprd"))
                        copy2captain = opentable.Get_CopySendcaptain_subgroup(QORDPrd.GetString("ref_catsubprd"))
                        id_ref_temp = "P" & Login.DateData.ToString("dd") & Login.DateData.ToString("MM") & Login.DateData.ToString("yy") & Format(DateAndTime.Now, "HH") & Format(DateAndTime.Now, "mm") & Format(DateAndTime.Now, "ss") & "0" & x
                        array_print.Add(printername_v)
                        array_idtemp.Add(id_ref_temp)
                        array_sendcap.Add(copy2captain)
                        array_namecat.Add(QORDPrd.GetString("name_th_cat"))
                        array_print_onoff.Add(print_onoff)
                    End If

                    x += 1
                End While
                ' Dim t As Integer = 0
                While QORDPrd_Insert.Read
                    For t As Integer = 0 To array_print.Count - 1
                        If opentable.Get_printer_subgroup(QORDPrd_Insert.GetString("ref_catsubprd")) = array_print(t).ToString Then
                            str &= "INSERT INTO pos_temp_print(rf_id_prd,rf_id_con,name_ord,name_ord_en,amt,price,prs,rf_id_table,status_sd_captain,status_pay,status_open,remark,code_gohome,name_cat_en,name_cat_th,id_ref_temp,create_date) " _
                       & " SELECT rf_id_prd,rf_id_con,name_ord,name_ord_en,amt,price,prs,rf_id_table,'void',status_pay,status_open,remark,code_gohome,name_en_cat,name_th_cat,'" & array_idtemp(t).ToString & "','" & dateNew & "' FROM pos_order_list WHERE rf_id_table='" & id & "' and status_pay='no' AND status_sd_captain<>'void' AND ref_catsubprd='" & QORDPrd_Insert.GetString("ref_catsubprd") & "';"

                        End If
                    Next

                End While
                ' MsgBox(str)
                If str <> "" Then
                    con.mysql_query(str)
                End If
                'For Print To Printer
                Dim g As Integer = 1
                For h As Integer = 0 To array_print.Count - 1
                    If array_print_onoff(h) <> "0" Or array_print_onoff(h) <> 0 Then
                        Dim WorkerThread As Thread
                        Dim W As New worker
                        Thread.Sleep(1000)
                        W.setSendCaptainCancel(id, "ontb", index.getNameTable(id), dateNew.ToString("dd/MM/yyyy"), "0", Login.username, array_print(h).ToString, array_idtemp(h).ToString)
                        WorkerThread = New Thread(AddressOf W.Start)    'Create our Worker thread and tell it that when we start it it should call our Worker's Start() method
                        WorkerThread.Start()
                        If Login.LangG = "TH" Then
                            dialog_complete.Label_Dialog.Text = "ยกเลิกรายการของ " & array_namecat(h).ToString & " เรียบร้อยแล้วค่ะ"
                            dialog_complete.ShowDialog()
                        Else
                            dialog_complete.Label_Dialog.Text = "Cancel order " & array_namecat(h).ToString & " Complete."
                            dialog_complete.ShowDialog()
                        End If

                    End If
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub PrintVoidJoinIsHead(ByVal id)
        Dim dateNew As DateTime
        Dim year As Integer = 0
        If CInt(Login.DateData.ToString("yyyy")) > 2450 Then
            year = CInt(Login.DateData.ToString("yyyy")) - 543
        Else
            year = CInt(Login.DateData.ToString("yyyy"))
        End If
        dateNew = year & Login.DateData.ToString("-MM-dd") & Now.ToString(" HH:mm:ss")
        Dim array_print As New ArrayList
        Dim array_idtemp As New ArrayList
        Dim array_sendcap As New ArrayList
        Dim array_namecat As New ArrayList
        Dim array_countGroup As New ArrayList
        Dim array_print_onoff As New ArrayList
        array_print.Clear()
        array_idtemp.Clear()
        array_sendcap.Clear()
        array_namecat.Clear()
        array_countGroup.Clear()
        array_print_onoff.Clear()
        Try
            Dim p As Integer = con.mysql_num_rows(con.mysql_query("SELECT * FROM pos_order_list WHERE rf_id_table='" & id & "' and status_pay='no';"))
            If p > 0 Then
                Dim QORDPrd As MySqlDataReader = con.mysql_query("SELECT * FROM pos_order_list WHERE rf_id_table='" & id & "' and status_pay='no' AND status_sd_captain<>'void' GROUP BY ref_catsubprd ORDER BY ref_catsubprd ASC;")
                Dim QORDPrd_Insert As MySqlDataReader = con.mysql_query("SELECT * FROM pos_order_list WHERE rf_id_table='" & id & "' and status_pay='no' AND status_sd_captain<>'void' ORDER BY ref_catsubprd ASC;")
                Dim x As Integer = 0
                Dim str As String = ""
                While QORDPrd.Read()
                    Dim v As Boolean = False
                    Dim printername_v As String = ""
                    Dim copy2captain As String = ""
                    Dim id_ref_temp As String = ""
                    Dim print_onoff As String = ""

                    For u As Integer = 0 To array_print.Count - 1
                        If opentable.Get_printer_subgroup(QORDPrd.GetString("ref_catsubprd")) = array_print(u).ToString Then
                            v = True
                        End If
                    Next
                    If v = False Then
                        array_countGroup.Add(QORDPrd.GetString("ref_catsubprd"))
                        print_onoff = opentable.Get_printer_ONOFF_subgroup(QORDPrd.GetString("ref_catsubprd"))
                        printername_v = opentable.Get_printer_subgroup(QORDPrd.GetString("ref_catsubprd"))
                        copy2captain = opentable.Get_CopySendcaptain_subgroup(QORDPrd.GetString("ref_catsubprd"))
                        id_ref_temp = "P" & Login.DateData.ToString("dd") & Login.DateData.ToString("MM") & Login.DateData.ToString("yy") & Format(DateAndTime.Now, "HH") & Format(DateAndTime.Now, "mm") & Format(DateAndTime.Now, "ss") & "0" & x
                        array_print.Add(printername_v)
                        array_idtemp.Add(id_ref_temp)
                        array_sendcap.Add(copy2captain)
                        array_namecat.Add(QORDPrd.GetString("name_th_cat"))
                        array_print_onoff.Add(print_onoff)

                    End If
                    x += 1
                End While

                While QORDPrd_Insert.Read
                    For t As Integer = 0 To array_print.Count - 1
                        If opentable.Get_printer_subgroup(QORDPrd_Insert.GetString("ref_catsubprd")) = array_print(t).ToString Then
                            str &= "INSERT INTO pos_temp_print(rf_id_prd,rf_id_con,name_ord,name_ord_en,amt,price,prs,rf_id_table,status_sd_captain,status_pay,status_open,remark,code_gohome,name_cat_en,name_cat_th,id_ref_temp,create_date) " _
                  & " SELECT rf_id_prd,rf_id_con,name_ord,name_ord_en,amt,price,prs,rf_id_table,'void',status_pay,status_open,remark,code_gohome,name_en_cat,name_th_cat,'" & array_idtemp(t).ToString & "','" & dateNew & "' FROM pos_order_list WHERE rf_id_table='" & id & "' and status_pay='no' AND status_sd_captain<>'void' AND ref_catsubprd='" & QORDPrd_Insert.GetString("ref_catsubprd") & "';"

                        End If
                    Next

                End While
                If str <> "" Then
                    con.mysql_query(str)
                End If
                'For Print To Printer
                Dim g As Integer = 1
                For h As Integer = 0 To array_print.Count - 1
                    If array_print_onoff(h) <> "0" Or array_print_onoff(h) <> 0 Then
                        Dim WorkerThread As Thread
                        Dim W As New worker
                        Thread.Sleep(1000)
                        W.setSendCaptainCancel(id, "ontb", index.getNameTable(id), dateNew.ToString("dd/MM/yyyy"), "0", Login.username, array_print(h).ToString, array_idtemp(h).ToString)
                        WorkerThread = New Thread(AddressOf W.Start)    'Create our Worker thread and tell it that when we start it it should call our Worker's Start() method
                        WorkerThread.Start()
                        If Login.LangG = "TH" Then
                            dialog_complete.Label_Dialog.Text = "ยกเลิกรายการของ " & array_namecat(h).ToString & " เรียบร้อยแล้วค่ะ"
                            dialog_complete.ShowDialog()
                        Else
                            dialog_complete.Label_Dialog.Text = "Cancel order " & array_namecat(h).ToString & " Complete."
                            dialog_complete.ShowDialog()
                        End If
                    End If
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub TabControl1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles TabControl1.Click
        ShowTable(TabControl1.SelectedTab.Tag, TabControl1.SelectedIndex)
    End Sub

    Private Sub Button_StartFD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_StartFD.Click
        If currentpage <> 1 Then
            currentpage = 1
            ShowTable("All", 0)
        End If
    End Sub

    Private Sub Button_PreFD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_PreFD.Click
        If currentpage > 1 Then
            currentpage -= 1
            ShowTable("All", 0)
        End If
    End Sub

    Private Sub Button_NextFD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_NextFD.Click
        If currentpage < maxpage Then
            currentpage += 1
            ShowTable("All", 0)
        End If
    End Sub

    Private Sub Button_LastFD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_LastFD.Click
        If currentpage <> maxpage Then
            currentpage = maxpage
            ShowTable("All", 0)
        End If
    End Sub
    Private Sub TextBox_Name_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox_Name.Leave
        Login.KillP()
    End Sub
    Private Sub btn_sendagain_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_sendagain.Click
        form_reprint_captain.ShowDialog()
    End Sub

    Private Sub ListView_food_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView_food.MouseClick
        If e.Button = MouseButtons.Left Then
            If ListView_food.SelectedItems.Count > 0 Then
                If ListView_food.SelectedIndices(0) < ListView_food.Items.Count - 1 Then
                    If ListView_food.Items(ListView_food.SelectedIndices(0)).SubItems(0).Text() = "void" Or CInt(ListView_food.Items(ListView_food.SelectedIndices(0)).SubItems(7).Text) = 0 Then

                    ElseIf ListView_food.Items(ListView_food.SelectedIndices(0)).SubItems(0).Text() = "yes" Then

                    End If
                End If
            Else
                If ListView_food.Items(ListView_food.SelectedIndices(0)).SubItems(0).Text() = "void" Or CInt(ListView_food.Items(ListView_food.SelectedIndices(0)).SubItems(7).Text) = 0 Then

                ElseIf ListView_food.Items(ListView_food.SelectedIndices(0)).SubItems(0).Text() = "yes" Then

                End If
            End If
        End If
    End Sub

    Private Sub btn_close_reserv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_close_reserv.Click
        index.ReservationP = False
        Panel_Ontb.Hide()
        Panel_Reservation.Hide()
        Panel1.Show()
        clearReserv()
        Login.KillP()
        btn_add_reserv.Text = "เพิ่มการจอง"
        ComboBox_ETime.Enabled = False
        ComboBox_ETimeEnd.Enabled = False

    End Sub

    Private Sub ComboBox_STime_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox_STime.SelectedIndexChanged
        ComboBox_ETime.Enabled = True
        ComboBox_ETime.Items.Clear()
        Dim i As Integer = CInt(ComboBox_STime.SelectedItem)
        Dim str As String = ""
        For j As Integer = i To 24
            If j < 10 Then
                str = "0" & j
            Else
                str = j
            End If
            ComboBox_ETime.Items.Add(str)
        Next
    End Sub
    Private Sub ComboBox_STimeEnd_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox_STimeEnd.SelectedIndexChanged
        ComboBox_ETimeEnd.Enabled = True
    End Sub

    Private Sub ListView_Reserv_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView_Reserv.DoubleClick

    End Sub
    Private Sub ListView_Reserv_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView_Reserv.SelectedIndexChanged
        If ListView_Reserv.SelectedItems.Count > 0 Then
            'Date Login
            Dim dLogin As Date
            If CInt(Login.DateData.ToString("yyyy")) > 2450 Then
                dLogin = CInt(Login.DateData.ToString("yyyy")) - 543 & Login.DateData.ToString("-MM-dd")
            Else
                dLogin = Login.DateData.ToString("yyyy-MM-dd")
            End If

            Dim read1 As MySqlDataReader = con.mysql_query("select * from pos_reserv_tb  INNER JOIN pos_table_system ON  pos_table_system.id=pos_reserv_tb.rf_id_tb " _
           & " where pos_reserv_tb.id='" & ListView_Reserv.Items.Item(ListView_Reserv.SelectedIndices(0)).SubItems(0).Text & "' ")
            read1.Read()

            Dim D1 As DateTime = CDate(read1.GetString("st_time"))
            If CInt(D1.ToString("yyyy")) > 2450 Then
                D1 = CInt(D1.ToString("yyyy")) - 543 & D1.ToString("-MM-dd")
            Else
                D1 = D1.ToString("yyyy-MM-dd")
            End If

            If CInt(read1.GetString("status")) = 2 Or (D1.ToString("yyyy-MM-dd") <> dLogin.ToString("yyyy-MM-dd")) Then
                btn_confirm.Enabled = False
            Else
                btn_confirm.Enabled = True
            End If
            btn_confirm.Enabled = True
            btn_edit_reserv.Enabled = True
            btn_cal_resv.Enabled = True
        End If
    End Sub
    Private Sub ListView_Reserv_ItemSelectionChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) Handles ListView_Reserv.ItemSelectionChanged
        If ListView_Reserv.SelectedIndices.Count = 0 Then
            btn_confirm.Enabled = False
            btn_edit_reserv.Enabled = False
            btn_cal_resv.Enabled = False
        End If
    End Sub

    Private Sub btn_confirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_confirm.Click
        If ListView_Reserv.SelectedItems.Count > 0 Then
            Dim result As Integer
            If Login.LangG = "TH" Then
                result = MessageBox.Show("คุณมั่นใจใช่ไหมที่เปิดโต๊ะใช่ไหม?", "ข้อความแจ้งการทำงาน", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            Else
                result = MessageBox.Show("Are you sure Open Table?", "Alert Comfirm Open Table?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            End If
            If result = DialogResult.Yes Then
                If ListView_Reserv.Items.Item(ListView_Reserv.SelectedIndices(0)).SubItems(0).Text <> "" Then
                    Dim chk2 As Integer = con.mysql_num_rows(con.mysql_query("select * from pos_reserv_tb  INNER JOIN pos_table_system ON  pos_table_system.id=pos_reserv_tb.rf_id_tb " _
                    & " where pos_reserv_tb.id='" & ListView_Reserv.Items.Item(ListView_Reserv.SelectedIndices(0)).SubItems(0).Text & "' and pos_table_system.status =1"))
                    If chk2 > 0 Then
                        Dim read_update As MySqlDataReader = con.mysql_query("select * from pos_reserv_tb  INNER JOIN pos_table_system ON  pos_table_system.id=pos_reserv_tb.rf_id_tb " _
                    & " where pos_reserv_tb.id='" & ListView_Reserv.Items.Item(ListView_Reserv.SelectedIndices(0)).SubItems(0).Text & "' and pos_table_system.status =1")
                        read_update.Read()
                        read_update.GetString("rf_id_tb")
                        read_update.GetString("id")
                        Dim v As Boolean = con_timer.mysql_query("UPDATE pos_reserv_tb SET st_confirm='1' WHERE id= '" & read_update.GetString("id") & "'")
                        If v = True Then
                            con.mysql_query("UPDATE pos_table_system SET status='2',remark_tb='" & ListView_Reserv.Items.Item(ListView_Reserv.SelectedIndices(0)).SubItems(1).Text & "' WHERE id='" & read_update.GetString("rf_id_tb") & "'")
                            ShowTable(TabControl1.SelectedTab.Tag, TabControl1.SelectedIndex)
                            ShowReservation()
                            btn_confirm.Enabled = False
                            btn_edit_reserv.Enabled = False
                            btn_cal_resv.Enabled = False
                        End If
                    Else
                        MsgBox("โต๊ะเปิดใช้งานอยู่ไม่สามารถใช้ซ้ำได้!")
                    End If


                End If
                End If
        End If
    End Sub

    Private Sub btn_supptb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_supptb.Click
        Dim result As Integer
        If Login.LangG = "TH" Then
            result = MessageBox.Show("คุณมั่นใจใช่ไหมที่จะแยกโต๊ะอาหาร?", "ยืนยันการแยกโต๊ะอาหาร", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        Else
            result = MessageBox.Show("Are You Sure Separate Table/คุณมั่นใจใช่ไหมที่จะแยกโต๊ะอาหาร ?", "Confirm Separate Table/ยืนยันการแยกโต๊ะ", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        End If
        If result = DialogResult.Yes Then
            If Tb_Id_OldJoin > 0 Then
                Dim year As String = ""
                If CInt(Login.DateData.ToString("yyyy")) > 2450 Then
                    year = CInt(Login.DateData.ToString("yyyy")) - 543
                Else
                    year = Login.DateData.ToString("yyyy")
                End If

                Dim tb_join As String = ""
                Dim numinvoice As String = ""
                Dim query_tb_join As MySqlDataReader = con.mysql_query("SELECT * FROM pos_table_system where id='" & Login.OpenId & "'")
                query_tb_join.Read()
                tb_join = query_tb_join.GetString("id_join_tb")
                numinvoice = query_tb_join.GetString("invoice_number")
                Dim v As String = ""
                v &= "UPDATE pos_order_list SET update_by='" & Login.username & "',ref_id_join='0',rf_id_invoice='0',tryNumber='0' WHERE (rf_id_table='" & tb_join & "' or ref_id_join='" & tb_join & "') and status_pay='no' and  DAY(create_date)='" & Login.DateData.ToString("dd") & "' and MONTH(create_date)='" & Login.DateData.ToString("MM") & "' and YEAR(create_date)='" & year & "';"
                '==== เช้คว่ามีบิลในรายการสินค้าไหมถ้ามีให้ลบออกทั้งมด ====='
                Dim chk As Integer = con.mysql_num_rows(con.mysql_query("select rf_id_invoice from pos_order_list where (rf_id_table='" & tb_join & "' or ref_id_join='" & tb_join & "') and status_pay='no' and  DAY(create_date)='" & Login.DateData.ToString("dd") & "' and MONTH(create_date)='" & Login.DateData.ToString("MM") & "' and YEAR(create_date)='" & year & "' GROUP BY rf_id_invoice;"))
                If chk > 0 Then
                    Dim k As MySqlDataReader = con.mysql_query("select rf_id_invoice from pos_order_list where (rf_id_table='" & tb_join & "' or ref_id_join='" & tb_join & "') and status_pay='no' and  DAY(create_date)='" & Login.DateData.ToString("dd") & "' and MONTH(create_date)='" & Login.DateData.ToString("MM") & "' and YEAR(create_date)='" & year & "' GROUP BY rf_id_invoice;")
                    While k.Read
                        v &= "DELETE FROM pos_invoice_temp WHERE id='" & k.GetString("rf_id_invoice") & "';"
                    End While
                End If
                v &= "DELETE FROM pos_invoice_temp WHERE namber_inv='" & numinvoice & "';"
                v &= "UPDATE pos_table_system SET id_join_tb='0',update_by='" & Login.username & "',invoice_number='0' WHERE id_join_tb='" & tb_join & "';"


                Dim y As Boolean = con.mysql_query(v)
                If y = True Then
                    If Login.LangG = "TH" Then
                        MessageBox.Show("แยกโต๊ะเรียบร้อย", "ข้อความแจ้งการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Separate Table Complete", "Message Alert ", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                    Login.OpenId = Tb_Id_OldJoin
                    Tb_Id_OldJoin = 0
                    ShowTable("All", 0)
                    Panel_Ontb.Hide()
                    Panel_Reservation.Hide()
                    Panel1.Show()
                End If
            End If
        End If
    End Sub

    Private Sub Panel_Chg_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)

    End Sub

    Private Sub btn_cancel_order_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancel_order.Click
        home_cancel_order.ListView_food.Items.Clear()
        For j As Integer = 0 To ListView_food.Items.Count - 1
            If ListView_food.Items(j).SubItems(0).Text() <> "voidp" Or ListView_food.Items(j).SubItems(0).Text() = "void" Then

                Dim itmx2 As ListViewItem
                Dim strV(17) As String
                strV(0) = ListView_food.Items(j).SubItems(0).Text()
                strV(1) = ListView_food.Items(j).SubItems(1).Text()
                strV(2) = ListView_food.Items(j).SubItems(2).Text()
                strV(3) = ListView_food.Items(j).SubItems(3).Text()
                strV(4) = ListView_food.Items(j).SubItems(4).Text()
                strV(5) = ListView_food.Items(j).SubItems(5).Text()
                strV(6) = ListView_food.Items(j).SubItems(6).Text()
                strV(7) = ListView_food.Items(j).SubItems(7).Text()
                strV(8) = ListView_food.Items(j).SubItems(8).Text()
                strV(9) = ListView_food.Items(j).SubItems(9).Text()
                strV(10) = ListView_food.Items(j).SubItems(10).Text()
                strV(11) = ListView_food.Items(j).SubItems(11).Text()
                strV(12) = ListView_food.Items(j).SubItems(12).Text()
                strV(13) = ListView_food.Items(j).SubItems(13).Text()
                strV(14) = ListView_food.Items(j).SubItems(14).Text()
                strV(15) = ListView_food.Items(j).SubItems(15).Text()
                strV(16) = ListView_food.Items(j).SubItems(16).Text()
                itmx2 = New ListViewItem(strV)
                home_cancel_order.ListView_food.Items.Add(itmx2)

            End If
        Next

        home_cancel_order.ShowDialog()
    End Sub

    Private Sub btn_tb_detail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_tb_detail.Click
        home1_menu.ShowDialog()
    End Sub

    Private Sub txt_adult_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_adult.Click
        keyborad_number.text1 = "txt_adult_home"
        keyborad_number.ShowDialog()
        '  opentable.AddCoverTable(txt_adult.Text, txt_child.Text, txt_cover.Text, txt_roomnum.Tag.ToString, txt_roomnum.Text, Login.OpenId, "")
    End Sub

    Private Sub txt_child_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_child.Click
        keyborad_number.text1 = "txt_child_home"
        keyborad_number.ShowDialog()
        '  opentable.AddCoverTable(txt_adult.Text, txt_child.Text, txt_cover.Text, txt_roomnum.Tag.ToString, txt_roomnum.Text, Login.OpenId, "")
    End Sub

    Private Sub txt_roomnum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_roomnum.Click
        inroom.page = "home1"
        inroom.ShowDialog()
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        txt_roomnum.Text = ""
        opentable.AddCoverTable(txt_adult.Text, txt_child.Text, txt_cover.Text, "", "", Login.OpenId, "0")
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        opentable.AddRemarkTable(Login.OpenId, txt_remark.Text)
        opentable.AddCoverTable(txt_adult.Text, txt_child.Text, txt_cover.Text, txt_roomnum.Tag.ToString, txt_roomnum.Text, Login.OpenId, "")
    End Sub

    Private Sub ListView_OrderList_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView_OrderList.DoubleClick
        If ListView_OrderList.SelectedIndices.Count = 0 Then
            Exit Sub
        End If
        If ListView_OrderList.Items.Count > 0 Then
            TextBox_SumIndex.Text = ListView_OrderList.Items(ListView_OrderList.FocusedItem.Index).SubItems(3).Text()
        End If

        Panel1.Hide()
        Panel_Reservation.Hide()
        Panel_Ontb.Show()
        Label_tb_select.Text = "Table No. " & ListView_OrderList.Items(ListView_OrderList.SelectedIndices(0)).SubItems(1).Text() & " Option"
        Login.OpenId = ListView_OrderList.Items(ListView_OrderList.SelectedIndices(0)).SubItems(0).Text()
        Load_Product_list()
    End Sub

  
    Private Sub txt_roomnum_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_roomnum.TextChanged

    End Sub

   
End Class
