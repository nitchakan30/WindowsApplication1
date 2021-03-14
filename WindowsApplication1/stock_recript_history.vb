Imports MySql.Data.MySqlClient
Public Class stock_recript_history
    Dim con As New MysqlTimer
    Dim dateN As DateTime
    Private Sub stock_recript_history_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        btn_edit.Enabled = True
        btn_save.Enabled = False
        btn_cancel.Enabled = False
    End Sub
    Private Sub stock_recript_history_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If CInt(Login.DateData.ToString("yyyy")) > 2450 Then
            dateN = CInt(Login.DateData.ToString("yyyy")) - 543 & Login.DateData.ToString("-MM-dd")
        Else
            dateN = Login.DateData.ToString("yyyy-MM-dd")
        End If
        LoadHistoryStiockH(dateN.ToString("dd"), dateN.ToString("MM"), dateN.ToString("yyyy"))
    End Sub
    Public Sub LoadHistoryStiockH(ByVal d, ByVal m, ByVal y)
        Dim dt As MySqlDataReader = con.mysql_query("select * from pos_product_recript where DAY(rcp_createdate)='" & d & "' and MONTH(rcp_createdate)='" & m & "' and YEAR(rcp_createdate)='" & y & "' GROUP BY rcp_number order by rcp_createdate desc ")
        Dim i As Integer = 1
        DataGridView2.Rows.Clear()
        While dt.Read()
            Dim n As Integer = DataGridView2.Rows.Add()
            DataGridView2.Rows.Item(n).Cells(0).Value = dt.GetString("rcp_number")
            DataGridView2.Rows.Item(n).Cells(1).Value = i
            DataGridView2.Rows.Item(n).Cells(2).Value = dt.GetString("rcp_number")
            If i Mod 2 = 0 Then
                DataGridView2.Rows.Item(n).DefaultCellStyle.BackColor = Color.Beige
            End If
            i += 1
        End While
        dt.Close()
    End Sub
    Public Sub LoadHistoryStiock(ByVal d, ByVal m, ByVal y, ByVal num_r)
        Dim dt As MySqlDataReader = con.mysql_query("select * from pos_product_recript where DAY(rcp_createdate)='" & d & "' and MONTH(rcp_createdate)='" & m & "' and YEAR(rcp_createdate)='" & y & "' and rcp_number='" & num_r & "' order by rcp_createdate desc ")
        Dim i As Integer = 1
        DataGridView1.Rows.Clear()
        While dt.Read()
            Dim n As Integer = DataGridView1.Rows.Add()
            DataGridView1.Rows.Item(n).Cells(0).Value = dt.GetString("rcp_id")
            DataGridView1.Rows.Item(n).Cells(1).Value = dt.GetString("rcp_ref_id_prd")
            DataGridView1.Rows.Item(n).Cells(2).Value = dt.GetString("rcp_ref_id_prd_con")
            DataGridView1.Rows.Item(n).Cells(3).Value = dt.GetString("rcp_ref_id_unit")
            DataGridView1.Rows.Item(n).Cells(4).Value = i
            DataGridView1.Rows.Item(n).Cells(5).Value = dt.GetString("barcode")
            DataGridView1.Rows.Item(n).Cells(6).Value = dt.GetString("rcp_nameprd_th")
            DataGridView1.Rows.Item(n).Cells(7).Value = dt.GetString("rcp_nameprd_en")
            DataGridView1.Rows.Item(n).Cells(8).Value = dt.GetString("rcp_name_unit_th")
            DataGridView1.Rows.Item(n).Cells(9).Value = CInt(dt.GetString("rcp_amount"))
            DataGridView1.Rows.Item(n).Cells(10).Value = dt.GetDateTime("rcp_createdate").ToString("dd/MM/yyyy HH:mm:ss")
            DataGridView1.Rows.Item(n).Cells(11).Value = dt.GetString("rcp_action_by")
            DataGridView1.Rows.Item(n).Cells(12).Value = dt.GetString("rcp_update_by")
            If i Mod 2 = 0 Then
                DataGridView1.Rows.Item(n).DefaultCellStyle.BackColor = Color.Beige
            End If
            i += 1
        End While
        dt.Close()
    End Sub
    Private Sub ShowData()
        Dim dateSel As DateTime
        If CInt(DateTimePicker1.Value.ToString("yyyy")) > 2450 Then
            dateSel = CInt(DateTimePicker1.Value.ToString("yyyy")) - 543 & DateTimePicker1.Value.ToString("-MM-dd")
        Else
            dateSel = DateTimePicker1.Value.ToString("yyyy-MM-dd")
        End If
        DataGridView1.Rows.Clear()
        LoadHistoryStiockH(dateSel.ToString("dd"), dateSel.ToString("MM"), dateSel.ToString("yyyy"))
    End Sub
    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        ShowData()
    End Sub

    Private Sub btn_search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_search.Click
        ShowData()
    End Sub
    
    Private Sub btn_edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_edit.Click
        btn_edit.Enabled = False
        btn_save.Enabled = True
        btn_cancel.Enabled = True
    End Sub

    Private Sub btn_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancel.Click
        btn_edit.Enabled = True
        btn_save.Enabled = False
        btn_cancel.Enabled = False
    End Sub

    Private Sub btn_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_save.Click
        btn_edit.Enabled = True
        btn_save.Enabled = False
        btn_cancel.Enabled = False
    End Sub
    Private Sub DataGridView2_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellClick
        Dim dateSel As DateTime
        If CInt(DateTimePicker1.Value.ToString("yyyy")) > 2450 Then
            dateSel = CInt(DateTimePicker1.Value.ToString("yyyy")) - 543 & DateTimePicker1.Value.ToString("-MM-dd")
        Else
            dateSel = DateTimePicker1.Value.ToString("yyyy-MM-dd")
        End If
        LoadHistoryStiock(dateSel.ToString("dd"), dateSel.ToString("MM"), dateSel.ToString("yyyy"), DataGridView2.CurrentRow.Cells(0).Value)
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        stock_form_previewprint.preview_history_recript(DateTimePicker1.Value.ToString("dd/MM/yyyy"))
        stock_form_previewprint.Show()
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        stock_form_previewprint.print_history_recript(DateTimePicker1.Value.ToString("dd/MM/yyyy"))
    End Sub

End Class