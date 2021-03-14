Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Windows.Forms
Imports System.Data
Public Class testprint1
    Dim cryRpt As New ReportDocument
    Dim con As New Mysql
    Private Sub testprint1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


    End Sub
    Public Sub RuningInv()
        Login.DateData = Date.Now()
        Dim num As String = ""
        Dim ymd As String = Login.DateData.ToString("yyMMdd")
        Dim str1 As Integer = 0
        Dim f As String = ""
        Dim u As Integer = 0
        Dim res_num As MySqlDataReader = con.mysql_query("select * from pos_num_runing")
        While res_num.Read()
            If res_num.GetString("y_rn_inv_st") = "1" Then
                If res_num.GetString("y_rn_inv_st").Length >= 1 And res_num.GetString("y_rn_inv_st") <= 2 Then
                    num += Login.DateData.ToString("yy")
                Else
                    num += Login.DateData.ToString("yyyy")
                End If
            End If
            If res_num.GetString("m_rn_inv_st") = "1" Then
                num += Login.DateData.ToString("MM")
            End If
            If res_num.GetString("d_rn_inv_st") = "1" Then
                num += Login.DateData.ToString("dd")
            End If
            u = res_num.GetString("num_rn_inv").Length

            Dim res As MySqlDataReader = con.mysql_query("select IFNULL(MAX(namber_inv),0) AS max1 from pos_invoice")
            While res.Read()
                If res.GetString("max1") <> "" Then
                    str1 = CInt((Microsoft.VisualBasic.Right(res.GetString("max1"), u)))
                Else
                    str1 = 0
                End If
            End While

        End While

        'INVOICE NUMBER
        str1 = str1 + 1
        Dim string1 As String = ""
        For value As Integer = u - 1 To CInt(CStr(str1).Length) Step -1
            f &= "0"
        Next
        f &= str1
        TextBox1.Text = num & f
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'cryRpt.Load("report\payment.rpt")
        'cryRpt.SetParameterValue("invoice_number", TextBox1.Text)
        'cryRpt.SetParameterValue("recript_m", 1000)
        'cryRpt.SetParameterValue("ton_m", 500)
        ' CrystalReportViewer1.ReportSource = cryRpt
        ' CrystalReportViewer1.Refresh()
        'cryRpt.PrintOptions.PrinterName = "EPSON L800 Series"
        '  cryRpt.PrintToPrinter(1, True, 0, 0)
        Connect_Report()


    End Sub

    Public Sub Connect_Report()
        'Dim objConn As New SqlConnection
        'Dim objCmd As New SqlCommand
        'Dim dtAdapter As New SqlDataAdapter

        ''  Dim ds As New posDataSet
        'Dim dt As DataTable
        'Dim strConnString, strSQL As String

        'strConnString = "Server=localhost;UID=root;PASSWORD=root;database=pos;"
        'strSQL = "SELECT * FROM pos_order_list"

        'objConn.ConnectionString = strConnString
        'With objCmd
        '    .Connection = objConn
        '    .CommandText = strSQL
        '    .CommandType = CommandType.Text
        'End With
        'dtAdapter.SelectCommand = objCmd
        'dtAdapter.Fill(ds, "myDataSet")
        'dt = ds.Tables(0)

        'dtAdapter = Nothing
        'objConn.Close()
        'objConn = Nothing

        'Dim rpt As New ReportDocument()
        'Dim directory As String = My.Application.Info.DirectoryPath
        'rpt.Load("report\test.rpt")
        'rpt.SetDataSource(dt)
        'Me.CrystalReportViewer2.ReportSource = rpt
        'Me.CrystalReportViewer2.Refresh()
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        RuningInv()
    End Sub
End Class