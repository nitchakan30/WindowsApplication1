Imports MySql.Data.MySqlClient
Imports System
Imports System.IO
Imports System.Text

Public Class Admin_addUser
    Dim con As New Mysql

    Dim res_per As MySqlDataReader
    Dim ac As New Admin_ClassMain
    Dim ID_edit As Integer
    Dim pathname As String
    Dim name_img As String
    Dim images_user As String
    Dim taype_img As String
    Dim pic_user As String = ""

    Private Sub Admin_addUser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadData()
        btn_edit.Visible = False
        btn_del.Visible = False
        btn_cancle.Visible = False
    End Sub
    Private Sub Admin_addUser_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        con.mysql_close()

    End Sub

    Private Sub Admin_addUser_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        con.mysql_close()

    End Sub
    Public Sub loadData()
        ListView1.Items.Clear() 'clear Data
        Dim res_user As MySqlDataReader = con.mysql_query("select * from pos_user order by id ASC")
        Dim i As Integer = 0
        Dim itmx As New ListViewItem
        While res_user.Read()
            i += 1
            itmx = ListView1.Items.Add(res_user.GetString("id"), CInt(res_user.GetString("id")))
            itmx.SubItems.Add(i.ToString)
            itmx.SubItems.Add(res_user.GetString("username"))
            itmx.SubItems.Add(res_user.GetString("name") & " " & res_user.GetString("surname"))
            itmx.SubItems.Add(res_user.GetString("tel"))

            ' ListView1.Items.Add("id_user", )
        End While
    End Sub
    Public Sub clearForm()
        txt_username.Text = ""
        txt_password.Text = ""
        txt_name.Text = ""
        txt_surname.Text = ""
        txt_tel.Text = ""
        txt_email.Text = ""
        txt_numemp.Text = ""
        CheckedListBox1.ClearSelected()
        RadioButton1.Checked = True
        RadioButton2.Checked = False
        btn_save.Text = "Save"
        PictureBox1.Image = Nothing
        CheckedListBox1.ClearSelected()
        For i As Integer = 0 To CheckedListBox1.Items.Count - 1
            CheckedListBox1.SetItemChecked(i, False)
        Next
       
    End Sub
    Private Sub btn_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_save.Click
        Dim Enable As String = "0"
        If RadioButton1.Checked = True Then
            Enable = "1"
        ElseIf RadioButton2.Checked = True Then
            Enable = "0"
        End If

        If txt_username.Text <> "" And txt_password.Text <> "" Then

            If btn_save.Text = "Update" Then

                Dim pic_user As String = ""
                Dim prm_nameIMG As String = ""
                'GET FOLDER IMG
                Dim objReader As New System.IO.StreamReader("active_fol.bat", Encoding.UTF8)
                Dim TextLine() As String
                Dim fulltextIMG As String = ""

                Do While objReader.Peek() <> -1
                    TextLine = objReader.ReadLine().ToString.Trim.Split("=")
                    If TextLine(0).ToString.Trim = "folderAvatar" Then
                        fulltextIMG &= TextLine(1).ToString.Trim
                    End If
                Loop
                'CLOSE LOOP GET FOLDER IMG
                If name_img <> "" Then
                    Dim time As DateTime = DateTime.Now
                    pic_user = Login.TextBox_Username.Text & time.Millisecond & taype_img
                    If images_user <> "" Then
                        File.Delete(fulltextIMG & images_user) 'delete images old
                        File.Copy(pathname, fulltextIMG & pic_user)
                        prm_nameIMG = " ,name_img='" & pic_user & "'" 'set update data on table pos_user
                    Else
                        File.Copy(pathname, fulltextIMG & pic_user)
                        prm_nameIMG = " ,name_img='" & pic_user & "'" 'set update data on table pos_user
                    End If
                Else
                    prm_nameIMG = ""
                End If
                Dim ac_void As Integer = 0
                If active_void.Checked = True Then
                    ac_void = 1
                Else
                    ac_void = 0
                End If
                Dim update As Boolean = con.mysql_query("UPDATE pos_user SET username='" & txt_username.Text & "'," _
                & "password='" & txt_password.Text & "',name='" & txt_name.Text & "',surname='" & txt_surname.Text & "'," _
                & "tel='" & txt_tel.Text & "',email='" & txt_email.Text & "',number_emp='" & txt_numemp.Text & "'," _
                & "enable_emp='" & Enable & "',cnf_void='" & ac_void & "',update_by='ADMIN' " & prm_nameIMG & " WHERE id='" & ID_edit & "'")

                If update = True Then
                    'INSERT Table pos_user_permission_match
                    Dim update_per As String = "UPDATE pos_user_permission_match SET update_by='ADMIN' "

                    For i As Integer = 0 To CheckedListBox1.Items.Count - 1
                        If CheckedListBox1.GetItemChecked(i) = True Then
                            If CheckedListBox1.Items.Item(i).ToString = "POS System" Then
                                update_per += ",POS_system = '1' "
                            ElseIf CheckedListBox1.Items.Item(i).ToString() = "Closing Bill" Then
                                update_per += ",closing_bill= '1'"
                            ElseIf CheckedListBox1.Items.Item(i).ToString() = "Profile Shop" Then
                                update_per += ",profile_shop= '1'"
                            ElseIf CheckedListBox1.Items.Item(i).ToString() = "Manage Table Food" Then
                                update_per += ",manage_tb= '1'"
                            ElseIf CheckedListBox1.Items.Item(i).ToString() = "Manage Product" Then
                                update_per += ",manage_prd= '1'"
                            ElseIf CheckedListBox1.Items.Item(i).ToString() = "Setting Other" Then
                                update_per += ",setting_other= '1'"
                            ElseIf CheckedListBox1.Items.Item(i).ToString() = "Report" Then
                                update_per += ",report= '1'"
                            ElseIf CheckedListBox1.Items.Item(i).ToString() = "Manage User" Then
                                update_per += ",user= '1'"
                            ElseIf CheckedListBox1.Items.Item(i).ToString() = "Stock" Then
                                update_per += ",stock= '1'"
                            End If
                        Else
                            If CheckedListBox1.Items.Item(i).ToString() = "POS System" Then
                                update_per += ",POS_system = '0' "
                            ElseIf CheckedListBox1.Items.Item(i).ToString() = "Closing Bill" Then
                                update_per += ",closing_bill= '0'"
                            ElseIf CheckedListBox1.Items.Item(i).ToString() = "Profile Shop" Then
                                update_per += ",profile_shop= '0'"
                            ElseIf CheckedListBox1.Items.Item(i).ToString() = "Manage Table Food" Then
                                update_per += ",manage_tb= '0'"
                            ElseIf CheckedListBox1.Items.Item(i).ToString() = "Manage Product" Then
                                update_per += ",manage_prd= '0'"
                            ElseIf CheckedListBox1.Items.Item(i).ToString() = "Setting Other" Then
                                update_per += ",setting_other= '0'"
                            ElseIf CheckedListBox1.Items.Item(i).ToString() = "Report" Then
                                update_per += ",report= '0'"
                            ElseIf CheckedListBox1.Items.Item(i).ToString() = "Manage User" Then
                                update_per += ",user= '0'"
                            ElseIf CheckedListBox1.Items.Item(i).ToString() = "Stock" Then
                                update_per += ",stock= '0'"
                            End If
                        End If
                    Next
                    update_per += " WHERE id_user ='" & ID_edit & "'"
                    'MsgBox(update_per)
                    Dim query_pere As Boolean = con.mysql_query(update_per) 'query update permission user

                    If query_pere = True Or update = True Then
                        MsgBox("Update User Complete")
                        clearForm()
                        btn_edit.Visible = False
                        btn_del.Visible = False
                        active_void.Checked = False
                    End If

                Else
                    MsgBox("Error Update User Please Contact Admin")
                    clearForm()
                    active_void.Checked = False
                End If
            Else
                'GET FOLDER IMG
                Dim objReader As New System.IO.StreamReader("active_fol.bat", Encoding.UTF8)
                Dim TextLine() As String
                Dim fulltextIMG As String = ""

                Do While objReader.Peek() <> -1
                    TextLine = objReader.ReadLine().ToString.Trim.Split("=")
                    If TextLine(0).ToString.Trim = "folderAvatar" Then
                        fulltextIMG &= TextLine(1).ToString.Trim
                    End If
                Loop
                'CLOSE LOOP GET FOLDER IMG
                If name_img <> "" Then
                    Dim time As DateTime = DateTime.Now
                    pic_user = Login.TextBox_Username.Text & time.Millisecond & taype_img
                    'MsgBox(pic_user)
                    System.IO.File.Copy(pathname, fulltextIMG & pic_user)
                End If
                Dim ac_void As Integer = 0
                If active_void.Checked = True Then
                    ac_void = 1
                Else
                    ac_void = 0
                End If
                Dim insert As Boolean = con.mysql_query("INSERT INTO pos_user (username,password,name,surname,tel," _
            & "email,number_emp,enable_emp,create_by,create_date,name_img,cnf_void) VALUES('" & txt_username.Text & "','" & txt_password.Text & "'," _
            & "'" & txt_name.Text & "','" & txt_surname.Text & "','" & txt_tel.Text & "','" & txt_email.Text & "'," _
            & "'" & txt_numemp.Text & "','" & Enable & "','ADMIN','" & ac.dateFormat(Date.Now) & "','" & pic_user & "','" & ac_void & "')")
                If insert = True Then
                    'query id user after insert user
                    Dim id_user As String = "0"
                    Dim res_user As MySqlDataReader = con.mysql_query("select id AS id from pos_user where username='" + txt_username.Text + "' limit 1")
                    While res_user.Read()
                        id_user = res_user.GetString("id")
                    End While

                    'INSERT Table pos_user_permission_match
                    Dim insert_per As String = "INSERT INTO pos_user_permission_match (id_user"

                    For Each itemChecked In CheckedListBox1.CheckedItems
                        If itemChecked.ToString() = "POS System" Then
                            insert_per += ",POS_system"
                        ElseIf itemChecked.ToString() = "Closing Bill" Then
                            insert_per += ",closing_bill"
                        ElseIf itemChecked.ToString() = "Profile Shop" Then
                            insert_per += ",profile_shop"
                        ElseIf itemChecked.ToString() = "Manage Table Food" Then
                            insert_per += ",manage_tb"
                        ElseIf itemChecked.ToString() = "Manage Product" Then
                            insert_per += ",manage_prd"
                        ElseIf itemChecked.ToString() = "Setting Other" Then
                            insert_per += ",setting_other"
                        ElseIf itemChecked.ToString() = "Report" Then
                            insert_per += ",report"
                        ElseIf itemChecked.ToString() = "Manage User" Then
                            insert_per += ",user"
                        ElseIf itemChecked.ToString() = "Stock" Then
                            insert_per += ",stock"
                        End If
                    Next

                    insert_per += ",create_by,create_date) VALUES('" + id_user + "'"

                    For Each itemChecked In CheckedListBox1.CheckedItems

                        If itemChecked.ToString() = "POS System" Then
                            insert_per += ",'1'"
                        ElseIf itemChecked.ToString() = "Closing Bill" Then
                            insert_per += ",'1'"
                        ElseIf itemChecked.ToString() = "Profile Shop" Then
                            insert_per += ",'1'"
                        ElseIf itemChecked.ToString() = "Manage Table Food" Then
                            insert_per += ",'1'"
                        ElseIf itemChecked.ToString() = "Manage Product" Then
                            insert_per += ",'1'"
                        ElseIf itemChecked.ToString() = "Setting Other" Then
                            insert_per += ",'1'"
                        ElseIf itemChecked.ToString() = "Report" Then
                            insert_per += ",'1'"
                        ElseIf itemChecked.ToString() = "Manage User" Then
                            insert_per += ",'1'"
                        ElseIf itemChecked.ToString() = "Stock" Then
                            insert_per += ",'1'"
                        End If

                        ' Use the IndexOf method to get the index of an item.
                        ' MessageBox.Show("Item with title: " + quote + itemChecked.ToString() + quote + _
                        ' ", is checked. Checked state is: " + _
                        ' CheckedListBox1.GetItemCheckState(CheckedListBox1.Items.IndexOf(itemChecked)).ToString() + ".")
                    Next
                    insert_per += ",'ADMIN','" + ac.dateFormat(Date.Now) + "')"
                    'MsgBox(insert_per)
                    Dim chk_permission As Boolean = con.mysql_query(insert_per)

                    If chk_permission = True Or insert = True Then
                        MsgBox("Add User Complete")
                        active_void.Checked = False
                        clearForm()
                    End If
                    btn_edit.Visible = False
                    btn_del.Visible = False
                Else
                    MsgBox("Error Add User Please Contact Admin")
                    clearForm()
                    active_void.Checked = False
                End If
            End If
            loadData()
        Else
            If txt_username.Text = "" Then
                MsgBox("Please input username")
                txt_username.Focus()
            ElseIf txt_password.Text = "" Then
                MsgBox("Please input password")
                txt_password.Focus()
            End If
        End If

    End Sub

    Private Sub btn_reset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_reset.Click, btn_cancle.Click
        clearForm()
        btn_save.Text = "Save"
        btn_del.Visible = False
        btn_edit.Visible = False
        btn_cancle.Visible = False
        active_void.Checked = False
    End Sub

    Private Sub btn_back_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_back.Click
        con.mysql_close()
        Me.Close()
    End Sub
    Public Sub setID()
        Dim user As String = ListView1.Items(ListView1.FocusedItem.Index).SubItems(0).Text
        Dim res_user As MySqlDataReader = con.mysql_query("select * from pos_user where id='" & user & "' limit 1")
        While res_user.Read()
            ID_edit = res_user.GetString("id")
        End While

    End Sub
    Public Sub Load_update()
        Dim res_user1 As MySqlDataReader = con.mysql_query("select IFNULL(username,'0') as username," _
        & "IFNULL(password,'0') as password,IFNULL(name,'-') as name,IFNULL(surname,'-') as surname," _
        & "IFNULL(tel,'-') as tel,IFNULL(email,'-') as email,IFNULL(number_emp,'0') as number_emp,IFNULL(name_img,'-') as name_img," _
        & "IFNULL(enable_emp,'0') as enable_emp,id as id,IFNULL(cnf_void,'0') as cnf_void " _
        & " from pos_user where id='" & ID_edit & "'")
        While res_user1.Read()
            txt_username.Text = res_user1.GetString("username")
            txt_password.Text = res_user1.GetString("password")
            txt_name.Text = res_user1.GetString("name")
            txt_surname.Text = res_user1.GetString("surname")
            txt_tel.Text = res_user1.GetString("tel")
            txt_email.Text = res_user1.GetString("email")
            Dim j As String = ""
            If res_user1.GetString("number_emp") = "" Then
                j = ""
            Else
                j = res_user1.GetString("number_emp")
            End If
            txt_numemp.Text = j
            images_user = res_user1.GetString("name_img")

            If images_user <> "" Then
                'GET FOLDER IMG
                Dim objReader As New System.IO.StreamReader("active_fol.bat", Encoding.UTF8)
                Dim TextLine() As String
                Dim fulltextIMG As String = ""

                Do While objReader.Peek() <> -1
                    TextLine = objReader.ReadLine().ToString.Trim.Split("=")
                    If TextLine(0).ToString.Trim = "folderAvatar" Then
                        fulltextIMG &= TextLine(1).ToString.Trim
                    End If
                Loop
                objReader.Close()
                objReader.Dispose()
                'CLOSE LOOP GET FOLDER IMG
                PictureBox1.ImageLocation = fulltextIMG & res_user1.GetString("name_img")
                ' Using fs As New System.IO.FileStream("avatar\" & res_user.GetString("name_img"), IO.FileMode.Open, IO.FileAccess.Read)
                '' PictureBox1.Image = System.Drawing.Image.FromStream(fs)
                ' End Using
            End If


            If res_user1.GetString("enable_emp") = "1" Then
                RadioButton1.Checked = True
                RadioButton2.Checked = False
            Else
                RadioButton1.Checked = False
                RadioButton2.Checked = True
            End If
            If CInt(res_user1.GetString("cnf_void")) = 1 Then
                active_void.Checked = True
            Else
                active_void.Checked = False
            End If
        End While

        'select permission show
        Dim res_per1 As MySqlDataReader = con.mysql_query("select * from pos_user_permission_match where id_user = '" & ID_edit & "' ")
        While res_per1.Read()
            If res_per1.GetString("POS_system") = "1" Then
                CheckedListBox1.SetItemChecked(0, True)
            End If
            If res_per1.GetString("closing_bill") = "1" Then
                CheckedListBox1.SetItemChecked(1, True)
            End If
            If res_per1.GetString("profile_shop") = "1" Then
                CheckedListBox1.SetItemChecked(2, True)
            End If
            If res_per1.GetString("manage_tb") = "1" Then
                CheckedListBox1.SetItemChecked(3, True)
            End If
            If res_per1.GetString("manage_prd") = "1" Then
                CheckedListBox1.SetItemChecked(4, True)
            End If
            If res_per1.GetString("setting_other") = "1" Then
                CheckedListBox1.SetItemChecked(5, True)
            End If
            If res_per1.GetString("report") = "1" Then
                CheckedListBox1.SetItemChecked(6, True)
            End If
            If res_per1.GetString("user") = "1" Then
                CheckedListBox1.SetItemChecked(7, True)
            End If
            If res_per1.GetString("stock") = "1" Then
                CheckedListBox1.SetItemChecked(8, True)
            End If
        End While
        res_per1.Close()
      
    End Sub
    Private Sub btn_edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_edit.Click
        Dim res_user As MySqlDataReader = con.mysql_query("select IFNULL(username,'0') as username," _
        & "IFNULL(password,'0') as password,IFNULL(name,'-') as name,IFNULL(surname,'-') as surname," _
        & "IFNULL(tel,'-') as tel,IFNULL(email,'-') as email,IFNULL(number_emp,'0') as number_emp,IFNULL(name_img,'-') as name_img," _
        & "IFNULL(enable_emp,'0') as enable_emp,id as id,IFNULL(cnf_void,'0') as cnf_void" _
        & " from pos_user where id='" & ID_edit & "'")
        While res_user.Read()
            txt_username.Text = res_user.GetString("username")
            txt_password.Text = res_user.GetString("password")
            txt_name.Text = res_user.GetString("name")
            txt_surname.Text = res_user.GetString("surname")
            txt_tel.Text = res_user.GetString("tel")
            txt_email.Text = res_user.GetString("email")
            txt_numemp.Text = res_user.GetString("number_emp")
            images_user = res_user.GetString("name_img")
            If images_user <> "" Then
                'GET FOLDER IMG
                Dim objReader As New System.IO.StreamReader("active_fol.bat", Encoding.UTF8)
                Dim TextLine() As String
                Dim fulltextIMG As String = ""

                Do While objReader.Peek() <> -1
                    TextLine = objReader.ReadLine().ToString.Trim.Split("=")
                    If TextLine(0).ToString.Trim = "folderAvatar" Then
                        fulltextIMG &= TextLine(1).ToString.Trim
                    End If
                Loop
                'CLOSE LOOP GET FOLDER IMG
                PictureBox1.ImageLocation = fulltextIMG & res_user.GetString("name_img")
                ' Using fs As New System.IO.FileStream("avatar\" & res_user.GetString("name_img"), IO.FileMode.Open, IO.FileAccess.Read)
                '' PictureBox1.Image = System.Drawing.Image.FromStream(fs)
                ' End Using
            End If
           

            If res_user.GetString("enable_emp") = "1" Then
                RadioButton1.Checked = True
                RadioButton2.Checked = False
            Else
                RadioButton1.Checked = False
                RadioButton2.Checked = True
            End If
            If CInt(res_user.GetString("cnf_void")) = 1 Then
                active_void.Checked = True
            Else
                active_void.Checked = False
            End If
        End While

        'select permission show
        res_per = con.mysql_query("select * from pos_user_permission_match where id_user = '" & ID_edit & "' ")
        While res_per.Read()
            If res_per.GetString("POS_system") = "1" Then
                CheckedListBox1.SetItemChecked(0, True)
            End If
            If res_per.GetString("closing_bill") = "1" Then
                CheckedListBox1.SetItemChecked(1, True)
            End If
            If res_per.GetString("profile_shop") = "1" Then
                CheckedListBox1.SetItemChecked(2, True)
            End If
            If res_per.GetString("manage_tb") = "1" Then
                CheckedListBox1.SetItemChecked(3, True)
            End If
            If res_per.GetString("manage_prd") = "1" Then
                CheckedListBox1.SetItemChecked(4, True)
            End If
            If res_per.GetString("setting_other") = "1" Then
                CheckedListBox1.SetItemChecked(5, True)
            End If
            If res_per.GetString("report") = "1" Then
                CheckedListBox1.SetItemChecked(6, True)
            End If
            If res_per.GetString("user") = "1" Then
                CheckedListBox1.SetItemChecked(7, True)
            End If
            If res_per.GetString("stock") = "1" Then
                CheckedListBox1.SetItemChecked(8, True)
            End If
        End While
        res_per.Close()
        btn_save.Text = "Update"
        btn_cancle.Visible = True
    End Sub

    Private Sub ListView1_MouseUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView1.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Left Then
            setID() 'set id
            'clearForm()
            ' btn_save.Text = "Save"
            btn_del.Visible = True
            btn_edit.Visible = True
            btn_cancle.Visible = True
        End If
        Return
    End Sub

    Private Sub btn_add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_add.Click
        clearForm()
        btn_save.Text = "Save"
        btn_del.Visible = False
        btn_edit.Visible = False
        btn_cancle.Visible = False
    End Sub

    Private Sub btn_del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_del.Click

        If ListView1.Items.Count() > 0 Then

            Dim Des As String = ListView1.Items(ListView1.FocusedItem.Index).SubItems(2).Text

            Dim result As Integer = MessageBox.Show("Are You Sure Delete " & Des & " ?", "Confirm Delete User", MessageBoxButtons.YesNo)
            If result = DialogResult.No Then

            ElseIf result = DialogResult.Yes Then
                btn_save.Text = "Save"
                clearForm()
                Dim Del As Boolean = con.mysql_query("DELETE FROM pos_user WHERE id='" & ID_edit & "'")
                If Del = True Then
                    Dim Del_permission As Boolean = con.mysql_query("DELETE FROM pos_user_permission_match WHERE id_user='" & ID_edit & "'")
                    MsgBox("Delete user Complete")
                Else
                    MsgBox("Error Delete user Complete")
                End If
                loadData()
                btn_del.Visible = False
                btn_edit.Visible = False
                btn_cancle.Visible = False
            End If

        Else
            MsgBox("Data is null")
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim OpenFileDialog1 As New OpenFileDialog
        OpenFileDialog1.Filter = "Picture Files (*)|*.bmp;*.gif;*.jpg;*.png"

        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            PictureBox1.Image = Image.FromFile(OpenFileDialog1.FileName)
            pathname = OpenFileDialog1.FileName
            name_img = OpenFileDialog1.SafeFileName
            taype_img = IO.Path.GetExtension(OpenFileDialog1.FileName)
        End If

    End Sub

    Private Sub ListView1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick
        btn_save.Text = "Update"
        btn_cancle.Visible = True
        Load_update()
    End Sub

    Private Sub ListView1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.Click
        setID()
    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        btn_del.Visible = False
        btn_edit.Visible = False
        btn_save.Text = "Save"
        clearForm()
    End Sub
End Class