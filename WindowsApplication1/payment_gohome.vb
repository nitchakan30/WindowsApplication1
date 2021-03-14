Imports MySql.Data.MySqlClient
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Threading
Imports ccltsvc
Public Class payment_gohome
    Dim con As New Mysql
    Dim con_front As New MysqlFront
    Dim ac As New Admin_ClassMain
    Dim print As New printClass
    Dim paymentType As String = "cash"
    Public code_gohome As String
    Public StrSql As String
    Dim vat_st As Boolean = False
    Dim Serv_st As Boolean = False
    Public qty_prd As Integer = 0
    Public des_payment As String = "CASH"
    Public rf_payment_type As Integer = 1
    Public rf_payment_acc As Integer = 0
    Public payment_cl As Boolean = False
    Public page As String = ""
    Public Discount As Double = 0.0
    Public Ref_Invoice As String = ""
    Public Code_GohomeEdit As String = ""
    Public payment_type_request_id As String = ""
    Public payment_type_request_text As String = ""
    Public print_vat As Boolean = True
    Public page_confirm_pay As Boolean = False
    Public calc As New calc
    Public ihno As String = ""
    Dim selBill As String = ""
    Public selBill_sendgohomelist As String = ""
    Public id_card As Integer = 0
    Public rf_id_oc As Integer = 0
    Public rf_name_oc As String = "-"
    Private Sub payment_gohome_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DoubleBuffered = True
        LoadSMType()
        TextBox_InputC.Focus()
        print_rongbill.Enabled = index.onoff_rongbill()
        s1()
        If code_gohome = "" Or code_gohome = "0" Then
            GroupBox5.Visible = False
        Else
            GroupBox5.Visible = True
        End If
        TextBox_TypePay.Text = "CASH"
    End Sub
    Private Sub payment_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        ' Determine whether the keystroke is a number from the top of the keyboard. 
        If e.KeyCode < Keys.D0 OrElse e.KeyCode > Keys.D9 Then
            ' Determine whether the keystroke is a number from the keypad. 
            If e.KeyCode < Keys.NumPad0 OrElse e.KeyCode > Keys.NumPad9 Then
                ' Determine whether the keystroke is a backspace. 
                If e.KeyCode <> Keys.Back Then
                    ' A non-numerical keystroke was pressed.  
                    ' Set the flag to true and evaluate in KeyPress event.
                    Convert.ToChar(e.KeyCode)
                End If
            End If
        End If
    End Sub
    Private Sub btn_back_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_back.Click
        index.CloseForm()
        If page = "gohome_list" Then
            gohome_list.MdiParent = index
            gohome_list.Show()
            gohome_list.WindowState = FormWindowState.Minimized
            gohome_list.WindowState = FormWindowState.Maximized
            Login.Formname = "gohome_list"
        ElseIf page = "opentakehome" Then
            opentakehome.MdiParent = index
            opentakehome.Show()
            opentakehome.WindowState = FormWindowState.Minimized
            opentakehome.WindowState = FormWindowState.Maximized
            Login.Formname = "opentakehome"
        Else
            gohome_list.MdiParent = index
            gohome_list.Show()
            gohome_list.WindowState = FormWindowState.Minimized
            gohome_list.WindowState = FormWindowState.Maximized
            Login.Formname = "gohome_list"
        End If
        payment_cl = False
        code_gohome = ""
        opentakehome.SendOrder1 = "0"
        Me.Close()
    End Sub
    Public discount_prd As Double = 0.0
    Public Sub cal_list_price()
        qty_prd = 0
        Dim serCh As Double = 0.0
        Dim serCh_St As Boolean = False
        Dim cal_format As String = ""
        Dim vat_bill_st As String = ""
        Dim vat_bill As Integer = 0
        If Login.use_client = "com" Then
            serCh = Login.service_val
            serCh_St = Login.service_st
            cal_format = Login.cal_format
            vat_bill_st = Login.vat_all_status
            vat_bill = Login.vat_all_val
            txt_service_chg.Text = Login.service_val
        Else
            Dim res_shop As MySqlDataReader = con.mysql_query("select vat,vat_status,service_chg,service_status,cal_format from pos_shop")
            While res_shop.Read()
                If CInt(res_shop.GetString("service_chg")) > 0 Then
                    txt_service_chg.Text = res_shop.GetString("service_chg")
                    serCh = res_shop.GetString("service_chg")
                    If CInt(res_shop.GetString("service_chg")) > 0 And res_shop.GetString("service_status") = "inc" Then
                        serCh_St = False
                    ElseIf CInt(res_shop.GetString("service_chg")) > 0 And res_shop.GetString("service_status") = "exc" Then
                        serCh_St = True
                    Else
                        serCh_St = False
                    End If
                Else
                    serCh_St = False
                End If
                vat_bill_st = res_shop.GetString("vat_status")
                vat_bill = res_shop.GetInt32("vat")
                cal_format = res_shop.GetString("cal_format")
            End While

        End If

        'Show TYpe Service Ch
        If serCh > 0 And serCh_St = False Then
            txt_service_ch_type.Text = "Include"
        ElseIf serCh > 0 And serCh_St = True Then
            txt_service_ch_type.Text = "Exclude"
        Else
            txt_service_ch_type.Text = "None"
        End If

        Dim vat As Double = 0
        Dim ser_chg As Double = 0
        Dim v1 As Double = 0.0
        Dim v2 As Double = 0.0
        Dim v3 As Double = 0.0
        Dim v4 As Double = 0.0
        Dim v5 As Double = 0.0
        Dim allnetamount As Double = 0.0
        Dim vat_n As Double = 0.0
        Dim priceAl As Double = 0.0
        Dim discount As Double = 0.0
        Dim net As Double = 0.0
        Dim cboVat As String = ""
        Dim cbDis As Boolean = False
        Dim servCh_sum As Double = 0.0
        If ListView1.Items.Count > 0 Then
            For i As Integer = 0 To ListView1.Items.Count - 1
                If ListView1.Items(i).SubItems(0).Text.ToLower = "yes" Or ListView1.Items(i).SubItems(0).Text.ToLower = "no" Then
                    If ListView1.Items(i).SubItems(24).Text() = "1" Then
                        cboVat = "inc"
                    ElseIf ListView1.Items(i).SubItems(24).Text() = "2" Then
                        cboVat = "exc"
                    Else
                        cboVat = "non"
                    End If
                    If ListView1.Items(i).SubItems(14).Text() = "%" Then
                        cbDis = True
                    Else
                        cbDis = False
                    End If
                    Dim pp As Double = 0.0
                    If ListView1.Items(i).SubItems(24).Text() = "2" Or ListView1.Items(i).SubItems(24).Text() = 2 Then
                        pp = ListView1.Items(i).SubItems(9).Text()
                    Else
                        pp = ListView1.Items(i).SubItems(11).Text()
                    End If
                    calc.setval(cal_format, CDbl(pp), cboVat, CDbl(ListView1.Items(i).SubItems(23).Text()), False, 0, cbDis, Math.Abs(CDbl(ListView1.Items(i).SubItems(12).Text())))
                    allnetamount += CDbl(calc.GetAmount)
                    vat_n += CDbl(calc.GetVat)
                    qty_prd += CInt(ListView1.Items(i).SubItems(8).Text)
                    servCh_sum += CDbl(calc.GetService)
                    discount += CDbl(calc.GetDiscount)
                    net += CDbl(calc.GetTotal)

                End If
            Next

            Dim cboDis_bill = False
            If Label_ShowAllDisType.Tag = "%" Then
                cboDis_bill = True
            Else
                cboDis_bill = False
            End If
            calc.setval(cal_format, CDbl(net), vat_bill_st, vat_bill, serCh_St, CDbl(serCh), cboDis_bill, Math.Abs(CDbl(txt_dis_all.Text)))
            txt_sum_discount.Text = FormatNumber(CDbl(calc.GetDiscount) + discount, 2)
            txt_priceall.Text = FormatNumber(CDbl(calc.GetAmount), 2)
            txt_sum_vat.Text = FormatNumber(CDbl(calc.GetVat), 2)
            txt_sum_service_chg.Text = FormatNumber(CDbl(calc.GetService), 2)
            txt_sum_total.Text = FormatNumber(CDbl(calc.GetTotal), 2)
        End If

    End Sub

  
    Private Sub LoadSMType()
        FlowLayoutPanel_TypePay.Controls.Clear()
        Dim res_m As MySqlDataReader = con.mysql_query("SELECT * FROM pos_payment_type where pay_active='1' ORDER BY id ASC")
        Dim x As Integer = 8
        Dim y As Integer = 5
        While res_m.Read()
            If CInt(res_m.GetString("pay_active")) = 1 Then
                Dim btn_m As New Button
                btn_m.Text = res_m.GetString("name")
                btn_m.Name = res_m.GetString("id")
                If CInt(res_m.GetString("id")) = 1 Then
                    btn_m.BackgroundImage = My.Resources.Resources.bg_3
                Else
                    btn_m.BackgroundImage = My.Resources.Resources.bg_2
                End If
                btn_m.Width = "110"
                btn_m.Height = "38"
                btn_m.ForeColor = Color.White
                btn_m.Padding = New Padding(5, 3, 8, 3)
                btn_m.Location = New Point(x, y)
                btn_m.FlatStyle = FlatStyle.Flat
                btn_m.FlatAppearance.BorderSize = "0"
                btn_m.Cursor = Cursors.Hand
                btn_m.Tag = res_m.GetString("id") & "_" & res_m.GetString("name")
                AddHandler btn_m.Click, AddressOf Change_color
                FlowLayoutPanel_TypePay.Controls.Add(btn_m)
                x += 0
                y += 40
            End If
        End While
        res_m.Close()

    End Sub

    Private Sub Change_color(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim menu As Button = CType(sender, Button)
        Dim res1 As MySqlDataReader = con.mysql_query("SELECT * FROM pos_payment_type where pay_active<>'0' ORDER BY id ASC")
        Dim num As Integer = con.mysql_num_rows(res1)
        res1.Close()
        For i As Integer = 0 To num - 1
            Dim btn As Button = CType(FlowLayoutPanel_TypePay.Controls.Item(i), Button)
            If btn.Name = menu.Name Then
                menu.BackgroundImage = My.Resources.Resources.bg_3
            Else
                btn.BackgroundImage = My.Resources.Resources.bg_2
            End If
        Next
        ' GET paymentType  , des_payment
        Dim str() As String = menu.Tag.ToString.Split("_")
        rf_payment_type = str(0)
        payment_inputtype.rf_payment_type = rf_payment_type
        If rf_payment_type = 1 Then
            payment_inputtype.GroupBox_Credit.Hide()
            payment_inputtype.GroupBox_BankTranfer.Hide()
            payment_inputtype.GroupBox_Coupon.Hide()
            TextBox_TypePay.Text = "CASH"
        ElseIf rf_payment_type = 2 Then
            payment_inputtype.GroupBox_BankTranfer.Hide()
            payment_inputtype.GroupBox_Credit.Show()
            payment_inputtype.GroupBox_Coupon.Hide()
            payment_inputtype.page = "payment_gohome"
            payment_inputtype.ShowDialog()
        ElseIf rf_payment_type = 3 Then
            payment_inputtype.GroupBox_Credit.Hide()
            payment_inputtype.GroupBox_BankTranfer.Show()
            payment_inputtype.GroupBox_Coupon.Hide()
            inroom.page = "payment_gohome"
            inroom.ShowDialog()
        ElseIf rf_payment_type = 4 Then
            payment_inputtype.GroupBox_Credit.Hide()
            payment_inputtype.GroupBox_BankTranfer.Hide()
            payment_inputtype.GroupBox_Coupon.Show()
            payment_inputtype.page = "payment_gohome"
            payment_inputtype.ShowDialog()
        ElseIf rf_payment_type = 5 Then
            payment_inputtype.GroupBox_Credit.Hide()
            payment_inputtype.GroupBox_BankTranfer.Hide()
            payment_inputtype.GroupBox_Coupon.Hide()
            payment_inputtype.GroupBox_Other.Show()
            payment_inputtype.page = "payment_gohome"
            payment_inputtype.ShowDialog()
        ElseIf rf_payment_type = 99 Then
            payment_inputbanktranfer.rf_payment_type = 99
            payment_inputbanktranfer.page = "payment_gohome"
            payment_inputbanktranfer.ShowDialog()
        Else
            payment_inputtype.GroupBox_Credit.Hide()
            payment_inputtype.GroupBox_BankTranfer.Hide()
            payment_inputtype.GroupBox_Coupon.Hide()
            payment_inputtype.GroupBox_Other.Hide()
            des_payment = str(1)
            TextBox_TypePay.Text = str(1)
            Dim ck As Integer = con.mysql_num_rows(con.mysql_query("select * from pos_payment_oc where ref_payment_type_id='" & menu.Name & "' and status_oc='1'; "))
            If ck > 0 Then
                payment_oc.payment_type_id = menu.Name
                payment_oc.payment_type_name = menu.Text
                payment_oc.payment_amount_oc = CDbl(txt_sum_total.Text)
                payment_oc.page = "payment_gohome"
                payment_oc.ShowDialog()
            End If
        End If

    End Sub

    Dim dot As Boolean = True
    Public Sub InputNum(ByVal Num As String)
        If Num = "." Then
            If dot = False Then
                TextBox_InputC.Text &= Num
                dot = True
            End If
        Else
            If TextBox_InputC.Text <> "" Then
                If CDbl(TextBox_InputC.Text) = 0 Then
                    TextBox_InputC.Clear()
                    dot = False
                End If
            End If
            If dot = True Then
                Dim words As String() = TextBox_InputC.Text.ToString.Split(New Char() {"."c})
                If words(1).Length < 2 Then
                    TextBox_InputC.Text &= Num
                End If
            Else
                TextBox_InputC.Text &= Num
            End If
        End If
    End Sub

    Private Sub Btn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn1.Click
        InputNum(1)
    End Sub

    Private Sub Btn2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn2.Click
        InputNum(2)
    End Sub

    Private Sub Btn3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn3.Click
        InputNum(3)
    End Sub

    Private Sub Btn4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn4.Click
        InputNum(4)
    End Sub

    Private Sub Btn5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn5.Click
        InputNum(5)
    End Sub

    Private Sub Btn6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn6.Click
        InputNum(6)
    End Sub

    Private Sub Btn7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn7.Click
        InputNum(7)
    End Sub

    Private Sub Btn8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn8.Click
        InputNum(8)
    End Sub

    Private Sub Btn9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn9.Click
        InputNum(9)
    End Sub

    Private Sub Btn0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn0.Click
        InputNum(0)
    End Sub

    Private Sub BtnDemin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDemin.Click
        InputNum(".")
    End Sub

    Private Sub Btn_backS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_backS.Click
        If TextBox_InputC.TextLength > 0 Then
            If TextBox_InputC.Text.IndexOf(".") = TextBox_InputC.TextLength - 1 Then
                dot = False
            End If
            TextBox_InputC.Text = TextBox_InputC.Text.Substring(0, TextBox_InputC.TextLength - 1)
        End If
    End Sub

    Private Sub Btn_Reload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Reload.Click
        TextBox_InputC.Text = "0.00"
        dot = True
    End Sub
    Public number_invoice_new As String = ""

    Public Sub EnterPay()
        Btn_Enter.Enabled = False
        Dim ymd As String = Date.Now.ToString("yyMMdd")
        Dim pos_invoice_id As String = ""
        Dim dNow As DateTime = Login.DateData.ToString("yyyy-MM-dd") & " " & Format(DateAndTime.Now, "HH:mm:ss")

        '============GET Price all======================'
        Dim priceAll As Double = txt_sum_total.Text
        '=============GET ค่า id , description ของ ประเภทการจ่ายเงิน============'
        If payment_cl = True Then
            rf_payment_type = payment_type_request_id
            des_payment = payment_type_request_text
            payment_cl = False
        End If
       
        '===============Chreck ส่วนลด ราคาว่าเป็น % หรือ บาท==================='
        Dim descount_des As String = ""
        Dim disC As Double = 0.0
        Dim disC_prd_sum As Double = 0.0
        For j As Integer = 0 To ListView1.Items.Count - 1
            If ListView1.Items(j).SubItems(0).Text.ToLower <> "void" And ListView1.Items(j).SubItems(0).Text.ToLower <> "voidp" Then
                disC_prd_sum += CDbl(ListView1.Items(j).SubItems(13).Text)
            End If
        Next
        If Label_ShowAllDisType.Tag.ToString = "บาท" Then
            descount_des = Label_ShowAllDisType.Tag.ToString
            'disC = FormatNumber(CDbl(txt_dis_all.Text), 2)
            disC = FormatNumber(CDbl(txt_sum_discount.Text) - CDbl(disC_prd_sum), 2)
        Else
            descount_des = Label_ShowAllDisType.Tag.ToString
            ' disC = FormatNumber(((CDbl(txt_priceall.Text) + CDbl(txt_sum_vat.Text) - discount_prd) * CDbl(txt_dis_all.Text)) / 100, 2)
            disC = FormatNumber(CDbl(txt_sum_discount.Text) - CDbl(disC_prd_sum), 2)
        End If

        '=============== INSERT OR UPDATE INVOICE TEMP =========================='
        Dim str_query_invoice As String = ""
        Dim RuningP As String = ""
        Dim RuningInv As String = ""
        ' MsgBox("บิลเก่าตาราง inv_temp:" & selBill)

        '======================== ยังไม่เกิดบิล แล้วกดจ่ายเงิน =========================='
        If selBill = "" Or selBill = "0" Then
            Dim selbillnew As String = ""
            Dim pair As KeyValuePair(Of String, String) = CreateOrderBill()
            selbillnew = pair.Key
            code_gohome = pair.Value
            '=============== INSERT OR UPDATE INVOICE=============='
            str_query_invoice &= "UPDATE pos_invoice_temp SET qty='" & qty_prd & "',price_all='" & priceAll & "',create_by='" & Login.username & "'," _
           & "create_date='" & dNow.ToString("yyyy-MM-dd ") & Date.Now().ToString("HH:mm:ss") & "',rf_payment_type='" & rf_payment_type & "',des_payment='" & des_payment & "'," _
           & "machin_number='" & System.Net.Dns.GetHostName() & "',price_exclu_vat='" & CDbl(txt_priceall.Text) & "',vat='" & CDbl(txt_sum_vat.Text) & "',serviceCh='" & CDbl(txt_sum_service_chg.Text) & "'," _
           & "discount='" & txt_dis_all.Text & "',discount_des='" & descount_des & "',discount_sum='" & disC & "'," _
           & "ref_id_payment_acc='" & rf_payment_acc & "',machine_inv='" & Login.getMacAddress & "',rf_id_card='" & id_card & "'," _
           & "money_recript='" & TextBox_InputC.Text & "',money_ton='" & (CDbl(TextBox_InputC.Text) - CDbl(txt_sum_total.Text)) & "'," _
           & "close_rop_id_inv='" & Login.Id_RopBill & "',close_rop_name_inv='" & Login.Str_Ropbill & "'" _
           & " WHERE id='" & selbillnew & "';"
            RuningInv = ac.RuningInv()
            RuningP = ac.RuningPOS()
            str_query_invoice &= "INSERT INTO pos_invoice (id,namber_inv,number_pos,qty,price_all," _
                & "create_by,create_date,rf_payment_type,des_payment,machin_number,price_exclu_vat," _
                & "vat,serviceCh,discount,discount_des,discount_sum,ref_id_payment_acc,machine_inv," _
                & "rf_id_card,money_recript,money_ton,close_rop_id_inv,close_rop_name_inv)" _
                & "  Select pos_invoice_temp.id,'" & RuningInv & "','" & RuningP & "',qty,price_all, " _
                & "create_by,create_date,rf_payment_type,des_payment,machin_number,price_exclu_vat," _
                & "vat,serviceCh,discount,discount_des,discount_sum,ref_id_payment_acc,machine_inv," _
                & "rf_id_card,money_recript,money_ton,close_rop_id_inv,close_rop_name_inv" _
                & "  FROM pos_invoice_temp WHERE pos_invoice_temp.id='" & selbillnew & "';"
            Dim insert_invoice As Boolean = con.mysql_query(str_query_invoice)
            pos_invoice_id = GetIdInv_Pos_Invoice(RuningInv)
            con.mysql_query("UPDATE pos_order_list SET rf_id_invoice='" & pos_invoice_id & "'," _
           & "status_pay='yes' WHERE (create_date LIKE '%" & dNow.ToString("yyyy-MM-dd") & "%') and " _
           & "status_pay='no' and rf_id_invoice='" & selbillnew & "' and status_open='gohome'; ")
            Dim str_up As String = ""
            str_up &= "UPDATE pos_invoice SET rf_id_oc='" & rf_id_oc & "',rf_name_oc='" & rf_name_oc & "' WHERE id='" & pos_invoice_id & "';"
            If rf_id_oc > 0 Then
                str_up &= "UPDATE pos_payment_oc SET credit_oc = credit_oc - " & CDbl(priceAll) & ",update_by_oc='" & Login.username & "' WHERE id_oc='" & rf_id_oc & "'; "
                str_up &= "INSERT INTO pos_payment_oc_history (ref_id_oc,ref_name_oc,amount_oc_his,remark_oc_his,create_oc_his)" _
                    & " VALUES('" & rf_id_oc & "','" & rf_name_oc & "','" & CDbl(priceAll) & "','" & RuningInv & "','" & Login.username & "'); "
            End If
            If str_up <> "" Then
                con.mysql_query(str_up)
            End If
        End If

        If selBill <> "" And selBill <> "0" Then  '========== เช้ึวว่ามี bill ที่เลือกหรือไม่ จาก Tabs No.1 ด้านล่าง ===='
            str_query_invoice &= "UPDATE pos_invoice_temp SET qty='" & qty_prd & "',price_all='" & priceAll & "',create_by='" & Login.username & "'," _
            & "create_date='" & dNow.ToString("yyyy-MM-dd ") & Date.Now().ToString("HH:mm:ss") & "',rf_payment_type='" & rf_payment_type & "',des_payment='" & des_payment & "'," _
            & "machin_number='" & System.Net.Dns.GetHostName() & "',price_exclu_vat='" & CDbl(txt_priceall.Text) & "',vat='" & CDbl(txt_sum_vat.Text) & "',serviceCh='" & CDbl(txt_sum_service_chg.Text) & "'," _
            & "discount='" & txt_dis_all.Text & "',discount_des='" & descount_des & "',discount_sum='" & disC & "'," _
            & "ref_id_payment_acc='" & rf_payment_acc & "',machine_inv='" & Login.getMacAddress & "',rf_id_card='" & id_card & "'," _
            & "money_recript='" & TextBox_InputC.Text & "',money_ton='" & (CDbl(TextBox_InputC.Text) - CDbl(txt_sum_total.Text)) & "'," _
            & "close_rop_id_inv='" & Login.Id_RopBill & "',close_rop_name_inv='" & Login.Str_Ropbill & "'" _
            & " WHERE id='" & selBill & "';"
            '=============== INSERT OR UPDATE INVOICE=============='
       
                RuningInv = ac.RuningInv()
                RuningP = ac.RuningPOS()

            str_query_invoice &= "INSERT INTO pos_invoice (id,namber_inv,number_pos,qty,price_all," _
                & "create_by,create_date,rf_payment_type,des_payment,machin_number,price_exclu_vat," _
                & "vat,serviceCh,discount,discount_des,discount_sum,ref_id_payment_acc,machine_inv," _
                & "rf_id_card,money_recript,money_ton,close_rop_id_inv,close_rop_name_inv)" _
                & "  Select id,'" & RuningInv & "','" & RuningP & "',qty,price_all, " _
                & "create_by,create_date,rf_payment_type,des_payment,machin_number,price_exclu_vat," _
                & "vat,serviceCh,discount,discount_des,discount_sum,ref_id_payment_acc,machine_inv," _
                & "rf_id_card,money_recript,money_ton,close_rop_id_inv,close_rop_name_inv" _
                & "  FROM pos_invoice_temp WHERE pos_invoice_temp.id='" & selBill & "';"

            Dim insert_invoice As Boolean = con.mysql_query(str_query_invoice)
            pos_invoice_id = GetIdInv_Pos_Invoice(RuningInv)

            Dim str_up As String = ""
            Dim prs As String = "1"
            For y As Integer = 0 To ListView1.Items.Count - 1
                Dim order_dis_val As Double = CDbl(ListView1.Items(y).SubItems(12).Text)
                Dim order_dis_sum As Double = CDbl(ListView1.Items(y).SubItems(13).Text)
                Dim order_dis_type As String = ListView1.Items(y).SubItems(14).Text
                Dim rf_id_prd As String = ListView1.Items(y).SubItems(2).Text
                Dim rf_id_con As String = ListView1.Items(y).SubItems(3).Text
                Dim name_ord As String = ListView1.Items(y).SubItems(4).Text.Replace("'", "\'")
                Dim name_ord_en As String = ListView1.Items(y).SubItems(5).Text.Replace("'", "\'")
                'If ListView1.Items(y).SubItems(0).Text.ToLower <> "void" And ListView1.Items(y).SubItems(0).Text.ToLower <> "voidp" Then
                str_up &= "UPDATE pos_order_list SET prs='" & prs & "',order_dis_val='" & order_dis_val & "'," _
                & "order_dis_sum='" & order_dis_sum & "',order_dis_type='" & order_dis_type & "' " _
                & " where rf_id_prd='" & rf_id_prd & "' and rf_id_con='" & rf_id_con & "' and name_ord='" & name_ord & "' " _
                & " and rf_id_invoice='" & selBill & "' and status_pay='no'  and status_open='gohome';"
                ' End If
            Next
            str_up &= "UPDATE pos_order_list SET rf_id_invoice='" & pos_invoice_id & "'," _
            & "status_pay='yes' WHERE (create_date LIKE '%" & dNow.ToString("yyyy-MM-dd") & "%') and " _
            & "status_pay='no' and rf_id_invoice='" & selBill & "' and status_open='gohome'; "
            '=========update table pos+_invoice filed ที่เพิ่มใหม่เกี่ยวกับ oc ==========='


            str_up &= "UPDATE pos_invoice SET rf_id_oc='" & rf_id_oc & "',rf_name_oc='" & rf_name_oc & "' WHERE id='" & pos_invoice_id & "';"
            If rf_id_oc > 0 Then
                str_up &= "UPDATE pos_payment_oc SET credit_oc = credit_oc - " & CDbl(priceAll) & ",update_by_oc='" & Login.username & "' WHERE id_oc='" & rf_id_oc & "'; "
                str_up &= "INSERT INTO pos_payment_oc_history (ref_id_oc,ref_name_oc,amount_oc_his,remark_oc_his,create_oc_his)" _
                    & " VALUES('" & rf_id_oc & "','" & rf_name_oc & "','" & CDbl(priceAll) & "','" & RuningInv & "','" & Login.username & "'); "
            End If

            Dim c As Boolean = False
            If str_up <> "" Then
                c = con.mysql_query(str_up)
            End If
        End If

        InsertDataInvTo_CloseBillDetail(pos_invoice_id, 0, code_gohome)

        Dim ton As Double = CDbl(TextBox_InputC.Text) - CDbl(txt_sum_total.Text)
        showPay.txt_total.Text = FormatNumber(CDbl(txt_sum_total.Text), 2)
        showPay.txt_recript.Text = FormatNumber(CDbl(TextBox_InputC.Text), 2)
        showPay.txt_ton.Text = FormatNumber(ton, 2)
        ' SET VALUES FORM SHOWPAY
        showPay.invoice_number = pos_invoice_id
        showPay.paytype = rf_payment_type
        showPay.ihno = ihno
        showPay.Ref_Invoice = GetNumberINV_POSINV(pos_invoice_id)
        showPay.recript_m = FormatNumber(CDbl(TextBox_InputC.Text), 2)
        showPay.ton_m = FormatNumber(ton, 2)
        showPay.page = "gohome_list"
        showPay.ShowDialog()

    End Sub
    Private Sub Btn_Enter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Enter.Click
        If IsNumeric(TextBox_InputC.Text) = True Then
            If CDbl(TextBox_InputC.Text) > CDbl(txt_sum_total.Text) Or CDbl(TextBox_InputC.Text) = CDbl(txt_sum_total.Text) Or (payment_cl = True) Then
                Dim ton1 As Double = CDbl(TextBox_InputC.Text) - CDbl(txt_sum_total.Text)
                showpay_alert.txt_total.Text = FormatNumber(CDbl(txt_sum_total.Text), 2)
                showpay_alert.txt_recript.Text = FormatNumber(CDbl(TextBox_InputC.Text), 2)
                showpay_alert.txt_ton.Text = FormatNumber(ton1, 2)
                showpay_alert.page = "payment_gohome"
                showpay_alert.ShowDialog()
                If page_confirm_pay = True Then
                    EnterPay()
                Else
                    Btn_Enter.Enabled = True
                End If

            Else
                MessageBox.Show("กรุณารับเงินให้ครบจำนวนค่ะ..!", "Message Alert Payment")
            End If
        Else
            MessageBox.Show("กรุณารับเงินให้ครบจำนวนค่ะ..!", "Message Alert Payment")
        End If
    End Sub
    Public Function GetPrsInOrderList(ByVal id_bill)
        Dim p As String = ""
        Dim prs As MySqlDataReader = con.mysql_query("SELECT IFNULL(prs,'0') as prs FROM pos_order_list " _
        & "WHERE status_pay='no' and (create_date LIKE '%" & Login.DateData.ToString("yyyy-MM-dd") & "%') " _
        & "and rf_id_table='" & Login.OpenId & "' and rf_id_invoice='" & id_bill & "' and " _
        & "status_open='gohome' order by id_ord desc limit 1;")
        While prs.Read
            p = prs.GetString("prs")
        End While
        Return p
    End Function
    Public Function GetIdInv_Pos_Invoice(ByVal namber_inv)
        Dim id_inv As String = ""
        Dim id As MySqlDataReader = con.mysql_query("SELECT IFNULL(id,'0') as id FROM pos_invoice WHERE namber_inv='" & namber_inv & "';")
        While id.Read
            id_inv = id.GetString("id")
        End While
        Return id_inv
    End Function
    Public Function GetIdInv_Pos_Invoice_Temp(ByVal namber_inv)
        Dim id_inv As String = ""
        Dim id As MySqlDataReader = con.mysql_query("SELECT IFNULL(id,'0') as id FROM pos_invoice_temp WHERE namber_inv='" & namber_inv & "';")
        While id.Read
            id_inv = id.GetString("id")
        End While
        Return id_inv
    End Function
    Public Function Update_Orderlist_Discount(ByVal id_tb, ByVal idbill)
        'Update Data  order list discount
        Dim query_prs As MySqlDataReader = con.mysql_query("SELECT IFNULL(tryNumber,'0') as tryNumber FROM pos_order_list WHERE status_pay='no' and (create_date LIKE '%" & Login.DateData.ToString("yyyy-MM-dd") & "%') and rf_id_table='" & Login.OpenId & "' and status_open='gohome' order by id_ord desc limit 1")
        Dim prs As String = GetPrsInOrderList(idbill)
        Dim tryNumber As String = ""
        While query_prs.Read()
            tryNumber = query_prs.GetString("tryNumber")
        End While
        query_prs.Close()
        Dim str_up As String = ""
        For y As Integer = 0 To ListView1.Items.Count - 1
            Dim order_dis_val As Double = CDbl(ListView1.Items(y).SubItems(12).Text)
            Dim order_dis_sum As Double = CDbl(ListView1.Items(y).SubItems(13).Text)
            Dim order_dis_type As String = ListView1.Items(y).SubItems(14).Text
            Dim rf_id_prd As String = ListView1.Items(y).SubItems(2).Text
            Dim rf_id_con As String = ListView1.Items(y).SubItems(3).Text
            Dim name_ord As String = ListView1.Items(y).SubItems(4).Text.Replace("'", "\'")
            Dim name_ord_en As String = ListView1.Items(y).SubItems(5).Text.Replace("'", "\'")
            If ListView1.Items(y).SubItems(0).Text.ToLower <> "void" And ListView1.Items(y).SubItems(0).Text.ToLower <> "voidp" Then
                str_up &= "UPDATE pos_order_list SET prs='" & prs & "',order_dis_val='" & order_dis_val & "'," _
                & "order_dis_sum='" & order_dis_sum & "',order_dis_type='" & order_dis_type & "',rf_id_invoice='" & idbill & "',tryNumber='" & tryNumber & "' " _
                & " where rf_id_prd='" & rf_id_prd & "' and rf_id_con='" & rf_id_con & "' and name_ord='" & name_ord & "' and " _
                & "rf_id_table='" & Login.OpenId & "' and status_pay='no'  and status_open='gohome';"
            End If
        Next
        Dim c As Boolean = False
        If str_up <> "" Then
            c = con.mysql_query(str_up)
        End If
        Return c
    End Function
    
    Public Function Update_Orderlist_Discount_GH(ByVal id_Gh)
        'Clear DB and Insert Data new order list
        Dim num_check As Integer = con.mysql_num_rows(con.mysql_query("SELECT * FROM pos_order_list WHERE status_pay='no' and (create_date LIKE '%" & Login.DateData.ToString("yyyy-MM-dd") & "%') and status_open='gohome' and code_gohome='" & id_Gh & "' order by id_ord desc;"))
        Dim prs As String = "0"
        Dim tryNumber As String = "0"
        Dim cle As String = ""
        If num_check > 0 Then
            Dim rb As MySqlDataReader = con.mysql_query("SELECT IFNULL(tryNumber,'0') as tryNumber FROM pos_order_list where code_gohome='" & id_Gh & "';")
            rb.Read()
            tryNumber = rb.GetString("tryNumber")
            rb.Close()
            cle &= "DELETE FROM pos_order_list WHERE status_pay='no' and status_open='gohome' and code_gohome='" & id_Gh & "';"
        Else
            tryNumber = "0"
        End If
        ' MsgBox("num_check=" & num_check & "&tryNumber=" & tryNumber)
        For d As Integer = 0 To ListView1.Items.Count - 1
            Dim status_sd_captain As String = ListView1.Items(d).SubItems(0).Text
            Dim rf_id_prd As Integer = ListView1.Items(d).SubItems(2).Text
            Dim rf_id_con As String = ListView1.Items(d).SubItems(3).Text
            Dim name_ord As String = ListView1.Items(d).SubItems(4).Text.Replace("'", "\'")
            Dim name_ord_en As String = ListView1.Items(d).SubItems(5).Text.Replace("'", "\'")
            Dim amt As Integer = ListView1.Items(d).SubItems(8).Text
            Dim price As Double = CDbl(ListView1.Items(d).SubItems(11).Text)
            Dim remark As String = ListView1.Items(d).SubItems(16).Text.Replace("'", "\'")
            Dim order_dis_val As Double = ListView1.Items(d).SubItems(12).Text
            Dim order_dis_sum As Double = ListView1.Items(d).SubItems(13).Text
            Dim order_dis_type As String = ListView1.Items(d).SubItems(14).Text
            Dim ref_cat_id As String = ListView1.Items(d).SubItems(17).Text
            Dim ref_catsubprd As String = ListView1.Items(d).SubItems(18).Text
            Dim name_en_cat As String = ListView1.Items(d).SubItems(19).Text
            Dim name_th_cat As String = ListView1.Items(d).SubItems(20).Text
            Dim name_en_catsubprd As String = ListView1.Items(d).SubItems(21).Text
            Dim name_th_catsubprd As String = ListView1.Items(d).SubItems(22).Text
            Dim ord_vat As String = ListView1.Items(d).SubItems(23).Text
            Dim ord_vat_st As String = ListView1.Items(d).SubItems(24).Text
            cle &= "INSERT INTO pos_order_list (rf_id_prd,rf_id_con,name_ord,name_ord_en,amt,price,prs," _
            & "rf_id_table,status_sd_captain,status_open,remark,create_date,create_by,code_gohome,order_dis_val,order_dis_sum,order_dis_type,tryNumber,ref_cat_id,ref_catsubprd,name_en_cat,name_th_cat,name_en_catsubprd,name_th_catsubprd,ord_vat,ord_vat_st) " _
            & " VALUES('" & rf_id_prd & "','" & rf_id_con & "','" & name_ord & "','" & name_ord_en & "','" & amt & "','" & price & "'," _
            & "'" & prs & "','0','" & status_sd_captain & "','gohome','" & remark & "','" & Login.DateData.ToString("yyyy-MM-dd") & Now.ToString(" HH:mm:ss") & "','" & Login.username & "'," _
            & "'" & id_Gh & "','" & order_dis_val & "','" & order_dis_sum & "','" & order_dis_type & "','" & tryNumber & "','" & ref_cat_id & "'," _
            & "'" & ref_catsubprd & "','" & name_en_cat & "','" & name_th_cat & "','" & name_en_catsubprd & "','" & name_th_catsubprd & "','" & ord_vat & "','" & ord_vat_st & "');"

        Next
        Dim c As Boolean = False
        If cle <> "" Then
            c = con.mysql_query(cle)
        End If
        Return c
    End Function
    Public Function InsertDataInvTo_CloseBillDetail(ByVal id_inv, ByVal rf_id_table, ByVal code_gohome)
        Dim Query As Boolean = False
        Dim tryNumber As String = "0"
        Dim prs As String = "0"
        Dim num_trybill As Integer = con.mysql_num_rows(con.mysql_query("SELECT IFNULL(tryNumber,'0') AS tryNumber,IFNULL(prs,'0') AS prs FROM pos_order_list WHERE rf_id_invoice='" & id_inv & "' Limit 1"))
        If num_trybill > 0 Then
            Dim qty_trybill As MySqlDataReader = con.mysql_query("SELECT IFNULL(tryNumber,'0') AS tryNumber,IFNULL(prs,'0') AS prs FROM pos_order_list WHERE rf_id_invoice='" & id_inv & "' Limit 1")
            qty_trybill.Read()
            tryNumber = qty_trybill.GetString("tryNumber")
            prs = qty_trybill.GetString("prs")
        End If
        Dim year As Integer = 0
        If CInt(Login.DateData.ToString("yyyy")) > 2450 Then
            year = CInt(Login.DateData.ToString("yyyy")) - 543
        Else
            year = CInt(Login.DateData.ToString("yyyy"))
        End If
        Dim date_inv As DateTime = year & "-" & Login.DateData.ToString("MM") & "-" & Login.DateData.ToString("dd") & " " & Date.Now().ToString("HH:mm:ss")
        Dim string1 As String = ""
        Dim cstatus_open As String = ""

        If ListView1.Items.Count > 0 Then
            cstatus_open = "gohome"
            rf_id_table = 0
        
        For i As Integer = 0 To ListView1.Items.Count - 1
                Dim crf_id_prd As String = ListView1.Items.Item(i).SubItems(2).Text
                Dim crf_id_con As String = ListView1.Items.Item(i).SubItems(3).Text
                Dim cname_ord As String = ListView1.Items.Item(i).SubItems(4).Text.Replace("'", "\'")
                Dim cname_ord_en As String = ListView1.Items.Item(i).SubItems(5).Text.Replace("'", "\'")
                Dim camt As String = ListView1.Items.Item(i).SubItems(8).Text
                Dim cprice As String = ListView1.Items.Item(i).SubItems(9).Text
                Dim c_vat As String = ListView1.Items.Item(i).SubItems(23).Text 'home1.vat_prd(ListView1.Items.Item(i).SubItems(2).Text)
                Dim c_vat_st As String = ListView1.Items.Item(i).SubItems(24).Text 'home1.vat_in_ex(ListView1.Items.Item(i).SubItems(2).Text)
                Dim c_vat_sum As Double = CDbl(ListView1.Items.Item(i).SubItems(10).Text)
                Dim c_amount As String = CDbl(ListView1.Items.Item(i).SubItems(9).Text)
                Dim c_net_amount As Double = CDbl(ListView1.Items.Item(i).SubItems(11).Text)
                Dim cstatus As String = ListView1.Items.Item(i).SubItems(0).Text
                Dim c_discount As String = ListView1.Items.Item(i).SubItems(12).Text
                Dim c_discount_sum As Double = ListView1.Items.Item(i).SubItems(13).Text
                Dim c_discount_type As String = ListView1.Items.Item(i).SubItems(14).Text
                Dim ref_id_cat As String = ListView1.Items.Item(i).SubItems(17).Text
                Dim ref_id_subcat As String = ListView1.Items.Item(i).SubItems(18).Text
                Dim name_cat_en As String = ListView1.Items.Item(i).SubItems(19).Text
                Dim name_cat_th As String = ListView1.Items.Item(i).SubItems(20).Text
                Dim name_subcat_en As String = ListView1.Items.Item(i).SubItems(21).Text
                Dim name_subcat_th As String = ListView1.Items.Item(i).SubItems(22).Text
                Dim c_remark As String = ListView1.Items.Item(i).SubItems(16).Text
                string1 &= "INSERT INTO pos_closebilldetail (cref_id_ord,crf_id_prd,crf_id_con,cname_ord,cname_ord_en,camt" _
                    & ",cprice,cprs,crf_id_table,crf_id_invoice,c_vat,c_vat_st,c_vat_sum,c_discount,c_discount_sum,c_discount_type,c_amount,c_net_amount," _
                    & "	cstatus_open,cremark,cstatus,ccreate_date,ccode_gohome,ctryNumber,ccreate_by,rf_id_closebill,name_closebill," _
                    & "c_id_cat,c_id_subcat,c_name_cat_en,c_name_cat_th,c_name_subcat_en,c_name_subcat_th) " _
                    & " VALUES('0','" & crf_id_prd & "','" & crf_id_con & "','" & cname_ord & "','" & cname_ord_en & "','" & camt & "'," _
                    & "'" & cprice & "','" & prs & "','0','" & id_inv & "','" & c_vat & "'," _
                    & "'" & c_vat_st & "','" & c_vat_sum & "','" & c_discount & "','" & c_discount_sum & "','" & c_discount_type & "','" & c_amount & "','" & c_net_amount & "','" & cstatus_open & "'," _
                    & "'" & c_remark & "','" & cstatus & "','" & date_inv.ToString("yyyy-MM-dd HH:mm:ss") & "','" & code_gohome & "','" & tryNumber & "','" & Login.username & "','" & Login.Id_RopBill & "','" & Login.Str_Ropbill & "'" _
                    & ",'" & ref_id_cat & "','" & ref_id_subcat & "','" & name_cat_en & "','" & name_cat_th & "','" & name_subcat_en & "','" & name_subcat_th & "');"
        Next
            Dim v As Boolean = False

            If string1 <> "" Then
                ' MsgBox(string1)
                v = con.mysql_query(string1)
            End If
        If v = True Then
            Query = True
        End If
        End If
        Return Query
    End Function

    Private Sub TextBox_Card1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        keyborad_str.text1 = "TextBox_Card1"
        keyborad_str.ShowDialog()
    End Sub

    Private Sub TextBox_Exp_M_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        keyborad_str.text1 = "TextBox_Exp_M"
        keyborad_str.ShowDialog()
    End Sub

    Private Sub TextBox_Exp_Y_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        keyborad_str.text1 = "TextBox_Exp_Y"
        keyborad_str.ShowDialog()
    End Sub

    Private Sub TextBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        keyborad_number.text1 = "TextBox1_discount"
        keyborad_number.ShowDialog()
    End Sub

    Private Sub TextBox_NumberRoom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' keyborad_str.text1 = "TextBox_NumberRoom"
        'keyborad_str.ShowDialog()
        inroom.ShowDialog()
    End Sub

    Private Sub btn_payother_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        payment_type.ShowDialog()
    End Sub
    Private Sub TextBox_Coupon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Login.p = Process.GetProcessesByName("osk")
        'If Login.p.Count > 0 Then
        '    ' Process is running
        '    Array.ForEach(Login.p, Sub(p1 As Process) p1.Kill())
        '    System.Diagnostics.Process.Start("osk.exe")
        'Else
        '    ' Process is not running
        '    System.Diagnostics.Process.Start("osk.exe")
        'End If
    End Sub
    Private Sub TextBox_Coupon_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Login.KillP()
    End Sub

    Dim sumdis As Double = 0.0
    Private Sub text_discount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        keyborad_number.text1 = "discount"
        keyborad_number.ShowDialog()
    End Sub
    Private Sub minus_dis_all_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txt_sum_discount.Text = "0.0"
        txt_dis_all.Text = "0.0"
        cal_list_price()
    End Sub
    Private Sub add_dis_all_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        cal_list_price()
    End Sub

    Private Sub txt_dis_all_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        keyborad_number.text1 = "discount_all"
        keyborad_number.ShowDialog()
    End Sub

    '============= parameter for print try bill use in buttom trybill =========='
    Friend id_bill_printtry As String = "0"
    Friend type_bill_printtry As String = "novat"
    Friend printer_name_trybill As String = ""
    Friend user_login_print As String = ""
    Public switch_lang As String = Login.LangG
    Private Sub print_rongbill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles print_rongbill.Click
        If code_gohome = "0" Or code_gohome = "" Then
            Dim pair As KeyValuePair(Of String, String) = CreateOrderBill()
            selBill = pair.Key
        End If

        Dim id_bill As String = selBill
        Dim CodeTrybill As String = ""
        Dim chk_trybill As Integer = con.mysql_num_rows(con.mysql_query("select tryNumber from pos_order_list where tryNumber<>'0' and rf_id_invoice='" & selBill & "';"))
        If chk_trybill > 0 Then
            Dim q_trybill As MySqlDataReader = con.mysql_query("select tryNumber from pos_order_list where tryNumber<>'0' and rf_id_invoice='" & selBill & "';")
            q_trybill.Read()
            CodeTrybill = q_trybill.GetString("tryNumber")
        Else
            CodeTrybill = ac.RuningRb()
        End If

        '=== query namber_inv on tb ==='
        Dim f As MySqlDataReader = con.mysql_query("select pos_invoice_temp.namber_inv as namber_inv from pos_invoice_temp where id='" & selBill & "';")
        Dim num_i As String = ""
        While f.Read()
            num_i = f.GetString("namber_inv")
        End While
        f.Close()
        Dim str_up_join As String = ""
        Dim disC_prd_sum As Double = 0.0
        For y As Integer = 0 To ListView1.Items.Count - 1
            Dim order_dis_val As String = CDbl(ListView1.Items(y).SubItems(12).Text)
            Dim order_dis_sum As Double = CDbl(ListView1.Items(y).SubItems(13).Text)
            Dim order_dis_type As String = ListView1.Items(y).SubItems(14).Text
            Dim rf_id_prd As String = ListView1.Items(y).SubItems(2).Text
            Dim rf_id_con As String = ListView1.Items(y).SubItems(3).Text
            Dim name_ord As String = ListView1.Items(y).SubItems(4).Text.Replace("'", "\'")
            Dim name_ord_en As String = ListView1.Items(y).SubItems(5).Text.Replace("'", "\'")
            Dim rf_id_table As Integer = ListView1.Items(y).SubItems(25).Text
            Dim ref_id_join As Integer = ListView1.Items(y).SubItems(26).Text
            If ListView1.Items(y).SubItems(0).Text.ToLower <> "void" And ListView1.Items(y).SubItems(0).Text.ToLower <> "voidp" Then
                disC_prd_sum += CDbl(ListView1.Items(y).SubItems(13).Text)
                str_up_join &= "UPDATE pos_order_list SET tryNumber='" & CodeTrybill & "',rf_id_invoice='" & id_bill & "',order_dis_val='" & order_dis_val & "'," _
                & "order_dis_sum='" & order_dis_sum & "',order_dis_type='" & order_dis_type & "' where rf_id_prd='" & rf_id_prd & "' and rf_id_con='" & rf_id_con & "' and name_ord='" & name_ord & "' " _
                & "and rf_id_invoice='" & id_bill & "' and status_pay='no' and status_open='gohome' and DAY(create_date)='" & Login.DateData.ToString("dd") & "' and MONTH(create_date)='" & Login.DateData.ToString("MM") & "' and YEAR(create_date)='" & Login.DateData.ToString("yyyy") & "' ;"
            End If
        Next
        con.mysql_query(str_up_join)

        '=====Update invoice for print rong bill==='
        Dim discount_des As String = ""
        Dim discount_sum As Double = 0.0

        If Label_ShowAllDisType.Tag.ToString = "%" Then
            discount_des = Label_ShowAllDisType.Tag.ToString
            ' discount_sum = FormatNumber(((CDbl(txt_priceall.Text) + CDbl(txt_sum_vat.Text) - discount_prd) * CDbl(txt_dis_all.Text)) / 100, 2)
            discount_sum = FormatNumber(CDbl(txt_sum_discount.Text) - CDbl(disC_prd_sum), 2)
        Else
            discount_des = Label_ShowAllDisType.Tag.ToString
            'discount_sum = FormatNumber(CDbl(txt_dis_all.Text), 2)
            discount_sum = FormatNumber(CDbl(txt_sum_discount.Text) - CDbl(disC_prd_sum), 2)
        End If

        '====== update bil invoice ====='
        Dim str_y As String = ""
        str_y &= "UPDATE pos_invoice_temp SET qty='" & qty_prd & "',price_all='" & CDbl(txt_sum_total.Text) & "',create_by='" & Login.username & "'," _
          & "create_date='" & Login.DateData.ToString("yyyy-MM-dd ") & Date.Now().ToString("HH:mm:ss") & "',rf_payment_type='" & rf_payment_type & "',des_payment='" & des_payment & "'," _
          & "machin_number='" & System.Net.Dns.GetHostName() & "',price_exclu_vat='" & CDbl(txt_priceall.Text) & "',vat='" & CDbl(txt_sum_vat.Text) & "',serviceCh='" & CDbl(txt_sum_service_chg.Text) & "'," _
          & "discount='" & txt_dis_all.Text & "',discount_des='" & discount_des & "',discount_sum='" & discount_sum & "'," _
          & "ref_id_payment_acc='0',machine_inv='" & Login.getMacAddress & "',rf_id_card='0'," _
          & "money_recript='0',money_ton='0'," _
          & "close_rop_id_inv='" & Login.Id_RopBill & "',close_rop_name_inv='" & Login.Str_Ropbill & "'" _
          & " WHERE id='" & selBill & "';"
        number_invoice_new = num_i
        Dim qtyTryNum As Boolean = con.mysql_query(str_y)
        If qtyTryNum = True Then
            'Print TryBill
            Payment_DialogPrintVat.ShowDialog()
            If print_vat = True Then
                If Login.dialog_switchLangPrintTryBill = 1 Then
                    switch_langprint.page = "payment_gohome"
                    switch_langprint.ShowDialog()
                End If
                id_bill_printtry = id_bill
                type_bill_printtry = "vat"
                printer_name_trybill = Login.printer_trybill
                user_login_print = Login.username
                switch_lang = switch_lang
                BackgroundWorker1.RunWorkerAsync()

            Else
                If Login.dialog_switchLangPrintTryBill = 1 Then
                    switch_langprint.page = "payment_gohome"
                    switch_langprint.ShowDialog()
                End If
                id_bill_printtry = id_bill
                type_bill_printtry = "novat"
                printer_name_trybill = Login.printer_trybill
                user_login_print = Login.username
                switch_lang = switch_lang
                BackgroundWorker1.RunWorkerAsync()

            End If
            If Login.alert_sendcaptain = 1 Then
                MessageBox.Show("Print Information Bill Complete.!", "Message Alert", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Function CreateOrderBill() As KeyValuePair(Of String, String)
        Dim prs As String = "1"
        Dim str As String = ""
        Dim CodeGoHome As String = opentakehome.Create_Code_Gohome()
        Dim id_inv_temp As String = ""
        '==== insert bill invoice ===='
        Dim qty_all As Integer = 0
        Dim price_all As Double = 0.0
        For x As Integer = 0 To ListView1.Items.Count - 1
            If ListView1.Items(x).SubItems(1).Text.ToLower = "no" Then
                qty_all += ListView1.Items(x).SubItems(8).Text
                price_all += CDbl(ListView1.Items(x).SubItems(15).Text)
            End If
        Next
        Dim id_insert As String = ac.RuningInvTEMP()
        con.mysql_query("INSERT INTO pos_invoice_temp (namber_inv,number_pos,qty,price_all," _
                & "create_by,create_date,rf_payment_type,des_payment,machin_number,price_exclu_vat," _
                & "vat,serviceCh,discount,discount_des,discount_sum,ref_id_payment_acc,machine_inv," _
                & "rf_id_card,money_recript,money_ton,close_rop_id_inv,close_rop_name_inv) values(" _
                & "'" & id_insert & "','" & ac.RuningPOSTEMP() & "','" & qty_all & "','" & price_all & "'," _
                & "'" & Login.username & "','" & Login.DateData.ToString("yyyy-MM-dd") & Date.Now().ToString(" HH:mm:ss") & "','0','-','" & System.Net.Dns.GetHostName() & "','0'," _
                & "'0','0','0','บาท','0','0','" & Login.getMacAddress & "'," _
                & "'0','0','0','" & Login.Id_RopBill & "','" & Login.Str_Ropbill & "');")
        id_inv_temp = payment.GetIdInv_Pos_Invoice_Temp(id_insert)

        'Loop get value for insert database
        For x As Integer = 0 To ListView1.Items.Count - 1
            If ListView1.Items(x).SubItems(0).Text.ToLower <> "void" Or ListView1.Items(x).SubItems(0).Text.ToLower <> "voidp" Then
                Dim status_sd_captain As String = ListView1.Items(x).SubItems(0).Text.ToLower
                Dim rf_id_prd As String = ListView1.Items(x).SubItems(2).Text
                Dim rf_id_con As String = ListView1.Items(x).SubItems(3).Text
                Dim name_ord As String = ListView1.Items(x).SubItems(4).Text.Replace("'", "\'")
                Dim name_ord_en As String = ListView1.Items(x).SubItems(5).Text.Replace("'", "\'")
                Dim amt As Integer = ListView1.Items(x).SubItems(8).Text
                Dim price1 As Double = CDbl(ListView1.Items(x).SubItems(11).Text)
                Dim remark As String = ListView1.Items(x).SubItems(16).Text.Replace("'", "\'")
                Dim id_cat As String = ListView1.Items(x).SubItems(17).Text.Trim
                Dim id_subcatprd As String = ListView1.Items(x).SubItems(18).Text.Trim
                Dim name_cat_en As String = ListView1.Items(x).SubItems(19).Text.Trim
                Dim name_cat_th As String = ListView1.Items(x).SubItems(20).Text.Trim
                Dim name_subcat_en As String = ListView1.Items(x).SubItems(21).Text.Trim
                Dim name_subcat_th As String = ListView1.Items(x).SubItems(22).Text.Trim
                Dim ord_vat As Integer = ListView1.Items(x).SubItems(23).Text.Trim
                Dim ord_vat_st As String = ListView1.Items(x).SubItems(24).Text.Trim
                Dim order_dis_val As Double = ListView1.Items(x).SubItems(12).Text.Trim
                Dim order_dis_sum As Double = ListView1.Items(x).SubItems(13).Text.Trim
                Dim order_dis_type As String = ListView1.Items(x).SubItems(14).Text.Trim
                str &= "INSERT INTO pos_order_list (rf_id_prd,rf_id_con,name_ord,name_ord_en,amt,price,prs," _
                 & "rf_id_table,rf_id_invoice,status_sd_captain,status_open,remark,create_date,create_by,code_gohome,ref_cat_id," _
                 & "ref_catsubprd,name_th_cat,name_en_cat,name_th_catsubprd,name_en_catsubprd,ord_vat,ord_vat_st,order_dis_val,order_dis_sum,order_dis_type) " _
                 & " VALUES('" & rf_id_prd & "','" & rf_id_con & "','" & name_ord & "','" & name_ord_en & "','" & amt & "','" & price1 & "'," _
                 & "'" & prs & "','0','" & id_inv_temp & "','" & status_sd_captain & "','gohome','" & remark & "','" & Login.DateData.ToString("yyyy-MM-dd") & Date.Now.ToString(" HH:mm:ss") & "','" & Login.username & "'," _
                 & "'" & CodeGoHome & "','" & id_cat & "','" & id_subcatprd & "','" & name_cat_th & "'," _
                 & "'" & name_cat_en & "','" & name_subcat_th & "','" & name_subcat_en & "','" & ord_vat & "','" & ord_vat_st & "','" & order_dis_val & "','" & order_dis_sum & "','" & order_dis_type & "');"
                opentakehome.cutStock(rf_id_prd, rf_id_con, amt) 'ตัดสินค้าออกจากสต๊อก ในกรณีที่ขาายของminimart 
            End If
        Next
        Dim q_order As Boolean = False
        If str <> "" Then
            q_order = con.mysql_query(str)
        End If
        Return New KeyValuePair(Of String, String)(id_inv_temp, CodeGoHome)
    End Function

    Private Sub ListView1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.Click
        If ListView1.Items.Count > 0 Then
            If ListView1.SelectedItems.Count > 0 Then
                If ListView1.Items(ListView1.SelectedIndices(0)).SubItems(0).Text.ToLower <> "void" Or ListView1.Items(ListView1.SelectedIndices(0)).SubItems(0).Text.ToLower <> "voidp" Then
                    btn_disprd.Enabled = True
                Else
                    btn_disprd.Enabled = False
                End If
            Else
                btn_disprd.Enabled = False
            End If
        End If
    End Sub
    Private Sub radio_dis_all1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        cal_list_price()
    End Sub

    Private Sub radio_dis_all2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        cal_list_price()
    End Sub

    Private Sub ListView1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick
       
        If ListView1.Items.Item(ListView1.SelectedIndices(0)).SubItems(0).Text = "void" Then
            ListView1.Items.Item(ListView1.SelectedIndices(0)).Selected = False
        Else
            payment_discount_gohome.typedis = "bill"
            payment_discount_gohome.ShowDialog()
        End If
    End Sub

    Private Sub btn_disprd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_disprd.Click
        If ListView1.Items.Item(ListView1.SelectedIndices(0)).SubItems(0).Text = "void" Then
            ListView1.Items.Item(ListView1.SelectedIndices(0)).Selected = False
        Else
            payment_discount_gohome.typedis = "bill"
            payment_discount_gohome.ShowDialog()
        End If
    End Sub

    Private Sub btn_disallbill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_disallbill.Click
        payment_discount_gohome.typedis = "all"
        payment_discount_gohome.ShowDialog()
    End Sub

    Private Sub btn_subpbill_new_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_subpbill_new.Click
        Dim j As Integer = FlowLayoutPanel_Bill.Controls.Count
        If j + 1 <= 6 Then
            Dim btn As New Button
            btn.Name = "no" & j + 1
            btn.Width = "102"
            btn.Height = "33"
            btn.Tag = j - 6 & "_new"
            btn.Text = "No." & j + 1
            btn.Cursor = Cursors.Hand
            btn.BackColor = Color.Gainsboro
            btn.FlatStyle = FlatStyle.Flat
            btn.FlatAppearance.BorderColor = Color.Silver
            btn.FlatAppearance.BorderSize = "1"
            btn.Margin = New Padding(0, 0, 0, 0)
            btn.Font = New Drawing.Font("Microsoft Sans Serif", 12, FontStyle.Bold)
            AddHandler btn.Click, AddressOf ShowBill
            FlowLayoutPanel_Bill.Controls.Add(btn)
        End If

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
        s2(selBill) 'load data show
        payment_gohome_subp_dialog.sel_bill = btn.Tag.ToString
        If btn.Text = "No.1" Then
            btn_subpbill_del.Enabled = False
        Else
            btn_subpbill_del.Enabled = True
        End If
    End Sub
    Public Sub s1()
        FlowLayoutPanel_Bill.Controls.Clear()
        Dim x As MySqlDataReader = con.mysql_query("SELECT * FROM pos_order_list WHERE status_pay='no' and status_open='gohome' and code_gohome='" & code_gohome & "' GROUP BY rf_id_invoice ASC")
        Dim j As Integer = 1
        While x.Read()
            Dim btn As New Button
            btn.Name = "no" & j
            btn.Width = "102"
            btn.Height = "33"
            btn.Tag = x.GetString("rf_id_invoice") & "_old"
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
                s2(x.GetString("rf_id_invoice")) '==load data show =='
                btn.PerformClick() '== สั่งให้click อัตโนมัติ==='
                btn_subpbill_del.Enabled = False
            Else
                btn_subpbill_del.Enabled = True
            End If
            j += 1
        End While
    End Sub
    Private Sub s2(ByVal id_inv)
        ListView1.Items.Clear()
        Dim y As Integer = con.mysql_num_rows(con.mysql_query("select * from pos_invoice_temp where id='" & id_inv & "' "))
        If y > 0 Then
           
            Dim res_tb As MySqlDataReader = con.mysql_query("select * from view_order_list_gh where create_date_orderlist LIKE '%" & Login.DateData.ToString("yyyy-MM-dd") & "%' and rf_id_invoice_order_list='" & id_inv & "' ORDER BY status_sd_captain DESC;")
            Dim price_new1 As Double = 0.0
            Dim itmx1 As New ListViewItem
            Dim v As Integer = 1
            Dim vats As Double = 0
            Dim price_new As Double = 0
            Dim h_inv As Integer = 0
            While res_tb.Read
                h_inv = res_tb.GetString("rf_id_invoice")
                itmx1 = ListView1.Items.Add(res_tb.GetString("status_sd_captain"), v)
                itmx1.SubItems.Add(res_tb.GetString("id_ord"))
                itmx1.SubItems.Add(res_tb.GetString("rf_id_prd"))
                itmx1.SubItems.Add(res_tb.GetString("rf_id_con"))
                itmx1.SubItems.Add(res_tb.GetString("name_ord"))
                itmx1.SubItems.Add(res_tb.GetString("name_ord_en"))
                itmx1.SubItems.Add(res_tb.GetString("name_size"))
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
                itmx1.SubItems.Add(str_vat & " " & home1.vat_prd(res_tb.GetString("rf_id_prd")) & "%")
                itmx1.SubItems.Add(res_tb.GetInt32("samt"))
                itmx1.SubItems.Add(price_new1)
                itmx1.SubItems.Add(FormatNumber(vats * CInt(res_tb.GetInt32("samt")), 2))
                itmx1.SubItems.Add(FormatNumber(CDbl(price_new1 + (vats * CInt(res_tb.GetInt32("samt")))), 2))
                If res_tb.GetString("order_dis_val") <> "0" Then
                    itmx1.SubItems.Add(res_tb.GetString("order_dis_val"))
                    itmx1.SubItems.Add(res_tb.GetString("order_dis_sum"))
                    itmx1.SubItems.Add(res_tb.GetString("order_dis_type"))
                Else
                    itmx1.SubItems.Add("0")
                    itmx1.SubItems.Add("0")
                    itmx1.SubItems.Add("0")
                End If
                itmx1.SubItems.Add(FormatNumber((CDbl(price_new1 + (vats * CInt(res_tb.GetInt32("samt"))))) - CDbl(res_tb.GetString("order_dis_sum")), 2))
                itmx1.SubItems.Add(res_tb.GetString("remark"))
                itmx1.SubItems.Add(res_tb.GetString("ref_cat_id"))
                itmx1.SubItems.Add(res_tb.GetString("ref_catsubprd"))
                itmx1.SubItems.Add(res_tb.GetString("name_en_cat"))
                itmx1.SubItems.Add(res_tb.GetString("name_th_cat"))
                itmx1.SubItems.Add(res_tb.GetString("name_en_catsubprd"))
                itmx1.SubItems.Add(res_tb.GetString("name_th_catsubprd"))
                itmx1.SubItems.Add(res_tb.GetString("ord_vat"))
                itmx1.SubItems.Add(res_tb.GetString("ord_vat_st"))
                itmx1.SubItems.Add(res_tb.GetString("rf_id_table"))
                itmx1.SubItems.Add(res_tb.GetString("ref_id_join"))
                itmx1.SubItems.Add(code_gohome)
                v += 1
            End While
            '==== GET DISCOUNT ALL BILL ===='
            Dim disc As Double = 0.0
            Dim discT As String = ""
            Dim discS As Double = 0.0
            If h_inv > 0 Then
                Dim hhave_inv As MySqlDataReader = con.mysql_query("select * from pos_invoice_temp where id='" & h_inv & "' ")
                While hhave_inv.Read
                    If CDbl(hhave_inv.GetString("discount_sum")) > 0 Then
                        disc = hhave_inv.GetString("discount")
                        discT = hhave_inv.GetString("discount_des")
                        discS = hhave_inv.GetString("discount_sum")
                    End If
                End While
                hhave_inv.Close()
                If discT = "%" Then
                    Label_ShowAllDisType.Text = "(" & discT & ")"
                    Label_ShowAllDisType.Tag = discT
                    txt_dis_all.Text = disc
                Else
                    Label_ShowAllDisType.Text = "(" & discT & ")"
                    Label_ShowAllDisType.Tag = discT
                    txt_dis_all.Text = discS
                End If
            Else
                Label_ShowAllDisType.Text = "(" & discT & ")"
                Label_ShowAllDisType.Tag = discT
            End If
            page = "home1"
            cal_list_price()
        Else
            txt_priceall.Text = "0.0"
            txt_sum_vat.Text = "0.0"
            txt_dis_all.Text = "0.0"
            Label_ShowAllDisType.Tag = "บาท"
            Label_ShowAllDisType.Text = "()"
            txt_sum_discount.Text = "-0.0"
            txt_sum_service_chg.Text = "0"
            txt_sum_total.Text = "0.00"
        End If
        For n As Integer = 0 To ListView1.Items.Count - 1
            If ListView1.Items.Item(n).SubItems(0).Text = "void" Then
                ListView1.Items.Item(n).Selected = False
                ListView1.Items.Item(n).Checked = False
                ListView1.Items.Item(n).ForeColor = Color.Red
            Else
                ListView1.Items.Item(n).Selected = True
            End If
        Next

    End Sub
    Private Sub btn_subpbill_del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_subpbill_del.Click
        If ListView1.Items.Count > 0 Then
            Dim result As Integer
            If Login.LangG = "TH" Then
                result = MessageBox.Show("คุณมั่นใจใช่ไหมที่จะลบบิลนี้ รายการทั้งหมดจะถูกย้ายไปที่บิลที่ 1 ?", "ยืนยันการลบบิล", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            Else
                result = MessageBox.Show("Are You Sure Cancel  Bill?", "Confirm Cancel Bill", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            End If
            If result = DialogResult.Yes Then
                Dim StringQuery As String = ""
                Dim prs As String = "1"
                Dim strArr_sel_bill() As String = FlowLayoutPanel_Bill.Controls.Item(0).Tag.Split("_")
                Dim id As String = strArr_sel_bill(0)
                'MsgBox("บิลที่เลือก=" & selBill & ":::บิลที่ 1=" & id)
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
                   
                    Dim check_is_prd As Integer = con.mysql_num_rows(con.mysql_query("select * from pos_order_list " _
                        & "where rf_id_prd='" & rf_id_prd & "' and rf_id_con='" & rf_id_con & "' and name_ord='" & name_ord & "' and " _
                        & "code_gohome='" & code_gohome & "' and status_open='gohome' and rf_id_invoice='" & id & "' and status_pay='no';"))
                    If check_is_prd > 0 Then
                        StringQuery &= "UPDATE pos_order_list SET amt=amt+" & qty & ",price=price+'" & price & "' " _
                        & "where rf_id_prd='" & rf_id_prd & "' and rf_id_con='" & rf_id_con & "' and name_ord='" & name_ord & "' and " _
                        & "code_gohome='" & code_gohome & "' and status_open='gohome' and rf_id_invoice='" & id & "' and status_pay='no';"
                    Else
                        StringQuery &= "INSERT INTO pos_order_list (rf_id_prd,rf_id_con,name_ord,name_ord_en,amt,price,prs,rf_id_invoice," _
                        & "rf_id_table,status_sd_captain,status_open,status_pay,remark,create_date,create_by,code_gohome,ref_cat_id," _
                        & "ref_catsubprd,name_th_cat,name_en_cat,name_th_catsubprd,name_en_catsubprd,ord_vat,ord_vat_st) " _
                        & " VALUES('" & rf_id_prd & "','" & rf_id_con & "','" & name_ord & "','" & name_ord_en & "','" & qty & "','" & price & "'," _
                        & "'" & prs & "','" & id & "','0','" & status_sd_captain & "'," _
                        & "'gohome','no','" & remark & "','" & Login.DateData.ToString("yyyy-MM-dd") & Date.Now.ToString(" HH:mm:ss") & "','" & Login.username & "'," _
                        & "'" & code_gohome & "','" & id_cat & "','" & id_subcatprd & "','" & name_cat_th & "'," _
                        & "'" & name_cat_en & "','" & name_subcat_th & "','" & name_subcat_en & "','" & ord_vat & "','" & ord_vat_st & "');"
                    End If
                Next
                StringQuery &= "DELETE FROM pos_order_list WHERE code_gohome='" & code_gohome & "' and rf_id_invoice='" & selBill & "' and status_pay='no' and status_open='gohome';" '=== delete order old ==='
                '==== delete bill ที่ค้างในระบบเมื่อย้ายข้อมูลไปบิลอื่นๆหมดแล้ว ลบทั้ง order_list และ pos_invoice_temp ===='
                StringQuery &= "DELETE FROM pos_invoice_temp where id='" & selBill & "';"
                If StringQuery <> "" Then
                    con.mysql_query(StringQuery)
                End If
                s1()
            End If
        Else
            Dim k As String = ""
            Dim kk As Integer = 0
            Dim v As Integer = 0
            For i As Integer = 0 To FlowLayoutPanel_Bill.Controls.Count - 1
                Dim f() As String = FlowLayoutPanel_Bill.Controls.Item(i).Tag.Split("_")
                If f(0) = selBill Then
                    v = i
                    kk = i - 1
                End If
            Next
            FlowLayoutPanel_Bill.Controls.RemoveAt(v)
            Dim t As Button = CType(FlowLayoutPanel_Bill.Controls.Item(kk), Button)
            t.PerformClick() ' == load data 
            For i As Integer = 0 To FlowLayoutPanel_Bill.Controls.Count - 1
                FlowLayoutPanel_Bill.Controls.Item(i).Text = "No." & (i + 1)
            Next
        End If
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

    Private Sub btn_tick_item_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_tick_item.Click
        If ListView1.Items.Count > 0 Then
            If ListView1.SelectedItems.Count > 0 Then
                If ListView1.Items(ListView1.SelectedIndices(0)).Checked = CheckState.Unchecked Then
                    ListView1.Items(ListView1.SelectedIndices(0)).Checked = CheckState.Checked
                    ListView1.Focus()
                Else
                    ListView1.Items(ListView1.SelectedIndices(0)).Checked = CheckState.Unchecked
                    ListView1.Focus()
                End If
            End If
        End If
    End Sub
    Private Sub btn_move_item_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_move_item.Click
        'Loop Check have Checked = True in select focus tabs
        Dim t As Boolean = False
        If ListView1.Items.Count > 0 Then
            For j As Integer = (ListView1.Items.Count - 1) To 0 Step -1
                If ListView1.Items(j).Checked = True Then
                    t = True
                End If
            Next
        End If
        If t = True Then
            Dim itmx1 As New ListViewItem
            payment_gohome_subp_dialog.ListView1.Items.Clear()
            For i As Integer = (ListView1.Items.Count - 1) To 0 Step -1
                If ListView1.Items(i).Checked = True Then
                    If ListView1.Items(i).SubItems(0).Text <> "void" Then
                        itmx1 = payment_gohome_subp_dialog.ListView1.Items.Add(ListView1.Items(i).SubItems(0).Text, i)
                        itmx1.SubItems.Add(ListView1.Items(i).SubItems(1).Text)
                        itmx1.SubItems.Add(ListView1.Items(i).SubItems(2).Text)
                        itmx1.SubItems.Add(ListView1.Items(i).SubItems(3).Text)
                        itmx1.SubItems.Add(ListView1.Items(i).SubItems(4).Text)
                        itmx1.SubItems.Add(ListView1.Items(i).SubItems(5).Text)
                        itmx1.SubItems.Add(ListView1.Items(i).SubItems(6).Text)
                        itmx1.SubItems.Add(ListView1.Items(i).SubItems(7).Text)
                        itmx1.SubItems.Add(ListView1.Items(i).SubItems(8).Text)
                        itmx1.SubItems.Add(ListView1.Items(i).SubItems(9).Text)
                        itmx1.SubItems.Add(ListView1.Items(i).SubItems(10).Text)
                        itmx1.SubItems.Add(ListView1.Items(i).SubItems(11).Text)
                        itmx1.SubItems.Add(ListView1.Items(i).SubItems(12).Text)
                        itmx1.SubItems.Add(ListView1.Items(i).SubItems(13).Text)
                        itmx1.SubItems.Add(ListView1.Items(i).SubItems(14).Text)
                        itmx1.SubItems.Add(ListView1.Items(i).SubItems(15).Text)
                        itmx1.SubItems.Add(ListView1.Items(i).SubItems(16).Text)
                        itmx1.SubItems.Add(ListView1.Items(i).SubItems(17).Text)
                        itmx1.SubItems.Add(ListView1.Items(i).SubItems(18).Text)
                        itmx1.SubItems.Add(ListView1.Items(i).SubItems(19).Text)
                        itmx1.SubItems.Add(ListView1.Items(i).SubItems(20).Text)
                        itmx1.SubItems.Add(ListView1.Items(i).SubItems(21).Text)
                        itmx1.SubItems.Add(ListView1.Items(i).SubItems(22).Text)
                        itmx1.SubItems.Add(ListView1.Items(i).SubItems(23).Text)
                        itmx1.SubItems.Add(ListView1.Items(i).SubItems(24).Text)
                        itmx1.SubItems.Add(ListView1.Items(i).SubItems(8).Text)
                        itmx1.SubItems.Add(ListView1.Items(i).SubItems(11).Text)
                        itmx1.SubItems.Add(ListView1.Items(i).SubItems(25).Text)
                        itmx1.SubItems.Add(ListView1.Items(i).SubItems(26).Text)

                    Else
                        ListView1.Items(i).Checked = False
                    End If
                End If
            Next
            payment_gohome_subp_dialog.ShowDialog()
            payment_gohome_subp_dialog.RecalPrice_QTY()
        End If

    End Sub

    Private Sub btn_tick_item_all_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_tick_item_all.Click
        If btn_tick_item_all.Text = "Select All" Then
            Dim i As Integer = 0
            For i = 0 To ListView1.Items.Count - 1
                ListView1.Items(i).Checked = True
            Next
            btn_tick_item_all.Text = "UnSelect All"
        Else
            Dim j As Integer = 0
            For j = 0 To ListView1.Items.Count - 1
                ListView1.Items(j).Checked = False
            Next
            btn_tick_item_all.Text = "Select All"
        End If
    End Sub
    Public Function GetNameTb(ByVal id_tb)
        Dim nm As String = ""
        Dim g As MySqlDataReader = con.mysql_query("select IFNULL(number,'0') as number from pos_table_system where id='" & id_tb & "';")
        g.Read()
        nm = g.GetString("number")
        g.Close()
        Return nm
    End Function
    Public Function GetNumberINV_POSINV(ByVal id)
        Dim numberinv As String = ""
        Dim k As MySqlDataReader = con.mysql_query("select namber_inv from pos_invoice where id='" & id & "';")
        k.Read()
        numberinv = k.GetString("namber_inv")
        Return numberinv
    End Function

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        print.PrintTryBill(id_bill_printtry, user_login_print, type_bill_printtry, printer_name_trybill, switch_lang)
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        'print.ReDefalutPrint()
    End Sub
End Class