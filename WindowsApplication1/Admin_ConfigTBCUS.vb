Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Text
Imports System
Public Class Admin_ConfigTBCUS
    Dim con As New Mysql
    Dim rc As ResizeableControl
    Dim conn As New Mysql
    Dim res As MySqlDataReader
    Dim res2 As MySqlDataReader
    Dim OpenFileDialog As New OpenFileDialog
    Dim ct As Integer = 1
    Dim tt As Integer = 1
    Dim c(3) As String
    Dim cN(3) As String
    Public roomArr As New List(Of String)()
    Private Sub Admin_ConfigTBCUS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadFloor()
    End Sub
    Private Sub manageTB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles manageTB.Click
        planManageRoom.fl = TabControl_Locat.SelectedTab.Name
        planManageRoom.ShowDialog()
    End Sub
    Public Sub load_layout(ByVal id_floor As Integer)
        TabControl_Locat.SelectedTab.Controls.Clear()
        res2 = conn.mysql_query("SELECT *,pos_table_system.number as number,pos_table_system.id as idtb,IFNULL(pos_status_table.st_color,'0,0,0') as st_color,pos_table_system.status as statustb  FROM pos_table_layout LEFT JOIN pos_table_system ON pos_table_system.id=pos_table_layout.room_no LEFT JOIN pos_status_table ON pos_status_table.id = pos_table_system.status WHERE floor='" & id_floor & "'")
        While res2.Read
            If res2.GetString("type") = "Label" Then
                Dim lbl As New Label
                lbl.Name = res2.GetString("name")
                lbl.Text = res2.GetString("text")
                c = res2.GetString("color").Split(",")
                lbl.ForeColor = Color.FromArgb(255, c(0), c(1), c(2))
                If res2.GetString("font_bold") = "True" And res2.GetString("font_italic") = "False" Then
                    lbl.Font = New Font(res2.GetString("font_famiry"), CByte(res2.GetString("font_size")), FontStyle.Bold)
                ElseIf res2.GetString("font_bold") = "False" And res2.GetString("font_italic") = "True" Then
                    lbl.Font = New Font(res2.GetString("font_famiry"), CByte(res2.GetString("font_size")), FontStyle.Italic)
                ElseIf res2.GetString("font_bold") = "True" And res2.GetString("font_italic") = "True" Then
                    lbl.Font = New Font(res2.GetString("font_famiry"), CByte(res2.GetString("font_size")), FontStyle.Italic Or FontStyle.Bold)
                ElseIf res2.GetString("font_bold") = "False" And res2.GetString("font_italic") = "False" Then
                    lbl.Font = New Font(res2.GetString("font_famiry"), CByte(res2.GetString("font_size")), FontStyle.Regular)
                End If
                lbl.Top = res2.GetInt32("y")
                lbl.Left = res2.GetInt32("x")
                lbl.Width = res2.GetInt32("w")
                lbl.Height = res2.GetInt32("h")
                lbl.ContextMenuStrip = DeletePIC
                TabControl_Locat.SelectedTab.Controls.Add(lbl)
                AddHandler lbl.DoubleClick, AddressOf lbl_DoubleClick
                rc = New ResizeableControl(TabControl_Locat.SelectedTab, lbl)
                tt += 1
            ElseIf res2.GetString("type") = "Button" Then
                Dim btn As New Button
                btn.Text = res2.GetString("number")
                roomArr.Add(res2.GetString("room_no"))
                btn.Name = res2.GetString("room_no")
                btn.Width = res2.GetInt32("w")
                btn.Height = res2.GetInt32("h")
                btn.FlatStyle = FlatStyle.Flat
                btn.Top = res2.GetInt32("y")
                btn.Left = res2.GetInt32("x")
                If res2.GetString("statustb") = "1" Then
                    cN = res2.GetString("st_color").Split(",")
                    btn.BackColor = Color.FromArgb(255, cN(0), cN(1), cN(2))
                ElseIf res2.GetString("statustb") = "2" Then
                    cN = res2.GetString("st_color").Split(",")
                    btn.BackColor = Color.FromArgb(255, cN(0), cN(1), cN(2))
                ElseIf res2.GetString("statustb") = "3" Then
                    cN = res2.GetString("st_color").Split(",")
                    btn.BackColor = Color.FromArgb(255, cN(0), cN(1), cN(2))
                End If
                btn.ContextMenuStrip = DeleteBTN
                TabControl_Locat.SelectedTab.Controls.Add(btn)
                c = res2.GetString("color").Split(",")
                btn.ForeColor = Color.FromArgb(255, c(0), c(1), c(2))
                If res2.GetString("font_bold") = "True" And res2.GetString("font_italic") = "False" Then
                    btn.Font = New Font(res2.GetString("font_famiry"), CByte(res2.GetString("font_size")), FontStyle.Bold)
                ElseIf res2.GetString("font_bold") = "False" And res2.GetString("font_italic") = "True" Then
                    btn.Font = New Font(res2.GetString("font_famiry"), CByte(res2.GetString("font_size")), FontStyle.Italic)
                ElseIf res2.GetString("font_bold") = "True" And res2.GetString("font_italic") = "True" Then
                    btn.Font = New Font(res2.GetString("font_famiry"), CByte(res2.GetString("font_size")), FontStyle.Italic Or FontStyle.Bold)
                ElseIf res2.GetString("font_bold") = "False" And res2.GetString("font_italic") = "False" Then
                    btn.Font = New Font(res2.GetString("font_famiry"), CByte(res2.GetString("font_size")), FontStyle.Regular)
                End If
                rc = New ResizeableControl(TabControl_Locat.SelectedTab, btn)
            ElseIf res2.GetString("type") = "PictureBox" Then
                'GET FOLDER IMG
                Dim objReader As New System.IO.StreamReader("active_fol.bat", Encoding.UTF8)
                Dim TextLine() As String
                Dim fulltextIMG As String = ""

                Do While objReader.Peek() <> -1
                    TextLine = objReader.ReadLine().ToString.Trim.Split("=")
                    If TextLine(0).ToString.Trim = "folderSystem" Then
                        fulltextIMG &= TextLine(1).ToString.Trim
                    End If
                Loop
               
                Dim pic As New PictureBox
                pic.ImageLocation = fulltextIMG & res2.GetString("name")
                pic.Name = "pic" & ct
                ct += 1
                pic.Width = res2.GetString("w")
                pic.Height = res2.GetString("h")
                pic.SizeMode = PictureBoxSizeMode.StretchImage
                pic.Left = 10
                pic.Top = 10
                pic.Top = res2.GetInt32("y")
                pic.Left = res2.GetInt32("x")
                pic.ContextMenuStrip = DeletePIC
                TabControl_Locat.SelectedTab.Controls.Add(pic)
                rc = New ResizeableControl(TabControl_Locat.SelectedTab, pic)
            End If
        End While

    End Sub
    Public Sub loadFloor()
        Try
            TabControl_Locat.TabPages.Clear()
            ct = 1
            tt = 1
            res = conn.mysql_query("SELECT * FROM pos_table_location WHERE name_en<>'All' ORDER BY id ASC,name_th ASC")
            Dim num_res As Integer = conn.mysql_num_rows(conn.mysql_query("SELECT * FROM pos_table_location WHERE name_en<>'All' ORDER BY id ASC,name_th ASC"))
            If num_res > 0 Then
                manageTB.Enabled = True
                addText.Enabled = True
                addPicture.Enabled = True
                btnSaveLayout.Enabled = True
                Dim i As Integer = 0
                While res.Read
                    Dim newTab As New TabPage()
                    If res.GetString("name_th") <> "" Then
                        newTab.Text = res.GetString("name_th")
                    Else
                        newTab.Text = res.GetString("name_en")
                    End If
                    newTab.ToolTipText = res.GetString("description")
                    newTab.Name = res.GetString("id")
                    newTab.Tag = i
                    newTab.BackColor = Color.White
                    TabControl_Locat.TabPages.Add(newTab)
                    TabControl_Locat.SelectedIndex = i
                    load_layout(res.GetString("id"))
                    i += 1

                End While
            Else
                manageTB.Enabled = False
                addText.Enabled = False
                addPicture.Enabled = False
                btnSaveLayout.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
        Admin_ConfigTBCUS_Detail.ShowDialog()
    End Sub

    Private Sub TabPage3_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
        ShowDialog()
    End Sub

    Public Sub addRoom(ByVal btnTxt As String, ByVal id As Integer)
        Dim btn As New Button
        btn.Text = btnTxt
        btn.Name = id
        btn.Width = 120
        btn.Height = 66
        btn.ContextMenuStrip = DeleteBTN
        TabControl_Locat.SelectedTab.Controls.Add(btn)
        btn.BringToFront()
        rc = New ResizeableControl(TabControl_Locat.SelectedTab, btn)
    End Sub

    Public Sub delRoom(ByVal btnTxt As String)
        TabControl_Locat.SelectedTab.Controls.RemoveByKey(btnTxt)
    End Sub

    Private Sub addPicture_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles addPicture.Click
        addPic("pic" & ct)
        ct += 1
    End Sub

    Public Sub addPic(ByVal picName As String)
        Dim pic As New PictureBox
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
        OpenFileDialog.Filter = "(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.JPEG;*.GIF;*.PNG"
        OpenFileDialog.FileName = ""
        OpenFileDialog.Multiselect = False
        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            pic.ImageLocation = OpenFileDialog.FileName
            pic.Name = picName
            If New Bitmap(OpenFileDialog.FileName).Width > TabControl_Locat.SelectedTab.Width Then
                pic.Width = TabControl_Locat.SelectedTab.Width - 20
            Else
                pic.Width = New Bitmap(OpenFileDialog.FileName).Width
            End If
            If New Bitmap(OpenFileDialog.FileName).Height > TabControl_Locat.SelectedTab.Height Then
                pic.Height = TabControl_Locat.SelectedTab.Height - 20
            Else
                pic.Height = New Bitmap(OpenFileDialog.FileName).Height
            End If
            pic.SizeMode = PictureBoxSizeMode.StretchImage
            pic.Left = 10
            pic.Top = 10
            pic.ContextMenuStrip = DeletePIC
            TabControl_Locat.SelectedTab.Controls.Add(pic)
            rc = New ResizeableControl(TabControl_Locat.SelectedTab, pic)
        End If
    End Sub

    Private Sub addText_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles addText.Click
        plan_add_text.name1 = ""
        plan_add_text.text1 = ""
        plan_add_text.ShowDialog()
    End Sub

    Public Sub addLbl(ByVal txt As String, ByVal name As String, ByVal color As Color, ByVal font As Font)
        If name <> "" Then
            TabControl_Locat.SelectedTab.Controls.Item(name).Text = txt
            TabControl_Locat.SelectedTab.Controls.Item(name).ForeColor = color
            TabControl_Locat.SelectedTab.Controls.Item(name).Font = font
        Else
            Dim lbl As New Label
            lbl.Name = "lbl" & tt
            lbl.Text = txt
            lbl.ForeColor = color
            lbl.Font = font
            lbl.ContextMenuStrip = DeletePIC
            TabControl_Locat.SelectedTab.Controls.Add(lbl)
            AddHandler lbl.DoubleClick, AddressOf lbl_DoubleClick
            rc = New ResizeableControl(TabControl_Locat.SelectedTab, lbl)
            tt += 1
        End If
    End Sub

    Private Sub lbl_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim lbl As Label = sender
        plan_add_text.text1 = lbl.Text
        plan_add_text.name1 = lbl.Name
        plan_add_text.font1 = lbl.Font
        plan_add_text.color = lbl.ForeColor
        plan_add_text.ShowDialog()
    End Sub

    Private Sub PicDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicDel.Click
        Dim myItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        Dim cms As ContextMenuStrip = CType(myItem.Owner, ContextMenuStrip)

        TabControl_Locat.SelectedTab.Controls.RemoveByKey(cms.SourceControl.Name)
    End Sub

    Private Sub DelBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DelBtn.Click
        Dim myItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        Dim cms As ContextMenuStrip = CType(myItem.Owner, ContextMenuStrip)

        For j As Integer = 0 To roomArr.Count - 1
            If cms.SourceControl.Name = roomArr(j) Then
                roomArr(j) = ""
                TabControl_Locat.SelectedTab.Controls.RemoveByKey(cms.SourceControl.Name)
            End If
        Next
    End Sub
    Private Sub btnSaveLayout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveLayout.Click
        'Try
        conn.mysql_query("DELETE FROM pos_table_layout")
        Dim str As String = ""
        Dim name As String = ""
        Dim text As String = ""
        Dim floor As String = ""
        Dim room_no As String = ""
        Dim type As String = ""
        Dim x As String = ""
        Dim y As String = ""
        Dim w As String = ""
        Dim h As String = ""
        Dim font As String = ""
        Dim font_size As String = ""
        Dim bold As String = ""
        Dim italic As String = ""
        Dim color As String = ""
        Dim ind As Integer = 0
        ind = TabControl_Locat.SelectedIndex
        For i As Integer = 0 To TabControl_Locat.TabPages.Count - 1
            TabControl_Locat.SelectTab(i)
            For j As Integer = 0 To TabControl_Locat.SelectedTab.Controls.Count - 1
                name = TabControl_Locat.SelectedTab.Controls.Item(j).Name.ToString
                floor = TabControl_Locat.SelectedTab.Name.ToString
                type = TabControl_Locat.SelectedTab.Controls.Item(j).GetType.Name.ToString
                x = TabControl_Locat.SelectedTab.Controls.Item(j).Left.ToString
                y = TabControl_Locat.SelectedTab.Controls.Item(j).Top.ToString
                w = TabControl_Locat.SelectedTab.Controls.Item(j).Width.ToString
                h = TabControl_Locat.SelectedTab.Controls.Item(j).Height.ToString
                If type = "Button" Then
                    font = TabControl_Locat.SelectedTab.Controls.Item(j).Font.FontFamily.Name.ToString
                    font_size = TabControl_Locat.SelectedTab.Controls.Item(j).Font.Size.ToString
                    bold = TabControl_Locat.SelectedTab.Controls.Item(j).Font.Bold.ToString
                    italic = TabControl_Locat.SelectedTab.Controls.Item(j).Font.Italic.ToString
                    color = TabControl_Locat.SelectedTab.Controls.Item(j).ForeColor.R.ToString & "," & TabControl_Locat.SelectedTab.Controls.Item(j).ForeColor.G.ToString & "," & TabControl_Locat.SelectedTab.Controls.Item(j).ForeColor.B.ToString
                    str &= "INSERT INTO pos_table_layout(name,text,floor,room_no,type,x,y,w,h,font_famiry,font_size,font_bold,font_italic,color)" _
                            & "VALUES('" & name & "','','" & floor & "','" & name & "','" & type & "','" & x & "','" & y & "','" & w & "','" & h & "','" & font & "','" & font_size & "','" & bold & "','" & italic & "','" & color & "');"
                ElseIf type = "PictureBox" Then
                    'GET FOLDER IMG
                    Dim objReader As New System.IO.StreamReader("active_fol.bat", Encoding.UTF8)
                    Dim TextLine() As String
                    Dim fulltextIMG As String = ""

                    Do While objReader.Peek() <> -1
                        TextLine = objReader.ReadLine().ToString.Trim.Split("=")
                        If TextLine(0).ToString.Trim = "folderSystem" Then
                            fulltextIMG &= TextLine(1).ToString.Trim
                        End If
                    Loop

                    Dim img As PictureBox
                    img = TabControl_Locat.SelectedTab.Controls.Item(j)
                    name = j & Path.GetExtension(img.ImageLocation)
                    Try
                        System.IO.File.Copy(img.ImageLocation, fulltextIMG & name, True)
                    Catch ex As Exception

                    End Try
                    str &= "INSERT INTO pos_table_layout(name,text,floor,room_no,type,x,y,w,h,font_famiry,font_size,font_bold,font_italic,color)" _
                            & "VALUES('" & name & "','','" & floor & "','','" & type & "','" & x & "','" & y & "','" & w & "','" & h & "','','','','','');"
                ElseIf type = "Label" Then
                    text = TabControl_Locat.SelectedTab.Controls.Item(j).Text.ToString
                    font = TabControl_Locat.SelectedTab.Controls.Item(j).Font.FontFamily.Name.ToString
                    font_size = TabControl_Locat.SelectedTab.Controls.Item(j).Font.Size.ToString
                    bold = TabControl_Locat.SelectedTab.Controls.Item(j).Font.Bold.ToString
                    italic = TabControl_Locat.SelectedTab.Controls.Item(j).Font.Italic.ToString
                    color = TabControl_Locat.SelectedTab.Controls.Item(j).ForeColor.R.ToString & "," & TabControl_Locat.SelectedTab.Controls.Item(j).ForeColor.G.ToString & "," & TabControl_Locat.SelectedTab.Controls.Item(j).ForeColor.B.ToString

                    str &= "INSERT INTO pos_table_layout(name,text,floor,room_no,type,x,y,w,h,font_famiry,font_size,font_bold,font_italic,color)" _
                            & "VALUES('" & name & "','" & text & "','" & floor & "','','" & type & "','" & x & "','" & y & "','" & w & "','" & h & "','" & font & "','" & font_size & "','" & bold & "','" & italic & "','" & color & "');"
                End If
            Next
        Next
        If conn.mysql_query(str) = True Then
            MessageBox.Show("Save Layout Table Complete.", "Message Alert", MessageBoxButtons.OK, MessageBoxIcon.Information)
            loadFloor()
            TabControl_Locat.SelectTab(ind)
        Else
            MessageBox.Show("Error Query Insert Table Layout.!", "Message Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        '   MsgBox(TabControl_Locat.SelectedTab.Tag)

        ' TabControl_Locat.SelectTab(TabControl_Locat.SelectedTab.Tag)
        'Catch ex As Exception
        '   MessageBox.Show(ex.Message & " -----")

        'End Try
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        Me.Close()
    End Sub
   
    Private Sub FontSettingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FontSettingToolStripMenuItem.Click
        Dim myItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        Dim cms As ContextMenuStrip = CType(myItem.Owner, ContextMenuStrip)
        For j As Integer = 0 To roomArr.Count - 1
            If cms.SourceControl.Name = roomArr(j) Then
                If FontDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
                    cms.SourceControl.Font = FontDialog1.Font
                End If
            End If
        Next
    End Sub
    Private Sub ColorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ColorToolStripMenuItem.Click
        Dim myItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        Dim cms As ContextMenuStrip = CType(myItem.Owner, ContextMenuStrip)
        Dim old_color As Color
        For j As Integer = 0 To roomArr.Count - 1
            If cms.SourceControl.Name = roomArr(j) Then
                Dim cDialog As New ColorDialog()
                cDialog.Color = cms.SourceControl.ForeColor
                old_color = cms.SourceControl.ForeColor
                If (cDialog.ShowDialog() = DialogResult.OK) Then
                    cms.SourceControl.ForeColor = cDialog.Color
                Else
                    cms.SourceControl.ForeColor = old_color
                End If
            End If
        Next
    End Sub
End Class