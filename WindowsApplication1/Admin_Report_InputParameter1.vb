Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Windows.Forms
Imports MySql.Data.MySqlClient
Imports System
Imports System.IO
Imports System.Text
Imports System.Collections.Generic
Public Class Admin_Report_InputParameter1
    Dim cryRpt As New ReportDocument
    Dim con As New Mysql
    Public NameFileReport As String = ""
    Public ServerPathFile As String = ""
    Dim TextLine() As String
    Dim TextLine_Server() As String
    Dim nameF As String = ""
    Dim serverfile As String = ""
    Dim nameCompany As String = ""
    Private Sub Admin_Report_InputParameter1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextLine = NameFileReport.ToString.Split("=")
        TextLine_Server = ServerPathFile.Split("=")
        If Radio_Day.Checked = True Then
            ComboBox_Bill.Enabled = False
            nameF = TextLine(1).ToString
            serverfile = TextLine_Server(1).ToString()
        Else
            ComboBox_Bill.Enabled = True
            nameF = TextLine(0).ToString
            serverfile = TextLine_Server(0).ToString()
        End If
        nameCompany = index.loadCompany
    End Sub
    Public Sub Ldata_Bill(ByVal date1)
        Dim res_cat As MySqlDataReader
        res_cat = con.mysql_query("select * from  pos_audit where rop_date_aud LIKE '%" & date1 & "%' order by id_ropbill_aud asc")
        Dim cboItemsFl As New List(Of cboItem)
        Dim txt As String = ""
        While res_cat.Read
            cboItemsFl.Add(New cboItem With {.Text = res_cat.GetString("name_rop_aud"), .Value = res_cat.GetString("id_aud")})
        End While

        With Me.ComboBox_Bill
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .DataSource = cboItemsFl
        End With

        If ComboBox_Bill.Items.Count > 0 Then
            ComboBox_Bill.SelectedIndex = 0
        End If
        res_cat.Close()
    End Sub

    Private Sub Radio_Bill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Radio_Bill.Click
        If Radio_Bill.Checked = True Then
            ComboBox_Bill.Enabled = True
            nameF = TextLine(0).ToString
            serverfile = TextLine_Server(0).ToString()
            Dim dateSel As DateTime
            If CInt(DateTimePicker1.Value.ToString("yyyy")) > 2450 Then
                dateSel = CInt(DateTimePicker1.Value.ToString("yyyy")) - 543 & DateTimePicker1.Value.ToString("-MM-dd")
            Else
                dateSel = DateTimePicker1.Value.ToString("yyyy-MM-dd")
            End If
            Ldata_Bill(dateSel.ToString("yyyy-MM-dd"))
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Radio_Day_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Radio_Day.Click
        If Radio_Day.Checked = True Then
            ComboBox_Bill.Enabled = False
            ComboBox_Bill.Text = ""
            nameF = TextLine(1).ToString
            serverfile = TextLine_Server(1).ToString()
        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Check report for set parameter 
        'Try

        Dim date_g As String = ""
        If CInt(DateTimePicker1.Value.ToString("yyyy")) > 2450 Then
            date_g = CInt(DateTimePicker1.Value.ToString("yyyy")) - 543 & DateTimePicker1.Value.ToString("-MM-dd")
        Else
            date_g = DateTimePicker1.Value.ToString("yyyy-MM-dd")
        End If
        If Admin_Report.openReport = True Then
            cryRpt.Close()
        End If

        For Each filepath As String In Directory.GetFiles("temp\")
            File.Delete(filepath)
        Next
        FileCopy(Login.pathreport & serverfile & nameF & ".rpt", "temp\" & nameF & ".rpt")

        If Radio_Bill.Checked = True Then
            'MsgBox("Bill=" & nameF)
            Dim sc As Boolean = False
            If nameF & ".rpt" = "rptCashier_summary_shift_V2_new.rpt" Or nameF & ".rpt" = "rptCashier_summary_shift_new.rpt" Then
                '  MsgBox("Bill=" & date_g.ToString("yyyy-MM-dd"))

                sc = Admin_Report.Craete_DataToViewReport(ComboBox_Bill.Text.ToString, date_g)

                If sc = True Then
                    cryRpt.Load("temp\" & nameF & ".rpt")
                    cryRpt.SetParameterValue("rop", ComboBox_Bill.Text.ToString)
                    cryRpt.SetParameterValue("CompanyName", nameCompany)
                    cryRpt.SetParameterValue("date1", CDate(DateTimePicker1.Value))
                    cryRpt.SetParameterValue("UserName", Login.username)
                    cryRpt.SetParameterValue("rptName", title.Text & "(" & Radio_Bill.Text & ")")
                End If
            Else
                cryRpt.Load("temp\" & nameF & ".rpt")
                cryRpt.SetParameterValue("rop", ComboBox_Bill.Text.ToString)
                cryRpt.SetParameterValue("CompanyName", nameCompany)
                cryRpt.SetParameterValue("date1", CDate(DateTimePicker1.Value))
                cryRpt.SetParameterValue("UserName", Login.username)
                cryRpt.SetParameterValue("rptName", title.Text & "(" & Radio_Bill.Text & ")")
            End If


        Else
            'MsgBox("Day = " & nameF)
            Dim sc1 As Boolean = False
            If nameF & ".rpt" = "rptCashier_summary_shift_new.rpt" Or nameF & ".rpt" = "rptCashier_summary_shift_V2_new.rpt" Then
                sc1 = Admin_Report.Craete_DataToViewReport("", date_g)
                If sc1 = True Then
                    cryRpt.Load("temp\" & nameF & ".rpt")
                    cryRpt.SetParameterValue("CompanyName", nameCompany)
                    cryRpt.SetParameterValue("date1", CDate(DateTimePicker1.Value))
                    cryRpt.SetParameterValue("UserName", Login.username)
                    cryRpt.SetParameterValue("rptName", title.Text & "(" & Radio_Day.Text & ")")

                End If
            Else
                cryRpt.Load("temp\" & nameF & ".rpt")
                cryRpt.SetParameterValue("CompanyName", nameCompany)
                cryRpt.SetParameterValue("date1", CDate(DateTimePicker1.Value))
                cryRpt.SetParameterValue("UserName", Login.username)
                cryRpt.SetParameterValue("rptName", title.Text & "(" & Radio_Day.Text & ")")

            End If

        End If

        Admin_Report.CrystalReportViewer1.ReportSource = cryRpt
        Admin_Report.CrystalReportViewer1.Refresh()
        Admin_Report.openReport = True
        Me.Close()

        'Catch ex As Exception

        'End Try
    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        If Radio_Bill.Checked = True Then
            ComboBox_Bill.Enabled = True
            nameF = TextLine(0).ToString
            serverfile = TextLine_Server(0).ToString()
            Dim dateSel As DateTime
            If CInt(DateTimePicker1.Value.ToString("yyyy")) > 2450 Then
                dateSel = CInt(DateTimePicker1.Value.ToString("yyyy")) - 543 & DateTimePicker1.Value.ToString("-MM-dd")
            Else
                dateSel = DateTimePicker1.Value.ToString("yyyy-MM-dd")
            End If
            Ldata_Bill(dateSel.ToString("yyyy-MM-dd"))
        Else
            ComboBox_Bill.Enabled = False
        End If
    End Sub
End Class