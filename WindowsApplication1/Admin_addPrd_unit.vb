Imports MySql.Data.MySqlClient

Public Class Admin_addprd_unit
    Dim con As New Mysql
    Dim res1 As MySqlDataReader
    Public array_unit As New ArrayList
    Dim cn As New Admin_addPrd
    Private Sub Admin_addprd_unit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadData_unit()
    End Sub
    Private Sub btn_cancle_unit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancle_unit.Click
        Me.Close()
    End Sub
    Public Sub loadData_unit()
        CheckedListBox_unit.Items.Clear()
        res1 = con.mysql_query("select 	name_en,name_th,id from pos_product_unit")
        While res1.Read
            CheckedListBox_unit.Items.Add(res1.GetString("name_en"))
        End While
        res1.Close()

        For i As Integer = 0 To Admin_addPrdCon.CheckedListBox1.Items.Count - 1
            If Admin_addPrdCon.CheckedListBox1.GetItemChecked(i) = True Then
                CheckedListBox_unit.SetItemChecked(i, True)
            End If
        Next
    End Sub

 
End Class