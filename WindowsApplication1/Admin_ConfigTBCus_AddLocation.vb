Imports MySql.Data.MySqlClient
Public Class Admin_ConfigTBCus_AddLocation
    Dim ac As New Admin_ClassMain
    Dim con As New Mysql
    Dim ID_Edit As String = ""
    Private Sub Admin_ConfigTBCus_AddLocation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadDATA() 'แสดงข้อมูล
        btn_cancle.Hide()
        loadCheckbox()
        For t As Integer = 0 To CheckedListBox1.Items.Count - 1
            CheckedListBox1.SetItemCheckState(t, False)
        Next
    End Sub
    Public Sub loadDATA()
        ListView1.Items.Clear() 'clear Data
        Dim itmx As New ListViewItem
        Dim reader As MySqlDataReader = con.mysql_query("SELECT * FROM pos_table_location WHERE id<>'2' ORDER BY id ASC")
        Dim i As Integer = 1
        While reader.Read()
            itmx = ListView1.Items.Add(CInt(reader.GetString("id")))
            itmx.SubItems.Add(i.ToString)
            itmx.SubItems.Add(reader.GetString("name_th"))
            itmx.SubItems.Add(reader.GetString("name_en"))
            i += 1
        End While
        reader.Close()
    End Sub

    Public Sub clearForm()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        RadioButton1.Checked = True
        RadioButton2.Checked = False
        ID_Edit = "0"
        btn_add.Enabled = True
        btn_edit.Enabled = False
        btn_del.Enabled = False
        btn_cancle.Visible = False
        btn_save.Enabled = False
        btn_reset.Enabled = False
        For t As Integer = 0 To CheckedListBox1.Items.Count - 1
            CheckedListBox1.SetItemCheckState(t, False)
        Next

    End Sub
    Private Sub btn_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_save.Click
        If TextBox1.Text <> "" And TextBox3.Text <> "" And (RadioButton1.Checked = True Or RadioButton2.Checked = True) Then
            Dim st As String = "0"
            If RadioButton1.Checked = True Then
                st = "1"
            ElseIf RadioButton2.Checked = True Then
                st = "0"
            Else
                st = "0"
            End If

            If btn_save.Text = "Update" Then
                Dim SqlString As String = "UPDATE pos_table_location SET name_th='" & TextBox1.Text & "',name_en='" & TextBox3.Text & "'," _
                & "description='" & TextBox2.Text & "',update_by='" & Login.username & "',status='" & st & "' WHERE id='" & ID_Edit & "' "
                con.mysql_query(SqlString)
                Dim del_join_location As Boolean = con.mysql_query("DELETE FROM pos_location_join_cat WHERE id_location='" & ID_Edit & "';")
                Dim SqlString1 As String = ""
                If CheckedListBox1.Items.Count > 0 Then
                    For t As Integer = 0 To CheckedListBox1.Items.Count - 1
                        If CheckedListBox1.GetItemChecked(t) = True Then
                            SqlString1 &= "INSERT INTO pos_location_join_cat (id_location,id_catprd,name_location,name_catprd,act_by) " _
                            & " VALUES('" & ID_Edit & "','" & arr(t) & "','" & TextBox1.Text & "','" & CheckedListBox1.Items.Item(t).ToString & "','" & Login.username & "');"
                        End If
                    Next
                    If SqlString1 <> "" Then
                        con.mysql_query(SqlString1)
                    End If

                End If
                MsgBox("แก้ไขเรียบร้อยแล้วค่ะ")
                btn_save.Text = "Save"
                btn_add.Enabled = False
                btn_edit.Enabled = False
                clearForm()
            Else
                Dim SqlString As String = "INSERT INTO pos_table_location (name_th,name_en,description,create_by,create_date,status)" _
                & "VALUES ('" & TextBox1.Text & "','" & TextBox3.Text & "','" & TextBox2.Text & "','" & Login.username & "','" & ac.dateFormat(Date.Now) & "','" & st & "');"

                Dim idlo1 As String = "0"
                If con.mysql_query(SqlString) = True Then
                    Dim g As MySqlDataReader = con.mysql_query("SELECT id as idlo from pos_table_location order by id desc limit 1;")
                    While g.Read
                        idlo1 = g.GetString("idlo")
                    End While
                End If


                If CheckedListBox1.Items.Count > 0 Then
                    Dim SqlString1 As String = ""
                    For t As Integer = 0 To CheckedListBox1.Items.Count - 1
                        If CheckedListBox1.GetItemChecked(t) = True Then
                            SqlString1 &= "INSERT INTO pos_location_join_cat (id_location,id_catprd,name_location,name_catprd,act_by) " _
                            & " VALUES('" & idlo1 & "','" & arr(t) & "','" & TextBox1.Text & "','" & CheckedListBox1.Items.Item(t).ToString & "','" & Login.username & "');"
                        End If
                    Next
                    If SqlString1 <> "" Then
                        con.mysql_query(SqlString1)
                    End If

                End If
                MsgBox("บันทึกเรียบร้อยแล้วค่ะ")
                btn_add.Enabled = False
                btn_edit.Enabled = False
                clearForm()
            End If
            loadDATA() 'แสดงข้อมูล
        Else
            MsgBox("กรูณากรอกชื่อพื้นที่ด้วยค่ะ")
        End If
    End Sub
    Dim arr As New ArrayList()
    Private Sub loadCheckListboxCatprd(ByVal id_location)

        Dim g As Integer = con.mysql_num_rows(con.mysql_query("select * from pos_location_join_cat" _
        & " where id_location ='" & id_location & "' "))
        If g > 0 Then
            Dim dt As MySqlDataReader = con.mysql_query("select IFNULL(pos_catprd.namecat_th,'0') as namecat_th," _
           & "IFNULL(pos_catprd.id,'0') as idcat,IFNULL(pos_table_location.id,'0') as id_loc," _
           & "IFNULL(pos_table_location.name_th,'0') as name_th_lo from pos_catprd" _
           & " LEFT JOIN  pos_location_join_cat ON pos_catprd.id  = pos_location_join_cat.id_catprd " _
           & " LEFT JOIN pos_table_location ON pos_table_location.id = pos_location_join_cat.id_location where pos_table_location.id ='" & id_location & "' ")
            While dt.Read
                For y As Integer = 0 To CheckedListBox1.Items.Count - 1
                    If arr(y) = dt.GetString("idcat") Then
                        CheckedListBox1.SetItemChecked(y, True)
                    End If
                Next
            End While
            dt.Close()
        End If
    End Sub
    Private Sub loadCheckbox()
        CheckedListBox1.Items.Clear()
        Dim dt As MySqlDataReader = con.mysql_query("select IFNULL(pos_catprd.namecat_th,'0') as namecat_th," _
            & "IFNULL(pos_catprd.id,'0') as idcat " _
            & " from pos_catprd where id_status_sales='1'  order by namecat_th asc ")
        While dt.Read
            arr.Add(dt.GetString("idcat"))
            CheckedListBox1.Items.Add(dt.GetString("namecat_th"))
            CheckedListBox1.ValueMember = (dt.GetString("idcat"))
            CheckedListBox1.DisplayMember = (dt.GetString("namecat_th"))
            ' .Items.Add(dt.GetString("namecat_th"), False)
            CheckedListBox1.SelectedIndex = 0
        End While
        dt.Close()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub
    Private Sub btn_add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_add.Click
        clearForm()
        TextBox1.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        btn_cancle.Hide()
        btn_save.Text = "Save"
        ID_Edit = "0"
        btn_del.Enabled = False
        btn_edit.Enabled = False
        btn_save.Enabled = True
        btn_reset.Enabled = True
        TextBox1.Focus()
    End Sub

    Private Sub btn_edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_edit.Click
        If ListView1.SelectedIndices.Count > 0 Then
            TextBox1.Enabled = True
            TextBox2.Enabled = True
            TextBox3.Enabled = True
            showDataEdit()
            TextBox1.Focus()
            btn_cancle.Visible = True
            btn_save.Enabled = True
            btn_reset.Enabled = True
        End If
    End Sub

    Public Sub showDataEdit()
        btn_del.Enabled = True
        btn_edit.Enabled = True
        ID_Edit = ListView1.Items(ListView1.SelectedIndices(0)).SubItems(0).Text
        Dim reader As MySqlDataReader = con.mysql_query("SELECT * FROM pos_table_location WHERE id='" & ID_Edit & "'")
        While reader.Read()
            TextBox1.Text = reader.GetString("name_th")
            TextBox3.Text = reader.GetString("name_en")
            TextBox2.Text = reader.GetString("description")
        End While
        If CInt(reader.GetString("status")) = 1 Then
            RadioButton1.Checked = True
            RadioButton2.Checked = False
        ElseIf CInt(reader.GetString("status")) = 0 Or CInt(reader.GetString("status")) = 2 Then
            RadioButton2.Checked = True
            RadioButton1.Checked = False
        End If
        reader.Close()
        loadCheckListboxCatprd(ListView1.Items.Item(ListView1.SelectedIndices(0)).SubItems(0).Text)
        btn_save.Text = "Update"
        btn_cancle.Show()
    End Sub

    Private Sub btn_del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_del.Click
        Dim Des As String = ListView1.Items(ListView1.SelectedIndices(0)).SubItems(2).Text
        Dim result As Integer = MessageBox.Show("Are You Sure Delete " & Des & " ?", "Confirm Delete Location", MessageBoxButtons.YesNo)
        If  result = DialogResult.Yes Then
            btn_save.Text = "Save"
            clearForm()
            Dim updateTb As Boolean = con.mysql_query("UPDATE pos_table_system SET ref_id_location = '0',status='3' WHERE ref_id_location='" & ListView1.Items(ListView1.SelectedIndices(0)).SubItems(0).Text & "'")
            Dim SQLDel As Boolean = con.mysql_query("DELETE FROM pos_table_location WHERE id='" & ListView1.Items(ListView1.SelectedIndices(0)).SubItems(0).Text & "'")
            Dim del_join_location As Boolean = con.mysql_query("DELETE FROM pos_location_join_cat WHERE id_location='" & ListView1.Items(ListView1.SelectedIndices(0)).SubItems(0).Text & "'")
            If updateTb = True And SQLDel = True And del_join_location = True Then
                MsgBox("Delete Complete")
            End If
            loadDATA()
        End If
    End Sub

    Private Sub btn_reset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_reset.Click
        clearForm()
    End Sub

    Private Sub btn_cancle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancle.Click
        clearForm()
        ID_Edit = "0"
        btn_cancle.Hide()
        btn_save.Text = "Save"
    End Sub

    Private Sub ListView1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick
        showDataEdit()
        btn_cancle.Visible = True
        btn_save.Enabled = True
        btn_reset.Enabled = True
        TextBox1.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        TextBox1.Focus()
    End Sub

    Private Sub ListView1_ItemSelectionChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) Handles ListView1.ItemSelectionChanged
        If ListView1.SelectedIndices.Count = 0 Then
            clearForm()
        Else
            btn_edit.Enabled = True
            btn_del.Enabled = True
        End If
    End Sub
End Class