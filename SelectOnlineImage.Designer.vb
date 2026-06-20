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
        LblDimFront = New Skye.UI.Label()
        LblDimBack = New Skye.UI.Label()
        LblSearchPhrase = New Skye.UI.Label()
        tipInfo = New Skye.UI.ToolTipEX(components)
        CType(PicBoxArt, ComponentModel.ISupportInitialize).BeginInit()
        CType(PicBoxBackThumb, ComponentModel.ISupportInitialize).BeginInit()
        CType(PicBoxFrontThumb, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' LVIDs
        ' 
        LVIDs.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        LVIDs.Columns.AddRange(New ColumnHeader() {ColumnHeader1})
        LVIDs.HeaderStyle = ColumnHeaderStyle.None
        tipInfo.SetImage(LVIDs, Nothing)
        LVIDs.Location = New Point(15, 61)
        LVIDs.Margin = New Padding(4)
        LVIDs.Name = "LVIDs"
        LVIDs.Size = New Size(498, 256)
        LVIDs.TabIndex = 10
        tipInfo.SetText(LVIDs, Nothing)
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
        tipInfo.SetImage(PicBoxArt, Nothing)
        PicBoxArt.Location = New Point(13, 326)
        PicBoxArt.Margin = New Padding(4)
        PicBoxArt.Name = "PicBoxArt"
        PicBoxArt.Size = New Size(776, 622)
        PicBoxArt.SizeMode = PictureBoxSizeMode.Zoom
        PicBoxArt.TabIndex = 2
        PicBoxArt.TabStop = False
        tipInfo.SetText(PicBoxArt, "Selected Image")
        ' 
        ' BtnOK
        ' 
        BtnOK.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        BtnOK.Image = My.Resources.Resources.ImageOK96
        tipInfo.SetImage(BtnOK, Nothing)
        BtnOK.Location = New Point(725, 254)
        BtnOK.Margin = New Padding(4)
        BtnOK.Name = "BtnOK"
        BtnOK.Size = New Size(64, 64)
        BtnOK.TabIndex = 30
        tipInfo.SetText(BtnOK, "Insert Image as Art")
        BtnOK.UseVisualStyleBackColor = True
        ' 
        ' PicBoxBackThumb
        ' 
        PicBoxBackThumb.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        tipInfo.SetImage(PicBoxBackThumb, Nothing)
        PicBoxBackThumb.Location = New Point(660, 61)
        PicBoxBackThumb.Margin = New Padding(4)
        PicBoxBackThumb.Name = "PicBoxBackThumb"
        PicBoxBackThumb.Size = New Size(129, 140)
        PicBoxBackThumb.SizeMode = PictureBoxSizeMode.Zoom
        PicBoxBackThumb.TabIndex = 4
        PicBoxBackThumb.TabStop = False
        tipInfo.SetText(PicBoxBackThumb, "Back Cover Thumbnail, Click to Select")
        ' 
        ' PicBoxFrontThumb
        ' 
        PicBoxFrontThumb.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        tipInfo.SetImage(PicBoxFrontThumb, Nothing)
        PicBoxFrontThumb.Location = New Point(521, 61)
        PicBoxFrontThumb.Margin = New Padding(4)
        PicBoxFrontThumb.Name = "PicBoxFrontThumb"
        PicBoxFrontThumb.Size = New Size(129, 140)
        PicBoxFrontThumb.SizeMode = PictureBoxSizeMode.Zoom
        PicBoxFrontThumb.TabIndex = 5
        PicBoxFrontThumb.TabStop = False
        tipInfo.SetText(PicBoxFrontThumb, "Front Cover Thumbnail, Click to Select")
        ' 
        ' LblStatus
        ' 
        LblStatus.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        LblStatus.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LblStatus.ForeColor = Color.Red
        tipInfo.SetImage(LblStatus, Nothing)
        LblStatus.Location = New Point(522, 33)
        LblStatus.Margin = New Padding(4, 0, 4, 0)
        LblStatus.Name = "LblStatus"
        LblStatus.Size = New Size(265, 23)
        LblStatus.TabIndex = 8
        LblStatus.Text = "Downloading Art..."
        tipInfo.SetText(LblStatus, Nothing)
        LblStatus.TextAlign = ContentAlignment.MiddleCenter
        LblStatus.Visible = False
        ' 
        ' TxtBoxSearchPhrase
        ' 
        TxtBoxSearchPhrase.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        tipInfo.SetImage(TxtBoxSearchPhrase, Nothing)
        TxtBoxSearchPhrase.Location = New Point(121, 18)
        TxtBoxSearchPhrase.Margin = New Padding(4)
        TxtBoxSearchPhrase.Name = "TxtBoxSearchPhrase"
        TxtBoxSearchPhrase.Size = New Size(392, 29)
        TxtBoxSearchPhrase.TabIndex = 5
        tipInfo.SetText(TxtBoxSearchPhrase, Nothing)
        ' 
        ' BtnSaveArt
        ' 
        BtnSaveArt.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        BtnSaveArt.Enabled = False
        BtnSaveArt.Image = My.Resources.Resources.ImageSave64
        tipInfo.SetImage(BtnSaveArt, Nothing)
        BtnSaveArt.Location = New Point(521, 254)
        BtnSaveArt.Margin = New Padding(4)
        BtnSaveArt.Name = "BtnSaveArt"
        BtnSaveArt.Size = New Size(64, 64)
        BtnSaveArt.TabIndex = 20
        tipInfo.SetText(BtnSaveArt, "Save Image to File")
        BtnSaveArt.UseVisualStyleBackColor = True
        ' 
        ' LblDimFront
        ' 
        LblDimFront.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        LblDimFront.Font = New Font("Segoe UI", 9.75F)
        tipInfo.SetImage(LblDimFront, Nothing)
        LblDimFront.Location = New Point(522, 194)
        LblDimFront.Margin = New Padding(4, 0, 4, 0)
        LblDimFront.Name = "LblDimFront"
        LblDimFront.Size = New Size(128, 28)
        LblDimFront.TabIndex = 101
        LblDimFront.Text = "W x H"
        tipInfo.SetText(LblDimFront, Nothing)
        LblDimFront.TextAlign = ContentAlignment.TopCenter
        ' 
        ' LblDimBack
        ' 
        LblDimBack.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        LblDimBack.Font = New Font("Segoe UI", 9.75F)
        tipInfo.SetImage(LblDimBack, Nothing)
        LblDimBack.Location = New Point(660, 194)
        LblDimBack.Margin = New Padding(4, 0, 4, 0)
        LblDimBack.Name = "LblDimBack"
        LblDimBack.Size = New Size(129, 28)
        LblDimBack.TabIndex = 102
        LblDimBack.Text = "W x H"
        tipInfo.SetText(LblDimBack, Nothing)
        LblDimBack.TextAlign = ContentAlignment.TopCenter
        ' 
        ' LblSearchPhrase
        ' 
        tipInfo.SetImage(LblSearchPhrase, Nothing)
        LblSearchPhrase.Location = New Point(15, 15)
        LblSearchPhrase.Margin = New Padding(4, 0, 4, 0)
        LblSearchPhrase.Name = "LblSearchPhrase"
        LblSearchPhrase.Size = New Size(121, 32)
        LblSearchPhrase.TabIndex = 103
        LblSearchPhrase.Text = "Search Phrase:"
        tipInfo.SetText(LblSearchPhrase, Nothing)
        LblSearchPhrase.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' tipInfo
        ' 
        tipInfo.BackColor = Color.White
        tipInfo.BorderColor = Color.Gainsboro
        tipInfo.BorderThickness = 2
        tipInfo.FadeInRate = 25
        tipInfo.FadeOutRate = 25
        tipInfo.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        tipInfo.ShadowAlpha = 0
        tipInfo.ShadowThickness = 0
        tipInfo.ShowDelay = 100
        ' 
        ' SelectOnlineImage
        ' 
        AutoScaleDimensions = New SizeF(9F, 21F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(802, 961)
        Controls.Add(LblDimBack)
        Controls.Add(LblDimFront)
        Controls.Add(LblStatus)
        Controls.Add(BtnSaveArt)
        Controls.Add(TxtBoxSearchPhrase)
        Controls.Add(PicBoxFrontThumb)
        Controls.Add(PicBoxBackThumb)
        Controls.Add(BtnOK)
        Controls.Add(PicBoxArt)
        Controls.Add(LVIDs)
        Controls.Add(LblSearchPhrase)
        Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        tipInfo.SetImage(Me, Nothing)
        Margin = New Padding(4)
        MinimumSize = New Size(638, 684)
        Name = "SelectOnlineImage"
        StartPosition = FormStartPosition.CenterScreen
        tipInfo.SetText(Me, Nothing)
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
    Friend WithEvents tipInfo As Skye.UI.ToolTipEX
End Class
