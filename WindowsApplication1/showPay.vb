Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Windows.Forms
Imports System.ComponentModel
Imports System.Threading
Imports Microsoft.Win32
Imports System.IO
Imports System.Text

Public Class showPay
    Private _worker As BackgroundWorker
    Public invoice_number As String
    Public recript_m As Double
    Public ton_m As Double
    Public printer_payment As String = ""
    Public user As String = ""
    Dim con As New Mysql
    Dim con_front As New MysqlFront
    Dim print As New printClass
    Public StringTabs As String
    Public page As String = "home1"
    Dim create_by As String = ""
    Public paytype As Integer = 0
    Public ihno As String = ""
    Public Ref_Invoice As String = ""
    Private Sub showPay_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If paytype = 3 Then
            Try
                Dim str1 As String = ""
                Dim fh_pos_id As String = ""
                Dim count_res_ihfolio As Integer = con_front.mysql_num_rows(con_front.mysql_query("SELECT fh_no FROM front_inhouse_folio WHERE fh_ihno='" & ihno & "' ORDER BY fh_no DESC LIMIT 1"))
                Dim ihno1 As Integer = 0
                If count_res_ihfolio > 0 Then
                    Dim res_ihfolio As MySqlDataReader = con_front.mysql_query("SELECT fh_no FROM front_inhouse_folio WHERE fh_ihno='" & ihno & "' ORDER BY fh_no DESC LIMIT 1")
                    res_ihfolio.Read()
                    ihno1 = CInt(res_ihfolio.GetString("fh_no")) + 1
                End If
                If ihno.Contains("MH") Then
                    Dim c As MySqlDataReader = con_front.mysql_query("SELECT IFNULL(fh_pos_id,'-') AS fh_pos_id FROM front_inhouse_folio WHERE fh_ihno='" & ihno & "' AND fh_cate_name='' AND fh_transection_ref='02' ORDER BY fh_pos_id DESC LIMIT 1")
                    While c.Read()
                        fh_pos_id = c.GetString("fh_pos_id")
                        If fh_pos_id = "-" Then
                            Dim b As MySqlDataReader = con_front.mysql_query("SELECT IFNULL(fh_pos_id,'-') AS fh_pos_id FROM front_inhouse_folio WHERE fh_ihno='" & ihno & "' AND fh_modify_by='POS' AND fh_cate_name='' AND fh_transection_ref='95' ORDER BY fh_pos_id DESC LIMIT 1")
                            While b.Read()
                                fh_pos_id = b.GetString("fh_pos_id")
                                If fh_pos_id = "-" Then
                                    Dim a As MySqlDataReader = con_front.mysql_query("SELECT IFNULL(fh_pos_id,'-') FROM front_inhouse_folio WHERE fh_ihno LIKE 'MH%' ORDER BY fh_pos_id DESC LIMIT 1")
                                    While a.Read()
                                        fh_pos_id = a.GetString("fh_pos_id")
                                        If fh_pos_id = "" Or fh_pos_id = "-" Then
                                            fh_pos_id = ""
                                        Else
                                            fh_pos_id.Replace("MH", "")
                                            fh_pos_id = "MH" & (CInt(fh_pos_id) + 1).ToString("000000")
                                        End If
                                    End While
                                End If
                            End While
                        End If
                    End While
                End If

                Dim res_det As MySqlDataReader = con.mysql_query("SELECT * FROM pos_closebilldetail WHERE crf_id_invoice='" & invoice_number & "' and cstatus<>'void' order by id_close ASC")
                While res_det.Read()
                    Dim id_close As String = res_det.GetString("id_close")
                    Dim d As DateTime
                    If CInt(res_det.GetDateTime("ccreate_date").ToString("yyyy")) > 2450 Then
                        d = CInt(res_det.GetDateTime("ccreate_date").ToString("yyyy")) - 543 & res_det.GetDateTime("ccreate_date").ToString("-MM-dd HH:mm:ss")
                    Else
                        d = res_det.GetDateTime("ccreate_date").ToString("yyyy-MM-dd HH:mm:ss")
                    End If
                    Dim c_amount As Double = 0.0
                    Dim c_vat_sum As Double = 0.0
                    Dim c_net_amount As Double = FormatNumber(CDbl(res_det.GetString("c_net_amount")) - CDbl(res_det.GetString("c_discount_sum")), 2)
                    If res_det.GetString("c_vat_st") = "1" Or res_det.GetString("c_vat_st") = "2" Then
                        c_amount = FormatNumber((c_net_amount * 100) / (100 + CDbl(res_det.GetString("c_vat"))), 2)
                        c_vat_sum = FormatNumber(c_net_amount * CInt(res_det.GetString("c_vat")) / (100 + res_det.GetString("c_vat")), 2)
                    Else
                        c_amount = FormatNumber(c_net_amount, 2)
                        c_vat_sum = 0.0
                    End If


                    ihno1 += 1
                    str1 &= "INSERT INTO front_inhouse_folio (fh_ihno,fh_gof,fh_no,fh_date,fh_transection,fh_qty,fh_amount," _
                        & "fh_vat,fh_vattype,fh_type,fh_dc,fh_remark,fh_lock,fh_void,fh_ref,fh_modify_by,fh_transection_ref,fh_pos_id) VALUES('" & ihno & "'," _
                        & "'1','" & ihno1 & "','" & d.ToString("yyyy-MM-dd HH:mm:ss") & "','" & res_det.GetString("cname_ord") & "'," _
                        & "'" & res_det.GetString("camt") & "','" & c_amount & "','" & c_vat_sum & "'," _
                        & "'" & res_det.GetString("c_vat_st") & "','','Credit','" & res_det.GetString("cremark") & "','2','1','" & Ref_Invoice & "-" & id_close & "','POS','95','" & fh_pos_id & "');"

                End While
                ' UPDATE Discount Bill
                Dim check_discount_bill As Integer = con.mysql_num_rows(con.mysql_query("select * from pos_invoice where discount_sum>0 and namber_inv='" & Ref_Invoice & "';"))
                If check_discount_bill > 0 Then
                    Dim qty_bill As MySqlDataReader = con.mysql_query("select * from pos_invoice where namber_inv='" & Ref_Invoice & "';")
                    While qty_bill.Read()
                        str1 &= "INSERT INTO front_inhouse_folio (fh_ihno,fh_gof,fh_no,fh_date,fh_transection,fh_qty,fh_amount," _
                        & "fh_vat,fh_vattype,fh_type,fh_dc,fh_remark,fh_lock,fh_void,fh_ref,fh_modify_by,fh_transection_ref,fh_pos_id) VALUES('" & ihno & "'," _
                        & "'1','" & ihno1 + 1 & "','" & qty_bill.GetDateTime("create_date").ToString("yyyy-MM-dd HH:mm:ss") & "','POS-Discount-Bill-" & Ref_Invoice & "'," _
                        & "'0','" & qty_bill.GetString("discount_sum") & "','0'," _
                        & "'0','','Debit','" & qty_bill.GetString("discount") & "(" & qty_bill.GetString("discount_des") & ")" & "','2','1','" & Ref_Invoice & "-DisBill" & "','POS','95','" & fh_pos_id & "');"
                    End While
                End If
                ' TextBox1.Text = str1
                If str1 <> "" Then
                    con_front.mysql_query(str1)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If

    End Sub
    Private Sub btn_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_close.Click
        index.Gohome = False
        Login.OpenId = ""
        payment.payment_cl = False
        index.ReservationP = False
        payment.Close()
        If page = "gohome_list" Then
            index.CloseForm()
            gohome_list.MdiParent = index
            gohome_list.Show()
            gohome_list.WindowState = FormWindowState.Minimized
            gohome_list.WindowState = FormWindowState.Maximized
            Login.Formname = "gohome_list"
        Else
            index.CloseForm()
            index.ishomeopen = True
            home1.MdiParent = index
            home1.Show()
            home1.WindowState = FormWindowState.Minimized
            home1.WindowState = FormWindowState.Maximized
            Login.Formname = "home1"
        End If
        payment.Btn_Enter.Enabled = True
        payment_gohome.code_gohome = ""
        payment_gohome.ihno = ""
        payment.ihno = ""
        Me.Close()
    End Sub

    Public invoice_number_print As String = ""
    Public recript_m_print As String = ""
    Public ton_m_print As String = ""
    Public switch_lang As String = Login.LangG

    Private Sub btn_print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_print.Click

        If shv.Checked = True Then
            'startLoadData() 'Print Payment In Worker 
            If Login.dialog_switchLangPrintPayment = 1 Then
                switch_langprint.page = "showPay"
                switch_langprint.ShowDialog()
            End If
            
            invoice_number_print = invoice_number
            recript_m_print = recript_m
            ton_m_print = ton_m
            user = Login.username
            printer_payment = Login.printer_payment
            switch_lang = switch_lang

            BackgroundWorker1.RunWorkerAsync()
            print.OpenCashDrawer()
        End If
        If shv_not.Checked = True Then
            'startLoadData1() 'Print Payment In Worker no show vat
            If Login.dialog_switchLangPrintPayment = 1 Then
                switch_langprint.page = "showPay"
                switch_langprint.ShowDialog()
            End If
            invoice_number_print = invoice_number
            recript_m_print = recript_m
            ton_m_print = ton_m
            user = Login.username
            printer_payment = Login.printer_payment
            switch_lang = switch_lang
            BackgroundWorker2.RunWorkerAsync()
            print.OpenCashDrawer()
        End If

        index.ReservationP = False
        Login.OpenId = ""
        index.Gohome = False
        'Return Values Parameters
        invoice_number = ""
        recript_m = 0
        ton_m = 0
        If page = "gohome_list" Then
            payment_gohome.Ref_Invoice = ""
            gohome_list.MdiParent = index
            gohome_list.Show()
            gohome_list.WindowState = FormWindowState.Minimized
            gohome_list.WindowState = FormWindowState.Maximized
            Login.Formname = "gohome_list"
            payment_gohome.payment_cl = False
            payment_gohome.Btn_Enter.Enabled = True
            payment_gohome.code_gohome = ""
            payment_gohome.ihno = ""
            payment_gohome.Close()
        Else
            payment.Ref_Invoice = ""
            index.ishomeopen = True
            home1.MdiParent = index
            home1.Show()
            home1.WindowState = FormWindowState.Minimized
            home1.WindowState = FormWindowState.Maximized
            Login.Formname = "home1"
            payment.payment_cl = False
            payment.Btn_Enter.Enabled = True
            payment.ihno = ""
            payment.Close()
        End If
        Me.Close()

    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        ' MsgBox(invoice_number_print)
        print.PrintPayment(invoice_number_print, recript_m_print, ton_m_print, user, "payment", printer_payment, switch_lang)
    End Sub
    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        ' print.ReDefalutPrint()
        Dim name_p As String = ""
        Dim objReader As New System.IO.StreamReader("printer.txt", Encoding.UTF8)
        Dim TextLine() As String
        Do While objReader.Peek() <> -1
            TextLine = objReader.ReadLine().ToString.Trim.Split("=")
            If "rpt_front" = TextLine(0).ToString.Trim Then
                name_p = TextLine(1).ToString
            End If
        Loop
        objReader.Close()
        objReader.Dispose()
        print.setDefalutPrint(name_p)
    End Sub

    Private Sub BackgroundWorker2_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker2.DoWork
        print.PrintPayment(invoice_number_print, recript_m_print, ton_m_print, user, "payment_noShow_vat", printer_payment, switch_lang)
    End Sub
    Private Sub BackgroundWorker2_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker2.RunWorkerCompleted
        '  print.ReDefalutPrint()
        Dim name_p As String = ""
        Dim objReader As New System.IO.StreamReader("printer.txt", Encoding.UTF8)
        Dim TextLine() As String
        Do While objReader.Peek() <> -1
            TextLine = objReader.ReadLine().ToString.Trim.Split("=")
            If "rpt_front" = TextLine(0).ToString.Trim Then
                name_p = TextLine(1).ToString
            End If
        Loop
        objReader.Close()
        objReader.Dispose()
        print.setDefalutPrint(name_p)
    End Sub

End Class