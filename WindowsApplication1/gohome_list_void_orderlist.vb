Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Threading
Public Class gohome_list_void_orderlist
    Dim con As New Mysql
    Dim print As New printClass
    Dim ac As New Admin_ClassMain
    Public code_gohome As String = ""
    Public rf_id_invoice As String = ""
    Private Sub gohome_list_void_orderlist_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If gohome_list.ListView_GHF.Items.Count > 0 Then
            ListView_GHF.Items.Clear()
            Dim itmx1 As New ListViewItem
            For i As Integer = 0 To gohome_list.ListView_GHF.Items.Count - 1
                If gohome_list.ListView_GHF.Items(i).SubItems(1).Text <> "void" Then
                    itmx1 = ListView_GHF.Items.Add(gohome_list.ListView_GHF.Items(i).SubItems(0).Text, i)
                    itmx1.SubItems.Add(gohome_list.ListView_GHF.Items(i).SubItems(1).Text)
                    itmx1.SubItems.Add(gohome_list.ListView_GHF.Items(i).SubItems(2).Text)
                    itmx1.SubItems.Add(gohome_list.ListView_GHF.Items(i).SubItems(3).Text)
                    itmx1.SubItems.Add(gohome_list.ListView_GHF.Items(i).SubItems(4).Text)
                    itmx1.SubItems.Add(gohome_list.ListView_GHF.Items(i).SubItems(5).Text)
                    itmx1.SubItems.Add(gohome_list.ListView_GHF.Items(i).SubItems(6).Text)
                    itmx1.SubItems.Add(gohome_list.ListView_GHF.Items(i).SubItems(7).Text)
                    itmx1.SubItems.Add(gohome_list.ListView_GHF.Items(i).SubItems(8).Text)
                    itmx1.SubItems.Add(gohome_list.ListView_GHF.Items(i).SubItems(9).Text)
                    itmx1.SubItems.Add(gohome_list.ListView_GHF.Items(i).SubItems(10).Text)
                    itmx1.SubItems.Add(gohome_list.ListView_GHF.Items(i).SubItems(11).Text)
                    itmx1.SubItems.Add(gohome_list.ListView_GHF.Items(i).SubItems(12).Text)
                    itmx1.SubItems.Add(gohome_list.ListView_GHF.Items(i).SubItems(13).Text)
                    itmx1.SubItems.Add(gohome_list.ListView_GHF.Items(i).SubItems(14).Text)
                    itmx1.SubItems.Add(gohome_list.ListView_GHF.Items(i).SubItems(15).Text)
                    itmx1.SubItems.Add(gohome_list.ListView_GHF.Items(i).SubItems(16).Text)
                    itmx1.SubItems.Add(gohome_list.ListView_GHF.Items(i).SubItems(17).Text)
                    itmx1.SubItems.Add(gohome_list.ListView_GHF.Items(i).SubItems(18).Text)
                    itmx1.SubItems.Add(gohome_list.ListView_GHF.Items(i).SubItems(19).Text)
                    itmx1.SubItems.Add(gohome_list.ListView_GHF.Items(i).SubItems(20).Text)
                    itmx1.SubItems.Add(gohome_list.ListView_GHF.Items(i).SubItems(21).Text)
                End If
            Next
        End If
    End Sub

    Private Sub btn_cut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cut.Click
        If ListView_GHF.SelectedItems.Count > 0 Then
            void_orderlist.id_prd = ListView_GHF.Items(ListView_GHF.SelectedIndices(0)).SubItems(2).Text()
            void_orderlist.id_con_prd = ListView_GHF.Items(ListView_GHF.SelectedIndices(0)).SubItems(3).Text()
            void_orderlist.name_prd = ListView_GHF.Items(ListView_GHF.SelectedIndices(0)).SubItems(4).Text()
            void_orderlist.name_prd_en = ListView_GHF.Items(ListView_GHF.SelectedIndices(0)).SubItems(5).Text()
            void_orderlist.Nsize = ListView_GHF.Items(ListView_GHF.SelectedIndices(0)).SubItems(6).Text()
            void_orderlist.samt = CInt(ListView_GHF.Items(ListView_GHF.SelectedIndices(0)).SubItems(7).Text())
            void_orderlist.sprice = CDbl(ListView_GHF.Items(ListView_GHF.SelectedIndices(0)).SubItems(8).Text())
            void_orderlist.remark = ListView_GHF.Items(ListView_GHF.SelectedIndices(0)).SubItems(9).Text()
            void_orderlist.id_cat = ListView_GHF.Items(ListView_GHF.SelectedIndices(0)).SubItems(14).Text()
            void_orderlist.id_subcatprd = ListView_GHF.Items(ListView_GHF.SelectedIndices(0)).SubItems(15).Text()
            void_orderlist.name_cat_en = ListView_GHF.Items(ListView_GHF.SelectedIndices(0)).SubItems(16).Text()
            void_orderlist.name_cat_th = ListView_GHF.Items(ListView_GHF.SelectedIndices(0)).SubItems(17).Text()
            void_orderlist.name_subcat_en = ListView_GHF.Items(ListView_GHF.SelectedIndices(0)).SubItems(18).Text()
            void_orderlist.name_subcat_th = ListView_GHF.Items(ListView_GHF.SelectedIndices(0)).SubItems(19).Text()
            void_orderlist.ord_vat = ListView_GHF.Items(ListView_GHF.SelectedIndices(0)).SubItems(20).Text()
            void_orderlist.ord_vat_st = ListView_GHF.Items(ListView_GHF.SelectedIndices(0)).SubItems(21).Text()
            void_orderlist.PageRefer = "gohome"
            void_orderlist.ShowDialog()
        End If
    End Sub

    Private Sub btn_re_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_re.Click
        If ListView_GHF.SelectedItems.Count > 0 Then
            If ListView_GHF.Items(ListView_GHF.SelectedIndices(0)).SubItems(1).Text() = "void" Then
                For i As Integer = 0 To ListView_GHF.Items.Count - 1
                    If ListView_GHF.Items(i).SubItems(1).Text.ToLower <> "void" Or ListView_GHF.Items(i).SubItems(1).Text.ToLower <> "voidp" Then
                        If ListView_GHF.Items(ListView_GHF.SelectedIndices(0)).SubItems(2).Text() = ListView_GHF.Items(i).SubItems(2).Text() And ListView_GHF.Items(ListView_GHF.SelectedIndices(0)).SubItems(3).Text() = ListView_GHF.Items(i).SubItems(3).Text() Then
                            ListView_GHF.Items(i).SubItems(7).Text() += CInt(ListView_GHF.Items(ListView_GHF.SelectedIndices(0)).SubItems(7).Text())
                            ListView_GHF.Items(i).SubItems(8).Text() += CDbl(ListView_GHF.Items(ListView_GHF.SelectedIndices(0)).SubItems(8).Text())
                            ListView_GHF.Items(i).SubItems(13).Text() += CDbl(ListView_GHF.Items(ListView_GHF.SelectedIndices(0)).SubItems(13).Text())
                        End If
                    End If
                Next
                ListView_GHF.Items.RemoveAt(ListView_GHF.SelectedIndices.Item(0))
                gohome_list.calsum()
            End If
        End If
    End Sub

    Private Sub btn_up_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_up.Click
        If ListView_GHF.Items.Count > 0 Then
            If ListView_GHF.SelectedItems.Count > 0 Then
                If ListView_GHF.SelectedIndices(0) > 0 Then
                    ListView_GHF.Items.Item(ListView_GHF.SelectedIndices(0) - 1).Selected = True
                    ListView_GHF.Focus()

                End If
            Else
                ListView_GHF.Items.Item(0).Selected = True
                ListView_GHF.Focus()
            End If
            If ListView_GHF.Items(ListView_GHF.SelectedIndices(0)).SubItems(1).Text() = "void" Then
                btn_re.Enabled = True
                btn_cut.Enabled = False
            ElseIf ListView_GHF.Items(ListView_GHF.SelectedIndices(0)).SubItems(1).Text() = "yes" Or ListView_GHF.Items(ListView_GHF.SelectedIndices(0)).SubItems(1).Text() = "no" Then
                btn_re.Enabled = False
                btn_cut.Enabled = True
            End If

        End If
    End Sub

    Private Sub btn_drow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_drow.Click
        If ListView_GHF.Items.Count > 0 Then
            If ListView_GHF.SelectedItems.Count > 0 Then
                If ListView_GHF.SelectedIndices(0) < ListView_GHF.Items.Count - 1 Then
                    ListView_GHF.Items.Item(ListView_GHF.SelectedIndices(0) + 1).Selected = True
                    ListView_GHF.Focus()
                End If
            Else
                ListView_GHF.Items.Item(ListView_GHF.Items.Count - 1).Selected = True
                ListView_GHF.Focus()
            End If

              If ListView_GHF.Items(ListView_GHF.SelectedIndices(0)).SubItems(1).Text() = "void" Then
                btn_re.Enabled = True
                btn_cut.Enabled = False
            ElseIf ListView_GHF.Items(ListView_GHF.SelectedIndices(0)).SubItems(1).Text() = "yes" Or ListView_GHF.Items(ListView_GHF.SelectedIndices(0)).SubItems(1).Text() = "no" Then
                btn_re.Enabled = False
                btn_cut.Enabled = True
            End If

        End If
    End Sub

    Private Sub btn_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_save.Click
        If MessageBox.Show("คุณมั่นใจใช่ไหมที่จะยกเลิกรายการต่างๆ?", "Alert Comfirm Void Order List?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim StrV As String = ""
            Dim dateY As DateTime = Login.DateData.ToString("yyyy-MM-dd") & Date.Now().ToString(" HH:mm:ss")
            'Loop Check IS Data Not Null
            Dim Check_is_value As Integer = 0
            For j As Integer = 0 To ListView_GHF.Items.Count - 1
                If ListView_GHF.Items(j).SubItems(1).Text.ToLower = "void" Then
                    Check_is_value += 1
                End If
            Next
            If Check_is_value > 0 Then
                Dim cf_returnstk As Boolean = False
                Dim qty_new As Integer = 0
                Dim price_all_new As Double = 0.0
                For i As Integer = 0 To ListView_GHF.Items.Count - 1
                    'Check listview find void ?
                    Dim status As String = ListView_GHF.Items(i).SubItems(1).Text
                    Dim id_prd As String = ListView_GHF.Items(i).SubItems(2).Text
                    Dim id_con_prd As String = ListView_GHF.Items(i).SubItems(3).Text
                    If id_con_prd = "" Then
                        id_con_prd = "0"
                    Else
                        id_con_prd = id_con_prd
                    End If
                    Dim name_prd As String = ListView_GHF.Items(i).SubItems(4).Text.Replace("'", "\'")
                    Dim name_prd_en As String = ListView_GHF.Items(i).SubItems(5).Text.Replace("'", "\'")
                    Dim price As Double = ListView_GHF.Items(i).SubItems(8).Text
                    Dim qty1 As Integer = ListView_GHF.Items(i).SubItems(7).Text
                    Dim remark As String = ListView_GHF.Items(i).SubItems(9).Text.Replace("'", "\'")
                    Dim strvoid As String = ""
                    Dim id_cat As String = ListView_GHF.Items(i).SubItems(14).Text.Trim
                    Dim id_subcatprd As String = ListView_GHF.Items(i).SubItems(15).Text.Trim
                    Dim name_cat_en As String = ListView_GHF.Items(i).SubItems(16).Text.Trim
                    Dim name_cat_th As String = ListView_GHF.Items(i).SubItems(17).Text.Trim
                    Dim name_subcat_en As String = ListView_GHF.Items(i).SubItems(18).Text.Trim
                    Dim name_subcat_th As String = ListView_GHF.Items(i).SubItems(19).Text.Trim
                    Dim ord_vat As Integer = ListView_GHF.Items(i).SubItems(20).Text.Trim
                    Dim ord_vat_st As String = ListView_GHF.Items(i).SubItems(21).Text.Trim


                    If status = "void" And CInt(ListView_GHF.Items(i).SubItems(7).Text) > 0 Then
                        'เช็คว่ามีการยกเลิกรายการก่อนหน้านี้หรือยัง
                        Dim l As Integer = con.mysql_num_rows(con.mysql_query("select * from pos_order_list where  rf_id_prd='" & id_prd & "' and rf_id_con='" & id_con_prd & "' and name_ord='" & name_prd & "' and " _
                          & "code_gohome='" & code_gohome & "' and status_open='gohome' and status_sd_captain='void' and rf_id_invoice='" & rf_id_invoice & "' and status_pay='no';"))
                        If l > 0 Then 'มีรายการที่ถูกยกเลิกอยู๋แล้ว

                            StrV &= "UPDATE pos_order_list SETamt=amt+" & qty1 & ",price=price+" & price & " " _
                          & "where rf_id_prd='" & id_prd & "' and rf_id_con='" & id_con_prd & "' and name_ord='" & name_prd & "' and " _
                          & "code_gohome='" & code_gohome & "' and status_open='gohome' and status_sd_captain='void' and rf_id_invoice='" & rf_id_invoice & "' and status_pay='no';"

                        Else

                            StrV &= "UPDATE pos_order_list SET amt=amt-" & qty1 & ",price=price-" & price & " " _
                           & "where rf_id_prd='" & id_prd & "' and rf_id_con='" & id_con_prd & "' and name_ord='" & name_prd & "' and " _
                           & "code_gohome='" & code_gohome & "' and status_open='gohome' and rf_id_invoice='" & rf_id_invoice & "' and status_pay='no';"

                            StrV &= "INSERT INTO pos_order_list (rf_id_prd,rf_id_con,name_ord,name_ord_en,amt,price,prs,rf_id_invoice," _
                                 & "code_gohome,status_sd_captain,status_open,status_pay,remark,create_date,create_by,ref_cat_id," _
                                 & "ref_catsubprd,name_th_cat,name_en_cat,name_th_catsubprd,name_en_catsubprd,ord_vat,ord_vat_st) " _
                                 & " VALUES('" & id_prd & "','" & id_con_prd & "','" & name_prd & "','" & name_prd_en & "','" & qty1 & "','" & price & "'," _
                                 & "'1','" & rf_id_invoice & "','" & code_gohome & "','void'," _
                                 & "'gohome','no','" & remark & "','" & Login.DateData.ToString("yyyy-MM-dd") & Date.Now.ToString(" HH:mm:ss") & "','" & Login.username & "'," _
                                 & "'" & id_cat & "','" & id_subcatprd & "','" & name_cat_th & "'," _
                                 & "'" & name_cat_en & "','" & name_subcat_th & "','" & name_subcat_en & "','" & ord_vat & "','" & ord_vat_st & "');"

                        End If
                    Else
                        qty_new += ListView_GHF.Items(i).SubItems(7).Text
                        price_all_new += ListView_GHF.Items(i).SubItems(8).Text
                    End If
                    If status = "yes" And CInt(ListView_GHF.Items(i).SubItems(7).Text) = 0 Then
                        StrV &= "DELETE FROM pos_order_list WHERE id_ord='" & ListView_GHF.Items(i).SubItems(0).Text & "';"
                    End If
                    If CInt(ListView_GHF.Items(i).SubItems(7).Text) > 0 Then

                        If ListView_GHF.Items(i).SubItems(0).Text.ToLower = "void" Then
                            opentable.returnStock(id_prd, id_con_prd, qty1)

                        End If
                    End If

                Next
                '=== update invoice ===='
                StrV &= "UPDATE pos_invoice_temp SET qty='" & qty_new & "',price_all='" & price_all_new & "',update_by='" & Login.username & "' WHERE id='" & rf_id_invoice & "';"

                'Query Into Database
                Dim qty As Boolean = False

                If StrV <> "" Then
                    qty = con.mysql_query(StrV)
                End If
                If qty = True Then
                    'Print Void 
                    Try
                        Dim array_print As New ArrayList
                        Dim array_idtemp As New ArrayList
                        Dim array_sendcap As New ArrayList
                        Dim array_namecat As New ArrayList
                        array_print.Clear()
                        array_idtemp.Clear()
                        array_sendcap.Clear()
                        array_namecat.Clear()
                        Dim array_countGroup As New ArrayList
                        array_countGroup.Clear()
                        For x As Integer = 0 To ListView_GHF.Items.Count - 1
                            If ListView_GHF.Items(x).SubItems(1).Text().ToLower = "void" Then
                                Dim v As Boolean = False
                                Dim printername_v As String = ""
                                Dim copy2captain As String = ""
                                Dim id_ref_temp As String = ""
                                For u As Integer = 0 To array_countGroup.Count - 1
                                    If ListView_GHF.Items(x).SubItems(15).Text() = array_countGroup(u).ToString Then
                                        v = True
                                    End If
                                Next
                                If v = False Then
                                    array_countGroup.Add(ListView_GHF.Items(x).SubItems(15).Text())
                                    printername_v = opentable.Get_printer(ListView_GHF.Items(x).SubItems(15).Text())
                                    copy2captain = opentable.Get_CopySendcaptain(ListView_GHF.Items(x).SubItems(15).Text())
                                    id_ref_temp = "P" & Login.DateData.ToString("dd") & Login.DateData.ToString("MM") & Login.DateData.ToString("yy") & Format(DateAndTime.Now, "HH") & Format(DateAndTime.Now, "mm") & Format(DateAndTime.Now, "ss") & "0" & x
                                    array_print.Add(printername_v)
                                    array_idtemp.Add(id_ref_temp)
                                    array_sendcap.Add(copy2captain)
                                    array_namecat.Add(ListView_GHF.Items(x).SubItems(16).Text())
                                End If
                            End If
                        Next
                        Dim g As Integer = 1
                        Dim string_q As String = ""
                        For t As Integer = 0 To array_countGroup.Count - 1
                            For n As Integer = 0 To ListView_GHF.Items.Count - 1
                                If ListView_GHF.Items(n).SubItems(1).Text().ToLower = "void" Then
                                    If ListView_GHF.Items(n).SubItems(15).Text() = array_countGroup(t).ToString Then
                                        Dim rf_id_prd As String = ListView_GHF.Items(n).SubItems(2).Text
                                        Dim rf_id_con As String = ListView_GHF.Items(n).SubItems(3).Text
                                        Dim name_ord As String = ListView_GHF.Items(n).SubItems(4).Text.Replace("'", "\'")
                                        Dim name_ord_en As String = ListView_GHF.Items(n).SubItems(5).Text.Replace("'", "\'")
                                        Dim amt As Integer = CInt(ListView_GHF.Items(n).SubItems(7).Text)
                                        Dim price As Double = CDbl(ListView_GHF.Items(n).SubItems(8).Text)
                                        Dim remark As String = ListView_GHF.Items(n).SubItems(9).Text.Replace("'", "\'")
                                        string_q &= "INSERT INTO pos_temp_print (rf_id_prd,rf_id_con,name_ord,name_ord_en,amt,price,prs,rf_id_table,status_sd_captain,status_pay,status_open,remark,create_date,code_gohome,name_cat_en,name_cat_th,id_ref_temp)" _
                                        & " VALUES('" & rf_id_prd & "','" & rf_id_con & "','" & name_ord & "','" & name_ord_en & "'," _
                                        & "'" & amt & "','" & price & "','1','0'," _
                                        & "'void','no','gohome','" & remark & "'," _
                                        & "'" & dateY.ToString("yyyy-MM-dd") & Date.Now.ToString(" HH:mm:ss") & "','" & code_gohome & "','" & ListView_GHF.Items(n).SubItems(16).Text & "','" & ListView_GHF.Items(n).SubItems(17).Text & "','" & array_idtemp(t).ToString & "');"
                                        g += 1
                                    End If
                                End If
                            Next
                        Next

                        If string_q <> "" Then
                            con.mysql_query(string_q)
                        End If
                        For h As Integer = 0 To array_countGroup.Count - 1
                            'Print Void Order
                            Dim WorkerThread As Thread
                            Dim W As New worker
                            Thread.Sleep(1000)
                            W.setSendCaptainCancel("0", "gohome", code_gohome, dateY.ToString("dd/MM/yyyy"), code_gohome, Login.username, array_print(h).ToString, array_idtemp(h).ToString)
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
                        gohome_list.s2(rf_id_invoice) '==load data show =='
                        Me.Close()
                    Catch ex As Exception
                        MessageBox.Show(ex.Message.ToString())
                    End Try
                Else
                    MessageBox.Show("Error Void Order List!", "Message Alert Show")
                End If
            Else
                MessageBox.Show("ไม่มีข้อมูลในการอัพเดต", "Message Alert Show")
            End If
        End If
    End Sub

    Private Sub btn_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_close.Click
        Me.Close()
    End Sub

    Private Sub ListView_GHF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView_GHF.Click
        If ListView_GHF.Items(ListView_GHF.SelectedIndices(0)).SubItems(1).Text() = "void" Then
            btn_re.Enabled = True
            btn_cut.Enabled = False
        ElseIf ListView_GHF.Items(ListView_GHF.SelectedIndices(0)).SubItems(1).Text() = "yes" Or ListView_GHF.Items(ListView_GHF.SelectedIndices(0)).SubItems(1).Text() = "no" Then
            btn_re.Enabled = False
            btn_cut.Enabled = True
        End If

    End Sub

End Class