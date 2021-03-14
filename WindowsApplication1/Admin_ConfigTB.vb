Imports MySql.Data.MySqlClient
Public Class Admin_ConfigTB
    Dim con As New Mysql
    Dim res As MySqlDataReader
    Dim id_edit As Integer = 0
    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TextBox1.Text = " "
    End Sub

    Private Sub Admin_ConfigTB_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadZone()
        loadDetail()
        ComboBox_status.SelectedIndex = 1
    End Sub
    Private Sub loadDetail()
        ListView1.Items.Clear()
        res = con.mysql_query("SELECT pos_table_system.id AS id_tb,pos_table_system.number AS number,pos_table_system.status AS status1," _
       & " IFNULL(pos_table_location.name_th,'-') AS name_th_lo,IFNULL(pos_table_location.name_en,'-') AS name_en_lo,IFNULL(pos_table_location.id,'0') AS id_loc" _
        & " FROM pos_table_system LEFT JOIN pos_table_location ON " _
       & " pos_table_system.ref_id_location=pos_table_location.id ORDER BY number ASC")

        Dim str(4) As String
        Dim itmx As New ListViewItem
        Dim i As Integer = 0
        Dim str1 As String = ""
        While res.Read
            itmx = ListView1.Items.Add(res.GetString("id_tb"), i)
            itmx.SubItems.Add(res.GetString("id_loc"))
            itmx.SubItems.Add(i + 1)
            itmx.SubItems.Add(res.GetString("number"))
            itmx.SubItems.Add(res.GetString("name_th_lo"))
            If res.GetString("status1") = "0" Then
                str1 = "ปิด"
            ElseIf res.GetString("status1") = "1" Then
                str1 = "เปิด"
            ElseIf res.GetString("status1") = "2" Then
                str1 = "กำลังใช้งาน"
            ElseIf res.GetString("status1") = "3" Then
                itmx.ForeColor = Color.Gray
                str1 = "Not Active"
            End If
            itmx.SubItems.Add(str1)
            i += 1
        End While
        
    End Sub
    Public Sub loadZone()
        Dim res_cat As MySqlDataReader
        res_cat = con.mysql_query("select id,name_en,name_th from  pos_table_location order by name_th asc")
        Dim cboItemsFl As New List(Of cboItem)
        Dim txt As String
        While res_cat.Read
            If res_cat.GetString("name_en") <> "All" Then
                txt = res_cat.GetString("name_th") & "(" & res_cat.GetString("name_en") & ")"
                cboItemsFl.Add(New cboItem With {.Text = txt, .Value = res_cat.GetString("id")})
            End If
        End While

        With Me.ComboBox_zone
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .DataSource = cboItemsFl
        End With

        If ComboBox_zone.Items.Count > 0 Then
            ComboBox_zone.SelectedIndex = 0
        End If

    End Sub
    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        TextBox1.Enabled = False
        ComboBox_zone.Enabled = False
        ComboBox_status.Enabled = False
        If Button2.Text = "cancel" Then
            Button2.Enabled = False
            btn_new.Enabled = True
            Button_Save.Enabled = False
            Button_Save.Text = "Save"
            Button2.Text = "Clear"
            id_edit = 0
        ElseIf Button2.Text = "Clear" Then
            Button2.Enabled = False
            btn_new.Enabled = True
            Button_Save.Enabled = False
        End If
        TextBox1.Text = ""
        ComboBox_zone.SelectedIndex = 0
        ComboBox_status.SelectedIndex = 0
    End Sub

    Private Sub Button_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Save.Click
        Try
            TextBox1.Enabled = False
        ComboBox_zone.Enabled = False
        ComboBox_status.Enabled = False
        Dim sta As String = "1"
        If ComboBox_status.Text = "ปิด" Then
            sta = "0"
        Else
            sta = "1"
        End If
        Dim dt As DateTime = Login.DateData.ToString("yyyy-MM-dd")
        If Login.DateData.ToString("yyyy") > 2450 Then
            dt = (Login.DateData.ToString("yyyy") - 543) & Login.DateData.ToString("-MM-dd") & Now.ToString(" HH:mm:ss")
        Else
            dt = Login.DateData.ToString("yyyy-MM-dd") & Now.ToString(" HH:mm:ss")
        End If
        Dim str As String = ""
        If Button_Save.Text = "Edit" Then
            btn_new.Enabled = True
            Button2.Enabled = False
            Button_Save.Enabled = False
            If id_edit > 0 Then
                    Dim chk As Integer = con.mysql_num_rows(con.mysql_query("SELECT number FROM pos_table_system WHERE number='" & TextBox1.Text & "' and id<>'" & id_edit & "'"))
                If chk > 0 Then
                    MessageBox.Show("มีข้อมูลโต๊ะนี้อยู๋แล้วค่ะ กรูณาตรวจสอบใหม่ด้วยค่ะ", "Message Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Dim zone As String = ""
                        If ComboBox_zone.SelectedValue = "" Then
                            zone = 0
                        Else
                            zone = ComboBox_zone.SelectedValue.ToString
                        End If
                        str = "UPDATE pos_table_system SET number='" & TextBox1.Text & "',status='" & sta & "',ref_id_location='" & zone & "',update_by='" & Login.username & "' WHERE id ='" & id_edit & "'"
                End If
            End If
            Else
                btn_new.Enabled = True
                Button2.Enabled = False
                Button_Save.Enabled = False
                Dim chk As Integer = con.mysql_num_rows(con.mysql_query("SELECT * FROM pos_table_system WHERE number='" & TextBox1.Text & "'"))
                If chk > 0 Then
                MessageBox.Show("มีข้อมูลโต๊ะนี้อยู๋แล้วค่ะ กรูณาตรวจสอบใหม่ด้วยค่ะ", "Message Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    str = "INSERT INTO pos_table_system (number,status,create_by,create_date,ref_id_location)" _
                    & "VALUES('" & TextBox1.Text & "','" & sta & "','" & Login.username & "','" & dt & "','" & ComboBox_zone.SelectedValue.ToString & "')"
                End If
            End If
        If con.mysql_query(str) = True Then
            If Button_Save.Text <> "Edit" Then
                MessageBox.Show("เพิ่มใหม่เรียบร้อย", "บันทึกเลขที่โต๊ะ", MessageBoxButtons.OK, MessageBoxIcon.Information)
                clear()
            Else
                MessageBox.Show("แก้ไขเรียบร้อย", "แก้ไขเลขที่โต๊ะ", MessageBoxButtons.OK, MessageBoxIcon.Information)
                clear()
            End If
        Else
        End If
            loadDetail()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ListView1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditItem.Click
        If ListView1.Items(ListView1.SelectedIndices(0)).SubItems(5).Text() <> "Not Active" Then
            btn_new.Enabled = False
            Button_Save.Enabled = True
            Button2.Enabled = True
            TextBox1.Enabled = True
            ComboBox_zone.Enabled = True
            ComboBox_status.Enabled = True
            Button_Save.Text = "Edit"
            Button2.Text = "cancel"
            id_edit = ListView1.Items(ListView1.SelectedIndices(0)).SubItems(0).Text()
            TextBox1.Text = ListView1.Items(ListView1.SelectedIndices(0)).SubItems(3).Text()
            ComboBox_zone.SelectedValue = ListView1.Items(ListView1.SelectedIndices(0)).SubItems(1).Text()
            If ListView1.Items(ListView1.SelectedIndices(0)).SubItems(5).Text() = "ปิด" Then
                ComboBox_status.SelectedIndex = 0
            ElseIf ListView1.Items(ListView1.SelectedIndices(0)).SubItems(5).Text() = "เปิด" Then
                ComboBox_status.SelectedIndex = 1
            End If
        Else
            btn_new.Enabled = True
            Button_Save.Enabled = False
            Button2.Enabled = False
            TextBox1.Enabled = False
            ComboBox_zone.Enabled = False
            ComboBox_status.Enabled = False
            TextBox1.Text = ListView1.Items(ListView1.SelectedIndices(0)).SubItems(3).Text()
            ComboBox_zone.SelectedValue = ListView1.Items(ListView1.SelectedIndices(0)).SubItems(1).Text()
        End If


    End Sub
    Private Sub ListView1_MouseClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles ListView1.MouseClick
        If e.Button = MouseButtons.Right Then
            If ListView1.FocusedItem.Bounds.Contains(e.Location) = True Then
                Dim check_active As MySqlDataReader = con.mysql_query("SELECT status FROM pos_table_system WHERE id='" & ListView1.Items(ListView1.SelectedIndices(0)).SubItems(0).Text() & "'")
                check_active.Read()
                If CInt(check_active.GetString("status")) = 3 Then
                    ActiveToolStripMenuItem.Visible = True
                    DelItem.Visible = False
                ElseIf CInt(check_active.GetString("status")) = 2 Or CInt(check_active.GetString("status")) = 1 Or CInt(check_active.GetString("status")) = 0 Then
                    ActiveToolStripMenuItem.Visible = False
                    DelItem.Visible = True
                End If
                ContextMenuStrip1.Show(Cursor.Position)
            End If
        End If
    End Sub

    Private Sub DelItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DelItem.Click
        If ListView1.SelectedIndices.Count = 0 Then
            Exit Sub
        End If
        If ListView1.Items.Count > 0 Then
            Dim result = MessageBox.Show("Are you sure Not Active" & ListView1.Items(ListView1.SelectedIndices(0)).SubItems(3).Text & " ?", "Message Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                con.mysql_query("DELETE FROM pos_order_list WHERE rf_id_table='" & ListView1.Items(ListView1.SelectedIndices(0)).SubItems(0).Text & "' and status_pay='no'")
                If con.mysql_query("UPDATE pos_table_system  SET status='3',update_by='" & Login.username & "' WHERE id='" & ListView1.Items(ListView1.SelectedIndices(0)).SubItems(0).Text & "' ") = True Then
                    MessageBox.Show("Not Active Complete.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    loadDetail()
                End If
            End If
        End If
    End Sub

    Private Sub clear()
        If Button2.Text = "cancel" Then
            Button_Save.Text = "Save"
            Button2.Text = "Clear"
            id_edit = 0
        End If
        TextBox1.Text = ""
        ComboBox_zone.SelectedIndex = 0
        ComboBox_status.SelectedIndex = 0
    End Sub
    Private Sub ListView1_DoubleClick_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick
        If ListView1.Items(ListView1.SelectedIndices(0)).SubItems(5).Text() <> "Not Active" Then
            btn_new.Enabled = False
            Button_Save.Enabled = True
            Button2.Enabled = True
            TextBox1.Enabled = True
            ComboBox_zone.Enabled = True
            ComboBox_status.Enabled = True
            Button_Save.Text = "Edit"
            Button2.Text = "cancel"
            id_edit = ListView1.Items(ListView1.SelectedIndices(0)).SubItems(0).Text()
            TextBox1.Text = ListView1.Items(ListView1.SelectedIndices(0)).SubItems(3).Text()
            ComboBox_zone.SelectedValue = ListView1.Items(ListView1.SelectedIndices(0)).SubItems(1).Text()
            If ListView1.Items(ListView1.SelectedIndices(0)).SubItems(5).Text() = "ปิด" Then
                ComboBox_status.SelectedIndex = 0
            ElseIf ListView1.Items(ListView1.SelectedIndices(0)).SubItems(5).Text() = "เปิด" Then
                ComboBox_status.SelectedIndex = 1
            End If
        Else
            btn_new.Enabled = True
            Button_Save.Enabled = False
            Button2.Enabled = False
            TextBox1.Enabled = False
            ComboBox_zone.Enabled = False
            ComboBox_status.Enabled = False
            TextBox1.Text = ListView1.Items(ListView1.SelectedIndices(0)).SubItems(3).Text()
            ComboBox_zone.SelectedValue = ListView1.Items(ListView1.SelectedIndices(0)).SubItems(1).Text()
        End If
    End Sub

    Private Sub btn_new_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_new.Click
        btn_new.Enabled = False
        Button_Save.Enabled = True
        Button2.Enabled = True
        If Button2.Text = "cancel" Then
            Button_Save.Text = "Save"
            Button2.Text = "Clear"
            id_edit = 0
        End If
        TextBox1.Enabled = True
        ComboBox_zone.Enabled = True
        ComboBox_status.Enabled = True
        TextBox1.Text = ""
        ComboBox_zone.SelectedIndex = 0
        ComboBox_status.SelectedIndex = 0
    End Sub
    Private Sub ActiveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActiveToolStripMenuItem.Click
        If ListView1.SelectedIndices.Count = 0 Then
            Exit Sub
        End If
        If ListView1.Items.Count > 0 Then
            Dim result = MessageBox.Show("Are you sure Active " & ListView1.Items(ListView1.SelectedIndices(0)).SubItems(3).Text & " ?", "Active Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                If con.mysql_query("UPDATE pos_table_system  SET status='1',update_by='" & Login.username & "' WHERE id='" & ListView1.Items(ListView1.SelectedIndices(0)).SubItems(0).Text & "' ") = True Then
                    MessageBox.Show("Active Complete.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    loadDetail()
                End If
            End If
        End If
    End Sub
End Class