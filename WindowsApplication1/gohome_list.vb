Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Threading

Public Class gohome_list
    Dim con As New Mysql
    Dim print As New printClass
    Dim ac As New Admin_ClassMain
    Dim idCode As String = "0"
    Dim selBill As String = ""
    Private Sub gohome_list_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        btn_edit.Enabled = False
        printAgain.Enabled = False
        btn_pay.Enabled = False
    End Sub
    Private Sub gohome_list_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DoubleBuffered = True
        LoadList()
        If index.CheckOpenSystemTakehomeonly() = True Then
            printAgain.Visible = False
            btn_edit.Visible = False
            btn_voidall.Visible = False
            btn_close.Visible = False
        Else
            printAgain.Visible = True
            btn_edit.Visible = True
            btn_voidall.Visible = True
            btn_close.Visible = True
        End If
    End Sub
    Public Sub LoadList()
        ListView_GH.Items.Clear()
        Dim itmx1 As New ListViewItem
        Dim str As String = "SELECT t1.status_sd_captain AS status_sd_captain,t1.code_gohome AS code_gohome,t1.rf_id_invoice AS rf_id_invoice,SUM(price) AS sprice,SUM(amt) AS samt,SUM(order_dis_sum) AS sdis,IFNULL(sum(pos_invoice_temp.discount_sum),'0') as discount_sum,t1.create_date as create_date," _
& "SUM(IFNULL(price-order_dis_sum,0)) AS alltotal," _
& "IF(status_pay='no',discount_sum,0) AS no," _
& "IF(status_pay='yes',(SELECT discount_sum AS Total From pos_order_list t2 INNER JOIN pos_invoice ON pos_invoice.id = t2.rf_id_invoice WHERE t2.status_open ='gohome' and t2.status_sd_captain<>'void' AND t2.code_gohome =t1.code_gohome and t2.status_pay='yes' and t2.create_date LIKE '%" & Login.DateData.ToString("yyyy-MM-dd") & "%' AND t2.id_ord=t1.id_ord GROUP BY t2.code_gohome),0) AS yes" _
& ",t1.status_pay as status_pay,IFNULL(pos_invoice_temp.price_all,'0') as price_all,IFNULL(pos_invoice_temp.price_exclu_vat,'0') as price_exclu_vat,IFNULL(pos_invoice_temp.vat,'0') as vat,IFNULL(pos_invoice_temp.discount_sum,'0') as discount_sum,IFNULL(pos_invoice_temp.serviceCh,'0') as serviceCh FROM pos_order_list t1 LEFT JOIN pos_invoice_temp ON pos_invoice_temp.id = t1.rf_id_invoice WHERE t1.status_open =  'gohome' and t1.status_sd_captain<>'void' AND t1.code_gohome <>'0' and t1.create_date LIKE '%" & Login.DateData.ToString("yyyy-MM-dd") & "%' GROUP BY t1.code_gohome ORDER BY t1.code_gohome DESC"
        Dim resLoad As MySqlDataReader = con.mysql_query(str)
                Dim y As Integer = 0
        While resLoad.Read
            Dim prcie_n As Double = 0.0
            Dim txt As String = ""
            Dim txt_st_pay As String = ""
            Dim price As Double = 0.0
            itmx1 = ListView_GH.Items.Add(resLoad.GetString("code_gohome"), y)
            itmx1.SubItems.Add(resLoad.GetString("samt"))
            If CInt(resLoad.GetString("rf_id_invoice")) <> 0 Then
                If CheckPay(resLoad.GetString("code_gohome")) = True Then
                    txt = "ยังไม่จ่าย/จ่ายยังไม่ครบ"
                    txt_st_pay = "0"
                Else
                    If checkvoid(resLoad.GetString("rf_id_invoice")) = True Then
                        ListView_GH.Items(y).ForeColor = Color.Red
                        txt = "จ่ายแล้ว(ยกเลิกรายการ)"
                        txt_st_pay = GetNumberINV_POSINV_FROMCODEHOME(resLoad.GetString("code_gohome"))
                    Else
                        If resLoad.GetString("status_pay") = "yes" Then
                            ListView_GH.Items(y).ForeColor = Color.Green
                            txt = "จ่ายแล้ว"
                            txt_st_pay = GetNumberINV_POSINV_FROMCODEHOME(resLoad.GetString("code_gohome"))
                        End If
                    End If
                End If
            Else
                txt = "ยังไม่จ่าย"
                txt_st_pay = "0"
            End If
            itmx1.SubItems.Add(CDbl(resLoad.GetString("alltotal")) - CDbl(resLoad.GetString("yes")) - CDbl(resLoad.GetString("no")))
            itmx1.SubItems.Add(resLoad.GetString("create_date"))
            itmx1.SubItems.Add(txt)
            itmx1.SubItems.Add(txt_st_pay)
            itmx1.SubItems.Add(CDbl(resLoad.GetString("discount_sum")))
            itmx1.SubItems.Add(resLoad.GetString("price_exclu_vat"))
            itmx1.SubItems.Add(resLoad.GetString("vat"))
            itmx1.SubItems.Add(resLoad.GetString("serviceCh"))
            y += 1
        End While
                resLoad.Close()
    End Sub
    Private Function GetNumberINV_POSINV_FROMCODEHOME(ByVal code_home)
        Dim p As String = ""
        Dim h As MySqlDataReader = con.mysql_query("SELECT pos_invoice.namber_inv as namber_inv From pos_order_list INNER JOIN pos_invoice ON pos_invoice.id = pos_order_list.rf_id_invoice where pos_order_list.code_gohome='" & code_home & "' GROUP BY pos_order_list.rf_id_invoice;")
        While h.Read()
            p &= CDbl(h.GetString("namber_inv")) & " , "
        End While
        h.Close()
        Return p
    End Function
    Private Function CheckPay(ByVal code_gh)
        Dim r As Boolean = False
        Dim ch As Integer = con.mysql_num_rows(con.mysql_query("select * from pos_order_list where status_pay='no' and code_gohome='" & code_gh & "';"))
        If ch > 0 Then
            r = True
        Else
            r = False
        End If
        Return r
    End Function
    Public Function checkvoid(ByVal idinv)
        Dim b As Boolean = False
        Dim r As MySqlDataReader = con.mysql_query("SELECT * FROM pos_invoice WHERE id='" & idinv & "'")
        While r.Read()
            If r.GetString("void") = "1" Then
                b = True
            Else
                b = False
            End If
        End While
        r.Close()
        Return b
    End Function
    Public Sub LoadListFood()
        If ListView_GH.SelectedItems.Count > 0 Then
            TextBox2.Text = ListView_GH.Items(ListView_GH.SelectedIndices(0)).SubItems(0).Text
            Dim itmx1 As New ListViewItem
            ListView_GHF.Items.Clear()
            Dim resLoadF As MySqlDataReader = con.mysql_query("SELECT pos_order_list.id_ord AS id_ord,pos_order_list.status_sd_captain AS status_sd_captain," _
            & "pos_order_list.rf_id_prd AS rf_id_prd,pos_order_list.rf_id_con As rf_id_con,pos_order_list.name_ord AS name_ord,pos_order_list.name_ord_en AS name_ord_en," _
            & "  pos_order_list.prs AS prs,pos_order_list.remark AS remark,pos_order_list.code_gohome AS code_gohome ,pos_order_list.remark_tb as remark_tb," _
            & " SUM(pos_order_list.amt) AS samt,SUM(pos_order_list.price) AS sprice,IFNULL(pos_product_size.name_th,0) AS name_size " _
            & ",IFNULL(pos_product_condition.ref_id_unit,'0') as ref_id_unit,pos_product_unit.name_th as name_th_unit,pos_product_unit.name_en as name_en_unit" _
            & ",pos_order_list.order_dis_val as order_dis_val,pos_order_list.order_dis_type as order_dis_type,pos_order_list.order_dis_sum as order_dis_sum" _
            & ",pos_order_list.ref_cat_id as ref_cat_id,pos_order_list.ref_catsubprd as ref_catsubprd,pos_order_list.name_th_cat as name_th_cat,pos_order_list.name_en_cat as name_en_cat," _
            & "pos_order_list.name_th_catsubprd as name_th_catsubprd,pos_order_list.name_en_catsubprd as name_en_catsubprd,pos_order_list.ord_vat as ord_vat,pos_order_list.ord_vat_st as ord_vat_st" _
            & " FROM pos_order_list  LEFT JOIN pos_product_condition ON pos_order_list.rf_id_con =  pos_product_condition.id" _
            & " LEFT JOIN pos_product_ingredients ON pos_product_ingredients.id  =  pos_product_condition.ref_id_ingredients" _
            & " LEFT JOIN pos_product_size ON pos_product_size.id =  pos_product_condition.ref_id_size " _
            & " LEFT JOIN pos_product_unit ON pos_product_unit.id =  pos_product_condition.ref_id_unit " _
            & " WHERE (pos_order_list.status_sd_captain<>'void') and code_gohome ='" & ListView_GH.Items(ListView_GH.SelectedIndices(0)).SubItems(0).Text() & "'  " _
            & " GROUP BY  pos_order_list.rf_id_prd,pos_order_list.rf_id_con,pos_order_list.name_ord")

            Dim i As Integer = 0
            Dim nameSize As String = ""
            While resLoadF.Read
                itmx1 = ListView_GHF.Items.Add(resLoadF.GetString("id_ord"), i)
                itmx1.SubItems.Add(resLoadF.GetString("status_sd_captain"))
                itmx1.SubItems.Add(resLoadF.GetString("rf_id_prd"))
                itmx1.SubItems.Add(resLoadF.GetString("rf_id_con"))
                itmx1.SubItems.Add(resLoadF.GetString("name_ord"))
                itmx1.SubItems.Add(resLoadF.GetString("name_ord_en"))
                If resLoadF.GetString("name_size") <> "0" And CInt(resLoadF.GetString("ref_id_unit")) = 0 Then
                    nameSize = resLoadF.GetString("name_size")
                ElseIf resLoadF.GetString("name_size") = "0" And CInt(resLoadF.GetString("ref_id_unit")) > 0 Then
                    If resLoadF.GetString("name_th_unit") <> "" Then
                        nameSize = resLoadF.GetString("name_th_unit")
                    Else
                        nameSize = resLoadF.GetString("name_en_unit")
                    End If
                Else
                    nameSize = ""
                End If
                itmx1.SubItems.Add(nameSize)
                itmx1.SubItems.Add(resLoadF.GetString("samt"))
                itmx1.SubItems.Add(FormatNumber(resLoadF.GetString("sprice"), 2))
                itmx1.SubItems.Add(resLoadF.GetString("remark"))
                itmx1.SubItems.Add(resLoadF.GetString("order_dis_val"))
                itmx1.SubItems.Add(resLoadF.GetString("order_dis_type"))
                itmx1.SubItems.Add(resLoadF.GetString("order_dis_sum"))
                itmx1.SubItems.Add(FormatNumber(CDbl(resLoadF.GetString("sprice")) - CDbl(resLoadF.GetString("order_dis_sum")), 2))
                itmx1.SubItems.Add(resLoadF.GetString("ref_cat_id"))
                itmx1.SubItems.Add(resLoadF.GetString("ref_catsubprd"))
                itmx1.SubItems.Add(resLoadF.GetString("name_th_cat"))
                itmx1.SubItems.Add(resLoadF.GetString("name_en_cat"))
                itmx1.SubItems.Add(resLoadF.GetString("name_th_catsubprd"))
                itmx1.SubItems.Add(resLoadF.GetString("name_en_catsubprd"))
                itmx1.SubItems.Add(resLoadF.GetString("ord_vat"))
                itmx1.SubItems.Add(resLoadF.GetString("ord_vat_st"))
                i += 1
            End While
            resLoadF.Close()
            ' Load Show Void List
            Dim resLoadFV As MySqlDataReader = con.mysql_query("SELECT pos_order_list.id_ord AS id_ord,pos_order_list.status_sd_captain AS status_sd_captain," _
           & "pos_order_list.rf_id_prd AS rf_id_prd,pos_order_list.rf_id_con As rf_id_con,pos_order_list.name_ord AS name_ord,pos_order_list.name_ord_en AS name_ord_en," _
           & "  pos_order_list.prs AS prs,pos_order_list.remark AS remark,pos_order_list.code_gohome AS code_gohome ," _
           & " SUM(pos_order_list.amt) AS samt,SUM(pos_order_list.price) AS sprice,IFNULL(pos_product_size.name_th,0) AS name_size " _
           & ",IFNULL(pos_product_condition.ref_id_unit,'0') as ref_id_unit,pos_product_unit.name_th as name_th_unit,pos_product_unit.name_en as name_en_unit" _
           & ",pos_order_list.order_dis_val as order_dis_val,pos_order_list.order_dis_type as order_dis_type,pos_order_list.order_dis_sum as order_dis_sum" _
           & ",pos_order_list.ref_cat_id as ref_cat_id,pos_order_list.ref_catsubprd as ref_catsubprd,pos_order_list.name_th_cat as name_th_cat,pos_order_list.name_en_cat as name_en_cat," _
           & "pos_order_list.name_th_catsubprd as name_th_catsubprd,pos_order_list.name_en_catsubprd as name_en_catsubprd,pos_order_list.ord_vat as ord_vat,pos_order_list.ord_vat_st as ord_vat_st" _
           & "  FROM pos_order_list  LEFT JOIN pos_product_condition ON pos_order_list.rf_id_con =  pos_product_condition.id" _
           & " LEFT JOIN pos_product_ingredients ON pos_product_ingredients.id  =  pos_product_condition.ref_id_ingredients" _
           & " LEFT JOIN pos_product_size ON pos_product_size.id =  pos_product_condition.ref_id_size " _
           & " LEFT JOIN pos_product_unit ON pos_product_unit.id =  pos_product_condition.ref_id_unit " _
           & " WHERE (pos_order_list.status_pay='no' or pos_order_list.status_pay='yes') and (pos_order_list.status_sd_captain='void' or pos_order_list.status_sd_captain='voidp') and code_gohome ='" & ListView_GH.Items(ListView_GH.SelectedIndices(0)).SubItems(0).Text() & "'  " _
           & " GROUP BY  pos_order_list.rf_id_prd,pos_order_list.rf_id_con,pos_order_list.name_ord")
            Dim cmax As Integer = ListView_GHF.Items.Count
            While resLoadFV.Read
                itmx1 = ListView_GHF.Items.Add(resLoadFV.GetString("id_ord"), cmax + 1)
                itmx1.SubItems.Add("voidp")
                itmx1.SubItems.Add(resLoadFV.GetString("rf_id_prd"))
                itmx1.SubItems.Add(resLoadFV.GetString("rf_id_con"))
                itmx1.SubItems.Add(resLoadFV.GetString("name_ord"))
                itmx1.SubItems.Add(resLoadFV.GetString("name_ord_en"))
                If resLoadFV.GetString("name_size") <> "0" And CInt(resLoadFV.GetString("ref_id_unit")) = 0 Then
                    nameSize = resLoadFV.GetString("name_size")
                ElseIf resLoadFV.GetString("name_size") = "0" And CInt(resLoadFV.GetString("ref_id_unit")) > 0 Then
                    If resLoadFV.GetString("name_th_unit") <> "" Then
                        nameSize = resLoadFV.GetString("name_th_unit")
                    Else
                        nameSize = resLoadFV.GetString("name_en_unit")
                    End If
                Else
                    nameSize = ""
                End If
                itmx1.SubItems.Add(nameSize)
                itmx1.SubItems.Add(resLoadFV.GetString("samt"))
                itmx1.SubItems.Add(FormatNumber(resLoadFV.GetString("sprice"), 2))
                itmx1.SubItems.Add(resLoadFV.GetString("remark"))
                itmx1.SubItems.Add(resLoadFV.GetString("order_dis_val"))
                itmx1.SubItems.Add(resLoadFV.GetString("order_dis_type"))
                itmx1.SubItems.Add(resLoadFV.GetString("order_dis_sum"))
                itmx1.SubItems.Add(FormatNumber(CDbl(resLoadFV.GetString("sprice")) - CDbl(resLoadFV.GetString("order_dis_sum")), 2))
                itmx1.SubItems.Add(resLoadFV.GetString("ref_cat_id"))
                itmx1.SubItems.Add(resLoadFV.GetString("ref_catsubprd"))
                itmx1.SubItems.Add(resLoadFV.GetString("name_th_cat"))
                itmx1.SubItems.Add(resLoadFV.GetString("name_en_cat"))
                itmx1.SubItems.Add(resLoadFV.GetString("name_th_catsubprd"))
                itmx1.SubItems.Add(resLoadFV.GetString("name_en_catsubprd"))
                itmx1.SubItems.Add(resLoadFV.GetString("ord_vat"))
                itmx1.SubItems.Add(resLoadFV.GetString("ord_vat_st"))
                itmx1.ForeColor = Color.Red
            End While
            resLoadFV.Close()

            Dim price_notvat As Double = 0
            Dim sum_vat As Double = 0
            Dim total As Double = 0
            Dim disc As Double = 0
            For y As Integer = 0 To ListView_GHF.Items.Count - 1
                total += ListView_GHF.Items(y).SubItems(13).Text
                disc -= ListView_GHF.Items(y).SubItems(12).Text
            Next
            TextBox1.Text = FormatNumber(ListView_GH.Items(ListView_GH.SelectedIndices(0)).SubItems(2).Text, 2)
            txt_sum_discount.Text = FormatNumber(CDbl(ListView_GH.Items(ListView_GH.SelectedIndices(0)).SubItems(6).Text) - CDbl(disc), 2)
            txt_priceall.Text = FormatNumber(CDbl(ListView_GH.Items(ListView_GH.SelectedIndices(0)).SubItems(7).Text), 2)
            txt_sum_vat.Text = FormatNumber(CDbl(ListView_GH.Items(ListView_GH.SelectedIndices(0)).SubItems(8).Text), 2)
            txt_sum_service_chg.Text = FormatNumber(CDbl(ListView_GH.Items(ListView_GH.SelectedIndices(0)).SubItems(9).Text), 2)

            If ListView_GH.Items(ListView_GH.SelectedIndices(0)).SubItems(4).Text() = "จ่ายแล้ว" Or ListView_GH.Items(ListView_GH.SelectedIndices(0)).SubItems(4).Text() = "จ่ายแล้ว(ยกเลิกรายการ)" Then
                Label4.Text = "Status: Paid"
                Label4.Tag = "Paid"
            Else
                Label4.Text = "Status: No"
                Label4.Tag = "No"
            End If

        Else
            MessageBox.Show("กรุณาเลือกรายการด้วยค่ะ", "Message Alert")
        End If
    End Sub
    Private Sub btn_addGoHome_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_addGoHome.Click
        index.ReservationP = False
        home1.Change_Tb = False
        index.Gohome = True
        Login.OpenId = 0
        'home1.Close()
        ' index.openCloseMenu(opentakehome)
        index.CloseForm()
        opentakehome.MdiParent = index
        opentakehome.Show()
        opentakehome.WindowState = FormWindowState.Minimized
        opentakehome.WindowState = FormWindowState.Maximized
        Login.Formname = "opentakehome"
        opentakehome.clearData()
        opentakehome.Label_tb_select.Text = "Code :"
        opentakehome.Code_GohomeEdit = ""
        opentakehome.page = "gohome_list"
        opentakehome.LoadCheckSendCaptain()
        index.Add_order = False
        Me.Close()
    End Sub

    Private Sub btn_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_close.Click
        index.CloseForm()
        index.Gohome = False
        idCode = "0"
        'index.openCloseMenu(home1)
        Me.Close()
        index.ishomeopen = True
        home1.MdiParent = index
        home1.Show()
        home1.WindowState = FormWindowState.Minimized
        home1.WindowState = FormWindowState.Maximized
        Login.Formname = "home1"
    End Sub
    Private Sub none_display()
        btn_edit.Enabled = False
        btn_voidall.Enabled = False
        btn_pay.Enabled = False
        printAgain.Enabled = False
        btn_void_order.Enabled = False
    End Sub


    Private Sub btn_up_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_up.Click
        If ListView_GH.Items.Count > 0 Then
            If ListView_GH.SelectedItems.Count > 0 Then
                If ListView_GH.SelectedIndices(0) > 0 Then
                    ListView_GH.Items.Item(ListView_GH.SelectedIndices(0) - 1).Selected = True
                    ListView_GH.Focus()
                    If ListView_GH.Items(ListView_GH.SelectedIndices(0)).SubItems(4).Text() = "yes" Or ListView_GH.Items(ListView_GH.SelectedIndices(0)).SubItems(4).Text() = "จ่ายแล้ว" Then
                        none_display()
                    Else
                        printAgain.Enabled = True
                        btn_pay.Enabled = True
                        btn_voidall.Enabled = True
                        btn_edit.Enabled = True
                        btn_void_order.Enabled = True
                    End If

                End If
                s1()

            Else
                ListView_GH.Items.Item(0).Selected = True
                ListView_GH.Focus()
                If ListView_GH.Items(ListView_GH.SelectedIndices(0)).SubItems(4).Text() = "yes" Or ListView_GH.Items(ListView_GH.SelectedIndices(0)).SubItems(4).Text() = "จ่ายแล้ว" Then
                    none_display()
                Else
                    printAgain.Enabled = True
                    btn_pay.Enabled = True
                    btn_voidall.Enabled = True
                    btn_edit.Enabled = True
                    btn_void_order.Enabled = True
                End If
                s1()

            End If

        End If
    End Sub

    Private Sub btn_drow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_drow.Click
        If ListView_GH.Items.Count > 0 Then
            If ListView_GH.SelectedItems.Count > 0 Then
                If ListView_GH.SelectedIndices(0) < ListView_GH.Items.Count - 1 Then
                    ListView_GH.Items.Item(ListView_GH.SelectedIndices(0) + 1).Selected = True
                    ListView_GH.Focus()

                    If ListView_GH.Items(ListView_GH.SelectedIndices(0)).SubItems(4).Text() = "yes" Or ListView_GH.Items(ListView_GH.SelectedIndices(0)).SubItems(4).Text() = "จ่ายแล้ว" Then
                        none_display()
                    Else
                        printAgain.Enabled = True
                        btn_pay.Enabled = True
                        btn_voidall.Enabled = True
                        btn_edit.Enabled = True
                        btn_void_order.Enabled = True
                    End If

                End If
                s1()
            Else
                ListView_GH.Items.Item(ListView_GH.Items.Count - 1).Selected = True
                ListView_GH.Focus()
                If ListView_GH.Items(ListView_GH.SelectedIndices(0)).SubItems(4).Text() = "yes" Or ListView_GH.Items(ListView_GH.SelectedIndices(0)).SubItems(4).Text() = "จ่ายแล้ว" Then
                    none_display()
                Else
                    printAgain.Enabled = True
                    btn_pay.Enabled = True
                    btn_voidall.Enabled = True
                    btn_edit.Enabled = True
                    btn_void_order.Enabled = True
                End If
                s1()
            End If

        End If
    End Sub
    Public TabEvent As String = "TabPage1"
    Private Sub TabControl1_TabIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.Click
        If TabControl1.SelectedTab.Tag = "TabPage2" Then
            'LoadListFood()
            btn_edit.Enabled = False
            TabEvent = "TabPage2"
        Else
            btn_edit.Enabled = True
            TabEvent = "TabPage1"
            Label4.Text = ""
        End If
    End Sub

    Private Sub btn_edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_edit.Click
        index.Gohome = True
        If ListView_GH.SelectedItems.Count > 0 Then
            index.Add_order = True
            opentakehome.MdiParent = index
            opentakehome.Show()
            opentakehome.WindowState = FormWindowState.Minimized
            opentakehome.WindowState = FormWindowState.Maximized
            opentakehome.page = "gohome_list"
            opentakehome.Label_tb_select.Text = "Code :" & ListView_GH.Items(ListView_GH.SelectedIndices(0)).SubItems(0).Text()
            opentakehome.btn_pay.Enabled = True
            opentakehome.Code_GohomeEdit = ListView_GH.Items(ListView_GH.SelectedIndices(0)).SubItems(0).Text()
            opentakehome.Load_Product_list()
            index.CloseForm()
            Login.Formname = "opentakehome"
            Me.Close()
            'End If
        Else
            MessageBox.Show("กรุณาเลือกรายการที่จะแก้ไขด้วยค่ะ", "Message Alert")
        End If
    End Sub

    Private Sub btn_refres_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_refres.Click
        LoadList()
    End Sub
    Public Sub calsum()
        Dim Summary_plus As Double = 0.0
        For x As Integer = 0 To ListView_GHF.Items.Count - 1
            If ListView_GHF.Items(x).SubItems(1).Text.ToLower = "yes" Then
                Summary_plus += CDbl(ListView_GHF.Items(x).SubItems(8).Text)
            End If
        Next
        TextBox1.Text = (Summary_plus)
        Summary_plus = 0
    End Sub
    Public void_remark As String = ""
    Private Sub btn_voidall_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_voidall.Click
        If ListView_GH.SelectedItems.Count > 0 Then
            index.Gohome = True
            If MessageBox.Show("คุณมั่นใจใช่ไหมที่จะยกเลิกรายการนี้?", "Alert Comfirm Void Order?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                If voidReson.ShowDialog() Then
                    If voidReson.EnterT = True Then
                        Dim code_ghome As String = TextBox2.Text
                        btn_voidall.Enabled = False
                        PrintVoidOrder(code_ghome) '===== print void ==='
                        Dim queryOrd As Boolean = False
                        Dim invoice_id_void As Integer = 0
                        Dim str As String = ""
                        Dim order As MySqlDataReader = con.mysql_query("select * from pos_order_list WHERE code_gohome='" & code_ghome & "' and status_pay='no' and (status_sd_captain<>'void' or status_sd_captain<>'voidp') ")
                        While order.Read
                            str &= "DELETE FROM pos_invoice_temp WHERE id='" & order.GetString("rf_id_invoice") & "';"
                            opentable.returnStock(order.GetString("rf_id_prd"), order.GetString("rf_id_con"), order.GetString("amt")) 'Query Data for return Stock ดึงข้อมูลมาคืนค่าของให้สต๊อกสินค้า
                        End While
                        str &= "UPDATE pos_order_list SET status_sd_captain='void'  WHERE code_gohome='" & code_ghome & "' and status_open='gohome' and status_pay='no';"
                        str &= "INSERT INTO pos_order_void (ref_id_tb,rf_id_invoice,rf_id_prd,rf_id_con,code_gohome,remark_v,"
                        str &= "name_ord,name_ord_en,amt_v,price_v,prs_v,ref_cat_id_v,ref_catsubprd_v,name_th_cat_v,"
                        str &= "name_en_cat_v,name_th_catsubprd_v,name_en_catsubprd_v,ord_vat_v,ord_vat_st_v,prd_type_dis_id_v,"
                        str &= "prd_type_dis_en_v,prd_type_dis_th_v,actionBy,date_void)"
                        str &= " SELECT pos_order_list.rf_id_table,pos_order_list.rf_id_invoice,pos_order_list.rf_id_prd,"
                        str &= "pos_order_list.rf_id_con,'" & code_ghome & "','" & void_remark & "',pos_order_list.name_ord,"
                        str &= "pos_order_list.name_ord_en,pos_order_list.amt,pos_order_list.price,pos_order_list.prs,"
                        str &= "pos_order_list.ref_cat_id,pos_order_list.ref_catsubprd,pos_order_list.name_th_cat,pos_order_list.name_en_cat,"
                        str &= "pos_order_list.name_th_catsubprd,pos_order_list.name_en_catsubprd,pos_order_list.ord_vat,"
                        str &= "pos_order_list.ord_vat_st,pos_order_list.prd_type_dis_id,pos_order_list.prd_type_dis_en,"
                        str &= "pos_order_list.prd_type_dis_th,'" & Login.username & "','" & Login.DateData.ToString("yyyy-MM-dd HH:mm:ss") & "'"
                        str &= " FROM pos_order_list WHERE code_gohome='" & code_ghome & "' and status_open='gohome' and status_pay='no' and status_sd_captain='void';"

                        order.Close()
                        If str <> "" Then
                            queryOrd = con.mysql_query(str)
                            btn_pay.Enabled = False
                            btn_edit.Enabled = False
                            printAgain.Enabled = False
                            btn_void_order.Enabled = False
                            TextBox2.Text = ""
                            LoadList()
                        End If
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub PrintVoidOrder(ByVal code_gohome)
        Try
            Dim array_print As New ArrayList
            Dim array_idtemp As New ArrayList
            Dim array_sendcap As New ArrayList
            Dim array_namecat As New ArrayList
            Dim array_countGroup As New ArrayList
            array_print.Clear()
            array_idtemp.Clear()
            array_sendcap.Clear()
            array_namecat.Clear()
            array_countGroup.Clear()
            '======== query group prd for add array print =========='
            Dim q_groupprd As MySqlDataReader = con.mysql_query("select * from pos_order_list where status_sd_captain<>'void' and code_gohome='" & code_gohome & "' and status_pay='no' and status_open='gohome' GROUP BY ref_cat_id;")
            Dim printername_v As String = ""
            Dim copy2captain As String = ""
            Dim id_ref_temp As String = ""
            Dim k As Integer = 0
            While q_groupprd.Read()
                array_countGroup.Add(q_groupprd.GetString("ref_cat_id"))
                printername_v = opentable.Get_printer(q_groupprd.GetString("ref_cat_id"))
                copy2captain = opentable.Get_CopySendcaptain(q_groupprd.GetString("ref_cat_id"))
                id_ref_temp = "P" & Login.DateData.ToString("dd") & Login.DateData.ToString("MM") & Login.DateData.ToString("yy") & Format(DateAndTime.Now, "HH") & Format(DateAndTime.Now, "mm") & Format(DateAndTime.Now, "ss") & "0" & k
                array_print.Add(printername_v)
                array_idtemp.Add(id_ref_temp)
                array_sendcap.Add(copy2captain)
                array_namecat.Add(q_groupprd.GetString("name_en_cat"))
                k += 1
            End While
            ' =========== query data inert temp print =============='
            Dim str_p As String = ""
            Dim q_tmpprint As MySqlDataReader = con.mysql_query("select * from  pos_order_list where status_sd_captain<>'void' and code_gohome='" & code_gohome & "' and status_pay='no' and status_open='gohome';")
            While q_tmpprint.Read
                For t As Integer = 0 To array_countGroup.Count - 1
                    If q_tmpprint.GetString("ref_cat_id") = array_countGroup(t).ToString Then
                        str_p &= "INSERT INTO pos_temp_print (rf_id_prd,rf_id_con,name_ord,name_ord_en,amt,price,prs,rf_id_table,status_sd_captain,status_pay,status_open,remark,create_date,code_gohome,name_cat_en,name_cat_th,id_ref_temp)" _
                        & " VALUES('" & q_tmpprint.GetString("rf_id_prd") & "','" & q_tmpprint.GetString("rf_id_con") & "','" & q_tmpprint.GetString("name_ord") & "','" & q_tmpprint.GetString("name_ord_en") & "'," _
                        & "'" & q_tmpprint.GetString("amt") & "','" & q_tmpprint.GetString("price") & "','1','0'," _
                        & "'void','no','gohome','" & voidReson.TextBox1.Text & "'," _
                        & "'" & Login.DateData.ToString("yyyy-MM-dd") & Date.Now.ToString(" HH:mm:ss") & "','" & TextBox2.Text & "','" & array_namecat(t).ToString & "','" & array_namecat(t).ToString & "','" & array_idtemp(t).ToString & "');"
                    End If
                Next
            End While
            q_tmpprint.Close()
            If str_p <> "" Then
                con.mysql_query(str_p)
            End If
            For h As Integer = 0 To array_countGroup.Count - 1
                'Print Void Order
                Dim WorkerThread As Thread
                Dim W As New worker
                Thread.Sleep(1000)
                W.setSendCaptainCancel("0", "gohome", TextBox2.Text, Login.DateData.ToString("dd/MM/yyyy"), TextBox2.Text, Login.username, array_print(h).ToString, array_idtemp(h).ToString)
                WorkerThread = New Thread(AddressOf W.Start)    'Create our Worker thread and tell it that when we start it it should call our Worker's Start() method
                WorkerThread.Start()
                If Login.LangG = "TH" Then
                    dialog_complete.Label_Dialog.Text = "ยกเลิกรายการถึง " & array_namecat(h).ToString & " เรียบร้อยแล้วค่ะ"
                    dialog_complete.ShowDialog()
                Else
                    dialog_complete.Label_Dialog.Text = "Cancel order " & array_namecat(h).ToString & " Complete."
                    dialog_complete.ShowDialog()
                End If
            Next
            voidReson.EnterT = False
            ListView_GHF.Items.Clear()
            ' LoadList()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString())
        End Try
    End Sub
    Private Sub btn_pay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_pay.Click
        Try
            idCode = "0"
            index.Gohome = True
            If ListView_GH.Items.Count > 0 Then
                '=======Check ว่ามี invoice หรือยัง และหลังจากนั้น เอาข้อมูลของ invoice นั้นๆขึ้นมา เพื่อส่งค่าไปหน้า payment ในช่อง ส่วนลดทั้งบิล หรือ อื่นๆ ====='
                payment_gohome.code_gohome = TextBox2.Text
                payment_gohome.selBill_sendgohomelist = selBill
                payment_gohome.MdiParent = index
                payment_gohome.Show()
                payment_gohome.WindowState = FormWindowState.Minimized
                payment_gohome.WindowState = FormWindowState.Maximized
                payment_gohome.Label_Num_Pay.Text = "Payment : " & TextBox2.Text
                payment_gohome.Btn_Enter.Enabled = True
                payment_gohome.page = "gohome_list"
                'payment_gohome.s1()
                index.CloseForm()
                Login.Formname = "payment_gohome"
                Me.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message & "-->BTN_PAYMENT_GOHOME")
        End Try
    End Sub

    Private Sub printAgain_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles printAgain.Click
        Try
            If ListView_GH.SelectedItems.Count > 0 Then
                index.Gohome = True
                form_reprint_captain_gh.ShowDialog()
                form_reprint_captain_gh.gh_id = TextBox2.Text
               
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString())
        End Try
    End Sub
    Private Sub ListView_GH_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView_GH.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Left Then
            idCode = ListView_GH.Items(ListView_GH.SelectedIndices(0)).SubItems(0).Text()
            TextBox2.Text = ListView_GH.Items(ListView_GH.SelectedIndices(0)).SubItems(0).Text
            If ListView_GH.Items(ListView_GH.SelectedIndices(0)).SubItems(4).Text() = "yes" Or ListView_GH.Items(ListView_GH.SelectedIndices(0)).SubItems(4).Text() = "จ่ายแล้ว" Then
                none_display()
            Else
                btn_edit.Enabled = True
                btn_voidall.Enabled = True
                btn_void_order.Enabled = True
                printAgain.Enabled = True
                btn_pay.Enabled = True
            End If
            s1() ' LOAD order list
        End If
    End Sub

    Private Sub ListView_GH_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView_GH.DoubleClick
        index.Gohome = True
        If ListView_GH.SelectedItems.Count > 0 Then
            'Check is payment 
            '  If ListView_GH.Items(ListView_GH.SelectedIndices(0)).SubItems(4).Text = "ยังไม่จ่าย" Or ListView_GH.Items(ListView_GH.SelectedIndices(0)).SubItems(4).Text = "" Then
            ' MsgBox(ListView_GH.Items(ListView_GH.SelectedIndices(0)).SubItems(0).Text())
            If ListView_GH.Items(ListView_GH.SelectedIndices(0)).SubItems(4).Text() = "yes" Or ListView_GH.Items(ListView_GH.SelectedIndices(0)).SubItems(4).Text() = "จ่ายแล้ว" Then
                none_display()
            Else
                btn_edit.Enabled = True
                btn_voidall.Enabled = True
                btn_void_order.Enabled = True
                printAgain.Enabled = True
                btn_pay.Enabled = True

                index.Add_order = True
                opentakehome.MdiParent = index
                opentakehome.Show()
                opentakehome.WindowState = FormWindowState.Minimized
                opentakehome.WindowState = FormWindowState.Maximized
                opentakehome.page = "gohome_list"
                opentakehome.Label_tb_select.Text = "Code :" & ListView_GH.Items(ListView_GH.SelectedIndices(0)).SubItems(0).Text()
                ' opentakehome.Load_Product_list()
                opentakehome.btn_pay.Enabled = True
                opentakehome.Code_GohomeEdit = ListView_GH.Items(ListView_GH.SelectedIndices(0)).SubItems(0).Text()
                opentakehome.Load_Product_list()
                index.CloseForm()
                Login.Formname = "opentakehome"
                Me.Close()
            End If
        Else
            MessageBox.Show("กรุณาเลือกรายการที่จะแก้ไขด้วยค่ะ", "Message Alert")
        End If
    End Sub
    Private Sub s1()
        FlowLayoutPanel_Bill.Controls.Clear()
        Dim x As MySqlDataReader = con.mysql_query("SELECT * FROM pos_order_list WHERE status_open='gohome' and code_gohome='" & ListView_GH.Items(ListView_GH.SelectedIndices(0)).SubItems(0).Text() & "' GROUP BY rf_id_invoice ASC")
        Dim j As Integer = 1
        While x.Read()
            Dim btn As New Button
            btn.Name = "no" & j
            btn.Width = "102"
            btn.Height = "33"
            btn.Tag = x.GetString("rf_id_invoice") & "_" & x.GetString("status_pay")
            btn.Text = "No." & j
            btn.Cursor = Cursors.Hand
            btn.BackColor = Color.Gainsboro
            btn.FlatStyle = FlatStyle.Flat
            btn.FlatAppearance.BorderColor = Color.Silver
            btn.FlatAppearance.BorderSize = "1"
            btn.Margin = New Padding(0, 0, 0, 0)
            btn.Font = New Drawing.Font("Microsoft Sans Serif", 12, FontStyle.Bold)
            AddHandler btn.Click, AddressOf ShowBill
            FlowLayoutPanel_Bill.Controls.Add(btn)
            If btn.Text = "No.1" Then
                If x.GetString("status_pay") = "no" Then
                    s2(x.GetString("rf_id_invoice")) '==load data show =='
                Else
                    s3(x.GetString("rf_id_invoice")) '==load data show =='
                End If
                btn.PerformClick() '== สั่งให้click อัตโนมัติ==='
            End If
            j += 1
        End While
    End Sub
    Private Sub ShowBill(ByVal sender As System.Object, ByVal e As System.EventArgs)
        For i As Integer = 0 To FlowLayoutPanel_Bill.Controls.Count - 1
            Dim temp As Button = FlowLayoutPanel_Bill.Controls.Item(i)
            temp.BackColor = Color.Gainsboro
        Next
        Dim btn As Button = CType(sender, Button)
        Dim strArr_selbill() As String
        strArr_selbill = btn.Tag.Split("_")
        selBill = strArr_selbill(0)
        btn.BackColor = SystemColors.ActiveCaption
        btn.FlatAppearance.BorderColor = Color.Silver
        btn.FlatAppearance.BorderSize = "1"
        If strArr_selbill(1) = "yes" Then
            s3(strArr_selbill(0)) 'load data show
        Else
            s2(strArr_selbill(0)) 'load data show
        End If
        payment_gohome_subp_dialog.sel_bill = btn.Tag.ToString
    End Sub
    Public Sub s2(ByVal id_inv)
        ListView_GHF.Items.Clear()
        Dim y As Integer = con.mysql_num_rows(con.mysql_query("select * from pos_invoice_temp where id='" & id_inv & "' "))
        If y > 0 Then
            Dim res_tb As MySqlDataReader = con.mysql_query("SELECT pos_order_list.id_ord AS id_ord,pos_order_list.status_sd_captain AS status_sd_captain," _
            & "pos_order_list.rf_id_prd AS rf_id_prd,pos_order_list.rf_id_con As rf_id_con,pos_order_list.name_ord AS name_ord,pos_order_list.name_ord_en AS name_ord_en," _
            & "pos_order_list.prs AS prs,pos_order_list.remark AS remark,pos_order_list.ref_id_join AS ref_id_join," _
            & "SUM(pos_order_list.amt) AS samt,SUM(pos_order_list.price) AS sprice,IFNULL(pos_product_size.name_th,0) AS name_size  " _
            & ",IFNULL(pos_order_list.order_dis_val,'0') as order_dis_val,IFNULL(pos_order_list.order_dis_type,'0') as order_dis_type,IFNULL(pos_order_list.order_dis_sum,'0') as order_dis_sum,IFNULL(pos_order_list.rf_id_invoice,'0') as rf_id_invoice," _
            & "pos_order_list.ref_cat_id as ref_cat_id,pos_order_list.ref_catsubprd as ref_catsubprd,pos_order_list.name_th_cat as name_th_cat,pos_order_list.name_en_cat as name_en_cat," _
            & "pos_order_list.name_th_catsubprd as name_th_catsubprd,pos_order_list.name_en_catsubprd as name_en_catsubprd,pos_order_list.ord_vat as ord_vat,pos_order_list.ord_vat_st as ord_vat_st" _
            & ",pos_order_list.ref_id_join as ref_id_join,pos_order_list.rf_id_table as rf_id_table" _
            & ",IFNULL(un.name_th,'') as name_unit " _
            & "  FROM pos_order_list " _
             & " LEFT JOIN pos_product_condition ON pos_order_list.rf_id_con =  pos_product_condition.id " _
             & " LEFT JOIN pos_product_ingredients ON pos_product_ingredients.id  =  pos_product_condition.ref_id_ingredients" _
             & " LEFT JOIN pos_product_size ON pos_product_size.id =  pos_product_condition.ref_id_size" _
              & " LEFT JOIN pos_invoice_temp ON pos_invoice_temp.id =  pos_order_list.rf_id_invoice" _
              & " LEFT JOIN pos_product_unit un ON un.id =  pos_product_condition.ref_id_unit" _
            & " WHERE  pos_order_list.status_pay='no' and (pos_order_list.create_date LIKE '%" & Login.DateData.ToString("yyyy-MM-dd") & "%') and " _
            & "pos_order_list.status_open='gohome' " _
            & " and pos_order_list.status_sd_captain <>'void' and pos_order_list.rf_id_invoice='" & id_inv & "' GROUP BY pos_order_list.rf_id_prd,pos_order_list.rf_id_con,pos_order_list.name_ord order by id_ord asc")

            Dim price_new1 As Double = 0.0
            Dim itmx1 As New ListViewItem
            Dim v As Integer = 1
            Dim vats As Double = 0
            Dim price_new As Double = 0
            Dim h_inv As Integer = 0
            Dim order_dis As Double = 0.0
            Dim size_n As String = ""
            While res_tb.Read
                h_inv = res_tb.GetString("rf_id_invoice")
                itmx1 = ListView_GHF.Items.Add(res_tb.GetString("id_ord"), v)
                itmx1.SubItems.Add(res_tb.GetString("status_sd_captain"))
                itmx1.SubItems.Add(res_tb.GetString("rf_id_prd"))
                itmx1.SubItems.Add(res_tb.GetString("rf_id_con"))
                itmx1.SubItems.Add(res_tb.GetString("name_ord"))
                itmx1.SubItems.Add(res_tb.GetString("name_ord_en"))
                If res_tb.GetString("name_size") <> "0" Or res_tb.GetString("name_unit") <> "" Then

                    If res_tb.GetString("name_size") <> "0" Then
                        size_n = res_tb.GetString("name_size")
                    Else
                        size_n = res_tb.GetString("name_unit")
                    End If
                Else
                    size_n = ""
                End If
                itmx1.SubItems.Add(size_n)
                Dim str_vat As String = ""
                If res_tb.GetString("rf_id_prd") = "0" Then
                    vats = 0
                    Dim pprice As Double = CDbl(res_tb.GetDecimal("sprice") / res_tb.GetInt32("samt"))
                    price_new = CDbl(res_tb.GetDecimal("sprice") / res_tb.GetInt32("samt"))
                    If CInt(res_tb.GetString("ord_vat_st")) = 0 Then
                        str_vat = "None(vat)"
                        vats = 0
                        price_new1 = FormatNumber(pprice * CInt(res_tb.GetInt32("samt")), 2)
                    ElseIf CInt(res_tb.GetString("ord_vat_st")) = 1 Then
                        str_vat = "Inc(vat)"
                        vats = pprice - ((pprice * 100) / CInt(res_tb.GetString("ord_vat") + 100))
                        price_new1 = FormatNumber((price_new - vats) * CInt(res_tb.GetInt32("samt")), 2)
                    ElseIf CInt(res_tb.GetString("ord_vat_st")) = 2 Then
                        str_vat = "Add(vat)"
                        vats = pprice * (CInt(res_tb.GetString("ord_vat")) / 100)
                        price_new1 = FormatNumber(price_new * CInt(res_tb.GetInt32("samt")), 2)
                    End If
                Else
                    ' หา vat / status 
                    vats = home1.vat_prd_cal(res_tb.GetString("rf_id_prd"), CDbl(res_tb.GetDecimal("sprice") / res_tb.GetInt32("samt")))
                    price_new = CDbl(res_tb.GetDecimal("sprice") / res_tb.GetInt32("samt"))
                    If home1.vat_in_ex(res_tb.GetString("rf_id_prd")) = "0" Then
                        str_vat = "None(vat)"
                        price_new1 = FormatNumber(price_new * CInt(res_tb.GetInt32("samt")), 2)
                    ElseIf home1.vat_in_ex(res_tb.GetString("rf_id_prd")) = "1" Then
                        str_vat = "Inc(vat)"
                        price_new1 = FormatNumber((price_new - vats) * CInt(res_tb.GetInt32("samt")), 2)
                    ElseIf home1.vat_in_ex(res_tb.GetString("rf_id_prd")) = "2" Then
                        str_vat = "Add(vat)"
                        price_new1 = FormatNumber(price_new * CInt(res_tb.GetInt32("samt")), 2)
                    End If
                End If

                itmx1.SubItems.Add(res_tb.GetInt32("samt"))
                itmx1.SubItems.Add(CDbl(res_tb.GetDecimal("sprice")))
                itmx1.SubItems.Add(res_tb.GetString("remark"))
                If res_tb.GetString("order_dis_val") <> "0" Then
                    itmx1.SubItems.Add(res_tb.GetString("order_dis_val"))
                    itmx1.SubItems.Add(res_tb.GetString("order_dis_type"))
                    itmx1.SubItems.Add(res_tb.GetString("order_dis_sum"))
                    order_dis += res_tb.GetString("order_dis_sum")
                Else
                    itmx1.SubItems.Add("0")
                    itmx1.SubItems.Add("0")
                    itmx1.SubItems.Add("0")
                    order_dis += 0
                End If
                itmx1.SubItems.Add(FormatNumber((CDbl(price_new1 + (vats * CInt(res_tb.GetInt32("samt"))))) - CDbl(res_tb.GetString("order_dis_sum")), 2))
                itmx1.SubItems.Add(res_tb.GetString("ref_cat_id"))
                itmx1.SubItems.Add(res_tb.GetString("ref_catsubprd"))
                itmx1.SubItems.Add(res_tb.GetString("name_en_cat"))
                itmx1.SubItems.Add(res_tb.GetString("name_th_cat"))
                itmx1.SubItems.Add(res_tb.GetString("name_en_catsubprd"))
                itmx1.SubItems.Add(res_tb.GetString("name_th_catsubprd"))
                itmx1.SubItems.Add(res_tb.GetString("ord_vat"))
                itmx1.SubItems.Add(res_tb.GetString("ord_vat_st"))
                v += 1
            End While
            s2_void(id_inv)
            '==== GET DISCOUNT ALL BILL ===='
            Dim disc As Double = 0.0
            Dim discT As String = ""
            Dim discS As Double = 0.0
            Dim txt_priceall_cal As Double = 0.0
            Dim txt_sum_vat_cal As Double = 0.0
            Dim service_ch_sum As Double = 0.0
            Dim sum_price As Double = 0.0
            If h_inv > 0 Then
                Dim hhave_inv As MySqlDataReader = con.mysql_query("select * from pos_invoice_temp where id='" & h_inv & "' ")
                While hhave_inv.Read
                    txt_priceall_cal = hhave_inv.GetString("price_exclu_vat")
                    txt_sum_vat_cal = hhave_inv.GetString("vat")
                    txt_sum_vat_cal = hhave_inv.GetString("vat")
                    service_ch_sum = hhave_inv.GetString("serviceCh")
                    sum_price = hhave_inv.GetString("price_all")
                    If CDbl(hhave_inv.GetString("discount_sum")) > 0 Then
                        disc = hhave_inv.GetString("discount")
                        discT = hhave_inv.GetString("discount_des")
                        discS = hhave_inv.GetString("discount_sum")
                    End If
                End While
                hhave_inv.Close()
                txt_priceall.Text = FormatNumber(txt_priceall_cal, 2)
                txt_sum_vat.Text = FormatNumber(txt_sum_vat_cal, 2)
                txt_sum_discount_bill.Text = FormatNumber("-" & CDbl(discS), 2)
                txt_sum_discount.Text = FormatNumber("-" & CDbl(discS) + order_dis, 2)
                txt_sum_service_chg.Text = FormatNumber(service_ch_sum, 2)
                TextBox1.Text = FormatNumber(sum_price, 2)
                btn_pay.Enabled = True
                Label4.Text = "สถานะ : ยังไม่จ่าย"
            End If
        End If

    End Sub
    Public Sub s2_void(ByVal id_inv)
        '  ListView_GHF.Items.Clear()
        Dim y As Integer = con.mysql_num_rows(con.mysql_query("select * from pos_invoice_temp where id='" & id_inv & "' "))
        If y > 0 Then
            Dim res_tb As MySqlDataReader = con.mysql_query("SELECT pos_order_list.id_ord AS id_ord,pos_order_list.status_sd_captain AS status_sd_captain," _
            & "pos_order_list.rf_id_prd AS rf_id_prd,pos_order_list.rf_id_con As rf_id_con,pos_order_list.name_ord AS name_ord,pos_order_list.name_ord_en AS name_ord_en," _
            & "pos_order_list.prs AS prs,pos_order_list.remark AS remark,pos_order_list.ref_id_join AS ref_id_join," _
            & "SUM(pos_order_list.amt) AS samt,SUM(pos_order_list.price) AS sprice,IFNULL(pos_product_size.name_th,0) AS name_size  " _
            & ",IFNULL(pos_order_list.order_dis_val,'0') as order_dis_val,IFNULL(pos_order_list.order_dis_type,'0') as order_dis_type,IFNULL(pos_order_list.order_dis_sum,'0') as order_dis_sum,IFNULL(pos_order_list.rf_id_invoice,'0') as rf_id_invoice," _
            & "pos_order_list.ref_cat_id as ref_cat_id,pos_order_list.ref_catsubprd as ref_catsubprd,pos_order_list.name_th_cat as name_th_cat,pos_order_list.name_en_cat as name_en_cat," _
            & "pos_order_list.name_th_catsubprd as name_th_catsubprd,pos_order_list.name_en_catsubprd as name_en_catsubprd,pos_order_list.ord_vat as ord_vat,pos_order_list.ord_vat_st as ord_vat_st" _
            & ",pos_order_list.ref_id_join as ref_id_join,pos_order_list.rf_id_table as rf_id_table" _
            & ",IFNULL(un.name_th,'') as name_unit " _
            & "  FROM pos_order_list " _
             & " LEFT JOIN pos_product_condition ON pos_order_list.rf_id_con =  pos_product_condition.id " _
             & " LEFT JOIN pos_product_ingredients ON pos_product_ingredients.id  =  pos_product_condition.ref_id_ingredients" _
             & " LEFT JOIN pos_product_size ON pos_product_size.id =  pos_product_condition.ref_id_size" _
              & " LEFT JOIN pos_invoice_temp ON pos_invoice_temp.id =  pos_order_list.rf_id_invoice" _
              & " LEFT JOIN pos_product_unit un ON un.id =  pos_product_condition.ref_id_unit" _
            & " WHERE  pos_order_list.status_pay='no' and (pos_order_list.create_date LIKE '%" & Login.DateData.ToString("yyyy-MM-dd") & "%') and " _
            & "pos_order_list.status_open='gohome' " _
            & " and pos_order_list.status_sd_captain ='void' and pos_order_list.rf_id_invoice='" & id_inv & "' GROUP BY pos_order_list.rf_id_prd,pos_order_list.rf_id_con,pos_order_list.name_ord order by id_ord asc")

            Dim price_new1 As Double = 0.0
            Dim itmx1 As New ListViewItem
            Dim v As Integer = 1
            Dim vats As Double = 0
            Dim price_new As Double = 0
            Dim h_inv As Integer = 0
            Dim order_dis As Double = 0.0
            Dim size_n As String = ""
            While res_tb.Read
                h_inv = res_tb.GetString("rf_id_invoice")
                itmx1 = ListView_GHF.Items.Add(res_tb.GetString("id_ord"), v)
                itmx1.SubItems.Add(res_tb.GetString("status_sd_captain"))
                itmx1.SubItems.Add(res_tb.GetString("rf_id_prd"))
                itmx1.SubItems.Add(res_tb.GetString("rf_id_con"))
                itmx1.SubItems.Add(res_tb.GetString("name_ord"))
                itmx1.SubItems.Add(res_tb.GetString("name_ord_en"))
                If res_tb.GetString("name_size") <> "0" Or res_tb.GetString("name_unit") <> "" Then
                    If res_tb.GetString("name_size") <> "0" Then
                        size_n = res_tb.GetString("name_size")
                    Else
                        size_n = res_tb.GetString("name_unit")
                    End If
                Else
                    size_n = ""
                End If
                itmx1.SubItems.Add(size_n)
                Dim str_vat As String = ""
                If res_tb.GetString("rf_id_prd") = "0" Then
                    vats = 0
                    Dim pprice As Double = CDbl(res_tb.GetDecimal("sprice") / res_tb.GetInt32("samt"))
                    price_new = CDbl(res_tb.GetDecimal("sprice") / res_tb.GetInt32("samt"))
                    If CInt(res_tb.GetString("ord_vat_st")) = 0 Then
                        str_vat = "None(vat)"
                        vats = 0
                        price_new1 = FormatNumber(pprice * CInt(res_tb.GetInt32("samt")), 2)
                    ElseIf CInt(res_tb.GetString("ord_vat_st")) = 1 Then
                        str_vat = "Inc(vat)"
                        vats = pprice - ((pprice * 100) / CInt(res_tb.GetString("ord_vat") + 100))
                        price_new1 = FormatNumber((price_new - vats) * CInt(res_tb.GetInt32("samt")), 2)
                    ElseIf CInt(res_tb.GetString("ord_vat_st")) = 2 Then
                        str_vat = "Add(vat)"
                        vats = pprice * (CInt(res_tb.GetString("ord_vat")) / 100)
                        price_new1 = FormatNumber(price_new * CInt(res_tb.GetInt32("samt")), 2)
                    End If
                Else
                    ' หา vat / status 
                    vats = home1.vat_prd_cal(res_tb.GetString("rf_id_prd"), CDbl(res_tb.GetDecimal("sprice") / res_tb.GetInt32("samt")))
                    price_new = CDbl(res_tb.GetDecimal("sprice") / res_tb.GetInt32("samt"))
                    If home1.vat_in_ex(res_tb.GetString("rf_id_prd")) = "0" Then
                        str_vat = "None(vat)"
                        price_new1 = FormatNumber(price_new * CInt(res_tb.GetInt32("samt")), 2)
                    ElseIf home1.vat_in_ex(res_tb.GetString("rf_id_prd")) = "1" Then
                        str_vat = "Inc(vat)"
                        price_new1 = FormatNumber((price_new - vats) * CInt(res_tb.GetInt32("samt")), 2)
                    ElseIf home1.vat_in_ex(res_tb.GetString("rf_id_prd")) = "2" Then
                        str_vat = "Add(vat)"
                        price_new1 = FormatNumber(price_new * CInt(res_tb.GetInt32("samt")), 2)
                    End If
                End If

                itmx1.SubItems.Add(res_tb.GetInt32("samt"))
                itmx1.SubItems.Add(CDbl(res_tb.GetDecimal("sprice")))
                itmx1.SubItems.Add(res_tb.GetString("remark"))
                If res_tb.GetString("order_dis_val") <> "0" Then
                    itmx1.SubItems.Add(res_tb.GetString("order_dis_val"))
                    itmx1.SubItems.Add(res_tb.GetString("order_dis_type"))
                    itmx1.SubItems.Add(res_tb.GetString("order_dis_sum"))
                    order_dis += res_tb.GetString("order_dis_sum")
                Else
                    itmx1.SubItems.Add("0")
                    itmx1.SubItems.Add("0")
                    itmx1.SubItems.Add("0")
                    order_dis += 0
                End If
                itmx1.SubItems.Add(FormatNumber((CDbl(price_new1 + (vats * CInt(res_tb.GetInt32("samt"))))) - CDbl(res_tb.GetString("order_dis_sum")), 2))
                itmx1.SubItems.Add(res_tb.GetString("ref_cat_id"))
                itmx1.SubItems.Add(res_tb.GetString("ref_catsubprd"))
                itmx1.SubItems.Add(res_tb.GetString("name_en_cat"))
                itmx1.SubItems.Add(res_tb.GetString("name_th_cat"))
                itmx1.SubItems.Add(res_tb.GetString("name_en_catsubprd"))
                itmx1.SubItems.Add(res_tb.GetString("name_th_catsubprd"))
                itmx1.SubItems.Add(res_tb.GetString("ord_vat"))
                itmx1.SubItems.Add(res_tb.GetString("ord_vat_st"))
                itmx1.ForeColor = Color.Red
                v += 1
            End While

        End If

    End Sub
    Private Sub s3(ByVal id_inv)
        ListView_GHF.Items.Clear()
        Dim y As Integer = con.mysql_num_rows(con.mysql_query("select * from pos_invoice where id='" & id_inv & "' "))
        If y > 0 Then
            Dim res_tb As MySqlDataReader = con.mysql_query("SELECT pos_order_list.id_ord AS id_ord,pos_order_list.status_sd_captain AS status_sd_captain," _
            & "pos_order_list.rf_id_prd AS rf_id_prd,pos_order_list.rf_id_con As rf_id_con,pos_order_list.name_ord AS name_ord,pos_order_list.name_ord_en AS name_ord_en," _
            & "pos_order_list.prs AS prs,pos_order_list.remark AS remark,pos_order_list.ref_id_join AS ref_id_join," _
            & "SUM(pos_order_list.amt) AS samt,SUM(pos_order_list.price) AS sprice,IFNULL(pos_product_size.name_th,0) AS name_size  " _
            & ",IFNULL(pos_order_list.order_dis_val,'0') as order_dis_val,IFNULL(pos_order_list.order_dis_type,'0') as order_dis_type,IFNULL(pos_order_list.order_dis_sum,'0') as order_dis_sum,IFNULL(pos_order_list.rf_id_invoice,'0') as rf_id_invoice," _
            & "pos_order_list.ref_cat_id as ref_cat_id,pos_order_list.ref_catsubprd as ref_catsubprd,pos_order_list.name_th_cat as name_th_cat,pos_order_list.name_en_cat as name_en_cat," _
            & "pos_order_list.name_th_catsubprd as name_th_catsubprd,pos_order_list.name_en_catsubprd as name_en_catsubprd,pos_order_list.ord_vat as ord_vat,pos_order_list.ord_vat_st as ord_vat_st" _
            & ",pos_order_list.ref_id_join as ref_id_join,pos_order_list.rf_id_table as rf_id_table" _
            & ",IFNULL(un.name_th,'') as name_unit " _
            & "  FROM pos_order_list " _
            & " LEFT JOIN pos_product_condition ON pos_order_list.rf_id_con =  pos_product_condition.id " _
            & " LEFT JOIN pos_product_ingredients ON pos_product_ingredients.id  =  pos_product_condition.ref_id_ingredients" _
            & " LEFT JOIN pos_product_size ON pos_product_size.id =  pos_product_condition.ref_id_size" _
            & " LEFT JOIN pos_invoice ON pos_invoice.id =  pos_order_list.rf_id_invoice" _
            & " LEFT JOIN pos_product_unit un ON un.id =  pos_product_condition.ref_id_unit" _
            & " WHERE  pos_order_list.status_pay='yes' and (pos_order_list.create_date LIKE '%" & Login.DateData.ToString("yyyy-MM-dd") & "%') and " _
            & "pos_order_list.status_open='gohome' " _
            & " and pos_order_list.status_sd_captain <>'void' and pos_order_list.rf_id_invoice='" & id_inv & "' GROUP BY pos_order_list.rf_id_prd,pos_order_list.rf_id_con,pos_order_list.name_ord order by id_ord asc ")

            Dim price_new1 As Double = 0.0
            Dim itmx1 As New ListViewItem
            Dim v As Integer = 1
            Dim vats As Double = 0
            Dim price_new As Double = 0
            Dim h_inv As Integer = 0
            Dim order_dis As Double = 0.0
            Dim size_n As String = ""
            While res_tb.Read
                h_inv = res_tb.GetString("rf_id_invoice")
                itmx1 = ListView_GHF.Items.Add(res_tb.GetString("id_ord"), v)
                itmx1.SubItems.Add(res_tb.GetString("status_sd_captain"))
                itmx1.SubItems.Add(res_tb.GetString("rf_id_prd"))
                itmx1.SubItems.Add(res_tb.GetString("rf_id_con"))
                itmx1.SubItems.Add(res_tb.GetString("name_ord"))
                itmx1.SubItems.Add(res_tb.GetString("name_ord_en"))
                If res_tb.GetString("name_size") <> "0" Or res_tb.GetString("name_unit") <> "" Then
                    If res_tb.GetString("name_size") <> "0" Then
                        size_n = res_tb.GetString("name_size")
                    Else
                        size_n = res_tb.GetString("name_unit")
                    End If
                Else
                    size_n = ""
                End If
                itmx1.SubItems.Add(size_n)
                Dim str_vat As String = ""
                If res_tb.GetString("rf_id_prd") = "0" Then
                    vats = 0
                    Dim pprice As Double = CDbl(res_tb.GetDecimal("sprice") / res_tb.GetInt32("samt"))
                    price_new = CDbl(res_tb.GetDecimal("sprice") / res_tb.GetInt32("samt"))
                    If CInt(res_tb.GetString("ord_vat_st")) = 0 Then
                        str_vat = "None(vat)"
                        vats = 0
                        price_new1 = FormatNumber(pprice * CInt(res_tb.GetInt32("samt")), 2)
                    ElseIf CInt(res_tb.GetString("ord_vat_st")) = 1 Then
                        str_vat = "Inc(vat)"
                        vats = pprice - ((pprice * 100) / CInt(res_tb.GetString("ord_vat") + 100))
                        price_new1 = FormatNumber((price_new - vats) * CInt(res_tb.GetInt32("samt")), 2)
                    ElseIf CInt(res_tb.GetString("ord_vat_st")) = 2 Then
                        str_vat = "Add(vat)"
                        vats = pprice * (CInt(res_tb.GetString("ord_vat")) / 100)
                        price_new1 = FormatNumber(price_new * CInt(res_tb.GetInt32("samt")), 2)
                    End If
                Else
                    ' หา vat / status 
                    vats = home1.vat_prd_cal(res_tb.GetString("rf_id_prd"), CDbl(res_tb.GetDecimal("sprice") / res_tb.GetInt32("samt")))
                    price_new = CDbl(res_tb.GetDecimal("sprice") / res_tb.GetInt32("samt"))
                    If home1.vat_in_ex(res_tb.GetString("rf_id_prd")) = "0" Then
                        str_vat = "None(vat)"
                        price_new1 = FormatNumber(price_new * CInt(res_tb.GetInt32("samt")), 2)
                    ElseIf home1.vat_in_ex(res_tb.GetString("rf_id_prd")) = "1" Then
                        str_vat = "Inc(vat)"
                        price_new1 = FormatNumber((price_new - vats) * CInt(res_tb.GetInt32("samt")), 2)
                    ElseIf home1.vat_in_ex(res_tb.GetString("rf_id_prd")) = "2" Then
                        str_vat = "Add(vat)"
                        price_new1 = FormatNumber(price_new * CInt(res_tb.GetInt32("samt")), 2)
                    End If
                End If

                itmx1.SubItems.Add(res_tb.GetInt32("samt"))
                itmx1.SubItems.Add(CDbl(res_tb.GetDecimal("sprice")))
                itmx1.SubItems.Add(res_tb.GetString("remark"))
                If res_tb.GetString("order_dis_val") <> "0" Then
                    itmx1.SubItems.Add(res_tb.GetString("order_dis_val"))
                    itmx1.SubItems.Add(res_tb.GetString("order_dis_type"))
                    itmx1.SubItems.Add(res_tb.GetString("order_dis_sum"))
                    order_dis += res_tb.GetString("order_dis_sum")
                Else
                    itmx1.SubItems.Add("0")
                    itmx1.SubItems.Add("0")
                    itmx1.SubItems.Add("0")
                    order_dis += 0
                End If
                itmx1.SubItems.Add(FormatNumber((CDbl(price_new1 + (vats * CInt(res_tb.GetInt32("samt"))))) - CDbl(res_tb.GetString("order_dis_sum")), 2))
                itmx1.SubItems.Add(res_tb.GetString("ref_cat_id"))
                itmx1.SubItems.Add(res_tb.GetString("ref_catsubprd"))
                itmx1.SubItems.Add(res_tb.GetString("name_en_cat"))
                itmx1.SubItems.Add(res_tb.GetString("name_th_cat"))
                itmx1.SubItems.Add(res_tb.GetString("name_en_catsubprd"))
                itmx1.SubItems.Add(res_tb.GetString("name_th_catsubprd"))
                itmx1.SubItems.Add(res_tb.GetString("ord_vat"))
                itmx1.SubItems.Add(res_tb.GetString("ord_vat_st"))
                itmx1.ForeColor = Color.Gray
                v += 1
            End While
            '==== GET DISCOUNT ALL BILL ===='
            Dim disc As Double = 0.0
            Dim discT As String = ""
            Dim discS As Double = 0.0
            Dim txt_priceall_cal As Double = 0.0
            Dim txt_sum_vat_cal As Double = 0.0
            Dim service_ch_sum As Double = 0.0
            Dim sum_price As Double = 0.0
            If h_inv > 0 Then
                Dim hhave_inv As MySqlDataReader = con.mysql_query("select * from pos_invoice where id='" & h_inv & "' ")
                While hhave_inv.Read
                    txt_priceall_cal = hhave_inv.GetString("price_exclu_vat")
                    txt_sum_vat_cal = hhave_inv.GetString("vat")
                    txt_sum_vat_cal = hhave_inv.GetString("vat")
                    service_ch_sum = hhave_inv.GetString("serviceCh")
                    sum_price = hhave_inv.GetString("price_all")
                    If CDbl(hhave_inv.GetString("discount_sum")) > 0 Then
                        disc = hhave_inv.GetString("discount")
                        discT = hhave_inv.GetString("discount_des")
                        discS = hhave_inv.GetString("discount_sum")
                    End If
                End While
                hhave_inv.Close()
                txt_priceall.Text = FormatNumber(txt_priceall_cal, 2)
                txt_sum_vat.Text = FormatNumber(txt_sum_vat_cal, 2)
                txt_sum_discount_bill.Text = FormatNumber("-" & CDbl(discS), 2)
                txt_sum_discount.Text = FormatNumber("-" & CDbl(discS) + order_dis, 2)
                txt_sum_service_chg.Text = FormatNumber(service_ch_sum, 2)
                TextBox1.Text = FormatNumber(sum_price, 2)
                btn_pay.Enabled = False
                Label4.Text = "สถานะ : จ่ายแล้ว"
            End If
        End If

    End Sub

    Private Sub btn_void_order_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_void_order.Click
        gohome_list_void_orderlist.code_gohome = TextBox2.Text
        gohome_list_void_orderlist.rf_id_invoice = selBill
        gohome_list_void_orderlist.ShowDialog()
    End Sub

    Private Sub ListView_GH_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles ListView_GH.KeyDown

        If e.KeyCode = Keys.Up Then
            idCode = ListView_GH.Items(ListView_GH.SelectedIndices(0)).SubItems(0).Text()
            TextBox2.Text = ListView_GH.Items(ListView_GH.SelectedIndices(0)).SubItems(0).Text
            If ListView_GH.Items(ListView_GH.SelectedIndices(0)).SubItems(4).Text() = "yes" Or ListView_GH.Items(ListView_GH.SelectedIndices(0)).SubItems(4).Text() = "จ่ายแล้ว" Then
                none_display()
            Else
                btn_edit.Enabled = True
                btn_voidall.Enabled = True
                btn_void_order.Enabled = True
                printAgain.Enabled = True
                btn_pay.Enabled = True
            End If
            s1() ' LOAD order list
        End If
        If e.KeyCode = Keys.Down Then
            idCode = ListView_GH.Items(ListView_GH.SelectedIndices(0)).SubItems(0).Text()
            TextBox2.Text = ListView_GH.Items(ListView_GH.SelectedIndices(0)).SubItems(0).Text
            If ListView_GH.Items(ListView_GH.SelectedIndices(0)).SubItems(4).Text() = "yes" Or ListView_GH.Items(ListView_GH.SelectedIndices(0)).SubItems(4).Text() = "จ่ายแล้ว" Then
                none_display()
            Else
                btn_edit.Enabled = True
                btn_voidall.Enabled = True
                btn_void_order.Enabled = True
                printAgain.Enabled = True
                btn_pay.Enabled = True
            End If
            s1() ' LOAD order list
        End If

    End Sub
End Class