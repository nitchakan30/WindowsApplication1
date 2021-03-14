Imports MySql.Data.MySqlClient
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Text
Imports System.Threading

Public Class opentakehome
    Dim con As New Mysql
    Dim ac As New Admin_ClassMain
    Dim he As New home1
    Dim print As New printClass
    Public GroupId As String
    Public SubGroupID As String
    Dim pageEnd As Integer
    Dim numPage As Integer = 0
    Dim pageAll As String
    Dim pageAllFood As Integer
    Dim sizeWFood As String
    Dim numPageFD As Integer = 0
    Dim Array_Condit() As String
    Dim Summary As Double
    Dim price1 As Double
    Dim pr_indre As Integer
    Dim Str_indre As String
    Dim Str_size As String
    Dim typeTb As String
    Dim array_new(,) As String
    Public Loadchk As Boolean = False
    Public page As String = "home1"
    Public Code_GohomeEdit As String = ""  'code ที่จะนำมาแก้ไขหรือเพิ่มรายการอาหารใหม่
    Public SendOrder1 As String = ""
    Public code_send As String = ""
    Dim getHight As Double = 0
    Public Confirm_sendOrder = False
    Private Sub opentakehome_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DoubleBuffered = True
        tabs_group()
        getHight = Math.Floor(FlowLayout_subGroup.Height / 44)
        Load_numPageAll()
        ShowSub_GroupF(0, 7)
        LoadCheckSendCaptain()
        Switch_lang()
        Confirm_sendOrder = False
        Login.Formname = "gohome_list"
        ' Label_tb_select.Text = "Table No. " & home1.getNameTable(Login.OpenId) & " Option "
        If sizeWFood > 0 Then
            FlowLayout_food.Controls.Clear()
            Show_FoodLoadF(0)
        Else
            FlowLayout_food.Controls.Clear()
        End If
        TextBox_Barcode.Focus()
        If index.Add_order = True Then
            btn_pay.Enabled = True
            ' btn_sendorder.Enabled = True
            'Load_Product_list()
        Else
            btn_pay.Enabled = True
            If ListView_ListOrder.Items.Count > 0 Then
                ListView_ListOrder.Items.Clear()
            End If
        End If
        If index.CheckOpenSystemTakehomeonly() = True Then
            btn_sendorder.Enabled = False
        End If
    End Sub
    Public Sub LoadCheckSendCaptain()
        Dim res As MySqlDataReader = con.mysql_query("SELECT send_captain_takehome AS send_captain_takehome FROM pos_shop")
        res.Read()
        If CInt(res.GetString("send_captain_takehome")) = 0 And index.Add_order = False Then
            btn_sendorder.Enabled = False
        ElseIf Code_GohomeEdit <> "" And CInt(res.GetString("send_captain_takehome")) = 1 Then
            btn_sendorder.Enabled = True
        ElseIf CInt(res.GetString("send_captain_takehome")) = 1 And index.Add_order = True Then
            btn_sendorder.Enabled = True
        ElseIf CInt(res.GetString("send_captain_takehome")) = 0 And index.Add_order = True Then
            btn_sendorder.Enabled = False
        End If
        res.Close()
    End Sub
    Private Sub Switch_lang()
        If Login.LangG = "EN" Then
            btn_sendorder.Text = "Send Captain"
            btn_pay.Text = "Payment"
            btn_save.Text = "Save"
            btn_back_menu.Text = "Back"
            Label1.Text = "Product List"
            btn_add_other.Text = "Add Other Order"
            Label3.Text = "Product All"

            ListView_ListOrder.Columns(4).Text = "Name"
            ListView_ListOrder.Columns(6).Text = "Size"
            ListView_ListOrder.Columns(7).Text = "Qty"
            ListView_ListOrder.Columns(8).Text = "Price"
            ListView_ListOrder.Columns(9).Text = "Recomment"
            ListView_ListOrder.Columns(4).Width = 0
            ListView_ListOrder.Columns(5).Width = 100

        Else
            btn_sendorder.Text = "ส่งรายการให้ห้องครัว"
            btn_pay.Text = "รับชำระเงิน"
            btn_save.Text = "บันทึก"
            btn_back_menu.Text = "ย้อนกลับ"
            Label1.Text = "รายการสินค้าที่เลือก"
            btn_add_other.Text = "เพิ่มใหม่"
            Label3.Text = "รายการสินค้าทั้งหมด"
            ListView_ListOrder.Columns(4).Text = "ชื่อรายการ"
            ListView_ListOrder.Columns(6).Text = "ขนาด"
            ListView_ListOrder.Columns(7).Text = "จำนวน"
            ListView_ListOrder.Columns(8).Text = "ราคา"
            ListView_ListOrder.Columns(9).Text = "เพิ่มเติม"
            ListView_ListOrder.Columns(4).Width = 100
            ListView_ListOrder.Columns(5).Width = 0
        End If

    End Sub
    Private Sub btn_back_menu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_back_menu.Click
        price1 = 0
        Str_indre = ""
        Str_size = ""
        Summary = 0
        clearData()
        Code_GohomeEdit = ""
        index.Add_order = False
        index.CloseForm()
            index.Gohome = False
            index.ishomeopen = False
            gohome_list.MdiParent = index
            gohome_list.Show()
            gohome_list.WindowState = FormWindowState.Minimized
            gohome_list.WindowState = FormWindowState.Maximized
            Login.OpenId = ""
            Login.Formname = "gohome_list"
        payment_gohome.code_gohome = ""
        SendOrder1 = "0"
        Me.Close()
    End Sub
    Dim count_group_menu As Integer = 0
    Public Sub tabs_group()
        Dim Str As String
        Dim i As Integer = 1
        Dim FlowLaout As New FlowLayoutPanel
        FlowLaout.Name = "tabs_group"
        FlowLaout.FlowDirection = FlowDirection.LeftToRight
        FlowLaout.Dock = DockStyle.Fill
        Panel_TabH.Controls.Add(FlowLaout)
        FlowLaout.Controls.Clear()
        '  Login.DataGropPrd.RecordsAffecte
        Login.DataGropPrd_H = con.mysql_query("select * from pos_catprd WHERE id_status_sales='1' order by id asc")
        While Login.DataGropPrd_H.Read()
            ' MsgBox("fff")
            If CheckShowGroupMenu(Login.DataGropPrd_H.GetString("id")) = True Then
                count_group_menu += 1
            End If
            Dim Button_head = New Button
            If i = 1 Then
                GroupId = Login.DataGropPrd_H.GetString("id")
                AddHandler Button_head.Paint, AddressOf TabsOrange_Paint
            Else
                AddHandler Button_head.Paint, AddressOf TabsBlue_Paint
            End If
            Button_head.FlatStyle = FlatStyle.Flat
            Button_head.FlatAppearance.BorderSize = 0
            Button_head.FlatAppearance.MouseOverBackColor = Color.Transparent
            Button_head.Cursor = Cursors.Hand
            Button_head.Name = "Button_group" & i
            Button_head.Height = 43
            Button_head.ForeColor = Color.White
            Button_head.Font = New Font(Button_head.Font.FontFamily, 12, FontStyle.Bold)
            If Login.DataGropPrd_H.GetString("namecat_en") <> "" Then
                Str = Login.DataGropPrd_H.GetString("namecat_en")
            Else
                Str = Login.DataGropPrd_H.GetString("namecat_th")
            End If
            Button_head.Tag = Login.DataGropPrd_H.GetString("id")
            Button_head.Text = Str
            Button_head.TextAlign = ContentAlignment.MiddleCenter
            Button_head.Visible = CheckShowGroupMenu(Login.DataGropPrd_H.GetString("id"))
            FlowLaout.Controls.Add(Button_head)
            AddHandler Button_head.Click, AddressOf Group_Click
            i += 1
        End While
        Login.DataGropPrd_H.Close()
    End Sub
    Private Sub TabsOrange_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs)
        Dim bOrange As Button = CType(sender, Button)
        Dim rect As New System.Drawing.Rectangle(0, 0, bOrange.Width, 43)
        Dim g As Graphics = e.Graphics
        Dim gradientBrush As New LinearGradientBrush(New Point(0, 43), New Point(0, 0), System.Drawing.ColorTranslator.FromHtml("#D54B00"), ColorTranslator.FromHtml("#D95F00"))
        g.FillRectangle(gradientBrush, rect)
        ' Paint Text to button
        Dim text1 As String = bOrange.Text
        Dim font1 As New Font("Tahoma", 12, FontStyle.Bold, GraphicsUnit.Point)
        Try
            Dim rectF1 As New RectangleF(20, 10, 200, 50)
            e.Graphics.DrawString(text1, font1, Brushes.White, rectF1)
            e.Graphics.DrawRectangle(Pens.Transparent, Rectangle.Round(rectF1))
        Finally
            font1.Dispose()
        End Try
        gradientBrush.Dispose()
    End Sub
    Private Sub TabsBlue_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs)
        Dim bBlue As Button = CType(sender, Button)
        Dim rect As New System.Drawing.Rectangle(0, 0, bBlue.Width, 43)
        Dim g As Graphics = e.Graphics
        Dim gradientBrush As New LinearGradientBrush(New Point(0, 43), New Point(0, 0), System.Drawing.ColorTranslator.FromHtml("#041830"), ColorTranslator.FromHtml("#082C79"))
        g.FillRectangle(gradientBrush, rect)


        ' Paint Text to button
        Dim text1 As String = bBlue.Text
        Dim font1 As New Font("Tahoma", 12, FontStyle.Bold, GraphicsUnit.Point)
        Try
            Dim rectF1 As New RectangleF(20, 10, 200, 50)
            e.Graphics.DrawString(text1, font1, Brushes.White, rectF1)
            e.Graphics.DrawRectangle(Pens.Transparent, Rectangle.Round(rectF1))
        Finally
            font1.Dispose()
        End Try
        gradientBrush.Dispose()
    End Sub
    Private Sub TabsGray_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs)
        Dim bBlue As Button = CType(sender, Button)
        Dim rect As New System.Drawing.Rectangle(0, 0, bBlue.Width, 43)
        Dim g As Graphics = e.Graphics
        Dim gradientBrush As New LinearGradientBrush(New Point(0, 43), New Point(0, 0), System.Drawing.ColorTranslator.FromHtml("#BBBDBF"), ColorTranslator.FromHtml("#FFFFFF"))
        g.FillRectangle(gradientBrush, rect)
        ' Paint Text to button
        Dim text1 As String = bBlue.Text
        Dim font1 As New Font("Tahoma", 11, FontStyle.Bold, GraphicsUnit.Point)
        Try
            Dim rectF1 As New RectangleF(20, 10, 200, 50)
            e.Graphics.DrawString(text1, font1, Brushes.Black, rectF1)
            e.Graphics.DrawRectangle(Pens.Transparent, Rectangle.Round(rectF1))
        Finally
            font1.Dispose()
        End Try
        gradientBrush.Dispose()
    End Sub

    Private Sub Group_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        numPage = 0
        Dim b As Button = CType(sender, Button)
        Dim t As Integer = numPage
        GroupId = b.Tag.ToString
        ShowSub_Group(0, getHight)
        Show_Food(0)
        Load_numPageAll()
        Load_numFood()
        If pageAll <= 0 Then
            Label_ShowSubGroup.Text = "0/0"
        Else
            Label_ShowSubGroup.Text = t + 1 & "/" & pageAll
        End If
        Dim tl As Integer
        tl = Panel_TabH.Controls.IndexOfKey("tabs_group")
        For i As Integer = 0 To Panel_TabH.Controls.Item(tl).Controls.Count - 1
            If b.Name = Panel_TabH.Controls.Item(tl).Controls.Item(i).Name Then
                AddHandler Panel_TabH.Controls.Item(tl).Controls.Item(i).Paint, AddressOf TabsOrange_Paint
                Panel_TabH.Controls.Item(tl).Controls.Item(i).Focus()
                Label_ShowHead.Text = "(" & b.Text.ToString & ")"
            Else
                AddHandler Panel_TabH.Controls.Item(tl).Controls.Item(i).Paint, AddressOf TabsBlue_Paint
                Panel_TabH.Controls.Item(tl).Controls.Item(i).Focus()

            End If

        Next
    End Sub
    Private Sub opentable_ResizeEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ResizeEnd
        Dim tl As Integer
        tl = Panel_TabH.Controls.IndexOfKey("tabs_group")
        ' Panel_TabH.Controls.Item(tl).Controls.Count
        For i As Integer = 0 To Panel_TabH.Controls.Item(tl).Controls.Count - 1
            Panel_TabH.Controls.Item(tl).Controls.Item(i).Width = Panel_TabH.Width / count_group_menu
        Next
    End Sub

    Private Sub opentable_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        Try
            'resize Group
            Dim tl As Integer
            tl = Panel_TabH.Controls.IndexOfKey("tabs_group")
            If Panel_TabH.Controls.Item(tl).Controls.Count > 0 Then
                For i As Integer = 0 To Panel_TabH.Controls.Item(tl).Controls.Count - 1
                    Panel_TabH.Controls.Item(tl).Controls.Item(i).Width = (Panel_TabH.Width / count_group_menu) - 9
                Next
            End If
            sizeWFood = Math.Floor(CDbl(FlowLayout_food.Width / 146)) * Math.Floor(CDbl(FlowLayout_food.Height / 82))
            Show_Food(0)
        Catch ex As Exception

        End Try
    End Sub
    Public Sub Load_numPageAll()
        Dim res_num = con.mysql_query("select * from pos_catsubprd where ref_id_cat='" & GroupId & "' and id_status_sales='1';")
        Dim num_i As Double = con.mysql_num_rows(res_num)
        pageAll = Math.Ceiling(num_i / getHight)
    End Sub
    Public Sub ShowSub_GroupF(ByVal StrartP As Integer, ByVal EndP As Integer)

        Dim Str As String
        Dim i As Integer = 1
        Dim x As Integer = numPage
        Label_ShowSubGroup.Text = (x + 1) & "/" & pageAll
        FlowLayout_subGroup.Controls.Clear()
        Dim n As Integer = 0
        n = con.mysql_num_rows(con.mysql_query("select * from pos_catsubprd  Where ref_id_cat='" & GroupId & "' and id_status_sales='1' order by id asc LIMIT 0," & getHight & ""))
        If n > 0 Then
            Login.DataSubGropPrd_H = con.mysql_query("select * from pos_catsubprd  Where ref_id_cat='" & GroupId & "' and id_status_sales='1' order by id asc LIMIT 0," & getHight & "")
        While Login.DataSubGropPrd_H.Read()
            Dim Button_subGroup = New Button
            If i = 1 Then
                SubGroupID = Login.DataSubGropPrd_H.GetString("id")
                AddHandler Button_subGroup.Paint, AddressOf TabsOrange_Paint
            Else
                AddHandler Button_subGroup.Paint, AddressOf TabsGray_Paint
            End If
            Button_subGroup.FlatStyle = FlatStyle.Flat
            Button_subGroup.FlatAppearance.BorderSize = 0
            Button_subGroup.FlatAppearance.MouseOverBackColor = Color.Transparent
            Button_subGroup.Cursor = Cursors.Hand
            Button_subGroup.Name = "Button_Subgroup" & i
            Button_subGroup.Width = FlowLayout_subGroup.Width - 6
            Button_subGroup.Height = 44
            Button_subGroup.Font = New Font(Button_subGroup.Font.FontFamily, 11, FontStyle.Bold)
            If Login.LangG = "EN" Then
                Str = Login.DataSubGropPrd_H.GetString("name_en")
            Else
                Str = Login.DataSubGropPrd_H.GetString("name_th")
            End If
            Button_subGroup.Tag = Login.DataSubGropPrd_H.GetString("id")
            Button_subGroup.Text = Str
            Button_subGroup.TextAlign = ContentAlignment.MiddleCenter
            FlowLayout_subGroup.Controls.Add(Button_subGroup)
            AddHandler Button_subGroup.Click, AddressOf SubGroup_Click
            i += 1
        End While
            Login.DataSubGropPrd_H.Close()

        End If
    End Sub
    Public Sub ShowSub_Group(ByVal StrartP As Integer, ByVal EndP As Integer)
        ' Load_numPageAll()

        Dim Str As String
        Dim res_subgroup As MySqlDataReader
        Dim i As Integer = 1
        Dim x As Integer = numPage
        'GroupId ค่าเดิมของกลุ่มเรียกใช้ตอนเปิดโปรแกรม
        Dim n As Integer = con.mysql_num_rows(con.mysql_query("select * from pos_catsubprd where ref_id_cat='" & GroupId & "' and id_status_sales='1' order by id asc LIMIT " & StrartP & " ," & EndP))
        If n > 0 Then

            res_subgroup = con.mysql_query("select * from pos_catsubprd where ref_id_cat='" & GroupId & "' and id_status_sales='1' order by id asc LIMIT " & StrartP & " ," & EndP & "")
            Label_ShowSubGroup.Text = (x + 1) & "/" & pageAll
            FlowLayout_subGroup.Controls.Clear()
            While res_subgroup.Read()
                Dim Button_subGroup = New Button
                If i = 1 Then
                    SubGroupID = res_subgroup.GetString("id")
                    AddHandler Button_subGroup.Paint, AddressOf TabsOrange_Paint
                Else
                    AddHandler Button_subGroup.Paint, AddressOf TabsGray_Paint
                End If
                Button_subGroup.FlatStyle = FlatStyle.Flat
                Button_subGroup.FlatAppearance.BorderSize = 0
                Button_subGroup.FlatAppearance.MouseOverBackColor = Color.Transparent
                Button_subGroup.Cursor = Cursors.Hand
                Button_subGroup.Name = "Button_Subgroup" & i
                Button_subGroup.Width = FlowLayout_subGroup.Width - 6
                Button_subGroup.Height = 44
                Button_subGroup.Font = New Font(Button_subGroup.Font.FontFamily, 11, FontStyle.Bold)
                If Login.LangG = "EN" Then
                    Str = res_subgroup.GetString("name_en")
                Else
                    Str = res_subgroup.GetString("name_th")
                End If
                Button_subGroup.Tag = res_subgroup.GetString("id")
                Button_subGroup.Text = Str
                Button_subGroup.TextAlign = ContentAlignment.MiddleCenter
                FlowLayout_subGroup.Controls.Add(Button_subGroup)
                AddHandler Button_subGroup.Click, AddressOf SubGroup_Click
                i += 1
            End While
            res_subgroup.Close()
        End If
    End Sub
    Public Function CheckShowGroupMenu(ByVal id)
        'โหลดข้อมูล Tabspage1
        Dim g As Boolean = False
        Dim objReader As New System.IO.StreamReader("setting_grouptakehome.bat", Encoding.UTF8)
        Dim TextLine() As String
        Do While objReader.Peek() <> -1
            TextLine = objReader.ReadLine().ToString.Trim.Split("=")
            If TextLine(0).ToString.Trim = id Then
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
    Private Sub SubGroup_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim b As Button = CType(sender, Button)
        SubGroupID = b.Tag.ToString
        Show_Food(0)
        Dim tl As Integer
        tl = Panel9.Controls.IndexOfKey("FlowLayout_subGroup")
        For i As Integer = 0 To Panel9.Controls.Item(tl).Controls.Count - 1
            If b.Name = Panel9.Controls.Item(tl).Controls.Item(i).Name Then
                AddHandler Panel9.Controls.Item(tl).Controls.Item(i).Paint, AddressOf TabsOrange_Paint
                Panel9.Controls.Item(tl).Controls.Item(i).Focus()
            Else
                AddHandler Panel9.Controls.Item(tl).Controls.Item(i).Paint, AddressOf TabsGray_Paint
                Panel9.Controls.Item(tl).Controls.Item(i).Focus()
            End If
        Next
    End Sub
    Public Sub Load_numFood()
        Dim vv = con.mysql_query("select * from pos_product where ref__id_catsubprd='" & SubGroupID & "' order by id asc ")
        Dim res_f As Integer = con.mysql_num_rows(vv)
        pageAllFood = Math.Ceiling(res_f / sizeWFood)
    End Sub
    Private Sub Food_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs)
        Dim bGray As Button = CType(sender, Button)
        Dim rect As New System.Drawing.Rectangle(0, 0, bGray.Width, bGray.Height)
        Dim g As Graphics = e.Graphics
        Dim gradientBrush As New LinearGradientBrush(New Point(0, bGray.Height), New Point(0, 0), System.Drawing.ColorTranslator.FromHtml("#BBBDBF"), ColorTranslator.FromHtml("#FFFFFF"))
        g.FillRectangle(gradientBrush, rect)

        ' Paint Text to button
        Dim text1 As String = bGray.Text
        Dim font1 As New Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point)
        Try
            Dim rectF1 As New RectangleF(20, 10, 100, 50)
            e.Graphics.DrawString(text1, font1, Brushes.Black, rectF1)
            e.Graphics.DrawRectangle(Pens.Transparent, Rectangle.Round(rectF1))
        Finally
            font1.Dispose()
        End Try
        gradientBrush.Dispose()
    End Sub
    Public Sub Show_FoodLoadF(ByVal StratPFD As Integer)
        Dim Str As String
        Dim i As Integer = 1
        Dim uu As Integer
        FlowLayout_food.Controls.Clear()
        If pageAllFood > 0 Then
            If numPageFD = 0 Then
                uu = numPageFD + 1
            Else
                uu = numPageFD
            End If
            TextBox_PageFD.Text = uu & "/" & pageAllFood
        ElseIf numPageFD = pageAllFood Then
            TextBox_PageFD.Text = pageAllFood & "/" & pageAllFood
        Else

            TextBox_PageFD.Text = "0/0"
        End If
        While Login.DataResPrd_H.Read()
            If Login.DataResPrd_H.GetString("ref__id_catsubprd") = SubGroupID And i <= sizeWFood Then
                If Login.DataResPrd_H.GetString("id") <> "" Then
                    Dim Button_Food = New Button
                    Button_Food.Cursor = Cursors.Hand
                    Button_Food.Name = "Button_FD" & i
                    Button_Food.Width = 130
                    Button_Food.Height = 70
                    Button_Food.Margin = New Padding(6)
                    Button_Food.Padding = New System.Windows.Forms.Padding(5)
                    Button_Food.ForeColor = Color.Black
                    Button_Food.Font = New Font(Button_Food.Font.FontFamily, 10, FontStyle.Bold)
                    If Login.LangG = "EN" Then
                        Str = Login.DataResPrd_H.GetString("nameprd_en")
                    Else
                        Str = Login.DataResPrd_H.GetString("nameprd_th")
                    End If
                    Button_Food.Tag = Login.DataResPrd_H.GetString("id") & "_" & " " & "_" & " " & "_" & ""
                    Button_Food.Text = Str
                    Button_Food.TextAlign = ContentAlignment.MiddleCenter
                    AddHandler Button_Food.Paint, AddressOf Food_Paint 'Paint BG And Text
                    FlowLayout_food.Controls.Add(Button_Food)
                    If CInt(Login.DataResPrd_H.GetString("indre")) > 0 Then
                        AddHandler Button_Food.Click, AddressOf ClickShowIndre
                    Else
                        AddHandler Button_Food.Click, AddressOf Add_ToCat
                    End If
                End If
            End If
            i += 1
        End While
        Login.DataResPrd_H.Close()
    End Sub
    Public Sub Show_Food(ByVal StratPFD As Integer)
        Load_numFood()
        Dim Str As String
        Dim res_food As MySqlDataReader
        Dim i As Integer = 1
        Dim uu As Integer
        Dim StrSQL As String = ""
        StrSQL += "select pos_product.nameprd_en as nameprd_en,pos_product.nameprd_th as nameprd_th,pos_product.id as id,IFNULL(pos_product_condition.ref_id_ingredients,'0')  AS indre,pos_product_condition.ref_id_size AS ref_id_size "
        StrSQL += ",pos_product_unit.id as id_unit,pos_product_unit.name_th as name_th_unit,pos_product_unit.name_en as name_en_unit,IFNULL(pos_product_condition.ref_id_unit,'0') as ref_id_unit "
        StrSQL += ",pos_product_condition.price_condition AS price_condition from pos_product"
        StrSQL += " LEFT JOIN  pos_product_condition  ON pos_product.id=pos_product_condition.ref_id_prd"
        StrSQL += " LEFT JOIN pos_product_unit ON pos_product_condition.ref_id_unit = pos_product_unit.id "
        StrSQL += " where pos_product.ref__id_catsubprd='" & SubGroupID & "' and pos_product.id_status_sales='1' GROUP BY pos_product.id order by pos_product.id asc LIMIT " & StratPFD & "," & sizeWFood
        res_food = con.mysql_query(StrSQL)
        FlowLayout_food.Controls.Clear()
        If pageAllFood > 0 Then
            If numPageFD = 0 Then
                uu = numPageFD + 1
            Else
                uu = numPageFD
            End If
            TextBox_PageFD.Text = uu & "/" & pageAllFood
        ElseIf numPageFD = pageAllFood Then
            TextBox_PageFD.Text = pageAllFood & "/" & pageAllFood
        Else
            TextBox_PageFD.Text = "0/0"
        End If
        While res_food.Read()
            If res_food.GetString("id") <> "" Then
                Dim Button_Food = New Button
                Button_Food.Cursor = Cursors.Hand
                Button_Food.Name = "Button_FD" & i
                Button_Food.Width = 130
                Button_Food.Height = 70
                Button_Food.Margin = New Padding(6)
                Button_Food.Padding = New System.Windows.Forms.Padding(5)
                Button_Food.ForeColor = Color.Black
                Button_Food.Font = New Font(Button_Food.Font.FontFamily, 9, FontStyle.Regular)
                If Login.LangG = "EN" Then
                    Str = res_food.GetString("nameprd_en")
                Else
                    Str = res_food.GetString("nameprd_th")
                End If
                Button_Food.Tag = res_food.GetString("id") & "_" & " " & "_" & " " & "_" & ""
                Button_Food.Text = Str
                Button_Food.TextAlign = ContentAlignment.MiddleCenter
                AddHandler Button_Food.Paint, AddressOf Food_Paint 'Paint BG And Text
                FlowLayout_food.Controls.Add(Button_Food)
                If CInt(res_food.GetString("indre")) > 0 Then
                    AddHandler Button_Food.Click, AddressOf ClickShowIndre
                ElseIf CInt(res_food.GetString("ref_id_unit")) > 0 Then
                    AddHandler Button_Food.Click, AddressOf ClickShowUnit
                Else
                    AddHandler Button_Food.Click, AddressOf Add_ToCat
                End If
            End If
            i += 1
        End While
        res_food.Close()
    End Sub

    Public Sub Add_ToCat(ByVal sender As Object, ByVal e As System.EventArgs)
        opentable_addnumprd1.txt_numprd.Text = "1"  'Set ค่าว่างให้ opentable_addnumprd1 กรอกตัวเลขจำนวนสินค้า
        opentable_addnumprd1.txt_recomment.Text = "" 'Set ค่าว่างให้ opentable_addnumprd1 กรอกคอมเม้นท์เพิ่มเติม
        Dim k As New Button
        k = sender
        opentable_addnumprd1.TextBox_NamePrd.Text = k.Text
        Dim res_Check As MySqlDataReader = con.mysql_query("SELECT config_frm_commentord_gh FROM pos_shop")
        res_Check.Read()
        If res_Check.GetString("config_frm_commentord_gh") = "1" Then
            If opentable_addnumprd1.ShowDialog Then  ' เช็คเมื่อมีการเปิดนหน้าจอการเพิ่มจำนวน
                If opentable_addnumprd1.CHK_Close = False Then  'เช็คว่ามีการปิดหน้าจอการเพิ่มจำนวนสินค้าหรือไม่
                    Dim id As New Button
                    Dim i As String
                    Dim aryTextFile() As String
                    id = sender
                    i = id.Tag
                    aryTextFile = i.Split("_")
                    Str_size = aryTextFile(2)
                    'add To array for check send captain order

                    Dim StrSQL As String = ""
                    StrSQL += "select *,pos_product.id AS id_prd,pos_product_condition.id AS id_con,"
                    StrSQL += "IFNULL(pos_product_condition.price_condition,'0')  AS price_condition1, "
                    StrSQL += "IFNULL(pos_product_condition.ref_id_ingredients,'0')  AS indre,pos_product_condition.ref_id_size AS ref_id_size"
                    StrSQL += ",IFNULL(pos_product_condition.ref_id_unit,'0') as ref_id_unit "
                    StrSQL += ",IFNULL(pos_catprd.namecat_en,'-') as namecat_en,IFNULL(pos_catprd.namecat_th,'-') as namecat_th "
                    StrSQL += ",IFNULL(pos_catsubprd.name_th,'-') as namesubcat_th,IFNULL(pos_catsubprd.name_en,'-') as namesubcat_en "
                    StrSQL += ",IFNULL(pos_catprd.id,'-') as id_cat1,IFNULL(pos_catsubprd.id,'-') as id_subcatprd "
                    StrSQL += ",IFNULL(pos_product.prd_vat,'0') as prd_vat,IFNULL(pos_product.prd_vatstatus,'0') as prd_vatstatus "
                    StrSQL += ",pos_product_condition.price_condition AS price_condition"
                    StrSQL += ",IFNULL(pos_product_type.t_prd_id,'0') as prd_type_dis_id,IFNULL(pos_product_type.t_name_en,'0') as prd_type_dis_en,IFNULL(pos_product_type.t_name_th,'0') as prd_type_dis_th"
                    StrSQL += "  from pos_product LEFT JOIN  pos_product_condition  ON pos_product.id=pos_product_condition.ref_id_prd"
                    StrSQL += " LEFT JOIN pos_product_unit ON  pos_product_unit.id = pos_product_condition.ref_id_unit "
                    StrSQL += " LEFT JOIN pos_catprd ON  pos_catprd.id = pos_product.ref__id_catprd "
                    StrSQL += " LEFT JOIN pos_catsubprd ON  pos_catsubprd.id = pos_product.ref__id_catsubprd "
                    StrSQL += " LEFT JOIN pos_product_type ON  pos_product_type.t_prd_id = pos_product.prd_type_dis "
                    StrSQL += " where pos_product.id='" & aryTextFile(0) & "' "
                    If aryTextFile(1) <> " " Then
                        StrSQL += " and pos_product_condition.id='" & aryTextFile(1) & "'  "
                    End If
                    Dim res_order As MySqlDataReader = con.mysql_query(StrSQL)
                    Dim itmx As New ListViewItem
                    Dim y As Integer = 0
                    Dim StrSize As String
                    Dim Name_N As String
                    Dim Name_N_En As String
                    Dim price_N As Double
                    Dim id_prd_n As String
                    Dim id_con_n As String
                    Dim bo As Boolean = False

                    For j As Integer = ListView_ListOrder.Items.Count - 1 To 0 Step -1
                        If ListView_ListOrder.Items(j).SubItems(1).Text = "no" Then
                            id_prd_n = ListView_ListOrder.Items(j).SubItems(2).Text()
                            id_con_n = ListView_ListOrder.Items(j).SubItems(3).Text()
                            If (id_prd_n = aryTextFile(0) And id_con_n = aryTextFile(1)) Then
                                ListView_ListOrder.Items(j).SubItems(8).Text = FormatNumber((CDbl(ListView_ListOrder.Items(j).SubItems(8).Text) / CDbl(ListView_ListOrder.Items(j).SubItems(7).Text)) * ((CDbl(ListView_ListOrder.Items(j).SubItems(7).Text) + CDbl(opentable_addnumprd1.txt_numprd.Text))), 2)
                                ListView_ListOrder.Items(j).SubItems(7).Text = CInt(ListView_ListOrder.Items(j).SubItems(7).Text) + CInt(opentable_addnumprd1.txt_numprd.Text)
                                bo = True
                                Exit For
                            ElseIf aryTextFile(1) = "" And aryTextFile(1) = id_prd_n Then
                                ListView_ListOrder.Items(j).SubItems(8).Text = FormatNumber((CDbl(ListView_ListOrder.Items(j).SubItems(8).Text) / CDbl(ListView_ListOrder.Items(j).SubItems(7).Text)) * ((CDbl(ListView_ListOrder.Items(j).SubItems(7).Text) + CDbl(opentable_addnumprd1.txt_numprd.Text))), 2)
                                ListView_ListOrder.Items(j).SubItems(7).Text = CInt(ListView_ListOrder.Items(j).SubItems(7).Text) + CInt(opentable_addnumprd1.txt_numprd.Text)
                                bo = True
                                Exit For
                            End If
                        Else
                            bo = False
                            Exit For
                        End If

                    Next
                    Dim stru As String = ""
                    If bo = False Then
                        While res_order.Read()
                            itmx = ListView_ListOrder.Items.Add("0", y)
                            itmx.SubItems.Add("no")
                            itmx.SubItems.Add(res_order.GetString("id_prd"))
                            If aryTextFile(2) <> " " Then
                                StrSize = Str_size
                                If CInt(res_order.GetString("ref_id_unit")) > 0 Then
                                    stru = ""
                                Else
                                    stru = "(" & Str_indre & ")"
                                End If
                                Name_N_En = res_order.GetString("nameprd_en") & stru
                                Name_N = res_order.GetString("nameprd_th") & stru
                                price_N = res_order.GetString("price_condition1")
                            Else
                                StrSize = ""
                                Name_N = res_order.GetString("nameprd_th")
                                Name_N_En = res_order.GetString("nameprd_en")
                                price_N = res_order.GetString("price")
                            End If
                            itmx.SubItems.Add(aryTextFile(1))
                            itmx.SubItems.Add(Name_N)
                            itmx.SubItems.Add(Name_N_En)
                            itmx.SubItems.Add(StrSize)
                            itmx.SubItems.Add(opentable_addnumprd1.txt_numprd.Text)
                            itmx.SubItems.Add(FormatNumber((price_N * opentable_addnumprd1.txt_numprd.Text), 2))
                            itmx.SubItems.Add(opentable_addnumprd1.txt_recomment.Text)
                            itmx.SubItems.Add("0.0")
                            itmx.SubItems.Add("0")
                            itmx.SubItems.Add("0")
                            itmx.SubItems.Add(res_order.GetString("id_cat1"))
                            itmx.SubItems.Add(res_order.GetString("id_subcatprd"))
                            itmx.SubItems.Add(res_order.GetString("namecat_en"))
                            itmx.SubItems.Add(res_order.GetString("namecat_th"))
                            itmx.SubItems.Add(res_order.GetString("namesubcat_en"))
                            itmx.SubItems.Add(res_order.GetString("namesubcat_th"))
                            itmx.SubItems.Add(res_order.GetString("prd_vat"))
                            itmx.SubItems.Add(res_order.GetString("prd_vatstatus"))
                            itmx.SubItems.Add(res_order.GetString("prd_type_dis_id"))
                            itmx.SubItems.Add(res_order.GetString("prd_type_dis_en"))
                            itmx.SubItems.Add(res_order.GetString("prd_type_dis_th"))
                            y += 1
                        End While
                        res_order.Close()
                    End If
                    calsum()
                    If aryTextFile(3) = "level2" Then
                        Show_Food(0)
                    End If
                End If
            Else
                'Else  opentable_addnumprd.ShowDialog
            End If
        ElseIf res_Check.GetString("config_frm_commentord_gh") = "0" Then
            Dim id As New Button
            Dim i As String
            Dim aryTextFile() As String
            id = sender
            i = id.Tag
            aryTextFile = i.Split("_")
            Str_size = aryTextFile(2)
            'add To array for check send captain order

            Dim StrSQL As String = ""
            StrSQL += "select *,pos_product.id AS id_prd,pos_product_condition.id AS id_con,"
            StrSQL += "IFNULL(pos_product_condition.price_condition,'0')  AS price_condition1, "
            StrSQL += "IFNULL(pos_product_condition.ref_id_ingredients,'0')  AS indre,pos_product_condition.ref_id_size AS ref_id_size,"
            StrSQL += "IFNULL(pos_product_condition.ref_id_unit,'0') as ref_id_unit "
            StrSQL += ",IFNULL(pos_catprd.namecat_en,'-') as namecat_en,IFNULL(pos_catprd.namecat_th,'-') as namecat_th "
            StrSQL += ",IFNULL(pos_catsubprd.name_th,'-') as namesubcat_th,IFNULL(pos_catsubprd.name_en,'-') as namesubcat_en "
            StrSQL += ",IFNULL(pos_catprd.id,'-') as id_cat1,IFNULL(pos_catsubprd.id,'-') as id_subcatprd "
            StrSQL += ",IFNULL(pos_product.prd_vat,'0') as prd_vat,IFNULL(pos_product.prd_vatstatus,'0') as prd_vatstatus "
            StrSQL += ",pos_product_condition.price_condition AS price_condition"
            StrSQL += ",IFNULL(pos_product_type.t_prd_id,'0') as prd_type_dis_id,IFNULL(pos_product_type.t_name_en,'0') as prd_type_dis_en,IFNULL(pos_product_type.t_name_th,'0') as prd_type_dis_th"
            StrSQL += " from pos_product LEFT JOIN  pos_product_condition  ON pos_product.id=pos_product_condition.ref_id_prd"
            StrSQL += " LEFT JOIN pos_product_unit ON  pos_product_unit.id = pos_product_condition.ref_id_unit "
            StrSQL += " LEFT JOIN pos_catprd ON  pos_catprd.id = pos_product.ref__id_catprd "
            StrSQL += " LEFT JOIN pos_catsubprd ON  pos_catsubprd.id = pos_product.ref__id_catsubprd "
            StrSQL += " LEFT JOIN pos_product_type ON  pos_product_type.t_prd_id = pos_product.prd_type_dis "
            StrSQL += " where pos_product.id='" & aryTextFile(0) & "' "
            If aryTextFile(1) <> " " Then
                StrSQL += " and pos_product_condition.id='" & aryTextFile(1) & "'  "
            End If
            Dim res_order As MySqlDataReader = con.mysql_query(StrSQL)
            Dim itmx As New ListViewItem
            Dim y As Integer = 0
            Dim StrSize As String
            Dim Name_N As String
            Dim Name_N_En As String
            Dim price_N As Double
            Dim id_prd_n As String
            Dim id_con_n As String
            Dim bo As Boolean = False

            For j As Integer = ListView_ListOrder.Items.Count - 1 To 0 Step -1
                If ListView_ListOrder.Items(j).SubItems(1).Text = "no" Then
                    id_prd_n = ListView_ListOrder.Items(j).SubItems(2).Text()
                    id_con_n = ListView_ListOrder.Items(j).SubItems(3).Text()
                    If (id_prd_n = aryTextFile(0) And id_con_n = aryTextFile(1)) Then
                        ListView_ListOrder.Items(j).SubItems(8).Text = FormatNumber((CDbl(ListView_ListOrder.Items(j).SubItems(8).Text) / CDbl(ListView_ListOrder.Items(j).SubItems(7).Text)) * ((CDbl(ListView_ListOrder.Items(j).SubItems(7).Text) + CDbl(opentable_addnumprd1.txt_numprd.Text))), 2)
                        ListView_ListOrder.Items(j).SubItems(7).Text = CInt(ListView_ListOrder.Items(j).SubItems(7).Text) + CInt(opentable_addnumprd1.txt_numprd.Text)
                        bo = True
                        Exit For
                    ElseIf aryTextFile(1) = "" And aryTextFile(1) = id_prd_n Then
                        ListView_ListOrder.Items(j).SubItems(8).Text = FormatNumber((CDbl(ListView_ListOrder.Items(j).SubItems(8).Text) / CDbl(ListView_ListOrder.Items(j).SubItems(7).Text)) * ((CDbl(ListView_ListOrder.Items(j).SubItems(7).Text) + CDbl(opentable_addnumprd1.txt_numprd.Text))), 2)
                        ListView_ListOrder.Items(j).SubItems(7).Text = CInt(ListView_ListOrder.Items(j).SubItems(7).Text) + CInt(opentable_addnumprd1.txt_numprd.Text)
                        bo = True
                        Exit For
                        
                    End If
                    Else
                        bo = False
                        Exit For
                    End If
            Next

            If bo = False Then
                Dim str As String = ""
                While res_order.Read()
                    itmx = ListView_ListOrder.Items.Add("0", y)
                    itmx.SubItems.Add("no")
                    itmx.SubItems.Add(res_order.GetString("id_prd"))
                    If aryTextFile(2) <> " " Then
                        StrSize = Str_size
                        If CInt(res_order.GetString("ref_id_unit")) > 0 Then
                            str = ""
                        Else
                            str = "(" & Str_indre & ")"
                        End If
                        Name_N_En = res_order.GetString("nameprd_en") & str
                        Name_N = res_order.GetString("nameprd_th") & str
                        price_N = res_order.GetString("price_condition1")
                    Else
                        StrSize = ""
                        Name_N_En = res_order.GetString("nameprd_en")
                        Name_N = res_order.GetString("nameprd_th")
                        price_N = res_order.GetString("price")
                    End If
                    itmx.SubItems.Add(aryTextFile(1))
                    itmx.SubItems.Add(Name_N)
                    itmx.SubItems.Add(Name_N_En)
                    itmx.SubItems.Add(StrSize)
                    itmx.SubItems.Add(opentable_addnumprd1.txt_numprd.Text)
                    itmx.SubItems.Add(FormatNumber((price_N * opentable_addnumprd1.txt_numprd.Text), 2))
                    itmx.SubItems.Add("")
                    itmx.SubItems.Add("0.0")
                    itmx.SubItems.Add("0")
                    itmx.SubItems.Add("0")
                    itmx.SubItems.Add(res_order.GetString("id_cat1"))
                    itmx.SubItems.Add(res_order.GetString("id_subcatprd"))
                    itmx.SubItems.Add(res_order.GetString("namecat_en"))
                    itmx.SubItems.Add(res_order.GetString("namecat_th"))
                    itmx.SubItems.Add(res_order.GetString("namesubcat_en"))
                    itmx.SubItems.Add(res_order.GetString("namesubcat_th"))
                    itmx.SubItems.Add(res_order.GetString("prd_vat"))
                    itmx.SubItems.Add(res_order.GetString("prd_vatstatus"))
                    itmx.SubItems.Add(res_order.GetString("prd_type_dis_id"))
                    itmx.SubItems.Add(res_order.GetString("prd_type_dis_en"))
                    itmx.SubItems.Add(res_order.GetString("prd_type_dis_th"))
                    y += 1
                End While
                res_order.Close()
            End If
            calsum()
            If aryTextFile(3) = "level2" Then
                Show_Food(0)
            End If
        End If
        res_Check.Close()
    End Sub

    Public Sub calsum()
        Summary = 0
        Dim sql_price As String = ""
        Dim vat As Double = 0.0
        Dim service_chg As Double = CalServiceCh()
        For x As Integer = 0 To ListView_ListOrder.Items.Count - 1
            If ListView_ListOrder.Items(x).SubItems(1).Text.ToLower = "cancel" Then
                Summary -= (CDbl(ListView_ListOrder.Items(x).SubItems(8).Text))
            ElseIf ListView_ListOrder.Items(x).SubItems(1).Text.ToLower = "yes" Or ListView_ListOrder.Items(x).SubItems(1).Text.ToLower = "no" Then
                Summary += (CDbl(ListView_ListOrder.Items(x).SubItems(8).Text))
            End If
        Next
        TextBox_Summary.Text = Summary
    End Sub
    Public Function CalServiceCh()
        Dim Serv As Integer = 1
        Dim res_ser As MySqlDataReader = con.mysql_query("select vat,vat_status,service_chg,service_status from pos_shop ")
        While res_ser.Read()
            If CStr(res_ser.GetDouble("service_chg")) <> "" Then
                Serv = res_ser.GetDouble("service_chg")
            Else
                Serv = 1
            End If
        End While
        res_ser.Close()
        Return Serv
    End Function

    Public Sub ClickShowIndre(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim id As New Button
        Dim i As String
        Dim aryTextFile() As String
        id = sender
        i = id.Tag
        aryTextFile = i.Split("_")
        pr_indre = aryTextFile(0)
        FlowLayout_food.Controls.Clear()
        Dim Sql1 As String = ""
        Dim Button_Back As New Button
        Button_Back.BackColor = Color.Blue
        Button_Back.FlatStyle = FlatStyle.Flat
        Button_Back.FlatAppearance.BorderSize = 1
        Button_Back.FlatAppearance.MouseOverBackColor = Color.Silver
        Button_Back.Cursor = Cursors.Hand

        Button_Back.Name = "Button_Back"
        Button_Back.Width = 130
        Button_Back.Height = 70
        Button_Back.Margin = New Padding(6)
        Button_Back.Padding = New System.Windows.Forms.Padding(5)
        Button_Back.ForeColor = Color.White
        Button_Back.Font = New Font(Button_Back.Font.FontFamily, 10, FontStyle.Bold)
        Button_Back.Text = " BACK "
        Button_Back.Image = My.Resources.Resources.arrow_180
        Button_Back.ImageAlign = ContentAlignment.MiddleCenter
        Button_Back.TextImageRelation = TextImageRelation.ImageBeforeText
        Button_Back.TextAlign = ContentAlignment.MiddleCenter
        FlowLayout_food.Controls.Add(Button_Back)
        AddHandler Button_Back.Click, AddressOf Back_FD

        Sql1 += "select *,pos_product_ingredients.name_th AS name_th1 from pos_product_condition INNER JOIN  pos_product_ingredients ON "
        Sql1 += " pos_product_condition.ref_id_ingredients=pos_product_ingredients.id "
        Sql1 += " INNER JOIN  pos_product_size ON pos_product_condition.ref_id_size=pos_product_size.id "
        Sql1 += " where pos_product_condition.ref_id_prd='" & aryTextFile(0) & "' Group by pos_product_ingredients.name_th "
        Dim res_getIndre As MySqlDataReader = con.mysql_query(Sql1)
        While res_getIndre.Read()
            Dim btn_indre As New Button
            btn_indre.BackColor = Color.LightGray
            btn_indre.FlatStyle = FlatStyle.Flat
            btn_indre.FlatAppearance.BorderSize = 1
            btn_indre.FlatAppearance.MouseOverBackColor = Color.Gray
            btn_indre.Cursor = Cursors.Hand
            btn_indre.Name = "btn_indre"
            btn_indre.Width = 130
            btn_indre.Height = 70
            btn_indre.Margin = New Padding(6)
            btn_indre.Padding = New System.Windows.Forms.Padding(5)
            btn_indre.ForeColor = Color.Black
            btn_indre.Tag = aryTextFile(0) & "_" & res_getIndre.GetString("ref_id_ingredients") & "_" & res_getIndre.GetString("name_th1")
            btn_indre.Font = New Font(Button_Back.Font.FontFamily, 10, FontStyle.Bold)
            btn_indre.Text = res_getIndre.GetString("name_th1")
            btn_indre.TextAlign = ContentAlignment.MiddleCenter
            AddHandler btn_indre.Paint, AddressOf Food_Paint 'Paint BG And Text
            AddHandler btn_indre.Click, AddressOf ShowSize
            FlowLayout_food.Controls.Add(btn_indre)
        End While
        res_getIndre.Close()
    End Sub
    Public Sub Show_indre()
        FlowLayout_food.Controls.Clear()
        Dim Sql1 As String = ""
        Dim Button_Back As New Button
        Button_Back.BackColor = Color.Blue
        Button_Back.FlatStyle = FlatStyle.Flat
        Button_Back.FlatAppearance.BorderSize = 1
        Button_Back.FlatAppearance.MouseOverBackColor = Color.Silver
        Button_Back.Cursor = Cursors.Hand
        Button_Back.Name = "Button_Back"
        Button_Back.Width = 130
        Button_Back.Height = 70
        Button_Back.Margin = New Padding(6)
        Button_Back.Padding = New System.Windows.Forms.Padding(5)
        Button_Back.ForeColor = Color.White
        Button_Back.Font = New Font(Button_Back.Font.FontFamily, 10, FontStyle.Bold)
        Button_Back.Text = " BACK "
        Button_Back.Image = My.Resources.Resources.arrow_180
        Button_Back.ImageAlign = ContentAlignment.MiddleCenter
        Button_Back.TextImageRelation = TextImageRelation.ImageBeforeText
        Button_Back.TextAlign = ContentAlignment.MiddleCenter
        FlowLayout_food.Controls.Add(Button_Back)
        AddHandler Button_Back.Click, AddressOf Back_FD
        Sql1 += "select *,pos_product_ingredients.name_th AS name_th1 from pos_product_condition INNER JOIN  pos_product_ingredients ON "
        Sql1 += " pos_product_condition.ref_id_ingredients=pos_product_ingredients.id "
        Sql1 += " INNER JOIN  pos_product_size ON pos_product_condition.ref_id_size=pos_product_size.id "
        Sql1 += " where pos_product_condition.ref_id_prd='" & pr_indre & "' Group by pos_product_ingredients.name_th "
        Dim res_getIndre As MySqlDataReader = con.mysql_query(Sql1)
        While res_getIndre.Read()
            Dim btn_indre As New Button
            btn_indre.BackColor = Color.LightGray
            btn_indre.FlatStyle = FlatStyle.Flat
            btn_indre.FlatAppearance.BorderSize = 1
            btn_indre.FlatAppearance.MouseOverBackColor = Color.Gray
            btn_indre.Cursor = Cursors.Hand
            btn_indre.Name = "btn_indre"
            btn_indre.Width = 130
            btn_indre.Height = 70
            btn_indre.Margin = New Padding(6)
            btn_indre.Padding = New System.Windows.Forms.Padding(5)
            btn_indre.ForeColor = Color.Black
            btn_indre.Tag = pr_indre & "_" & res_getIndre.GetString("ref_id_ingredients") & "_" & res_getIndre.GetString("name_th1")
            btn_indre.Font = New Font(Button_Back.Font.FontFamily, 10, FontStyle.Bold)
            btn_indre.Text = res_getIndre.GetString("name_th1")
            btn_indre.TextAlign = ContentAlignment.MiddleCenter
            AddHandler btn_indre.Paint, AddressOf Food_Paint 'Paint BG And Text
            AddHandler btn_indre.Click, AddressOf ShowSize
            FlowLayout_food.Controls.Add(btn_indre)
        End While
        res_getIndre.Close()
    End Sub
    Public Sub ClickShowUnit(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim id As New Button
        Dim i As String
        Dim aryTextFile() As String
        id = sender
        i = id.Tag
        aryTextFile = i.Split("_")
        pr_indre = aryTextFile(0)
        FlowLayout_food.Controls.Clear()
        Dim Sql1 As String = ""
        Dim Button_Back As New Button
        Button_Back.BackColor = Color.Blue
        Button_Back.FlatStyle = FlatStyle.Flat
        Button_Back.FlatAppearance.BorderSize = 1
        Button_Back.FlatAppearance.MouseOverBackColor = Color.Silver
        Button_Back.Cursor = Cursors.Hand

        Button_Back.Name = "Button_Back"
        Button_Back.Width = 130
        Button_Back.Height = 70
        Button_Back.Margin = New Padding(6)
        Button_Back.Padding = New System.Windows.Forms.Padding(5)
        Button_Back.ForeColor = Color.White
        Button_Back.Font = New Font(Button_Back.Font.FontFamily, 10, FontStyle.Bold)
        Button_Back.Text = " BACK "
        Button_Back.Image = My.Resources.Resources.arrow_180
        Button_Back.ImageAlign = ContentAlignment.MiddleCenter
        Button_Back.TextImageRelation = TextImageRelation.ImageBeforeText
        Button_Back.TextAlign = ContentAlignment.MiddleCenter
        FlowLayout_food.Controls.Add(Button_Back)
        AddHandler Button_Back.Click, AddressOf Back_FD

        Sql1 += "select pos_product_condition.ref_id_unit as ref_id_unit,pos_product_unit.name_th as name_th_unit,  "
        Sql1 += " pos_product_unit.name_en as name_en_unit,pos_product_condition.id as id_con"
        Sql1 += " from pos_product_condition "
        Sql1 += " INNER JOIN  pos_product_unit ON pos_product_condition.ref_id_unit = pos_product_unit.id "
        Sql1 += " where pos_product_condition.ref_id_prd='" & aryTextFile(0) & "' Group by pos_product_condition.ref_id_unit "
        Dim res_getUnit As MySqlDataReader = con.mysql_query(Sql1)
        Dim str As String = ""
        While res_getUnit.Read()
            Dim btn_unit As New Button
            btn_unit.BackColor = Color.LightGray
            btn_unit.FlatStyle = FlatStyle.Flat
            btn_unit.FlatAppearance.BorderSize = 1
            btn_unit.FlatAppearance.MouseOverBackColor = Color.Gray
            btn_unit.Cursor = Cursors.Hand
            btn_unit.Name = "btn_unit"
            btn_unit.Width = 130
            btn_unit.Height = 70
            btn_unit.Margin = New Padding(6)
            btn_unit.Padding = New System.Windows.Forms.Padding(5)
            btn_unit.ForeColor = Color.Black
            btn_unit.Tag = aryTextFile(0) & "_" & res_getUnit.GetString("id_con") & "_" & res_getUnit.GetString("name_th_unit") & "_" & "level2"
            btn_unit.Font = New Font(Button_Back.Font.FontFamily, 10, FontStyle.Bold)
            If res_getUnit.GetString("name_th_unit") <> "" Then
                str = res_getUnit.GetString("name_th_unit")
            Else
                str = res_getUnit.GetString("name_en_unit")
            End If
            btn_unit.Text = str
            btn_unit.TextAlign = ContentAlignment.MiddleCenter
            AddHandler btn_unit.Paint, AddressOf Food_Paint 'Paint BG And Text
            AddHandler btn_unit.Click, AddressOf Add_ToCat
            FlowLayout_food.Controls.Add(btn_unit)
        End While
        res_getUnit.Close()
    End Sub
    Private Sub Back_FD()
        FlowLayout_food.Controls.Clear()
        Show_Food(sizeWFood * numPageFD)
    End Sub
    Public Sub Back_FD1()
        FlowLayout_food.Controls.Clear()
        Show_indre()
    End Sub
    Private Sub ShowSize(ByVal sender As Object, ByVal e As System.EventArgs)
        FlowLayout_food.Controls.Clear()
        Dim id As New Button
        Dim aryTextFile() As String
        Dim Sql1 As String = ""
        Dim i As String
        id = sender
        i = id.Tag
        aryTextFile = i.Split("_")
        Str_indre = aryTextFile(2)
        Dim Button_Back1 As New Button
        Button_Back1.BackColor = Color.Blue
        Button_Back1.FlatStyle = FlatStyle.Flat
        Button_Back1.FlatAppearance.BorderSize = 1
        Button_Back1.FlatAppearance.MouseOverBackColor = Color.Silver
        Button_Back1.Cursor = Cursors.Hand
        Button_Back1.Name = "Button_Back"
        Button_Back1.Width = 130
        Button_Back1.Height = 70
        Button_Back1.Margin = New Padding(6)
        Button_Back1.Padding = New System.Windows.Forms.Padding(5)
        Button_Back1.ForeColor = Color.White
        Button_Back1.Font = New Font(Button_Back1.Font.FontFamily, 10, FontStyle.Bold)
        Button_Back1.Text = " BACK "
        Button_Back1.Image = My.Resources.Resources.arrow_180
        Button_Back1.ImageAlign = ContentAlignment.MiddleCenter
        Button_Back1.TextImageRelation = TextImageRelation.ImageBeforeText
        Button_Back1.TextAlign = ContentAlignment.MiddleCenter
        FlowLayout_food.Controls.Add(Button_Back1)
        AddHandler Button_Back1.Click, AddressOf Back_FD1
        Sql1 += "select *,pos_product_condition.id AS id_con ,pos_product_ingredients.name_th AS name_th1,pos_product_size.name_th AS name_size from pos_product_condition INNER JOIN  pos_product_ingredients ON "
        Sql1 += " pos_product_condition.ref_id_ingredients=pos_product_ingredients.id "
        Sql1 += " INNER JOIN  pos_product_size ON pos_product_condition.ref_id_size=pos_product_size.id "
        Sql1 += " where pos_product_condition.ref_id_prd='" & aryTextFile(0) & "' and pos_product_condition.ref_id_ingredients='" & aryTextFile(1) & "'  "
        Dim res_size As MySqlDataReader = con.mysql_query(Sql1)

        While res_size.Read()
            Dim btn_size As New Button
            btn_size.BackgroundImage = My.Resources.Resources.bg_51
            btn_size.FlatStyle = FlatStyle.Flat
            btn_size.FlatAppearance.BorderSize = 1
            btn_size.FlatAppearance.MouseOverBackColor = Color.Gray
            btn_size.Cursor = Cursors.Hand
            btn_size.Name = "btn_size"
            btn_size.Width = 130
            btn_size.Height = 70
            btn_size.Margin = New Padding(6)
            btn_size.Padding = New System.Windows.Forms.Padding(5)
            btn_size.ForeColor = Color.Black
            btn_size.Tag = res_size.GetString("ref_id_prd") & "_" & res_size.GetString("id_con") & "_" & res_size.GetString("name_size") & "_" & "level2"
            btn_size.Font = New Font(btn_size.Font.FontFamily, 10, FontStyle.Bold)
            btn_size.Text = res_size.GetString("name_size")
            btn_size.TextAlign = ContentAlignment.MiddleCenter
            FlowLayout_food.Controls.Add(btn_size)
            AddHandler btn_size.Paint, AddressOf Food_Paint 'Paint BG And Text
            AddHandler btn_size.Click, AddressOf Add_ToCat
        End While
        res_size.Close()
    End Sub

    Private Sub btn_next_subG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_next_subG.Click
        numPage += 1
        Dim x As Integer = numPage
        If pageAll = x Then
            numPage = (pageAll - 1)
            FlowLayout_food.Controls.Clear()
        Else

            Label_ShowSubGroup.Text = x + 1 & "/" & pageAll
            ShowSub_Group(getHight * numPage, getHight)
            FlowLayout_food.Controls.Clear()
        End If
        Show_Food(0)
    End Sub
    Private Sub btn_pre_subG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_pre_subG.Click
        Dim y As Integer = numPage
        If numPage = 0 Or numPage < 0 Then
            numPage = 0
            Label_ShowSubGroup.Text = (y + 1) & "/" & pageAll
            FlowLayout_food.Controls.Clear()
        Else
            numPage -= 1
            ShowSub_Group(getHight * numPage, getHight)
            Label_ShowSubGroup.Text = y & "/" & pageAll
            FlowLayout_food.Controls.Clear()
        End If
        Show_Food(0)
    End Sub

    Private Sub Button_NextFD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_NextFD.Click
        Dim xx As Integer = numPageFD + 1
        If pageAllFood = xx Then
            numPageFD = (pageAllFood - 1)
        Else
            numPageFD += 1
            Show_Food(sizeWFood * numPageFD)
            TextBox_PageFD.Text = xx + 1 & "/" & pageAllFood
        End If
    End Sub

    Private Sub Button_PreFD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_PreFD.Click
        Dim y As Integer = numPageFD
        If numPageFD = 0 Or numPageFD < 0 Then
            numPageFD = 0
            TextBox_PageFD.Text = (y + 1) & "/" & pageAllFood
        Else
            numPageFD -= 1
            Show_Food(sizeWFood * numPageFD)
            TextBox_PageFD.Text = y & "/" & pageAllFood
        End If
    End Sub

    Private Sub Button_LastFD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_LastFD.Click
        numPageFD = pageAllFood
        TextBox_PageFD.Text = pageAllFood & "/" & pageAllFood
        Show_Food(sizeWFood * (pageAllFood - 1))
    End Sub

    Private Sub Button_StartFD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_StartFD.Click
        numPageFD = 0
        TextBox_PageFD.Text = "1/" & pageAllFood
        Show_Food(0)
    End Sub

    Private Sub btn_up_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_up.Click
        If ListView_ListOrder.Items.Count > 0 Then
            Dim amm As Integer
            Dim pr_n As Integer
            If ListView_ListOrder.SelectedItems.Count > 0 Then
                If ListView_ListOrder.SelectedIndices(0) > 0 Then
                    ListView_ListOrder.Items.Item(ListView_ListOrder.SelectedIndices(0) - 1).Selected = True
                    ListView_ListOrder.Focus()
                    pr_n = ListView_ListOrder.Items(ListView_ListOrder.SelectedIndices(0)).SubItems(8).Text()
                    amm = ListView_ListOrder.Items(ListView_ListOrder.SelectedIndices(0)).SubItems(7).Text()
                End If
            Else
                ListView_ListOrder.Items.Item(0).Selected = True
                ListView_ListOrder.Focus()
                pr_n = ListView_ListOrder.Items(ListView_ListOrder.SelectedIndices(0)).SubItems(8).Text()
                amm = ListView_ListOrder.Items(ListView_ListOrder.SelectedIndices(0)).SubItems(7).Text()
            End If
        End If
    End Sub

    Private Sub btn_drow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_drow.Click
        If ListView_ListOrder.Items.Count > 0 Then
            Dim amm As Integer
            Dim pr_n As Integer
            If ListView_ListOrder.SelectedItems.Count > 0 Then
                If ListView_ListOrder.SelectedIndices(0) < ListView_ListOrder.Items.Count - 1 Then
                    ListView_ListOrder.Items.Item(ListView_ListOrder.SelectedIndices(0) + 1).Selected = True
                    ListView_ListOrder.Focus()
                    pr_n = ListView_ListOrder.Items(ListView_ListOrder.SelectedIndices(0)).SubItems(8).Text()
                    amm = ListView_ListOrder.Items(ListView_ListOrder.SelectedIndices(0)).SubItems(7).Text()
                End If
            Else
                ListView_ListOrder.Items.Item(ListView_ListOrder.Items.Count - 1).Selected = True
                ListView_ListOrder.Focus()
                pr_n = ListView_ListOrder.Items(ListView_ListOrder.SelectedIndices(0)).SubItems(8).Text()
                amm = ListView_ListOrder.Items(ListView_ListOrder.SelectedIndices(0)).SubItems(7).Text()
            End If

        End If
    End Sub

    Private Sub btn_plus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_plus.Click
        If ListView_ListOrder.Items.Count > 0 Then
            If ListView_ListOrder.SelectedItems.Count > 0 Then
                If ListView_ListOrder.Items(ListView_ListOrder.SelectedIndices(0)).SubItems(1).Text().ToLower <> "yes" Then
                    Try
                        Dim am As Integer = ListView_ListOrder.Items(ListView_ListOrder.SelectedIndices(0)).SubItems(7).Text()
                        Dim pr As Double = ListView_ListOrder.Items(ListView_ListOrder.SelectedIndices(0)).SubItems(8).Text()
                        am += 1
                        If am > 0 Then
                            ListView_ListOrder.Items(ListView_ListOrder.SelectedIndices(0)).SubItems(8).Text() = (pr / CDbl(ListView_ListOrder.Items(ListView_ListOrder.SelectedIndices(0)).SubItems(7).Text())) * am
                            ListView_ListOrder.Items(ListView_ListOrder.SelectedIndices(0)).SubItems(7).Text() = am
                        Else
                            ListView_ListOrder.Items(ListView_ListOrder.SelectedIndices(0)).SubItems(8).Text() = (pr / CDbl(ListView_ListOrder.Items(ListView_ListOrder.SelectedIndices(0)).SubItems(7).Text())) * 1
                            ListView_ListOrder.Items(ListView_ListOrder.SelectedIndices(0)).SubItems(7).Text() = 1
                        End If
                        calsum()
                    Catch ex As Exception
                    End Try
                Else
                End If
            Else
                MessageBox.Show("กรุณาเลือกรายการ เพื่อเพิ่มจำนวนค่ะ")
            End If
        End If
    End Sub

    Private Sub btn_minus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_minus.Click
        If ListView_ListOrder.Items.Count > 0 Then
            If ListView_ListOrder.SelectedItems.Count > 0 Then
                If ListView_ListOrder.Items(ListView_ListOrder.SelectedIndices(0)).SubItems(0).Text().ToLower <> "yes" Then
                    Try
                        Dim am As Integer = ListView_ListOrder.Items(ListView_ListOrder.SelectedIndices(0)).SubItems(7).Text()
                        Dim pr As Double = ListView_ListOrder.Items(ListView_ListOrder.SelectedIndices(0)).SubItems(8).Text()
                        am -= 1
                        If am > 0 Then
                            ListView_ListOrder.Items(ListView_ListOrder.SelectedIndices(0)).SubItems(8).Text() = (pr / CDbl(ListView_ListOrder.Items(ListView_ListOrder.SelectedIndices(0)).SubItems(7).Text())) * am
                            ListView_ListOrder.Items(ListView_ListOrder.SelectedIndices(0)).SubItems(7).Text() = am
                        Else
                            ListView_ListOrder.Items(ListView_ListOrder.SelectedIndices(0)).SubItems(8).Text() = (pr / CDbl(ListView_ListOrder.Items(ListView_ListOrder.SelectedIndices(0)).SubItems(7).Text())) * 1
                            ListView_ListOrder.Items(ListView_ListOrder.SelectedIndices(0)).SubItems(7).Text() = 1
                        End If
                        calsum()
                    Catch ex As Exception
                    End Try
                End If
            Else
                MessageBox.Show("กรุณาเลือกรายการ เพื่อลดจำนวนค่ะ")
            End If
        End If
    End Sub
    Private Sub ListView_ListOrder_LeftClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView_ListOrder.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Left Then
            price1 = ListView_ListOrder.Items(ListView_ListOrder.FocusedItem.Index).SubItems(8).Text()
        Else
            price1 = 0
        End If
    End Sub
    Private Sub btn_cancle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancle.Click
        Dim result As Integer
        If Login.LangG = "TH" Then
            result = MessageBox.Show("คุณมั่นใจใช่ไหมที่จะลบรายการสินค้านี้?", "ข้อความแจ้งการทำงาน", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        Else
            result = MessageBox.Show("Are you sure calcel this order?", "Alert Comfirm Void Order?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        End If
        If result = DialogResult.Yes Then
            If ListView_ListOrder.SelectedIndices.Count > 0 Then
                If ListView_ListOrder.Items(ListView_ListOrder.SelectedIndices(0)).SubItems(1).Text() = "cancel" Or ListView_ListOrder.Items(ListView_ListOrder.SelectedIndices(0)).SubItems(1).Text() = "no" Then
                    ListView_ListOrder.Items.RemoveAt(ListView_ListOrder.SelectedIndices.Item(0))
                    calsum()
                    If ListView_ListOrder.Items.Count > 0 Then
                        ListView_ListOrder.Items(0).Selected = True
                    End If
                End If
            Else
                MessageBox.Show("Error is data null please contact Admin")
            End If
        End If
    End Sub

    Public lang_print As String = Login.LangG
    Private Sub btn_sendorder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_sendorder.Click
        If ListView_ListOrder.Items.Count > 0 Then
            ' Dim result As Integer
            dialog_confirm.Page = "opentakehome"
            If Login.LangG = "TH" Then
                dialog_confirm.Label_Dialog.Text = "คุณมั่นใจใช่ไหมที่จะส่งรายการอาหาร?"
            Else
                dialog_confirm.Label_Dialog.Text = "Are you sure send order to captain?"
            End If
            dialog_confirm.ShowDialog()
            If Confirm_sendOrder = True Then
                If index.Add_order = True Then
                    Dim sd_prd As Boolean = False
                    For i As Integer = 0 To ListView_ListOrder.Items.Count - 1
                        If ListView_ListOrder.Items(i).SubItems(1).Text = "no" Then
                            sd_prd = True
                        End If
                    Next
                    If sd_prd = True Then
                        If Login.switchLangPrintCaptain = 1 Then
                            switch_langprint.ShowDialog()
                        End If
                        btn_sendorder.Enabled = False
                        Send_again()
                        index.Add_order = False
                    Else
                        MsgBox("กรุณาเลือกรายการเพิ่มด้วยค่ะ")
                        btn_sendorder.Enabled = True
                        sd_prd = False
                        index.Add_order = False
                    End If
                Else
                    If Login.switchLangPrintCaptain = 1 Then
                        switch_langprint.ShowDialog()
                    End If
                    btn_sendorder.Enabled = False
                    Send_Captain()
                End If
            End If
        Else
            If Login.LangG = "TH" Then
                MessageBox.Show("กรุณาเพิ่มรายการสินค้าก่อนค่ะ.!", "ข้อความแจ้งการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                MessageBox.Show("Please add order!", "Message Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        End If
    End Sub

    Public Sub Send_again()
        Dim status_open As String = "gohome"
        Dim NameTB As String = ""
        status_open = "gohome"
        Code_GohomeEdit = Code_GohomeEdit
        payment_gohome.Code_GohomeEdit = Code_GohomeEdit
        NameTB = Code_GohomeEdit
        Dim chk As Boolean = False
        Dim amt As Integer = 0
        Dim price1 As Double = 0
        Dim StringQty As String = ""
        Dim dNow As DateTime = Login.DateData.ToString("yyyy-MM-dd") & " " & Format(DateAndTime.Now, "HH:mm:ss")
        Dim id_inv_temp As String = ""
        Dim q_inv As MySqlDataReader = con.mysql_query("select IFNULL(rf_id_invoice,'0') as rf_id_invoice from pos_order_list where code_gohome='" & Code_GohomeEdit & "' and status_pay='no' limit 1;")
        q_inv.Read()
        id_inv_temp = q_inv.GetString("rf_id_invoice")
        q_inv.Close()

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

        For j As Integer = 0 To ListView_ListOrder.Items.Count - 1
            'เช็คว่าทั้งหมดมีที่เหมือนกันไหม ถ้าเหมือนให้บวกกัน หลังจากนั้น ลบข้อมูลในดาต้าเบส ออกแล้วบันทึกที่รวมกันไหมเข้าไปแทน
            If ListView_ListOrder.Items(j).SubItems(1).Text = "no" Then
                Dim rf_id_prd As Integer = ListView_ListOrder.Items(j).SubItems(2).Text
                Dim rf_id_con As String = ListView_ListOrder.Items(j).SubItems(3).Text
                Dim name_ord1 As String = ListView_ListOrder.Items(j).SubItems(4).Text.Replace("'", "\'")
                Dim name_ord_en As String = ListView_ListOrder.Items(j).SubItems(5).Text.Replace("'", "\'")
                Dim amt1 As Integer = ListView_ListOrder.Items(j).SubItems(7).Text
                Dim price As Double = CDbl(ListView_ListOrder.Items(j).SubItems(8).Text)
                Dim remark As String = ListView_ListOrder.Items(j).SubItems(9).Text.Replace("'", "\'")
                Dim id_cat As String = ListView_ListOrder.Items(j).SubItems(13).Text.Trim
                Dim id_subcatprd As String = ListView_ListOrder.Items(j).SubItems(14).Text.Trim
                Dim name_cat As String = ListView_ListOrder.Items(j).SubItems(16).Text.Trim
                Dim name_subcat As String = ListView_ListOrder.Items(j).SubItems(18).Text.Trim
                Dim ord_vat As Integer = ListView_ListOrder.Items(j).SubItems(19).Text.Trim
                Dim ord_vat_st As String = ListView_ListOrder.Items(j).SubItems(20).Text.Trim
                Dim prd_t_id As Integer = ListView_ListOrder.Items(j).SubItems(21).Text.Trim
                Dim prd_t_en As String = ListView_ListOrder.Items(j).SubItems(22).Text.Trim
                Dim prd_t_th As String = ListView_ListOrder.Items(j).SubItems(23).Text.Trim

                StringQty &= "INSERT INTO pos_order_list (rf_id_prd,rf_id_con,name_ord,name_ord_en,amt,price,prs," _
                & "rf_id_table,rf_id_invoice,status_sd_captain,status_open,remark,create_date,create_by,code_gohome,ref_cat_id," _
                 & "ref_catsubprd,name_th_cat,name_en_cat,name_th_catsubprd,name_en_catsubprd,ord_vat,ord_vat_st,prd_type_dis_id,prd_type_dis_en,prd_type_dis_th) " _
                & " VALUES('" & rf_id_prd & "','" & rf_id_con & "','" & name_ord1 & "','" & name_ord_en & "','" & amt1 & "','" & price & "'," _
                & "'1','0','" & id_inv_temp & "','no','gohome','" & ListView_ListOrder.Items(j).SubItems(9).Text.Replace("'", "\'") & "','" & dNow.ToString("yyyy-MM-dd HH:mm:ss") & "','" & Login.username & "'," _
                & "'" & Code_GohomeEdit & "','" & id_cat & "','" & id_subcatprd & "','" & name_cat & "'," _
                 & "'" & name_cat & "','" & name_subcat & "','" & name_subcat & "','" & ord_vat & "','" & ord_vat_st & "','" & prd_t_id & "','" & prd_t_en & "','" & prd_t_th & "');"
                cutStock(rf_id_prd, rf_id_con, amt1)
                Dim v As Boolean = False
                For u As Integer = 0 To array_print.Count - 1
                    If opentable.Get_printer_subgroup(id_subcatprd) = array_print(u).ToString Then
                        v = True
                    End If
                Next
                If v = False Then
                    array_print.Add(opentable.Get_printer_subgroup(id_subcatprd))
                    Dim copy2captain As String = opentable.Get_CopySendcaptain_subgroup(id_subcatprd)
                    Dim print_onoff As String = opentable.Get_printer_ONOFF_subgroup(id_subcatprd)
                    Dim id_ref_temp As String = ""
                    id_ref_temp = "P" & Login.DateData.ToString("dd") & Login.DateData.ToString("MM") & Login.DateData.ToString("yy") & Format(DateAndTime.Now, "HH") & Format(DateAndTime.Now, "mm") & Format(DateAndTime.Now, "ss") & "0" & j
                    array_idtemp.Add(id_ref_temp)
                    array_sendcap.Add(copy2captain)
                    array_namecat.Add(name_cat)
                    array_print_onoff.Add(print_onoff)
                End If

            End If
        Next
        Dim query As Boolean = con.mysql_query(StringQty)

        'ส่งเข้าห้องครัว ปริ้น ' // ส่งค่าวันที่ เดือน ปี เลขที่โต๊ะ สถานะ status_sd_captain = no ยังไม่ปริ้น
        'Print
        'Query Group of Product
        Dim str_temp As String = ""
        For t As Integer = 0 To array_print.Count - 1
            For j As Integer = 0 To ListView_ListOrder.Items.Count - 1
                If ListView_ListOrder.Items(j).SubItems(1).Text().ToLower = "no" Then

                    Dim rf_id_prd As String = ListView_ListOrder.Items(j).SubItems(2).Text
                    Dim rf_id_con As String = ListView_ListOrder.Items(j).SubItems(3).Text
                    Dim name_ord As String = ListView_ListOrder.Items(j).SubItems(4).Text.Replace("'", "\'")
                    Dim name_ord_en As String = ListView_ListOrder.Items(j).SubItems(5).Text.Replace("'", "\'")
                    Dim amt1 As String = ListView_ListOrder.Items(j).SubItems(7).Text
                    Dim price As String = ListView_ListOrder.Items(j).SubItems(8).Text
                    Dim remark As String = ListView_ListOrder.Items(j).SubItems(9).Text.Replace("'", "\'")
                    Dim namecat_en As String = ListView_ListOrder.Items(j).SubItems(15).Text
                    Dim namecat_th As String = ListView_ListOrder.Items(j).SubItems(16).Text
                    Dim id_subcatprd As String = ListView_ListOrder.Items(j).SubItems(14).Text

                    If array_print(t).ToString = opentable.Get_printer_subgroup(id_subcatprd) Then
                        str_temp &= "INSERT INTO pos_temp_print (rf_id_prd,rf_id_con,name_ord,name_ord_en,amt,price,prs,rf_id_table,status_sd_captain,status_pay,status_open,remark,create_date,code_gohome,name_cat_en,name_cat_th,id_ref_temp) " _
                        & " VALUES ('" & rf_id_prd & "','" & rf_id_con & "','" & name_ord & "','" & name_ord_en & "','" & amt1 & "','" & price & "','1','0','no','no','gohome','" & remark & "','" & dNow.ToString("yyyy-MM-dd") & "','" & Code_GohomeEdit & "'," _
                        & "'" & namecat_en & "','" & namecat_th & "','" & array_idtemp(t).ToString & "');"
                    End If

                End If
            Next
        Next
        If str_temp <> "" Then
            con.mysql_query(str_temp)
        End If

        For t As Integer = 0 To array_print.Count - 1
            If array_print_onoff(t) = "0" Then
                If Login.LangG = "TH" Then
                    dialog_complete.Label_Dialog.Text = "บันทึกรายการ " & array_namecat(t).ToString & " เรียบร้อยแล้วค่ะ"
                    dialog_complete.ShowDialog()
                Else
                    dialog_complete.Label_Dialog.Text = "Save order " & array_namecat(t).ToString & "Complete."
                    dialog_complete.ShowDialog()
                End If
            Else
                'Print
                Dim WorkerThread As Thread
                Dim W As New worker
                W.setSendCaptain(0, "gohome", NameTB, dNow.ToString("dd/MM/yyyy"), Code_GohomeEdit, Login.username, array_print(t).ToString, array_idtemp(t).ToString, array_sendcap(t).ToString, lang_print)
                WorkerThread = New Thread(AddressOf W.Start)    'Create our Worker thread and tell it that when we start it it should call our Worker's Start() method
                WorkerThread.Start()
                WorkerThread.Join()
                If Login.alert_sendcaptain = 1 Then
                    If Login.LangG = "TH" Then
                        dialog_complete.Label_Dialog.Text = "ส่งรายการ " & array_namecat(t).ToString & " เรียบร้อยแล้วค่ะ"
                        dialog_complete.ShowDialog()
                    Else
                        dialog_complete.Label_Dialog.Text = "Send order " & array_namecat(t).ToString & " to Captain Complete."
                        dialog_complete.ShowDialog()
                    End If
                End If
            End If
        Next
        Dim strUp As String = ""
        strUp &= "Update pos_order_list SET status_sd_captain='yes' WHERE " _
            & "rf_id_table='0' and status_sd_captain='no' and rf_id_invoice='" & id_inv_temp & "' and  code_gohome='" & Code_GohomeEdit & "' and " _
            & "DAY(create_date)='" & Login.DateData.ToString("dd") & "' and MONTH(create_date)='" & Login.DateData.ToString("MM") & "' and YEAR(create_date)='" & Login.DateData.ToString("yyyy") & "'"

        chk = con.mysql_query(strUp) 'Query update รายการอาหารเมื่อทำการปริ้นแล้ว
        SendOrder1 = "1"
        code_send = Code_GohomeEdit
        'เช้คว่า insert ยัง และ ปริ้นหรือยัง
        If chk = True And query = True Then
            btn_sendorder.Enabled = False
            Confirm_sendOrder = False
            gohome_list.MdiParent = index
            gohome_list.Show()
            gohome_list.WindowState = FormWindowState.Minimized
            gohome_list.WindowState = FormWindowState.Maximized
            Login.Formname = "gohome_list"
            Me.Close()
        End If
    End Sub
    Public Sub Send_Captain()
        Dim prs As String = "1"
        Dim str As String = ""
        Dim CodeGoHome As String = Create_Code_Gohome()
        Dim q_order As Boolean = False
        Dim NameTb As String = ""
        Dim id_inv_temp As String = ""
        payment_gohome.Code_GohomeEdit = CodeGoHome
        NameTb = CodeGoHome

        Dim dNow As DateTime
        If CInt(Login.DateData.ToString("yyyy")) > 2450 Then
            dNow = CInt(Login.DateData.ToString("yyyy")) - 543 & "-" & Login.DateData.ToString("MM-dd") & " " & Date.Now().ToString(" HH:mm:ss")
        Else
            dNow = CInt(Login.DateData.ToString("yyyy")) & "-" & Login.DateData.ToString("MM-dd") & " " & Date.Now().ToString(" HH:mm:ss")
        End If
        '==== insert bill invoice ===='
        Dim qty_all As Integer = 0
        Dim price_all As Double = 0.0
        For x As Integer = 0 To ListView_ListOrder.Items.Count - 1
            If ListView_ListOrder.Items(x).SubItems(1).Text.ToLower = "no" Then
                qty_all += ListView_ListOrder.Items(x).SubItems(7).Text
                price_all += CDbl(ListView_ListOrder.Items(x).SubItems(8).Text)
            End If
        Next
        Dim id_insert As String = ac.RuningInvTEMP()
        con.mysql_query("INSERT INTO pos_invoice_temp (namber_inv,number_pos,qty,price_all," _
                & "create_by,create_date,rf_payment_type,des_payment,machin_number,price_exclu_vat," _
                & "vat,serviceCh,discount,discount_des,discount_sum,ref_id_payment_acc,machine_inv," _
                & "rf_id_card,money_recript,money_ton,close_rop_id_inv,close_rop_name_inv) values(" _
                & "'" & id_insert & "','" & ac.RuningPOSTEMP() & "','" & qty_all & "','" & price_all & "'," _
                & "'" & Login.username & "','" & dNow.ToString("yyyy-MM-dd HH:mm:ss") & "','0','-','" & System.Net.Dns.GetHostName() & "','0'," _
                & "'0','0','0','บาท','0','0','" & Login.getMacAddress & "'," _
                & "'0','0','0','" & Login.Id_RopBill & "','" & Login.Str_Ropbill & "');")
        id_inv_temp = payment.GetIdInv_Pos_Invoice_Temp(id_insert)

        'Loop get value for insert database
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
        For x As Integer = 0 To ListView_ListOrder.Items.Count - 1
            If ListView_ListOrder.Items(x).SubItems(1).Text.ToLower = "no" Then
                Dim rf_id_prd As String = ListView_ListOrder.Items(x).SubItems(2).Text
                Dim rf_id_con As String = ListView_ListOrder.Items(x).SubItems(3).Text
                Dim name_ord As String = ListView_ListOrder.Items(x).SubItems(4).Text.Replace("'", "\'")
                Dim name_ord_en As String = ListView_ListOrder.Items(x).SubItems(5).Text.Replace("'", "\'")
                Dim amt As Integer = ListView_ListOrder.Items(x).SubItems(7).Text
                Dim price1 As Double = CDbl(ListView_ListOrder.Items(x).SubItems(8).Text)
                Dim remark As String = ListView_ListOrder.Items(x).SubItems(9).Text.Replace("'", "\'")
                Dim id_cat As String = ListView_ListOrder.Items(x).SubItems(13).Text.Trim
                Dim id_subcatprd As String = ListView_ListOrder.Items(x).SubItems(14).Text.Trim
                Dim name_cat_en As String = ListView_ListOrder.Items(x).SubItems(15).Text.Trim
                Dim name_cat_th As String = ListView_ListOrder.Items(x).SubItems(16).Text.Trim
                Dim name_subcat_en As String = ListView_ListOrder.Items(x).SubItems(17).Text.Trim
                Dim name_subcat_th As String = ListView_ListOrder.Items(x).SubItems(18).Text.Trim
                Dim ord_vat As Integer = ListView_ListOrder.Items(x).SubItems(19).Text.Trim
                Dim ord_vat_st As String = ListView_ListOrder.Items(x).SubItems(20).Text.Trim
                Dim prd_t_id As Integer = ListView_ListOrder.Items(x).SubItems(21).Text.Trim
                Dim prd_t_en As String = ListView_ListOrder.Items(x).SubItems(22).Text.Trim
                Dim prd_t_th As String = ListView_ListOrder.Items(x).SubItems(23).Text.Trim
                str &= "INSERT INTO pos_order_list (rf_id_prd,rf_id_con,name_ord,name_ord_en,amt,price,prs," _
                 & "rf_id_table,rf_id_invoice,status_sd_captain,status_open,remark,create_date,create_by,code_gohome,ref_cat_id," _
                 & "ref_catsubprd,name_th_cat,name_en_cat,name_th_catsubprd,name_en_catsubprd,ord_vat,ord_vat_st,prd_type_dis_id,prd_type_dis_en,prd_type_dis_th) " _
                 & " VALUES('" & rf_id_prd & "','" & rf_id_con & "','" & name_ord & "','" & name_ord_en & "','" & amt & "','" & price1 & "'," _
                 & "'" & prs & "','0','" & id_inv_temp & "','no','gohome','" & remark & "','" & dNow.ToString("yyyy-MM-dd HH:mm:ss") & "','" & Login.username & "'," _
                 & "'" & CodeGoHome & "','" & id_cat & "','" & id_subcatprd & "','" & name_cat_en & "'," _
                 & "'" & name_cat_th & "','" & name_subcat_en & "','" & name_subcat_th & "','" & ord_vat & "','" & ord_vat_st & "','" & prd_t_id & "','" & prd_t_en & "','" & prd_t_th & "');"
                cutStock(rf_id_prd, rf_id_con, amt) 'ตัดสินค้าออกจากสต๊อก ในกรณีที่ขาายของminimart 

                Dim v As Boolean = False
                For u As Integer = 0 To array_print.Count - 1
                    If opentable.Get_printer_subgroup(id_subcatprd) = array_print(u).ToString Then
                        v = True
                    End If
                Next
                If v = False Then
                    array_print.Add(opentable.Get_printer_subgroup(id_subcatprd))
                    Dim copy2captain As String = opentable.Get_CopySendcaptain_subgroup(id_subcatprd)
                    Dim print_onoff As String = opentable.Get_printer_ONOFF_subgroup(id_subcatprd)
                    Dim id_ref_temp As String = ""
                    id_ref_temp = "P" & Login.DateData.ToString("dd") & Login.DateData.ToString("MM") & Login.DateData.ToString("yy") & Format(DateAndTime.Now, "HH") & Format(DateAndTime.Now, "mm") & Format(DateAndTime.Now, "ss") & "0" & x
                    array_idtemp.Add(id_ref_temp)
                    array_sendcap.Add(copy2captain)
                    array_namecat.Add(name_cat_en)
                    array_print_onoff.Add(print_onoff)
                End If

            End If
        Next
        If str <> "" Then
            q_order = con.mysql_query(str)
        End If

        If q_order = True Then  'Check When insert database = true
            'Query Group of Product
            Dim str_temp As String = ""
            For t As Integer = 0 To array_print.Count - 1
                For j As Integer = 0 To ListView_ListOrder.Items.Count - 1
                    If ListView_ListOrder.Items(j).SubItems(1).Text().ToLower = "no" Then
                        Dim rf_id_prd As String = ListView_ListOrder.Items(j).SubItems(2).Text
                        Dim rf_id_con As String = ListView_ListOrder.Items(j).SubItems(3).Text
                        Dim name_ord As String = ListView_ListOrder.Items(j).SubItems(4).Text.Replace("'", "\'")
                        Dim name_ord_en As String = ListView_ListOrder.Items(j).SubItems(5).Text.Replace("'", "\'")
                        Dim amt As String = ListView_ListOrder.Items(j).SubItems(7).Text
                        Dim price As String = ListView_ListOrder.Items(j).SubItems(8).Text
                        Dim remark As String = ListView_ListOrder.Items(j).SubItems(9).Text.Replace("'", "\'")
                        Dim namecat_en As String = ListView_ListOrder.Items(j).SubItems(15).Text
                        Dim namecat_th As String = ListView_ListOrder.Items(j).SubItems(16).Text
                        Dim id_subcatprd As String = ListView_ListOrder.Items(j).SubItems(14).Text
                        If array_print(t).ToString = opentable.Get_printer_subgroup(id_subcatprd) Then
                            str_temp &= "INSERT INTO pos_temp_print (rf_id_prd,rf_id_con,name_ord,name_ord_en,amt,price,prs,rf_id_table,status_sd_captain,status_pay,status_open,remark,create_date,code_gohome,name_cat_en,name_cat_th,id_ref_temp) " _
                            & " VALUES ('" & rf_id_prd & "','" & rf_id_con & "','" & name_ord & "','" & name_ord_en & "','" & amt & "','" & price & "','1','0','no','no','gohome','" & remark & "','" & dNow.ToString("yyyy-MM-dd") & "','" & CodeGoHome & "'," _
                            & "'" & namecat_en & "','" & namecat_th & "','" & array_idtemp(t).ToString & "');"
                        End If
                    End If
                Next
            Next
            If str_temp <> "" Then
                con.mysql_query(str_temp)
            End If

            For p As Integer = 0 To array_print.Count - 1
                If array_print_onoff(p) = "0" Then
                    If Login.LangG = "TH" Then
                        dialog_complete.Label_Dialog.Text = "บันทึกรายการ " & array_namecat(p).ToString & " เรียบร้อยแล้วค่ะ"
                        dialog_complete.ShowDialog()
                    Else
                        dialog_complete.Label_Dialog.Text = "Save order " & array_namecat(p).ToString & " Complete."
                        dialog_complete.ShowDialog()
                    End If
                Else
                    Dim WorkerThread As Thread
                    Dim W As New worker
                    W.setSendCaptain(0, "gohome", CodeGoHome, dNow.ToString("dd/MM/yyyy"), CodeGoHome, Login.username, array_print(p).ToString, array_idtemp(p).ToString, array_sendcap(p).ToString, lang_print)
                    WorkerThread = New Thread(AddressOf W.Start)    'Create our Worker thread and tell it that when we start it it should call our Worker's Start() method
                    WorkerThread.Start()
                    WorkerThread.Join()
                    If Login.alert_sendcaptain = 1 Then
                        If Login.LangG = "TH" Then
                            dialog_complete.Label_Dialog.Text = "ส่งรายการ " & array_namecat(p).ToString & " เรียบร้อยแล้วค่ะ"
                            dialog_complete.ShowDialog()
                        Else
                            dialog_complete.Label_Dialog.Text = "Send order " & array_namecat(p).ToString & " Complete."
                            dialog_complete.ShowDialog()
                        End If
                    End If
                End If
            Next
            'SET UP PRINT
            Dim strUp As String = ""
            strUp &= "Update pos_order_list SET status_sd_captain='yes' WHERE " _
            & "rf_id_table='0' and rf_id_invoice='" & id_inv_temp & "' and code_gohome='" & CodeGoHome & "' and " _
            & "DAY(create_date)='" & Login.DateData.ToString("dd") & "' and MONTH(create_date)='" & Login.DateData.ToString("MM") & "' and YEAR(create_date)='" & Login.DateData.ToString("yyyy") & "'"
            Dim qty_print As Boolean = con.mysql_query(strUp)
            'Alert
            SendOrder1 = "1"
            code_send = CodeGoHome
            If qty_print = True Then
                'clearData()
                index.Add_order = False
                Confirm_sendOrder = False
                gohome_list.MdiParent = index
                gohome_list.Show()
                If (gohome_list.Visible = True) Then
                    gohome_list.WindowState = FormWindowState.Minimized
                    gohome_list.WindowState = FormWindowState.Maximized
                End If
                Login.Formname = "gohome_list"
                Me.Close()
            End If
        End If

    End Sub
    Public Function Get_printer(ByRef idcat)
        Dim objReader As New System.IO.StreamReader("printer_g.txt", Encoding.UTF8)
        Dim TextLine() As String
        Dim p As String = ""
        'โหลดข้อมูล Tabspage2
        Do While objReader.Peek() <> -1
            TextLine = objReader.ReadLine().ToString.Trim.Split("=")
            If idcat = TextLine(0).ToString.Trim Then
                p = TextLine(1).ToString
            End If
        Loop
        objReader.Close()
        Return p
    End Function
    Public Function Create_Code_Gohome()
        Dim code As String = ac.RuningGohome
        Return code
    End Function
    Public Function save_order()
        Dim prs As String = "1"
        Dim ID_TB As Integer = 0
        Dim CodeGoHome As String = ""
        Dim q_order As Boolean
        Dim chk As Boolean = False
        Dim status_open As String = "gohome"
        Dim NameTb As String = ""

        status_open = "gohome"
        ID_TB = 0
        CodeGoHome = Create_Code_Gohome()
        NameTb = CodeGoHome

        'Loop get value for insert database
        Dim yearNew As String
        If CInt(Login.DateData.ToString("yyyy")) > 2450 Then
            yearNew = CInt(Login.DateData.ToString("yyyy")) - 543
        Else
            yearNew = CInt(Login.DateData.ToString("yyyy"))
        End If
        Dim dNow As DateTime = yearNew & "-" & Login.DateData.ToString("MM-dd") & " " & Format(DateAndTime.Now, "HH:mm:ss")
        For x As Integer = 0 To ListView_ListOrder.Items.Count - 1
            If ListView_ListOrder.Items(x).SubItems(1).Text.ToLower <> "yes" Then
                Dim rf_id_prd As String = ListView_ListOrder.Items(x).SubItems(2).Text
                Dim rf_id_con As String = ListView_ListOrder.Items(x).SubItems(3).Text
                Dim name_ord As String = ListView_ListOrder.Items(x).SubItems(4).Text.Replace("'", "\'")
                Dim name_ord_en As String = ListView_ListOrder.Items(x).SubItems(5).Text.Replace("'", "\'")
                Dim amt As String = ListView_ListOrder.Items(x).SubItems(7).Text
                Dim price1 As Double = CDbl(ListView_ListOrder.Items(x).SubItems(8).Text)
                Dim remark As String = ListView_ListOrder.Items(x).SubItems(9).Text.Replace("'", "\'")
                Dim id_cat As String = ListView_ListOrder.Items(x).SubItems(13).Text.Trim
                Dim id_subcatprd As String = ListView_ListOrder.Items(x).SubItems(14).Text.Trim
                Dim name_cat As String = ListView_ListOrder.Items(x).SubItems(16).Text.Trim
                Dim name_subcat As String = ListView_ListOrder.Items(x).SubItems(18).Text.Trim
                Dim ord_vat As Integer = ListView_ListOrder.Items(x).SubItems(19).Text.Trim
                Dim ord_vat_st As String = ListView_ListOrder.Items(x).SubItems(20).Text.Trim
                Dim prd_t_id As Integer = ListView_ListOrder.Items(x).SubItems(21).Text.Trim
                Dim prd_t_en As String = ListView_ListOrder.Items(x).SubItems(22).Text.Trim
                Dim prd_t_th As String = ListView_ListOrder.Items(x).SubItems(23).Text.Trim
                q_order = con.mysql_query("INSERT INTO pos_order_list (rf_id_prd,rf_id_con,name_ord,amt,price,prs," _
                 & "rf_id_table,status_sd_captain,status_open,remark,create_date,create_by,code_gohome,ref_cat_id," _
                 & "ref_catsubprd,name_th_cat,name_en_cat,name_th_catsubprd,name_en_catsubprd,ord_vat,ord_vat_st,prd_type_dis_id,prd_type_dis_en,prd_type_dis_th) " _
                 & " VALUES('" & rf_id_prd & "','" & rf_id_con & "','" & name_ord & "','" & amt & "','" & price1 & "'," _
                 & "'" & prs & "','" & ID_TB & "','no','" & status_open & "','" & remark & "','" & dNow.ToString("yyyy-MM-dd HH:mm:ss") & "','" & Login.username & "'," _
                 & "'" & CodeGoHome & "','" & id_cat & "','" & id_subcatprd & "','" & name_cat & "'," _
                 & "'" & name_cat & "','" & name_subcat & "','" & name_subcat & "','" & ord_vat & "','" & ord_vat_st & "','" & prd_t_id & "','" & prd_t_en & "','" & prd_t_th & "')")
                'Cut Stock at CutPrd_Atpayment_gohome() เด้อ
                If q_order = True Then
                    chk = True
                End If
            End If
        Next
        Return CodeGoHome
    End Function
    Public Sub clearData()
        If ListView_ListOrder.Items.Count > 0 Then
            ListView_ListOrder.Items.Clear()
        End If
        TextBox_Summary.Text = "0.00"
    End Sub
    Public Sub Load_Product_list()
        If ListView_ListOrder.Items.Count > 0 Then
            ListView_ListOrder.Items.Clear()
        End If
        Dim size_n As String
        Dim rf_id_con As String
        Dim itmx1 As New ListViewItem
        Dim y As Integer = 0
        Dim res_listView As MySqlDataReader
        Dim yearNew As String
        If CInt(Login.DateData.ToString("yyyy")) > 2450 Then
            yearNew = CInt(Login.DateData.ToString("yyyy")) - 543
        Else
            yearNew = CInt(Login.DateData.ToString("yyyy"))
        End If
        Dim dNow As Date = yearNew & "-" & Login.DateData.ToString("MM-dd")
        Dim strArr() As String
        strArr = Label_tb_select.Text.Split(":")
        '  Code_GohomeEdit = strArr(1)

        res_listView = con.mysql_query("SELECT pos_order_list.id_ord AS id_ord,pos_order_list.status_sd_captain AS status_sd_captain," _
        & "pos_order_list.rf_id_prd AS rf_id_prd,pos_order_list.rf_id_con As rf_id_con,pos_order_list.name_ord AS name_ord," _
        & "  pos_order_list.prs AS prs,pos_order_list.remark AS remark,pos_order_list.code_gohome AS code_gohome," _
        & " pos_order_list.name_ord_en AS name_ord_en," _
        & " SUM(pos_order_list.amt) AS samt,SUM(pos_order_list.price) AS sprice,IFNULL(pos_product_size.name_th,0) AS name_size " _
        & ",IFNULL(pos_order_list.order_dis_val,'0') as order_dis_val,IFNULL(pos_order_list.order_dis_type,'0') as order_dis_type,IFNULL(pos_order_list.order_dis_sum,'0') as order_dis_sum," _
        & "pos_order_list.ref_cat_id as ref_cat_id,pos_order_list.ref_catsubprd as ref_catsubprd,pos_order_list.name_th_cat as name_th_cat,pos_order_list.name_en_cat as name_en_cat," _
        & "pos_order_list.name_th_catsubprd as name_th_catsubprd,pos_order_list.name_en_catsubprd as name_en_catsubprd,pos_order_list.ord_vat as ord_vat,pos_order_list.ord_vat_st as ord_vat_st" _
        & ",IFNULL(pos_order_list.prd_type_dis_id,'0') as prd_type_dis_id,IFNULL(pos_order_list.prd_type_dis_en,'0') as prd_type_dis_en" _
        & ",IFNULL(pos_order_list.prd_type_dis_th,'0') as prd_type_dis_th " _
        & " FROM pos_order_list  LEFT JOIN pos_product_condition ON pos_order_list.rf_id_con =  pos_product_condition.id" _
        & " LEFT JOIN pos_product_ingredients ON pos_product_ingredients.id  =  pos_product_condition.ref_id_ingredients" _
        & " LEFT JOIN pos_product_size ON pos_product_size.id =  pos_product_condition.ref_id_size " _
        & " WHERE pos_order_list.status_pay='no' and status_sd_captain<>'void' and code_gohome ='" & Code_GohomeEdit & "'  " _
        & " GROUP BY  pos_order_list.rf_id_prd,pos_order_list.rf_id_con,pos_order_list.name_ord")
        
        ' If Code_GohomeEdit <> "" Then
        'btn_sendorder.Enabled = True
        'End If
        While res_listView.Read()
            Dim st As String = ""
            If res_listView.GetString("status_sd_captain") = "no" Or res_listView.GetString("status_sd_captain") = "yes" Then
                st = "yes"
            ElseIf res_listView.GetString("status_sd_captain") = "void" Or res_listView.GetString("status_sd_captain") = "voidp" Then
                st = "void"
            End If
            itmx1 = ListView_ListOrder.Items.Add(res_listView.GetString("id_ord"), y)
            itmx1.SubItems.Add(st)
            itmx1.SubItems.Add(res_listView.GetString("rf_id_prd"))
            If res_listView.GetString("rf_id_con") <> "0" Then
                rf_id_con = res_listView.GetString("rf_id_con")
            Else
                rf_id_con = ""
            End If

            itmx1.SubItems.Add(rf_id_con)
            itmx1.SubItems.Add(res_listView.GetString("name_ord"))
            itmx1.SubItems.Add(res_listView.GetString("name_ord_en"))
            If res_listView.GetString("name_size") <> "0" Then
                size_n = res_listView.GetString("name_size")
            Else
                size_n = ""
            End If
            itmx1.SubItems.Add(size_n)
            itmx1.SubItems.Add(res_listView.GetString("samt"))
            itmx1.SubItems.Add(FormatNumber(res_listView.GetString("sprice"), 2))
            itmx1.SubItems.Add(res_listView.GetString("remark"))
            itmx1.SubItems.Add(res_listView.GetString("order_dis_val"))
            itmx1.SubItems.Add(res_listView.GetString("order_dis_type"))
            itmx1.SubItems.Add(res_listView.GetString("order_dis_sum"))
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
            If res_listView.GetString("status_sd_captain").ToLower = "void" Or res_listView.GetString("status_sd_captain").ToLower = "voidp" Then
                ListView_ListOrder.Items(y).ForeColor = Color.Red
            Else
                ListView_ListOrder.Items(y).BackColor = Color.Green
            End If
            y += 1
        End While

        ReDim array_new(ListView_ListOrder.Items.Count, 2)
        For i As Integer = 0 To ListView_ListOrder.Items.Count - 1
            array_new(i, 0) = ListView_ListOrder.Items(i).SubItems(2).Text
            array_new(i, 1) = ListView_ListOrder.Items(i).SubItems(3).Text
            array_new(i, 2) = ListView_ListOrder.Items(i).SubItems(7).Text
        Next
        Loadchk = True
        calsum()
        res_listView.Close()
    End Sub
    Private Sub btn_sendOrderHome_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If ListView_ListOrder.Items.Count > 0 Then
            Dim result As Integer
            If Login.LangG = "TH" Then
                result = MessageBox.Show("คุณมั่นใจใช่ไหมที่จะส่งรายการสินค้าให้ห้องครัวที่รับผิดชอบ?", "ข้อความแจ้งการทำงาน", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            Else
                result = MessageBox.Show("Are You Sure Send Captain order?", "Confirm Send Captain order", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            End If
            If result = DialogResult.Yes Then
                Send_Captain()
            End If
        End If
    End Sub
  
    Private Sub TextBox_Prs_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        keyborad_number.text1 = "TextBox_Prs"
        keyborad_number.ShowDialog()
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

    Private Sub Panel5_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel5.Paint
        'Fill Panel with gradient colors Red and Blue
        Dim rect As New System.Drawing.Rectangle(0, 0, Panel5.Width, Panel5.Height)
        Dim g As Graphics = e.Graphics
        Dim gradientBrush As New LinearGradientBrush(New Point(0, Panel5.Height), New Point(0, 0), System.Drawing.ColorTranslator.FromHtml("#BBBDBF"), Color.White)
        g.FillRectangle(gradientBrush, rect)
        gradientBrush.Dispose()
    End Sub
    Private Sub PictureBox1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PictureBox1.Paint, PictureBox2.Paint
        Dim rect As New System.Drawing.Rectangle(0, 0, PictureBox1.Width, PictureBox1.Height)
        Dim g As Graphics = e.Graphics
        Dim gradientBrush As New LinearGradientBrush(New Point(0, 0), New Point(PictureBox1.Width, 0), System.Drawing.ColorTranslator.FromHtml("#082C79"), ColorTranslator.FromHtml("#041830"))
        g.FillRectangle(gradientBrush, rect)
        gradientBrush.Dispose()
    End Sub
    Private Sub TextBox1_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        opentable_prdother.ShowDialog()
    End Sub
    Private Sub btn_viewall_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_viewall.Click
        opentable_viewlistall.Pr_Page = "opentable"
        opentable_viewlistall.ShowDialog()
    End Sub
    Private Sub ListView_ListOrder_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView_ListOrder.SelectedIndexChanged
        If ListView_ListOrder.SelectedIndices.Count() > 0 Then
            If ListView_ListOrder.Items(ListView_ListOrder.SelectedIndices(0)).SubItems(1).Text().ToLower <> "yes".ToLower Then
                btn_add_other.Enabled = True
            Else
                btn_add_other.Enabled = False
            End If
        End If
    End Sub
    Private Sub btn_pay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_pay.Click
        If CDbl(TextBox_Summary.Text) > 0.0 Then
            index.Gohome = True
            Dim itmx1 As New ListViewItem
            Dim v As Integer = 1
            Dim vats As Double = 0
            Dim price_new As Double = 0
            If ListView_ListOrder.Items.Count > 0 Then
                payment_gohome.ListView1.Items.Clear()
                For i As Integer = 0 To ListView_ListOrder.Items.Count - 1
                    If ListView_ListOrder.Items(i).SubItems(1).Text.ToLower <> "void" Or ListView_ListOrder.Items(i).SubItems(1).Text.ToLower <> "voidp" Then
                       

                        Dim price_new1 As Double = 0.0
                        Dim str_vat As String = ""
                        Dim id_prd As String = ListView_ListOrder.Items(i).SubItems(2).Text()
                        Dim sprice As Double = CDbl(ListView_ListOrder.Items(i).SubItems(8).Text())
                        Dim samt As Integer = CInt(ListView_ListOrder.Items(i).SubItems(7).Text())
                        Dim sord_vat_st As Integer = CInt(ListView_ListOrder.Items(i).SubItems(20).Text())
                        Dim sord_vat As Integer = CInt(ListView_ListOrder.Items(i).SubItems(19).Text())
                        If id_prd = "0" Then
                            vats = 0
                            Dim pprice As Double = CDbl(sprice / samt)
                            price_new = CDbl(sprice / samt)
                            If sord_vat_st = 0 Then
                                str_vat = "None(vat)"
                                vats = 0
                                price_new1 = FormatNumber(pprice * samt, 2)
                            ElseIf sord_vat_st = 1 Then
                                str_vat = "Inc(vat)"
                                vats = pprice - ((pprice * 100) / (sord_vat + 100))
                                price_new1 = FormatNumber((price_new - vats) * samt, 2)
                            ElseIf sord_vat_st = 2 Then
                                str_vat = "Add(vat)"
                                vats = pprice * (sord_vat / 100)
                                price_new1 = FormatNumber(price_new * samt, 2)
                            End If
                        Else
                            vats = home1.vat_prd_cal(ListView_ListOrder.Items(i).SubItems(2).Text, CDbl(ListView_ListOrder.Items(i).SubItems(8).Text() / ListView_ListOrder.Items(i).SubItems(7).Text()))
                            price_new = CDbl(ListView_ListOrder.Items(i).SubItems(8).Text() / ListView_ListOrder.Items(i).SubItems(7).Text())
                            ' หา vat / status 
                            If home1.vat_in_ex(ListView_ListOrder.Items(i).SubItems(2).Text()) = "0" Then
                                str_vat = "None(vat)"
                                price_new1 = FormatNumber(price_new * CInt(ListView_ListOrder.Items(i).SubItems(7).Text), 2)
                            ElseIf home1.vat_in_ex(ListView_ListOrder.Items(i).SubItems(2).Text()) = "1" Then
                                str_vat = "Inc(vat)"
                                price_new1 = FormatNumber((price_new - vats) * CInt(ListView_ListOrder.Items(i).SubItems(7).Text), 2)
                            ElseIf home1.vat_in_ex(ListView_ListOrder.Items(i).SubItems(2).Text()) = "2" Then
                                str_vat = "Add(vat)"
                                price_new1 = FormatNumber(price_new * CInt(ListView_ListOrder.Items(i).SubItems(7).Text), 2)
                            End If
                        End If
                        itmx1 = payment_gohome.ListView1.Items.Add(ListView_ListOrder.Items(i).SubItems(1).Text(), v)
                        itmx1.SubItems.Add(ListView_ListOrder.Items(i).SubItems(0).Text())
                        itmx1.SubItems.Add(ListView_ListOrder.Items(i).SubItems(2).Text())
                        itmx1.SubItems.Add(ListView_ListOrder.Items(i).SubItems(3).Text())
                        itmx1.SubItems.Add(ListView_ListOrder.Items(i).SubItems(4).Text())
                        itmx1.SubItems.Add(ListView_ListOrder.Items(i).SubItems(5).Text())
                        itmx1.SubItems.Add(ListView_ListOrder.Items(i).SubItems(6).Text())
                        If id_prd = "0" Then
                            itmx1.SubItems.Add(str_vat & " " & ListView_ListOrder.Items(i).SubItems(19).Text() & "%")
                        Else
                            itmx1.SubItems.Add(str_vat & " " & home1.vat_prd(ListView_ListOrder.Items(i).SubItems(2).Text()) & "%")
                        End If
                        itmx1.SubItems.Add(ListView_ListOrder.Items(i).SubItems(7).Text())
                        itmx1.SubItems.Add(price_new1)
                        itmx1.SubItems.Add(FormatNumber(vats * CInt(ListView_ListOrder.Items(i).SubItems(7).Text), 2))
                        itmx1.SubItems.Add(FormatNumber(CDbl(price_new1 + (vats * CInt(ListView_ListOrder.Items(i).SubItems(7).Text))), 2))
                        If index.Add_order = True Then
                            itmx1.SubItems.Add(ListView_ListOrder.Items(i).SubItems(10).Text())
                            itmx1.SubItems.Add(ListView_ListOrder.Items(i).SubItems(12).Text())
                            itmx1.SubItems.Add(ListView_ListOrder.Items(i).SubItems(11).Text())
                        Else
                            itmx1.SubItems.Add("0.0")
                            itmx1.SubItems.Add("0")
                            itmx1.SubItems.Add("0")
                        End If
                        itmx1.SubItems.Add(FormatNumber(CDbl(price_new1 + (vats * CInt(ListView_ListOrder.Items(i).SubItems(7).Text))), 2))
                        itmx1.SubItems.Add(ListView_ListOrder.Items(i).SubItems(9).Text())
                        itmx1.SubItems.Add(ListView_ListOrder.Items(i).SubItems(13).Text())
                        itmx1.SubItems.Add(ListView_ListOrder.Items(i).SubItems(14).Text())
                        itmx1.SubItems.Add(ListView_ListOrder.Items(i).SubItems(15).Text())
                        itmx1.SubItems.Add(ListView_ListOrder.Items(i).SubItems(16).Text())
                        itmx1.SubItems.Add(ListView_ListOrder.Items(i).SubItems(17).Text())
                        itmx1.SubItems.Add(ListView_ListOrder.Items(i).SubItems(18).Text())
                        itmx1.SubItems.Add(ListView_ListOrder.Items(i).SubItems(19).Text())
                        itmx1.SubItems.Add(ListView_ListOrder.Items(i).SubItems(20).Text())
                        itmx1.SubItems.Add("0")
                        itmx1.SubItems.Add("0")
                        itmx1.SubItems.Add("0")
                        v += 1
                    End If
                Next
                ' MsgBox(Code_GohomeEdit)
                '=======Check ว่ามี invoice หรือยัง และหลังจากนั้น เอาข้อมูลของ invoice นั้นๆขึ้นมา เพื่อส่งค่าไปหน้า payment_gohome ในช่อง ส่วนลดทั้งบิล หรือ อื่นๆ ====='
                Dim ck_dt_numnberinv As Integer = con.mysql_num_rows(con.mysql_query("select IFNULL(pos_invoice_temp.discount_des,'0') as discount_des,IFNULL(pos_invoice_temp.discount,'0') as discount,pos_order_list.rf_id_invoice as rf_id_invoice, pos_invoice_temp.namber_inv as namber_inv,pos_order_list.code_gohome as code_gohome from pos_order_list  INNER JOIN  pos_invoice_temp ON  pos_invoice_temp.id = pos_order_list.rf_id_invoice  where pos_order_list.code_gohome='" & Code_GohomeEdit & "' order by pos_order_list.id_ord asc"))
                Dim id_inv_temp As String = ""
                If ck_dt_numnberinv > 0 Then
                    Dim dt_numberinv As MySqlDataReader = con.mysql_query("select IFNULL(pos_invoice_temp.discount_des,'0') as discount_des,IFNULL(pos_invoice_temp.discount,'0') as discount,pos_order_list.rf_id_invoice as rf_id_invoice, pos_invoice_temp.namber_inv as namber_inv,pos_order_list.code_gohome as code_gohome from pos_order_list  INNER JOIN  pos_invoice_temp ON  pos_invoice_temp.id = pos_order_list.rf_id_invoice  where pos_order_list.code_gohome='" & Code_GohomeEdit & "' order by pos_order_list.id_ord asc;")
                    While dt_numberinv.Read
                        id_inv_temp = dt_numberinv.GetString("rf_id_invoice")
                        payment_gohome.number_invoice_new = dt_numberinv.GetString("namber_inv")
                        payment_gohome.Label_ShowAllDisType.Text = "(" & dt_numberinv.GetString("discount_des") & ")"
                        payment_gohome.Label_ShowAllDisType.Tag = dt_numberinv.GetString("discount_des")
                        payment_gohome.txt_dis_all.Text = dt_numberinv.GetString("discount")
                    End While
                    dt_numberinv.Close()
                    payment_gohome.code_gohome = Code_GohomeEdit
                Else
                    payment_gohome.number_invoice_new = ""
                    payment_gohome.code_gohome = "0"
                End If

                If payment_gohome.code_gohome <> "" And payment_gohome.code_gohome <> "0" Then
                    '===== update สินค้าที่เพิ่มมาใหม่และยังไม่ส่งให้ห้องครัวพิมพ์ ============'
                    Dim StringQty As String = ""
                    For j As Integer = 0 To ListView_ListOrder.Items.Count - 1
                        If ListView_ListOrder.Items(j).SubItems(1).Text = "no" Then
                            Dim rf_id_prd As Integer = ListView_ListOrder.Items(j).SubItems(2).Text
                            Dim rf_id_con As String = ListView_ListOrder.Items(j).SubItems(3).Text
                            Dim name_ord As String = ListView_ListOrder.Items(j).SubItems(4).Text.Replace("'", "\'")
                            Dim name_ord_en As String = ListView_ListOrder.Items(j).SubItems(5).Text.Replace("'", "\'")
                            Dim amt As Integer = CInt(ListView_ListOrder.Items(j).SubItems(7).Text)
                            Dim price As Double = CDbl(ListView_ListOrder.Items(j).SubItems(8).Text)
                            Dim remark As String = ListView_ListOrder.Items(j).SubItems(9).Text.Replace("'", "\'")
                            Dim id_cat As String = ListView_ListOrder.Items(j).SubItems(13).Text.Trim
                            Dim id_subcatprd As String = ListView_ListOrder.Items(j).SubItems(14).Text.Trim
                            Dim name_cat As String = ListView_ListOrder.Items(j).SubItems(16).Text.Trim
                            Dim name_subcat As String = ListView_ListOrder.Items(j).SubItems(18).Text.Trim
                            Dim ord_vat As Integer = ListView_ListOrder.Items(j).SubItems(19).Text.Trim
                            Dim ord_vat_st As String = ListView_ListOrder.Items(j).SubItems(20).Text.Trim
                            Dim prd_t_id As String = ListView_ListOrder.Items(j).SubItems(21).Text.Trim
                            Dim prd_t_en As String = ListView_ListOrder.Items(j).SubItems(22).Text.Trim
                            Dim prd_t_th As String = ListView_ListOrder.Items(j).SubItems(23).Text.Trim
                            StringQty &= "INSERT INTO pos_order_list (rf_id_prd,rf_id_con,name_ord,name_ord_en,amt,price,prs," _
                            & "rf_id_table,rf_id_invoice,status_sd_captain,status_open,remark,create_date,create_by,code_gohome,ref_cat_id," _
                            & "ref_catsubprd,name_th_cat,name_en_cat,name_th_catsubprd,name_en_catsubprd,ord_vat,ord_vat_st,prd_type_dis_id,prd_type_dis_en,prd_type_dis_th) " _
                            & " VALUES('" & rf_id_prd & "','" & rf_id_con & "','" & name_ord & "','" & name_ord_en & "','" & amt & "','" & price & "'," _
                            & "'1','0','" & id_inv_temp & "','no','gohome','" & remark & "','" & Login.DateData.ToString("yyyy-MM-dd") & Date.Now.ToString(" HH:mm:ss") & "','" & Login.username & "'," _
                            & "'" & payment_gohome.code_gohome & "','" & id_cat & "','" & id_subcatprd & "','" & name_cat & "'," _
                            & "'" & name_cat & "','" & name_subcat & "','" & name_subcat & "','" & ord_vat & "','" & ord_vat_st & "','" & prd_t_id & "','" & prd_t_en & "','" & prd_t_th & "');"
                            cutStock(rf_id_prd, rf_id_con, amt) ' ==== ตัดสต๊อกสินค้า ===='
                        End If
                    Next
                    MsgBox(StringQty) '--ใส่ไว้แก้บั๊คเด้ง ห้ามเอาออก
                    If StringQty <> "" Then
                        con.mysql_query(StringQty)
                    End If
                End If
                '=====Show Form payment_gohome ====='
                payment_gohome.page = "opentakehome"
                payment_gohome.MdiParent = index
                payment_gohome.Show()
                'payment_gohome.WindowState = FormWindowState.Minimized
                'payment_gohome.WindowState = FormWindowState.Maximized
                ' payment_gohome.Label_Num_Pay.Text = "Gohome Code : " & payment_gohome.code_gohome
                'payment_gohome.Btn_Enter.Enabled = True
                payment_gohome.cal_list_price()
                SendOrder1 = "0"
            End If
            index.CloseForm()
            Login.Formname = "payment_gohome"
            Me.Close()
        End If
    End Sub
    Private Sub TextBox_Barcode_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox_Barcode.Enter
        If TextBox_Barcode.Text <> "" Then
            Dim Id_product As String = ""
            Dim num As Integer = con.mysql_num_rows(con.mysql_query("SELECT * FROM pos_product WHERE number_prd='" & TextBox_Barcode.Text & "'"))
            If num > 0 Then
                Dim qty_prd As MySqlDataReader = con.mysql_query("SELECT * FROM pos_product WHERE number_prd='" & TextBox_Barcode.Text & "' LIMIT 1")
                qty_prd.Read()
                Id_product = qty_prd.GetString("id")
                'add To array for check send captain order

                opentable_addnumprd1.txt_numprd.Text = 1
                Dim StrSQL As String = ""
                StrSQL += "select *,pos_product.id AS id_prd,pos_product_condition.id AS id_con,"
                StrSQL += "IFNULL(pos_product_condition.ref_id_ingredients,'0')  AS indre,pos_product_condition.ref_id_size AS ref_id_size "
                StrSQL += ",pos_product_condition.price_condition AS price_condition from pos_product  LEFT JOIN  pos_product_condition "
                StrSQL += " ON pos_product.id=pos_product_condition.ref_id_prd"
                StrSQL += " where pos_product.number_prd='" & TextBox_Barcode.Text & "' "

                Dim res_order As MySqlDataReader = con.mysql_query(StrSQL)
                Dim itmx As New ListViewItem
                Dim y As Integer = 0
                Dim StrSize As String
                Dim Name_N As String
                Dim price_N As Double
                Dim id_prd_n As String
                Dim id_con_n As String
                Dim bo As Boolean = False

                For j As Integer = ListView_ListOrder.Items.Count - 1 To 0 Step -1
                    If ListView_ListOrder.Items(j).SubItems(1).Text = "no" Then
                        id_prd_n = ListView_ListOrder.Items(j).SubItems(2).Text()
                        id_con_n = ListView_ListOrder.Items(j).SubItems(3).Text()
                        If (id_prd_n = Id_product And id_con_n = "") Then
                            ListView_ListOrder.Items(j).SubItems(8).Text = FormatNumber((CDbl(ListView_ListOrder.Items(j).SubItems(8).Text) / CDbl(ListView_ListOrder.Items(j).SubItems(7).Text)) * ((CDbl(ListView_ListOrder.Items(j).SubItems(7).Text) + CDbl(opentable_addnumprd1.txt_numprd.Text))), 2)
                            ListView_ListOrder.Items(j).SubItems(7).Text = CInt(ListView_ListOrder.Items(j).SubItems(7).Text) + CInt(opentable_addnumprd1.txt_numprd.Text)
                            bo = True
                            Exit For
                        End If
                    Else
                        bo = False
                        Exit For
                    End If
                Next

                If bo = False Then
                    While res_order.Read()
                        itmx = ListView_ListOrder.Items.Add("0", y)
                        itmx.SubItems.Add("no")
                        itmx.SubItems.Add(res_order.GetString("id_prd"))
                        StrSize = ""
                        If res_order.GetString("nameprd_th") <> "" Then
                            Name_N = res_order.GetString("nameprd_th")
                        Else
                            Name_N = res_order.GetString("nameprd_en")
                        End If
                        price_N = res_order.GetString("price")
                        itmx.SubItems.Add("")
                        itmx.SubItems.Add(Name_N)
                        itmx.SubItems.Add(StrSize)
                        itmx.SubItems.Add(opentable_addnumprd1.txt_numprd.Text)
                        itmx.SubItems.Add(FormatNumber((price_N * opentable_addnumprd1.txt_numprd.Text), 2))
                        itmx.SubItems.Add("")
                        y += 1
                    End While
                    res_order.Close()
                End If
                calsum()
                TextBox_Barcode.Text = ""
                TextBox_Barcode.Focus()
            Else
                MsgBox("ไม่มีสินค้านี้ในระบบค่ะ")
                TextBox_Barcode.Focus()
            End If
        Else
            'MsgBox("กรุณากรอกรหัสสินค้าด้วยค่ะ")
        End If
    End Sub
    Private Sub TextBox_Barcode_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox_Barcode.KeyUp
        If e.KeyCode = Keys.Enter Then
            If TextBox_Barcode.Text <> "" Then
                Dim Id_product As String = ""
                Dim num As Integer = con.mysql_num_rows(con.mysql_query("SELECT * FROM pos_product WHERE number_prd='" & TextBox_Barcode.Text & "'"))
                If num > 0 Then
                    Dim qty_prd As MySqlDataReader = con.mysql_query("SELECT * FROM pos_product WHERE number_prd='" & TextBox_Barcode.Text & "' LIMIT 1")
                    qty_prd.Read()
                    Id_product = qty_prd.GetString("id")
                    'add To array for check send captain order
                    opentable_addnumprd1.txt_numprd.Text = 1
                    Dim StrSQL As String = ""
                    StrSQL += "select *,pos_product.id AS id_prd,pos_product_condition.id AS id_con,"
                    StrSQL += "IFNULL(pos_product_condition.ref_id_ingredients,'0')  AS indre,pos_product_condition.ref_id_size AS ref_id_size "
                    StrSQL += ",pos_product_condition.price_condition AS price_condition from pos_product  LEFT JOIN  pos_product_condition "
                    StrSQL += " ON pos_product.id=pos_product_condition.ref_id_prd"
                    StrSQL += " where pos_product.number_prd='" & TextBox_Barcode.Text & "' "

                    Dim res_order As MySqlDataReader = con.mysql_query(StrSQL)
                    Dim itmx As New ListViewItem
                    Dim y As Integer = 0
                    Dim StrSize As String
                    Dim Name_N As String
                    Dim price_N As Double
                    Dim id_prd_n As String
                    Dim id_con_n As String
                    Dim bo As Boolean = False

                    For j As Integer = ListView_ListOrder.Items.Count - 1 To 0 Step -1
                        If ListView_ListOrder.Items(j).SubItems(1).Text = "no" Then
                            id_prd_n = ListView_ListOrder.Items(j).SubItems(2).Text()
                            id_con_n = ListView_ListOrder.Items(j).SubItems(3).Text()
                            If (id_prd_n = Id_product And id_con_n = "") Then
                                ListView_ListOrder.Items(j).SubItems(8).Text = FormatNumber((CDbl(ListView_ListOrder.Items(j).SubItems(8).Text) / CDbl(ListView_ListOrder.Items(j).SubItems(7).Text)) * ((CDbl(ListView_ListOrder.Items(j).SubItems(7).Text) + CDbl(opentable_addnumprd1.txt_numprd.Text))), 2)
                                ListView_ListOrder.Items(j).SubItems(7).Text = CInt(ListView_ListOrder.Items(j).SubItems(7).Text) + CInt(opentable_addnumprd1.txt_numprd.Text)
                                bo = True
                                Exit For
                            End If
                        Else
                            bo = False
                            Exit For
                        End If
                    Next

                    If bo = False Then
                        While res_order.Read()
                            itmx = ListView_ListOrder.Items.Add("0", y)
                            itmx.SubItems.Add("no")
                            itmx.SubItems.Add(res_order.GetString("id_prd"))
                            StrSize = ""
                            If res_order.GetString("nameprd_th") <> "" Then
                                Name_N = res_order.GetString("nameprd_th")
                            Else
                                Name_N = res_order.GetString("nameprd_en")
                            End If
                            price_N = res_order.GetString("price")
                            itmx.SubItems.Add("")
                            itmx.SubItems.Add(Name_N)
                            itmx.SubItems.Add(StrSize)
                            itmx.SubItems.Add(opentable_addnumprd1.txt_numprd.Text)
                            itmx.SubItems.Add(FormatNumber((price_N * opentable_addnumprd1.txt_numprd.Text), 2))
                            itmx.SubItems.Add("")
                            y += 1
                        End While
                        res_order.Close()
                    End If
                    calsum()
                    TextBox_Barcode.Text = ""
                    TextBox_Barcode.Focus()
                Else
                    MsgBox("ไม่มีสินค้านี้ในระบบค่ะ")
                    TextBox_Barcode.Focus()
                End If
            Else
                ' MsgBox("กรุณากรอกรหัสสินค้าด้วยค่ะ")

            End If
        End If
    End Sub
    Public Function cutStock(ByVal id_prd, ByVal id_prd_con, ByVal amt)
        Dim tf As Boolean = False
        'Check IS Product Not on Table is = 0
        Dim ck As Integer = con.mysql_num_rows(con.mysql_query("SELECT id_status_table from pos_product where id='" & id_prd & "' and  id_status_table='0' "))
        If ck > 0 Then
            'Check Have in PRD Condition ?
            Dim nu As Integer = con.mysql_num_rows(con.mysql_query("SELECT * FROM pos_product_condition WHERE id='" & id_prd_con & "' and ref_id_prd='" & id_prd & "' and ref_id_ingredients='0' and ref_id_unit>'0'"))
            If nu > 0 Then
                'UPDATE DATA amount new pos_product_condition
                Dim res_prd_con As MySqlDataReader = con.mysql_query("SELECT * FROM pos_product_condition WHERE id='" & id_prd_con & "' and ref_id_prd='" & id_prd & "' and ref_id_ingredients='0' and ref_id_unit>'0'")
                res_prd_con.Read()
                con.mysql_query("UPDATE pos_product_condition SET amount='" & CInt(res_prd_con.GetString("amount")) - CInt(amt) & "' WHERE id='" & id_prd_con & "' and ref_id_prd='" & id_prd & "' and ref_id_ingredients='0' and ref_id_unit>'0'")

                '==== check barcode ของตาราง เงื่อไข ว่าตรงกับตาราง inv หรือไม ให้ตัดสต๊อกที่ inv แทน ตาราง เงื่อนไข
                Dim h As Integer = con.mysql_num_rows(con.mysql_query("select * from pos_product_inv where inv_barcode='" & res_prd_con.GetString("barcode") & "'"))
                If h > 0 Then
                    Dim b As MySqlDataReader = con.mysql_query("select * from pos_product_inv where inv_barcode='" & res_prd_con.GetString("barcode") & "'")
                    b.Read()
                    tf = con.mysql_query("UPDATE pos_product_inv SET inv_amount='" & CInt(b.GetString("inv_amount")) - CInt(amt) & "' Where inv_barcode='" & res_prd_con.GetString("barcode") & "';")
                    b.Close()
                End If
                res_prd_con.Close()
            Else
                Dim res_prd1 As MySqlDataReader = con.mysql_query("SELECT * FROM pos_product WHERE id='" & id_prd & "' ")
                res_prd1.Read()
                'UPDATE DATA amount new pos_product
                con.mysql_query("UPDATE pos_product SET amount='" & CInt(res_prd1.GetString("amount")) - CInt(amt) & "' WHERE id='" & id_prd & "' ")
                Dim h As Integer = con.mysql_num_rows(con.mysql_query("select * from pos_product_inv where inv_barcode='" & res_prd1.GetString("number_prd") & "'"))
                If h > 0 Then
                    Dim b As MySqlDataReader = con.mysql_query("select * from pos_product_inv where inv_barcode='" & res_prd1.GetString("number_prd") & "'")
                    b.Read()
                    tf = con.mysql_query("UPDATE pos_product_inv SET inv_amount='" & CInt(b.GetString("inv_amount")) - CInt(amt) & "' Where inv_barcode='" & res_prd1.GetString("number_prd") & "';")
                    b.Close()
                End If
                res_prd1.Close()

            End If
            'End Check Have in PRD Condition ?
        End If
        Return tf
    End Function
    Public Function returnStock(ByVal id_prd, ByVal id_prd_con, ByVal amt)
        Dim tf As Boolean = False
        'Check IS Product Not on Table is = 0
        Dim ck As Integer = con.mysql_num_rows(con.mysql_query("SELECT id_status_table from pos_product where id='" & id_prd & "' and  id_status_table='0' "))
        If ck > 0 Then
            'Check Have in PRD Condition ?
            Dim nu As Integer = con.mysql_num_rows(con.mysql_query("SELECT * FROM pos_product_condition WHERE id='" & id_prd_con & "' and ref_id_prd='" & id_prd & "' and ref_id_ingredients='0' and ref_id_unit>'0'"))
            If nu > 0 Then
                Dim res_prd_con As MySqlDataReader = con.mysql_query("SELECT * FROM pos_product_condition WHERE id='" & id_prd_con & "' and ref_id_prd='" & id_prd & "' and ref_id_ingredients='0' and ref_id_unit>'0'")
                res_prd_con.Read()
                'UPDATE DATA amount new pos_product_condition
                con.mysql_query("UPDATE pos_product_condition SET amount='" & CInt(res_prd_con.GetString("amount")) + CInt(amt) & "' WHERE id='" & id_prd_con & "' and ref_id_prd='" & id_prd & "'")

                '==== check barcode ของตาราง เงื่อไข ว่าตรงกับตาราง inv หรือไม ให้ตัดสต๊อกที่ inv แทน ตาราง เงื่อนไข
                Dim h As Integer = con.mysql_num_rows(con.mysql_query("select * from pos_product_inv where inv_barcode='" & res_prd_con.GetString("barcode") & "'"))
                If h > 0 Then
                    Dim b As MySqlDataReader = con.mysql_query("select * from pos_product_inv where inv_barcode='" & res_prd_con.GetString("barcode") & "'")
                    b.Read()
                    tf = con.mysql_query("UPDATE pos_product_inv SET inv_amount='" & CInt(b.GetString("inv_amount")) + CInt(amt) & "' Where inv_barcode='" & res_prd_con.GetString("barcode") & "';")
                    b.Close()
                End If
                res_prd_con.Close()
            Else
                Dim num As Integer = 0
                Dim res_prd1 As MySqlDataReader = con.mysql_query("SELECT * FROM pos_product WHERE id='" & id_prd & "' order by id desc limit 1")
                res_prd1.Read()
                'UPDATE DATA amount new pos_product
                con.mysql_query("UPDATE pos_product SET amount='" & CInt(res_prd1.GetString("amount")) + CInt(amt) & "' WHERE id='" & id_prd & "' ")
                Dim h As Integer = con.mysql_num_rows(con.mysql_query("select * from pos_product_inv where inv_barcode='" & res_prd1.GetString("number_prd") & "'"))
                If h > 0 Then
                    Dim b As MySqlDataReader = con.mysql_query("select * from pos_product_inv where inv_barcode='" & res_prd1.GetString("number_prd") & "'")
                    b.Read()
                    tf = con.mysql_query("UPDATE pos_product_inv SET inv_amount='" & CInt(b.GetString("inv_amount")) + CInt(amt) & "' Where inv_barcode='" & res_prd1.GetString("number_prd") & "';")
                    b.Close()
                End If
                res_prd1.Close()
            End If
            'End Check Have in PRD Condition ?
        End If
        Return tf
    End Function
    Private Sub TextBox_Barcode_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox_Barcode.Leave
        ' TextBox_Barcode.Focus()
    End Sub
    Private Sub btn_add_other_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_add_other.Click
        opentable_add_other.ShowDialog()
    End Sub
    Private Sub btn_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_save.Click
        If ListView_ListOrder.Items.Count > 0 Then
            If MessageBox.Show("คุณมั่นใจใช่ไหมที่จะบันทึกรายการนี้?", "Alert Comfirm Save Order?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim str As String = ""
                Dim id_inv_temp As String = ""
                Dim CodeGoHome As String = ""
                If Code_GohomeEdit = "" Or Code_GohomeEdit = "0" Then
                    CodeGoHome = Create_Code_Gohome()
                Else
                    CodeGoHome = Code_GohomeEdit
                End If
                '==== insert bill invoice ===='
                If Code_GohomeEdit = "" Or Code_GohomeEdit = "0" Then
                    Dim qty_all As Integer = 0
                    Dim price_all As Double = 0.0
                    For x As Integer = 0 To ListView_ListOrder.Items.Count - 1
                        If ListView_ListOrder.Items(x).SubItems(1).Text.ToLower = "no" Then
                            qty_all += ListView_ListOrder.Items(x).SubItems(7).Text
                            price_all += CDbl(ListView_ListOrder.Items(x).SubItems(8).Text)
                        End If
                    Next
                    Dim id_insert As String = ac.RuningInvTEMP()

                    con.mysql_query("INSERT INTO pos_invoice_temp (namber_inv,number_pos,qty,price_all," _
                            & "create_by,create_date,rf_payment_type,des_payment,machin_number,price_exclu_vat," _
                            & "vat,serviceCh,discount,discount_des,discount_sum,ref_id_payment_acc,machine_inv," _
                            & "rf_id_card,money_recript,money_ton,close_rop_id_inv,close_rop_name_inv) values(" _
                            & "'" & id_insert & "','" & ac.RuningPOSTEMP() & "','" & qty_all & "','" & price_all & "'," _
                            & "'" & Login.username & "','" & Login.DateData.ToString("yyyy-MM-dd") & Date.Now.ToString(" HH:mm:ss") & "','0','-','" & System.Net.Dns.GetHostName() & "','0'," _
                            & "'0','0','0','บาท','0','0','" & Login.getMacAddress & "'," _
                            & "'0','0','0','" & Login.Id_RopBill & "','" & Login.Str_Ropbill & "');")
                    id_inv_temp = payment.GetIdInv_Pos_Invoice_Temp(id_insert)
                Else
                    Dim qty_all As Integer = 0
                    Dim price_all As Double = 0.0
                    For x As Integer = 0 To ListView_ListOrder.Items.Count - 1
                        If ListView_ListOrder.Items(x).SubItems(1).Text.ToLower <> "void" Or ListView_ListOrder.Items(x).SubItems(1).Text.ToLower <> "voidp" Then
                            qty_all += ListView_ListOrder.Items(x).SubItems(7).Text
                            price_all += CDbl(ListView_ListOrder.Items(x).SubItems(8).Text)
                        End If
                    Next
                    Dim g As MySqlDataReader = con.mysql_query("select * from pos_order_list where status_open='gohome' and status_pay='no' and code_gohome='" & CodeGoHome & "' order by id_ord asc;")
                    g.Read()
                    id_inv_temp = g.GetString("rf_id_invoice")
                    str &= "UPDATE pos_invoice_temp SET qty='" & qty_all & "',price_all='" & price_all & "',update_by='" & Login.username & "'" _
                      & " WHERE id='" & id_inv_temp & "';"
                End If
                'Loop get value for insert order list database
                For x As Integer = 0 To ListView_ListOrder.Items.Count - 1
                    If ListView_ListOrder.Items(x).SubItems(1).Text.ToLower = "no" Then
                        Dim rf_id_prd As String = ListView_ListOrder.Items(x).SubItems(2).Text
                        Dim rf_id_con As String = ListView_ListOrder.Items(x).SubItems(3).Text
                        Dim name_ord As String = ListView_ListOrder.Items(x).SubItems(4).Text.Replace("'", "\'")
                        Dim name_ord_en As String = ListView_ListOrder.Items(x).SubItems(5).Text.Replace("'", "\'")
                        Dim amt As Integer = ListView_ListOrder.Items(x).SubItems(7).Text
                        Dim price1 As Double = CDbl(ListView_ListOrder.Items(x).SubItems(8).Text)
                        Dim remark As String = ListView_ListOrder.Items(x).SubItems(9).Text.Replace("'", "\'")
                        Dim id_cat As String = ListView_ListOrder.Items(x).SubItems(13).Text.Trim
                        Dim id_subcatprd As String = ListView_ListOrder.Items(x).SubItems(14).Text.Trim
                        Dim name_cat_en As String = ListView_ListOrder.Items(x).SubItems(15).Text.Trim
                        Dim name_cat_th As String = ListView_ListOrder.Items(x).SubItems(16).Text.Trim
                        Dim name_subcat_en As String = ListView_ListOrder.Items(x).SubItems(17).Text.Trim
                        Dim name_subcat_th As String = ListView_ListOrder.Items(x).SubItems(18).Text.Trim
                        Dim ord_vat As Integer = ListView_ListOrder.Items(x).SubItems(19).Text.Trim
                        Dim ord_vat_st As String = ListView_ListOrder.Items(x).SubItems(20).Text.Trim
                        Dim prd_t_id As Integer = ListView_ListOrder.Items(x).SubItems(21).Text.Trim
                        Dim prd_t_en As String = ListView_ListOrder.Items(x).SubItems(22).Text.Trim
                        Dim prd_t_th As String = ListView_ListOrder.Items(x).SubItems(23).Text.Trim
                        Dim check_is_prd As Integer = con.mysql_num_rows(con.mysql_query("select * from pos_order_list " _
                       & "where rf_id_prd='" & rf_id_prd & "' and rf_id_con='" & rf_id_con & "' and name_ord='" & name_ord & "' and " _
                       & "code_gohome='" & CodeGoHome & "' and status_open='gohome' and status_pay='no';"))
                        If check_is_prd > 0 Then
                            str &= "UPDATE pos_order_list SET amt=amt+" & amt & ",price=price+'" & price1 & "' " _
                            & "where rf_id_prd='" & rf_id_prd & "' and rf_id_con='" & rf_id_con & "' and name_ord='" & name_ord & "' and " _
                            & "code_gohome='" & CodeGoHome & "' and status_open='gohome' and status_pay='no';"
                        Else
                            str &= "INSERT INTO pos_order_list (rf_id_prd,rf_id_con,name_ord,name_ord_en,amt,price,prs," _
                             & "rf_id_table,rf_id_invoice,status_sd_captain,status_open,remark,create_date,create_by,code_gohome,ref_cat_id," _
                             & "ref_catsubprd,name_th_cat,name_en_cat,name_th_catsubprd,name_en_catsubprd,ord_vat,ord_vat_st,prd_type_dis_id,prd_type_dis_en,prd_type_dis_th) " _
                             & " VALUES('" & rf_id_prd & "','" & rf_id_con & "','" & name_ord & "','" & name_ord_en & "','" & amt & "','" & price1 & "'," _
                             & "'1','0','" & id_inv_temp & "','no','gohome','" & remark & "','" & Login.DateData.ToString("yyyy-MM-dd") & Date.Now.ToString(" HH:mm:ss") & "','" & Login.username & "'," _
                             & "'" & CodeGoHome & "','" & id_cat & "','" & id_subcatprd & "','" & name_cat_en & "'," _
                             & "'" & name_cat_th & "','" & name_subcat_en & "','" & name_subcat_th & "','" & ord_vat & "','" & ord_vat_st & "','" & prd_t_id & "','" & prd_t_en & "','" & prd_t_th & "');"
                        End If
                        cutStock(rf_id_prd, rf_id_con, amt) 'ตัดสินค้าออกจากสต๊อก ในกรณีที่ขาายของminimart 
                    End If
                Next
                payment_gohome.Code_GohomeEdit = CodeGoHome
                Dim q_order As Boolean = False
                If str <> "" Then
                    q_order = con.mysql_query(str)
                End If

                If q_order = True Then
                    MsgBox("บันทึกเรียบร้อย", MsgBoxStyle.Information, "แจ้งบันทึกรายการสินค้า")
                    Me.Close()
                    index.Add_order = False
                    Confirm_sendOrder = False
                    
                    gohome_list.MdiParent = index
                    gohome_list.Show()
                    gohome_list.WindowState = FormWindowState.Minimized
                    gohome_list.WindowState = FormWindowState.Maximized
                    ' If (gohome_list.Visible = True) Then
                    'd If
                    'MsgBox(Login.Formname)
                    Login.Formname = "gohome_list"

                End If
            End If
        End If
    End Sub
End Class