Imports MySql.Data.MySqlClient
Imports System
Imports System.IO
Imports System.Text
Public Class Admin_addPrdList
    Dim con As New Mysql
    Public id_prd_edit As Integer
    Private Sub Admin_addPrdList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        load_cat()
        load_subcat()
        load_ontb()
        loadData_PrdListAll()
    End Sub
    Public Sub loadData_PrdListAll()

        id_prd_edit = 0
        Dim res1 As MySqlDataReader
        ListView_PRD.Items.Clear()
        Dim SQLStr As String = "select *,IFNULL(pos_catprd.namecat_en,'-') AS namecat_en1,IFNULL(pos_catsubprd.name_en,'-') AS sname_en," _
    & "IFNULL(pos_product_unit.name_en,'-') AS uname_en from pos_product " _
    & " LEFT JOIN pos_catprd ON pos_catprd.id=pos_product.ref__id_catprd " _
    & " LEFT JOIN pos_catsubprd ON pos_catsubprd.id=pos_product.ref__id_catsubprd" _
    & " LEFT JOIN pos_product_unit ON pos_product_unit.id=pos_product.ref_unit" _
    & " LEFT JOIN pos_product_condition ON pos_product_condition.ref_id_prd = pos_product.id" _
    & "  WHERE pos_product.id_status_sales <> '2' GROUP BY  pos_product.id order by pos_product.id DESC"
        Dim str As String = ""
        Dim itmx As New ListViewItem
        res1 = con.mysql_query(SQLStr)
        Dim y As Integer = 1
        Dim status As String = ""
        Dim status_tb As String = ""
        ' Dim strs(3) As String
        ' Dim itm As ListViewItem
        While res1.Read()
            Dim myCheckbox As New CheckBox
            myCheckbox.Text = ""
            myCheckbox.Checked = False

            itmx = ListView_PRD.Items.Add(res1.GetString("id"), y)
            itmx.SubItems.Add("")
            itmx.SubItems.Add(y.ToString)
            itmx.SubItems.Add(res1.GetString("namecat_en1"))
            itmx.SubItems.Add(res1.GetString("sname_en"))
            itmx.SubItems.Add(res1.GetString("number_prd"))
            itmx.SubItems.Add(res1.GetString("nameprd_th"))
            itmx.SubItems.Add(res1.GetString("nameprd_en"))
            itmx.SubItems.Add(res1.GetString("uname_en"))
            itmx.SubItems.Add(res1.GetString("price"))
            If res1.GetString("id_status_sales") = "0" Then
                status = "Off"
            ElseIf res1.GetString("id_status_sales") = "1" Then
                status = "on"
            Else
                status = "Del"
                itmx.ForeColor = Color.Gray
            End If
            itmx.SubItems.Add(status)
            If res1.GetString("id_status_table") = "0" Then
                status_tb = "Off"
            Else
                status_tb = "On"
            End If
            itmx.SubItems.Add(status_tb)
            y += 1
        End While

        'itm = New ListViewItem(strs)
        'ListView_PRD.Items.Add(itm)
        For i As Integer = 0 To ListView_PRD.Items.Count - 1
            If i Mod 2 Then
                ListView_PRD.Items(i).BackColor = Color.AliceBlue
            Else
                ListView_PRD.Items(i).BackColor = Color.White
            End If
        Next
       
    End Sub

    Public Sub loadData_PrdList()
        Dim index As Integer = text_filter.Text.IndexOf("'")
        If index > -1 Then

        Else
            'ToolStrip_Menu.Hide()
            id_prd_edit = 0
            Dim res As MySqlDataReader

            Dim SQLStr As String = "select *,IFNULL(pos_catprd.namecat_en,'-') AS namecat_en1,IFNULL(pos_catsubprd.name_en,'-') AS sname_en,IFNULL(pos_product_unit.name_en,'-') AS uname_en from ((pos_product"
            SQLStr += " LEFT JOIN pos_catprd ON pos_catprd.id=pos_product.ref__id_catprd) "
            SQLStr += " LEFT JOIN pos_catsubprd ON pos_catsubprd.id=pos_product.ref__id_catsubprd) "
            SQLStr += " LEFT JOIN pos_product_unit ON pos_product_unit.id=pos_product.ref_unit   "
            If text_filter.Text <> "" Or category_filter.SelectedValue <> "0" Or ontb_filter.SelectedValue <> "2" Or status_filter.SelectedValue <> "2" Then
                SQLStr += "where pos_product.id>0  and pos_product.id_status_sales <> '2'"
            End If
            If text_filter.Text <> "" Then
                SQLStr += " and (nameprd_en LIKE '%" & text_filter.Text & "%' or nameprd_th LIKE '%" & text_filter.Text & "%' or number_prd LIKE '%" & text_filter.Text & "%')"
            End If
            If category_filter.SelectedValue <> "0" Then
                SQLStr += " and pos_product.ref__id_catprd='" & category_filter.SelectedValue & "'"
            End If
            If Me.subgroup_filter.SelectedValue <> "0" Then
                SQLStr += " and pos_product.ref__id_catsubprd='" & subgroup_filter.SelectedValue & "'"
            End If
            If Me.ontb_filter.SelectedValue <> "2" Then
                SQLStr += " and pos_product.id_status_table='" & ontb_filter.SelectedValue & "'"
            End If
            If Me.status_filter.SelectedValue <> "2" Then
                SQLStr += " and pos_product.id_status_sales='" & status_filter.SelectedValue & "'"
            End If
            SQLStr += " order by pos_product.id DESC"
           
            ListView_PRD.Items.Clear()
            Dim str As String = ""
            Dim itmx As New ListViewItem
            res = con.mysql_query(SQLStr)
            Dim y As Integer = 1
            Dim status As String = ""
            Dim status_tb As String = ""

            While res.Read()

                itmx = ListView_PRD.Items.Add(res.GetString("id"), y)
                itmx.SubItems.Add("")
                itmx.SubItems.Add(y.ToString)
                itmx.SubItems.Add(res.GetString("namecat_en1"))
                itmx.SubItems.Add(res.GetString("sname_en"))
                itmx.SubItems.Add(res.GetString("number_prd"))
                itmx.SubItems.Add(res.GetString("nameprd_th"))
                itmx.SubItems.Add(res.GetString("nameprd_en"))
                itmx.SubItems.Add(res.GetString("uname_en"))
                itmx.SubItems.Add(res.GetString("price"))
                If res.GetString("id_status_sales") = "0" Then
                    status = "OFF"
                Else
                    status = "ON"
                End If
                itmx.SubItems.Add(status)
                If res.GetString("id_status_table") = "0" Then
                    status_tb = "OFF"
                Else
                    status_tb = "ON"
                End If
                itmx.SubItems.Add(status_tb)
                If res.GetString("id_status_sales") = "2" Then
                    itmx.ForeColor = Color.Gray
                End If
                y += 1
            End While

            For i As Integer = 0 To ListView_PRD.Items.Count - 1
                If i Mod 2 Then
                    ListView_PRD.Items(i).BackColor = Color.AliceBlue
                Else
                    ListView_PRD.Items(i).BackColor = Color.White
                End If
            Next
        End If
    End Sub

    Public Function Get_namegroup(ByVal id)
        Dim res2 As MySqlDataReader
        Dim Str As String = ""
        res2 = con.mysql_query("SELECT * from pos_catprd where id='" & id & "'")
        While res2.Read()
            If res2.GetString("namecat_en") = "" Then
                Str = res2.GetString("namecat_th")
            Else
                Str = res2.GetString("namecat_en")
            End If
        End While
        Return Str
        res2.Close()
    End Function

    Public Function Get_nameSubgroup(ByVal id)
        Dim res_getN As MySqlDataReader
        Dim Str As String = ""
        res_getN = con.mysql_query("select * from pos_catsubprd where id='" & id & "' ")
        While res_getN.Read()
            If res_getN.GetString("name_en") = "" Then
                Str = res_getN.GetString("name_th")
            Else
                Str = res_getN.GetString("name_en")
            End If
        End While
        Return Str

    End Function

    Public Function Get_nameUnit(ByVal id)
        Dim res_get_Nunit As MySqlDataReader
        Dim Str As String = ""
        res_get_Nunit = con.mysql_query("select * from pos_product_unit where id='" & id & "'")
        While res_get_Nunit.Read()
            If res_get_Nunit.GetString("name_en") = "" Then
                Str = res_get_Nunit.GetString("name_th")
            Else
                Str = res_get_Nunit.GetString("name_en")
            End If
        End While
        Return Str

    End Function

    Public Sub load_cat()
        Dim res_cat As MySqlDataReader
        res_cat = con.mysql_query("select * from  pos_catprd where id_status_sales<>'2' order by namecat_en asc")
        Dim cboItemsFl As New List(Of cboItem)
        Dim txt As String = ""
        cboItemsFl.Add(New cboItem With {.Text = "All", .Value = 0})
        While res_cat.Read
            If res_cat.GetString("namecat_en") = "" Then
                txt = res_cat.GetString("namecat_th")
            Else
                txt = res_cat.GetString("namecat_en")
            End If
            cboItemsFl.Add(New cboItem With {.Text = txt, .Value = res_cat.GetString("id")})
        End While
        res_cat.Close()
        With Me.category_filter
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .DataSource = cboItemsFl
        End With

        If category_filter.Items.Count > 0 Then
            category_filter.SelectedIndex = 0
        End If

    End Sub
    Public Sub load_subcat()
        Dim id_cat As String = category_filter.SelectedValue
        Dim str1 As String = "select * from pos_catsubprd where id_status_sales<>'2' "
        If id_cat = 0 Then
        Else
            str1 += " and ref_id_cat='" & id_cat & "'"
        End If
        str1 += " order by id_subcat asc"
        Dim res_subcat As MySqlDataReader
        res_subcat = con.mysql_query(str1)
        Dim cboItemsFl As New List(Of cboItem)
        Dim txt As String = ""
        cboItemsFl.Add(New cboItem With {.Text = "All", .Value = 0})
        While res_subcat.Read
            If res_subcat.GetString("name_en") = "" Then
                txt = res_subcat.GetString("name_th") & "(" & res_subcat.GetString("name_en") & ")"
            Else
                txt = res_subcat.GetString("name_en") & "(" & res_subcat.GetString("name_th") & ")"
            End If
            cboItemsFl.Add(New cboItem With {.Text = txt, .Value = res_subcat.GetString("id")})
        End While
        res_subcat.Close()
        With Me.subgroup_filter
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .DataSource = cboItemsFl
        End With

        If subgroup_filter.Items.Count > 0 Then
            subgroup_filter.SelectedIndex = 0
        End If
    End Sub
    Public Sub load_ontb()
        Dim cboItemsF2 As New List(Of cboItem)
        cboItemsF2.Add(New cboItem With {.Text = "All", .Value = 2})
        cboItemsF2.Add(New cboItem With {.Text = "On", .Value = 1})
        cboItemsF2.Add(New cboItem With {.Text = "Off", .Value = 0})

        With Me.ontb_filter
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .DataSource = cboItemsF2
        End With
        If ontb_filter.Items.Count > 0 Then
            ontb_filter.SelectedIndex = 0
        End If
        Dim cboItemsF3 As New List(Of cboItem)
        cboItemsF3.Add(New cboItem With {.Text = "All", .Value = 2})
        cboItemsF3.Add(New cboItem With {.Text = "On", .Value = 1})
        cboItemsF3.Add(New cboItem With {.Text = "Off", .Value = 0})

        With Me.status_filter
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .DataSource = cboItemsF3
        End With
        If status_filter.Items.Count > 0 Then
            status_filter.SelectedIndex = 0
        End If
    End Sub
    Public Sub delete_data()
        Dim query_condition As Boolean
        Dim query_prd As Boolean
        Dim res_del As MySqlDataReader
        If ListView_PRD.SelectedItems.Count > 0 Then
            Dim result = MessageBox.Show("Are you sure delete " & ListView_PRD.Items(ListView_PRD.FocusedItem.Index).SubItems(6).Text & " ?", "Delete Product", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                If id_prd_edit > 0 Then
                    query_condition = con.mysql_query("DELETE FROM pos_product_condition WHERE ref_id_prd='" & id_prd_edit & "'")
                    res_del = con.mysql_query("select * from pos_product where id='" & id_prd_edit & "'")
                    Dim pathfile As String = ""
                    Dim objReader As New System.IO.StreamReader("active_fol.bat", Encoding.UTF8)
                    Dim TextLine() As String
                    Do While objReader.Peek() <> -1
                        TextLine = objReader.ReadLine().ToString.Trim.Split("=")
                        If "folderProduct" = TextLine(0).ToString.Trim Then
                            pathfile = TextLine(1).ToString
                        End If
                    Loop
                    objReader.Close()
                    While res_del.Read()
                        If res_del.GetString("name_img") <> "none" And res_del.GetString("name_img") <> "" Then
                            File.Delete(pathfile & res_del.GetString("name_img").ToString) 'delete images old
                        End If
                    End While
                    query_prd = con.mysql_query("UPDATE pos_product SET id_status_sales='2' WHERE id='" & id_prd_edit & "';")
                    'query_prd = con.mysql_query("DELETE FROM pos_product WHERE id='" & id_prd_edit & "'")
                    If query_prd = True Then
                        MessageBox.Show("Delete Product Complete", "Message Alert")
                        loadData_PrdList()
                        'ToolStrip_Menu.Visible = False
                    Else
                        MessageBox.Show("Error Delete Product....!", "Message Alert")
                        loadData_PrdList()
                        'ToolStrip_Menu.Visible = False
                    End If
                End If
            ElseIf result = DialogResult.No Then
                loadData_PrdListAll()
            End If
        Else
            MsgBox("กรุณษเลือกรายการที่ต้องการลบด้วยค่ะ")
        End If
    End Sub

    Private Sub btn_addprd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_addprd.Click
        Admin_addPrd.ShowDialog()
    End Sub
    Private Sub btn_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_close.Click
        Me.Close()
    End Sub
    Private Sub btn_reload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_reload.Click
        loadData_PrdList()
    End Sub
    Private Sub btn_filter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_filter.Click
        loadData_PrdList()
    End Sub
    Private Sub ListView_PRD_DoubleClick1(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView_PRD.DoubleClick, btn_edit.Click
        If ListView_PRD.SelectedItems.Count > 0 Then
            id_prd_edit = ListView_PRD.Items(ListView_PRD.FocusedItem.Index).SubItems(0).Text
            Dim ins As Integer = con.mysql_num_rows(con.mysql_query("select id_status_sales from pos_product where id='" & id_prd_edit & "' and id_status_sales='2';"))
            If ins > 0 Then
            Else
                Admin_editPrd.ShowDialog()
            End If

        End If
    End Sub

    Private Sub ListView_PRD_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView_PRD.MouseClick
        If e.Button = MouseButtons.Left Then
            id_prd_edit = ListView_PRD.Items(ListView_PRD.FocusedItem.Index).SubItems(0).Text
            ' ToolStrip_Menu.Show()
            Dim ins As Integer = con.mysql_num_rows(con.mysql_query("select id_status_sales from pos_product where id='" & id_prd_edit & "' and id_status_sales='2';"))
            If ins > 0 Then
                btn_del.Enabled = False
                btn_edit.Enabled = False
            Else
                btn_del.Enabled = True
                btn_edit.Enabled = True
            End If
        End If
    End Sub
    Private Sub btn_del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_del.Click
        If ListView_PRD.SelectedItems.Count > 0 Then
            If id_prd_edit.ToString <> "" Or CInt(id_prd_edit.ToString) > 0 Then
                delete_data()
            End If
        End If  
    End Sub
    Private Sub text_filter_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles text_filter.TextChanged
        loadData_PrdList()
    End Sub
  
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Admin_ReportInputParameter4.NameFileReport = "product_list"
        Admin_ReportInputParameter4.ServerPathFile = ""
        Admin_ReportInputParameter4.page = "product"
        Admin_ReportInputParameter4.ShowDialog()
        
    End Sub

    Private Sub category_filter_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles category_filter.SelectedIndexChanged
        load_subcat()
        loadData_PrdList()
    End Sub

    Private Sub subgroup_filter_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles subgroup_filter.SelectedIndexChanged
        loadData_PrdList()
    End Sub

    Private Sub ontb_filter_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ontb_filter.SelectedIndexChanged
        loadData_PrdList()
    End Sub

    Private Sub status_filter_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles status_filter.SelectedIndexChanged
        loadData_PrdList()
    End Sub
End Class