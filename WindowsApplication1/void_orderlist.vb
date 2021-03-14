Public Class void_orderlist
    Public id_prd As String
    Public id_con_prd As String
    Public name_prd As String
    Public name_prd_en As String
    Public Nsize As String
    Public samt As Integer = 0
    Public sprice As Double = 0
    Public remark As String = ""
    Public id_cat As String = ""
    Public id_subcatprd As String = ""
    Public name_cat_en As String = ""
    Public name_cat_th As String = ""
    Public name_subcat_en As String = ""
    Public name_subcat_th As String = ""
    Public ord_vat As String = ""
    Public ord_vat_st As String = ""
    Public prd_t_id As Integer = 0
    Public prd_t_en As String = ""
    Public prd_t_th As String = ""
    Public PageRefer As String = "home1"
    Private Sub btn_enter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_enter.Click
        If PageRefer = "home1" Then
            If samt > 0 Then
                Dim g As Integer
                For i As Integer = 0 To home_cancel_order.ListView_food.Items.Count - 1
                    If home_cancel_order.ListView_food.Items(i).SubItems(0).Text.ToLower = "void" Then
                        If id_prd = home_cancel_order.ListView_food.Items(i).SubItems(2).Text And id_con_prd = home_cancel_order.ListView_food.Items(i).SubItems(3).Text Then
                            g += CInt(home_cancel_order.ListView_food.Items(i).SubItems(7).Text)
                        End If
                    End If
                Next
                If TextBox1.Text <= samt Then
                    home_cancel_order.ListView_food.Items(home_cancel_order.ListView_food.SelectedIndices(0)).SubItems(7).Text() = samt - CInt(TextBox1.Text)
                    If samt = 1 Then
                        home_cancel_order.ListView_food.Items(home_cancel_order.ListView_food.SelectedIndices(0)).SubItems(8).Text() = 0
                    Else
                        If samt = CInt(TextBox1.Text) Then
                            home_cancel_order.ListView_food.Items(home_cancel_order.ListView_food.SelectedIndices(0)).SubItems(8).Text() = 0
                        Else
                            home_cancel_order.ListView_food.Items(home_cancel_order.ListView_food.SelectedIndices(0)).SubItems(8).Text() = (CDbl(home_cancel_order.ListView_food.Items(home_cancel_order.ListView_food.SelectedIndices(0)).SubItems(8).Text() / samt)) * (samt - TextBox1.Text)
                        End If
                    End If

                    If samt - CInt(TextBox1.Text) >= 0 Then
                        Dim itmx As New ListViewItem
                        Dim n As Integer = home_cancel_order.ListView_food.Items.Count
                        Dim x As Integer = n + 1
                        Dim nPrice As Double

                        nPrice = (sprice / samt)
                        sprice = (TextBox1.Text * nPrice)

                        itmx = home_cancel_order.ListView_food.Items.Add("void", x)
                        itmx.SubItems.Add("")
                        itmx.SubItems.Add(id_prd)
                        itmx.SubItems.Add(id_con_prd)
                        itmx.SubItems.Add(name_prd)
                        itmx.SubItems.Add(name_prd_en)
                        itmx.SubItems.Add(Nsize)
                        itmx.SubItems.Add(TextBox1.Text())
                        itmx.SubItems.Add(sprice)
                        itmx.SubItems.Add(TextBox2.Text)
                        itmx.SubItems.Add(id_cat)
                        itmx.SubItems.Add(id_subcatprd)
                        itmx.SubItems.Add(name_cat_en)
                        itmx.SubItems.Add(name_cat_th)
                        itmx.SubItems.Add(name_subcat_en)
                        itmx.SubItems.Add(name_subcat_th)
                        itmx.SubItems.Add(ord_vat)
                        itmx.SubItems.Add(ord_vat_st)
                        itmx.SubItems.Add(prd_t_id)
                        itmx.SubItems.Add(prd_t_en)
                        itmx.SubItems.Add(prd_t_th)
                        home_cancel_order.ListView_food.Items(x - 1).BackColor = Color.Red
                        home1.calsum()
                        home_cancel_order.save_voidlist.Enabled = True
                        Me.Close()
                    End If
                Else
                    MsgBox("ไม่สามารถยกเลิกรายการได้ค่ะ กรุณาตรวจสอบใหม่อีกครั้ง")
                End If
            End If
        ElseIf PageRefer = "gohome" Then
            If samt > 0 Then
                
                If TextBox1.Text <= samt Then
                    gohome_list_void_orderlist.ListView_GHF.Items(gohome_list_void_orderlist.ListView_GHF.SelectedIndices(0)).SubItems(7).Text() = samt - CInt(TextBox1.Text)
                    If samt = 1 Then
                        gohome_list_void_orderlist.ListView_GHF.Items(gohome_list_void_orderlist.ListView_GHF.SelectedIndices(0)).SubItems(8).Text() = 0
                        gohome_list_void_orderlist.ListView_GHF.Items(gohome_list_void_orderlist.ListView_GHF.SelectedIndices(0)).SubItems(13).Text() = 0
                    Else
                        If samt = CInt(TextBox1.Text) Then
                            gohome_list_void_orderlist.ListView_GHF.Items(gohome_list_void_orderlist.ListView_GHF.SelectedIndices(0)).SubItems(8).Text() = 0
                            gohome_list_void_orderlist.ListView_GHF.Items(gohome_list_void_orderlist.ListView_GHF.SelectedIndices(0)).SubItems(13).Text() = 0
                        Else
                            gohome_list_void_orderlist.ListView_GHF.Items(gohome_list_void_orderlist.ListView_GHF.SelectedIndices(0)).SubItems(8).Text() = CDbl(sprice / samt) * CInt(samt - TextBox1.Text)
                            gohome_list_void_orderlist.ListView_GHF.Items(gohome_list_void_orderlist.ListView_GHF.SelectedIndices(0)).SubItems(13).Text() = CDbl(sprice / samt) * CInt(samt - TextBox1.Text)
                        End If
                    End If

                    If samt - CInt(TextBox1.Text) >= 0 Then
                        Dim itmx As New ListViewItem
                        Dim n As Integer = gohome_list_void_orderlist.ListView_GHF.Items.Count
                        Dim y As Integer = n + 1
                        Dim nPrice As Double

                        nPrice = (sprice / samt)
                        sprice = (TextBox1.Text * nPrice)

                        itmx = gohome_list_void_orderlist.ListView_GHF.Items.Add("", y)
                        itmx.SubItems.Add("void")
                        itmx.SubItems.Add(id_prd)
                        itmx.SubItems.Add(id_con_prd)
                        itmx.SubItems.Add(name_prd)
                        itmx.SubItems.Add(name_prd_en)
                        itmx.SubItems.Add(Nsize)
                        itmx.SubItems.Add(TextBox1.Text())
                        itmx.SubItems.Add((TextBox1.Text * nPrice))
                        itmx.SubItems.Add(TextBox2.Text)
                        itmx.SubItems.Add("0")
                        itmx.SubItems.Add("0")
                        itmx.SubItems.Add("0")
                        itmx.SubItems.Add((TextBox1.Text * nPrice))
                        itmx.SubItems.Add(id_cat)
                        itmx.SubItems.Add(id_subcatprd)
                        itmx.SubItems.Add(name_cat_en)
                        itmx.SubItems.Add(name_cat_th)
                        itmx.SubItems.Add(name_subcat_en)
                        itmx.SubItems.Add(name_subcat_th)
                        itmx.SubItems.Add(ord_vat)
                        itmx.SubItems.Add(ord_vat_st)
                        gohome_list_void_orderlist.ListView_GHF.Items(y - 1).BackColor = Color.Red
                        ' gohome_list.calsum()
                        PageRefer = "home1"
                        Me.Close()
                    End If
                Else
                    MsgBox("ไม่สามารถยกเลิกรายการได้ค่ะ กรุณาตรวจสอบใหม่อีกครั้ง")
                End If
            End If
        End If
       
    End Sub

    Private Sub btn_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_close.Click
        Me.Close()
    End Sub

    Private Sub TextBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.Click
        keyborad_number.text1 = "voidorderlist"
        keyborad_number.ShowDialog()
    End Sub

End Class