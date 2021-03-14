Imports MySql.Data.MySqlClient
Public Class Admin_ConfigTBColor
    Dim con As New Mysql
    Private Sub Admin_ConfigTBColor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim res_g As MySqlDataReader = con.mysql_query("SELECT * FROM pos_status_table order by id asc")
        While res_g.Read
            Dim c() As String = res_g.GetString("st_color").Split(",")
            If CInt(res_g.GetString("id")) = 1 Then
                Label1.ForeColor = Color.FromArgb(255, c(0), c(1), c(2))
            ElseIf CInt(res_g.GetString("id")) = 2 Then
                lblExample.ForeColor = Color.FromArgb(255, c(0), c(1), c(2))
            Else
                Label2.ForeColor = Color.FromArgb(255, c(0), c(1), c(2))
            End If
            End While
            Dim reg_g_all As MySqlDataReader = con.mysql_query("SELECT all_color,all_font,all_font_size,all_bold,all_italic FROM pos_shop")
            reg_g_all.Read()
            Dim c1() As String = reg_g_all.GetString("all_color").Split(",")
            Label4.ForeColor = Color.FromArgb(255, c1(0), c1(1), c1(2))
            If reg_g_all.GetString("all_bold") = "True" And reg_g_all.GetString("all_italic") = "False" Then
                Label4.Font = New Font(reg_g_all.GetString("all_font"), CByte(reg_g_all.GetString("all_font_size")), FontStyle.Bold)
            ElseIf reg_g_all.GetString("all_bold") = "False" And reg_g_all.GetString("all_italic") = "True" Then
                Label4.Font = New Font(reg_g_all.GetString("all_font"), CByte(reg_g_all.GetString("all_font_size")), FontStyle.Italic)
            ElseIf reg_g_all.GetString("all_bold") = "True" And reg_g_all.GetString("all_italic") = "True" Then
                Label4.Font = New Font(reg_g_all.GetString("all_font"), CByte(reg_g_all.GetString("all_font_size")), FontStyle.Italic Or FontStyle.Bold)
            ElseIf reg_g_all.GetString("all_bold") = "False" And reg_g_all.GetString("all_italic") = "False" Then
                Label4.Font = New Font(reg_g_all.GetString("all_font"), CByte(reg_g_all.GetString("all_font_size")), FontStyle.Regular)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub btn_tbnull_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_tbnull.Click
        Dim cDialog As New ColorDialog()
        cDialog.Color = Label1.ForeColor
        If (cDialog.ShowDialog() = DialogResult.OK) Then
            Label1.ForeColor = cDialog.Color
        End If
    End Sub

    Private Sub btn_tbuse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_tbuse.Click
        Dim cDialog As New ColorDialog()
        cDialog.Color = lblExample.ForeColor
        If (cDialog.ShowDialog() = DialogResult.OK) Then
            lblExample.ForeColor = cDialog.Color
        End If
    End Sub

    Private Sub btn_tbclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_tbclose.Click
        Dim cDialog As New ColorDialog()
        cDialog.Color = Label2.ForeColor
        If (cDialog.ShowDialog() = DialogResult.OK) Then
            Label2.ForeColor = cDialog.Color
        End If
    End Sub

    Private Sub btn_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_save.Click
        Try
            Dim c_close As String = Label2.ForeColor.R.ToString & "," & Label2.ForeColor.G.ToString & "," & Label2.ForeColor.B.ToString
            Dim c_use As String = lblExample.ForeColor.R.ToString & "," & lblExample.ForeColor.G.ToString & "," & lblExample.ForeColor.B.ToString
            Dim c_open As String = Label1.ForeColor.R.ToString & "," & Label1.ForeColor.G.ToString & "," & Label1.ForeColor.B.ToString

            Dim c_all As String = Label4.ForeColor.R.ToString & "," & Label4.ForeColor.G.ToString & "," & Label4.ForeColor.B.ToString
            Dim Font = Label4.Font.FontFamily.Name.ToString
            Dim font_size = Label4.Font.Size.ToString
            Dim bold = Label4.Font.Bold.ToString
            Dim italic = Label4.Font.Italic.ToString
            Dim str As String = ""
            str &= "UPDATE pos_status_table SET st_color='" & c_open & "' WHERE id='1';"
            str &= "UPDATE pos_status_table SET st_color='" & c_use & "' WHERE id='2';"
            str &= "UPDATE pos_status_table SET st_color='" & c_close & "' WHERE id='0';"
            str &= "UPDATE pos_shop SET all_color='" & c_all & "',all_font='" & Font & "',all_font_size='" & font_size & "',all_bold='" & bold & "',all_italic='" & italic & "';"
            If con.mysql_query(str) = True Then
                MessageBox.Show("บันทึกเรียบร้อย", "Message Alert")
            Else
                MessageBox.Show("Error Color Status Save Please Contact Support.", "Message Alert")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btn_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancel.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If FontDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            Label4.Font = FontDialog1.Font
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim cDialog As New ColorDialog()
        cDialog.Color = Label4.ForeColor
        If (cDialog.ShowDialog() = DialogResult.OK) Then
            Label4.ForeColor = cDialog.Color
        End If
    End Sub
End Class