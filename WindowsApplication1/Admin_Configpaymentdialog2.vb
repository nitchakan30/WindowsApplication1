Imports MySql.Data.MySqlClient
Public Class Admin_Configpaymentdialog2
    Dim con As New Mysql
    Public Edit As Boolean = False
    Public id_edit As Integer = 0
    Private Sub Admin_Configpaymentdialog2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Edit = True Then
            btn_save.Text = "แก้ไข"
        Else
            btn_save.Text = "เพิ่มใหม่"
            TextBox1.Text = ""
            TextBox1.Focus()
        End If
    End Sub
    Private Sub btn_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_save.Click
        If TextBox1.Text <> "" Then
            If Edit = True Then
                If con.mysql_query("UPDATE pos_payment_card SET name_card='" & TextBox1.Text & "' WHERE id_card='" & id_edit & "'") = True Then
                    MessageBox.Show("แก้ไขเรียบร้อย", "Message Box Alert", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Admin_Configpayment.load_typecard()
                    TextBox1.Text = ""
                    id_edit = 0
                    Me.Close()
                    Edit = False
                End If
            Else
                If con.mysql_query("INSERT INTO pos_payment_card (name_card) VALUES('" & TextBox1.Text & "')") = True Then
                    MessageBox.Show("เพิ่มใหม่เรียบร้อย", "Message Box Alert", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Admin_Configpayment.load_typecard()
                    TextBox1.Text = ""
                    Me.Close()
                End If
            End If
        Else
            MessageBox.Show("กรุณาเพิ่มข้อมูลด้วยค่ะ", "Message Box Alert", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TextBox1.Focus()
        End If
    End Sub
    Private Sub Admin_Configpaymentdialog2_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Edit = False
    End Sub
   
End Class