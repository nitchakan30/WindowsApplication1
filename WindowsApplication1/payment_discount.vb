Imports MySql.Data.MySqlClient
Public Class payment_discount
    Dim con As New Mysql
    Public typedis As String = "all"
    Private Sub payment_discount_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
    
    Private Sub add_dis_only_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles add_dis_only.Click
        If typedis = "all" Then
            Dim t As String = ""
            If radio_dis_only1.Checked = True Then
                t = radio_dis_only1.Text
            End If
            If radio_dis_only2.Checked = True Then
                t = radio_dis_only2.Text
            End If
            payment.txt_dis_all.Text = FormatNumber(CDbl(txt_dis_only.Text), 2)
            payment.Label_ShowAllDisType.Text = "( " & t & " )"
            payment.Label_ShowAllDisType.Tag = t

        ElseIf typedis = "Food" Then
            If payment.ListView1.Items.Count > 0 Then
                For i As Integer = 0 To payment.ListView1.Items.Count - 1
                    If (payment.ListView1.Items(i).SubItems(28).Text = "1" Or payment.ListView1.Items(i).SubItems(28).Text = 1) And payment.ListView1.Items(i).SubItems(0).Text <> "void" Then
                        If radio_dis_only1.Checked = True Then
                            payment.ListView1.Items.Item(i).SubItems(12).Text = "-" & FormatNumber(CDbl(txt_dis_only.Text), 2)
                            payment.ListView1.Items.Item(i).SubItems(13).Text = FormatNumber(CDbl(txt_dis_only.Text), 2)
                            payment.ListView1.Items.Item(i).SubItems(14).Text = "บาท"
                            payment.ListView1.Items.Item(i).SubItems(15).Text = FormatNumber(CDbl(payment.ListView1.Items(i).SubItems(11).Text()) - CDbl(txt_dis_only.Text), 2)
                        End If
                        If radio_dis_only2.Checked = True Then
                            Dim disV As Double = (CDbl(payment.ListView1.Items(i).SubItems(11).Text()) * CDbl(txt_dis_only.Text) / 100)
                            Dim disS As Double = CDbl(payment.ListView1.Items(i).SubItems(11).Text()) - CDbl(disV)
                            payment.ListView1.Items(i).SubItems(12).Text = "-" & FormatNumber(CDbl(txt_dis_only.Text), 2)
                            payment.ListView1.Items(i).SubItems(13).Text = disV
                            payment.ListView1.Items(i).SubItems(14).Text = "%"
                            payment.ListView1.Items(i).SubItems(15).Text = FormatNumber(disS, 2)
                        End If
                    End If
                Next
            End If
        ElseIf typedis = "Bev" Then
            If payment.ListView1.Items.Count > 0 Then
                For i As Integer = 0 To payment.ListView1.Items.Count - 1
                    If (payment.ListView1.Items(i).SubItems(28).Text = "2" Or payment.ListView1.Items(i).SubItems(28).Text = 2) And payment.ListView1.Items(i).SubItems(0).Text <> "void" Then
                        If radio_dis_only1.Checked = True Then
                            payment.ListView1.Items.Item(i).SubItems(12).Text = "-" & FormatNumber(CDbl(txt_dis_only.Text), 2)
                            payment.ListView1.Items.Item(i).SubItems(13).Text = FormatNumber(CDbl(txt_dis_only.Text), 2)
                            payment.ListView1.Items.Item(i).SubItems(14).Text = "บาท"
                            payment.ListView1.Items.Item(i).SubItems(15).Text = FormatNumber(CDbl(payment.ListView1.Items(i).SubItems(11).Text()) - CDbl(txt_dis_only.Text), 2)
                        End If
                        If radio_dis_only2.Checked = True Then
                            Dim disV As Double = (CDbl(payment.ListView1.Items(i).SubItems(11).Text()) * CDbl(txt_dis_only.Text) / 100)
                            Dim disS As Double = CDbl(payment.ListView1.Items(i).SubItems(11).Text()) - CDbl(disV)
                            payment.ListView1.Items(i).SubItems(12).Text = "-" & FormatNumber(CDbl(txt_dis_only.Text), 2)
                            payment.ListView1.Items(i).SubItems(13).Text = disV
                            payment.ListView1.Items(i).SubItems(14).Text = "%"
                            payment.ListView1.Items(i).SubItems(15).Text = FormatNumber(disS, 2)
                        End If
                    End If
                Next
            End If
        ElseIf typedis = "Other" Then
            If payment.ListView1.Items.Count > 0 Then
                For i As Integer = 0 To payment.ListView1.Items.Count - 1
                    If (payment.ListView1.Items(i).SubItems(28).Text = "3" Or payment.ListView1.Items(i).SubItems(28).Text = 3) And payment.ListView1.Items(i).SubItems(0).Text <> "void" Then
                        If radio_dis_only1.Checked = True Then
                            payment.ListView1.Items.Item(i).SubItems(12).Text = "-" & FormatNumber(CDbl(txt_dis_only.Text), 2)
                            payment.ListView1.Items.Item(i).SubItems(13).Text = FormatNumber(CDbl(txt_dis_only.Text), 2)
                            payment.ListView1.Items.Item(i).SubItems(14).Text = "บาท"
                            payment.ListView1.Items.Item(i).SubItems(15).Text = FormatNumber(CDbl(payment.ListView1.Items(i).SubItems(11).Text()) - CDbl(txt_dis_only.Text), 2)
                        End If
                        If radio_dis_only2.Checked = True Then
                            Dim disV As Double = (CDbl(payment.ListView1.Items(i).SubItems(11).Text()) * CDbl(txt_dis_only.Text) / 100)
                            Dim disS As Double = CDbl(payment.ListView1.Items(i).SubItems(11).Text()) - CDbl(disV)
                            payment.ListView1.Items(i).SubItems(12).Text = "-" & FormatNumber(CDbl(txt_dis_only.Text), 2)
                            payment.ListView1.Items(i).SubItems(13).Text = disV
                            payment.ListView1.Items(i).SubItems(14).Text = "%"
                            payment.ListView1.Items(i).SubItems(15).Text = FormatNumber(disS, 2)
                        End If
                    End If
                Next
            End If
        Else
            Dim ds1 As Double = 0.0
            If payment.ListView1.Items.Count > 0 Then
                If payment.ListView1.SelectedIndices.Count > 0 Then
                    If radio_dis_only1.Checked = True Then
                        payment.ListView1.SelectedItems.Item(0).SubItems(12).Text = "-" & FormatNumber(CDbl(txt_dis_only.Text), 2)
                        payment.ListView1.SelectedItems.Item(0).SubItems(13).Text = FormatNumber(CDbl(txt_dis_only.Text), 2)
                        payment.ListView1.SelectedItems.Item(0).SubItems(14).Text = "บาท"
                        payment.ListView1.SelectedItems.Item(0).SubItems(15).Text = FormatNumber(CDbl(payment.ListView1.Items(payment.ListView1.SelectedIndices(0)).SubItems(11).Text()) - CDbl(txt_dis_only.Text), 2)
                    End If
                    If radio_dis_only2.Checked = True Then
                        Dim disV As Double = (CDbl(payment.ListView1.Items(payment.ListView1.SelectedIndices(0)).SubItems(11).Text()) * CDbl(txt_dis_only.Text) / 100)
                        Dim disS As Double = CDbl(payment.ListView1.Items(payment.ListView1.SelectedIndices(0)).SubItems(11).Text()) - CDbl(disV)
                        payment.ListView1.Items(payment.ListView1.SelectedIndices(0)).SubItems(12).Text = "-" & FormatNumber(CDbl(txt_dis_only.Text), 2)
                        payment.ListView1.Items(payment.ListView1.SelectedIndices(0)).SubItems(13).Text = disV
                        payment.ListView1.Items(payment.ListView1.SelectedIndices(0)).SubItems(14).Text = "%"
                        payment.ListView1.Items(payment.ListView1.SelectedIndices(0)).SubItems(15).Text = FormatNumber(disS, 2)
                    End If
                End If
            End If

        End If
        payment.cal_list_price()
        Me.Close()
    End Sub

    Private Sub minus_dis_all_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub
    Private Sub minus_dis_only_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles minus_dis_only.Click
        If typedis = "all" Then
            payment.txt_sum_discount.Text = "0.0"
            payment.txt_dis_all.Text = "0.0"
            payment.cal_list_price()
        End If
        Me.Close()
    End Sub

    Private Sub txt_dis_only_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_dis_only.Click
        keyborad_number.text1 = "discount_only"
        keyborad_number.ShowDialog()
    End Sub

End Class