Imports MySql.Data.MySqlClient
Imports System.IO
Public Class opentable_jointb
    Dim con As New Mysql
    Dim Res_TB As MySqlDataReader
    Dim Res_lo As MySqlDataReader
    Dim list As New ArrayList
    Dim Arr As New ArrayList
    Dim ac As New Admin_ClassMain
    Private Sub opentable_jointb_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        NameTabs = ""
    End Sub
    Private Sub opentable_jointb_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TabControl2.TabPages.Clear()
        loadShowTabs()
        ShowTabs()
    End Sub
    Public Sub ShowTabs()

        Res_lo = con.mysql_query("select * from pos_table_location where name_en<>'All' ")
        Dim i As Integer = 0
        While Res_lo.Read()

            Res_TB = con.mysql_query("select pos_table_location.id As idLo,pos_table_location.name_en  As nameEnLo," _
          & " pos_table_system.id AS id,pos_table_system.number AS number,pos_table_system.ref_id_location AS ref_id_location	from pos_table_system " _
          & " LEFT JOIN pos_table_location ON pos_table_system.ref_id_location= pos_table_location.id " _
          & "where pos_table_system.status='2' and pos_table_system.ref_id_location='" & Res_lo.GetString("id") & "'")

            Dim newPage As New TabPage()
            newPage.Text = Res_lo.GetString("name_en")
            newPage.Name = Res_lo.GetString("name_en")
            newPage.Tag = Res_lo.GetString("id")

            Dim CheckedListBox As New CheckedListBox
            CheckedListBox.Name = "Checkbox" & Res_lo.GetString("id")
            CheckedListBox.Height = "460"
            CheckedListBox.Width = "309"
            While Res_TB.Read()
                If Res_TB.GetString("id") <> Login.OpenId Then
                    list.Add("Checkbox" & Res_lo.GetString("id"))
                    CheckedListBox.Items.Add(Res_TB.GetString("number"), False)
                End If
            End While
            newPage.Controls.Add(CheckedListBox)
            TabControl2.TabPages.Add(newPage)
            i += 1

        End While

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ShowTabs()
    End Sub

    Private Sub TabControl2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl2.Click
        If TabControl2.SelectedTab.Tag <> "All" Then
            NameTabs = TabControl2.SelectedTab.Tag
        Else
            NameTabs = "All"
        End If
    End Sub
    Public Sub loadShowTabs()
        Dim newPage As New TabPage()
        newPage.Text = "All"
        newPage.Name = "TabPage3"
        newPage.Tag = "All"
        TabControl2.TabPages.Add(newPage)

        Dim Res_TB1 As MySqlDataReader
        Res_TB1 = con.mysql_query("select pos_table_location.id As idLo,pos_table_location.name_en  As nameEnLo," _
       & " pos_table_system.id AS id,pos_table_system.number AS number,pos_table_system.ref_id_location AS ref_id_location	from pos_table_system " _
       & " LEFT JOIN pos_table_location ON pos_table_system.ref_id_location= pos_table_location.id " _
       & "where pos_table_system.status='2' and pos_table_system.id_join_tb='0' ")
        Dim CheckedListBox1 As New CheckedListBox
        CheckedListBox1.Name = "CheckboxAll"
        CheckedListBox1.Height = "460"
        CheckedListBox1.Width = "309"
        CheckedListBox1.DataSource = Nothing
        CheckedListBox1.Items.Clear()
        Dim cboItemsFl As New List(Of cboItem1)
        While Res_TB1.Read()
            If Res_TB1.GetString("id") <> Login.OpenId Then
                cboItemsFl.Add(New cboItem1 With {.Text = Res_TB1.GetString("number"), .Value = Res_TB1.GetString("id")})
            End If
        End While
        With CheckedListBox1
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .DataSource = cboItemsFl
        End With
        newPage.Controls.Add(CheckedListBox1)
    End Sub

    Public NameTabs As String = "All"
    Private Sub btn_up_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_up.Click
        Try
            Dim b As CheckedListBox = TabControl2.SelectedTab.Controls.Item(TabControl2.SelectedTab.Controls.IndexOfKey("Checkbox" & NameTabs))
            If b.Name <> "CheckedListBox1" Then
                If b.SelectedIndices.Count > 0 Then
                    If b.SelectedIndex < b.Items.Count - 1 Then
                        Dim selectedIndex As Integer = b.SelectedIndex
                        Dim selectedItem As Object = b.SelectedItem
                        selectedIndex -= 1
                        b.SelectedIndex = selectedIndex
                    End If
                Else
                    If b.Items.Count > 0 Then
                        b.SelectedIndex = 0
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Please contact Admin.! -" & ex.Message)
        End Try
    End Sub
    Private Sub btn_drow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_drow.Click
        Try
        Dim b As CheckedListBox = TabControl2.SelectedTab.Controls.Item(TabControl2.SelectedTab.Controls.IndexOfKey("Checkbox" & NameTabs))
            If b.Name <> "CheckedListBox1" Then
                If b.SelectedIndices.Count > 0 Then
                    If b.SelectedIndex < b.Items.Count - 1 Then
                        Dim selectedIndex As Integer = b.SelectedIndex
                        Dim selectedItem As Object = b.SelectedItem
                        selectedIndex += 1
                        b.SelectedIndex = selectedIndex
                    End If
                Else
                    If b.Items.Count > 0 Then
                        b.SelectedIndex = 0
                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show("Please contact Admin.! -" & ex.Message)
        End Try
    End Sub

    Private Sub btn_select_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_select.Click
        Try
            If NameTabs = "All" Then
                Dim b As CheckedListBox = TabControl2.SelectedTab.Controls.Item(TabControl2.SelectedTab.Controls.IndexOfKey("CheckboxAll"))
                Dim str As String
                If b.GetItemCheckState(b.SelectedIndices(0)) = CheckState.Unchecked Then
                    b.SetItemCheckState(b.SelectedIndices(0), CheckState.Checked)
                Else
                    b.SetItemCheckState(b.SelectedIndices(0), CheckState.Unchecked)
                End If
                str = b.GetItemText(b.SelectedItem)

                For i As Integer = 0 To TabControl2.Controls.Count - 1
                    If TabControl2.TabPages.Item(i).Tag <> "All" Then
                        Dim c As CheckedListBox = TabControl2.Controls.Item(i).Controls.Item(TabControl2.Controls.Item(i).Controls.IndexOfKey("Checkbox" & TabControl2.TabPages.Item(i).Tag))
                        For j As Integer = 0 To c.Items.Count - 1
                            If c.Items.Item(j).ToString = str Then

                                If b.GetItemCheckState(b.SelectedIndices(0)) = CheckState.Unchecked Then
                                    c.SetItemCheckState(j, CheckState.Unchecked)
                                Else
                                    c.SetItemCheckState(j, CheckState.Checked)
                                End If
                                Exit Sub
                            End If
                        Next
                    End If
                Next
            Else
                Dim b As CheckedListBox = TabControl2.SelectedTab.Controls.Item(TabControl2.SelectedTab.Controls.IndexOfKey("Checkbox" & NameTabs))
                Dim str As String
                If b.GetItemCheckState(b.SelectedIndices(0)) = CheckState.Unchecked Then
                    b.SetItemCheckState(b.SelectedIndices(0), CheckState.Checked)
                Else
                    b.SetItemCheckState(b.SelectedIndices(0), CheckState.Unchecked)
                End If
                str = b.GetItemText(b.SelectedItem)

                Dim c As CheckedListBox = TabControl2.Controls.Item(0).Controls.Item(TabControl2.Controls.Item(0).Controls.IndexOfKey("CheckboxAll"))
                For j As Integer = 0 To c.Items.Count - 1
                    If c.GetItemText(c.Items.Item(j)) = str Then
                        If b.GetItemCheckState(b.SelectedIndices(0)) = CheckState.Unchecked Then
                            c.SetItemCheckState(j, CheckState.Unchecked)
                        Else
                            c.SetItemCheckState(j, CheckState.Checked)
                        End If
                        Exit Sub
                    End If
                Next
            End If
        Catch ex As Exception
            MessageBox.Show("Please contact Admin.! -" & ex.Message)
        End Try
    End Sub
    Private Sub btn_jointb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_jointb.Click
        Try
            Dim Array1 As New ArrayList
            Dim c As CheckedListBox = TabControl2.Controls.Item(0).Controls.Item(TabControl2.Controls.Item(0).Controls.IndexOfKey("CheckboxAll"))

            For j As Integer = 0 To c.Items.Count - 1
                If c.GetItemCheckState(j) = CheckState.Checked Then
                    'ดึงค่าออกจาก CboItem select index ก่อนอันดับแรก
                    c.SelectedIndex = j
                    'Add ค่าใส่ array
                    Array1.Add(c.SelectedValue)
                End If
            Next
            'Update Table
            Dim dateNew As DateTime = Login.DateData.ToString("yyyy-MM-dd")
            If Array1.Count > 0 Then
                Dim Str2 As String = ""
                Dim Str3 As String = ""
                Dim num As Integer

                For Each num In Array1
                    Str2 &= "UPDATE pos_order_list SET update_by='" & Login.username & "',ref_id_join='" & Login.OpenId & "' WHERE rf_id_table='" & num & "' and status_pay='no' and (pos_order_list.create_date LIKE '%" & dateNew.ToString("yyyy-MM-dd") & "%');"
                    Str2 &= "UPDATE pos_table_system SET id_join_tb='" & Login.OpenId & "',update_by='" & Login.username & "' WHERE id='" & num & "';"
                    Str2 &= "UPDATE pos_table_system SET id_join_tb='" & Login.OpenId & "',update_by='" & Login.username & "' WHERE id='" & Login.OpenId & "';"
                Next
                Str2 &= "UPDATE pos_order_list SET update_by='" & Login.username & "',ref_id_join='" & Login.OpenId & "' WHERE pos_order_list.rf_id_table='" & Login.OpenId & "' and status_pay='no';"
                Dim tUpOrd As Boolean = con.mysql_query(Str2)
                If tUpOrd = True Then
                    Dim invoice_number As String = "0"
                    Dim cd As MySqlDataReader = con.mysql_query("select IFNULL(invoice_number,'0') as invoice_number from pos_table_system where id='" & Login.OpenId & "';")
                    cd.Read()
                    If cd.GetString("invoice_number") = "0" Then
                        invoice_number = ac.CreateBillOntb(Login.OpenId) 'สร้าง number invoice ส่งค่าเลขที่โต๊ะเพื่อให้เช็ค
                    Else
                        invoice_number = cd.GetString("invoice_number")
                    End If
                    If invoice_number <> "0" Then
                        Dim id_inv As String = payment.GetIdInv_Pos_Invoice_Temp(invoice_number)
                        '==== ตามลบ inv ในโต๊ะอื่นๆที่เปิดทิ้งไว้===='
                        Dim j As String = ""
                        Dim cv As MySqlDataReader = con.mysql_query("select * from pos_table_system where id_join_tb='" & Login.OpenId & "' and id<>'" & Login.OpenId & "';")
                        While cv.Read
                            j &= "DELETE FROM pos_invoice_temp where namber_inv='" & cv.GetString("invoice_number") & "';"
                        End While
                        j &= "UPDATE pos_order_list SET rf_id_invoice='" & id_inv & "' where ref_id_join='" & Login.OpenId & "' and status_pay='no';"
                        j &= "UPDATE pos_table_system SET invoice_number='" & invoice_number & "' where id_join_tb='" & Login.OpenId & "';"
                        con.mysql_query(j)
                    End If
                    MessageBox.Show("รวมโต๊ะเรียบร้อย", "Message Alert Join TABLE")
                    Array1.Clear()
                    home1.ShowTable(home1.TabControl1.SelectedTab.Tag, home1.TabControl1.SelectedIndex)
                    home1.Panel_Ontb.Hide()
                    home1.Panel_Reservation.Hide()
                    home1.Panel1.Show()
                    Me.Close()
                    home1_menu.Close()
                End If
            Else
                MessageBox.Show("กรุณาเลือกโต๊ะด้วยค่ะ", "Message Alert Join TABLE")
            End If
        Catch ex As Exception
            MessageBox.Show("Please contact Admin.! -" & ex.Message)
        End Try
    End Sub
    Private Sub btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        NameTabs = ""
        Me.Close()
    End Sub

End Class
Friend Class cboItem1
    Public Property Text As String
    Public Property Value As String
End Class