Imports MySql.Data.MySqlClient
Imports System
Imports System.IO
Imports System.Text
Public Class user_edit
    Dim con As New Mysql
    Dim images_user As String
    Dim taype_img As String
    Dim pic_user As String = ""
    Dim pathname As String
    Dim name_img As String
    Private Sub user_edit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            loadData()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub loadData()
        Dim res_user As MySqlDataReader = con.mysql_query("select * from pos_user where username='" & Login.username & "' and password='" & Login.password & "'")
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
            End If

        End While

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

    Private Sub btn_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_save.Click
        Try
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

            Dim update As Boolean = con.mysql_query("UPDATE pos_user SET username='" & txt_username.Text & "'," _
            & "password='" & txt_password.Text & "',name='" & txt_name.Text & "',surname='" & txt_surname.Text & "'," _
            & "tel='" & txt_tel.Text & "',email='" & txt_email.Text & "',number_emp='" & txt_numemp.Text & "'," _
            & "update_by='" & Login.username & "'" & prm_nameIMG & " WHERE username='" & Login.username & "' and password='" & Login.password & "'")

        If update = True Then
                MsgBox("Update Data Complete.")
                Me.Close()
        Else
            MsgBox("Error Update User Please Contact Admin.")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btn_cancle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancle.Click
        Me.Close()
    End Sub
End Class