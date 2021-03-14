Imports MySql.Data.MySqlClient
Public Class stock_recript
    Dim con As New MysqlTimer
    Dim i As Integer = 1
    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radio_group.CheckedChanged
        Label_qty.Visible = True
        textbox_qt.Visible = True
    End Sub
    Private Sub radio_alone_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radio_alone.CheckedChanged
        Label_qty.Visible = False
        textbox_qt.Visible = False
    End Sub
    Private Sub btn_add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_add.Click
        InsertFiled()
    End Sub
    Private Sub textbox_barcoce_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles textbox_barcoce.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            ' InsertFiled()
            InsertFiledNew()
            textbox_barcoce.Text = ""
            textbox_barcoce.Focus()
        End If
    End Sub
    Private Sub textbox_barcoce_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If textbox_barcoce.Text <> "" Then
            InsertFiled()
            textbox_barcoce.Text = ""
            textbox_barcoce.Focus()
        End If
    End Sub

    Private Sub stock_recript_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        textbox_barcoce.Text = ""
        textbox_barcoce.Focus()
    End Sub

    Private Sub btn_clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_clear.Click
        textbox_barcoce.Text = ""
        textbox_qt.Text = "0"
        textbox_barcoce.Focus()
    End Sub
    Private Sub textbox_qt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles textbox_qt.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            InsertFiled()
            textbox_barcoce.Text = ""
            textbox_barcoce.Focus()
        End If
    End Sub
    Public Function genId()
        Dim h As Integer = con.mysql_num_rows(con.mysql_query("select rcp_id as rcp_id from pos_product_recript order by rcp_id desc "))
        Dim d As MySqlDataReader
        Dim id As String = ""
        If h > 0 Then
            d = con.mysql_query("select rcp_id as rcp_id from pos_product_recript order by rcp_id desc ")
            d.Read()
            id = Now.ToString("yy") & Now.ToString("dd") & Now.ToString("MM") & Now.ToString("HH") & "_" & d.GetString("rcp_id")
            d.Close()
        Else
            id = Now.ToString("yy") & Now.ToString("dd") & Now.ToString("MM") & Now.ToString("HH") & "_1"
        End If
        Return id
    End Function
    Private Sub InsertFiled()
        If textbox_barcoce.Text <> "" Then
            Dim isH As Boolean = False
            Dim amt As Integer = 0
            If radio_alone.Checked = True And radio_group.Checked = False Then
                amt = 1
            ElseIf radio_alone.Checked = False And radio_group.Checked = True Then
                amt = CInt(textbox_qt.Text)
            End If

            Dim num_prd_con As Integer = con.mysql_num_rows(con.mysql_query("SELECT * FROM pos_product_condition WHERE barcode ='" & textbox_barcoce.Text & "' "))

            If num_prd_con > 0 Then
                Dim num As Integer = 1
                Dim prd_con As MySqlDataReader = con.mysql_query("SELECT * FROM pos_product_condition INNER JOIN pos_product ON pos_product.id = pos_product_condition.ref_id_prd LEFT JOIN pos_product_unit ON pos_product_unit.id = pos_product_condition.ref_id_unit WHERE barcode ='" & textbox_barcoce.Text & "' and id_status_table='0' order by barcode desc Limit 1 ")
                prd_con.Read()
                If DataGridView1.RowCount > 0 Then
                    For x As Integer = 0 To DataGridView1.RowCount - 1
                        If prd_con.GetString("barcode") = DataGridView1.Rows.Item(x).Cells(4).Value Then
                            DataGridView1.Rows.Item(x).Cells(8).Value += amt
                            isH = True
                        Else
                            isH = False
                        End If
                    Next
                    If isH = False Then
                        Dim n As Integer = DataGridView1.Rows.Add()
                        DataGridView1.Rows.Item(n).Cells(0).Value = prd_con.GetString("ref_id_prd")
                        DataGridView1.Rows.Item(n).Cells(1).Value = prd_con.GetString("id")
                        DataGridView1.Rows.Item(n).Cells(2).Value = prd_con.GetString("ref_id_unit")
                        DataGridView1.Rows.Item(n).Cells(3).Value = i
                        DataGridView1.Rows.Item(n).Cells(4).Value = prd_con.GetString("barcode")
                        DataGridView1.Rows.Item(n).Cells(5).Value = prd_con.GetString("nameprd_th")
                        DataGridView1.Rows.Item(n).Cells(6).Value = prd_con.GetString("nameprd_en")
                        DataGridView1.Rows.Item(n).Cells(7).Value = prd_con.GetString("name_th")
                        DataGridView1.Rows.Item(n).Cells(8).Value += amt
                        isH = False
                    End If

                Else
                    Dim n As Integer = DataGridView1.Rows.Add()
                    DataGridView1.Rows.Item(n).Cells(0).Value = prd_con.GetString("ref_id_prd")
                    DataGridView1.Rows.Item(n).Cells(1).Value = prd_con.GetString("id")
                    DataGridView1.Rows.Item(n).Cells(2).Value = prd_con.GetString("ref_id_unit")
                    DataGridView1.Rows.Item(n).Cells(3).Value = i
                    DataGridView1.Rows.Item(n).Cells(4).Value = prd_con.GetString("barcode")
                    DataGridView1.Rows.Item(n).Cells(5).Value = prd_con.GetString("nameprd_th")
                    DataGridView1.Rows.Item(n).Cells(6).Value = prd_con.GetString("nameprd_en")
                    DataGridView1.Rows.Item(n).Cells(7).Value = prd_con.GetString("name_th")
                    DataGridView1.Rows.Item(n).Cells(8).Value += amt
                    isH = False
                End If
            Else
                Dim Check_num As Integer = con.mysql_num_rows(con.mysql_query("SELECT * FROM pos_product LEFT JOIN pos_product_unit ON pos_product_unit.id = pos_product.ref_unit WHERE number_prd ='" & textbox_barcoce.Text & "' and id_status_table='0' order by number_prd desc Limit 1 "))
                If Check_num > 0 Then
                    Dim prd_main As MySqlDataReader = con.mysql_query("SELECT pos_product.id as id,IFNULL(pos_product_unit.name_th,'-') as name_th, " _
                    & "pos_product.ref_unit as ref_unit,pos_product.number_prd as number_prd,pos_product.nameprd_th as nameprd_th,pos_product.nameprd_en as nameprd_en " _
                    & " FROM pos_product LEFT JOIN pos_product_unit ON pos_product_unit.id = pos_product.ref_unit WHERE number_prd ='" & textbox_barcoce.Text & "' and id_status_table='0' order by number_prd desc Limit 1 ")
                    prd_main.Read()
                    If DataGridView1.RowCount > 0 Then
                        For x As Integer = 0 To DataGridView1.RowCount - 1
                            If prd_main.GetString("number_prd") = DataGridView1.Rows.Item(x).Cells(4).Value Then
                                DataGridView1.Rows.Item(x).Cells(8).Value += amt
                                isH = True
                            Else
                                isH = False
                            End If
                        Next
                        If isH = False Then
                            Dim n As Integer = DataGridView1.Rows.Add()
                            DataGridView1.Rows.Item(n).Cells(0).Value = prd_main.GetString("id")
                            DataGridView1.Rows.Item(n).Cells(1).Value = "0"
                            DataGridView1.Rows.Item(n).Cells(2).Value = prd_main.GetString("ref_unit")
                            DataGridView1.Rows.Item(n).Cells(3).Value = i
                            DataGridView1.Rows.Item(n).Cells(4).Value = prd_main.GetString("number_prd")
                            DataGridView1.Rows.Item(n).Cells(5).Value = prd_main.GetString("nameprd_th")
                            DataGridView1.Rows.Item(n).Cells(6).Value = prd_main.GetString("nameprd_en")
                            DataGridView1.Rows.Item(n).Cells(7).Value = prd_main.GetString("name_th")
                            DataGridView1.Rows.Item(n).Cells(8).Value += amt
                            isH = False
                        End If

                    Else
                        Dim n As Integer = DataGridView1.Rows.Add()
                        DataGridView1.Rows.Item(n).Cells(0).Value = prd_main.GetString("id")
                        DataGridView1.Rows.Item(n).Cells(1).Value = "0"
                        DataGridView1.Rows.Item(n).Cells(2).Value = prd_main.GetString("ref_unit")
                        DataGridView1.Rows.Item(n).Cells(3).Value = i
                        DataGridView1.Rows.Item(n).Cells(4).Value = prd_main.GetString("number_prd")
                        DataGridView1.Rows.Item(n).Cells(5).Value = prd_main.GetString("nameprd_th")
                        DataGridView1.Rows.Item(n).Cells(6).Value = prd_main.GetString("nameprd_en")
                        DataGridView1.Rows.Item(n).Cells(7).Value = prd_main.GetString("name_th")
                        DataGridView1.Rows.Item(n).Cells(8).Value += amt
                        isH = False
                    End If
                Else
                    MessageBox.Show("ไม่มีสินค้านี้ในระบบค่ะ", "Message Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
        End If
        i += 1
    End Sub
    Private Sub InsertFiledNew()
        If textbox_barcoce.Text <> "" Then
            Dim isH As Boolean = False
            Dim amt As Integer = 0
            If radio_alone.Checked = True And radio_group.Checked = False Then
                amt = 1
            ElseIf radio_alone.Checked = False And radio_group.Checked = True Then
                amt = CInt(textbox_qt.Text)
            End If

            Dim num_prd_con As Integer = con.mysql_num_rows(con.mysql_query("SELECT * FROM pos_product_inv WHERE inv_barcode ='" & textbox_barcoce.Text & "' "))
            If num_prd_con > 0 Then
                Dim num As Integer = 1
                Dim prd_con As MySqlDataReader = con.mysql_query("SELECT * FROM pos_product_inv WHERE inv_barcode ='" & textbox_barcoce.Text & "'  order by inv_barcode desc Limit 1 ")
                prd_con.Read()
                If DataGridView1.RowCount > 0 Then
                    For x As Integer = 0 To DataGridView1.RowCount - 1
                        If prd_con.GetString("inv_barcode") = DataGridView1.Rows.Item(x).Cells(4).Value Then
                            DataGridView1.Rows.Item(x).Cells(8).Value += amt
                            isH = True
                        Else
                            isH = False
                        End If
                    Next
                    If isH = False Then
                        Dim n As Integer = DataGridView1.Rows.Add()
                        DataGridView1.Rows.Item(n).Cells(0).Value = prd_con.GetString("inv_prd_id")
                        DataGridView1.Rows.Item(n).Cells(1).Value = "0"
                        DataGridView1.Rows.Item(n).Cells(2).Value = prd_con.GetString("inv_unit_id")
                        DataGridView1.Rows.Item(n).Cells(3).Value = i
                        DataGridView1.Rows.Item(n).Cells(4).Value = prd_con.GetString("inv_barcode")
                        DataGridView1.Rows.Item(n).Cells(5).Value = prd_con.GetString("inv_name_th")
                        DataGridView1.Rows.Item(n).Cells(6).Value = prd_con.GetString("inv_name_en")
                        DataGridView1.Rows.Item(n).Cells(7).Value = prd_con.GetString("inv_unit_name")
                        DataGridView1.Rows.Item(n).Cells(8).Value += amt
                        isH = False
                    End If

                Else
                    Dim n As Integer = DataGridView1.Rows.Add()
                    DataGridView1.Rows.Item(n).Cells(0).Value = prd_con.GetString("inv_prd_id")
                    DataGridView1.Rows.Item(n).Cells(1).Value = "0"
                    DataGridView1.Rows.Item(n).Cells(2).Value = prd_con.GetString("inv_unit_id")
                    DataGridView1.Rows.Item(n).Cells(3).Value = i
                    DataGridView1.Rows.Item(n).Cells(4).Value = prd_con.GetString("inv_barcode")
                    DataGridView1.Rows.Item(n).Cells(5).Value = prd_con.GetString("inv_name_th")
                    DataGridView1.Rows.Item(n).Cells(6).Value = prd_con.GetString("inv_name_en")
                    DataGridView1.Rows.Item(n).Cells(7).Value = prd_con.GetString("inv_unit_name")
                    DataGridView1.Rows.Item(n).Cells(8).Value += amt
                    isH = False
                End If
            Else
                MessageBox.Show("ไม่มีสินค้านี้ในระบบค่ะ", "Message Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        End If
        i += 1
    End Sub
    Private Sub btn_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancel.Click
        DataGridView1.Rows.Clear()
        textbox_qt.Text = "0"
        textbox_barcoce.Text = ""
    End Sub

    Private Sub btn_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_save.Click
        Dim date1 As String
        If CInt(Now.ToString("yyyy")) > 2450 Then
            date1 = CInt(Now.ToString("yyyy")) - 543 & Now.ToString("-MM-dd HH:mm:ss")
        Else
            date1 = Now.ToString("yyyy-MM-dd HH:mm:ss")
        End If
        Dim result1 As Integer = MessageBox.Show("คุณมั่นใจใช่ไหมทีจะบันทึกรับของเข้าสต๊อก?", "ข้อความแจ้งการทำงาน", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result1 = DialogResult.Yes Then
            If DataGridView1.RowCount > 0 Then
                Dim Str As String = ""
                Dim number_recript As String = genId()
                For f As Integer = 0 To DataGridView1.RowCount - 1
                    Dim id_prd As String = DataGridView1.Rows.Item(f).Cells(0).Value
                    Dim id_prd_con As String = DataGridView1.Rows.Item(f).Cells(1).Value
                    Dim id_unit As String = DataGridView1.Rows.Item(f).Cells(2).Value
                    Dim number_prd As String = DataGridView1.Rows.Item(f).Cells(4).Value
                    Dim nameprd_th As String = DataGridView1.Rows.Item(f).Cells(5).Value
                    Dim nameprd_en As String = DataGridView1.Rows.Item(f).Cells(6).Value
                    Dim name_unit As String = DataGridView1.Rows.Item(f).Cells(7).Value
                    Dim amt As String = DataGridView1.Rows.Item(f).Cells(8).Value
                    Str &= "INSERT INTO pos_product_recript (rcp_number,rcp_ref_id_prd,rcp_ref_id_prd_con,rcp_ref_id_unit,barcode,rcp_nameprd_th,rcp_nameprd_en,rcp_name_unit_th,rcp_name_unit_en," _
                        & "rcp_amount,rcp_action_by,rcp_createdate) VALUES(" _
                        & "'" & number_recript & "','" & id_prd & "','" & id_prd_con & "','" & id_unit & "','" & number_prd & "','" & nameprd_th & "','" & nameprd_en & "'," _
                        & "'" & name_unit & "','" & name_unit & "','" & amt & "','" & Login.username & "','" & date1 & "'" _
                        & ");"
                    Str &= "UPDATE pos_product_inv SET inv_amount=inv_amount+" & amt & " WHERE inv_barcode='" & number_prd & "';"

                    ' If id_prd_con > 0 Then
                    '  Dim qty_new As Integer = 0
                    ' Dim amt_old As MySqlDataReader = con.mysql_query("SELECT * FROM pos_product_condition WHERE  id='" & id_prd_con & "'")
                    '  amt_old.Read()
                    '   qty_new = CInt(amt_old.GetString("amount")) + amt
                    '   Str &= "UPDATE pos_product_condition SET amount='" & qty_new & "' WHERE id='" & id_prd_con & "';"
                    ' Else
                    '  Dim qty_new As Integer = 0
                    '  Dim amt_old As MySqlDataReader = con.mysql_query("SELECT * FROM pos_product WHERE  id='" & id_prd & "'")
                    ' amt_old.Read()
                    '  qty_new = CInt(amt_old.GetString("amount")) + amt
                    ' Str &= "UPDATE pos_product SET amount='" & qty_new & "' WHERE id='" & id_prd & "';"
                    ' End If
                Next
                If con.mysql_query(Str) = True Then
                    MessageBox.Show("Save Complete.", "messages alert", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    textbox_qt.Text = "0"
                    textbox_barcoce.Text = ""
                    DataGridView1.Rows.Clear()
                Else
                    MsgBox("Error Data Empty.!")
                    textbox_qt.Text = "0"
                    textbox_barcoce.Text = ""
                    DataGridView1.Rows.Clear()
                End If
            Else
                MsgBox("กรุณาเพิ่มรายการสินค้าที่จะนำเข้าระบบด้วยค่ะ")
            End If
        End If
    End Sub

End Class