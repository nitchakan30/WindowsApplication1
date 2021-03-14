Imports MySql.Data.MySqlClient
Public Class Admin_ConfigUnitPrd
    Dim ac As New Admin_ClassMain
    Dim con As New Mysql
    Dim ID_edit As String
    Private Sub Admin_ConfigUnitPrd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            loadDATA()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub loadDATA()
        ListView1.Items.Clear() 'clear Data
        Dim itmx As New ListViewItem
        Dim reader As MySqlDataReader = con.mysql_query("SELECT * FROM pos_product_unit ORDER BY id ASC")
        Dim x As Integer = 0
        Dim i As Integer = 0
        While reader.Read()
            i += 1
            itmx = ListView1.Items.Add(reader.GetString("id"), CInt(reader.GetString("id")))
            itmx.SubItems.Add(i.ToString)
            itmx.SubItems.Add(reader.GetString("code_unit"))
            itmx.SubItems.Add(reader.GetString("name_th"))
            itmx.SubItems.Add(reader.GetString("name_en"))
           
            x += 1
        End While
        reader.Close()

    End Sub
    Public Sub InsertFiled(ByRef SQLStatement As String, ByVal msgShow As String)
        Dim query As Boolean = con.mysql_query(SQLStatement)
        If msgShow <> "" And query = True Then
            MsgBox(msgShow)
        End If

    End Sub
    Public Sub clearForm()
        txt_code.Text = ""
        txt_name_en.Text = ""
        txt_name_th.Text = ""
        txt_code.ReadOnly = False
        txt_code.Enabled = True
        btn_edit.Enabled = False
        btn_del.Enabled = False
        btn_save.Text = "Save"
    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub btn_add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_add.Click
        clearForm()
    End Sub

    Private Sub btn_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_save.Click
        If txt_code.Text <> "" And (txt_name_en.Text <> "" Or txt_name_th.Text <> "") Then
            If btn_save.Text = "Update" Then
                Dim SqlStringUpdate = "UPDATE pos_product_unit SET code_unit='" & txt_code.Text & "',name_th='" & txt_name_th.Text & "',name_en='" & txt_name_en.Text & "',update_by='ADMIN' WHERE id='" & ListView1.Items(ListView1.SelectedIndices(0)).SubItems(0).Text & "'"
                InsertFiled(SqlStringUpdate, "Update Complete.")
                btn_save.Text = "Save"
                clearForm()
                loadDATA()
            Else
                Dim SqlString As String = "INSERT INTO pos_product_unit (code_unit,name_th,name_en,create_date,create_by)" _
                & "VALUES('" & txt_code.Text & "','" & txt_name_th.Text & "','" & txt_name_en.Text & "','" & ac.dateFormat(Date.Now) & "','ADMIN')"
                InsertFiled(SqlString, "Save Unit Complete.")
                clearForm()
                loadDATA()
            End If
        Else
            If txt_code.Text = "" Then
                MsgBox("Please input  code")
                txt_code.Focus()
            ElseIf txt_name_th.Text = "" Then
                MsgBox("Please input name thai")
                txt_name_th.Focus()
            ElseIf txt_name_en.Text = "" Then
                MsgBox("Please input name english")
                txt_name_en.Focus()
            End If
        End If
    End Sub

    Private Sub btn_edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_edit.Click
        Dim reader As MySqlDataReader = con.mysql_query("SELECT * FROM pos_product_unit WHERE id='" & ListView1.Items(ListView1.SelectedIndices(0)).SubItems(0).Text & "'")
        While reader.Read()
            txt_code.Text = reader.GetString("code_unit")
            txt_name_en.Text = reader.GetString("name_en")
            txt_name_th.Text = reader.GetString("name_th")
        End While
        reader.Close()
        btn_save.Text = "Update"
    End Sub

    Private Sub btn_del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_del.Click
        If ListView1.Items.Count() > 0 Then
            If ListView1.SelectedItems.Count() > 0 Then
                Dim Des As String = ListView1.Items(ListView1.FocusedItem.Index).SubItems(2).Text

                Dim result As Integer = MessageBox.Show("Are You Sure Delete " & Des & " ?", "Confirm Delete Unit Product", MessageBoxButtons.YesNo)
                If result = DialogResult.No Then

                ElseIf result = DialogResult.Yes Then
                    btn_save.Text = "Save"
                    clearForm()
                    Dim SQLDel As String = "DELETE FROM pos_product_unit WHERE id='" & ListView1.Items(ListView1.SelectedIndices(0)).SubItems(0).Text & "'"
                    InsertFiled(SQLDel, "Delete Complete")
                    loadDATA()
                End If
            Else
                MsgBox("Please selected item.")
            End If
        Else
            MsgBox("Data is null !")
        End If
    End Sub

    Public Sub setID()
        Dim code_unit As String = ListView1.Items(ListView1.FocusedItem.Index).SubItems(1).Text

        Dim reader As MySqlDataReader = con.mysql_query("SELECT * FROM pos_product_unit WHERE code_unit='" & code_unit & "'")
        While reader.Read()
            ID_edit = reader.GetString("id")
        End While
        reader.Close()

    End Sub

    Private Sub btn_autoID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_autoID.Click
        txt_code.ReadOnly = True
        txt_code.Enabled = False
        Dim substring As Integer
        Dim reader As MySqlDataReader = con.mysql_query("SELECT code_unit FROM pos_product_unit where code_unit like 'UN%' order by code_unit  desc limit 1 ")
        While reader.Read()
            If reader.GetString("code_unit") <> "" Then
                substring = reader.GetString("code_unit").Substring(2).ToString
            Else
                substring = 0
            End If

        End While
        Dim Str As String
        Dim v As Integer = (substring + 1)
        If v < 10 Then
            Str = "UN000" & v
        ElseIf v > 9 And v < 99 Then
            Str = "UN00" & v
        ElseIf v > 99 And v < 1000 Then
            Str = "UN0" & v
        Else
            Str = "UN" & v
        End If

        txt_code.Text = Str
        reader.Close()
    End Sub

    Private Sub btn_cancle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancle.Click
        clearForm()
        ID_edit = ""
    End Sub

    Private Sub ListView1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick
        btn_edit.Enabled = True
        btn_del.Enabled = True
        Dim reader As MySqlDataReader = con.mysql_query("SELECT * FROM pos_product_unit WHERE id='" & ListView1.Items(ListView1.SelectedIndices(0)).SubItems(0).Text & "'")
        While reader.Read()
            txt_code.Text = reader.GetString("code_unit")
            txt_name_en.Text = reader.GetString("name_en")
            txt_name_th.Text = reader.GetString("name_th")
        End While
        reader.Close()
        btn_save.Text = "Update"
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