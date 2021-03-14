Imports MySql.Data.MySqlClient

Public Class Admin_addPrd_Condit
    Dim con As New Mysql
    Dim res1 As MySqlDataReader
    Public array_indre As New ArrayList
    Dim cn As New Admin_addPrd

    Private Sub Admin_addPrd_Condit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadData_Indre()
    End Sub
    Public Sub loadData_Indre()
        CheckedListBox_Con.Items.Clear()
        res1 = con.mysql_query("select name_en,id from pos_product_ingredients")
        While res1.Read
            CheckedListBox_Con.Items.Add(res1.GetString("name_en"))
        End While
        res1.Close()

        For i As Integer = 0 To Admin_addPrdCon.CheckedListBox1.Items.Count - 1
            If Admin_addPrdCon.CheckedListBox1.GetItemChecked(i) = True Then
                CheckedListBox_Con.SetItemChecked(i, True)
            End If
        Next
    End Sub

    Private Sub btn_select_indre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_select_indre.Click
        array_indre.Clear()
        For i As Integer = 0 To Admin_addPrdCon.CheckedListBox1.Items.Count - 1
            Admin_addPrdCon.CheckedListBox1.SetItemChecked(i, False)
        Next
        For i As Integer = 0 To CheckedListBox_Con.Items.Count - 1
            If CheckedListBox_Con.GetItemChecked(i) = True Then
                Admin_addPrdCon.CheckedListBox1.SetItemChecked(i, True)
            End If
        Next
        Me.Close()
    End Sub

    Private Sub btn_cancle_indre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancle_indre.Click
        clearForm()
        Me.Close()
    End Sub
    Public Sub clearForm()    
        CheckedListBox_Con.ClearSelected()
        For i As Integer = 0 To CheckedListBox_Con.Items.Count - 1
            CheckedListBox_Con.SetItemChecked(i, False)
        Next
    End Sub
End Class
