Imports MySql.Data.MySqlClient
Public Class Admin_EditBill
    Dim con As New Mysql
    Dim print As New printClass
    Private Sub Admin_EditBill_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            LoadINV()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub LoadINV()
        ' LOAD SHOW Data
        Dim year As Integer = 0
        If CInt(Login.DateData.ToString("yyyy")) > 2450 Then
            year = (CInt(Login.DateData.ToString("yyyy")) - 543)
        Else
            year = CInt(Login.DateData.ToString("yyyy"))
        End If
        DataGridView1.Rows.Clear()
        Dim date_d As Date = DateTimePicker1.Value.ToString("yyyy-MM-dd")
        Dim y As String = ""
        If date_d.ToString("yyyy") > 2460 Then
            y = CInt(date_d.ToString("yyyy")) - 543
        Else
            y = date_d.ToString("yyyy")
        End If
        Dim Str_sql As String = "SELECT pos_invoice.id as id,pos_invoice.namber_inv as namber_inv,pos_invoice.qty as qty," _
        & "pos_invoice.price_all as price_all,pos_invoice.create_date as create_date,pos_invoice.void as void," _
        & "pos_payment_type.name as name_type,pos_invoice.close_rop_name_inv as close_rop_name_inv," _
        & "pos_invoice.price_exclu_vat as price_exclu_vat,pos_invoice.vat as vat,pos_invoice.discount_sum as discount_sum," _
        & "pos_invoice.serviceCh as serviceCh,pos_invoice.machine_inv as machine_inv,pos_invoice.price_all as price_all " _
        & ",SUM(pos_closebilldetail.c_discount_sum) as c_discount_sum,pos_closebilldetail.c_id_cat as c_id_cat," _
        & "pos_invoice.des_payment as des_payment" _
        & " FROM pos_invoice LEFT JOIN pos_closebilldetail ON pos_closebilldetail.crf_id_invoice = pos_invoice.id" _
        & "  LEFT JOIN pos_payment_type ON pos_invoice.rf_payment_type = pos_payment_type.id " _
        & " WHERE close_day_inv='" & y & date_d.ToString("-MM-dd") & "' GROUP BY id  order by namber_inv DESC"
        '/*TextBox1.Text = Str_sql*/

        Dim res_inv As MySqlDataReader = con.mysql_query(Str_sql)
        Dim i As Integer = 1
        While res_inv.Read
            Dim srv As Double = 0.0
            If res_inv.GetString("c_id_cat") = 2 Then
                srv = FormatNumber(CDbl(res_inv.GetString("price_all")) * 10 / 110, 2)
            Else
                srv = FormatNumber(CDbl(res_inv.GetString("serviceCh")), 2)
            End If
            Dim n As Integer = DataGridView1.Rows.Add()
            DataGridView1.Rows.Item(n).Cells(0).Value = res_inv.GetString("id")
            DataGridView1.Rows.Item(n).Cells(1).Value = i
            DataGridView1.Rows.Item(n).Cells(2).Value = res_inv.GetString("namber_inv")
            DataGridView1.Rows.Item(n).Cells(3).Value = res_inv.GetString("qty")
            DataGridView1.Rows.Item(n).Cells(4).Value = res_inv.GetString("price_exclu_vat")
            DataGridView1.Rows.Item(n).Cells(5).Value = res_inv.GetString("vat")
            DataGridView1.Rows.Item(n).Cells(6).Value = CDbl(res_inv.GetString("price_exclu_vat")) + CDbl(res_inv.GetString("vat"))
            DataGridView1.Rows.Item(n).Cells(9).Value = FormatNumber(CDbl(res_inv.GetString("price_all")), 2)
            DataGridView1.Rows.Item(n).Cells(7).Value = FormatNumber(CDbl(res_inv.GetString("discount_sum")) + CDbl(res_inv.GetDouble("c_discount_sum")), 2)
            DataGridView1.Rows.Item(n).Cells(8).Value = srv
            DataGridView1.Rows.Item(n).Cells(9).Value = FormatNumber(CDbl(res_inv.GetString("price_all")), 2)
            DataGridView1.Rows.Item(n).Cells(10).Value = res_inv.GetString("name_type") & "/" & res_inv.GetString("des_payment")
            DataGridView1.Rows.Item(n).Cells(11).Value = res_inv.GetString("machine_inv")
            DataGridView1.Rows.Item(n).Cells(12).Value = res_inv.GetDateTime("create_date").ToString("dd/MM/yyyy")
            DataGridView1.Rows.Item(n).Cells(13).Value = res_inv.GetString("close_rop_name_inv")
            If res_inv.GetString("void") = "1" Then
                DataGridView1.Rows.Item(n).DefaultCellStyle.BackColor = Color.Red
            End If
            i += 1
        End While

    End Sub
    Dim srv As Double = 0.0
    Dim Pprice As Double = 0.0

    Private Sub LoadINV_Detail(ByRef idInv)
        ' LOAD SHOW Data
        DataGridView2.Rows.Clear()
        Dim str1 As String = "SELECT pos_closebilldetail.id_close AS id_close,pos_closebilldetail.cstatus_open AS cstatus_open," _
         & "pos_closebilldetail.crf_id_prd AS crf_id_prd,pos_closebilldetail.crf_id_con As crf_id_con,pos_closebilldetail.cname_ord AS name_ord," _
         & "pos_closebilldetail.cprs AS prs,pos_closebilldetail.cremark AS remark," _
         & " SUM(pos_closebilldetail.camt) AS samt,SUM(pos_closebilldetail.c_net_amount) AS sprice,IFNULL(pos_product_size.name_th,0) AS name_size," _
         & " SUM(pos_closebilldetail.c_amount) as c_amount,SUM(pos_closebilldetail.c_vat_sum) as c_vat_sum" _
         & " ,pos_closebilldetail.cupdate_by as cupdate_by,pos_closebilldetail.c_discount as c_discount," _
         & " pos_closebilldetail.c_discount_type as c_discount_type,SUM(pos_closebilldetail.c_discount_sum) as c_discount_sum " _
         & ",pos_closebilldetail.c_id_cat as c_id_cat" _
        & " FROM pos_closebilldetail INNER JOIN pos_invoice ON pos_invoice.id=pos_closebilldetail.crf_id_invoice" _
         & " LEFT JOIN pos_product_condition ON   pos_product_condition.id  = pos_closebilldetail.crf_id_con " _
        & " LEFT JOIN pos_product_size ON pos_product_size.id = pos_product_condition.ref_id_size" _
        & " WHERE pos_closebilldetail.crf_id_invoice='" & idInv & "'" _
        & " GROUP BY pos_closebilldetail.crf_id_prd,pos_closebilldetail.crf_id_con,pos_closebilldetail.cname_ord"
        Dim j As Integer = 1
        Dim size_n As String = ""
        Dim res_listView As MySqlDataReader = con.mysql_query(str1)
        srv = 0.0
        Pprice = 0.0
        While res_listView.Read


            Dim n As Integer = DataGridView2.Rows.Add()
            DataGridView2.Rows.Item(n).Cells(0).Value = res_listView.GetString("id_close")
            DataGridView2.Rows.Item(n).Cells(1).Value = j
            DataGridView2.Rows.Item(n).Cells(2).Value = res_listView.GetString("crf_id_prd")
            DataGridView2.Rows.Item(n).Cells(3).Value = res_listView.GetString("crf_id_con")
            DataGridView2.Rows.Item(n).Cells(4).Value = res_listView.GetString("name_ord")
            DataGridView2.Rows.Item(n).Cells(5).Value = CDbl(res_listView.GetString("c_amount")) / CDbl(res_listView.GetString("samt"))
            DataGridView2.Rows.Item(n).Cells(6).Value = CDbl(res_listView.GetString("c_vat_sum")) / CDbl(res_listView.GetString("samt"))
            ' หา vat / status 
            Dim str_vat As String = ""
            If home1.vat_in_ex(res_listView.GetString("crf_id_prd")) = "1" Then
                str_vat = "include"
            Else
                str_vat = "Add"
            End If
            DataGridView2.Rows.Item(n).Cells(7).Value = str_vat
            DataGridView2.Rows.Item(n).Cells(8).Value = CInt(res_listView.GetString("samt"))
            DataGridView2.Rows.Item(n).Cells(9).Value = CInt(res_listView.GetString("sprice")) / CInt(res_listView.GetString("samt"))
            If res_listView.GetString("name_size") <> "0" Then
                size_n = res_listView.GetString("name_size")
            Else
                size_n = ""
            End If

            DataGridView2.Rows.Item(n).Cells(10).Value = size_n
            DataGridView2.Rows.Item(n).Cells(11).Value = res_listView.GetString("c_discount")
            DataGridView2.Rows.Item(n).Cells(12).Value = res_listView.GetString("c_discount_type")
            DataGridView2.Rows.Item(n).Cells(13).Value = FormatNumber(CDbl(res_listView.GetString("c_discount_sum")), 2)
            DataGridView2.Rows.Item(n).Cells(14).Value = FormatNumber(CDbl(res_listView.GetString("sprice")) - CDbl(res_listView.GetString("c_discount_sum")), 2)
            DataGridView2.Rows.Item(n).Cells(15).Value = res_listView.GetString("cstatus_open")
            DataGridView2.Rows.Item(n).Cells(16).Value = res_listView.GetString("cupdate_by")

            j += 1
            If res_listView.GetString("c_id_cat") = 2 And Admin_Report.Check_Key() = "2001E-2C517-9051A-07B3D-616A3-1C7EE" Then
                srv += 1
                Pprice += CDbl(res_listView.GetString("sprice"))
            Else
                srv += 0.0
                Pprice += CDbl(res_listView.GetString("sprice"))
            End If
        End While

    End Sub
    Private Sub loadPrice(ByVal idInv)
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index

        Dim Str_sql As String = "SELECT * FROM pos_invoice WHERE id='" & idInv & "' "
        Dim res_inv As MySqlDataReader = con.mysql_query(Str_sql)
        While res_inv.Read

            If srv > 0 And Admin_Report.Check_Key() = "2001E-2C517-9051A-07B3D-616A3-1C7EE" Then
                Dim srv_n As Double = (Pprice - CDbl(DataGridView1.Item(7, i).Value)) * 10 / 110
                Dim p_new As Double = (Pprice - CDbl(DataGridView1.Item(7, i).Value)) - srv_n

                txt_sum_price.Text = FormatNumber(CDbl(p_new * 100 / 107), 2)
                txt_sum_vat.Text = FormatNumber(p_new - CDbl(p_new * 100 / 107), 2)
                txt_sum_service_chg.Text = FormatNumber(CDbl(srv_n), 2)
                txt_service_chg.Text = "10"
                txt_sum_discount.Text = FormatNumber(CDbl(DataGridView1.Item(7, i).Value), 2)
                txt_sum_total.Text = FormatNumber(CDbl(res_inv.GetString("price_all")), 2)
            Else

                txt_sum_price.Text = FormatNumber(CDbl(res_inv.GetString("price_exclu_vat")), 2)
                txt_sum_vat.Text = FormatNumber(CDbl(res_inv.GetString("vat")), 2)
                txt_sum_service_chg.Text = FormatNumber(CDbl(res_inv.GetString("serviceCh")), 2)
                txt_service_chg.Text = "0"
                txt_sum_discount.Text = "-" & FormatNumber(CDbl(DataGridView1.Item(7, i).Value), 2)
                txt_sum_total.Text = FormatNumber(CDbl(res_inv.GetString("price_all")), 2)
            End If

        End While
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        LoadINV()
        btn_save.Enabled = False
        DataGridView2.Rows.Clear()
        Label3.Text = "No."
        txt_sum_price.Text = "0.0"
        txt_sum_vat.Text = "0.0"
        txt_sum_service_chg.Text = "0.0"
        txt_sum_discount.Text = "0.0"
        txt_sum_total.Text = "0.0"
    End Sub

    Private Sub btn_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancel.Click
        btn_save.Enabled = False
        DataGridView2.Rows.Clear()
        Label3.Text = "No."
        txt_sum_price.Text = "0.0"
        txt_sum_vat.Text = "0.0"
        txt_sum_service_chg.Text = "0.0"
        txt_sum_discount.Text = "0.0"
        txt_sum_total.Text = "0.0"
    End Sub

    Private Sub btn_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_save.Click
        Try
            Dim str As String = ""
            Dim i As Integer
            i = DataGridView1.CurrentRow.Index
            str &= "UPDATE pos_invoice SET price_all='" & CDbl(DataGridView1.Rows(i).Cells(8).Value()) & "',qty='" & CInt(DataGridView1.Rows(i).Cells(2).Value()) & "',update_by='" & Login.username & "',vat='" & CDbl(DataGridView1.Rows(i).Cells(4).Value()) & "'," _
                & "price_exclu_vat='" & CDbl(DataGridView1.Rows(i).Cells(3).Value()) & "',serviceCh='" & CDbl(DataGridView1.Rows(i).Cells(7).Value()) & "',discount_sum='" & CDbl(DataGridView1.Rows(i).Cells(6).Value()) & "' WHERE id='" & DataGridView1.Rows(i).Cells(0).Value() & "';"
            Dim query_inv As Boolean = con.mysql_query(str)
            Dim st1 As String = ""
            If query_inv = True Then
                Dim res As MySqlDataReader = con.mysql_query("SELECT * FROM pos_closebilldetail WHERE crf_id_invoice='" & DataGridView1.Rows(i).Cells(0).Value() & "'")
                For h As Integer = 0 To DataGridView2.Rows.Count - 1
                    While res.Read()
                        If res.GetString("crf_id_prd") = DataGridView2.Item(1, h).Value And res.GetString("crf_id_con") = DataGridView2.Item(2, h).Value Then
                            MsgBox(DataGridView2.Item(1, h).Value & DataGridView2.Item(2, h).Value)
                            ' ตรวจเช็คค่าวันที่ ปิดรอบวัน
                            Dim close_day As Date
                            Try
                                If CInt(CDate(res.GetString("close_day")).ToString("yyyy")) > 2450 Then
                                    close_day = CDate(res.GetString("close_day")).ToString("yyyy") - 543 & CDate(res.GetString("close_day")).ToString("-MM-dd")
                                Else
                                    close_day = CDate(res.GetString("close_day")).ToString("yyyy-MM-dd")
                                End If
                            Catch ex As Exception

                            End Try
                            ' ตรวจเช็คค่าวันที่ สร้างรายการ
                            Dim ccreate_date As DateTime
                            ' Dim close_day As Date
                            If CInt(CDate(res.GetString("ccreate_date")).ToString("yyyy")) > 2450 Then
                                ccreate_date = CInt(CDate(res.GetString("ccreate_date")).ToString("yyyy")) - 543 & CDate(res.GetString("ccreate_date")).ToString("-MM-dd HH:mm:ss")
                            Else
                                ccreate_date = CDate(res.GetString("ccreate_date")).ToString("yyyy-MM-dd HH:mm:ss")
                            End If
                            Dim qty As Integer = CInt(DataGridView2.Rows(h).Cells(7).Value())
                            Dim pr_ex As Double = CDbl(DataGridView2.Rows(h).Cells(4).Value()) * CInt(DataGridView2.Rows(h).Cells(7).Value())
                            Dim vat_sun As Double = CInt(DataGridView2.Rows(h).Cells(5).Value()) * CInt(DataGridView2.Rows(h).Cells(7).Value())
                            Dim pr_sum As Double = CDbl(DataGridView2.Rows(h).Cells(9).Value())
                            st1 &= "INSERT INTO pos_closebilldetail (crf_id_prd,crf_id_con,cname_ord,camt,cprice,cprs,crf_id_table,crf_id_invoice,c_vat,c_vat_st,c_vat_sum," _
                             & "c_discount,c_amount,c_net_amount,cstatus_open,cremark,cstatus,ccreate_date,ccode_gohome,ctryNumber," _
                             & "ccreate_by,cupdate_by,rf_id_closebill,name_closebill,machine_closedetail,close_day,close_day_action) " _
                             & "VALUES('" & res.GetString("crf_id_prd") & "','" & res.GetString("crf_id_con") & "','" & res.GetString("cname_ord").Replace("'", "\'") & "','" & qty & "'," _
                             & "'" & pr_ex & "','" & res.GetString("cprs") & "','" & res.GetString("crf_id_table") & "','" & res.GetString("crf_id_invoice") & "','" & res.GetString("c_vat") & "'," _
                             & "'" & res.GetString("c_vat_st") & "','" & vat_sun & "','" & res.GetString("c_discount") & "','" & pr_ex & "'," _
                             & "'" & pr_sum & "','" & res.GetString("cstatus_open") & "','" & res.GetString("cremark").Replace("'", "\'") & "','" & res.GetString("cstatus") & "','" & ccreate_date.ToString("yyyy-MM-dd HH:mm:ss") & "'," _
                             & "'" & res.GetString("ccode_gohome") & "','" & res.GetString("ctryNumber") & "','" & res.GetString("ccreate_by") & "','" & Login.username & "','" & res.GetString("rf_id_closebill") & "','" & res.GetString("name_closebill") & "'," _
                             & "'" & res.GetString("machine_closedetail") & "','" & close_day & "','" & res.GetString("close_day_action") & "'" _
                             & ");"
                        End If
                    End While
                Next
                Dim del As Boolean = con.mysql_query("DELETE FROM pos_closebilldetail WHERE crf_id_invoice='" & DataGridView1.Rows(i).Cells(0).Value() & "'")
                Dim insert_new As Boolean = con.mysql_query(st1)
                If query_inv = True And del = True And insert_new = True Then
                    MessageBox.Show("Update Bill Complete", "Message Alert", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Error Update Bill.!", "Message Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
 
    Private Sub DataGridView1_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Try
            Dim i As Integer
            i = DataGridView1.CurrentRow.Index
            Dim id As String = DataGridView1.Item(0, i).Value
            Dim chk As MySqlDataReader = con.mysql_query("SELECT void as void FROM pos_invoice WHERE namber_inv='" & DataGridView1.Item(2, i).Value & "'")
            chk.Read()
            If CInt(chk.GetString("void")) = 1 Then
                btn_save.Enabled = False
            Else
                btn_save.Enabled = True
            End If
            Label3.Text = DataGridView1.Item(2, i).Value
            LoadINV_Detail(id)
            loadPrice(id)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub cal_datagrid1()
        Try
            Dim qty As Integer = 0
            Dim price As Double = 0.0
            Dim price_exvat As Double = 0.0
            Dim vat_price As Double = 0.0
            If DataGridView2.Rows.Count > 0 Then
                For j As Integer = 0 To DataGridView2.Rows.Count - 1
                    qty += CInt(DataGridView2.Item(7, j).Value)
                    price += CDbl(DataGridView2.Item(9, j).Value) * CInt(DataGridView2.Item(7, j).Value)
                    price_exvat += CDbl(DataGridView2.Item(4, j).Value) * CInt(DataGridView2.Item(7, j).Value)
                    vat_price += CDbl(DataGridView2.Item(5, j).Value) * CInt(DataGridView2.Item(7, j).Value)
                    DataGridView2.Item(9, j).Value = (CDbl(DataGridView2.Item(4, j).Value) + CDbl(DataGridView2.Item(5, j).Value)) * CInt(DataGridView2.Item(7, j).Value)
                Next
            End If
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
            DataGridView1.Item(2, i).Value = qty
            DataGridView1.Item(3, i).Value = FormatNumber(price_exvat, 2)
            DataGridView1.Item(4, i).Value = FormatNumber(vat_price, 2)
            DataGridView1.Item(5, i).Value = FormatNumber((price_exvat + vat_price), 2)
            DataGridView1.Item(8, i).Value = FormatNumber(((price_exvat + vat_price) - CDbl(DataGridView1.Item(6, i).Value)) + CDbl(DataGridView1.Item(7, i).Value), 2)
            txt_sum_price.Text = FormatNumber(price_exvat, 2)
            txt_sum_vat.Text = FormatNumber(vat_price, 2)
            txt_sum_service_chg.Text = DataGridView1.Item(7, i).Value
            txt_sum_discount.Text = DataGridView1.Item(6, i).Value
            txt_sum_total.Text = DataGridView1.Item(3, i).Value
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub Cal_Service_Discount()
        Try
            Dim i As Integer
            i = DataGridView1.CurrentRow.Index
            txt_sum_price.Text = FormatNumber(DataGridView1.Item(5, i).Value)
            txt_sum_vat.Text = DataGridView1.Item(4, i).Value
            txt_sum_service_chg.Text = DataGridView1.Item(7, i).Value
            txt_sum_discount.Text = DataGridView1.Item(6, i).Value
            txt_sum_total.Text = (CDbl(DataGridView1.Item(5, i).Value) - CDbl(DataGridView1.Item(6, i).Value)) + CDbl(DataGridView1.Item(7, i).Value)
            DataGridView1.Item(8, i).Value = (CDbl(DataGridView1.Item(5, i).Value) - CDbl(DataGridView1.Item(6, i).Value)) + CDbl(DataGridView1.Item(7, i).Value)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub DataGridView2_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellEndEdit
        cal_datagrid1()
        Cal_Service_Discount()
    End Sub
    Private Sub DataGridView1_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
        Cal_Service_Discount()
    End Sub

    Private Sub enter_void_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles enter_void.Click
        Try
            Dim result As Integer = MessageBox.Show("คุณมั่นใจใช่ไหมที่จะยกเลิกบิลนี้", "Confirm Void Bill", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then
                Dim i As Integer
                i = DataGridView1.CurrentRow.Index
                Dim id As Integer = DataGridView1.Item(0, i).Value
                Dim q1 As Boolean = con.mysql_query("UPDATE pos_order_list SET status_sd_captain='void' where rf_id_invoice='" & id & "' and status_pay='yes'")
                Dim q_closebill As Boolean = con.mysql_query("UPDATE pos_closebilldetail SET cstatus='void',cupdate_by='" & Login.username & "' WHERE crf_id_invoice='" & id & "' ")
                If q1 = True And q_closebill = True Then
                    Dim q2 As Boolean = con.mysql_query("UPDATE pos_invoice SET void='1' WHERE id='" & id & "'")
                    If q2 = True Then
                        MessageBox.Show("Void Bill Complete", "Message Alert", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        LoadINV()
                        btn_save.Enabled = False
                        DataGridView2.Rows.Clear()
                        Label3.Text = "No."
                        txt_sum_price.Text = "0.0"
                        txt_sum_vat.Text = "0.0"
                        txt_sum_service_chg.Text = "0.0"
                        txt_sum_discount.Text = "0.0"
                        txt_sum_total.Text = "0.0"
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub print1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles print1.Click
        Try
           
            Dim i As Integer
            i = DataGridView1.CurrentRow.Index
            Dim id_inv As String = DataGridView1.Item(0, i).Value
            showpay_typeprint.invoice_number = id_inv
            showpay_typeprint.ShowDialog()
            ' print.PrintPayment(id_inv, "0", "0", Login.username, "payment", Login.printer_payment) 'Print Bill Payment

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        LoadINV()
    End Sub

    Private Sub txt_service_chg_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_service_chg.TextChanged

    End Sub

    Private Sub Txt_sum_discount_TextChanged(sender As Object, e As EventArgs) Handles txt_sum_discount.TextChanged

    End Sub
End Class