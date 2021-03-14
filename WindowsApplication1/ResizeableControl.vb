Public Class ResizeableControl

    Private WithEvents mControl As Control
    Private Property Panel As Panel
    Private mMouseDown As Boolean = False
    Private mEdge As EdgeEnum = EdgeEnum.None
    Private mWidth As Integer = 4
    Private mOutlineDrawn As Boolean = False
    Private ClickOffsetX, ClickOffsetY As Integer
    Private w, h As Integer

    Private Enum EdgeEnum
        None
        Right
        Left
        Top
        Bottom
        TopLeft
    End Enum

    Public Sub New(ByVal mpanel As Panel, ByVal Control As Control)
        mControl = Control
        Panel = mpanel
    End Sub

    Private Sub mControl_MouseDown(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.MouseEventArgs) _
        Handles mControl.MouseDown

        If e.Button = Windows.Forms.MouseButtons.Left Then
            mMouseDown = True
            ClickOffsetX = e.X
            ClickOffsetY = e.Y
        End If
    End Sub

    Private Sub mControl_MouseUp(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.MouseEventArgs) _
        Handles mControl.MouseUp

        mMouseDown = False
    End Sub

    Private Sub mControl_MouseMove(ByVal sender As Object, _
    ByVal e As System.Windows.Forms.MouseEventArgs) _
    Handles mControl.MouseMove

        Dim c As Control = CType(sender, Control)
        Dim g As Graphics = c.CreateGraphics
        Select Case mEdge
            Case EdgeEnum.TopLeft
                'g.FillRectangle(Brushes.Fuchsia, 0, 0, mWidth * 4, mWidth * 4)
                mOutlineDrawn = True
            Case EdgeEnum.Left
                g.FillRectangle(Brushes.Black, 0, 0, mWidth, c.Height)
                mOutlineDrawn = True
            Case EdgeEnum.Right
                g.FillRectangle(Brushes.Black, c.Width - mWidth, 0, c.Width, c.Height)
                mOutlineDrawn = True
            Case EdgeEnum.Top
                g.FillRectangle(Brushes.Black, 0, 0, c.Width, mWidth)
                mOutlineDrawn = True
            Case EdgeEnum.Bottom
                g.FillRectangle(Brushes.Black, 0, c.Height - mWidth, c.Width, mWidth)
                mOutlineDrawn = True
            Case EdgeEnum.None
                If mOutlineDrawn Then
                    c.Refresh()
                    mOutlineDrawn = False
                End If
        End Select

        If mMouseDown And mEdge <> EdgeEnum.None Then
            c.SuspendLayout()
            Select Case mEdge
                Case EdgeEnum.TopLeft
                    If (c.Left + e.X - ClickOffsetX) >= 0 And (c.Left + c.Width + e.X - ClickOffsetX) <= Panel.Width Then
                        c.SetBounds(c.Left + e.X - ClickOffsetX, c.Top, c.Width, c.Height)
                    End If
                    If (c.Top + e.Y - ClickOffsetY) >= 0 And (c.Top + e.Y + c.Height - ClickOffsetY) <= Panel.Height Then
                        c.SetBounds(c.Left, c.Top + e.Y - ClickOffsetY, c.Width, c.Height)
                    End If
                Case EdgeEnum.Left
                    If c.Left + e.X >= 0 And c.Width - e.X > 20 Then
                        c.SetBounds(c.Left + e.X, c.Top, c.Width - e.X, c.Height)
                    End If
                Case EdgeEnum.Right
                    If Panel.Width - c.Left >= c.Width - (c.Width - e.X) And (c.Width - (c.Width - e.X)) > 20 Then
                        c.SetBounds(c.Left, c.Top, c.Width - (c.Width - e.X), c.Height)
                    End If
                Case EdgeEnum.Top
                    If c.Top + e.Y >= 0 And c.Height - e.Y > 20 Then
                        c.SetBounds(c.Left, c.Top + e.Y, c.Width, c.Height - e.Y)
                    End If
                Case EdgeEnum.Bottom
                    If Panel.Height - c.Top >= c.Height - (c.Height - e.Y) And c.Height - (c.Height - e.Y) > 20 Then
                        c.SetBounds(c.Left, c.Top, c.Width, c.Height - (c.Height - e.Y))
                    End If
            End Select
            c.ResumeLayout()
        Else
            Select Case True
                'Case e.X <= (mWidth * 4) And _
                '    e.Y <= (mWidth * 4) 'top left corner
                '    c.Cursor = Cursors.SizeAll
                '    mEdge = EdgeEnum.TopLeft
                Case e.X <= mWidth 'left edge
                    c.Cursor = Cursors.VSplit
                    mEdge = EdgeEnum.Left
                Case e.X > c.Width - (mWidth + 1) 'right edge
                    c.Cursor = Cursors.VSplit
                    mEdge = EdgeEnum.Right
                Case e.Y <= mWidth 'top edge
                    c.Cursor = Cursors.HSplit
                    mEdge = EdgeEnum.Top
                Case e.Y > c.Height - (mWidth + 1) 'bottom edge
                    c.Cursor = Cursors.HSplit
                    mEdge = EdgeEnum.Bottom
                Case Else 'no edge
                    'c.Cursor = Cursors.Default
                    'mEdge = EdgeEnum.None
                    c.Cursor = Cursors.SizeAll
                    mEdge = EdgeEnum.TopLeft
            End Select
        End If
    End Sub

    Private Sub mControl_MouseLeave(ByVal sender As Object, _
        ByVal e As System.EventArgs) _
        Handles mControl.MouseLeave

        Dim c As Control = CType(sender, Control)
        mEdge = EdgeEnum.None
        c.Refresh()
    End Sub

End Class
