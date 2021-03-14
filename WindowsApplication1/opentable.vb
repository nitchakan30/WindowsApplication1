Imports MySql.Data.MySqlClient
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Text
Imports System.Threading

Public Class opentable
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
    Public Code_GohomeEdit As String = ""  'code ที่จะนำมาแก้ไขหรือเพิ่มรายการอาหารใหม่
    Dim Frist_SubGroup As String = ""
    Dim year As Integer = 0
    Public ID_TB_JOIN_OLD As String = ""
    Dim getHight As Double = 0
    Private Sub opentable_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub opentable_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            index.CloseForm()
            home1.Change_Tb = False
            index.Gohome = False
            index.ReservationP = False
            index.Add_order = False
            index.ishomeopen = True
            home1.MdiParent = index
            home1.Show()
            home1.WindowState = FormWindowState.Minimized
            home1.WindowState = FormWindowState.Maximized
            Login.OpenId = ""
            opentakehome.SendOrder1 = "0"
            Login.Formname = "home1"
            clearData()
        End If
    End Sub
    Private Sub opentable_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DoubleBuffered = True
        tabs_group()
        getHight = Math.Floor(FlowLayout_subGroup.Height / 44)
        Load_numPageAll()
        ShowSub_GroupF(0, 7)
        Label_tb_select.Text = "Table No. " & index.getNameTable(Login.OpenId) & " Option "
        Switch_lang()
        If sizeWFood > 0 Then
            FlowLayout_food.Controls.Clear()
            Show_FoodLoadF(0)
        Else
            FlowLayout_food.Controls.Clear()
        End If

        If index.Add_order = True Then
            If ListView_ListOrder.Items.Count > 0 Then
                ListView_ListOrder.Items.Clear()
            End If
            btnopen.Enabled = False
            If Login.LangG = "EN" Then
                ListView_ListOrder.Columns.Item(4).Width = "0"
                ListView_ListOrder.Columns.Item(5).Width = "100"
            Else
                ListView_ListOrder.Columns.Item(4).Width = "100"
                ListView_ListOrder.Columns.Item(5).Width = "0"
            End If
            Load_Product_list()

        Else
            btnopen.Enabled = True
            If ListView_ListOrder.Items.Count > 0 Then
                ListView_ListOrder.Items.Clear()
            End If
            If Login.LangG = "EN" Then
                ListView_ListOrder.Columns.Item(4).Width = "0"
                ListView_ListOrder.Columns.Item(5).Width = "100"
            Else
                ListView_ListOrder.Columns.Item(4).Width = "100"
                ListView_ListOrder.Columns.Item(5).Width = "0"
            End If
        End If

    End Sub
    Private Sub Switch_lang()
        If Login.LangG = "EN" Then
            btn_sendorder.Text = "Send Captain"
            btn_back_menu.Text = "Back"
            btnopen.Text = "Save"
            Label_room.Text = "Room :"
            Label4.Text = "Recom."
            Label_adult.Text = ""
            Label3.Text = "Product All"
            btn_add_other.Text = "Add Other Order"
            Label_adult.Text = "Adult : "
            Label_child.Text = "Child : "
            Label_cover.Text = "Cover : "

            ListView_ListOrder.Columns(4).Text = "Name"
            ListView_ListOrder.Columns(6).Text = "Size"
            ListView_ListOrder.Columns(7).Text = "Qty"
            ListView_ListOrder.Columns(8).Text = "Price"
            ListView_ListOrder.Columns(9).Text = "Recomment"
            ListView_ListOrder.Columns(4).Width = 0
            ListView_ListOrder.Columns(5).Width = 100

        Else
            btn_sendorder.Text = "ส่งรายการให้ห้องครัว"
            btn_back_menu.Text = "ย้อนกลับ"
            btnopen.Text = "บันทึก"
            Label4.Text = "เพิ่มเติม"
            Label_adult.Text = "คน"
            Label3.Text = "รายการสินค้าทั้งหมด"
            btn_add_other.Text = "เพิ่มรายการใหม่"
            Label_adult.Text = "ผู้ใหญ่ : "
            Label_child.Text = "เด็ก : "
            Label_cover.Text = "รวม :"
            Label_room.Text = "ห้องที่ :"

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
        index.CloseForm()
        home1.Change_Tb = False
        index.Gohome = False
        index.ReservationP = False
        index.Add_order = False
        'openCloseMenu(home1)
        index.ishomeopen = True
        home1.MdiParent = index
        home1.Show()
        home1.WindowState = FormWindowState.Minimized
        home1.WindowState = FormWindowState.Maximized
        Login.OpenId = ""
        opentakehome.SendOrder1 = "0"
        Login.Formname = "home1"
        clearData()
    End Sub
    Public Sub tabs_group()
        Dim Str As String
        Dim FlowLaout As New FlowLayoutPanel
        FlowLaout.Name = "tabs_group"
        FlowLaout.FlowDirection = FlowDirection.LeftToRight
        FlowLaout.Dock = DockStyle.Fill
        Panel_TabH.Controls.Add(FlowLaout)
        FlowLaout.Controls.Clear()
        Dim i As Integer = 1
        Dim n As Integer = 0
        n = con.mysql_num_rows(con.mysql_query("select pos_catprd.id AS id,pos_catprd.namecat_en AS namecat_en,pos_catprd.namecat_th AS namecat_th from (pos_catprd INNER JOIN pos_location_join_cat ON pos_catprd.id=pos_location_join_cat.id_catprd) INNER JOIN pos_table_system ON pos_location_join_cat.id_location=pos_table_system.ref_id_location WHERE pos_catprd.id_status_sales='1' AND pos_table_system.id='" & Login.OpenId & "' GROUP BY pos_catprd.id order by id asc"))
        If n > 0 Then
            Login.DataGropPrd = con.mysql_query("select pos_catprd.id AS id,pos_catprd.namecat_en AS namecat_en,pos_catprd.namecat_th AS namecat_th from (pos_catprd INNER JOIN pos_location_join_cat ON pos_catprd.id=pos_location_join_cat.id_catprd) INNER JOIN pos_table_system ON pos_location_join_cat.id_location=pos_table_system.ref_id_location WHERE pos_catprd.id_status_sales='1' AND pos_table_system.id='" & Login.OpenId & "' GROUP BY pos_catprd.id order by id asc")
            While Login.DataGropPrd.Read()
                Dim Button_head = New Button
                If i = 1 Then
                    GroupId = Login.DataGropPrd.GetString("id")
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
                Button_head.Width = 40
                Button_head.BackColor = Color.Aqua
                Button_head.ForeColor = Color.White
                Button_head.Font = New Font(Button_head.Font.FontFamily, 12, FontStyle.Bold)

                If Login.LangG = "EN" Then
                    Str = Login.DataGropPrd.GetString("namecat_en")
                Else
                    Str = Login.DataGropPrd.GetString("namecat_th")
                End If
                Button_head.Tag = Login.DataGropPrd.GetString("id")
                Button_head.Text = Str
                Button_head.TextAlign = ContentAlignment.MiddleCenter
                AddHandler Button_head.Click, AddressOf Group_Click
                FlowLaout.Controls.Add(Button_head)
                i += 1
            End While
            Login.DataGropPrd.Close()
        End If
    End Sub
    Public Function CheckZone_IdSubGroup()
        Dim id_lo As String = "0"
        Dim id As String = "0"
        Dim n As Integer = con.mysql_num_rows(con.mysql_query("select ref_id_location as ref_id_location from pos_table_system where id='" & Login.OpenId & "'"))
        If n > 0 Then
            Dim getLocation As MySqlDataReader = con.mysql_query("select ref_id_location as ref_id_location from pos_table_system where id='" & Login.OpenId & "'")
            getLocation.Read()
            id_lo = getLocation.GetString("ref_id_location")
            getLocation.Close()
            Dim k As Integer = con.mysql_num_rows(con.mysql_query("select * from pos_location_join_cat where id_location='" & id_lo & "' order by id_catprd asc limit 1; "))
            If k > 0 Then
                Dim id_cat As MySqlDataReader = con.mysql_query("select * from pos_location_join_cat where id_location='" & id_lo & "' order by id_catprd asc limit 1; ")
                id_cat.Read()
                id = id_cat.GetString("id_catprd")
                id_cat.Close()
            Else
                id = "0"
            End If
        End If
        Return id
    End Function
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
    Public Sub Group_Click(ByVal sender As Object, ByVal e As System.EventArgs)
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
            Else
                AddHandler Panel_TabH.Controls.Item(tl).Controls.Item(i).Paint, AddressOf TabsBlue_Paint
                Panel_TabH.Controls.Item(tl).Controls.Item(i).Focus()
            End If
        Next
    End Sub


    Private Sub opentable_ResizeEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ResizeEnd
        Dim tl As Integer
        tl = Panel_TabH.Controls.IndexOfKey("tabs_group")

        For i As Integer = 0 To Panel_TabH.Controls.Item(tl).Controls.Count - 1
            Panel_TabH.Controls.Item(tl).Controls.Item(i).Width = Panel_TabH.Width / Panel_TabH.Controls.Item(tl).Controls.Count
        Next
        '  ShowSub_Group(0, 7)
    End Sub

    Private Sub opentable_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        Try
            'resize Group
            Dim tl As Integer
            tl = Panel_TabH.Controls.IndexOfKey("tabs_group")
            If Panel_TabH.Controls.Item(tl).Controls.Count > 0 Then
                For i As Integer = 0 To Panel_TabH.Controls.Item(tl).Controls.Count - 1
                    Panel_TabH.Controls.Item(tl).Controls.Item(i).Width = (Panel_TabH.Width / Panel_TabH.Controls.Item(tl).Controls.Count) - 9
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
        'ค่าเดิมที่เรียกใช้งาน Login.IdG
        Dim n As Integer = 0
        n = con.mysql_num_rows(con.mysql_query("select * from pos_catsubprd  Where ref_id_cat='" & CheckZone_IdSubGroup() & "' and id_status_sales='1' order by id asc LIMIT 0," & getHight & ""))
        If n > 0 Then
            Login.DataSubGropPrd = con.mysql_query("select * from pos_catsubprd  Where ref_id_cat='" & CheckZone_IdSubGroup() & "' and id_status_sales='1' order by id asc LIMIT 0," & getHight & "")
            While Login.DataSubGropPrd.Read()
                Dim Button_subGroup = New Button
                If i = 1 Then
                    SubGroupID = Login.DataSubGropPrd.GetString("id")
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
                    Str = Login.DataSubGropPrd.GetString("name_en")
                Else
                    Str = Login.DataSubGropPrd.GetString("name_th")
                End If
                Button_subGroup.Tag = Login.DataSubGropPrd.GetString("id")
                Button_subGroup.Text = Str
                Button_subGroup.TextAlign = ContentAlignment.MiddleCenter
                FlowLayout_subGroup.Controls.Add(Button_subGroup)
                AddHandler Button_subGroup.Click, AddressOf SubGroup_Click
                i += 1
            End While
            Login.DataSubGropPrd.Close()
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
        Dim vv = con.mysql_query("select * from pos_product where ref__id_catsubprd='" & SubGroupID & "' and id_status_sales='1' order by id asc ")
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
        If Login.NumDataResPrd > 0 Then
            While Login.DataResPrd.Read()
                If Login.DataResPrd.GetString("ref__id_catsubprd") = SubGroupID And i <= sizeWFood Then
                    If Login.DataResPrd.GetString("id") <> "" Then
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
                            Str = Login.DataResPrd.GetString("nameprd_en")
                        Else
                            Str = Login.DataResPrd.GetString("nameprd_th")
                        End If
                        Button_Food.Tag = Login.DataResPrd.GetString("id") & "_" & " " & "_" & " " & "_" & ""
                        Button_Food.Text = Str
                        Button_Food.TextAlign = ContentAlignment.MiddleCenter
                        AddHandler Button_Food.Paint, AddressOf Food_Paint 'Paint BG And Text
                        FlowLayout_food.Controls.Add(Button_Food)
                        If CInt(Login.DataResPrd.GetString("indre")) > 0 Then
                            AddHandler Button_Food.Click, AddressOf ClickShowIndre
                        Else
                            AddHandler Button_Food.Click, AddressOf Add_ToCat
                        End If

                    End If
                End If
                i += 1
            End While
            Login.DataResPrd.Close()
        End If
    End Sub
    Public Sub Show_Food(ByVal StratPFD As Integer)
        Load_numFood()
        FlowLayout_food.Controls.Clear()
        Dim Str As String
        Dim res_food As MySqlDataReader
        Dim i As Integer = 1
        Dim uu As Integer = 0
        Dim StrSQL As String = ""
        StrSQL += "select pos_product.nameprd_en as nameprd_en,pos_product.nameprd_th as nameprd_th,pos_product.id as id,IFNULL(pos_product_condition.ref_id_ingredients,'0')  AS indre,pos_product_condition.ref_id_size AS ref_id_size "
        StrSQL += ",pos_product_unit.id as id_unit,pos_product_unit.name_th as name_th_unit,pos_product_unit.name_en as name_en_unit,IFNULL(pos_product_condition.ref_id_unit,'0') as ref_id_unit "
        StrSQL += ",pos_product_condition.price_condition AS price_condition from pos_product"
        StrSQL += " LEFT JOIN  pos_product_condition  ON pos_product.id=pos_product_condition.ref_id_prd"
        StrSQL += " LEFT JOIN pos_product_unit ON pos_product_condition.ref_id_unit = pos_product_unit.id "
        StrSQL += " where pos_product.id_status_sales='1' and pos_product.ref__id_catsubprd='" & SubGroupID & "' GROUP BY pos_product.id order by pos_product.id asc LIMIT " & StratPFD & "," & sizeWFood
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
        Dim c As Integer = con.mysql_num_rows(con.mysql_query(StrSQL))
        If c > 0 Then
            res_food = con.mysql_query(StrSQL)
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
        End If
    End Sub

    Public Sub Add_ToCat(ByVal sender As Object, ByVal e As System.EventArgs)
        opentable_addnumprd1.txt_numprd.Text = "1"  'Set ค่าว่างให้ opentable_addnumprd1 กรอกตัวเลขจำนวนสินค้า
        opentable_addnumprd1.txt_recomment.Text = "" 'Set ค่าว่างให้ opentable_addnumprd1 กรอกคอมเม้นท์เพิ่มเติม
        Dim k As New Button
        k = sender
        opentable_addnumprd1.TextBox_NamePrd.Text = k.Text
        Dim res_Check As MySqlDataReader = con.mysql_query("SELECT config_frm_commentord FROM pos_shop")
        res_Check.Read()
        If res_Check.GetString("config_frm_commentord") = "1" Then
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
                    StrSQL += ",pos_product_condition.price_condition AS price_condition  "
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
                    Dim Name_N As String = ""
                    Dim Name_N_En As String = ""
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
                        Dim stru As String = ""
                        While res_order.Read()
                            itmx = ListView_ListOrder.Items.Add("0", y)
                            itmx.SubItems.Add("no")
                            itmx.SubItems.Add(res_order.GetString("id_prd"))
                            If aryTextFile(2) <> " " Then
                                If CInt(res_order.GetString("ref_id_unit")) > 0 Then
                                    stru = ""
                                Else
                                    stru = "(" & Str_indre & ")"
                                End If
                                StrSize = Str_size
                                    Name_N_En = res_order.GetString("nameprd_en") & stru
                                    Name_N = res_order.GetString("nameprd_th") & stru
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
                    itmx.SubItems.Add(opentable_addnumprd1.txt_recomment.Text)
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

        ElseIf res_Check.GetString("config_frm_commentord") = "0" Then
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
            StrSQL += ",pos_product_condition.price_condition AS price_condition  "
            StrSQL += ",pos_product_type.t_prd_id as prd_type_dis_id,pos_product_type.t_name_en as prd_type_dis_en,pos_product_type.t_name_th as prd_type_dis_th"
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
            Dim Name_N As String = ""
            Dim Name_N_En As String = ""
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
                Dim stru As String = ""
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
                        Name_N_En = res_order.GetString("nameprd_en")
                        Name_N = res_order.GetString("nameprd_th")
                    price_N = res_order.GetString("price")
                    End If
            itmx.SubItems.Add(aryTextFile(1))
            itmx.SubItems.Add(Name_N)
            itmx.SubItems.Add(Name_N_En)
            itmx.SubItems.Add(StrSize)
            itmx.SubItems.Add(opentable_addnumprd1.txt_numprd.Text)
            itmx.SubItems.Add(FormatNumber((price_N * 1), 2))
            itmx.SubItems.Add("")
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
    End Sub

    Public Sub calsum()
        Summary = 0
        Dim sql_price As String = ""
        Dim vat As Double = 0.0
        Dim service_chg As Double = CalServiceCh()
        For x As Integer = 0 To ListView_ListOrder.Items.Count - 1

            If ListView_ListOrder.Items(x).SubItems(1).Text = "cancel" Then
                Summary -= (CDbl(ListView_ListOrder.Items(x).SubItems(8).Text))
            Else
                Summary += (CDbl(ListView_ListOrder.Items(x).SubItems(8).Text))
            End If
        Next
        TextBox_Summary.Text = FormatNumber(Summary, 2)
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
                            ListView_ListOrder.Items(ListView_ListOrder.SelectedIndices(0)).SubItems(8).Text() = FormatNumber((pr / CDbl(ListView_ListOrder.Items(ListView_ListOrder.SelectedIndices(0)).SubItems(7).Text())) * am, 2)
                            ListView_ListOrder.Items(ListView_ListOrder.SelectedIndices(0)).SubItems(7).Text() = am
                        Else
                            ListView_ListOrder.Items(ListView_ListOrder.SelectedIndices(0)).SubItems(8).Text() = FormatNumber((pr / CDbl(ListView_ListOrder.Items(ListView_ListOrder.SelectedIndices(0)).SubItems(7).Text())) * 1, 2)
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
                            ListView_ListOrder.Items(ListView_ListOrder.SelectedIndices(0)).SubItems(8).Text() = FormatNumber((pr / CDbl(ListView_ListOrder.Items(ListView_ListOrder.SelectedIndices(0)).SubItems(7).Text())) * am, 2)
                            ListView_ListOrder.Items(ListView_ListOrder.SelectedIndices(0)).SubItems(7).Text() = am
                        Else
                            ListView_ListOrder.Items(ListView_ListOrder.SelectedIndices(0)).SubItems(8).Text() = FormatNumber((pr / CDbl(ListView_ListOrder.Items(ListView_ListOrder.SelectedIndices(0)).SubItems(7).Text())) * 1, 2)
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
            price1 = FormatNumber(CDbl(ListView_ListOrder.Items(ListView_ListOrder.FocusedItem.Index).SubItems(8).Text), 2)
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
    Public Confirm_sendOrder = False
    Public LangPrintSendCaptain As String = Login.LangG
    Private Sub btn_sendorder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_sendorder.Click
        If ListView_ListOrder.Items.Count > 0 Then
            dialog_confirm.Page = "opentable"
            If Login.LangG = "TH" Then
                dialog_confirm.Label_Dialog.Text = "คุณมั่นใจใช่ไหมที่จะส่งรายการอาหาร?"
            Else
                dialog_confirm.Label_Dialog.Text = "Are you sure send order to captain?"
            End If
            dialog_confirm.ShowDialog()

            If Confirm_sendOrder = True Then
                If index.Add_order = True Then
                    If Login.switchLangPrintCaptain = 1 Then
                        switch_langprint.ShowDialog()
                    End If
                    btn_sendorder.Enabled = False
                    Send_again()
                    index.Add_order = False
                    btn_sendorder.Enabled = True
                Else
                    If Login.switchLangPrintCaptain = 1 Then
                        switch_langprint.ShowDialog()
                    End If
                    btn_sendorder.Enabled = False
                    Send_Captain()
                    btn_sendorder.Enabled = True
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
        Dim status_open As String = "ontb"
        Dim ID_TB As Integer = 0
        Dim id_tb_join As Integer = 0
        Dim NameTB As String = ""
        status_open = "ontb"
        Code_GohomeEdit = "0"
        NameTB = index.getNameTable(Login.OpenId)
        Dim chk As Boolean = False
        Dim chk_void As Boolean = False
        Dim amt As Integer = 0
        Dim price1 As Double = 0
        Dim StringQty As String = ""
        Dim print_void As Boolean = False
        Dim yearNew As String
        If CInt(Login.DateData.ToString("yyyy")) > 2450 Then
            yearNew = CInt(Login.DateData.ToString("yyyy")) - 543
        Else
            yearNew = CInt(Login.DateData.ToString("yyyy"))
        End If
        Dim dNow As DateTime = yearNew & "-" & Login.DateData.ToString("MM-dd ") & " " & Format(DateAndTime.Now(), "HH:mm:ss")

        If ID_TB_JOIN_OLD <> Login.OpenId And CInt(ID_TB_JOIN_OLD) > 0 Then '==== เข้าเงื่อนไขที่มีการรวมโต๊ะ===='
            ID_TB = ID_TB_JOIN_OLD
            id_tb_join = Login.OpenId
        ElseIf ID_TB_JOIN_OLD = Login.OpenId Then  '==== โต๊ะที่ย้ายเป็นโต๊ะ Head ในการรวมดต๊ะ===='
            ID_TB = Login.OpenId
            id_tb_join = Login.OpenId
        ElseIf CInt(ID_TB_JOIN_OLD) = 0 And CInt(Login.OpenId) > 0 Then '==== เข้าเงื่อนไขที่ไม่่มีการรวมโต๊ะไว้====='
            ID_TB = Login.OpenId
            id_tb_join = 0
        End If

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

                Dim rf_id_prd As String = ListView_ListOrder.Items(j).SubItems(2).Text
                Dim rf_id_con As String = ListView_ListOrder.Items(j).SubItems(3).Text
                Dim name_ord1 As String = ListView_ListOrder.Items(j).SubItems(4).Text.Replace("'", "\'")
                Dim name_ord_en As String = ListView_ListOrder.Items(j).SubItems(5).Text.Replace("'", "\'")
                Dim amt1 As Integer = ListView_ListOrder.Items(j).SubItems(7).Text
                Dim price As Double = CDbl(ListView_ListOrder.Items(j).SubItems(8).Text)
                Dim remark As String = ListView_ListOrder.Items(j).SubItems(9).Text.Replace("'", "\'")
                Dim id_cat As String = ListView_ListOrder.Items(j).SubItems(10).Text.Trim
                Dim id_subcatprd As String = ListView_ListOrder.Items(j).SubItems(11).Text
                Dim name_cat As String = ListView_ListOrder.Items(j).SubItems(12).Text.Trim
                Dim name_subcat As String = ListView_ListOrder.Items(j).SubItems(14).Text.Trim
                Dim ord_vat As Integer = ListView_ListOrder.Items(j).SubItems(16).Text.Trim
                Dim ord_vat_st As String = ListView_ListOrder.Items(j).SubItems(17).Text.Trim
                Dim prd_t_id As String = ListView_ListOrder.Items(j).SubItems(18).Text.Trim
                Dim prd_t_en As String = ListView_ListOrder.Items(j).SubItems(19).Text.Trim
                Dim prd_t_th As String = ListView_ListOrder.Items(j).SubItems(20).Text.Trim

                Dim str_ck As String = "select * from pos_order_list where rf_id_prd='" & rf_id_prd & "' and rf_id_con='" & rf_id_con & "'" _
                & " and name_ord='" & name_ord1 & "' and rf_id_table='" & ID_TB & "' and  ref_id_join='" & id_tb_join & "' and status_pay='no'" _
                & " and status_open='ontb' and status_sd_captain<>'void' "
               

                If con.mysql_num_rows(con.mysql_query(str_ck)) > 0 Then

                    StringQty &= "UPDATE pos_order_list SET amt=amt+" & amt1 & ",price=price+" & price & " where  rf_id_table='" & ID_TB & "' " _
                           & "and ref_id_join='" & id_tb_join & "' and rf_id_prd='" & rf_id_prd & "' " _
                           & "and rf_id_con='" & rf_id_con & "' and name_ord='" & name_ord1 & "' and status_pay='no' and status_open='ontb' and status_sd_captain<>'void';"

                Else

                    StringQty &= "INSERT INTO pos_order_list (rf_id_prd,rf_id_con,name_ord,name_ord_en,amt,price,prs," _
               & "rf_id_table,ref_id_join,status_sd_captain,status_open,remark,create_date,create_by,code_gohome,ref_cat_id," _
                & "ref_catsubprd,name_th_cat,name_en_cat,name_th_catsubprd,name_en_catsubprd,ord_vat,ord_vat_st,prd_type_dis_id,prd_type_dis_en,prd_type_dis_th) " _
               & " VALUES('" & rf_id_prd & "','" & rf_id_con & "','" & name_ord1 & "','" & name_ord_en & "','" & amt1 & "','" & price & "'," _
               & "'" & TextBox_Prs.Text & "','" & ID_TB & "','" & id_tb_join & "','no','" & status_open & "','" & remark & "','" & dNow.ToString("yyyy-MM-dd HH:mm:ss") & "','" & Login.username & "'," _
               & "'" & Code_GohomeEdit & "','" & id_cat & "','" & id_subcatprd & "','" & name_cat & "'," _
                & "'" & name_cat & "','" & name_subcat & "','" & name_subcat & "','" & ord_vat & "','" & ord_vat_st & "','" & prd_t_id & "','" & prd_t_en & "','" & prd_t_th & "');"

                End If


                cutStock(rf_id_prd, rf_id_con, amt1)
                Dim v As Boolean = False
                For u As Integer = 0 To array_print.Count - 1
                    If Get_printer_subgroup(id_subcatprd) = array_print(u).ToString Then
                        v = True
                    End If
                Next
                If v = False Then
                    array_print.Add(Get_printer_subgroup(id_subcatprd))
                    Dim copy2captain As String = Get_CopySendcaptain_subgroup(id_subcatprd)
                    Dim print_onoff As String = Get_printer_ONOFF_subgroup(id_subcatprd)
                    Dim id_ref_temp As String = ""
                    id_ref_temp = "P" & Login.DateData.ToString("dd") & Login.DateData.ToString("MM") & Login.DateData.ToString("yy") & Format(DateAndTime.Now, "HH") & Format(DateAndTime.Now, "mm") & Format(DateAndTime.Now, "ss") & "0" & j
                    array_idtemp.Add(id_ref_temp)
                    array_sendcap.Add(copy2captain)
                    array_namecat.Add(name_cat)
                    array_print_onoff.Add(print_onoff)
                End If

            End If
        Next
        StringQty &= "UPDATE pos_table_system SET remark_tb='" & TextBox_Comment.Text & "' WHERE id='" & Login.OpenId & "';"

        Dim query As Boolean = con.mysql_query(StringQty)

        'ส่งเข้าห้องครัว ปริ้น ' // ส่งค่าวันที่ เดือน ปี เลขที่โต๊ะ สถานะ status_sd_captain = no ยังไม่ปริ้น
        'Print

        If CInt(Login.DateData.ToString("yyyy")) > 2450 Then
            year = CInt(Login.DateData.ToString("yyyy")) - 543
        Else
            year = CInt(Login.DateData.ToString("yyyy"))
        End If

        If query = True Then
            Dim insert_temp As String = ""
            For t As Integer = 0 To array_print.Count - 1
                For k As Integer = 0 To ListView_ListOrder.Items.Count - 1
                    If ListView_ListOrder.Items(k).SubItems(1).Text.ToLower = "no" Then
                        Dim rf_id_prd As String = ListView_ListOrder.Items(k).SubItems(2).Text.Trim
                        Dim rf_id_con As String = ListView_ListOrder.Items(k).SubItems(3).Text.Trim
                        Dim name_ord As String = ListView_ListOrder.Items(k).SubItems(4).Text.Trim.Replace("'", "\'")
                        Dim name_ord_en = ListView_ListOrder.Items(k).SubItems(5).Text.Trim.Replace("'", "\'")
                        Dim samt As Integer = CInt(ListView_ListOrder.Items(k).SubItems(7).Text.Trim)
                        Dim price As Double = CDbl(ListView_ListOrder.Items(k).SubItems(8).Text.Trim)
                        Dim remark As String = ListView_ListOrder.Items(k).SubItems(9).Text.Trim.Replace("'", "\'")
                        Dim id_cat As String = ListView_ListOrder.Items(k).SubItems(10).Text.Trim
                        Dim id_subcatprd As String = CStr(ListView_ListOrder.Items(k).SubItems(11).Text.ToString)
                        Dim name_cat_en As String = ListView_ListOrder.Items(k).SubItems(12).Text.Trim
                        Dim name_cat_th As String = ListView_ListOrder.Items(k).SubItems(13).Text.Trim
                        Dim name_subcat As String = ListView_ListOrder.Items(k).SubItems(14).Text.Trim
                        Dim ord_vat As Integer = ListView_ListOrder.Items(k).SubItems(16).Text.Trim
                        Dim ord_vat_st As String = ListView_ListOrder.Items(k).SubItems(17).Text.Trim
                        If array_print(t).ToString = Get_printer_subgroup(id_subcatprd) Then
                            insert_temp &= "INSERT INTO pos_temp_print (rf_id_prd,rf_id_con,name_ord,name_ord_en,amt,price,prs,rf_id_table,status_sd_captain,status_pay,status_open,remark,create_date,code_gohome,name_cat_en,name_cat_th,id_ref_temp)" _
                               & " VALUES('" & rf_id_prd & "','" & rf_id_con & "','" & name_ord & "','" & name_ord_en & "'," _
                              & "'" & samt & "','" & price & "','" & TextBox_Prs.Text & "','" & ID_TB & "'," _
                             & "'no','no','ontb','" & remark & "'," _
                            & "'" & dNow.ToString("yyyy-MM-dd HH:mm:ss") & "','0','" & name_cat_th & "','" & name_cat_en & "','" & array_idtemp(t).ToString & "');"
                        End If
                    End If
                Next

            Next
            If insert_temp <> "" Then
                con.mysql_query(insert_temp)
            End If

            For h As Integer = 0 To array_print.Count - 1
                If array_print_onoff(h) <> "0" Or array_print_onoff(h) <> 0 Then
                    Dim WorkerThread As Thread
                    Dim W As New worker
                    W.setSendCaptain(ID_TB, status_open, NameTB, dNow.ToString("dd/MM/yyyy"), "0", Login.username, array_print(h).ToString, array_idtemp(h).ToString, array_sendcap(h).ToString, LangPrintSendCaptain)
                    WorkerThread = New Thread(AddressOf W.Start)    'Create our Worker thread and tell it that when we start it it should call our Worker's Start() method
                    WorkerThread.Start()
                    WorkerThread.Join()
                    If Login.alert_sendcaptain = 1 Then
                        If Login.LangG = "TH" Then
                            dialog_complete.Label_Dialog.Text = "ส่งรายการ " & array_namecat(h).ToString & " เรียบร้อยแล้วค่ะ"
                            dialog_complete.ShowDialog()
                        Else
                            dialog_complete.Label_Dialog.Text = "Send order " & array_namecat(h).ToString & " to Captain Complete."
                            dialog_complete.ShowDialog()
                        End If
                    End If
                End If
            Next

            Dim strUp As String = ""
            strUp &= "Update pos_order_list SET status_sd_captain='yes',code_print='" & GetCode_printOld() & "',remark_tb='" & TextBox_Comment.Text & "' WHERE " _
            & "rf_id_table='" & Login.OpenId & "' and status_sd_captain='no' and  DAY(create_date)='" & Login.DateData.ToString("dd") & "' and MONTH(create_date)='" & Login.DateData.ToString("MM") & "' and YEAR(create_date)='" & year & "'"
            chk = con.mysql_query(strUp) 'Query update รายการอาหารเมื่อทำการปริ้นแล้ว

        End If
        'เช้คว่า insert ยัง และ ปริ้นหรือยัง
        If chk = True And query = True Then
            index.CloseForm()
            home1.Change_Tb = False
            index.Gohome = False
            index.ReservationP = False
            index.Add_order = False
            home1.MdiParent = index
            home1.Show()
            home1.WindowState = FormWindowState.Minimized
            home1.WindowState = FormWindowState.Maximized
            Login.OpenId = ""
            opentakehome.SendOrder1 = "0"
            Login.Formname = "home1"
            clearData()
        End If
    End Sub

    Public Function GetCode_printOld()
        Dim v As String = ""
        Dim res_v As MySqlDataReader = con.mysql_query("SELECT * FROM pos_order_list WHERE rf_id_table='" & Login.OpenId & "' and  DAY(create_date)='" & Login.DateData.ToString("dd") & "' and MONTH(create_date)='" & Login.DateData.ToString("MM") & "' and YEAR(create_date)='" & year & "' and status_pay='no' ORDER BY id_ord DESC limit 1")
        res_v.Read()
        v = res_v.GetString("code_print")
        res_v.Close()
        Return v
    End Function
    Public Function Save_Captain()
        Dim return1 As Boolean = False
        Dim prs As String = TextBox_Prs.Text
        Dim ID_TB As Integer = 0
        Dim CodeGoHome As String = "0"
        Dim q_order As Boolean = False
        Dim chk As Boolean = False
        Dim status_open As String = "ontb"
        Dim NameTb As String = ""
        status_open = "ontb"
        ID_TB = Login.OpenId
        NameTb = index.getNameTable(Login.OpenId)
        Dim up_tb As Boolean = con.mysql_query("UPDATE pos_table_system SET status='2',remark_tb='" & TextBox_Comment.Text & "' WHERE id='" & Login.OpenId & "'")
        'Loop get value for insert database
        Dim yearNew As String
        If CInt(Login.DateData.ToString("yyyy")) > 2450 Then
            yearNew = CInt(Login.DateData.ToString("yyyy")) - 543
        Else
            yearNew = CInt(Login.DateData.ToString("yyyy"))
        End If
        Dim dNow As DateTime = yearNew & "-" & Login.DateData.ToString("MM-dd") & " " & Date.Now.ToString(" HH:mm:ss")
        Dim string_g As String = ""
        For x As Integer = 0 To ListView_ListOrder.Items.Count - 1
            If ListView_ListOrder.Items(x).SubItems(1).Text.ToLower <> "yes" Then
                Dim rf_id_prd As String = ListView_ListOrder.Items(x).SubItems(2).Text.Trim
                Dim rf_id_con As String = ListView_ListOrder.Items(x).SubItems(3).Text.Trim
                Dim name_ord As String = ListView_ListOrder.Items(x).SubItems(4).Text.Trim.Replace("'", "\'")
                Dim name_ord_en As String = ListView_ListOrder.Items(x).SubItems(5).Text.Trim.Replace("'", "\'")
                Dim amt As String = ListView_ListOrder.Items(x).SubItems(7).Text.Trim
                Dim price1 As Double = CDbl(ListView_ListOrder.Items(x).SubItems(8).Text.Trim)
                Dim remark As String = ListView_ListOrder.Items(x).SubItems(9).Text.Trim.Replace("'", "\'")
                Dim id_cat As String = ListView_ListOrder.Items(x).SubItems(10).Text.Trim
                Dim id_subcatprd As String = ListView_ListOrder.Items(x).SubItems(11).Text.Trim
                Dim name_cat As String = ListView_ListOrder.Items(x).SubItems(12).Text.Trim
                Dim name_subcat As String = ListView_ListOrder.Items(x).SubItems(14).Text.Trim
                Dim ord_vat As Integer = ListView_ListOrder.Items(x).SubItems(16).Text.Trim
                Dim ord_vat_st As String = ListView_ListOrder.Items(x).SubItems(17).Text.Trim
                Dim prd_t_id As String = ListView_ListOrder.Items(x).SubItems(18).Text.Trim
                Dim prd_t_en As String = ListView_ListOrder.Items(x).SubItems(19).Text.Trim
                Dim prd_t_th As String = ListView_ListOrder.Items(x).SubItems(20).Text.Trim
                q_order = con.mysql_query("INSERT INTO pos_order_list (rf_id_prd,rf_id_con,name_ord,name_ord_en,amt,price,prs," _
                 & "rf_id_table,status_sd_captain,status_open,remark,create_date,create_by,code_gohome,remark_tb,ref_cat_id," _
                 & "ref_catsubprd,name_th_cat,name_en_cat,name_th_catsubprd,name_en_catsubprd,ord_vat,ord_vat_st,prd_type_dis_id,prd_type_dis_en,prd_type_dis_th) " _
                 & " VALUES('" & rf_id_prd & "','" & rf_id_con & "','" & name_ord & "','" & name_ord_en & "','" & amt & "','" & price1 & "'," _
                 & "'" & prs & "','" & ID_TB & "','yes','" & status_open & "','" & remark & "','" & dNow.ToString("yyyy-MM-dd ") & Now().ToString("HH:mm:ss") & "','" & Login.username & "'," _
                 & "'" & CodeGoHome & "','" & TextBox_Comment.Text & "','" & id_cat & "','" & id_subcatprd & "','" & name_cat & "'," _
                 & "'" & name_cat & "','" & name_subcat & "','" & name_subcat & "','" & ord_vat & "','" & ord_vat_st & "','" & prd_t_id & "','" & prd_t_en & "','" & prd_t_th & "');")

                cutStock(rf_id_prd, rf_id_con, amt)
                If q_order = True Then
                    chk = True
                End If
            End If
        Next
        If chk = True Then  'Check When insert database = true
            return1 = True
        End If
        Return return1
    End Function
    Public Sub Send_Captain()
        Dim prs As String = TextBox_Prs.Text
        Dim ID_TB As Integer = 0
        Dim CodeGoHome As String = ""
        Dim q_order As Boolean
        Dim str_order As String = ""
        Dim chk As Boolean = False
        Dim status_open As String = "ontb"
        Dim NameTb As String = ""

        status_open = "ontb"
        ID_TB = Login.OpenId
        CodeGoHome = "0"
        NameTb = index.getNameTable(Login.OpenId)
        Dim up_tb As Boolean = con.mysql_query("UPDATE pos_table_system SET status='2' WHERE id='" & Login.OpenId & "'")

        'Loop get value for insert database
        Dim yearNew As String
        If CInt(Login.DateData.ToString("yyyy")) > 2450 Then
            yearNew = CInt(Login.DateData.ToString("yyyy")) - 543
        Else
            yearNew = CInt(Login.DateData.ToString("yyyy"))
        End If
        Dim dNow As DateTime = yearNew & "-" & Login.DateData.ToString("MM-dd") & " " & Date.Now.ToString(" HH:mm:ss")
        Dim string_g As String = ""
        '==== status yes 0r no ==='
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
            If ListView_ListOrder.Items(x).SubItems(1).Text.ToLower <> "yes" Then
                Dim rf_id_prd As String = ListView_ListOrder.Items(x).SubItems(2).Text.Trim
                Dim rf_id_con As String = ListView_ListOrder.Items(x).SubItems(3).Text.Trim
                Dim name_ord As String = ListView_ListOrder.Items(x).SubItems(4).Text.Trim.Replace("'", "\'")
                Dim name_ord_en As String = ListView_ListOrder.Items(x).SubItems(5).Text.Trim.Replace("'", "\'")
                Dim size1 As String = ListView_ListOrder.Items(x).SubItems(6).Text.Trim
                Dim amt As String = ListView_ListOrder.Items(x).SubItems(7).Text.Trim
                Dim price1 As Double = CDbl(ListView_ListOrder.Items(x).SubItems(8).Text.Trim)
                Dim remark As String = ListView_ListOrder.Items(x).SubItems(9).Text.Trim.Replace("'", "\'")
                Dim id_cat As String = ListView_ListOrder.Items(x).SubItems(10).Text.Trim
                Dim id_subcatprd As String = ListView_ListOrder.Items(x).SubItems(11).Text.Trim
                Dim name_cat As String = ListView_ListOrder.Items(x).SubItems(12).Text.Trim
                Dim name_subcat As String = ListView_ListOrder.Items(x).SubItems(14).Text.Trim
                Dim ord_vat As Integer = ListView_ListOrder.Items(x).SubItems(16).Text.Trim
                Dim ord_vat_st As String = ListView_ListOrder.Items(x).SubItems(17).Text.Trim
                Dim prd_t_id As String = ListView_ListOrder.Items(x).SubItems(18).Text.Trim
                Dim prd_t_en As String = ListView_ListOrder.Items(x).SubItems(19).Text.Trim
                Dim prd_t_th As String = ListView_ListOrder.Items(x).SubItems(20).Text.Trim
                str_order &= "INSERT INTO pos_order_list (rf_id_prd,rf_id_con,name_ord,name_ord_en,amt,price,prs," _
                 & "rf_id_table,status_sd_captain,status_open,remark,create_date,create_by,code_gohome,remark_tb,ref_cat_id," _
                 & "ref_catsubprd,name_th_cat,name_en_cat,name_th_catsubprd,name_en_catsubprd,ord_vat,ord_vat_st,prd_type_dis_id,prd_type_dis_en,prd_type_dis_th) " _
                 & " VALUES('" & rf_id_prd & "','" & rf_id_con & "','" & name_ord & "','" & name_ord_en & "','" & amt & "','" & price1 & "'," _
                 & "'" & prs & "','" & ID_TB & "','no','" & status_open & "','" & remark & "','" & dNow.ToString("yyyy-MM-dd ") & Now().ToString("HH:mm:ss") & "','" & Login.username & "'," _
                 & "'" & CodeGoHome & "','" & TextBox_Comment.Text & "','" & id_cat & "','" & id_subcatprd & "','" & name_cat & "'," _
                 & "'" & name_cat & "','" & name_subcat & "','" & name_subcat & "','" & ord_vat & "','" & ord_vat_st & "','" & prd_t_id & "','" & prd_t_en & "','" & prd_t_th & "');"

                Dim v As Boolean = False
                For u As Integer = 0 To array_print.Count - 1
                    If Get_printer_subgroup(id_subcatprd) = array_print(u).ToString Then
                        v = True
                    End If
                Next
                If v = False Then
                    array_print.Add(Get_printer_subgroup(id_subcatprd))
                    Dim copy2captain As String = Get_CopySendcaptain_subgroup(id_subcatprd)
                    Dim print_onoff As String = Get_printer_ONOFF_subgroup(id_subcatprd)
                    Dim id_ref_temp As String = ""
                    id_ref_temp = "P" & Login.DateData.ToString("dd") & Login.DateData.ToString("MM") & Login.DateData.ToString("yy") & Format(DateAndTime.Now, "HH") & Format(DateAndTime.Now, "mm") & Format(DateAndTime.Now, "ss") & "0" & x
                    array_idtemp.Add(id_ref_temp)
                    array_sendcap.Add(copy2captain)
                    array_namecat.Add(name_cat)
                    array_print_onoff.Add(print_onoff)
                End If

                cutStock(rf_id_prd, rf_id_con, amt) ' ตัดสต๊อกสินค้า

            End If
        Next

        If str_order <> "" Then
            q_order = con.mysql_query(str_order)
            con.mysql_query("UPDATE pos_table_system SET remark_tb='" & TextBox_Comment.Text & "' WHERE id='" & Login.OpenId & "';")
        End If


        If q_order = True Then  'Check When insert database = true
            Dim str_temp As String = ""
            For t As Integer = 0 To array_print.Count - 1
                For k As Integer = 0 To ListView_ListOrder.Items.Count - 1
                    If ListView_ListOrder.Items(k).SubItems(1).Text.ToLower = "no" Then
                        Dim rf_id_prd As String = ListView_ListOrder.Items(k).SubItems(2).Text.Trim
                        Dim rf_id_con As String = ListView_ListOrder.Items(k).SubItems(3).Text.Trim
                        Dim name_ord_en = ListView_ListOrder.Items(k).SubItems(5).Text.Trim.Replace("'", "\'")
                        Dim name_ord = ListView_ListOrder.Items(k).SubItems(4).Text.Trim.Replace("'", "\'")
                        Dim samt As String = ListView_ListOrder.Items(k).SubItems(7).Text.Trim
                        Dim price1 As Double = CDbl(ListView_ListOrder.Items(k).SubItems(8).Text.Trim)
                        Dim remark As String = ListView_ListOrder.Items(k).SubItems(9).Text.Trim.Replace("'", "\'")
                        Dim id_cat As String = ListView_ListOrder.Items(k).SubItems(10).Text.Trim
                        Dim id_subcatprd As String = ListView_ListOrder.Items(k).SubItems(11).Text.Trim
                        Dim name_cat_en As String = ListView_ListOrder.Items(k).SubItems(12).Text.Trim
                        Dim name_cat_th As String = ListView_ListOrder.Items(k).SubItems(13).Text.Trim
                        Dim name_subcat As String = ListView_ListOrder.Items(k).SubItems(14).Text.Trim
                        Dim ord_vat As Integer = ListView_ListOrder.Items(k).SubItems(16).Text.Trim
                        Dim ord_vat_st As String = ListView_ListOrder.Items(k).SubItems(17).Text.Trim
                        If array_print(t).ToString = Get_printer_subgroup(id_subcatprd) Then
                            str_temp &= "INSERT INTO pos_temp_print (rf_id_prd,rf_id_con,name_ord,name_ord_en,amt,price,rf_id_table," _
                                         & "status_sd_captain,status_pay,status_open,remark,create_date,code_gohome,name_cat_en," _
                                        & "name_cat_th,id_ref_temp)" _
                                        & " VALUES('" & rf_id_prd & "','" & rf_id_con & "','" & name_ord & "','" & name_ord_en & "'," _
                                        & "'" & samt & "','" & price1 & "','" & Login.OpenId & "'," _
                                        & "'yes','no','ontb','" & remark & "'," _
                                        & "'" & Login.DateData.ToString("yyyy-MM-dd HH:mm:ss") & "','0','" & name_cat_en & "','" & name_cat_th & "','" & array_idtemp(t).ToString & "');"
                        End If
                    End If
                Next
            Next
            If str_temp <> "" Then
                con.mysql_query(str_temp)
            End If

            For g As Integer = 0 To array_print.Count - 1
                If array_print_onoff(g) = "0" Then
                    If Login.alert_sendcaptain = 1 Then
                        If Login.LangG = "TH" Then
                            dialog_complete.Label_Dialog.Text = "บันทึกรายการ " & array_namecat(g) & " เรียบร้อยแล้วค่ะ"
                            dialog_complete.ShowDialog()
                        Else
                            dialog_complete.Label_Dialog.Text = "Save order " & array_namecat(g) & " Complete."
                            dialog_complete.ShowDialog()
                        End If
                    End If
                Else
                    Dim WorkerThread As Thread
                    Dim W As New worker
                    W.setSendCaptain(ID_TB, status_open, NameTb, dNow.ToString("dd/MM/yyyy"), CodeGoHome, Login.username, array_print(g).ToString, array_idtemp(g).ToString, array_sendcap(g).ToString, LangPrintSendCaptain)
                    WorkerThread = New Thread(AddressOf W.Start)    'Create our Worker thread and tell it that when we start it it should call our Worker's Start() method
                    WorkerThread.Start()
                    WorkerThread.Join()
                    If Login.alert_sendcaptain = 1 Then
                        If Login.LangG = "TH" Then
                            dialog_complete.Label_Dialog.Text = "ส่งรายการ " & array_namecat(g) & " เรียบร้อยแล้วค่ะ"
                            dialog_complete.ShowDialog()
                        Else
                            dialog_complete.Label_Dialog.Text = "Send order " & array_namecat(g) & " Complete."
                            dialog_complete.ShowDialog()
                        End If
                    End If
                End If
            Next

            'SET DATABASE AFTER PRINT
            Dim strUp As String = ""
            'Check Type Use System
            strUp &= "Update pos_order_list SET status_sd_captain='yes',code_print='0' WHERE " _
             & "rf_id_table='" & ID_TB & "' and status_sd_captain='no' and  DAY(create_date)='" & Login.DateData.ToString("dd") & "' and MONTH(create_date)='" & Login.DateData.ToString("MM") & "' and YEAR(create_date)='" & Login.DateData.ToString("yyyy") & "'"
            Dim qty_print As Boolean = con.mysql_query(strUp)
            'Alert
            If qty_print = True Then
                Confirm_sendOrder = False
                index.CloseForm()
                home1.Change_Tb = False
                index.Gohome = False
                index.ReservationP = False
                index.Add_order = False
                home1.MdiParent = index
                home1.Show()
                home1.WindowState = FormWindowState.Minimized
                home1.WindowState = FormWindowState.Maximized
                Login.OpenId = ""
                opentakehome.SendOrder1 = "0"
                Login.Formname = "home1"
                clearData()

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
   
    Public Function Get_CopySendcaptain(ByRef idcat)
        Dim objReader As New System.IO.StreamReader("printer_g.txt", Encoding.UTF8)
        Dim TextLine() As String
        Dim p As String = ""
        'โหลดข้อมูล Tabspage2
        Do While objReader.Peek() <> -1
            TextLine = objReader.ReadLine().ToString.Trim.Split("=")
            If idcat = TextLine(0).ToString.Trim Then
                p = TextLine(2).ToString
            End If
        Loop
        objReader.Close()
        Return p
    End Function
    Public Function GetCode_print()
        Dim x As String = ""
        x = Now.ToString("dd") & Now.ToString("HH") & Now.ToString("mm") & Now.ToString("ss")
        Return x
    End Function
    Public Function Get_printer_ONOFF(ByRef idcat)
        Dim objReader As New System.IO.StreamReader("printer_g.txt", Encoding.UTF8)
        Dim TextLine() As String
        Dim p As String = ""
        'โหลดข้อมูล Tabspage2
        Do While objReader.Peek() <> -1
            TextLine = objReader.ReadLine().ToString.Trim.Split("=")
            If idcat = TextLine(0).ToString.Trim Then
                p = TextLine(3).ToString
            End If
        Loop
        objReader.Close()
        Return p
    End Function
    Public Sub clearData()
        If ListView_ListOrder.Items.Count > 0 Then
            ListView_ListOrder.Items.Clear()
        End If
        TextBox_Prs.Text = "1"
        TextBox_Summary.Text = "0.00"
        ID_TB_JOIN_OLD = "0"
    End Sub
    Public Sub Load_Product_list()
        If ListView_ListOrder.Items.Count > 0 Then
            ListView_ListOrder.Items.Clear()
        End If
        Dim size_n As String = ""
        Dim rf_id_con As String = ""
        Dim itmx1 As New ListViewItem
        Dim y As Integer = 0
        Dim res_listView As MySqlDataReader
        Dim yearNew As String = ""
        If CInt(Login.DateData.ToString("yyyy")) > 2450 Then
            yearNew = CInt(Login.DateData.ToString("yyyy")) - 543
        Else
            yearNew = CInt(Login.DateData.ToString("yyyy"))
        End If
        Dim dNow As Date = yearNew & "-" & Login.DateData.ToString("MM-dd")
       
        res_listView = con.mysql_query("SELECT pos_order_list.id_ord AS id_ord,pos_order_list.status_sd_captain AS status_sd_captain," _
        & "pos_order_list.rf_id_prd AS rf_id_prd,pos_order_list.rf_id_con As rf_id_con,pos_order_list.name_ord AS name_ord," _
        & "pos_order_list.name_ord_en AS name_ord_en," _
        & "pos_order_list.prs AS prs,pos_order_list.remark AS remark,pos_table_system.remark_tb as remark_tb," _
        & "SUM(pos_order_list.amt) AS samt,SUM(pos_order_list.price) AS sprice,pos_table_system.id AS idTb,IFNULL(pos_product_size.name_th,0) AS name_size," _
        & "pos_order_list.ref_cat_id as ref_cat_id,pos_order_list.ref_catsubprd as ref_catsubprd,pos_order_list.name_th_cat as name_th_cat,pos_order_list.name_en_cat as name_en_cat," _
        & "pos_order_list.name_th_catsubprd as name_th_catsubprd,pos_order_list.name_en_catsubprd as name_en_catsubprd,pos_order_list.ord_vat as ord_vat,pos_order_list.ord_vat_st as ord_vat_st," _
        & "pos_order_list.prd_type_dis_id as prd_type_dis_id,pos_order_list.prd_type_dis_en as prd_type_dis_en,pos_order_list.prd_type_dis_th as prd_type_dis_th" _
        & ",IFNULL(un.name_th,'') as name_unit" _
        & "  FROM pos_order_list  INNER JOIN pos_table_system ON pos_table_system.id=pos_order_list.rf_id_table " _
        & " LEFT JOIN pos_product_condition ON pos_order_list.rf_id_con =  pos_product_condition.id " _
        & " LEFT JOIN pos_product_ingredients ON pos_product_ingredients.id  =  pos_product_condition.ref_id_ingredients" _
        & " LEFT JOIN pos_product_size ON pos_product_size.id =  pos_product_condition.ref_id_size" _
        & " LEFT JOIN pos_product_unit un ON un.id =  pos_product_condition.ref_id_unit" _
        & " WHERE (pos_order_list.create_date LIKE '%" & dNow.ToString("yyyy-MM-dd") & "%') and pos_order_list.status_pay='no' and pos_order_list.status_sd_captain='yes' and pos_order_list.status_open<>'gohome' and pos_order_list.rf_id_table='" & Login.OpenId & "'" _
        & " GROUP BY pos_order_list.rf_id_prd,pos_order_list.rf_id_con,pos_order_list.name_ord order by id_ord asc")

        While res_listView.Read
            itmx1 = ListView_ListOrder.Items.Add(res_listView.GetString("id_ord"), y)
            itmx1.SubItems.Add(res_listView.GetString("status_sd_captain"))
            itmx1.SubItems.Add(res_listView.GetString("rf_id_prd"))
            If res_listView.GetString("rf_id_con") <> "0" Then
                rf_id_con = res_listView.GetString("rf_id_con")
            Else
                rf_id_con = ""
            End If

            itmx1.SubItems.Add(rf_id_con)
            itmx1.SubItems.Add(res_listView.GetString("name_ord"))
            itmx1.SubItems.Add(res_listView.GetString("name_ord_en"))
            If res_listView.GetString("name_size") <> "0" Or res_listView.GetString("name_unit") <> "" Then

                If res_listView.GetString("name_size") <> "0" Then
                    size_n = res_listView.GetString("name_size")
                Else
                    size_n = res_listView.GetString("name_unit")
                End If
            Else
                size_n = ""
            End If
            itmx1.SubItems.Add(size_n)
            itmx1.SubItems.Add(res_listView.GetString("samt"))
            itmx1.SubItems.Add(FormatNumber(res_listView.GetString("sprice"), 2))
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
            TextBox_Prs.Text = res_listView.GetString("prs")
            TextBox_Comment.Text = res_listView.GetString("remark_tb")
            ListView_ListOrder.Items(y).BackColor = Color.Green
            y += 1
        End While
        res_listView.Close()
        ReDim array_new(ListView_ListOrder.Items.Count, 2)
        For i As Integer = 0 To ListView_ListOrder.Items.Count - 1
            array_new(i, 0) = ListView_ListOrder.Items(i).SubItems(2).Text
            array_new(i, 1) = ListView_ListOrder.Items(i).SubItems(3).Text
            array_new(i, 2) = ListView_ListOrder.Items(i).SubItems(7).Text
        Next
        Loadchk = True
        calsum()
        ShowCover(Login.OpenId, TextBox_Prs, txt_child, txt_cover, txt_roomnum, TextBox_Comment)
    End Sub

    Private Sub btn_backGohome_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        index.Gohome = False
        home1.Show()
    End Sub

    Private Sub btn_pay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '  index.openCloseMenu(payment)
        payment.MdiParent = index
        payment.Show()
        payment.WindowState = FormWindowState.Minimized
        payment.WindowState = FormWindowState.Maximized
        'payment.TextBox_Total.Text = TextBox_Summary.Text
        Me.Hide()
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
    ' Edit Order list
    Public Size_Edit As String
    Public Idprd_edit As String
    Public Idprd_editCon As String
   
    Private Sub TextBox_Prs_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TextBox_Prs.Click
        keyborad_number.text1 = "TextBox_Prs"
        keyborad_number.ShowDialog()
        AddCoverTable(TextBox_Prs.Text, txt_child.Text, txt_cover.Text, txt_roomnum.Tag.ToString, txt_roomnum.Text, Login.OpenId, "0")
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
       
    End Sub
    Private Sub btnopen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnopen.Click
        'Dim setOpen As Boolean = con.mysql_query("UPDATE pos_table_system SET status ='2' WHERE id='" & Login.OpenId & "' ")
        If ListView_ListOrder.Items.Count > 0 Then
            If MessageBox.Show("[บันทึกข้อมูลนี้หรือไม่?", "Comfirm Save Order?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                If Save_Captain() = True Then
                    If Login.LangG = "TH" Then
                        MessageBox.Show("บันทึกข้อมูลและเปิดโต๊ะเรียบร้อย.", "Message Alert", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Save Data & Open table complete.", "Message Alert", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                    Confirm_sendOrder = False
                    index.CloseForm()
                    home1.Change_Tb = False
                    index.Gohome = False
                    index.ReservationP = False
                    index.Add_order = False
                    home1.MdiParent = index
                    home1.Show()
                    home1.WindowState = FormWindowState.Minimized
                    home1.WindowState = FormWindowState.Maximized
                    Login.OpenId = ""
                    opentakehome.SendOrder1 = "0"
                    Login.Formname = "home1"
                    clearData()
                End If
            End If
        Else
            If MessageBox.Show("คุณมั่นใจใช่ไหมที่จะเปิดโต๊ะนี้?", "Alert Comfirm open Table?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                AddCoverTable(TextBox_Prs.Text, txt_child.Text, txt_cover.Text, "", "", Login.OpenId, "0")
                con.mysql_query("UPDATE pos_table_system SET status='2',remark_tb='" & TextBox_Comment.Text & "' WHERE id='" & Login.OpenId & "'")
                Me.Close()
                home1.MdiParent = index
                home1.Show()
                home1.WindowState = FormWindowState.Minimized
                home1.WindowState = FormWindowState.Maximized
                Login.OpenId = ""
            Else
                MessageBox.Show("กรุณาเลือกสินค้าด้วยค่ะ", "ข้อความแจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If



        End If
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
    Public Function cutStock(ByVal id_prd, ByVal id_prd_con, ByVal amt)
        Dim tf As Boolean = False
        'Check IS Product Not on Table is = 0
        Dim ck As Integer = con.mysql_num_rows(con.mysql_query("SELECT id_status_table from pos_product where id='" & id_prd & "' and  id_status_table='0' "))
        If ck > 0 Then
            'Check Have in PRD Condition ?
            Dim nu As Integer = con.mysql_num_rows(con.mysql_query("SELECT * FROM pos_product_condition WHERE id='" & id_prd_con & "' and ref_id_prd='" & id_prd & "' and ref_id_ingredients='0' and ref_id_unit>'0'"))
            Dim num As Integer = 0
            If nu > 0 Then
                Dim res_prd_con As MySqlDataReader = con.mysql_query("SELECT * FROM pos_product_condition WHERE id='" & id_prd_con & "' and ref_id_prd='" & id_prd & "' and ref_id_ingredients='0' and ref_id_unit>'0'")
                res_prd_con.Read()
                'UPDATE DATA amount new pos_product_condition
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
                con.mysql_query("UPDATE pos_product_condition SET amount='" & CInt(res_prd_con.GetString("amount")) + CInt(amt) & "' WHERE id='" & id_prd_con & "' and ref_id_prd='" & id_prd & "' and ref_id_ingredients='0' and ref_id_unit>'0'")
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
                Dim res_prd1 As MySqlDataReader = con.mysql_query("SELECT * FROM pos_product WHERE id='" & id_prd & "'")
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
    Public p() As Process
    Private Sub TextBox_Comment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox_Comment.Click
        ' p = Process.GetProcessesByName("osk")
        'If p.Count > 0 Then
        '    ' Process is running
        '    Array.ForEach(p, Sub(p1 As Process) p1.Kill())
        '    System.Diagnostics.Process.Start("osk.exe")
        'Else
        '    ' Process is not running
        '    System.Diagnostics.Process.Start("osk.exe")
        'End If
    End Sub
    Private Sub btn_add_other_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_add_other.Click
        opentable_add_other.page = "opentable"
        opentable_add_other.ShowDialog()
    End Sub
    Public Function Get_printer_subgroup(ByVal idsubcat)
        Dim objReader As New System.IO.StreamReader("printer_sg.txt", Encoding.UTF8)
        Dim TextLine() As String
        Dim p As String = ""
        'โหลดข้อมูล Tabspage2
        Do While objReader.Peek() <> -1
            TextLine = objReader.ReadLine().ToString.Trim.Split("=")
            If idsubcat = TextLine(0).ToString.Trim Then
                p = TextLine(1).ToString
            End If
        Loop
        objReader.Close()
        Return p
    End Function
    Public Function Get_CopySendcaptain_subgroup(ByVal idsubcat)
        Dim objReader As New System.IO.StreamReader("printer_sg.txt", Encoding.UTF8)
        Dim TextLine() As String
        Dim p As String = ""
        'โหลดข้อมูล Tabspage2
        Do While objReader.Peek() <> -1
            TextLine = objReader.ReadLine().ToString.Trim.Split("=")
            If idsubcat = TextLine(0).ToString.Trim Then
                p = TextLine(2).ToString
            End If
        Loop
        objReader.Close()
        Return p
    End Function
    Public Function Get_printer_ONOFF_subgroup(ByVal idsubcat)
        Dim objReader As New System.IO.StreamReader("printer_sg.txt", Encoding.UTF8)
        Dim TextLine() As String
        Dim p As String = ""
        'โหลดข้อมูล Tabspage2
        Do While objReader.Peek() <> -1
            TextLine = objReader.ReadLine().ToString.Trim.Split("=")
            If idsubcat = TextLine(0).ToString.Trim Then
                p = TextLine(3).ToString
            End If
        Loop
        objReader.Close()
        Return p
    End Function

    Private Sub txt_child_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_child.Click
        keyborad_number.text1 = "txt_child"
        keyborad_number.ShowDialog()
        AddCoverTable(TextBox_Prs.Text, txt_child.Text, txt_cover.Text, txt_roomnum.Tag.ToString, txt_roomnum.Text, Login.OpenId, "0")
    End Sub

    Private Sub txt_cover_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_cover.Click
        keyborad_number.text1 = "txt_cover"
        keyborad_number.ShowDialog()
        AddCoverTable(TextBox_Prs.Text, txt_child.Text, txt_cover.Text, txt_roomnum.Tag.ToString, txt_roomnum.Text, Login.OpenId, "0")
    End Sub
    Public Function AddCoverTable(ByVal adult, ByVal child, ByVal cover, ByVal id_room, ByVal room_number, ByVal rf_id_table, ByVal rf_id_invoice_temp)
        Dim h As Boolean = False
        Dim str As String = ""
        Dim ck As Integer = con.mysql_num_rows(con.mysql_query("select * from pos_order_list_prs where rf_id_table='" & rf_id_table & "';"))
        If ck > 0 Then
            str &= "UPDATE pos_order_list_prs SET adult='" & adult & "',child='" & child & "',cover='" & cover & "',id_room='" & id_room & "',room_number='" & room_number & "',update_by='" & Login.username & "',rf_id_invoice_temp='" & rf_id_invoice_temp & "' WHERE rf_id_table='" & rf_id_table & "'; "
        Else
            str &= "INSERT INTO pos_order_list_prs (id_prs,adult,child,cover,id_room,room_number,update_by,rf_id_table) VALUES("
            str &= "'','" & adult & "','" & child & "','" & cover & "','" & id_room & "','" & room_number & "','" & Login.username & "','" & rf_id_table & "');"
        End If

        If str <> "" Then
            h = con.mysql_query(str)
        End If
        Return h
    End Function
    Public Sub ShowCover(ByVal rf_id_table, ByVal txt_adult, ByVal txt_child, ByVal txt_cover, ByVal txt_room, ByVal txt_remark)
        Dim j As Integer = con.mysql_num_rows(con.mysql_query("SELECT * FROM pos_order_list_prs WHERE rf_id_table='" & rf_id_table & "'"))
        If j > 0 Then

            Dim k As MySqlDataReader = con.mysql_query("SELECT * FROM pos_order_list_prs WHERE rf_id_table='" & rf_id_table & "'")
            Dim txt_adult1 As TextBox = CType(txt_adult, TextBox)
            Dim txt_child1 As TextBox = CType(txt_child, TextBox)
            Dim txt_cover1 As TextBox = CType(txt_cover, TextBox)
            ' If txt_room <> "" Then
            Dim txt_room1 As TextBox = CType(txt_room, TextBox)
            ' End If


            While k.Read()
                txt_adult1.Text = k.GetString("adult")
                txt_child1.Text = k.GetString("child")
                txt_cover1.Text = k.GetString("cover")
                ' If txt_room <> "" Then
                txt_room1.Text = k.GetString("room_number")
                txt_room1.Tag = k.GetString("id_room")
                '  End If

            End While
        End If
        Dim h As Integer = con.mysql_num_rows(con.mysql_query("select remark_tb from pos_table_system where id='" & rf_id_table & "';"))
        If h > 0 Then
            Dim txt_remark1 As TextBox = CType(txt_remark, TextBox)
            Dim v As MySqlDataReader = con.mysql_query("select remark_tb as remark_tb from pos_table_system where id='" & rf_id_table & "';")
            While v.Read
                txt_remark1.Text = v.GetString("remark_tb")
            End While
        End If

    End Sub
   

    Private Sub txt_roomnum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_roomnum.Click
        inroom.page = "opentable"
        inroom.ShowDialog()
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        txt_roomnum.Text = ""
        AddCoverTable(TextBox_Prs.Text, txt_child.Text, txt_cover.Text, "", "", Login.OpenId, "0")
    End Sub
    Public Function AddRemarkTable(ByVal rf_id_table, ByVal remark)
        Dim h As Boolean = False
        Dim str As String = ""
        str &= "UPDATE pos_table_system SET remark_tb='" & remark & "' WHERE id='" & rf_id_table & "'; "
      
        If str <> "" Then
            h = con.mysql_query(str)
            MsgBox("Save complete.", MsgBoxStyle.Information)
        End If
        Return h
    End Function

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        AddRemarkTable(Login.OpenId, TextBox_Comment.Text)
    End Sub

   
End Class