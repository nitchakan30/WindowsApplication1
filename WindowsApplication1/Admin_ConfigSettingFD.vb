Imports MySql.Data.MySqlClient
Public Class Admin_ConfigSettingFD
    Dim ac As New Admin_ClassMain
    Dim con As New Mysql
    Dim ID_edit As String
    Dim ID_edit_size As String
    Private Sub Admin_ConfigSettingFD_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            loadDATA() 'แสดงข้อมูล
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub loadDATA()
        ListView_Ingre.Items.Clear() 'clear Data
        Dim itmx As New ListViewItem
        Dim reader As MySqlDataReader = con.mysql_query("SELECT * FROM pos_product_ingredients ORDER BY id ASC")
        Dim x As Integer = 0
        Dim i As Integer = 0
        While reader.Read()
            i += 1
            itmx = ListView_Ingre.Items.Add(reader.GetString("id"), CInt(reader.GetString("id")))
            itmx.SubItems.Add(i.ToString)
            itmx.SubItems.Add(reader.GetString("code_ingre"))
            itmx.SubItems.Add(reader.GetString("name_th"))
            itmx.SubItems.Add(reader.GetString("name_en"))

            x += 1
        End While
        reader.Close()

    End Sub
    Public Sub loadDATA_Size()
        ListView_size.Items.Clear() 'clear Data
        Dim itmx As New ListViewItem
        Dim reader As MySqlDataReader = con.mysql_query("SELECT * FROM pos_product_size ORDER BY id ASC")
        Dim x As Integer = 0
        Dim i As Integer = 0
        While reader.Read()
            i += 1
            itmx = ListView_size.Items.Add(reader.GetString("id"), CInt(reader.GetString("id")))
            itmx.SubItems.Add(i.ToString)
            itmx.SubItems.Add(reader.GetString("code_size"))
            itmx.SubItems.Add(reader.GetString("name_th"))
            itmx.SubItems.Add(reader.GetString("name_en"))

            x += 1
        End While
        reader.Close()
    End Sub
    Public Sub InsertFiled(ByRef SQLStatement As String, ByVal msgShow As String)
        Dim b As Boolean = con.mysql_query(SQLStatement)
        If msgShow <> "" And b = True Then
            MsgBox(msgShow)
        End If

    End Sub
    Public Sub clearForm()
        txt_code_ingre.Text = ""
        txt_nameEN_ingre.Text = ""
        txt_nameTH_ingre.Text = ""
        txt_code_ingre.ReadOnly = False
        txt_code_ingre.Enabled = True
        btn_save_ingre.Text = "Save"
        btn_auto_Id_Ingre.Enabled = True

        btn_edit_ingre.Enabled = False
        btn_del_ingre.Enabled = False
    End Sub
    Public Sub clearForm_Size()
        txt_code_size.Text = ""
        txt_nameEN_size.Text = ""
        txt_nameTH_size.Text = ""
        txt_code_size.ReadOnly = False
        txt_code_size.Enabled = True
        btn_save_size.Text = "Save"
        btn_auto_Id_Size.Enabled = True
        btn_del_size.Enabled = False
        btn_edit_size.Enabled = False
    End Sub
    Private Sub btn_auto_Id_Ingre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_auto_Id_Ingre.Click
        txt_code_ingre.ReadOnly = True
        txt_code_ingre.Enabled = False
        Dim substring As Integer
        Dim reader As MySqlDataReader = con.mysql_query("SELECT code_ingre FROM pos_product_ingredients where code_ingre like 'IG%' order by code_ingre  desc limit 1  ")
        While reader.Read()

            If reader.GetString("code_ingre") <> "" Then
                substring = reader.GetString("code_ingre").Substring(2)
            Else
                substring = 0
            End If

        End While
        Dim Str As String
        Dim v As Integer = (substring + 1)
        'MsgBox(v)
        If v <= 9 Then
            Str = "IG000" & v
        ElseIf v > 9 And v < 99 Then
            Str = "IG00" & v
        ElseIf v > 99 And v < 1000 Then
            Str = "IG0" & v
        Else
            Str = "IG" & v
        End If
        txt_code_ingre.Text = Str
    End Sub
    Private Sub btn_auto_Id_Size_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_auto_Id_Size.Click
        txt_code_size.ReadOnly = True
        txt_code_size.Enabled = False
        Dim substring As Integer
        Dim reader As MySqlDataReader = con.mysql_query("SELECT code_size FROM pos_product_size where code_size like 'SZ%' order by code_size  desc limit 1  ")
        While reader.Read()

            If reader.GetString("code_size") <> "" Then
                substring = reader.GetString("code_size").Substring(2)
            Else
                substring = 0
            End If

        End While
        Dim Str As String
        Dim v As Integer = (substring + 1)
        If v <= 9 Then
            Str = "SZ000" & v
        ElseIf v > 9 And v < 99 Then
            Str = "SZ00" & v
        ElseIf v > 99 And v < 1000 Then
            Str = "SZ0" & v
        Else
            Str = "SZ" & v
        End If
        txt_code_size.Text = Str
    End Sub

    Private Sub btn_save_ingre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_save_ingre.Click
        If txt_code_ingre.Text <> "" And (txt_nameEN_ingre.Text <> "" Or txt_nameTH_ingre.Text <> "") Then
            If btn_save_ingre.Text = "Update" Then
                Dim SqlStringUpdate = "UPDATE pos_product_ingredients SET code_ingre='" & txt_code_ingre.Text & "',name_th='" & txt_nameTH_ingre.Text & "',name_en='" & txt_nameEN_ingre.Text & "',update_by='ADMIN' WHERE id='" & ListView_Ingre.Items(ListView_Ingre.SelectedIndices(0)).SubItems(0).Text & "'"
                InsertFiled(SqlStringUpdate, "Update ingredients food complete.")
                btn_save_ingre.Text = "Save"
                clearForm()
                loadDATA()
            Else
                Dim SqlString As String = "INSERT INTO pos_product_ingredients (code_ingre,name_th,name_en,create_date,create_by)" _
                & "VALUES('" & txt_code_ingre.Text & "','" & txt_nameTH_ingre.Text & "','" & txt_nameEN_ingre.Text & "','" & ac.dateFormat(Date.Now) & "','ADMIN')"
                InsertFiled(SqlString, "Save ingredients food complete.")
                clearForm()
                loadDATA()
            End If
        Else
            If txt_code_ingre.Text = "" Then
                MsgBox("Please input code")
                txt_code_ingre.Focus()
            ElseIf txt_nameTH_ingre.Text = "" Then
                MsgBox("Please input name ingredients food thai")
                txt_nameTH_ingre.Focus()
            ElseIf txt_nameEN_ingre.Text = "" Then
                MsgBox("Please input name ingredients food english")
                txt_nameEN_ingre.Focus()
            End If


        End If
    End Sub
    Private Sub btn_save_size_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_save_size.Click
        If txt_code_size.Text <> "" And (txt_nameEN_size.Text <> "" Or txt_nameTH_size.Text <> "") Then
            If btn_save_size.Text = "Update" Then
                Dim SqlStringUpdate = "UPDATE pos_product_size SET code_size='" & txt_code_size.Text & "',name_th='" & txt_nameTH_size.Text & "',name_en='" & txt_nameEN_size.Text & "',update_by='ADMIN' WHERE id='" & ListView_size.Items(ListView_size.SelectedIndices(0)).SubItems(0).Text & "'"
                InsertFiled(SqlStringUpdate, "Update size food complete.")
                btn_save_size.Text = "Save"
                clearForm_Size()
                loadDATA_Size()
            Else
                Dim SqlString As String = "INSERT INTO pos_product_size (code_size,name_th,name_en,create_date,create_by)" _
                & "VALUES('" & txt_code_size.Text & "','" & txt_nameTH_size.Text & "','" & txt_nameEN_size.Text & "','" & ac.dateFormat(Date.Now) & "','ADMIN')"
                InsertFiled(SqlString, "Save size food complete.")
                clearForm_Size()
                loadDATA_Size()
            End If
        Else
            If txt_code_size.Text = "" Then
                MsgBox("Please input code")
                txt_code_size.Focus()
            ElseIf txt_nameTH_size.Text = "" Then
                MsgBox("Please input name size food thai")
                txt_nameTH_size.Focus()
            ElseIf txt_nameEN_size.Text = "" Then
                MsgBox("Please input name size food english")
                txt_nameEN_size.Focus()
            End If


        End If
    End Sub

    Private Sub btn_cancle_ingre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancle_ingre.Click
        clearForm()
    End Sub

    Private Sub btn_del_ingre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_del_ingre.Click
        If ListView_Ingre.Items.Count() > 0 Then

            Dim Des As String = ListView_Ingre.Items(ListView_Ingre.FocusedItem.Index).SubItems(2).Text

            Dim result As Integer = MessageBox.Show("Are You Sure Delete " & Des & " ?", "Confirm Delete Ingredients Food", MessageBoxButtons.YesNo)
            If result = DialogResult.No Then

            ElseIf result = DialogResult.Yes Then
                btn_save_ingre.Text = "Save"
                clearForm()
                Dim SQLDel As String = "DELETE FROM pos_product_ingredients WHERE id='" & ListView_Ingre.Items(ListView_Ingre.SelectedIndices(0)).SubItems(0).Text & "'"
                InsertFiled(SQLDel, "Delete ingredients Complete")
                loadDATA()
            End If
        
        Else
        MsgBox("Data is null")
        End If
    End Sub
    Public Sub setID()
        Dim code_ingre As String = ListView_Ingre.Items(ListView_Ingre.FocusedItem.Index).SubItems(1).Text
        Dim reader As MySqlDataReader = con.mysql_query("SELECT * FROM pos_product_ingredients WHERE code_ingre='" & code_ingre & "'")
        While reader.Read()
            ID_edit = reader.GetString("id")
        End While
        reader.Close()

    End Sub

    Private Sub btn_add_ingre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_add_ingre.Click
        clearForm()
        btn_save_ingre.Text = "Save"
        ID_edit = ""
        btn_del_ingre.Enabled = False
        btn_edit_ingre.Enabled = False
    End Sub

    Private Sub btn_edit_ingre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_edit_ingre.Click

        Dim reader As MySqlDataReader = con.mysql_query("SELECT * FROM pos_product_ingredients WHERE id='" & ListView_Ingre.Items(ListView_Ingre.SelectedIndices(0)).SubItems(0).Text & "'")
        While reader.Read()

            txt_code_ingre.Text = reader.GetString("code_ingre")
            txt_nameEN_ingre.Text = reader.GetString("name_en")
            txt_nameTH_ingre.Text = reader.GetString("name_th")
        End While
        txt_code_ingre.Enabled = False
        btn_auto_Id_Ingre.Enabled = False
        reader.Close()
        btn_save_ingre.Text = "Update"
    End Sub

    
    Private Sub btn_cancle_size_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancle_size.Click
        clearForm_Size()
    End Sub

    Private Sub btn_add_size_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_add_size.Click
        clearForm_Size()
    End Sub

    Private Sub TabControl1_Selecting(ByVal sender As Object, ByVal e As TabControlCancelEventArgs) _
     Handles TabControl1.Selecting
        If e.TabPageIndex = "1" Then
            loadDATA_Size()
        Else
            loadDATA() 'แสดงข้อมูล
        End If
    End Sub

    Private Sub btn_edit_size_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_edit_size.Click
        Dim reader As MySqlDataReader = con.mysql_query("SELECT * FROM pos_product_size WHERE id='" & ListView_size.Items(ListView_size.SelectedIndices(0)).SubItems(0).Text & "'")
        While reader.Read()
            txt_code_size.Text = reader.GetString("code_size")
            txt_nameEN_size.Text = reader.GetString("name_en")
            txt_nameTH_size.Text = reader.GetString("name_th")
        End While
        txt_code_size.Enabled = False
        btn_auto_Id_Size.Enabled = False
        reader.Close()
        btn_save_size.Text = "Update"
    End Sub
    Public Sub setID_size()
        Dim code_size As String = ListView_size.Items(ListView_size.FocusedItem.Index).SubItems(1).Text
        Dim reader As MySqlDataReader = con.mysql_query("SELECT * FROM pos_product_size WHERE code_size='" & code_size & "'")
        While reader.Read()
            ID_edit_size = reader.GetString("id")
        End While
    End Sub
    Private Sub btn_del_size_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_del_size.Click
        If ListView_size.Items.Count() > 0 Then
            If ListView_size.SelectedItems.Count() > 0 Then
                Dim Des As String = ListView_size.Items(ListView_size.FocusedItem.Index).SubItems(2).Text

                Dim result As Integer = MessageBox.Show("Are You Sure Delete " & Des & " ?", "Confirm Delete Size Food", MessageBoxButtons.YesNo)
                If result = DialogResult.No Then

                ElseIf result = DialogResult.Yes Then
                    btn_save_size.Text = "Save"
                    clearForm_Size()
                    Dim SQLDel As String = "DELETE FROM pos_product_size WHERE id='" & ListView_size.Items(ListView_size.SelectedIndices(0)).SubItems(0).Text & "'"
                    InsertFiled(SQLDel, "Delete Size Food Complete")
                    loadDATA_Size()
                End If
            Else
                MsgBox("Please selected data")
            End If
        Else
            MsgBox("Data is null")
        End If
    End Sub

    Private Sub ListView_Ingre_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView_Ingre.DoubleClick
        btn_edit_ingre.Enabled = True
        btn_del_ingre.Enabled = True
        Dim reader As MySqlDataReader = con.mysql_query("SELECT * FROM pos_product_ingredients WHERE id='" & ListView_Ingre.Items(ListView_Ingre.SelectedIndices(0)).SubItems(0).Text & "'")
        While reader.Read()

            txt_code_ingre.Text = reader.GetString("code_ingre")
            txt_nameEN_ingre.Text = reader.GetString("name_en")
            txt_nameTH_ingre.Text = reader.GetString("name_th")
        End While
        txt_code_ingre.Enabled = False
        btn_auto_Id_Ingre.Enabled = False
        reader.Close()
        btn_save_ingre.Text = "Update"
    End Sub
    Private Sub ListView_Ingre_ItemSelectionChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) Handles ListView_Ingre.ItemSelectionChanged
        If ListView_Ingre.SelectedIndices.Count = 0 Then
            clearForm()
        Else
            btn_edit_ingre.Enabled = True
            btn_del_ingre.Enabled = True
        End If
    End Sub

    Private Sub ListView_size_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView_size.DoubleClick
        btn_edit_size.Enabled = True
        btn_del_size.Enabled = True
        Dim reader As MySqlDataReader = con.mysql_query("SELECT * FROM pos_product_size WHERE id='" & ListView_size.Items(ListView_size.SelectedIndices(0)).SubItems(0).Text & "'")
        While reader.Read()
            txt_code_size.Text = reader.GetString("code_size")
            txt_nameEN_size.Text = reader.GetString("name_en")
            txt_nameTH_size.Text = reader.GetString("name_th")
        End While
        txt_code_size.Enabled = False
        btn_auto_Id_Size.Enabled = False
        reader.Close()
        btn_save_size.Text = "Update"
    End Sub
    Private Sub ListView_size_ItemSelectionChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) Handles ListView_size.ItemSelectionChanged
        If ListView_size.SelectedIndices.Count = 0 Then
            clearForm_Size()
        Else
            btn_edit_size.Enabled = True
            btn_del_size.Enabled = True
        End If
    End Sub
End Class