Imports MySql.Data.MySqlClient
Imports System
Imports System.IO
Imports System.Text
Public Class Admin_addPrd
    Dim con As New Mysql
    Dim ac As New Admin_ClassMain
    ' variable set on/off sale
    Dim arr_OnTb As String = "0"
    Dim arr_OnSales As String = "0"
    Public x As Integer = 0
    Public y As Integer = 0
    ' variable upload file product
    Dim name_img As String
    Dim images_prd As String
    Dim taype_img As String
    Dim pathname As String

    'set array condition 
    Public arr_indre As New ArrayList
    Public arr_size As New ArrayList
    Public arr_price As New ArrayList
    Public arr_MGroup As New ArrayList
    Public arr_amount As New ArrayList
    Public arr_barcode As New ArrayList


    Private Sub Admin_addPrd_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        con.mysql_close()
    End Sub

    Private Sub Admin_addPrd_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        con.mysql_close()
    End Sub

    Private Sub Admin_addPrd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        load_cat() 'Load cat data show 
        GroupBox2.Hide()
        Check_OnTB() ' Check OB Table in DB
        setLableTB() ' Lable show Yes,No.
        loadData_Indre()
        loadData_unit()
        load_PrdType()
    End Sub
    Public Sub load_cat()
        Dim res_cat As MySqlDataReader
        res_cat = con.mysql_query("select * from  pos_catprd where id_status_sales<>'2' order by namecat_en asc")
        Dim cboItemsFl As New List(Of cboItem)
        Dim txt As String = ""
        While res_cat.Read
            If res_cat.GetString("namecat_en") = "" Then
                txt = res_cat.GetString("namecat_th")
            Else
                txt = res_cat.GetString("namecat_en")
            End If
            cboItemsFl.Add(New cboItem With {.Text = txt, .Value = res_cat.GetString("id")})
        End While

        With Me.ComboBox_Cat
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .DataSource = cboItemsFl
        End With

        If ComboBox_Cat.Items.Count > 0 Then
            ComboBox_Cat.SelectedIndex = 0
        End If
        res_cat.Close()
    End Sub
    Public Sub load_PrdType()
        Dim res_cat As MySqlDataReader
        res_cat = con.mysql_query("select * from  pos_product_type order by t_prd_id asc")
        Dim cboItemsFl As New List(Of cboItem)
        Dim txt As String = ""
        While res_cat.Read
            If res_cat.GetString("t_name_en") <> "" Then
                txt = res_cat.GetString("t_name_en")
            Else
                txt = res_cat.GetString("t_name_th")
            End If
            cboItemsFl.Add(New cboItem With {.Text = txt, .Value = res_cat.GetString("t_prd_id")})
        End While

        With Me.ComboBox_PrdType
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .DataSource = cboItemsFl
        End With

        If ComboBox_PrdType.Items.Count > 0 Then
            ComboBox_PrdType.SelectedIndex = 0
        End If
        res_cat.Close()
    End Sub
    Public Sub clearForm()
        txtBoxIDprd.Text = ""
        txtBoxNameprd_th.Text = ""
        txtBoxNameprd_en.Text = ""
        txtBoxNameprd_comment.Text = ""
        txtBoxPrice.Text = "0"
        txtBoxUnit.Text = ""
        txtBoxNumSales.Text = "0"
        If txtBoxUnit.Items.Count > 0 Then
            txtBoxUnit.SelectedIndex = 0
        End If
        PicImgBox.Image = Nothing
        arr_indre.Clear()
        arr_price.Clear()
        arr_size.Clear()
        arr_amount.Clear()
        arr_barcode.Clear()
        If ListView_Condition.Items.Count > 0 Then
            ListView_Condition.Items.Clear()
        End If
        If ListView1.Items.Count > 0 Then
            ListView1.Items.Clear()
        End If
        If ComboBox_Cat.Items.Count > 0 Then
            ComboBox_Cat.SelectedIndex = 0
        End If
        If ComboBox_SubCat.Items.Count > 0 Then
            ComboBox_SubCat.SelectedIndex = 0
        End If
    End Sub
    Public Sub SetOn_Sales()
        btnSalesOpen.BackColor = Color.LimeGreen
        btnSalesOff.BackColor = Color.DarkGray
        arr_OnSales = "1"
    End Sub
    Public Sub SetOff_Sales()
        btnSalesOpen.BackColor = Color.DarkGray
        btnSalesOff.BackColor = Color.Red
        arr_OnSales = "0"
    End Sub
   
    Private Sub btnSalesOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalesOpen.Click
        SetOn_Sales()
    End Sub
    Private Sub btnSalesOff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalesOff.Click
        SetOff_Sales()
    End Sub
    Private Sub btn_calcle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_calcle.Click
        clearForm()
        Me.Close()
    End Sub
    Private Sub btn_reset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_reset.Click
        clearForm()
    End Sub
    Private Sub ComboBox_Cat_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox_Cat.SelectedIndexChanged
        loadDataSubCat()
        loadData_size()
        Check_OnTB()
        setLableTB()
    End Sub

    Public Sub loadDataSubCat()
        'Clear Array Data
        arr_indre.Clear()
        arr_price.Clear()
        arr_size.Clear()
        arr_MGroup.Clear()
        Dim res_subcat As MySqlDataReader
        Dim id_cat As Integer = ComboBox_Cat.SelectedValue.ToString()
        res_subcat = con.mysql_query("select * from pos_catsubprd where ref_id_cat='" & id_cat & "' and id_status_sales<>'2' order by name_en asc")
        Dim cboItemsF2 As New List(Of cboItem)
        While res_subcat.Read()
            cboItemsF2.Add(New cboItem With {.Text = res_subcat.GetString("name_en"), .Value = res_subcat.GetString("id")})
            arr_OnTb = res_subcat.GetString("id_status_table")
        End While

        With Me.ComboBox_SubCat
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .DataSource = cboItemsF2
        End With

        If ComboBox_SubCat.Items.Count > 0 Then
            ComboBox_SubCat.SelectedIndex = 0
        End If
        res_subcat.Close()
    End Sub
    Public Sub loadData_size()
        '   Dim res_size As MySqlDataReader
        ' res_size = con.mysql_query("select * from pos_product_size order by name_en asc")
        '  Dim cboItemsF3 As New List(Of cboItem)
        '  Dim txt1 As String = ""
        '  While res_size.Read()
        'If res_size.GetString("name_en") = "" Then
        'txt1 = res_size.GetString("name_th")
        'Else
        'txt1 = res_size.GetString("name_en")
        ' End If
        ' cboItemsF3.Add(New cboItem With {.Text = txt1, .Value = res_size.GetString("id")})
        ' End While

        ' With Me.ComboBox_Unit
        '.DisplayMember = "Text"
        ' .ValueMember = "Value"
        ' .DataSource = cboItemsF3
        ' End With

        ' If ComboBox_Unit.Items.Count > 0 Then
        'ComboBox_Unit.SelectedIndex = 0
        ' End If
        ' res_size.Close()
    End Sub
    Public Sub Check_OnTB()
        Dim res_chkTB As MySqlDataReader
        Dim id_cat As Integer = ComboBox_Cat.SelectedValue.ToString()
        res_chkTB = con.mysql_query("select * from pos_catprd where id='" & id_cat & "' limit 1")
        While res_chkTB.Read
            arr_OnTb = res_chkTB.GetString("id_status_table")
        End While
        res_chkTB.Close()
        If arr_OnTb = "1" Then
            GroupBox2.Show()
            Panel_Price.Hide()
            Admin_addPrdCon.Panel12.Show()
            Admin_addPrdCon.Panel13.Hide()
            GroupBox5.Hide()
        Else
            Panel_Price.Show()
            GroupBox2.Hide()
            Admin_addPrdCon.Panel12.Hide()
            Admin_addPrdCon.Panel13.Show()
            GroupBox5.Show()
        End If
    End Sub
    Public Sub setLableTB()
        If arr_OnTb = "1" Then
            Label_OnTB.Text = "No."
        Else
            Label_OnTB.Text = "Yes."
        End If
    End Sub
    Public Sub loadData_Indre()
        '  Dim res_indre As MySqlDataReader
        'Dim cboItemsF3 As New List(Of cboItem)
        ' res_indre = con.mysql_query("select * from pos_product_ingredients")
        ' While res_indre.Read
        '     CheckedListBox1.Items.Add(res_indre.GetString("name_en"))
        ' End While
        ' res_indre.Close()
    End Sub

    Private Sub btn_search_indre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Admin_addPrd_Condit.ShowDialog() 'show form indregent
    End Sub


    Private Sub btn_add_condition_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_add_condition.Click
        ' add_condition() 'load data condition all
        'clearFormCon() 'load funtion clear form condition price
        Admin_addPrdCon.Page = "add"
        Admin_addPrdCon.ShowDialog()
    End Sub

    Public Sub add_condition()
        ' Dim itmx As New ListViewItem
        ' Dim str As String = ""
        ' Dim str1 As String = ""
        ' Dim cout As Integer = 0
        ' y += 1
        ' Dim cc As String = arr_indre.Count.ToString
        '  itmx = ListView_Condition.Items.Add(cc, CInt(y))
        ' For i As Integer = 0 To CheckedListBox1.Items.Count - 1
        'If CheckedListBox1.GetItemChecked(i) = True Then
        'arr_MGroup.Add(cc)
        ' arr_indre.Add(CheckedListBox1.Items.Item(i).ToString)
        ' arr_price.Add(txtBox_priceCon.Text)
        ' arr_size.Add(get_id("pos_product_size", "name_th", "name_en", ComboBox_Unit.Text))
        ' If cout > 0 Then
        '     str1 = ","
        ' Else
        'str1 = ""
        ' End If
        ' Str += str1 + CheckedListBox1.Items.Item(i).ToString
        ' cout += 1

        'End If
        ' Next
        ' itmx.SubItems.Add(Str)
        ' itmx.SubItems.Add(ComboBox_Unit.Text)
        ' itmx.SubItems.Add(txtBox_priceCon.Text)

    End Sub

    Private Sub btn_del_con_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_del_con.Click
        Try
            If ListView_Condition.SelectedItems.Count > 0 Then
                Dim count_arr As String
                Dim str_now As String()
                count_arr = ListView_Condition.Items(ListView_Condition.FocusedItem.Index).SubItems(0).Text()
                str_now = ListView_Condition.Items(ListView_Condition.FocusedItem.Index).SubItems(1).Text().Split(New Char() {","c})

                For i As Integer = CInt(count_arr) To CInt(count_arr) + str_now.Count - 1
                    If arr_OnTb = "1" Then
                        arr_indre(i) = ""
                        arr_price(i) = ""
                        arr_MGroup(i) = ""
                        arr_size(i) = ""
                    Else
                        arr_price(i) = ""
                        arr_MGroup(i) = ""
                        arr_size(i) = ""
                    End If
                Next
                ListView_Condition.Items.RemoveAt(ListView_Condition.SelectedIndices(0))
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub txtBoxPrice_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBoxPrice.TextChanged
        checkIsNumeric(txtBoxPrice.Text, txtBoxPrice)
    End Sub

    Private Sub txtBox_priceCon_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'checkIsNumeric(txtBox_priceCon.Text, txtBox_priceCon)
    End Sub
    Private Sub txtBoxNumSales_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        checkIsNumeric(txtBoxNumSales.Text, txtBoxNumSales)
    End Sub
    Public Sub checkIsNumeric(ByVal num, ByVal param)
        If IsNumeric(num) = False Then
            param.Focus()
            param.text = "0"
        End If
    End Sub

    Private Sub btnImgPrd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImgPrd.Click
        Dim OpenFileDialog1 As New OpenFileDialog
        OpenFileDialog1.Filter = "Picture Files (*)|*.bmp;*.gif;*.jpg;*.png"

        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            PicImgBox.Image = Image.FromFile(OpenFileDialog1.FileName)
            pathname = OpenFileDialog1.FileName
            name_img = OpenFileDialog1.SafeFileName
            taype_img = IO.Path.GetExtension(OpenFileDialog1.FileName)
        End If
    End Sub

    Private Sub btn_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_save.Click
        Try
            Dim res1 As MySqlDataReader
            If txtBoxNameprd_th.Text <> "" And txtBoxNameprd_en.Text <> "" Then
                If btn_save.Text = "Save" Then
                    Dim str_inv As String = ""
                    Dim pic_prd As String = ""
                    If name_img <> "" Then
                        'Upload file images
                        Dim objReader As New System.IO.StreamReader("active_fol.bat", Encoding.UTF8)
                        Dim TextLine() As String
                        Dim fulltextIMG As String = ""
                        Do While objReader.Peek() <> -1
                            TextLine = objReader.ReadLine().ToString.Trim.Split("=")
                            If TextLine(0).ToString.Trim = "folderProduct" Then
                                fulltextIMG &= TextLine(1).ToString.Trim
                            End If
                        Loop

                        Dim prm_nameIMG As String = ""
                        Dim time As DateTime = DateTime.Now
                        pic_prd = txtBoxIDprd.Text & "_" & time.Millisecond & taype_img
                        System.IO.File.Copy(pathname, fulltextIMG & pic_prd)
                    Else
                        pic_prd = "none"
                    End If

                    Dim cat_id As String = ComboBox_Cat.SelectedValue.ToString()
                    Dim subcat_id As String = ComboBox_SubCat.SelectedValue.ToString()
                    Dim unit_id As Integer
                    If txtBoxUnit.SelectedValue.ToString <> "" Then
                        unit_id = CInt(txtBoxUnit.SelectedValue.ToString())
                    Else
                        unit_id = 0
                    End If
                    Dim prd_type_id As Integer
                    If ComboBox_PrdType.SelectedValue.ToString <> "" Then
                        prd_type_id = CInt(ComboBox_PrdType.SelectedValue.ToString())
                    Else
                        prd_type_id = 0
                    End If
                    Dim pt As Boolean = False
                    Dim amount As String = "0"
                    Dim unit_idnew As String = "0"
                    Dim vatstatus As Integer = 0
                    If arr_OnTb = 1 Then
                        amount = 0
                        unit_idnew = 0
                    Else
                        If ListView1.Items.Count > 0 Then
                            txtBoxIDprd.Text = ""
                        Else
                            txtBoxIDprd.Text = txtBoxIDprd.Text
                        End If
                        amount = txtBoxNumSales.Text
                        unit_idnew = unit_id
                    End If

                    If RadioButton1.Checked = True Then
                        vatstatus = 0
                    ElseIf RadioButton2.Checked = True Then
                        vatstatus = 1
                    ElseIf RadioButton3.Checked = True Then
                        vatstatus = 2
                    End If
                    Dim txtBoxNameprd_th_replace As String = txtBoxNameprd_th.Text.Replace("'", "\'")
                    Dim txtBoxNameprd_en_replace As String = txtBoxNameprd_en.Text.Replace("'", "\'")
                    Dim str_q As String = "INSERT INTO pos_product (number_prd,nameprd_th,nameprd_en,create_date,create_by," _
                      & "amount,price,comment,id_status_sales,id_status_table,ref__id_catprd,ref__id_catsubprd,ref_unit,name_img,prd_vatstatus,prd_type_dis) " _
                     & "VALUES('" & txtBoxIDprd.Text & "','" & txtBoxNameprd_th_replace & "','" & txtBoxNameprd_en_replace & "'," _
                     & "'" & ac.dateFormat(Date.Now) & "','" & Login.username & "','" & amount & "','" & txtBoxPrice.Text & "'," _
                      & "'" & txtBoxNameprd_comment.Text & "','" & arr_OnSales & "','" & arr_OnTb & "','" & cat_id & "','" & subcat_id & "'," _
                    & "'" & unit_idnew & "','" & pic_prd & "','" & vatstatus & "','" & prd_type_id & "'" _
                    & ");"
                    'MsgBox(str_q)
                    pt = con.mysql_query(str_q)

                    If pt = True Then
                        'QUESRY ID PRD
                        Dim ref_id_prd As Integer = 0 'ID Prd 
                        res1 = con.mysql_query("select * from pos_product order by id desc limit 1")
                        While res1.Read()
                            ref_id_prd = res1.GetString("id")
                        End While
                        res1.Close()
                        Dim in_bl_c As Boolean = False
                        If arr_OnTb = 1 Then
                            'INSERT CONDITION PRD ON TABLE
                            For i As Integer = 0 To arr_indre.Count - 1
                                If arr_indre(i) <> "" Then
                                    con.mysql_query("INSERT INTO pos_product_condition (ref_id_prd,ref_id_ingredients,ref_id_size,price_condition,group_mark)" _
                                           & " VALUES('" & ref_id_prd & "','" & get_id("pos_product_ingredients", "name_th", "name_en", arr_indre(i).ToString) & "','" & arr_size(i) & "','" & arr_price(i) & "'" _
                                           & ",'" & arr_MGroup(i) & "')")
                                End If
                            Next
                        Else
                            'INSERT CONDITION PRD NOT ON TABLE

                            '==== loop insert database==='
                            For i As Integer = 0 To arr_barcode.Count - 1
                                If arr_amount(i) <> "" Then
                                    in_bl_c = True
                                    con.mysql_query("INSERT INTO pos_product_condition (ref_id_prd,ref_id_ingredients,ref_id_unit,price_condition,group_mark,barcode,amount)" _
                                           & " VALUES('" & ref_id_prd & "','0','" & arr_size(i) & "','" & arr_price(i) & "'" _
                                           & ",'" & arr_MGroup(i) & "','" & arr_barcode(i) & "','" & arr_amount(i) & "')")
                                    Dim c As MySqlDataReader = con.mysql_query("select * from pos_product_condition where ref_id_prd='" & ref_id_prd & "' and ref_id_unit='" & arr_size(i) & "' order by id desc limit 1 ")
                                    c.Read()
                                    Dim id_con As String = c.GetString("id")
                                    c.Close()
                                    Dim nameUnit1 As String = ""
                                    Dim idUnit As String = ""
                                    nameUnit1 = nameUnit(arr_size(i))
                                    idUnit = arr_size(i)
                                    If arr_barcode(i) <> "" Then
                                        str_inv &= "INSERT INTO pos_product_inv (inv_barcode,inv_amount,inv_name_th,inv_name_en," _
                                                & "inv_unit_name,inv_unit_id,inv_prd_id,inv_prd_con) VALUES('" & arr_barcode(i) & "','" & arr_amount(i) & "'," _
                                                & "'" & txtBoxNameprd_th.Text & "','" & txtBoxNameprd_en.Text & "','" & nameUnit1 & "','" & idUnit & "','" & ref_id_prd & "','" & id_con & "');"
                                    End If
                                End If
                            Next
                        End If

                        If in_bl_c = False And arr_OnTb = 0 Then
                            Dim txtBoxNameprd_th_replace1 As String = txtBoxNameprd_th.Text.Replace("'", "\'")
                            Dim txtBoxNameprd_en_replace1 As String = txtBoxNameprd_en.Text.Replace("'", "\'")
                            str_inv &= "INSERT INTO pos_product_inv (inv_barcode,inv_amount,inv_name_th,inv_name_en," _
                            & "inv_unit_name,inv_unit_id,inv_prd_id) VALUES('" & txtBoxIDprd.Text & "','0','" & txtBoxNameprd_th_replace1 & "'," _
                            & "'" & txtBoxNameprd_en_replace1 & "','" & txtBoxUnit.Text & "','" & unit_id & "','" & ref_id_prd & "');"
                        End If

                    End If
                    ' ====== insert barcode update table pos_inv====='
                    If str_inv <> "" Then
                        Dim inv As Boolean = con.mysql_query(str_inv)
                    End If

                    If pt = True Then
                        MessageBox.Show("Save New Product Complete")
                        clearForm()
                        Admin_addPrdCon.clearFormCon()
                        ListView_Condition.Items.Clear()
                        Admin_addPrdList.loadData_PrdList()
                        Me.Close()
                    Else
                        MessageBox.Show("Error add Product Complete")
                        clearForm()
                        Admin_addPrdCon.clearFormCon()
                        ListView_Condition.Items.Clear()
                    End If

                End If
            Else
                MsgBox("กรอกข้อมูลให้ครบถ้วนด้วยค่ะ")
                If txtBoxNameprd_th.Text = "" Then
                    txtBoxNameprd_th.Focus()
                ElseIf txtBoxNameprd_en.Text = "" Then
                    txtBoxNameprd_en.Focus()
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Function nameUnit(ByVal id)
        Dim str As String
        Dim g As MySqlDataReader = con.mysql_query("select name_th as name_th,name_en as name_en from pos_product_unit where id='" & id & "'")
        g.Read()
        If g.GetString("name_th") <> "" Then
            str = g.GetString("name_th")
        Else
            str = g.GetString("name_en")
        End If
        g.Close()
        Return str
    End Function
    Public Function check_unit_id(ByVal item)
        Dim res_unit As MySqlDataReader
        Dim id As Integer
        res_unit = con.mysql_query("select * from pos_product_unit where id='" & item & "'")
        If con.mysql_num_rows(res_unit) > 0 Then
            res_unit = con.mysql_query("select * from pos_product_unit where id = '" & item & "'")
            While res_unit.Read()
                id = res_unit.GetString("id")
            End While
        Else
            id = 0
        End If

        Return id
        res_unit.Close()
    End Function

    Public Function get_id(ByVal type_1, ByVal p1, ByVal p2, ByVal v1)
        Dim res_getID As MySqlDataReader
        Dim id_f As Integer
        res_getID = con.mysql_query("select id from " & type_1 & " where (" & p1 & "='" & v1 & "' or " & p2 & "='" & v1 & "') limit 1")
        While res_getID.Read()
            If res_getID.GetString("id") <> "" And res_getID.GetString("id") <> 0 Then
                id_f = res_getID.GetString("id")
            Else
                id_f = 0
            End If
        End While
        Return id_f
        res_getID.Close()
    End Function
    Public Sub loadData_unit()
        txtBoxUnit.DataSource = Nothing
        txtBoxUnit.Items.Clear()
        txtBoxUnit.Items.Remove(txtBoxUnit.DisplayMember)
        'txtBoxUnit.Items.Clear()

        Dim res_unit1 As MySqlDataReader
        Dim cboItemsF3 As New List(Of cboItem)
        Dim Str As String = ""
        res_unit1 = con.mysql_query("select name_en,name_th,id from pos_product_unit")
        While res_unit1.Read()
            If res_unit1.GetString("name_en") <> "" Then
                Str = res_unit1.GetString("name_en")
            Else
                Str = res_unit1.GetString("name_th")
            End If
            cboItemsF3.Add(New cboItem With {.Text = Str, .Value = res_unit1.GetString("id")})
        End While
        res_unit1.Close()
        With Me.txtBoxUnit
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .DataSource = cboItemsF3
        End With
    End Sub


    Private Sub add_conunit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles add_conunit.Click
        Admin_addPrdCon.Page = "add"
        Admin_addPrdCon.ShowDialog()
    End Sub
    Private Sub del_conunit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles del_conunit.Click
        Try
            If ListView1.SelectedItems.Count > 0 Then
                Dim count_arr As String
                Dim str_now As String()
                count_arr = ListView1.Items(ListView1.FocusedItem.Index).SubItems(0).Text()
                str_now = ListView1.Items(ListView1.FocusedItem.Index).SubItems(1).Text().Split(New Char() {","c})
                For i As Integer = CInt(count_arr) To CInt(count_arr) + str_now.Count - 1
                    If arr_OnTb <> "1" Then
                        arr_price(i) = ""
                        arr_MGroup(i) = ""
                        arr_size(i) = ""
                        arr_amount(i) = ""
                        arr_barcode(i) = ""
                        arr_indre(i) = ""
                    End If
                Next
                ListView1.Items.RemoveAt(ListView1.SelectedIndices(0))
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
    Private Sub txtBoxNumSales_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBoxNumSales.TextChanged
        checkIsNumeric(txtBoxNumSales.Text, txtBoxNumSales)
    End Sub

End Class

Friend Class cboItem
    Public Property Text As String
    Public Property Value As String
End Class