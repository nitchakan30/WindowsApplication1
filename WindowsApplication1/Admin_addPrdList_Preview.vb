Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System
Imports System.IO
Imports System.Text
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Windows.Forms
Public Class Admin_addPrdList_Preview
    Dim con As New Mysql
    Private Sub Admin_addPrdList_Preview_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' preview_product()
    End Sub
    Public Sub preview_product()
        Try
            For Each filepath As String In Directory.GetFiles("temp\")
                File.Delete(filepath)
            Next
            FileCopy(Login.pathreport & "\rpt_new\Fix\product_list.rpt", "temp\product_list.rpt")
            Dim cryRpt As New ReportDocument
            cryRpt.Load("temp\product_list.rpt")
            cryRpt.PrintOptions.PaperSize = CType(System.Drawing.Printing.PaperKind.A4, CrystalDecisions.Shared.PaperSize)
            CrystalReportViewer1.ReportSource = cryRpt
            CrystalReportViewer1.Refresh()
        Catch ex As Exception
            ' MessageBox.Show(ex.Message.ToString() & "Error Printing Please Contact Support.!", "Msg", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class