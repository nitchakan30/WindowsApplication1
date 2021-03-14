Imports MySql.Data.MySqlClient
Public Class payment_gohome_subp_dialog
    Dim con As New Mysql
    Dim ac As New Admin_ClassMain
    Public qty_subp As Integer = 0
    Public sel_bill As String = ""
    Private Sub payment_gohome_subp_dialog_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        payment_gohome.s1()
    End Sub
    Private Sub payment_gohome_subp_dialog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Create_Btn()
        RecalPrice_QTY()
    End Sub
    Private Sub Create_Btn()
        FlowLayoutPanel1.Controls.Clear()
        For i As Integer = 0 To payment_gohome.FlowLayoutPanel_Bill.Controls.Count - 1
            Dim btn As New Button
            btn.Name = "No." & i
            btn.Width = "128"
            btn.Height = "55"
            btn.Margin = New Padding(3, 3, 3, 3)
            btn.Font = New Font("Microsoft Sans Serif", 11, FontStyle.Regular)
            btn.Tag = payment_gohome.FlowLayoutPanel_Bill.Controls.Item(i).Tag.ToString
            btn.Text = payment_gohome.FlowLayoutPanel_Bill.Controls.Item(i).Text.ToString
            AddHandler btn.Click, AddressOf Enter_Btn
            FlowLayoutPanel1.Controls.Add(btn)
        Next
    End Sub
    Private Function GetCodeGohomeForINV(ByVal id_inv)
        Dim code As String = ""
        Dim g As MySqlDataReader = con.mysql_query("select IFNULL(code_gohome,'0') as code_gohome from pos_order_list where rf_id_invoice='" & id_inv & "' order by id_ord asc limit 1;")
        While g.Read
            code = g.GetString("code_gohome")
        End While
        Return code
    End Function
    Private Sub Enter_Btn(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim btn As Button = CType(sender, Button)
        Dim strArr() As String = btn.Tag.Split("_")
        Dim btn_id_inv = strArr(0)
        Dim strArr_selbill() As String = sel_bill.Split("_")

        If (strArr_selbill(1) <> strArr(1)) Or btn_id_inv <> strArr_selbill(0) Then
            Dim StringQuery As String = ""
            Dim prs As String = "1"

            '========================== insert new bill ============================================'
            '=== check ว่าย้ายกลับมาบิลที่มีอยู๋แล้วหรือเปล่า
            Dim Is_havebill As Boolean = False
            Dim invoice As MySqlDataReader = con.mysql_query("select rf_id_invoice from pos_order_list where status_pay='no' and status_open='gohome' and rf_id_invoice='" & btn_id_inv & "' GROUP BY rf_id_invoice;")
            While invoice.Read()
                If btn_id_inv = invoice.GetString("rf_id_invoice") Then
                    Is_havebill = True
                End If
            End While

            Dim qty_prd As Integer = 0
            Dim priceAll As Double = 0.0
            For k As Integer = 0 To ListView1.Items.Count - 1
                qty_prd += CInt(ListView1.Items(k).SubItems(8).Text)
                priceAll += CDbl(ListView1.Items(k).SubItems(11).Text)
            Next

            Dim id As String = ""
            Dim code_gohome As String = ""

            If Is_havebill = True Then '=== เช็คว่าย้ายกลับมาที่มีบิลในระบบออยู่แล้วหรือเปล่า ===='
                id = btn_id_inv
                code_gohome = GetCodeGohomeForINV(strArr_selbill(0))
                StringQuery &= "UPDATE pos_invoice_temp SET qty=qty+" & qty_prd & ",price_all=price_all+" & priceAll & ",update_by='" & Login.username & "' " _
                & " WHERE id='" & id & "';"
            Else
                Dim number_invoice As String = ac.RuningInvTEMP()
                Dim numPos As String = ac.RuningPOSTEMP()
                Dim str_inv_new As String = ""
                str_inv_new &= "INSERT INTO pos_invoice_temp (namber_inv,number_pos,qty,price_all,create_by," _
                & "create_date,rf_payment_type,des_payment,machin_number," _
                & "price_exclu_vat,vat,serviceCh,discount,discount_des,discount_sum,ref_id_payment_acc," _
                & "machine_inv,rf_id_card,money_recript," _
                & "money_ton,close_rop_id_inv,close_rop_name_inv) " _
                & "VALUES('" & number_invoice & "','" & numPos & "','" & qty_prd & "','" & priceAll & "','" & Login.username & "'," _
                & "'" & Login.DateData.ToString("yyyy-MM-dd ") & Date.Now().ToString("HH:mm:ss") & "','0','-'," _
                & "'" & System.Net.Dns.GetHostName() & "','0','0','0','0','0','0','0','" & Login.getMacAddress & "'," _
                & "'0','0.0','0','" & Login.Id_RopBill & "','" & Login.Str_Ropbill & "');"
                con.mysql_query(str_inv_new) '== query insert invoice temp for get id invoice=='
                Dim query_inv As MySqlDataReader = con.mysql_query("SELECT id as id FROM  pos_invoice_temp where namber_inv='" & number_invoice & "' LIMIT 1;")
                query_inv.Read()
                id = query_inv.GetString("id")
                code_gohome = GetCodeGohomeForINV(strArr_selbill(0))
            End If

            For j As Integer = 0 To ListView1.Items.Count - 1
                Dim status_sd_captain As String = ListView1.Items(j).SubItems(0).Text
                Dim rf_id_prd As String = ListView1.Items(j).SubItems(2).Text
                Dim rf_id_con As String = ListView1.Items(j).SubItems(3).Text
                Dim name_ord As String = ListView1.Items(j).SubItems(4).Text.Replace("'", "\'")
                Dim name_ord_en As String = ListView1.Items(j).SubItems(5).Text.Replace("'", "\'")
                Dim qty As Integer = CInt(ListView1.Items(j).SubItems(8).Text)
                Dim price As Double = CDbl(ListView1.Items(j).SubItems(11).Text)
                Dim remark As String = ListView1.Items(j).SubItems(16).Text.Replace("'", "\'")
                Dim id_cat As String = ListView1.Items(j).SubItems(17).Text.Trim
                Dim id_subcatprd As String = ListView1.Items(j).SubItems(18).Text.Trim
                Dim name_cat_en As String = ListView1.Items(j).SubItems(19).Text.Trim
                Dim name_cat_th As String = ListView1.Items(j).SubItems(20).Text.Trim
                Dim name_subcat_en As String = ListView1.Items(j).SubItems(21).Text.Trim
                Dim name_subcat_th As String = ListView1.Items(j).SubItems(22).Text.Trim
                Dim ord_vat As Integer = CInt(ListView1.Items(j).SubItems(23).Text.Trim)
                Dim ord_vat_st As String = ListView1.Items(j).SubItems(24).Text.Trim
                Dim rf_id_table As Integer = ListView1.Items(j).SubItems(27).Text.Trim

                Dim check_is_prd As Integer = con.mysql_num_rows(con.mysql_query("select * from pos_order_list " _
                    & "where rf_id_prd='" & rf_id_prd & "' and rf_id_con='" & rf_id_con & "' and name_ord='" & name_ord & "' and " _
                    & "code_gohome='" & code_gohome & "' and status_open='gohome' and rf_id_invoice='" & id & "' and status_pay='no';"))
                If check_is_prd > 0 Then
                    StringQuery &= "UPDATE pos_order_list SET amt=amt+" & qty & ",price=price+'" & price & "' " _
                    & "where rf_id_prd='" & rf_id_prd & "' and rf_id_con='" & rf_id_con & "' and name_ord='" & name_ord & "' and " _
                    & "code_gohome='" & code_gohome & "' and status_open='gohome' and rf_id_invoice='" & id & "' and status_pay='no';"
                Else
                    StringQuery &= "INSERT INTO pos_order_list (rf_id_prd,rf_id_con,name_ord,name_ord_en,amt,price,prs,rf_id_invoice," _
                    & "code_gohome,status_sd_captain,status_open,status_pay,remark,create_date,create_by,ref_cat_id," _
                    & "ref_catsubprd,name_th_cat,name_en_cat,name_th_catsubprd,name_en_catsubprd,ord_vat,ord_vat_st) " _
                    & " VALUES('" & rf_id_prd & "','" & rf_id_con & "','" & name_ord & "','" & name_ord_en & "','" & qty & "','" & price & "'," _
                    & "'" & prs & "','" & id & "','" & code_gohome & "','" & status_sd_captain & "'," _
                    & "'gohome','no','" & remark & "','" & Login.DateData.ToString("yyyy-MM-dd") & Date.Now.ToString(" HH:mm:ss") & "','" & Login.username & "'," _
                    & "'" & id_cat & "','" & id_subcatprd & "','" & name_cat_th & "'," _
                    & "'" & name_cat_en & "','" & name_subcat_th & "','" & name_subcat_en & "','" & ord_vat & "','" & ord_vat_st & "');"
                End If

            Next

            '==== insert old bill at select==='

            StringQuery &= "DELETE FROM pos_order_list WHERE code_gohome='" & GetCodeGohomeForINV(strArr_selbill(0)) & "' and rf_id_invoice='" & strArr_selbill(0) & "' and status_pay='no' and status_open='gohome';" '=== delete order old ==='
            Dim qty_new As Integer = 0
            Dim price_all_new As Double = 0.0
            For r As Integer = 0 To payment_gohome.ListView1.Items.Count - 1 '=== loop insert order new but invoice old ==='
                Dim status_sd_captain As String = payment_gohome.ListView1.Items(r).SubItems(0).Text
                Dim rf_id_prd As String = payment_gohome.ListView1.Items(r).SubItems(2).Text
                Dim rf_id_con As String = payment_gohome.ListView1.Items(r).SubItems(3).Text
                Dim name_ord As String = payment_gohome.ListView1.Items(r).SubItems(4).Text.Replace("'", "\'")
                Dim name_ord_en As String = payment_gohome.ListView1.Items(r).SubItems(5).Text.Replace("'", "\'")
                Dim qty As Integer = CInt(payment_gohome.ListView1.Items(r).SubItems(8).Text)
                Dim price As Double = CDbl(payment_gohome.ListView1.Items(r).SubItems(11).Text)
                Dim remark As String = payment_gohome.ListView1.Items(r).SubItems(16).Text.Replace("'", "\'")
                Dim id_cat As String = payment_gohome.ListView1.Items(r).SubItems(17).Text.Trim
                Dim id_subcatprd As String = payment_gohome.ListView1.Items(r).SubItems(18).Text.Trim
                Dim name_cat_en As String = payment_gohome.ListView1.Items(r).SubItems(19).Text.Trim
                Dim name_cat_th As String = payment_gohome.ListView1.Items(r).SubItems(20).Text.Trim
                Dim name_subcat_en As String = payment_gohome.ListView1.Items(r).SubItems(21).Text.Trim
                Dim name_subcat_th As String = payment_gohome.ListView1.Items(r).SubItems(22).Text.Trim
                Dim ord_vat As Integer = CInt(payment_gohome.ListView1.Items(r).SubItems(23).Text.Trim)
                Dim ord_vat_st As String = payment_gohome.ListView1.Items(r).SubItems(24).Text.Trim
                Dim rf_id_table As Integer = payment_gohome.ListView1.Items(r).SubItems(25).Text.Trim

                If qty <> 0 Then
                    qty_new += qty
                    price_all_new += price
                    StringQuery &= "INSERT INTO pos_order_list (rf_id_prd,rf_id_con,name_ord,name_ord_en,amt,price,prs,rf_id_invoice," _
                    & "code_gohome,status_sd_captain,status_open,status_pay,remark,create_date,create_by,ref_cat_id," _
                    & "ref_catsubprd,name_th_cat,name_en_cat,name_th_catsubprd,name_en_catsubprd,ord_vat,ord_vat_st) " _
                    & " VALUES('" & rf_id_prd & "','" & rf_id_con & "','" & name_ord & "','" & name_ord_en & "','" & qty & "','" & price & "'," _
                    & "'" & prs & "','" & strArr_selbill(0) & "','" & GetCodeGohomeForINV(strArr_selbill(0)) & "','" & status_sd_captain & "','gohome','no'," _
                    & "'" & remark & "','" & Login.DateData.ToString("yyyy-MM-dd") & Date.Now.ToString(" HH:mm:ss") & "','" & Login.username & "'," _
                    & "'" & id_cat & "','" & id_subcatprd & "','" & name_cat_th & "'," _
                    & "'" & name_cat_en & "','" & name_subcat_th & "','" & name_subcat_en & "','" & ord_vat & "','" & ord_vat_st & "');"
                End If
            Next

            Dim discount_des As String = ""
            Dim discount_sum As Double = 0.0
            If payment_gohome.Label_ShowAllDisType.Tag.ToString = "%" Then
                discount_des = payment_gohome.Label_ShowAllDisType.Tag.ToString
                discount_sum = FormatNumber(((CDbl(payment_gohome.txt_priceall.Text) + CDbl(payment_gohome.txt_sum_vat.Text) - 0) * CDbl(payment_gohome.txt_dis_all.Text)) / 100, 2)
            Else
                discount_des = payment_gohome.Label_ShowAllDisType.Tag.ToString
                discount_sum = FormatNumber(CDbl(payment_gohome.txt_dis_all.Text), 2)
            End If
            StringQuery &= "UPDATE pos_invoice_temp SET qty='" & qty_new & "',price_all='" & price_all_new & "',update_by='" & Login.username & "'," _
                & "vat='" & CDbl(payment_gohome.txt_sum_vat.Text) & "',price_exclu_vat='" & CDbl(payment_gohome.txt_priceall.Text) & "',discount='" & CDbl(payment_gohome.txt_dis_all.Text) & "'," _
                & "discount_des='" & discount_des & "',discount_sum='" & discount_sum & "' WHERE id='" & strArr_selbill(0) & "';"

            '==== delete bill ที่ค้างในระบบเมื่อย้ายข้อมูลไปบิลอื่นๆหมดแล้ว ลบทั้ง order_list และ pos_invoice_temp ===='
            Dim c As Integer = con.mysql_num_rows(con.mysql_query("select * From pos_order_list where code_gohome='" & GetCodeGohomeForINV(strArr_selbill(0)) & "' and rf_id_invoice='" & strArr_selbill(0) & "' and status_pay='no' and status_open='gohome';"))
            If c <= 0 Then
                StringQuery &= "DELETE FROM pos_order_list where code_gohome='" & GetCodeGohomeForINV(strArr_selbill(0)) & "' and rf_id_invoice='" & strArr_selbill(0) & "' and status_pay='no' and status_open='gohome';"
                StringQuery &= "DELETE FROM pos_invoice_temp where id='" & strArr_selbill(0) & "';"
            End If

            Dim q As Boolean = False
            If StringQuery <> "" Then
                q = con.mysql_query(StringQuery)
            End If
            If q = True Then
                MsgBox("Move Order Complete.")
            End If
        End If
        Me.Close()
    End Sub

    Private Sub btn_up_sel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_up_sel.Click
        If ListView1.Items.Count > 0 Then
            If ListView1.SelectedItems.Count > 0 Then
                If ListView1.SelectedIndices(0) > 0 Then
                    ListView1.Items.Item(ListView1.SelectedIndices(0) - 1).Selected = True
                    ListView1.Focus()
                End If
            Else
                ListView1.Items.Item(0).Selected = True
                ListView1.Focus()
            End If
        End If
    End Sub

    Private Sub btn_drow_sel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_drow_sel.Click
        If ListView1.Items.Count > 0 Then
            If ListView1.SelectedItems.Count > 0 Then
                If ListView1.SelectedIndices(0) < ListView1.Items.Count - 1 Then
                    ListView1.Items.Item(ListView1.SelectedIndices(0) + 1).Selected = True
                    ListView1.Focus()
                End If
            Else
                ListView1.Items.Item(ListView1.Items.Count - 1).Selected = True
                ListView1.Focus()
            End If
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click, ListView1.DoubleClick
        keyborad_str.text1 = "Edit_QTY_GH"
        keyborad_str.ShowDialog()
        If qty_subp > CInt(ListView1.Items(ListView1.SelectedIndices(0)).SubItems(25).Text) Or qty_subp <= 0 Then
            MsgBox("จำนวนไม่ต้องกับยอดเดิม กรุณาตรววจสอบด้วยค่ะ")
            ListView1.Items(ListView1.SelectedIndices(0)).SubItems(8).Text = ListView1.Items(ListView1.SelectedIndices(0)).SubItems(25).Text
            qty_subp = ListView1.Items(ListView1.SelectedIndices(0)).SubItems(25).Text
        End If
        Dim qty_up_payment As Integer = CInt(ListView1.Items(ListView1.SelectedIndices(0)).SubItems(25).Text) - qty_subp
        Dim str_vat As String = ""
        Dim vats As Double = 0.0
        Dim vats1 As Double = 0.0
        Dim price_new As Double = 0.0
        Dim price_new1 As Double = 0.0
        Dim price_new2 As Double = 0.0
        If ListView1.Items(ListView1.SelectedIndices(0)).SubItems(2).Text = "0" Then
            vats = 0
            Dim pprice As Double = CDbl(ListView1.Items(ListView1.SelectedIndices(0)).SubItems(26).Text) / CInt(ListView1.Items(ListView1.SelectedIndices(0)).SubItems(25).Text)
            price_new = CDbl(ListView1.Items(ListView1.SelectedIndices(0)).SubItems(26).Text) / CInt(ListView1.Items(ListView1.SelectedIndices(0)).SubItems(25).Text)
            If CInt(ListView1.Items(ListView1.SelectedIndices(0)).SubItems(23).Text) = 0 Then
                str_vat = "None(vat)"
                vats = 0
                price_new1 = FormatNumber(pprice * qty_subp, 2)
                price_new2 = FormatNumber(pprice * qty_up_payment, 2)
            ElseIf CInt(ListView1.Items(ListView1.SelectedIndices(0)).SubItems(23).Text) = 1 Then
                str_vat = "Inc(vat)"
                vats = pprice - ((pprice * 100) / CInt(ListView1.Items(ListView1.SelectedIndices(0)).SubItems(24).Text + 100))
                price_new1 = FormatNumber((price_new - vats) * qty_subp, 2)
                price_new2 = FormatNumber((price_new - vats) * qty_up_payment, 2)
            ElseIf CInt(ListView1.Items(ListView1.SelectedIndices(0)).SubItems(23).Text) = 2 Then
                str_vat = "Add(vat)"
                vats = pprice * (CInt(ListView1.Items(ListView1.SelectedIndices(0)).SubItems(24).Text) / 100)
                price_new1 = FormatNumber(price_new * qty_subp, 2)
                price_new2 = FormatNumber(price_new * qty_up_payment, 2)
            End If
        Else
            ' หา vat / status 
            vats = home1.vat_prd_cal(ListView1.Items(ListView1.SelectedIndices(0)).SubItems(2).Text, CDbl(ListView1.Items(ListView1.SelectedIndices(0)).SubItems(26).Text / ListView1.Items(ListView1.SelectedIndices(0)).SubItems(25).Text))
            price_new = CDbl(ListView1.Items(ListView1.SelectedIndices(0)).SubItems(26).Text / ListView1.Items(ListView1.SelectedIndices(0)).SubItems(25).Text)
            If home1.vat_in_ex(ListView1.Items(ListView1.SelectedIndices(0)).SubItems(2).Text) = "0" Then
                str_vat = "None(vat)"
                price_new1 = FormatNumber(price_new * qty_subp, 2)
                price_new2 = FormatNumber(price_new * qty_up_payment, 2)
            ElseIf home1.vat_in_ex(ListView1.Items(ListView1.SelectedIndices(0)).SubItems(2).Text) = "1" Then
                str_vat = "Inc(vat)"
                price_new1 = FormatNumber((price_new - vats) * qty_subp, 2)
                price_new2 = FormatNumber((price_new - vats) * qty_up_payment, 2)
            ElseIf home1.vat_in_ex(ListView1.Items(ListView1.SelectedIndices(0)).SubItems(2).Text) = "2" Then
                str_vat = "Add(vat)"
                price_new1 = FormatNumber(price_new * qty_subp, 2)
                price_new2 = FormatNumber(price_new * qty_up_payment, 2)
            End If
        End If

        ListView1.Items(ListView1.SelectedIndices(0)).SubItems(8).Text = qty_subp
        ListView1.Items(ListView1.SelectedIndices(0)).SubItems(9).Text = price_new1
        ListView1.Items(ListView1.SelectedIndices(0)).SubItems(10).Text = FormatNumber(vats * CInt(qty_subp), 2)
        ListView1.Items(ListView1.SelectedIndices(0)).SubItems(11).Text = FormatNumber(CDbl(price_new1 + (vats * CInt(qty_subp))), 2)
        ListView1.Items(ListView1.SelectedIndices(0)).SubItems(15).Text = FormatNumber(CDbl(price_new1 + (vats * CInt(qty_subp))), 2)

        '=== Update Listview หน้า payment เพื่ออัพเดตลงดาต้าเบส==='
        For i As Integer = (payment_gohome.ListView1.Items.Count - 1) To 0 Step -1
            If payment_gohome.ListView1.Items(i).Checked = True Then
                If ListView1.Items(ListView1.SelectedIndices(0)).SubItems(4).Text = payment_gohome.ListView1.Items(i).SubItems(4).Text Then
                    payment_gohome.ListView1.Items(i).SubItems(8).Text = qty_up_payment
                    payment_gohome.ListView1.Items(i).SubItems(9).Text = price_new2
                    payment_gohome.ListView1.Items(i).SubItems(10).Text = FormatNumber(vats * CInt(qty_up_payment), 2)
                    payment_gohome.ListView1.Items(i).SubItems(11).Text = FormatNumber(CDbl(price_new2 + (vats * CInt(qty_up_payment))), 2)
                    payment_gohome.ListView1.Items(i).SubItems(15).Text = FormatNumber(CDbl(price_new2 + (vats * CInt(qty_up_payment))), 2)
                End If
            End If
        Next
        payment_gohome.cal_list_price()
    End Sub
    Public Sub RecalPrice_QTY()
        '=== Update Listview หน้า payment เพื่ออัพเดตลงดาต้าเบส==='
        For i As Integer = (payment_gohome.ListView1.Items.Count - 1) To 0 Step -1
            If payment_gohome.ListView1.Items(i).Checked = True Then
                For j As Integer = 0 To ListView1.Items.Count - 1
                    If ListView1.Items(j).SubItems(4).Text = payment_gohome.ListView1.Items(i).SubItems(4).Text Then
                        payment_gohome.ListView1.Items(i).SubItems(8).Text = "0"
                        payment_gohome.ListView1.Items(i).SubItems(9).Text = "0"
                        payment_gohome.ListView1.Items(i).SubItems(10).Text = FormatNumber("0", 2)
                        payment_gohome.ListView1.Items(i).SubItems(11).Text = FormatNumber("0", 2)
                        payment_gohome.ListView1.Items(i).SubItems(15).Text = FormatNumber("0", 2)
                    End If
                Next
            End If
        Next
        payment_gohome.cal_list_price()
    End Sub
End Class