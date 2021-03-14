Imports MySql.Data.MySqlClient
Public Class form_tax
    Dim con As New Mysql
    Private Sub form_tax_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim shop As MySqlDataReader = con.mysql_query("select * from pos_shop")
        shop.Read()

    End Sub
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox_Name.TextChanged
        If TextBox_Name.Text = "" Then
            Panel_Name.Visible = False
        Else
            Dim chk As Integer = con.mysql_num_rows(con.mysql_query("select name_cus from pos_customers where name_cus LIKE '%" & TextBox_Name.Text & "%'"))
            If chk > 0 Then
                showCustomers(TextBox_Name.Text, "name_cus")
                Panel_Name.Location() = New Point(3, 53)
                Panel_Name.Show()
                ListView_Name.Show()
            Else
                Panel_Name.Visible = False
            End If
        End If
    End Sub
    Private Sub ListView_Name_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView_Name.DoubleClick
        Dim name As String = ListView_Name.FocusedItem.SubItems(0).Text
        Dim surname As String = ListView_Name.FocusedItem.SubItems(1).Text
        Dim tel As String = ListView_Name.FocusedItem.SubItems(2).Text
        Dim tax As String = ListView_Name.FocusedItem.SubItems(3).Text
        Dim address As String = ListView_Name.FocusedItem.SubItems(4).Text
        Dim tumbon As String = ListView_Name.FocusedItem.SubItems(5).Text
        Dim district As String = ListView_Name.FocusedItem.SubItems(6).Text
        Dim provice As String = ListView_Name.FocusedItem.SubItems(7).Text
        Dim postcode As String = ListView_Name.FocusedItem.SubItems(8).Text
        Dim email As String = ListView_Name.FocusedItem.SubItems(9).Text
        TextBox_Name.Text = name
        TextBox_Surname.Text = surname
        TextBox_Tel.Text = tel
        TextBox_Tax.Text = tax
        TextBox_Address.Text = address
        TextBox_Tumbon.Text = tumbon
        TextBox_District.Text = district
        TextBox_Provice.Text = provice
        TextBox_Postcode.Text = postcode
        TextBox_Email.Text = email
        Panel_Name.Visible = False
    End Sub

    Private Sub close_box_cus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles close_box_cus.Click
        Panel_Name.Visible = False
    End Sub

    Private Sub TextBox_Surname_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox_Surname.TextChanged
        If TextBox_Surname.Text = "" Then
            Panel_Name.Visible = False
        Else
            Dim chk As Integer = con.mysql_num_rows(con.mysql_query("select surname_cus from pos_customers where surname_cus LIKE '%" & TextBox_Surname.Text & "%'"))
            If chk > 0 Then
                showCustomers(TextBox_Surname.Text, "surname_cus")
                Panel_Name.Location() = New Point(7, 78)
                Panel_Name.Show()
                ListView_Name.Show()
            Else
                Panel_Name.Visible = False
            End If
        End If
    End Sub

    Private Sub TextBox_Tel_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox_Tel.TextChanged
        If TextBox_Tel.Text = "" Then
            Panel_Name.Visible = False
        Else
            Dim chk As Integer = con.mysql_num_rows(con.mysql_query("select tel_cus from pos_customers where tel_cus LIKE '%" & TextBox_Tel.Text & "%'"))
            If chk > 0 Then
                showCustomers(TextBox_Tel.Text, "tel_cus")
                Panel_Name.Location() = New Point(12, 102)
                Panel_Name.Show()
                ListView_Name.Show()
            Else
                Panel_Name.Visible = False
            End If
        End If
    End Sub

    Private Sub TextBox_Tax_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox_Tax.TextChanged
        If TextBox_Tax.Text = "" Then
            Panel_Name.Visible = False
        Else
            Dim chk As Integer = con.mysql_num_rows(con.mysql_query("select tax_cus from pos_customers where tax_cus LIKE '%" & TextBox_Tax.Text & "%'"))
            If chk > 0 Then
                showCustomers(TextBox_Tax.Text, "tax_cus")
                Panel_Name.Location() = New Point(19, 105)
                Panel_Name.Show()
                ListView_Name.Show()
            Else
                Panel_Name.Visible = False
            End If
        End If
    End Sub
    Public Sub showCustomers(ByVal txt, ByVal param)
        Dim h As MySqlDataReader = con.mysql_query("select * from pos_customers where " & param & " LIKE '%" & txt & "%'")
        If ListView_Name.Items.Count > 0 Then
            ListView_Name.Items.Clear()
        End If
        Dim itmx1 As New ListViewItem
        Dim i As Integer = 0
        While h.Read
            itmx1 = ListView_Name.Items.Add(h.GetString("name_cus"), i)
            itmx1.SubItems.Add(h.GetString("surname_cus"))
            itmx1.SubItems.Add(h.GetString("tel_cus"))
            itmx1.SubItems.Add(h.GetString("tax_cus"))
            itmx1.SubItems.Add(h.GetString("address_cus"))
            itmx1.SubItems.Add(h.GetString("tombun_cus"))
            itmx1.SubItems.Add(h.GetString("district_cus"))
            itmx1.SubItems.Add(h.GetString("provice_cus"))
            itmx1.SubItems.Add(h.GetString("postcode_cus"))
            itmx1.SubItems.Add(h.GetString("email_cus"))
            i += 1
        End While
        h.Close()
    End Sub

End Class