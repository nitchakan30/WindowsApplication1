Imports MySql.Data.MySqlClient
Public Class form_ropday
    Dim con As New Mysql
    Dim ac As New Admin_ClassMain
    Dim print As New printClass
    Private Sub form_ropday_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label1.Text = "ข้อมูลขาย ประจำวันที่ " & Login.DateData.ToString("dd/MM/yyyy")
        TextBox1.Text = ""
        TextBox2.Text = ""
        loaddetail()
        summary_rop()
        summary_typepay()
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TextBox1.Text = ""
        TextBox2.Text = ""
        Me.Close()
        index.CloseForm()
        index.ishomeopen = True
        home1.MdiParent = index
        home1.Show()
        home1.WindowState = FormWindowState.Minimized
        home1.WindowState = FormWindowState.Maximized
        Login.Formname = "home1"
        ' index.openCloseMenu(home1)
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_clear.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
    End Sub
    Public Sub loaddetail()
        'คำนวณหารายได้ที่ขายได้
        ListView1.Items.Clear()
        'Date Old 
        Dim yearOld As String
        If CInt(Login.DateData.ToString("yyyy")) > 2450 Then
            yearOld = CInt(Login.DateData.ToString("yyyy")) - 543
        Else
            yearOld = CInt(Login.DateData.ToString("yyyy"))
        End If
        Dim dnew As DateTime = yearOld & "-" & Login.DateData.ToString("MM-dd")

        Dim itmx1 As New ListViewItem
        Dim resLoad As MySqlDataReader = con.mysql_query("SELECT *,SUM(pos_closebilldetail.camt) AS samt" _
           & ",pos_payment_type.name AS namePayType,SUM(pos_invoice.price_all) AS sumprice,pos_invoice.serviceCh AS serviceCh," _
           & " pos_invoice.discount_des AS discount_des,pos_invoice.void AS void,pos_invoice.discount_sum As discount_sum,pos_closebilldetail.machine_closedetail as machine_closedetail  FROM ((pos_invoice " _
            & "INNER JOIN pos_closebilldetail ON  pos_closebilldetail.crf_id_invoice=pos_invoice.id )" _
            & "LEFT JOIN pos_payment_type ON pos_payment_type.id = pos_invoice.rf_payment_type)" _
            & " WHERE pos_closebilldetail.close_day='0000-00-00' and pos_closebilldetail.ccreate_date LIKE '%" & dnew.ToString("yyyy-MM-dd") & "%' " _
            & " GROUP BY pos_invoice.id order by pos_invoice.namber_inv DESC")
        ' and pos_closebilldetail.machine_closedetail='" & Login.getMacAddress() & "'

        Dim y As Integer = 0
        Dim sumAll As Double = 0.0
        While resLoad.Read
            itmx1 = ListView1.Items.Add((y + 1).ToString, y)
            itmx1.SubItems.Add(resLoad.GetString("namber_inv"))
            itmx1.SubItems.Add(resLoad.GetString("samt"))
            itmx1.SubItems.Add(FormatNumber(resLoad.GetString("price_all"), 2))
            itmx1.SubItems.Add(FormatNumber(resLoad.GetString("vat"), 2))
            itmx1.SubItems.Add(FormatNumber(resLoad.GetString("price_exclu_vat"), 2))
            itmx1.SubItems.Add(FormatNumber(resLoad.GetString("serviceCh"), 2))
            itmx1.SubItems.Add(FormatNumber(resLoad.GetString("discount_sum"), 2))
            itmx1.SubItems.Add(resLoad.GetString("discount_des"))
            itmx1.SubItems.Add(resLoad.GetString("namePayType"))
            itmx1.SubItems.Add(resLoad.GetString("des_payment"))
            ' itmx1.SubItems.Add(resLoad.GetString("ref_id_payment_acc"))
            itmx1.SubItems.Add(resLoad.GetString("name_closebill"))
            itmx1.SubItems.Add(resLoad.GetString("machine_inv"))
            If CInt(resLoad.GetString("Void")) = 1 Then
                itmx1.ForeColor = Color.Red
                'sumAll -= CDbl(resLoad.GetString("price_all"))
            Else
                sumAll += CDbl(resLoad.GetString("price_all"))
            End If
            y += 1
        End While
        TextBox3.Text = FormatNumber(sumAll, 2)
    End Sub
    Public Sub summary_rop()
        Dim year As Integer
        If CInt(Login.DateData.ToString("yyyy")) > 2480 Then
            year = CInt(Login.DateData.ToString("yyyy")) - 543
        Else
            year = CInt(Login.DateData.ToString("yyyy"))
        End If

        Dim dt_n As DateTime = year & Login.DateData.ToString("-MM-dd")
        Dim i As Integer = 0
        Dim itmx1 As New ListViewItem
        Dim res As MySqlDataReader = con.mysql_query("select * from pos_audit where DAY(rop_date_aud)='" & dt_n.ToString("dd") & "' and MONTH(rop_date_aud)='" & dt_n.ToString("MM") & "' and YEAR(rop_date_aud)='" & dt_n.ToString("yyyy") & "' ORDER BY id_aud ASC") 'machine_aud='" & Login.getMacAddress() & "' and
        While res.Read()
            itmx1 = ListView_RopSum.Items.Add(res.GetString("name_rop_aud"), i)
            itmx1.SubItems.Add(FormatNumber(res.GetString("money_aud"), 2))
            itmx1.SubItems.Add(FormatNumber(Cal_priceRop(res.GetString("id_aud"), dt_n), 2))
            itmx1.SubItems.Add(res.GetString("machine_aud"))
            i += 1
        End While
    End Sub
    Public Sub summary_typepay()
        Dim year As Integer
        If CInt(Login.DateData.ToString("yyyy")) > 2480 Then
            year = CInt(Login.DateData.ToString("yyyy")) - 543
        Else
            year = CInt(Login.DateData.ToString("yyyy"))
        End If
        Dim dt_n As DateTime = year & Login.DateData.ToString("-MM-dd")
   
        Dim r As MySqlDataReader = con.mysql_query("SELECT SUM(pos_invoice.price_all) as price_all,pos_payment_type.name as name_t " _
        & " from pos_invoice " _
        & " INNER JOIN pos_payment_type ON pos_payment_type.id = pos_invoice.rf_payment_type " _
        & " WHERE DAY(pos_invoice.create_date)='" & dt_n.ToString("dd") & "' and MONTH(pos_invoice.create_date)='" & dt_n.ToString("MM") & "' and YEAR(pos_invoice.create_date)='" & dt_n.ToString("yyyy") & "' " _
        & " and pos_invoice.void='0' and pos_invoice.money_recript>'0' GROUP BY pos_payment_type.id ")
      
        Dim b As Integer = 1
        Dim itmx1 As New ListViewItem
        While r.Read
            itmx1 = ListView2.Items.Add(b.ToString, b - 1)
            itmx1.SubItems.Add(r.GetString("name_t"))
            itmx1.SubItems.Add(FormatNumber(r.GetString("price_all"), 2))
            b += 1
        End While
        r.Close()
    End Sub
    Public Function Cal_priceRop(ByRef id_rop, ByRef date1)
        Dim cp As Double = 0.0
        Dim dt As DateTime = date1
        Dim res As MySqlDataReader = con.mysql_query("SELECT pos_invoice.price_all as price_all FROM pos_closebilldetail " _
        & "INNER JOIN pos_invoice ON pos_invoice.id = pos_closebilldetail.crf_id_invoice WHERE pos_closebilldetail.rf_id_closebill='" & id_rop & "' " _
        & " and DAY(pos_closebilldetail.ccreate_date)='" & dt.ToString("dd") & "' and MONTH(pos_closebilldetail.ccreate_date)='" & dt.ToString("MM") & "' " _
        & " and YEAR(pos_closebilldetail.ccreate_date)='" & dt.ToString("yyyy") & "' and pos_invoice.void<>'1' GROUP BY pos_invoice.id  ")     
        While res.Read
            cp += res.GetDouble("price_all")
        End While
        Return cp
    End Function
    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
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
    End Sub
   
    Private Sub insert_vat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles insert_vat.Click

    End Sub
End Class