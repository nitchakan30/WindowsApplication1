Imports MySql.Data.MySqlClient
Public Class stock_inventory
    Dim con As New Mysql
    Dim dateN As DateTime
    Private Sub stock_inventory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If CInt(Login.DateData.ToString("yyyy")) > 2450 Then
            dateN = CInt(Login.DateData.ToString("yyyy")) - 543 & Login.DateData.ToString("-MM-dd")
        Else
            dateN = Login.DateData.ToString("yyyy-MM-dd")
        End If
        ' LoadInventory_Today()
        LoadInventory_Today_New()
        ' LoadInventory(dateN.ToString("dd"), dateN.ToString("MM"), dateN.ToString("yyyy"))
    End Sub
    Private Sub DataGridView2_CellMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView2.CellMouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim dateSel As DateTime
            If CInt(DateTimePicker1.Value.ToString("yyyy")) > 2450 Then
                dateSel = CInt(DateTimePicker1.Value.ToString("yyyy")) - 543 & DateTimePicker1.Value.ToString("-MM-dd")
            Else
                dateSel = DateTimePicker1.Value.ToString("yyyy-MM-dd")
            End If
            Dim y As Integer = 0
            If CInt(Date.Now.ToString("yyyy")) > 2450 Then
                y = CInt(Date.Now.ToString("yyyy")) - 543
            Else
                y = CInt(Date.Now.ToString("yyyy"))
            End If
            If Date.Now.ToString("yyyy-MM-dd") = DateTimePicker1.Value.ToString("yyyy-MM-dd") Then
                ContextMenuStrip1.Show(Cursor.Position)
            End If
        End If
    End Sub
    Private Sub ShowData()
        Dim dateSel As DateTime
        If CInt(DateTimePicker1.Value.ToString("yyyy")) > 2450 Then
            dateSel = CInt(DateTimePicker1.Value.ToString("yyyy")) - 543 & DateTimePicker1.Value.ToString("-MM-dd")
        Else
            dateSel = DateTimePicker1.Value.ToString("yyyy-MM-dd")
        End If
        Dim y As Integer = 0
        If CInt(Date.Now.ToString("yyyy")) > 2450 Then
            y = CInt(Date.Now.ToString("yyyy")) - 543
        Else
            y = CInt(Date.Now.ToString("yyyy"))
        End If
        If Date.Now.ToString("yyyy-MM-dd") = DateTimePicker1.Value.ToString("yyyy-MM-dd") Then
            ' LoadInventory_Today()
            LoadInventory_Today_New()
        Else
            LoadInventory(dateSel.ToString("dd"), dateSel.ToString("MM"), dateSel.ToString("yyyy"))
        End If
    End Sub
    Public Sub LoadInventory(ByVal d, ByVal m, ByVal y)
        DataGridView2.Rows.Clear()
        Dim dt As MySqlDataReader
        dt = con.mysql_query("select pos_product_stock.stk_id as stk_id,pos_product_stock.stk_id_prd as stk_id_prd," _
      & "pos_product_stock.stk_id_prd_con as stk_id_prd_con,pos_product_stock.stk_ref_unit as stk_ref_unit,pos_product_stock.stk_barcode as stk_barcode," _
      & "pos_product_stock.stk_nameprd_th as stk_nameprd_th,pos_product_stock.stk_nameprd_en as stk_nameprd_en,IFNULL(pos_product_unit.name_th,'-') as name_th_unit," _
      & "pos_product_stock.stk_amount as stk_amount,pos_product_stock.stk_create_date as stk_create_date" _
      & " from pos_product_stock LEFT JOIN pos_product_unit ON pos_product_unit.id = pos_product_stock.stk_ref_unit " _
      & " where DAY(pos_product_stock.stk_create_date)='" & d & "' and MONTH(pos_product_stock.stk_create_date)='" & m & "' and YEAR(pos_product_stock.stk_create_date)='" & y & "' ")
        Dim i As Integer = 1
        While dt.Read()
            Dim n As Integer = DataGridView2.Rows.Add()
            DataGridView2.Rows.Item(n).Cells(0).Value = dt.GetString("stk_id")
            DataGridView2.Rows.Item(n).Cells(1).Value = dt.GetString("stk_id_prd")
            DataGridView2.Rows.Item(n).Cells(2).Value = dt.GetString("stk_id_prd_con")
            DataGridView2.Rows.Item(n).Cells(3).Value = dt.GetString("stk_ref_unit")
            DataGridView2.Rows.Item(n).Cells(4).Value = i
            DataGridView2.Rows.Item(n).Cells(5).Value = dt.GetString("stk_barcode")
            DataGridView2.Rows.Item(n).Cells(6).Value = dt.GetString("stk_nameprd_th")
            DataGridView2.Rows.Item(n).Cells(7).Value = dt.GetString("stk_nameprd_en")
            DataGridView2.Rows.Item(n).Cells(8).Value = dt.GetString("name_th_unit")
            DataGridView2.Rows.Item(n).Cells(9).Value = CInt(dt.GetString("stk_amount"))
            DataGridView2.Rows.Item(n).Cells(10).Value = dt.GetDateTime("stk_create_date").ToString("dd/MM/yyyy HH:mm:ss")
            If i Mod 2 = 0 Then
                DataGridView2.Rows.Item(n).DefaultCellStyle.BackColor = Color.Beige
            End If
            i += 1
        End While
        dt.Close()
    End Sub
    Public Sub LoadInventory_Today()
        DataGridView2.Rows.Clear()
        Dim dt As MySqlDataReader
        dt = con.mysql_query("select pos_product.id as id,pos_product.number_prd as number_prd,pos_product.ref_unit as ref_unit," _
     & "pos_product.nameprd_th as nameprd_th,pos_product.nameprd_en as nameprd_en,IFNULL(pos_product_unit.name_th,'-') as name_th_unit" _
     & " ,pos_product.amount as amount,pos_product.update_date as update_date,IFNULL(pos_product_condition.id,'0') as id_con " _
    & "    from(pos_product) " _
     & " LEFT JOIN pos_product_unit ON pos_product_unit.id = pos_product.ref_unit  " _
     & " LEFT JOIN pos_product_condition ON  pos_product_condition.ref_id_prd = pos_product.id  where id_status_table='0' " _
     & "   UNION " _
& " select pos_product_condition.ref_id_prd AS id,pos_product_condition.barcode as number_prd,pos_product_condition.ref_id_unit as ref_unit, " _
& " pos_product.nameprd_th as nameprd_th,pos_product.nameprd_en as nameprd_en,IFNULL(pos_product_unit.name_th,'-') as name_th_unit," _
& " pos_product_condition.amount as amount,pos_product.update_date as update_date,IFNULL(pos_product_condition.id,'0') as id_con " _
 & "  from pos_product_condition  LEFT JOIN pos_product ON pos_product.id = pos_product_condition.ref_id_prd  " _
 & " LEFT JOIN pos_product_unit ON pos_product_unit.id = pos_product.ref_unit " _
& "where pos_product_condition.ref_id_ingredients > 0 and  pos_product.id_status_table='0'")
        Dim i As Integer = 1
        While dt.Read()
            Dim n As Integer = DataGridView2.Rows.Add()
            DataGridView2.Rows.Item(n).Cells(0).Value = dt.GetString("id")
            DataGridView2.Rows.Item(n).Cells(1).Value = dt.GetString("id")
            DataGridView2.Rows.Item(n).Cells(2).Value = dt.GetString("id_con")
            DataGridView2.Rows.Item(n).Cells(3).Value = dt.GetString("ref_unit")
            DataGridView2.Rows.Item(n).Cells(4).Value = i
            DataGridView2.Rows.Item(n).Cells(5).Value = dt.GetString("number_prd")
            DataGridView2.Rows.Item(n).Cells(6).Value = dt.GetString("nameprd_th")
            DataGridView2.Rows.Item(n).Cells(7).Value = dt.GetString("nameprd_en")
            DataGridView2.Rows.Item(n).Cells(8).Value = dt.GetString("name_th_unit")
            DataGridView2.Rows.Item(n).Cells(9).Value = CInt(dt.GetString("amount"))
            DataGridView2.Rows.Item(n).Cells(10).Value = Date.Now.ToString("dd/MM/yyyy HH:mm:ss")
            If i Mod 2 = 0 Then
                DataGridView2.Rows.Item(n).DefaultCellStyle.BackColor = Color.Beige
                End If
            i += 1
            End While
        dt.Close()
    End Sub
    Public Sub LoadInventory_Today_New()
        DataGridView2.Rows.Clear()
        Dim dt As MySqlDataReader
        dt = con.mysql_query("select * from pos_product_inv order by inv_barcode asc")
        Dim i As Integer = 1
        While dt.Read()
            Dim n As Integer = DataGridView2.Rows.Add()
            DataGridView2.Rows.Item(n).Cells(0).Value = dt.GetString("inv_barcode")
            DataGridView2.Rows.Item(n).Cells(1).Value = dt.GetString("inv_barcode")
            DataGridView2.Rows.Item(n).Cells(2).Value = dt.GetString("inv_prd_con")
            DataGridView2.Rows.Item(n).Cells(3).Value = dt.GetString("inv_unit_id")
            DataGridView2.Rows.Item(n).Cells(4).Value = i
            DataGridView2.Rows.Item(n).Cells(5).Value = dt.GetString("inv_barcode")
            DataGridView2.Rows.Item(n).Cells(6).Value = dt.GetString("inv_name_th")
            DataGridView2.Rows.Item(n).Cells(7).Value = dt.GetString("inv_name_en")
            DataGridView2.Rows.Item(n).Cells(8).Value = dt.GetString("inv_unit_name")
            DataGridView2.Rows.Item(n).Cells(9).Value = CInt(dt.GetString("inv_amount"))
            DataGridView2.Rows.Item(n).Cells(10).Value = Date.Now.ToString("dd/MM/yyyy HH:mm:ss")
            If i Mod 2 = 0 Then
                DataGridView2.Rows.Item(n).DefaultCellStyle.BackColor = Color.Beige
            End If
            i += 1
        End While
        dt.Close()
    End Sub
    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        ShowData()
    End Sub

    Private Sub btn_search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_search.Click
        ShowData()
    End Sub
    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Dim dateSel As DateTime
        If CInt(DateTimePicker1.Value.ToString("yyyy")) > 2450 Then
            dateSel = CInt(DateTimePicker1.Value.ToString("yyyy")) - 543 & DateTimePicker1.Value.ToString("-MM-dd")
        Else
            dateSel = DateTimePicker1.Value.ToString("yyyy-MM-dd")
        End If
        If Date.Now.ToString("yyyy-MM-dd") = DateTimePicker1.Value.ToString("yyyy-MM-dd") Then
            stock_form_previewprint.preview_inventory_current()
            stock_form_previewprint.Show()
        Else
            stock_form_previewprint.preview_inventory(DateTimePicker1.Value.ToString("dd/MM/yyyy"))
            stock_form_previewprint.Show()
        End If
        
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Dim dateSel As DateTime
        If CInt(DateTimePicker1.Value.ToString("yyyy")) > 2450 Then
            dateSel = CInt(DateTimePicker1.Value.ToString("yyyy")) - 543 & DateTimePicker1.Value.ToString("-MM-dd")
        Else
            dateSel = DateTimePicker1.Value.ToString("yyyy-MM-dd")
        End If
        If Date.Now.ToString("yyyy-MM-dd") = DateTimePicker1.Value.ToString("yyyy-MM-dd") Then
            stock_form_previewprint.print_inventory_current()
        Else
            stock_form_previewprint.print_inventory(DateTimePicker1.Value.ToString("dd/MM/yyyy"))
        End If

    End Sub
    Public cut_rep As Boolean = False
    Private Sub cut_prd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cut_prd.Click
        Admin.Str = "cut_recript"
        Admin.ShowDialog()
        If cut_rep = True Then
            Dim i As Integer
            i = DataGridView2.CurrentRow.Index
            stock_cut_prd.amountold = DataGridView2.Item(9, i).Value
            stock_cut_prd.barcode = DataGridView2.Item(5, i).Value
            stock_cut_prd.ShowDialog()
        End If
    End Sub
    Public Function cutSTK(ByVal barcode, ByVal amt, ByVal amountold, ByVal des)
        Dim tf As Boolean = False
        'Check IS Product Not on Table is = 0
        Dim ck As Integer = con.mysql_num_rows(con.mysql_query("SELECT * from pos_product_inv where inv_barcode='" & barcode & "'"))
        Dim str1 As String = ""
        If ck > 0 Then
            Dim amt1 As Integer = CInt(amountold) - CInt(amt)
            str1 &= "UPDATE pos_product_inv SET inv_amount ='" & amt1 & "',update_by='" & Login.username & "' WHERE inv_barcode='" & barcode & "'; "
            str1 &= "INSERT INTO pos_product_recript_cut (ref_barcode,description_rcp_cut,amount_rcp_cut,action_rcp_cut) VALUES('" & barcode & "','" & des & "','" & amt & "','" & Login.username & "');"
            tf = con.mysql_query(str1)
        End If
        Return tf
    End Function
End Class