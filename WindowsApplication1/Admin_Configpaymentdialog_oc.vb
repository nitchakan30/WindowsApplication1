Imports MySql.Data.MySqlClient
Public Class Admin_Configpaymentdialog_oc
    Dim con As New Mysql
    Public Edit As Boolean = False
    Public id_edit As Integer = 0
    Private Sub Admin_Configpaymentdialog_oc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        If Edit = True Then
            btn_save.Text = "Edit"
            TextBox_Credit.Enabled = False
            btn_plus.Enabled = True
            btn_minus.Enabled = True
        Else
            Dim cboItemsFl As New List(Of cboItem)
            cboItemsFl.Add(New cboItem With {.Text = "Per-Month", .Value = "nerver"})
            cboItemsFl.Add(New cboItem With {.Text = "Onetime", .Value = "onetime"})
            With Me.ComboBox_TypeOc
                .DisplayMember = "Text"
                .ValueMember = "Value"
                .DataSource = cboItemsFl
            End With
            If ComboBox_TypeOc.Items.Count > 0 Then
                ComboBox_TypeOc.SelectedIndex = 0
            End If


            '============== load type payment for join ================
            Dim cboItemsF2 As New List(Of cboItem)
            Dim res As MySqlDataReader
            res = con.mysql_query("SELECT * from pos_payment_type where pay_active='1' ORDER BY id ASC")
            While res.Read
                If CInt(res.GetString("id")) > 4 Then
                    cboItemsF2.Add(New cboItem With {.Text = res.GetString("name"), .Value = res.GetString("id")})
                End If
            End While
            With Me.ComboBox_PayType
                .DisplayMember = "Text"
                .ValueMember = "Value"
                .DataSource = cboItemsF2
            End With
            If ComboBox_PayType.Items.Count > 0 Then
                ComboBox_PayType.SelectedIndex = 0
            End If

            btn_save.Text = "Save"
            TextBox_Credit.Enabled = True
            btn_plus.Enabled = False
            btn_minus.Enabled = False
            TextBox_Name.Text = ""
            TextBox_Credit.Text = ""
            TextBox_FixCredit.Text = ""
            TextBox_Depart.Text = ""
            TextBox_Position.Text = ""
            TextBox_EmpID.Text = ""
            TextBox_Remark.Text = ""
            DateTimePicker1.Value = Now.Day & "-" & Now.Month & "-" & Now.Year
        End If
    End Sub

    Private Sub btn_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_save.Click
        If Edit = True Then
            Dim date_st As Date = DateTimePicker1.Text
            If CInt(date_st.ToString("yyyy")) > 2450 Then
                date_st = CInt(date_st.ToString("yyyy")) - 543 & date_st.ToString("-MM-dd")
            Else
                date_st = date_st.ToString("yyyy-MM-dd")
            End If
            If con.mysql_query("UPDATE pos_payment_oc SET name_oc='" & TextBox_Name.Text & "',type_oc='" & ComboBox_TypeOc.SelectedValue.ToString & "'," _
                               & "date_oc='" & date_st.ToString("yyyy-MM-dd") & Now.ToString(" HH:mm:ss") & "',fix_credit_oc='" & CDbl(TextBox_FixCredit.Text) & "'," _
                               & "department_oc='" & TextBox_Depart.Text & "',position_oc='" & TextBox_Position.Text & "',emp_id_oc='" & TextBox_EmpID.Text & "'," _
                               & "remark_oc='" & TextBox_Remark.Text & "',update_by_oc='" & Login.username & "'," _
                               & "ref_payment_type_id='" & ComboBox_PayType.SelectedValue.ToString & "',ref_payment_type_name='" & ComboBox_PayType.Text.ToString & "'" _
                               & " WHERE id_oc='" & id_edit & "'") = True Then
                MessageBox.Show("Edit Comeplete", "Message Box Alert", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Admin_Configpayment.load_paymentOc()
                id_edit = 0
                Me.Close()
                Edit = False
            End If
        Else
            Dim date_st As Date = DateTimePicker1.Text
            If CInt(date_st.ToString("yyyy")) > 2450 Then
                date_st = CInt(date_st.ToString("yyyy")) - 543 & date_st.ToString("-MM-dd")
            Else
                date_st = date_st.ToString("yyyy-MM-dd")
            End If
            If TextBox_Name.Text <> "" And TextBox_Credit.Text <> "" And TextBox_FixCredit.Text <> "" And ComboBox_TypeOc.SelectedValue.ToString <> "" And ComboBox_PayType.SelectedValue.ToString <> "" Then
                If con.mysql_query("INSERT INTO pos_payment_oc (name_oc,type_oc,date_oc,credit_oc,fix_credit_oc,department_oc,position_oc,emp_id_oc,remark_oc,update_by_oc,status_oc,ref_payment_type_id,ref_payment_type_name) VALUES('" & TextBox_Name.Text & "','" & ComboBox_TypeOc.SelectedValue.ToString & "'," _
                                   & "'" & date_st.ToString("yyyy-MM-dd") & Date.Now.ToString(" HH:mm:ss") & "','" & CDbl(TextBox_Credit.Text) & "','" & CDbl(TextBox_FixCredit.Text) & "','" & TextBox_Depart.Text & "','" & TextBox_Position.Text & "'," _
                                   & "'" & TextBox_EmpID.Text & "','" & TextBox_Remark.Text & "','" & Login.username & "','1','" & ComboBox_PayType.SelectedValue.ToString & "','" & ComboBox_PayType.Text.ToString & "')") = True Then
                    MessageBox.Show("Save Complete", "Message Box Alert", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Admin_Configpayment.load_paymentOc()
                    Me.Close()
                End If
            End If


        End If
    End Sub

    Private Sub btn_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancel.Click
        Me.Close()
    End Sub

    Private Sub btn_plus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_plus.Click
        Admin_Configpaymentdialog_oc_plus.pay_add = True
        Admin_Configpaymentdialog_oc_plus.ref_id_oc = id_edit
        Admin_Configpaymentdialog_oc_plus.ref_name_oc = TextBox_Name.Text
        Admin_Configpaymentdialog_oc_plus.amount_fix = CDbl(TextBox_FixCredit.Text)
        Admin_Configpaymentdialog_oc_plus.ShowDialog()
    End Sub

    Private Sub btn_minus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_minus.Click
        Admin_Configpaymentdialog_oc_plus.pay_add = False
        Admin_Configpaymentdialog_oc_plus.ref_id_oc = id_edit
        Admin_Configpaymentdialog_oc_plus.ref_name_oc = TextBox_Name.Text
        Admin_Configpaymentdialog_oc_plus.amount_fix = CDbl(TextBox_FixCredit.Text)
        Admin_Configpaymentdialog_oc_plus.ShowDialog()
    End Sub
    Private Sub checkIsNumeric(ByVal num, ByVal param)
        If IsNumeric(num) = False Then
            param.Focus()
            param.text = "0.00"
        End If
    End Sub

    Private Sub TextBox_Credit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox_Credit.TextChanged
        checkIsNumeric(TextBox_Credit.Text, TextBox_Credit)
    End Sub

    Private Sub TextBox_FixCredit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox_FixCredit.TextChanged
        checkIsNumeric(TextBox_FixCredit.Text, TextBox_FixCredit)
    End Sub
End Class