Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Windows.Forms
Imports System.IO
Imports System.Text
Imports Excel = Microsoft.Office.Interop.Excel
Public Class Export
    Dim con As New Mysql
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox2.Text <> "" And DateTimePicker1.Text <> "" Then
            If TextBox2.Text = "admin87" And DateTimePicker1.Text <> "" Then
                Dim date1 As String = ""
                If CInt(DateTimePicker1.Value.ToString("yyyy")) > 2450 Then
                    date1 = CInt(DateTimePicker1.Value.ToString("yyyy")) - 543 & "-" & DateTimePicker1.Value.ToString("MM-dd")
                Else
                    date1 = DateTimePicker1.Value.ToString("yyyy-MM-dd")
                End If
                If date1 <> "" Then
                    s(date1)
                    'Dim startP As DateTime = New DateTime(2018, 2, 1)
                    'Dim endP As DateTime = New DateTime(2018, 8, 29)
                    'Dim CurrD As DateTime = startP

                    'While (CurrD <= endP)
                    '    ' ProcessData(CurrD)
                    '    s(CurrD.ToString("yyyy-MM-dd"))
                    '    Console.WriteLine(CurrD.ToShortDateString)
                    '    CurrD = CurrD.AddDays(1)
                    'End While

                End If
            Else
                MsgBox("Admin Code Error..")
            End If
        Else
            MsgBox("กรอกรหัส Admin Code หรือ วันที่ ด้วยค่ะ")
        End If
    End Sub
    Public Sub s(ByVal c)
        ' Try
        Dim xlApp As Excel.Application = New Microsoft.Office.Interop.Excel.Application()
        If xlApp Is Nothing Then
            MessageBox.Show("Excel is not properly installed!!")
            Return
        End If
        'Get data For insert Datasheet
        Dim dnew As Date = c
        If CInt(dnew.ToString("yyyy")) > 2450 Then
            dnew = (CInt(dnew.ToString("yyyy")) - 543) & dnew.ToString("-MM-dd")
        Else
            dnew = dnew.ToString("yyyy-MM-dd")
        End If
        'MsgBox(c & ":=" & dnew)
        Dim resLoad As MySqlDataReader =
        con.mysql_query("SELECT  IFNULL(pos_invoice.namber_inv,'-') as namber_inv, IFNULL(pos_payment_type.name,'-') AS namePayType," _
        & " IFNULL(pos_invoice.price_all,'0') AS sumprice," _
        & "IFNULL(pos_invoice.discount_des,'-') AS discount_des, IFNULL(pos_invoice.void,'-') AS void," _
        & "IFNULL(pos_invoice.number_pos,'-') as number_pos,IFNULL(pos_invoice.qty,'0') as qty_inv,IFNULL(pos_invoice.price_all,'0') as price_all_inv," _
        & "IFNULL(pos_invoice.create_by,'-') as create_by,IFNULL(pos_invoice.update_by,'-') as update_by,IFNULL(pos_invoice.create_date,'0000-00-00') as create_date," _
        & "IFNULL(pos_invoice.update_date,'0000-00-00') as update_date,IFNULL(pos_invoice.machin_number,'-') as machin_number," _
        & "IFNULL(pos_invoice.rf_payment_type,'-') as id_payment_type,IFNULL(pos_invoice.des_payment,'-') AS des_payment," _
        & "IFNULL(pos_invoice.vat,'0') as vat_inv,IFNULL(pos_invoice.serviceCh,'0') as serviceCh_inv," _
        & "IFNULL(pos_invoice.discount_sum,'0') as discount_sum,IFNULL(pos_invoice.rf_id_card,'-') as rf_id_card," _
        & "IFNULL(pos_invoice.money_recript,'0') as money_recript,IFNULL(pos_invoice.money_ton,'0') as money_ton,IFNULL(pos_invoice.void,'-') as void," _
        & "IFNULL(pos_invoice.close_rop_id_inv,'-') as close_rop_id_inv,IFNULL(pos_invoice.close_rop_name_inv,'-') as close_rop_name_inv," _
        & "IFNULL(pos_invoice.close_day_inv,'-') AS close_day_inv,IFNULL(pos_closebilldetail.crf_id_prd,'-') as crf_id_prd," _
        & "IFNULL(pos_product_size.name_th,'none') as name_size," _
        & "IFNULL(pos_closebilldetail.cname_ord,'none') as name_prd,IFNULL(pos_closebilldetail.camt,'0') as cqty," _
        & "IFNULL(pos_closebilldetail.cprice,'0.0') as cprice,IFNULL(pos_closebilldetail.cprs,'0') as cprs,IFNULL(pos_table_system.number,'-') as number_tb," _
        & "IFNULL(pos_closebilldetail.c_vat,'-') as c_vat,IFNULL(pos_closebilldetail.c_vat_st,'-') as c_vat_st," _
        & "IFNULL(pos_closebilldetail.c_vat_sum,'0') as c_vat_sum,IFNULL(pos_closebilldetail.c_amount,'0') as c_amount," _
        & "IFNULL(pos_closebilldetail.c_net_amount,'0.0') as c_net_amount,IFNULL(pos_closebilldetail.cremark,'-') as cremark," _
        & "IFNULL(pos_closebilldetail.cstatus,'-') as cstatus,IFNULL(pos_closebilldetail.ccode_gohome,'-') as ccode_gohome," _
        & "IFNULL(pos_closebilldetail.ctryNumber,'none') as ctryNumber,IFNULL(pos_closebilldetail.close_day_action,'none') as close_day_action" _
        & ",IFNULL(pos_audit.id_ropbill_aud,'0') as id_ropbill_aud,IFNULL(pos_closebilldetail.c_id_cat,'0') as id_cat,IFNULL(pos_closebilldetail.c_name_cat_en,'-') as namecat_en, " _
        & "IFNULL(pos_closebilldetail.c_name_cat_th,'-') as namecat_th,IFNULL(pos_closebilldetail.crf_id_table,'0') as crf_id_table" _
        & ",IFNULL(pos_table_location.id,'0') as idLocation,IFNULL(pos_table_location.name_th,'Take Home') as name_th_location " _
        & ",IFNULL(pos_closebilldetail.c_discount,'0') as c_discount,IFNULL(pos_closebilldetail.c_discount_sum,'0') as c_discount_sum,IFNULL(pos_closebilldetail.c_discount_type,'0') as c_discount_type " _
        & ",IFNULL(pos_closebilldetail.c_id_subcat,'0') as c_id_subcat,IFNULL(pos_closebilldetail.c_name_subcat_en,'-') as c_name_subcat_en,IFNULL(pos_closebilldetail.c_name_subcat_th,'-') as c_name_subcat_th" _
        & "  FROM   pos_invoice INNER JOIN pos_closebilldetail ON pos_closebilldetail.crf_id_invoice = pos_invoice.id " _
        & " LEFT JOIN pos_payment_type ON pos_payment_type.id = pos_invoice.rf_payment_type " _
        & " LEFT JOIN pos_product_condition ON  pos_product_condition.id =  pos_closebilldetail.crf_id_con " _
        & " LEFT JOIN pos_table_system ON  pos_table_system.id = pos_closebilldetail.crf_id_table" _
        & " LEFT JOIN pos_product_size ON  pos_product_size.id=pos_product_condition.ref_id_size " _
        & " LEFT JOIN pos_audit ON  pos_audit.id_aud=pos_invoice.close_rop_id_inv " _
        & " LEFT JOIN pos_product ON  pos_product.id=pos_closebilldetail.crf_id_prd " _
        & " LEFT JOIN pos_catprd ON  pos_catprd.id=pos_product.ref__id_catprd " _
         & " LEFT JOIN pos_table_location ON  pos_table_location.id=pos_table_system.ref_id_location " _
        & " WHERE pos_closebilldetail.close_day='" & c & "' and pos_closebilldetail.cstatus<>'void' order by namber_inv ASC ")


        Dim name_res As MySqlDataReader = con.mysql_query("SELECT * FROM pos_shop")
        name_res.Read()
        Dim name_shop As String = name_res.GetString("name_onfront")
        name_res.Close()


        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet
        Dim misValue As Object = System.Reflection.Missing.Value

        xlWorkBook = xlApp.Workbooks.Add(misValue)
        xlWorkSheet = xlWorkBook.Sheets("sheet1")
        Dim i As Integer = 2
        xlWorkSheet.Cells(1, 1) = "namber_inv"
        xlWorkSheet.Cells(1, 2) = "number_pos"
        xlWorkSheet.Cells(1, 3) = "sumprice"
        xlWorkSheet.Cells(1, 4) = "qty_inv"
        xlWorkSheet.Cells(1, 5) = "create_by"
        xlWorkSheet.Cells(1, 6) = "create_date"
        xlWorkSheet.Cells(1, 7) = "update_date"
        xlWorkSheet.Cells(1, 8) = "machin_number"
        xlWorkSheet.Cells(1, 9) = "id_payment_type"
        xlWorkSheet.Cells(1, 10) = "namePayType"
        xlWorkSheet.Cells(1, 11) = "des_payment"
        xlWorkSheet.Cells(1, 12) = "vat_inv"
        xlWorkSheet.Cells(1, 13) = "serviceCh_inv"
        xlWorkSheet.Cells(1, 14) = "discount_sum"
        xlWorkSheet.Cells(1, 15) = "discount_des"
        xlWorkSheet.Cells(1, 16) = "rf_id_card"
        xlWorkSheet.Cells(1, 17) = "money_recript"
        xlWorkSheet.Cells(1, 18) = "money_ton"
        xlWorkSheet.Cells(1, 19) = "void"
        xlWorkSheet.Cells(1, 20) = "close_rop_id_inv"
        xlWorkSheet.Cells(1, 21) = "close_rop_name_inv"
        xlWorkSheet.Cells(1, 22) = "close_day_inv"
        xlWorkSheet.Cells(1, 23) = "crf_id_prd"
        xlWorkSheet.Cells(1, 24) = "name_size"
        xlWorkSheet.Cells(1, 25) = "name_prd"
        xlWorkSheet.Cells(1, 26) = "cqty"
        xlWorkSheet.Cells(1, 27) = "cprice"
        xlWorkSheet.Cells(1, 28) = "cprs"
        xlWorkSheet.Cells(1, 29) = "number_tb"
        xlWorkSheet.Cells(1, 30) = "c_vat"
        xlWorkSheet.Cells(1, 31) = "c_vat_st"
        xlWorkSheet.Cells(1, 32) = "c_vat_sum"
        xlWorkSheet.Cells(1, 33) = "c_amount"
        xlWorkSheet.Cells(1, 34) = "c_net_amount"
        xlWorkSheet.Cells(1, 35) = "cremark"
        xlWorkSheet.Cells(1, 36) = "cstatus"
        xlWorkSheet.Cells(1, 37) = "ccode_gohome"
        xlWorkSheet.Cells(1, 38) = "ctryNumber"
        xlWorkSheet.Cells(1, 39) = "close_day_action"
        xlWorkSheet.Cells(1, 40) = "Close rop ที่"
        xlWorkSheet.Cells(1, 41) = "Id group"
        xlWorkSheet.Cells(1, 42) = "Name group"
        xlWorkSheet.Cells(1, 43) = "Id location"
        xlWorkSheet.Cells(1, 44) = "Name location"
        xlWorkSheet.Cells(1, 45) = "Name shop"
        xlWorkSheet.Cells(1, 46) = "ส่วนลดรายตัว"
        xlWorkSheet.Cells(1, 47) = "รวมส่วนลดรายตัว"
        xlWorkSheet.Cells(1, 48) = "ประเภทส่วนลดรายตัว"
        xlWorkSheet.Cells(1, 49) = "Id_SubGroup"
        xlWorkSheet.Cells(1, 50) = "Name Subgroup TH"
        xlWorkSheet.Cells(1, 51) = "Name Subgroup EN"
        While resLoad.Read()
            Dim c_amount As Double = 0.0
            Dim c_vat_sum As Double = 0.0
            Dim c_net_amount As Double = FormatNumber((CDbl(resLoad.GetString("c_amount")) + CDbl(resLoad.GetString("c_vat_sum"))) - CDbl(resLoad.GetString("c_discount_sum")), 2)
            If resLoad.GetString("c_vat_st") = "1" Then
                c_amount = (c_net_amount * 100) / (100 + CDbl(resLoad.GetString("c_vat")))
                c_vat_sum = c_net_amount - ((c_net_amount * 100) / (100 + resLoad.GetString("c_vat")))
            ElseIf resLoad.GetString("c_vat_st") = "2" Then
                c_amount = c_net_amount
                c_vat_sum = c_net_amount * (CDbl(resLoad.GetString("c_vat") / 100))
            Else
                c_amount = c_net_amount
                c_vat_sum = 0
            End If
            '  MsgBox(c_amount & ":" & c_vat_sum)
            xlWorkSheet.Cells(i, 1) = resLoad.GetString("namber_inv")
            xlWorkSheet.Cells(i, 2) = resLoad.GetString("number_pos")
            xlWorkSheet.Cells(i, 3) = resLoad.GetString("sumprice")
            xlWorkSheet.Cells(i, 4) = resLoad.GetString("qty_inv")
            xlWorkSheet.Cells(i, 5) = resLoad.GetString("create_by")
            xlWorkSheet.Cells(i, 6) = resLoad.GetString("create_date")
            xlWorkSheet.Cells(i, 7) = resLoad.GetString("update_date")
            xlWorkSheet.Cells(i, 8) = resLoad.GetString("machin_number")
            xlWorkSheet.Cells(i, 9) = resLoad.GetString("id_payment_type")
            xlWorkSheet.Cells(i, 10) = resLoad.GetString("namePayType")
            xlWorkSheet.Cells(i, 11) = resLoad.GetString("des_payment")
            xlWorkSheet.Cells(i, 12) = resLoad.GetString("vat_inv")
            xlWorkSheet.Cells(i, 13) = resLoad.GetString("serviceCh_inv")
            xlWorkSheet.Cells(i, 14) = resLoad.GetString("discount_sum")
            xlWorkSheet.Cells(i, 15) = resLoad.GetString("discount_des")
            xlWorkSheet.Cells(i, 16) = resLoad.GetString("rf_id_card")
            xlWorkSheet.Cells(i, 17) = resLoad.GetString("money_recript")
            xlWorkSheet.Cells(i, 18) = resLoad.GetString("money_ton")
            xlWorkSheet.Cells(i, 19) = resLoad.GetString("void")
            xlWorkSheet.Cells(i, 20) = resLoad.GetString("close_rop_id_inv")
            xlWorkSheet.Cells(i, 21) = resLoad.GetString("close_rop_name_inv")
            xlWorkSheet.Cells(i, 22) = resLoad.GetString("close_day_inv")
            xlWorkSheet.Cells(i, 23) = resLoad.GetString("crf_id_prd")
            xlWorkSheet.Cells(i, 24) = resLoad.GetString("name_size")
            xlWorkSheet.Cells(i, 25) = resLoad.GetString("name_prd")
            xlWorkSheet.Cells(i, 26) = resLoad.GetString("cqty")
            xlWorkSheet.Cells(i, 27) = resLoad.GetString("cprice")
            xlWorkSheet.Cells(i, 28) = resLoad.GetString("cprs")
            xlWorkSheet.Cells(i, 29) = resLoad.GetString("number_tb")
            xlWorkSheet.Cells(i, 30) = resLoad.GetString("c_vat")
            xlWorkSheet.Cells(i, 31) = resLoad.GetString("c_vat_st")
            xlWorkSheet.Cells(i, 32) = FormatNumber(c_vat_sum, 2)
            xlWorkSheet.Cells(i, 33) = FormatNumber(c_amount, 2)
            xlWorkSheet.Cells(i, 34) = FormatNumber((CDbl(resLoad.GetString("c_amount")) + CDbl(resLoad.GetString("c_vat_sum"))) - CDbl(resLoad.GetString("c_discount_sum")), 2)
            xlWorkSheet.Cells(i, 35) = resLoad.GetString("cremark")
            xlWorkSheet.Cells(i, 36) = resLoad.GetString("cstatus")
            xlWorkSheet.Cells(i, 37) = resLoad.GetString("ccode_gohome")
            xlWorkSheet.Cells(i, 38) = resLoad.GetString("ctryNumber")
            xlWorkSheet.Cells(i, 39) = resLoad.GetString("close_day_action")
            xlWorkSheet.Cells(i, 40) = resLoad.GetString("id_ropbill_aud")
            xlWorkSheet.Cells(i, 41) = resLoad.GetString("id_cat")
            xlWorkSheet.Cells(i, 42) = resLoad.GetString("namecat_th")
            xlWorkSheet.Cells(i, 43) = resLoad.GetString("idLocation")
            xlWorkSheet.Cells(i, 44) = resLoad.GetString("name_th_location")
            xlWorkSheet.Cells(i, 45) = name_shop
            xlWorkSheet.Cells(i, 46) = FormatNumber(resLoad.GetString("c_discount"), 2)
            xlWorkSheet.Cells(i, 47) = FormatNumber(resLoad.GetString("c_discount_sum"), 2)
            xlWorkSheet.Cells(i, 48) = resLoad.GetString("c_discount_type")
            xlWorkSheet.Cells(i, 49) = resLoad.GetString("c_id_subcat")
            xlWorkSheet.Cells(i, 50) = resLoad.GetString("c_name_subcat_th")
            xlWorkSheet.Cells(i, 51) = resLoad.GetString("c_name_subcat_en")

            i += 1
        End While
        'Get Folder SAVEExcel
        Dim folderExpport As String = ""
        Dim objReader As New System.IO.StreamReader("active_fol.bat", Encoding.UTF8)
        Dim TextLine() As String
        Do While objReader.Peek() <> -1
            TextLine = objReader.ReadLine().ToString.Trim.Split("=")
            If TextLine(0).ToString.Trim = "folderExcel" Then
                folderExpport = TextLine(1).ToString.Trim
            End If
        Loop
        objReader.Close()

        Dim NameFile As String = CDate(c).ToString("yy-MM-dd")
        '===== delete file ===='
        Dim FileToDelete As String
        FileToDelete = folderExpport & "\" & NameFile & ".xls"
        If System.IO.File.Exists(FileToDelete) = True Then
            System.IO.File.Delete(FileToDelete)
            ' MsgBox("File Deleted")
        End If
        'MsgBox(folderExpport & "\" & NameFile & ".xls")
        xlWorkBook.SaveAs(folderExpport & "\" & NameFile & ".xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, _
         Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue)
        xlWorkBook.Close(True, misValue, misValue)
        xlApp.Quit()

        releaseObject(xlWorkSheet)
        releaseObject(xlWorkBook)
        releaseObject(xlApp)
        MessageBox.Show("Excel file created , you can find the file " & folderExpport & "\" & NameFile & ".xls")
        ' Catch ex As Exception
        'MessageBox.Show(ex.Message)
        'End Try
    End Sub

    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            If TextBox2.Text <> "" And DateTimePicker1.Text <> "" Then
                If DateTimePicker1.Text <> "" And TextBox2.Text = "admin1987" Or TextBox2.Text = "admin123!@#" Or TextBox2.Text = "admin87" Or TextBox2.Text = "adminadmin" Or TextBox2.Text = "nukaiang" Or TextBox2.Text = "nitchakan" Then
                    Dim date1 As String = ""
                    If CInt(DateTimePicker1.Value.ToString("yyyy")) > 2450 Then
                        date1 = CInt(DateTimePicker1.Value.ToString("yyyy")) - 543 & "-" & DateTimePicker1.Value.ToString("MM-dd")
                    Else
                        date1 = DateTimePicker1.Value.ToString("yyyy-MM-dd")
                    End If
                    If date1 <> "" Then
                        s(date1)
                    End If
                Else
                    MsgBox("รหัสผ่านไม่ถูกต้องค่ะ")

                End If
            Else
                MsgBox("กรอกรหัส Admin Code หรือ วันที่ ด้วยค่ะ")
            End If
        End If
    End Sub


End Class