
Imports SkyeTag.My

Public Class Log

    'Declarations
    Private mMove As Boolean = False
    Private mOffset, mPosition As Point
    Private DeleteLogConfirm As Boolean = False
    Private WithEvents TimerDeleteLog As New Timer

    'Form Events
    Private Sub Frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Initialize
        TimerDeleteLog.Interval = 5000
        Lblnfo.Text = Skye.Common.Log.LogFilePath
        Skye.UI.ThemeManager.RegisterComponent(tipInfo)
        Skye.UI.ThemeManager.RegisterComponent(tipAlert)
        Skye.UI.ThemeManager.ApplyTheme(Me)

        'Center in FrmMain
        Left = CType((FrmMain.Left + FrmMain.Width / 2) - Width / 2, Integer)
        Top = CType((FrmMain.Top + FrmMain.Height / 2) - Height / 2, Integer)
        If Left < 0 Then Left = 0
        If Top < 0 Then Top = 0
        If Right > My.Computer.Screen.WorkingArea.Width Then Left = My.Computer.Screen.WorkingArea.Width - Width
        If Bottom > My.Computer.Screen.WorkingArea.Height Then Top = My.Computer.Screen.WorkingArea.Height - Height

    End Sub
    Private Sub Frm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        App.FrmLog.Dispose()
        App.FrmLog = Nothing
    End Sub
    Private Sub Frm_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown, Lblnfo.MouseDown
        Dim cSender As Control
        If e.Button = MouseButtons.Left AndAlso Me.WindowState = FormWindowState.Normal Then
            mMove = True
            cSender = DirectCast(sender, Control)
            If cSender Is Lblnfo Then
                mOffset = New Point(-e.X - cSender.Left - SystemInformation.FrameBorderSize.Width - 4, -e.Y - cSender.Top - SystemInformation.FrameBorderSize.Height - SystemInformation.CaptionHeight - 4)
            Else : mOffset = New Point(-e.X - SystemInformation.FrameBorderSize.Width - 4, -e.Y - SystemInformation.FrameBorderSize.Height - SystemInformation.CaptionHeight - 4)
            End If
        End If
    End Sub
    Private Sub Frm_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove, Lblnfo.MouseMove
        If mMove Then
            mPosition = Control.MousePosition
            mPosition.Offset(mOffset.X, mOffset.Y)
            CheckMove(mPosition)
            Location = mPosition
        End If
    End Sub
    Private Sub Frm_MouseUp(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp, Lblnfo.MouseUp
        mMove = False
    End Sub
    Private Sub Frm_Move(sender As Object, e As EventArgs) Handles MyBase.Move
        If Not mMove AndAlso Me.WindowState = FormWindowState.Normal Then
            CheckMove(Me.Location)
        End If
    End Sub
    Private Sub Frm_DoubleClick(sender As Object, e As EventArgs) Handles MyBase.DoubleClick
        ToggleMaximized
    End Sub
    Private Sub Frm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If DeleteLogConfirm Then
            App.DeleteLog()
            LogViewer.RefreshContent()
        End If
        SetDeleteLogConfirm()
    End Sub
    Private Sub Lblnfo_DoubleClick(sender As Object, e As EventArgs) Handles Lblnfo.DoubleClick
        App.OpenFileLocation(Skye.Common.Log.LogFilePath)
    End Sub

    'Handlers
    Private Sub TimerDeleteLog_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles TimerDeleteLog.Tick
        SetDeleteLogConfirm()
    End Sub

    'Procedures
    Private Sub SetDeleteLogConfirm(Optional forcereset As Boolean = False)
        If DeleteLogConfirm Or forcereset Then
            TimerDeleteLog.Stop()
            DeleteLogConfirm = False
            Me.BtnDelete.ResetBackColor()
            tipAlert.HideTooltip()
        Else
            DeleteLogConfirm = True
            Me.BtnDelete.BackColor = Color.Red
            tipInfo.HideTooltip()
            tipAlert.ShowTooltipAtCursor("Are You Sure?")
            TimerDeleteLog.Start()
        End If
    End Sub
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
