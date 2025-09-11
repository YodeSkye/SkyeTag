<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectOnlineImage
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SelectOnlineImage))
        LVIDs = New ListView()
        ColumnHeader1 = New ColumnHeader()
        PicBoxArt = New PictureBox()
        BtnOK = New Button()
        PicBoxBackThumb = New PictureBox()
        PicBoxFrontThumb = New PictureBox()
        LblStatus = New Label()
        TxtBoxSearchPhrase = New TextBox()
        BtnSaveArt = New Button()
        LblDimFront = New Skye.UI.Label
        LblDimBack = New Skye.UI.Label
        LblSearchPhrase = New Skye.UI.Label
        tipInfo = New ToolTip(components)
        CType(PicBoxArt, ComponentModel.ISupportInitialize).BeginInit()
        CType(PicBoxBackThumb, ComponentModel.ISupportInitialize).BeginInit()
        CType(PicBoxFrontThumb, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' LVIDs
        ' 
        LVIDs.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        LVIDs.Columns.AddRange(New ColumnHeader() {ColumnHeader1})
        LVIDs.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold)
        LVIDs.HeaderStyle = ColumnHeaderStyle.None
        LVIDs.Location = New Point(12, 49)
        LVIDs.Name = "LVIDs"
        LVIDs.Size = New Size(388, 208)
        LVIDs.TabIndex = 0
        LVIDs.UseCompatibleStateImageBehavior = False
        LVIDs.View = View.Details
        ' 
        ' ColumnHeader1
        ' 
        ColumnHeader1.Text = ""
        ColumnHeader1.Width = 540
        ' 
        ' PicBoxArt
        ' 
        PicBoxArt.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        PicBoxArt.Location = New Point(12, 264)
        PicBoxArt.Name = "PicBoxArt"
        PicBoxArt.Size = New Size(600, 680)
        PicBoxArt.SizeMode = PictureBoxSizeMode.Zoom
        PicBoxArt.TabIndex = 2
        PicBoxArt.TabStop = False
        tipInfo.SetToolTip(PicBoxArt, "Selected Image")
        ' 
        ' BtnOK
        ' 
        BtnOK.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        BtnOK.Image = My.Resources.Resources.ImageOK64
        BtnOK.Location = New Point(548, 185)
        BtnOK.Name = "BtnOK"
        BtnOK.Size = New Size(64, 73)
        BtnOK.TabIndex = 30
        tipInfo.SetToolTip(BtnOK, "Insert Image as Art")
        BtnOK.UseVisualStyleBackColor = True
        ' 
        ' PicBoxBackThumb
        ' 
        PicBoxBackThumb.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        PicBoxBackThumb.Location = New Point(512, 12)
        PicBoxBackThumb.Name = "PicBoxBackThumb"
        PicBoxBackThumb.Size = New Size(100, 113)
        PicBoxBackThumb.SizeMode = PictureBoxSizeMode.Zoom
        PicBoxBackThumb.TabIndex = 4
        PicBoxBackThumb.TabStop = False
        tipInfo.SetToolTip(PicBoxBackThumb, "Back Cover Thumbnail, Click to Select")
        ' 
        ' PicBoxFrontThumb
        ' 
        PicBoxFrontThumb.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        PicBoxFrontThumb.Location = New Point(406, 14)
        PicBoxFrontThumb.Name = "PicBoxFrontThumb"
        PicBoxFrontThumb.Size = New Size(100, 113)
        PicBoxFrontThumb.SizeMode = PictureBoxSizeMode.Zoom
        PicBoxFrontThumb.TabIndex = 5
        PicBoxFrontThumb.TabStop = False
        tipInfo.SetToolTip(PicBoxFrontThumb, "Front Cover Thumbnail, Click to Select")
        ' 
        ' LblStatus
        ' 
        LblStatus.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        LblStatus.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LblStatus.ForeColor = Color.Red
        LblStatus.Location = New Point(406, 162)
        LblStatus.Name = "LblStatus"
        LblStatus.Size = New Size(206, 19)
        LblStatus.TabIndex = 8
        LblStatus.Text = "Downloading Art..."
        LblStatus.TextAlign = ContentAlignment.MiddleCenter
        LblStatus.Visible = False
        ' 
        ' TxtBoxSearchPhrase
        ' 
        TxtBoxSearchPhrase.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        TxtBoxSearchPhrase.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold)
        TxtBoxSearchPhrase.Location = New Point(107, 14)
        TxtBoxSearchPhrase.Name = "TxtBoxSearchPhrase"
        TxtBoxSearchPhrase.Size = New Size(293, 25)
        TxtBoxSearchPhrase.TabIndex = 100
        ' 
        ' BtnSaveArt
        ' 
        BtnSaveArt.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        BtnSaveArt.Enabled = False
        BtnSaveArt.Image = My.Resources.Resources.ImageSave64
        BtnSaveArt.Location = New Point(406, 185)
        BtnSaveArt.Name = "BtnSaveArt"
        BtnSaveArt.Size = New Size(64, 73)
        BtnSaveArt.TabIndex = 20
        BtnSaveArt.TabStop = False
        tipInfo.SetToolTip(BtnSaveArt, "Save Image to File")
        BtnSaveArt.UseVisualStyleBackColor = True
        ' 
        ' LblDimFront
        ' 
        LblDimFront.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        LblDimFront.Font = New Font("Segoe UI", 9.75F)
        LblDimFront.Location = New Point(406, 126)
        LblDimFront.Name = "LblDimFront"
        LblDimFront.Size = New Size(100, 23)
        LblDimFront.TabIndex = 101
        LblDimFront.Text = "W x H"
        LblDimFront.TextAlign = ContentAlignment.TopCenter
        ' 
        ' LblDimBack
        ' 
        LblDimBack.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        LblDimBack.Font = New Font("Segoe UI", 9.75F)
        LblDimBack.Location = New Point(512, 125)
        LblDimBack.Name = "LblDimBack"
        LblDimBack.Size = New Size(100, 23)
        LblDimBack.TabIndex = 102
        LblDimBack.Text = "W x H"
        LblDimBack.TextAlign = ContentAlignment.TopCenter
        ' 
        ' LblSearchPhrase
        ' 
        LblSearchPhrase.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LblSearchPhrase.Location = New Point(14, 15)
        LblSearchPhrase.Name = "LblSearchPhrase"
        LblSearchPhrase.Size = New Size(94, 26)
        LblSearchPhrase.TabIndex = 103
        LblSearchPhrase.Text = "Search Phrase:"
        LblSearchPhrase.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' tipInfo
        ' 
        tipInfo.OwnerDraw = True
        ' 
        ' SelectOnlineImage
        ' 
        AutoScaleDimensions = New SizeF(7F, 17F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(624, 957)
        Controls.Add(LblStatus)
        Controls.Add(BtnSaveArt)
        Controls.Add(TxtBoxSearchPhrase)
        Controls.Add(PicBoxFrontThumb)
        Controls.Add(PicBoxBackThumb)
        Controls.Add(BtnOK)
        Controls.Add(PicBoxArt)
        Controls.Add(LVIDs)
        Controls.Add(LblDimFront)
        Controls.Add(LblDimBack)
        Controls.Add(LblSearchPhrase)
        Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MinimumSize = New Size(500, 561)
        Name = "SelectOnlineImage"
        StartPosition = FormStartPosition.CenterParent
        Text = "Select Image from MusicBrainz"
        CType(PicBoxArt, ComponentModel.ISupportInitialize).EndInit()
        CType(PicBoxBackThumb, ComponentModel.ISupportInitialize).EndInit()
        CType(PicBoxFrontThumb, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents LVIDs As ListView
    Friend WithEvents PicBoxArt As PictureBox
    Friend WithEvents BtnOK As Button
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents PicBoxBackThumb As PictureBox
    Friend WithEvents PicBoxFrontThumb As PictureBox
    Friend WithEvents LblStatus As Label
    Friend WithEvents TxtBoxSearchPhrase As TextBox
    Friend WithEvents BtnSaveArt As Button
    Friend WithEvents LblDimFront As Skye.UI.Label
    Friend WithEvents LblDimBack As Skye.UI.Label
    Friend WithEvents LblSearchPhrase As Skye.UI.Label
    Friend WithEvents tipInfo As ToolTip
End Class
