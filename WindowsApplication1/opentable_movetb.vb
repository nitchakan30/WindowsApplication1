Imports MySql.Data.MySqlClient
Imports System.IO
Public Class opentable_movetb
    Dim con As New Mysql
    Dim Res_TB As MySqlDataReader
    Dim Res_lo As MySqlDataReader
    Dim list As New ArrayList
    Dim Arr As New ArrayList
    Dim cout As Integer = 0
    Private Sub opentable_jointb_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'NameTabs = ""
    End Sub
    Private Sub opentable_jointb_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TabControl2.TabPages.Clear()
        loadShowTabs()
        ShowTabs()
        TextBox1.Text = home1.Label_tb_select.Text
    End Sub
    Public Sub ShowTabs()

        Res_lo = con.mysql_query("select * from pos_table_location where name_en<>'All' ")
        Dim i As Integer = 0
        While Res_lo.Read()

            Res_TB = con.mysql_query("select pos_table_location.id As idLo,pos_table_location.name_en  As nameEnLo," _
          & " pos_table_system.id AS id,pos_table_system.number AS number,pos_table_system.ref_id_location AS ref_id_location	from pos_table_system " _
          & " LEFT JOIN pos_table_location ON pos_table_system.ref_id_location= pos_table_location.id " _
          & "where  pos_table_location.status='1' and pos_table_system.status='1' and pos_table_system.ref_id_location='" & Res_lo.GetString("id") & "'")

            Dim newPage As New TabPage()
            newPage.Text = Res_lo.GetString("name_en")
            newPage.Name = Res_lo.GetString("name_en")
            newPage.Tag = cout.ToString

            Dim CheckedListBox As New CheckedListBox
            CheckedListBox.Name = "Checkbox" & cout
            CheckedListBox.Height = "405"
            CheckedListBox.Width = "309"
            CheckedListBox.Dock = DockStyle.Fill
            'CheckedListBox.ScrollAlwaysVisible = True
            CheckedListBox.DataSource = Nothing
            CheckedListBox.Items.Clear()
            While Res_TB.Read()
                If Res_TB.GetString("id") <> Login.OpenId Then
                    list.Add("Checkbox" & cout.ToString)
                    CheckedListBox.Items.Add(Res_TB.GetString("number"), False)
                End If
            End While
            newPage.Controls.Add(CheckedListBox)
            TabControl2.TabPages.Add(newPage)
            i += 1
            AddHandler CheckedListBox.MouseUp, AddressOf btn_select_Click
            cout += 1
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
       & "where pos_table_location.status='1' and pos_table_system.status='1' and pos_table_system.id_join_tb='0' ")
        Dim CheckedListBox1 As New CheckedListBox
        CheckedListBox1.Name = "CheckboxAll"
        CheckedListBox1.Height = "405"
        CheckedListBox1.Width = "309"
        CheckedListBox1.Dock = DockStyle.Fill
        CheckedListBox1.DataSource = Nothing
        CheckedListBox1.ScrollAlwaysVisible = True
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
        AddHandler CheckedListBox1.MouseUp, AddressOf btn_select_Click
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
        'Try
        If NameTabs = "All" Then
            Dim b As CheckedListBox = TabControl2.SelectedTab.Controls.Item(TabControl2.SelectedTab.Controls.IndexOfKey("CheckboxAll"))
            Dim str As String
            'เครียล์ ตัวที่ติกให้หมดก่อน
            For j As Integer = 0 To b.Items.Count - 1
                b.SetItemCheckState(j, CheckState.Unchecked)
            Next
            b.SetItemCheckState(b.SelectedIndex, CheckState.Checked)

            str = b.GetItemText(b.SelectedItem)

            For i As Integer = 0 To TabControl2.TabPages.Count - 1
                If TabControl2.TabPages.Item(i).Tag <> "All" Then
                    Dim c As CheckedListBox = TabControl2.TabPages.Item(i).Controls.Item(TabControl2.TabPages.Item(i).Controls.IndexOfKey("Checkbox" & TabControl2.TabPages.Item(i).Tag))
                    For j As Integer = 0 To c.Items.Count - 1
                        c.SetItemCheckState(j, CheckState.Unchecked)
                    Next
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
            For i As Integer = 0 To TabControl2.TabPages.Count - 1
                If TabControl2.TabPages.Item(i).Tag <> "All" Then
                    Dim a As CheckedListBox = TabControl2.TabPages.Item(i).Controls.Item(TabControl2.TabPages.Item(i).Controls.IndexOfKey("Checkbox" & TabControl2.TabPages.Item(i).Tag))
                    For j As Integer = 0 To a.Items.Count - 1
                        a.SetItemCheckState(j, CheckState.Unchecked)
                    Next
                End If
            Next

            Dim b As CheckedListBox = TabControl2.SelectedTab.Controls.Item(TabControl2.SelectedTab.Controls.IndexOfKey("Checkbox" & TabControl2.SelectedTab.Tag))
            Dim str As String
            For j As Integer = 0 To b.Items.Count - 1
                b.SetItemCheckState(j, CheckState.Unchecked)
            Next
            b.SetItemCheckState(b.SelectedIndex, CheckState.Checked)
            str = b.GetItemText(b.SelectedItem)

            Dim c As CheckedListBox = TabControl2.Controls.Item(0).Controls.Item(TabControl2.Controls.Item(0).Controls.IndexOfKey("CheckboxAll"))
            For j As Integer = 0 To c.Items.Count - 1
                c.SetItemCheckState(j, CheckState.Unchecked)
            Next
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
        'Catch ex As Exception
        'MessageBox.Show("Please contact Admin.! -" & ex.Message)
        'End Try
    End Sub
    Private Sub btn_jointb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_jointb.Click
        Try
            Dim Array1 As New ArrayList
            Array1.Clear()
            Dim c As CheckedListBox = TabControl2.Controls.Item(0).Controls.Item(TabControl2.Controls.Item(0).Controls.IndexOfKey("CheckboxAll"))
            For j As Integer = 0 To c.Items.Count - 1
                If c.GetItemCheckState(j) = CheckState.Checked Then
                    'ดึงค่าออกจาก CboItem select index ก่อนอันดับแรก
                    c.SelectedIndex = j
                    'Add ค่าใส่ array
                    Array1.Add(c.SelectedValue)
                End If
            Next
            '===== เช็คว่ามีการรวมโต๊ะอยู๋หรือเปล่า==='
            'MsgBox(index.getNameTable(CInt(home1.Tb_Id_OldJoin)) & "==" & index.getNameTable(CInt(Login.OpenId)))
            Dim Tb_ID As Integer = home1.Tb_Id_OldJoin
            If Tb_ID <> Login.OpenId And Tb_ID > 0 Then '==== เข้าเงื่อนไขที่มีการรวมโต๊ะ===='
                Dim Str_Query As String = ""
                Dim g As MySqlDataReader = con.mysql_query("SELECT IFNULL(invoice_number,'0') as invoice_number,IFNULL(id_join_tb,'0') as id_join_tb,IFNULL(remark_tb,'-') as remark_tb FROM pos_table_system WHERE id='" & Tb_ID & "' and id_join_tb<>'0';")
                g.Read()
                Dim invoice_number As String = g.GetString("invoice_number")
                Dim id_join_tb As String = g.GetString("id_join_tb")
                Dim remark_tb As String = g.GetString("remark_tb")
                Dim id_tbmove1 As Integer = 0
                If Array1.Count > 0 And Array1.Count <= 1 Then
                    For Each id_tbmove In Array1
                        id_tbmove1 = id_tbmove
                        Str_Query &= "UPDATE pos_order_list SET rf_id_table='" & id_tbmove & "' WHERE rf_id_table='" & Tb_ID & "' and status_pay='no';"
                        Str_Query &= "UPDATE pos_table_system SET status='2',id_join_tb='" & id_join_tb & "',remark_tb='" & remark_tb & "',invoice_number='" & invoice_number & "' WHERE id='" & id_tbmove & "';"
                        Str_Query &= "UPDATE pos_table_system SET status='1',id_join_tb='0',invoice_number='0',remark_tb='-' WHERE id='" & Tb_ID & "';"
                    Next
                    Dim h As Boolean = con.mysql_query(Str_Query)
                    If h = True Then
                        If Login.LangG = "TH" Then
                            MessageBox.Show("ทำการเปลี่ยนโต๊ะเรียบร้อย.", "Message Alert Change Table", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("Change Table Complete.", "Message Alert Change Table", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                        home1.Label_tb_select.Text = "Table No. " & index.getNameTable(CInt(id_tbmove1)) & " Option"
                        Login.OpenId = id_tbmove1
                        home1.ShowTable(home1.TabControl1.SelectedTab.Tag, home1.TabControl1.SelectedIndex)
                        home1.ShowListView_Order()
                        Me.Close()
                        home1_menu.Close()
                    End If
                Else
                    MessageBox.Show("กรุณาเลือกโต๊ะด้วยค่ะ", "Message Alert Move TABLE")
                End If
            ElseIf Tb_ID = Login.OpenId Then  '==== โต๊ะที่ย้ายเป็นโต๊ะ Head ในการรวมดต๊ะ===='
                Dim str As String = ""
                If Array1.Count > 0 And Array1.Count <= 1 Then
                    Dim g As MySqlDataReader = con.mysql_query("SELECT * FROM pos_table_system WHERE id='" & Tb_ID & "' and id_join_tb<>'0';")
                    g.Read()
                    Dim invoice_number As String = g.GetString("invoice_number")
                    Dim id_join_tb_old As String = g.GetString("id_join_tb")
                    Dim remark_tb As String = g.GetString("remark_tb")
                    Dim id_tbmove1 As Integer = 0
                    For Each id_tbmove In Array1
                        id_tbmove1 = id_tbmove
                        str &= "UPDATE pos_order_list SET rf_id_table='" & id_tbmove & "',ref_id_join='" & id_tbmove & "' WHERE rf_id_table='" & Tb_ID & "' and status_pay='no';"
                        Dim L As MySqlDataReader = con.mysql_query("SELECT * FROM pos_table_system WHERE id_join_tb='" & Tb_ID & "'")
                        While L.Read()
                            str &= "UPDATE pos_order_list SET ref_id_join='" & id_tbmove & "' WHERE rf_id_table='" & L.GetString("id") & "' and status_pay='no';"
                            str &= "UPDATE pos_table_system SET id_join_tb='" & id_tbmove & "' WHERE id='" & L.GetString("id") & "';"
                        End While
                        str &= "UPDATE pos_table_system SET status='2',id_join_tb='" & id_tbmove & "',remark_tb='" & remark_tb & "',invoice_number='" & invoice_number & "' WHERE id='" & id_tbmove & "';"
                        str &= "UPDATE pos_table_system SET status='1',id_join_tb='0',invoice_number='0',remark_tb='-' WHERE id='" & Tb_ID & "';"
                    Next
                    Dim p As Boolean = con.mysql_query(str)
                    If p = True Then
                        If Login.LangG = "TH" Then
                            MessageBox.Show("ทำการเปลี่ยนโต๊ะเรียบร้อย.", "Message Alert Change Table", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("Change Table Complete.", "Message Alert Change Table", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                        home1.Label_tb_select.Text = "Table No. " & index.getNameTable(CInt(id_tbmove1)) & " Option"
                        Login.OpenId = id_tbmove1
                        home1.ShowTable(home1.TabControl1.SelectedTab.Tag, home1.TabControl1.SelectedIndex)
                        home1.ShowListView_Order()
                        Me.Close()
                        home1_menu.Close()
                    End If
                Else
                    MessageBox.Show("กรุณาเลือกโต๊ะด้วยค่ะ", "Message Alert Move TABLE")
                End If
            ElseIf Tb_ID = 0 And Login.OpenId > 0 Then '==== เข้าเงื่อนไขที่ไม่่มีการรวมโต๊ะไว้====='
                '===== loop อัพเดตข้อมูลโต๊ะที่ต้องการย้ายไป===='
                'Update Table
                If Array1.Count > 0 And Array1.Count <= 1 Then
                    Dim stry As String = ""
                    Dim id_tbmove1 As Integer = 0
                    For Each id_tbmove In Array1
                        id_tbmove1 = id_tbmove
                        Dim f As MySqlDataReader = con.mysql_query("select IFNULL(remark_tb,'-') as remark_tb,IFNULL(id_join_tb,'0') as id_join_tb,IFNULL(invoice_number,'0') as invoice_number from pos_table_system where id='" & Login.OpenId & "'")
                        f.Read()
                        Dim invoice_number As String = f.GetString("invoice_number")
                        Dim id_join_tb As String = f.GetString("id_join_tb")
                        Dim remark_tb As String = f.GetString("remark_tb")
                        stry &= "UPDATE pos_order_list SET rf_id_table='" & id_tbmove & "'  WHERE rf_id_table='" & Login.OpenId & "' and status_pay='no';"
                        stry &= "UPDATE pos_table_system SET status='2',id_join_tb='" & id_join_tb & "',remark_tb='" & remark_tb & "',invoice_number='" & invoice_number & "' WHERE id='" & id_tbmove & "';"
                        stry &= "UPDATE pos_table_system SET status='1',id_join_tb='0',invoice_number='0',remark_tb='-' WHERE id='" & Login.OpenId & "';"
                    Next
                    Dim up_d As Boolean = con.mysql_query(stry)
                    If up_d = True Then
                        If Login.LangG = "TH" Then
                            MessageBox.Show("ทำการเปลี่ยนโต๊ะเรียบร้อย.", "Message Alert Change Table", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("Change Table Complete.", "Message Alert Change Table", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                        home1.Label_tb_select.Text = "Table No. " & index.getNameTable(CInt(id_tbmove1)) & " Option"
                        Login.OpenId = id_tbmove1
                        home1.ShowTable(home1.TabControl1.SelectedTab.Tag, home1.TabControl1.SelectedIndex)
                        home1.ShowListView_Order()
                        Me.Close()
                        home1_menu.Close()
                    End If
                Else
                    MessageBox.Show("กรุณาเลือกโต๊ะด้วยค่ะ", "Message Alert Move TABLE")
                End If
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
