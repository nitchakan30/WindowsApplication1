Public Class MoveWindows
    Private WithEvents mControl As Control
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

    Public Sub New(ByVal Control As Control)
        mControl = Control
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
        If mMouseDown = True Then
            If (index.Left + e.X - ClickOffsetX) >= 0 And (index.Left + index.Width + e.X - ClickOffsetX) <= Screen.PrimaryScreen.Bounds.Width Then
                index.SetBounds(index.Left + e.X - ClickOffsetX, index.Top, index.Width, index.Height)
            End If
            If (index.Top + e.Y - ClickOffsetY) >= 0 And (index.Top + e.Y + index.Height - ClickOffsetY) <= Screen.PrimaryScreen.Bounds.Height Then
                index.SetBounds(index.Left, index.Top + e.Y - ClickOffsetY, index.Width, index.Height)
            End If
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
