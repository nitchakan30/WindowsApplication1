Imports MySql.Data.MySqlClient
Public Class confirm_void
    Dim con As New Mysql
    Public page As String = ""
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        checkActive_void()
    End Sub
    Private Sub checkActive_void()
        If TextBox1.Text <> "" And TextBox2.Text <> "" Then
            Dim count As Integer = con.mysql_num_rows(con.mysql_query("select username,password,cnf_void from pos_user where username='" & TextBox1.Text & "' and password='" & TextBox2.Text & "' and cnf_void='1'"))
            If count > 0 Then
                If page = "voidbill" Then
                    form_voidbill.cn_void = True
                ElseIf page = "voidtb" Then
                    home1_menu.cn_voidtb = True
                End If
                Me.Close()
            Else
                MessageBox.Show("คุณไม่มีสิทธิในการยกเลิกรายการนี้กรุณาติดต่อ Food Manager.", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TextBox1.Focus()
                TextBox2.Text = ""
            End If
        End If
    End Sub
    Private Sub confirm_void_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Focus()
        TextBox1.Text = ""
        TextBox2.Text = ""
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If page = "voidbill" Then
            form_voidbill.cn_void = False
        ElseIf page = "voidtb" Then
            home1_menu.cn_voidtb = False
        End If
        Me.Close()
    End Sub
    Private Sub TextBox2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            checkActive_void()
        End If
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            checkActive_void()
        End If
    End Sub
End Class