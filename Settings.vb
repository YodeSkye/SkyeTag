
Imports SkyeTag.My

Partial Friend Class Settings

    ' Declarations
    Private mMove As Boolean = False
    Private mOffset, mPosition As Point

    ' Form Events
    Public Sub New()

        InitializeComponent()

        ' Form Settings
        Text = "Settings For " + My.Application.Info.ProductName
        If App.frmMain Is Nothing Then
            StartPosition = FormStartPosition.CenterScreen
        Else
            Location = New Point(CInt(App.frmMain.Left + (App.frmMain.Width / 2) - (Width / 2)), CInt(App.frmMain.Top + (App.frmMain.Height / 2) - (Height / 2)))
        End If

        ' Control Settings
        chkboxSaveMetrics.Checked = App.Settings.SaveMetrics

    End Sub
    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        Try
            Select Case m.Msg
                Case Skye.WinAPI.WM_SYSCOMMAND
                    Select Case CInt(m.WParam)
                        Case Skye.WinAPI.SC_CLOSE : My.App.CloseSettings()
                        Case Else : MyBase.WndProc(m)
                    End Select
                Case Else : MyBase.WndProc(m)
            End Select
        Catch ex As Exception : My.App.WriteToLog("MainForm WndProc Handler Error" + Chr(13) + ex.ToString)
        End Try
    End Sub
    Private Sub Frm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        App.SaveSettings()
    End Sub
    Private Sub Frm_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles MyBase.MouseDown
        '	Dim cSender As Control
        If e.Button = MouseButtons.Left AndAlso Me.WindowState = FormWindowState.Normal Then
            mMove = True
            'cSender = DirectCast(sender, Control)
            'If cSender Is chkboxSaveMetrics Then
            '	mOffset = New Point(-e.X - cSender.Left - SystemInformation.FrameBorderSize.Width - 4, -e.Y - cSender.Top - SystemInformation.FrameBorderSize.Height - SystemInformation.CaptionHeight - 4)
            'Else
            mOffset = New Point(-e.X - SystemInformation.FrameBorderSize.Width - 4, -e.Y - SystemInformation.FrameBorderSize.Height - SystemInformation.CaptionHeight - 4)
            'End If
        End If
    End Sub
    Private Sub Frm_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles MyBase.MouseMove
        If mMove Then
            mPosition = Control.MousePosition
            mPosition.Offset(mOffset.X, mOffset.Y)
            CheckMove(mPosition)
            Location = mPosition
        End If
    End Sub
    Private Sub Frm_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles MyBase.MouseUp
        mMove = False
    End Sub
    Private Sub Frm_Move(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Move
        If Not mMove AndAlso Me.WindowState = FormWindowState.Normal Then CheckMove(Me.Location)
    End Sub
    Private Sub Frm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyData
            Case Keys.W Or Keys.Control
                App.CloseSettings()
            Case Keys.W Or Keys.Control Or Keys.Shift, Keys.Escape
                WindowState = FormWindowState.Minimized
        End Select
    End Sub

    ' Control Events
    Private Sub ChkboxSaveMetrics_Click(sender As Object, e As EventArgs) Handles chkboxSaveMetrics.Click
        App.Settings.SaveMetrics = chkboxSaveMetrics.Checked
        App.Settings.NeedsSaved = True
        Me.btnClose.Focus()
    End Sub
    Private Sub BtnCloseClick(sender As Object, e As EventArgs) Handles btnClose.Click
        App.CloseSettings()
    End Sub

    ' Methods
    Private Sub CheckMove(ByRef location As Point)
        If location.X + Width > My.Computer.Screen.WorkingArea.Right Then location.X = My.Computer.Screen.WorkingArea.Right - Width + App.AdjustScreenBoundsDialogWindow
        If location.Y + Height > My.Computer.Screen.WorkingArea.Bottom Then location.Y = My.Computer.Screen.WorkingArea.Bottom - Height + App.AdjustScreenBoundsDialogWindow
        If location.X < My.Computer.Screen.WorkingArea.Left Then location.X = My.Computer.Screen.WorkingArea.Left - App.AdjustScreenBoundsDialogWindow
        If location.Y < App.AdjustScreenBoundsDialogWindow Then location.Y = My.Computer.Screen.WorkingArea.Top
    End Sub

End Class
