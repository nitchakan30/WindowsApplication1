Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Imports System.Text
Imports System.Threading
Public Class form_reprint_captain
    Dim con As New Mysql
    Dim print As New printClass
    Public LangPrintSendCaptain1 As String = Login.LangG
    Private Sub form_reprint_captain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Load_Product_list()
    End Sub
    Private Sub Load_Product_list()
        DataGridView1.Rows.Clear()
        Dim size_n As String
        Dim rf_id_con As String

        Dim str1 As String = "SELECT pos_order_list.id_ord AS id_ord,pos_order_list.status_sd_captain AS status_sd_captain," _
        & "pos_order_list.rf_id_prd AS rf_id_prd,pos_order_list.rf_id_con As rf_id_con,pos_order_list.name_ord AS name_ord," _
        & "pos_order_list.name_ord_en AS name_ord_en," _
         & "pos_order_list.prs AS prs,pos_order_list.remark AS remark,pos_order_list.ref_id_join AS ref_id_join," _
        & "SUM(pos_order_list.amt) AS samt,SUM(pos_order_list.price) AS sprice,pos_table_system.id AS idTb,IFNULL(pos_product_size.name_th,0) AS name_size," _
        & "pos_order_list.ref_cat_id as ref_cat_id,pos_order_list.ref_catsubprd as ref_catsubprd,pos_order_list.name_th_cat as name_th_cat,pos_order_list.name_en_cat as name_en_cat," _
        & "pos_order_list.name_th_catsubprd as name_th_catsubprd,pos_order_list.name_en_catsubprd as name_en_catsubprd,pos_order_list.ord_vat as ord_vat,pos_order_list.ord_vat_st as ord_vat_st" _
        & ",IFNULL(un.name_th,'') as name_unit" _
        & " FROM pos_order_list  INNER JOIN pos_table_system ON pos_table_system.id=pos_order_list.rf_id_table " _
         & " LEFT JOIN pos_product_condition ON pos_order_list.rf_id_con =  pos_product_condition.id " _
         & " LEFT JOIN pos_product_ingredients ON pos_product_ingredients.id  =  pos_product_condition.ref_id_ingredients" _
         & " LEFT JOIN pos_product_size ON pos_product_size.id =  pos_product_condition.ref_id_size" _
         & " LEFT JOIN pos_product_unit un ON un.id =  pos_product_condition.ref_id_unit" _
        & " WHERE  pos_order_list.status_pay='no' and (pos_order_list.create_date LIKE '%" & Login.DateData.ToString("yyyy-MM-dd") & "%') and pos_order_list.status_sd_captain<>'void' and " _
        & "pos_order_list.status_open<>'gohome' and (pos_order_list.rf_id_table='" & Login.OpenId & "' or pos_order_list.ref_id_join='" & Login.OpenId & "')" _
        & " GROUP BY pos_order_list.rf_id_prd,pos_order_list.rf_id_con,pos_order_list.name_ord order by id_ord asc"

        'TextBox1.Text = str1
        Dim dt As MySqlDataReader = con.mysql_query(str1)
        While dt.Read
            If dt.GetString("rf_id_con") <> "0" Then
                rf_id_con = dt.GetString("rf_id_con")
            Else
                rf_id_con = ""
            End If
            If dt.GetString("name_size") <> "0" Or dt.GetString("name_unit") <> "" Then
                If dt.GetString("name_size") <> "0" Then
                    size_n = dt.GetString("name_size")
                Else
                    size_n = dt.GetString("name_unit")
                End If
            Else
                size_n = ""
            End If
            Dim n As Integer = DataGridView1.Rows.Add()
            DataGridView1.Rows.Item(n).Cells(1).Value = dt.GetString("status_sd_captain")
            DataGridView1.Rows.Item(n).Cells(2).Value = dt.GetString("id_ord")
            DataGridView1.Rows.Item(n).Cells(3).Value = dt.GetString("rf_id_prd")
            DataGridView1.Rows.Item(n).Cells(4).Value = rf_id_con
            DataGridView1.Rows.Item(n).Cells(5).Value = dt.GetString("name_ord")
            DataGridView1.Rows.Item(n).Cells(6).Value = dt.GetString("name_ord_en")
            DataGridView1.Rows.Item(n).Cells(7).Value = size_n
            DataGridView1.Rows.Item(n).Cells(8).Value = dt.GetString("samt")
            DataGridView1.Rows.Item(n).Cells(9).Value = dt.GetDecimal("sprice").ToString("#,##0.00")
            DataGridView1.Rows.Item(n).Cells(10).Value = dt.GetString("remark")
            DataGridView1.Rows.Item(n).Cells(11).Value = dt.GetString("ref_cat_id")
            DataGridView1.Rows.Item(n).Cells(12).Value = dt.GetString("ref_catsubprd")
            DataGridView1.Rows.Item(n).Cells(13).Value = dt.GetString("name_th_cat")
            DataGridView1.Rows.Item(n).Cells(14).Value = dt.GetString("name_en_cat")
            DataGridView1.Rows.Item(n).Cells(15).Value = dt.GetString("name_th_catsubprd")
            DataGridView1.Rows.Item(n).Cells(16).Value = dt.GetString("name_en_catsubprd")
            DataGridView1.Rows.Item(n).Cells(17).Value = dt.GetString("ord_vat")
            DataGridView1.Rows.Item(n).Cells(18).Value = dt.GetString("ord_vat_st")
            DataGridView1.Rows.Item(n).Cells(19).Value = dt.GetString("samt")
            If dt.GetString("status_sd_captain").ToLower = "yes" Then
                DataGridView1.Rows.Item(n).DefaultCellStyle.ForeColor = Color.Green
            Else
                DataGridView1.Rows.Item(n).DefaultCellStyle.ForeColor = Color.Black
            End If
        End While
        dt.Close()
        'Query Void Order list
      
        Dim dt_void As MySqlDataReader = con.mysql_query("SELECT pos_order_list.id_ord AS id_ord,pos_order_list.status_sd_captain AS status_sd_captain," _
       & "pos_order_list.rf_id_prd AS rf_id_prd,pos_order_list.rf_id_con As rf_id_con,pos_order_list.name_ord AS name_ord," _
       & "pos_order_list.name_ord_en AS name_ord_en," _
       & "pos_order_list.prs AS prs,pos_order_list.remark AS remark,pos_order_list.ref_id_join AS ref_id_join," _
       & "SUM(pos_order_list.amt) AS samt,SUM(pos_order_list.price) AS sprice,pos_table_system.id AS idTb,IFNULL(pos_product_size.name_th,0) AS name_size," _
       & "pos_order_list.ref_cat_id as ref_cat_id,pos_order_list.ref_catsubprd as ref_catsubprd,pos_order_list.name_th_cat as name_th_cat,pos_order_list.name_en_cat as name_en_cat," _
       & "pos_order_list.name_th_catsubprd as name_th_catsubprd,pos_order_list.name_en_catsubprd as name_en_catsubprd,pos_order_list.ord_vat as ord_vat,pos_order_list.ord_vat_st as ord_vat_st" _
       & ",IFNULL(un.name_th,'') as name_unit" _
       & "  FROM pos_order_list  INNER JOIN pos_table_system ON pos_table_system.id=pos_order_list.rf_id_table " _
       & " LEFT JOIN pos_product_condition ON pos_order_list.rf_id_con =  pos_product_condition.id " _
       & " LEFT JOIN pos_product_ingredients ON pos_product_ingredients.id  =  pos_product_condition.ref_id_ingredients" _
       & " LEFT JOIN pos_product_size ON pos_product_size.id =  pos_product_condition.ref_id_size" _
        & " LEFT JOIN pos_product_unit un ON un.id =  pos_product_condition.ref_id_unit" _
       & " WHERE  pos_order_list.status_pay='no' and  pos_order_list.status_sd_captain='void' and pos_order_list.status_open<>'gohome' and (pos_order_list.rf_id_table='" & Login.OpenId & "' or pos_order_list.ref_id_join='" & Login.OpenId & "') and " _
       & " DAY(pos_order_list.create_date)='" & Login.DateData.ToString("dd") & "' and MONTH(pos_order_list.create_date)='" & Login.DateData.ToString("MM") & "' and YEAR(pos_order_list.create_date)='" & Login.DateData.ToString("yyyy") & "' " _
       & " GROUP BY pos_order_list.rf_id_prd,pos_order_list.rf_id_con,pos_order_list.name_ord order by id_ord asc")

        While dt_void.Read
            If dt_void.GetString("rf_id_con") <> "0" Then
                rf_id_con = dt_void.GetString("rf_id_con")
            Else
                rf_id_con = ""
            End If
            If dt_void.GetString("name_size") <> "0" Or dt_void.GetString("name_unit") <> "" Then
                If dt_void.GetString("name_size") <> "0" Then
                    size_n = dt_void.GetString("name_size")
                Else
                    size_n = dt_void.GetString("name_unit")
                End If
            Else
                size_n = ""
            End If
            Dim n As Integer = DataGridView1.Rows.Add()
            DataGridView1.Rows.Item(n).Cells(1).Value = "voidp"
            DataGridView1.Rows.Item(n).Cells(2).Value = dt_void.GetString("id_ord")
            DataGridView1.Rows.Item(n).Cells(3).Value = dt_void.GetString("rf_id_prd")
            DataGridView1.Rows.Item(n).Cells(4).Value = rf_id_con
            DataGridView1.Rows.Item(n).Cells(5).Value = dt_void.GetString("name_ord")
            DataGridView1.Rows.Item(n).Cells(6).Value = dt_void.GetString("name_ord_en")
            DataGridView1.Rows.Item(n).Cells(7).Value = size_n
            DataGridView1.Rows.Item(n).Cells(8).Value = dt_void.GetString("samt")
            DataGridView1.Rows.Item(n).Cells(9).Value = dt_void.GetDecimal("sprice").ToString("#,##0.00")
            DataGridView1.Rows.Item(n).Cells(10).Value = dt_void.GetString("remark")
            DataGridView1.Rows.Item(n).Cells(11).Value = dt_void.GetString("ref_cat_id")
            DataGridView1.Rows.Item(n).Cells(12).Value = dt_void.GetString("ref_catsubprd")
            DataGridView1.Rows.Item(n).Cells(13).Value = dt_void.GetString("name_th_cat")
            DataGridView1.Rows.Item(n).Cells(14).Value = dt_void.GetString("name_en_cat")
            DataGridView1.Rows.Item(n).Cells(15).Value = dt_void.GetString("name_th_catsubprd")
            DataGridView1.Rows.Item(n).Cells(16).Value = dt_void.GetString("name_en_catsubprd")
            DataGridView1.Rows.Item(n).Cells(17).Value = dt_void.GetString("ord_vat")
            DataGridView1.Rows.Item(n).Cells(18).Value = dt_void.GetString("ord_vat_st")
            DataGridView1.Rows.Item(n).Cells(19).Value = dt_void.GetString("samt")

            DataGridView1.Rows.Item(n).DefaultCellStyle.ForeColor = Color.Red
        End While
        dt_void.Close()
    End Sub
    Private Sub btn_move_right_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim message As String = String.Empty
        For Each row As DataGridViewRow In DataGridView1.Rows
            Dim isSelected As Boolean = Convert.ToBoolean(row.Cells(0).Value)
            If isSelected = True Then
                Dim c As String = row.Cells(1).Value.ToString()
            End If
        Next
    End Sub

    Private Sub btn_up_left_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_up_left.Click
        Try

            If DataGridView1.RowCount > 0 Then

                Dim MyDesiredIndex As Integer = 0

                If DataGridView1.CurrentRow.Index < DataGridView1.RowCount - 1 Then
                    MyDesiredIndex = DataGridView1.CurrentRow.Index - 1
                ElseIf DataGridView1.CurrentRow.Index = DataGridView1.RowCount - 1 Then
                    MyDesiredIndex = DataGridView1.CurrentRow.Index - 1
                ElseIf DataGridView1.CurrentRow.Index > DataGridView1.RowCount - 1 Then
                    MyDesiredIndex = DataGridView1.CurrentRow.Index + 1
                End If
                If DataGridView1.CurrentRow.Index = 0 Then
                Else
                    DataGridView1.ClearSelection()
                    DataGridView1.CurrentCell = DataGridView1.Rows(MyDesiredIndex).Cells(0)
                    DataGridView1.Rows(MyDesiredIndex).Selected = True
                End If
            End If


        Catch ex As Exception
            MessageBox.Show("Please contact Admin.! -" & ex.Message)
        End Try
    End Sub

    Private Sub btn_drow_left_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_drow_left.Click
        Try

            If DataGridView1.RowCount > 0 Then

                Dim MyDesiredIndex As Integer = 0

                If DataGridView1.CurrentRow.Index < DataGridView1.RowCount - 1 Then
                    MyDesiredIndex = DataGridView1.CurrentRow.Index + 1
                ElseIf DataGridView1.CurrentRow.Index = DataGridView1.RowCount - 1 Then
                    MyDesiredIndex = DataGridView1.RowCount
                ElseIf DataGridView1.CurrentRow.Index > DataGridView1.RowCount - 1 Then
                    MyDesiredIndex = DataGridView1.CurrentRow.Index - 1
                End If
                If DataGridView1.CurrentRow.Index = DataGridView1.RowCount - 1 Then
                    ' DataGridView1.CurrentCell = DataGridView1.Rows(DataGridView1.RowCount).Cells(0)
                Else
                    DataGridView1.ClearSelection()
                    DataGridView1.CurrentCell = DataGridView1.Rows(MyDesiredIndex).Cells(0)
                    DataGridView1.Rows(MyDesiredIndex).Selected = True
                End If


            End If
        Catch ex As Exception
            MessageBox.Show("Please contact Admin.! -" & ex.Message)
        End Try
    End Sub

    Private Sub btn_print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_print.Click
        Try
            Dim Is_itemCheck As Boolean = False
            For Each row1 As DataGridViewRow In DataGridView1.Rows
                Dim isSelected As Boolean = Convert.ToBoolean(row1.Cells(0).Value)
                If isSelected = True Then
                    Is_itemCheck = True
                End If
            Next
            If Is_itemCheck = True Then
                Dim result As Integer
                If Login.LangG = "TH" Then
                    result = MessageBox.Show("คุณมั่นใจใช่ไหมพิมพ์ส่งครัวใหม่หรือไหม?", "ยืนยันการพิมพ์ส่งครัวใหม่", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                Else
                    result = MessageBox.Show("Are You Sure Print Send Captain?", "Confirm Print Send Captain", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                End If
                If result = DialogResult.Yes Then

                    If Login.switchLangPrintCaptain = 1 Then
                        switch_langprint.page = "form_reprint_captain"
                        switch_langprint.ShowDialog()
                    End If

                    Dim dateNew As DateTime = Login.DateData.ToString("yyyy-MM-dd ") & Date.Now().ToString("HH:mm:ss")
                    Dim insert_temp_v As String = ""
                    Dim str_update_send As String = ""
                    '==== status yes 0r no ==='
                    Dim array_print As New ArrayList
                    Dim array_idtemp As New ArrayList
                    Dim array_sendcap As New ArrayList
                    Dim array_namecat As New ArrayList
                    Dim array_countGroup As New ArrayList
                    Dim array_print_onoff As New ArrayList
                    array_print.Clear()
                    array_idtemp.Clear()
                    array_sendcap.Clear()
                    array_namecat.Clear()
                    array_countGroup.Clear()
                    array_print_onoff.Clear()
                    '==== status void ==='
                    Dim array_print_void As New ArrayList
                    Dim array_idtemp_void As New ArrayList
                    Dim array_sendcap_void As New ArrayList
                    Dim array_namecat_void As New ArrayList
                    Dim array_countGroup_void As New ArrayList
                    Dim array_print_onoff_void As New ArrayList
                    array_print_void.Clear()
                    array_idtemp_void.Clear()
                    array_sendcap_void.Clear()
                    array_namecat_void.Clear()
                    array_countGroup_void.Clear()
                    array_print_onoff.Clear()
                    Dim g As Integer = 1
                    Dim str_temp As String = ""
                    For Each row As DataGridViewRow In DataGridView1.Rows
                        Dim isSelected As Boolean = Convert.ToBoolean(row.Cells(0).Value)
                        If isSelected = True Then
                            If row.Cells(1).Value.ToString.ToLower = "yes" Or row.Cells(1).Value.ToString.ToLower = "no" Then
                                Dim v As Boolean = False
                                For u As Integer = 0 To array_print.Count - 1
                                    If opentable.Get_printer_subgroup(row.Cells(12).Value.ToString()) = array_print(u).ToString Then
                                        v = True
                                    End If
                                Next
                                If v = False Then
                                    array_print.Add(opentable.Get_printer_subgroup(row.Cells(12).Value.ToString()))
                                    Dim printername As String = opentable.Get_printer_subgroup(row.Cells(12).Value.ToString())
                                    Dim copy2captain As String = opentable.Get_CopySendcaptain_subgroup(row.Cells(12).Value.ToString())
                                    Dim print_onoff As String = opentable.Get_printer_ONOFF_subgroup(row.Cells(12).Value.ToString())
                                    Dim id_ref_temp As String = ""
                                    id_ref_temp = "P" & Login.DateData.ToString("dd") & Login.DateData.ToString("MM") & Login.DateData.ToString("yy") & Format(DateAndTime.Now, "HH") & Format(DateAndTime.Now, "mm") & Format(DateAndTime.Now, "ss") & "0" & g
                                    array_countGroup.Add(row.Cells(12).Value.ToString())
                                    array_idtemp.Add(id_ref_temp)
                                    array_sendcap.Add(copy2captain)
                                    array_namecat.Add(row.Cells(14).Value.ToString())
                                    array_print_onoff.Add(print_onoff)
                                End If
                            ElseIf row.Cells(1).Value.ToString.ToLower = "void" Or row.Cells(1).Value.ToString.ToLower = "voidp" Then
                                Dim v As Boolean = False
                                For u As Integer = 0 To array_print_void.Count - 1
                                    If opentable.Get_printer_subgroup(row.Cells(12).Value.ToString()) = array_print_void(u).ToString Then
                                        v = True
                                    End If
                                Next
                                If v = False Then
                                    array_print_void.Add(opentable.Get_printer_subgroup(row.Cells(12).Value.ToString()))
                                    Dim printername_void As String = opentable.Get_printer_subgroup(row.Cells(12).Value.ToString())
                                    Dim copy2captain_void As String = opentable.Get_CopySendcaptain_subgroup(row.Cells(12).Value.ToString())
                                    Dim print_onoff_void As String = opentable.Get_printer_ONOFF_subgroup(row.Cells(12).Value.ToString())
                                    Dim id_ref_temp_void As String = ""
                                    id_ref_temp_void = "P" & Login.DateData.ToString("dd") & Login.DateData.ToString("MM") & Login.DateData.ToString("yy") & Format(DateAndTime.Now, "HH") & Format(DateAndTime.Now, "mm") & Format(DateAndTime.Now, "ss") & "0" & g
                                    array_countGroup_void.Add(row.Cells(12).Value.ToString())
                                    array_idtemp_void.Add(id_ref_temp_void)
                                    array_sendcap_void.Add(copy2captain_void)
                                    array_namecat_void.Add(row.Cells(14).Value.ToString())
                                    array_print_onoff_void.Add(print_onoff_void)
                                End If
                            End If
                            g += 1
                        End If
                    Next
                    '=== check order = group after insert temp print==='
                    For t As Integer = 0 To array_print.Count - 1
                        For j As Integer = 0 To DataGridView1.RowCount - 1
                            Dim isSelected As Boolean = Convert.ToBoolean(DataGridView1.Rows(j).Cells(0).Value)
                            If isSelected = True Then
                                Dim rf_id_prd As String = DataGridView1.Rows(j).Cells(3).Value.ToString()
                                Dim rf_id_con As String = DataGridView1.Rows(j).Cells(4).Value.ToString()
                                Dim name_ord As String = DataGridView1.Rows(j).Cells(5).Value.ToString().Replace("'", "\'")
                                Dim name_ord_en As String = DataGridView1.Rows(j).Cells(6).Value.ToString().Replace("'", "\'")
                                Dim samt As Integer = DataGridView1.Rows(j).Cells(8).Value.ToString()
                                Dim price As Double = DataGridView1.Rows(j).Cells(9).Value.ToString()
                                Dim remark As String = DataGridView1.Rows(j).Cells(10).Value.ToString().Replace("'", "\'")
                                If DataGridView1.Rows(j).Cells(1).Value.ToString.ToLower = "yes" Or DataGridView1.Rows(j).Cells(1).Value.ToString.ToLower = "no" Then
                                    If array_print(t).ToString = opentable.Get_printer_subgroup(CStr(DataGridView1.Rows(j).Cells(12).Value.ToString())) Then
                                        str_temp &= "INSERT INTO pos_temp_print (rf_id_prd,rf_id_con,name_ord,name_ord_en,amt,price,rf_id_table," _
                                         & "status_sd_captain,status_pay,status_open,remark,create_date,code_gohome,name_cat_en," _
                                        & "name_cat_th,id_ref_temp)" _
                                        & " VALUES('" & rf_id_prd & "','" & rf_id_con & "','" & name_ord & "','" & name_ord_en & "'," _
                                        & "'" & samt & "','" & price & "','" & Login.OpenId & "'," _
                                        & "'yes','no','ontb','" & remark & "'," _
                                        & "'" & dateNew.ToString("yyyy-MM-dd HH:mm:ss") & "','0','" & DataGridView1.Rows(j).Cells(14).Value.ToString() & "','" & DataGridView1.Rows(j).Cells(13).Value.ToString() & "','" & array_idtemp(t).ToString & "');"
                                        If DataGridView1.Rows(j).Cells(1).Value.ToString.ToLower = "no" Then
                                            str_temp &= "UPDATE pos_order_list SET status_sd_captain='yes' Where status_sd_captain='no' and status_pay='no' and (rf_id_table='" & Login.OpenId & "' or ref_id_join='" & Login.OpenId & "');"
                                        End If
                                    End If
                                End If
                            End If
                        Next
                    Next
                    If array_print_void.Count > 0 Then
                        For m As Integer = 0 To array_print_void.Count - 1
                            For j As Integer = 0 To DataGridView1.RowCount - 1
                                Dim isSelected As Boolean = Convert.ToBoolean(DataGridView1.Rows(j).Cells(0).Value)
                                If isSelected = True Then
                                    Dim rf_id_prd As String = DataGridView1.Rows(j).Cells(3).Value.ToString()
                                    Dim rf_id_con As String = DataGridView1.Rows(j).Cells(4).Value.ToString()
                                    Dim name_ord As String = DataGridView1.Rows(j).Cells(5).Value.ToString().Replace("'", "\'")
                                    Dim name_ord_en As String = DataGridView1.Rows(j).Cells(6).Value.ToString().Replace("'", "\'")
                                    Dim samt As Integer = DataGridView1.Rows(j).Cells(8).Value.ToString()
                                    Dim price As Double = DataGridView1.Rows(j).Cells(9).Value.ToString()
                                    Dim remark As String = DataGridView1.Rows(j).Cells(10).Value.ToString().Replace("'", "\'")
                                    If DataGridView1.Rows(j).Cells(1).Value.ToString.ToLower = "void" Or DataGridView1.Rows(j).Cells(1).Value.ToString.ToLower = "voidp" Then
                                        If array_print_void(m).ToString = opentable.Get_printer_subgroup(DataGridView1.Rows(j).Cells(12).Value.ToString()) Then
                                            str_temp &= "INSERT INTO pos_temp_print (rf_id_prd,rf_id_con,name_ord,name_ord_en,amt,price,rf_id_table," _
                                             & "status_sd_captain,status_pay,status_open,remark,create_date,code_gohome,name_cat_en," _
                                            & "name_cat_th,id_ref_temp)" _
                                            & " VALUES('" & rf_id_prd & "','" & rf_id_con & "','" & name_ord & "','" & name_ord_en & "'," _
                                            & "'" & samt & "','" & price & "','" & Login.OpenId & "'," _
                                            & "'void','no','ontb','" & remark & "'," _
                                            & "'" & dateNew.ToString("yyyy-MM-dd HH:mm:ss") & "','0','" & DataGridView1.Rows(j).Cells(14).Value.ToString() & "','" & DataGridView1.Rows(j).Cells(13).Value.ToString() & "','" & array_idtemp_void(m).ToString & "');"
                                        End If
                                    End If
                                End If
                            Next
                        Next
                    End If
                    Dim q As Boolean = False
                    If str_temp <> "" Then
                        q = con.mysql_query(str_temp)
                    End If

                    If q = True Then
                        '==== print yes 0r no ==='
                        For y As Integer = 0 To array_print.Count - 1

                            If array_print_onoff(y) <> "0" Or array_print_onoff(y) <> 0 Then

                                Dim WorkerThread As Thread
                                Dim W As New worker
                                W.setSendCaptain(Login.OpenId, "ontb", index.getNameTable(Login.OpenId), dateNew.ToString("dd/MM/yyyy"), "0", Login.username, array_print(y).ToString, array_idtemp(y).ToString, array_sendcap(y).ToString, LangPrintSendCaptain1)
                                WorkerThread = New Thread(AddressOf W.Start)    'Create our Worker thread and tell it that when we start it it should call our Worker's Start() method
                                WorkerThread.Start()
                                WorkerThread.Join()

                                If Login.alert_sendcaptain = 1 Or Login.alert_sendcaptain = "1" Then
                                    If Login.LangG = "TH" Then
                                        dialog_complete.Label_Dialog.Text = "ส่งรายการ " & array_namecat(y).ToString & " เรียบร้อยแล้วค่ะ"
                                        dialog_complete.ShowDialog()
                                    Else
                                        dialog_complete.Label_Dialog.Text = "Send order " & array_namecat(y).ToString & " Complete."
                                        dialog_complete.ShowDialog()
                                    End If
                                End If
                            End If
                        Next
                        '==== print void ==='
                        If array_print_void.Count > 0 Then

                            For h As Integer = 0 To array_print_void.Count - 1
                                If array_print_onoff_void(h) <> "0" Or array_print_onoff_void(h) <> 0 Then
                                    Dim WorkerThread As Thread
                                    Dim W As New worker
                                    W.setSendCaptainCancel(Login.OpenId, "ontb", index.getNameTable(Login.OpenId), dateNew.ToString("dd/MM/yyyy"), "0", Login.username, array_print_void(h).ToString, array_idtemp_void(h).ToString)
                                    WorkerThread = New Thread(AddressOf W.Start)    'Create our Worker thread and tell it that when we start it it should call our Worker's Start() method
                                    WorkerThread.Start()
                                    WorkerThread.Join()

                                    If Login.alert_sendcaptain = 1 Or Login.alert_sendcaptain = "1" Then
                                        If Login.LangG = "TH" Then
                                            dialog_complete.Label_Dialog.Text = "ส่งรายการยกเลิก " & array_namecat_void(h).ToString & " เรียบร้อยแล้วค่ะ"
                                            dialog_complete.ShowDialog()

                                        Else
                                            dialog_complete.Label_Dialog.Text = "Send Cancel order " & array_namecat_void(h).ToString & " Complete."
                                            dialog_complete.ShowDialog()
                                        End If
                                    End If
                                End If
                            Next
                        End If


                    End If


                End If
            Else
                MessageBox.Show("Please Check Item For Print.!", "Alert Check Item", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString())
        End Try
    End Sub
    Private Sub DataGridView1_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        If e.ColumnIndex = 8 Then
            If IsNumeric(DataGridView1.Rows.Item(i).Cells(8).Value) Then
                If CInt(DataGridView1.Rows.Item(i).Cells(8).Value) > CInt(DataGridView1.Rows.Item(i).Cells(19).Value) Or CInt(DataGridView1.Rows.Item(i).Cells(8).Value) <= 0 Then
                    MsgBox("จำนวที่จะพิมพ์มากกว่าจำนวนรายการเดิม กรุณาทำรายการให้ถูกต้องค่ะ.")
                    DataGridView1.Rows.Item(i).Cells(8).Value = DataGridView1.Rows.Item(i).Cells(19).Value
                End If
            Else
                DataGridView1.Rows.Item(i).Cells(8).Value = DataGridView1.Rows.Item(i).Cells(19).Value
            End If
        End If
    End Sub
    Private Sub btn_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_close.Click
        Me.Close()
    End Sub
    Private Sub btn_tick_left_all_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_tick_left_all.Click
        If btn_tick_left_all.Text = "Select All" Then
            Dim i As Integer = 0
            For i = 0 To DataGridView1.RowCount - 1
                DataGridView1.Rows(i).Cells(0).Value = True
            Next
            btn_tick_left_all.Text = "UnSelect All"
        Else
            Dim j As Integer = 0
            For j = 0 To DataGridView1.RowCount - 1
                DataGridView1.Rows(j).Cells(0).Value = False
            Next
            btn_tick_left_all.Text = "Select All"
        End If
    End Sub
    Private Sub btn_tick_left_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_tick_left.Click
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        If DataGridView1.Rows.Item(i).Cells(0).Value = True Then
            DataGridView1.Rows(i).Cells(0).Value = False
        Else
            DataGridView1.Rows(i).Cells(0).Value = True
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs)

    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs)

    End Sub
End Class