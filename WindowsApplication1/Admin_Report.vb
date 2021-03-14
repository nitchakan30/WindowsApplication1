Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Windows.Forms
Imports MySql.Data.MySqlClient
Imports System
Imports System.IO
Imports System.Text
Imports System.Collections.Generic
Imports Microsoft.Win32

Public Class Admin_Report
    Dim cryRpt As New ReportDocument
    Public page As String = "front"
    Dim con As New Mysql
    Dim print As New printClass
    Public openReport As Boolean = False
    Dim array_rpt(,) As ArrayList
    Dim type_report_main As Boolean = True
    Private Sub Admin_Report_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ShowDataTreeviewReport()
        cryRpt.Close()
        CrystalReportViewer1.Refresh()
        CrystalReportViewer1.ShowGroupTreeButton = False
        CrystalReportViewer1.ShowCloseButton = False
        CrystalReportViewer1.ShowExportButton = False
        CrystalReportViewer1.ShowPrintButton = False
        CrystalReportViewer1.ShowTextSearchButton = False
        CrystalReportViewer1.ShowParameterPanelButton = False
        CrystalReportViewer1.ShowRefreshButton = False

    End Sub
    Public Sub loadDataTreeview()
        TreeView1.Nodes.Clear()
        TreeView1.Nodes.Add("Node0", "ทั้งหมด(All)")

        Dim strQuery As String = "SELECT * FROM pos_catprd ORDER BY id ASC "
        'ShowDataTreeviewReport()
    End Sub
    Public Sub ShowDataTreeviewReport()
        'โหลดข้อมูล Tabspage1
        Dim UseReportDb As String = Registry.GetValue("HKEY_CURRENT_USER\POSPathImport_UseDB", "UseReportDb", "True")
        TreeView1.Nodes.Clear()
        Dim reader As MySqlDataReader = con.mysql_query("SELECT * FROM pos_report_node order by id_node ASC")
        'Dim childnodes() As TreeNode
        Dim i As Integer = 0
        While reader.Read()
            If reader.GetString("id_node") = "0" Or reader.GetString("id_node") = "1" Or reader.GetString("id_node") = "2" Then
                Dim id As String = "Node" & reader.GetString("id_node")
                Dim rootNode As TreeNode
                Dim subchildnodes1 As TreeNode

                rootNode = TreeView1.Nodes.Add(id, reader.GetString("title_node"))
                Dim reader_sub As MySqlDataReader = con.mysql_query("SELECT * FROM pos_report WHERE id_node0='" & reader.GetString("id_node") & "' order by title_rpt ASC")
                While reader_sub.Read()
                    If reader_sub.GetString("status") = "1" Then
                        subchildnodes1 = rootNode.Nodes.Add(reader_sub.GetString("title_rpt"))
                        subchildnodes1.Name = CStr(reader_sub.GetString("name_rpt"))
                        subchildnodes1.ToolTipText = CInt(reader_sub.GetString("open_rpt"))
                        subchildnodes1.Tag = reader_sub.GetString("url_rpt")
                    End If
                End While

           

                i += 1
            End If
        End While
        TreeView1.ExpandAll()
    End Sub
    Private Sub TreeView1_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TreeView1.MouseDoubleClick
        'Dim treenode As TreeView = CType(sender, TreeView)
        If TreeView1.SelectedNode.ToolTipText = "1" Then
            'If openReport = True Then
            '    cryRpt.Close()
            'End If

            If TreeView1.SelectedNode.Tag <> "report\" Then
                type_report_main = False

                If TreeView1.SelectedNode.Name = "topten_order" Then
                    Admin_ReportInputParameter2.NameFileReport = TreeView1.SelectedNode.Name
                    Admin_ReportInputParameter2.ServerPathFile = TreeView1.SelectedNode.Tag
                    Admin_ReportInputParameter2.ShowDialog()
                ElseIf TreeView1.SelectedNode.Name = "product_list" Then
                    Admin_ReportInputParameter4.page = ""
                    Admin_ReportInputParameter4.NameFileReport = TreeView1.SelectedNode.Name
                    Admin_ReportInputParameter4.ServerPathFile = TreeView1.SelectedNode.Tag
                    Admin_ReportInputParameter4.ShowDialog()
                Else
                    Admin_Report_InputParameter1.title.Text = TreeView1.SelectedNode.Text.ToString()
                    Admin_Report_InputParameter1.NameFileReport = TreeView1.SelectedNode.Name
                    Admin_Report_InputParameter1.ServerPathFile = TreeView1.SelectedNode.Tag
                    Admin_Report_InputParameter1.ShowDialog()
                End If
            Else
                'Check report for set parameter 
                For Each filepath As String In Directory.GetFiles("temp\")
                    File.Delete(filepath)
                Next

                If TreeView1.SelectedNode.Name = "sort_order" Then
                    Admin_ReportInputParameter2.NameFileReport = TreeView1.SelectedNode.Name
                    Admin_ReportInputParameter2.ServerPathFile = TreeView1.SelectedNode.Tag
                    Admin_ReportInputParameter2.ShowDialog()
                    type_report_main = False
                ElseIf TreeView1.SelectedNode.Name = "sort_order_time" Then
                    Admin_ReportInputParameter3.NameFileReport = TreeView1.SelectedNode.Name
                    Admin_ReportInputParameter3.ServerPathFile = TreeView1.SelectedNode.Tag
                    Admin_ReportInputParameter3.ShowDialog()
                    type_report_main = False
                Else
                    FileCopy(Login.pathreport & "\" & TreeView1.SelectedNode.Name & ".rpt", "temp\" & TreeView1.SelectedNode.Name & ".rpt")
                    cryRpt.Load("temp\" & TreeView1.SelectedNode.Name & ".rpt")
                    CrystalReportViewer1.ReportSource = cryRpt
                    CrystalReportViewer1.Refresh()
                    type_report_main = True
                End If

            End If

        End If
    End Sub
    Friend Function Check_Key()
        Dim res_Licen As MySqlDataReader
        Dim license As String = ""
        Dim license_hotel_name As String = ""
        res_Licen = con.mysql_query("SELECT * FROM main_system WHERE system_id='1'")
        While res_Licen.Read()
            license = res_Licen.GetString("system_license")
        End While
        Return license
    End Function
    Public Function Craete_DataToViewReport(ByVal name_rop, ByVal date1)
        Dim id_rop As Integer = 0
        Dim x As Boolean = False
        If name_rop <> "" Then
            Dim rop As MySqlDataReader = con.mysql_query("select * from pos_audit where name_rop_aud='" & name_rop & "';")
            rop.Read()
            id_rop = CInt(rop.GetString("id_aud"))
        End If
        Dim show_dis_bill As Boolean = onoff_rpt_show_disbill()
        Dim show_dis_group As Boolean = onoff_rpt_show_disgroup()
        Dim show_vat As Boolean = onoff_rpt_show_vat()
        Dim show_ser As Boolean = onoff_rpt_show_service()
        con.mysql_query("DELETE FROM pos_disc;DELETE FROM pos_disc_detail;")

        Dim num_c As Integer = 0
        Dim str As String = ""
        Dim str_input As String = ""
        Dim param As String = ""
        Dim param1 As String = ""
        If name_rop <> "" Then
            str_input &= "select * from pos_invoice where close_rop_id_inv='" & id_rop & "';"
            param &= "close_rop_id_inv='" & id_rop & "'"
            param1 &= "pos_closebilldetail.rf_id_closebill='" & id_rop & "'"
        Else
            str_input &= "select * from pos_invoice where close_day_inv='" & date1 & "';"
            param &= "close_day_inv='" & date1 & "'"
            param1 &= "pos_closebilldetail.close_day='" & date1 & "'"
        End If
        Dim Disc_Bill As Double = 0.0
        Dim cat As MySqlDataReader = con.mysql_query("select pos_catprd.id as id,pos_catprd.namecat_en as namecat_en,pos_catprd.namecat_th as namecat_th from pos_closebilldetail INNER JOIN  pos_catprd ON pos_catprd.id = pos_closebilldetail.c_id_cat where " & param1 & " Group by c_id_cat;")
        Dim g As Double = 0.0
        While cat.Read()
            Dim c As Integer = con.mysql_num_rows(con.mysql_query(str_input))
            If c > 0 Then
                Dim ref_disc As String = "CAT0" & num_c
                Dim ref_cat As String = "CAT" & num_c
                Dim ref_disc_bill As String = "DISB"
                Dim ref_ser As String = "Ser"
                Dim ref_vat As String = "Vat"

                con.mysql_query("INSERT INTO pos_disc (id,name) VALUES('" & ref_cat & "','" & cat.GetString("namecat_en") & "');")
                con.mysql_query("INSERT INTO pos_disc (id,name) VALUES('" & ref_disc & "','" & cat.GetString("namecat_en") & "- ส่วนลด');")
                con.mysql_query("INSERT INTO pos_disc (id,name) VALUES('" & ref_disc_bill & "','ส่วนลดต่อบิล');")
                con.mysql_query("INSERT INTO pos_disc (id,name) VALUES('" & ref_ser & "','Service charge');")
                con.mysql_query("INSERT INTO pos_disc (id,name) VALUES('" & ref_vat & "','Vat');")

                Dim inv As MySqlDataReader = con.mysql_query("select pos_invoice.id as id,pos_invoice.namber_inv as namber_inv " _
                & ",pos_closebilldetail.cprs as cprs,IFNULL(pos_table_system.number,'-') as number,pos_closebilldetail.ccode_gohome as ccode_gohome,pos_invoice.create_by as create_by " _
                & ",pos_invoice.discount_sum as discount_sum,pos_invoice.serviceCh as serviceCh,pos_invoice.price_all as price_all" _
                & " from pos_invoice  INNER JOIN pos_closebilldetail ON pos_closebilldetail.crf_id_invoice = pos_invoice.id " _
                & " LEFT JOIN pos_table_system ON pos_table_system.id = pos_closebilldetail.crf_id_table " _
                & " where " & param & " and pos_invoice.void<>'1' GROUP BY pos_closebilldetail.crf_id_invoice;")
                Dim disc_sum As Double = 0.0
                While inv.Read()
                    Dim name_tb As String = ""
                    Dim cprs As Integer = inv.GetString("cprs")
                    If inv.GetString("number") = "-" Then
                        name_tb = inv.GetString("ccode_gohome")
                    Else
                        name_tb = inv.GetString("number")
                    End If

                    str = ""
                    Dim closedetail As MySqlDataReader = con.mysql_query("select pos_closebilldetail.crf_id_invoice as crf_id_invoice," _
                    & "pos_closebilldetail.c_discount_sum as c_discount_sum,pos_closebilldetail.c_net_amount as c_net_amount,pos_closebilldetail.rf_id_closebill as rf_id_closebill," _
                    & "pos_closebilldetail.close_day as close_day,pos_closebilldetail.cstatus as cstatus,pos_closebilldetail.c_id_cat as c_id_cat" _
                    & ",pos_closebilldetail.c_vat as c_vat,pos_closebilldetail.c_vat_st as c_vat_st" _
                    & " from pos_closebilldetail " _
                    & " where " & param1 & " and pos_closebilldetail.c_id_cat='" & cat.GetString("id") & "'and pos_closebilldetail.cstatus<>'void' and pos_closebilldetail.crf_id_invoice ='" & inv.GetString("id") & "';")

                    Dim srv As Double = 0.0
                    Dim price As Double = 0.0
                    Dim disc As Double = 0.0
                    Dim vat As Double = 0.0
                    Dim chkcat As Boolean = False
                    While closedetail.Read()
                        If Check_Key() = "2001E-2C517-9051A-07B3D-616A3-1C7EE" Then
                            price += CDbl(closedetail.GetString("c_net_amount"))
                            vat += 0
                            disc += CDbl(closedetail.GetString("c_discount_sum"))
                            If closedetail.GetString("c_id_cat") = "2" Then
                                chkcat = True
                            End If
                        Else

                            If closedetail.GetString("c_vat_st") = "1" Or closedetail.GetString("c_vat_st") = "2" Then
                                price += (CDbl(closedetail.GetString("c_net_amount")) * 100) / (100 + CInt(closedetail.GetString("c_vat")))
                                vat += CDbl(closedetail.GetString("c_net_amount")) - (CDbl(closedetail.GetString("c_net_amount")) * 100) / (100 + CInt(closedetail.GetString("c_vat")))
                            Else
                                price += CDbl(closedetail.GetString("c_net_amount"))
                                vat += 0.0
                            End If
                            disc += CDbl(closedetail.GetString("c_discount_sum"))
                            srv += 0
                        End If
                    End While

                    If chkcat = True And Check_Key() = "2001E-2C517-9051A-07B3D-616A3-1C7EE" Then
                        price = price - CDbl(inv.GetString("discount_sum")) - disc
                        srv = price * 10 / 110
                        price -= srv
                        vat = price * 0.07
                        price -= vat
                    ElseIf Check_Key() = "2001E-2C517-9051A-07B3D-616A3-1C7EE" Then
                        price = price - CDbl(inv.GetString("discount_sum")) - disc
                        srv = 0
                        price -= srv
                        vat = price * 0.07
                        price -= vat
                    End If



                    If Check_Key() <> "2001E-2C517-9051A-07B3D-616A3-1C7EE" Then

                        str &= "INSERT ignore INTO pos_disc_detail (id,ref_invoice,net_amount,name_tb,action,prs) VALUES (" _
                    & "'" & ref_cat & "','" & inv.GetString("namber_inv") & "','" & price & "','" & name_tb & "','" & inv.GetString("create_by") & "','" & cprs & "' );"

                        str &= "INSERT ignore INTO pos_disc_detail (id,ref_invoice,net_amount,name_tb,action,prs) VALUES (" _
                        & "'" & ref_disc & "','" & inv.GetString("namber_inv") & "','-" & disc & "','" & name_tb & "','" & inv.GetString("create_by") & "','" & cprs & "');"


                        str &= "INSERT ignore INTO pos_disc_detail (id,ref_invoice,net_amount,name_tb,action,prs) VALUES (" _
                            & "'" & ref_vat & "','" & inv.GetString("namber_inv") & "','" & vat & "' ,'" & name_tb & "','" & inv.GetString("create_by") & "','" & cprs & "');"

                    Else

                        str &= "INSERT ignore INTO pos_disc_detail (id,ref_invoice,net_amount,name_tb,action,prs) VALUES (" _
                    & "'" & ref_cat & "','" & inv.GetString("namber_inv") & "','" & price & "','" & name_tb & "','" & inv.GetString("create_by") & "','" & cprs & "' );"

                        str &= "INSERT ignore INTO pos_disc_detail (id,ref_invoice,net_amount,name_tb,action,prs) VALUES (" _
                        & "'" & ref_disc & "','" & inv.GetString("namber_inv") & "','-" & disc & "','" & name_tb & "','" & inv.GetString("create_by") & "','" & cprs & "');"

                        str &= "INSERT ignore INTO pos_disc_detail (id,ref_invoice,net_amount,name_tb,action,prs) VALUES (" _
                        & "'" & ref_disc_bill & "','" & inv.GetString("namber_inv") & "','-" & inv.GetString("discount_sum") & "','" & name_tb & "','" & inv.GetString("create_by") & "','" & cprs & "' );"

                        str &= "INSERT ignore INTO pos_disc_detail (id,ref_invoice,net_amount,name_tb,action,prs) VALUES (" _
                            & "'" & ref_ser & "','" & inv.GetString("namber_inv") & "','" & srv & "','" & name_tb & "','" & inv.GetString("create_by") & "','" & cprs & "' );"
                        str &= "INSERT ignore INTO pos_disc_detail (id,ref_invoice,net_amount,name_tb,action,prs) VALUES (" _
                            & "'" & ref_vat & "','" & inv.GetString("namber_inv") & "','" & vat & "' ,'" & name_tb & "','" & inv.GetString("create_by") & "','" & cprs & "');"
                    End If



                    If str <> "" Then
                        x = con.mysql_query(str)
                    End If

                End While
                num_c += 1
            End If
        End While
        If Check_Key() <> "2001E-2C517-9051A-07B3D-616A3-1C7EE" Then
            Dim str1 As String = ""
            Dim inv1 As MySqlDataReader = con.mysql_query("select pos_invoice.id as id,pos_invoice.namber_inv as namber_inv " _
                     & ",pos_closebilldetail.cprs as cprs,IFNULL(pos_table_system.number,'-') as number,pos_closebilldetail.ccode_gohome as ccode_gohome,pos_invoice.create_by as create_by " _
                     & ",pos_invoice.discount_sum as discount_sum,pos_invoice.serviceCh as serviceCh,pos_invoice.price_all as price_all" _
                     & " from pos_invoice  INNER JOIN pos_closebilldetail ON pos_closebilldetail.crf_id_invoice = pos_invoice.id " _
                     & " LEFT JOIN pos_table_system ON pos_table_system.id = pos_closebilldetail.crf_id_table " _
                     & " where " & param & " and pos_invoice.void<>'1' GROUP BY pos_closebilldetail.crf_id_invoice;")

            While inv1.Read()
                Dim name_tb As String = ""
                Dim cprs As Integer = inv1.GetString("cprs")
                If inv1.GetString("number") = "-" Then
                    name_tb = inv1.GetString("ccode_gohome")
                Else
                    name_tb = inv1.GetString("number")
                End If
                str1 &= "INSERT ignore INTO pos_disc_detail (id,ref_invoice,net_amount,name_tb,action,prs) VALUES (" _
                & "'DISB','" & inv1.GetString("namber_inv") & "','-" & inv1.GetString("discount_sum") & "','" & name_tb & "','" & inv1.GetString("create_by") & "','" & cprs & "' );"

                str1 &= "INSERT ignore INTO pos_disc_detail (id,ref_invoice,net_amount,name_tb,action,prs) VALUES (" _
                    & "'Ser','" & inv1.GetString("namber_inv") & "','" & FormatNumber(CDbl(inv1.GetString("serviceCh")), 2) & "','" & name_tb & "','" & inv1.GetString("create_by") & "','" & cprs & "' );"

            End While
            If str1 <> "" Then
                con.mysql_query(str1)
            End If

        End If


        Return x
    End Function
    Private Sub btn_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_close.Click
        If page = "front" Then
            Me.Close()
            index.ishomeopen = True
            If index.CheckOpenSystemTakehomeonly() = True Then
                gohome_list.MdiParent = index
                gohome_list.Show()
                gohome_list.WindowState = FormWindowState.Minimized
                gohome_list.WindowState = FormWindowState.Maximized
                Login.Formname = "gohome_list"
            Else
                home1.MdiParent = index
                home1.Show()
                home1.WindowState = FormWindowState.Minimized
                home1.WindowState = FormWindowState.Maximized
                Login.Formname = "home1"
            End If
        Else
            Me.Close()
        End If
    End Sub

    Private Sub nimi_s_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nimi_s.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
    Private Sub max_s_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles max_s.Click
        Me.WindowState = FormWindowState.Maximized
    End Sub
    Public Function onoff_report(ByVal id)
        'โหลดข้อมูล Tabspage1
        Dim g As Boolean = False
        Dim objReader As New System.IO.StreamReader("setting_system.bat", Encoding.UTF8)
        Dim TextLine() As String
        Do While objReader.Peek() <> -1
            TextLine = objReader.ReadLine().ToString.Trim.Split("=")
            If TextLine(0).ToString.Trim = id Then
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
    Public Function onoff_rpt_show_disgroup()
        'โหลดข้อมูล Tabspage1
        Dim g As Boolean = False
        Dim objReader As New System.IO.StreamReader("setting_system.bat", Encoding.UTF8)
        Dim TextLine() As String
        Do While objReader.Peek() <> -1
            TextLine = objReader.ReadLine().ToString.Trim.Split("=")
            If TextLine(0).ToString.Trim = "onoff_rpt_show_disgroup" Then
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
    Public Function onoff_rpt_show_disbill()
        'โหลดข้อมูล Tabspage1
        Dim g As Boolean = False
        Dim objReader As New System.IO.StreamReader("setting_system.bat", Encoding.UTF8)
        Dim TextLine() As String
        Do While objReader.Peek() <> -1
            TextLine = objReader.ReadLine().ToString.Trim.Split("=")
            If TextLine(0).ToString.Trim = "onoff_rpt_show_disbill" Then
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
    Public Function onoff_rpt_show_vat()
        'โหลดข้อมูล Tabspage1
        Dim g As Boolean = False
        Dim objReader As New System.IO.StreamReader("setting_system.bat", Encoding.UTF8)
        Dim TextLine() As String
        Do While objReader.Peek() <> -1
            TextLine = objReader.ReadLine().ToString.Trim.Split("=")
            If TextLine(0).ToString.Trim = "onoff_rpt_show_vat" Then
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
    Public Function onoff_rpt_show_service()
        'โหลดข้อมูล Tabspage1
        Dim g As Boolean = False
        Dim objReader As New System.IO.StreamReader("setting_system.bat", Encoding.UTF8)
        Dim TextLine() As String
        Do While objReader.Peek() <> -1
            TextLine = objReader.ReadLine().ToString.Trim.Split("=")
            If TextLine(0).ToString.Trim = "onoff_rpt_show_service" Then
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
    Private Sub btn_export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_export.Click
        CrystalReportViewer1.ExportReport()
    End Sub

    Private Sub btn_refrese_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_refrese.Click
        If type_report_main = True Then
            CrystalReportViewer1.RefreshReport()

        Else
            If TreeView1.SelectedNode.Name = "topten_order" Or TreeView1.SelectedNode.Name = "sort_order" Then
                Admin_ReportInputParameter2.NameFileReport = TreeView1.SelectedNode.Name
                Admin_ReportInputParameter2.ServerPathFile = TreeView1.SelectedNode.Tag
                Admin_ReportInputParameter2.ShowDialog()
            ElseIf TreeView1.SelectedNode.Name = "sort_order_time" Then
                Admin_ReportInputParameter3.NameFileReport = TreeView1.SelectedNode.Name
                Admin_ReportInputParameter3.ServerPathFile = TreeView1.SelectedNode.Tag
                Admin_ReportInputParameter3.ShowDialog()
            Else
                Admin_Report_InputParameter1.title.Text = TreeView1.SelectedNode.Text.ToString()
                Admin_Report_InputParameter1.NameFileReport = TreeView1.SelectedNode.Name
                Admin_Report_InputParameter1.ServerPathFile = TreeView1.SelectedNode.Tag
                Admin_Report_InputParameter1.ShowDialog()
            End If
        End If
    End Sub
    Private Sub btn_print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_print.Click
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

        If Registry.GetValue("HKEY_CURRENT_USER\POSPathImport2", "ShowPrint", "0") = "0" Then
            cryRpt.Load(IO.Directory.GetFiles(Application.StartupPath() & "\temp\")(0))
            Dim rangeval As New ParameterRangeValue
            Dim discrete As New ParameterDiscreteValue
            Dim name As String
            For i = 0 To Me.CrystalReportViewer1.ParameterFieldInfo.Count - 1
                If Me.CrystalReportViewer1.ParameterFieldInfo(i).CurrentValues(0).IsRange = True Then
                    name = (CrystalReportViewer1.ParameterFieldInfo(i).Name)
                    rangeval = CrystalReportViewer1.ParameterFieldInfo(i).CurrentValues.Item(0)
                    'MsgBox(rangeval.StartValue)
                    'MsgBox(rangeval.EndValue)
                    cryRpt.SetParameterValue(name, rangeval)
                ElseIf Me.CrystalReportViewer1.ParameterFieldInfo(i).CurrentValues(0).IsRange = False Then
                    name = (CrystalReportViewer1.ParameterFieldInfo(i).Name)
                    discrete = CrystalReportViewer1.ParameterFieldInfo(i).CurrentValues.Item(0)
                    'MsgBox(discrete.Value)
                    cryRpt.SetParameterValue(name, discrete.Value)
                End If
            Next
            cryRpt.PrintOptions.PrinterName = name_p
            cryRpt.PrintToPrinter(1, True, 1, 100)
            MsgBox("Send Print Complete.")
        Else
            CrystalReportViewer1.PrintReport()
        End If
        
    End Sub

    Private Function myReport() As ReportDocument
        Throw New NotImplementedException
    End Function

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)

    End Sub

End Class