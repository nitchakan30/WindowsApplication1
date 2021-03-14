Imports MySql.Data.MySqlClient
Public Class opentable_add_other
    Dim con As New Mysql
    Public page As String = ""
    Private Sub opentable_add_other_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        textbox_name_prd.Focus()
        LOAD_GROUP1()
        textbox_vat_prd.Text = GetVat()
        load_PrdType()
    End Sub
    Public Sub LOAD_GROUP1()
        Dim res_cat As MySqlDataReader
        res_cat = con.mysql_query("select * from  pos_catprd where id_status_sales='1'  order by namecat_en asc")
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

        With Me.ComboBox_Group1
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .DataSource = cboItemsFl
        End With

        If ComboBox_Group1.Items.Count > 0 Then
            ComboBox_Group1.SelectedIndex = 0
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

        With Me.ComboBox_Prd_Type
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .DataSource = cboItemsFl
        End With

        If ComboBox_Prd_Type.Items.Count > 0 Then
            ComboBox_Prd_Type.SelectedIndex = 0
        End If
        res_cat.Close()
    End Sub
    Private Sub btn_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_close.Click
        Me.Close()
    End Sub
    Private Sub textbox_price_prd_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles textbox_price_prd.TextChanged
        checkIsNumeric(textbox_price_prd.Text, textbox_price_prd)
    End Sub
    Private Sub textbox_qty_prd_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles textbox_qty_prd.TextChanged
        checkIsNumeric(textbox_qty_prd.Text, textbox_qty_prd)
    End Sub
    Private Sub checkIsNumeric(ByVal num, ByVal param)
        If IsNumeric(num) = False Then
            param.Focus()
            param.text = "0"
        End If
    End Sub
    Private Sub textbox_vat_prd_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles textbox_vat_prd.TextChanged
        checkIsNumeric(textbox_vat_prd.Text, textbox_vat_prd)
    End Sub
    Private Sub ComboBox_Group1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox_Group1.SelectedIndexChanged
        loadDataSubCat()
    End Sub
    Public Sub loadDataSubCat()
        'Clear Array Data
        Dim res_subcat As MySqlDataReader
        Dim id_cat As Integer = ComboBox_Group1.SelectedValue.ToString()
        res_subcat = con.mysql_query("select * from pos_catsubprd where ref_id_cat='" & id_cat & "' and id_status_sales='1' order by name_en asc")
        Dim cboItemsF2 As New List(Of cboItem)
        While res_subcat.Read()
            cboItemsF2.Add(New cboItem With {.Text = res_subcat.GetString("name_en") & " (" & res_subcat.GetString("name_th") & ")", .Value = res_subcat.GetString("id")})
        End While

        With Me.ComboBox_Group2
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .DataSource = cboItemsF2
        End With
        If ComboBox_Group2.Items.Count > 0 Then
            ComboBox_Group2.SelectedIndex = 0
        End If
        res_subcat.Close()
    End Sub
    Private Function GetVat()
        Dim vat As String = ""
        Dim sqlvat As MySqlDataReader = con.mysql_query("select IFNULL(vat,'0') as vat from pos_shop")
        sqlvat.Read()
        vat = sqlvat.GetString("vat")
        Return vat
    End Function

    Private Sub btn_add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_add.Click
        If page = "opentable" Then
            Dim max As Integer = opentable.ListView_ListOrder.Items.Count
            Dim num As Integer = max + 1
            Dim itmx As New ListViewItem
            Dim vat_st As String = ""
            If vat_none.Checked = True Then
                vat_st = "0"
            End If
            If vat_include.Checked = True Then
                vat_st = "1"
            End If
            If vat_add.Checked = True Then
                vat_st = "2"
            End If
            itmx = opentable.ListView_ListOrder.Items.Add("0", num)
            itmx.SubItems.Add("no")
            itmx.SubItems.Add("0")
            itmx.SubItems.Add("0")
            itmx.SubItems.Add(textbox_name_prd.Text)
            itmx.SubItems.Add(textbox_name_prd_en.Text)
            itmx.SubItems.Add("0")
            itmx.SubItems.Add(CInt(textbox_qty_prd.Text))
            itmx.SubItems.Add(FormatNumber((textbox_qty_prd.Text) * CDbl(textbox_price_prd.Text), 2))
            itmx.SubItems.Add(textbox_remark_prd.Text)
            itmx.SubItems.Add(ComboBox_Group1.SelectedValue.ToString)
            itmx.SubItems.Add(ComboBox_Group2.SelectedValue.ToString)
            itmx.SubItems.Add(ComboBox_Group1.Text.ToString)
            itmx.SubItems.Add(ComboBox_Group1.Text.ToString)
            itmx.SubItems.Add(ComboBox_Group2.Text.ToString)
            itmx.SubItems.Add(ComboBox_Group2.Text.ToString)
            itmx.SubItems.Add(CInt(textbox_vat_prd.Text))
            itmx.SubItems.Add(vat_st)
            itmx.SubItems.Add(ComboBox_Prd_Type.SelectedValue.ToString)
            itmx.SubItems.Add(ComboBox_Prd_Type.Text.ToString)
            itmx.SubItems.Add(ComboBox_Prd_Type.Text.ToString)
            opentable.calsum()
        Else
            Dim max As Integer = opentakehome.ListView_ListOrder.Items.Count
            Dim num As Integer = max + 1
            Dim itmx As New ListViewItem
            Dim vat_st As String = ""
            If vat_none.Checked = True Then
                vat_st = "0"
            End If
            If vat_include.Checked = True Then
                vat_st = "1"
            End If
            If vat_add.Checked = True Then
                vat_st = "2"
            End If
            itmx = opentakehome.ListView_ListOrder.Items.Add("0", num)
            itmx.SubItems.Add("no")
            itmx.SubItems.Add("0")
            itmx.SubItems.Add("0")
            itmx.SubItems.Add(textbox_name_prd.Text)
            itmx.SubItems.Add(textbox_name_prd_en.Text)
            itmx.SubItems.Add("0")
            itmx.SubItems.Add(CInt(textbox_qty_prd.Text))
            itmx.SubItems.Add(FormatNumber((textbox_qty_prd.Text) * CDbl(textbox_price_prd.Text), 2))
            itmx.SubItems.Add(textbox_remark_prd.Text)
            itmx.SubItems.Add("0.0")
            itmx.SubItems.Add("0")
            itmx.SubItems.Add("0")
            itmx.SubItems.Add(ComboBox_Group1.SelectedValue.ToString)
            itmx.SubItems.Add(ComboBox_Group2.SelectedValue.ToString)
            itmx.SubItems.Add(ComboBox_Group1.Text.ToString)
            itmx.SubItems.Add(ComboBox_Group1.Text.ToString)
            itmx.SubItems.Add(ComboBox_Group2.Text.ToString)
            itmx.SubItems.Add(ComboBox_Group2.Text.ToString)
            itmx.SubItems.Add(CInt(textbox_vat_prd.Text))
            itmx.SubItems.Add(vat_st)
            itmx.SubItems.Add(ComboBox_Prd_Type.SelectedValue.ToString)
            itmx.SubItems.Add(ComboBox_Prd_Type.Text.ToString)
            itmx.SubItems.Add(ComboBox_Prd_Type.Text.ToString)
            opentakehome.calsum()
        End If
        Me.Close()
    End Sub

End Class