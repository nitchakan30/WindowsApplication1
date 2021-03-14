Imports MySql.Data.MySqlClient
Imports System
Imports System.Security.Cryptography
Imports System.Text

Public Class putLicense
    Dim conn As New Mysql
    Dim res As MySqlDataReader
    Dim d As Date
    Dim s As Boolean = False

    Private Sub putLicense_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        If s = False Then
            login.Close()
        End If
    End Sub

    Private Sub txtLicense1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLicense1.KeyDown
        If e.Modifiers = Keys.Control AndAlso e.KeyCode = Keys.V Then
            Dim key As String = ""
            key = Clipboard.GetText(TextDataFormat.Text).Replace(" ", "")

            Dim rtn As String = ""
            Dim i As Integer = 0
            If key.Length > 0 Then
                i = 5 - txtLicense1.Text.Length
                txtLicense1.Text &= key.Substring(0, i)
                key = key.Remove(0, i)
                If key.Length >= 5 Then
                    txtLicense2.Text = key.Substring(0, 5)
                    key = key.Remove(0, 5)
                    If key.Length >= 5 Then
                        txtLicense3.Text = key.Substring(0, 5)
                        key = key.Remove(0, 5)
                        If key.Length >= 5 Then
                            txtLicense4.Text = key.Substring(0, 5)
                            key = key.Remove(0, 5)
                            If key.Length >= 5 Then
                                txtLicense5.Text = key.Substring(0, 5)
                                key = key.Remove(0, 5)
                                If key.Length >= 5 Then
                                    txtLicense6.Text = key.Substring(0, 5)
                                    key = key.Remove(0, 5)
                                Else
                                    txtLicense6.Text = key.Substring(0, key.Length)
                                    key = key.Remove(0, key.Length)
                                End If
                            Else
                                txtLicense5.Text = key.Substring(0, key.Length)
                                key = key.Remove(0, key.Length)
                            End If
                        Else
                            txtLicense4.Text = key.Substring(0, key.Length)
                            key = key.Remove(0, key.Length)
                        End If
                    Else
                        txtLicense3.Text = key.Substring(0, key.Length)
                        key = key.Remove(0, key.Length)
                    End If
                Else
                    txtLicense2.Text = key.Substring(0, key.Length)
                    key = key.Remove(0, key.Length)
                End If
            Else
                txtLicense1.Text &= key.Substring(0, key.Length)
                key = key.Remove(0, key.Length)
            End If

            e.Handled = True
        End If
    End Sub

    Private Sub txtLicense2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLicense2.KeyDown
        If e.Modifiers = Keys.Control AndAlso e.KeyCode = Keys.V Then
            Dim key As String = ""
            key = Clipboard.GetText(TextDataFormat.Text).Replace(" ", "")

            Dim rtn As String = ""
            Dim i As Integer = 0

            If key.Length >= 5 Then
                i = 5 - txtLicense2.Text.Length
                txtLicense2.Text &= key.Substring(0, i)
                key = key.Remove(0, i)
                If key.Length >= 5 Then
                    txtLicense3.Text = key.Substring(0, 5)
                    key = key.Remove(0, 5)
                    If key.Length >= 5 Then
                        txtLicense4.Text = key.Substring(0, 5)
                        key = key.Remove(0, 5)
                        If key.Length >= 5 Then
                            txtLicense5.Text = key.Substring(0, 5)
                            key = key.Remove(0, 5)
                            If key.Length >= 5 Then
                                txtLicense6.Text = key.Substring(0, 5)
                                key = key.Remove(0, 5)
                            Else
                                txtLicense6.Text = key.Substring(0, key.Length)
                                key = key.Remove(0, key.Length)
                            End If
                        Else
                            txtLicense5.Text = key.Substring(0, key.Length)
                            key = key.Remove(0, key.Length)
                        End If
                    Else
                        txtLicense4.Text = key.Substring(0, key.Length)
                        key = key.Remove(0, key.Length)
                    End If
                Else
                    txtLicense3.Text = key.Substring(0, key.Length)
                    key = key.Remove(0, key.Length)
                End If
            Else
                txtLicense2.Text &= key.Substring(0, key.Length)
                key = key.Remove(0, key.Length)
            End If

            e.Handled = True
        End If
    End Sub

    Private Sub txtLicense3_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLicense3.KeyDown
        If e.Modifiers = Keys.Control AndAlso e.KeyCode = Keys.V Then
            Dim key As String = ""
            key = Clipboard.GetText(TextDataFormat.Text).Replace(" ", "")

            Dim rtn As String = ""
            Dim i As Integer = 0

            If key.Length >= 5 Then
                i = 5 - txtLicense3.Text.Length
                txtLicense3.Text &= key.Substring(0, i)
                key = key.Remove(0, i)
                If key.Length >= 5 Then
                    txtLicense4.Text = key.Substring(0, 5)
                    key = key.Remove(0, 5)
                    If key.Length >= 5 Then
                        txtLicense5.Text = key.Substring(0, 5)
                        key = key.Remove(0, 5)
                        If key.Length >= 5 Then
                            txtLicense6.Text = key.Substring(0, 5)
                            key = key.Remove(0, 5)
                        Else
                            txtLicense6.Text = key.Substring(0, key.Length)
                            key = key.Remove(0, key.Length)
                        End If
                    Else
                        txtLicense5.Text = key.Substring(0, key.Length)
                        key = key.Remove(0, key.Length)
                    End If
                Else
                    txtLicense4.Text = key.Substring(0, key.Length)
                    key = key.Remove(0, key.Length)
                End If
            Else
                txtLicense3.Text &= key.Substring(0, key.Length)
                key = key.Remove(0, key.Length)
            End If

            e.Handled = True
        End If
    End Sub

    Private Sub txtLicense4_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLicense4.KeyDown
        If e.Modifiers = Keys.Control AndAlso e.KeyCode = Keys.V Then
            Dim key As String = ""
            key = Clipboard.GetText(TextDataFormat.Text).Replace(" ", "")

            Dim rtn As String = ""
            Dim i As Integer = 0


            If key.Length >= 5 Then
                i = 5 - txtLicense4.Text.Length
                txtLicense4.Text &= key.Substring(0, i)
                key = key.Remove(0, i)
                If key.Length >= 5 Then
                    txtLicense5.Text = key.Substring(0, 5)
                    key = key.Remove(0, 5)
                    If key.Length >= 5 Then
                        txtLicense6.Text = key.Substring(0, 5)
                        key = key.Remove(0, 5)
                    Else
                        txtLicense6.Text = key.Substring(0, key.Length)
                        key = key.Remove(0, key.Length)
                    End If
                Else
                    txtLicense5.Text = key.Substring(0, key.Length)
                    key = key.Remove(0, key.Length)
                End If
            Else
                txtLicense4.Text &= key.Substring(0, key.Length)
                key = key.Remove(0, key.Length)
            End If

            e.Handled = True
        End If
    End Sub

    Private Sub txtLicense5_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLicense5.KeyDown
        If e.Modifiers = Keys.Control AndAlso e.KeyCode = Keys.V Then
            Dim key As String = ""
            key = Clipboard.GetText(TextDataFormat.Text).Replace(" ", "")

            Dim rtn As String = ""
            Dim i As Integer = 0

            If key.Length >= 5 Then
                i = 5 - txtLicense4.Text.Length
                txtLicense5.Text &= key.Substring(0, i)
                key = key.Remove(0, i)
                If key.Length >= 5 Then
                    txtLicense6.Text = key.Substring(0, 5)
                    key = key.Remove(0, 5)
                Else
                    txtLicense6.Text = key.Substring(0, key.Length)
                    key = key.Remove(0, key.Length)
                End If
            Else
                txtLicense5.Text &= key.Substring(0, key.Length)
                key = key.Remove(0, key.Length)
            End If

            e.Handled = True
        End If
    End Sub

    Private Sub txtLicense6_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLicense6.KeyDown
        If e.Modifiers = Keys.Control AndAlso e.KeyCode = Keys.V Then
            Dim key As String = ""
            key = Clipboard.GetText(TextDataFormat.Text).Replace(" ", "")

            Dim rtn As String = ""
            Dim i As Integer = 0

            If key.Length >= 5 Then
                txtLicense6.Text = key.Substring(0, 5)
                key = key.Remove(0, 5)
            Else
                txtLicense6.Text = key.Substring(0, key.Length)
                key = key.Remove(0, key.Length)
            End If

            e.Handled = True
        End If
    End Sub

    Private Sub btnConfirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfirm.Click
        If txtLicense1.TextLength = 5 And txtLicense2.TextLength = 5 And txtLicense3.TextLength = 5 And txtLicense4.TextLength = 5 And txtLicense5.TextLength = 5 And txtLicense6.TextLength = 5 Then
            Dim [source] As String = txtLicense1.Text & " " & txtLicense2.Text & " " & txtLicense3.Text & " " & txtLicense4.Text & " " & txtLicense5.Text.Substring(0, 4)
            Dim n As String = ""
            Using md5Hash As MD5 = MD5.Create()
                n = GetMd5Hash(md5Hash, source).ToUpper().Substring(10, 5)
            End Using

            If n = txtLicense6.Text Then
                Dim pattarn As String = ""
                Select Case txtLicense5.Text.Substring(txtLicense5.Text.Length - 1, 1)
                    Case "1"
                        pattarn = "RNNNDDUUNNDDNDNDRDRNDNNN"
                        Exit Select
                    Case "3"
                        pattarn = "DDRUNNNNDDNDRNNUDNDNRDNN"
                        Exit Select
                    Case "4"
                        pattarn = "DNNNNDRDNNDNRNNUDNUDNRDD"
                        Exit Select
                    Case "5"
                        pattarn = "DDNRNNRNNUUNNDDNRNDNNDDD"
                        Exit Select
                    Case "7"
                        pattarn = "NUDDNNNRUNNDDNDDNRDDNNRN"
                        Exit Select
                    Case "9"
                        pattarn = "DRUNRNRNNNUDNDNNDDDNDDNN"
                        Exit Select
                    Case "0"
                        pattarn = "NDNUNNRUNDDNDDNNDRDNNRND"
                        Exit Select
                    Case "A"
                        pattarn = "RNDDNRNNNDNDNDRDNDUNUNDN"
                        Exit Select
                    Case "B"
                        pattarn = "DNURRNNNRNNDNNNUDDDNNDDD"
                        Exit Select
                    Case "C"
                        pattarn = "NRNNUDNRNRNDDNNDDNDUDNDN"
                        Exit Select
                    Case "E"
                        pattarn = "DNDDNNNRNRNUNDDNRNUNNDDD"
                        Exit Select
                    Case "F"
                        pattarn = "NUNDNDNNNURDNNDNRNDDDNRD"
                        Exit Select
                    Case "T"
                        pattarn = "RDNDNNDNUNDNNRNDDRNDDNUN"
                        Exit Select
                    Case "H"
                        pattarn = "NDDNNNNUNDNDNRDNRNDDRDUN"
                        Exit Select
                    Case "J"
                        pattarn = "NUDNNRNNNDNDNNDDDRURDNND"
                        Exit Select
                End Select

                Dim key, cn, cd, cr, cu As String
                Dim i As Integer = 0
                cn = ""
                cd = ""
                cr = ""
                cu = ""
                key = txtLicense1.Text & txtLicense2.Text & txtLicense3.Text & txtLicense4.Text & txtLicense5.Text
                For Each c As Char In pattarn
                    Select Case c
                        Case "N"
                            cn &= key.Substring(i, 1)
                            Exit Select
                        Case "D"
                            cd &= key.Substring(i, 1)
                            Exit Select
                        Case "R"
                            cr &= key.Substring(i, 1)
                            Exit Select
                        Case "U"
                            cu &= key.Substring(i, 1)
                            Exit Select
                    End Select
                    i += 1
                Next

                source = txtHotalname.Text
                n = ""
                Using md5Hash As MD5 = MD5.Create()
                    n = GetMd5Hash(md5Hash, source).ToUpper().Substring(0, 11)
                End Using
                If n <> cn Then
                    MsgBox("Hotal name is not valid.")
                    Exit Sub
                End If

                d = CDate(cd.Substring(0, 4) & "-" & cd.Substring(4, 2) & "-" & cd.Substring(6, 2))
                lblExpireDate.Text = cd.Substring(6, 2) & "/" & cd.Substring(4, 2) & "/" & cd.Substring(0, 4)
                lblMaxRoom.Text = CInt(cr)
                lblMaxUser.Text = CInt(cu)

                GroupBox1.Enabled = False
                GroupBox2.Enabled = True
            Else
                MsgBox("License is not valid.")
            End If
        Else
            MsgBox("License is not fully.")
        End If
    End Sub

    Shared Function GetMd5Hash(ByVal md5Hash As MD5, ByVal input As String) As String
        Dim data As Byte() = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input))
        Dim sBuilder As New StringBuilder()
        Dim i As Integer
        For i = 0 To data.Length - 1
            sBuilder.Append(data(i).ToString("x2"))
        Next i
        Return sBuilder.ToString()
    End Function

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If MessageBox.Show("Do you want cancel license?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
            GroupBox1.Enabled = True
            GroupBox2.Enabled = False
        End If
    End Sub

    Private Sub btnApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApply.Click
        Dim str As String = ""
        Dim license As String = txtLicense1.Text & "-" & txtLicense2.Text & "-" & txtLicense3.Text & "-" & txtLicense4.Text & "-" & txtLicense5.Text & "-" & txtLicense6.Text
        Dim stdate As String = ""
        If dtpStart.Value.ToString("yyyy") > 2450 Then
            stdate = (dtpStart.Value.ToString("yyyy") - 543) & dtpStart.Value.ToString("-MM-dd")
        Else
            stdate = dtpStart.Value.ToString("yyyy-MM-dd")
        End If

        res = conn.mysql_query("SELECT COUNT(system_id) AS cout FROM main_system")
        res.Read()
        If CInt(res.GetString("cout")) > 0 Then
            str &= "UPDATE main_system SET system_license='" & license & "',system_date='" & stdate & "',system_name='" & txtHotalname.Text & "' WHERE system_id='1';"
        Else
            str &= "INSERT INTO main_system(system_id,system_license,system_name,system_nowlogin,system_date) VALUES('1','" & license & "','" & txtHotalname.Text & "','0','" & stdate & "');"
        End If
        str &= "UPDATE pos_shop SET alert_1m='0',alert_15='0',alert_7='0' where id='1';"
        conn.mysql_query(str)
        Login.maxTable = CInt(lblMaxRoom.Text)
        Login.maxUser = CInt(lblMaxUser.Text)
        Login.Expire = d
        s = True
        Me.Close()
    End Sub
End Class