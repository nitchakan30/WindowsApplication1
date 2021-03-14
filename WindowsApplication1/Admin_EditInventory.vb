Imports MySql.Data.MySqlClient
Public Class Admin_EditInventory
    Dim con As New Mysql
    Private Sub Admin_EditInventory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadData()
    End Sub
    Public Sub LoadData()
        Dim dt As MySqlDataReader = con.mysql_query("select * from pos_product_inv order by inv_barcode asc")
        Dim i As Integer = 1
        DataGridView1.Rows.Clear()
        While dt.Read()
            Dim n As Integer = DataGridView1.Rows.Add()
            DataGridView1.Rows.Item(n).Cells(0).Value = dt.GetString("inv_barcode")
            DataGridView1.Rows.Item(n).Cells(1).Value = i
            DataGridView1.Rows.Item(n).Cells(2).Value = dt.GetString("inv_barcode")
            DataGridView1.Rows.Item(n).Cells(3).Value = dt.GetString("inv_name_th")
            DataGridView1.Rows.Item(n).Cells(4).Value = dt.GetString("inv_name_en")
            DataGridView1.Rows.Item(n).Cells(5).Value = dt.GetString("inv_unit_name")
            DataGridView1.Rows.Item(n).Cells(6).Value = dt.GetString("inv_unit_id")
            If i Mod 2 = 0 Then
                DataGridView1.Rows.Item(n).DefaultCellStyle.BackColor = Color.Beige
            End If
            i += 1
        End While
        dt.Close()
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        LoadData()
    End Sub

    Private Sub DataGridView1_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        If e.ColumnIndex = 5 Or e.ColumnIndex = 6 Then
            Admin_EditInventory_Unit.i = i
            Admin_EditInventory_Unit.ShowDialog()
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If DataGridView1.Rows.Count > 0 Then
            Dim result = MessageBox.Show("Are you sure Save Data  ?", "Update Detail Inventory", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                Dim str As String = ""
                For j As Integer = 0 To DataGridView1.Rows.Count - 1
                    str &= "UPDATE pos_product_inv SET update_by='" & Login.username & "',inv_name_th='" & DataGridView1.Rows(j).Cells(3).Value() & "'," _
                    & "inv_name_en='" & DataGridView1.Rows(j).Cells(4).Value() & "',inv_unit_name='" & DataGridView1.Rows(j).Cells(5).Value() & "',inv_unit_id='" & DataGridView1.Rows(j).Cells(6).Value() & "' WHERE inv_barcode='" & DataGridView1.Rows(j).Cells(2).Value() & "';"
                Next
                If con.mysql_query(str) = True Then
                    MsgBox("Update Data Complete.")
                    LoadData()
                Else
                    MsgBox("Error Query Inventory.!")
                End If
            End If
        End If
    End Sub
End Class