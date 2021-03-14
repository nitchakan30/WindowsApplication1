Imports MySql.Data.MySqlClient
Public Class Admin_addCatPrd
    Dim ac As New Admin_ClassMain
    Dim arr_OnTb As String = "0" ' set data value for ontb
    Dim arr_OnSales As String = "0" 'set data value for onsales
    Dim arr_IDEdit As String = "All" ' set data id for edit
    Dim arr_Select As String = "All"
    Dim arr_IDSubEdit As String = ""
    Dim con As New Mysql
    Private Sub Admin_addCatPrd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            loadDataTreeview() 'Show DATA TreeView1
            btnCancel.Hide()
            btnEditCat.Visible = False
            btnDelCat.Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Public Sub loadDataTreeview()
        TreeView1.Nodes.Clear()
        TreeView1.Nodes.Add("Node0", "All")
        Dim strQuery As String = "SELECT * FROM pos_catprd where id_status_sales<>'2' ORDER BY id ASC "
        ShowDataTreeviewCat(strQuery, "SELECT_CAT")
    End Sub
    Public Sub ShowDataTreeviewCat(ByRef SQLStatement As String, ByRef TypeIN As String)
        If TypeIN = "SELECT_CAT" Then
            Dim reader As MySqlDataReader = con.mysql_query(SQLStatement)
            Dim childnodes() As TreeNode
            Dim str As New List(Of String)()
            Dim i As Integer = 0
            Dim str_name As String
            Dim Nodes(5) As TreeNode
            While reader.Read()
                Dim id As String = reader.GetString("id")
                childnodes = TreeView1.Nodes.Find("Node0", True)

                If reader.GetString("namecat_th") <> "" Then
                    str_name = reader.GetString("namecat_th") & " (" & reader.GetString("namecat_en") & ")"
                Else
                    str_name = reader.GetString("namecat_en") & " (" & reader.GetString("namecat_th") & ")"
                End If
              
                ' TreeView1.Nodes.Add("All").Nodes.Add(reader.GetString("id"), str_name, reader.GetString("id"))
                childnodes(0).Nodes.Add(id, reader.GetString("id_cat") & "-" & str_name, reader.GetString("id"), reader.GetString("id"))

                'add sub childnodes
                str.Add(id)
                i += 1
            End While
            reader.Close()

            For j = 0 To i - 1
                loadSubNotes(str(j))
            Next
        End If
        TreeView1.ExpandAll()
    End Sub
    Public Sub loadSubNotes(ByVal NodesID As Integer)
        Dim reader_sub As MySqlDataReader = con.mysql_query("SELECT * FROM pos_catsubprd WHERE ref_id_cat='" & NodesID & "' and id_status_sales<>'2' ORDER BY id ASC")
        Dim subchildnodes1(2) As TreeNode
        Dim str_name As String
        Dim i As Integer = 0
        While reader_sub.Read()
            If reader_sub.GetString("id") <> "" Then
                subchildnodes1 = TreeView1.Nodes.Find(NodesID, True)
                If reader_sub.GetString("name_th") <> "" Then
                    str_name = reader_sub.GetString("name_th") & " (" & reader_sub.GetString("name_en") & ")"
                Else
                    str_name = reader_sub.GetString("name_en") & " (" & reader_sub.GetString("name_th") & ")"
                End If
                subchildnodes1(0).Nodes.Add(reader_sub.GetString("id"), reader_sub.GetString("id_subcat") & "-" & str_name, reader_sub.GetString("id"), reader_sub.GetString("id"))
            End If
        End While
    End Sub
    Public Sub InsertFiled(ByRef SQLStatement As String, ByVal msgShow As String)
        Dim x As Boolean = con.mysql_query(SQLStatement)
        If msgShow <> "" And x = True Then
            MsgBox(msgShow)
        End If
    End Sub
    Public Sub selectEdit(ByRef SQLStatement)
        Dim reader As MySqlDataReader = con.mysql_query(SQLStatement)
        While reader.Read()
            arr_IDEdit = reader.GetString("id")
            arr_OnSales = reader.GetString("id_status_sales")
            arr_OnTb = reader.GetString("id_status_table")
            txtIDCat.Text = reader.GetString("id_cat")
            txtDesCatTH.Text = reader.GetString("namecat_th")
            txtDesCatEN.Text = reader.GetString("namecat_en")
        End While
        reader.Close()
        If arr_OnSales = "1" Then
            SetOn_Sales()
        ElseIf arr_OnSales = "0" Then
            SetOff_Sales()
        End If

        If arr_OnTb = "1" Then
            ' SetOn_TB()
            NotCountStk()
        ElseIf arr_OnTb = "0" Then
            ' SetOff_TB()
            CountStk()
        End If
    End Sub
    Public Sub selectSubEdit(ByRef SQLStatement)
        Dim reader As MySqlDataReader = con.mysql_query(SQLStatement)
        While reader.Read()
            arr_IDSubEdit = reader.GetString("id")
            arr_OnSales = reader.GetString("id_status_sales")
            arr_OnTb = reader.GetString("id_status_table")
            txtIDCat.Text = reader.GetString("id_subcat")
            txtDesCatTH.Text = reader.GetString("name_th")
            txtDesCatEN.Text = reader.GetString("name_en")

        End While
        If arr_OnSales = "1" Then
            SetOn_Sales()
        ElseIf arr_OnSales = "0" Then
            SetOff_Sales()
        End If

        If arr_OnTb = "1" Then
            ' SetOn_TB()
            NotCountStk()
        ElseIf arr_OnTb = "0" Then
            'SetOff_TB()
            CountStk()
        End If
    End Sub
    Public Sub setID(ByVal SQLStatement)
        Dim reader1 As MySqlDataReader = con.mysql_query(SQLStatement)
        While reader1.Read()
            arr_IDEdit = reader1.GetString("id")
        End While
        reader1.Close()
    End Sub
    Public Sub setSubID(ByVal SQLStatement)
        Dim reader1 As MySqlDataReader = con.mysql_query(SQLStatement)
        While reader1.Read()
            arr_IDSubEdit = reader1.GetString("id")
        End While
        reader1.Close()
    End Sub


    Public Sub saveCat()
        Dim SQLstring As String
        SQLstring = "INSERT INTO pos_catprd (id_cat,namecat_en,namecat_th,create_date,create_by,id_status_sales,id_status_table) " _
        & "VALUES('" & txtIDCat.Text & "','" & txtDesCatEN.Text & "','" & txtDesCatTH.Text & "','" & ac.dateFormat(Date.Now) & "','" & Login.username & "','" & arr_OnSales & "','" & arr_OnTb & "')"

        InsertFiled(SQLstring, "Save Group Complete.") 'บันทึกข้อมูลลงดาต้าเบส
        clear_text() 'รีเซ็ตข้อมูลในฟอร์ม

    End Sub
    Public Sub saveSubCat()

        Dim SQLstring As String
        SQLstring = "INSERT INTO pos_catsubprd (id_subcat,name_th,name_en,create_date,create_by,id_status_sales,id_status_table,ref_id_cat) " _
        & "VALUES('" & txtIDCat.Text & "','" & txtDesCatTH.Text & "','" & txtDesCatEN.Text & "','" & ac.dateFormat(Date.Now) & "','" & Login.username & "','" & arr_OnSales & "','" & arr_OnTb & "','" & TreeView1.SelectedNode.SelectedImageKey.ToString & "')"

        InsertFiled(SQLstring, "Save Sub-Group Complete.") 'บันทึกข้อมูลลงดาต้าเบส
        clear_text() 'รีเซ็ตข้อมูลในฟอร์ม
    End Sub
    Public Sub editCat()

        Dim SQLstring As String
        SQLstring = "UPDATE pos_catprd SET id_cat='" & txtIDCat.Text & "',namecat_en='" & txtDesCatEN.Text & "',namecat_th='" & txtDesCatTH.Text & "',update_by='" & Login.username & "' " _
        & ",id_status_sales='" & arr_OnSales & "',id_status_table='" & arr_OnTb & "' WHERE id='" & TreeView1.SelectedNode.SelectedImageKey.ToString & "' "

        InsertFiled(SQLstring, "Edit Group Complete.") 'บันทึกข้อมูลลงดาต้าเบส
        btnSaveCat.Text = "Save Group"
        clear_text() 'รีเซ็ตข้อมูลในฟอร์ม
    End Sub
    Public Sub editSubCat()

        Dim SQLstring As String
        SQLstring = "UPDATE pos_catsubprd SET id_subcat='" & txtIDCat.Text & "',name_en='" & txtDesCatEN.Text & "',name_th='" & txtDesCatTH.Text & "',update_by='" & Login.username & "' " _
        & ",id_status_sales='" & arr_OnSales & "',id_status_table='" & arr_OnTb & "' WHERE id='" & TreeView1.SelectedNode.SelectedImageKey.ToString & "' "
        InsertFiled(SQLstring, "Edit Sub-Group Complete") 'บันทึกข้อมูลลงดาต้าเบส
        btnSaveCat.Text = "Save Group"
        clear_text() 'รีเซ็ตข้อมูลในฟอร์ม
    End Sub
    Public Sub loadShowONOFFTB()
        Dim sql1 As String = ""
        If TreeView1.SelectedNode.Level = "1" Then
            sql1 = "select * from pos_catprd where id='" & TreeView1.SelectedNode.SelectedImageKey.ToString & "' "

        ElseIf TreeView1.SelectedNode.Level = "2" Then
            sql1 = "select * from pos_catsubprd where id='" & TreeView1.SelectedNode.SelectedImageKey.ToString & "' "

        End If
        Dim reader As MySqlDataReader = con.mysql_query(sql1)
        While reader.Read()

            If reader.GetString("id_status_sales") = "1" Then
                arr_OnSales = "1"
                SetOn_Sales()
            ElseIf reader.GetString("id_status_sales") = "0" Then
                arr_OnSales = "0"
                SetOff_Sales()
            End If

            If reader.GetString("id_status_table") = "1" Then
                arr_OnTb = "1"
                '  SetOn_TB()
                NotCountStk()
            ElseIf reader.GetString("id_status_table") = "0" Then
                arr_OnTb = "0"
                'SetOff_TB()
                CountStk()
            End If

        End While

    End Sub
    Public Sub DelCat()
        If TreeView1.SelectedNode.Level = "1" Then
           
            Dim SQLstring As String
            SQLstring = "UPDATE pos_catprd SET id_status_sales='2' WHERE id='" & TreeView1.SelectedNode.SelectedImageKey.ToString & "'"
            ' SQLstring = "DELETE FROM pos_catprd WHERE id='" & TreeView1.SelectedNode.SelectedImageKey.ToString & "'"
            Dim SQLStringSub As String
            SQLStringSub = "UPDATE pos_catsubprd SET id_status_sales='2' WHERE ref_id_cat='" & TreeView1.SelectedNode.SelectedImageKey.ToString & "';"
            SQLStringSub &= "UPDATE pos_product SET id_status_sales='2' where ref__id_catprd='" & TreeView1.SelectedNode.SelectedImageKey.ToString & "';"
            Dim result = MessageBox.Show("Are you sure delete " & TreeView1.SelectedNode.Text & " ?", "Delete Group", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If result = DialogResult.Yes Then
                InsertFiled(SQLStringSub, "") 'บันทึกข้อมูลลงดาต้าเบส
                InsertFiled(SQLstring, "Delete Group Complete.") 'บันทึกข้อมูลลงดาต้าเบส
            ElseIf result = DialogResult.No Then

            End If
        ElseIf TreeView1.SelectedNode.Level = "2" Then

            Dim SQLstring As String
            SQLstring = "UPDATE pos_catsubprd SET id_status_sales='2' WHERE id='" & TreeView1.SelectedNode.SelectedImageKey.ToString & "';"
            SQLstring &= "UPDATE pos_product SET id_status_sales='2' where ref__id_catsubprd='" & TreeView1.SelectedNode.SelectedImageKey.ToString & "';"
            Dim result = MessageBox.Show("Are you sure delete " & TreeView1.SelectedNode.Text & " ?", "Delete Sub-Group", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If result = DialogResult.Yes Then
                InsertFiled(SQLstring, "Delete Sub-Group Complete") 'บันทึกข้อมูลลงดาต้าเบส
            ElseIf result = DialogResult.No Then

            End If

        End If
        loadDataTreeview() 'Show DATA TreeView1
        clear_text() 'รีเซ็ตข้อมูลในฟอร์ม
        btnSaveCat.Enabled = False
        btnClearText.Enabled = False
        btnCancel.Enabled = False
        txtIDCat.Enabled = False
        txtDesCatTH.Enabled = False
        txtDesCatEN.Enabled = False
    End Sub

    Public Sub clear_text()
        txtIDCat.Text = ""
        txtDesCatTH.Text = ""
        txtDesCatEN.Text = ""
        txtIDCat.ReadOnly = False
        arr_OnSales = "0"
        arr_OnTb = "0"
        ' SetOff_TB()
        CountStk()
        SetOff_Sales()
    End Sub
    Public Sub SetOff_TB()
        btnOnTBOpen.BackColor = Color.DarkGray
        btnOnTBOff.BackColor = Color.Red
        arr_OnTb = "0"
    End Sub
    Public Sub SetOn_TB()
        btnOnTBOpen.BackColor = Color.LimeGreen
        btnOnTBOff.BackColor = Color.DarkGray
        arr_OnTb = "1"
    End Sub
    Public Sub CountStk()
        btnOnTBOpen.BackColor = Color.LimeGreen
        btnOnTBOff.BackColor = Color.DarkGray
        arr_OnTb = "0"
    End Sub
    Public Sub NotCountStk()
        btnOnTBOpen.BackColor = Color.DarkGray
        btnOnTBOff.BackColor = Color.Red
        arr_OnTb = "1"
    End Sub
    Public Sub SetOn_Sales()
        btnSalesOpen.BackColor = Color.LimeGreen
        btnSalesOff.BackColor = Color.DarkGray
        arr_OnSales = "1"
    End Sub
    Public Sub SetOff_Sales()
        btnSalesOpen.BackColor = Color.DarkGray
        btnSalesOff.BackColor = Color.Red
        arr_OnSales = "0"
    End Sub

    Private Sub btnSaveCat_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveCat.Click
        CHK_SaveCat() 'ฟังก์ชันเช็คก่อนบันทึกข้อมูล
    End Sub

    Private Sub btnOnTBOpen_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOnTBOpen.Click
        arr_OnTb = "0"
        ' SetOff_TB()
        CountStk()
    End Sub

    Private Sub btnSalesOpen_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalesOpen.Click
        arr_OnSales = "1"
        SetOn_Sales()
    End Sub

    Private Sub btnOnTBOff_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOnTBOff.Click
        arr_OnTb = "1"
        ' SetOn_TB()
        NotCountStk()
    End Sub

    Private Sub btnSalesOff_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalesOff.Click
        arr_OnSales = "0"
        SetOff_Sales()
    End Sub

    Private Sub btnCancel_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        'clear_text()
        arr_OnTb = "0"
        arr_OnSales = "0"
        btnSaveCat.Text = "Save"
        arr_IDEdit = "All"
        arr_IDSubEdit = ""
        btnCancel.Hide()
        GroupBox1.Text = "Add Group"
        btnSaveCat.Enabled = False
        btnClearText.Enabled = False
        btnCancel.Enabled = False
        txtIDCat.Enabled = False
        txtDesCatTH.Enabled = False
        txtDesCatEN.Enabled = False
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        clear_text()
        arr_IDEdit = ""
        Me.Close()
    End Sub

    Private Sub btnClearText_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearText.Click
        clear_text()
    End Sub

    Private Sub btnAddCat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddCat.Click
        clear_text()
        btnCancel.Hide()
        GroupBox1.Text = "Add Group"
        btnSaveCat.Enabled = True
        btnClearText.Enabled = True
        btnCancel.Enabled = True
        txtIDCat.Enabled = True
        txtDesCatTH.Enabled = True
        txtDesCatEN.Enabled = True
        If btnAddCat.Text = "Add Sub-Group" Then
            btnSaveCat.Text = "Save Sub-Group"
            Label2.Text = "Number Sub-Group"
            Label9.Text = "Name Sub-Group [TH]"
            Label6.Text = "Name Sub-Group [EN]"
            Label3.Hide()
            btnOnTBOpen.Hide()
            btnOnTBOff.Hide()
        Else
            btnSaveCat.Text = "Save"
            Label2.Text = "Number Group"
            Label9.Text = "Name Group [TH]"
            Label6.Text = "Name Group [EN]"
        End If

    End Sub

    Public Sub SelectsetArrOnTB()
        Dim reader As MySqlDataReader = con.mysql_query("SELECT id FROM pos_status_table order by id ASC")
        While reader.Read()
            txtIDCat.Text = reader.GetString("id_cat")
            txtDesCatTH.Text = reader.GetString("namecat_th")
            txtDesCatEN.Text = reader.GetString("namecat_en")
        End While
    End Sub

    Public Sub CHK_SaveCat()
        Dim pr As Boolean = False
        If txtIDCat.Text <> "" Then
            pr = True
        ElseIf txtDesCatTH.Text <> "" Then
            pr = True
        ElseIf txtDesCatEN.Text <> "" Then
            pr = True
        Else
            pr = False
            MsgBox("Please input data")
        End If

        If pr = True Then
            If btnSaveCat.Text = "Save" Then
                saveCat() 'บันทึกข้อมูลลงดาต้าเบส
            ElseIf btnSaveCat.Text = "Save Sub-Group" Then
                saveSubCat() 'บันทึกข้อมูลหมวดหมู่ย่อยลงดาต้าเบส
            ElseIf btnSaveCat.Text = "Edit Sub-Group" Then
                editSubCat()
            ElseIf btnSaveCat.Text = "Edit" Then
                editCat() 'แก้ไขข้อมูลลงดาต้าเบส
            End If
            btnSaveCat.Enabled = False
            btnClearText.Enabled = False
            btnCancel.Enabled = False
            txtIDCat.Enabled = False
            txtDesCatTH.Enabled = False
            txtDesCatEN.Enabled = False
        End If
        loadDataTreeview() 'Show DATA TreeView1
        clear_text()
    End Sub

    Private Sub btnEditCat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditCat.Click

        If TreeView1.SelectedNode.IsSelected = True Then
            btnCancel.Show()
            If TreeView1.SelectedNode.Level = "1" Then
                Dim strQuery As String = "SELECT * FROM pos_catprd WHERE id = '" & TreeView1.SelectedNode.SelectedImageKey.ToString & "'"
                selectEdit(strQuery)
                btnSaveCat.Text = "Edit"
                GroupBox1.Text = "Edit Group"
                btnSaveCat.Enabled = True
                btnClearText.Enabled = True
                btnCancel.Enabled = True
                txtIDCat.Enabled = True
                txtDesCatTH.Enabled = True
                txtDesCatEN.Enabled = True
            ElseIf TreeView1.SelectedNode.Level = "2" Then
                Dim strQuery As String = "SELECT * FROM pos_catsubprd WHERE  id = '" & TreeView1.SelectedNode.SelectedImageKey.ToString & "'"
                selectSubEdit(strQuery)
                btnSaveCat.Text = "Edit Sub-Group"
                GroupBox1.Text = "Edit Sub-Group"
                btnSaveCat.Enabled = True
                btnClearText.Enabled = True
                btnCancel.Enabled = True
                txtIDCat.Enabled = True
                txtDesCatTH.Enabled = True
                txtDesCatEN.Enabled = True
            End If

        End If

    End Sub

    Private Sub btnDelCat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelCat.Click
        DelCat() 'sub delete cat
        GroupBox1.Text = "Add Group"
    End Sub


    Private Sub TreeView1_NodeMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles TreeView1.NodeMouseClick
        If e.Button = Windows.Forms.MouseButtons.Left Then
            TreeView1.SelectedNode = e.Node

            If TreeView1.SelectedNode.Text = "All" Then
                arr_IDEdit = "All"
                btnAddCat.Visible = True
                btnAddCat.Text = "Add Group"
                txtIDCat.Text = ""
                txtDesCatTH.Text = ""
                txtDesCatEN.Text = ""
                Label2.Text = "Number Group"
                Label9.Text = "Name Group [TH]"
                Label6.Text = "Name Group [EN]"
                btnSaveCat.Text = "Save"
                btnEditCat.Visible = False
                btnDelCat.Visible = False
                btnOnTBOpen.Show()
                btnOnTBOff.Show()
                Label3.Show()
                btnSaveCat.Enabled = False
                btnClearText.Enabled = False
                btnCancel.Enabled = False
                txtIDCat.Enabled = False
                txtDesCatTH.Enabled = False
                txtDesCatEN.Enabled = False
            ElseIf TreeView1.SelectedNode.Level = "1" Then
                btnEditCat.Visible = True
                btnDelCat.Visible = True
                
                    btnAddCat.Visible = True
                    btnOnTBOpen.Show()
                    btnOnTBOff.Show()
                    Label3.Show()

                '  MsgBox(TreeView1.SelectedNode.SelectedImageKey.ToString)
                Dim res1 As MySqlDataReader = con.mysql_query("select * from pos_catprd Where id='" & TreeView1.SelectedNode.SelectedImageKey.ToString & "' ")
                    res1.Read()
                    txtIDCat.Text = res1.GetString("id_cat")
                    txtDesCatTH.Text = res1.GetString("namecat_th")
                    txtDesCatEN.Text = res1.GetString("namecat_en")
                    If res1.GetString("id_status_sales") = "1" Then
                        arr_OnSales = "1"
                        SetOn_Sales()
                    Else
                        arr_OnSales = "0"
                        SetOff_Sales()
                    End If

                    If res1.GetString("id_status_table") = "1" Then
                        arr_OnTb = "1"
                        ' SetOn_TB()
                        NotCountStk()
                    Else
                        arr_OnTb = "0"
                        'SetOff_TB()
                        CountStk()
                    End If
                    res1.Close()
                    btnAddCat.Text = "Add Sub-Group"
                    Label2.Text = "Number Group"
                    Label9.Text = "Name Group [TH]"
                    Label6.Text = "Name Group [EN]"
                    btnSaveCat.Text = "Save Group"
                    btnSaveCat.Enabled = False
                    btnClearText.Enabled = False
                    btnCancel.Enabled = False
                    txtIDCat.Enabled = False
                    txtDesCatTH.Enabled = False
                    txtDesCatEN.Enabled = False
            ElseIf TreeView1.SelectedNode.Level = "2" Then
                Dim res As MySqlDataReader = con.mysql_query("select * from pos_catsubprd Where id='" & TreeView1.SelectedNode.SelectedImageKey.ToString & "' and id_status_sales<>'2' ")
                res.Read()
                txtIDCat.Text = res.GetString("id_subcat")
                txtDesCatTH.Text = res.GetString("name_th")
                txtDesCatEN.Text = res.GetString("name_en")
                If res.GetString("id_status_sales") = "1" Then
                    arr_OnSales = "1"
                    SetOn_Sales()
                Else
                    arr_OnSales = "0"
                    SetOff_Sales()
                End If

                If res.GetString("id_status_table") = "1" Then
                    arr_OnTb = "1"
                    'SetOn_TB()
                    NotCountStk()
                Else
                    arr_OnTb = "0"
                    'SetOff_TB()
                    CountStk()
                End If
                res.Close()
                btnEditCat.Visible = True
                btnDelCat.Visible = True
                Label2.Text = "Number Sub-Group"
                Label9.Text = "Name Sub-Group [TH]"
                Label6.Text = "Name Sub-Group [EN]"
                btnSaveCat.Text = "Save Sub-Group"
                btnSaveCat.Enabled = False
                btnClearText.Enabled = False
                btnCancel.Enabled = False
                txtIDCat.Enabled = False
                txtDesCatTH.Enabled = False
                txtDesCatEN.Enabled = False
                btnAddCat.Visible = False
                Label3.Hide()
                btnOnTBOpen.Hide()
                btnOnTBOff.Hide()
            End If
        End If
    End Sub

    Private Sub TreeView1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TreeView1.DoubleClick

        If TreeView1.SelectedNode.IsSelected = True Then
            btnCancel.Show()
            If TreeView1.SelectedNode.Level = "1" Then
                Dim strQuery As String = "SELECT * FROM pos_catprd WHERE id='" & TreeView1.SelectedNode.SelectedImageKey.ToString & "'"
                selectEdit(strQuery)
                btnSaveCat.Text = "Edit"
                GroupBox1.Text = "Edit Group"
                btnSaveCat.Enabled = True
                btnClearText.Enabled = True
                btnCancel.Enabled = True
                txtIDCat.Enabled = True
                txtDesCatTH.Enabled = True
                txtDesCatEN.Enabled = True
            ElseIf TreeView1.SelectedNode.Level = "2" Then
                Dim strQuery As String = "SELECT * FROM pos_catsubprd WHERE id='" & TreeView1.SelectedNode.SelectedImageKey.ToString & "'"
                selectSubEdit(strQuery)
                btnSaveCat.Text = "Edit Sub-Group"
                GroupBox1.Text = "Edit Sub-Group"
                btnSaveCat.Enabled = True
                btnClearText.Enabled = True
                btnCancel.Enabled = True
                txtIDCat.Enabled = True
                txtDesCatTH.Enabled = True
                txtDesCatEN.Enabled = True
            End If

        End If
    End Sub

    Private Sub TreeView1_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TreeView1.MouseClick
        If e.Button = MouseButtons.Right Then
            If TreeView1.SelectedNode.Level <> "0" Then
                If TreeView1.SelectedNode.Bounds.Contains(e.Location) = True Then
                    ContextMenuStrip1.Show(Cursor.Position)
                End If
            End If
        End If
    End Sub
    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        Dim result As Integer = MessageBox.Show("Are You Sure Delete " & TreeView1.SelectedNode.Text.ToString & " ?", "Confirm Delete Item?", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            If TreeView1.SelectedNode.Level = "1" Then
                Dim z As Boolean = con.mysql_query("UPDATE pos_product SET id_status_sales='2' WHERE ref__id_catprd ='" & TreeView1.SelectedNode.SelectedImageKey.ToString & "';")
                Dim x As Boolean = con.mysql_query("UPDATE pos_catsubprd SET id_status_sales='2' WHERE ref_id_cat ='" & TreeView1.SelectedNode.SelectedImageKey.ToString & "';")
                Dim y As Boolean = con.mysql_query("UPDATE pos_catprd SET id_status_sales='2' WHERE id ='" & TreeView1.SelectedNode.SelectedImageKey.ToString & "';")
                If x = True And y = True And z = True Then
                    MessageBox.Show("Delete Complete.", "Complete Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    loadDataTreeview() 'Show DATA TreeView1
                Else
                    MessageBox.Show("Error Delete .", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    loadDataTreeview() 'Show DATA TreeView1
                End If
            ElseIf TreeView1.SelectedNode.Level = "2" Then
                Dim x As Boolean = con.mysql_query("UPDATE pos_catsubprd SET id_status_sales='2' WHERE id ='" & TreeView1.SelectedNode.SelectedImageKey.ToString & "'")
                Dim u As Boolean = con.mysql_query("UPDATE pos_product SET id_status_sales='2' WHERE ref__id_catsubprd ='" & TreeView1.SelectedNode.SelectedImageKey.ToString & "';")
                If x = True And u = True Then
                    MessageBox.Show("Delete Complete.", "Complete Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    loadDataTreeview() 'Show DATA TreeView1
                Else
                    MessageBox.Show("Error Delete .", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    loadDataTreeview() 'Show DATA TreeView1
                End If
            End If
            clear_text() 'รีเซ็ตข้อมูลในฟอร์ม
            btnSaveCat.Enabled = False
            btnClearText.Enabled = False
            btnCancel.Enabled = False
            txtIDCat.Enabled = False
            txtDesCatTH.Enabled = False
            txtDesCatEN.Enabled = False
        End If
    End Sub
End Class