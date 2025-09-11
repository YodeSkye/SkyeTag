
Imports SkyeTag.My

Public Class Log

    'Declarations
    Private mMove As Boolean = False
    Private mOffset, mPosition As Point
    Private RTxBoxCM As New Skye.UI.RichTextBoxContextMenu
    Private LogSearchTitle As String
    Private LogSearchInActiveColor As Color
    Private DeleteLogConfirm As Boolean = False
    Private WithEvents timerDeleteLog As New Timer

    'Form Events
    Private Sub frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Initialize
        timerDeleteLog.Interval = 5000
        LogSearchTitle = TxbxSearch.Text
        LogSearchInActiveColor = TxbxSearch.ForeColor
        RTxBoxLog.ContextMenuStrip = RTxBoxCM

        'Center in FrmMain
        Left = CType((frmMain.Left + frmMain.Width / 2) - Width / 2, Integer)
        Top = CType((frmMain.Top + frmMain.Height / 2) - Height / 2, Integer)
        If Left < 0 Then Left = 0
        If Top < 0 Then Top = 0
        If Right > My.Computer.Screen.WorkingArea.Width Then Left = My.Computer.Screen.WorkingArea.Width - Width
        If Bottom > My.Computer.Screen.WorkingArea.Height Then Top = My.Computer.Screen.WorkingArea.Height - Height

    End Sub
    Private Sub Log_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        App.FrmLog.Dispose()
        App.FrmLog = Nothing
    End Sub
    Private Sub frm_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown, Lblnfo.MouseDown
        Dim cSender As Control
        If e.Button = MouseButtons.Left AndAlso Me.WindowState = FormWindowState.Normal Then
            mMove = True
            cSender = DirectCast(sender, Control)
            If cSender Is Lblnfo Then
                mOffset = New Point(-e.X - cSender.Left - SystemInformation.FrameBorderSize.Width - 4, -e.Y - cSender.Top - SystemInformation.FrameBorderSize.Height - SystemInformation.CaptionHeight - 4)
            Else : mOffset = New Point(-e.X - SystemInformation.FrameBorderSize.Width - 4, -e.Y - SystemInformation.FrameBorderSize.Height - SystemInformation.CaptionHeight - 4)
            End If
        End If
        cSender = Nothing
    End Sub
    Private Sub frm_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove, Lblnfo.MouseMove
        If mMove Then
            mPosition = Control.MousePosition
            mPosition.Offset(mOffset.X, mOffset.Y)
            CheckMove(mPosition)
            Location = mPosition
        End If
    End Sub
    Private Sub frm_MouseUp(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp, Lblnfo.MouseUp
        mMove = False
    End Sub
    Private Sub frm_Move(sender As Object, e As EventArgs) Handles MyBase.Move
        If Not mMove AndAlso Me.WindowState = FormWindowState.Normal Then
            CheckMove(Me.Location)
        End If
    End Sub
    Private Sub Log_DoubleClick(sender As Object, e As EventArgs) Handles MyBase.DoubleClick, LblSearch.DoubleClick
        ToggleMaximized()
    End Sub
    Private Sub frm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyData
            Case Keys.W Or Keys.Control
                Close()
            Case Keys.W Or Keys.Control Or Keys.Shift, Keys.Escape
                ResetRTxBoxLogFind()
                RTxBoxLog.Focus()
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
        End If
        SetDeleteLogConfirm()
    End Sub
    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        SetDeleteLogConfirm(True)
        App.ShowLog()
    End Sub
    Private Sub Lblnfo_DoubleClick(sender As Object, e As EventArgs) Handles Lblnfo.DoubleClick
        App.OpenFileLocation(LogPath)
    End Sub
    Private Sub RTxBoxLog_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles RTxBoxLog.PreviewKeyDown
        RTxBoxCM.ShortcutKeys(DirectCast(sender, RichTextBox), e)
    End Sub
    Private Sub TxBxSearch_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxbxSearch.KeyPress
        Select Case e.KeyChar
            Case Convert.ToChar(Keys.Escape)
                ResetRTxBoxLogFind()
                RTxBoxLog.Focus()
                e.Handled = True
        End Select
    End Sub
    Private Sub TxBxSearch_Enter(sender As Object, e As EventArgs) Handles TxbxSearch.Enter
        If TxbxSearch.Text = LogSearchTitle Then TxbxSearch.ResetText()
    End Sub
    Private Sub TxBxSearch_Leave(sender As Object, e As EventArgs) Handles TxbxSearch.Leave
        TxbxSearch.Text = LogSearchTitle
        TxbxSearch.ForeColor = LogSearchInActiveColor
    End Sub
    Private Sub TxBxSearch_TextChanged(sender As Object, e As EventArgs) Handles TxbxSearch.TextChanged
        If TxbxSearch.Text Is String.Empty Or RTxBoxLog.Focused Then
            ResetRTxBoxLogFind()
        ElseIf TxbxSearch.Text.Length <= 4 Then
            TxbxSearch.ResetForeColor()
            ResetRTxBoxLogFind()
        ElseIf Not TxbxSearch.Text = LogSearchTitle AndAlso TxbxSearch.Text.Length > 4 AndAlso IsHandleCreated Then
            Debug.Print("Searching Log...")
            LblSearch.Visible = True
            LblSearch.Refresh()
            Dim foundindex As Integer
            Dim searchtext As String = RTxBoxLog.Text
            ResetRTxBoxLogFind()
            'Try To Find First Occurrence
            foundindex = searchtext.IndexOf(TxbxSearch.Text, 0, StringComparison.CurrentCultureIgnoreCase)
            If foundindex < 0 Then
                TxbxSearch.ForeColor = Color.Red
            Else
                TxbxSearch.ResetForeColor()
                RTxBoxLog.Select(foundindex, 0)
                RTxBoxLog.ScrollToCaret()
            End If
            Do Until foundindex < 0
                'Highlight Current Match
                RTxBoxLog.SelectionStart = foundindex
                RTxBoxLog.SelectionLength = TxbxSearch.Text.Length
                RTxBoxLog.SelectionBackColor = RTxBoxLog.ForeColor
                RTxBoxLog.SelectionColor = RTxBoxLog.BackColor
                'Try To Find Next Occurrence
                foundindex = searchtext.IndexOf(TxbxSearch.Text, foundindex + TxbxSearch.Text.Length, StringComparison.CurrentCultureIgnoreCase)
            Loop
            LblSearch.Visible = False
        End If
    End Sub
    Private Sub tipInfo_Popup(sender As Object, e As PopupEventArgs) Handles tipInfo.Popup
        Static s As Size
        s = TextRenderer.MeasureText(tipInfo.GetToolTip(e.AssociatedControl), App.TipFont)
        s.Width += 14
        s.Height += 14
        e.ToolTipSize = s
    End Sub
    Private Sub tipInfo_Draw(sender As Object, e As DrawToolTipEventArgs) Handles tipInfo.Draw

        'Declarations
        Dim g As Graphics = e.Graphics

        'Draw background
        Dim brbg As New SolidBrush(App.TipBackColor)
        g.FillRectangle(brbg, e.Bounds)

        'Draw border
        Using p As New Pen(App.TipBorderColor, CInt(App.TipFont.Size / 4)) 'Scale border thickness with font
            g.DrawRectangle(p, 0, 0, e.Bounds.Width - 1, e.Bounds.Height - 1)
        End Using

        'Draw text
        TextRenderer.DrawText(g, e.ToolTipText, App.TipFont, New Point(7, 7), App.TipTextColor)

        'Finalize
        brbg.Dispose()
        g.Dispose()

    End Sub

    'Handlers
    Private Sub timerDeleteLog_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles timerDeleteLog.Tick
        SetDeleteLogConfirm()
    End Sub

    'Procedures
    Private Sub SetDeleteLogConfirm(Optional forcereset As Boolean = False)
        If DeleteLogConfirm Or forcereset Then
            timerDeleteLog.Stop()
            DeleteLogConfirm = False
            Me.BtnDelete.ResetBackColor()
            tipInfo.Hide(Me)
        Else
            DeleteLogConfirm = True
            Me.BtnDelete.BackColor = Color.Red
            tipInfo.Show("Are You Sure?", Me, BtnDelete.Location)
            timerDeleteLog.Start()
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
    Private Sub ResetRTxBoxLogFind()
        RTxBoxLog.SelectAll()
        RTxBoxLog.SelectionBackColor = SystemColors.Window
        RTxBoxLog.SelectionColor = SystemColors.WindowText
        RTxBoxLog.DeselectAll()
        RTxBoxLog.SelectionStart = RTxBoxLog.TextLength
        RTxBoxLog.SelectionLength = 0
        RTxBoxLog.ScrollToCaret()
    End Sub
    Private Sub CheckMove(ByRef location As Point)
        If location.X + Width > My.Computer.Screen.WorkingArea.Right Then location.X = My.Computer.Screen.WorkingArea.Right - Width + App.AdjustScreenBoundsNormalWindow
        If location.Y + Height > My.Computer.Screen.WorkingArea.Bottom Then location.Y = My.Computer.Screen.WorkingArea.Bottom - Height + App.AdjustScreenBoundsNormalWindow
        If location.X < My.Computer.Screen.WorkingArea.Left Then location.X = My.Computer.Screen.WorkingArea.Left - App.AdjustScreenBoundsNormalWindow
        If location.Y < App.AdjustScreenBoundsNormalWindow Then location.Y = My.Computer.Screen.WorkingArea.Top
    End Sub

End Class
