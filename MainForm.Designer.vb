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
        tipInfo = New Skye.UI.ToolTip()
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
        btnError.Image = My.Resources.Resources.imageError
        btnError.Location = New Point(340, 517)
        btnError.Name = "btnError"
        btnError.Size = New Size(32, 32)
        btnError.TabIndex = 25
        btnError.TabStop = False
        tipInfo.SetToolTip(btnError, "An Error Has Occurred" & vbCrLf & "Click To Clear Error" & vbCrLf & "RightClick = View Log")
        tipInfo.SetToolTipIcon(btnError, Nothing)
        btnError.Visible = False
        ' 
        ' tipInfo
        ' 
        tipInfo.BackColor = SystemColors.Control
        tipInfo.BorderColor = SystemColors.Window
        tipInfo.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        tipInfo.ForeColor = SystemColors.WindowText
        tipInfo.InitialDelay = 100
        tipInfo.OwnerDraw = True
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
        tipInfo.SetToolTipIcon(btnSave, Nothing)
        ' 
        ' btnAlbumArtRight
        ' 
        btnAlbumArtRight.CausesValidation = False
        btnAlbumArtRight.ContextMenuStrip = cmArtRight
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
        tipInfo.SetToolTip(btnAlbumArtRight, "LeftClick = Next Image" & vbCrLf & "RightClick = Menu")
        tipInfo.SetToolTipIcon(btnAlbumArtRight, Nothing)
        btnAlbumArtRight.UseMnemonic = False
        btnAlbumArtRight.UseVisualStyleBackColor = False
        ' 
        ' cmArtRight
        ' 
        cmArtRight.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        cmArtRight.Items.AddRange(New ToolStripItem() {cmiArtNext, ToolStripSeparator5, cmiArtMoveRight, cmiArtMoveLast})
        cmArtRight.Name = "cmArtRight"
        cmArtRight.Size = New Size(184, 76)
        tipInfo.SetToolTipIcon(cmArtRight, Nothing)
        ' 
        ' cmiArtNext
        ' 
        cmiArtNext.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        cmiArtNext.Image = My.Resources.Resources.imageAdvanceRight
        cmiArtNext.Name = "cmiArtNext"
        cmiArtNext.Size = New Size(183, 22)
        cmiArtNext.Text = "Next Image"
        ' 
        ' ToolStripSeparator5
        ' 
        ToolStripSeparator5.Name = "ToolStripSeparator5"
        ToolStripSeparator5.Size = New Size(180, 6)
        ' 
        ' cmiArtMoveRight
        ' 
        cmiArtMoveRight.Image = My.Resources.Resources.imageAdvanceRight
        cmiArtMoveRight.Name = "cmiArtMoveRight"
        cmiArtMoveRight.Size = New Size(183, 22)
        cmiArtMoveRight.Text = "Move Image Right"
        ' 
        ' cmiArtMoveLast
        ' 
        cmiArtMoveLast.Image = My.Resources.Resources.imageAdvanceLast
        cmiArtMoveLast.Name = "cmiArtMoveLast"
        cmiArtMoveLast.Size = New Size(183, 22)
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
        btnAlbumArtLeft.FlatStyle = FlatStyle.Flat
        btnAlbumArtLeft.Image = My.Resources.Resources.imageAdvanceLeft
        btnAlbumArtLeft.Location = New Point(217, 236)
        btnAlbumArtLeft.Name = "btnAlbumArtLeft"
        btnAlbumArtLeft.Size = New Size(16, 16)
        btnAlbumArtLeft.TabIndex = 0
        btnAlbumArtLeft.TabStop = False
        tipInfo.SetToolTip(btnAlbumArtLeft, "LeftClick = Previous Image" & vbCrLf & "RightClick = Menu")
        tipInfo.SetToolTipIcon(btnAlbumArtLeft, Nothing)
        btnAlbumArtLeft.UseMnemonic = False
        btnAlbumArtLeft.UseVisualStyleBackColor = False
        ' 
        ' cmArtLeft
        ' 
        cmArtLeft.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        cmArtLeft.Items.AddRange(New ToolStripItem() {cmiArtPrevious, ToolStripSeparator4, cmiArtMoveLeft, cmiArtMoveFirst})
        cmArtLeft.Name = "cmArtLeft"
        cmArtLeft.Size = New Size(178, 76)
        tipInfo.SetToolTipIcon(cmArtLeft, Nothing)
        ' 
        ' cmiArtPrevious
        ' 
        cmiArtPrevious.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        cmiArtPrevious.Image = My.Resources.Resources.imageAdvanceLeft
        cmiArtPrevious.Name = "cmiArtPrevious"
        cmiArtPrevious.Size = New Size(177, 22)
        cmiArtPrevious.Text = "Previous Image"
        ' 
        ' ToolStripSeparator4
        ' 
        ToolStripSeparator4.Name = "ToolStripSeparator4"
        ToolStripSeparator4.Size = New Size(174, 6)
        ' 
        ' cmiArtMoveLeft
        ' 
        cmiArtMoveLeft.Image = My.Resources.Resources.imageAdvanceLeft
        cmiArtMoveLeft.Name = "cmiArtMoveLeft"
        cmiArtMoveLeft.Size = New Size(177, 22)
        cmiArtMoveLeft.Text = "Move Image Left"
        ' 
        ' cmiArtMoveFirst
        ' 
        cmiArtMoveFirst.Image = My.Resources.Resources.imageAdvanceFirst
        cmiArtMoveFirst.Name = "cmiArtMoveFirst"
        cmiArtMoveFirst.Size = New Size(177, 22)
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
        btnRestore.Image = My.Resources.Resources.imageRestore
        btnRestore.ImageAlign = ContentAlignment.MiddleLeft
        btnRestore.Location = New Point(95, 518)
        btnRestore.Name = "btnRestore"
        btnRestore.Size = New Size(79, 32)
        btnRestore.TabIndex = 1005
        btnRestore.Text = "Undo"
        btnRestore.TextAlign = ContentAlignment.MiddleRight
        tipInfo.SetToolTip(btnRestore, "Restore Original Tag")
        tipInfo.SetToolTipIcon(btnRestore, Nothing)
        ' 
        ' btnArtistLeft
        ' 
        btnArtistLeft.CausesValidation = False
        btnArtistLeft.ContextMenuStrip = cmArtistLeft
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
        tipInfo.SetToolTip(btnArtistLeft, "LeftClick = Previous Artist" & vbCrLf & "RightClick = Menu")
        tipInfo.SetToolTipIcon(btnArtistLeft, Nothing)
        btnArtistLeft.UseMnemonic = False
        btnArtistLeft.UseVisualStyleBackColor = False
        ' 
        ' cmArtistLeft
        ' 
        cmArtistLeft.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        cmArtistLeft.Items.AddRange(New ToolStripItem() {cmiArtistPrevious, ToolStripSeparator2, cmiArtistMoveLeft, cmiArtistMoveFirst})
        cmArtistLeft.Name = "ContextMenuStrip1"
        cmArtistLeft.Size = New Size(172, 76)
        tipInfo.SetToolTipIcon(cmArtistLeft, Nothing)
        ' 
        ' cmiArtistPrevious
        ' 
        cmiArtistPrevious.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        cmiArtistPrevious.Image = My.Resources.Resources.imageAdvanceLeft
        cmiArtistPrevious.Name = "cmiArtistPrevious"
        cmiArtistPrevious.Size = New Size(171, 22)
        cmiArtistPrevious.Text = "Previous Artist"
        ' 
        ' ToolStripSeparator2
        ' 
        ToolStripSeparator2.Name = "ToolStripSeparator2"
        ToolStripSeparator2.Size = New Size(168, 6)
        ' 
        ' cmiArtistMoveLeft
        ' 
        cmiArtistMoveLeft.Image = My.Resources.Resources.imageAdvanceLeft
        cmiArtistMoveLeft.Name = "cmiArtistMoveLeft"
        cmiArtistMoveLeft.Size = New Size(171, 22)
        cmiArtistMoveLeft.Text = "Move Artist Left"
        ' 
        ' cmiArtistMoveFirst
        ' 
        cmiArtistMoveFirst.Image = My.Resources.Resources.imageAdvanceFirst
        cmiArtistMoveFirst.Name = "cmiArtistMoveFirst"
        cmiArtistMoveFirst.Size = New Size(171, 22)
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
        btnArtistRight.FlatStyle = FlatStyle.Flat
        btnArtistRight.Image = My.Resources.Resources.imageAdvanceRight
        btnArtistRight.Location = New Point(233, 68)
        btnArtistRight.Name = "btnArtistRight"
        btnArtistRight.Size = New Size(16, 16)
        btnArtistRight.TabIndex = 1011
        btnArtistRight.TabStop = False
        tipInfo.SetToolTip(btnArtistRight, "LeftClick = Next Artist" & vbCrLf & "RightClick = Menu")
        tipInfo.SetToolTipIcon(btnArtistRight, Nothing)
        btnArtistRight.UseMnemonic = False
        btnArtistRight.UseVisualStyleBackColor = False
        ' 
        ' cmArtistRight
        ' 
        cmArtistRight.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        cmArtistRight.Items.AddRange(New ToolStripItem() {cmiArtistNext, ToolStripSeparator3, cmiArtistMoveRight, cmiArtistMoveLast})
        cmArtistRight.Name = "cmArtistRight"
        cmArtistRight.Size = New Size(178, 76)
        tipInfo.SetToolTipIcon(cmArtistRight, Nothing)
        ' 
        ' cmiArtistNext
        ' 
        cmiArtistNext.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        cmiArtistNext.Image = My.Resources.Resources.imageAdvanceRight
        cmiArtistNext.Name = "cmiArtistNext"
        cmiArtistNext.Size = New Size(177, 22)
        cmiArtistNext.Text = "Next Artist"
        ' 
        ' ToolStripSeparator3
        ' 
        ToolStripSeparator3.Name = "ToolStripSeparator3"
        ToolStripSeparator3.Size = New Size(174, 6)
        ' 
        ' cmiArtistMoveRight
        ' 
        cmiArtistMoveRight.Image = My.Resources.Resources.imageAdvanceRight
        cmiArtistMoveRight.Name = "cmiArtistMoveRight"
        cmiArtistMoveRight.Size = New Size(177, 22)
        cmiArtistMoveRight.Text = "Move Artist Right"
        ' 
        ' cmiArtistMoveLast
        ' 
        cmiArtistMoveLast.Image = My.Resources.Resources.imageAdvanceLast
        cmiArtistMoveLast.Name = "cmiArtistMoveLast"
        cmiArtistMoveLast.Size = New Size(177, 22)
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
        btnArtistInsert.FlatStyle = FlatStyle.Flat
        btnArtistInsert.Image = My.Resources.Resources.imageNew
        btnArtistInsert.Location = New Point(116, 67)
        btnArtistInsert.Name = "btnArtistInsert"
        btnArtistInsert.Size = New Size(16, 16)
        btnArtistInsert.TabIndex = 1014
        btnArtistInsert.TabStop = False
        tipInfo.SetToolTip(btnArtistInsert, "LeftClick = Add New Artist" & vbCrLf & "RightClick = Menu")
        tipInfo.SetToolTipIcon(btnArtistInsert, Nothing)
        btnArtistInsert.UseMnemonic = False
        btnArtistInsert.UseVisualStyleBackColor = False
        ' 
        ' cmNewArtist
        ' 
        cmNewArtist.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        cmNewArtist.Items.AddRange(New ToolStripItem() {cmiArtistInsert, cmiArtistInsertFromClipboard})
        cmNewArtist.Name = "ContextMenuStrip1"
        cmNewArtist.Size = New Size(197, 48)
        tipInfo.SetToolTipIcon(cmNewArtist, Nothing)
        ' 
        ' cmiArtistInsert
        ' 
        cmiArtistInsert.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        cmiArtistInsert.Image = My.Resources.Resources.imageNew
        cmiArtistInsert.Name = "cmiArtistInsert"
        cmiArtistInsert.Size = New Size(196, 22)
        cmiArtistInsert.Text = "Add New Artist"
        ' 
        ' cmiArtistInsertFromClipboard
        ' 
        cmiArtistInsertFromClipboard.Image = My.Resources.Resources.imageNew
        cmiArtistInsertFromClipboard.Name = "cmiArtistInsertFromClipboard"
        cmiArtistInsertFromClipboard.Size = New Size(196, 22)
        cmiArtistInsertFromClipboard.Text = "Add From Clipboard"
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
        tipInfo.SetToolTipIcon(btnArtistDelete, Nothing)
        btnArtistDelete.UseMnemonic = False
        btnArtistDelete.UseVisualStyleBackColor = False
        ' 
        ' cmAlbumArt
        ' 
        cmAlbumArt.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        cmAlbumArt.Items.AddRange(New ToolStripItem() {cmiAlbumArtSelect, cmiAlbumArtInsert, cmiAlbumArtExport, tsSeparator1, cmiAlbumArtMoveLeft, cmiAlbumArtMoveFirst, cmiAlbumArtMoveRight, cmiAlbumArtMoveLast, tsSeparator2, cmiAlbumArtDelete})
        cmAlbumArt.Name = "cmAlbumArt"
        cmAlbumArt.Size = New Size(184, 192)
        tipInfo.SetToolTipIcon(cmAlbumArt, Nothing)
        ' 
        ' cmiAlbumArtSelect
        ' 
        cmiAlbumArtSelect.DropDown = cmImageSource
        cmiAlbumArtSelect.Image = My.Resources.Resources.imageOpenImage
        cmiAlbumArtSelect.Name = "cmiAlbumArtSelect"
        cmiAlbumArtSelect.Size = New Size(183, 22)
        cmiAlbumArtSelect.Text = "Select Image"
        ' 
        ' cmImageSource
        ' 
        cmImageSource.Items.AddRange(New ToolStripItem() {cmiSelectFromFile, cmiSelectFromOnline, cmiPasteFromClipboard})
        cmImageSource.Name = "cm"
        cmImageSource.OwnerItem = cmiAlbumArtInsertAfter
        cmImageSource.Size = New Size(189, 70)
        tipInfo.SetToolTipIcon(cmImageSource, Nothing)
        ' 
        ' cmiSelectFromFile
        ' 
        cmiSelectFromFile.Image = My.Resources.Resources.imageOpen
        cmiSelectFromFile.Name = "cmiSelectFromFile"
        cmiSelectFromFile.Size = New Size(188, 22)
        cmiSelectFromFile.Text = "Select From File"
        ' 
        ' cmiSelectFromOnline
        ' 
        cmiSelectFromOnline.Image = My.Resources.Resources.ImageOnline16
        cmiSelectFromOnline.Name = "cmiSelectFromOnline"
        cmiSelectFromOnline.Size = New Size(188, 22)
        cmiSelectFromOnline.Text = "Select From Online"
        ' 
        ' cmiPasteFromClipboard
        ' 
        cmiPasteFromClipboard.Image = My.Resources.Resources.ImageEditPaste16
        cmiPasteFromClipboard.Name = "cmiPasteFromClipboard"
        cmiPasteFromClipboard.Size = New Size(188, 22)
        cmiPasteFromClipboard.Text = "Paste From Clipboard"
        ' 
        ' cmiAlbumArtInsertLast
        ' 
        cmiAlbumArtInsertLast.DropDown = cmImageSource
        cmiAlbumArtInsertLast.Image = My.Resources.Resources.imageAdvanceLast
        cmiAlbumArtInsertLast.Name = "cmiAlbumArtInsertLast"
        cmiAlbumArtInsertLast.Size = New Size(114, 22)
        cmiAlbumArtInsertLast.Text = "Last"
        ' 
        ' cmiAlbumArtInsert
        ' 
        cmiAlbumArtInsert.DropDown = cmAlbumArtInsert
        cmiAlbumArtInsert.Image = My.Resources.Resources.imageNew
        cmiAlbumArtInsert.Name = "cmiAlbumArtInsert"
        cmiAlbumArtInsert.Size = New Size(183, 22)
        cmiAlbumArtInsert.Text = "Add New Image"
        ' 
        ' cmAlbumArtInsert
        ' 
        cmAlbumArtInsert.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        cmAlbumArtInsert.Items.AddRange(New ToolStripItem() {cmiAlbumArtInsertBefore, cmiAlbumArtInsertFirst, cmiAlbumArtInsertAfter, cmiAlbumArtInsertLast})
        cmAlbumArtInsert.Name = "cmAlbumArtInsert"
        cmAlbumArtInsert.OwnerItem = cmiAlbumArtInsert
        cmAlbumArtInsert.Size = New Size(115, 92)
        tipInfo.SetToolTipIcon(cmAlbumArtInsert, Nothing)
        ' 
        ' cmiAlbumArtInsertBefore
        ' 
        cmiAlbumArtInsertBefore.DropDown = cmImageSource
        cmiAlbumArtInsertBefore.Image = My.Resources.Resources.imageAdvanceLeft
        cmiAlbumArtInsertBefore.Name = "cmiAlbumArtInsertBefore"
        cmiAlbumArtInsertBefore.Size = New Size(114, 22)
        cmiAlbumArtInsertBefore.Text = "Before"
        ' 
        ' cmiAlbumArtInsertFirst
        ' 
        cmiAlbumArtInsertFirst.DropDown = cmImageSource
        cmiAlbumArtInsertFirst.Image = My.Resources.Resources.imageAdvanceFirst
        cmiAlbumArtInsertFirst.Name = "cmiAlbumArtInsertFirst"
        cmiAlbumArtInsertFirst.Size = New Size(114, 22)
        cmiAlbumArtInsertFirst.Text = "First"
        ' 
        ' cmiAlbumArtInsertAfter
        ' 
        cmiAlbumArtInsertAfter.DropDown = cmImageSource
        cmiAlbumArtInsertAfter.Image = My.Resources.Resources.imageAdvanceRight
        cmiAlbumArtInsertAfter.Name = "cmiAlbumArtInsertAfter"
        cmiAlbumArtInsertAfter.Size = New Size(114, 22)
        cmiAlbumArtInsertAfter.Text = "After"
        ' 
        ' cmiAlbumArtExport
        ' 
        cmiAlbumArtExport.DropDown = cmExport
        cmiAlbumArtExport.Image = My.Resources.Resources.imageSave
        cmiAlbumArtExport.Name = "cmiAlbumArtExport"
        cmiAlbumArtExport.Size = New Size(183, 22)
        cmiAlbumArtExport.Text = "Export Image"
        ' 
        ' cmExport
        ' 
        cmExport.Items.AddRange(New ToolStripItem() {cmiExportToFile, cmiExportToBitmap, cmiExportToClipboard})
        cmExport.Name = "cmExport"
        cmExport.OwnerItem = cmiAlbumArtExport
        cmExport.Size = New Size(150, 70)
        tipInfo.SetToolTipIcon(cmExport, Nothing)
        ' 
        ' cmiExportToFile
        ' 
        cmiExportToFile.Image = My.Resources.Resources.imageOpen
        cmiExportToFile.Name = "cmiExportToFile"
        cmiExportToFile.Size = New Size(149, 22)
        cmiExportToFile.Text = "To File"
        ' 
        ' cmiExportToBitmap
        ' 
        cmiExportToBitmap.Image = My.Resources.Resources.imageOpen
        cmiExportToBitmap.Name = "cmiExportToBitmap"
        cmiExportToBitmap.Size = New Size(149, 22)
        cmiExportToBitmap.Text = "To Bitmap File"
        ' 
        ' cmiExportToClipboard
        ' 
        cmiExportToClipboard.Image = My.Resources.Resources.ImageEditPaste16
        cmiExportToClipboard.Name = "cmiExportToClipboard"
        cmiExportToClipboard.Size = New Size(149, 22)
        cmiExportToClipboard.Text = "To Clipboard"
        ' 
        ' tsSeparator1
        ' 
        tsSeparator1.Name = "tsSeparator1"
        tsSeparator1.Size = New Size(180, 6)
        ' 
        ' cmiAlbumArtMoveLeft
        ' 
        cmiAlbumArtMoveLeft.Image = My.Resources.Resources.imageAdvanceLeft
        cmiAlbumArtMoveLeft.Name = "cmiAlbumArtMoveLeft"
        cmiAlbumArtMoveLeft.Size = New Size(183, 22)
        cmiAlbumArtMoveLeft.Text = "Move Image Left"
        ' 
        ' cmiAlbumArtMoveFirst
        ' 
        cmiAlbumArtMoveFirst.Image = My.Resources.Resources.imageAdvanceFirst
        cmiAlbumArtMoveFirst.Name = "cmiAlbumArtMoveFirst"
        cmiAlbumArtMoveFirst.Size = New Size(183, 22)
        cmiAlbumArtMoveFirst.Text = "Move Image First"
        ' 
        ' cmiAlbumArtMoveRight
        ' 
        cmiAlbumArtMoveRight.Image = My.Resources.Resources.imageAdvanceRight
        cmiAlbumArtMoveRight.Name = "cmiAlbumArtMoveRight"
        cmiAlbumArtMoveRight.Size = New Size(183, 22)
        cmiAlbumArtMoveRight.Text = "Move Image Right"
        ' 
        ' cmiAlbumArtMoveLast
        ' 
        cmiAlbumArtMoveLast.Image = My.Resources.Resources.imageAdvanceLast
        cmiAlbumArtMoveLast.Name = "cmiAlbumArtMoveLast"
        cmiAlbumArtMoveLast.Size = New Size(183, 22)
        cmiAlbumArtMoveLast.Text = "Move Image Last"
        ' 
        ' tsSeparator2
        ' 
        tsSeparator2.Name = "tsSeparator2"
        tsSeparator2.Size = New Size(180, 6)
        ' 
        ' cmiAlbumArtDelete
        ' 
        cmiAlbumArtDelete.Image = My.Resources.Resources.imageDelete
        cmiAlbumArtDelete.Name = "cmiAlbumArtDelete"
        cmiAlbumArtDelete.Size = New Size(183, 22)
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
        btnAlbumArt.FlatStyle = FlatStyle.Flat
        btnAlbumArt.Image = My.Resources.Resources.imageImage
        btnAlbumArt.Location = New Point(140, 233)
        btnAlbumArt.Name = "btnAlbumArt"
        btnAlbumArt.Size = New Size(16, 17)
        btnAlbumArt.TabIndex = 0
        btnAlbumArt.TabStop = False
        tipInfo.SetToolTipIcon(btnAlbumArt, Nothing)
        btnAlbumArt.UseMnemonic = False
        btnAlbumArt.UseVisualStyleBackColor = False
        ' 
        ' picbxAlbumArt
        ' 
        picbxAlbumArt.ContextMenuStrip = cmAlbumArt
        picbxAlbumArt.Location = New Point(0, 0)
        picbxAlbumArt.Name = "picbxAlbumArt"
        picbxAlbumArt.Size = New Size(360, 229)
        picbxAlbumArt.TabIndex = 1001
        picbxAlbumArt.TabStop = False
        tipInfo.SetToolTipIcon(picbxAlbumArt, Nothing)
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
        tipInfo.SetToolTipIcon(txbxArtist, Nothing)
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
        tipInfo.SetToolTipIcon(txbxAlbum, Nothing)
        ' 
        ' txbxAlbumArt
        ' 
        txbxAlbumArt.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txbxAlbumArt.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold)
        txbxAlbumArt.Location = New Point(50, 251)
        txbxAlbumArt.Name = "txbxAlbumArt"
        txbxAlbumArt.ShortcutsEnabled = False
        txbxAlbumArt.Size = New Size(200, 25)
        txbxAlbumArt.TabIndex = 100
        tipInfo.SetToolTipIcon(txbxAlbumArt, Nothing)
        ' 
        ' cobxAlbumArtType
        ' 
        cobxAlbumArtType.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        cobxAlbumArtType.DropDownStyle = ComboBoxStyle.DropDownList
        cobxAlbumArtType.DropDownWidth = 130
        cobxAlbumArtType.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold)
        cobxAlbumArtType.FormattingEnabled = True
        cobxAlbumArtType.ItemHeight = 17
        cobxAlbumArtType.Location = New Point(256, 251)
        cobxAlbumArtType.MaxDropDownItems = 7
        cobxAlbumArtType.Name = "cobxAlbumArtType"
        cobxAlbumArtType.Size = New Size(117, 25)
        cobxAlbumArtType.TabIndex = 110
        tipInfo.SetToolTipIcon(cobxAlbumArtType, Nothing)
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
        tipInfo.SetToolTipIcon(txbxTitle, Nothing)
        ' 
        ' txbxYear
        ' 
        txbxYear.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        txbxYear.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold)
        txbxYear.Location = New Point(322, 167)
        txbxYear.MaxLength = 4
        txbxYear.Name = "txbxYear"
        txbxYear.ShortcutsEnabled = False
        txbxYear.Size = New Size(50, 25)
        txbxYear.TabIndex = 35
        txbxYear.Text = "8888"
        txbxYear.TextAlign = HorizontalAlignment.Center
        tipInfo.SetToolTipIcon(txbxYear, Nothing)
        ' 
        ' txbxTrack
        ' 
        txbxTrack.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        txbxTrack.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold)
        txbxTrack.Location = New Point(256, 125)
        txbxTrack.MaxLength = 2
        txbxTrack.Name = "txbxTrack"
        txbxTrack.ShortcutsEnabled = False
        txbxTrack.Size = New Size(27, 25)
        txbxTrack.TabIndex = 25
        txbxTrack.Text = "88"
        txbxTrack.TextAlign = HorizontalAlignment.Center
        tipInfo.SetToolTipIcon(txbxTrack, Nothing)
        ' 
        ' txbxComments
        ' 
        txbxComments.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txbxComments.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold)
        txbxComments.Location = New Point(12, 209)
        txbxComments.Name = "txbxComments"
        txbxComments.ShortcutsEnabled = False
        txbxComments.Size = New Size(361, 25)
        txbxComments.TabIndex = 50
        tipInfo.SetToolTipIcon(txbxComments, Nothing)
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
        tipInfo.SetToolTipIcon(cobxGenre, Nothing)
        ' 
        ' txbxLyrics
        ' 
        txbxLyrics.AcceptsReturn = True
        txbxLyrics.AcceptsTab = True
        txbxLyrics.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        txbxLyrics.BackColor = Color.Linen
        txbxLyrics.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        txbxLyrics.HideSelection = False
        txbxLyrics.Location = New Point(13, 277)
        txbxLyrics.Multiline = True
        txbxLyrics.Name = "txbxLyrics"
        txbxLyrics.ScrollBars = ScrollBars.Both
        txbxLyrics.ShortcutsEnabled = False
        txbxLyrics.Size = New Size(360, 229)
        txbxLyrics.TabIndex = 0
        txbxLyrics.TabStop = False
        tipInfo.SetToolTipIcon(txbxLyrics, Nothing)
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
        tipInfo.SetToolTipIcon(btnLyrics, Nothing)
        ' 
        ' txbxDuration
        ' 
        txbxDuration.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        txbxDuration.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold)
        txbxDuration.Location = New Point(322, 125)
        txbxDuration.Name = "txbxDuration"
        txbxDuration.ReadOnly = True
        txbxDuration.Size = New Size(50, 25)
        txbxDuration.TabIndex = 28
        txbxDuration.TabStop = False
        txbxDuration.Text = "8:00:88"
        txbxDuration.TextAlign = HorizontalAlignment.Center
        tipInfo.SetToolTipIcon(txbxDuration, Nothing)
        ' 
        ' txbxTrackCount
        ' 
        txbxTrackCount.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        txbxTrackCount.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold)
        txbxTrackCount.Location = New Point(289, 125)
        txbxTrackCount.MaxLength = 2
        txbxTrackCount.Name = "txbxTrackCount"
        txbxTrackCount.ShortcutsEnabled = False
        txbxTrackCount.Size = New Size(27, 25)
        txbxTrackCount.TabIndex = 26
        txbxTrackCount.Text = "88"
        txbxTrackCount.TextAlign = HorizontalAlignment.Center
        tipInfo.SetToolTipIcon(txbxTrackCount, Nothing)
        ' 
        ' txbxGenre
        ' 
        txbxGenre.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        txbxGenre.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold)
        txbxGenre.Location = New Point(256, 83)
        txbxGenre.Name = "txbxGenre"
        txbxGenre.ShortcutsEnabled = False
        txbxGenre.Size = New Size(106, 25)
        txbxGenre.TabIndex = 15
        tipInfo.SetToolTipIcon(txbxGenre, Nothing)
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
        tipInfo.SetToolTipIcon(panelAlbumArt, Nothing)
        ' 
        ' MenuMain
        ' 
        MenuMain.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        MenuMain.Items.AddRange(New ToolStripItem() {MIFile, MIEdit, MIView, MIPlay, MIAbout})
        MenuMain.Location = New Point(0, 0)
        MenuMain.Name = "MenuMain"
        MenuMain.Size = New Size(384, 25)
        MenuMain.TabIndex = 1015
        MenuMain.Text = "MenuStrip1"
        tipInfo.SetToolTipIcon(MenuMain, Nothing)
        ' 
        ' MIFile
        ' 
        MIFile.DropDownItems.AddRange(New ToolStripItem() {MIOpenFile, MITrimFile, MIOpenLocation, MICloseFile, ToolStripSeparator1, MIExit})
        MIFile.ForeColor = Color.White
        MIFile.Image = My.Resources.Resources.imageOpen
        MIFile.Name = "MIFile"
        MIFile.Size = New Size(55, 21)
        MIFile.Text = "File"
        ' 
        ' MIOpenFile
        ' 
        MIOpenFile.Image = My.Resources.Resources.imageOpen
        MIOpenFile.Name = "MIOpenFile"
        MIOpenFile.Size = New Size(152, 22)
        MIOpenFile.Text = "Open File"
        ' 
        ' MITrimFile
        ' 
        MITrimFile.Image = My.Resources.Resources.imageSave
        MITrimFile.Name = "MITrimFile"
        MITrimFile.Size = New Size(152, 22)
        MITrimFile.Text = "Trim MP3"
        ' 
        ' MIOpenLocation
        ' 
        MIOpenLocation.Image = My.Resources.Resources.imageFolder
        MIOpenLocation.Name = "MIOpenLocation"
        MIOpenLocation.Size = New Size(152, 22)
        MIOpenLocation.Text = "Go To Folder"
        ' 
        ' MICloseFile
        ' 
        MICloseFile.Image = My.Resources.Resources.imageClose
        MICloseFile.Name = "MICloseFile"
        MICloseFile.Size = New Size(152, 22)
        MICloseFile.Text = "Close File"
        ' 
        ' ToolStripSeparator1
        ' 
        ToolStripSeparator1.Name = "ToolStripSeparator1"
        ToolStripSeparator1.Size = New Size(149, 6)
        ' 
        ' MIExit
        ' 
        MIExit.Image = My.Resources.Resources.imageClose
        MIExit.Name = "MIExit"
        MIExit.Size = New Size(152, 22)
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
        MIEdit.Size = New Size(58, 21)
        MIEdit.Text = "Edit"
        ' 
        ' MICopyTagBasic
        ' 
        MICopyTagBasic.Image = My.Resources.Resources.ImageEditCopy16
        MICopyTagBasic.Name = "MICopyTagBasic"
        MICopyTagBasic.Size = New Size(164, 22)
        MICopyTagBasic.Text = "Copy Basic Tag"
        MICopyTagBasic.ToolTipText = "Copy Tag without Album Art or Lyrics"
        ' 
        ' MICopyTagArt
        ' 
        MICopyTagArt.Image = My.Resources.Resources.ImageEditCopy16
        MICopyTagArt.Name = "MICopyTagArt"
        MICopyTagArt.Size = New Size(164, 22)
        MICopyTagArt.Text = "Copy Art Only"
        MICopyTagArt.ToolTipText = "Copy only Album Art"
        ' 
        ' MICopyTagFull
        ' 
        MICopyTagFull.Image = My.Resources.Resources.ImageEditCopy16
        MICopyTagFull.Name = "MICopyTagFull"
        MICopyTagFull.Size = New Size(164, 22)
        MICopyTagFull.Text = "Copy Full Tag"
        MICopyTagFull.ToolTipText = "Copy Tag with Album Art and Lyrics"
        ' 
        ' MIPasteTag
        ' 
        MIPasteTag.Image = My.Resources.Resources.ImageEditPaste16
        MIPasteTag.Name = "MIPasteTag"
        MIPasteTag.Size = New Size(164, 22)
        MIPasteTag.Text = "Paste Tag"
        ' 
        ' MIView
        ' 
        MIView.BackColor = Color.Transparent
        MIView.DropDownItems.AddRange(New ToolStripItem() {MISettings})
        MIView.ForeColor = Color.White
        MIView.Image = My.Resources.Resources.ImageView
        MIView.Name = "MIView"
        MIView.Size = New Size(63, 21)
        MIView.Text = "View"
        ' 
        ' MISettings
        ' 
        MISettings.Image = My.Resources.Resources.imageSettings
        MISettings.Name = "MISettings"
        MISettings.Size = New Size(122, 22)
        MISettings.Text = "Settings"
        ' 
        ' MIPlay
        ' 
        MIPlay.ForeColor = Color.White
        MIPlay.Image = My.Resources.Resources.imageSound
        MIPlay.Name = "MIPlay"
        MIPlay.Size = New Size(59, 21)
        MIPlay.Text = "Play"
        ' 
        ' MIAbout
        ' 
        MIAbout.DropDownItems.AddRange(New ToolStripItem() {MIHelp, MILog})
        MIAbout.ForeColor = Color.White
        MIAbout.Image = My.Resources.Resources.imageInfo
        MIAbout.Name = "MIAbout"
        MIAbout.Size = New Size(71, 21)
        MIAbout.Text = "About"
        ' 
        ' MIHelp
        ' 
        MIHelp.Image = My.Resources.Resources.imageInfo
        MIHelp.Name = "MIHelp"
        MIHelp.Size = New Size(156, 22)
        MIHelp.Text = "Help && About"
        ' 
        ' MILog
        ' 
        MILog.Image = My.Resources.Resources.imageLog
        MILog.Name = "MILog"
        MILog.Size = New Size(156, 22)
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
        tipInfo.SetToolTipIcon(lblFileInfo, Nothing)
        ' 
        ' lblArtist
        ' 
        lblArtist.Location = New Point(11, 65)
        lblArtist.Name = "lblArtist"
        lblArtist.Size = New Size(41, 20)
        lblArtist.TabIndex = 1017
        lblArtist.Text = "Artist"
        lblArtist.TextAlign = ContentAlignment.BottomLeft
        tipInfo.SetToolTipIcon(lblArtist, Nothing)
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
        tipInfo.SetToolTipIcon(lblGenre, Nothing)
        ' 
        ' lblTitle
        ' 
        lblTitle.Location = New Point(11, 107)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(42, 20)
        lblTitle.TabIndex = 1019
        lblTitle.Text = "Title"
        lblTitle.TextAlign = ContentAlignment.BottomLeft
        tipInfo.SetToolTipIcon(lblTitle, Nothing)
        ' 
        ' lblAlbum
        ' 
        lblAlbum.Location = New Point(11, 149)
        lblAlbum.Name = "lblAlbum"
        lblAlbum.Size = New Size(50, 20)
        lblAlbum.TabIndex = 1020
        lblAlbum.Text = "Album"
        lblAlbum.TextAlign = ContentAlignment.BottomLeft
        tipInfo.SetToolTipIcon(lblAlbum, Nothing)
        ' 
        ' lblComments
        ' 
        lblComments.Location = New Point(11, 191)
        lblComments.Name = "lblComments"
        lblComments.Size = New Size(73, 20)
        lblComments.TabIndex = 1021
        lblComments.Text = "Comments"
        lblComments.TextAlign = ContentAlignment.BottomLeft
        tipInfo.SetToolTipIcon(lblComments, Nothing)
        ' 
        ' lblAlbumArt
        ' 
        lblAlbumArt.Location = New Point(49, 233)
        lblAlbumArt.Name = "lblAlbumArt"
        lblAlbumArt.Size = New Size(88, 20)
        lblAlbumArt.TabIndex = 1022
        lblAlbumArt.Text = "Art"
        lblAlbumArt.TextAlign = ContentAlignment.BottomLeft
        tipInfo.SetToolTipIcon(lblAlbumArt, Nothing)
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
        tipInfo.SetToolTipIcon(lblTrack, Nothing)
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
        tipInfo.SetToolTipIcon(lblTrackSeparator, Nothing)
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
        tipInfo.SetToolTipIcon(lblDuration, Nothing)
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
        tipInfo.SetToolTipIcon(lblYear, Nothing)
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
        tipInfo.SetToolTipIcon(Me, Nothing)
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
    Friend WithEvents tipInfo As Skye.UI.ToolTip
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
End Class