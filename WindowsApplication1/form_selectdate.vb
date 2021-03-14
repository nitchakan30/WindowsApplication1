Imports MySql.Data.MySqlClient
Public Class form_selectdate
    Dim DayLast As String = ""
    Dim YearNext As Integer = 0
    Dim YearPrev As Integer = 0
    Dim MonthNext As Integer = 0
    Dim MonthPrev As Integer = 0
    Dim DateNew As String
    Dim DateNow As Date = Date.Now
    Dim dateSel As String
    Dim monthSel As String
    Dim yearSel As String
    Dim DateSelect As String
    Dim con As New Mysql

    Private Sub form_selectdate_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Login.KillP()
        Login.KillLogin()
        Login.Show()
    End Sub
    Private Sub form_selectdate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ReloadCal(Date.Now, Date.Now.Day)
        MonthNext = DateNow.Month
        YearNext = (DateNow.Year) + 543
        DateSelect = Date.Now.ToString("dd/MM/yyyy")
    End Sub
    Private Sub btn_next_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_next.Click
        btn_prev.Enabled = True
        If DateNow.Month = 12 Or MonthNext = 12 Then
            MonthNext = 0
            MonthNext += 1
            YearNext += 1
        ElseIf MonthNext < 12 Then
            MonthNext += 1
            YearNext = YearNext
        End If
        DateNew = "1/" & MonthNext & "/" & YearNext
        ReloadCal(DateNew, 0)
    End Sub
    Private Sub btn_prev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_prev.Click

        If (MonthNext = 1) And (YearNext > (DateNow.Year) + 543) Then
            MonthNext = 12
            YearNext -= 1
            DateNew = "1/" & MonthNext & "/" & YearNext
        Else
            MonthNext -= 1
            YearNext = YearNext
            If DateNow.Month = MonthNext And (DateNow.Year) + 543 = YearNext Then
                DateNew = "1/" & DateNow.Month & "/" & (DateNow.Year) + 543
                btn_prev.Enabled = False
            Else
                DateNew = "1/" & MonthNext & "/" & YearNext
            End If
        End If
        ReloadCal(DateNew, 0)
    End Sub
    Public Sub ReloadCal(ByVal ldate As Date, ByVal Selected As Integer)
        On Error Resume Next
        Me.clearall()
        MonthName.Text = monthstr(ldate.Month)
        year1.Text = "ปี " & CInt(ldate.Year) + 543
        Dim fdate As DayOfWeek
        If DayLast <> "" Then
            Dim oldDate As Date = ldate
            Dim oldWeekDay As Integer
            oldWeekDay = oldDate.DayOfWeek()
            fdate = oldWeekDay
        Else
            fdate = GetFirstOfMonthDay(ldate)
        End If

        Dim idate As Integer = 1
        Dim row As Integer = 1

        dateSel = ldate.Date
        monthSel = ldate.Month
        yearSel = ldate.Year
        'MsgBox(ldate.Month)
        Do
            getlabel(fdate, row).Text = idate
            getlabel(fdate, row).ForeColor = f1.ForeColor
            getlabel(fdate, row).Enabled = True
            getlabel(fdate, row).ForeColor = Color.Black
            getlabel(fdate, row).BackColor = Color.Empty

            If idate = Date.Now.Day And (ldate.Month = Date.Now.Month) And ldate.Year = Date.Now.Year Then
                getlabel(fdate, row).ForeColor = Color.Black
                getlabel(fdate, row).BackColor = Color.Green
            ElseIf (idate < Date.Now.Day And (ldate.Month <= Date.Now.Month) And ldate.Year = Date.Now.Year) Then
                getlabel(fdate, row).Enabled = False
            End If

            If idate = Selected Then
                getlabel(fdate, row).ForeColor = Color.Black
                getlabel(fdate, row).BackColor = Color.Green
            End If


            If fdate = DayOfWeek.Saturday Then
                row += 1
            End If
            fdate = tdate(fdate)
            DayLast = idate & "/ " & ldate.Month & "/" & ldate.Year
            idate += 1
            If idate = Date.DaysInMonth(ldate.Year, ldate.Month) + 1 Then
                Exit Do
            End If
        Loop

    End Sub
    Function getlabel(ByVal day As DayOfWeek, ByVal row As Integer) As System.Windows.Forms.Button
        Select Case day
            Case DayOfWeek.Sunday
                Select Case row
                    Case 1
                        Return su1
                    Case 2
                        Return su2
                    Case 3
                        Return su3
                    Case 4
                        Return su4
                    Case 5
                        Return su5
                    Case 6
                        Return su6
                End Select
            Case DayOfWeek.Monday
                Select Case row
                    Case 1
                        Return m1
                    Case 2
                        Return m2
                    Case 3
                        Return m3
                    Case 4
                        Return m4
                    Case 5
                        Return m5
                    Case 6
                        Return m6
                End Select
            Case DayOfWeek.Tuesday
                Select Case row
                    Case 1
                        Return tu1
                    Case 2
                        Return tu2
                    Case 3
                        Return tu3
                    Case 4
                        Return tu4
                    Case 5
                        Return tu5
                    Case 6
                        Return tu6
                End Select
            Case DayOfWeek.Wednesday
                Select Case row
                    Case 1
                        Return w1
                    Case 2
                        Return w2
                    Case 3
                        Return w3
                    Case 4
                        Return w4
                    Case 5
                        Return w5
                    Case 6
                        Return w6
                End Select
            Case DayOfWeek.Thursday
                Select Case row
                    Case 1
                        Return th1
                    Case 2
                        Return th2
                    Case 3
                        Return th3
                    Case 4
                        Return th4
                    Case 5
                        Return th5
                    Case 6
                        Return th6
                End Select
            Case DayOfWeek.Friday
                Select Case row
                    Case 1
                        Return f1
                    Case 2
                        Return f2
                    Case 3
                        Return f3
                    Case 4
                        Return f4
                    Case 5
                        Return f5
                    Case 6
                        Return f6
                End Select
            Case DayOfWeek.Saturday
                Select Case row
                    Case 1
                        Return sa1
                    Case 2
                        Return sa2
                    Case 3
                        Return sa3
                    Case 4
                        Return sa4
                    Case 5
                        Return sa5
                    Case 6
                        Return sa6
                End Select
        End Select

    End Function
    Function GetLastDayOfMonth(ByVal CurrentDate As DateTime) As DateTime
        With CurrentDate
            Return (New DateTime(.Year, .Month, Date.DaysInMonth(.Year, .Month)))
        End With
    End Function
    Function GetFirstDayOfMonth(ByVal CurrentDate As DateTime) As DateTime
        Return (New DateTime(CurrentDate.Year, CurrentDate.Month, 1))
    End Function
    Private Function GetFirstOfMonthDay(ByVal ThisDay As Date) As DayOfWeek
        Dim tday As DayOfWeek = ThisDay.DayOfWeek
        Dim tint As Integer = ThisDay.Day
        If tint = 1 Then
            Return tday
            Exit Function
        End If
        Do
            tint -= 1
            tday = ydate(tday)
            If tint = 1 Then Exit Do
        Loop
        Return tday
        ' MsgBox(tday)
    End Function

    Private Function ydate(ByVal tday As DayOfWeek) As DayOfWeek
        Dim rday As DayOfWeek
        Select Case tday
            Case DayOfWeek.Sunday
                rday = DayOfWeek.Saturday
            Case DayOfWeek.Monday
                rday = DayOfWeek.Sunday
            Case DayOfWeek.Tuesday
                rday = DayOfWeek.Monday
            Case DayOfWeek.Wednesday
                rday = DayOfWeek.Tuesday
            Case DayOfWeek.Thursday
                rday = DayOfWeek.Wednesday
            Case DayOfWeek.Friday
                rday = DayOfWeek.Thursday
            Case DayOfWeek.Saturday
                rday = DayOfWeek.Friday
        End Select
        Return rday
    End Function

    Private Function tdate(ByVal tday As DayOfWeek) As DayOfWeek
        Dim rday As DayOfWeek
        Select Case tday
            Case DayOfWeek.Sunday
                rday = DayOfWeek.Monday
            Case DayOfWeek.Monday
                rday = DayOfWeek.Tuesday
            Case DayOfWeek.Tuesday
                rday = DayOfWeek.Wednesday
            Case DayOfWeek.Wednesday
                rday = DayOfWeek.Thursday
            Case DayOfWeek.Thursday
                rday = DayOfWeek.Friday
            Case DayOfWeek.Friday
                rday = DayOfWeek.Saturday
            Case DayOfWeek.Saturday
                rday = DayOfWeek.Sunday
        End Select
        Return rday
    End Function


    Sub clearall()
        su1.Text = ""
        su2.Text = ""
        su3.Text = ""
        su4.Text = ""
        su5.Text = ""
        su6.Text = ""

        m1.Text = ""
        m2.Text = ""
        m3.Text = ""
        m4.Text = ""
        m5.Text = ""
        m6.Text = ""

        tu1.Text = ""
        tu2.Text = ""
        tu3.Text = ""
        tu4.Text = ""
        tu5.Text = ""
        tu6.Text = ""

        w1.Text = ""
        w2.Text = ""
        w3.Text = ""
        w4.Text = ""
        w5.Text = ""
        w6.Text = ""

        th1.Text = ""
        th2.Text = ""
        th3.Text = ""
        th4.Text = ""
        th5.Text = ""
        th6.Text = ""

        f1.Text = ""
        f2.Text = ""
        f3.Text = ""
        f4.Text = ""
        f5.Text = ""
        f6.Text = ""

        sa1.Text = ""
        sa2.Text = ""
        sa3.Text = ""
        sa4.Text = ""
        sa5.Text = ""
        sa6.Text = ""

        su1.Text = ""
        su2.Text = ""
        su3.Text = ""
        su4.Text = ""
        su5.Text = ""
        su6.Text = ""

        m1.Text = ""
        m2.Text = ""
        m3.Text = ""
        m4.Text = ""
        m5.Text = ""
        m6.Text = ""

        tu1.Text = ""
        tu2.Text = ""
        tu3.Text = ""
        tu4.Text = ""
        tu5.Text = ""
        tu6.Text = ""

        w1.Text = ""
        w2.Text = ""
        w3.Text = ""
        w4.Text = ""
        w5.Text = ""
        w6.Text = ""

        th1.Enabled = False
        th2.Enabled = False
        th3.Enabled = False
        th4.Enabled = False
        th5.Enabled = False
        th6.Enabled = False

        f1.Enabled = False
        f2.Enabled = False
        f3.Enabled = False
        f4.Enabled = False
        f5.Enabled = False
        f6.Enabled = False

        sa1.Enabled = False
        sa2.Enabled = False
        sa3.Enabled = False
        sa4.Enabled = False
        sa5.Enabled = False
        sa6.Enabled = False

        su1.Enabled = False
        su2.Enabled = False
        su3.Enabled = False
        su4.Enabled = False
        su5.Enabled = False
        su6.Enabled = False

        m1.Enabled = False
        m2.Enabled = False
        m3.Enabled = False
        m4.Enabled = False
        m5.Enabled = False
        m6.Enabled = False

        tu1.Enabled = False
        tu2.Enabled = False
        tu3.Enabled = False
        tu4.Enabled = False
        tu5.Enabled = False
        tu6.Enabled = False

        w1.Enabled = False
        w2.Enabled = False
        w3.Enabled = False
        w4.Enabled = False
        w5.Enabled = False
        w6.Enabled = False
    End Sub

    Public Function monthstr(ByVal month As Integer) As String
        Select Case month
            Case 1
                Return "January-มกราคม"
            Case 2
                Return "Febuary-กุมภาพันธ์"
            Case 3
                Return "March-มีนาคม"
            Case 4
                Return "April-เมษายน"
            Case 5
                Return "May-พฤษภาคม"
            Case 6
                Return "June-มิถุนายน"
            Case 7
                Return "July-กรกฏาคม"
            Case 8
                Return "August-สิงหาคม"
            Case 9
                Return "September-กันยายน"
            Case 10
                Return "October-ตุลาคม"
            Case 11
                Return "November-พฤศจิกายน"
            Case 12
                Return "December-ธันวาคม"
        End Select
    End Function

    Private Sub year1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles year1.Click

    End Sub
    Private Sub MonthName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MonthName.Click

    End Sub
    Private Sub tu3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tu3.Click, tu2.Click, w6.Click, w5.Click, w4.Click, w3.Click, w2.Click, w1.Click, tu6.Click, tu5.Click, tu4.Click, tu1.Click, th6.Click, th5.Click, th4.Click, th3.Click, th2.Click, th1.Click, su6.Click, su5.Click, su4.Click, su3.Click, su2.Click, su1.Click, sa6.Click, sa5.Click, sa4.Click, sa3.Click, sa2.Click, sa1.Click, m6.Click, m5.Click, m4.Click, m3.Click, m2.Click, m1.Click, f6.Click, f5.Click, f4.Click, f3.Click, f2.Click, f1.Click
        Dim bButton As Button = CType(sender, Button)
        For i As Integer = 0 To Panel1.Controls.Count - 1
            If Trim(bButton.Text) <> Trim(Panel1.Controls.Item(i).Text) Then
                Panel1.Controls.Item(i).BackColor = Color.Empty
                Panel1.Controls.Item(i).ForeColor = Color.Black
            Else
                Panel1.Controls.Item(i).BackColor = Color.Blue
                Panel1.Controls.Item(i).ForeColor = Color.Black
            End If
        Next
        dateSel = Trim(bButton.Text)
        DateSelect = dateSel & "/" & monthSel & "/" & yearSel
    End Sub

    Private Sub btn_enterdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_enterdate.Click

        Dim strN() As String
        Dim date1 As String
        If DateSelect <> "" Then
            strN = DateSelect.Split("/")
            If strN(2) > 2450 Then
                strN(2) = strN(2) - 543
            Else
                strN(2) = strN(2)
            End If
            date1 = strN(2) & "-" & strN(1) & "-" & strN(0) & " 00:00:00"
            Login.DateData = strN(2) & "-" & strN(1) & "-" & strN(0)
            If CInt(Login.DateData.ToString("yyyy")) > 2450 Then
                Login.DateData = CInt(Login.DateData.ToString("yyyy")) - 543 & Login.DateData.ToString("-MM-dd HH:mm:ss")
            Else
                Login.DateData = Login.DateData.ToString("yyyy-MM-dd HH:mm:ss")
            End If

            Dim qty As MySqlDataReader = con.mysql_query("SELECT DateSel FROM pos_closebill ")
            Dim g As String = "0"
            While qty.Read()
                If qty.GetString("DateSel") <> "0" Then
                    g = "1"
                Else
                    g = "0"
                End If
            End While
            If g = "0" Then
                Dim insertDate As Boolean = con.mysql_query("UPDATE pos_closebill SET create_date='" & date1 & "',DateSelBy='" & Login.username & "',DateSel='1',active='1' WHERE DateSel='0'")
                If insertDate = True Then
                    Login.SelectDate = True
                    MessageBox.Show("เลือกวันที่ทำการขายเรียบร้อย", "Message Alert", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                    'index.Show()
                End If
            End If

        End If

    End Sub
End Class