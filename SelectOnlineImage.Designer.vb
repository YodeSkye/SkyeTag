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
        LblStatus = New Label()
        TxtBoxSearchPhrase = New TextBox()
        BtnSaveArt = New Button()
        LblDimFront = New My.Components.LabelCSY()
        LblDimBack = New My.Components.LabelCSY()
        LblSearchPhrase = New My.Components.LabelCSY()
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
        LVIDs.Size = New Size(388, 184)
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
        PicBoxArt.Location = New Point(12, 233)
        PicBoxArt.Name = "PicBoxArt"
        PicBoxArt.Size = New Size(600, 600)
        PicBoxArt.SizeMode = PictureBoxSizeMode.Zoom
        PicBoxArt.TabIndex = 2
        PicBoxArt.TabStop = False
        ' 
        ' BtnOK
        ' 
        BtnOK.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        BtnOK.Image = My.Resources.Resources.ImageOK64
        BtnOK.Location = New Point(548, 163)
        BtnOK.Name = "BtnOK"
        BtnOK.Size = New Size(64, 64)
        BtnOK.TabIndex = 30
        BtnOK.UseVisualStyleBackColor = True
        ' 
        ' PicBoxBackThumb
        ' 
        PicBoxBackThumb.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        PicBoxBackThumb.Location = New Point(512, 11)
        PicBoxBackThumb.Name = "PicBoxBackThumb"
        PicBoxBackThumb.Size = New Size(100, 100)
        PicBoxBackThumb.SizeMode = PictureBoxSizeMode.Zoom
        PicBoxBackThumb.TabIndex = 4
        PicBoxBackThumb.TabStop = False
        ' 
        ' PicBoxFrontThumb
        ' 
        PicBoxFrontThumb.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        PicBoxFrontThumb.Location = New Point(406, 12)
        PicBoxFrontThumb.Name = "PicBoxFrontThumb"
        PicBoxFrontThumb.Size = New Size(100, 100)
        PicBoxFrontThumb.SizeMode = PictureBoxSizeMode.Zoom
        PicBoxFrontThumb.TabIndex = 5
        PicBoxFrontThumb.TabStop = False
        ' 
        ' LblStatus
        ' 
        LblStatus.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        LblStatus.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LblStatus.ForeColor = Color.Red
        LblStatus.Location = New Point(406, 143)
        LblStatus.Name = "LblStatus"
        LblStatus.Size = New Size(206, 17)
        LblStatus.TabIndex = 8
        LblStatus.Text = "Downloading Art..."
        LblStatus.TextAlign = ContentAlignment.MiddleCenter
        LblStatus.Visible = False
        ' 
        ' TxtBoxSearchPhrase
        ' 
        TxtBoxSearchPhrase.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        TxtBoxSearchPhrase.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TxtBoxSearchPhrase.Location = New Point(107, 12)
        TxtBoxSearchPhrase.Name = "TxtBoxSearchPhrase"
        TxtBoxSearchPhrase.Size = New Size(293, 25)
        TxtBoxSearchPhrase.TabIndex = 100
        ' 
        ' BtnSaveArt
        ' 
        BtnSaveArt.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        BtnSaveArt.Enabled = False
        BtnSaveArt.Image = My.Resources.Resources.ImageSave64
        BtnSaveArt.Location = New Point(406, 163)
        BtnSaveArt.Name = "BtnSaveArt"
        BtnSaveArt.Size = New Size(64, 64)
        BtnSaveArt.TabIndex = 20
        BtnSaveArt.TabStop = False
        BtnSaveArt.UseVisualStyleBackColor = True
        ' 
        ' LblDimFront
        ' 
        LblDimFront.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        LblDimFront.Font = New Font("Segoe UI", 9.75F)
        LblDimFront.Location = New Point(406, 111)
        LblDimFront.Name = "LblDimFront"
        LblDimFront.Size = New Size(100, 20)
        LblDimFront.TabIndex = 101
        LblDimFront.Text = "W x H"
        LblDimFront.TextAlign = ContentAlignment.TopCenter
        ' 
        ' LblDimBack
        ' 
        LblDimBack.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        LblDimBack.Font = New Font("Segoe UI", 9.75F)
        LblDimBack.Location = New Point(512, 110)
        LblDimBack.Name = "LblDimBack"
        LblDimBack.Size = New Size(100, 20)
        LblDimBack.TabIndex = 102
        LblDimBack.Text = "W x H"
        LblDimBack.TextAlign = ContentAlignment.TopCenter
        ' 
        ' LblSearchPhrase
        ' 
        LblSearchPhrase.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LblSearchPhrase.Location = New Point(14, 13)
        LblSearchPhrase.Name = "LblSearchPhrase"
        LblSearchPhrase.Size = New Size(94, 23)
        LblSearchPhrase.TabIndex = 103
        LblSearchPhrase.Text = "Search Phrase:"
        LblSearchPhrase.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' SelectOnlineImage
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(624, 844)
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
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MinimumSize = New Size(500, 500)
        Name = "SelectOnlineImage"
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
    Friend WithEvents LblStatus As Label
    Friend WithEvents TxtBoxSearchPhrase As TextBox
    Friend WithEvents BtnSaveArt As Button
    Friend WithEvents LblDimFront As My.Components.LabelCSY
    Friend WithEvents LblDimBack As My.Components.LabelCSY
    Friend WithEvents LblSearchPhrase As My.Components.LabelCSY
End Class
