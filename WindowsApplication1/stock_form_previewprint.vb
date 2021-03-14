Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Windows.Forms
Imports System
Imports System.IO
Imports System.Text
Public Class stock_form_previewprint
    Dim con As New Mysql
    Private Sub stock_form_previewprint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
    Public Sub preview_inventory(ByRef dmy)
        Try
            For Each filepath As String In Directory.GetFiles("temp\")
                File.Delete(filepath)
            Next
            FileCopy(Login.pathreport & "report\rpt_new\Fix\inventory.rpt", "temp\inventory.rpt")
            Dim cryRpt As New ReportDocument
            cryRpt.Load("temp\inventory.rpt")
            cryRpt.SetParameterValue("date_input", dmy)
            cryRpt.PrintOptions.PaperSize = CType(System.Drawing.Printing.PaperKind.A4, CrystalDecisions.Shared.PaperSize)
            CrystalReportViewer1.ReportSource = cryRpt
            CrystalReportViewer1.Refresh()
        Catch ex As Exception
            ' MessageBox.Show(ex.Message.ToString() & "Error Printing Please Contact Support.!", "Msg", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub preview_inventory_current()
        Try
            For Each filepath As String In Directory.GetFiles("temp\")
                File.Delete(filepath)
            Next
            FileCopy(Login.pathreport & "report\rpt_new\Fix\inventory_current.rpt", "temp\inventory_current.rpt")
            Dim cryRpt As New ReportDocument
            cryRpt.Load("temp\inventory_current.rpt")
            cryRpt.PrintOptions.PaperSize = CType(System.Drawing.Printing.PaperKind.A4, CrystalDecisions.Shared.PaperSize)
            CrystalReportViewer1.ReportSource = cryRpt
            CrystalReportViewer1.Refresh()
        Catch ex As Exception
            ' MessageBox.Show(ex.Message.ToString() & "Error Printing Please Contact Support.!", "Msg", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub print_inventory(ByRef dmy)
        Try
            For Each filepath As String In Directory.GetFiles("temp\")
                File.Delete(filepath)
            Next
            FileCopy(Login.pathreport & "report\rpt_new\Fix\inventory.rpt", "temp\inventory.rpt")
            Dim cryRpt As New ReportDocument
            cryRpt.Load("temp\inventory.rpt")
            cryRpt.SetParameterValue("date_input", dmy)
            cryRpt.PrintOptions.PaperSize = CType(System.Drawing.Printing.PaperKind.A4, CrystalDecisions.Shared.PaperSize)
            CrystalReportViewer1.ReportSource = cryRpt
            CrystalReportViewer1.Refresh()
            CrystalReportViewer1.PrintReport()
            'cryRpt.PrintToPrinter(1, True, 0, 0)
        Catch ex As Exception
            ' MessageBox.Show(ex.Message.ToString() & "Error Printing Please Contact Support.!", "Msg", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub print_inventory_current()
        Try
            For Each filepath As String In Directory.GetFiles("temp\")
                File.Delete(filepath)
            Next
            FileCopy(Login.pathreport & "report\rpt_new\Fix\inventory_current.rpt", "temp\inventory_current.rpt")
            Dim cryRpt As New ReportDocument
            cryRpt.Load("temp\inventory_current.rpt")
            cryRpt.PrintOptions.PaperSize = CType(System.Drawing.Printing.PaperKind.A4, CrystalDecisions.Shared.PaperSize)
            CrystalReportViewer1.ReportSource = cryRpt
            CrystalReportViewer1.Refresh()
            CrystalReportViewer1.PrintReport()
            'cryRpt.PrintToPrinter(1, True, 0, 0)
        Catch ex As Exception
            ' MessageBox.Show(ex.Message.ToString() & "Error Printing Please Contact Support.!", "Msg", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub preview_history_recript(ByRef dmy)
        ' Try
        For Each filepath As String In Directory.GetFiles("temp\")
            File.Delete(filepath)
        Next
        FileCopy(Login.pathreport & "report\rpt_new\Fix\recript_history.rpt", "temp\recript_history.rpt")
        Dim cryRpt As New ReportDocument
        cryRpt.Load("temp\recript_history.rpt")
        cryRpt.SetParameterValue("date_input", dmy)
        cryRpt.PrintOptions.PaperSize = CType(System.Drawing.Printing.PaperKind.A4, CrystalDecisions.Shared.PaperSize)
        CrystalReportViewer1.ReportSource = cryRpt
        CrystalReportViewer1.Refresh()
        ' Catch ex As Exception
        'MessageBox.Show(ex.Message.ToString() & "Error Printing Please Contact Support.!", "Msg", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ' End Try
    End Sub
    Public Sub print_history_recript(ByRef dmy)
        Try
            For Each filepath As String In Directory.GetFiles("temp\")
                File.Delete(filepath)
            Next
            FileCopy(Login.pathreport & "report\rpt_new\Fix\recript_history.rpt", "temp\recript_history.rpt")
            Dim cryRpt As New ReportDocument
            cryRpt.Load("temp\recript_history.rpt")
            cryRpt.SetParameterValue("date_input", dmy)
            cryRpt.PrintOptions.PaperSize = CType(System.Drawing.Printing.PaperKind.A4, CrystalDecisions.Shared.PaperSize)
            CrystalReportViewer1.ReportSource = cryRpt
            CrystalReportViewer1.Refresh()
            CrystalReportViewer1.PrintReport()
            'cryRpt.PrintToPrinter(1, True, 0, 0)
        Catch ex As Exception
            ' MessageBox.Show(ex.Message.ToString() & "Error Printing Please Contact Support.!", "Msg", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class