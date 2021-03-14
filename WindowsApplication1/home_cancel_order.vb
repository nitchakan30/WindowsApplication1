Imports MySql.Data.MySqlClient
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports System.IO
Imports System.Text
Imports System.Threading

Public Class home_cancel_order
    Dim con As New Mysql
    Private Sub home_cancel_order_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadDaata()
    End Sub
    Private Sub loadDaata()
        If ListView_food.Items.Count > 0 Then
            ListView_food.Items.Clear()
        End If
        Dim size_n As String
        Dim rf_id_con As String
        Dim y As Integer = 0
        Dim yearNew As Integer
        If CInt(Login.DateData.ToString("yyyy")) > 2450 Then
            yearNew = CInt(Login.DateData.ToString("yyyy")) - 543
        Else
            yearNew = CInt(Login.DateData.ToString("yyyy"))
        End If
        Dim dNow As Date = yearNew & "-" & Login.DateData.ToString("MM-dd")
        Dim str1 As String = "SELECT pos_order_list.id_ord AS id_ord,pos_order_list.status_sd_captain AS status_sd_captain," _
       & "pos_order_list.rf_id_prd AS rf_id_prd,pos_order_list.rf_id_con As rf_id_con,pos_order_list.name_ord AS name_ord," _
       & "pos_order_list.name_ord_en AS name_ord_en," _
       & "pos_order_list.prs AS prs,pos_order_list.remark AS remark,pos_order_list.ref_id_join AS ref_id_join," _
       & "SUM(pos_order_list.amt) AS samt,SUM(pos_order_list.price) AS sprice,pos_table_system.id AS idTb,IFNULL(pos_product_size.name_th,0) AS name_size," _
       & "pos_order_list.ref_cat_id as ref_cat_id,pos_order_list.ref_catsubprd as ref_catsubprd,pos_order_list.name_th_cat as name_th_cat,pos_order_list.name_en_cat as name_en_cat," _
       & "pos_order_list.name_th_catsubprd as name_th_catsubprd,pos_order_list.name_en_catsubprd as name_en_catsubprd,pos_order_list.ord_vat as ord_vat,pos_order_list.ord_vat_st as ord_vat_st," _
       & "pos_order_list.prd_type_dis_id as prd_type_dis_id,pos_order_list.prd_type_dis_en as prd_type_dis_en,pos_order_list.prd_type_dis_th as prd_type_dis_th" _
        & ",IFNULL(un.name_th,'') as name_unit  " _
        & " FROM pos_order_list  INNER JOIN pos_table_system ON pos_table_system.id=pos_order_list.rf_id_table " _
        & " LEFT JOIN pos_product_condition ON pos_order_list.rf_id_con =  pos_product_condition.id " _
        & " LEFT JOIN pos_product_ingredients ON pos_product_ingredients.id  =  pos_product_condition.ref_id_ingredients" _
        & " LEFT JOIN pos_product_size ON pos_product_size.id =  pos_product_condition.ref_id_size" _
        & " LEFT JOIN pos_product_unit un ON un.id =  pos_product_condition.ref_id_unit" _
       & " WHERE  pos_order_list.status_pay='no' and (pos_order_list.create_date LIKE '%" & dNow.ToString("yyyy-MM-dd") & "%') and pos_order_list.status_sd_captain<>'void' and " _
       & "pos_order_list.status_open<>'gohome' and (pos_order_list.rf_id_table='" & Login.OpenId & "' or pos_order_list.ref_id_join='" & Login.OpenId & "')" _
       & " GROUP BY pos_order_list.rf_id_prd,pos_order_list.rf_id_con,pos_order_list.name_ord order by id_ord asc"
        Dim res_listView As MySqlDataReader = con.mysql_query(str1)
        Dim itmx1 As New ListViewItem
        While res_listView.Read
            itmx1 = ListView_food.Items.Add(res_listView.GetString("status_sd_captain"), y)
            itmx1.SubItems.Add(res_listView.GetString("id_ord"))
            itmx1.SubItems.Add(res_listView.GetString("rf_id_prd"))
            If res_listView.GetString("rf_id_con") <> "0" Then
                rf_id_con = res_listView.GetString("rf_id_con")
            Else
                rf_id_con = ""
            End If
            itmx1.SubItems.Add(rf_id_con)
            itmx1.SubItems.Add(res_listView.GetString("name_ord"))
            itmx1.SubItems.Add(res_listView.GetString("name_ord_en"))

            If res_listView.GetString("name_size") <> "0" Or res_listView.GetString("name_unit") <> "" Then
                If res_listView.GetString("name_size") Then
                    size_n = res_listView.GetString("name_size")
                Else
                    size_n = res_listView.GetString("name_unit")
                End If
            Else
                size_n = ""
            End If
            itmx1.SubItems.Add(size_n)
            itmx1.SubItems.Add(res_listView.GetString("samt"))
            itmx1.SubItems.Add(res_listView.GetDecimal("sprice").ToString("#,##0.00"))
            itmx1.SubItems.Add(res_listView.GetString("remark"))
            itmx1.SubItems.Add(res_listView.GetString("ref_cat_id"))
            itmx1.SubItems.Add(res_listView.GetString("ref_catsubprd"))
            itmx1.SubItems.Add(res_listView.GetString("name_th_cat"))
            itmx1.SubItems.Add(res_listView.GetString("name_en_cat"))
            itmx1.SubItems.Add(res_listView.GetString("name_th_catsubprd"))
            itmx1.SubItems.Add(res_listView.GetString("name_en_catsubprd"))
            itmx1.SubItems.Add(res_listView.GetString("ord_vat"))
            itmx1.SubItems.Add(res_listView.GetString("ord_vat_st"))
            itmx1.SubItems.Add(res_listView.GetString("prd_type_dis_id"))
            itmx1.SubItems.Add(res_listView.GetString("prd_type_dis_en"))
            itmx1.SubItems.Add(res_listView.GetString("prd_type_dis_th"))

            save_voidlist.Enabled = False
        End While
    End Sub


    Private Sub btn_delOrd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delOrd.Click
        If ListView_food.SelectedItems.Count > 0 Then
            Dim strV(21) As String
            Dim itmx2 As ListViewItem
            Dim n As Integer = ListView_food.Items.Count - 1
            If ListView_food.Items(ListView_food.SelectedIndices(0)).SubItems(0).Text() = "void" Then
                save_voidlist.Enabled = True
                For i As Integer = 0 To ListView_food.Items.Count - 1
                    If ListView_food.Items(i).SubItems(0).Text.ToLower <> "void" Then
                        If ListView_food.Items(ListView_food.SelectedIndices(0)).SubItems(2).Text() = ListView_food.Items(i).SubItems(2).Text() And ListView_food.Items(ListView_food.SelectedIndices(0)).SubItems(3).Text() = ListView_food.Items(i).SubItems(3).Text() Then
                            ListView_food.Items(i).SubItems(7).Text() += CInt(ListView_food.Items(ListView_food.SelectedIndices(0)).SubItems(7).Text())
                            ListView_food.Items(i).SubItems(8).Text() += CDbl(ListView_food.Items(ListView_food.SelectedIndices(0)).SubItems(8).Text())
                            Exit For
                        Else
                            strV(0) = "yes"
                            strV(1) = ListView_food.Items(ListView_food.SelectedIndices(0)).SubItems(1).Text()
                            strV(2) = ListView_food.Items(ListView_food.SelectedIndices(0)).SubItems(2).Text()
                            strV(3) = ListView_food.Items(ListView_food.SelectedIndices(0)).SubItems(3).Text()
                            strV(4) = ListView_food.Items(ListView_food.SelectedIndices(0)).SubItems(4).Text()
                            strV(5) = ListView_food.Items(ListView_food.SelectedIndices(0)).SubItems(5).Text()
                            strV(6) = ListView_food.Items(ListView_food.SelectedIndices(0)).SubItems(6).Text()
                            strV(7) = ListView_food.Items(ListView_food.SelectedIndices(0)).SubItems(7).Text()
                            strV(8) = ListView_food.Items(ListView_food.SelectedIndices(0)).SubItems(8).Text()
                            strV(9) = ListView_food.Items(ListView_food.SelectedIndices(0)).SubItems(9).Text()
                            strV(10) = ListView_food.Items(ListView_food.SelectedIndices(0)).SubItems(10).Text()
                            strV(11) = ListView_food.Items(ListView_food.SelectedIndices(0)).SubItems(11).Text()
                            strV(12) = ListView_food.Items(ListView_food.SelectedIndices(0)).SubItems(12).Text()
                            strV(13) = ListView_food.Items(ListView_food.SelectedIndices(0)).SubItems(13).Text()
                            strV(14) = ListView_food.Items(ListView_food.SelectedIndices(0)).SubItems(14).Text()
                            strV(15) = ListView_food.Items(ListView_food.SelectedIndices(0)).SubItems(15).Text()
                            strV(16) = ListView_food.Items(ListView_food.SelectedIndices(0)).SubItems(16).Text()
                            strV(17) = ListView_food.Items(ListView_food.SelectedIndices(0)).SubItems(17).Text()
                            strV(18) = ListView_food.Items(ListView_food.SelectedIndices(0)).SubItems(18).Text()
                            strV(19) = ListView_food.Items(ListView_food.SelectedIndices(0)).SubItems(19).Text()
                            strV(20) = ListView_food.Items(ListView_food.SelectedIndices(0)).SubItems(20).Text()
                            itmx2 = New ListViewItem(strV)
                            ListView_food.Items.Add(itmx2)
                            Exit For
                        End If
                    End If
                Next
                ListView_food.Items.RemoveAt(ListView_food.SelectedIndices.Item(0))
                home1.calsum()
            End If
        End If
    End Sub

    Private Sub btn_voidOrd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_voidOrd.Click
        Dim result1 As Integer
        If Login.LangG = "TH" Then
            result1 = MessageBox.Show("คุณมั่นใจใช่ไหมที่จะยกเลิกรายการสินค้านี้?", "ข้อความแจ้งการทำงานยกเลิกรายการสินค้า", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        Else
            result1 = MessageBox.Show("Are You Sure Cancel this Order?", "Alert Comfirm Void Order?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        End If
        If result1 = DialogResult.Yes Then
            If ListView_food.SelectedItems.Count > 0 Then
                void_orderlist.id_prd = ListView_food.Items(ListView_food.SelectedIndices(0)).SubItems(2).Text()
                void_orderlist.id_con_prd = ListView_food.Items(ListView_food.SelectedIndices(0)).SubItems(3).Text()
                void_orderlist.name_prd = ListView_food.Items(ListView_food.SelectedIndices(0)).SubItems(4).Text()
                void_orderlist.name_prd_en = ListView_food.Items(ListView_food.SelectedIndices(0)).SubItems(5).Text()
                void_orderlist.Nsize = ListView_food.Items(ListView_food.SelectedIndices(0)).SubItems(6).Text()
                void_orderlist.samt = CInt(ListView_food.Items(ListView_food.SelectedIndices(0)).SubItems(7).Text())
                void_orderlist.sprice = CDbl(ListView_food.Items(ListView_food.SelectedIndices(0)).SubItems(8).Text())
                void_orderlist.remark = ListView_food.Items(ListView_food.SelectedIndices(0)).SubItems(9).Text()
                void_orderlist.id_cat = ListView_food.Items(ListView_food.SelectedIndices(0)).SubItems(10).Text()
                void_orderlist.id_subcatprd = ListView_food.Items(ListView_food.SelectedIndices(0)).SubItems(11).Text()
                void_orderlist.name_cat_en = ListView_food.Items(ListView_food.SelectedIndices(0)).SubItems(12).Text()
                void_orderlist.name_cat_th = ListView_food.Items(ListView_food.SelectedIndices(0)).SubItems(13).Text()
                void_orderlist.name_subcat_en = ListView_food.Items(ListView_food.SelectedIndices(0)).SubItems(14).Text()
                void_orderlist.name_subcat_th = ListView_food.Items(ListView_food.SelectedIndices(0)).SubItems(15).Text()
                void_orderlist.ord_vat = ListView_food.Items(ListView_food.SelectedIndices(0)).SubItems(16).Text()
                void_orderlist.ord_vat_st = ListView_food.Items(ListView_food.SelectedIndices(0)).SubItems(17).Text()
                void_orderlist.prd_t_id = ListView_food.Items(ListView_food.SelectedIndices(0)).SubItems(18).Text()
                void_orderlist.prd_t_en = ListView_food.Items(ListView_food.SelectedIndices(0)).SubItems(19).Text()
                void_orderlist.prd_t_th = ListView_food.Items(ListView_food.SelectedIndices(0)).SubItems(20).Text()
                void_orderlist.ShowDialog()
            End If
        End If
    End Sub

    Private Sub save_voidlist_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles save_voidlist.Click
        Try
            Dim b As Boolean = False
            For j As Integer = 0 To ListView_food.Items.Count - 1
                'Check listview find void ?
                Dim status As String = ListView_food.Items(j).SubItems(0).Text
                If status = "void" Then
                    b = True
                End If
            Next
            If b = True Then


                Dim result As Integer
                If Login.LangG = "TH" Then
                    result = MessageBox.Show("คุณมั่นใจใช่ไหมที่จะยกเลิกรายการต่างๆ?", "ข้อความแจ้งการทำงาน", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                Else
                    result = MessageBox.Show("Are you sure cancel order list?", "Alert Comfirm Void Order List?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                End If
                Dim print_void As Boolean = False
                If result = DialogResult.Yes Then
                    Dim StrV As String = ""
                    Dim year As Integer = 0
                    Dim dateNew As DateTime
                    If CInt(Login.DateData.ToString("yyyy")) > 2450 Then
                        year = CInt(Login.DateData.ToString("yyyy")) - 543
                    Else
                        year = CInt(Login.DateData.ToString("yyyy"))
                    End If
                    dateNew = year & Login.DateData.ToString("-MM-dd ") & Date.Now().ToString("HH:mm:ss")
                    If ListView_food.Items.Count > 0 Then
                        Dim qty As Boolean = False
                        For k As Integer = 0 To ListView_food.Items.Count - 1
                            If ListView_food.Items(k).SubItems(0).Text.ToLower = "void" Then
                                print_void = True
                            Else
                                print_void = False
                            End If
                        Next
                        If print_void = True Then
                            Dim sqlSql As MySqlDataReader = con.mysql_query("select prs as prs,IFNULL(rf_id_invoice,'0') as rf_id_invoice,ref_id_join as ref_id_join from pos_order_list WHERE rf_id_table='" & Login.OpenId & "' and status_pay='no'")
                            sqlSql.Read()
                            'Dim res_del As Boolean = con.mysql_query("DELETE FROM pos_order_list WHERE rf_id_table='" & Login.OpenId & "' and status_pay='no' ")
                            'If res_del = True Then

                            Dim str_q As String = ""
                            For i As Integer = 0 To ListView_food.Items.Count - 1
                                'Check listview find void ?
                                Dim status As String = ListView_food.Items(i).SubItems(0).Text
                                Dim id_ord As String = ListView_food.Items(i).SubItems(1).Text
                                Dim id_prd As String = ListView_food.Items(i).SubItems(2).Text
                                Dim id_con_prd As String = ListView_food.Items(i).SubItems(3).Text
                                If id_con_prd = "" Then
                                    id_con_prd = "0"
                                Else
                                    id_con_prd = id_con_prd
                                End If
                                Dim name_prd As String = ListView_food.Items(i).SubItems(4).Text.Replace("'", "\'")
                                Dim name_prd_en As String = ListView_food.Items(i).SubItems(5).Text.Replace("'", "\'")
                                Dim amt As Integer = CInt(ListView_food.Items(i).SubItems(7).Text)
                                Dim price As Double = CDbl(ListView_food.Items(i).SubItems(8).Text)
                                Dim id_cat As String = ListView_food.Items(i).SubItems(10).Text.Trim
                                Dim id_subcatprd As String = ListView_food.Items(i).SubItems(11).Text.Trim
                                Dim name_cat As String = ListView_food.Items(i).SubItems(12).Text.Trim
                                Dim name_subcat As String = ListView_food.Items(i).SubItems(14).Text.Trim
                                Dim ord_vat As Integer = ListView_food.Items(i).SubItems(16).Text.Trim
                                Dim ord_vat_st As String = ListView_food.Items(i).SubItems(17).Text.Trim
                                Dim prd_t_id As Integer = ListView_food.Items(i).SubItems(18).Text.Trim
                                Dim prd_t_en As String = ListView_food.Items(i).SubItems(19).Text.Trim
                                Dim prd_t_th As String = ListView_food.Items(i).SubItems(20).Text.Trim

                                If status = "void" And CInt(ListView_food.Items(i).SubItems(7).Text) > 0 Then

                                    'เช็คว่ามีการยกเลิกรายการก่อนหน้านี้หรือยัง
                                    Dim l As Integer = con.mysql_num_rows(con.mysql_query("select * from pos_order_list where rf_id_table='" & Login.OpenId & "' " _
                                & "and ref_id_join='" & sqlSql.GetString("ref_id_join") & "' and rf_id_prd='" & id_prd & "' " _
                                & "and rf_id_con='" & id_con_prd & "' and name_ord='" & name_prd & "' and status_sd_captain='void' and status_pay='no';"))
                                    If l > 0 Then 'มีรายการที่ถูกยกเลิกอยู๋แล้ว

                                        StrV &= "UPDATE pos_order_list SET amt=amt+" & amt & ",price=price+" & price & " where rf_id_table='" & Login.OpenId & "' " _
                        & "and ref_id_join='" & sqlSql.GetString("ref_id_join") & "' and rf_id_prd='" & id_prd & "' " _
                        & "and rf_id_con='" & id_con_prd & "' and name_ord='" & name_prd & "' and status_sd_captain='void' and status_pay='no';"

                                    Else

                                        StrV &= "INSERT INTO pos_order_list (rf_id_prd,rf_id_con,name_ord,name_ord_en,amt,price,prs," _
                               & "rf_id_table,ref_id_join,status_sd_captain,status_open,remark,create_date,create_by,code_gohome,code_print,rf_id_invoice,ref_cat_id," _
                               & "ref_catsubprd,name_th_cat,name_en_cat,name_th_catsubprd,name_en_catsubprd,ord_vat,ord_vat_st,prd_type_dis_id,prd_type_dis_en,prd_type_dis_th) " _
                               & " VALUES('" & id_prd & "','" & id_con_prd & "','" & name_prd & "','" & name_prd_en & "','" & CInt(ListView_food.Items(i).SubItems(7).Text) & "','" & CDbl(ListView_food.Items(i).SubItems(8).Text) & "'," _
                               & "'" & sqlSql.GetString("prs") & "','" & Login.OpenId & "','" & sqlSql.GetString("ref_id_join") & "','" & status & "','ontb','" & ListView_food.Items(i).SubItems(9).Text.Replace("'", "\'") & "','" & dateNew.ToString("yyyy-MM-dd ") & Date.Now().ToString("HH:mm:ss") & "','" & Login.username & "'," _
                               & "'0','" & opentable.GetCode_print() & "','" & sqlSql.GetString("rf_id_invoice") & "','" & id_cat & "','" & id_subcatprd & "','" & name_cat & "'," _
                               & "'" & name_cat & "','" & name_subcat & "','" & name_subcat & "','" & ord_vat & "','" & ord_vat_st & "','" & prd_t_id & "','" & prd_t_en & "','" & prd_t_th & "');"

                                    End If

                                    StrV &= "UPDATE pos_order_list SET amt=amt-" & amt & ",price=price-" & price & " where  rf_id_table='" & Login.OpenId & "' " _
                           & "and ref_id_join='" & sqlSql.GetString("ref_id_join") & "' and rf_id_prd='" & id_prd & "' " _
                           & "and rf_id_con='" & id_con_prd & "' and name_ord='" & name_prd & "' and status_pay='no' and status_sd_captain<>'void' ;"

                                End If

                                If status = "yes" And CInt(ListView_food.Items(i).SubItems(7).Text) = 0 Then
                                    StrV &= "DELETE FROM pos_order_list WHERE id_ord='" & ListView_food.Items(i).SubItems(1).Text & "';"
                                End If
                                If CInt(ListView_food.Items(i).SubItems(7).Text) > 0 Then

                                    If ListView_food.Items(i).SubItems(0).Text.ToLower = "void" Then
                                        opentable.returnStock(ListView_food.Items(i).SubItems(2).Text, ListView_food.Items(i).SubItems(3).Text, ListView_food.Items(i).SubItems(7).Text)
                                        print_void = True
                                    End If
                                End If
                            Next

                        End If

                        'Query Into Database
                        ' MsgBox(StrV)
                        qty = con.mysql_query(StrV)
                        If qty = True Then
                            If print_void = True Then
                                Dim array_print As New ArrayList
                                Dim array_idtemp As New ArrayList
                                Dim array_sendcap As New ArrayList
                                Dim array_namecat As New ArrayList
                                array_print.Clear()
                                array_idtemp.Clear()
                                array_sendcap.Clear()
                                array_namecat.Clear()
                                Try
                                    Dim array_countGroup As New ArrayList
                                    array_countGroup.Clear()
                                    For x As Integer = 0 To ListView_food.Items.Count - 1
                                        If ListView_food.Items(x).SubItems(0).Text().ToLower = "void" Then
                                            Dim v As Boolean = False
                                            Dim printername_v As String = ""
                                            Dim copy2captain As String = ""
                                            Dim id_ref_temp As String = ""
                                            For u As Integer = 0 To array_countGroup.Count - 1
                                                If ListView_food.Items(x).SubItems(11).Text() = array_countGroup(u).ToString Then
                                                    v = True
                                                End If
                                            Next
                                            If v = False Then
                                                array_countGroup.Add(ListView_food.Items(x).SubItems(11).Text())
                                                printername_v = opentable.Get_printer_subgroup(ListView_food.Items(x).SubItems(11).Text())
                                                copy2captain = opentable.Get_CopySendcaptain_subgroup(ListView_food.Items(x).SubItems(11).Text())
                                                id_ref_temp = "P" & Login.DateData.ToString("dd") & Login.DateData.ToString("MM") & Login.DateData.ToString("yy") & Format(DateAndTime.Now, "HH") & Format(DateAndTime.Now, "mm") & Format(DateAndTime.Now, "ss") & "0" & x
                                                array_print.Add(printername_v)
                                                array_idtemp.Add(id_ref_temp)
                                                array_sendcap.Add(copy2captain)
                                                array_namecat.Add(ListView_food.Items(x).SubItems(12).Text())
                                            End If
                                        End If
                                    Next
                                    Dim g As Integer = 1
                                    For t As Integer = 0 To array_countGroup.Count - 1
                                        For j As Integer = 0 To ListView_food.Items.Count - 1
                                            If ListView_food.Items(j).SubItems(0).Text().ToLower = "void" Then
                                                If ListView_food.Items(j).SubItems(11).Text() = array_countGroup(t).ToString Then
                                                    Dim rf_id_prd As String = ListView_food.Items(j).SubItems(2).Text()
                                                    Dim rf_id_con As String = ListView_food.Items(j).SubItems(3).Text()
                                                    Dim name_ord As String = ListView_food.Items(j).SubItems(4).Text()
                                                    Dim name_ord_en As String = ListView_food.Items(j).SubItems(5).Text()
                                                    Dim amt As String = ListView_food.Items(j).SubItems(7).Text()
                                                    Dim price As String = ListView_food.Items(j).SubItems(8).Text()
                                                    Dim remark As String = ListView_food.Items(j).SubItems(9).Text()
                                                    con.mysql_query("INSERT INTO pos_temp_print (rf_id_prd,rf_id_con,name_ord,name_ord_en,amt,price,prs,rf_id_table,status_sd_captain,status_pay,status_open,remark,create_date,code_gohome,name_cat_en,name_cat_th,id_ref_temp)" _
                                                    & " VALUES('" & rf_id_prd & "','" & rf_id_con & "','" & name_ord & "','" & name_ord_en & "'," _
                                                    & "'" & amt & "','" & price & "','1','" & Login.OpenId & "'," _
                                                    & "'void','no','ontb','" & remark & "'," _
                                                    & "'" & Login.DateData.ToString("yyyy-MM-dd") & Date.Now.ToString(" HH:mm:ss") & "','0','" & ListView_food.Items(j).SubItems(12).Text() & "','" & ListView_food.Items(j).SubItems(13).Text() & "','" & array_idtemp(t).ToString & "')")
                                                    g += 1
                                                End If
                                            End If
                                        Next
                                    Next
                                    'For Print To Printer
                                    For h As Integer = 0 To array_countGroup.Count - 1
                                        Dim WorkerThread As Thread
                                        Dim W As New worker
                                        Thread.Sleep(1000)
                                        W.setSendCaptainCancel(Login.OpenId, "ontb", index.getNameTable(Login.OpenId), dateNew.ToString("dd/MM/yyyy"), "0", Login.username, array_print(h).ToString, array_idtemp(h).ToString)
                                        WorkerThread = New Thread(AddressOf W.Start)    'Create our Worker thread and tell it that when we start it it should call our Worker's Start() method
                                        WorkerThread.Start()
                                        If Login.LangG = "TH" Then
                                            dialog_complete.Label_Dialog.Text = "ยกเลิกรายการของ " & array_namecat(h).ToString & " เรียบร้อยแล้วค่ะ"
                                            dialog_complete.ShowDialog()
                                        Else
                                            dialog_complete.Label_Dialog.Text = "Cancel order " & array_namecat(h).ToString & " Complete."
                                            dialog_complete.ShowDialog()
                                        End If
                                    Next
                                Catch ex As Exception
                                    MessageBox.Show(ex.Message.ToString())
                                End Try
                            End If

                            home1.Load_Product_list()
                            home1.calsum()
                            Me.Close()
                        Else
                            MessageBox.Show("ไม่มีข้อมูลในการยกเลิก กรุณาตรวจอสอบอีกครั้ง", "Message Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    Else
                        MessageBox.Show("Error Void Order List! Please Contact  support", "Message Alert Show", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString(), "Msg", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ListView_food_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView_food.Click
        If ListView_food.Items(ListView_food.SelectedIndices(0)).SubItems(0).Text() = "void" Then
            btn_delOrd.Enabled = True
            btn_voidOrd.Enabled = False
        ElseIf ListView_food.Items(ListView_food.SelectedIndices(0)).SubItems(0).Text() = "yes" Then
            btn_delOrd.Enabled = False
            btn_voidOrd.Enabled = True
        End If
    End Sub

    Private Sub ListView_food_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView_food.MouseClick
        If e.Button = MouseButtons.Left Then
            If ListView_food.SelectedItems.Count > 0 Then
                If ListView_food.SelectedIndices(0) < ListView_food.Items.Count - 1 Then
                    If ListView_food.Items(ListView_food.SelectedIndices(0)).SubItems(0).Text() = "void" Or CInt(ListView_food.Items(ListView_food.SelectedIndices(0)).SubItems(7).Text) = 0 Then
                        btn_delOrd.Enabled = True
                        btn_voidOrd.Enabled = False
                    ElseIf ListView_food.Items(ListView_food.SelectedIndices(0)).SubItems(0).Text() = "yes" Then
                        btn_delOrd.Enabled = False
                        btn_voidOrd.Enabled = True
                    End If
                End If
            Else
                If ListView_food.Items(ListView_food.SelectedIndices(0)).SubItems(0).Text() = "void" Or CInt(ListView_food.Items(ListView_food.SelectedIndices(0)).SubItems(7).Text) = 0 Then
                    btn_delOrd.Enabled = True
                    btn_voidOrd.Enabled = False
                ElseIf ListView_food.Items(ListView_food.SelectedIndices(0)).SubItems(0).Text() = "yes" Then
                    btn_delOrd.Enabled = False
                    btn_voidOrd.Enabled = True
                End If
            End If
        End If
    End Sub

    Private Sub btn_up_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_up.Click
        If ListView_food.SelectedItems.Count > 0 Then
            If ListView_food.SelectedIndices(0) > 0 Then
                ListView_food.Items.Item(ListView_food.SelectedIndices(0) - 1).Selected = True
                ListView_food.Focus()
                If ListView_food.Items(ListView_food.SelectedIndices(0)).SubItems(0).Text() = "void" Then
                    btn_delOrd.Enabled = True
                    btn_voidOrd.Enabled = False
                ElseIf ListView_food.Items(ListView_food.SelectedIndices(0)).SubItems(0).Text() = "yes" Then
                    btn_delOrd.Enabled = False
                    btn_voidOrd.Enabled = True
                End If
            End If
        Else
            ListView_food.Items.Item(0).Selected = True
            ListView_food.Focus()
            btn_voidOrd.Enabled = True
            If ListView_food.Items(ListView_food.SelectedIndices(0)).SubItems(0).Text() = "void" Then
                btn_delOrd.Enabled = True
                btn_voidOrd.Enabled = False
            ElseIf ListView_food.Items(ListView_food.SelectedIndices(0)).SubItems(0).Text() = "yes" Then
                btn_delOrd.Enabled = False
                btn_voidOrd.Enabled = True
            End If
        End If
    End Sub

    Private Sub btn_drow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_drow.Click
        If ListView_food.SelectedItems.Count > 0 Then
            If ListView_food.SelectedIndices(0) < ListView_food.Items.Count - 1 Then
                ListView_food.Items.Item(ListView_food.SelectedIndices(0) + 1).Selected = True
                ListView_food.Focus()
                If ListView_food.Items(ListView_food.SelectedIndices(0)).SubItems(0).Text() = "void" Then
                    btn_delOrd.Enabled = True
                    btn_voidOrd.Enabled = False
                ElseIf ListView_food.Items(ListView_food.SelectedIndices(0)).SubItems(0).Text() = "yes" Then
                    btn_delOrd.Enabled = False
                    btn_voidOrd.Enabled = True
                End If
            End If
        Else
            ListView_food.Items.Item(ListView_food.Items.Count - 1).Selected = True
            ListView_food.Focus()
            If ListView_food.Items(ListView_food.SelectedIndices(0)).SubItems(0).Text() = "void" Then
                btn_delOrd.Enabled = True
                btn_voidOrd.Enabled = False
            ElseIf ListView_food.Items(ListView_food.SelectedIndices(0)).SubItems(0).Text() = "yes" Then
                btn_delOrd.Enabled = False
                btn_voidOrd.Enabled = True
            End If
        End If
    End Sub

End Class