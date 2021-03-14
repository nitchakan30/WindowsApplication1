Imports MySql.Data.MySqlClient
Public Class payment_oc
    Dim con_front As New Mysql
    Dim pageAll As Integer = 0
    Dim pageAllFood As Integer
    Dim sizeWFood As String
    Dim numPageFD As Integer = 0
    Public page As String = "payment"
    Public payment_type_id As Integer = 0
    Public payment_type_name As String = ""
    Public payment_amount_oc As Double = 0.0
    Private Sub payment_oc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        sizeWFood = Math.Floor(CDbl(FlowLayoutPanel1.Width / 150)) * Math.Floor(CDbl(FlowLayoutPanel1.Height / 60))
        Show_Inroom(0)
    End Sub
    Private Sub opentable_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        Try
            sizeWFood = Math.Floor(CDbl(FlowLayoutPanel1.Width / 150)) * Math.Floor(CDbl(FlowLayoutPanel1.Height / 60))
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
        StrSQL &= "SELECT * from pos_payment_oc WHERE ref_payment_type_id='" & payment_type_id & "' and status_oc='1' "
        StrSQL &= " ORDER BY name_oc ASC LIMIT " & StratPFD & "," & sizeWFood
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

            Dim Button_inroom = New Button
            Button_inroom.Cursor = Cursors.Hand
            Button_inroom.Name = "Button_FD" & i
            Button_inroom.Width = 150
            Button_inroom.Height = 60
            Button_inroom.ForeColor = Color.Black
            Button_inroom.Font = New Font(Button_inroom.Font.FontFamily, 9, FontStyle.Bold)
            Button_inroom.Tag = res_food.GetString("id_oc")
            Button_inroom.Text = res_food.GetString("name_oc") & vbCrLf & "C:" & res_food.GetString("credit_oc")
            Button_inroom.TextAlign = ContentAlignment.MiddleCenter
            If payment_amount_oc > res_food.GetDouble("credit_oc") Or res_food.GetDouble("credit_oc") <= 0 Then
                Button_inroom.Enabled = False
            Else
                Button_inroom.Enabled = True
            End If
            FlowLayoutPanel1.Controls.Add(Button_inroom)
            AddHandler Button_inroom.Click, AddressOf AddRoom_Click

            i += 1
        End While
    End Sub
    Private Sub AddRoom_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim b As Button = CType(sender, Button)
        'payment_amount_oc
        Dim strArr() As String
        strArr = b.Text.ToString.Split("C:")
   
        If page = "payment" Then
            payment.des_payment = payment_type_name & ":" & strArr(0).ToString
            payment.rf_id_oc = CInt(b.Tag.ToString)
            payment.rf_name_oc = strArr(0).ToString
            '   payment.rf_payment_type = b.Tag.ToString
            payment.TextBox_TypePay.Text = payment_type_name & ":" & strArr(0).ToString
        Else
            payment_gohome.des_payment = payment_type_name & ":" & strArr(0).ToString
            payment_gohome.rf_id_oc = CInt(b.Tag.ToString)
            payment_gohome.rf_name_oc = strArr(0).ToString
            MsgBox(CInt(b.Tag.ToString) & strArr(0).ToString)
            '  payment_gohome.rf_payment_type = b.Tag.ToString
            payment_gohome.TextBox_TypePay.Text = payment_type_name & ":" & strArr(0).ToString
        End If
        Me.Close()
    End Sub
    Public Sub Load_numInroom()
        Dim res_i As Integer = con_front.mysql_num_rows(con_front.mysql_query("SELECT * from pos_payment_oc WHERE ref_payment_type_id='" & payment_type_id & "' and status_oc='1' " _
        & " ORDER BY name_oc ASC "))
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