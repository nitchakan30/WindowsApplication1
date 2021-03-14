Imports MySql
Imports MySql.Data.MySqlClient

Public Class home1_menu
    Dim con As New Mysql
    Private Sub btn_sendagain_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_sendagain.Click
        form_reprint_captain.ShowDialog()
    End Sub

    Private Sub btn_changTb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_changTb.Click
        opentable_movetb.ShowDialog()
    End Sub

    Private Sub btn_cancel_order_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancel_order.Click
        home_cancel_order.ShowDialog()
    End Sub

    Private Sub btn_jointb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_jointb.Click
        If btn_jointb.Text = "รวมโต๊ะ" Or btn_jointb.Text = "Join" Then
            opentable_jointb.ShowDialog()
        End If
    End Sub

    Private Sub btn_supptb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_supptb.Click
        Dim result As Integer
        If Login.LangG = "TH" Then
            result = MessageBox.Show("คุณมั่นใจใช่ไหมที่จะแยกโต๊ะอาหาร?", "ยืนยันการแยกโต๊ะอาหาร", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        Else
            result = MessageBox.Show("Are You Sure Separate Table/คุณมั่นใจใช่ไหมที่จะแยกโต๊ะอาหาร ?", "Confirm Separate Table/ยืนยันการแยกโต๊ะ", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        End If
        If result = DialogResult.Yes Then
            If home1.Tb_Id_OldJoin > 0 Then
                Dim year As String = ""
                If CInt(Login.DateData.ToString("yyyy")) > 2450 Then
                    year = CInt(Login.DateData.ToString("yyyy")) - 543
                Else
                    year = Login.DateData.ToString("yyyy")
                End If

                Dim tb_join As String = ""
                Dim numinvoice As String = ""
                Dim query_tb_join As MySqlDataReader = con.mysql_query("SELECT * FROM pos_table_system where id='" & Login.OpenId & "'")
                query_tb_join.Read()
                tb_join = query_tb_join.GetString("id_join_tb")
                numinvoice = query_tb_join.GetString("invoice_number")
                Dim v As String = ""
                v &= "UPDATE pos_order_list SET update_by='" & Login.username & "',ref_id_join='0',rf_id_invoice='0',tryNumber='0' WHERE (rf_id_table='" & tb_join & "' or ref_id_join='" & tb_join & "') and status_pay='no' and  DAY(create_date)='" & Login.DateData.ToString("dd") & "' and MONTH(create_date)='" & Login.DateData.ToString("MM") & "' and YEAR(create_date)='" & year & "';"
                '==== เช้คว่ามีบิลในรายการสินค้าไหมถ้ามีให้ลบออกทั้งมด ====='
                Dim chk As Integer = con.mysql_num_rows(con.mysql_query("select rf_id_invoice from pos_order_list where (rf_id_table='" & tb_join & "' or ref_id_join='" & tb_join & "') and status_pay='no' and  DAY(create_date)='" & Login.DateData.ToString("dd") & "' and MONTH(create_date)='" & Login.DateData.ToString("MM") & "' and YEAR(create_date)='" & year & "' GROUP BY rf_id_invoice;"))
                If chk > 0 Then
                    Dim k As MySqlDataReader = con.mysql_query("select rf_id_invoice from pos_order_list where (rf_id_table='" & tb_join & "' or ref_id_join='" & tb_join & "') and status_pay='no' and  DAY(create_date)='" & Login.DateData.ToString("dd") & "' and MONTH(create_date)='" & Login.DateData.ToString("MM") & "' and YEAR(create_date)='" & year & "' GROUP BY rf_id_invoice;")
                    While k.Read
                        v &= "DELETE FROM pos_invoice_temp WHERE id='" & k.GetString("rf_id_invoice") & "';"
                    End While
                End If
                v &= "DELETE FROM pos_invoice_temp WHERE namber_inv='" & numinvoice & "';"
                v &= "UPDATE pos_table_system SET id_join_tb='0',update_by='" & Login.username & "',invoice_number='0' WHERE id_join_tb='" & tb_join & "';"


                Dim y As Boolean = con.mysql_query(v)
                If y = True Then
                    If Login.LangG = "TH" Then
                        MessageBox.Show("แยกโต๊ะเรียบร้อย", "ข้อความแจ้งการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Separate Table Complete", "Message Alert ", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                    Login.OpenId = home1.Tb_Id_OldJoin
                    home1.Tb_Id_OldJoin = 0
                    home1.ShowTable("All", 0)
                    home1.Panel_Ontb.Hide()
                    home1.Panel_Reservation.Hide()
                    home1.Panel1.Show()
                    Me.Close()

                End If
            End If
        End If
    End Sub
    Public confirm_dialogvoid As Boolean = False
    Public cn_voidtb As Boolean = False
    Public void_remark As String = ""
    Private Sub btn_void_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_void.Click
        confirm_void.page = "voidtb"
        confirm_void.ShowDialog()
        If cn_voidtb = True Then
            If Login.LangG = "TH" Then
                If home1.Tb_Id_OldJoin = Login.OpenId Then  '==== โต๊ะที่ย้ายเป็นโต๊ะ Head ในการรวมดต๊ะ===='
                    ConfirmDialog.TextBox1.Text = "เตือนค่ะ คุณได้รวมโต๊ะไว้ซึ่งโต๊ะนี้เป็นโต๊ะหลักที่ตั้งรวม ข้อมูลทั้งหมดที่ทำการรวมโต๊ะทั้งหมดจะโดนยกลเลิกไปด้วย คุณมั่นใจใช่ไหมที่จะยกเลิกโต๊ะนี้?"
                Else
                    ConfirmDialog.TextBox1.Text = "คุณมั่นใจใช่ไหมที่จะยกเลิกโต๊ะนี้?"
                End If
                ConfirmDialog.ShowDialog()
            Else
                If home1.Tb_Id_OldJoin = Login.OpenId Then  '==== โต๊ะที่ย้ายเป็นโต๊ะ Head ในการรวมดต๊ะ===='
                    ConfirmDialog.TextBox1.Text = "Table Is Select Active Head, Delete Data All Table Is Join Head. Are You Sure Cancel this All Table Is Join?"
                Else
                    ConfirmDialog.TextBox1.Text = "Are You Sure Cancel this Table?"
                End If
                ConfirmDialog.ShowDialog()
            End If
            If confirm_dialogvoid = True Then
                If voidReson.ShowDialog() Then
                    If voidReson.EnterT = True Then
                        'set remark ลงฟิวส์เพิ่อใช้ในการปริ้น
                        If home1.ListView_food.Items.Count > 0 Then
                            For j As Integer = 0 To home1.ListView_food.Items.Count - 1
                                home1.ListView_food.Items(j).SubItems(9).Text() = void_remark
                            Next
                        End If

                        'Print Void And Return Stock =='
                        'Query Group of Product for void

                        Dim ID_TB As Integer = 0
                        If home1.Tb_Id_OldJoin <> Login.OpenId And home1.Tb_Id_OldJoin > 0 Then '==== เข้าเงื่อนไขที่มีการรวมโต๊ะ===='
                            ID_TB = home1.Tb_Id_OldJoin
                            con.mysql_query("UPDATE pos_order_list SET remark='" & void_remark & "' WHERE rf_id_table='" & ID_TB & "' and status_pay='no';")
                            home1.PrintVoidJoin(ID_TB)
                        ElseIf home1.Tb_Id_OldJoin = Login.OpenId Then  '==== โต๊ะที่ย้ายเป็นโต๊ะ Head ในการรวมดต๊ะ===='
                            ID_TB = Login.OpenId
                            con.mysql_query("UPDATE pos_order_list SET remark='" & void_remark & "' WHERE rf_id_table='" & ID_TB & "' and status_pay='no';")
                            home1.PrintVoidJoinIsHead(ID_TB)
                        ElseIf home1.Tb_Id_OldJoin = 0 And Login.OpenId > 0 Then '==== เข้าเงื่อนไขที่ไม่่มีการรวมโต๊ะไว้====='
                            ID_TB = Login.OpenId
                            'con.mysql_query("UPDATE pos_order_list SET remark='" & void_remark & "' WHERE rf_id_table='" & ID_TB & "' and status_pay='no';")
                            home1.PrintVoidNoJoin()
                        End If
                        '=== Query Date For Return Stock ==='
                        Dim query_prd As MySqlDataReader = con.mysql_query("SELECT * FROM pos_order_list WHERE rf_id_table='" & ID_TB & "' and status_pay='no'")
                        While query_prd.Read()
                            If query_prd.GetString("status_sd_captain") <> "void" Then
                                opentable.returnStock(query_prd.GetString("rf_id_prd"), query_prd.GetString("rf_id_con"), query_prd.GetString("amt"))
                            End If
                        End While
                        ' UPDATE TABLE ORDER LIST
                        Dim yearNew As String
                        If CInt(Login.DateData.ToString("yyyy")) > 2450 Then
                            yearNew = CInt(Login.DateData.ToString("yyyy")) - 543
                        Else
                            yearNew = CInt(Login.DateData.ToString("yyyy"))
                        End If
                        Dim dNow As DateTime = yearNew & "-" & Login.DateData.ToString("MM-dd ") & " " & Format(DateAndTime.Now(), "HH:mm:ss")

                        Dim StringU As String = ""

                        StringU &= "INSERT INTO pos_order_void (ref_id_tb,rf_id_invoice,rf_id_prd,rf_id_con,code_gohome,remark_v,"
                        StringU &= "name_ord,name_ord_en,amt_v,price_v,prs_v,ref_cat_id_v,ref_catsubprd_v,name_th_cat_v,"
                        StringU &= "name_en_cat_v,name_th_catsubprd_v,name_en_catsubprd_v,ord_vat_v,ord_vat_st_v,prd_type_dis_id_v,"
                        StringU &= "prd_type_dis_en_v,prd_type_dis_th_v,actionBy,date_void)"
                        StringU &= " SELECT pos_order_list.rf_id_table,pos_order_list.rf_id_invoice,pos_order_list.rf_id_prd,"
                        StringU &= "pos_order_list.rf_id_con,pos_order_list.code_gohome,'" & void_remark & "',pos_order_list.name_ord,"
                        StringU &= "pos_order_list.name_ord_en,pos_order_list.amt,pos_order_list.price,pos_order_list.prs,"
                        StringU &= "pos_order_list.ref_cat_id,pos_order_list.ref_catsubprd,pos_order_list.name_th_cat,pos_order_list.name_en_cat,"
                        StringU &= "pos_order_list.name_th_catsubprd,pos_order_list.name_en_catsubprd,pos_order_list.ord_vat,"
                        StringU &= "pos_order_list.ord_vat_st,pos_order_list.prd_type_dis_id,pos_order_list.prd_type_dis_en,"
                        StringU &= "pos_order_list.prd_type_dis_th,'" & Login.username & "','" & dNow.ToString("yyyy-MM-dd HH:mm:ss") & "'"
                        StringU &= " FROM pos_order_list WHERE rf_id_table='" & ID_TB & "' and status_pay='no';"
                        StringU &= "Delete FROM pos_order_list WHERE rf_id_table='" & ID_TB & "' and status_pay='no';"

                        If home1.Tb_Id_OldJoin <> Login.OpenId And home1.Tb_Id_OldJoin > 0 Then '==== เข้าเงื่อนไขที่มีการรวมโต๊ะ===='
                            StringU &= "UPDATE pos_table_system SET update_by='" & Login.username & "',status='1',id_join_tb='0',invoice_number='0',remark_tb='-' WHERE id='" & ID_TB & "';"
                            Dim t As Integer = con.mysql_num_rows(con.mysql_query("select * from pos_table_system where id_join_tb='" & Login.OpenId & "';"))
                            If t = 1 Then
                                StringU &= "UPDATE pos_order_list SET ref_id_join='0' where rf_id_table='" & Login.OpenId & "';"
                                StringU &= "UPDATE pos_table_system SET update_by='" & Login.username & "',id_join_tb='0' where id='" & Login.OpenId & "';"
                            End If
                        ElseIf home1.Tb_Id_OldJoin = Login.OpenId Then  '==== โต๊ะที่ย้ายเป็นโต๊ะ Head ในการรวมดต๊ะ===='
                            Dim qy_delinv0 As MySqlDataReader = con.mysql_query("select rf_id_invoice from pos_order_list where (rf_id_table='" & ID_TB & "' or ref_id_join='" & ID_TB & "') and status_pay='no';")
                            While qy_delinv0.Read
                                StringU &= "DELETE FROM pos_invoice_temp WHERE id ='" & qy_delinv0.GetString("rf_id_invoice") & "';"
                            End While
                            StringU &= "UPDATE pos_order_list SET rf_id_invoice='0',ref_id_join='0' where ref_id_join='" & ID_TB & "' and status_pay='no';" '=== update รายการที่มีการร่วมโต๊ะอยู๋ให้ รวมโต๊ะเท่า0 และ เลข invoice=0=='
                            StringU &= "UPDATE pos_table_system SET update_by='" & Login.username & "',id_join_tb='0',status='1',invoice_number='0',remark_tb='-' WHERE id='" & ID_TB & "';"
                            StringU &= "UPDATE pos_table_system SET update_by='" & Login.username & "',id_join_tb='0',status='2',invoice_number='0',remark_tb='-' WHERE id_join_tb='" & ID_TB & "' and id<>'" & ID_TB & "';"
                        ElseIf home1.Tb_Id_OldJoin = 0 And Login.OpenId > 0 Then '==== เข้าเงื่อนไขที่ไม่่มีการรวมโต๊ะไว้====='
                            StringU &= "DELETE FROM pos_invoice_temp WHERE namber_inv = (select IFNULL(invoice_number,'0') as namber_inv from pos_table_system where id='" & ID_TB & "');" _
                            & "UPDATE pos_table_system SET status='1',update_by='" & Login.username & "',invoice_number='0',id_join_tb='0' WHERE id='" & ID_TB & "'; "
                        End If
                        ' MsgBox(StringU)
                        Dim queryOrd As Boolean = con.mysql_query(StringU)
                        If queryOrd = True Then 'CHECK QUERY VOID
                            ' UPDATE TABLE TABLE_SYSEM
                            cn_voidtb = False
                            home1.Label_tb_select.Text = "Table No. Option"
                            home1.Label_tb.Text = "Table No. Option"
                            home1.Label_Reserv.Text = "Table No. Reservation"
                            opentable.Label_tb_select.Text = "Table No.  Option"
                            If Login.LangG = "TH" Then
                                MessageBox.Show("ยกเลิกโต๊ะนี้เรียบร้อย.", "ข้อความแจ้งการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else
                                MessageBox.Show("Cancel Table Comple.", "Message Alert Action System", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If
                            voidReson.EnterT = False
                            confirm_dialogvoid = False
                            Login.OpenId = ""
                            home1.ShowListView_Order()
                            home1.ShowTable(home1.TabControl1.SelectedTab.Tag, home1.TabControl1.SelectedIndex)
                            home1.Panel_Ontb.Hide()
                            home1.Panel_Reservation.Hide()
                            home1.Panel1.Show()
                            Me.Close()
                        End If

                    End If
                End If
            End If
        End If
    End Sub

    Private Sub home1_menu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Switch_lang()
    End Sub
    Private Sub Switch_lang()
        If Login.LangG = "EN" Then
            
            btn_void.Text = "Void Table"
            btn_changTb.Text = "Move"
            btn_jointb.Text = "Join"
            btn_supptb.Text = "Separate"
            btn_sendagain.Text = "Print Again"
            btn_cancel_order.Text = "Void Order List"
        Else   
            btn_void.Text = "ยกเลิกโต๊ะ"
            btn_changTb.Text = "ย้ายโต๊ะ"
            btn_jointb.Text = "รวมโต๊ะ"
            btn_supptb.Text = "แยกโต๊ะ"
            btn_sendagain.Text = "พิมพ์ส่งครัวใหม่"
            btn_cancel_order.Text = "ยกเลิกรายการ"
        End If
    End Sub
End Class