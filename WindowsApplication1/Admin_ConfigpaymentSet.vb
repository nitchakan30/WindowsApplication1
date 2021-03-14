Imports MySql.Data.MySqlClient
Public Class Admin_ConfigpaymentSet
    Dim con As New Mysql
    Private Sub Admin_ConfigpaymentSet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadData()
    End Sub
    Private Sub ComboBox_St_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox_St.SelectionChangeCommitted
        Dim ist As Integer = 0
        If ComboBox_St.Text.ToString = "ปิด" Then
            ist = 0
        Else
            ist = 1
        End If
        Dim query As Boolean = con.mysql_query("UPDATE pos_shop SET audit_money_action='" & ist & "'")
        If query = True Then
            MessageBox.Show("บันทึกเรียบร้อย", "Message Alert", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    Private Sub LoadData()
        Dim res As MySqlDataReader = con.mysql_query("select audit_money_action from pos_shop")
        res.Read()
        If CInt(res.GetString("audit_money_action")) = 1 Then
            ComboBox_St.SelectedIndex = 1
        Else
            ComboBox_St.SelectedIndex = 0
        End If
    End Sub

    Private Sub Button_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

End Class