Imports MySql.Data.MySqlClient
Public Class payment_type
    Dim con As New Mysql
    Dim ac As New Admin_ClassMain
    Private Sub payment_type_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadPayType()
    End Sub
    Private Sub loadPayType()
        Dim res As MySqlDataReader = con.mysql_query("select * from pos_payment_type where id >'4' and pay_active='1' and CL='1' order by id ASC")
        Dim cboItemsFl As New List(Of cboItem)
        Dim txt As String = ""
        While res.Read
            cboItemsFl.Add(New cboItem With {.Text = res.GetString("name"), .Value = res.GetString("id")})
        End While

        With Me.ComboBox1
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .DataSource = cboItemsFl
        End With

        If ComboBox1.Items.Count > 0 Then
            ComboBox1.SelectedIndex = 0
        End If
        res.Close()
    End Sub

    Private Sub TextBox_Amount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        keyborad_number.text1 = "Textbox_typepay"
        keyborad_number.ShowDialog()
    End Sub
    Private Sub Btn_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_save.Click
        If ComboBox1.SelectedValue <> "" Then
            payment.payment_cl = True
            payment.payment_type_request_id = CInt(ComboBox1.SelectedValue.ToString())
            payment.payment_type_request_text = ComboBox1.Text.ToString()
            ' payment.txt_payment_other.Text = ComboBox1.Text.ToString()
            Me.Close()
        Else
            payment.payment_cl = False
            Me.Close()
        End If
    End Sub

    Private Sub Btn_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_cancel.Click
        payment.payment_cl = False
        ComboBox1.SelectedIndex = 0
        ' payment.txt_payment_other.Text = ""
        payment.payment_type_request_id = "0"
        Me.Close()
    End Sub
End Class