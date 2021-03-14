Imports MySql.Data.MySqlClient
Public Class Admin_EditInventory_Unit
    Dim con As New Mysql
    Public i As Integer = 0
    Private Sub Admin_EditInventory_Unit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadData_unit()
    End Sub
    Public Sub loadData_unit()
        txtBoxUnit.DataSource = Nothing
        txtBoxUnit.Items.Clear()
        txtBoxUnit.Items.Remove(txtBoxUnit.DisplayMember)
        Dim res_unit1 As MySqlDataReader
        Dim cboItemsF3 As New List(Of cboItem)
        Dim Str As String = ""
        res_unit1 = con.mysql_query("select name_en,name_th,id from pos_product_unit")
        cboItemsF3.Add(New cboItem With {.Text = " ", .Value = "0"})
        While res_unit1.Read()
            If res_unit1.GetString("name_en") <> "" Then
                Str = res_unit1.GetString("name_en")
            Else
                Str = res_unit1.GetString("name_th")
            End If
            cboItemsF3.Add(New cboItem With {.Text = Str, .Value = res_unit1.GetString("id")})
        End While
        res_unit1.Close()
        With Me.txtBoxUnit
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .DataSource = cboItemsF3
        End With
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Admin_EditInventory.DataGridView1.Item(5, i).Value = txtBoxUnit.Text
        Admin_EditInventory.DataGridView1.Item(6, i).Value = txtBoxUnit.SelectedValue.ToString
        Me.Close()
    End Sub
End Class