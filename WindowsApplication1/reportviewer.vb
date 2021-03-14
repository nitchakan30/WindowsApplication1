Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Windows.Forms
Imports System.Data
Public Class reportviewer
    Dim cryRpt As New ReportDocument
    Private Sub reportviewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      
    End Sub
    Public Sub loadReport(ByVal pr)
        Try

            cryRpt.Load("report\" & pr & ".rpt")
            'cryRpt.SetParameterValue("invoice_number", TextBox1.Text)
            'cryRpt.SetParameterValue("recript_m", 1000)
            'cryRpt.SetParameterValue("ton_m", 500)
            CrystalReportViewer1.ReportSource = cryRpt
            CrystalReportViewer1.Refresh()
            'cryRpt.PrintOptions.PrinterName = "EPSON L800 Series"
            '  cryRpt.PrintToPrinter(1, True, 0, 0)
            'Me.ReportViewer1.RefreshReport()
            ' Me.ReportViewer1.RefreshReport()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub btn_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_close.Click
        Me.Close()
        index.openCloseMenu(home1)
    End Sub

    Private Sub rpt_saleDay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rpt_saleDay.Click
        loadReport("formpaybalance_day")
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        loadReport("formpaybalance_typepay")
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        loadReport("formpaybalance_group")
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        loadReport("formpaybalance_cate")
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        loadReport("formpaybalance_emp")
    End Sub
End Class