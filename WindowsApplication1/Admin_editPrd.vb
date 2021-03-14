Imports MySql.Data.MySqlClient
Imports System
Imports System.IO
Imports System.Text
Public Class Admin_editPrd
    Dim con As New Mysql
    Dim res As MySqlDataReader
    Dim res1 As MySqlDataReader
    Dim res_indre As MySqlDataReader
    Dim ac As New Admin_ClassMain
    ' variable set on/off sale
    Public arr_OnTb As String = "0"
    Public arr_OnSales As String = "0"
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
    'Data For check Edit
    Dim id_edit As Integer
    Dim id_catedit As Integer
    Dim id_subcatedit As Integer
    Dim id_unitedit As Integer

    Private Sub Admin_editPrd_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        id_edit = 0
        clearForm()
        con.mysql_close()
    End Sub

    Private Sub Admin_editPrd_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        clearForm()
        id_edit = 0
        con.mysql_close()
    End Sub

    Private Sub Admin_editPrd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load     
        loadData_Edit()
        ' load_cat() 'Load cat data show 
        GroupBox2.Hide()
        loadData_Indre()
        '  MsgBox(arr_OnTb)
        Check_OnTB() ' Check OB Table in DB
        setLableTB() ' Lable show Yes,No.
    End Sub
    Public Sub loadData_Edit()
        Dim res_edit As MySqlDataReader
        load_cat()
        loadData_unit()
        loadData_PrdType()
        id_edit = Admin_addPrdList.id_prd_edit.ToString
        res_edit = con.mysql_query("select ref__id_catprd as ref__id_catprd,ref__id_catsubprd as ref__id_catsubprd," _
                                   & "number_prd as number_prd,nameprd_th as nameprd_th,nameprd_en as nameprd_en," _
                                   & "comment as comment,price as price,ref_unit as ref_unit,amount as amount," _
                                   & "id_status_table as id_status_table,id_status_sales as id_status_sales," _
                                   & "prd_vatstatus as prd_vatstatus,name_img as name_img,ref__id_catprd as ref__id_catprd," _
                                   & "ref__id_catsubprd as ref__id_catsubprd,IFNULL(prd_type_dis,'0') as prd_type_disn" _
                                   & " from pos_product where id='" & id_edit & "'")
        While res_edit.Read()
            id_catedit = res_edit.GetString("ref__id_catprd")
            id_subcatedit = res_edit.GetString("ref__id_catsubprd")
            txtBoxIDprd.Text = res_edit.GetString("number_prd")
            txtBoxNameprd_th.Text = res_edit.GetString("nameprd_th")
            txtBoxNameprd_en.Text = res_edit.GetString("nameprd_en")
            If res_edit.GetString("comment") <> "" And res_edit.GetString("comment") <> "-" Then
                txtBoxNameprd_comment.Text = res_edit.GetString("comment")
            End If
            txtBoxPrice.Text = res_edit.GetString("price")
            id_unitedit = res_edit.GetString("ref_unit")
            If res_edit.GetString("amount") <> "" And res_edit.GetString("amount") <> 0 Then
                txtBoxNumSales.Text = res_edit.GetString("amount")
            Else
                txtBoxNumSales.Text = "0"
            End If

            arr_OnTb = res_edit.GetString("id_status_table")
            arr_OnSales = res_edit.GetString("id_status_sales")
            If res_edit.GetString("id_status_table") = "1" Then
                Load_Edit_Condition_indre(id_edit)
            Else
                Load_Edit_Condition_unit(id_edit)
            End If
            If res_edit.GetString("id_status_sales") = "1" Then
                SetOn_Sales()
            Else
                SetOff_Sales()
            End If
            If res_edit.GetInt32("prd_vatstatus") = 0 Then
                RadioButton1.Checked = True
            ElseIf res_edit.GetInt32("prd_vatstatus") = 1 Then
                RadioButton2.Checked = True
            ElseIf res_edit.GetInt32("prd_vatstatus") = 2 Then
                RadioButton3.Checked = True
            Else
                RadioButton1.Checked = False
                RadioButton2.Checked = False
                RadioButton3.Checked = False
            End If

            If res_edit.GetString("name_img") <> "" And res_edit.GetString("name_img") <> "none" Then
                images_prd = res_edit.GetString("name_img")
                ' GET FOLDER SAVE IMAGES
                Dim objReader As New System.IO.StreamReader("active_fol.bat", Encoding.UTF8)
                Dim TextLine() As String
                Dim fulltextIMG As String = ""

                Do While objReader.Peek() <> -1
                    TextLine = objReader.ReadLine().ToString.Trim.Split("=")
                    If TextLine(0).ToString.Trim = "folderProduct" Then
                        fulltextIMG &= TextLine(1).ToString.Trim
                    End If
                Loop
                PicImgBox.ImageLocation = fulltextIMG & res_edit.GetString("name_img")
            Else
                images_prd = ""
                PicImgBox.Image = Nothing
            End If
            ComboBox_Cat.SelectedValue = res_edit.GetString("ref__id_catprd")
            ComboBox_SubCat.SelectedValue = res_edit.GetString("ref__id_catsubprd")
            If res_edit.GetString("ref_unit") <> "" Then
                txtBoxUnit.SelectedValue = res_edit.GetString("ref_unit")
            End If
            If res_edit.GetString("prd_type_disn") <> "" Or res_edit.GetString("prd_type_disn") <> 0 Then
                ComboBox_PrdType.SelectedValue = res_edit.GetString("prd_type_disn")
            End If
        End While
        res_edit.Close()
    End Sub
    Public Sub Load_Edit_Condition_indre(ByVal id_edit)
        'QUERY INDRE PRICE CONDITION
        Dim res_condit As MySqlDataReader
        Dim itmx As New ListViewItem
        Dim str As String = ""
        Dim get_price As String = ""
        Dim get_size As String = ""
        Dim n As Integer = 1
        Dim str_size As String = ""
        Dim str_indre As String = ""
        res_condit = con.mysql_query("select *,pos_product_ingredients.name_en AS indrename_en," _
        & "pos_product_size.name_en AS sname_en,pos_product_size.name_th AS sname_th from((pos_product_condition " _
        & " INNER JOIN pos_product_ingredients ON pos_product_ingredients.id = pos_product_condition.ref_id_ingredients) " _
        & " INNER JOIN pos_product_size ON pos_product_size.id = pos_product_condition.ref_id_size) " _
        & " where pos_product_condition.ref_id_prd='" & id_edit & "' ORDER BY pos_product_condition.ref_id_size ASC,pos_product_condition.price_condition ASC")

        Dim strs(3) As String
        Dim itm As ListViewItem
        arr_indre.Clear()
        arr_price.Clear()
        arr_size.Clear()
        arr_amount.Clear()
        arr_barcode.Clear()
        arr_MGroup.Clear()
        While res_condit.Read()

            If res_condit.GetString("sname_en") <> "" Then
                str_size = res_condit.GetString("sname_en")
            Else
                str_size = res_condit.GetString("sname_th")
            End If

            If res_condit.GetString("indrename_en") <> "" Then
                str_indre = res_condit.GetString("indrename_en")
            Else
                str_indre = res_condit.GetString("indrename_th")
            End If

            arr_indre.Add(str_indre)
            arr_price.Add(res_condit.GetString("price_condition"))
            arr_size.Add(res_condit.GetString("ref_id_size"))
            arr_MGroup.Add(res_condit.GetString("group_mark"))


            If get_price = res_condit.GetString("price_condition") And get_size = res_condit.GetString("ref_id_size") Then
                str &= "," & res_condit.GetString("indrename_en")
            Else
                If get_price <> "" Then
                    Dim words As String() = str.Split(New Char() {","c})
                    strs(0) = (n - 1) - words.Count
                    strs(1) = str
                    strs(2) = str_size
                    strs(3) = get_price
                    itm = New ListViewItem(strs)
                    ListView_Condition.Items.Add(itm)

                    get_price = res_condit.GetString("price_condition")
                    get_size = res_condit.GetString("ref_id_size")
                    str = res_condit.GetString("indrename_en")
                Else
                    get_price = res_condit.GetString("price_condition")
                    get_size = res_condit.GetString("ref_id_size")
                    str = res_condit.GetString("indrename_en")
                End If
            End If
            n += 1
        End While
        Try
            Dim last_price As String = ListView_Condition.Items(ListView_Condition.Items.Count - 1).SubItems(3).Text()
            Dim last_size As String = ListView_Condition.Items(ListView_Condition.Items.Count - 1).SubItems(2).Text()

            If get_price <> last_price Or get_size <> last_size Then
                Dim words As String() = str.Split(New Char() {","c})
                strs(0) = (n - 1) - words.Count
                strs(1) = str
                strs(2) = str_size
                strs(3) = get_price
                itm = New ListViewItem(strs)
                ListView_Condition.Items.Add(itm)
            End If
        Catch ex As Exception
            If str <> "" Then
                Dim words As String() = str.Split(New Char() {","c})
                strs(0) = (n - 1) - words.Count
                strs(1) = str
                strs(2) = str_size
                strs(3) = get_price
                itm = New ListViewItem(strs)
                ListView_Condition.Items.Add(itm)
            End If
        End Try
    End Sub
    Public Sub Load_Edit_Condition_unit(ByVal id_edit)
        'QUERY INDRE PRICE CONDITION IS HAVE UNIT

        Dim res_condit As MySqlDataReader
        Dim itmx As New ListViewItem
        Dim str As String = ""
        Dim n As Integer = 0
        Dim str_unit As String = ""
        res_condit = con.mysql_query("select * from pos_product_condition " _
       & " INNER JOIN pos_product_unit ON pos_product_unit.id = pos_product_condition.ref_id_unit" _
       & "  where pos_product_condition.ref_id_prd='" & id_edit & "' ORDER BY pos_product_condition.ref_id_unit ASC,pos_product_condition.price_condition ASC")
        Dim strs1(4) As String
        Dim itm1 As ListViewItem
        arr_indre.Clear()
        arr_price.Clear()
        arr_size.Clear()
        arr_amount.Clear()
        arr_barcode.Clear()
        arr_MGroup.Clear()
        While res_condit.Read()
            If res_condit.GetString("name_en") <> "" Then
                str_unit = res_condit.GetString("name_en")
            Else
                str_unit = res_condit.GetString("name_th")
            End If
            arr_indre.Add("0")
            arr_price.Add(res_condit.GetString("price_condition"))
            arr_size.Add(res_condit.GetString("ref_id_unit"))
            arr_amount.Add(res_condit.GetString("amount"))
            arr_barcode.Add(res_condit.GetString("barcode"))
            arr_MGroup.Add(res_condit.GetString("group_mark"))
            strs1(0) = n
            strs1(1) = res_condit.GetString("barcode")
            strs1(2) = str_unit
            strs1(3) = res_condit.GetString("price_condition")
            strs1(4) = res_condit.GetString("amount")
            n += 1
            itm1 = New ListViewItem(strs1)
            ListView1.Items.Add(itm1)
        End While
      
    End Sub
    Public Sub load_cat()
        Dim res_cat As MySqlDataReader
        res_cat = con.mysql_query("select * from  pos_catprd where id_status_sales<>'2' order by namecat_en asc")
        Dim cboItemsFl As New List(Of cboItem)
        Dim txt As String = ""
        While res_cat.Read()
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
        Check_OnTB()
        setLableTB()
        loadDataSubCat()
        loadData_size()
    End Sub

    Public Sub loadDataSubCat()
        Dim res_subcat As MySqlDataReader
        Dim Str_subcat As String
        Dim id_cat As Integer = ComboBox_Cat.SelectedValue.ToString()
        res_subcat = con.mysql_query("select * from pos_catsubprd where ref_id_cat='" & id_cat & "' and id_status_sales<>'2' order by name_en asc")
        Dim cboItemsF2 As New List(Of cboItem)
        While res_subcat.Read
            If res_subcat.GetString("name_en") <> "" Then
                Str_subcat = res_subcat.GetString("name_en")
            Else
                Str_subcat = res_subcat.GetString("name_th")
            End If
            cboItemsF2.Add(New cboItem With {.Text = Str_subcat, .Value = res_subcat.GetString("id")})
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

        ' Dim res_size As MySqlDataReader
        ' res_size = con.mysql_query("select * from pos_product_size order by name_en asc")
        '  Dim cboItemsF3 As New List(Of cboItem)
        '  Dim txt1 As String = ""
        '  While res_size.Read()
        'If res_size.GetString("name_en") = "" Then
        ' 'txt1 = res_size.GetString("name_th")
        ' Else
        ' txt1 = res_size.GetString("name_en")
        ' End If
        'cboItemsF3.Add(New cboItem With {.Text = txt1, .Value = res_size.GetString("id")})
        ' End While

        'With Me.ComboBox_Unit
        '.DisplayMember = "Text"
        ' .ValueMember = "Value"
        '  .DataSource = cboItemsF3
        '  End With
        '  res_size.Close()
        ' If ComboBox_Unit.Items.Count > 0 Then
        'ComboBox_Unit.SelectedIndex = 0
        '  End If

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
            If ComboBox_Cat.SelectedValue.ToString <> id_catedit Then
                arr_amount.Clear()
                arr_barcode.Clear()
                arr_indre.Clear()
                arr_MGroup.Clear()
                arr_price.Clear()
                arr_size.Clear()
                ListView1.Items.Clear()
            End If
        Else
            Panel_Price.Show()
            GroupBox2.Hide()
            Admin_addPrdCon.Panel12.Hide()
            Admin_addPrdCon.Panel13.Show()
            GroupBox5.Show()
            If ComboBox_Cat.SelectedValue.ToString <> id_catedit Then
                arr_amount.Clear()
                arr_barcode.Clear()
                arr_indre.Clear()
                arr_MGroup.Clear()
                arr_price.Clear()
                arr_size.Clear()
                ListView_Condition.Items.Clear()
            End If
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
        'CheckedListBox1.Items.Clear()
        ' Dim res_indre As MySqlDataReader
        ' Dim Str_indre As String
        ' Dim cboItemsF3 As New List(Of cboItem)
        ' res_indre = con.mysql_query("select * from pos_product_ingredients order by name_th ASC")
        ' While res_indre.Read
        'If res_indre.GetString("name_en") <> "" Then
        'Str_indre = res_indre.GetString("name_en")
        ' Else
        ' Str_indre = res_indre.GetString("name_th")
        'End If
        'CheckedListBox1.Items.Add(Str_indre)
        ' End While
        ' res_indre.Close()
    End Sub

    Private Sub btn_search_indre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Admin_addPrd_Condit.ShowDialog() 'show form indregent
    End Sub


    Public Sub add_condition()
        '  Dim itmx As New ListViewItem
        '  Dim str As String = ""
        '  Dim str1 As String = ""
        '  Dim cout As Integer = 0
        '  y += 1
        '  Dim cc As String = arr_indre.Count.ToString
        '  itmx = ListView_Condition.Items.Add(cc, CInt(y))
        ' For i As Integer = 0 To CheckedListBox1.Items.Count - 1
        'If CheckedListBox1.GetItemChecked(i) = True Then
        'arr_MGroup.Add(cc)
        ' arr_indre.Add(CheckedListBox1.Items.Item(i).ToString)
        ' arr_price.Add(txtBox_priceCon.Text)
        '  arr_size.Add(get_id("pos_product_size", "name_th", "name_en", ComboBox_Unit.Text))
        '  If cout > 0 Then
        'str1 = ","
        ' Else
        '  str1 = ""
        '  End If
        '  Str += str1 + CheckedListBox1.Items.Item(i).ToString
        '  cout += 1

        ' End If
        ' Next
        ' itmx.SubItems.Add(Str)
        ' itmx.SubItems.Add(ComboBox_Unit.Text)
        ' itmx.SubItems.Add(txtBox_priceCon.Text)

    End Sub

    Private Sub btn_del_con_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim count_arr As String
            Dim str_now As String()
            count_arr = ListView_Condition.Items(ListView_Condition.FocusedItem.Index).SubItems(0).Text()
            str_now = ListView_Condition.Items(ListView_Condition.FocusedItem.Index).SubItems(1).Text().Split(New Char() {","c})
            For i As Integer = CInt(count_arr) To CInt(count_arr) + str_now.Count - 1
                arr_indre(i) = ""
                arr_price(i) = ""
                arr_MGroup(i) = ""
                arr_size(i) = ""
            Next
            ListView_Condition.Items.RemoveAt(ListView_Condition.SelectedIndices(0))
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
    Private Sub txtBoxPrice_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBoxPrice.TextChanged
        checkIsNumeric(txtBoxPrice.Text, txtBoxPrice)
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
            If btn_save.Text = "Edit" Then
                'Upload file images
                Dim pic_prd As String = ""
                If name_img <> "" Then
                    ' GET FOLDER SAVE IMAGES
                    Dim objReader As New System.IO.StreamReader("active_fol.bat", Encoding.UTF8)
                    Dim TextLine() As String
                    Dim fulltextIMG As String = ""

                    Do While objReader.Peek() <> -1
                        TextLine = objReader.ReadLine().ToString.Trim.Split("=")
                        If TextLine(0).ToString.Trim = "folderProduct" Then
                            fulltextIMG &= TextLine(1).ToString.Trim
                        End If
                    Loop

                    Dim time As DateTime = DateTime.Now
                    pic_prd = txtBoxIDprd.Text & "_" & time.Millisecond & taype_img
                    If images_prd <> "" Then
                        File.Delete(fulltextIMG & images_prd) 'delete images old
                        File.Copy(pathname, fulltextIMG & pic_prd)
                        images_prd = pic_prd
                    Else
                        File.Copy(pathname, fulltextIMG & pic_prd)
                        images_prd = pic_prd
                    End If
                Else
                    images_prd = images_prd
                End If


                Dim cat_id As String = ComboBox_Cat.SelectedValue.ToString()
                Dim subcat_id As String = ComboBox_SubCat.SelectedValue.ToString()
                Dim prd_type_id As String = ComboBox_PrdType.SelectedValue.ToString()
                Dim pt As Boolean
                Dim amount As String
                Dim unit_idnew As String
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
                    If txtBoxUnit.SelectedValue = "" Then
                        unit_idnew = 0
                    Else
                        unit_idnew = txtBoxUnit.SelectedValue.ToString() ' check_unit_id(txtBoxUnit.SelectedValue.ToString())
                    End If
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
                Dim comment_replec As String = txtBoxNameprd_comment.Text.Replace("'", "\'")
                pt = con.mysql_query("UPDATE pos_product SET " _
                & "number_prd='" & txtBoxIDprd.Text & "',nameprd_th='" & txtBoxNameprd_th_replace & "',nameprd_en='" & txtBoxNameprd_en_replace & "'," _
                & "update_by='" & Login.username & "',amount='" & amount & "',price='" & txtBoxPrice.Text & "',comment='" & comment_replec & "'," _
                & "id_status_sales='" & arr_OnSales & "',id_status_table='" & arr_OnTb & "',ref__id_catprd='" & cat_id & "'," _
                & "ref__id_catsubprd='" & subcat_id & "',ref_unit='" & unit_idnew & "',name_img='" & images_prd & "',prd_vatstatus='" & vatstatus & "' " _
                & ",prd_type_dis='" & prd_type_id & "' WHERE id ='" & id_edit & "'; ")
                If pt = True Then
                    Dim str1 As String = ""
                    If arr_OnTb = 1 Then
                        If arr_indre.Count > 0 Or (ComboBox_Cat.SelectedValue.ToString <> id_catedit) Then
                            Dim id_indre_new As Integer
                            con.mysql_query("DELETE FROM pos_product_condition WHERE ref_id_prd='" & id_edit & "';")
                            'INSERT CONDITION PRD
                            For i As Integer = 0 To arr_indre.Count - 1
                                If arr_indre(i) <> "" Then
                                    id_indre_new = get_id("pos_product_ingredients", "name_th", "name_en", arr_indre(i).ToString)
                                    con.mysql_query("INSERT INTO pos_product_condition (ref_id_prd,ref_id_ingredients,ref_id_size,price_condition,group_mark)" _
                                     & " VALUES('" & id_edit & "','" & id_indre_new & "','" & arr_size(i) & "','" & arr_price(i) & "'" _
                                    & ",'" & arr_MGroup(i) & "');")
                                End If
                            Next
                        End If
                    Else
                        If arr_barcode.Count > 0 Or (ComboBox_Cat.SelectedValue.ToString <> id_catedit) Then
                            con.mysql_query("DELETE FROM pos_product_condition WHERE ref_id_prd='" & id_edit & "';")
                            'INSERT CONDITION PRD
                            '=== query for delete pos_product_inv ===='
                            Dim g As MySqlDataReader = con.mysql_query("select * from pos_product_inv where inv_prd_id='" & id_edit & "'")
                            While g.Read
                                If CInt(g.GetString("inv_amount")) = 0 Then
                                    str1 &= "DELETE FROM pos_product_inv where inv_barcode='" & g.GetString("inv_barcode") & "' and inv_amount<='0'; "
                                End If
                            End While
                            g.Close()
                            For i As Integer = 0 To arr_barcode.Count - 1
                                If arr_amount(i) <> "" Then
                                    con.mysql_query("INSERT INTO pos_product_condition (ref_id_prd,ref_id_ingredients,ref_id_unit,price_condition,group_mark,barcode,amount)" _
                                     & " VALUES('" & id_edit & "','0','" & arr_size(i) & "','" & arr_price(i) & "'" _
                                    & ",'" & arr_MGroup(i) & "','" & arr_barcode(i) & "','" & arr_amount(i) & "');")

                                    Dim c As MySqlDataReader = con.mysql_query("select * from pos_product_condition where ref_id_prd='" & id_edit & "' and ref_id_unit='" & arr_size(i) & "' order by id desc limit 1 ")
                                    c.Read()
                                    Dim id_con As String = c.GetString("id")
                                    c.Close()
                                    Dim nameUnit1 As String = ""
                                    Dim idUnit As String = ""
                                    nameUnit1 = Admin_addPrd.nameUnit(arr_size(i))
                                    idUnit = arr_size(i)
                                    If arr_barcode(i) <> "" Then
                                        str1 &= "INSERT INTO pos_product_inv (inv_barcode,inv_amount,inv_name_th,inv_name_en," _
                                             & "inv_unit_name,inv_unit_id,inv_prd_id,inv_prd_con) VALUES('" & arr_barcode(i) & "','" & arr_amount(i) & "'," _
                                             & "'" & txtBoxNameprd_th_replace & "','" & txtBoxNameprd_en_replace & "','" & nameUnit1 & "','" & idUnit & "','" & id_edit & "','" & id_con & "');"
                                    End If
                                End If
                            Next
                        End If
                        '==== check ว่ามีbarcode นี้ในระบบหรือยัง แล้วหลังจากนั้นเพิ่มให้เลยถ้ายังไม่มีในระบบของ inv ====='
                        If txtBoxIDprd.Text <> "" Then
                            Dim h As Integer = con.mysql_num_rows(con.mysql_query("select inv_barcode from pos_product_inv where inv_barcode='" & txtBoxIDprd.Text & "'"))
                            If h > 0 Then 'ถ้ามีในระบบแล้วให้ upfate ชื่อแทน และหน่วยสินค้า
                                str1 &= "UPDATE pos_product_inv SET inv_name_th='" & txtBoxNameprd_th_replace & "',inv_name_en='" & txtBoxNameprd_en_replace & "'," _
                                & "inv_unit_name='" & txtBoxUnit.Text & "',inv_unit_id='" & unit_idnew & "' where inv_barcode='" & txtBoxIDprd.Text & "';"
                            Else 'ถ้าไม่มีให้เพิ่มเข้าแทน
                                str1 &= "INSERT INTO pos_product_inv(inv_barcode,inv_name_th,inv_name_en,inv_unit_name,inv_unit_id) VALUES(" _
                                & "'" & txtBoxIDprd.Text & "','" & txtBoxNameprd_th_replace & "','" & txtBoxNameprd_en_replace & "','" & txtBoxUnit.Text & "','" & unit_idnew & "');"
                            End If
                        End If
                        If str1 <> "" Then
                            con.mysql_query(str1)
                        End If
                    End If
                    MessageBox.Show("Edit Product Complete", "Message Alert", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Admin_addPrdList.loadData_PrdList()
                    Me.Close()
                Else
                    MessageBox.Show("Error Add Product..!")
                    clearForm()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Function check_unit_id(ByVal item)
        Dim res_chk_unit As MySqlDataReader
        Dim id As Integer
        res_chk_unit = con.mysql_query("select * from pos_product_unit where id='" & item & "'")
        If con.mysql_num_rows(res_chk_unit) > 0 Then
            res_chk_unit = con.mysql_query("select * from pos_product_unit where  id='" & item & "'")
            While res_chk_unit.Read()
                id = res_chk_unit.GetString("id")
            End While
            res_chk_unit.Close()
        Else
            id = 0
        End If
        Return id
    End Function

    Public Function get_id(ByVal type_1, ByVal p1, ByVal p2, ByVal v1)
        Dim id_f As Integer
        Dim res_getID As MySqlDataReader
        res_getID = con.mysql_query("select id from " & type_1 & " where (" & p1 & "='" & v1 & "' or " & p2 & "='" & v1 & "') limit 1")
        While res_getID.Read()
            If res_getID.GetString("id") <> "" And res_getID.GetString("id") <> 0 Then
                id_f = res_getID.GetString("id")
            Else
                id_f = 0
            End If
        End While
        res_getID.Close()
        Return id_f
    End Function
    Public Sub loadData_unit()
        txtBoxUnit.DataSource = Nothing
        txtBoxUnit.Items.Clear()
        txtBoxUnit.Items.Remove(txtBoxUnit.DisplayMember)
        'txtBoxUnit.Items.Clear()

        Dim res_unit As MySqlDataReader
        Dim cboItemsF3 As New List(Of cboItem)
        Dim Str As String = ""
        res_unit = con.mysql_query("select 	name_en,name_th,id from pos_product_unit")
        While res_unit.Read()
            If res_unit.GetString("name_en") <> "" Then
                Str = res_unit.GetString("name_en")
            Else
                Str = res_unit.GetString("name_th")
            End If
            cboItemsF3.Add(New cboItem With {.Text = Str, .Value = res_unit.GetString("id")})
        End While
        res_unit.Close()
        With Me.txtBoxUnit
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .DataSource = cboItemsF3
        End With
        If txtBoxUnit.Items.Count > 0 Then
            txtBoxUnit.SelectedIndex = 0
        End If
    End Sub
    Public Sub loadData_PrdType()
        ComboBox_PrdType.DataSource = Nothing
        ComboBox_PrdType.Items.Clear()
        ComboBox_PrdType.Items.Remove(ComboBox_PrdType.DisplayMember)

        Dim res_unit As MySqlDataReader
        Dim cboItemsF3 As New List(Of cboItem)
        Dim Str As String = ""
        res_unit = con.mysql_query("select 	t_name_th,t_name_en,t_prd_id from pos_product_type ")
        While res_unit.Read()
            If res_unit.GetString("t_name_en") <> "" Then
                Str = res_unit.GetString("t_name_en")
            Else
                Str = res_unit.GetString("t_name_th")
            End If
            cboItemsF3.Add(New cboItem With {.Text = Str, .Value = res_unit.GetString("t_prd_id")})
        End While
        res_unit.Close()
        With Me.ComboBox_PrdType
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .DataSource = cboItemsF3
        End With
        If ComboBox_PrdType.Items.Count > 0 Then
            ComboBox_PrdType.SelectedIndex = 0
        End If
    End Sub
    Private Sub btn_add_condition_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_add_condition.Click
        Admin_addPrdCon.Page = "edit"
        Admin_addPrdCon.ShowDialog()
    End Sub

    Private Sub btn_del_con_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_del_con.Click
        ' Try
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
        ' Catch ex As Exception
        ' MsgBox(ex.Message.ToString)
        ' End Try
    End Sub

    Private Sub add_conunit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles add_conunit.Click
        Admin_addPrdCon.Page = "edit"
        Admin_addPrdCon.ShowDialog()
    End Sub

    Private Sub del_conunit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles del_conunit.Click
        '   Try
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
        '   Catch ex As Exception
        'MsgBox(ex.Message.ToString)
        ' End Try
    End Sub

    Private Sub txtBoxNumSales_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBoxNumSales.TextChanged
        checkIsNumeric(txtBoxNumSales.Text, txtBoxNumSales)
    End Sub

End Class

