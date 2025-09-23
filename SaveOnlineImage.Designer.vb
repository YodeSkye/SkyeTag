<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SaveOnlineImage
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
        GroupBox1 = New GroupBox()
        RadBtnImageFormatBMP = New RadioButton()
        RadBtnImageFormatPNG = New RadioButton()
        RadBtnImageFormatJPG = New RadioButton()
        TxtBoxFilename = New TextBox()
        TxtBoxLocation = New TextBox()
        BtnLocation = New Button()
        BtnSave = New Button()
        LblFilename = New Skye.UI.Label()
        LblLocation = New Skye.UI.Label()
        PicBoxThumb = New PictureBox()
        tipInfo = New Skye.UI.ToolTipEX(components)
        GroupBox1.SuspendLayout()
        CType(PicBoxThumb, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(RadBtnImageFormatBMP)
        GroupBox1.Controls.Add(RadBtnImageFormatPNG)
        GroupBox1.Controls.Add(RadBtnImageFormatJPG)
        GroupBox1.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        tipInfo.SetImage(GroupBox1, Nothing)
        GroupBox1.Location = New Point(12, 107)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(83, 120)
        GroupBox1.TabIndex = 0
        GroupBox1.TabStop = False
        GroupBox1.Text = "Format"
        tipInfo.SetText(GroupBox1, "Select the File Format")
        ' 
        ' RadBtnImageFormatBMP
        ' 
        RadBtnImageFormatBMP.AutoSize = True
        RadBtnImageFormatBMP.Font = New Font("Segoe UI", 9.75F)
        tipInfo.SetImage(RadBtnImageFormatBMP, Nothing)
        RadBtnImageFormatBMP.Location = New Point(17, 82)
        RadBtnImageFormatBMP.Name = "RadBtnImageFormatBMP"
        RadBtnImageFormatBMP.Size = New Size(52, 21)
        RadBtnImageFormatBMP.TabIndex = 2
        RadBtnImageFormatBMP.TabStop = True
        RadBtnImageFormatBMP.Text = "BMP"
        RadBtnImageFormatBMP.UseVisualStyleBackColor = True
        ' 
        ' RadBtnImageFormatPNG
        ' 
        RadBtnImageFormatPNG.AutoSize = True
        RadBtnImageFormatPNG.Font = New Font("Segoe UI", 9.75F)
        tipInfo.SetImage(RadBtnImageFormatPNG, Nothing)
        RadBtnImageFormatPNG.Location = New Point(17, 53)
        RadBtnImageFormatPNG.Name = "RadBtnImageFormatPNG"
        RadBtnImageFormatPNG.Size = New Size(52, 21)
        RadBtnImageFormatPNG.TabIndex = 1
        RadBtnImageFormatPNG.TabStop = True
        RadBtnImageFormatPNG.Text = "PNG"
        RadBtnImageFormatPNG.UseVisualStyleBackColor = True
        ' 
        ' RadBtnImageFormatJPG
        ' 
        RadBtnImageFormatJPG.AutoSize = True
        RadBtnImageFormatJPG.Font = New Font("Segoe UI", 9.75F)
        tipInfo.SetImage(RadBtnImageFormatJPG, Nothing)
        RadBtnImageFormatJPG.Location = New Point(17, 25)
        RadBtnImageFormatJPG.Name = "RadBtnImageFormatJPG"
        RadBtnImageFormatJPG.Size = New Size(54, 21)
        RadBtnImageFormatJPG.TabIndex = 0
        RadBtnImageFormatJPG.TabStop = True
        RadBtnImageFormatJPG.Text = "JPEG"
        RadBtnImageFormatJPG.UseVisualStyleBackColor = True
        ' 
        ' TxtBoxFilename
        ' 
        TxtBoxFilename.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold)
        tipInfo.SetImage(TxtBoxFilename, Nothing)
        TxtBoxFilename.Location = New Point(12, 27)
        TxtBoxFilename.Name = "TxtBoxFilename"
        TxtBoxFilename.Size = New Size(174, 25)
        TxtBoxFilename.TabIndex = 1
        ' 
        ' TxtBoxLocation
        ' 
        TxtBoxLocation.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold)
        tipInfo.SetImage(TxtBoxLocation, Nothing)
        TxtBoxLocation.Location = New Point(12, 76)
        TxtBoxLocation.Name = "TxtBoxLocation"
        TxtBoxLocation.Size = New Size(296, 25)
        TxtBoxLocation.TabIndex = 3
        ' 
        ' BtnLocation
        ' 
        tipInfo.SetImage(BtnLocation, Nothing)
        BtnLocation.Image = My.Resources.Resources.imageOpenImage
        BtnLocation.Location = New Point(308, 72)
        BtnLocation.Name = "BtnLocation"
        BtnLocation.Size = New Size(32, 32)
        BtnLocation.TabIndex = 5
        tipInfo.SetText(BtnLocation, "Select a File Location")
        BtnLocation.UseVisualStyleBackColor = True
        ' 
        ' BtnSave
        ' 
        tipInfo.SetImage(BtnSave, Nothing)
        BtnSave.Image = My.Resources.Resources.imageSave
        BtnSave.ImageAlign = ContentAlignment.MiddleLeft
        BtnSave.Location = New Point(11, 233)
        BtnSave.Name = "BtnSave"
        BtnSave.Size = New Size(84, 32)
        BtnSave.TabIndex = 6
        tipInfo.SetText(BtnSave, "Save Image with the Selected Properties")
        BtnSave.Text = "Save"
        BtnSave.TextAlign = ContentAlignment.MiddleRight
        BtnSave.UseVisualStyleBackColor = True
        ' 
        ' LblFilename
        ' 
        LblFilename.AutoSize = True
        tipInfo.SetImage(LblFilename, Nothing)
        LblFilename.Location = New Point(12, 9)
        LblFilename.Name = "LblFilename"
        LblFilename.Size = New Size(175, 17)
        LblFilename.TabIndex = 7
        LblFilename.Text = "Filename (Without Extension)"
        ' 
        ' LblLocation
        ' 
        LblLocation.AutoSize = True
        tipInfo.SetImage(LblLocation, Nothing)
        LblLocation.Location = New Point(12, 58)
        LblLocation.Name = "LblLocation"
        LblLocation.Size = New Size(57, 17)
        LblLocation.TabIndex = 8
        LblLocation.Text = "Location"
        ' 
        ' PicBoxThumb
        ' 
        tipInfo.SetImage(PicBoxThumb, Nothing)
        PicBoxThumb.Location = New Point(187, 110)
        PicBoxThumb.Name = "PicBoxThumb"
        PicBoxThumb.Size = New Size(153, 153)
        PicBoxThumb.SizeMode = PictureBoxSizeMode.Zoom
        PicBoxThumb.TabIndex = 9
        PicBoxThumb.TabStop = False
        tipInfo.SetText(PicBoxThumb, "Thumbnail of Image to Save")
        ' 
        ' tipInfo
        ' 
        tipInfo.BackColor = Color.White
        tipInfo.BorderColor = Color.Gainsboro
        tipInfo.FadeInRate = 25
        tipInfo.FadeOutRate = 25
        tipInfo.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        tipInfo.ShowBorder = False
        tipInfo.ShowDelay = 100
        ' 
        ' SaveOnlineImage
        ' 
        AutoScaleDimensions = New SizeF(7F, 17F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(352, 275)
        Controls.Add(PicBoxThumb)
        Controls.Add(BtnSave)
        Controls.Add(BtnLocation)
        Controls.Add(TxtBoxLocation)
        Controls.Add(TxtBoxFilename)
        Controls.Add(GroupBox1)
        Controls.Add(LblFilename)
        Controls.Add(LblLocation)
        Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        FormBorderStyle = FormBorderStyle.FixedDialog
        tipInfo.SetImage(Me, Nothing)
        Name = "SaveOnlineImage"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Save Selected Image"
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        CType(PicBoxThumb, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents RadBtnImageFormatBMP As RadioButton
    Friend WithEvents RadBtnImageFormatPNG As RadioButton
    Friend WithEvents RadBtnImageFormatJPG As RadioButton
    Friend WithEvents TxtBoxFilename As TextBox
    Friend WithEvents TxtBoxLocation As TextBox
    Friend WithEvents BtnLocation As Button
    Friend WithEvents BtnSave As Button
    Friend WithEvents LblFilename As Skye.UI.Label
    Friend WithEvents LblLocation As Skye.UI.Label
    Friend WithEvents PicBoxThumb As PictureBox
    Friend WithEvents tipInfo As Skye.UI.ToolTipEX
End Class
