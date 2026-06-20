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
        btnSave = New Button()
        btnAlbumArtRight = New Button()
        cmArtRight = New ContextMenuStrip(components)
        cmiArtNext = New ToolStripMenuItem()
        ToolStripSeparator5 = New ToolStripSeparator()
        cmiArtMoveRight = New ToolStripMenuItem()
        cmiArtMoveLast = New ToolStripMenuItem()
        btnAlbumArtLeft = New Button()
        cmArtLeft = New ContextMenuStrip(components)
        cmiArtPrevious = New ToolStripMenuItem()
        ToolStripSeparator4 = New ToolStripSeparator()
        cmiArtMoveLeft = New ToolStripMenuItem()
        cmiArtMoveFirst = New ToolStripMenuItem()
        btnRestore = New Button()
        btnArtistLeft = New Button()
        cmArtistLeft = New ContextMenuStrip(components)
        cmiArtistPrevious = New ToolStripMenuItem()
        ToolStripSeparator2 = New ToolStripSeparator()
        cmiArtistMoveLeft = New ToolStripMenuItem()
        cmiArtistMoveFirst = New ToolStripMenuItem()
        btnArtistRight = New Button()
        cmArtistRight = New ContextMenuStrip(components)
        cmiArtistNext = New ToolStripMenuItem()
        ToolStripSeparator3 = New ToolStripSeparator()
        cmiArtistMoveRight = New ToolStripMenuItem()
        cmiArtistMoveLast = New ToolStripMenuItem()
        btnArtistInsert = New Button()
        cmNewArtist = New ContextMenuStrip(components)
        cmiArtistInsert = New ToolStripMenuItem()
        cmiArtistInsertFromClipboard = New ToolStripMenuItem()
        btnArtistDelete = New Button()
        cmAlbumArt = New ContextMenuStrip(components)
        cmiAlbumArtSelect = New ToolStripMenuItem()
        cmImageSource = New ContextMenuStrip(components)
        cmiSelectFromFile = New ToolStripMenuItem()
        cmiSelectFromOnline = New ToolStripMenuItem()
        cmiPasteFromClipboard = New ToolStripMenuItem()
        cmiAlbumArtInsertLast = New ToolStripMenuItem()
        cmiAlbumArtInsert = New ToolStripMenuItem()
        cmAlbumArtInsert = New ContextMenuStrip(components)
        cmiAlbumArtInsertBefore = New ToolStripMenuItem()
        cmiAlbumArtInsertFirst = New ToolStripMenuItem()
        cmiAlbumArtInsertAfter = New ToolStripMenuItem()
        cmiAlbumArtExport = New ToolStripMenuItem()
        cmExport = New ContextMenuStrip(components)
        cmiExportToFile = New ToolStripMenuItem()
        cmiExportToBitmap = New ToolStripMenuItem()
        cmiExportToClipboard = New ToolStripMenuItem()
        tsSeparator1 = New ToolStripSeparator()
        cmiAlbumArtMoveLeft = New ToolStripMenuItem()
        cmiAlbumArtMoveFirst = New ToolStripMenuItem()
        cmiAlbumArtMoveRight = New ToolStripMenuItem()
        cmiAlbumArtMoveLast = New ToolStripMenuItem()
        tsSeparator2 = New ToolStripSeparator()
        cmiAlbumArtDelete = New ToolStripMenuItem()
        btnAlbumArt = New Button()
        picbxAlbumArt = New PictureBox()
        txbxArtist = New TextBox()
        txbxAlbum = New TextBox()
        txbxAlbumArt = New TextBox()
        txbxTitle = New TextBox()
        txbxYear = New TextBox()
        txbxTrack = New TextBox()
        txbxComments = New TextBox()
        txbxLyrics = New TextBox()
        btnLyrics = New Button()
        txbxDuration = New TextBox()
        txbxTrackCount = New TextBox()
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
        ToolStripMenuItem1 = New ToolStripMenuItem()
        lblFileInfo = New Skye.UI.Label()
        lblArtist = New Skye.UI.Label()
        lblGenre = New Skye.UI.Label()
        lblTitle = New Skye.UI.Label()
        lblAlbum = New Skye.UI.Label()
        lblComments = New Skye.UI.Label()
        lblAlbumArt = New Skye.UI.Label()
        lblTrack = New Skye.UI.Label()
        lblTrackSeparator = New Skye.UI.Label()
        lblDuration = New Skye.UI.Label()
        lblYear = New Skye.UI.Label()
        tipInfo = New Skye.UI.ToolTipEX(components)
        CoBoxGenre = New Skye.UI.ComboBox()
        cobxAlbumArtType = New Skye.UI.ComboBox()
        cmArtRight.SuspendLayout()
        cmArtLeft.SuspendLayout()
        cmArtistLeft.SuspendLayout()
        cmArtistRight.SuspendLayout()
        cmNewArtist.SuspendLayout()
        cmAlbumArt.SuspendLayout()
        cmImageSource.SuspendLayout()
        cmAlbumArtInsert.SuspendLayout()
        cmExport.SuspendLayout()
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
        btnError.Image = My.Resources.Resources.ImageError32
        tipInfo.SetImage(btnError, My.Resources.Resources.ImageError32)
        btnError.Location = New Point(417, 640)
        btnError.Margin = New Padding(4)
        btnError.Name = "btnError"
        btnError.Size = New Size(64, 64)
        btnError.TabIndex = 25
        btnError.TabStop = False
        tipInfo.SetText(btnError, "An Error Has Occurred" & vbCrLf & "Click To Clear Error" & vbCrLf & "RightClick = View Log")
        btnError.Visible = False
        ' 
        ' btnSave
        ' 
        btnSave.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnSave.FlatAppearance.BorderColor = SystemColors.Info
        btnSave.FlatAppearance.BorderSize = 2
        btnSave.FlatAppearance.MouseDownBackColor = Color.GhostWhite
        btnSave.FlatAppearance.MouseOverBackColor = SystemColors.Info
        btnSave.Image = My.Resources.Resources.ImageSave64
        tipInfo.SetImage(btnSave, My.Resources.Resources.ImageSave64)
        btnSave.ImageAlign = ContentAlignment.MiddleLeft
        btnSave.Location = New Point(15, 640)
        btnSave.Margin = New Padding(4)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(128, 64)
        btnSave.TabIndex = 1000
        tipInfo.SetText(btnSave, "Save Tag To File")
        btnSave.Text = "Save"
        btnSave.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' btnAlbumArtRight
        ' 
        btnAlbumArtRight.CausesValidation = False
        btnAlbumArtRight.ContextMenuStrip = cmArtRight
        btnAlbumArtRight.FlatAppearance.BorderColor = SystemColors.ControlDark
        btnAlbumArtRight.FlatAppearance.BorderSize = 0
        btnAlbumArtRight.FlatAppearance.MouseDownBackColor = Color.Transparent
        btnAlbumArtRight.FlatAppearance.MouseOverBackColor = Color.Transparent
        btnAlbumArtRight.Image = My.Resources.Resources.imageAdvanceRight
        tipInfo.SetImage(btnAlbumArtRight, My.Resources.Resources.imageAdvanceRight)
        btnAlbumArtRight.Location = New Point(296, 288)
        btnAlbumArtRight.Margin = New Padding(4)
        btnAlbumArtRight.Name = "btnAlbumArtRight"
        btnAlbumArtRight.Size = New Size(24, 24)
        btnAlbumArtRight.TabIndex = 0
        btnAlbumArtRight.TabStop = False
        tipInfo.SetText(btnAlbumArtRight, "LeftClick = Next Image")
        btnAlbumArtRight.UseMnemonic = False
        btnAlbumArtRight.UseVisualStyleBackColor = False
        ' 
        ' cmArtRight
        ' 
        cmArtRight.Font = New Font("Segoe UI", 12F)
        tipInfo.SetImage(cmArtRight, Nothing)
        cmArtRight.Items.AddRange(New ToolStripItem() {cmiArtNext, ToolStripSeparator5, cmiArtMoveRight, cmiArtMoveLast})
        cmArtRight.Name = "cmArtRight"
        cmArtRight.Size = New Size(208, 88)
        tipInfo.SetText(cmArtRight, Nothing)
        ' 
        ' cmiArtNext
        ' 
        cmiArtNext.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        cmiArtNext.Image = My.Resources.Resources.imageAdvanceRight
        cmiArtNext.Name = "cmiArtNext"
        cmiArtNext.Size = New Size(207, 26)
        cmiArtNext.Text = "Next Image"
        ' 
        ' ToolStripSeparator5
        ' 
        ToolStripSeparator5.Name = "ToolStripSeparator5"
        ToolStripSeparator5.Size = New Size(204, 6)
        ' 
        ' cmiArtMoveRight
        ' 
        cmiArtMoveRight.Image = My.Resources.Resources.imageAdvanceRight
        cmiArtMoveRight.Name = "cmiArtMoveRight"
        cmiArtMoveRight.Size = New Size(207, 26)
        cmiArtMoveRight.Text = "Move Image Right"
        ' 
        ' cmiArtMoveLast
        ' 
        cmiArtMoveLast.Image = My.Resources.Resources.imageAdvanceLast
        cmiArtMoveLast.Name = "cmiArtMoveLast"
        cmiArtMoveLast.Size = New Size(207, 26)
        cmiArtMoveLast.Text = "Move Image Last"
        ' 
        ' btnAlbumArtLeft
        ' 
        btnAlbumArtLeft.CausesValidation = False
        btnAlbumArtLeft.ContextMenuStrip = cmArtLeft
        btnAlbumArtLeft.FlatAppearance.BorderColor = SystemColors.ControlDark
        btnAlbumArtLeft.FlatAppearance.BorderSize = 0
        btnAlbumArtLeft.FlatAppearance.MouseDownBackColor = Color.Transparent
        btnAlbumArtLeft.FlatAppearance.MouseOverBackColor = Color.Transparent
        btnAlbumArtLeft.Image = My.Resources.Resources.imageAdvanceLeft
        tipInfo.SetImage(btnAlbumArtLeft, My.Resources.Resources.imageAdvanceLeft)
        btnAlbumArtLeft.Location = New Point(274, 288)
        btnAlbumArtLeft.Margin = New Padding(4)
        btnAlbumArtLeft.Name = "btnAlbumArtLeft"
        btnAlbumArtLeft.Size = New Size(24, 24)
        btnAlbumArtLeft.TabIndex = 0
        btnAlbumArtLeft.TabStop = False
        tipInfo.SetText(btnAlbumArtLeft, "LeftClick = Previous Image")
        btnAlbumArtLeft.UseMnemonic = False
        btnAlbumArtLeft.UseVisualStyleBackColor = False
        ' 
        ' cmArtLeft
        ' 
        cmArtLeft.Font = New Font("Segoe UI", 12F)
        tipInfo.SetImage(cmArtLeft, Nothing)
        cmArtLeft.Items.AddRange(New ToolStripItem() {cmiArtPrevious, ToolStripSeparator4, cmiArtMoveLeft, cmiArtMoveFirst})
        cmArtLeft.Name = "cmArtLeft"
        cmArtLeft.Size = New Size(201, 88)
        tipInfo.SetText(cmArtLeft, Nothing)
        ' 
        ' cmiArtPrevious
        ' 
        cmiArtPrevious.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        cmiArtPrevious.Image = My.Resources.Resources.imageAdvanceLeft
        cmiArtPrevious.Name = "cmiArtPrevious"
        cmiArtPrevious.Size = New Size(200, 26)
        cmiArtPrevious.Text = "Previous Image"
        ' 
        ' ToolStripSeparator4
        ' 
        ToolStripSeparator4.Name = "ToolStripSeparator4"
        ToolStripSeparator4.Size = New Size(197, 6)
        ' 
        ' cmiArtMoveLeft
        ' 
        cmiArtMoveLeft.Image = My.Resources.Resources.imageAdvanceLeft
        cmiArtMoveLeft.Name = "cmiArtMoveLeft"
        cmiArtMoveLeft.Size = New Size(200, 26)
        cmiArtMoveLeft.Text = "Move Image Left"
        ' 
        ' cmiArtMoveFirst
        ' 
        cmiArtMoveFirst.Image = My.Resources.Resources.imageAdvanceFirst
        cmiArtMoveFirst.Name = "cmiArtMoveFirst"
        cmiArtMoveFirst.Size = New Size(200, 26)
        cmiArtMoveFirst.Text = "Move Image First"
        ' 
        ' btnRestore
        ' 
        btnRestore.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnRestore.Enabled = False
        btnRestore.FlatAppearance.BorderColor = SystemColors.Info
        btnRestore.FlatAppearance.BorderSize = 2
        btnRestore.FlatAppearance.MouseDownBackColor = Color.GhostWhite
        btnRestore.FlatAppearance.MouseOverBackColor = SystemColors.Info
        btnRestore.Image = My.Resources.Resources.ImageRestore32
        tipInfo.SetImage(btnRestore, My.Resources.Resources.ImageRestore32)
        btnRestore.Location = New Point(151, 640)
        btnRestore.Margin = New Padding(4)
        btnRestore.Name = "btnRestore"
        btnRestore.Size = New Size(64, 64)
        btnRestore.TabIndex = 1005
        tipInfo.SetText(btnRestore, "Restore Original Tag")
        btnRestore.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' btnArtistLeft
        ' 
        btnArtistLeft.CausesValidation = False
        btnArtistLeft.ContextMenuStrip = cmArtistLeft
        btnArtistLeft.FlatAppearance.BorderColor = SystemColors.ControlDark
        btnArtistLeft.FlatAppearance.BorderSize = 0
        btnArtistLeft.FlatAppearance.MouseDownBackColor = Color.Transparent
        btnArtistLeft.FlatAppearance.MouseOverBackColor = Color.Transparent
        btnArtistLeft.Image = My.Resources.Resources.imageAdvanceLeft
        tipInfo.SetImage(btnArtistLeft, My.Resources.Resources.imageAdvanceLeft)
        btnArtistLeft.Location = New Point(276, 80)
        btnArtistLeft.Margin = New Padding(4)
        btnArtistLeft.Name = "btnArtistLeft"
        btnArtistLeft.Size = New Size(24, 24)
        btnArtistLeft.TabIndex = 1012
        btnArtistLeft.TabStop = False
        tipInfo.SetText(btnArtistLeft, "LeftClick = Previous Artist")
        btnArtistLeft.UseMnemonic = False
        btnArtistLeft.UseVisualStyleBackColor = False
        ' 
        ' cmArtistLeft
        ' 
        cmArtistLeft.Font = New Font("Segoe UI", 12F)
        tipInfo.SetImage(cmArtistLeft, Nothing)
        cmArtistLeft.Items.AddRange(New ToolStripItem() {cmiArtistPrevious, ToolStripSeparator2, cmiArtistMoveLeft, cmiArtistMoveFirst})
        cmArtistLeft.Name = "ContextMenuStrip1"
        cmArtistLeft.Size = New Size(195, 88)
        tipInfo.SetText(cmArtistLeft, Nothing)
        ' 
        ' cmiArtistPrevious
        ' 
        cmiArtistPrevious.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        cmiArtistPrevious.Image = My.Resources.Resources.imageAdvanceLeft
        cmiArtistPrevious.Name = "cmiArtistPrevious"
        cmiArtistPrevious.Size = New Size(194, 26)
        cmiArtistPrevious.Text = "Previous Artist"
        ' 
        ' ToolStripSeparator2
        ' 
        ToolStripSeparator2.Name = "ToolStripSeparator2"
        ToolStripSeparator2.Size = New Size(191, 6)
        ' 
        ' cmiArtistMoveLeft
        ' 
        cmiArtistMoveLeft.Image = My.Resources.Resources.imageAdvanceLeft
        cmiArtistMoveLeft.Name = "cmiArtistMoveLeft"
        cmiArtistMoveLeft.Size = New Size(194, 26)
        cmiArtistMoveLeft.Text = "Move Artist Left"
        ' 
        ' cmiArtistMoveFirst
        ' 
        cmiArtistMoveFirst.Image = My.Resources.Resources.imageAdvanceFirst
        cmiArtistMoveFirst.Name = "cmiArtistMoveFirst"
        cmiArtistMoveFirst.Size = New Size(194, 26)
        cmiArtistMoveFirst.Text = "Move Artist First"
        ' 
        ' btnArtistRight
        ' 
        btnArtistRight.CausesValidation = False
        btnArtistRight.ContextMenuStrip = cmArtistRight
        btnArtistRight.FlatAppearance.BorderColor = SystemColors.ControlDark
        btnArtistRight.FlatAppearance.BorderSize = 0
        btnArtistRight.FlatAppearance.MouseDownBackColor = Color.Transparent
        btnArtistRight.FlatAppearance.MouseOverBackColor = Color.Transparent
        btnArtistRight.Image = My.Resources.Resources.imageAdvanceRight
        tipInfo.SetImage(btnArtistRight, My.Resources.Resources.imageAdvanceRight)
        btnArtistRight.Location = New Point(297, 80)
        btnArtistRight.Margin = New Padding(4)
        btnArtistRight.Name = "btnArtistRight"
        btnArtistRight.Size = New Size(24, 24)
        btnArtistRight.TabIndex = 1011
        btnArtistRight.TabStop = False
        tipInfo.SetText(btnArtistRight, "LeftClick = Next Artist")
        btnArtistRight.UseMnemonic = False
        btnArtistRight.UseVisualStyleBackColor = False
        ' 
        ' cmArtistRight
        ' 
        cmArtistRight.Font = New Font("Segoe UI", 12F)
        tipInfo.SetImage(cmArtistRight, Nothing)
        cmArtistRight.Items.AddRange(New ToolStripItem() {cmiArtistNext, ToolStripSeparator3, cmiArtistMoveRight, cmiArtistMoveLast})
        cmArtistRight.Name = "cmArtistRight"
        cmArtistRight.Size = New Size(202, 88)
        tipInfo.SetText(cmArtistRight, Nothing)
        ' 
        ' cmiArtistNext
        ' 
        cmiArtistNext.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        cmiArtistNext.Image = My.Resources.Resources.imageAdvanceRight
        cmiArtistNext.Name = "cmiArtistNext"
        cmiArtistNext.Size = New Size(201, 26)
        cmiArtistNext.Text = "Next Artist"
        ' 
        ' ToolStripSeparator3
        ' 
        ToolStripSeparator3.Name = "ToolStripSeparator3"
        ToolStripSeparator3.Size = New Size(198, 6)
        ' 
        ' cmiArtistMoveRight
        ' 
        cmiArtistMoveRight.Image = My.Resources.Resources.imageAdvanceRight
        cmiArtistMoveRight.Name = "cmiArtistMoveRight"
        cmiArtistMoveRight.Size = New Size(201, 26)
        cmiArtistMoveRight.Text = "Move Artist Right"
        ' 
        ' cmiArtistMoveLast
        ' 
        cmiArtistMoveLast.Image = My.Resources.Resources.imageAdvanceLast
        cmiArtistMoveLast.Name = "cmiArtistMoveLast"
        cmiArtistMoveLast.Size = New Size(201, 26)
        cmiArtistMoveLast.Text = "Move Artist Last"
        ' 
        ' btnArtistInsert
        ' 
        btnArtistInsert.AllowDrop = True
        btnArtistInsert.CausesValidation = False
        btnArtistInsert.ContextMenuStrip = cmNewArtist
        btnArtistInsert.FlatAppearance.BorderColor = SystemColors.ControlDark
        btnArtistInsert.FlatAppearance.BorderSize = 0
        btnArtistInsert.FlatAppearance.MouseDownBackColor = Color.Transparent
        btnArtistInsert.FlatAppearance.MouseOverBackColor = Color.Transparent
        btnArtistInsert.Image = My.Resources.Resources.imageNew
        tipInfo.SetImage(btnArtistInsert, My.Resources.Resources.imageNew)
        btnArtistInsert.Location = New Point(149, 80)
        btnArtistInsert.Margin = New Padding(4)
        btnArtistInsert.Name = "btnArtistInsert"
        btnArtistInsert.Size = New Size(24, 24)
        btnArtistInsert.TabIndex = 1014
        btnArtistInsert.TabStop = False
        tipInfo.SetText(btnArtistInsert, "LeftClick = Add New Artist")
        btnArtistInsert.UseMnemonic = False
        btnArtistInsert.UseVisualStyleBackColor = False
        ' 
        ' cmNewArtist
        ' 
        cmNewArtist.Font = New Font("Segoe UI", 12F)
        tipInfo.SetImage(cmNewArtist, Nothing)
        cmNewArtist.Items.AddRange(New ToolStripItem() {cmiArtistInsert, cmiArtistInsertFromClipboard})
        cmNewArtist.Name = "ContextMenuStrip1"
        cmNewArtist.Size = New Size(222, 56)
        tipInfo.SetText(cmNewArtist, Nothing)
        ' 
        ' cmiArtistInsert
        ' 
        cmiArtistInsert.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        cmiArtistInsert.Image = My.Resources.Resources.imageNew
        cmiArtistInsert.Name = "cmiArtistInsert"
        cmiArtistInsert.Size = New Size(221, 26)
        cmiArtistInsert.Text = "Add New Artist"
        ' 
        ' cmiArtistInsertFromClipboard
        ' 
        cmiArtistInsertFromClipboard.Image = My.Resources.Resources.imageNew
        cmiArtistInsertFromClipboard.Name = "cmiArtistInsertFromClipboard"
        cmiArtistInsertFromClipboard.Size = New Size(221, 26)
        cmiArtistInsertFromClipboard.Text = "Add From Clipboard"
        ' 
        ' btnArtistDelete
        ' 
        btnArtistDelete.CausesValidation = False
        btnArtistDelete.FlatAppearance.BorderColor = SystemColors.ControlDark
        btnArtistDelete.FlatAppearance.BorderSize = 0
        btnArtistDelete.FlatAppearance.MouseDownBackColor = Color.Transparent
        btnArtistDelete.FlatAppearance.MouseOverBackColor = Color.Transparent
        btnArtistDelete.Image = My.Resources.Resources.imageDelete
        tipInfo.SetImage(btnArtistDelete, My.Resources.Resources.imageDelete)
        btnArtistDelete.Location = New Point(180, 80)
        btnArtistDelete.Margin = New Padding(4)
        btnArtistDelete.Name = "btnArtistDelete"
        btnArtistDelete.Size = New Size(24, 24)
        btnArtistDelete.TabIndex = 1013
        btnArtistDelete.TabStop = False
        tipInfo.SetText(btnArtistDelete, "LeftClick = Remove This Artist")
        btnArtistDelete.UseMnemonic = False
        btnArtistDelete.UseVisualStyleBackColor = False
        ' 
        ' cmAlbumArt
        ' 
        cmAlbumArt.Font = New Font("Segoe UI", 12F)
        tipInfo.SetImage(cmAlbumArt, Nothing)
        cmAlbumArt.Items.AddRange(New ToolStripItem() {cmiAlbumArtSelect, cmiAlbumArtInsert, cmiAlbumArtExport, tsSeparator1, cmiAlbumArtMoveLeft, cmiAlbumArtMoveFirst, cmiAlbumArtMoveRight, cmiAlbumArtMoveLast, tsSeparator2, cmiAlbumArtDelete})
        cmAlbumArt.Name = "cmAlbumArt"
        cmAlbumArt.Size = New Size(208, 224)
        tipInfo.SetText(cmAlbumArt, Nothing)
        ' 
        ' cmiAlbumArtSelect
        ' 
        cmiAlbumArtSelect.DropDown = cmImageSource
        cmiAlbumArtSelect.Image = My.Resources.Resources.imageOpenImage
        cmiAlbumArtSelect.Name = "cmiAlbumArtSelect"
        cmiAlbumArtSelect.Size = New Size(207, 26)
        cmiAlbumArtSelect.Text = "Select Image"
        ' 
        ' cmImageSource
        ' 
        cmImageSource.Font = New Font("Segoe UI", 12F)
        tipInfo.SetImage(cmImageSource, Nothing)
        cmImageSource.Items.AddRange(New ToolStripItem() {cmiSelectFromFile, cmiSelectFromOnline, cmiPasteFromClipboard})
        cmImageSource.Name = "cm"
        cmImageSource.OwnerItem = cmiAlbumArtInsertAfter
        cmImageSource.Size = New Size(230, 82)
        tipInfo.SetText(cmImageSource, Nothing)
        ' 
        ' cmiSelectFromFile
        ' 
        cmiSelectFromFile.Image = My.Resources.Resources.imageOpen
        cmiSelectFromFile.Name = "cmiSelectFromFile"
        cmiSelectFromFile.Size = New Size(229, 26)
        cmiSelectFromFile.Text = "Select From File"
        ' 
        ' cmiSelectFromOnline
        ' 
        cmiSelectFromOnline.Image = My.Resources.Resources.ImageOnline16
        cmiSelectFromOnline.Name = "cmiSelectFromOnline"
        cmiSelectFromOnline.Size = New Size(229, 26)
        cmiSelectFromOnline.Text = "Select From Online"
        ' 
        ' cmiPasteFromClipboard
        ' 
        cmiPasteFromClipboard.Image = My.Resources.Resources.ImageEditPaste16
        cmiPasteFromClipboard.Name = "cmiPasteFromClipboard"
        cmiPasteFromClipboard.Size = New Size(229, 26)
        cmiPasteFromClipboard.Text = "Paste From Clipboard"
        ' 
        ' cmiAlbumArtInsertLast
        ' 
        cmiAlbumArtInsertLast.DropDown = cmImageSource
        cmiAlbumArtInsertLast.Image = My.Resources.Resources.imageAdvanceLast
        cmiAlbumArtInsertLast.Name = "cmiAlbumArtInsertLast"
        cmiAlbumArtInsertLast.Size = New Size(125, 26)
        cmiAlbumArtInsertLast.Text = "Last"
        ' 
        ' cmiAlbumArtInsert
        ' 
        cmiAlbumArtInsert.DropDown = cmAlbumArtInsert
        cmiAlbumArtInsert.Image = My.Resources.Resources.imageNew
        cmiAlbumArtInsert.Name = "cmiAlbumArtInsert"
        cmiAlbumArtInsert.Size = New Size(207, 26)
        cmiAlbumArtInsert.Text = "Add New Image"
        ' 
        ' cmAlbumArtInsert
        ' 
        cmAlbumArtInsert.Font = New Font("Segoe UI", 12F)
        tipInfo.SetImage(cmAlbumArtInsert, Nothing)
        cmAlbumArtInsert.Items.AddRange(New ToolStripItem() {cmiAlbumArtInsertBefore, cmiAlbumArtInsertFirst, cmiAlbumArtInsertAfter, cmiAlbumArtInsertLast})
        cmAlbumArtInsert.Name = "cmAlbumArtInsert"
        cmAlbumArtInsert.OwnerItem = cmiAlbumArtInsert
        cmAlbumArtInsert.Size = New Size(126, 108)
        tipInfo.SetText(cmAlbumArtInsert, Nothing)
        ' 
        ' cmiAlbumArtInsertBefore
        ' 
        cmiAlbumArtInsertBefore.DropDown = cmImageSource
        cmiAlbumArtInsertBefore.Image = My.Resources.Resources.imageAdvanceLeft
        cmiAlbumArtInsertBefore.Name = "cmiAlbumArtInsertBefore"
        cmiAlbumArtInsertBefore.Size = New Size(125, 26)
        cmiAlbumArtInsertBefore.Text = "Before"
        ' 
        ' cmiAlbumArtInsertFirst
        ' 
        cmiAlbumArtInsertFirst.DropDown = cmImageSource
        cmiAlbumArtInsertFirst.Image = My.Resources.Resources.imageAdvanceFirst
        cmiAlbumArtInsertFirst.Name = "cmiAlbumArtInsertFirst"
        cmiAlbumArtInsertFirst.Size = New Size(125, 26)
        cmiAlbumArtInsertFirst.Text = "First"
        ' 
        ' cmiAlbumArtInsertAfter
        ' 
        cmiAlbumArtInsertAfter.DropDown = cmImageSource
        cmiAlbumArtInsertAfter.Image = My.Resources.Resources.imageAdvanceRight
        cmiAlbumArtInsertAfter.Name = "cmiAlbumArtInsertAfter"
        cmiAlbumArtInsertAfter.Size = New Size(125, 26)
        cmiAlbumArtInsertAfter.Text = "After"
        ' 
        ' cmiAlbumArtExport
        ' 
        cmiAlbumArtExport.DropDown = cmExport
        cmiAlbumArtExport.Image = My.Resources.Resources.imageSave
        cmiAlbumArtExport.Name = "cmiAlbumArtExport"
        cmiAlbumArtExport.Size = New Size(207, 26)
        cmiAlbumArtExport.Text = "Export Image"
        ' 
        ' cmExport
        ' 
        cmExport.Font = New Font("Segoe UI", 12F)
        tipInfo.SetImage(cmExport, Nothing)
        cmExport.Items.AddRange(New ToolStripItem() {cmiExportToFile, cmiExportToBitmap, cmiExportToClipboard})
        cmExport.Name = "cmExport"
        cmExport.OwnerItem = cmiAlbumArtExport
        cmExport.Size = New Size(177, 82)
        tipInfo.SetText(cmExport, Nothing)
        ' 
        ' cmiExportToFile
        ' 
        cmiExportToFile.Image = My.Resources.Resources.imageOpen
        cmiExportToFile.Name = "cmiExportToFile"
        cmiExportToFile.Size = New Size(176, 26)
        cmiExportToFile.Text = "To File"
        ' 
        ' cmiExportToBitmap
        ' 
        cmiExportToBitmap.Image = My.Resources.Resources.imageOpen
        cmiExportToBitmap.Name = "cmiExportToBitmap"
        cmiExportToBitmap.Size = New Size(176, 26)
        cmiExportToBitmap.Text = "To Bitmap File"
        ' 
        ' cmiExportToClipboard
        ' 
        cmiExportToClipboard.Image = My.Resources.Resources.ImageEditPaste16
        cmiExportToClipboard.Name = "cmiExportToClipboard"
        cmiExportToClipboard.Size = New Size(176, 26)
        cmiExportToClipboard.Text = "To Clipboard"
        ' 
        ' tsSeparator1
        ' 
        tsSeparator1.Name = "tsSeparator1"
        tsSeparator1.Size = New Size(204, 6)
        ' 
        ' cmiAlbumArtMoveLeft
        ' 
        cmiAlbumArtMoveLeft.Image = My.Resources.Resources.imageAdvanceLeft
        cmiAlbumArtMoveLeft.Name = "cmiAlbumArtMoveLeft"
        cmiAlbumArtMoveLeft.Size = New Size(207, 26)
        cmiAlbumArtMoveLeft.Text = "Move Image Left"
        ' 
        ' cmiAlbumArtMoveFirst
        ' 
        cmiAlbumArtMoveFirst.Image = My.Resources.Resources.imageAdvanceFirst
        cmiAlbumArtMoveFirst.Name = "cmiAlbumArtMoveFirst"
        cmiAlbumArtMoveFirst.Size = New Size(207, 26)
        cmiAlbumArtMoveFirst.Text = "Move Image First"
        ' 
        ' cmiAlbumArtMoveRight
        ' 
        cmiAlbumArtMoveRight.Image = My.Resources.Resources.imageAdvanceRight
        cmiAlbumArtMoveRight.Name = "cmiAlbumArtMoveRight"
        cmiAlbumArtMoveRight.Size = New Size(207, 26)
        cmiAlbumArtMoveRight.Text = "Move Image Right"
        ' 
        ' cmiAlbumArtMoveLast
        ' 
        cmiAlbumArtMoveLast.Image = My.Resources.Resources.imageAdvanceLast
        cmiAlbumArtMoveLast.Name = "cmiAlbumArtMoveLast"
        cmiAlbumArtMoveLast.Size = New Size(207, 26)
        cmiAlbumArtMoveLast.Text = "Move Image Last"
        ' 
        ' tsSeparator2
        ' 
        tsSeparator2.Name = "tsSeparator2"
        tsSeparator2.Size = New Size(204, 6)
        ' 
        ' cmiAlbumArtDelete
        ' 
        cmiAlbumArtDelete.Image = My.Resources.Resources.imageDelete
        cmiAlbumArtDelete.Name = "cmiAlbumArtDelete"
        cmiAlbumArtDelete.Size = New Size(207, 26)
        cmiAlbumArtDelete.Text = "Delete"
        ' 
        ' btnAlbumArt
        ' 
        btnAlbumArt.AllowDrop = True
        btnAlbumArt.CausesValidation = False
        btnAlbumArt.FlatAppearance.BorderColor = SystemColors.ControlDark
        btnAlbumArt.FlatAppearance.BorderSize = 0
        btnAlbumArt.FlatAppearance.MouseDownBackColor = Color.Transparent
        btnAlbumArt.FlatAppearance.MouseOverBackColor = Color.Transparent
        btnAlbumArt.Image = My.Resources.Resources.imageImage
        tipInfo.SetImage(btnAlbumArt, My.Resources.Resources.imageImage)
        btnAlbumArt.Location = New Point(180, 287)
        btnAlbumArt.Margin = New Padding(4)
        btnAlbumArt.Name = "btnAlbumArt"
        btnAlbumArt.Size = New Size(23, 25)
        btnAlbumArt.TabIndex = 0
        btnAlbumArt.TabStop = False
        tipInfo.SetText(btnAlbumArt, "Art Menu")
        btnAlbumArt.UseMnemonic = False
        btnAlbumArt.UseVisualStyleBackColor = False
        ' 
        ' picbxAlbumArt
        ' 
        picbxAlbumArt.ContextMenuStrip = cmAlbumArt
        tipInfo.SetImage(picbxAlbumArt, Nothing)
        picbxAlbumArt.Location = New Point(0, 0)
        picbxAlbumArt.Margin = New Padding(4)
        picbxAlbumArt.Name = "picbxAlbumArt"
        picbxAlbumArt.Size = New Size(463, 285)
        picbxAlbumArt.TabIndex = 1001
        picbxAlbumArt.TabStop = False
        tipInfo.SetText(picbxAlbumArt, "Album Art")
        ' 
        ' txbxArtist
        ' 
        txbxArtist.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txbxArtist.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        tipInfo.SetImage(txbxArtist, Nothing)
        txbxArtist.Location = New Point(15, 103)
        txbxArtist.Margin = New Padding(4)
        txbxArtist.Name = "txbxArtist"
        txbxArtist.ShortcutsEnabled = False
        txbxArtist.Size = New Size(305, 29)
        txbxArtist.TabIndex = 10
        tipInfo.SetText(txbxArtist, "Artist")
        ' 
        ' txbxAlbum
        ' 
        txbxAlbum.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txbxAlbum.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        tipInfo.SetImage(txbxAlbum, Nothing)
        txbxAlbum.Location = New Point(15, 206)
        txbxAlbum.Margin = New Padding(4)
        txbxAlbum.Name = "txbxAlbum"
        txbxAlbum.ShortcutsEnabled = False
        txbxAlbum.Size = New Size(390, 29)
        txbxAlbum.TabIndex = 30
        tipInfo.SetText(txbxAlbum, "Album")
        ' 
        ' txbxAlbumArt
        ' 
        txbxAlbumArt.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txbxAlbumArt.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        tipInfo.SetImage(txbxAlbumArt, Nothing)
        txbxAlbumArt.Location = New Point(64, 311)
        txbxAlbumArt.Margin = New Padding(4)
        txbxAlbumArt.Name = "txbxAlbumArt"
        txbxAlbumArt.ShortcutsEnabled = False
        txbxAlbumArt.Size = New Size(256, 29)
        txbxAlbumArt.TabIndex = 100
        tipInfo.SetText(txbxAlbumArt, "Art Description")
        ' 
        ' txbxTitle
        ' 
        txbxTitle.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txbxTitle.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        tipInfo.SetImage(txbxTitle, Nothing)
        txbxTitle.Location = New Point(15, 154)
        txbxTitle.Margin = New Padding(4)
        txbxTitle.Name = "txbxTitle"
        txbxTitle.ShortcutsEnabled = False
        txbxTitle.Size = New Size(305, 29)
        txbxTitle.TabIndex = 20
        tipInfo.SetText(txbxTitle, "Title")
        ' 
        ' txbxYear
        ' 
        txbxYear.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        txbxYear.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        tipInfo.SetImage(txbxYear, Nothing)
        txbxYear.Location = New Point(414, 206)
        txbxYear.Margin = New Padding(4)
        txbxYear.MaxLength = 4
        txbxYear.Name = "txbxYear"
        txbxYear.ShortcutsEnabled = False
        txbxYear.Size = New Size(63, 29)
        txbxYear.TabIndex = 35
        tipInfo.SetText(txbxYear, "Year")
        txbxYear.Text = "8888"
        txbxYear.TextAlign = HorizontalAlignment.Center
        ' 
        ' txbxTrack
        ' 
        txbxTrack.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        txbxTrack.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        tipInfo.SetImage(txbxTrack, Nothing)
        txbxTrack.Location = New Point(329, 154)
        txbxTrack.Margin = New Padding(4)
        txbxTrack.MaxLength = 2
        txbxTrack.Name = "txbxTrack"
        txbxTrack.ShortcutsEnabled = False
        txbxTrack.Size = New Size(34, 29)
        txbxTrack.TabIndex = 25
        tipInfo.SetText(txbxTrack, "Track Number")
        txbxTrack.Text = "88"
        txbxTrack.TextAlign = HorizontalAlignment.Center
        ' 
        ' txbxComments
        ' 
        txbxComments.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txbxComments.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        tipInfo.SetImage(txbxComments, Nothing)
        txbxComments.Location = New Point(15, 258)
        txbxComments.Margin = New Padding(4)
        txbxComments.Name = "txbxComments"
        txbxComments.ShortcutsEnabled = False
        txbxComments.Size = New Size(463, 29)
        txbxComments.TabIndex = 50
        tipInfo.SetText(txbxComments, "Comments")
        ' 
        ' txbxLyrics
        ' 
        txbxLyrics.AcceptsReturn = True
        txbxLyrics.AcceptsTab = True
        txbxLyrics.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        txbxLyrics.BackColor = Color.Linen
        txbxLyrics.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        txbxLyrics.HideSelection = False
        tipInfo.SetImage(txbxLyrics, Nothing)
        txbxLyrics.Location = New Point(17, 342)
        txbxLyrics.Margin = New Padding(4)
        txbxLyrics.Multiline = True
        txbxLyrics.Name = "txbxLyrics"
        txbxLyrics.ScrollBars = ScrollBars.Both
        txbxLyrics.ShortcutsEnabled = False
        txbxLyrics.Size = New Size(462, 285)
        txbxLyrics.TabIndex = 0
        txbxLyrics.TabStop = False
        tipInfo.SetText(txbxLyrics, Nothing)
        txbxLyrics.WordWrap = False
        ' 
        ' btnLyrics
        ' 
        btnLyrics.CausesValidation = False
        btnLyrics.FlatAppearance.BorderColor = Color.Black
        btnLyrics.FlatStyle = FlatStyle.Flat
        btnLyrics.Image = My.Resources.Resources.ImageLyrics32
        tipInfo.SetImage(btnLyrics, My.Resources.Resources.ImageLyrics32)
        btnLyrics.Location = New Point(18, 296)
        btnLyrics.Margin = New Padding(4)
        btnLyrics.Name = "btnLyrics"
        btnLyrics.Size = New Size(44, 44)
        btnLyrics.TabIndex = 95
        btnLyrics.TabStop = False
        tipInfo.SetText(btnLyrics, "Show Lyrics")
        ' 
        ' txbxDuration
        ' 
        txbxDuration.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        txbxDuration.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        tipInfo.SetImage(txbxDuration, Nothing)
        txbxDuration.Location = New Point(414, 154)
        txbxDuration.Margin = New Padding(4)
        txbxDuration.Name = "txbxDuration"
        txbxDuration.ReadOnly = True
        txbxDuration.Size = New Size(63, 29)
        txbxDuration.TabIndex = 28
        txbxDuration.TabStop = False
        tipInfo.SetText(txbxDuration, Nothing)
        txbxDuration.Text = "8:00:88"
        txbxDuration.TextAlign = HorizontalAlignment.Center
        ' 
        ' txbxTrackCount
        ' 
        txbxTrackCount.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        txbxTrackCount.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        tipInfo.SetImage(txbxTrackCount, Nothing)
        txbxTrackCount.Location = New Point(371, 154)
        txbxTrackCount.Margin = New Padding(4)
        txbxTrackCount.MaxLength = 2
        txbxTrackCount.Name = "txbxTrackCount"
        txbxTrackCount.ShortcutsEnabled = False
        txbxTrackCount.Size = New Size(34, 29)
        txbxTrackCount.TabIndex = 26
        tipInfo.SetText(txbxTrackCount, "Total Tracks")
        txbxTrackCount.Text = "88"
        txbxTrackCount.TextAlign = HorizontalAlignment.Center
        ' 
        ' panelAlbumArt
        ' 
        panelAlbumArt.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        panelAlbumArt.AutoScroll = True
        panelAlbumArt.CausesValidation = False
        panelAlbumArt.ContextMenuStrip = cmAlbumArt
        panelAlbumArt.Controls.Add(picbxAlbumArt)
        tipInfo.SetImage(panelAlbumArt, Nothing)
        panelAlbumArt.Location = New Point(17, 342)
        panelAlbumArt.Margin = New Padding(4)
        panelAlbumArt.Name = "panelAlbumArt"
        panelAlbumArt.Size = New Size(463, 285)
        panelAlbumArt.TabIndex = 0
        tipInfo.SetText(panelAlbumArt, Nothing)
        ' 
        ' MenuMain
        ' 
        MenuMain.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        tipInfo.SetImage(MenuMain, Nothing)
        MenuMain.Items.AddRange(New ToolStripItem() {MIFile, MIEdit, MIView, MIPlay, MIAbout, ToolStripMenuItem1})
        MenuMain.Location = New Point(0, 0)
        MenuMain.Name = "MenuMain"
        MenuMain.Padding = New Padding(8, 2, 0, 2)
        MenuMain.Size = New Size(494, 29)
        MenuMain.TabIndex = 1015
        MenuMain.Text = "MenuStrip1"
        tipInfo.SetText(MenuMain, Nothing)
        ' 
        ' MIFile
        ' 
        MIFile.DropDownItems.AddRange(New ToolStripItem() {MIOpenFile, MITrimFile, MIOpenLocation, MICloseFile, ToolStripSeparator1, MIExit})
        MIFile.ForeColor = Color.White
        MIFile.Image = My.Resources.Resources.imageOpen
        MIFile.Name = "MIFile"
        MIFile.Size = New Size(62, 25)
        MIFile.Text = "File"
        ' 
        ' MIOpenFile
        ' 
        MIOpenFile.Image = My.Resources.Resources.imageOpen
        MIOpenFile.Name = "MIOpenFile"
        MIOpenFile.Size = New Size(167, 26)
        MIOpenFile.Text = "Open File(s)"
        ' 
        ' MITrimFile
        ' 
        MITrimFile.Image = My.Resources.Resources.imageSave
        MITrimFile.Name = "MITrimFile"
        MITrimFile.Size = New Size(167, 26)
        MITrimFile.Text = "Trim MP3"
        ' 
        ' MIOpenLocation
        ' 
        MIOpenLocation.Image = My.Resources.Resources.imageFolder
        MIOpenLocation.Name = "MIOpenLocation"
        MIOpenLocation.Size = New Size(167, 26)
        MIOpenLocation.Text = "Go To Folder"
        ' 
        ' MICloseFile
        ' 
        MICloseFile.Image = My.Resources.Resources.imageClose
        MICloseFile.Name = "MICloseFile"
        MICloseFile.Size = New Size(167, 26)
        MICloseFile.Text = "Close File(s)"
        ' 
        ' ToolStripSeparator1
        ' 
        ToolStripSeparator1.Name = "ToolStripSeparator1"
        ToolStripSeparator1.Size = New Size(164, 6)
        ' 
        ' MIExit
        ' 
        MIExit.Image = My.Resources.Resources.imageClose
        MIExit.Name = "MIExit"
        MIExit.Size = New Size(167, 26)
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
        MIEdit.Size = New Size(64, 25)
        MIEdit.Text = "Edit"
        ' 
        ' MICopyTagBasic
        ' 
        MICopyTagBasic.Image = My.Resources.Resources.ImageEditCopy16
        MICopyTagBasic.Name = "MICopyTagBasic"
        MICopyTagBasic.Size = New Size(182, 26)
        MICopyTagBasic.Text = "Copy Basic Tag"
        MICopyTagBasic.ToolTipText = "Copy Tag without Album Art or Lyrics"
        ' 
        ' MICopyTagArt
        ' 
        MICopyTagArt.Image = My.Resources.Resources.ImageEditCopy16
        MICopyTagArt.Name = "MICopyTagArt"
        MICopyTagArt.Size = New Size(182, 26)
        MICopyTagArt.Text = "Copy Art Only"
        MICopyTagArt.ToolTipText = "Copy only Album Art"
        ' 
        ' MICopyTagFull
        ' 
        MICopyTagFull.Image = My.Resources.Resources.ImageEditCopy16
        MICopyTagFull.Name = "MICopyTagFull"
        MICopyTagFull.Size = New Size(182, 26)
        MICopyTagFull.Text = "Copy Full Tag"
        MICopyTagFull.ToolTipText = "Copy Tag with Album Art and Lyrics"
        ' 
        ' MIPasteTag
        ' 
        MIPasteTag.Image = My.Resources.Resources.ImageEditPaste16
        MIPasteTag.Name = "MIPasteTag"
        MIPasteTag.Size = New Size(182, 26)
        MIPasteTag.Text = "Paste Tag"
        ' 
        ' MIView
        ' 
        MIView.BackColor = Color.Transparent
        MIView.DropDownItems.AddRange(New ToolStripItem() {MISettings})
        MIView.ForeColor = Color.White
        MIView.Image = My.Resources.Resources.ImageView
        MIView.Name = "MIView"
        MIView.Size = New Size(72, 25)
        MIView.Text = "View"
        ' 
        ' MISettings
        ' 
        MISettings.Image = My.Resources.Resources.imageSettings
        MISettings.Name = "MISettings"
        MISettings.Size = New Size(136, 26)
        MISettings.Text = "Settings"
        ' 
        ' MIPlay
        ' 
        MIPlay.ForeColor = Color.White
        MIPlay.Image = My.Resources.Resources.imageSound
        MIPlay.Name = "MIPlay"
        MIPlay.Size = New Size(67, 25)
        MIPlay.Text = "Play"
        ' 
        ' MIAbout
        ' 
        MIAbout.DropDownItems.AddRange(New ToolStripItem() {MIHelp, MILog})
        MIAbout.ForeColor = Color.White
        MIAbout.Image = My.Resources.Resources.imageInfo
        MIAbout.Name = "MIAbout"
        MIAbout.Size = New Size(80, 25)
        MIAbout.Text = "About"
        ' 
        ' MIHelp
        ' 
        MIHelp.Image = My.Resources.Resources.imageInfo
        MIHelp.Name = "MIHelp"
        MIHelp.Size = New Size(175, 26)
        MIHelp.Text = "Help && About"
        ' 
        ' MILog
        ' 
        MILog.Image = My.Resources.Resources.imageLog
        MILog.Name = "MILog"
        MILog.Size = New Size(175, 26)
        MILog.Text = "Log"
        ' 
        ' ToolStripMenuItem1
        ' 
        ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        ToolStripMenuItem1.Size = New Size(12, 25)
        ' 
        ' lblFileInfo
        ' 
        lblFileInfo.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        lblFileInfo.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        tipInfo.SetImage(lblFileInfo, Nothing)
        lblFileInfo.Location = New Point(15, 47)
        lblFileInfo.Margin = New Padding(4, 0, 4, 0)
        lblFileInfo.Name = "lblFileInfo"
        lblFileInfo.Size = New Size(463, 28)
        lblFileInfo.TabIndex = 0
        lblFileInfo.Text = "File Info"
        tipInfo.SetText(lblFileInfo, "File Info")
        lblFileInfo.TextAlign = ContentAlignment.TopCenter
        ' 
        ' lblArtist
        ' 
        tipInfo.SetImage(lblArtist, Nothing)
        lblArtist.Location = New Point(14, 80)
        lblArtist.Margin = New Padding(4, 0, 4, 0)
        lblArtist.Name = "lblArtist"
        lblArtist.Size = New Size(127, 25)
        lblArtist.TabIndex = 1017
        lblArtist.Text = "Artist"
        tipInfo.SetText(lblArtist, Nothing)
        lblArtist.TextAlign = ContentAlignment.BottomLeft
        ' 
        ' lblGenre
        ' 
        lblGenre.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        tipInfo.SetImage(lblGenre, Nothing)
        lblGenre.Location = New Point(327, 81)
        lblGenre.Margin = New Padding(4, 0, 4, 0)
        lblGenre.Name = "lblGenre"
        lblGenre.Size = New Size(80, 25)
        lblGenre.TabIndex = 1018
        lblGenre.Text = "Genre"
        tipInfo.SetText(lblGenre, Nothing)
        lblGenre.TextAlign = ContentAlignment.BottomLeft
        ' 
        ' lblTitle
        ' 
        tipInfo.SetImage(lblTitle, Nothing)
        lblTitle.Location = New Point(14, 132)
        lblTitle.Margin = New Padding(4, 0, 4, 0)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(54, 25)
        lblTitle.TabIndex = 1019
        lblTitle.Text = "Title"
        tipInfo.SetText(lblTitle, Nothing)
        lblTitle.TextAlign = ContentAlignment.BottomLeft
        ' 
        ' lblAlbum
        ' 
        tipInfo.SetImage(lblAlbum, Nothing)
        lblAlbum.Location = New Point(14, 184)
        lblAlbum.Margin = New Padding(4, 0, 4, 0)
        lblAlbum.Name = "lblAlbum"
        lblAlbum.Size = New Size(77, 25)
        lblAlbum.TabIndex = 1020
        lblAlbum.Text = "Album"
        tipInfo.SetText(lblAlbum, Nothing)
        lblAlbum.TextAlign = ContentAlignment.BottomLeft
        ' 
        ' lblComments
        ' 
        tipInfo.SetImage(lblComments, Nothing)
        lblComments.Location = New Point(14, 236)
        lblComments.Margin = New Padding(4, 0, 4, 0)
        lblComments.Name = "lblComments"
        lblComments.Size = New Size(127, 25)
        lblComments.TabIndex = 1021
        lblComments.Text = "Comments"
        tipInfo.SetText(lblComments, Nothing)
        lblComments.TextAlign = ContentAlignment.BottomLeft
        ' 
        ' lblAlbumArt
        ' 
        tipInfo.SetImage(lblAlbumArt, Nothing)
        lblAlbumArt.Location = New Point(63, 288)
        lblAlbumArt.Margin = New Padding(4, 0, 4, 0)
        lblAlbumArt.Name = "lblAlbumArt"
        lblAlbumArt.Size = New Size(113, 25)
        lblAlbumArt.TabIndex = 1022
        lblAlbumArt.Text = "Art"
        tipInfo.SetText(lblAlbumArt, Nothing)
        lblAlbumArt.TextAlign = ContentAlignment.BottomLeft
        ' 
        ' lblTrack
        ' 
        lblTrack.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        tipInfo.SetImage(lblTrack, Nothing)
        lblTrack.Location = New Point(329, 132)
        lblTrack.Margin = New Padding(4, 0, 4, 0)
        lblTrack.Name = "lblTrack"
        lblTrack.Size = New Size(76, 25)
        lblTrack.TabIndex = 1023
        lblTrack.Text = "Track"
        tipInfo.SetText(lblTrack, Nothing)
        lblTrack.TextAlign = ContentAlignment.BottomCenter
        ' 
        ' lblTrackSeparator
        ' 
        lblTrackSeparator.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        tipInfo.SetImage(lblTrackSeparator, Nothing)
        lblTrackSeparator.Location = New Point(355, 154)
        lblTrackSeparator.Margin = New Padding(4, 0, 4, 0)
        lblTrackSeparator.Name = "lblTrackSeparator"
        lblTrackSeparator.Size = New Size(26, 25)
        lblTrackSeparator.TabIndex = 1024
        lblTrackSeparator.Text = "/"
        tipInfo.SetText(lblTrackSeparator, Nothing)
        lblTrackSeparator.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblDuration
        ' 
        lblDuration.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        tipInfo.SetImage(lblDuration, Nothing)
        lblDuration.Location = New Point(410, 132)
        lblDuration.Margin = New Padding(4, 0, 4, 0)
        lblDuration.Name = "lblDuration"
        lblDuration.Size = New Size(75, 25)
        lblDuration.TabIndex = 1025
        lblDuration.Text = "Duration"
        tipInfo.SetText(lblDuration, Nothing)
        lblDuration.TextAlign = ContentAlignment.BottomCenter
        ' 
        ' lblYear
        ' 
        lblYear.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        tipInfo.SetImage(lblYear, Nothing)
        lblYear.Location = New Point(417, 184)
        lblYear.Margin = New Padding(4, 0, 4, 0)
        lblYear.Name = "lblYear"
        lblYear.Size = New Size(64, 25)
        lblYear.TabIndex = 1026
        lblYear.Text = "Year"
        tipInfo.SetText(lblYear, Nothing)
        lblYear.TextAlign = ContentAlignment.BottomCenter
        ' 
        ' tipInfo
        ' 
        tipInfo.BackColor = Color.White
        tipInfo.BorderColor = Color.Gainsboro
        tipInfo.BorderThickness = 2
        tipInfo.CopyOnRightClick = True
        tipInfo.FadeInRate = 25
        tipInfo.FadeOutRate = 25
        tipInfo.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        tipInfo.HideDelay = 3000
        tipInfo.ShadowAlpha = 0
        tipInfo.ShadowThickness = 0
        tipInfo.ShowDelay = 100
        ' 
        ' CoBoxGenre
        ' 
        CoBoxGenre.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        CoBoxGenre.DropDownWidth = 149
        CoBoxGenre.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        CoBoxGenre.FormattingEnabled = True
        tipInfo.SetImage(CoBoxGenre, Nothing)
        CoBoxGenre.ItemHeight = 22
        CoBoxGenre.Location = New Point(329, 104)
        CoBoxGenre.Margin = New Padding(4)
        CoBoxGenre.Name = "CoBoxGenre"
        CoBoxGenre.Size = New Size(148, 28)
        CoBoxGenre.Sorted = True
        CoBoxGenre.TabIndex = 15
        tipInfo.SetText(CoBoxGenre, "Genre")
        ' 
        ' cobxAlbumArtType
        ' 
        cobxAlbumArtType.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Right
        cobxAlbumArtType.DropDownStyle = ComboBoxStyle.DropDownList
        cobxAlbumArtType.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        cobxAlbumArtType.FormattingEnabled = True
        tipInfo.SetImage(cobxAlbumArtType, Nothing)
        cobxAlbumArtType.ItemHeight = 22
        cobxAlbumArtType.Location = New Point(329, 312)
        cobxAlbumArtType.Margin = New Padding(4)
        cobxAlbumArtType.Name = "cobxAlbumArtType"
        cobxAlbumArtType.Size = New Size(149, 28)
        cobxAlbumArtType.TabIndex = 1027
        tipInfo.SetText(cobxAlbumArtType, Nothing)
        ' 
        ' MainForm
        ' 
        AllowDrop = True
        AutoScaleDimensions = New SizeF(9F, 21F)
        AutoScaleMode = AutoScaleMode.Font
        AutoSizeMode = AutoSizeMode.GrowAndShrink
        AutoValidate = AutoValidate.EnableAllowFocusChange
        ClientSize = New Size(494, 717)
        Controls.Add(cobxAlbumArtType)
        Controls.Add(CoBoxGenre)
        Controls.Add(lblFileInfo)
        Controls.Add(MenuMain)
        Controls.Add(btnLyrics)
        Controls.Add(txbxLyrics)
        Controls.Add(btnError)
        Controls.Add(btnSave)
        Controls.Add(btnRestore)
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
        Controls.Add(txbxAlbumArt)
        Controls.Add(btnAlbumArtLeft)
        Controls.Add(btnAlbumArtRight)
        Controls.Add(btnAlbumArt)
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
        Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        tipInfo.SetImage(Me, Nothing)
        KeyPreview = True
        MainMenuStrip = MenuMain
        Margin = New Padding(4, 5, 4, 5)
        MinimumSize = New Size(510, 732)
        Name = "MainForm"
        SizeGripStyle = SizeGripStyle.Show
        StartPosition = FormStartPosition.Manual
        tipInfo.SetText(Me, Nothing)
        cmArtRight.ResumeLayout(False)
        cmArtLeft.ResumeLayout(False)
        cmArtistLeft.ResumeLayout(False)
        cmArtistRight.ResumeLayout(False)
        cmNewArtist.ResumeLayout(False)
        cmAlbumArt.ResumeLayout(False)
        cmImageSource.ResumeLayout(False)
        cmAlbumArtInsert.ResumeLayout(False)
        cmExport.ResumeLayout(False)
        CType(picbxAlbumArt, ComponentModel.ISupportInitialize).EndInit()
        panelAlbumArt.ResumeLayout(False)
        MenuMain.ResumeLayout(False)
        MenuMain.PerformLayout()
        ResumeLayout(False)
        PerformLayout()

    End Sub
    Private WithEvents picbxAlbumArt As System.Windows.Forms.PictureBox
    Private WithEvents txbxAlbumArt As System.Windows.Forms.TextBox
    Private WithEvents txbxYear As System.Windows.Forms.TextBox
    Private WithEvents txbxComments As System.Windows.Forms.TextBox
    Private WithEvents txbxLyrics As System.Windows.Forms.TextBox
    Private WithEvents txbxDuration As System.Windows.Forms.TextBox
    Private WithEvents txbxTrackCount As System.Windows.Forms.TextBox
    Private WithEvents txbxTrack As System.Windows.Forms.TextBox
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
    Friend WithEvents lblFileInfo As Skye.UI.Label
    Friend WithEvents lblArtist As Skye.UI.Label
    Friend WithEvents lblGenre As Skye.UI.Label
    Friend WithEvents lblTitle As Skye.UI.Label
    Friend WithEvents lblAlbum As Skye.UI.Label
    Friend WithEvents lblComments As Skye.UI.Label
    Friend WithEvents lblAlbumArt As Skye.UI.Label
    Friend WithEvents lblTrack As Skye.UI.Label
    Friend WithEvents lblTrackSeparator As Skye.UI.Label
    Friend WithEvents lblDuration As Skye.UI.Label
    Friend WithEvents lblYear As Skye.UI.Label
    Friend WithEvents MIEdit As ToolStripMenuItem
    Friend WithEvents MICopyTagBasic As ToolStripMenuItem
    Friend WithEvents MICopyTagFull As ToolStripMenuItem
    Friend WithEvents MIPasteTag As ToolStripMenuItem
    Friend WithEvents txbxAlbum As TextBox
    Friend WithEvents txbxArtist As TextBox
    Friend WithEvents MICopyTagArt As ToolStripMenuItem
    Friend WithEvents MITrimFile As ToolStripMenuItem
    Friend WithEvents MIView As ToolStripMenuItem
    Friend WithEvents cmNewArtist As ContextMenuStrip
    Friend WithEvents cmiArtistInsert As ToolStripMenuItem
    Friend WithEvents cmiArtistInsertFromClipboard As ToolStripMenuItem
    Friend WithEvents cmArtistLeft As ContextMenuStrip
    Friend WithEvents cmiArtistPrevious As ToolStripMenuItem
    Friend WithEvents cmiArtistMoveLeft As ToolStripMenuItem
    Friend WithEvents cmiArtistMoveFirst As ToolStripMenuItem
    Friend WithEvents cmArtistRight As ContextMenuStrip
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents cmiArtistNext As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents cmiArtistMoveRight As ToolStripMenuItem
    Friend WithEvents cmiArtistMoveLast As ToolStripMenuItem
    Friend WithEvents cmArtLeft As ContextMenuStrip
    Friend WithEvents cmArtRight As ContextMenuStrip
    Friend WithEvents cmiArtPrevious As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents cmiArtMoveLeft As ToolStripMenuItem
    Friend WithEvents cmiArtMoveFirst As ToolStripMenuItem
    Friend WithEvents cmiArtNext As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents cmiArtMoveRight As ToolStripMenuItem
    Friend WithEvents cmiArtMoveLast As ToolStripMenuItem
    Friend WithEvents cmiAlbumArtMoveFirst As ToolStripMenuItem
    Friend WithEvents cmiAlbumArtMoveLast As ToolStripMenuItem
    Friend WithEvents cmImageSource As ContextMenuStrip
    Friend WithEvents cmiSelectFromFile As ToolStripMenuItem
    Friend WithEvents cmiSelectFromOnline As ToolStripMenuItem
    Friend WithEvents cmiPasteFromClipboard As ToolStripMenuItem
    Friend WithEvents cmExport As ContextMenuStrip
    Friend WithEvents cmiExportToFile As ToolStripMenuItem
    Friend WithEvents cmiExportToBitmap As ToolStripMenuItem
    Friend WithEvents cmiExportToClipboard As ToolStripMenuItem
    Friend WithEvents tipInfo As Skye.UI.ToolTipEX
    Friend WithEvents CoBoxGenre As Skye.UI.ComboBox
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents cobxAlbumArtType As Skye.UI.ComboBox
End Class