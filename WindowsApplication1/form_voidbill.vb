Imports MySql.Data.MySqlClient
Imports System.Threading

Public Class form_voidbill
    Dim con As New Mysql
    Dim print As New printClass
    Public cn_void As Boolean = False
    Private Sub form_voidbill_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadINV()
        cn_void = False
    End Sub
    Private Sub LoadINV()
        ' LOAD SHOW Data
        ListView_Inv.Items.Clear()
        Dim year As Integer = 0
        If CInt(Login.DateData.ToString("yyyy")) > 2450 Then
            year = (CInt(Login.DateData.ToString("yyyy")) - 543)
        Else
            year = CInt(Login.DateData.ToString("yyyy"))
        End If
        'and pos_invoice.machine_inv='" & Login.getMacAddress & "'
        Dim Str_sql As String = "SELECT pos_invoice.id as id,pos_invoice.namber_inv as namber_inv,pos_invoice.qty as qty," _
        & "pos_invoice.price_all as price_all,pos_invoice.create_date as create_date,pos_invoice.void as void," _
        & "IFNULL(pos_payment_type.name,'-') as name_type,pos_invoice.close_rop_name_inv as close_rop_name_inv,pos_invoice.machine_inv as machine_inv" _
        & ",IFNULL(pos_invoice.discount,'0') as discount,IFNULL(pos_invoice.discount_des,'0') as discount_des,IFNULL(pos_invoice.discount_sum,'0') as discount_sum " _
        & " FROM pos_invoice LEFT JOIN pos_payment_type ON pos_invoice.rf_payment_type = pos_payment_type.id " _
        & " LEFT JOIN pos_order_list ON pos_order_list.rf_id_invoice = pos_invoice.id " _
        & " WHERE DAY(pos_invoice.create_date)='" & Login.DateData.ToString("dd") & "' " _
        & "and MONTH(pos_invoice.create_date)='" & Login.DateData.ToString("MM") & "' and YEAR(pos_invoice.create_date)='" & year & "' and pos_invoice.close_day_inv='0000-00-00'  and pos_order_list.status_pay = 'yes' and pos_invoice.rf_payment_type<>'0' " _
        & " GROUP BY pos_invoice.namber_inv order by pos_invoice.namber_inv DESC "
        Dim res_inv As MySqlDataReader = con.mysql_query(Str_sql)
        Dim n As Integer = 1
        Dim itmx As New ListViewItem

        While res_inv.Read
            itmx = ListView_Inv.Items.Add(res_inv.GetString("id"), n)
            itmx.SubItems.Add(n)
            itmx.SubItems.Add(res_inv.GetString("namber_inv"))
            itmx.SubItems.Add(res_inv.GetString("qty"))
            itmx.SubItems.Add(FormatNumber(res_inv.GetString("price_all"), 2))
            itmx.SubItems.Add(res_inv.GetDateTime("create_date").ToString("dd/MM/yyyy HH:mm:ss"))
            itmx.SubItems.Add(res_inv.GetString("name_type"))
            itmx.SubItems.Add(res_inv.GetString("close_rop_name_inv"))
            itmx.SubItems.Add(res_inv.GetString("machine_inv"))
            itmx.SubItems.Add(res_inv.GetString("discount"))
            itmx.SubItems.Add(res_inv.GetString("discount_des"))
            itmx.SubItems.Add(res_inv.GetString("discount_sum"))
            If res_inv.GetString("void") = "1" Then
                itmx.ForeColor = Color.Red

            End If
            n += 1
        End While
        res_inv.Close()
       
    End Sub
    Private Sub checkVoid(ByVal id)
        Dim cn_void_check As Boolean = False
        Dim ch As Integer = con.mysql_num_rows(con.mysql_query("select void as void from pos_invoice where namber_inv='" & id & "' and void='1'; "))
        If ch > 0 Then
            enter_void.Enabled = False
            print1.Enabled = False
        Else
            enter_void.Enabled = True
            print1.Enabled = True
        End If
    End Sub
    Private Sub LoadINV_Detail(ByRef idInv)
        ' LOAD SHOW Data
        ListView_Inv1.Items.Clear()
        Dim year As Integer = 0
        If CInt(Login.DateData.ToString("yyyy")) > 2450 Then
            year = (CInt(Login.DateData.ToString("yyyy")) - 543)
        Else
            year = CInt(Login.DateData.ToString("yyyy"))
        End If
        Dim str1 As String = "SELECT pos_order_list.id_ord AS id_ord,pos_order_list.status_sd_captain AS status_sd_captain," _
         & "pos_order_list.rf_id_prd AS rf_id_prd,pos_order_list.rf_id_con As rf_id_con,pos_order_list.name_ord AS name_ord, " _
         & "pos_order_list.prs AS prs,pos_order_list.remark AS remark,pos_order_list.ref_id_join AS ref_id_join, " _
         & "SUM(pos_order_list.amt) AS samt,SUM(pos_order_list.price) AS sprice,IFNULL(pos_product_size.name_th,0) AS name_size" _
         & ",IFNULL(pos_product_condition.ref_id_unit,'0') as ref_id_unit,pos_product_unit.name_th as name_th_unit,pos_product_unit.name_en as name_en_unit" _
        & ",IFNULL(pos_order_list.order_dis_val,'0') as order_dis_val,IFNULL(pos_order_list.order_dis_sum,'0') as order_dis_sum,IFNULL(pos_order_list.order_dis_type,'0') as order_dis_type" _
        & " FROM pos_order_list " _
         & " LEFT JOIN pos_invoice ON pos_invoice.id=pos_order_list.rf_id_invoice" _
         & " LEFT JOIN pos_product_condition ON pos_order_list.rf_id_con =  pos_product_condition.id " _
         & " LEFT JOIN pos_product_ingredients ON pos_product_ingredients.id  =  pos_product_condition.ref_id_ingredients" _
         & " LEFT JOIN pos_product_size ON pos_product_size.id = pos_product_condition.ref_id_size" _
         & " LEFT JOIN pos_product_unit ON pos_product_unit.id =  pos_product_condition.ref_id_unit " _
         & " WHERE pos_order_list.rf_id_invoice='" & idInv & "' and pos_order_list.status_pay ='yes' and pos_invoice.void='0' and (pos_order_list.status_sd_captain<>'void' and pos_order_list.status_sd_captain<>'voidp')  GROUP BY pos_order_list.rf_id_prd,pos_order_list.rf_id_con,pos_order_list.name_ord "

        'TextBox1.Text = str1
        Dim y As Integer = 0
        Dim rf_id_con As String = ""
        Dim size_n As String = ""
        Dim res_listView As MySqlDataReader = con.mysql_query(str1)
        Dim itmx1 As New ListViewItem
        Me.ListView_Inv1.CheckBoxes = True
        Dim samt As Integer = 0
        Dim sprice As Double = 0

        While res_listView.Read
            itmx1 = ListView_Inv1.Items.Add("", y)
            itmx1.SubItems.Add(y + 1)
            itmx1.SubItems.Add(res_listView.GetString("id_ord"))
            itmx1.SubItems.Add(res_listView.GetString("rf_id_prd"))
            If res_listView.GetString("rf_id_con") <> "0" Then
                rf_id_con = res_listView.GetString("rf_id_con")
            Else
                rf_id_con = ""
            End If
            itmx1.SubItems.Add(rf_id_con)
            itmx1.SubItems.Add(res_listView.GetString("name_ord"))
            If res_listView.GetString("name_size") <> "0" And CInt(res_listView.GetString("ref_id_unit")) = 0 Then
                size_n = res_listView.GetString("name_size")
            ElseIf res_listView.GetString("name_size") = "0" And CInt(res_listView.GetString("ref_id_unit")) > 0 Then
                If res_listView.GetString("name_th_unit") <> "" Then
                    size_n = res_listView.GetString("name_th_unit")
                Else
                    size_n = res_listView.GetString("name_en_unit")
                End If
            Else
                size_n = ""
            End If
            itmx1.SubItems.Add(size_n)
            ' หา vat / status 
            Dim str_vat As String = ""
            If home1.vat_in_ex(res_listView.GetString("rf_id_prd")) = "1" Then
                str_vat = "included VAT"
            Else
                str_vat = "excluded VAT"
            End If
            itmx1.SubItems.Add(str_vat & " " & home1.vat_prd(res_listView.GetString("rf_id_prd")) & "%")
            'คำนวณ vat show ถ้าเป็น exclude
            Dim vats As Double = home1.vat_prd_cal(res_listView.GetString("rf_id_prd"), CDbl(res_listView.GetString("sprice")))
            Dim price_new As Double = 0.0
            If vats > 0 Then
                price_new = CDbl(res_listView.GetString("sprice"))
            Else
                price_new = res_listView.GetString("sprice")
            End If

            itmx1.SubItems.Add(CInt(res_listView.GetString("samt")))
            itmx1.SubItems.Add(FormatNumber(res_listView.GetString("sprice"), 2))
            itmx1.SubItems.Add(FormatNumber(res_listView.GetString("order_dis_val"), 2))
            Dim discY As String = ""
            If res_listView.GetString("order_dis_type") = "%" Then
                discY = "%"
            Else
                discY = "บาท"
            End If
            itmx1.SubItems.Add(discY)
            itmx1.SubItems.Add(FormatNumber(res_listView.GetString("order_dis_sum"), 2))
            itmx1.SubItems.Add(FormatNumber(CDbl(res_listView.GetString("sprice")) - CDbl(res_listView.GetString("order_dis_sum")), 2))
            itmx1.SubItems.Add(res_listView.GetString("remark"))
           
            y += 1
        End While
        res_listView.Close()

        ' Load Show Void List
        Dim resLoadFV As MySqlDataReader = con.mysql_query("SELECT pos_order_list.id_ord AS id_ord,pos_order_list.status_sd_captain AS status_sd_captain," _
       & "pos_order_list.rf_id_prd AS rf_id_prd,pos_order_list.rf_id_con As rf_id_con,pos_order_list.name_ord AS name_ord," _
       & "  pos_order_list.prs AS prs,pos_order_list.remark AS remark,pos_order_list.code_gohome AS code_gohome ," _
       & " SUM(pos_order_list.amt) AS samt,SUM(pos_order_list.price) AS sprice,IFNULL(pos_product_size.name_th,0) AS name_size" _
       & ",IFNULL(pos_product_condition.ref_id_unit,'0') as ref_id_unit,pos_product_unit.name_th as name_th_unit,pos_product_unit.name_en as name_en_unit" _
        & ",IFNULL(pos_order_list.order_dis_val,'0') as order_dis_val,IFNULL(pos_order_list.order_dis_sum,'0') as order_dis_sum,IFNULL(pos_order_list.order_dis_type,'0') as order_dis_type" _
       & " FROM pos_order_list " _
       & " LEFT JOIN pos_product_condition ON pos_order_list.rf_id_con =  pos_product_condition.id" _
       & " LEFT JOIN pos_product_ingredients ON pos_product_ingredients.id  =  pos_product_condition.ref_id_ingredients" _
       & " LEFT JOIN pos_product_size ON pos_product_size.id =  pos_product_condition.ref_id_size " _
        & " LEFT JOIN pos_product_unit ON pos_product_unit.id =  pos_product_condition.ref_id_unit " _
       & " WHERE pos_order_list.rf_id_invoice='" & idInv & "' and (pos_order_list.status_sd_captain='void' or pos_order_list.status_sd_captain='voidp')  " _
       & " GROUP BY  pos_order_list.rf_id_prd,pos_order_list.rf_id_con,pos_order_list.name_ord")
        Dim cmax As Integer = CInt(ListView_Inv1.Items.Count) + 1
        Dim nameSize1 As String = ""
        While resLoadFV.Read
            itmx1 = ListView_Inv1.Items.Add("", cmax)
            itmx1.SubItems.Add(cmax)
            itmx1.SubItems.Add(resLoadFV.GetString("id_ord"))
            itmx1.SubItems.Add(resLoadFV.GetString("rf_id_prd"))
            If resLoadFV.GetString("rf_id_con") <> "0" Then
                rf_id_con = resLoadFV.GetString("rf_id_con")
            Else
                rf_id_con = ""
            End If
            itmx1.SubItems.Add(rf_id_con)
            itmx1.SubItems.Add(resLoadFV.GetString("name_ord"))
            If resLoadFV.GetString("name_size") <> "0" And CInt(resLoadFV.GetString("ref_id_unit")) = 0 Then
                size_n = resLoadFV.GetString("name_size")
            ElseIf resLoadFV.GetString("name_size") = "0" And CInt(resLoadFV.GetString("ref_id_unit")) > 0 Then
                If resLoadFV.GetString("name_th_unit") <> "" Then
                    size_n = resLoadFV.GetString("name_th_unit")
                Else
                    size_n = resLoadFV.GetString("name_en_unit")
                End If
            Else
                size_n = ""
            End If
            itmx1.SubItems.Add(size_n)
            ' หา vat / status 
            Dim str_vat As String = ""
            If home1.vat_in_ex(resLoadFV.GetString("rf_id_prd")) = "1" Then
                str_vat = "included VAT"
            Else
                str_vat = "excluded VAT"
            End If
            itmx1.SubItems.Add(str_vat & " " & home1.vat_prd(resLoadFV.GetString("rf_id_prd")) & "%")
            'คำนวณ vat show ถ้าเป็น exclude
            Dim vats As Double = home1.vat_prd_cal(resLoadFV.GetString("rf_id_prd"), CDbl(resLoadFV.GetString("sprice")))
            Dim price_new As Double = 0.0
            If vats > 0 Then
                price_new = CDbl(resLoadFV.GetString("sprice"))
            Else
                price_new = resLoadFV.GetString("sprice")
            End If

            itmx1.SubItems.Add(CInt(resLoadFV.GetString("samt")))
            itmx1.SubItems.Add(FormatNumber(resLoadFV.GetString("sprice"), 2))
            itmx1.SubItems.Add(FormatNumber(resLoadFV.GetString("order_dis_val"), 2))
            Dim discY As String = ""
            If resLoadFV.GetString("order_dis_type") = "%" Then
                discY = "%"
            Else
                discY = "บาท"
            End If
            itmx1.SubItems.Add(discY)
            itmx1.SubItems.Add(FormatNumber(resLoadFV.GetString("order_dis_sum"), 2))
            itmx1.SubItems.Add(FormatNumber(CDbl(resLoadFV.GetString("sprice")) - CDbl(resLoadFV.GetString("order_dis_sum")), 2))
            itmx1.SubItems.Add(resLoadFV.GetString("remark"))
            itmx1.ForeColor = Color.Red
            cmax += 1
        End While
        resLoadFV.Close()
    End Sub
    Private Sub loadPrice(ByVal idInv)
        Dim Str_sql As String = "SELECT * FROM pos_invoice WHERE id='" & idInv & "' "
        Dim res_inv As MySqlDataReader = con.mysql_query(Str_sql)
        Dim discs As Double = 0.0
        For y As Integer = 0 To ListView_Inv1.Items.Count - 1
            discs += ListView_Inv1.Items(y).SubItems(12).Text
        Next
        While res_inv.Read
            txt_sum_price.Text = FormatNumber(res_inv.GetString("price_exclu_vat"), 2)
            txt_sum_vat.Text = FormatNumber(res_inv.GetString("vat"), 2)
            txt_sum_service_chg.Text = FormatNumber(res_inv.GetString("serviceCh"), 2)
            txt_sum_discount.Text = "-" & FormatNumber(res_inv.GetString("discount_sum") + discs, 2)
            txt_sum_total.Text = FormatNumber(res_inv.GetString("price_all"), 2)
        End While
        res_inv.Close()
    End Sub
    Private Sub up_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles up.Click
        If ListView_Inv.SelectedItems.Count > 0 Then
            If ListView_Inv.SelectedIndices(0) > 0 Then
                ListView_Inv.Items.Item(ListView_Inv.SelectedIndices(0) - 1).Selected = True
                ListView_Inv.Focus()
                LoadINV_Detail(ListView_Inv.Items.Item(ListView_Inv.SelectedIndices(0)).SubItems(0).Text)
                loadPrice(ListView_Inv.Items.Item(ListView_Inv.SelectedIndices(0)).SubItems(0).Text)
                checkVoid(ListView_Inv.Items.Item(ListView_Inv.SelectedIndices(0)).SubItems(2).Text)
            End If
        Else
            ListView_Inv.Items.Item(0).Selected = True
            ListView_Inv.Focus()
            LoadINV_Detail(ListView_Inv.Items.Item(ListView_Inv.SelectedIndices(0)).SubItems(0).Text)
            loadPrice(ListView_Inv.Items.Item(ListView_Inv.SelectedIndices(0)).SubItems(0).Text)
            checkVoid(ListView_Inv.Items.Item(ListView_Inv.SelectedIndices(0)).SubItems(2).Text)
        End If

    End Sub

    Private Sub dw_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dw.Click
        If ListView_Inv.SelectedItems.Count > 0 Then
            If ListView_Inv.SelectedIndices(0) < ListView_Inv.Items.Count - 1 Then
                ListView_Inv.Items.Item(ListView_Inv.SelectedIndices(0) + 1).Selected = True
                ListView_Inv.Focus()
                LoadINV_Detail(ListView_Inv.Items.Item(ListView_Inv.SelectedIndices(0)).SubItems(0).Text)
                loadPrice(ListView_Inv.Items.Item(ListView_Inv.SelectedIndices(0)).SubItems(0).Text)
                checkVoid(ListView_Inv.Items.Item(ListView_Inv.SelectedIndices(0)).SubItems(2).Text)
            End If
        Else
            ListView_Inv.Items.Item(ListView_Inv.Items.Count - 1).Selected = True
            ListView_Inv.Focus()
            LoadINV_Detail(ListView_Inv.Items.Item(ListView_Inv.SelectedIndices(0)).SubItems(0).Text)
            loadPrice(ListView_Inv.Items.Item(ListView_Inv.SelectedIndices(0)).SubItems(0).Text)
            checkVoid(ListView_Inv.Items.Item(ListView_Inv.SelectedIndices(0)).SubItems(2).Text)
        End If

    End Sub


    Private Sub btn_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_close.Click
        Me.Close()
        If index.CheckOpenSystemTakehomeonly() = True Then
            gohome_list.MdiParent = index
            gohome_list.Show()
            gohome_list.WindowState = FormWindowState.Minimized
            gohome_list.WindowState = FormWindowState.Maximized
            Login.Formname = "gohome_list"
        Else
            home1.MdiParent = index
            home1.Show()
            home1.WindowState = FormWindowState.Minimized
            home1.WindowState = FormWindowState.Maximized
            Login.Formname = "home1"
        End If
        'index.openCloseMenu(home1)
    End Sub

    Private Sub ListView_Inv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView_Inv.Click
        LoadINV_Detail(ListView_Inv.Items.Item(ListView_Inv.SelectedIndices(0)).SubItems(0).Text)
        loadPrice(ListView_Inv.Items.Item(ListView_Inv.SelectedIndices(0)).SubItems(0).Text)
        checkVoid(ListView_Inv.Items.Item(ListView_Inv.SelectedIndices(0)).SubItems(2).Text)
    End Sub

    Private Sub btn_tick_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_tick.Click
        If ListView_Inv1.Items.Count > 0 Then
            If ListView_Inv1.SelectedItems.Count > 0 Then
                If ListView_Inv1.Items(ListView_Inv1.SelectedIndices(0)).Checked = CheckState.Unchecked Then
                    ListView_Inv1.Items(ListView_Inv1.SelectedIndices(0)).Checked = CheckState.Checked
                    ListView_Inv1.Focus()
                Else
                    ListView_Inv1.Items(ListView_Inv1.SelectedIndices(0)).Checked = CheckState.Unchecked
                    ListView_Inv1.Focus()
                End If
            End If
        End If
    End Sub
    Private Sub btn_tickall_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_tickall.Click
        If ListView_Inv1.Items.Count > 0 Then
            For I As Integer = 0 To ListView_Inv1.Items.Count - 1
                If ListView_Inv1.Items(I).Checked = CheckState.Unchecked Then
                    ListView_Inv1.Items(I).Checked = CheckState.Checked
                    ListView_Inv1.Focus()
                Else
                    ListView_Inv1.Items(I).Checked = CheckState.Unchecked
                    ListView_Inv1.Focus()
                End If
            Next
        End If
    End Sub

    Private Sub up1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles up1.Click
        If ListView_Inv1.SelectedItems.Count > 0 Then
            If ListView_Inv1.SelectedIndices(0) > 0 Then
                ListView_Inv1.Items.Item(ListView_Inv1.SelectedIndices(0) - 1).Selected = True
                ListView_Inv1.Focus()
            End If
        Else
            ListView_Inv1.Items.Item(0).Selected = True
            ListView_Inv1.Focus()
        End If
    End Sub

    Private Sub dw1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dw1.Click
        If ListView_Inv1.SelectedItems.Count > 0 Then
            If ListView_Inv1.SelectedIndices(0) < ListView_Inv1.Items.Count - 1 Then
                ListView_Inv1.Items.Item(ListView_Inv1.SelectedIndices(0) + 1).Selected = True
                ListView_Inv1.Focus()
            End If
        Else
            ListView_Inv1.Items.Item(ListView_Inv1.Items.Count - 1).Selected = True
            ListView_Inv1.Focus()
        End If
    End Sub
    Friend reson_void As String = ""
    Private Sub enter_void_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles enter_void.Click
        confirm_void.page = "voidbill"
        confirm_void.ShowDialog()
        If cn_void = True Then
            If ListView_Inv.SelectedItems.Count > 0 Then
                Dim id As String = ListView_Inv.Items.Item(ListView_Inv.SelectedIndices(0)).SubItems(0).Text
                Dim result2 As DialogResult = MessageBox.Show("คุณมั่นใจใช่ไหมที่จะvoid bill?", " Message Alert", _
                  MessageBoxButtons.YesNo, _
                  MessageBoxIcon.Question)
                Dim returnstk As Boolean = False
                If result2 = DialogResult.Yes Then
                    form_voidbill_reson.TextBox1.Text = ""
                    form_voidbill_reson.ShowDialog()

                    'Loop Query Data for return Stock
                    Dim dt_order As MySqlDataReader = con.mysql_query("SELECT * FROM pos_closebilldetail WHERE crf_id_invoice='" & id & "' and (cstatus<>'void' or cstatus<>'voidp')")
                    While dt_order.Read
                        returnstk = opentable.returnStock(dt_order.GetString("crf_id_prd"), dt_order.GetString("crf_id_con"), dt_order.GetString("camt")) 'ตัดของคืนสต๊อกสินค้า
                    End While
                    Dim q1 As Boolean = con.mysql_query("UPDATE pos_order_list SET status_sd_captain='void' where rf_id_invoice='" & id & "' and status_pay='yes'")
                    Dim q_closebill As Boolean = con.mysql_query("UPDATE pos_closebilldetail SET cstatus='void',cupdate_by='" & Login.username & "' WHERE crf_id_invoice='" & id & "' ")
                    If q1 = True And q_closebill = True Then
                        Dim q2 As Boolean = con.mysql_query("UPDATE pos_invoice SET void='1',remark='" & reson_void & "' WHERE id='" & id & "'")
                        If q2 = True Then
                            Dim id_inv As Integer = CInt(ListView_Inv.Items.Item(ListView_Inv.SelectedIndices(0)).SubItems(0).Text)
                            ' print.PrintPaymentVoid(id_inv, "0", "0", Login.username) 'Print Bill Payment
                            Dim WorkerThread As Thread
                            Dim W As New worker
                            W.setPaymentVoid(id_inv, Login.username, Login.printer_payment)
                            WorkerThread = New Thread(AddressOf W.Start)    'Create our Worker thread and tell it that when we start it it should call our Worker's Start() method
                            WorkerThread.Start()
                            Thread.Sleep(1000)
                            MessageBox.Show("Void Complete", "Message Alert", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            LoadINV()
                            cn_void = False
                            reson_void = ""
                        End If
                    End If
                End If 'End result2
            End If
        End If
    End Sub
    Private Sub print1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles print1.Click
        If ListView_Inv.SelectedItems.Count > 0 Then
            Dim id_inv As Integer = CInt(ListView_Inv.Items.Item(ListView_Inv.SelectedIndices(0)).SubItems(0).Text)
            showpay_typeprint.invoice_number = id_inv
            showpay_typeprint.recript_m_print = "0"
            showpay_typeprint.ton_m_print = "0"
            showpay_typeprint.page = "form_void"
            showpay_typeprint.ShowDialog()

        End If
    End Sub

    Private Sub btn_reload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_reload.Click
        LoadINV()
    End Sub

End Class