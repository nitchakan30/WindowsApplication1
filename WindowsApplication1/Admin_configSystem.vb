Imports MySql.Data.MySqlClient
Imports System
Imports System.IO
Imports System.Text
Imports System.Collections.Generic
Imports System.Management
Imports Microsoft.Win32

Public Class Admin_configSystem
    Dim con As New Mysql
    Dim rptID As New ArrayList
    Public pay() As Process
    Private Sub Admin_configSystem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        getShowComport()
        Load_dt()
        load_report()
        'load_report_check()

    End Sub
    Private Sub getShowComport()
        txtPOSPath.Text = Registry.GetValue("HKEY_CURRENT_USER\POSPathImport1", "NamePort", "None")
        TextBox1.Text = Registry.GetValue("HKEY_CURRENT_USER\POSPathImport1", "DelayStart", "1")
        TextBox2.Text = Registry.GetValue("HKEY_CURRENT_USER\POSPathImport1", "DelayWrite", "1")
        TextBox3.Text = Registry.GetValue("HKEY_CURRENT_USER\POSPathImport1", "DelayStop", "0")
        Dim sh As Integer = Registry.GetValue("HKEY_CURRENT_USER\POSPathImport2", "ShowPrint", "0")

        If sh = 0 Then
            CheckBox_1.Checked = False
        Else
            CheckBox_1.Checked = True
        End If
    End Sub
    Private Sub Load_dt()
        'โหลดข้อมูล Tabspage1
        Dim objReader As New System.IO.StreamReader("setting_system.bat", Encoding.UTF8)
        Dim TextLine() As String
        Do While objReader.Peek() <> -1
            TextLine = objReader.ReadLine().ToString.Trim.Split("=")
            If TextLine(0).ToString.Trim = "onoff_takehome" Then
                If TextLine(1).ToString.Trim = 0 Then
                    onoff_takehome.Checked = False
                Else
                    onoff_takehome.Checked = True
                End If
            ElseIf TextLine(0).ToString.Trim = "onoff_rongbill" Then
                If TextLine(1).ToString.Trim = 0 Then
                    onoff_rongbill.Checked = False
                Else
                    onoff_rongbill.Checked = True
                End If
            ElseIf TextLine(0).ToString.Trim = "onoff_rpt_show_disgroup" Then
                If TextLine(1).ToString.Trim = 0 Then
                    rpt_show_disgroup.Checked = False
                Else
                    rpt_show_disgroup.Checked = True
                End If
            ElseIf TextLine(0).ToString.Trim = "onoff_rpt_show_disbill" Then
                If TextLine(1).ToString.Trim = 0 Then
                    rpt_show_disbill.Checked = False
                Else
                    rpt_show_disbill.Checked = True
                End If
            ElseIf TextLine(0).ToString.Trim = "onoff_rpt_show_vat" Then
                If TextLine(1).ToString.Trim = 0 Then
                    rpt_show_vat.Checked = False
                Else
                    rpt_show_vat.Checked = True
                End If
            ElseIf TextLine(0).ToString.Trim = "onoff_rpt_show_service" Then
                If TextLine(1).ToString.Trim = 0 Then
                    rpt_show_service.Checked = False
                Else
                    rpt_show_service.Checked = True
                End If
            End If
        Loop
        objReader.Dispose()
        objReader.Close()
    End Sub
    Private Sub load_report()
        Dim rpt As MySqlDataReader = con.mysql_query("select * from pos_report order by id_rpt asc;")
        CheckedListBox_Report.Items.Clear()
        While rpt.Read
            CheckedListBox_Report.Items.Add(rpt.GetString("title_rpt"))
            rptID.Add(rpt.GetString("id_rpt"))
        End While
    End Sub
    Private Sub load_report_check()
        'โหลดข้อมูล Tabspage1
        Dim chk_db As Integer = con.mysql_num_rows(con.mysql_query("select * from pos_report order by id_rpt asc;"))
        Dim objReader As New System.IO.StreamReader("setting_system.bat", Encoding.UTF8)
        Dim TextLine() As String
        Dim i As Integer = 0
        Dim j As Integer = 0
        Do While objReader.Peek() <> -1
            TextLine = objReader.ReadLine().ToString.Trim.Split("=")
            If i > 5 Then
                j += 1

                'If TextLine(1).ToString.Trim = "1" Then
                '    CheckedListBox_Report.SetItemChecked(i - 6, True)
                'End If
            End If
            i += 1
        Loop
        'MsgBox(j & "-" & chk_db)
        objReader.Dispose()
        objReader.Close()
    End Sub

    Private Sub enter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles enter_save.Click
        Dim onoff_takehome_1 As Integer
        Dim onoff_rongbill_1 As Integer
        Dim onoff_rpt_show_disgroup_1 As Integer
        Dim onoff_rpt_show_disbill_1 As Integer
        Dim onoff_rpt_show_vat_1 As Integer
        Dim onoff_rpt_show_service_1 As Integer

        If onoff_takehome.Checked = True Then
            onoff_takehome_1 = 1
        Else
            onoff_takehome_1 = 0
        End If
        If onoff_rongbill.Checked = True Then
            onoff_rongbill_1 = 1
        Else
            onoff_rongbill_1 = 0
        End If
        If rpt_show_disgroup.Checked = True Then
            onoff_rpt_show_disgroup_1 = 1
        Else
            onoff_rpt_show_disgroup_1 = 0
        End If
        If rpt_show_disbill.Checked = True Then
            onoff_rpt_show_disbill_1 = 1
        Else
            onoff_rpt_show_disbill_1 = 0
        End If
        If rpt_show_vat.Checked = True Then
            onoff_rpt_show_vat_1 = 1
        Else
            onoff_rpt_show_vat_1 = 0
        End If
        If rpt_show_service.Checked = True Then
            onoff_rpt_show_service_1 = 1
        Else
            onoff_rpt_show_service_1 = 0
        End If
        Dim count As Integer = CheckedListBox_Report.Items.Count
        File.WriteAllText("setting_system.bat", String.Empty)
        Dim FILE_NAME As String = "setting_system.bat"
        Dim i As Integer
        Dim aryText(count + 6) As String
        aryText(0) = "onoff_takehome=" & onoff_takehome_1
        aryText(1) = "onoff_rongbill=" & onoff_rongbill_1
        aryText(2) = "onoff_rpt_show_disgroup=" & onoff_rpt_show_disgroup_1
        aryText(3) = "onoff_rpt_show_disbill=" & onoff_rpt_show_disbill_1
        aryText(4) = "onoff_rpt_show_vat=" & onoff_rpt_show_vat_1
        aryText(5) = "onoff_rpt_show_service=" & onoff_rpt_show_service_1
        For t As Integer = 0 To count - 1
            CheckedListBox_Report.SelectedIndex = t
            Dim ck As Integer = 0
            If CheckedListBox_Report.GetItemCheckState(t) = CheckState.Checked Then
                ck = 1
            End If
            aryText(t + 6) = rptID(t) & "=" & ck
        Next

        Dim objWriter As New System.IO.StreamWriter(FILE_NAME, True)
        For i = 0 To count + 5
            objWriter.WriteLine(aryText(i))
        Next
        objWriter.Close()
        objWriter.Dispose()
        Registry.CurrentUser.DeleteSubKey("POSPathImport_UseDB", False)
        Dim rk As RegistryKey = Registry.CurrentUser.CreateSubKey("POSPathImport_UseDB")
        rk.SetValue("UseReportDb", CheckBox_UseReport.Checked.ToString)
        MsgBox("บันทึกเรียบร้อย")
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Registry.CurrentUser.DeleteSubKey("POSPathImport1", False)
        Dim rk As RegistryKey = Registry.CurrentUser.CreateSubKey("POSPathImport1")
        rk.SetValue("NamePort", txtPOSPath.Text)
        rk.SetValue("DelayStart", TextBox1.Text)
        rk.SetValue("DelayWrite", TextBox2.Text)
        rk.SetValue("DelayStop", TextBox3.Text)
        MsgBox("Complete.")
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Dim namePort As String = Registry.GetValue("HKEY_CURRENT_USER\POSPathImport1", "NamePort", "None")
            Dim DelayStart As String = Registry.GetValue("HKEY_CURRENT_USER\POSPathImport1", "DelayStart", "1")
            Dim DelayWrite As String = Registry.GetValue("HKEY_CURRENT_USER\POSPathImport1", "DelayWrite", "1")
            Dim DelayStop As String = Registry.GetValue("HKEY_CURRENT_USER\POSPathImport1", "DelayStop", "0")
            pay = Process.GetProcessesByName("Drawer")
            If pay.Count > 0 Then
                ' Process is running
                Array.ForEach(pay, Sub(p1 As Process) p1.Kill())
            End If
            Dim str As String = """" & namePort & """ " & DelayStart & " " & DelayWrite & " " & DelayStop & ""
            System.Diagnostics.Process.Start("Drawer.exe", str)

        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim i As Integer = 0
        If CheckBox_1.Checked = True Then
            i = 1
        Else
            i = 0
        End If
        Registry.CurrentUser.DeleteSubKey("POSPathImport2", False)
        Dim rk As RegistryKey = Registry.CurrentUser.CreateSubKey("POSPathImport2")
        rk.SetValue("ShowPrint", i)
        MsgBox("Complete.")
    End Sub
End Class
