
Imports SkyeTag.My

Public Class Help

    'Declarations
    Private mMove As Boolean = False
    Private mOffset, mPosition As Point
    Private RTxBoxCM As New My.Components.RichTextBoxContextMenu

    'Form Events
    Private Sub frm_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown, LblVersion.MouseDown
        Dim cSender As Control
        If e.Button = MouseButtons.Left AndAlso Me.WindowState = FormWindowState.Normal Then
            mMove = True
            cSender = DirectCast(sender, Control)
            If cSender Is LblVersion Then
                mOffset = New Point(-e.X - cSender.Left - SystemInformation.FrameBorderSize.Width - 4, -e.Y - cSender.Top - SystemInformation.FrameBorderSize.Height - SystemInformation.CaptionHeight - 4)
            Else : mOffset = New Point(-e.X - SystemInformation.FrameBorderSize.Width - 4, -e.Y - SystemInformation.FrameBorderSize.Height - SystemInformation.CaptionHeight - 4)
            End If
        End If
        cSender = Nothing
    End Sub
    Private Sub frm_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove, LblVersion.MouseMove
        If mMove Then
            mPosition = Control.MousePosition
            mPosition.Offset(mOffset.X, mOffset.Y)
            CheckMove(mPosition)
            Location = mPosition
        End If
    End Sub
    Private Sub frm_MouseUp(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp, LblVersion.MouseUp
        mMove = False
    End Sub
    Private Sub frm_Move(sender As Object, e As EventArgs) Handles MyBase.Move
        If Not mMove AndAlso Me.WindowState = FormWindowState.Normal Then
            CheckMove(Me.Location)
        End If
    End Sub
    Private Sub Help_DoubleClick(sender As Object, e As EventArgs) Handles MyBase.DoubleClick, LblVersion.DoubleClick
        ToggleMaximized()
    End Sub
    Private Sub frm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyData
            Case Keys.W Or Keys.Control
                Close()
            Case Keys.W Or Keys.Control Or Keys.Shift, Keys.Escape
                WindowState = FormWindowState.Minimized
            Case Keys.F12
                ToggleMaximized()
        End Select
    End Sub

    'Control Events
    Private Sub RTxBoxHelp_MouseUp(sender As Object, e As MouseEventArgs) Handles RTxBoxHelp.MouseUp
        RTxBoxCM.Display(CType(sender, RichTextBox), e)
    End Sub
    Private Sub RTxBoxHelp_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles RTxBoxHelp.PreviewKeyDown
        RTxBoxCM.ShortcutKeys(CType(sender, RichTextBox), e)
    End Sub
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    'Procedures
    Private Sub ToggleMaximized()
        Select Case WindowState
            Case FormWindowState.Normal
                WindowState = FormWindowState.Maximized
            Case FormWindowState.Maximized, FormWindowState.Minimized
                WindowState = FormWindowState.Normal
        End Select
    End Sub
    Private Sub CheckMove(ByRef location As Point)
        If location.X + Width > My.Computer.Screen.WorkingArea.Right Then location.X = My.Computer.Screen.WorkingArea.Right - Width + App.AdjustScreenBoundsNormalWindow
        If location.Y + Height > My.Computer.Screen.WorkingArea.Bottom Then location.Y = My.Computer.Screen.WorkingArea.Bottom - Height + App.AdjustScreenBoundsNormalWindow
        If location.X < My.Computer.Screen.WorkingArea.Left Then location.X = My.Computer.Screen.WorkingArea.Left - App.AdjustScreenBoundsNormalWindow
        If location.Y < App.AdjustScreenBoundsNormalWindow Then location.Y = My.Computer.Screen.WorkingArea.Top
    End Sub

End Class