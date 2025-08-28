
Imports Microsoft.Win32
Imports SkyeTag.My
Imports System.Diagnostics
Imports System.Runtime.CompilerServices

Partial Friend Class MainForm

    'Declarations
    Private Enum rMove
        Left
        First
        Right
        Last
    End Enum
    Private mMove As Boolean = False
    Private mOffset, mPosition As Point
    Private wMaximized As Boolean = False
    Private wShowLyrics As Boolean = False
    Private NeedsSaved As Boolean = False
    Private IsFocused As Boolean = True
    Private inDoubleClick As Boolean
    Private lastClick As DateTime
    Private doubleclickMaxTime As TimeSpan
    Private clickTimer As Timer
    Private txtboxCM As New Components.TextBoxContextMenu
    Private txtboxCMLyrics As New Components.TextBoxContextMenu
    Private tlFile As TagLib.File

    'Form Events
    Friend Sub New()

        'Initialize Globals

        'Initialize Locals

        'Initialize Form
        InitializeComponent()
        Text = My.Application.Info.ProductName
        lblFileInfo.Text = String.Empty
        For Each name As String In System.Enum.GetNames(GetType(TagLib.PictureType)) : cobxAlbumArtType.Items.Add(name) : Next
        tipInfo.SetToolTip(btnAlbumArt, App.hArt + " Menu")
        txtboxCM.ShowExtendedTools = True
        txtboxCM.Font = New Font("Segoe UI", 10, FontStyle.Regular)
        txtboxCMLyrics.ShowExtendedTools = False
        txtboxCMLyrics.Font = New Font("Segoe UI", 10, FontStyle.Regular)
        doubleclickMaxTime = TimeSpan.FromMilliseconds(SystemInformation.DoubleClickTime)
        clickTimer = New Timer()
        clickTimer.Interval = SystemInformation.DoubleClickTime
        AddHandler clickTimer.Tick, AddressOf clickTimer_Tick
        SetLyrics()
        SetWindowState()
#If DEBUG Then
        'Location = App.Settings.StartLocation
        'Size = App.Settings.StartSize
        Location = New Point(My.Computer.Screen.WorkingArea.Left + CInt(My.Computer.Screen.WorkingArea.Width / 2) - CInt(Width / 2), My.Computer.Screen.WorkingArea.Top + 50)
        btnError.Visible = True
        tipInfo.SetToolTip(btnError, tipInfo.GetToolTip(btnError) + vbCr + "CtrlRightClick = Test Error")
#Else
		Location = App.Settings.StartLocation
		Size = App.Settings.StartSize
#End If
    End Sub
    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        Try
            Select Case m.Msg
                Case My.WinAPI.WM_SYSCOMMAND
                    Select Case CInt(m.WParam)
                        Case My.WinAPI.SC_MAXIMIZE, My.WinAPI.SC_MAXIMIZE_TBAR
                            wMaximized = True
                            SetWindowState()
                        Case My.WinAPI.SC_RESTORE, My.WinAPI.SC_RESTORE_TBAR
                            If Me.WindowState = FormWindowState.Minimized Then
                                Select Case wMaximized
                                    Case True : Me.WindowState = FormWindowState.Maximized
                                    Case False : Me.WindowState = FormWindowState.Normal
                                End Select
                            Else
                                wMaximized = False
                                SetWindowState()
                            End If
                    End Select
                Case My.WinAPI.WM_ACTIVATE
                    Select Case CInt(m.WParam)
                        Case 0
                            IsFocused = False
                            SetInactiveColor()
                        Case 1, 2
                            IsFocused = True
                            SetAccentColor()
                    End Select
                Case My.WinAPI.WM_DWMCOLORIZATIONCOLORCHANGED
                    SetAccentColor()
            End Select
        Catch ex As Exception
            My.App.WriteToLog("WndProc Handler Error" + Chr(13) + ex.ToString)
        Finally
            MyBase.WndProc(m)
        End Try
    End Sub
    Private Sub frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetTag()
        ShowTag()
    End Sub
    Private Sub frm_Closing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If App.FrmLog IsNot Nothing Then App.FrmLog.Close()
        My.App.Finalize()
    End Sub
    Private Sub frm_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        Dim g As Graphics = Me.CreateGraphics
        If tlFile Is Nothing Then
            Me.tipInfo.SetToolTip(Me.txbxArtist, Nothing)
        Else
            If tlFile.Tag.Performers.Length = 1 Then
                If g.MeasureString(Me.txbxArtist.Text, Me.txbxArtist.Font).Width > Me.txbxArtist.Width Then
                    Me.tipInfo.SetToolTip(Me.txbxArtist, Me.txbxArtist.Text)
                Else : Me.tipInfo.SetToolTip(Me.txbxArtist, Nothing)
                End If
            ElseIf tlFile.Tag.Performers.Length > 1 Then
                Me.tipInfo.SetToolTip(Me.txbxArtist, tlFile.Tag.JoinedPerformers)
            Else
                Me.tipInfo.SetToolTip(Me.txbxArtist, Nothing)
            End If
        End If
        If g.MeasureString(Me.txbxGenre.Text, Me.txbxGenre.Font).Width > Me.txbxGenre.Width Then
            Me.tipInfo.SetToolTip(Me.txbxGenre, Me.txbxGenre.Text)
        Else : Me.tipInfo.SetToolTip(Me.txbxGenre, Nothing)
        End If
        If g.MeasureString(Me.txbxTitle.Text, Me.txbxTitle.Font).Width > Me.txbxTitle.Width Then
            Me.tipInfo.SetToolTip(Me.txbxTitle, Me.txbxTitle.Text)
        Else : Me.tipInfo.SetToolTip(Me.txbxTitle, Nothing)
        End If
        If g.MeasureString(Me.txbxAlbum.Text, Me.txbxAlbum.Font).Width > Me.txbxAlbum.Width Then
            Me.tipInfo.SetToolTip(Me.txbxAlbum, Me.txbxAlbum.Text)
        Else : Me.tipInfo.SetToolTip(Me.txbxAlbum, Nothing)
        End If
        If g.MeasureString(Me.txbxComments.Text, Me.txbxComments.Font).Width > Me.txbxComments.Width Then
            Me.tipInfo.SetToolTip(Me.txbxComments, Me.txbxComments.Text)
        Else : Me.tipInfo.SetToolTip(Me.txbxComments, Nothing)
        End If
        If g.MeasureString(Me.txbxAlbumArt.Text, Me.txbxAlbumArt.Font).Width > Me.txbxAlbumArt.Width Then
            Me.tipInfo.SetToolTip(Me.txbxAlbumArt, Me.txbxAlbumArt.Text)
        Else : Me.tipInfo.SetToolTip(Me.txbxAlbumArt, Nothing)
        End If
        If tlFile IsNot Nothing AndAlso tlFile.Tag.Pictures.Length > 0 AndAlso g.MeasureString(Me.cobxAlbumArtType.Text, Me.cobxAlbumArtType.Font).Width > Me.cobxAlbumArtType.Width - 15 Then
            Me.tipInfo.SetToolTip(Me.cobxAlbumArtType, Me.cobxAlbumArtType.Text)
        Else : Me.tipInfo.SetToolTip(Me.cobxAlbumArtType, Nothing)
        End If
        g.Dispose()
    End Sub
    Private Sub frm_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles picbxAlbumArt.MouseDown, MyBase.MouseDown, MenuMain.MouseDown, lblYear.MouseDown, lblTrackSeparator.MouseDown, lblTrack.MouseDown, lblTitle.MouseDown, lblGenre.MouseDown, lblDuration.MouseDown, lblComments.MouseDown, lblArtist.MouseDown, lblAlbumArt.MouseDown, lblAlbum.MouseDown
        Dim cSender As Control
        If e.Button = MouseButtons.Left AndAlso Me.WindowState = FormWindowState.Normal Then
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
        cSender = Nothing
    End Sub
    Private Sub frm_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles picbxAlbumArt.MouseMove, MyBase.MouseMove, MenuMain.MouseMove, lblYear.MouseMove, lblTrackSeparator.MouseMove, lblTrack.MouseMove, lblTitle.MouseMove, lblGenre.MouseMove, lblDuration.MouseMove, lblComments.MouseMove, lblArtist.MouseMove, lblAlbumArt.MouseMove, lblAlbum.MouseMove
        If mMove Then
            mPosition = Control.MousePosition
            mPosition.Offset(mOffset.X, mOffset.Y)
            CheckMove(mPosition)
            Location = mPosition
        End If
    End Sub
    Private Sub frm_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles picbxAlbumArt.MouseUp, MyBase.MouseUp, MenuMain.MouseUp, lblYear.MouseUp, lblTrackSeparator.MouseUp, lblTrack.MouseUp, lblTitle.MouseUp, lblGenre.MouseUp, lblDuration.MouseUp, lblComments.MouseUp, lblArtist.MouseUp, lblAlbumArt.MouseUp, lblAlbum.MouseUp
        mMove = False
    End Sub
    Private Sub frm_Move(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Move
        If Not mMove AndAlso Me.WindowState = FormWindowState.Normal Then
            CheckMove(Me.Location)
        End If
    End Sub
    Private Sub frm_LocationChanged(sender As Object, e As EventArgs) Handles MyBase.LocationChanged
        If My.Settings.StartLocation <> Me.Location Then
            My.Settings.StartLocation = Me.Location
            My.Settings.MetricsNeedSaved = True
        End If
    End Sub
    Private Sub frm_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        If Visible AndAlso WindowState = FormWindowState.Normal Then
            App.Settings.StartSize = Me.Size
            App.Settings.MetricsNeedSaved = True
        End If
    End Sub
    Private Sub frm_DoubleClick(sender As Object, e As EventArgs) Handles picbxAlbumArt.DoubleClick, panelAlbumArt.DoubleClick, MyBase.DoubleClick, MenuMain.DoubleClick, lblYear.DoubleClick, lblTrackSeparator.DoubleClick, lblTrack.DoubleClick, lblTitle.DoubleClick, lblGenre.DoubleClick, lblFileInfo.DoubleClick, lblDuration.DoubleClick, lblComments.DoubleClick, lblArtist.DoubleClick, lblAlbumArt.DoubleClick, lblAlbum.DoubleClick
        wMaximized = Not wMaximized
        SetWindowState()
    End Sub
    Private Sub frm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyData
            Case Keys.W Or Keys.Control : Me.Close()
            Case Keys.W Or Keys.Control Or Keys.Shift : Me.WindowState = FormWindowState.Minimized
            Case Keys.Escape : Me.WindowState = FormWindowState.Minimized
            Case Keys.F12
                wMaximized = Not wMaximized
                SetWindowState()
        End Select
    End Sub
    Private Sub frm_DragEnter(sender As Object, e As DragEventArgs) Handles MyBase.DragEnter
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
    Private Sub frm_DragDrop(sender As Object, e As DragEventArgs) Handles MyBase.DragDrop
        If e.Effect = DragDropEffects.Link Then
            Dim filedrop As String() = DirectCast(e.Data.GetData(DataFormats.FileDrop, True), String())
            Dim files As New Collections.Generic.List(Of String)
            For Each s As String In filedrop : If My.Computer.FileSystem.FileExists(s) Then files.Add(s)
            Next
            If files.Count > 0 Then
                My.App.WriteToLog("Drag&Drop Performed (" + files.Count.ToString + " " + IIf(files.Count = 1, "File", "Files").ToString + ")", False)
                My.App.ProcessPassedParameters(files.AsReadOnly)
                SetTag()
                ShowTag()
                ClearSave()
            End If
            files.Clear()
            files = Nothing
            filedrop = Nothing
        End If
    End Sub

    'Control Events
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
            psi = New Diagnostics.ProcessStartInfo("EXPLORER.EXE")
            psi.Arguments = "/SELECT," + """" + My.tagPath + """"
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
    Private Sub cmAlbumArtOpening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmAlbumArt.Opening
        If tlFile.Tag.Pictures.Length = 0 Then
            Me.cmiAlbumArtSelect.Enabled = False
            Me.cmiAlbumArtExport.Enabled = False
            Me.cmiAlbumArtMoveLeft.Enabled = False
            Me.cmiAlbumArtMoveRight.Enabled = False
            Me.cmiAlbumArtDelete.Enabled = False
        Else
            Me.cmiAlbumArtSelect.Enabled = True
            Me.cmiAlbumArtExport.Enabled = True
            If My.tagArtIndex = 0 Then : Me.cmiAlbumArtMoveLeft.Enabled = False
            Else : Me.cmiAlbumArtMoveLeft.Enabled = True
            End If
            If My.tagArtIndex = tlFile.Tag.Pictures.Length - 1 Then : Me.cmiAlbumArtMoveRight.Enabled = False
            Else : Me.cmiAlbumArtMoveRight.Enabled = True
            End If
            Me.cmiAlbumArtDelete.Enabled = True
        End If
        If tlFile.TagTypes = TagLib.TagTypes.None Then : Me.cmiAlbumArtInsert.Enabled = False
        Else : Me.cmiAlbumArtInsert.Enabled = True
        End If
    End Sub
    Private Sub cmiAlbumArtInsertBeforeMouseUp(sender As Object, e As MouseEventArgs) Handles cmiAlbumArtInsertBefore.MouseUp
        If My.Computer.Keyboard.CtrlKeyDown Then
            InsertArt(My.tagArtIndex, My.App.ImageSource.ClipBoard)
        ElseIf My.Computer.Keyboard.ShiftKeyDown Then
            InsertArt(My.tagArtIndex, My.App.ImageSource.SelectOnline)
        Else
            InsertArt(My.tagArtIndex, My.App.ImageSource.SelectFile)
        End If
    End Sub
    Private Sub cmiAlbumArtInsertFirstMouseUp(sender As Object, e As MouseEventArgs) Handles cmiAlbumArtInsertFirst.MouseUp
        If My.Computer.Keyboard.CtrlKeyDown Then
            InsertArt(0, My.App.ImageSource.ClipBoard)
        ElseIf My.Computer.Keyboard.ShiftKeyDown Then
            InsertArt(0, My.App.ImageSource.SelectOnline)
        Else
            InsertArt(0, My.App.ImageSource.SelectFile)
        End If
    End Sub
    Private Sub cmiAlbumArtInsertAfterMouseUp(sender As Object, e As MouseEventArgs) Handles cmiAlbumArtInsertAfter.MouseUp
        If My.Computer.Keyboard.CtrlKeyDown Then
            InsertArt(CInt(IIf(tlFile.Tag.Pictures.Length = 0, 0, My.tagArtIndex + 1)), My.App.ImageSource.ClipBoard)
        ElseIf My.Computer.Keyboard.ShiftKeyDown Then
            InsertArt(CInt(IIf(tlFile.Tag.Pictures.Length = 0, 0, My.tagArtIndex + 1)), My.App.ImageSource.SelectOnline)
        Else
            InsertArt(CInt(IIf(tlFile.Tag.Pictures.Length = 0, 0, My.tagArtIndex + 1)), My.App.ImageSource.SelectFile)
        End If
    End Sub
    Private Sub cmiAlbumArtInsertLastMouseUp(sender As Object, e As MouseEventArgs) Handles cmiAlbumArtInsertLast.MouseUp, cmiAlbumArtInsert.MouseUp
        If Me.cmAlbumArt.Visible Then Me.cmAlbumArt.Close()
        If My.Computer.Keyboard.CtrlKeyDown Then
            InsertArt(tlFile.Tag.Pictures.Length, My.App.ImageSource.ClipBoard)
        ElseIf My.Computer.Keyboard.ShiftKeyDown Then
            InsertArt(tlFile.Tag.Pictures.Length, My.App.ImageSource.SelectOnline)
        Else
            InsertArt(tlFile.Tag.Pictures.Length, My.App.ImageSource.SelectFile)
        End If
    End Sub
    Private Sub cmiAlbumArtSelectMouseUp(sender As Object, e As MouseEventArgs) Handles cmiAlbumArtSelect.MouseUp
        If tlFile.Tag.Pictures.Length > 0 Then
            Dim picsource As My.App.ImageSource
            If My.Computer.Keyboard.CtrlKeyDown Then
                picsource = My.App.ImageSource.ClipBoard
            ElseIf My.Computer.Keyboard.ShiftKeyDown Then
                picsource = My.App.ImageSource.SelectOnline
            Else
                picsource = My.App.ImageSource.SelectFile
            End If
            Dim newpic As TagLib.IPicture
            newpic = My.App.GetNewPic(picsource)
            If newpic IsNot Nothing Then
                Dim piclist As New Collections.Generic.List(Of TagLib.IPicture)
                For Each pic As TagLib.IPicture In tlFile.Tag.Pictures : piclist.Add(pic) : Next
                newpic.Description = tlFile.Tag.Pictures(My.tagArtIndex).Description
                newpic.Type = tlFile.Tag.Pictures(My.tagArtIndex).Type
                piclist(My.tagArtIndex) = newpic
                tlFile.Tag.Pictures = piclist.ToArray
                piclist.Clear()
                piclist = Nothing
                newpic = Nothing
                picsource = Nothing
                ShowTag()
                SetSave()
            Else
                If picsource = My.App.ImageSource.ClipBoard Then
                    tipInfo.Tag = SystemIcons.Information.ToBitmap
                    tipInfo.Show("No Image On ClipBoard", Me, Me.btnAlbumArt.Left + CInt(Me.btnAlbumArt.Width / 2) + SystemInformation.FrameBorderSize.Width, Me.btnAlbumArt.Top + CInt(Me.btnAlbumArt.Height / 2) + SystemInformation.FrameBorderSize.Height + SystemInformation.CaptionHeight, 4000)
                End If
            End If
        End If
    End Sub
    Private Sub cmiAlbumArtExportMouseUp(sender As Object, e As MouseEventArgs) Handles cmiAlbumArtExport.MouseUp
        If My.Computer.Keyboard.CtrlKeyDown Then
            Dim ms As New IO.MemoryStream(tlFile.Tag.Pictures(My.tagArtIndex).Data.Data)
            My.Computer.Clipboard.SetImage(Image.FromStream(ms))
            ms.Dispose()
            ms = Nothing
        Else
            Dim sfd As New SaveFileDialog
            sfd.Title = "Save Image File"
            Dim saveFormat As Drawing.Imaging.ImageFormat
            If My.Computer.Keyboard.ShiftKeyDown Then
                saveFormat = Drawing.Imaging.ImageFormat.Bmp
                sfd.Filter = "Windows Bitmap Files|*.bmp"
            Else
                Select Case tlFile.Tag.Pictures(My.tagArtIndex).MimeType
                    Case "image/jpeg"
                        saveFormat = Drawing.Imaging.ImageFormat.Jpeg
                        sfd.Filter = "JPEG Files|*.jpg;*.jpeg"
                    Case "image/png"
                        saveFormat = Drawing.Imaging.ImageFormat.Png
                        sfd.Filter = "PNG Files|*.png"
                    Case Else
                        saveFormat = Drawing.Imaging.ImageFormat.Bmp
                        sfd.Filter = "Windows Bitmap Files|*.bmp"
                End Select
            End If
            sfd.Filter += "|All Files|*.*"
            Dim result As DialogResult = sfd.ShowDialog(Me)
            If result = DialogResult.OK AndAlso Not String.IsNullOrEmpty(sfd.FileName) Then
                Dim ms As New IO.MemoryStream(tlFile.Tag.Pictures(My.tagArtIndex).Data.Data)
                Dim im As Image = Image.FromStream(ms)
                im.Save(sfd.FileName, saveFormat)
                im.Dispose()
                im = Nothing
                ms.Dispose()
                ms = Nothing
            End If
            My.App.WriteToLog("Album Art Exported To " + sfd.FileName)
            result = Nothing
            saveFormat = Nothing
            sfd.Dispose()
            sfd = Nothing
        End If
    End Sub
    Private Sub cmiAlbumArtMoveLeftMouseUp(sender As Object, e As MouseEventArgs) Handles cmiAlbumArtMoveLeft.MouseUp
        If e.Button = MouseButtons.Left AndAlso Not My.tagArtIndex = 0 Then
            If My.Computer.Keyboard.CtrlKeyDown Then : MoveArt(rMove.First)
            Else : MoveArt(rMove.Left)
            End If
        End If
    End Sub
    Private Sub cmiAlbumArtMoveRightMouseUp(sender As Object, e As MouseEventArgs) Handles cmiAlbumArtMoveRight.MouseUp
        If e.Button = MouseButtons.Left AndAlso Not My.tagArtIndex = tlFile.Tag.Pictures.Length - 1 Then
            If My.Computer.Keyboard.CtrlKeyDown Then : MoveArt(rMove.Last)
            Else : MoveArt(rMove.Right)
            End If
        End If
    End Sub
    Private Sub cmiAlbumArtDeleteMouseUp(sender As Object, e As MouseEventArgs) Handles cmiAlbumArtDelete.MouseUp
        If tlFile.Tag.Pictures.Length > 0 Then
            Dim piclist As New Collections.Generic.List(Of TagLib.IPicture)
            If tlFile.Tag.Pictures.Length > 1 Then
                For Each pic As TagLib.IPicture In tlFile.Tag.Pictures : piclist.Add(pic) : Next
                piclist.RemoveAt(My.tagArtIndex)
                If My.tagArtIndex > tlFile.Tag.Pictures.Length - 2 Then My.tagArtIndex = tlFile.Tag.Pictures.Length - 2
            End If
            tlFile.Tag.Pictures = piclist.ToArray
            piclist.Clear()
            piclist = Nothing
            ShowTag()
            SetSave()
        End If
    End Sub
    Private Sub ctrlAlbumArtEnter(sender As Object, e As EventArgs) Handles txbxAlbumArt.Enter, cobxAlbumArtType.Enter
        ResetLyrics()
    End Sub
    Private Sub lblFileInfo_MouseDown(sender As Object, e As MouseEventArgs) Handles lblFileInfo.MouseDown
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
    Private Sub lblFileInfo_MouseEnter(sender As Object, e As EventArgs) Handles lblFileInfo.MouseEnter
        If Not String.IsNullOrEmpty(lblFileInfo.Text) Then
            Cursor = Cursors.Hand
            lblFileInfo.ForeColor = WinAPI.GetSystemColor(WinAPI.COLOR_HOTLIGHT)
        End If
    End Sub
    Private Sub lblFileInfo_MouseLeave(sender As Object, e As EventArgs) Handles lblFileInfo.MouseLeave
        ResetCursor()
        lblFileInfo.ResetForeColor()
    End Sub
    Private Sub lblAlbumArtClick(sender As Object, e As EventArgs)
        If tlFile.Tag.Pictures.Length > 0 Then ResetLyrics()
    End Sub
    Private Sub txtbox_MouseUp(sender As Object, e As MouseEventArgs) Handles txbxYear.MouseUp, txbxTrackCount.MouseUp, txbxTrack.MouseUp, txbxTitle.MouseUp, txbxGenre.MouseUp, txbxDuration.MouseDown, txbxComments.MouseUp, txbxArtist.MouseUp, txbxAlbumArt.MouseUp, txbxAlbum.MouseUp
        txtboxCM.Display(DirectCast(sender, TextBox), e)
    End Sub
    Private Sub txbx_MouseLeave(sender As Object, e As EventArgs) Handles txbxYear.MouseLeave, txbxTrackCount.MouseLeave, txbxTrack.MouseLeave, txbxTitle.MouseLeave, txbxGenre.MouseLeave, txbxComments.MouseLeave, txbxArtist.MouseLeave, txbxAlbum.MouseLeave
        tipInfo.Active = False
        tipInfo.Active = True
    End Sub
    Private Sub txtbox_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles txbxYear.PreviewKeyDown, txbxTrackCount.PreviewKeyDown, txbxTrack.PreviewKeyDown, txbxTitle.PreviewKeyDown, txbxGenre.PreviewKeyDown, txbxDuration.PreviewKeyDown, txbxComments.PreviewKeyDown, txbxArtist.PreviewKeyDown, txbxAlbumArt.PreviewKeyDown, txbxAlbum.PreviewKeyDown
        txtboxCM.ShortcutKeys(DirectCast(sender, TextBox), e)
    End Sub
    Private Sub txbxLyrics_MouseUp(sender As Object, e As MouseEventArgs) Handles txbxLyrics.MouseUp
        txtboxCMLyrics.Display(DirectCast(sender, TextBox), e)
    End Sub
    Private Sub txbxLyrics_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles txbxLyrics.PreviewKeyDown
        txtboxCMLyrics.ShortcutKeys(DirectCast(sender, TextBox), e)
    End Sub
    Private Sub txtboxKeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txbxTitle.KeyDown, txbxGenre.KeyDown, txbxComments.KeyDown, txbxArtist.KeyDown, txbxAlbumArt.KeyDown, txbxAlbum.KeyDown
        If Not e.Control AndAlso Not e.Alt Then SetSave()
        If e.KeyCode = Keys.Enter Then Me.Validate()
    End Sub
    Private Sub txbxNumbersOnly_KeyDown(sender As Object, e As KeyEventArgs) Handles txbxYear.KeyDown, txbxTrackCount.KeyDown, txbxTrack.KeyDown
        If Not e.Control AndAlso Not e.Alt Then SetSave()
    End Sub
    Private Sub txbxNumbersOnly_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txbxYear.KeyPress, txbxTrackCount.KeyPress, txbxTrack.KeyPress
        Static nonNumberEntered As Boolean
        nonNumberEntered = False
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then : nonNumberEntered = True
        ElseIf Asc(e.KeyChar) = Keys.Enter Then : Me.Validate()
        End If
        If nonNumberEntered Then e.Handled = True
    End Sub
    Private Sub txbxArtistValidated(sender As Object, e As EventArgs) Handles txbxArtist.Validated
        If Not tlFile Is Nothing Then
            If Not String.IsNullOrEmpty(Me.txbxArtist.Text) AndAlso tlFile.Tag.Performers.Length = 0 Then
                tlFile.Tag.Performers = New String() {Me.txbxArtist.Text}
                SetArtistControls(True)
                SetSave(True)
            ElseIf String.IsNullOrEmpty(Me.txbxArtist.Text) AndAlso tlFile.Tag.Performers.Length > 1 Then
                Dim alist As New Collections.Generic.List(Of String)
                For Each s As String In tlFile.Tag.Performers : alist.Add(s) : Next
                alist.RemoveAt(My.tagArtistIndex)
                If My.tagArtistIndex > tlFile.Tag.Performers.Length - 2 Then My.tagArtistIndex = tlFile.Tag.Performers.Length - 2
                tlFile.Tag.Performers = alist.ToArray
                alist.Clear()
                alist = Nothing
                ShowTag()
                SetSave()
            ElseIf tlFile.Tag.Performers.Length > 0 AndAlso Not String.Equals(IIf(tlFile.Tag.Performers(My.tagArtistIndex) Is Nothing, String.Empty, tlFile.Tag.Performers(My.tagArtistIndex)).ToString, Me.txbxArtist.Text) Then
                Dim s() As String
                s = tlFile.Tag.Performers
                s.SetValue(Me.txbxArtist.Text, My.tagArtistIndex)
                tlFile.Tag.Performers = s
                s = Nothing
                SetArtistControls(True)
                SetSave(True)
            End If
        End If
    End Sub
    Private Sub txbxGenreValidated(sender As Object, e As EventArgs) Handles txbxGenre.Validated
        If Not tlFile Is Nothing Then
            If Not String.Equals(IIf(tlFile.Tag.FirstGenre Is Nothing, String.Empty, tlFile.Tag.FirstGenre).ToString, Me.txbxGenre.Text) Then
                Dim s() As String
                If tlFile.Tag.Genres.Length = 0 Then
                    s = New String() {Me.txbxGenre.Text}
                Else
                    s = tlFile.Tag.Genres
                    s.SetValue(Me.txbxGenre.Text, 0)
                End If
                tlFile.Tag.Genres = s
                s = Nothing
                SetSave(True)
            End If
        End If
    End Sub
    Private Sub txbxTitleValidated(sender As Object, e As EventArgs) Handles txbxTitle.Validated
        If Not tlFile Is Nothing Then
            'Me.txbxTitle.Select(0, 0)
            'Me.txbxTitle.ScrollToCaret()

            If Not String.Equals(IIf(tlFile.Tag.Title Is Nothing, String.Empty, tlFile.Tag.Title).ToString, Me.txbxTitle.Text) Then
                tlFile.Tag.Title = Me.txbxTitle.Text
                SetSave(True)
            End If
        End If
    End Sub
    Private Sub txbxTrackValidated(sender As Object, e As EventArgs) Handles txbxTrack.Validated
        If tlFile IsNot Nothing Then
            'Me.txbxTrack.Select(0, 0)
            'Me.txbxTrack.ScrollToCaret()

            If Not tlFile.Tag.Track = CUInt(Val(Me.txbxTrack.Text)) Then
                tlFile.Tag.Track = CUInt(Val(Me.txbxTrack.Text))
                Me.txbxTrack.Text = IIf(tlFile.Tag.Track = 0, String.Empty, tlFile.Tag.Track).ToString
                SetSave()
            End If
        End If
    End Sub
    Private Sub txbxTrackCountValidated(sender As Object, e As EventArgs) Handles txbxTrackCount.Validated
        If Not tlFile Is Nothing Then
            'Me.txbxTrackCount.Select(0, 0)
            'Me.txbxTrackCount.ScrollToCaret()

            If Not tlFile.Tag.TrackCount = CUInt(Val(Me.txbxTrackCount.Text)) Then
                tlFile.Tag.TrackCount = CUInt(Val(Me.txbxTrackCount.Text))
                Me.txbxTrackCount.Text = IIf(tlFile.Tag.TrackCount = 0, String.Empty, tlFile.Tag.TrackCount).ToString
                SetSave()
            End If
        End If
    End Sub
    Private Sub txbxAlbumValidated(sender As Object, e As EventArgs) Handles txbxAlbum.Validated
        If Not tlFile Is Nothing Then
            'Me.txbxAlbum.Select(0, 0)
            'Me.txbxAlbum.ScrollToCaret()

            If Not String.Equals(IIf(tlFile.Tag.Album Is Nothing, String.Empty, tlFile.Tag.Album).ToString, Me.txbxAlbum.Text) Then
                tlFile.Tag.Album = Me.txbxAlbum.Text
                SetSave(True)
            End If
        End If
    End Sub
    Private Sub txbxYearValidated(sender As Object, e As EventArgs) Handles txbxYear.Validated
        If Not tlFile Is Nothing Then
            'Me.txbxYear.Select(0, 0)
            'Me.txbxYear.ScrollToCaret()

            If Not tlFile.Tag.Year = CUInt(Val(Me.txbxYear.Text)) Then
                tlFile.Tag.Year = CUInt(Val(Me.txbxYear.Text))
                Me.txbxYear.Text = IIf(tlFile.Tag.Year = 0, String.Empty, tlFile.Tag.Year).ToString
                SetSave()
            End If
        End If
    End Sub
    Private Sub txbxCommentsValidated(sender As Object, e As EventArgs) Handles txbxComments.Validated
        If Not tlFile Is Nothing Then
            If Not String.Equals(IIf(tlFile.Tag.Comment Is Nothing, String.Empty, tlFile.Tag.Comment).ToString, Me.txbxComments.Text) Then
                tlFile.Tag.Comment = Me.txbxComments.Text
                SetSave(True)
            End If
        End If
    End Sub
    Private Sub txbxAlbumArtValidated(sender As Object, e As EventArgs) Handles txbxAlbumArt.Validated
        If tlFile IsNot Nothing Then
            If tlFile.Tag.Pictures.Length > 0 AndAlso Not String.Equals(IIf(tlFile.Tag.Pictures(My.tagArtIndex).Description Is Nothing, String.Empty, tlFile.Tag.Pictures(My.tagArtIndex).Description).ToString, Me.txbxAlbumArt.Text) Then
                tlFile.Tag.Pictures(My.tagArtIndex).Description = txbxAlbumArt.Text
                SetSave(True)
            End If
        End If
    End Sub
    Private Sub txbxLyricsKeyUp(sender As Object, e As KeyEventArgs) Handles txbxLyrics.KeyUp
        If Not tlFile Is Nothing AndAlso Not Me.txbxLyrics.Text Is Nothing Then
            If Not String.Equals(IIf(tlFile.Tag.Lyrics Is Nothing, String.Empty, tlFile.Tag.Lyrics).ToString, Me.txbxLyrics.Text) Then SetSave()
        End If
    End Sub
    Private Sub txbxLyricsValidated(sender As Object, e As EventArgs) Handles txbxLyrics.Validated
        If tlFile IsNot Nothing Then
            If Not String.Equals(IIf(tlFile.Tag.Lyrics Is Nothing, String.Empty, tlFile.Tag.Lyrics).ToString, Me.txbxLyrics.Text) Then
                tlFile.Tag.Lyrics = Me.txbxLyrics.Text
                SetSave(True)
            End If
        End If
    End Sub
    Private Sub cobxGenreSelectionChangeCommitted(sender As Object, e As EventArgs) Handles cobxGenre.SelectionChangeCommitted
        Me.txbxGenre.Text = Me.cobxGenre.SelectedItem.ToString
        Me.txbxGenre.Focus()
        Me.Validate()
    End Sub
    Private Sub cobxAlbumArtTypeSelectionChangeCommitted(sender As Object, e As EventArgs) Handles cobxAlbumArtType.SelectionChangeCommitted
        Me.Validate()
    End Sub
    Private Sub cobxAlbumArtTypeValidated(sender As Object, e As EventArgs) Handles cobxAlbumArtType.Validated
        If tlFile IsNot Nothing Then
            If tlFile.Tag.Pictures.Length > 0 AndAlso Not tlFile.Tag.Pictures(My.tagArtIndex).Type = Me.cobxAlbumArtType.SelectedIndex Then
                Dim newpic As TagLib.IPicture = tlFile.Tag.Pictures(My.tagArtIndex)
                Dim piclist As New Collections.Generic.List(Of TagLib.IPicture)
                Try
                    newpic.Type = DirectCast(Me.cobxAlbumArtType.SelectedIndex, TagLib.PictureType)
                    For Each pic As TagLib.IPicture In tlFile.Tag.Pictures : piclist.Add(pic) : Next
                    piclist(My.tagArtIndex) = newpic
                    tlFile.Tag.Pictures = piclist.ToArray
                    SetSave()
                Catch
                Finally
                    piclist.Clear()
                    piclist = Nothing
                    newpic = Nothing
                End Try
            End If
        End If
    End Sub
    Private Sub btnErrorMouseUp(sender As Object, e As MouseEventArgs) Handles btnError.MouseUp
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
    Private Sub btnMinimizeClick(sender As Object, e As EventArgs)
        Me.WindowState = FormWindowState.Minimized
    End Sub
    Private Sub btnSaveClick(sender As Object, e As EventArgs) Handles btnSave.Click
        If NeedsSaved Then
            Try
                tlFile.Save()
                My.App.WriteToLog("Tag Saved")
                SetTag()
                ShowTag()
                ClearSave()
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
        End If
    End Sub
    Private Sub btnRestoreClick(sender As Object, e As EventArgs) Handles btnRestore.Click
#If DEBUG Then
        SetTag()
        ShowTag()
        ClearSave()
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
    Private Sub btnArtistInsertDragEnter(sender As Object, e As DragEventArgs) Handles btnArtistInsert.DragEnter
        If e.Data.GetDataPresent(DataFormats.StringFormat) _
        AndAlso Not String.IsNullOrEmpty(e.Data.GetData(DataFormats.StringFormat, True).ToString) _
            Then : e.Effect = DragDropEffects.Copy
        Else : e.Effect = DragDropEffects.None
        End If
    End Sub
    Private Sub btnArtistInsertDragDrop(sender As Object, e As DragEventArgs) Handles btnArtistInsert.DragDrop
        If e.Effect = DragDropEffects.Copy Then
            My.App.WriteToLog("Drag&Drop Performed (" + My.App.hArtist + " Text)", False)
            InsertArtist(e.Data.GetData(DataFormats.StringFormat, True).ToString)
        End If
    End Sub
    Private Sub btnArtistInsertMouseUp(sender As Object, e As MouseEventArgs) Handles btnArtistInsert.MouseUp
        If Not tlFile.TagTypes = TagLib.TagTypes.None AndAlso My.App.MouseInBounds(CType(sender, Control), e.Location) Then
            Select Case My.Computer.Keyboard.CtrlKeyDown
                Case True
                    If My.Computer.Clipboard.ContainsText Then : InsertArtist(My.Computer.Clipboard.GetText)
                    Else
                        tipInfo.Tag = SystemIcons.Information.ToBitmap
                        tipInfo.Show("No Text On ClipBoard", Me, Me.btnArtistInsert.Left + CInt(Me.btnArtistInsert.Width / 2) + SystemInformation.FrameBorderSize.Width, Me.btnArtistInsert.Top + CInt(Me.btnArtistInsert.Height / 2) + SystemInformation.FrameBorderSize.Height + SystemInformation.CaptionHeight, 4000)
                    End If
                Case False : InsertArtist()
            End Select
        End If
    End Sub
    Private Sub btnArtistDeleteMouseUp(sender As Object, e As MouseEventArgs) Handles btnArtistDelete.MouseUp
        If tlFile.Tag.Performers.Length > 1 AndAlso My.App.MouseInBounds(CType(sender, Control), e.Location) Then
            Dim alist As New Collections.Generic.List(Of String)
            For Each s As String In tlFile.Tag.Performers : alist.Add(s) : Next
            alist.RemoveAt(My.tagArtistIndex)
            If My.tagArtistIndex > tlFile.Tag.Performers.Length - 2 Then My.tagArtistIndex = tlFile.Tag.Performers.Length - 2
            tlFile.Tag.Performers = alist.ToArray
            alist.Clear()
            alist = Nothing
            ShowTag()
            SetSave()
        End If
    End Sub
    Private Sub btnArtistLeftMouseUp(sender As Object, e As MouseEventArgs) Handles btnArtistLeft.MouseUp
        If My.App.MouseInBounds(CType(sender, Control), e.Location) Then
            Select Case e.Button
                Case MouseButtons.Left
                    My.tagArtistIndex -= 1
                    If My.tagArtistIndex < 0 Then My.tagArtistIndex = 0
                    ShowTag()
                Case MouseButtons.Right
                    If My.Computer.Keyboard.CtrlKeyDown Then : MoveArtist(rMove.First)
                    Else : MoveArtist(rMove.Left)
                    End If
            End Select
        End If
    End Sub
    Private Sub btnArtistRightMouseUp(sender As Object, e As MouseEventArgs) Handles btnArtistRight.MouseUp
        If My.App.MouseInBounds(CType(sender, Control), e.Location) Then
            Select Case e.Button
                Case MouseButtons.Left
                    My.tagArtistIndex += 1
                    If My.tagArtistIndex > tlFile.Tag.Performers.Length - 1 Then My.tagArtistIndex = tlFile.Tag.Performers.Length - 1
                    ShowTag()
                Case MouseButtons.Right
                    If My.Computer.Keyboard.CtrlKeyDown Then : MoveArtist(rMove.Last)
                    Else : MoveArtist(rMove.Right)
                    End If
            End Select
        End If
    End Sub
    Private Sub btnAlbumArtDragEnter(sender As Object, e As DragEventArgs) Handles btnAlbumArt.DragEnter
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
    Private Sub btnAlbumArtDragDrop(sender As Object, e As DragEventArgs) Handles btnAlbumArt.DragDrop
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
    Private Sub btnAlbumArtMouseUp(sender As Object, e As MouseEventArgs) Handles btnAlbumArt.MouseUp
        If My.App.MouseInBounds(CType(sender, Control), e.Location) Then
            If tlFile.Tag.Pictures.Length > 0 Then ResetLyrics()
            Me.cmAlbumArt.Show(Me.btnAlbumArt, Point.Subtract(Point.Subtract(MousePosition, New Size(Me.Location)), New Size(Me.btnAlbumArt.Location)))
            If e.Button = MouseButtons.Left Then Me.txbxAlbumArt.Focus()
        End If
    End Sub
    Private Sub btnAlbumArtLeftMouseUp(sender As Object, e As MouseEventArgs) Handles btnAlbumArtLeft.MouseUp
        If My.App.MouseInBounds(CType(sender, Control), e.Location) Then
            Select Case e.Button
                Case MouseButtons.Left
                    txbxAlbumArt.CausesValidation = False
                    cobxAlbumArtType.CausesValidation = False
                    My.tagArtIndex -= 1
                    If My.tagArtIndex < 0 Then My.tagArtIndex = 0
                    ShowTag()
                    ResetLyrics()
                    txbxAlbumArt.CausesValidation = True
                    cobxAlbumArtType.CausesValidation = True
                Case MouseButtons.Right
                    If My.Computer.Keyboard.CtrlKeyDown Then : MoveArt(rMove.First)
                    Else : MoveArt(rMove.Left)
                    End If
            End Select
        End If
    End Sub
    Private Sub btnAlbumArtRightMouseUp(sender As Object, e As MouseEventArgs) Handles btnAlbumArtRight.MouseUp
        If My.App.MouseInBounds(CType(sender, Control), e.Location) Then
            Select Case e.Button
                Case MouseButtons.Left
                    txbxAlbumArt.CausesValidation = False
                    cobxAlbumArtType.CausesValidation = False
                    My.tagArtIndex += 1
                    If My.tagArtIndex > tlFile.Tag.Pictures.Length - 1 Then My.tagArtIndex = tlFile.Tag.Pictures.Length - 1
                    ShowTag()
                    ResetLyrics()
                    txbxAlbumArt.CausesValidation = True
                    cobxAlbumArtType.CausesValidation = True
                Case MouseButtons.Right
                    If My.Computer.Keyboard.CtrlKeyDown Then : MoveArt(rMove.Last)
                    Else : MoveArt(rMove.Right)
                    End If
            End Select
        End If
    End Sub
    Private Sub btnLyricsClick(sender As Object, e As EventArgs) Handles btnLyrics.Click
        wShowLyrics = Not wShowLyrics
        SetLyrics()
    End Sub
    Private Sub tipInfo_Popup(sender As Object, e As PopupEventArgs) Handles tipInfo.Popup
        Static s As Size
        s = TextRenderer.MeasureText(tipInfo.GetToolTip(e.AssociatedControl), App.TipFont)
        If tipInfo.Tag Is Nothing Then
            s.Width += 14
            s.Height += 14
        Else
            s.Width += CType(tipInfo.Tag, Bitmap).Width + 14
            s.Height = CType(tipInfo.Tag, Bitmap).Height + 12
        End If
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
        If tipInfo.Tag Is Nothing Then
            TextRenderer.DrawText(g, e.ToolTipText, App.TipFont, New Point(7, 7), App.TipTextColor)
        Else
            g.DrawImage(CType(tipInfo.Tag, Bitmap), New Point(7, 7))
            TextRenderer.DrawText(g, e.ToolTipText, App.TipFont, New Point(7 + CType(tipInfo.Tag, Bitmap).Width, CInt(CType(tipInfo.Tag, Bitmap).Height / 2 - 3)), App.TipTextColor)
            tipInfo.Tag = Nothing
        End If

        'Finalize
        brbg.Dispose()
        g.Dispose()

    End Sub

    'Handlers
    Private Sub clickTimer_Tick(sender As Object, e As EventArgs)
        'Clear double click watcher and timer
        inDoubleClick = False
        clickTimer.Stop()
        'Perform Single-Click Action
        If lblFileInfo.Text = App.sNoFile Then
            OpenFile()
        Else
            App.PlayMedia()
        End If
    End Sub

    'Procedures
    Friend Sub SetError()
        Me.btnError.Visible = True
        If Not String.IsNullOrEmpty(My.AppAlertMessage) Then
            tipInfo.Tag = SystemIcons.Error.ToBitmap
            tipInfo.Show(My.AppAlertMessage, Me, Me.btnError.Right + SystemInformation.FrameBorderSize.Width, Me.btnError.Bottom + SystemInformation.FrameBorderSize.Height + SystemInformation.CaptionHeight)
        End If
    End Sub
    Friend Sub ClearError()
#If DEBUG Then
#Else
			Me.btnError.Visible = False
#End If
    End Sub
    Private Sub OpenFile()
        Dim ofd As New OpenFileDialog
        ofd.Title = "Select Media File(s)"
        ofd.Filter = "All Files|*.*"
        ofd.Multiselect = True
        Dim result As DialogResult = ofd.ShowDialog(Me)
        If result = DialogResult.OK AndAlso ofd.FileNames.Length > 0 Then
            If ofd.FileNames.Length = 1 Then : My.tagPath = ofd.FileName
            Else : My.App.ProcessPassedParameters(Array.AsReadOnly(ofd.FileNames))
            End If
            SetTag()
            ShowTag()
            ClearSave()
        End If
        result = Nothing
        ofd.Dispose()
        ofd = Nothing
    End Sub
    Private Sub CloseFile()
        If Not String.IsNullOrEmpty(My.tagPath) Then
            ClearFile()
            My.tagPath = String.Empty
            ShowTag()
            My.App.WriteToLog("Media File Closed")
        End If
    End Sub
    Private Sub ClearFile()
        On Error Resume Next
        If tlFile IsNot Nothing Then
            tlFile.Dispose()
            tlFile = Nothing
        End If
    End Sub
    Private Sub SetTag()
        ClearFile()
        If String.IsNullOrEmpty(My.tagPath) Then : Me.tipInfo.SetToolTip(Me.lblFileInfo, My.App.sNoFile)
        Else
            Static fInfo As IO.FileInfo
            Static sExtendedInfo As String
            Try
                tlFile = TagLib.File.Create(My.tagPath)
                If tlFile.Tag.Performers Is Nothing Then tlFile.Tag.Performers = New String() {}
                fInfo = New IO.FileInfo(My.tagPath)
                sExtendedInfo = fInfo.Name
                lblFileInfo.Text = fInfo.Name
                sExtendedInfo += vbCr + "@" + fInfo.DirectoryName
                sExtendedInfo += vbCr + My.App.FormatFileSize(My.Computer.FileSystem.GetFileInfo(My.tagPath).Length, My.App.FormatFileSizeUnits.Auto, 2, False)
                If tlFile.Properties IsNot Nothing Then
                    sExtendedInfo += vbCr + "Type: " + tlFile.Properties.MediaTypes.ToString + " (" + tlFile.Properties.Description + ")"
                    Me.cobxGenre.Items.Clear()

                    Select Case tlFile.Properties.MediaTypes
                        Case TagLib.MediaTypes.Audio
                            For Each s As String In TagLib.Genres.Audio : Me.cobxGenre.Items.Add(s) : Next
                            sExtendedInfo += vbCr + "Properties: "
                            Select Case tlFile.Properties.AudioChannels
                                Case 1 : sExtendedInfo += "Mono"
                                Case 2 : sExtendedInfo += "Stereo"
                                Case Else : sExtendedInfo += tlFile.Properties.AudioChannels.ToString + " channels"
                            End Select
                            sExtendedInfo += ", " + tlFile.Properties.AudioBitrate.ToString + " Kbps, " + tlFile.Properties.AudioSampleRate.ToString + " Hz"
                        Case TagLib.MediaTypes.Video Or TagLib.MediaTypes.Audio
                            For Each s As String In TagLib.Genres.Video : Me.cobxGenre.Items.Add(s) : Next
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
                Me.tipInfo.SetToolTip(lblFileInfo, sExtendedInfo)
                sExtendedInfo = Nothing
                My.tagArtistIndex = 0
                My.tagArtIndex = 0
                My.App.WriteToLog("Tag Opened")
            Catch ex As TagLib.UnsupportedFormatException
                If My.Computer.FileSystem.DirectoryExists(My.tagPath) Then
                    My.App.WriteToLog("Tag NOT Opened (" + My.App.sNotFile + ")")
                    Me.tipInfo.SetToolTip(Me.btnError, My.tagPath + vbCr + My.App.sNotFile)
                    My.AppAlertMessage = My.App.sNotFile
                Else
                    My.App.WriteToLog("Tag NOT Opened (" + My.App.sUnSupportedFile + ")")
                    Me.tipInfo.SetToolTip(Me.btnError, My.tagPath + vbCr + My.App.sUnSupportedFile)
                    My.AppAlertMessage = My.App.sUnSupportedFile
                End If
                My.App.ErrorNotification()
                ClearFile()
            Catch ex As TagLib.CorruptFileException
                My.App.WriteToLog("Tag NOT Opened (" + My.App.sBadFile + ")")
                Me.tipInfo.SetToolTip(Me.btnError, My.tagPath + vbCr + My.App.sBadFile)
                My.AppAlertMessage = My.App.sBadFile
                My.App.ErrorNotification()
                ClearFile()
            Catch ex As Xml.XmlException
                My.App.WriteToLog("Tag NOT Opened (" + My.App.sBadFile + ")")
                Me.tipInfo.SetToolTip(Me.btnError, My.tagPath + vbCr + My.App.sBadFile)
                My.AppAlertMessage = My.App.sBadFile
                My.App.ErrorNotification()
                ClearFile()
            Catch ex As IO.FileNotFoundException
                My.App.WriteToLog("Tag NOT Opened (" + My.App.sNotFound + ")")
                Me.tipInfo.SetToolTip(Me.btnError, My.tagPath + vbCr + My.App.sNotFound)
                My.AppAlertMessage = My.App.sNotFound
                My.App.ErrorNotification()
                ClearFile()
            Catch ex As IO.IOException
                My.App.WriteToLog("Tag NOT Opened (" + My.App.sUnAccessibleFile + ")")
                Me.tipInfo.SetToolTip(Me.btnError, My.tagPath + vbCr + My.App.sUnAccessibleFile)
                My.AppAlertMessage = My.App.sUnAccessibleFile
                My.App.ErrorNotification()
                ClearFile()
            Catch ex As Exception
                My.App.WriteToLog("Tag NOT Opened (" + My.App.sError + ")")
                My.App.WriteToLog(ex.ToString, False)
                Me.tipInfo.SetToolTip(Me.btnError, My.tagPath + vbCr + My.App.sError)
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
            Me.Text = My.Application.Info.ProductName
        Else
            SetControls(True)
            Me.Text = My.Application.Info.ProductName + IIf(String.IsNullOrEmpty(tlFile.Tag.FirstPerformer), String.Empty, " --> " + tlFile.Tag.FirstPerformer + IIf(String.IsNullOrEmpty(tlFile.Tag.Title), String.Empty, " / " + tlFile.Tag.Title).ToString + IIf(String.IsNullOrEmpty(tlFile.Tag.Album), String.Empty, " / " + tlFile.Tag.Album).ToString).ToString
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
            Me.txbxGenre.Text = tlFile.Tag.FirstGenre
            Me.cobxGenre.Text = tlFile.Tag.FirstGenre
            Me.txbxTitle.Text = tlFile.Tag.Title
            Me.txbxTrack.Text = IIf(tlFile.Tag.Track = 0, String.Empty, tlFile.Tag.Track).ToString
            Me.txbxTrackCount.Text = IIf(tlFile.Tag.TrackCount = 0, String.Empty, tlFile.Tag.TrackCount.ToString).ToString
            If tlFile.Properties Is Nothing OrElse tlFile.Properties.Duration = TimeSpan.Zero Then
                Me.lblDuration.Enabled = False
                Me.txbxDuration.ResetText()
                Me.txbxDuration.Enabled = False
            Else
                If tlFile.Properties.Duration > New TimeSpan(0, 59, 59) Then : Me.txbxDuration.Text = tlFile.Properties.Duration.ToString("h\:mm\:ss")
                Else : Me.txbxDuration.Text = tlFile.Properties.Duration.ToString("m\:ss")
                End If
            End If
            Me.txbxAlbum.Text = tlFile.Tag.Album
            Me.txbxYear.Text = IIf(tlFile.Tag.Year = 0, String.Empty, tlFile.Tag.Year).ToString
            Me.txbxComments.Text = tlFile.Tag.Comment
            Me.txbxLyrics.Text = tlFile.Tag.Lyrics
            Me.txbxLyrics.Select(0, 0)
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
                If Me.picbxAlbumArt.Image IsNot Nothing Then Me.tipInfo.SetToolTip(Me.picbxAlbumArt, Me.picbxAlbumArt.Image.Size.Width.ToString + "x" + Me.picbxAlbumArt.Image.Size.Height.ToString + vbCr + tlFile.Tag.Pictures(My.tagArtIndex).MimeType + vbCr + My.App.FormatFileSize(tlFile.Tag.Pictures(My.tagArtIndex).Data.Data.Length, My.App.FormatFileSizeUnits.Auto))
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
        End If
        If My.tagPath = String.Empty Then
            Me.lblFileInfo.Text = My.App.sNoFile
            Me.tipInfo.SetToolTip(Me.lblFileInfo, My.App.sNoFile)
        End If
        Me.ResumeLayout()
    End Sub
    Private Sub CopyTag(mode As App.CopyModes)
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
    End Sub
    Private Sub PasteTag()
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
                    s = Nothing
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
                    s = Nothing
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
            SetSave()
        End If
    End Sub
    Private Sub SetControls(enabled As Boolean)
        Me.lblArtist.Enabled = enabled
        SetArtistControls(enabled)
        Me.txbxArtist.ResetText()
        Me.txbxArtist.Enabled = enabled
        Me.lblGenre.Enabled = enabled
        Me.txbxGenre.ResetText()
        Me.txbxGenre.Enabled = enabled
        Me.cobxGenre.ResetText()
        Me.cobxGenre.Enabled = enabled
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
        Me.btnSave.Enabled = enabled
        If enabled Then
            If NeedsSaved Then
                btnRestore.Enabled = True
            Else
                btnRestore.Enabled = False
            End If
        Else
            btnRestore.Enabled = enabled
        End If
    End Sub
    Private Sub SetArtistControls(enabled As Boolean)
        If enabled AndAlso Not tlFile Is Nothing AndAlso Not tlFile.TagTypes = TagLib.TagTypes.None AndAlso tlFile.Tag IsNot Nothing Then
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
    Private Sub SetArtControls(enabled As Boolean)
        If enabled _
        AndAlso Not tlFile Is Nothing _
        AndAlso Not tlFile.TagTypes = TagLib.TagTypes.None _
        AndAlso (tlFile.Properties IsNot Nothing AndAlso Not tlFile.Properties.MediaTypes = TagLib.MediaTypes.Photo) _
        Then
            Me.btnAlbumArt.Enabled = True
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
        Else
            Me.btnAlbumArt.Enabled = False
            Me.btnAlbumArtLeft.Enabled = False
            Me.btnAlbumArtRight.Enabled = False
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
        SetSave()
    End Sub
    Private Sub MoveArtist(move As rMove)
        If tlFile.Tag.Performers.Length > 1 Then
            Dim alist As New Collections.Generic.List(Of String)
            For Each s As String In tlFile.Tag.Performers : alist.Add(s) : Next
            Dim smove As String = alist(My.tagArtistIndex)
            alist.RemoveAt(My.tagArtistIndex)
            Select Case move
                Case rMove.Left
                    alist.Insert(My.tagArtistIndex - 1, smove)
                    My.tagArtistIndex -= 1
                Case rMove.First
                    alist.Insert(0, smove)
                    My.tagArtistIndex = 0
                Case rMove.Right
                    alist.Insert(My.tagArtistIndex + 1, smove)
                    My.tagArtistIndex += 1
                Case rMove.Last
                    alist.Insert(alist.Count, smove)
                    My.tagArtistIndex = tlFile.Tag.Performers.Length - 1
            End Select
            tlFile.Tag.Performers = alist.ToArray
            smove = Nothing
            alist.Clear()
            alist = Nothing
            ShowTag()
            SetSave()
        End If
    End Sub
    Private Sub InsertArt(index As Integer, picsource As My.App.ImageSource, Optional picpath As String = Nothing)
        If Not tlFile.TagTypes = TagLib.TagTypes.None Then
            Dim newpic As TagLib.IPicture
            newpic = My.App.GetNewPic(picsource, picpath)
            If newpic IsNot Nothing Then
                Dim piclist As New Collections.Generic.List(Of TagLib.IPicture)
                For Each pic As TagLib.IPicture In tlFile.Tag.Pictures : piclist.Add(pic) : Next
                newpic.Description = Nothing
                newpic.Type = Nothing
                piclist.Insert(index, newpic)
                tlFile.Tag.Pictures = piclist.ToArray
                My.tagArtIndex = index
                piclist.Clear()
                piclist = Nothing
                newpic = Nothing
                ShowTag()
                If wShowLyrics Then
                    wShowLyrics = False
                    SetLyrics()
                End If
                SetSave()
            Else
                If picsource = My.App.ImageSource.ClipBoard Then
                    tipInfo.Tag = SystemIcons.Information.ToBitmap
                    tipInfo.Show("No Image On ClipBoard", Me, Me.btnAlbumArt.Left + CInt(Me.btnAlbumArt.Width / 2) + SystemInformation.FrameBorderSize.Width, Me.btnAlbumArt.Top + CInt(Me.btnAlbumArt.Height / 2) + SystemInformation.FrameBorderSize.Height + SystemInformation.CaptionHeight, 4000)
                End If
            End If
        End If
    End Sub
    Private Sub MoveArt(move As rMove)
        If tlFile.Tag.Pictures.Length > 1 Then
            Dim piclist As New Collections.Generic.List(Of TagLib.IPicture)
            For Each pic As TagLib.IPicture In tlFile.Tag.Pictures : piclist.Add(pic) : Next
            Dim movepic As TagLib.IPicture = piclist(My.tagArtIndex)
            piclist.RemoveAt(My.tagArtIndex)
            Select Case move
                Case rMove.Left
                    piclist.Insert(My.tagArtIndex - 1, movepic)
                    My.tagArtIndex -= 1
                Case rMove.First
                    piclist.Insert(0, movepic)
                    My.tagArtIndex = 0
                Case rMove.Right
                    piclist.Insert(My.tagArtIndex + 1, movepic)
                    My.tagArtIndex += 1
                Case rMove.Last
                    piclist.Insert(piclist.Count, movepic)
                    My.tagArtIndex = tlFile.Tag.Pictures.Length - 1
            End Select
            tlFile.Tag.Pictures = piclist.ToArray
            movepic = Nothing
            piclist.Clear()
            piclist = Nothing
            ShowTag()
            SetSave()
        End If
    End Sub
    Private Sub SetLyrics()
        Select Case wShowLyrics
            Case True
                Me.panelAlbumArt.SendToBack()
                Me.btnLyrics.BackColor = WinAPI.GetSystemColor(COLOR_HIGHLIGHT) 'Color.Linen
                Me.btnLyrics.FlatAppearance.MouseDownBackColor = SystemColors.Control
                Me.btnLyrics.FlatAppearance.MouseOverBackColor = SystemColors.Control
                Me.txbxLyrics.Focus()
            Case False
                Me.txbxLyrics.SendToBack()
                Me.btnLyrics.Image = Resources.Resources.imageDocument 'DirectCast(My.AppResources.GetObject("imageDocument"), Image)
                Me.btnLyrics.BackColor = SystemColors.Control
                Me.btnLyrics.FlatAppearance.MouseDownBackColor = WinAPI.GetSystemColor(COLOR_HIGHLIGHT) 'Color.Linen
                Me.btnLyrics.FlatAppearance.MouseOverBackColor = WinAPI.GetSystemColor(COLOR_HIGHLIGHT) 'Color.Linen
                Me.tipInfo.SetToolTip(Me.btnLyrics, "Show Lyrics")
        End Select
    End Sub
    Private Sub ResetLyrics()
        If wShowLyrics Then
            wShowLyrics = False
            SetLyrics()
        End If
    End Sub
    Private Sub SetSave(Optional forcepaint As Boolean = False)
        If Not NeedsSaved OrElse forcepaint Then
            NeedsSaved = True
            Me.btnSave.ResetForeColor()
            Me.btnSave.ForeColor = Color.Firebrick
            Me.btnSave.Font = New Font(Me.Font, FontStyle.Bold)
            btnRestore.Enabled = True
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
    Private Sub SetWindowState()
        Me.SuspendLayout()
        Select Case wMaximized
            Case True
                Me.WindowState = FormWindowState.Maximized
                Me.panelAlbumArt.AutoScroll = True
                Me.picbxAlbumArt.Dock = DockStyle.None
                Me.picbxAlbumArt.SizeMode = PictureBoxSizeMode.AutoSize
                Me.txbxLyrics.Font = New Font(Me.Font.Name, 14, FontStyle.Bold)
                Me.txbxLyrics.TextAlign = HorizontalAlignment.Center
            Case False
                Me.WindowState = FormWindowState.Normal
                Me.panelAlbumArt.AutoScroll = False
                Me.picbxAlbumArt.Dock = DockStyle.Fill
                Me.picbxAlbumArt.SizeMode = PictureBoxSizeMode.Zoom
                Me.txbxLyrics.Font = New Font(Me.Font.Name, 10, FontStyle.Regular)
                Me.txbxLyrics.TextAlign = HorizontalAlignment.Left
        End Select
        Me.ResumeLayout()
    End Sub
    Private Sub CheckMove(ByRef location As Point)
        If location.X + Me.Width > My.Computer.Screen.WorkingArea.Right Then location.X = My.Computer.Screen.WorkingArea.Right - Me.Width + App.AdjustScreenBoundsNormalWindow
        If location.Y + Me.Height > My.Computer.Screen.WorkingArea.Bottom Then location.Y = My.Computer.Screen.WorkingArea.Bottom - Me.Height + App.AdjustScreenBoundsNormalWindow
        If location.X < My.Computer.Screen.WorkingArea.Left Then location.X = My.Computer.Screen.WorkingArea.Left - App.AdjustScreenBoundsNormalWindow
        If location.Y < App.AdjustScreenBoundsNormalWindow Then location.Y = My.Computer.Screen.WorkingArea.Top
    End Sub
    Private Sub SetAccentColor()
        If IsFocused Then
            '
            'API Method
            'Dim params As WinAPI.DWMCOLORIZATIONPARAMS
            'WinAPI.DwmGetColorizationParameters(params)
            'c = Color.FromArgb(255, App.GetRValue(params.ColorizationColor), App.GetGValue(params.ColorizationColor), App.GetBValue(params.ColorizationColor))
            '
            Dim c As Color
            Dim regkey As RegistryKey
            Dim regvalue As Integer
            regkey = Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\DWM")
            regvalue = CInt(regkey.GetValue("AccentColor"))
            c = Color.FromArgb(255, WinAPI.GetRValue(regvalue), WinAPI.GetGValue(regvalue), WinAPI.GetBValue(regvalue))
            MenuMain.BackColor = c
            regkey.Close()
            regkey.Dispose()
            Debug.Print("Accent Color Changed")
        End If
    End Sub
    Private Sub SetInactiveColor()
        MenuMain.BackColor = App.InactiveTitleBarColor
    End Sub

End Class
