
Imports Microsoft.Win32
Imports Skye
Imports SkyeTag.My

Partial Friend Class MainForm

    ' Declarations
    Private Enum RMove
        Left
        First
        Right
        Last
    End Enum
    Private Enum ExportDestination
        File
        BitmapFile
        Clipboard
    End Enum
    Private mMove As Boolean = False
    Private mOffset, mPosition As Point
    Private FrmArtViewer As ArtViewer
    Private wMaximized As Boolean = False
    Private wShowLyrics As Boolean = False
    Private NeedsSaved As Boolean = False
    Private IsFocused As Boolean = True
    Private inDoubleClick As Boolean
    Private lastClick As DateTime
    Private doubleclickMaxTime As TimeSpan
    Private clickTimer As Timer
    Private txtboxCM As New Skye.UI.TextBoxContextMenu
    Private txtboxCMLyrics As New Skye.UI.TextBoxContextMenu
    Private tlFile As TagLib.File
    Private sPerformers As List(Of String)
    Private sTitle As String
    Private sAlbum As String
    Private sGenre As String
    Private sYear As String
    Private sTrack As String
    Private sTrackCount As String
    Private sComment As String
    Private sLyrics As String
    Private sArt As List(Of TagLib.IPicture)
    Private oArtist As String = Nothing
    Private oTitle As String = Nothing
    Private oAlbum As String = Nothing
    Private oGenre As String = Nothing
    Private oYear As String = Nothing
    Private oTrack As String = Nothing
    Private oTrackCount As String = Nothing
    Private oComments As String = Nothing
    Private oLyrics As String = Nothing
    Private oArt As New List(Of TagLib.IPicture)
    Private nArt As New List(Of TagLib.IPicture)
    Private multiMessage As String = "< Keep Original >"
    Private multiMessageShort As String = "< Keep >"
    Private multiMessageShorter As String = "< >"
    Private aggregateconflict As Boolean = False

    ' Form Events
    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        Try
            Select Case m.Msg
                Case Skye.WinAPI.WM_SYSCOMMAND
                    Select Case CInt(m.WParam)
                        Case Skye.WinAPI.SC_MAXIMIZE, Skye.WinAPI.SC_MAXIMIZE_TBAR
                            wMaximized = True
                            SetWindowState()
                        Case Skye.WinAPI.SC_RESTORE, Skye.WinAPI.SC_RESTORE_TBAR
                            If WindowState = FormWindowState.Minimized Then
                                Select Case wMaximized
                                    Case True : WindowState = FormWindowState.Maximized
                                    Case False : WindowState = FormWindowState.Normal
                                End Select
                            Else
                                wMaximized = False
                                SetWindowState()
                            End If
                    End Select
            End Select
        Catch ex As Exception
            App.WriteToLog("WndProc Handler Error" + Chr(13) + ex.ToString)
        Finally
            MyBase.WndProc(m)
        End Try
    End Sub
    Friend Sub New()

        ' Initialize Form
        InitializeComponent()
        Text = My.Application.Info.ProductName
        lblFileInfo.Text = String.Empty
        For Each name As String In [Enum].GetNames(Of TagLib.PictureType)()
            cobxAlbumArtType.Items.Add(name)
        Next
        tipInfo.SetText(btnAlbumArt, App.hArt + " Menu")
        txtboxCM.ShowExtendedTools = True
        txtboxCM.Font = App.CMFont
        txtboxCMLyrics.ShowExtendedTools = False
        txtboxCMLyrics.Font = App.CMFont
        doubleclickMaxTime = TimeSpan.FromMilliseconds(SystemInformation.DoubleClickTime)
        clickTimer = New Timer With {
            .Interval = SystemInformation.DoubleClickTime}
        AddHandler clickTimer.Tick, AddressOf ClickTimer_Tick
        SetLyrics()
        Skye.UI.ThemeManager.RegisterComponent(tipInfo)
        MenuMain.Renderer = New Skye.UI.SkyeMenuRenderer
        cmAlbumArtInsert.Renderer = New Skye.UI.SkyeMenuRenderer
        cmImageSource.Renderer = New Skye.UI.SkyeMenuRenderer
        cmExport.Renderer = New Skye.UI.SkyeMenuRenderer
        txtboxCM.Renderer = New Skye.UI.SkyeMenuRenderer
        txtboxCMLyrics.Renderer = New Skye.UI.SkyeMenuRenderer
        Skye.UI.ThemeManager.ApplyTheme(Me)
#If DEBUG Then
        'Location = App.Settings.StartLocation
        'Size = App.Settings.StartSize
        StartPosition = FormStartPosition.Manual
        Location = New Point(My.Computer.Screen.WorkingArea.Left + CInt(My.Computer.Screen.WorkingArea.Width / 2) - CInt(Width / 2), My.Computer.Screen.WorkingArea.Top + 50)
        btnError.Visible = True
        tipInfo.SetText(btnError, tipInfo.GetText(btnError) + vbCr + "CtrlRightClick = Test Error")
#Else
        If App.Settings.SaveMetrics Then
            StartPosition = FormStartPosition.Manual
            Location = App.Settings.StartLocation
            Size = App.Settings.StartSize
            If App.Settings.IsMaximized Then wMaximized = True
        Else
            StartPosition = FormStartPosition.CenterScreen
        End If
#End If
        SetWindowState()

    End Sub
    Private Sub Frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        txbxTitle.ContextMenuStrip = txtboxCM
        CoBoxGenre.ContextMenuStrip = New ContextMenuStrip
        txbxComments.ContextMenuStrip = txtboxCM
        txbxArtist.ContextMenuStrip = txtboxCM
        txbxAlbum.ContextMenuStrip = txtboxCM
        txbxAlbumArt.ContextMenuStrip = txtboxCM
        txbxLyrics.ContextMenuStrip = txtboxCMLyrics
        CustomDrawToolTip(MIEdit.DropDown)
        LoadTags()
        ActiveControl = lblFileInfo

    End Sub
    Private Sub Frm_Closing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If App.FrmLog IsNot Nothing Then App.FrmLog.Close()
        My.App.Finalize()
    End Sub
    Private Sub Frm_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        Dim g As Graphics = Me.CreateGraphics
        If IsMultiFile Then

            ' Multi-file: always use textbox text
            If g.MeasureString(txbxArtist.Text, txbxArtist.Font).Width > txbxArtist.Width Then
                tipInfo.SetText(txbxArtist, txbxArtist.Text)
            Else
                tipInfo.SetText(txbxArtist, Nothing)
            End If

        Else
            ' Single-file mode
            If txbxArtist.Focused Then
                ' User is editing → use textbox text
                If g.MeasureString(txbxArtist.Text, txbxArtist.Font).Width > txbxArtist.Width Then
                    tipInfo.SetText(txbxArtist, txbxArtist.Text)
                Else
                    tipInfo.SetText(txbxArtist, Nothing)
                End If

            Else
                ' Not editing → use TagLib values
                If tlFile IsNot Nothing Then
                    Dim performerText As String

                    If tlFile.Tag.Performers.Length = 1 Then
                        performerText = txbxArtist.Text
                    ElseIf tlFile.Tag.Performers.Length > 1 Then
                        performerText = tlFile.Tag.JoinedPerformers
                    Else
                        performerText = ""
                    End If

                    If g.MeasureString(performerText, txbxArtist.Font).Width > txbxArtist.Width Then
                        tipInfo.SetText(txbxArtist, performerText)
                    Else
                        tipInfo.SetText(txbxArtist, Nothing)
                    End If
                End If
            End If
        End If
        If g.MeasureString(Me.CoBoxGenre.Text, Me.CoBoxGenre.Font).Width > Me.CoBoxGenre.Width Then
            Me.tipInfo.SetText(Me.CoBoxGenre, Me.CoBoxGenre.Text)
        Else : Me.tipInfo.SetText(Me.CoBoxGenre, Nothing)
        End If
        If g.MeasureString(Me.txbxTitle.Text, Me.txbxTitle.Font).Width > Me.txbxTitle.Width Then
            Me.tipInfo.SetText(Me.txbxTitle, Me.txbxTitle.Text)
        Else : Me.tipInfo.SetText(Me.txbxTitle, Nothing)
        End If
        If g.MeasureString(Me.txbxAlbum.Text, Me.txbxAlbum.Font).Width > Me.txbxAlbum.Width Then
            Me.tipInfo.SetText(Me.txbxAlbum, Me.txbxAlbum.Text)
        Else : Me.tipInfo.SetText(Me.txbxAlbum, Nothing)
        End If
        If g.MeasureString(Me.txbxComments.Text, Me.txbxComments.Font).Width > Me.txbxComments.Width Then
            Me.tipInfo.SetText(Me.txbxComments, Me.txbxComments.Text)
        Else : Me.tipInfo.SetText(Me.txbxComments, Nothing)
        End If
        If g.MeasureString(Me.txbxAlbumArt.Text, Me.txbxAlbumArt.Font).Width > Me.txbxAlbumArt.Width Then
            Me.tipInfo.SetText(Me.txbxAlbumArt, Me.txbxAlbumArt.Text)
        Else : Me.tipInfo.SetText(Me.txbxAlbumArt, Nothing)
        End If
        If tlFile IsNot Nothing AndAlso tlFile.Tag.Pictures.Length > 0 AndAlso g.MeasureString(Me.cobxAlbumArtType.Text, Me.cobxAlbumArtType.Font).Width > Me.cobxAlbumArtType.Width - 15 Then
            Me.tipInfo.SetText(Me.cobxAlbumArtType, Me.cobxAlbumArtType.Text)
        Else : Me.tipInfo.SetText(Me.cobxAlbumArtType, Nothing)
        End If
        g.Dispose()
    End Sub
    Private Sub Frm_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles picbxAlbumArt.MouseDown, MyBase.MouseDown, MenuMain.MouseDown, lblYear.MouseDown, lblTrackSeparator.MouseDown, lblTrack.MouseDown, lblTitle.MouseDown, lblGenre.MouseDown, lblDuration.MouseDown, lblComments.MouseDown, lblArtist.MouseDown, lblAlbumArt.MouseDown, lblAlbum.MouseDown
        Select Case e.Button
            Case MouseButtons.Left
                If WindowState = FormWindowState.Normal Then
                    Dim cSender As Control
                    mMove = True
                    cSender = CType(sender, Control)
                    If cSender Is lblFileInfo OrElse cSender Is Me.lblArtist OrElse cSender Is Me.lblGenre _
                        OrElse cSender Is Me.lblTitle OrElse cSender Is Me.lblTrack OrElse cSender Is Me.lblTrackSeparator OrElse cSender Is Me.lblDuration _
                        OrElse cSender Is Me.lblAlbum OrElse cSender Is Me.lblYear _
                        OrElse cSender Is Me.lblComments OrElse cSender Is Me.lblAlbumArt Then
                        mOffset = New Point(-e.X - cSender.Left - SystemInformation.FrameBorderSize.Width - 4, -e.Y - cSender.Top - SystemInformation.FrameBorderSize.Height - SystemInformation.CaptionHeight - 4)
                    ElseIf cSender Is Me.picbxAlbumArt Then
                        mOffset = New Point(-e.X - Me.panelAlbumArt.Left - SystemInformation.FrameBorderSize.Width - 4, -e.Y - Me.panelAlbumArt.Top - SystemInformation.FrameBorderSize.Height - SystemInformation.CaptionHeight - 4)
                    Else : mOffset = New Point(-e.X - SystemInformation.FrameBorderSize.Width - 4, -e.Y - SystemInformation.FrameBorderSize.Height - SystemInformation.CaptionHeight - 4)
                    End If
                End If
            Case MouseButtons.Right
                If My.Computer.Keyboard.ShiftKeyDown Then
                    Dim pSender As PictureBox = TryCast(sender, PictureBox)
                    If pSender IsNot Nothing AndAlso pSender.Image IsNot Nothing Then
                        tipInfo.HideTooltip()
                        FrmArtViewer = New ArtViewer(pSender.Image, MousePosition) With {.Owner = Me}
                        FrmArtViewer.Show()
                    End If
                End If
        End Select
        If e.Button = MouseButtons.Left AndAlso Me.WindowState = FormWindowState.Normal Then
        End If
    End Sub
    Private Sub Frm_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles picbxAlbumArt.MouseMove, MyBase.MouseMove, MenuMain.MouseMove, lblYear.MouseMove, lblTrackSeparator.MouseMove, lblTrack.MouseMove, lblTitle.MouseMove, lblGenre.MouseMove, lblDuration.MouseMove, lblComments.MouseMove, lblArtist.MouseMove, lblAlbumArt.MouseMove, lblAlbum.MouseMove
        If mMove Then
            mPosition = Control.MousePosition
            mPosition.Offset(mOffset.X, mOffset.Y)
            CheckMove(mPosition)
            Location = mPosition
        End If
    End Sub
    Private Sub Frm_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles picbxAlbumArt.MouseUp, MyBase.MouseUp, MenuMain.MouseUp, lblYear.MouseUp, lblTrackSeparator.MouseUp, lblTrack.MouseUp, lblTitle.MouseUp, lblGenre.MouseUp, lblDuration.MouseUp, lblComments.MouseUp, lblArtist.MouseUp, lblAlbumArt.MouseUp, lblAlbum.MouseUp
        mMove = False
        If e.Button = MouseButtons.Right Then
            FrmArtViewer?.Close()
        End If
    End Sub
    Private Sub Frm_Move(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Move
        If Not mMove AndAlso Me.WindowState = FormWindowState.Normal Then
            CheckMove(Me.Location)
        End If
    End Sub
    Private Sub Frm_LocationChanged(sender As Object, e As EventArgs) Handles MyBase.LocationChanged
        If App.Settings.StartLocation <> Me.Location Then
            App.Settings.StartLocation = Me.Location
        End If
    End Sub
    Private Sub Frm_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        If Visible AndAlso WindowState = FormWindowState.Normal Then
            App.Settings.StartSize = Me.Size
        End If
    End Sub
    Private Sub Frm_DoubleClick(sender As Object, e As EventArgs) Handles picbxAlbumArt.DoubleClick, panelAlbumArt.DoubleClick, MyBase.DoubleClick, MenuMain.DoubleClick, lblYear.DoubleClick, lblTrackSeparator.DoubleClick, lblTrack.DoubleClick, lblTitle.DoubleClick, lblGenre.DoubleClick, lblFileInfo.DoubleClick, lblDuration.DoubleClick, lblComments.DoubleClick, lblArtist.DoubleClick, lblAlbumArt.DoubleClick, lblAlbum.DoubleClick
        wMaximized = Not wMaximized
        SetWindowState()
    End Sub
    Private Sub Frm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyData
            Case Keys.W Or Keys.Control : Me.Close()
            Case Keys.W Or Keys.Control Or Keys.Shift : Me.WindowState = FormWindowState.Minimized
            Case Keys.Escape : Me.WindowState = FormWindowState.Minimized
            Case Keys.F12
                wMaximized = Not wMaximized
                SetWindowState()
        End Select
    End Sub
    Private Sub Frm_DragEnter(sender As Object, e As DragEventArgs) Handles MyBase.DragEnter
        Me.Activate()
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim filedrop As String() = DirectCast(e.Data.GetData(DataFormats.FileDrop, True), String())
            Dim files As New Collections.Generic.List(Of String)
            For Each s As String In filedrop : If My.Computer.FileSystem.FileExists(s) Then files.Add(s)
            Next
            If files.Count > 0 Then : e.Effect = DragDropEffects.Link
            Else : e.Effect = DragDropEffects.None
            End If
            files.Clear()
            files = Nothing
            filedrop = Nothing
        Else : e.Effect = DragDropEffects.None
        End If
    End Sub
    Private Sub Frm_DragDrop(sender As Object, e As DragEventArgs) Handles MyBase.DragDrop
        If e.Effect = DragDropEffects.Link Then
            Dim filedrop As String() = DirectCast(e.Data.GetData(DataFormats.FileDrop, True), String())
            Dim files As New Collections.Generic.List(Of String)
            For Each s As String In filedrop : If My.Computer.FileSystem.FileExists(s) Then files.Add(s)
            Next
            If files.Count > 0 Then
                My.App.WriteToLog("Drag&Drop Performed (" + files.Count.ToString + " " + IIf(files.Count = 1, "File", "Files").ToString + ")", False)
                App.tagPaths = files.ToList()
                LoadTags()
                ClearSave()
            End If
            files.Clear()
            files = Nothing
            filedrop = Nothing
        End If
    End Sub

    ' Control Events
    Private Sub MIOpenFile_Click(sender As Object, e As EventArgs) Handles MIOpenFile.Click
        OpenFile()
    End Sub
    Private Sub MITrimFile_Click(sender As Object, e As EventArgs) Handles MITrimFile.Click
        If tlFile IsNot Nothing AndAlso tlFile.MimeType.Substring(tlFile.MimeType.Length - 3) = "mp3" AndAlso Not NeedsSaved Then
            'Save current tag
            CopyTag(CopyModes.Full)
            'Remove current tag
            tlFile.RemoveTags(TagLib.TagTypes.AllTags)
            'Create new tag
            If tlFile.GetTag(TagLib.TagTypes.Id3v2, True) Is Nothing Then
                App.WriteToLog("Error Trimming File - Unable to create new tag")
            Else
                'Save to new tag
                PasteTag()
                tlFile.Save()
                ClearSave()
                App.WriteToLog("File Trimmed Successfully")
            End If
            'Finalize
            SetTag()
            ShowTag()
            App.tagCopy = New App.TagType
        End If
    End Sub
    Private Sub MICloseFile_Click(sender As Object, e As EventArgs) Handles MICloseFile.Click
        CloseFile()
    End Sub
    Private Sub MIOpenLocation_Click(sender As Object, e As EventArgs) Handles MIOpenLocation.Click
        If Not String.IsNullOrEmpty(My.tagPath) Then
            Static psi As Diagnostics.ProcessStartInfo
            psi = New Diagnostics.ProcessStartInfo("EXPLORER.EXE") With {
                .Arguments = "/SELECT," + """" + My.tagPath + """"}
            Try : Diagnostics.Process.Start(psi)
            Catch
                My.App.WriteToLog("Error Opening File Location")
                My.App.ErrorNotification()
            End Try
            psi = Nothing
        End If
    End Sub
    Private Sub MIExit_Click(sender As Object, e As EventArgs) Handles MIExit.Click
        Me.Close()
    End Sub
    Private Sub MIPlay_Click(sender As Object, e As EventArgs) Handles MIPlay.Click
        App.PlayMedia()
    End Sub
    Private Sub MIHelp_Click(sender As Object, e As EventArgs) Handles MIHelp.Click
        App.ShowHelp()
    End Sub
    Private Sub MILog_Click(sender As Object, e As EventArgs) Handles MILog.Click
        App.ShowLog()
    End Sub
    Private Sub MISettings_Click(sender As Object, e As EventArgs) Handles MISettings.Click
        App.ShowSettings()
    End Sub
    Private Sub MIFile_DropDownOpening(sender As Object, e As EventArgs) Handles MIFile.DropDownOpening
        MIFile.ForeColor = Color.Black
        If App.IsMultiFile Then
            MIOpenFile.Enabled = True
            MITrimFile.Enabled = False
            MIOpenLocation.Enabled = False
            MICloseFile.Enabled = True
        Else
            If tlFile Is Nothing Then
                MITrimFile.Enabled = False
                MICloseFile.Enabled = False
                MIOpenLocation.Enabled = False
            Else
                If NeedsSaved Then
                    MITrimFile.Enabled = False
                Else
                    If tlFile.MimeType.Substring(tlFile.MimeType.Length - 3) = "mp3" Then
                        MITrimFile.Enabled = True
                    Else
                        MITrimFile.Enabled = False
                    End If
                End If
                MICloseFile.Enabled = True
                MIOpenLocation.Enabled = True
            End If
        End If
    End Sub
    Private Sub MIFile_DropDownClosed(sender As Object, e As EventArgs) Handles MIFile.DropDownClosed
        If Not MIFile.Selected Then MIFile.ForeColor = Color.White
    End Sub
    Private Sub MIFile_MouseEnter(sender As Object, e As EventArgs) Handles MIFile.MouseEnter
        MIFile.ForeColor = Color.Black
    End Sub
    Private Sub MIFile_MouseLeave(sender As Object, e As EventArgs) Handles MIFile.MouseLeave
        If Not MIFile.DropDown.Visible Then MIFile.ForeColor = Color.White
    End Sub
    Private Sub MIEdit_DropDownOpening(sender As Object, e As EventArgs) Handles MIEdit.DropDownOpening
        MIEdit.ForeColor = Color.Black
        If App.IsMultiFile Then
            MICopyTagBasic.Enabled = False
            MICopyTagFull.Enabled = False
            If nArt.Count > 0 Then
                MICopyTagArt.Enabled = True
            Else
                MICopyTagArt.Enabled = False
            End If
            If App.tagCopy.TagContainsArtData Then
                MIPasteTag.Enabled = True
            Else
                MIPasteTag.Enabled = False
            End If
        Else
            If tlFile Is Nothing Then
                MICopyTagBasic.Enabled = False
                MICopyTagArt.Enabled = False
                MICopyTagFull.Enabled = False
                MIPasteTag.Enabled = False
            Else
                MICopyTagBasic.Enabled = True
                MICopyTagArt.Enabled = True
                MICopyTagFull.Enabled = True
                If App.tagCopy.TagContainsData Then
                    MIPasteTag.Enabled = True
                Else
                    MIPasteTag.Enabled = False
                End If
            End If
        End If
    End Sub
    Private Sub MIEdit_DropDownClosed(sender As Object, e As EventArgs) Handles MIEdit.DropDownClosed
        If Not MIEdit.Selected Then MIEdit.ForeColor = Color.White
    End Sub
    Private Sub MIEdit_MouseEnter(sender As Object, e As EventArgs) Handles MIEdit.MouseEnter
        MIEdit.ForeColor = Color.Black
    End Sub
    Private Sub MIEdit_MouseLeave(sender As Object, e As EventArgs) Handles MIEdit.MouseLeave
        If Not MIEdit.DropDown.Visible Then MIEdit.ForeColor = Color.White
    End Sub
    Private Sub MIView_DropDownOpening(sender As Object, e As EventArgs) Handles MIView.DropDownOpening
        MIView.ForeColor = Color.Black
    End Sub
    Private Sub MIView_DropDownClosed(sender As Object, e As EventArgs) Handles MIView.DropDownClosed
        If Not MIView.Selected Then MIView.ForeColor = Color.White
    End Sub
    Private Sub MIView_MouseEnter(sender As Object, e As EventArgs) Handles MIView.MouseEnter
        MIView.ForeColor = Color.Black
    End Sub
    Private Sub MIView_MouseLeave(sender As Object, e As EventArgs) Handles MIView.MouseLeave
        If Not MIView.DropDown.Visible Then MIView.ForeColor = Color.White
    End Sub
    Private Sub MIPlay_MouseEnter(sender As Object, e As EventArgs) Handles MIPlay.MouseEnter
        MIPlay.ForeColor = Color.Black
    End Sub
    Private Sub MIPlay_MouseLeave(sender As Object, e As EventArgs) Handles MIPlay.MouseLeave
        MIPlay.ForeColor = Color.White
    End Sub
    Private Sub MIAbout_DropDownOpening(sender As Object, e As EventArgs) Handles MIAbout.DropDownOpening
        MIAbout.ForeColor = Color.Black
    End Sub
    Private Sub MIAbout_DropDownClosed(sender As Object, e As EventArgs) Handles MIAbout.DropDownClosed
        If Not MIAbout.Selected Then MIAbout.ForeColor = Color.White
    End Sub
    Private Sub MIAbout_MouseEnter(sender As Object, e As EventArgs) Handles MIAbout.MouseEnter
        MIAbout.ForeColor = Color.Black
    End Sub
    Private Sub MIAbout_MouseLeave(sender As Object, e As EventArgs) Handles MIAbout.MouseLeave
        If Not MIAbout.DropDown.Visible Then MIAbout.ForeColor = Color.White
    End Sub
    Private Sub MICopyTagBasic_Click(sender As Object, e As EventArgs) Handles MICopyTagBasic.Click
        CopyTag(App.CopyModes.Basic)
    End Sub
    Private Sub MICopyTagArt_Click(sender As Object, e As EventArgs) Handles MICopyTagArt.Click
        CopyTag(App.CopyModes.Art)
    End Sub
    Private Sub MICopyTagFull_Click(sender As Object, e As EventArgs) Handles MICopyTagFull.Click
        CopyTag(App.CopyModes.Full)
    End Sub
    Private Sub MIPasteTag_Click(sender As Object, e As EventArgs) Handles MIPasteTag.Click
        PasteTag()
    End Sub
    Private Sub CMIArtistInsert_Click(sender As Object, e As EventArgs) Handles cmiArtistInsert.Click
        InsertArtist()
    End Sub
    Private Sub CMIArtistInsertFromClipboard_Click(sender As Object, e As EventArgs) Handles cmiArtistInsertFromClipboard.Click
        If My.Computer.Clipboard.ContainsText Then : InsertArtist(My.Computer.Clipboard.GetText)
        Else
            tipInfo.ShowTooltip(btnArtistInsert, "No Text On ClipBoard", SystemIcons.Information.ToBitmap)
        End If
    End Sub
    Private Sub CMIArtistPrevious_Click(sender As Object, e As EventArgs) Handles cmiArtistPrevious.Click
        My.tagArtistIndex -= 1
        If My.tagArtistIndex < 0 Then My.tagArtistIndex = 0
        ShowTag()
    End Sub
    Private Sub CMIArtistMoveLeft_Click(sender As Object, e As EventArgs) Handles cmiArtistMoveLeft.Click
        MoveArtist(RMove.Left)
    End Sub
    Private Sub CMIArtistMoveFirst_Click(sender As Object, e As EventArgs) Handles cmiArtistMoveFirst.Click
        MoveArtist(RMove.First)
    End Sub
    Private Sub CMIArtistNext_Click(sender As Object, e As EventArgs) Handles cmiArtistNext.Click
        My.tagArtistIndex += 1
        If My.tagArtistIndex > tlFile.Tag.Performers.Length - 1 Then My.tagArtistIndex = tlFile.Tag.Performers.Length - 1
        ShowTag()
    End Sub
    Private Sub CMIArtistMoveRight_Click(sender As Object, e As EventArgs) Handles cmiArtistMoveRight.Click
        MoveArtist(RMove.Right)
    End Sub
    Private Sub CMIArtistMoveLast_Click(sender As Object, e As EventArgs) Handles cmiArtistMoveLast.Click
        MoveArtist(RMove.Last)
    End Sub
    Private Sub CMAlbumArt_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmAlbumArt.Opening
        If My.Computer.Keyboard.ShiftKeyDown Then
            e.Cancel = True
            Return
        End If

        ' MULTI-FILE MODE
        If IsMultiFile Then
            If nArt Is Nothing OrElse nArt.Count = 0 Then
                ' No artwork → disable everything except Insert
                cmiAlbumArtSelect.Enabled = False
                cmiAlbumArtExport.Enabled = False
                cmiAlbumArtMoveLeft.Enabled = False
                cmiAlbumArtMoveFirst.Enabled = False
                cmiAlbumArtMoveRight.Enabled = False
                cmiAlbumArtMoveLast.Enabled = False
                cmiAlbumArtDelete.Enabled = False
                cmiAlbumArtInsert.DropDown = cmImageSource
            Else
                ' Artwork exists → enable appropriate items
                cmiAlbumArtSelect.Enabled = True
                cmiAlbumArtExport.Enabled = True

                ' Movement
                cmiAlbumArtMoveLeft.Enabled = (My.tagArtIndex > 0)
                cmiAlbumArtMoveFirst.Enabled = (My.tagArtIndex > 0)
                cmiAlbumArtMoveRight.Enabled = (My.tagArtIndex < nArt.Count - 1)
                cmiAlbumArtMoveLast.Enabled = (My.tagArtIndex < nArt.Count - 1)

                cmiAlbumArtDelete.Enabled = True
                cmiAlbumArtInsert.DropDown = cmAlbumArtInsert
            End If

            ' Always allow insert in multi-file mode
            cmiAlbumArtInsert.Enabled = True

            Return
        End If

        ' SINGLE-FILE MODE (your original logic)
        If tlFile.Tag.Pictures.Length = 0 Then
            cmiAlbumArtSelect.Enabled = False
            cmiAlbumArtExport.Enabled = False
            cmiAlbumArtMoveLeft.Enabled = False
            cmiAlbumArtMoveFirst.Enabled = False
            cmiAlbumArtMoveRight.Enabled = False
            cmiAlbumArtMoveLast.Enabled = False
            cmiAlbumArtDelete.Enabled = False
            cmiAlbumArtInsert.DropDown = cmImageSource
        Else
            cmiAlbumArtSelect.Enabled = True
            cmiAlbumArtExport.Enabled = True

            If My.tagArtIndex = 0 Then
                cmiAlbumArtMoveLeft.Enabled = False
                cmiAlbumArtMoveFirst.Enabled = False
            Else
                cmiAlbumArtMoveLeft.Enabled = True
                cmiAlbumArtMoveFirst.Enabled = True
            End If

            If My.tagArtIndex = tlFile.Tag.Pictures.Length - 1 Then
                cmiAlbumArtMoveRight.Enabled = False
                cmiAlbumArtMoveLast.Enabled = False
            Else
                cmiAlbumArtMoveRight.Enabled = True
                cmiAlbumArtMoveLast.Enabled = True
            End If

            cmiAlbumArtDelete.Enabled = True
            cmiAlbumArtInsert.DropDown = cmAlbumArtInsert
        End If

        cmiAlbumArtInsert.Enabled = (tlFile.TagTypes <> TagLib.TagTypes.None)
    End Sub
    Private Sub CMImageSource_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmImageSource.Opening
        cmImageSource.Tag = cmImageSource.OwnerItem.Name
    End Sub
    Private Sub CMISelectFromFile_Click(sender As Object, e As EventArgs) Handles cmiSelectFromFile.Click
        'Debug.Print("SelectFromFile For " + cmImageSource.Tag.ToString)
        Select Case cmImageSource.Tag.ToString
            Case cmiAlbumArtSelect.Name
                UpdateArt(ImageSource.SelectFile)
            Case cmiAlbumArtInsert.Name
                InsertArt(0, ImageSource.SelectFile)
            Case cmiAlbumArtInsertBefore.Name
                InsertArt(tagArtIndex, ImageSource.SelectFile)
            Case cmiAlbumArtInsertFirst.Name
                InsertArt(0, ImageSource.SelectFile)
            Case cmiAlbumArtInsertAfter.Name
                InsertArt(CInt(IIf(tlFile.Tag.Pictures.Length = 0, 0, tagArtIndex + 1)), ImageSource.SelectFile)
            Case cmiAlbumArtInsertLast.Name
                InsertArt(tlFile.Tag.Pictures.Length, ImageSource.SelectFile)
        End Select
    End Sub
    Private Sub CMISelectFromOnline_Click(sender As Object, e As EventArgs) Handles cmiSelectFromOnline.Click
        Debug.Print("SelectFromOnline For " + cmImageSource.Tag.ToString)
        Select Case cmImageSource.Tag.ToString
            Case cmiAlbumArtSelect.Name
                UpdateArt(ImageSource.SelectOnline)
            Case cmiAlbumArtInsert.Name
                InsertArt(0, ImageSource.SelectOnline)
            Case cmiAlbumArtInsertBefore.Name
                InsertArt(tagArtIndex, ImageSource.SelectOnline)
            Case cmiAlbumArtInsertFirst.Name
                InsertArt(0, ImageSource.SelectOnline)
            Case cmiAlbumArtInsertAfter.Name
                InsertArt(CInt(IIf(tlFile.Tag.Pictures.Length = 0, 0, tagArtIndex + 1)), ImageSource.SelectOnline)
            Case cmiAlbumArtInsertLast.Name
                InsertArt(tlFile.Tag.Pictures.Length, ImageSource.SelectOnline)
        End Select
    End Sub
    Private Sub CMIPasteFromClipboard_Click(sender As Object, e As EventArgs) Handles cmiPasteFromClipboard.Click
        Debug.Print("SelectPasteFromClipboard For " + cmImageSource.Tag.ToString)
        Select Case cmImageSource.Tag.ToString
            Case cmiAlbumArtSelect.Name
                UpdateArt(ImageSource.ClipBoard)
            Case cmiAlbumArtInsert.Name
                InsertArt(0, ImageSource.ClipBoard)
            Case cmiAlbumArtInsertBefore.Name
                InsertArt(tagArtIndex, ImageSource.ClipBoard)
            Case cmiAlbumArtInsertFirst.Name
                InsertArt(0, ImageSource.ClipBoard)
            Case cmiAlbumArtInsertAfter.Name
                InsertArt(CInt(IIf(tlFile.Tag.Pictures.Length = 0, 0, tagArtIndex + 1)), ImageSource.ClipBoard)
            Case cmiAlbumArtInsertLast.Name
                InsertArt(tlFile.Tag.Pictures.Length, ImageSource.ClipBoard)
        End Select
    End Sub
    Private Sub CMIExportToFile_Click(sender As Object, e As EventArgs) Handles cmiExportToFile.Click
        ExportArt(ExportDestination.File)
    End Sub
    Private Sub CMIExportToBitmap_Click(sender As Object, e As EventArgs) Handles cmiExportToBitmap.Click
        ExportArt(ExportDestination.BitmapFile)
    End Sub
    Private Sub CMIExportToClipboard_Click(sender As Object, e As EventArgs) Handles cmiExportToClipboard.Click
        ExportArt(ExportDestination.Clipboard)
    End Sub
    Private Sub CMIAlbumArtMoveLeft_Click(sender As Object, e As EventArgs) Handles cmiAlbumArtMoveLeft.Click
        MoveArt(RMove.Left)
    End Sub
    Private Sub CMIAlbumArtMoveFirst_Click(sender As Object, e As EventArgs) Handles cmiAlbumArtMoveFirst.Click
        MoveArt(RMove.First)
    End Sub
    Private Sub CMIAlbumArtMoveRight_Click(sender As Object, e As EventArgs) Handles cmiAlbumArtMoveRight.Click
        MoveArt(RMove.Right)
    End Sub
    Private Sub CMIAlbumArtMoveLast_Click(sender As Object, e As EventArgs) Handles cmiAlbumArtMoveLast.Click
        MoveArt(RMove.Last)
    End Sub
    Private Sub CMIAlbumArtDeleteMouseUp(sender As Object, e As MouseEventArgs) Handles cmiAlbumArtDelete.MouseUp

        ' MULTI-FILE MODE
        If App.IsMultiFile Then

            If nArt Is Nothing OrElse nArt.Count = 0 Then Exit Sub

            ' Remove the current picture
            nArt.RemoveAt(My.tagArtIndex)

            ' Fix index
            If My.tagArtIndex > nArt.Count - 1 Then
                My.tagArtIndex = Math.Max(0, nArt.Count - 1)
            End If

            ' Refresh UI
            ShowTagArtFromList(nArt)
            SetArtControls(True)
            CheckDirtyState()

            Exit Sub
        End If


        ' SINGLE-FILE MODE
        If tlFile Is Nothing OrElse tlFile.Tag.Pictures.Length = 0 Then Exit Sub

        Dim piclist As New List(Of TagLib.IPicture)(tlFile.Tag.Pictures)

        ' Remove the current picture
        piclist.RemoveAt(My.tagArtIndex)

        ' Fix index
        If My.tagArtIndex > piclist.Count - 1 Then
            My.tagArtIndex = Math.Max(0, piclist.Count - 1)
        End If

        ' Apply back to file
        tlFile.Tag.Pictures = piclist.ToArray()

        ' Refresh UI
        ShowTag()
        'SetSave()
        'SetDirtyStateForArt()

    End Sub
    Private Sub CMIArtPrevious_Click(sender As Object, e As EventArgs) Handles cmiArtPrevious.Click
        txbxAlbumArt.CausesValidation = False
        cobxAlbumArtType.CausesValidation = False
        My.tagArtIndex -= 1
        If My.tagArtIndex < 0 Then My.tagArtIndex = 0
        ShowTag()
        ResetLyrics()
        txbxAlbumArt.CausesValidation = True
        cobxAlbumArtType.CausesValidation = True
    End Sub
    Private Sub CMIArtMoveLeft_Click(sender As Object, e As EventArgs) Handles cmiArtMoveLeft.Click
        MoveArt(RMove.Left)
    End Sub
    Private Sub CMIArtMoveFirst_Click(sender As Object, e As EventArgs) Handles cmiArtMoveFirst.Click
        MoveArt(RMove.First)
    End Sub
    Private Sub CMIArtNext_Click(sender As Object, e As EventArgs) Handles cmiArtNext.Click
        txbxAlbumArt.CausesValidation = False
        cobxAlbumArtType.CausesValidation = False
        My.tagArtIndex += 1
        If My.tagArtIndex > tlFile.Tag.Pictures.Length - 1 Then My.tagArtIndex = tlFile.Tag.Pictures.Length - 1
        ShowTag()
        ResetLyrics()
        txbxAlbumArt.CausesValidation = True
        cobxAlbumArtType.CausesValidation = True
    End Sub
    Private Sub CMIArtMoveRight_Click(sender As Object, e As EventArgs) Handles cmiArtMoveRight.Click
        MoveArt(RMove.Right)
    End Sub
    Private Sub CMIArtMoveLast_Click(sender As Object, e As EventArgs) Handles cmiArtMoveLast.Click
        MoveArt(RMove.Last)
    End Sub
    Private Sub CtrlAlbumArtEnter(sender As Object, e As EventArgs) Handles txbxAlbumArt.Enter
        ResetLyrics()
    End Sub
    Private Sub LblFileInfo_MouseDown(sender As Object, e As MouseEventArgs) Handles lblFileInfo.MouseDown
        If inDoubleClick Then
            inDoubleClick = False
            Dim length As TimeSpan = DateTime.Now - lastClick
            'If double click is valid, respond
            If length < doubleclickMaxTime Then
                clickTimer.Stop()
                'Perform Double-Click Action
                wMaximized = Not wMaximized
                SetWindowState()
            End If
            Return
        End If
        'Double click was invalid, restart 
        clickTimer.Stop()
        clickTimer.Start()
        lastClick = DateTime.Now
        inDoubleClick = True
    End Sub
    Private Sub LblFileInfo_MouseEnter(sender As Object, e As EventArgs) Handles lblFileInfo.MouseEnter
        If Not String.IsNullOrEmpty(lblFileInfo.Text) Then
            Cursor = Cursors.Hand
            lblFileInfo.ForeColor = Skye.WinAPI.GetSystemColor(Skye.WinAPI.COLOR_HOTLIGHT)
        End If
    End Sub
    Private Sub LblFileInfo_MouseLeave(sender As Object, e As EventArgs) Handles lblFileInfo.MouseLeave
        ResetCursor()
        lblFileInfo.ResetForeColor()
    End Sub
    Private Sub LblAlbumArtClick(sender As Object, e As EventArgs)
        If tlFile.Tag.Pictures.Length > 0 Then ResetLyrics()
    End Sub
    Private Sub Txtbox_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles txbxTitle.PreviewKeyDown, txbxDuration.PreviewKeyDown, txbxComments.PreviewKeyDown, txbxArtist.PreviewKeyDown, txbxAlbumArt.PreviewKeyDown, txbxAlbum.PreviewKeyDown
        txtboxCM.ShortcutKeys(DirectCast(sender, TextBox), e)
    End Sub
    Private Sub TxbxLyrics_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles txbxLyrics.PreviewKeyDown
        txtboxCMLyrics.ShortcutKeys(DirectCast(sender, TextBox), e)
    End Sub
    Private Sub Txbx_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txbxTitle.KeyDown, txbxComments.KeyDown, txbxArtist.KeyDown, txbxAlbumArt.KeyDown, txbxAlbum.KeyDown, CoBoxGenre.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            Validate()
        End If
    End Sub
    Private Sub TxBx_KeyUp(sender As Object, e As KeyEventArgs) Handles txbxAlbumArt.KeyUp, txbxYear.KeyUp, txbxTrackCount.KeyUp, txbxTrack.KeyUp, txbxTitle.KeyUp, txbxComments.KeyUp, txbxArtist.KeyUp, txbxAlbum.KeyUp
        If sender Is txbxAlbumArt Then ValidateChildren()
        CheckDirtyState()
    End Sub
    Private Sub Txbx_TextChanged(sender As Object, e As EventArgs) Handles txbxComments.TextChanged, txbxAlbum.TextChanged, txbxTitle.TextChanged, txbxArtist.TextChanged, txbxLyrics.TextChanged
        CheckDirtyState()
    End Sub
    Private Sub TxbxNumbersOnly_KeyDown(sender As Object, e As KeyEventArgs) Handles txbxYear.KeyDown, txbxTrackCount.KeyDown, txbxTrack.KeyDown
        'If Not e.Control AndAlso Not e.Alt Then SetSave()
    End Sub
    Private Sub TxbxNumbersOnly_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txbxYear.KeyPress, txbxTrackCount.KeyPress, txbxTrack.KeyPress
        Static nonNumberEntered As Boolean
        nonNumberEntered = False
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then : nonNumberEntered = True
        ElseIf Asc(e.KeyChar) = Keys.Enter Then : Me.Validate()
        End If
        If nonNumberEntered Then e.Handled = True
    End Sub
    Private Sub TxbxArtist_Validated(sender As Object, e As EventArgs) Handles txbxArtist.Validated

        ' MULTI-FILE MODE
        If IsMultiFile Then
            ' Do NOT write to tlFile here.
            ' Just update dirty state.
            CheckDirtyState()
            Exit Sub
        End If

        ' SINGLE-FILE MODE (existing behavior)
        If tlFile IsNot Nothing Then

            ' Add new first artist if none exist
            If Not String.IsNullOrEmpty(txbxArtist.Text) AndAlso tlFile.Tag.Performers.Length = 0 Then
                tlFile.Tag.Performers = New String() {txbxArtist.Text}
                SetArtistControls(True)
                'SetSave(True)

                ' Remove current artist if textbox is empty
            ElseIf String.IsNullOrEmpty(txbxArtist.Text) AndAlso tlFile.Tag.Performers.Length > 1 Then
                Dim alist As New List(Of String)(tlFile.Tag.Performers)
                alist.RemoveAt(My.tagArtistIndex)

                If My.tagArtistIndex > alist.Count - 1 Then
                    My.tagArtistIndex = alist.Count - 1
                End If

                tlFile.Tag.Performers = alist.ToArray()
                ShowTag()
                'SetSave(True)

                ' Replace current artist
            ElseIf tlFile.Tag.Performers.Length > 0 AndAlso
               Not String.Equals(
                   If(tlFile.Tag.Performers(My.tagArtistIndex), String.Empty),
                   txbxArtist.Text
               ) Then

                Dim s() As String = tlFile.Tag.Performers
                s(My.tagArtistIndex) = txbxArtist.Text
                tlFile.Tag.Performers = s

                SetArtistControls(True)
                'SetSave(True)
            End If
        End If
    End Sub
    Private Sub TxbxTitle_Validated(sender As Object, e As EventArgs) Handles txbxTitle.Validated

        ' MULTI-FILE MODE
        If IsMultiFile Then
            ' Do NOT write to tlFile here.
            ' Just update dirty state.
            CheckDirtyState()
            Exit Sub
        End If

        ' SINGLE-FILE MODE (existing behavior)
        If tlFile IsNot Nothing Then
            CheckDirtyState()
            Dim current As String = If(tlFile.Tag.Title, String.Empty)
            If current <> txbxTitle.Text Then
                tlFile.Tag.Title = txbxTitle.Text
                ' SetSave(True)
            End If
        End If
    End Sub
    Private Sub TxbxTrackValidated(sender As Object, e As EventArgs) Handles txbxTrack.Validated
        ' MULTI-FILE MODE
        If IsMultiFile Then
            ' Do NOT write to tlFile here.
            ' Just update dirty state.
            CheckDirtyState()
            Exit Sub
        End If

        ' SINGLE-FILE MODE
        If tlFile IsNot Nothing Then
            If Not tlFile.Tag.Track = CUInt(Val(Me.txbxTrack.Text)) Then
                tlFile.Tag.Track = CUInt(Val(Me.txbxTrack.Text))
                Me.txbxTrack.Text = IIf(tlFile.Tag.Track = 0, String.Empty, tlFile.Tag.Track).ToString
                '   SetSave()
            End If
        End If
    End Sub
    Private Sub TxbxTrackCount_Validated(sender As Object, e As EventArgs) Handles txbxTrackCount.Validated

        ' MULTI-FILE MODE
        If IsMultiFile Then
            ' Never write to tlFile here.
            ' Just update dirty state.
            CheckDirtyState()
            Exit Sub
        End If

        ' SINGLE-FILE MODE
        If tlFile IsNot Nothing Then

            Dim newValue As UInt32 = CUInt(Val(txbxTrackCount.Text))
            Dim current As UInt32 = tlFile.Tag.TrackCount

            If current <> newValue Then
                tlFile.Tag.TrackCount = newValue

                ' Normalize textbox (0 becomes empty)
                If tlFile.Tag.TrackCount = 0UI Then
                    txbxTrackCount.Text = ""
                Else
                    txbxTrackCount.Text = tlFile.Tag.TrackCount.ToString()
                End If

                '       SetSave(True)
            End If
        End If
    End Sub
    Private Sub TxbxAlbumValidated(sender As Object, e As EventArgs) Handles txbxAlbum.Validated
        ' MULTI-FILE MODE
        If IsMultiFile Then
            ' Do NOT write to tlFile here.
            ' Just update dirty state.
            CheckDirtyState()
            Exit Sub
        End If

        ' SINGLE-FILE MODE
        If tlFile IsNot Nothing Then
            If Not String.Equals(IIf(tlFile.Tag.Album Is Nothing, String.Empty, tlFile.Tag.Album).ToString, Me.txbxAlbum.Text) Then
                tlFile.Tag.Album = Me.txbxAlbum.Text
                '               SetSave(True)
            End If
        End If
    End Sub
    Private Sub TxbxYearValidated(sender As Object, e As EventArgs) Handles txbxYear.Validated
        ' MULTI-FILE MODE
        If IsMultiFile Then
            ' Do NOT write to tlFile here.
            ' Just update dirty state.
            CheckDirtyState()
            Exit Sub
        End If

        ' SINGLE-FILE MODE
        If tlFile IsNot Nothing Then
            If Not tlFile.Tag.Year = CUInt(Val(Me.txbxYear.Text)) Then
                tlFile.Tag.Year = CUInt(Val(Me.txbxYear.Text))
                Me.txbxYear.Text = IIf(tlFile.Tag.Year = 0, String.Empty, tlFile.Tag.Year).ToString
                'SetSave()
            End If
        End If
    End Sub
    Private Sub TxbxCommentsValidated(sender As Object, e As EventArgs) Handles txbxComments.Validated
        ' MULTI-FILE MODE
        If IsMultiFile Then
            ' Do NOT write to tlFile here.
            ' Just update dirty state.
            CheckDirtyState()
            Exit Sub
        End If

        ' SINGLE-FILE MODE
        If tlFile IsNot Nothing Then
            If Not String.Equals(IIf(tlFile.Tag.Comment Is Nothing, String.Empty, tlFile.Tag.Comment).ToString, Me.txbxComments.Text) Then
                tlFile.Tag.Comment = Me.txbxComments.Text
                'SetSave(True)
            End If
        End If
    End Sub
    Private Sub TxbxAlbumArtValidated(sender As Object, e As EventArgs) Handles txbxAlbumArt.Validated
        ' MULTI-FILE MODE
        If IsMultiFile Then
            If nArt IsNot Nothing AndAlso nArt.Count > 0 AndAlso App.tagArtIndex >= 0 AndAlso App.tagArtIndex < nArt.Count Then
                Dim pic = nArt(My.tagArtIndex)
                Dim currentDesc As String = If(pic.Description, String.Empty)
                Dim newDesc As String = txbxAlbumArt.Text

                If Not String.Equals(currentDesc, newDesc, StringComparison.Ordinal) Then
                    pic.Description = newDesc
                    NeedsSaved = True
                    CheckDirtyState()
                End If

            End If
            Exit Sub
        End If

        ' SINGLE-FILE MODE
        If tlFile IsNot Nothing AndAlso tlFile.Tag.Pictures IsNot Nothing AndAlso tlFile.Tag.Pictures.Length > 0 AndAlso My.tagArtIndex >= 0 AndAlso My.tagArtIndex < tlFile.Tag.Pictures.Length Then
            Dim pic = tlFile.Tag.Pictures(My.tagArtIndex)
            Dim currentDesc As String = If(pic.Description, String.Empty)
            Dim newDesc As String = txbxAlbumArt.Text

            If Not String.Equals(currentDesc, newDesc, StringComparison.Ordinal) Then
                pic.Description = newDesc
                'SetSave(True)
            End If
            'SetDirtyStateForArt()

        End If
    End Sub
    Private Sub TxbxLyricsKeyUp(sender As Object, e As KeyEventArgs) Handles txbxLyrics.KeyUp
        If tlFile IsNot Nothing AndAlso txbxLyrics.Text IsNot Nothing Then
            CheckDirtyState()
        End If
    End Sub
    Private Sub TxbxLyricsValidated(sender As Object, e As EventArgs) Handles txbxLyrics.Validated
        ' MULTI-FILE MODE
        If IsMultiFile Then
            ' Do NOT write to tlFile here.
            ' Just update dirty state.
            CheckDirtyState()
            Exit Sub
        End If

        ' SINGLE-FILE MODE
        If tlFile IsNot Nothing Then
            If Not String.Equals(IIf(tlFile.Tag.Lyrics Is Nothing, String.Empty, tlFile.Tag.Lyrics).ToString, Me.txbxLyrics.Text) Then
                tlFile.Tag.Lyrics = Me.txbxLyrics.Text
                'SetSave(True)
            End If
        End If
    End Sub
    Private Sub CoBoxGenreSelectionChangeCommitted(sender As Object, e As EventArgs) Handles CoBoxGenre.SelectionChangeCommitted
        Validate()
    End Sub
    Private Async Sub CoBoxGenre_Validated(sender As Object, e As EventArgs) Handles CoBoxGenre.Validated
        Await Task.Delay(1)
        ' MULTI-FILE MODE
        If IsMultiFile Then
            ' Do NOT write to tlFile here.
            ' Just update dirty state.
            CheckDirtyState()
            Exit Sub
        End If

        ' SINGLE-FILE MODE
        If tlFile IsNot Nothing Then
            If Not String.Equals(IIf(tlFile.Tag.FirstGenre Is Nothing, String.Empty, tlFile.Tag.FirstGenre).ToString, CoBoxGenre.Text) Then
                CheckDirtyState()
                Dim s() As String
                If tlFile.Tag.Genres.Length = 0 Then
                    s = New String() {CoBoxGenre.Text}
                Else
                    s = tlFile.Tag.Genres
                    s.SetValue(CoBoxGenre.Text, 0)
                End If
                tlFile.Tag.Genres = s
                'SetSave(True)
            End If
        End If
    End Sub
    Private Sub CobxAlbumArtTypeSelectionChangeCommitted(sender As Object, e As EventArgs)
        Validate()
    End Sub
    Private Sub CobxAlbumArtTypeValidated(sender As Object, e As EventArgs)

        ' MULTI-FILE MODE
        If IsMultiFile Then
            If nArt IsNot Nothing AndAlso nArt.Count > 0 AndAlso
           tagArtIndex >= 0 AndAlso tagArtIndex < nArt.Count Then

                Dim pic = nArt(tagArtIndex)
                Dim currentType = pic.Type
                Dim newType = CType(cobxAlbumArtType.SelectedIndex, TagLib.PictureType)

                If currentType <> newType Then
                    pic.Type = newType
                    NeedsSaved = True
                    CheckDirtyState()
                End If
            End If

            Exit Sub
        End If


        ' SINGLE-FILE MODE
        If tlFile IsNot Nothing AndAlso
       tlFile.Tag.Pictures IsNot Nothing AndAlso
       tlFile.Tag.Pictures.Length > 0 AndAlso
       tagArtIndex >= 0 AndAlso tagArtIndex < tlFile.Tag.Pictures.Length Then

            Dim pic = tlFile.Tag.Pictures(tagArtIndex)
            Dim currentType = pic.Type
            Dim newType = CType(cobxAlbumArtType.SelectedIndex, TagLib.PictureType)

            If currentType <> newType Then
                pic.Type = newType
                'SetSave(True)
                CheckDirtyState()
            End If
            'SetDirtyStateForArt()
        End If

    End Sub
    Private Sub BtnErrorMouseUp(sender As Object, e As MouseEventArgs) Handles btnError.MouseUp
        If My.App.MouseInBounds(CType(sender, Control), e.Location) Then
            My.App.ErrorNotification(False)
            If e.Button = MouseButtons.Right Then
                If My.Computer.Keyboard.CtrlKeyDown Then
                    My.App.AppAlertMessage = "TEST ERROR! DO NOT PANIC!"
                    My.App.WriteToLog(My.App.AppAlertMessage, False)
                    My.App.ErrorNotification(True)
                Else : My.App.ShowLog()
                End If
            End If
        End If
    End Sub
    Private Sub BtnMinimizeClick(sender As Object, e As EventArgs)
        Me.WindowState = FormWindowState.Minimized
    End Sub
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        If Not NeedsSaved Then Exit Sub

        ' MULTI-FILE MODE
        If App.tagPaths IsNot Nothing AndAlso App.tagPaths.Count > 1 Then
            SaveTags()   ' <-- your new multi-file engine
            CheckDirtyState()
            Exit Sub
        End If

        ' SINGLE-FILE MODE (your original logic)
        Try
            tlFile.Save()
            My.App.WriteToLog("Tag Saved")
            SetTag()
            ShowTag()
            ClearSave()
            CheckDirtyState()
            btnSave.Enabled = False
            btnRestore.Enabled = False
        Catch ex As IO.IOException
            My.App.WriteToLog("Error Saving Tag")
            My.App.WriteToLog(ex.Message, False)
            My.AppAlertMessage = ex.Message
            My.App.ErrorNotification()
        Catch ex As Exception
            My.App.WriteToLog("Error Saving Tag")
            My.App.WriteToLog(ex.ToString, False)
            My.AppAlertMessage = ex.ToString
            My.App.ErrorNotification()
        End Try

    End Sub
    Private Sub BtnRestore_Click(sender As Object, e As EventArgs) Handles btnRestore.Click

        ' MULTI-FILE MODE
        If IsMultiFile Then

            ' Restore merged originals
            txbxArtist.Text = oArtist
            txbxTitle.Text = oTitle
            txbxAlbum.Text = oAlbum
            If oGenre = multiMessage Then
                CoBoxGenre.Text = multiMessageShort
                tipInfo.SetText(CoBoxGenre, oGenre)
            Else
                CoBoxGenre.Text = oGenre
                tipInfo.SetText(CoBoxGenre, Nothing)
            End If
            If oYear = multiMessage Then
                txbxYear.Text = multiMessageShorter
                tipInfo.SetText(txbxYear, oYear)
            Else
                txbxYear.Text = oYear
                tipInfo.SetText(txbxYear, Nothing)
            End If
            If oTrack = multiMessage Then
                txbxTrack.Text = multiMessageShorter
                tipInfo.SetText(txbxTrack, oTrack)
            Else
                txbxTrack.Text = oTrack
                tipInfo.SetText(txbxTrack, Nothing)
            End If
            If oTrackCount = multiMessage Then
                txbxTrackCount.Text = multiMessageShorter
                tipInfo.SetText(txbxTrackCount, oTrackCount)
            Else
                txbxTrackCount.Text = oTrackCount
                tipInfo.SetText(txbxTrackCount, Nothing)
            End If
            txbxComments.Text = oComments
            txbxLyrics.Text = oLyrics

            ' Restore artwork
            nArt = ClonePictures(oArt)
            My.tagArtIndex = 0

            If nArt.Count > 0 Then
                ShowTagArtFromList(nArt)
            Else
                picbxAlbumArt.Image = Nothing
            End If

            ' Reset UI state
            NeedsSaved = False
            btnSave.Enabled = False
            btnRestore.Enabled = False

            ' Reset bold labels
            ShowTagArtFromList(nArt)
            CheckDirtyState()

            Exit Sub
        End If


        ' SINGLE-FILE MODE (your original behavior)
#If DEBUG Then
        SetTag()
        ShowTag()
        ClearSave()
        CheckDirtyState()
        btnRestore.Enabled = False
#Else
    If NeedsSaved Then
        SetTag()
        ShowTag()
        ClearSave()
        btnRestore.Enabled = False
    End If
#End If

    End Sub
    Private Sub BtnArtistInsertDragEnter(sender As Object, e As DragEventArgs) Handles btnArtistInsert.DragEnter
        If e.Data.GetDataPresent(DataFormats.StringFormat) _
        AndAlso Not String.IsNullOrEmpty(e.Data.GetData(DataFormats.StringFormat, True).ToString) _
            Then : e.Effect = DragDropEffects.Copy
        Else : e.Effect = DragDropEffects.None
        End If
    End Sub
    Private Sub BtnArtistInsertDragDrop(sender As Object, e As DragEventArgs) Handles btnArtistInsert.DragDrop
        If e.Effect = DragDropEffects.Copy Then
            My.App.WriteToLog("Drag&Drop Performed (" + My.App.hArtist + " Text)", False)
            InsertArtist(e.Data.GetData(DataFormats.StringFormat, True).ToString)
        End If
    End Sub
    Private Sub BtnArtistInsertMouseUp(sender As Object, e As MouseEventArgs) Handles btnArtistInsert.MouseUp
        If e.Button = MouseButtons.Left AndAlso My.App.MouseInBounds(CType(sender, Control), e.Location) AndAlso Not tlFile.TagTypes = TagLib.TagTypes.None Then
            InsertArtist()
        End If
    End Sub
    Private Sub BtnArtistDeleteMouseUp(sender As Object, e As MouseEventArgs) Handles btnArtistDelete.MouseUp
        If e.Button = MouseButtons.Left AndAlso tlFile.Tag.Performers.Length > 1 AndAlso My.App.MouseInBounds(CType(sender, Control), e.Location) Then
            Dim alist As New Collections.Generic.List(Of String)
            For Each s As String In tlFile.Tag.Performers : alist.Add(s) : Next
            alist.RemoveAt(My.tagArtistIndex)
            If My.tagArtistIndex > tlFile.Tag.Performers.Length - 2 Then My.tagArtistIndex = tlFile.Tag.Performers.Length - 2
            tlFile.Tag.Performers = alist.ToArray
            alist.Clear()
            alist = Nothing
            ShowTag()
            ' SetSave()
        End If
    End Sub
    Private Sub BtnArtistLeftMouseUp(sender As Object, e As MouseEventArgs) Handles btnArtistLeft.MouseUp
        If e.Button = MouseButtons.Left AndAlso My.App.MouseInBounds(CType(sender, Control), e.Location) Then
            My.tagArtistIndex -= 1
            If My.tagArtistIndex < 0 Then My.tagArtistIndex = 0
            ShowTag()
        End If
    End Sub
    Private Sub BtnArtistRightMouseUp(sender As Object, e As MouseEventArgs) Handles btnArtistRight.MouseUp
        If e.Button = MouseButtons.Left AndAlso My.App.MouseInBounds(CType(sender, Control), e.Location) Then
            My.tagArtistIndex += 1
            If My.tagArtistIndex > tlFile.Tag.Performers.Length - 1 Then My.tagArtistIndex = tlFile.Tag.Performers.Length - 1
            ShowTag()
        End If
    End Sub
    Private Sub BtnAlbumArtDragEnter(sender As Object, e As DragEventArgs) Handles btnAlbumArt.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim filedrop As String() = DirectCast(e.Data.GetData(DataFormats.FileDrop, True), String())
            Dim files As New Collections.Generic.List(Of String)
            For Each s As String In filedrop : If My.App.HasImageFileExtension(s) AndAlso My.Computer.FileSystem.FileExists(s) Then files.Add(s)
            Next
            If files.Count > 0 Then : e.Effect = DragDropEffects.Copy
            Else : e.Effect = DragDropEffects.None
            End If
            files.Clear()
            files = Nothing
            filedrop = Nothing
        Else : e.Effect = DragDropEffects.None
        End If
    End Sub
    Private Sub BtnAlbumArtDragDrop(sender As Object, e As DragEventArgs) Handles btnAlbumArt.DragDrop
        If e.Effect = DragDropEffects.Copy Then
            Dim filedrop As String() = DirectCast(e.Data.GetData(DataFormats.FileDrop, True), String())
            Dim files As New Collections.Generic.List(Of String)
            For Each s As String In filedrop : If My.App.HasImageFileExtension(s) AndAlso My.Computer.FileSystem.FileExists(s) Then files.Add(s)
            Next
            If files.Count > 0 Then
                My.App.WriteToLog("Drag&Drop Performed (" + files.Count.ToString + " " + IIf(files.Count = 1, "Image", "Images").ToString + ")", False)
                For Each s As String In files : InsertArt(tlFile.Tag.Pictures.Length, My.App.ImageSource.File, s) : Next
            End If
            files.Clear()
            files = Nothing
            filedrop = Nothing
        End If
    End Sub
    Private Sub BtnAlbumArtMouseUp(sender As Object, e As MouseEventArgs) Handles btnAlbumArt.MouseUp
        If My.App.MouseInBounds(CType(sender, Control), e.Location) Then
            ValidateChildren()

            ' MULTI-FILE MODE: do NOT call ResetLyrics()
            If IsMultiFile Then
                cmAlbumArt.Show(btnAlbumArt, btnAlbumArt.PointToClient(MousePosition))
                Return
            End If

            ' SINGLE-FILE MODE
            If tlFile.Tag.Pictures.Length > 0 Then ResetLyrics()
            cmAlbumArt.Show(btnAlbumArt, btnAlbumArt.PointToClient(MousePosition))
            txbxAlbumArt.Focus()
        End If
    End Sub
    Private Sub BtnAlbumArtLeftMouseUp(sender As Object, e As MouseEventArgs) Handles btnAlbumArtLeft.MouseUp
        If e.Button = MouseButtons.Left AndAlso My.App.MouseInBounds(CType(sender, Control), e.Location) Then
            ValidateChildren()
            txbxAlbumArt.CausesValidation = False
            cobxAlbumArtType.CausesValidation = False

            ' MULTI-FILE MODE
            If IsMultiFile Then
                If nArt IsNot Nothing AndAlso nArt.Count > 0 Then
                    My.tagArtIndex -= 1
                    If My.tagArtIndex < 0 Then My.tagArtIndex = 0

                    ShowTagArtFromList(nArt)
                    UpdateArtLabel()
                    SetArtControlsMulti()
                End If

            Else
                ' SINGLE-FILE MODE
                If tlFile IsNot Nothing AndAlso tlFile.Tag.Pictures.Length > 0 Then
                    My.tagArtIndex -= 1
                    If My.tagArtIndex < 0 Then My.tagArtIndex = 0

                    ShowTagArt()
                    ResetLyrics()
                End If
            End If

            txbxAlbumArt.CausesValidation = True
            cobxAlbumArtType.CausesValidation = True
        End If
    End Sub
    Private Sub BtnAlbumArtRightMouseUp(sender As Object, e As MouseEventArgs) Handles btnAlbumArtRight.MouseUp
        If e.Button = MouseButtons.Left AndAlso My.App.MouseInBounds(CType(sender, Control), e.Location) Then
            ValidateChildren()
            txbxAlbumArt.CausesValidation = False
            cobxAlbumArtType.CausesValidation = False

            ' MULTI-FILE MODE
            If IsMultiFile Then
                If nArt IsNot Nothing AndAlso nArt.Count > 0 Then
                    My.tagArtIndex += 1
                    If My.tagArtIndex > nArt.Count - 1 Then My.tagArtIndex = nArt.Count - 1

                    ShowTagArtFromList(nArt)
                    UpdateArtLabel()
                    SetArtControlsMulti()
                End If

            Else
                ' SINGLE-FILE MODE
                If tlFile IsNot Nothing AndAlso tlFile.Tag.Pictures.Length > 0 Then
                    My.tagArtIndex += 1
                    If My.tagArtIndex > tlFile.Tag.Pictures.Length - 1 Then My.tagArtIndex = tlFile.Tag.Pictures.Length - 1

                    ShowTagArt()
                    ResetLyrics()
                End If
            End If

            txbxAlbumArt.CausesValidation = True
            cobxAlbumArtType.CausesValidation = True
        End If
    End Sub
    Private Sub BtnLyricsClick(sender As Object, e As EventArgs) Handles btnLyrics.Click
        wShowLyrics = Not wShowLyrics
        SetLyrics()
    End Sub

    ' Handlers
    Private Sub ClickTimer_Tick(sender As Object, e As EventArgs)
        'Clear double click watcher and timer
        inDoubleClick = False
        clickTimer.Stop()
        'Perform Single-Click Action
        If Not IsMultiFile Then
            If lblFileInfo.Text = App.sNoFile Then
                OpenFile()
            Else
                App.PlayMedia()
            End If
        End If
    End Sub

    ' Single-File
    Private Sub SetTag()
        ClearFile()
        ClearFiles()
        If String.IsNullOrEmpty(My.tagPath) Then
            tipInfo.SetText(lblFileInfo, My.App.sNoFile)
        Else
            Static fInfo As IO.FileInfo
            Static sExtendedInfo As String
            Try
                fInfo = New IO.FileInfo(My.tagPath)
                sExtendedInfo = fInfo.Name
                sExtendedInfo += vbCr + "@" + fInfo.DirectoryName
                sExtendedInfo += vbCr + Skye.Common.FormatFileSize(My.Computer.FileSystem.GetFileInfo(My.tagPath).Length, Skye.Common.FormatFileSizeUnits.Auto, 2, False)
                lblFileInfo.Text = fInfo.Name
                tlFile = TagLib.File.Create(My.tagPath)
                If tlFile.Tag.Performers Is Nothing Then tlFile.Tag.Performers = Array.Empty(Of String)()
                If tlFile.Properties IsNot Nothing Then
                    sExtendedInfo += vbCr + "Type: " + tlFile.Properties.MediaTypes.ToString + " (" + tlFile.Properties.Description + ")"
                    CoBoxGenre.Items.Clear()
                    Select Case tlFile.Properties.MediaTypes
                        Case TagLib.MediaTypes.Audio
                            For Each s As String In TagLib.Genres.Audio : CoBoxGenre.Items.Add(s) : Next
                            sExtendedInfo += vbCr + "Properties: "
                            Select Case tlFile.Properties.AudioChannels
                                Case 1 : sExtendedInfo += "Mono"
                                Case 2 : sExtendedInfo += "Stereo"
                                Case Else : sExtendedInfo += tlFile.Properties.AudioChannels.ToString + " channels"
                            End Select
                            sExtendedInfo += ", " + tlFile.Properties.AudioBitrate.ToString + " Kbps, " + tlFile.Properties.AudioSampleRate.ToString + " Hz"
                        Case TagLib.MediaTypes.Video Or TagLib.MediaTypes.Audio
                            For Each s As String In TagLib.Genres.Video : CoBoxGenre.Items.Add(s) : Next
                            sExtendedInfo += vbCr + "Properties: " + tlFile.Properties.VideoWidth.ToString + "x" + tlFile.Properties.VideoHeight.ToString + ", "
                            Select Case tlFile.Properties.AudioChannels
                                Case 1 : sExtendedInfo += "Mono"
                                Case 2 : sExtendedInfo += "Stereo"
                                Case Else : sExtendedInfo += tlFile.Properties.AudioChannels.ToString + " channels"
                            End Select
                            sExtendedInfo += ", " + tlFile.Properties.AudioBitrate.ToString + " Kbps, " + tlFile.Properties.AudioSampleRate.ToString + " Hz"
                        Case TagLib.MediaTypes.Photo : sExtendedInfo += vbCr + "Properties: " + tlFile.Properties.PhotoWidth.ToString + "x" + tlFile.Properties.PhotoHeight.ToString + IIf(tlFile.Properties.PhotoQuality > 0, ", Quality = " + tlFile.Properties.PhotoQuality.ToString, String.Empty).ToString
                    End Select
                End If
                sExtendedInfo += vbCr + "Tags: " + tlFile.TagTypes.ToString
                Me.tipInfo.SetText(lblFileInfo, sExtendedInfo)
                sExtendedInfo = Nothing
                My.tagArtistIndex = 0
                My.tagArtIndex = 0
                sPerformers = tlFile.Tag.Performers.ToList()
                sTitle = If(tlFile.Tag.Title, String.Empty)
                sAlbum = If(tlFile.Tag.Album, String.Empty)
                sGenre = If(tlFile.Tag.FirstGenre, String.Empty)
                sYear = If(tlFile.Tag.Year = Nothing OrElse tlFile.Tag.Year = 0, String.Empty, tlFile.Tag.Year.ToString())
                sTrack = If(tlFile.Tag.Track = Nothing OrElse tlFile.Tag.Track = 0, String.Empty, tlFile.Tag.Track.ToString())
                sTrackCount = If(tlFile.Tag.TrackCount = Nothing OrElse tlFile.Tag.TrackCount = 0, String.Empty, tlFile.Tag.TrackCount.ToString())
                sComment = If(tlFile.Tag.Comment, String.Empty)
                sLyrics = If(tlFile.Tag.Lyrics, String.Empty)
                sArt = ClonePictureList(tlFile.Tag.Pictures)
                My.App.WriteToLog("Tag Opened")
                MIPlay.Enabled = True
            Catch ex As TagLib.UnsupportedFormatException
                If My.Computer.FileSystem.DirectoryExists(My.tagPath) Then
                    My.App.WriteToLog("Tag NOT Opened (" + My.App.sNotFile + ")")
                    Me.tipInfo.SetText(Me.btnError, My.tagPath + vbCr + My.App.sNotFile)
                    My.AppAlertMessage = My.App.sNotFile
                Else
                    My.App.WriteToLog("Tag NOT Opened (" + My.App.sUnSupportedFile + ")")
                    Me.tipInfo.SetText(Me.btnError, My.tagPath + vbCr + My.App.sUnSupportedFile)
                    My.AppAlertMessage = My.App.sUnSupportedFile
                End If
                My.App.ErrorNotification()
                ClearFile()
            Catch ex As TagLib.CorruptFileException
                My.App.WriteToLog("Tag NOT Opened (" + My.App.sBadFile + ")")
                Me.tipInfo.SetText(Me.btnError, My.tagPath + vbCr + My.App.sBadFile)
                My.AppAlertMessage = My.App.sBadFile
                My.App.ErrorNotification()
                ClearFile()
            Catch ex As Xml.XmlException
                My.App.WriteToLog("Tag NOT Opened (" + My.App.sBadFile + ")")
                Me.tipInfo.SetText(Me.btnError, My.tagPath + vbCr + My.App.sBadFile)
                My.AppAlertMessage = My.App.sBadFile
                My.App.ErrorNotification()
                ClearFile()
            Catch ex As IO.FileNotFoundException
                My.App.WriteToLog("Tag NOT Opened (" + My.App.sNotFound + ")")
                Me.tipInfo.SetText(Me.btnError, My.tagPath + vbCr + My.App.sNotFound)
                My.AppAlertMessage = My.App.sNotFound
                My.App.ErrorNotification()
                ClearFile()
            Catch ex As IO.IOException
                My.App.WriteToLog("Tag NOT Opened (" + My.App.sUnAccessibleFile + ")")
                Me.tipInfo.SetText(Me.btnError, My.tagPath + vbCr + My.App.sUnAccessibleFile)
                My.AppAlertMessage = My.App.sUnAccessibleFile
                My.App.ErrorNotification()
                ClearFile()
            Catch ex As Exception
                My.App.WriteToLog("Tag NOT Opened (" + My.App.sError + ")")
                My.App.WriteToLog(ex.ToString, False)
                Me.tipInfo.SetText(Me.btnError, My.tagPath + vbCr + My.App.sError)
                My.AppAlertMessage = My.App.sError + vbCr + ex.ToString
                My.App.ErrorNotification()
                ClearFile()
            Finally
                sExtendedInfo = String.Empty
                sExtendedInfo = Nothing
                fInfo = Nothing
            End Try
        End If
    End Sub
    Private Sub ShowTag()
        Me.SuspendLayout()
        If tlFile Is Nothing OrElse tlFile.TagTypes = TagLib.TagTypes.None Then
            SetControls(False)
            Text = My.Application.Info.ProductName
        Else
            SetControls(True)
            Text = My.Application.Info.ProductName + IIf(String.IsNullOrEmpty(tlFile.Tag.FirstPerformer), String.Empty, " --> " + tlFile.Tag.FirstPerformer + IIf(String.IsNullOrEmpty(tlFile.Tag.Title), String.Empty, " / " + tlFile.Tag.Title).ToString + IIf(String.IsNullOrEmpty(tlFile.Tag.Album), String.Empty, " / " + tlFile.Tag.Album).ToString).ToString
            If tlFile.Tag.Performers.Length = 0 Then
                Me.lblArtist.Text = My.App.hArtist
                Me.txbxArtist.ResetText()
            Else
                Me.txbxArtist.Text = tlFile.Tag.Performers(My.tagArtistIndex)
                If tlFile.Tag.Performers.Length = 1 Then
                    Me.lblArtist.Text = My.App.hArtist
                Else
                    Me.lblArtist.Text = My.App.hArtist + " (" + (My.tagArtistIndex + 1).ToString + " of " + tlFile.Tag.Performers.Length.ToString + ")"
                End If
            End If
            CoBoxGenre.Text = tlFile.Tag.FirstGenre
            tipInfo.SetText(CoBoxGenre, Nothing)
            txbxTitle.Text = tlFile.Tag.Title
            txbxTrack.Text = IIf(tlFile.Tag.Track = 0, String.Empty, tlFile.Tag.Track).ToString
            tipInfo.SetText(txbxTrack, Nothing)
            txbxTrackCount.Text = IIf(tlFile.Tag.TrackCount = 0, String.Empty, tlFile.Tag.TrackCount.ToString).ToString
            tipInfo.SetText(txbxTrackCount, Nothing)
            If tlFile.Properties Is Nothing OrElse tlFile.Properties.Duration = TimeSpan.Zero Then
                Me.lblDuration.Enabled = False
                Me.txbxDuration.ResetText()
                Me.txbxDuration.Enabled = False
            Else
                If tlFile.Properties.Duration > New TimeSpan(0, 59, 59) Then : Me.txbxDuration.Text = tlFile.Properties.Duration.ToString("h\:mm\:ss")
                Else : Me.txbxDuration.Text = tlFile.Properties.Duration.ToString("m\:ss")
                End If
            End If
            txbxAlbum.Text = tlFile.Tag.Album
            txbxYear.Text = IIf(tlFile.Tag.Year = 0, String.Empty, tlFile.Tag.Year).ToString
            tipInfo.SetText(txbxYear, Nothing)
            txbxComments.Text = tlFile.Tag.Comment
            txbxLyrics.Text = tlFile.Tag.Lyrics
            txbxLyrics.Select(0, 0)
            ShowTagArt()
        End If
        If My.tagPath = String.Empty Then
            Me.lblFileInfo.Text = My.App.sNoFile
            Me.tipInfo.SetText(lblFileInfo, My.App.sNoFile)
        End If
        Me.ResumeLayout()
    End Sub
    Private Sub ShowTagArt()
        If tlFile.Tag.Pictures.Length > 0 Then
            If tlFile.Tag.Pictures.Length = 1 Then : Me.lblAlbumArt.Text = My.App.hArt
            Else : Me.lblAlbumArt.Text = My.App.hArt + " (" + (My.tagArtIndex + 1).ToString + " of " + tlFile.Tag.Pictures.Length.ToString + ")"
            End If
            Me.txbxAlbumArt.Text = tlFile.Tag.Pictures(App.tagArtIndex).Description
            Try
                Me.cobxAlbumArtType.SelectedIndex = tlFile.Tag.Pictures(App.tagArtIndex).Type
            Catch
                Me.cobxAlbumArtType.SelectedIndex = -1
            End Try
            Dim ms As New IO.MemoryStream(tlFile.Tag.Pictures(App.tagArtIndex).Data.Data)
            Try
                Me.picbxAlbumArt.Image = Image.FromStream(ms)
            Catch
                Me.picbxAlbumArt.Image = Nothing
            End Try
            ms.Dispose()
            ms = Nothing
            If Me.picbxAlbumArt.Image IsNot Nothing Then Me.tipInfo.SetText(Me.picbxAlbumArt, Me.picbxAlbumArt.Image.Size.Width.ToString + "x" + Me.picbxAlbumArt.Image.Size.Height.ToString + vbCr + tlFile.Tag.Pictures(My.tagArtIndex).MimeType + vbCr + Skye.Common.FormatFileSize(tlFile.Tag.Pictures(My.tagArtIndex).Data.Data.Length, Skye.Common.FormatFileSizeUnits.Auto))
        Else
            Me.lblAlbumArt.Text = My.App.hArt
            Me.lblAlbumArt.Enabled = False
            Me.btnAlbumArtLeft.Enabled = False
            Me.btnAlbumArtRight.Enabled = False
            Me.txbxAlbumArt.Enabled = False
            Me.cobxAlbumArtType.Enabled = False
            Me.btnLyrics.Visible = False
            If Not wShowLyrics Then
                wShowLyrics = True
                SetLyrics()
            End If
        End If
        SetArtControls(True)
    End Sub
    Private Sub SetArtistControls(enabled As Boolean)
        If enabled AndAlso tlFile IsNot Nothing AndAlso Not tlFile.TagTypes = TagLib.TagTypes.None AndAlso tlFile.Tag IsNot Nothing Then
            If tlFile.Tag.Performers.Length = 0 Then
                Me.btnArtistInsert.Enabled = False
            Else
                Me.btnArtistInsert.Enabled = True
            End If
            If tlFile.Tag.Performers.Length > 1 Then
                Me.btnArtistDelete.Enabled = True
                Select Case My.tagArtistIndex
                    Case 0
                        Me.btnArtistLeft.Enabled = False
                        Me.btnArtistRight.Enabled = True
                    Case tlFile.Tag.Performers.Length - 1
                        Me.btnArtistLeft.Enabled = True
                        Me.btnArtistRight.Enabled = False
                    Case Else
                        Me.btnArtistLeft.Enabled = True
                        Me.btnArtistRight.Enabled = True
                End Select
            Else
                Me.btnArtistDelete.Enabled = False
                Me.btnArtistLeft.Enabled = False
                Me.btnArtistRight.Enabled = False
            End If
        Else
            Me.btnArtistInsert.Enabled = False
            Me.btnArtistDelete.Enabled = False
            Me.btnArtistLeft.Enabled = False
            Me.btnArtistRight.Enabled = False
        End If
    End Sub
    Private Sub InsertArtist(Optional artist As String = Nothing)
        Dim alist As New Collections.Generic.List(Of String)
        For Each s As String In tlFile.Tag.Performers : alist.Add(s) : Next
        If String.IsNullOrEmpty(artist) Then : alist.Insert(alist.Count, "New " + My.App.hArtist)
        Else : alist.Insert(alist.Count, artist)
        End If
        tlFile.Tag.Performers = alist.ToArray
        My.tagArtistIndex = alist.Count - 1
        alist.Clear()
        alist = Nothing
        ShowTag()
        'SetSave()
    End Sub
    Private Sub MoveArtist(move As RMove)
        If tlFile.Tag.Performers.Length > 1 Then
            Dim alist As New Collections.Generic.List(Of String)
            For Each s As String In tlFile.Tag.Performers : alist.Add(s) : Next
            Dim smove As String = alist(My.tagArtistIndex)
            alist.RemoveAt(My.tagArtistIndex)
            Select Case move
                Case RMove.Left
                    alist.Insert(My.tagArtistIndex - 1, smove)
                    My.tagArtistIndex -= 1
                Case RMove.First
                    alist.Insert(0, smove)
                    My.tagArtistIndex = 0
                Case RMove.Right
                    alist.Insert(My.tagArtistIndex + 1, smove)
                    My.tagArtistIndex += 1
                Case RMove.Last
                    alist.Insert(alist.Count, smove)
                    My.tagArtistIndex = tlFile.Tag.Performers.Length - 1
            End Select
            tlFile.Tag.Performers = alist.ToArray
            smove = Nothing
            alist.Clear()
            alist = Nothing
            ShowTag()
            '    SetSave()
        End If
    End Sub
    Private Sub SetLyrics()
        Dim hover = App.Blend(Skye.UI.CurrentTheme.ButtonBack, Skye.UI.CurrentTheme.ButtonFore, 0.15)
        Dim pressed = App.Blend(Skye.UI.CurrentTheme.ButtonBack, Skye.UI.CurrentTheme.ButtonFore, 0.35)
        Dim toggleOnBack = App.Blend(Skye.UI.CurrentTheme.ButtonBack, Skye.UI.CurrentTheme.ButtonFore, 0.25)
        Dim toggleOnBorder = App.Blend(Skye.UI.CurrentTheme.ButtonBack, Skye.UI.CurrentTheme.ButtonFore, 0.45)
        If wShowLyrics Then
            panelAlbumArt.SendToBack()
            btnLyrics.BackColor = toggleOnBack
            btnLyrics.FlatAppearance.BorderColor = toggleOnBorder
            btnLyrics.FlatAppearance.MouseOverBackColor = hover
            btnLyrics.FlatAppearance.MouseDownBackColor = pressed
            btnLyrics.ForeColor = Skye.UI.CurrentTheme.ButtonFore
            txbxLyrics.Focus()
        Else
            txbxLyrics.SendToBack()
            btnLyrics.BackColor = Skye.UI.CurrentTheme.ButtonBack
            btnLyrics.FlatAppearance.BorderColor = Skye.UI.CurrentTheme.ButtonFore
            btnLyrics.FlatAppearance.MouseOverBackColor = hover
            btnLyrics.FlatAppearance.MouseDownBackColor = pressed
            btnLyrics.ForeColor = Skye.UI.CurrentTheme.ButtonFore
        End If
    End Sub
    Private Sub ResetLyrics()
        If wShowLyrics Then
            wShowLyrics = False
            SetLyrics()
        End If
    End Sub
    Private Sub ClearFile()
        If tlFile IsNot Nothing Then
            tlFile.Dispose()
            tlFile = Nothing
        End If
    End Sub

    ' Multi-File
    Private Sub LoadTags()
        If tagPaths Is Nothing OrElse tagPaths.Count = 0 Then Exit Sub

        If tagPaths.Count = 1 Then
            ' Single-file mode (use existing logic)
            tagPath = tagPaths(0)
            SetTag()
            ShowTag()
            Exit Sub
        End If

        ' Multi-file mode
        ClearFile()
        MIPlay.Enabled = False
        SetControls(True)
        LoadMergedTags()
        DisableArtistControls()
    End Sub
    Private Sub LoadMergedTags()
        ' Multi-file mode: merge tags across App._paths

        ' Reset UI state
        NeedsSaved = False
        btnSave.Enabled = False
        btnRestore.Enabled = False

        ' Reset merged originals
        oArtist = Nothing
        oTitle = Nothing
        oAlbum = Nothing
        oGenre = Nothing
        oYear = Nothing
        oTrack = Nothing
        oTrackCount = Nothing
        oComments = Nothing
        oLyrics = Nothing

        oArt = New List(Of TagLib.IPicture)
        nArt = New List(Of TagLib.IPicture)

        ' ============================================================
        '   LOAD ALL TAGLIB FILES ONCE
        ' ============================================================
        Dim tagFiles As New List(Of TagLib.File)

        For Each path In App.tagPaths
            Try
                Dim f = TagLib.File.Create(path)
                tagFiles.Add(f)
                App.WriteToLog("Tag Opened (" & path & ")")
            Catch ex As Exception
                App.WriteToLog("Error reading file during merge: " & path)
            End Try
        Next

        ' Loop through all files
        For Each tl In tagFiles
            If tl Is Nothing Then Continue For

            ' --- MERGE FIRST ARTIST ONLY ---
            Dim firstArtist As String = ""
            If tl.Tag.Performers IsNot Nothing AndAlso tl.Tag.Performers.Length > 0 Then
                firstArtist = tl.Tag.Performers(0)
            End If
            If oArtist Is Nothing Then
                oArtist = firstArtist
            ElseIf oArtist <> firstArtist Then
                oArtist = multiMessage
            End If

            ' --- MERGE TITLE ---
            Dim title As String = If(String.IsNullOrWhiteSpace(tl.Tag.Title), "", tl.Tag.Title)
            If oTitle Is Nothing Then
                oTitle = title
            ElseIf oTitle <> title Then
                oTitle = multiMessage
            End If

            ' --- MERGE ALBUM ---
            Dim album As String = If(String.IsNullOrWhiteSpace(tl.Tag.Album), "", tl.Tag.Album)
            If oAlbum Is Nothing Then
                oAlbum = album
            ElseIf oAlbum <> album Then
                oAlbum = multiMessage
            End If

            ' --- MERGE GENRE ---
            Dim genre As String = ""
            If tl.Tag.Genres IsNot Nothing AndAlso tl.Tag.Genres.Length > 0 Then
                genre = tl.Tag.Genres(0)
            End If
            If oGenre Is Nothing Then
                oGenre = genre
            ElseIf oGenre <> genre Then
                oGenre = multiMessage
            End If

            ' --- MERGE YEAR ---
            Dim year As String = If(tl.Tag.Year = 0UI, "", tl.Tag.Year.ToString())
            If oYear Is Nothing Then
                oYear = year
            ElseIf oYear <> year Then
                oYear = multiMessage
            End If

            ' --- MERGE TRACK ---
            Dim track As String = If(tl.Tag.Track = 0UI, "", tl.Tag.Track.ToString())
            If oTrack Is Nothing Then
                oTrack = track
            ElseIf oTrack <> track Then
                oTrack = multiMessage
            End If

            ' --- MERGE TRACK COUNT ---
            Dim trackCount As String = If(tl.Tag.TrackCount = 0UI, "", tl.Tag.TrackCount.ToString())
            If oTrackCount Is Nothing Then
                oTrackCount = trackCount
            ElseIf oTrackCount <> trackCount Then
                oTrackCount = multiMessage
            End If

            ' --- MERGE COMMENTS ---
            Dim comments As String = If(String.IsNullOrWhiteSpace(tl.Tag.Comment), "", tl.Tag.Comment)
            If oComments Is Nothing Then
                oComments = comments
            ElseIf oComments <> comments Then
                oComments = multiMessage
            End If

            ' --- MERGE LYRICS ---
            Dim lyrics As String = If(String.IsNullOrWhiteSpace(tl.Tag.Lyrics), "", tl.Tag.Lyrics)
            If oLyrics Is Nothing Then
                oLyrics = lyrics
            ElseIf oLyrics <> lyrics Then
                oLyrics = multiMessage
            End If

            tl.Dispose()
        Next

        ' ============================================================
        '   MERGE ARTWORK
        ' ============================================================

        ' Try to aggregate artwork across files
        oArt = AggregatePictures(tagFiles)

        ' Clone into editable list
        nArt = ClonePictures(oArt)

        ' Reset index
        My.tagArtIndex = 0

        ' ============================================================
        '   MULTI-FILE ARTWORK ANALYSIS
        ' ============================================================
        Dim hasAnyArt As Boolean = False
        Dim allArtIdentical As Boolean = True
        Dim firstPic As TagLib.IPicture = Nothing
        For Each f In tagFiles
            Try
                If f IsNot Nothing AndAlso f.Tag.Pictures IsNot Nothing AndAlso f.Tag.Pictures.Length > 0 Then
                    hasAnyArt = True
                    If firstPic Is Nothing Then
                        firstPic = f.Tag.Pictures(0)
                    Else
                        If Not PicturesEqual(firstPic, f.Tag.Pictures(0)) Then
                            allArtIdentical = False
                        End If
                    End If
                End If
            Finally
                If f IsNot Nothing Then f.Dispose()
            End Try
        Next
        ' Flags for later UI override
        Dim noArtDetected As Boolean = Not hasAnyArt
        Dim mixedArtDetected As Boolean = (hasAnyArt AndAlso Not allArtIdentical)
        If noArtDetected Then
            ' No artwork in ANY file → show lyrics
            wShowLyrics = True
            picbxAlbumArt.Image = Nothing
            lblAlbumArt.Text = ""
            nArt.Clear()
        ElseIf mixedArtDetected Then
            ' Mixed artwork → show Mixed Art placeholder
            wShowLyrics = False
            picbxAlbumArt.Image = My.Resources.Resources.ImageMixedImages
            lblAlbumArt.Text = "Mixed Art"
            nArt.Clear() ' disable navigation
            btnAlbumArtLeft.Enabled = False
            btnAlbumArtRight.Enabled = False
        Else
            ' Identical artwork → normal behavior
            wShowLyrics = False
            If nArt IsNot Nothing AndAlso nArt.Count > 0 Then
                ' Display artwork (only once)
                ShowTagArtFromList(nArt)
                lblAlbumArt.Text = $"1 of {nArt.Count}"
                ' Update label + arrows
                UpdateArtLabel()
            Else
                lblAlbumArt.Text = ""
            End If
        End If

        ' ============================================================
        '   POPULATE UI FIELDS
        ' ============================================================

        txbxArtist.Text = oArtist
        txbxTitle.Text = oTitle
        txbxAlbum.Text = oAlbum
        If oGenre = multiMessage Then
            CoBoxGenre.Text = multiMessageShort
            tipInfo.SetText(CoBoxGenre, oGenre)
        Else
            CoBoxGenre.Text = oGenre
            tipInfo.SetText(CoBoxGenre, Nothing)
        End If
        If oYear = multiMessage Then
            txbxYear.Text = multiMessageShorter
            tipInfo.SetText(txbxYear, oYear)
        Else
            txbxYear.Text = oYear
            tipInfo.SetText(txbxYear, Nothing)
        End If
        If oTrack = multiMessage Then
            txbxTrack.Text = multiMessageShorter
            tipInfo.SetText(txbxTrack, oTrack)
        Else
            txbxTrack.Text = oTrack
            tipInfo.SetText(txbxTrack, Nothing)
        End If
        If oTrackCount = multiMessage Then
            txbxTrackCount.Text = multiMessageShorter
            tipInfo.SetText(txbxTrackCount, oTrackCount)
        Else
            txbxTrackCount.Text = oTrackCount
            tipInfo.SetText(txbxTrackCount, Nothing)
        End If
        txbxDuration.Text = multiMessageShorter
        txbxComments.Text = oComments
        txbxLyrics.Text = oLyrics

        ' Disable multi-artist UI
        DisableArtistControls()
        CheckDirtyState()

        ' Update window title & file info
        Text = My.Application.Info.ProductName & " < Multiple Files > (" & App.tagPaths.Count.ToString() & ")"
        lblFileInfo.Text = " < Multiple Files > (" & App.tagPaths.Count.ToString() & ")"
        tipInfo.SetText(lblFileInfo, String.Join(vbCr, App.tagPaths.Select(Function(p) IO.Path.GetFileName(p))))

        For Each f In tagFiles
            f.Dispose()
        Next

    End Sub
    Private Sub SaveTags()
        ' Nothing to save?
        If Not NeedsSaved Then Exit Sub

        Dim failedPaths As New List(Of String)
        Dim savedCount As Integer = 0

        For Each path As String In App.tagPaths
            Try
                Using tl As TagLib.File = TagLib.File.Create(path)

                    ' ============================
                    '   FIRST ARTIST (PRIMARY ONLY)
                    ' ============================
                    If txbxArtist.Text <> multiMessage AndAlso oArtist <> txbxArtist.Text Then

                        Dim existing() As String = tl.Tag.Performers
                        ' Write new first artist
                        Dim newList As New List(Of String) From {
                            txbxArtist.Text
                        }

                        ' Preserve secondary artists
                        If existing IsNot Nothing AndAlso existing.Length > 1 Then
                            For i As Integer = 1 To existing.Length - 1
                                newList.Add(existing(i))
                            Next
                        End If

                        tl.Tag.Performers = newList.ToArray()
                    End If


                    ' ============================
                    '   TITLE
                    ' ============================
                    If txbxTitle.Text <> multiMessage AndAlso oTitle <> txbxTitle.Text Then
                        tl.Tag.Title = txbxTitle.Text
                    End If


                    ' ============================
                    '   ALBUM
                    ' ============================
                    If txbxAlbum.Text <> multiMessage AndAlso oAlbum <> txbxAlbum.Text Then
                        tl.Tag.Album = txbxAlbum.Text
                    End If


                    ' ============================
                    '   GENRE (PRIMARY ONLY)
                    ' ============================
                    If CoBoxGenre.Text <> multiMessageShort AndAlso oGenre <> CoBoxGenre.Text Then

                        Dim existing() As String = tl.Tag.Genres
                        ' Write new first genre
                        Dim newList As New List(Of String) From {
                            CoBoxGenre.Text
                        }

                        ' Preserve secondary genres
                        If existing IsNot Nothing AndAlso existing.Length > 1 Then
                            For i As Integer = 1 To existing.Length - 1
                                newList.Add(existing(i))
                            Next
                        End If

                        tl.Tag.Genres = newList.ToArray()
                    End If


                    ' ============================
                    '   YEAR
                    ' ============================
                    If txbxYear.Text <> multiMessageShorter AndAlso oYear <> txbxYear.Text Then
                        If txbxYear.Text = "" Then
                            tl.Tag.Year = 0UI
                        Else
                            tl.Tag.Year = Convert.ToUInt32(txbxYear.Text)
                        End If
                    End If


                    ' ============================
                    '   TRACK NUMBER
                    ' ============================
                    If txbxTrack.Text <> multiMessageShorter AndAlso oTrack <> txbxTrack.Text Then
                        If txbxTrack.Text = "" Then
                            tl.Tag.Track = 0UI
                        Else
                            tl.Tag.Track = Convert.ToUInt32(txbxTrack.Text)
                        End If
                    End If


                    ' ============================
                    '   TRACK COUNT
                    ' ============================
                    If txbxTrackCount.Text <> multiMessageShorter AndAlso oTrackCount <> txbxTrackCount.Text Then
                        If txbxTrackCount.Text = "" Then
                            tl.Tag.TrackCount = 0UI
                        Else
                            tl.Tag.TrackCount = Convert.ToUInt32(txbxTrackCount.Text)
                        End If
                    End If


                    ' ============================
                    '   COMMENTS
                    ' ============================
                    If txbxComments.Text <> multiMessage AndAlso oComments <> txbxComments.Text Then
                        tl.Tag.Comment = txbxComments.Text
                    End If


                    ' ============================
                    '   ARTWORK
                    ' ============================
                    If Not PicturesEqual(nArt, oArt) Then
                        tl.Tag.Pictures = nArt.ToArray()
                    End If


                    ' ============================
                    '   LYRICS
                    ' ============================
                    If txbxLyrics.Text <> multiMessage AndAlso oLyrics <> txbxLyrics.Text Then
                        tl.Tag.Lyrics = txbxLyrics.Text
                    End If


                    ' ============================
                    '   SAVE FILE
                    ' ============================
                    tl.Save()
                    App.WriteToLog("Tag Saved: " & path, False)
                End Using

                savedCount += 1

            Catch ioEx As IO.IOException
                failedPaths.Add(path)
                App.WriteToLog("File In Use, Cannot Save Tag: " & path & vbCrLf & ioEx.Message, False)

            Catch unauthEx As UnauthorizedAccessException
                failedPaths.Add(path)
                App.WriteToLog("Access Denied While Saving Tag: " & path & vbCrLf & unauthEx.Message, False)
            Catch ex As Exception
                failedPaths.Add(path)
                App.WriteToLog("TagLib Error While Saving Tag: " & path & vbCrLf & ex.Message, False)
            End Try
        Next


        ' ============================
        '   POST-SAVE UI UPDATE
        ' ============================
        If failedPaths.Count = 0 Then
            NeedsSaved = False
            btnSave.Enabled = False
            btnRestore.Enabled = False
            LoadMergedTags()
            tipInfo.ShowTooltipAtCursor("Tag" & If(savedCount > 1, "s", String.Empty) & " Saved Successfully (" & savedCount.ToString() & ")", My.Resources.Resources.ImageOK32)
        Else
            Dim msg As String = If(failedPaths.Count = 1,
               "1 file failed to save. Check log.",
               failedPaths.Count.ToString() & " files failed to save. Check log.")
            'tipInfo.ShowTooltipAtCursor(msg, SystemIcons.Error.ToBitmap)
            My.AppAlertMessage = msg
            My.App.ErrorNotification()
        End If
    End Sub
    Private Sub ShowTagArtFromList(pics As List(Of TagLib.IPicture))

        ' Ensure artwork panel is visible in multi-file mode
        ' MULTI-FILE: re-enable artwork UI
        If IsMultiFile Then
            lblAlbumArt.Enabled = True
            btnAlbumArtLeft.Enabled = (nArt.Count > 1 AndAlso My.tagArtIndex > 0)
            btnAlbumArtRight.Enabled = (nArt.Count > 1 AndAlso My.tagArtIndex < nArt.Count - 1)
            txbxAlbumArt.Enabled = True
            cobxAlbumArtType.Enabled = True

            btnLyrics.Visible = True
            wShowLyrics = False
            SetLyrics()   ' This switches back to the ART panel when wShowLyrics=False
        End If

        ' No artwork → clear UI completely
        If pics Is Nothing OrElse pics.Count = 0 Then
            picbxAlbumArt.Image = Nothing

            ' Clear text fields
            txbxAlbumArt.Text = ""
            cobxAlbumArtType.SelectedIndex = -1

            ' Reset label
            lblAlbumArt.Text = My.App.hArt
            lblAlbumArt.Enabled = False

            ' Disable art controls
            btnAlbumArtLeft.Enabled = False
            btnAlbumArtRight.Enabled = False
            txbxAlbumArt.Enabled = False
            cobxAlbumArtType.Enabled = False

            ' Multi-file: switch to lyrics mode (same behavior as ShowTag)
            If IsMultiFile Then
                btnLyrics.Visible = False
                If Not wShowLyrics Then
                    wShowLyrics = True
                    SetLyrics()
                End If
            End If

            Return
        End If

        ' Clamp index
        If My.tagArtIndex < 0 Then My.tagArtIndex = 0
        If My.tagArtIndex > pics.Count - 1 Then My.tagArtIndex = pics.Count - 1

        Dim pic As TagLib.IPicture = pics(My.tagArtIndex)

        ' Convert TagLib picture to Image
        Try
            Dim bytes() As Byte = pic.Data.Data
            Using ms As New IO.MemoryStream(bytes)
                picbxAlbumArt.Image = Image.FromStream(ms)
            End Using
        Catch
            picbxAlbumArt.Image = My.Resources.Resources.ImageCorruptImage
        End Try

        ' Update description textbox
        txbxAlbumArt.Text = If(pic.Description, String.Empty)

        ' Update picture type combobox
        Dim pType As TagLib.PictureType = pic.Type
        Dim index As Integer = cobxAlbumArtType.Items.IndexOf(pType.ToString())
        If index >= 0 Then
            cobxAlbumArtType.SelectedIndex = index
        Else
            cobxAlbumArtType.SelectedIndex = -1
        End If

        UpdateArtLabel()
    End Sub
    Private Function PicturesEqual(a As TagLib.IPicture, b As TagLib.IPicture) As Boolean
        ' Both nothing → equal
        If a Is Nothing AndAlso b Is Nothing Then Return True
        ' One nothing → not equal
        If a Is Nothing OrElse b Is Nothing Then Return False

        ' Compare type
        If a.Type <> b.Type Then Return False

        ' Compare description (Nothing vs "" counts as different, like your original logic)
        Dim descA As String = If(a.Description, String.Empty)
        Dim descB As String = If(b.Description, String.Empty)
        If Not String.Equals(descA, descB, StringComparison.Ordinal) Then Return False

        ' Compare data presence
        If a.Data Is Nothing AndAlso b.Data Is Nothing Then Return True
        If a.Data Is Nothing OrElse b.Data Is Nothing Then Return False

        ' Compare data length
        If a.Data.Count <> b.Data.Count Then Return False

        ' Compare raw bytes
        For i As Integer = 0 To a.Data.Count - 1
            If a.Data(i) <> b.Data(i) Then Return False
        Next

        Return True
    End Function
    Private Function PicturesEqual(listA As List(Of TagLib.IPicture), listB As List(Of TagLib.IPicture)) As Boolean
        If listA Is Nothing OrElse listB Is Nothing Then Return False
        If listA.Count <> listB.Count Then Return False

        For i As Integer = 0 To listA.Count - 1
            If Not PicturesEqual(listA(i), listB(i)) Then Return False
        Next

        Return True
    End Function
    Private Function PicturesEqual(list As List(Of TagLib.IPicture), pic As TagLib.IPicture) As Boolean
        If list Is Nothing OrElse pic Is Nothing Then Return False

        For Each p In list
            If PicturesEqual(p, pic) Then Return True
        Next

        Return False
    End Function
    Private Function PicturesEqual(pic As TagLib.IPicture, list As List(Of TagLib.IPicture)) As Boolean
        Return PicturesEqual(list, pic)
    End Function
    Private Function AggregatePictures(files As IEnumerable(Of TagLib.File)) As List(Of TagLib.IPicture)
        Dim basePics As List(Of TagLib.IPicture) = Nothing
        Dim conflict As Boolean = False

        For Each f In files
            Dim pics As List(Of TagLib.IPicture)

            If f.Tag.Pictures IsNot Nothing Then
                pics = f.Tag.Pictures.ToList()
            Else
                pics = New List(Of TagLib.IPicture)
            End If

            If basePics Is Nothing Then
                ' First file’s pictures become the baseline
                basePics = pics
            Else
                ' Compare count first
                If pics.Count <> basePics.Count Then
                    conflict = True
                    Exit For
                End If

                ' Compare each picture
                For i As Integer = 0 To pics.Count - 1
                    If Not PicturesEqual(pics(i), basePics(i)) Then
                        conflict = True
                        Exit For
                    End If
                Next
            End If
        Next

        If conflict OrElse basePics Is Nothing Then
            Return New List(Of TagLib.IPicture)
        Else
            Return basePics
        End If
    End Function
    Private Function ClonePictures(src As List(Of TagLib.IPicture)) As List(Of TagLib.IPicture)
        Dim result As New List(Of TagLib.IPicture)
        For Each pic In src
            Dim clone As New TagLib.Picture(pic.Data) With {
                .Type = pic.Type,
                .Description = pic.Description}
            result.Add(clone)
        Next
        Return result
    End Function
    Private Sub DisableArtistControls()
        btnArtistLeft.Enabled = False
        btnArtistRight.Enabled = False
        btnArtistInsert.Enabled = False
        btnArtistDelete.Enabled = False
    End Sub
    Private Sub SetArtControlsMulti()
        If nArt Is Nothing OrElse nArt.Count = 0 Then
            btnAlbumArt.Enabled = False
            btnAlbumArtLeft.Enabled = False
            btnAlbumArtRight.Enabled = False
            Exit Sub
        End If

        btnAlbumArt.Enabled = True

        Select Case nArt.Count
            Case 1
                btnAlbumArtLeft.Enabled = False
                btnAlbumArtRight.Enabled = False

            Case Else
                If My.tagArtIndex <= 0 Then
                    btnAlbumArtLeft.Enabled = False
                    btnAlbumArtRight.Enabled = True
                ElseIf My.tagArtIndex >= nArt.Count - 1 Then
                    btnAlbumArtLeft.Enabled = True
                    btnAlbumArtRight.Enabled = False
                Else
                    btnAlbumArtLeft.Enabled = True
                    btnAlbumArtRight.Enabled = True
                End If
        End Select
    End Sub
    Private Sub UpdateArtLabel()

        If IsMultiFile Then
            If nArt Is Nothing OrElse nArt.Count = 0 Then
                lblAlbumArt.Text = "No Artwork"
            Else
                lblAlbumArt.Text = $"{My.tagArtIndex + 1} of {nArt.Count}"
            End If
            Exit Sub
        End If

        ' SINGLE-FILE
        If tlFile.Tag.Pictures.Length = 0 Then
            lblAlbumArt.Text = "No Artwork"
        Else
            lblAlbumArt.Text = $"{tagArtIndex + 1} of {tlFile.Tag.Pictures.Length}"
        End If

    End Sub
    Private Sub ClearFiles()
        If App.tagPaths IsNot Nothing Then
            App.tagPaths.Clear()
            App.tagPaths = Nothing
        End If
    End Sub

    ' Methods
    Private Sub CheckDirtyState()
        Dim dirty As Boolean = False

        ' ============================
        ' MULTI-FILE MODE
        ' ============================
        If App.IsMultiFile Then

            ' Artist
            If txbxArtist.Text <> multiMessage AndAlso txbxArtist.Text <> oArtist Then
                lblArtist.Font = New Font(lblArtist.Font, FontStyle.Bold)
                dirty = True
            Else
                lblArtist.Font = New Font(lblArtist.Font, FontStyle.Regular)
            End If

            ' Title
            If txbxTitle.Text <> multiMessage AndAlso txbxTitle.Text <> oTitle Then
                lblTitle.Font = New Font(lblTitle.Font, FontStyle.Bold)
                dirty = True
            Else
                lblTitle.Font = New Font(lblTitle.Font, FontStyle.Regular)
            End If

            ' Album
            If txbxAlbum.Text <> multiMessage AndAlso txbxAlbum.Text <> oAlbum Then
                lblAlbum.Font = New Font(lblAlbum.Font, FontStyle.Bold)
                dirty = True
            Else
                lblAlbum.Font = New Font(lblAlbum.Font, FontStyle.Regular)
            End If

            ' Genre
            If CoBoxGenre.Text <> multiMessageShort AndAlso CoBoxGenre.Text <> oGenre Then
                lblGenre.Font = New Font(lblGenre.Font, FontStyle.Bold)
                dirty = True
            Else
                lblGenre.Font = New Font(lblGenre.Font, FontStyle.Regular)
            End If

            ' Year
            If txbxYear.Text <> multiMessageShorter AndAlso txbxYear.Text <> oYear Then
                lblYear.Font = New Font(lblYear.Font, FontStyle.Bold)
                dirty = True
            Else
                lblYear.Font = New Font(lblYear.Font, FontStyle.Regular)
            End If

            ' Track + TrackCount
            If (txbxTrack.Text <> multiMessageShorter AndAlso txbxTrack.Text <> oTrack) _
        OrElse (txbxTrackCount.Text <> multiMessageShorter AndAlso txbxTrackCount.Text <> oTrackCount) Then
                lblTrack.Font = New Font(lblTrack.Font, FontStyle.Bold)
                dirty = True
            Else
                lblTrack.Font = New Font(lblTrack.Font, FontStyle.Regular)
            End If

            ' Comments
            If txbxComments.Text <> multiMessage AndAlso txbxComments.Text <> oComments Then
                lblComments.Font = New Font(lblComments.Font, FontStyle.Bold)
                dirty = True
            Else
                lblComments.Font = New Font(lblComments.Font, FontStyle.Regular)
            End If

            ' Lyrics
            If txbxLyrics.Text <> multiMessage AndAlso txbxLyrics.Text <> oLyrics Then
                dirty = True
            End If

            ' Artwork
            If Not PicturesEqual(nArt, oArt) Then
                lblAlbumArt.Font = New Font(lblAlbumArt.Font, FontStyle.Bold)
                dirty = True
            Else
                lblAlbumArt.Font = New Font(lblAlbumArt.Font, FontStyle.Regular)
            End If


            ' ============================
            ' SINGLE-FILE MODE
            ' ============================
        Else

            ' Artist
            Dim currentPerformers As List(Of String) = New List(Of String)
            If tlFile IsNot Nothing Then currentPerformers = If(tlFile.Tag.Performers IsNot Nothing, tlFile.Tag.Performers.ToList(), New List(Of String))
            If Not currentPerformers.SequenceEqual(sPerformers) Then
                lblArtist.Font = New Font(lblArtist.Font, FontStyle.Bold)
                dirty = True
            Else
                lblArtist.Font = New Font(lblArtist.Font, FontStyle.Regular)
            End If

            ' Title
            If txbxTitle.Text <> sTitle Then
                lblTitle.Font = New Font(lblTitle.Font, FontStyle.Bold)
                dirty = True
            Else
                lblTitle.Font = New Font(lblTitle.Font, FontStyle.Regular)
            End If

            ' Album
            If txbxAlbum.Text <> sAlbum Then
                lblAlbum.Font = New Font(lblAlbum.Font, FontStyle.Bold)
                dirty = True
            Else
                lblAlbum.Font = New Font(lblAlbum.Font, FontStyle.Regular)
            End If

            ' Genre
            If CoBoxGenre.Text <> sGenre Then
                lblGenre.Font = New Font(lblGenre.Font, FontStyle.Bold)
                dirty = True
            Else
                lblGenre.Font = New Font(lblGenre.Font, FontStyle.Regular)
            End If

            ' Year
            If txbxYear.Text <> sYear Then
                lblYear.Font = New Font(lblYear.Font, FontStyle.Bold)
                dirty = True
            Else
                lblYear.Font = New Font(lblYear.Font, FontStyle.Regular)
            End If

            ' Track + TrackCount
            If txbxTrack.Text <> sTrack OrElse txbxTrackCount.Text <> sTrackCount Then
                lblTrack.Font = New Font(lblTrack.Font, FontStyle.Bold)
                dirty = True
            Else
                lblTrack.Font = New Font(lblTrack.Font, FontStyle.Regular)
            End If

            ' Comments
            If txbxComments.Text <> sComment Then
                lblComments.Font = New Font(lblComments.Font, FontStyle.Bold)
                dirty = True
            Else
                lblComments.Font = New Font(lblComments.Font, FontStyle.Regular)
            End If

            ' Lyrics
            If txbxLyrics.Text <> sLyrics Then
                dirty = True
            End If

            'Artwork
            If tlFile IsNot Nothing Then
                If Not PicturesEqual(tlFile.Tag.Pictures.ToList, sArt) Then
                    lblAlbumArt.Font = New Font(lblAlbumArt.Font, FontStyle.Bold)
                    dirty = True
                Else
                    lblAlbumArt.Font = New Font(lblAlbumArt.Font, FontStyle.Regular)
                End If
            End If


        End If

        ' ============================
        ' FINAL STATE
        ' ============================
        NeedsSaved = dirty
        If dirty Then
            btnSave.ForeColor = Color.Firebrick
            btnSave.Font = New Font(Me.Font, FontStyle.Bold)
        Else
            btnSave.ResetFont()
            btnSave.ResetForeColor()
        End If
        btnSave.Enabled = dirty
        btnRestore.Enabled = dirty

    End Sub
    Private Sub SetControls(enabled As Boolean)
        Me.lblArtist.Enabled = enabled
        SetArtistControls(enabled)
        Me.txbxArtist.ResetText()
        Me.txbxArtist.Enabled = enabled
        Me.lblGenre.Enabled = enabled
        Me.CoBoxGenre.ResetText()
        Me.CoBoxGenre.Enabled = enabled
        Me.lblTitle.Enabled = enabled
        Me.txbxTitle.ResetText()
        Me.txbxTitle.Enabled = enabled
        Me.lblTrack.Enabled = enabled
        Me.txbxTrack.ResetText()
        Me.txbxTrack.Enabled = enabled
        Me.lblTrackSeparator.Enabled = enabled
        Me.txbxTrackCount.ResetText()
        Me.txbxTrackCount.Enabled = enabled
        Me.lblDuration.Enabled = enabled
        Me.txbxDuration.ResetText()
        Me.txbxDuration.Enabled = enabled
        Me.lblAlbum.Enabled = enabled
        Me.txbxAlbum.ResetText()
        Me.txbxAlbum.Enabled = enabled
        Me.lblYear.Enabled = enabled
        Me.txbxYear.ResetText()
        Me.txbxYear.Enabled = enabled
        Me.lblComments.Enabled = enabled
        Me.txbxComments.ResetText()
        Me.txbxComments.Enabled = enabled
        Me.lblAlbumArt.Text = My.App.hArt
        lblAlbumArt.ResetFont()
        Me.lblAlbumArt.Enabled = enabled
        SetArtControls(enabled)
        Me.txbxAlbumArt.ResetText()
        Me.txbxAlbumArt.Enabled = enabled
        If tlFile Is Nothing OrElse tlFile.TagTypes = TagLib.TagTypes.None OrElse tlFile.Tag.Pictures.Length = 0 Then 'This is done to prevent blinking because of custom draw. This way, the draw event is not triggered so often.
            Me.cobxAlbumArtType.SelectedItem = Nothing
        End If
        Me.cobxAlbumArtType.Enabled = enabled
        Me.picbxAlbumArt.Image = Nothing
        Me.panelAlbumArt.Enabled = enabled
        If tlFile Is Nothing OrElse tlFile.TagTypes = TagLib.TagTypes.None OrElse tlFile.Properties IsNot Nothing AndAlso tlFile.Properties.MediaTypes = TagLib.MediaTypes.Photo Then 'This is done to prevent blinking.
            ResetLyrics()
            Me.txbxLyrics.ResetText()
        End If
        Me.btnLyrics.Visible = enabled
        If enabled Then
            If NeedsSaved Then
                btnSave.Enabled = True
                btnRestore.Enabled = True
            Else
                btnSave.Enabled = False
                btnSave.ResetFont()
                btnRestore.Enabled = False
            End If
        Else
            btnSave.Enabled = False
            btnSave.ResetFont()
            btnRestore.Enabled = False
        End If
    End Sub
    Private Sub SetArtControls(enabled As Boolean)

        If enabled AndAlso (
                    (tlFile IsNot Nothing _
                    AndAlso tlFile.TagTypes <> TagLib.TagTypes.None _
                    AndAlso tlFile.Properties IsNot Nothing _
                    AndAlso tlFile.Properties.MediaTypes <> TagLib.MediaTypes.Photo) _
                    Or App.IsMultiFile) _
        Then
            Me.btnAlbumArt.Enabled = True
            ' MULTI-FILE: tlFile is Nothing, use nArt
            If App.IsMultiFile Then
                Select Case nArt.Count
                    Case 0, 1
                        Me.btnAlbumArtLeft.Enabled = False
                        Me.btnAlbumArtRight.Enabled = False
                    Case Else
                        Select Case My.tagArtIndex
                            Case 0
                                Me.btnAlbumArtLeft.Enabled = False
                                Me.btnAlbumArtRight.Enabled = True
                            Case nArt.Count - 1
                                Me.btnAlbumArtLeft.Enabled = True
                                Me.btnAlbumArtRight.Enabled = False
                            Case Else
                                Me.btnAlbumArtLeft.Enabled = True
                                Me.btnAlbumArtRight.Enabled = True
                        End Select
                End Select
            Else ' SINGLE-FILE: your original logic
                Select Case tlFile.Tag.Pictures.Length
                    Case 0, 1
                        Me.btnAlbumArtLeft.Enabled = False
                        Me.btnAlbumArtRight.Enabled = False
                    Case Else
                        Select Case My.tagArtIndex
                            Case 0
                                Me.btnAlbumArtLeft.Enabled = False
                                Me.btnAlbumArtRight.Enabled = True
                            Case tlFile.Tag.Pictures.Length - 1
                                Me.btnAlbumArtLeft.Enabled = True
                                Me.btnAlbumArtRight.Enabled = False
                            Case Else
                                Me.btnAlbumArtLeft.Enabled = True
                                Me.btnAlbumArtRight.Enabled = True
                        End Select
                End Select
            End If
        Else
            Me.btnAlbumArt.Enabled = False
            Me.btnAlbumArtLeft.Enabled = False
            Me.btnAlbumArtRight.Enabled = False
        End If

    End Sub
    Private Sub UpdateArt(picsource As My.App.ImageSource)

        Dim newpic As TagLib.IPicture = GetNewPic(picsource)

        If newpic Is Nothing Then
            If picsource = My.App.ImageSource.ClipBoard Then
                tipInfo.ShowTooltip(btnAlbumArt, "No Image On ClipBoard", SystemIcons.Information.ToBitmap)
            End If
            Exit Sub
        End If

        ' ============================
        '   MULTI-FILE MODE
        ' ============================
        If IsMultiFile Then

            If nArt Is Nothing OrElse nArt.Count = 0 Then Exit Sub
            If My.tagArtIndex < 0 OrElse My.tagArtIndex >= nArt.Count Then Exit Sub

            ' Preserve metadata
            newpic.Description = nArt(My.tagArtIndex).Description
            newpic.Type = nArt(My.tagArtIndex).Type

            ' Replace in the editable list
            nArt(My.tagArtIndex) = newpic

            ' Update UI
            ShowTagArtFromList(nArt)

            ' Mark dirty
            CheckDirtyState()

            Exit Sub
        End If


        ' ============================
        '   SINGLE-FILE MODE
        ' ============================
        If tlFile.Tag.Pictures.Length > 0 Then

            Dim piclist As New List(Of TagLib.IPicture)
            For Each pic As TagLib.IPicture In tlFile.Tag.Pictures
                piclist.Add(pic)
            Next

            newpic.Description = tlFile.Tag.Pictures(tagArtIndex).Description
            newpic.Type = tlFile.Tag.Pictures(tagArtIndex).Type

            piclist(tagArtIndex) = newpic
            tlFile.Tag.Pictures = piclist.ToArray()

            ShowTag()
            '         SetSave()
            'SetDirtyStateForArt()
        End If

    End Sub
    Private Sub InsertArt(index As Integer, picsource As My.App.ImageSource, Optional picpath As String = Nothing)

        Dim newpic As TagLib.IPicture = My.App.GetNewPic(picsource, picpath)

        If newpic Is Nothing Then
            If picsource = My.App.ImageSource.ClipBoard Then
                tipInfo.ShowTooltip(btnAlbumArt, "No Image On ClipBoard", SystemIcons.Information.ToBitmap)
            End If
            Exit Sub
        End If


        ' ============================
        '   MULTI-FILE MODE
        ' ============================
        If IsMultiFile Then

            If nArt Is Nothing Then nArt = New List(Of TagLib.IPicture)

            ' Insert new picture
            If index < 0 OrElse index > nArt.Count Then index = nArt.Count
            nArt.Insert(index, newpic)

            ' Update index
            My.tagArtIndex = index

            ' Update UI
            ShowTagArtFromList(nArt)

            ' Mark dirty
            CheckDirtyState()

            Exit Sub
        End If


        ' ============================
        '   SINGLE-FILE MODE
        ' ============================
        If Not tlFile.TagTypes = TagLib.TagTypes.None Then

            Dim piclist As New List(Of TagLib.IPicture)
            For Each pic As TagLib.IPicture In tlFile.Tag.Pictures
                piclist.Add(pic)
            Next

            newpic.Description = Nothing
            newpic.Type = Nothing

            If index < 0 OrElse index > piclist.Count Then index = piclist.Count
            piclist.Insert(index, newpic)

            tlFile.Tag.Pictures = piclist.ToArray()

            My.tagArtIndex = index

            ShowTag()

            If wShowLyrics Then
                wShowLyrics = False
                SetLyrics()
            End If

            'SetSave()
            'SetDirtyStateForArt()
        End If

    End Sub
    Private Sub ExportArt(destination As ExportDestination)

        Dim pic As TagLib.IPicture

        ' Pick the correct picture source
        If App.IsMultiFile Then
            If nArt Is Nothing OrElse nArt.Count = 0 Then Exit Sub
            pic = nArt(My.tagArtIndex)
        Else
            If tlFile Is Nothing OrElse tlFile.Tag.Pictures.Length = 0 Then Exit Sub
            pic = tlFile.Tag.Pictures(My.tagArtIndex)
        End If


        Select Case destination

        ' ============================
        '  EXPORT TO CLIPBOARD
        ' ============================
            Case ExportDestination.Clipboard

                Using ms As New IO.MemoryStream(pic.Data.Data)
                    Computer.Clipboard.SetImage(Image.FromStream(ms))
                End Using


        ' ============================
        '  EXPORT TO FILE
        ' ============================
            Case ExportDestination.File, ExportDestination.BitmapFile

                Dim sfd As New SaveFileDialog With {
                .Title = "Save Image File"
            }

                Dim saveFormat As Imaging.ImageFormat

                If destination = ExportDestination.BitmapFile Then
                    saveFormat = Imaging.ImageFormat.Bmp
                    sfd.Filter = "Windows Bitmap Files|*.bmp"
                Else
                    Select Case pic.MimeType
                        Case "image/jpeg"
                            saveFormat = Imaging.ImageFormat.Jpeg
                            sfd.Filter = "JPEG Files|*.jpg;*.jpeg"
                        Case "image/png"
                            saveFormat = Imaging.ImageFormat.Png
                            sfd.Filter = "PNG Files|*.png"
                        Case Else
                            saveFormat = Imaging.ImageFormat.Bmp
                            sfd.Filter = "Windows Bitmap Files|*.bmp"
                    End Select
                End If

                sfd.Filter += "|All Files|*.*"

                If sfd.ShowDialog(Me) = DialogResult.OK AndAlso sfd.FileName <> "" Then
                    Using ms As New IO.MemoryStream(pic.Data.Data)
                        Using im As Image = Image.FromStream(ms)
                            im.Save(sfd.FileName, saveFormat)
                        End Using
                    End Using

                    WriteToLog("Album Art Exported To " & sfd.FileName)
                End If

                sfd.Dispose()

        End Select

    End Sub
    Private Sub MoveArt(move As RMove)

        ' ============================
        '   MULTI-FILE MODE
        ' ============================
        If IsMultiFile Then

            If nArt Is Nothing OrElse nArt.Count <= 1 Then Exit Sub
            If My.tagArtIndex < 0 OrElse My.tagArtIndex >= nArt.Count Then Exit Sub

            Dim movepic As TagLib.IPicture = nArt(My.tagArtIndex)
            nArt.RemoveAt(My.tagArtIndex)

            Select Case move
                Case RMove.Left
                    nArt.Insert(My.tagArtIndex - 1, movepic)
                    My.tagArtIndex -= 1

                Case RMove.First
                    nArt.Insert(0, movepic)
                    My.tagArtIndex = 0

                Case RMove.Right
                    nArt.Insert(My.tagArtIndex + 1, movepic)
                    My.tagArtIndex += 1

                Case RMove.Last
                    nArt.Insert(nArt.Count, movepic)
                    My.tagArtIndex = nArt.Count - 1
            End Select

            ShowTagArtFromList(nArt)
            CheckDirtyState()
            Exit Sub
        End If


        ' ============================
        '   SINGLE-FILE MODE
        ' ============================
        If tlFile.Tag.Pictures.Length > 1 Then

            Dim piclist As New List(Of TagLib.IPicture)
            For Each pic As TagLib.IPicture In tlFile.Tag.Pictures
                piclist.Add(pic)
            Next

            Dim movepic As TagLib.IPicture = piclist(My.tagArtIndex)
            piclist.RemoveAt(My.tagArtIndex)

            Select Case move
                Case RMove.Left
                    piclist.Insert(My.tagArtIndex - 1, movepic)
                    My.tagArtIndex -= 1

                Case RMove.First
                    piclist.Insert(0, movepic)
                    My.tagArtIndex = 0

                Case RMove.Right
                    piclist.Insert(My.tagArtIndex + 1, movepic)
                    My.tagArtIndex += 1

                Case RMove.Last
                    piclist.Insert(piclist.Count, movepic)
                    My.tagArtIndex = piclist.Count - 1
            End Select

            tlFile.Tag.Pictures = piclist.ToArray()

            ShowTag()
            ' SetSave()
            'SetDirtyStateForArt()
        End If

    End Sub
    Private Sub ClearSave()
        If NeedsSaved Then
            NeedsSaved = False
            Me.btnSave.ResetFont()
            Me.btnSave.ResetForeColor()
            btnRestore.Enabled = False
        End If
    End Sub
    Friend Sub SetError()
        Me.btnError.Visible = True
        If Not String.IsNullOrEmpty(My.AppAlertMessage) Then
            'tipInfo.Tag = SystemIcons.Error.ToBitmap
            'tipInfo.Show(My.AppAlertMessage, Me, Me.btnError.Right + SystemInformation.FrameBorderSize.Width, Me.btnError.Bottom + SystemInformation.FrameBorderSize.Height + SystemInformation.CaptionHeight)
            tipInfo.ShowTooltip(btnError, My.AppAlertMessage, SystemIcons.Error.ToBitmap)
        End If
    End Sub
    Friend Sub ClearError()
#If DEBUG Then
#Else
			Me.btnError.Visible = False
#End If
    End Sub
    Private Sub CopyTag(mode As App.CopyModes)
        If App.IsMultiFile Then
            tagCopy.Art.Clear()
            If nArt.Count > 0 Then
                For index As Integer = 0 To nArt.Count - 1
                    tagCopy.Art.Add(nArt(index))
                Next
            End If
        Else
            If tlFile IsNot Nothing Then
                tagCopy.Mode = mode
                If mode = App.CopyModes.Art Then
                    App.tagCopy.Artists.Clear()
                    tagCopy.Genre = String.Empty
                    tagCopy.Title = String.Empty
                    tagCopy.Track = 0
                    tagCopy.TrackCount = 0
                    tagCopy.Album = String.Empty
                    tagCopy.Year = 0
                    tagCopy.Comment = String.Empty
                Else
                    App.tagCopy.Artists.Clear()
                    For Each a As String In tlFile.Tag.Performers
                        App.tagCopy.Artists.Add(a)
                    Next
                    tagCopy.Genre = tlFile.Tag.FirstGenre
                    tagCopy.Title = tlFile.Tag.Title
                    tagCopy.Track = tlFile.Tag.Track
                    tagCopy.TrackCount = tlFile.Tag.TrackCount
                    tagCopy.Album = tlFile.Tag.Album
                    tagCopy.Year = tlFile.Tag.Year
                    tagCopy.Comment = tlFile.Tag.Comment
                End If
                If mode = App.CopyModes.Full OrElse mode = App.CopyModes.Art Then
                    tagCopy.Art.Clear()
                    If tlFile.Tag.Pictures.Length > 0 Then
                        For index As Integer = 0 To tlFile.Tag.Pictures.Length - 1
                            tagCopy.Art.Add(tlFile.Tag.Pictures(index))
                        Next
                    End If
                    If mode = App.CopyModes.Full Then
                        tagCopy.Lyrics = tlFile.Tag.Lyrics
                    Else
                        tagCopy.Lyrics = String.Empty
                    End If
                Else
                    tagCopy.Art.Clear()
                    tagCopy.Lyrics = String.Empty
                End If
            End If
        End If
    End Sub
    Private Sub PasteTag()
        If App.IsMultiFile Then
            If App.tagCopy.Art.Count > 0 Then
                nArt = App.tagCopy.Art.ToList
                App.tagArtIndex = 0
                wShowLyrics = False
                SetLyrics()
                ShowTagArtFromList(nArt)
                CheckDirtyState()
            End If
        Else
            If tlFile IsNot Nothing Then
                Select Case App.tagCopy.Mode
                    Case App.CopyModes.Basic
                        tlFile.Tag.Performers = App.tagCopy.Artists.ToArray
                        Dim s() As String
                        If tlFile.Tag.Genres.Length = 0 Then
                            s = New String() {App.tagCopy.Genre}
                        Else
                            s = tlFile.Tag.Genres
                            s.SetValue(App.tagCopy.Genre, 0)
                        End If
                        tlFile.Tag.Genres = s
                        tlFile.Tag.Title = App.tagCopy.Title
                        tlFile.Tag.Track = App.tagCopy.Track
                        tlFile.Tag.TrackCount = App.tagCopy.TrackCount
                        tlFile.Tag.Album = App.tagCopy.Album
                        tlFile.Tag.Year = App.tagCopy.Year
                        tlFile.Tag.Comment = App.tagCopy.Comment
                    Case App.CopyModes.Art
                        If App.tagCopy.Art.Count > 0 Then
                            tlFile.Tag.Pictures = App.tagCopy.Art.ToArray
                            App.tagArtIndex = 0
                            wShowLyrics = False
                            SetLyrics()
                        End If
                    Case App.CopyModes.Full
                        tlFile.Tag.Performers = App.tagCopy.Artists.ToArray
                        Dim s() As String
                        If tlFile.Tag.Genres.Length = 0 Then
                            s = New String() {App.tagCopy.Genre}
                        Else
                            s = tlFile.Tag.Genres
                            s.SetValue(App.tagCopy.Genre, 0)
                        End If
                        tlFile.Tag.Genres = s
                        tlFile.Tag.Title = App.tagCopy.Title
                        tlFile.Tag.Track = App.tagCopy.Track
                        tlFile.Tag.TrackCount = App.tagCopy.TrackCount
                        tlFile.Tag.Album = App.tagCopy.Album
                        tlFile.Tag.Year = App.tagCopy.Year
                        tlFile.Tag.Comment = App.tagCopy.Comment
                        If App.tagCopy.Art.Count > 0 Then
                            tlFile.Tag.Pictures = App.tagCopy.Art.ToArray
                            App.tagArtIndex = 0
                        End If
                        If Not String.IsNullOrEmpty(App.tagCopy.Lyrics) Then tlFile.Tag.Lyrics = App.tagCopy.Lyrics
                End Select
                ShowTag()
                'SetSave()
                'SetDirtyStateForArt()
            End If
        End If
    End Sub
    Private Sub OpenFile()
        Dim ofd As New OpenFileDialog With {
            .Title = "Select Media File(s)",
            .Filter = "All Files|*.*",
            .Multiselect = True}
        Dim result As DialogResult = ofd.ShowDialog(Me)
        If result = DialogResult.OK AndAlso ofd.FileNames.Length > 0 Then
            My.App.ProcessPassedParameters(Array.AsReadOnly(ofd.FileNames))
            LoadTags()
        End If
        ofd.Dispose()
    End Sub
    Private Sub CloseFile()
        If App.IsMultiFile Then
            App.tagPaths.Clear()
            SetControls(False)
            lblFileInfo.Text = App.sNoFile
            tipInfo.SetText(lblFileInfo, App.sNoFile)
            My.App.WriteToLog("Media Files Closed")
        Else
            If Not String.IsNullOrEmpty(My.tagPath) Then
                ClearFile()
                My.tagPath = String.Empty
                ShowTag()
                My.App.WriteToLog("Media File Closed")
            End If
        End If
    End Sub
    Private Function ClonePictureList(src As IList(Of TagLib.IPicture)) As List(Of TagLib.IPicture)
        Return src.Select(Function(p) ClonePicture(p)).ToList()
    End Function
    Private Function ClonePicture(src As TagLib.IPicture) As TagLib.IPicture
        Dim dataClone As Byte() = src.Data.Data.ToArray() ' deep copy bytes
        Dim pic As New TagLib.Picture(New TagLib.ByteVector(dataClone))

        pic.Type = src.Type
        pic.Description = src.Description
        pic.MimeType = src.MimeType

        Return pic
    End Function
    Private Sub SetWindowState()
        If App.Settings.IsMaximized <> wMaximized Then
            App.Settings.IsMaximized = wMaximized
            App.Settings.Save()
        End If
        SuspendLayout()
        Select Case wMaximized
            Case True
                WindowState = FormWindowState.Maximized
                panelAlbumArt.AutoScroll = True
                picbxAlbumArt.Dock = DockStyle.None
                picbxAlbumArt.SizeMode = PictureBoxSizeMode.AutoSize
                txbxLyrics.Font = New Font(txbxLyrics.Font.Name, 16)
                txbxLyrics.TextAlign = HorizontalAlignment.Center
            Case False
                WindowState = FormWindowState.Normal
                panelAlbumArt.AutoScroll = False
                picbxAlbumArt.Dock = DockStyle.Fill
                picbxAlbumArt.SizeMode = PictureBoxSizeMode.Zoom
                txbxLyrics.Font = New Font(txbxLyrics.Font.Name, 12)
                txbxLyrics.TextAlign = HorizontalAlignment.Left
        End Select
        ResumeLayout()
    End Sub
    Private Sub CheckMove(ByRef location As Point)
        If location.X + Me.Width > My.Computer.Screen.WorkingArea.Right Then location.X = My.Computer.Screen.WorkingArea.Right - Me.Width + App.AdjustScreenBoundsNormalWindow
        If location.Y + Me.Height > My.Computer.Screen.WorkingArea.Bottom Then location.Y = My.Computer.Screen.WorkingArea.Bottom - Me.Height + App.AdjustScreenBoundsNormalWindow
        If location.X < My.Computer.Screen.WorkingArea.Left Then location.X = My.Computer.Screen.WorkingArea.Left - App.AdjustScreenBoundsNormalWindow
        If location.Y < App.AdjustScreenBoundsNormalWindow Then location.Y = My.Computer.Screen.WorkingArea.Top
    End Sub
    Private Sub CustomDrawToolTip(MyToolStrip As ToolStrip)

        'Initialize
        Dim MyField As Reflection.PropertyInfo = MyToolStrip.GetType().GetProperty("ToolTip", Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance)
        Dim MyToolTip As System.Windows.Forms.ToolTip = CType(MyField.GetValue(MyToolStrip), System.Windows.Forms.ToolTip)

        'Configure ToolTip
        MyToolTip.OwnerDraw = True
        MyToolTip.InitialDelay = 100
        MyToolTip.ReshowDelay = 20

        'Draw
        AddHandler MyToolTip.Popup,
            Sub(sender, e)
                Dim s As Size
                s = TextRenderer.MeasureText(CType(sender, System.Windows.Forms.ToolTip).GetToolTip(e.AssociatedControl), tipInfo.Font)
                s.Width += 14
                s.Height += 14
                e.ToolTipSize = s
            End Sub
        AddHandler MyToolTip.Draw,
            Sub(sender, e)

                'Declarations
                Dim g As Graphics = e.Graphics

                'Draw background
                Dim brbg As New SolidBrush(App.Settings.Theme.TooltipBack)
                g.FillRectangle(brbg, e.Bounds)

                'Draw border
                Using p As New Pen(App.Settings.Theme.TooltipBorder, CInt(tipInfo.Font.Size / 4)) 'Scale border thickness with font
                    g.DrawRectangle(p, 0, 0, e.Bounds.Width - 1, e.Bounds.Height - 1)
                End Using

                'Draw text
                TextRenderer.DrawText(g, e.ToolTipText, tipInfo.Font, New Point(7, 7), App.Settings.Theme.TooltipFore)

                'Finalize
                brbg.Dispose()
                g.Dispose()

            End Sub

    End Sub

End Class
