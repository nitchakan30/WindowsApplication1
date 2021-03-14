Imports MySql.Data.MySqlClient
Public Class form_ropbill_close
    Dim con As New Mysql
    Public not_countMoney As Boolean = False
    Private Sub form_ropbill_close_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txt_user.Focus()
        txt_user.Text = ""
        txt_pwd.Text = ""
    End Sub
    Private Sub btn_clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_clear.Click
        form_ropbill.close_chk = False
        form_ropbill.id_ropclose = 0
        Me.Close()
    End Sub
    Private Sub btn_enter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_enter.Click
        Dim date1 As DateTime
        If CInt(Login.DateData.ToString("yyyy")) > 2450 Then
            date1 = CInt(Login.DateData.ToString("yyyy")) - 543 & Login.DateData.ToString("-MM-dd") & Now.ToString(" HH:mm:ss")
        Else
            date1 = Login.DateData.ToString("yyyy-MM-dd") & Now.ToString(" HH:mm:ss")
        End If
        If txt_user.Text <> "" And txt_pwd.Text <> "" Then
            Dim num_user As Integer = con.mysql_num_rows(con.mysql_query("select * from pos_user where username='" & txt_user.Text & "' and password='" & txt_pwd.Text & "' LIMIT 1"))
            If num_user > 0 Then
                Dim res_user As MySqlDataReader = con.mysql_query("select * from pos_user where username='" & txt_user.Text & "' and password='" & txt_pwd.Text & "' LIMIT 1")
                res_user.Read()
                Dim res_p As MySqlDataReader = con.mysql_query("select * from pos_user_permission_match where id_user='" & res_user.GetString("id") & "'")
                res_p.Read()
                If CInt(res_p.GetString("closing_bill")) = 1 Then
                    If not_countMoney = True Then
                        form_ropbill.close_chk = True
                        form_ropbill.id_ropclose = 0
                        not_countMoney = False
                        Me.Close()
                    End If
                Else
                    MessageBox.Show("คุณไม่มีสิทธิในการยินยันระบบนี้ ติดต่อ Support Program", "Message Show", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
        Else
            MessageBox.Show("username หรือ password ไม่ถูกต้องกรุณาตรวจสอบอีกครั้ง", "Message Show", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txt_pwd.Focus()
        End If
        Else
            MessageBox.Show("กรุณากรอกข้อมูลให้ครบด้วยค่ะ", "Message Show", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    Private Sub txt_money_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        keyborad_number.text1 = "txt_money"
        keyborad_number.ShowDialog()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        txt_user.Text = ""
        txt_pwd.Text = ""
    End Sub
    Private Sub txt_pwd_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_pwd.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            Dim date1 As DateTime
            If CInt(Login.DateData.ToString("yyyy")) > 2450 Then
                date1 = CInt(Login.DateData.ToString("yyyy")) - 543 & Login.DateData.ToString("-MM-dd") & Now.ToString(" HH:mm:ss")
            Else
                date1 = Login.DateData.ToString("yyyy-MM-dd") & Now.ToString(" HH:mm:ss")
            End If
            If txt_user.Text <> "" And txt_pwd.Text <> "" Then
                Dim num_user As Integer = con.mysql_num_rows(con.mysql_query("select * from pos_user where username='" & txt_user.Text & "' and password='" & txt_pwd.Text & "' LIMIT 1"))
                If num_user > 0 Then
                    Dim res_user As MySqlDataReader = con.mysql_query("select * from pos_user where username='" & txt_user.Text & "' and password='" & txt_pwd.Text & "' LIMIT 1")
                    res_user.Read()
                    Dim res_p As MySqlDataReader = con.mysql_query("select * from pos_user_permission_match where id_user='" & res_user.GetString("id") & "'")
                    res_p.Read()
                    If CInt(res_p.GetString("closing_bill")) = 1 Then
                        If not_countMoney = True Then
                            form_ropbill.close_chk = True
                            form_ropbill.id_ropclose = 0
                            not_countMoney = False
                            Me.Close()
                        End If
                    Else
                        MessageBox.Show("คุณไม่มีสิทธิในการยินยันระบบนี้ ติดต่อ Support Program", "Message Show", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Else
                    MessageBox.Show("username หรือ password ไม่ถูกต้องกรุณาตรวจสอบอีกครั้ง", "Message Show", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txt_pwd.Focus()
                End If
            Else
                MessageBox.Show("กรุณากรอกข้อมูลให้ครบด้วยค่ะ", "Message Show", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

  
End Class