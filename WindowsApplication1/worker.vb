Imports System.Threading
Imports System.Text.RegularExpressions
Imports System.Text
Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Windows.Forms
Imports System.IO
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Net
Imports System.Globalization

Public Class worker
    Private _invnum As Integer = 0
    Private _recM As Double = 0.0
    Private _tonM As Double = 0.0
    Private _user As String = ""
    Private _status_open As String = ""
    Private _ID_TB As Integer = 0
    Private _NameTb As String = ""
    Private _date_send As Date
    Private _CodeGoHome As String = ""
    Private _printername As String = ""
    Private _id_ref_temp As String = ""
    Private _copy2captain As String = ""
    Private _printer_trybill As String = ""
    Private _printer_bill As String = ""
    Private type As String = ""
    Private _onoff_print_g As Integer = 0
    Private _LangPrint As String = ""
    Private conn As New Mysql
    Dim print As New printClass
    Dim res As MySqlDataReader

    Friend ReadOnly Property invnum() As Integer
        Get
            Return Me._invnum
        End Get
    End Property
    Friend ReadOnly Property recM() As Double
        Get
            Return Me._recM
        End Get
    End Property
    Friend ReadOnly Property tonM() As Double
        Get
            Return Me._tonM
        End Get
    End Property

    Friend Sub setPayment(ByVal inv, ByVal rec, ByVal ton, ByVal user, ByVal printer1)
        _invnum = inv
        _recM = rec
        _tonM = ton
        _user = user
        _printer_bill = printer1
        type = "payment"
    End Sub
    Friend Sub setPaymentVoid(ByVal inv, ByVal user, ByVal printer1)
        _invnum = inv
        _user = user
        _printer_bill = printer1
        type = "payment_void"
    End Sub
    Friend Sub setPayment_novat(ByVal inv, ByVal rec, ByVal ton, ByVal user, ByVal printer1)
        _invnum = inv
        _recM = rec
        _tonM = ton
        _user = user
        _printer_bill = printer1
        type = "payment_notvat"
    End Sub
    Friend Sub setlongbill(ByVal id_bill, ByVal user, ByVal printer)
        _invnum = id_bill
        _user = user
        _printer_trybill = printer
        type = "longbill"
    End Sub
    Friend Sub setlongbill_novat(ByVal id_bill, ByVal user, ByVal printer)
        _invnum = id_bill
        _user = user
        _printer_trybill = printer
        type = "longbill_novat"
    End Sub
    Friend Sub setSendCaptain(ByVal ID_TB, ByVal status_open, ByVal NameTb, ByVal date1, ByVal CodeGoHome, ByVal user, ByVal printername, ByVal id_ref_temp, ByVal copy2captain, ByVal LangPrint)
        _ID_TB = ID_TB
        _status_open = status_open
        _NameTb = NameTb
        _date_send = date1
        _CodeGoHome = CodeGoHome
        _copy2captain = copy2captain
        _printername = printername
        _id_ref_temp = id_ref_temp
        _user = user
        ' _onoff_print_g = id_cat
        type = "sendcaptain"
        _LangPrint = LangPrint
    End Sub
    Friend Sub setSendCaptainCancel(ByVal ID_TB, ByVal status_open, ByVal NameTb, ByVal date1, ByVal CodeGoHome, ByVal user, ByVal printername, ByVal id_ref_temp)
        _ID_TB = ID_TB
        _status_open = status_open
        _NameTb = NameTb
        _date_send = date1
        _CodeGoHome = CodeGoHome
        _printername = printername
        _id_ref_temp = id_ref_temp
        _user = user
        type = "sendcaptaincancel"
    End Sub
    Friend Sub Start()
        If type = "payment" Then
            print.PrintPayment(_invnum, _recM, _tonM, _user, "payment", _printer_bill, _LangPrint) 'Print Bill Payment
        ElseIf type = "longbill" Then
            print.PrintTryBill(_invnum, _user, "vat", _printer_trybill, _LangPrint)
        ElseIf type = "sendcaptain" Then
            print.PrintSendCaptain(_ID_TB, _status_open, _NameTb, _date_send, _CodeGoHome, _user, _printername, _id_ref_temp, _copy2captain, _LangPrint)
        ElseIf type = "sendcaptaincancel" Then
            print.PrintSendCaptainCancel(_ID_TB, _status_open, _NameTb, _date_send, _CodeGoHome, _user, _printername, _id_ref_temp)
        ElseIf type = "payment_notvat" Then
            print.PrintPayment(_invnum, _recM, _tonM, _user, "payment_notvat", _printer_bill, _LangPrint) 'Print Bill Payment
        ElseIf type = "longbill_novat" Then
            print.PrintTryBill(_invnum, _user, "novat", _printer_trybill, _LangPrint)
        ElseIf type = "payment_void" Then
            print.PrintPaymentVoid(_invnum, "0", "0", _user, _printer_bill) 'Print Bill Payment
        End If
    End Sub

End Class

Public Class worker_closebill
    Private _id As String = ""
    Private _name As String = ""
    Private _Money_CloseRop As String = ""
    Private _date As DateTime
    Private _user As String = ""
    Private _getMacAddress As String = ""
    Private _run As Integer = 0
    Private _msg As String = ""
    Private con As New Mysql
    Dim print As New printClass
    Dim res As MySqlDataReader

    Friend Property id() As String
        Set(ByVal id As String)
            _id = id
        End Set
        Get
            Return Me._id
        End Get
    End Property
    Friend Property name() As String
        Set(ByVal name As String)
            _name = name
        End Set
        Get
            Return Me._name
        End Get
    End Property
    Friend Property Money_CloseRop() As String
        Set(ByVal Money_CloseRop As String)
            _Money_CloseRop = Money_CloseRop
        End Set
        Get
            Return Me._Money_CloseRop
        End Get
    End Property
    Friend Property setdate() As DateTime
        Set(ByVal sdate As DateTime)
            _date = sdate
        End Set
        Get
            Return Me._date
        End Get
    End Property
    Friend Property user() As String
        Set(ByVal user As String)
            _user = user
        End Set
        Get
            Return Me._user
        End Get
    End Property
    Friend Property getMacAddress() As String
        Set(ByVal getMacAddress As String)
            _getMacAddress = getMacAddress
        End Set
        Get
            Return Me._getMacAddress
        End Get
    End Property
    Friend ReadOnly Property run() As Integer
        Get
            Return Me._run
        End Get
    End Property
    Friend ReadOnly Property msg() As String
        Get
            Return Me._msg
        End Get
    End Property

    Friend Sub Start()
        Dim sql_insert As String = ""
        'แปลงวันที่ก่อนนำเข้าฐานข้อมูล
        Dim c_date As DateTime = _date.ToString("yyyy-MM-dd HH:mm:ss")
        Dim c_dateNew As String
        Dim ccdate_new As DateTime
        If CInt(c_date.ToString("yyyy")) > 2450 Then
            c_dateNew = CInt(c_date.ToString("yyyy")) - 543
        Else
            c_dateNew = CInt(c_date.ToString("yyyy"))
        End If
        ccdate_new = c_dateNew & "-" & c_date.ToString("MM-dd") & " " & Date.Now.ToString("HH:mm:ss")
        sql_insert &= "UPDATE pos_closebilldetail SET rf_id_closebill='" & _id & "',name_closebill='" & _name & "',machine_closedetail='" & _getMacAddress & "' WHERE rf_id_closebill='0' and name_closebill='0' and close_day='0000-00-00' and " _
                & "DAY(ccreate_date)='" & ccdate_new.ToString("dd") & "' and MONTH(ccreate_date)='" & ccdate_new.ToString("MM") & "' and YEAR(ccreate_date)='" & ccdate_new.ToString("yyyy") & "'; "
        sql_insert &= "UPDATE pos_invoice SET close_rop_id_inv='" & _id & "',close_rop_name_inv='" & _name & "' WHERE DAY(create_date)='" & ccdate_new.ToString("dd") & "' and MONTH(create_date)='" & ccdate_new.ToString("MM") & "' and YEAR(create_date)='" & ccdate_new.ToString("yyyy") & "' and close_rop_id_inv='0' and close_day_inv='0000-00-00'; "
        Dim qty As Boolean
        'Dim del_order As Boolean
        qty = con.mysql_query(sql_insert)
        _run = 1
        _msg = "Loading.."
        'del_order = con.mysql_query("DELETE FROM pos_order_list WHERE rf_id_invoice<>'0'")          
        If qty = True Then
            con.mysql_query("UPDATE pos_audit SET type_aud='1',action_by_aud='" & _user & "',money_closerop='" & _Money_CloseRop & "' WHERE id_aud='" & _id & "'") 'SET UPDATE ROPBIL
            ' con.mysql_query("UPDATE pos_audit SET type_aud='1',action_by_aud='" & _user & "',money_closerop='" & _Money_CloseRop & "' WHERE type_aud='0' and  DAY(rop_date_aud)='" & ccdate_new.ToString("dd") & "' and MONTH(rop_date_aud)='" & ccdate_new.ToString("MM") & "' and YEAR(rop_date_aud)='" & ccdate_new.ToString("yyyy") & "';") 'SET UPDATE ROPBIL

        Else
            _msg = "Error ไม่มีข้อมูลในการปิดรอบ"
            con.mysql_query("UPDATE pos_audit SET type_aud='1',action_by_aud='" & _user & "',money_closerop='0.0' WHERE id_aud='" & _id & "'") 'SET UPDATE ROPBILL
            ' con.mysql_query("UPDATE pos_audit SET type_aud='1',action_by_aud='" & _user & "',money_closerop='" & _Money_CloseRop & "' WHERE type_aud='0' and  DAY(rop_date_aud)='" & ccdate_new.ToString("dd") & "' and MONTH(rop_date_aud)='" & ccdate_new.ToString("MM") & "' and YEAR(rop_date_aud)='" & ccdate_new.ToString("yyyy") & "';") 'SET UPDATE ROPBIL
        End If
        _run = 2
        _msg = "Complete " & name & "."

        'Print Inventory
        If CheckPrintInventory() = True Then
            print.PrintInventory()
            _msg = "Print Inventory..."
        End If
        ' Print Summary Check Rop
        Dim d As Date = _date
        Dim StrCaltype = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Control Panel\International", "iCalendarType", Nothing)
        If StrCaltype = 7 Then
            If _date.Year < 2450 Then
                d = DateAdd(DateInterval.Year, 543, CDate(_date))
            End If
        Else
            If _date.Year > 2450 Then
                d = DateAdd(DateInterval.Year, -543, CDate(_date))
            End If
        End If

        If CheckPrintcloserop() = True Then
            print.PrintPaymentRopClose(d, _user, _id)
            _msg = "Print Close Rop..."
            ' print.ReDefalutPrint()
        End If

        If CheckPrintcloseropsummary() = True Then
            print.PrintPaymentSummaryRopClose(d, _user, _id)
            _msg = "Print Close Rop Summary..."
            'print.ReDefalutPrint()
        End If
        _run = 3
        _msg = "Print Complete."

        'hb.Enabled = False
        'Confirm_CloseDay(ccdate_new.ToString("dd/MM/yyyy"))
        'OpenLoginNew()
    End Sub
    Private Sub pingPrinter(ByVal printerName As String)
        Dim moReturn As Management.ManagementObjectCollection
        Dim moSearch As Management.ManagementObjectSearcher
        Dim mo As Management.ManagementObject
        '"SELECT * FROM Win32_Printer "
        moSearch = New Management.ManagementObjectSearcher("SELECT * FROM Win32_Printer  Where DriverName ='" & printerName & "'")
        moReturn = moSearch.Get
        Dim strOut As String = ""
        For Each mo In moReturn
            strOut = mo("PortName")
            ' = String.Format("Name {0} Port {1} Desc{2}", mo("Name"), )
            ' Trace.WriteLine(strOut)
            'MsgBox(strOut)
        Next
        'MsgBox(strOut

        Dim ip_ping As String = ""
        Dim objReader As New System.IO.StreamReader("ping.txt", Encoding.UTF8)
        Dim TextLine() As String
        Do While objReader.Peek() <> -1
            TextLine = objReader.ReadLine().ToString.Trim.Split("=")
            If "ip" = TextLine(0).ToString.Trim Then
                ip_ping = TextLine(1).ToString
                My.Computer.Network.Ping(ip_ping, 500)
            End If
        Loop
        objReader.Close()
        objReader.Dispose()
    End Sub
    Public Function CheckPrintcloserop()
        'โหลดข้อมูล Tabspage1
        Dim g As Boolean = False
        Dim objReader As New System.IO.StreamReader("setting_closeday.bat", Encoding.UTF8)
        Dim TextLine() As String
        Do While objReader.Peek() <> -1
            TextLine = objReader.ReadLine().ToString.Trim.Split("=")
            If TextLine(0).ToString.Trim = "printcloserop" Then
                If TextLine(1).ToString.Trim = 0 Then
                    g = False
                Else
                    g = True
                End If
            End If
        Loop
        objReader.Dispose()
        objReader.Close()
        Return g
    End Function
    Public Function CheckPrintcloseropsummary()
        'โหลดข้อมูล Tabspage1
        Dim g As Boolean = False
        Dim objReader As New System.IO.StreamReader("setting_closeday.bat", Encoding.UTF8)
        Dim TextLine() As String
        Do While objReader.Peek() <> -1
            TextLine = objReader.ReadLine().ToString.Trim.Split("=")
            If TextLine(0).ToString.Trim = "printcloseropsummary" Then
                If TextLine(1).ToString.Trim = 0 Then
                    g = False
                Else
                    g = True
                End If
            End If
        Loop
        objReader.Dispose()
        objReader.Close()
        Return g
    End Function
    Public Function CheckPrintInventory()
        'โหลดข้อมูล Tabspage1
        Dim g As Boolean = False
        Dim objReader As New System.IO.StreamReader("setting_closeday.bat", Encoding.UTF8)
        Dim TextLine() As String
        Do While objReader.Peek() <> -1
            TextLine = objReader.ReadLine().ToString.Trim.Split("=")
            If TextLine(0).ToString.Trim = "printinventory" Then
                If TextLine(1).ToString.Trim = 0 Then
                    g = False
                Else
                    g = True
                End If
            End If
        Loop
        objReader.Dispose()
        objReader.Close()
        Return g
    End Function
End Class

Public Class worker_closeDay
    Private _id As String = ""
    Private _name As String = ""
    Private _date As DateTime
    Private _user As String = ""
    Private _run As Integer = 0
    Private _msg As String = ""
    Private con As New Mysql
    Dim print As New printClass
    Dim res As MySqlDataReader

    Friend Property id() As String
        Set(ByVal id As String)
            _id = id
        End Set
        Get
            Return Me._id
        End Get
    End Property
    Friend Property name() As String
        Set(ByVal name As String)
            _name = name
        End Set
        Get
            Return Me._name
        End Get
    End Property
    Friend Property setdate() As DateTime
        Set(ByVal sdate As DateTime)
            _date = sdate
        End Set
        Get
            Return Me._date
        End Get
    End Property
    Friend Property user() As String
        Set(ByVal user As String)
            _user = user
        End Set
        Get
            Return Me._user
        End Get
    End Property
    Friend ReadOnly Property run() As Integer
        Get
            Return Me._run
        End Get
    End Property
    Friend ReadOnly Property msg() As String
        Get
            Return Me._msg
        End Get
    End Property

    Friend Sub Start()
        Dim cf As Boolean = False
        'Date Old 
        Dim yearOld As String
        If CInt(_date.ToString("yyyy")) > 2450 Then
            yearOld = CInt(_date.ToString("yyyy")) - 543
        Else
            yearOld = CInt(_date.ToString("yyyy"))
        End If
        Dim dnew As DateTime = yearOld & "-" & _date.ToString("MM-dd") & " " & Date.Now().ToString("HH:mm:ss")

        'Date Plus+1 
        Dim yaerNew As String
        Dim Dateplus As Date
        Dateplus = DateAdd(DateInterval.Day, 1, _date)
        If CInt(Dateplus.ToString("yyyy")) > 2450 Then
            yaerNew = CInt(Dateplus.ToString("yyyy")) - 543
        Else
            yaerNew = CInt(Dateplus.ToString("yyyy"))
        End If
        Dim dnew1 As DateTime = yaerNew & "-" & Dateplus.ToString("MM-dd") & Date.Now().ToString(" HH:mm:ss")

        _run = 1
        _msg = "UPDATE ROPBILL ALL AT close bill detail .."
        'UPDATE ROPBILL ALL AT pos_closebilldetail
        Dim qty_update_1 As Boolean = con.mysql_query("UPDATE pos_closebilldetail SET close_day='" & dnew.ToString("yyyy-MM-dd") & "',close_day_action='" & _user & "' WHERE close_day='0000-00-00' ")
        _run = 2
        _msg = "UPDATE ROPDAY AT close bill .."
        'UPDATE ROPDAY AT pos_closebill
        Dim qty_update_2 As Boolean = con.mysql_query("UPDATE pos_closebill SET create_date='" & dnew1.ToString("yyyy-MM-dd HH:mm:ss") & "',active='0',DateSel='0' ")
        _run = 3
        _msg = "UPDATE ROP DAY AT Invoice .."
        'UPDATE ROPDAY AT pos_invoice
        Dim qty_update_3 As Boolean = con.mysql_query("UPDATE pos_invoice SET close_day_inv='" & dnew.ToString("yyyy-MM-dd") & "' where close_day_inv='0000-00-00' and DAY(create_date)='" & _date.ToString("dd") & "' and MONTH(create_date)='" & _date.ToString("MM") & "' and YEAR(create_date)='" & yearOld & "' ")
        'Delete Temp Print 
        con.mysql_query("DELETE FROM pos_temp_print WHERE DAY(create_date)='" & dnew.ToString("dd") & "' and MONTH(create_date)='" & dnew.ToString("MM") & "' and YEAR(create_date)='" & dnew.ToString("yyyy") & "'")
        'Delete order list for empty
        con.mysql_query("DELETE FROM pos_order_list WHERE DAY(create_date)='" & dnew.ToString("dd") & "' and MONTH(create_date)='" & dnew.ToString("MM") & "' and YEAR(create_date)='" & dnew.ToString("yyyy") & "' ")
        'Update Table at open status 2= 1
        con.mysql_query("UPDATE pos_table_system SET status='1',update_by='" & _user & "',id_join_tb='0',remark_tb='-',invoice_number='0' WHERE status='2' ")
        'Update Rop ที่ยังไม่ได้ปิดในวันนั้นๆ
        con.mysql_query("UPDATE pos_audit SET type_aud='1',action_by_aud='" & _user & "' WHERE type_aud='0' and DAY(rop_date_aud)='" & dnew.ToString("dd") & "' and MONTH(rop_date_aud)='" & dnew.ToString("MM") & "' and YEAR(rop_date_aud)='" & dnew.ToString("yyyy") & "' ")
        _run = 4
        _msg = "Update Data .."
        ' Insert Sum Stock 
        'form_ropday.SumStock_Insert()
        SumStock_Insert_New()
        If qty_update_1 = True And qty_update_2 = True And qty_update_3 = True Then
            'Export Back up DB รายวัน
            _run = 6
            _msg = "Back up data .."
            Dim d As Date = dnew
            Dim StrCaltype = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Control Panel\International", "iCalendarType", Nothing)
            If StrCaltype = 7 Then
                If dnew.Year < 2450 Then
                    d = DateAdd(DateInterval.Year, 543, CDate(dnew))
                End If
            Else
                If dnew.Year > 2450 Then
                    d = DateAdd(DateInterval.Year, -543, CDate(dnew))
                End If
            End If
            If CheckPrintcloseday() = True Then
                print.PrintPaymentClose(d, _user)
                'print.ReDefalutPrint()
            End If
            If CheckPrintclosedaysummary() = True Then
                print.PrintPaymentSummaryClose(d, _user)
                ' print.ReDefalutPrint()
            End If
            _run = 6
            _msg = "Export Data .."
            print.ExportData(_date)
            'MessageBox.Show("Close Day Complete. Please Exit Program And Open Again", "Message Alert", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cf = True
        End If
    End Sub
    Public Function CheckPrintcloseday()
        'โหลดข้อมูล Tabspage1
        Dim g As Boolean = False
        Dim objReader As New System.IO.StreamReader("setting_closeday.bat", Encoding.UTF8)
        Dim TextLine() As String
        Do While objReader.Peek() <> -1
            TextLine = objReader.ReadLine().ToString.Trim.Split("=")
            If TextLine(0).ToString.Trim = "printcloseday" Then
                If TextLine(1).ToString.Trim = 0 Then
                    g = False
                Else
                    g = True
                End If
            End If
        Loop
        objReader.Dispose()
        objReader.Close()
        Return g
    End Function

    Public Function CheckPrintclosedaysummary()
        'โหลดข้อมูล Tabspage1
        Dim g As Boolean = False
        Dim objReader As New System.IO.StreamReader("setting_closeday.bat", Encoding.UTF8)
        Dim TextLine() As String
        Do While objReader.Peek() <> -1
            TextLine = objReader.ReadLine().ToString.Trim.Split("=")
            If TextLine(0).ToString.Trim = "printclosedaysummary" Then
                If TextLine(1).ToString.Trim = 0 Then
                    g = False
                Else
                    g = True
                End If
            End If
        Loop
        objReader.Dispose()
        objReader.Close()
        Return g
    End Function
    Public Function SumStock_Insert_New()
        Dim date1 As DateTime
        If CInt(_date.ToString("yyyy")) > 2450 Then
            date1 = CInt(_date.ToString("yyyy")) - 543 & _date.ToString("-MM-dd") & Now.ToString(" HH:mm:ss")
        Else
            date1 = _date.ToString("yyyy-MM-dd") & Now.ToString(" HH:mm:ss")
        End If
        Dim f As Boolean = False
        Dim str1 As String = ""
        Dim query_prd As MySqlDataReader = con.mysql_query("SELECT * FROM  pos_product_inv order by inv_barcode asc")
        Dim i As Integer = 0
        While query_prd.Read()
            Dim id_prd As String = "0"
            Dim number_prd As String = query_prd.GetString("inv_barcode")
            Dim nameprd_th As String = query_prd.GetString("inv_name_th")
            Dim nameprd_en As String = query_prd.GetString("inv_name_en")
            Dim amt_prd_main As String = query_prd.GetString("inv_amount")
            Dim inv_unit_name As String = query_prd.GetString("inv_unit_name")
            Dim inv_unit_id As String = query_prd.GetString("inv_unit_id")
            Dim ref__id_catsubprd As String = "0"
            Dim ref_unit_main As String = "0"
            Dim prd_vat As String = "0"
            Dim prd_vatstatus As String = "0"
            Dim ref__id_catprd As String = "0"
            Dim price_prd_main As Double = 0.0

            str1 &= "INSERT INTO pos_product_stock (stk_id_prd,stk_id_prd_con,stk_barcode,stk_nameprd_th,stk_nameprd_en,stk_amount,stk_price,stk_ref__id_catprd,stk_ref__id_catsubprd,stk_ref_unit,stk_prd_vat,stk_prd_vatstatus,stk_create_date)" _
                        & "VALUES('" & id_prd & "','0','" & number_prd & "','" & nameprd_th & "','" & nameprd_en & "','" & amt_prd_main & "','" & price_prd_main & "'," _
                        & "'" & ref__id_catprd & "','" & ref__id_catsubprd & "','" & ref_unit_main & "'," _
                        & "'" & prd_vat & "','" & prd_vatstatus & "','" & date1.ToString("yyyy-MM-dd HH:mm:ss") & "'" _
                        & ");"
            i += 1
        End While
        If i > 0 Then
            f = con.mysql_query(str1)
        Else
            f = False
        End If
        Return f
    End Function
End Class