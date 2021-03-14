Imports MySql.Data.MySqlClient
Public Class inroom
    Dim con_front As New MysqlFront
    Dim pageAll As Integer = 0
    Dim pageAllFood As Integer
    Dim sizeWFood As String
    Dim numPageFD As Integer = 0
    Public page As String = "payment"
    Private Sub inroom_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        sizeWFood = Math.Floor(CDbl(FlowLayoutPanel1.Width / 80)) * Math.Floor(CDbl(FlowLayoutPanel1.Height / 40))
        Show_Inroom(0)
    End Sub
    Private Sub opentable_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        Try
            sizeWFood = Math.Floor(CDbl(FlowLayoutPanel1.Width / 80)) * Math.Floor(CDbl(FlowLayoutPanel1.Height / 40))
            Show_Inroom(0)
        Catch ex As Exception
        End Try
    End Sub
    Public Sub Show_Inroom(ByVal StratPFD As Integer)
        Load_numInroom()
        Dim res_food As MySqlDataReader
        Dim i As Integer = 1
        Dim uu As Integer
        Dim StrSQL As String = ""
        StrSQL &= "SELECT ih_no AS no, ih_roomno AS roomno,'1' as type,ih_adult as adult,ih_child as child FROM front_inhouse WHERE ih_status =  '1'"
        StrSQL &= " UNION SELECT mi_ihno AS no, mi_roomno AS roomno,'2' as type,'1' as adult,'0' as child FROM front_monthly_inhouse WHERE mi_status =  '1'"
        StrSQL &= " ORDER BY roomno ASC LIMIT " & StratPFD & "," & sizeWFood

        res_food = con_front.mysql_query(StrSQL)
        FlowLayoutPanel1.Controls.Clear()
        If pageAllFood > 0 Then
            If numPageFD = 0 Then
                uu = numPageFD + 1
            Else
                uu = numPageFD
            End If
            TextBox_PageIh.Text = uu & "/" & pageAllFood
        ElseIf numPageFD = pageAllFood Then
            TextBox_PageIh.Text = pageAllFood & "/" & pageAllFood
        Else

            TextBox_PageIh.Text = "0/0"
        End If
        While res_food.Read()
            If res_food.GetString("no") <> "" Then
                Dim Button_inroom = New Button
                Button_inroom.Cursor = Cursors.Hand
                Button_inroom.Name = "Button_FD" & i
                Button_inroom.Width = 80
                Button_inroom.Height = 40
                Button_inroom.ForeColor = Color.Black
                Button_inroom.Font = New Font(Button_inroom.Font.FontFamily, 9, FontStyle.Bold)
                If page = "home1" Or page = "opentable" Then
                    Button_inroom.Tag = res_food.GetString("no") & "-" & res_food.GetString("adult") & "-" & res_food.GetString("child")
                Else
                    Button_inroom.Tag = res_food.GetString("no")
                End If
                Button_inroom.Text = res_food.GetString("roomno")
                Button_inroom.TextAlign = ContentAlignment.MiddleCenter
                FlowLayoutPanel1.Controls.Add(Button_inroom)
                AddHandler Button_inroom.Click, AddressOf AddRoom_Click
            End If
                i += 1
        End While
    End Sub
    Private Sub AddRoom_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim b As Button = CType(sender, Button)
        Dim strArr() As String
        If page = "payment" Then
            payment.des_payment = b.Text.ToString
            payment.ihno = b.Tag.ToString
            payment.TextBox_TypePay.Text = "INROOM: " & b.Text.ToString
        ElseIf page = "home1" Then
            strArr = b.Tag.ToString.Split("-")
            home1.txt_adult.Text = strArr(1).ToString
            home1.txt_child.Text = strArr(2).ToString
            home1.txt_roomnum.Text = b.Text.ToString
            home1.txt_roomnum.Tag = strArr(0).ToString
            home1.txt_cover.Text = CInt(strArr(1).ToString) + CInt(strArr(2).ToString)
            opentable.AddCoverTable(home1.txt_adult.Text, home1.txt_child.Text, home1.txt_cover.Text, strArr(0).ToString, b.Text.ToString, Login.OpenId, "0")
        ElseIf page = "opentable" Then
            strArr = b.Tag.ToString.Split("-")
            opentable.TextBox_Prs.Text = strArr(1).ToString
            opentable.txt_child.Text = strArr(2).ToString
            opentable.txt_roomnum.Text = b.Text.ToString
            opentable.txt_roomnum.Tag = strArr(0).ToString
            opentable.txt_cover.Text = CInt(strArr(1).ToString) + CInt(strArr(2).ToString)
            opentable.AddCoverTable(opentable.TextBox_Prs.Text, opentable.txt_child.Text, opentable.txt_cover.Text, strArr(0).ToString, b.Text.ToString, Login.OpenId, "0")
        Else
            payment_gohome.des_payment = b.Text.ToString
            payment_gohome.ihno = b.Tag.ToString
            payment_gohome.TextBox_TypePay.Text = "INROOM: " & b.Text.ToString
        End If
        Me.Close()
    End Sub
    Public Sub Load_numInroom()
        Dim res_i As Integer = con_front.mysql_num_rows(con_front.mysql_query("SELECT ih_no AS no, ih_roomno AS roomno,'1' as type FROM front_inhouse WHERE ih_status =  '1'" _
        & " UNION SELECT mi_ihno AS no, mi_roomno AS roomno,'2' as type FROM front_monthly_inhouse WHERE mi_status =  '1'" _
        & " ORDER BY no ASC"))
        pageAllFood = Math.Ceiling(res_i / sizeWFood)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim y As Integer = numPageFD
        If numPageFD = 0 Or numPageFD < 0 Then
            numPageFD = 0
            TextBox_PageIh.Text = (y + 1) & "/" & pageAllFood
        Else
            numPageFD -= 1
            Show_Inroom(sizeWFood * numPageFD)
            TextBox_PageIh.Text = y & "/" & pageAllFood
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        numPageFD = 0
        TextBox_PageIh.Text = "1/" & pageAllFood
        Show_Inroom(0)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim xx As Integer = numPageFD + 1
        If pageAllFood = xx Then
            numPageFD = (pageAllFood - 1)
        Else
            numPageFD += 1
            Show_Inroom(sizeWFood * numPageFD)
            TextBox_PageIh.Text = xx + 1 & "/" & pageAllFood
        End If
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        numPageFD = pageAllFood
        TextBox_PageIh.Text = pageAllFood & "/" & pageAllFood
        Show_Inroom(sizeWFood * (pageAllFood - 1))
    End Sub
End Class