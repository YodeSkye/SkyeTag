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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SelectOnlineImage))
        LVIDs = New ListView()
        ColumnHeader1 = New ColumnHeader()
        PicBoxArt = New PictureBox()
        BtnOK = New Button()
        PicBoxBackThumb = New PictureBox()
        PicBoxFrontThumb = New PictureBox()
        LblDimFront = New Label()
        LblDimBack = New Label()
        LblStatus = New Label()
        LblSearchPhrase = New Label()
        TxtBoxSearchPhrase = New TextBox()
        LblSizeFront = New Label()
        LblSizeBack = New Label()
        BtnSaveArt = New Button()
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
        LVIDs.Location = New Point(12, 43)
        LVIDs.Name = "LVIDs"
        LVIDs.Size = New Size(544, 201)
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
        PicBoxArt.Location = New Point(12, 250)
        PicBoxArt.Name = "PicBoxArt"
        PicBoxArt.Size = New Size(756, 724)
        PicBoxArt.SizeMode = PictureBoxSizeMode.Zoom
        PicBoxArt.TabIndex = 2
        PicBoxArt.TabStop = False
        ' 
        ' BtnOK
        ' 
        BtnOK.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        BtnOK.Image = My.Resources.Resources.ImageOK64
        BtnOK.Location = New Point(704, 180)
        BtnOK.Name = "BtnOK"
        BtnOK.Size = New Size(64, 64)
        BtnOK.TabIndex = 30
        BtnOK.UseVisualStyleBackColor = True
        ' 
        ' PicBoxBackThumb
        ' 
        PicBoxBackThumb.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        PicBoxBackThumb.Location = New Point(668, 14)
        PicBoxBackThumb.Name = "PicBoxBackThumb"
        PicBoxBackThumb.Size = New Size(100, 100)
        PicBoxBackThumb.SizeMode = PictureBoxSizeMode.Zoom
        PicBoxBackThumb.TabIndex = 4
        PicBoxBackThumb.TabStop = False
        ' 
        ' PicBoxFrontThumb
        ' 
        PicBoxFrontThumb.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        PicBoxFrontThumb.Location = New Point(562, 14)
        PicBoxFrontThumb.Name = "PicBoxFrontThumb"
        PicBoxFrontThumb.Size = New Size(100, 100)
        PicBoxFrontThumb.SizeMode = PictureBoxSizeMode.Zoom
        PicBoxFrontThumb.TabIndex = 5
        PicBoxFrontThumb.TabStop = False
        ' 
        ' LblDimFront
        ' 
        LblDimFront.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        LblDimFront.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LblDimFront.Location = New Point(562, 114)
        LblDimFront.Name = "LblDimFront"
        LblDimFront.Size = New Size(100, 20)
        LblDimFront.TabIndex = 6
        LblDimFront.Text = "W x H"
        LblDimFront.TextAlign = ContentAlignment.TopCenter
        ' 
        ' LblDimBack
        ' 
        LblDimBack.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        LblDimBack.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LblDimBack.Location = New Point(668, 114)
        LblDimBack.Name = "LblDimBack"
        LblDimBack.Size = New Size(100, 20)
        LblDimBack.TabIndex = 7
        LblDimBack.Text = "W x H"
        LblDimBack.TextAlign = ContentAlignment.TopCenter
        ' 
        ' LblStatus
        ' 
        LblStatus.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        LblStatus.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LblStatus.ForeColor = Color.Red
        LblStatus.Location = New Point(562, 160)
        LblStatus.Name = "LblStatus"
        LblStatus.Size = New Size(206, 17)
        LblStatus.TabIndex = 8
        LblStatus.Text = "Downloading Art..."
        LblStatus.TextAlign = ContentAlignment.MiddleCenter
        LblStatus.Visible = False
        ' 
        ' LblSearchPhrase
        ' 
        LblSearchPhrase.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LblSearchPhrase.Location = New Point(13, 13)
        LblSearchPhrase.Name = "LblSearchPhrase"
        LblSearchPhrase.Size = New Size(94, 23)
        LblSearchPhrase.TabIndex = 9
        LblSearchPhrase.Text = "Search Phrase:"
        LblSearchPhrase.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' TxtBoxSearchPhrase
        ' 
        TxtBoxSearchPhrase.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TxtBoxSearchPhrase.Location = New Point(107, 12)
        TxtBoxSearchPhrase.Name = "TxtBoxSearchPhrase"
        TxtBoxSearchPhrase.Size = New Size(450, 25)
        TxtBoxSearchPhrase.TabIndex = 100
        ' 
        ' LblSizeFront
        ' 
        LblSizeFront.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        LblSizeFront.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LblSizeFront.Location = New Point(562, 129)
        LblSizeFront.Name = "LblSizeFront"
        LblSizeFront.Size = New Size(100, 20)
        LblSizeFront.TabIndex = 31
        LblSizeFront.Text = "Size"
        LblSizeFront.TextAlign = ContentAlignment.TopCenter
        ' 
        ' LblSizeBack
        ' 
        LblSizeBack.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        LblSizeBack.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LblSizeBack.Location = New Point(668, 129)
        LblSizeBack.Name = "LblSizeBack"
        LblSizeBack.Size = New Size(100, 20)
        LblSizeBack.TabIndex = 32
        LblSizeBack.Text = "Size"
        LblSizeBack.TextAlign = ContentAlignment.TopCenter
        ' 
        ' BtnSaveArt
        ' 
        BtnSaveArt.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        BtnSaveArt.Enabled = False
        BtnSaveArt.Image = My.Resources.Resources.ImageSave64
        BtnSaveArt.Location = New Point(562, 180)
        BtnSaveArt.Name = "BtnSaveArt"
        BtnSaveArt.Size = New Size(64, 64)
        BtnSaveArt.TabIndex = 20
        BtnSaveArt.TabStop = False
        BtnSaveArt.UseVisualStyleBackColor = True
        ' 
        ' SelectImageOnline
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(780, 985)
        Controls.Add(BtnSaveArt)
        Controls.Add(TxtBoxSearchPhrase)
        Controls.Add(PicBoxFrontThumb)
        Controls.Add(PicBoxBackThumb)
        Controls.Add(BtnOK)
        Controls.Add(PicBoxArt)
        Controls.Add(LVIDs)
        Controls.Add(LblStatus)
        Controls.Add(LblSearchPhrase)
        Controls.Add(LblDimBack)
        Controls.Add(LblDimFront)
        Controls.Add(LblSizeFront)
        Controls.Add(LblSizeBack)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MinimumSize = New Size(500, 500)
        Name = "SelectImageOnline"
        StartPosition = FormStartPosition.CenterParent
        Text = "Select Image Online (MusicBrainz)"
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
    Friend WithEvents LblDimFront As Label
    Friend WithEvents LblDimBack As Label
    Friend WithEvents LblStatus As Label
    Friend WithEvents LblSearchPhrase As Label
    Friend WithEvents TxtBoxSearchPhrase As TextBox
    Friend WithEvents LblSizeFront As Label
    Friend WithEvents LblSizeBack As Label
    Friend WithEvents BtnSaveArt As Button
End Class
