Imports MySql.Data.MySqlClient
Imports System
Imports System.IO
Public Class Admin_profile_shop
    Dim ac As New Admin_ClassMain
    Dim con As New Mysql
    Dim IDdata As String = "0"
    Dim name_img As String
    Dim images_user As String
    Dim taype_img As String
    Dim pic_user As String = ""
    Dim pathname As String

    Private Sub Admin_profile_shop_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load 
        loadDataShow() ' ShowData
    End Sub
    Public Sub InsertFiled(ByRef SQLStatement As String, ByVal msgShow As String)
        con.mysql_query(SQLStatement)
        If msgShow <> "" And con.mysql_query(SQLStatement) = True Then
            MsgBox(msgShow)
        End If

    End Sub
    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        cleartForm()
        Me.Close()
    End Sub

    Public Sub cleartForm()
        TXT_Name_show.Text = ""
        TXT_Name_TH.Text = ""
        TXT_Name_EN.Text = ""
        TXT_Address.Text = ""
        TXT_Tambon.Text = ""
        TXT_District.Text = ""
        TXT_Province.Text = ""
        TXT_Postcode.Text = ""
        TXT_Tel1.Text = ""
        TXT_Tel2.Text = ""
        TXT_Taxid.Text = ""
        TXT_Fax.Text = ""
        TXT_Vat.Text = ""
        TXT_SerCHG.Text = ""
        RadioButton1.Checked = True
        RadioButton2.Checked = False
    End Sub


    Private Sub btnCleFormPrd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCleFormPrd.Click
        cleartForm()
    End Sub

   
    Private Sub btnAddPrd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddPrd.Click

        'If TXT_Name_TH.Text <> "" And TXT_Name_EN.Text <> "" And TXT_Address.Text <> "" And TXT_Tambon.Text <> "" And TXT_District.Text <> "" Then

        Dim VatStatus As String = "0"
        If RadioButton1.Checked = True Then
            VatStatus = "1"
        Else
            VatStatus = "0"
        End If


        If IDdata = "1" Then
          

            Dim pic_user As String = ""
            Dim prm_nameIMG As String = ""

            If name_img <> "" Then
                Dim time As DateTime = DateTime.Now
                pic_user = Login.TextBox_Username.Text & time.Millisecond & taype_img
                If images_user <> "" Then
                    File.Delete("avatar\" & images_user) 'delete images old
                    File.Copy(pathname, "avatar\" & pic_user)
                    prm_nameIMG = " ,images='" & pic_user & "'" 'set update data on table pos_user
                Else
                    File.Copy(pathname, "avatar\" & pic_user)
                    prm_nameIMG = " ,images='" & pic_user & "'" 'set update data on table pos_user
                End If
            Else
                prm_nameIMG = ""
            End If


            Dim SqlString As String = "UPDATE pos_shop SET name_onfront='" & TXT_Name_show.Text & "',name_th='" & TXT_Name_TH.Text & "',name_en='" & TXT_Name_EN.Text & "'," _
                & "Adress='" & TXT_Address.Text & "',Tambon='" & TXT_Tambon.Text & "',District='" & TXT_District.Text & "',Province='" & TXT_Province.Text & "'," _
                & "Postcode='" & TXT_Postcode.Text & "',Telephone_1='" & TXT_Tel1.Text & "',Telephone_2='" & TXT_Tel2.Text & "',Fax='" & TXT_Fax.Text & "'," _
                & "TAX_ID='" & TXT_Taxid.Text & "',vat='" & TXT_Vat.Text & "',vat_status='" & VatStatus & "',service_chg='" & TXT_SerCHG.Text & "'" & prm_nameIMG & ",update_by='ADMIN'"
            InsertFiled(SqlString, "Update Complete")

        Else
            If name_img <> "" Then
                Dim time As DateTime = DateTime.Now
                pic_user = Login.TextBox_Username.Text & time.Millisecond & taype_img
                System.IO.File.Copy(pathname, "avatar\" & pic_user)
            End If
            Dim SqlString As String = "INSERT INTO pos_shop (name_onfront,name_th,name_en,Adress," _
              & "Tambon,District,Province,Postcode,Telephone_1,Telephone_2,Fax,TAX_ID,vat,vat_status,service_chg,images,create_by,create_date)" _
            & " VALUES('" & TXT_Name_show.Text & "','" & TXT_Name_TH.Text & "','" & TXT_Name_EN.Text & "','" & TXT_Address.Text & "'," _
            & " '" & TXT_Tambon.Text & "','" & TXT_District.Text & "','" & TXT_Province.Text & "','" & TXT_Postcode.Text & "'," _
            & " '" & TXT_Tel1.Text & "','" & TXT_Tel2.Text & "','" & TXT_Fax.Text & "','" & TXT_Taxid.Text & "','" & TXT_Vat.Text & "','" & VatStatus & "'," _
            & " '" & TXT_SerCHG.Text & "','" & pic_user & "','ADMIN','" & ac.dateFormat(Date.Now) & "')"
            InsertFiled(SqlString, "SAVE Complete")
        End If
        '  Else
        ' MsgBox("Please input data")
        'End If
    End Sub
    Public Sub loadDataShow()
        Dim reader As MySqlDataReader = con.mysql_query("SELECT * FROM pos_shop")
        While reader.Read()
            If reader.GetString("id") > 0 Then
                IDdata = "1"
                TXT_Name_show.Text = reader.GetString("name_onfront")
                TXT_Name_TH.Text = reader.GetString("name_th")
                TXT_Name_EN.Text = reader.GetString("name_en")
                TXT_Address.Text = reader.GetString("Adress")
                TXT_Tambon.Text = reader.GetString("Tambon")
                TXT_District.Text = reader.GetString("District")
                TXT_Province.Text = reader.GetString("Province")
                TXT_Postcode.Text = reader.GetString("Postcode")
                TXT_Tel1.Text = reader.GetString("Telephone_1")
                TXT_Tel2.Text = reader.GetString("Telephone_2")
                TXT_Fax.Text = reader.GetString("Fax")
                TXT_Taxid.Text = reader.GetString("TAX_ID")
                TXT_Vat.Text = reader.GetString("vat")
                TXT_SerCHG.Text = reader.GetString("service_chg")

                images_user = reader.GetString("images")
                If reader.GetString("images") <> "" Then
                    PictureBox1.ImageLocation = "avatar\" & reader.GetString("images")
                    'Using fs As New System.IO.FileStream("avatar\" & reader.GetString("images"), IO.FileMode.Open, IO.FileAccess.Read)
                    'PictureBox1.Image = System.Drawing.Image.FromStream(fs)
                    'End Using
                End If


                If reader.GetString("vat_status") = "1" Then
                    RadioButton1.Checked = True
                    RadioButton2.Checked = False
                Else
                    RadioButton1.Checked = False
                    RadioButton2.Checked = True
                End If
            Else
                IDdata = "0"
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
End Class