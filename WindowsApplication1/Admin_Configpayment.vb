Imports MySql.Data.MySqlClient
Public Class Admin_Configpayment
    Dim con As New Mysql
    Private Sub Admin_Configpayment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim str As String = ""
        str = "SELECT id,pay_active FROM pos_payment_type;"
        Dim res As MySqlDataReader = con.mysql_query(str)
        While res.Read()
            If res.GetString("id") = "1" Then
                If res.GetString("pay_active") = "1" Then
                    ComboBox1.SelectedIndex = 1
                Else
                    ComboBox1.SelectedIndex = 0
                End If
            ElseIf res.GetString("id") = "2" Then
                If res.GetString("pay_active") = "1" Then
                    ComboBox4.SelectedIndex = 1
                Else
                    ComboBox4.SelectedIndex = 0
                End If
            ElseIf res.GetString("id") = "3" Then
                If res.GetString("pay_active") = "1" Then
                    ComboBox2.SelectedIndex = 1
                Else
                    ComboBox2.SelectedIndex = 0
                End If
            ElseIf res.GetString("id") = "4" Then
                If res.GetString("pay_active") = "1" Then
                    ComboBox3.SelectedIndex = 1
                Else
                    ComboBox3.SelectedIndex = 0
                End If
            ElseIf res.GetString("id") = "5" Then
                If res.GetString("pay_active") = "1" Then
                    ComboBox_Other.SelectedIndex = 1
                Else
                    ComboBox_Other.SelectedIndex = 0
                End If
            ElseIf res.GetString("id") = "99" Then
                If res.GetString("pay_active") = "1" Then
                    ComboBox_BankTran.SelectedIndex = 1
                Else
                    ComboBox_BankTran.SelectedIndex = 0
                End If
            End If
        End While
        res.Close()
        load_creditcard()
        load_typecard()
        load_paymentType()
        load_paymentOc()
    End Sub
    Public Sub load_creditcard()
        ListView1.Items.Clear()
        Dim res As MySqlDataReader
        res = con.mysql_query("SELECT * from pos_payment_acc where active_acc='1' ORDER BY id_acc ASC")
        Dim itmx As New ListViewItem
        Dim i As Integer = 0
        While res.Read
            itmx = ListView1.Items.Add(res.GetString("id_acc"), i)
            itmx.SubItems.Add(i + 1)
            itmx.SubItems.Add(res.GetString("name_acc"))
            i += 1
        End While
    End Sub
    Public Sub load_typecard()
        ListView_Card.Items.Clear()
        Dim res As MySqlDataReader
        res = con.mysql_query("SELECT * from pos_payment_card where active_del='0' ORDER BY id_card ASC")
        Dim itmx As New ListViewItem
        Dim i As Integer = 0
        While res.Read
            itmx = ListView_Card.Items.Add(res.GetString("id_card"), i)
            itmx.SubItems.Add(i + 1)
            itmx.SubItems.Add(res.GetString("name_card"))
            i += 1
        End While
        res.Close()
    End Sub
    Public Sub load_paymentType()
        ListView_other.Items.Clear()
        Dim res As MySqlDataReader
        res = con.mysql_query("SELECT * from pos_payment_type where pay_active='1' ORDER BY id ASC")
        Dim itmx As New ListViewItem
        Dim i As Integer = 0
        While res.Read
            If CInt(res.GetString("id")) > 4 Then
                itmx = ListView_other.Items.Add(res.GetString("id"), i)
                itmx.SubItems.Add(i + 1)
                itmx.SubItems.Add(res.GetString("name"))
                i += 1
            End If
        End While
        res.Close()
    End Sub
    Public Sub load_paymentOc()
        ListView_other1.Items.Clear()
        Dim res As MySqlDataReader
        res = con.mysql_query("SELECT * from pos_payment_oc where status_oc='1' ORDER BY id_oc ASC")
        Dim itmx As New ListViewItem
        Dim i As Integer = 0
        While res.Read

            itmx = ListView_other1.Items.Add(res.GetString("id_oc"), i)
            itmx.SubItems.Add(i + 1)
            itmx.SubItems.Add(res.GetString("name_oc"))
            itmx.SubItems.Add(FormatNumber(res.GetDouble("credit_oc"), 2))
            itmx.SubItems.Add(FormatNumber(res.GetDouble("fix_credit_oc"), 2))
            itmx.SubItems.Add(res.GetString("type_oc"))
            itmx.SubItems.Add(res.GetDateTime("date_oc"))
            itmx.SubItems.Add(res.GetString("department_oc"))
            itmx.SubItems.Add(res.GetString("position_oc"))
            itmx.SubItems.Add(res.GetString("emp_id_oc"))
            itmx.SubItems.Add(res.GetString("remark_oc"))
            itmx.SubItems.Add(res.GetString("ref_payment_type_id"))
            itmx.SubItems.Add(res.GetString("ref_payment_type_name"))
            i += 1
        End While
        res.Close()
    End Sub
    Private Sub btn_add_cnumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_add_cnumber.Click
        Admin_Configpayment_dialog.ShowDialog()
    End Sub
    Private Sub ListView1_MouseClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles ListView1.MouseClick
        If e.Button = MouseButtons.Right Then
            If ListView1.FocusedItem.Bounds.Contains(e.Location) = True Then
                ContextMenuStrip1.Show(Cursor.Position)
            End If
        End If
    End Sub
    Private Sub DelItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DelItem.Click
        If ListView1.SelectedIndices.Count = 0 Then
            Exit Sub
        End If
        If ListView1.Items.Count > 0 Then
            Dim result = MessageBox.Show("Are you sure delete " & ListView1.Items(ListView1.FocusedItem.Index).SubItems(2).Text & " ?", "ลบชื่อบัญชีธนาคาร", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                If con.mysql_query("UPDATE pos_payment_acc SET active_acc='0' WHERE id_acc='" & ListView1.Items(ListView1.FocusedItem.Index).SubItems(0).Text & "' ") = True Then
                    MessageBox.Show("ลบเรียบร้อย", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    load_creditcard()
                End If
            End If
        End If
    End Sub
    Private Sub EditItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditItem.Click
        Admin_Configpayment_dialog.Edit = True
        Admin_Configpayment_dialog.btn_save.Text = "แก้ไข"
        Admin_Configpayment_dialog.id_edit = ListView1.Items(ListView1.FocusedItem.Index).SubItems(0).Text
        Admin_Configpayment_dialog.TextBox1.Text = ListView1.Items(ListView1.FocusedItem.Index).SubItems(2).Text
        Admin_Configpayment_dialog.ShowDialog()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        con.mysql_query("UPDATE pos_payment_type SET pay_active='" & ComboBox1.SelectedIndex.ToString() & "' WHERE id ='1' ")
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        con.mysql_query("UPDATE pos_payment_type SET pay_active='" & ComboBox2.SelectedIndex.ToString() & "' WHERE id ='3' ")
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox4.SelectedIndexChanged
        con.mysql_query("UPDATE pos_payment_type SET pay_active='" & ComboBox4.SelectedIndex.ToString() & "' WHERE id ='2' ")
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox3.SelectedIndexChanged
        con.mysql_query("UPDATE pos_payment_type SET pay_active='" & ComboBox3.SelectedIndex.ToString() & "' WHERE id ='4' ")
    End Sub
    Private Sub ComboBox_Other_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox_Other.SelectedIndexChanged
        con.mysql_query("UPDATE pos_payment_type SET pay_active='" & ComboBox_Other.SelectedIndex.ToString() & "' WHERE id ='5' ")
    End Sub
    Private Sub ComboBox_BankTran_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox_BankTran.SelectedIndexChanged
        con.mysql_query("UPDATE pos_payment_type SET pay_active='" & ComboBox_BankTran.SelectedIndex.ToString() & "' WHERE id ='99' ")
    End Sub
    Private Sub btn_card_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_card.Click
        Admin_Configpaymentdialog2.ShowDialog()
    End Sub

    Private Sub ListView_Card_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView_Card.MouseClick
        If e.Button = MouseButtons.Right Then
            If ListView_Card.FocusedItem.Bounds.Contains(e.Location) = True Then
                ContextMenuStrip2.Show(Cursor.Position)
            End If
        End If
    End Sub

    Private Sub EditItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditItem1.Click
        Admin_Configpaymentdialog2.Edit = True
        Admin_Configpaymentdialog2.btn_save.Text = "แก้ไข"
        Admin_Configpaymentdialog2.id_edit = ListView_Card.Items(ListView_Card.FocusedItem.Index).SubItems(0).Text
        Admin_Configpaymentdialog2.TextBox1.Text = ListView_Card.Items(ListView_Card.FocusedItem.Index).SubItems(2).Text
        Admin_Configpaymentdialog2.ShowDialog()
    End Sub

    Private Sub DelItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DelItem1.Click
        If ListView_Card.SelectedIndices.Count = 0 Then
            Exit Sub
        End If
        If ListView_Card.Items.Count > 0 Then
            Dim result = MessageBox.Show("Are you sure delete " & ListView_Card.Items(ListView_Card.FocusedItem.Index).SubItems(2).Text & " ?", "ลบรอบบิล", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                If con.mysql_query("UPDATE pos_payment_card SET active_del='1'  WHERE id_card='" & ListView_Card.Items(ListView_Card.FocusedItem.Index).SubItems(0).Text & "' ") = True Then
                    MessageBox.Show("ลบเรียบร้อย", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    load_typecard()
                End If
            End If
        End If
    End Sub

    Private Sub btn_addother_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_addother.Click
        Admin_Configpaymentdialog3.ShowDialog()
    End Sub

    Private Sub EditOther_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditOther.Click
        Admin_Configpaymentdialog3.Edit = True
        Admin_Configpaymentdialog3.btn_save.Text = "แก้ไข"
        Admin_Configpaymentdialog3.id_edit = ListView_other.Items(ListView_other.FocusedItem.Index).SubItems(0).Text
        Admin_Configpaymentdialog3.TextBox1.Text = ListView_other.Items(ListView_other.FocusedItem.Index).SubItems(2).Text
        Admin_Configpaymentdialog3.ShowDialog()
    End Sub

    Private Sub DelOther_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DelOther.Click
        If ListView_other.SelectedIndices.Count = 0 Then
            Exit Sub
        End If
        If ListView_other.Items.Count > 0 Then
            Dim result = MessageBox.Show("Are you sure delete " & ListView_other.Items(ListView_other.FocusedItem.Index).SubItems(2).Text & " ?", "ลบรอบบิล", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                If con.mysql_query("UPDATE pos_payment_type SET pay_active='0'  WHERE id='" & ListView_other.Items(ListView_other.FocusedItem.Index).SubItems(0).Text & "' ") = True Then
                    MessageBox.Show("ลบเรียบร้อย", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    load_paymentType()
                End If
            End If
        End If
    End Sub
    Private Sub ListView_other_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView_other.MouseClick
        If e.Button = MouseButtons.Right Then
            If ListView_other.FocusedItem.Bounds.Contains(e.Location) = True Then
                ContextMenuStrip3.Show(Cursor.Position)
            End If
        End If
    End Sub

    Private Sub btn_addother1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_addother1.Click
        Admin_Configpaymentdialog_oc.Edit = False
        Admin_Configpaymentdialog_oc.ShowDialog()
    End Sub

    Private Sub ListView_other1_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView_other1.MouseClick
        If e.Button = MouseButtons.Right Then
            If ListView_other1.FocusedItem.Bounds.Contains(e.Location) = True Then
                ContextMenuStrip4.Show(Cursor.Position)
            End If
        End If
    End Sub

    Private Sub EditOther1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditOther1.Click
        Send_Edit_OC()
    End Sub
    Private Sub ListView_other1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView_other1.DoubleClick
        Send_Edit_OC()
    End Sub
    Private Sub Send_Edit_OC()
        Admin_Configpaymentdialog_oc.Edit = True
        Admin_Configpaymentdialog_oc.btn_save.Text = "Edit"
        Admin_Configpaymentdialog_oc.id_edit = ListView_other1.Items(ListView_other1.FocusedItem.Index).SubItems(0).Text
        Admin_Configpaymentdialog_oc.TextBox_Name.Text = ListView_other1.Items(ListView_other1.FocusedItem.Index).SubItems(2).Text
        Admin_Configpaymentdialog_oc.TextBox_Credit.Text = ListView_other1.Items(ListView_other1.FocusedItem.Index).SubItems(3).Text
        Admin_Configpaymentdialog_oc.TextBox_FixCredit.Text = ListView_other1.Items(ListView_other1.FocusedItem.Index).SubItems(4).Text
        Admin_Configpaymentdialog_oc.TextBox_Depart.Text = ListView_other1.Items(ListView_other1.FocusedItem.Index).SubItems(7).Text
        Admin_Configpaymentdialog_oc.TextBox_Position.Text = ListView_other1.Items(ListView_other1.FocusedItem.Index).SubItems(8).Text
        Admin_Configpaymentdialog_oc.TextBox_EmpID.Text = ListView_other1.Items(ListView_other1.FocusedItem.Index).SubItems(9).Text
        Admin_Configpaymentdialog_oc.TextBox_Remark.Text = ListView_other1.Items(ListView_other1.FocusedItem.Index).SubItems(10).Text

        Dim cboItemsFl As New List(Of cboItem)
        cboItemsFl.Add(New cboItem With {.Text = "Per-Month", .Value = "nerver"})
        cboItemsFl.Add(New cboItem With {.Text = "Onetime", .Value = "onetime"})
        With Admin_Configpaymentdialog_oc.ComboBox_TypeOc
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .DataSource = cboItemsFl
        End With
        If "nerver" = ListView_other1.Items(ListView_other1.FocusedItem.Index).SubItems(5).Text Then
            Admin_Configpaymentdialog_oc.ComboBox_TypeOc.SelectedIndex = 0
        Else
            Admin_Configpaymentdialog_oc.ComboBox_TypeOc.SelectedIndex = 1
        End If

        '==== payment type join==========
        Dim cboItemsF2 As New List(Of cboItem)
        Dim res As MySqlDataReader
        res = con.mysql_query("SELECT * from pos_payment_type where pay_active='1' ORDER BY id ASC")
        While res.Read
            If CInt(res.GetString("id")) > 4 Then
                cboItemsF2.Add(New cboItem With {.Text = res.GetString("name"), .Value = res.GetString("id")})
            End If
        End While
        With Admin_Configpaymentdialog_oc.ComboBox_PayType
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .DataSource = cboItemsF2
        End With

        Admin_Configpaymentdialog_oc.ComboBox_PayType.SelectedValue = ListView_other1.Items(ListView_other1.FocusedItem.Index).SubItems(11).Text
        Dim date1 As DateTime = CDate(ListView_other1.Items(ListView_other1.FocusedItem.Index).SubItems(6).Text)
        Admin_Configpaymentdialog_oc.DateTimePicker1.Value = date1.Day & "-" & date1.Month & "-" & date1.Year
        Admin_Configpaymentdialog_oc.ShowDialog()
    End Sub

    Private Sub ListView_other_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView_other.DoubleClick
        Admin_Configpaymentdialog3.Edit = True
        Admin_Configpaymentdialog3.btn_save.Text = "แก้ไข"
        Admin_Configpaymentdialog3.id_edit = ListView_other.Items(ListView_other.FocusedItem.Index).SubItems(0).Text
        Admin_Configpaymentdialog3.TextBox1.Text = ListView_other.Items(ListView_other.FocusedItem.Index).SubItems(2).Text
        Admin_Configpaymentdialog3.ShowDialog()
    End Sub

    Private Sub ListView_Card_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView_Card.DoubleClick
        Admin_Configpaymentdialog2.Edit = True
        Admin_Configpaymentdialog2.btn_save.Text = "แก้ไข"
        Admin_Configpaymentdialog2.id_edit = ListView_Card.Items(ListView_Card.FocusedItem.Index).SubItems(0).Text
        Admin_Configpaymentdialog2.TextBox1.Text = ListView_Card.Items(ListView_Card.FocusedItem.Index).SubItems(2).Text
        Admin_Configpaymentdialog2.ShowDialog()
    End Sub

    Private Sub ListView1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick
        Admin_Configpayment_dialog.Edit = True
        Admin_Configpayment_dialog.btn_save.Text = "แก้ไข"
        Admin_Configpayment_dialog.id_edit = ListView1.Items(ListView1.FocusedItem.Index).SubItems(0).Text
        Admin_Configpayment_dialog.TextBox1.Text = ListView1.Items(ListView1.FocusedItem.Index).SubItems(2).Text
        Admin_Configpayment_dialog.ShowDialog()
    End Sub

    Private Sub GroupBox5_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox5.Enter

    End Sub
End Class