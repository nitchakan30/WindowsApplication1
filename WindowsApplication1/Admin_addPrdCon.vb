Imports MySql.Data.MySqlClient
Public Class Admin_addPrdCon
    Dim con As New Mysql
    Dim arr_OnTb As String = ""
    Public Page As String = "add"
    Private Sub Admin_addPrdCon_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Page = "add"
    End Sub
    Private Sub Admin_addPrdCon_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Check_OnTB()
    End Sub
    Public Sub Check_OnTB()
        Dim id As String = ""
        If Page = "add" Then
            id = Admin_addPrd.ComboBox_Cat.SelectedValue.ToString()
        Else
            id = Admin_editPrd.ComboBox_Cat.SelectedValue.ToString()
        End If
        Dim res_chkTB As MySqlDataReader
        res_chkTB = con.mysql_query("select * from pos_catprd where id='" & id & "' limit 1")
        While res_chkTB.Read
            arr_OnTb = res_chkTB.GetString("id_status_table")
        End While
        res_chkTB.Close()
        If arr_OnTb = "1" Then
            loadData_size()
            loadData_Indre()
        Else
            loadData_unit()
        End If
    End Sub
    Private Sub add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Page = "add" Then
            add_condition() 'load data condition all
            clearFormCon() 'load funtion clear form condition price
            Me.Close()
        Else
            add_condition_edit() 'load data condition all
            clearFormCon() 'load funtion clear form condition price
            Me.Close()
        End If
    End Sub
    Public Sub loadData_Indre()
        Dim res_indre As MySqlDataReader
        Dim cboItemsF3 As New List(Of cboItem)
        CheckedListBox1.Items.Clear()
        res_indre = con.mysql_query("select * from pos_product_ingredients")
        While res_indre.Read
            CheckedListBox1.Items.Add(res_indre.GetString("name_en"))
        End While
        res_indre.Close()
    End Sub
    Public Sub loadData_size()
        Dim res_size As MySqlDataReader
        res_size = con.mysql_query("select * from pos_product_size order by name_en asc")
        Dim cboItemsF3 As New List(Of cboItem)
        Dim txt1 As String = ""
        While res_size.Read()
            If res_size.GetString("name_en") = "" Then
                txt1 = res_size.GetString("name_th")
            Else
                txt1 = res_size.GetString("name_en")
            End If
            cboItemsF3.Add(New cboItem With {.Text = txt1, .Value = res_size.GetString("id")})
        End While

        With Me.ComboBox_Unit
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .DataSource = cboItemsF3
        End With

        If ComboBox_Unit.Items.Count > 0 Then
            ComboBox_Unit.SelectedIndex = 0
        End If
        res_size.Close()
    End Sub
    Public Sub add_condition()
        Dim itmx As New ListViewItem
        Dim str As String = ""
        Dim str1 As String = ""
        Dim cout As Integer = 0
        Admin_addPrd.y += 1
        If arr_OnTb = "1" Then
            Dim cc As String = Admin_addPrd.arr_indre.Count.ToString
            itmx = Admin_addPrd.ListView_Condition.Items.Add(cc, CInt(Admin_addPrd.y))
            For i As Integer = 0 To CheckedListBox1.Items.Count - 1
                If CheckedListBox1.GetItemChecked(i) = True Then
                    Admin_addPrd.arr_MGroup.Add(cc)
                    Admin_addPrd.arr_indre.Add(CheckedListBox1.Items.Item(i).ToString)
                    Admin_addPrd.arr_price.Add(txtBox_priceCon.Text)
                    Admin_addPrd.arr_size.Add(ComboBox_Unit.SelectedValue.ToString())
                    Admin_addPrd.arr_barcode.Add("-")
                    Admin_addPrd.arr_amount.Add("0")
                    If cout > 0 Then
                        str1 = ","
                    Else
                        str1 = ""
                    End If
                    str += str1 + CheckedListBox1.Items.Item(i).ToString
                    cout += 1
                End If
            Next
            itmx.SubItems.Add(str)
            itmx.SubItems.Add(ComboBox_Unit.Text)
            itmx.SubItems.Add(txtBox_priceCon.Text)
        Else
            Dim cc As String = Admin_addPrd.arr_price.Count.ToString
            Admin_addPrd.arr_MGroup.Add(cc)
            Admin_addPrd.arr_indre.Add("0")
            Admin_addPrd.arr_price.Add(txtBox_priceCon.Text)
            Admin_addPrd.arr_size.Add(ComboBox_Unit.SelectedValue.ToString())
            Admin_addPrd.arr_barcode.Add(barcode.Text)
            Admin_addPrd.arr_amount.Add(amount.Text)
            itmx = Admin_addPrd.ListView1.Items.Add(cc, CInt(Admin_addPrd.y))
            itmx.SubItems.Add(barcode.Text)
            itmx.SubItems.Add(ComboBox_Unit.Text)
            itmx.SubItems.Add(txtBox_priceCon.Text)
            itmx.SubItems.Add(amount.Text)
        End If
       
    End Sub
    Public Sub add_condition_edit()
        Dim itmx As New ListViewItem
        Dim str As String = ""
        Dim str1 As String = ""
        Dim cout As Integer = 0
        Admin_editPrd.y += 1
        If arr_OnTb = "1" Then
            Dim cc As String = Admin_editPrd.arr_indre.Count.ToString
            itmx = Admin_editPrd.ListView_Condition.Items.Add(cc, CInt(Admin_addPrd.y))
            For i As Integer = 0 To CheckedListBox1.Items.Count - 1
                If CheckedListBox1.GetItemChecked(i) = True Then
                    Admin_editPrd.arr_MGroup.Add(cc)
                    Admin_editPrd.arr_indre.Add(CheckedListBox1.Items.Item(i).ToString)
                    Admin_editPrd.arr_price.Add(txtBox_priceCon.Text)
                    Admin_editPrd.arr_size.Add(ComboBox_Unit.SelectedValue.ToString())
                    Admin_editPrd.arr_barcode.Add("-")
                    Admin_editPrd.arr_amount.Add("0")
                    If cout > 0 Then
                        str1 = ","
                    Else
                        str1 = ""
                    End If
                    str += str1 + CheckedListBox1.Items.Item(i).ToString
                    cout += 1
                End If
            Next
            itmx.SubItems.Add(str)
            itmx.SubItems.Add(ComboBox_Unit.Text)
            itmx.SubItems.Add(txtBox_priceCon.Text)
        Else
            Dim cc As String = Admin_editPrd.arr_price.Count.ToString
            Admin_editPrd.arr_MGroup.Add(cc)
            Admin_editPrd.arr_indre.Add("0")
            Admin_editPrd.arr_price.Add(txtBox_priceCon.Text)
            Admin_editPrd.arr_size.Add(ComboBox_Unit.SelectedValue.ToString())
            Admin_editPrd.arr_barcode.Add(barcode.Text)
            Admin_editPrd.arr_amount.Add(amount.Text)
            itmx = Admin_editPrd.ListView1.Items.Add(cc, CInt(Admin_addPrd.y))
            itmx.SubItems.Add(barcode.Text)
            itmx.SubItems.Add(ComboBox_Unit.Text)
            itmx.SubItems.Add(txtBox_priceCon.Text)
            itmx.SubItems.Add(amount.Text)
        End If

    End Sub
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
        ComboBox_Unit.DataSource = Nothing
        ComboBox_Unit.Items.Clear()
        ComboBox_Unit.Items.Remove(ComboBox_Unit.DisplayMember)
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
        With Me.ComboBox_Unit
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .DataSource = cboItemsF3
        End With
    End Sub
    Public Sub clearFormCon()
        Try
            For i As Integer = 0 To CheckedListBox1.Items.Count - 1
                CheckedListBox1.SetItemChecked(i, False)
            Next
            If ComboBox_Unit.Items.Count > 0 Then
                ComboBox_Unit.SelectedIndex = 0
            End If
            txtBox_priceCon.Text = "0"
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        clearFormCon()
    End Sub

    Private Sub txtBox_priceCon_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBox_priceCon.TextChanged
        Admin_addPrd.checkIsNumeric(txtBox_priceCon.Text, txtBox_priceCon)
    End Sub
    Private Sub amount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles amount.TextChanged
        Admin_addPrd.checkIsNumeric(amount.Text, amount)
    End Sub
End Class