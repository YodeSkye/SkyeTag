Partial Friend Class MainForm
    Inherits System.Windows.Forms.Form
    Private components As System.ComponentModel.IContainer
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If components IsNot Nothing Then
                components.Dispose
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        btnError = New Button()
        tipInfo = New ToolTip(components)
        btnSave = New Button()
        btnAlbumArtRight = New Button()
        btnAlbumArtLeft = New Button()
        btnRestore = New Button()
        btnArtistLeft = New Button()
        btnArtistRight = New Button()
        btnArtistInsert = New Button()
        btnArtistDelete = New Button()
        btnAlbumArt = New Button()
        cmAlbumArt = New ContextMenuStrip(components)
        cmiAlbumArtInsert = New ToolStripMenuItem()
        cmAlbumArtInsert = New ContextMenuStrip(components)
        cmiAlbumArtInsertBefore = New ToolStripMenuItem()
        cmiAlbumArtInsertAfter = New ToolStripMenuItem()
        cmiAlbumArtInsertFirst = New ToolStripMenuItem()
        cmiAlbumArtInsertLast = New ToolStripMenuItem()
        cmiAlbumArtSelect = New ToolStripMenuItem()
        cmiAlbumArtExport = New ToolStripMenuItem()
        tsSeparator1 = New ToolStripSeparator()
        cmiAlbumArtMoveLeft = New ToolStripMenuItem()
        cmiAlbumArtMoveRight = New ToolStripMenuItem()
        tsSeparator2 = New ToolStripSeparator()
        cmiAlbumArtDelete = New ToolStripMenuItem()
        picbxAlbumArt = New PictureBox()
        txbxArtist = New TextBox()
        txbxAlbum = New TextBox()
        txbxAlbumArt = New TextBox()
        cobxAlbumArtType = New ComboBox()
        txbxTitle = New TextBox()
        txbxYear = New TextBox()
        txbxTrack = New TextBox()
        txbxComments = New TextBox()
        cobxGenre = New ComboBox()
        txbxLyrics = New TextBox()
        btnLyrics = New Button()
        txbxDuration = New TextBox()
        txbxTrackCount = New TextBox()
        txbxGenre = New TextBox()
        panelAlbumArt = New Panel()
        MenuMain = New MenuStrip()
        MIFile = New ToolStripMenuItem()
        MIOpenFile = New ToolStripMenuItem()
        MITrimFile = New ToolStripMenuItem()
        MIOpenLocation = New ToolStripMenuItem()
        MICloseFile = New ToolStripMenuItem()
        ToolStripSeparator1 = New ToolStripSeparator()
        MIExit = New ToolStripMenuItem()
        MIEdit = New ToolStripMenuItem()
        MICopyTagBasic = New ToolStripMenuItem()
        MICopyTagArt = New ToolStripMenuItem()
        MICopyTagFull = New ToolStripMenuItem()
        MIPasteTag = New ToolStripMenuItem()
        MIView = New ToolStripMenuItem()
        MISettings = New ToolStripMenuItem()
        MIPlay = New ToolStripMenuItem()
        MIAbout = New ToolStripMenuItem()
        MIHelp = New ToolStripMenuItem()
        MILog = New ToolStripMenuItem()
        lblFileInfo = New My.Components.LabelCSY()
        lblArtist = New My.Components.LabelCSY()
        lblGenre = New My.Components.LabelCSY()
        lblTitle = New My.Components.LabelCSY()
        lblAlbum = New My.Components.LabelCSY()
        lblComments = New My.Components.LabelCSY()
        lblAlbumArt = New My.Components.LabelCSY()
        lblTrack = New My.Components.LabelCSY()
        lblTrackSeparator = New My.Components.LabelCSY()
        lblDuration = New My.Components.LabelCSY()
        lblYear = New My.Components.LabelCSY()
        cmAlbumArt.SuspendLayout()
        cmAlbumArtInsert.SuspendLayout()
        CType(picbxAlbumArt, ComponentModel.ISupportInitialize).BeginInit()
        panelAlbumArt.SuspendLayout()
        MenuMain.SuspendLayout()
        SuspendLayout()
        ' 
        ' btnError
        ' 
        btnError.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnError.BackgroundImageLayout = ImageLayout.None
        btnError.FlatAppearance.BorderColor = SystemColors.ControlDark
        btnError.FlatAppearance.BorderSize = 0
        btnError.FlatAppearance.MouseDownBackColor = Color.Transparent
        btnError.FlatAppearance.MouseOverBackColor = Color.Transparent
        btnError.Image = My.Resources.Resources.imageError
        btnError.Location = New Point(340, 517)
        btnError.Name = "btnError"
        btnError.Size = New Size(32, 32)
        btnError.TabIndex = 25
        btnError.TabStop = False
        tipInfo.SetToolTip(btnError, "An Error Has Occurred" & vbCrLf & "Click To Clear Error" & vbCrLf & "RightClick = View Log")
        btnError.Visible = False
        ' 
        ' tipInfo
        ' 
        tipInfo.AutomaticDelay = 100
        tipInfo.AutoPopDelay = 5000
        tipInfo.InitialDelay = 100
        tipInfo.ReshowDelay = 20
        ' 
        ' btnSave
        ' 
        btnSave.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnSave.FlatAppearance.BorderColor = SystemColors.Info
        btnSave.FlatAppearance.BorderSize = 2
        btnSave.FlatAppearance.MouseDownBackColor = Color.GhostWhite
        btnSave.FlatAppearance.MouseOverBackColor = SystemColors.Info
        btnSave.Image = My.Resources.Resources.imageSave
        btnSave.ImageAlign = ContentAlignment.MiddleLeft
        btnSave.Location = New Point(10, 518)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(79, 32)
        btnSave.TabIndex = 1000
        btnSave.Text = "Save"
        btnSave.TextAlign = ContentAlignment.MiddleRight
        tipInfo.SetToolTip(btnSave, "Save Tag To File")
        ' 
        ' btnAlbumArtRight
        ' 
        btnAlbumArtRight.CausesValidation = False
        btnAlbumArtRight.FlatAppearance.BorderColor = SystemColors.ControlDark
        btnAlbumArtRight.FlatAppearance.BorderSize = 0
        btnAlbumArtRight.FlatAppearance.MouseDownBackColor = Color.Transparent
        btnAlbumArtRight.FlatAppearance.MouseOverBackColor = Color.Transparent
        btnAlbumArtRight.FlatStyle = FlatStyle.Flat
        btnAlbumArtRight.Image = My.Resources.Resources.imageAdvanceRight
        btnAlbumArtRight.Location = New Point(233, 236)
        btnAlbumArtRight.Name = "btnAlbumArtRight"
        btnAlbumArtRight.Size = New Size(16, 16)
        btnAlbumArtRight.TabIndex = 0
        btnAlbumArtRight.TabStop = False
        tipInfo.SetToolTip(btnAlbumArtRight, "LeftClick = Next Image" & vbCrLf & "RightClick = Move Right" & vbCrLf & "CtrlRightClick = Move Last")
        btnAlbumArtRight.UseMnemonic = False
        btnAlbumArtRight.UseVisualStyleBackColor = False
        ' 
        ' btnAlbumArtLeft
        ' 
        btnAlbumArtLeft.CausesValidation = False
        btnAlbumArtLeft.FlatAppearance.BorderColor = SystemColors.ControlDark
        btnAlbumArtLeft.FlatAppearance.BorderSize = 0
        btnAlbumArtLeft.FlatAppearance.MouseDownBackColor = Color.Transparent
        btnAlbumArtLeft.FlatAppearance.MouseOverBackColor = Color.Transparent
        btnAlbumArtLeft.FlatStyle = FlatStyle.Flat
        btnAlbumArtLeft.Image = My.Resources.Resources.imageAdvanceLeft
        btnAlbumArtLeft.Location = New Point(217, 236)
        btnAlbumArtLeft.Name = "btnAlbumArtLeft"
        btnAlbumArtLeft.Size = New Size(16, 16)
        btnAlbumArtLeft.TabIndex = 0
        btnAlbumArtLeft.TabStop = False
        tipInfo.SetToolTip(btnAlbumArtLeft, "LeftClick = Previous Image" & vbCrLf & "RightClick = Move Left" & vbCrLf & "CtrlRightClick = Move First")
        btnAlbumArtLeft.UseMnemonic = False
        btnAlbumArtLeft.UseVisualStyleBackColor = False
        ' 
        ' btnRestore
        ' 
        btnRestore.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnRestore.Enabled = False
        btnRestore.FlatAppearance.BorderColor = SystemColors.Info
        btnRestore.FlatAppearance.BorderSize = 2
        btnRestore.FlatAppearance.MouseDownBackColor = Color.GhostWhite
        btnRestore.FlatAppearance.MouseOverBackColor = SystemColors.Info
        btnRestore.Image = My.Resources.Resources.imageRestore
        btnRestore.ImageAlign = ContentAlignment.MiddleLeft
        btnRestore.Location = New Point(95, 518)
        btnRestore.Name = "btnRestore"
        btnRestore.Size = New Size(79, 32)
        btnRestore.TabIndex = 1005
        btnRestore.Text = "Undo"
        btnRestore.TextAlign = ContentAlignment.MiddleRight
        tipInfo.SetToolTip(btnRestore, "Restore Original Tag")
        ' 
        ' btnArtistLeft
        ' 
        btnArtistLeft.CausesValidation = False
        btnArtistLeft.FlatAppearance.BorderColor = SystemColors.ControlDark
        btnArtistLeft.FlatAppearance.BorderSize = 0
        btnArtistLeft.FlatAppearance.MouseDownBackColor = Color.Transparent
        btnArtistLeft.FlatAppearance.MouseOverBackColor = Color.Transparent
        btnArtistLeft.FlatStyle = FlatStyle.Flat
        btnArtistLeft.Image = My.Resources.Resources.imageAdvanceLeft
        btnArtistLeft.Location = New Point(217, 68)
        btnArtistLeft.Name = "btnArtistLeft"
        btnArtistLeft.Size = New Size(16, 16)
        btnArtistLeft.TabIndex = 1012
        btnArtistLeft.TabStop = False
        tipInfo.SetToolTip(btnArtistLeft, "LeftClick = Previous Artist" & vbCrLf & "RightClick = Move Artist Left" & vbCrLf & "CtrlRightClick = Move Artist First")
        btnArtistLeft.UseMnemonic = False
        btnArtistLeft.UseVisualStyleBackColor = False
        ' 
        ' btnArtistRight
        ' 
        btnArtistRight.CausesValidation = False
        btnArtistRight.FlatAppearance.BorderColor = SystemColors.ControlDark
        btnArtistRight.FlatAppearance.BorderSize = 0
        btnArtistRight.FlatAppearance.MouseDownBackColor = Color.Transparent
        btnArtistRight.FlatAppearance.MouseOverBackColor = Color.Transparent
        btnArtistRight.FlatStyle = FlatStyle.Flat
        btnArtistRight.Image = My.Resources.Resources.imageAdvanceRight
        btnArtistRight.Location = New Point(233, 68)
        btnArtistRight.Name = "btnArtistRight"
        btnArtistRight.Size = New Size(16, 16)
        btnArtistRight.TabIndex = 1011
        btnArtistRight.TabStop = False
        tipInfo.SetToolTip(btnArtistRight, "LeftClick = Next Artist" & vbCrLf & "RightClick = Move Artist Right" & vbCrLf & "CtrlRightClick = Move Artist Last")
        btnArtistRight.UseMnemonic = False
        btnArtistRight.UseVisualStyleBackColor = False
        ' 
        ' btnArtistInsert
        ' 
        btnArtistInsert.AllowDrop = True
        btnArtistInsert.CausesValidation = False
        btnArtistInsert.FlatAppearance.BorderColor = SystemColors.ControlDark
        btnArtistInsert.FlatAppearance.BorderSize = 0
        btnArtistInsert.FlatAppearance.MouseDownBackColor = Color.Transparent
        btnArtistInsert.FlatAppearance.MouseOverBackColor = Color.Transparent
        btnArtistInsert.FlatStyle = FlatStyle.Flat
        btnArtistInsert.Image = My.Resources.Resources.imageNew
        btnArtistInsert.Location = New Point(116, 67)
        btnArtistInsert.Name = "btnArtistInsert"
        btnArtistInsert.Size = New Size(16, 16)
        btnArtistInsert.TabIndex = 1014
        btnArtistInsert.TabStop = False
        tipInfo.SetToolTip(btnArtistInsert, "LeftClick = Insert New Artist (After This One)" & vbCrLf & "CtrlLeftClick = Insert Using Text From ClipBoard")
        btnArtistInsert.UseMnemonic = False
        btnArtistInsert.UseVisualStyleBackColor = False
        ' 
        ' btnArtistDelete
        ' 
        btnArtistDelete.CausesValidation = False
        btnArtistDelete.FlatAppearance.BorderColor = SystemColors.ControlDark
        btnArtistDelete.FlatAppearance.BorderSize = 0
        btnArtistDelete.FlatAppearance.MouseDownBackColor = Color.Transparent
        btnArtistDelete.FlatAppearance.MouseOverBackColor = Color.Transparent
        btnArtistDelete.FlatStyle = FlatStyle.Flat
        btnArtistDelete.Image = My.Resources.Resources.imageDelete
        btnArtistDelete.Location = New Point(140, 66)
        btnArtistDelete.Name = "btnArtistDelete"
        btnArtistDelete.Size = New Size(16, 16)
        btnArtistDelete.TabIndex = 1013
        btnArtistDelete.TabStop = False
        tipInfo.SetToolTip(btnArtistDelete, "LeftClick = Remove This Artist")
        btnArtistDelete.UseMnemonic = False
        btnArtistDelete.UseVisualStyleBackColor = False
        ' 
        ' btnAlbumArt
        ' 
        btnAlbumArt.AllowDrop = True
        btnAlbumArt.CausesValidation = False
        btnAlbumArt.ContextMenuStrip = cmAlbumArt
        btnAlbumArt.FlatAppearance.BorderColor = SystemColors.ControlDark
        btnAlbumArt.FlatAppearance.BorderSize = 0
        btnAlbumArt.FlatAppearance.MouseDownBackColor = Color.Transparent
        btnAlbumArt.FlatAppearance.MouseOverBackColor = Color.Transparent
        btnAlbumArt.FlatStyle = FlatStyle.Flat
        btnAlbumArt.Image = My.Resources.Resources.imageImage
        btnAlbumArt.Location = New Point(140, 233)
        btnAlbumArt.Name = "btnAlbumArt"
        btnAlbumArt.Size = New Size(16, 17)
        btnAlbumArt.TabIndex = 0
        btnAlbumArt.TabStop = False
        btnAlbumArt.UseMnemonic = False
        btnAlbumArt.UseVisualStyleBackColor = False
        ' 
        ' cmAlbumArt
        ' 
        cmAlbumArt.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        cmAlbumArt.Items.AddRange(New ToolStripItem() {cmiAlbumArtInsert, cmiAlbumArtSelect, cmiAlbumArtExport, tsSeparator1, cmiAlbumArtMoveLeft, cmiAlbumArtMoveRight, tsSeparator2, cmiAlbumArtDelete})
        cmAlbumArt.Name = "cmAlbumArt"
        cmAlbumArt.Size = New Size(144, 148)
        ' 
        ' cmiAlbumArtInsert
        ' 
        cmiAlbumArtInsert.DropDown = cmAlbumArtInsert
        cmiAlbumArtInsert.Image = My.Resources.Resources.imageNew
        cmiAlbumArtInsert.Name = "cmiAlbumArtInsert"
        cmiAlbumArtInsert.Size = New Size(143, 22)
        cmiAlbumArtInsert.Text = "Insert"
        ' 
        ' cmAlbumArtInsert
        ' 
        cmAlbumArtInsert.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        cmAlbumArtInsert.Items.AddRange(New ToolStripItem() {cmiAlbumArtInsertBefore, cmiAlbumArtInsertAfter, cmiAlbumArtInsertFirst, cmiAlbumArtInsertLast})
        cmAlbumArtInsert.Name = "cmAlbumArtInsert"
        cmAlbumArtInsert.OwnerItem = cmiAlbumArtInsert
        cmAlbumArtInsert.Size = New Size(115, 92)
        ' 
        ' cmiAlbumArtInsertBefore
        ' 
        cmiAlbumArtInsertBefore.Image = My.Resources.Resources.imageAdvanceLeft
        cmiAlbumArtInsertBefore.Name = "cmiAlbumArtInsertBefore"
        cmiAlbumArtInsertBefore.Size = New Size(114, 22)
        cmiAlbumArtInsertBefore.Text = "Before"
        cmiAlbumArtInsertBefore.ToolTipText = "LeftClick = Select From File" & vbCrLf & "ShiftLeftClick = Select From Online" & vbCrLf & "CtrlLeftClick = Paste From ClipBoard"
        ' 
        ' cmiAlbumArtInsertAfter
        ' 
        cmiAlbumArtInsertAfter.Image = My.Resources.Resources.imageAdvanceRight
        cmiAlbumArtInsertAfter.Name = "cmiAlbumArtInsertAfter"
        cmiAlbumArtInsertAfter.Size = New Size(114, 22)
        cmiAlbumArtInsertAfter.Text = "After"
        cmiAlbumArtInsertAfter.ToolTipText = "LeftClick = Select From File" & vbCrLf & "ShiftLeftClick = Select From Online" & vbCrLf & "CtrlLeftClick = Paste From ClipBoard"
        ' 
        ' cmiAlbumArtInsertFirst
        ' 
        cmiAlbumArtInsertFirst.Image = My.Resources.Resources.imageAdvanceFirst
        cmiAlbumArtInsertFirst.Name = "cmiAlbumArtInsertFirst"
        cmiAlbumArtInsertFirst.Size = New Size(114, 22)
        cmiAlbumArtInsertFirst.Text = "First"
        cmiAlbumArtInsertFirst.ToolTipText = "LeftClick = Select From File" & vbCrLf & "ShiftLeftClick = Select From Online" & vbCrLf & "CtrlLeftClick = Paste From ClipBoard"
        ' 
        ' cmiAlbumArtInsertLast
        ' 
        cmiAlbumArtInsertLast.Image = My.Resources.Resources.imageAdvanceLast
        cmiAlbumArtInsertLast.Name = "cmiAlbumArtInsertLast"
        cmiAlbumArtInsertLast.Size = New Size(114, 22)
        cmiAlbumArtInsertLast.Text = "Last"
        cmiAlbumArtInsertLast.ToolTipText = "Default" & vbCrLf & "LeftClick = Select From File" & vbCrLf & "ShiftLeftClick = Select From Online" & vbCrLf & "CtrlLeftClick = Paste From ClipBoard"
        ' 
        ' cmiAlbumArtSelect
        ' 
        cmiAlbumArtSelect.Image = My.Resources.Resources.imageOpenImage
        cmiAlbumArtSelect.Name = "cmiAlbumArtSelect"
        cmiAlbumArtSelect.Size = New Size(143, 22)
        cmiAlbumArtSelect.Text = "Select"
        cmiAlbumArtSelect.ToolTipText = "LeftClick = Select From File" & vbCrLf & "ShiftLeftClick = Select From Online" & vbCrLf & "CtrlLeftClick = Paste From ClipBoard"
        ' 
        ' cmiAlbumArtExport
        ' 
        cmiAlbumArtExport.Image = My.Resources.Resources.imageSave
        cmiAlbumArtExport.Name = "cmiAlbumArtExport"
        cmiAlbumArtExport.Size = New Size(143, 22)
        cmiAlbumArtExport.Text = "Export"
        cmiAlbumArtExport.ToolTipText = "LeftClick = Save To File" & vbCrLf & "ShiftLeftClick = Save As Windows Bitmap File" & vbCrLf & "CtrlLeftClick = Copy To ClipBoard"
        ' 
        ' tsSeparator1
        ' 
        tsSeparator1.Name = "tsSeparator1"
        tsSeparator1.Size = New Size(140, 6)
        ' 
        ' cmiAlbumArtMoveLeft
        ' 
        cmiAlbumArtMoveLeft.Image = My.Resources.Resources.imageAdvanceLeft
        cmiAlbumArtMoveLeft.Name = "cmiAlbumArtMoveLeft"
        cmiAlbumArtMoveLeft.Size = New Size(143, 22)
        cmiAlbumArtMoveLeft.Text = "Move Left"
        cmiAlbumArtMoveLeft.ToolTipText = "LeftClick = Move Left" & vbCrLf & "CtrlLeftClick = Move First"
        ' 
        ' cmiAlbumArtMoveRight
        ' 
        cmiAlbumArtMoveRight.Image = My.Resources.Resources.imageAdvanceRight
        cmiAlbumArtMoveRight.Name = "cmiAlbumArtMoveRight"
        cmiAlbumArtMoveRight.Size = New Size(143, 22)
        cmiAlbumArtMoveRight.Text = "Move Right"
        cmiAlbumArtMoveRight.ToolTipText = "LeftClick = Move Right" & vbCrLf & "CtrlLeftClick = Move Last"
        ' 
        ' tsSeparator2
        ' 
        tsSeparator2.Name = "tsSeparator2"
        tsSeparator2.Size = New Size(140, 6)
        ' 
        ' cmiAlbumArtDelete
        ' 
        cmiAlbumArtDelete.Image = My.Resources.Resources.imageDelete
        cmiAlbumArtDelete.Name = "cmiAlbumArtDelete"
        cmiAlbumArtDelete.Size = New Size(143, 22)
        cmiAlbumArtDelete.Text = "Delete"
        ' 
        ' picbxAlbumArt
        ' 
        picbxAlbumArt.ContextMenuStrip = cmAlbumArt
        picbxAlbumArt.Location = New Point(0, 0)
        picbxAlbumArt.Name = "picbxAlbumArt"
        picbxAlbumArt.Size = New Size(360, 229)
        picbxAlbumArt.TabIndex = 1001
        picbxAlbumArt.TabStop = False
        ' 
        ' txbxArtist
        ' 
        txbxArtist.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txbxArtist.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        txbxArtist.Location = New Point(12, 83)
        txbxArtist.Name = "txbxArtist"
        txbxArtist.ShortcutsEnabled = False
        txbxArtist.Size = New Size(238, 25)
        txbxArtist.TabIndex = 10
        ' 
        ' txbxAlbum
        ' 
        txbxAlbum.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txbxAlbum.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        txbxAlbum.Location = New Point(12, 167)
        txbxAlbum.Name = "txbxAlbum"
        txbxAlbum.ShortcutsEnabled = False
        txbxAlbum.Size = New Size(304, 25)
        txbxAlbum.TabIndex = 30
        ' 
        ' txbxAlbumArt
        ' 
        txbxAlbumArt.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txbxAlbumArt.Location = New Point(50, 251)
        txbxAlbumArt.Name = "txbxAlbumArt"
        txbxAlbumArt.ShortcutsEnabled = False
        txbxAlbumArt.Size = New Size(200, 25)
        txbxAlbumArt.TabIndex = 100
        ' 
        ' cobxAlbumArtType
        ' 
        cobxAlbumArtType.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        cobxAlbumArtType.DropDownStyle = ComboBoxStyle.DropDownList
        cobxAlbumArtType.DropDownWidth = 130
        cobxAlbumArtType.FormattingEnabled = True
        cobxAlbumArtType.ItemHeight = 17
        cobxAlbumArtType.Location = New Point(256, 251)
        cobxAlbumArtType.MaxDropDownItems = 7
        cobxAlbumArtType.Name = "cobxAlbumArtType"
        cobxAlbumArtType.Size = New Size(117, 25)
        cobxAlbumArtType.TabIndex = 110
        ' 
        ' txbxTitle
        ' 
        txbxTitle.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txbxTitle.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        txbxTitle.Location = New Point(12, 125)
        txbxTitle.Name = "txbxTitle"
        txbxTitle.ShortcutsEnabled = False
        txbxTitle.Size = New Size(238, 25)
        txbxTitle.TabIndex = 20
        ' 
        ' txbxYear
        ' 
        txbxYear.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        txbxYear.Location = New Point(322, 167)
        txbxYear.MaxLength = 4
        txbxYear.Name = "txbxYear"
        txbxYear.ShortcutsEnabled = False
        txbxYear.Size = New Size(50, 25)
        txbxYear.TabIndex = 35
        txbxYear.Text = "8888"
        txbxYear.TextAlign = HorizontalAlignment.Center
        ' 
        ' txbxTrack
        ' 
        txbxTrack.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        txbxTrack.Location = New Point(256, 125)
        txbxTrack.MaxLength = 2
        txbxTrack.Name = "txbxTrack"
        txbxTrack.ShortcutsEnabled = False
        txbxTrack.Size = New Size(27, 25)
        txbxTrack.TabIndex = 25
        txbxTrack.Text = "88"
        txbxTrack.TextAlign = HorizontalAlignment.Center
        ' 
        ' txbxComments
        ' 
        txbxComments.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txbxComments.Location = New Point(12, 209)
        txbxComments.Name = "txbxComments"
        txbxComments.ShortcutsEnabled = False
        txbxComments.Size = New Size(361, 25)
        txbxComments.TabIndex = 50
        ' 
        ' cobxGenre
        ' 
        cobxGenre.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        cobxGenre.DropDownStyle = ComboBoxStyle.DropDownList
        cobxGenre.DropDownWidth = 165
        cobxGenre.FlatStyle = FlatStyle.Flat
        cobxGenre.FormattingEnabled = True
        cobxGenre.ItemHeight = 17
        cobxGenre.Location = New Point(253, 83)
        cobxGenre.Name = "cobxGenre"
        cobxGenre.Size = New Size(125, 25)
        cobxGenre.Sorted = True
        cobxGenre.TabIndex = 15
        cobxGenre.TabStop = False
        ' 
        ' txbxLyrics
        ' 
        txbxLyrics.AcceptsReturn = True
        txbxLyrics.AcceptsTab = True
        txbxLyrics.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        txbxLyrics.BackColor = Color.Linen
        txbxLyrics.HideSelection = False
        txbxLyrics.Location = New Point(13, 277)
        txbxLyrics.Multiline = True
        txbxLyrics.Name = "txbxLyrics"
        txbxLyrics.ScrollBars = ScrollBars.Both
        txbxLyrics.ShortcutsEnabled = False
        txbxLyrics.Size = New Size(360, 229)
        txbxLyrics.TabIndex = 0
        txbxLyrics.TabStop = False
        txbxLyrics.WordWrap = False
        ' 
        ' btnLyrics
        ' 
        btnLyrics.CausesValidation = False
        btnLyrics.FlatAppearance.BorderColor = Color.Black
        btnLyrics.FlatStyle = FlatStyle.Flat
        btnLyrics.Location = New Point(13, 240)
        btnLyrics.Name = "btnLyrics"
        btnLyrics.Size = New Size(32, 36)
        btnLyrics.TabIndex = 95
        btnLyrics.TabStop = False
        ' 
        ' txbxDuration
        ' 
        txbxDuration.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        txbxDuration.Location = New Point(322, 125)
        txbxDuration.Name = "txbxDuration"
        txbxDuration.ReadOnly = True
        txbxDuration.Size = New Size(50, 25)
        txbxDuration.TabIndex = 28
        txbxDuration.TabStop = False
        txbxDuration.Text = "8:00:88"
        txbxDuration.TextAlign = HorizontalAlignment.Center
        ' 
        ' txbxTrackCount
        ' 
        txbxTrackCount.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        txbxTrackCount.Location = New Point(289, 125)
        txbxTrackCount.MaxLength = 2
        txbxTrackCount.Name = "txbxTrackCount"
        txbxTrackCount.ShortcutsEnabled = False
        txbxTrackCount.Size = New Size(27, 25)
        txbxTrackCount.TabIndex = 26
        txbxTrackCount.Text = "88"
        txbxTrackCount.TextAlign = HorizontalAlignment.Center
        ' 
        ' txbxGenre
        ' 
        txbxGenre.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        txbxGenre.Location = New Point(256, 83)
        txbxGenre.Name = "txbxGenre"
        txbxGenre.ShortcutsEnabled = False
        txbxGenre.Size = New Size(106, 25)
        txbxGenre.TabIndex = 15
        ' 
        ' panelAlbumArt
        ' 
        panelAlbumArt.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        panelAlbumArt.AutoScroll = True
        panelAlbumArt.CausesValidation = False
        panelAlbumArt.ContextMenuStrip = cmAlbumArt
        panelAlbumArt.Controls.Add(picbxAlbumArt)
        panelAlbumArt.Location = New Point(13, 277)
        panelAlbumArt.Name = "panelAlbumArt"
        panelAlbumArt.Size = New Size(360, 229)
        panelAlbumArt.TabIndex = 0
        ' 
        ' MenuMain
        ' 
        MenuMain.Items.AddRange(New ToolStripItem() {MIFile, MIEdit, MIView, MIPlay, MIAbout})
        MenuMain.Location = New Point(0, 0)
        MenuMain.Name = "MenuMain"
        MenuMain.Size = New Size(384, 24)
        MenuMain.TabIndex = 1015
        MenuMain.Text = "MenuStrip1"
        ' 
        ' MIFile
        ' 
        MIFile.DropDownItems.AddRange(New ToolStripItem() {MIOpenFile, MITrimFile, MIOpenLocation, MICloseFile, ToolStripSeparator1, MIExit})
        MIFile.ForeColor = Color.White
        MIFile.Image = My.Resources.Resources.imageOpen
        MIFile.Name = "MIFile"
        MIFile.Size = New Size(53, 20)
        MIFile.Text = "File"
        ' 
        ' MIOpenFile
        ' 
        MIOpenFile.Image = My.Resources.Resources.imageOpen
        MIOpenFile.Name = "MIOpenFile"
        MIOpenFile.Size = New Size(141, 22)
        MIOpenFile.Text = "Open File"
        ' 
        ' MITrimFile
        ' 
        MITrimFile.Image = My.Resources.Resources.imageSave
        MITrimFile.Name = "MITrimFile"
        MITrimFile.Size = New Size(141, 22)
        MITrimFile.Text = "Trim MP3"
        ' 
        ' MIOpenLocation
        ' 
        MIOpenLocation.Image = My.Resources.Resources.imageFolder
        MIOpenLocation.Name = "MIOpenLocation"
        MIOpenLocation.Size = New Size(141, 22)
        MIOpenLocation.Text = "Go To Folder"
        ' 
        ' MICloseFile
        ' 
        MICloseFile.Image = My.Resources.Resources.imageClose
        MICloseFile.Name = "MICloseFile"
        MICloseFile.Size = New Size(141, 22)
        MICloseFile.Text = "Close File"
        ' 
        ' ToolStripSeparator1
        ' 
        ToolStripSeparator1.Name = "ToolStripSeparator1"
        ToolStripSeparator1.Size = New Size(138, 6)
        ' 
        ' MIExit
        ' 
        MIExit.Image = My.Resources.Resources.imageClose
        MIExit.Name = "MIExit"
        MIExit.Size = New Size(141, 22)
        MIExit.Text = "Exit"
        MIExit.ToolTipText = "Ctrl+W"
        ' 
        ' MIEdit
        ' 
        MIEdit.BackColor = Color.Transparent
        MIEdit.DropDownItems.AddRange(New ToolStripItem() {MICopyTagBasic, MICopyTagArt, MICopyTagFull, MIPasteTag})
        MIEdit.ForeColor = Color.White
        MIEdit.Image = My.Resources.Resources.ImageEdit16
        MIEdit.Name = "MIEdit"
        MIEdit.Size = New Size(55, 20)
        MIEdit.Text = "Edit"
        ' 
        ' MICopyTagBasic
        ' 
        MICopyTagBasic.Image = My.Resources.Resources.ImageEditCopy16
        MICopyTagBasic.Name = "MICopyTagBasic"
        MICopyTagBasic.Size = New Size(154, 22)
        MICopyTagBasic.Text = "Copy Basic Tag"
        MICopyTagBasic.ToolTipText = "Copy Tag without Album Art or Lyrics"
        ' 
        ' MICopyTagArt
        ' 
        MICopyTagArt.Image = My.Resources.Resources.ImageEditCopy16
        MICopyTagArt.Name = "MICopyTagArt"
        MICopyTagArt.Size = New Size(154, 22)
        MICopyTagArt.Text = "Copy Art Only"
        MICopyTagArt.ToolTipText = "Copy ONLY Album Art"
        ' 
        ' MICopyTagFull
        ' 
        MICopyTagFull.Image = My.Resources.Resources.ImageEditCopy16
        MICopyTagFull.Name = "MICopyTagFull"
        MICopyTagFull.Size = New Size(154, 22)
        MICopyTagFull.Text = "Copy Full Tag"
        MICopyTagFull.ToolTipText = "Copy Tag WITH Album Art & Lyrics"
        ' 
        ' MIPasteTag
        ' 
        MIPasteTag.Image = My.Resources.Resources.ImageEditPaste16
        MIPasteTag.Name = "MIPasteTag"
        MIPasteTag.Size = New Size(154, 22)
        MIPasteTag.Text = "Paste Tag"
        ' 
        ' MIView
        ' 
        MIView.BackColor = Color.Transparent
        MIView.DropDownItems.AddRange(New ToolStripItem() {MISettings})
        MIView.ForeColor = Color.White
        MIView.Image = My.Resources.Resources.ImageView
        MIView.Name = "MIView"
        MIView.Size = New Size(60, 20)
        MIView.Text = "View"
        ' 
        ' MISettings
        ' 
        MISettings.Image = My.Resources.Resources.imageSettings
        MISettings.Name = "MISettings"
        MISettings.Size = New Size(180, 22)
        MISettings.Text = "Settings"
        ' 
        ' MIPlay
        ' 
        MIPlay.ForeColor = Color.White
        MIPlay.Image = My.Resources.Resources.imageSound
        MIPlay.Name = "MIPlay"
        MIPlay.Size = New Size(57, 20)
        MIPlay.Text = "Play"
        ' 
        ' MIAbout
        ' 
        MIAbout.DropDownItems.AddRange(New ToolStripItem() {MIHelp, MILog})
        MIAbout.ForeColor = Color.White
        MIAbout.Image = My.Resources.Resources.imageInfo
        MIAbout.Name = "MIAbout"
        MIAbout.Size = New Size(68, 20)
        MIAbout.Text = "About"
        ' 
        ' MIHelp
        ' 
        MIHelp.Image = My.Resources.Resources.imageInfo
        MIHelp.Name = "MIHelp"
        MIHelp.Size = New Size(180, 22)
        MIHelp.Text = "Help && About"
        ' 
        ' MILog
        ' 
        MILog.Image = My.Resources.Resources.imageLog
        MILog.Name = "MILog"
        MILog.Size = New Size(180, 22)
        MILog.Text = "Log"
        ' 
        ' lblFileInfo
        ' 
        lblFileInfo.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        lblFileInfo.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold Or FontStyle.Underline, GraphicsUnit.Point, CByte(0))
        lblFileInfo.Location = New Point(12, 38)
        lblFileInfo.Name = "lblFileInfo"
        lblFileInfo.Size = New Size(360, 23)
        lblFileInfo.TabIndex = 1016
        lblFileInfo.Text = "File Info"
        lblFileInfo.TextAlign = ContentAlignment.TopCenter
        ' 
        ' lblArtist
        ' 
        lblArtist.Location = New Point(11, 65)
        lblArtist.Name = "lblArtist"
        lblArtist.Size = New Size(41, 20)
        lblArtist.TabIndex = 1017
        lblArtist.Text = "Artist"
        lblArtist.TextAlign = ContentAlignment.BottomLeft
        ' 
        ' lblGenre
        ' 
        lblGenre.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        lblGenre.Location = New Point(254, 65)
        lblGenre.Name = "lblGenre"
        lblGenre.Size = New Size(43, 20)
        lblGenre.TabIndex = 1018
        lblGenre.Text = "Genre"
        lblGenre.TextAlign = ContentAlignment.BottomLeft
        ' 
        ' lblTitle
        ' 
        lblTitle.Location = New Point(11, 107)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(42, 20)
        lblTitle.TabIndex = 1019
        lblTitle.Text = "Title"
        lblTitle.TextAlign = ContentAlignment.BottomLeft
        ' 
        ' lblAlbum
        ' 
        lblAlbum.Location = New Point(11, 149)
        lblAlbum.Name = "lblAlbum"
        lblAlbum.Size = New Size(50, 20)
        lblAlbum.TabIndex = 1020
        lblAlbum.Text = "Album"
        lblAlbum.TextAlign = ContentAlignment.BottomLeft
        ' 
        ' lblComments
        ' 
        lblComments.Location = New Point(11, 191)
        lblComments.Name = "lblComments"
        lblComments.Size = New Size(73, 20)
        lblComments.TabIndex = 1021
        lblComments.Text = "Comments"
        lblComments.TextAlign = ContentAlignment.BottomLeft
        ' 
        ' lblAlbumArt
        ' 
        lblAlbumArt.Location = New Point(49, 233)
        lblAlbumArt.Name = "lblAlbumArt"
        lblAlbumArt.Size = New Size(88, 20)
        lblAlbumArt.TabIndex = 1022
        lblAlbumArt.Text = "Art"
        lblAlbumArt.TextAlign = ContentAlignment.BottomLeft
        ' 
        ' lblTrack
        ' 
        lblTrack.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        lblTrack.Location = New Point(258, 107)
        lblTrack.Name = "lblTrack"
        lblTrack.Size = New Size(59, 20)
        lblTrack.TabIndex = 1023
        lblTrack.Text = "Track"
        lblTrack.TextAlign = ContentAlignment.BottomCenter
        ' 
        ' lblTrackSeparator
        ' 
        lblTrackSeparator.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        lblTrackSeparator.Location = New Point(277, 126)
        lblTrackSeparator.Name = "lblTrackSeparator"
        lblTrackSeparator.Size = New Size(20, 20)
        lblTrackSeparator.TabIndex = 1024
        lblTrackSeparator.Text = "/"
        lblTrackSeparator.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblDuration
        ' 
        lblDuration.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        lblDuration.Location = New Point(319, 107)
        lblDuration.Name = "lblDuration"
        lblDuration.Size = New Size(58, 20)
        lblDuration.TabIndex = 1025
        lblDuration.Text = "Duration"
        lblDuration.TextAlign = ContentAlignment.BottomCenter
        ' 
        ' lblYear
        ' 
        lblYear.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        lblYear.Location = New Point(324, 149)
        lblYear.Name = "lblYear"
        lblYear.Size = New Size(50, 20)
        lblYear.TabIndex = 1026
        lblYear.Text = "Year"
        lblYear.TextAlign = ContentAlignment.BottomCenter
        ' 
        ' MainForm
        ' 
        AllowDrop = True
        AutoScaleDimensions = New SizeF(7F, 17F)
        AutoScaleMode = AutoScaleMode.Font
        AutoSizeMode = AutoSizeMode.GrowAndShrink
        AutoValidate = AutoValidate.EnableAllowFocusChange
        ClientSize = New Size(384, 561)
        Controls.Add(lblFileInfo)
        Controls.Add(MenuMain)
        Controls.Add(btnLyrics)
        Controls.Add(txbxLyrics)
        Controls.Add(btnError)
        Controls.Add(btnSave)
        Controls.Add(btnRestore)
        Controls.Add(txbxGenre)
        Controls.Add(txbxArtist)
        Controls.Add(txbxYear)
        Controls.Add(txbxTrack)
        Controls.Add(txbxTitle)
        Controls.Add(txbxComments)
        Controls.Add(txbxAlbum)
        Controls.Add(txbxTrackCount)
        Controls.Add(txbxDuration)
        Controls.Add(btnArtistInsert)
        Controls.Add(btnArtistDelete)
        Controls.Add(btnArtistRight)
        Controls.Add(btnArtistLeft)
        Controls.Add(panelAlbumArt)
        Controls.Add(cobxGenre)
        Controls.Add(txbxAlbumArt)
        Controls.Add(btnAlbumArtLeft)
        Controls.Add(btnAlbumArtRight)
        Controls.Add(btnAlbumArt)
        Controls.Add(cobxAlbumArtType)
        Controls.Add(lblArtist)
        Controls.Add(lblGenre)
        Controls.Add(lblTitle)
        Controls.Add(lblAlbum)
        Controls.Add(lblComments)
        Controls.Add(lblAlbumArt)
        Controls.Add(lblTrack)
        Controls.Add(lblTrackSeparator)
        Controls.Add(lblDuration)
        Controls.Add(lblYear)
        Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        KeyPreview = True
        MainMenuStrip = MenuMain
        Margin = New Padding(3, 4, 3, 4)
        MinimumSize = New Size(400, 600)
        Name = "MainForm"
        SizeGripStyle = SizeGripStyle.Show
        StartPosition = FormStartPosition.Manual
        cmAlbumArt.ResumeLayout(False)
        cmAlbumArtInsert.ResumeLayout(False)
        CType(picbxAlbumArt, ComponentModel.ISupportInitialize).EndInit()
        panelAlbumArt.ResumeLayout(False)
        MenuMain.ResumeLayout(False)
        MenuMain.PerformLayout()
        ResumeLayout(False)
        PerformLayout()

    End Sub
    Private WithEvents picbxAlbumArt As System.Windows.Forms.PictureBox
    Private WithEvents txbxAlbumArt As System.Windows.Forms.TextBox
    Private WithEvents cobxAlbumArtType As System.Windows.Forms.ComboBox
    Private WithEvents txbxYear As System.Windows.Forms.TextBox
    Private WithEvents txbxComments As System.Windows.Forms.TextBox
    Private WithEvents cobxGenre As System.Windows.Forms.ComboBox
    Private WithEvents txbxLyrics As System.Windows.Forms.TextBox
    Private WithEvents txbxDuration As System.Windows.Forms.TextBox
    Private WithEvents txbxTrackCount As System.Windows.Forms.TextBox
    Private WithEvents txbxTrack As System.Windows.Forms.TextBox
    Private WithEvents txbxGenre As System.Windows.Forms.TextBox
    Private WithEvents txbxTitle As System.Windows.Forms.TextBox
    Private tsSeparator1 As System.Windows.Forms.ToolStripSeparator
    Private tsSeparator2 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents btnArtistDelete As System.Windows.Forms.Button
    Private WithEvents btnArtistInsert As System.Windows.Forms.Button
    Private WithEvents btnArtistRight As System.Windows.Forms.Button
    Private WithEvents btnArtistLeft As System.Windows.Forms.Button
    Private WithEvents cmiAlbumArtExport As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents cmiAlbumArtInsertLast As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents cmiAlbumArtInsertAfter As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents cmiAlbumArtInsertFirst As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents cmiAlbumArtInsertBefore As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents cmAlbumArtInsert As System.Windows.Forms.ContextMenuStrip
    Private WithEvents btnAlbumArtRight As System.Windows.Forms.Button
    Private WithEvents btnAlbumArtLeft As System.Windows.Forms.Button
    Private WithEvents cmiAlbumArtMoveLeft As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents cmiAlbumArtMoveRight As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents cmiAlbumArtSelect As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents btnAlbumArt As System.Windows.Forms.Button
    Private WithEvents cmiAlbumArtDelete As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents cmiAlbumArtInsert As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents cmAlbumArt As System.Windows.Forms.ContextMenuStrip
    Private WithEvents panelAlbumArt As System.Windows.Forms.Panel
    Friend WithEvents btnError As System.Windows.Forms.Button
    Private WithEvents btnRestore As System.Windows.Forms.Button
    Private WithEvents btnLyrics As System.Windows.Forms.Button
    Private WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents tipInfo As System.Windows.Forms.ToolTip
    Friend WithEvents MenuMain As MenuStrip
    Friend WithEvents MIFile As ToolStripMenuItem
    Friend WithEvents MIOpenFile As ToolStripMenuItem
    Friend WithEvents MIExit As ToolStripMenuItem
    Friend WithEvents MIAbout As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents MIHelp As ToolStripMenuItem
    Friend WithEvents MILog As ToolStripMenuItem
    Friend WithEvents MISettings As ToolStripMenuItem
    Friend WithEvents MICloseFile As ToolStripMenuItem
    Friend WithEvents MIPlay As ToolStripMenuItem
    Friend WithEvents MIOpenLocation As ToolStripMenuItem
    Friend WithEvents lblFileInfo As My.Components.LabelCSY
    Friend WithEvents lblArtist As My.Components.LabelCSY
    Friend WithEvents lblGenre As My.Components.LabelCSY
    Friend WithEvents lblTitle As My.Components.LabelCSY
    Friend WithEvents lblAlbum As My.Components.LabelCSY
    Friend WithEvents lblComments As My.Components.LabelCSY
    Friend WithEvents lblAlbumArt As My.Components.LabelCSY
    Friend WithEvents lblTrack As My.Components.LabelCSY
    Friend WithEvents lblTrackSeparator As My.Components.LabelCSY
    Friend WithEvents lblDuration As My.Components.LabelCSY
    Friend WithEvents lblYear As My.Components.LabelCSY
    Friend WithEvents MIEdit As ToolStripMenuItem
    Friend WithEvents MICopyTagBasic As ToolStripMenuItem
    Friend WithEvents MICopyTagFull As ToolStripMenuItem
    Friend WithEvents MIPasteTag As ToolStripMenuItem
    Friend WithEvents txbxAlbum As TextBox
    Friend WithEvents txbxArtist As TextBox
    Friend WithEvents MICopyTagArt As ToolStripMenuItem
    Friend WithEvents MITrimFile As ToolStripMenuItem
    Friend WithEvents MIView As ToolStripMenuItem
End Class