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
        GroupBox1 = New GroupBox()
        RadBtnImageFormatBMP = New RadioButton()
        RadBtnImageFormatPNG = New RadioButton()
        RadBtnImageFormatJPG = New RadioButton()
        TxtBoxFilename = New TextBox()
        LblFilename = New Label()
        LblLocation = New Label()
        TxtBoxLocation = New TextBox()
        BtnLocation = New Button()
        BtnSave = New Button()
        GroupBox1.SuspendLayout()
        SuspendLayout()
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(RadBtnImageFormatBMP)
        GroupBox1.Controls.Add(RadBtnImageFormatPNG)
        GroupBox1.Controls.Add(RadBtnImageFormatJPG)
        GroupBox1.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        GroupBox1.Location = New Point(12, 107)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(83, 120)
        GroupBox1.TabIndex = 0
        GroupBox1.TabStop = False
        GroupBox1.Text = "Format"
        ' 
        ' RadBtnImageFormatBMP
        ' 
        RadBtnImageFormatBMP.AutoSize = True
        RadBtnImageFormatBMP.Font = New Font("Segoe UI", 9.75F)
        RadBtnImageFormatBMP.Location = New Point(18, 82)
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
        RadBtnImageFormatPNG.Location = New Point(18, 53)
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
        RadBtnImageFormatJPG.Location = New Point(18, 25)
        RadBtnImageFormatJPG.Name = "RadBtnImageFormatJPG"
        RadBtnImageFormatJPG.Size = New Size(47, 21)
        RadBtnImageFormatJPG.TabIndex = 0
        RadBtnImageFormatJPG.TabStop = True
        RadBtnImageFormatJPG.Text = "JPG"
        RadBtnImageFormatJPG.UseVisualStyleBackColor = True
        ' 
        ' TxtBoxFilename
        ' 
        TxtBoxFilename.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TxtBoxFilename.Location = New Point(12, 27)
        TxtBoxFilename.Name = "TxtBoxFilename"
        TxtBoxFilename.Size = New Size(300, 25)
        TxtBoxFilename.TabIndex = 1
        ' 
        ' LblFilename
        ' 
        LblFilename.AutoSize = True
        LblFilename.Location = New Point(12, 9)
        LblFilename.Name = "LblFilename"
        LblFilename.Size = New Size(175, 17)
        LblFilename.TabIndex = 2
        LblFilename.Text = "Filename (Without Extension)"
        ' 
        ' LblLocation
        ' 
        LblLocation.AutoSize = True
        LblLocation.Location = New Point(12, 58)
        LblLocation.Name = "LblLocation"
        LblLocation.Size = New Size(57, 17)
        LblLocation.TabIndex = 4
        LblLocation.Text = "Location"
        ' 
        ' TxtBoxLocation
        ' 
        TxtBoxLocation.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TxtBoxLocation.Location = New Point(12, 76)
        TxtBoxLocation.Name = "TxtBoxLocation"
        TxtBoxLocation.Size = New Size(475, 25)
        TxtBoxLocation.TabIndex = 3
        ' 
        ' BtnLocation
        ' 
        BtnLocation.Image = My.Resources.Resources.imageOpenImage
        BtnLocation.Location = New Point(486, 72)
        BtnLocation.Name = "BtnLocation"
        BtnLocation.Size = New Size(32, 32)
        BtnLocation.TabIndex = 5
        BtnLocation.UseVisualStyleBackColor = True
        ' 
        ' BtnSave
        ' 
        BtnSave.Image = My.Resources.Resources.imageSave
        BtnSave.ImageAlign = ContentAlignment.MiddleLeft
        BtnSave.Location = New Point(11, 233)
        BtnSave.Name = "BtnSave"
        BtnSave.Size = New Size(84, 32)
        BtnSave.TabIndex = 6
        BtnSave.Text = "Save"
        BtnSave.TextAlign = ContentAlignment.MiddleRight
        BtnSave.UseVisualStyleBackColor = True
        ' 
        ' SaveOnlineImage
        ' 
        AutoScaleDimensions = New SizeF(7F, 17F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(527, 275)
        Controls.Add(BtnSave)
        Controls.Add(BtnLocation)
        Controls.Add(LblLocation)
        Controls.Add(TxtBoxLocation)
        Controls.Add(LblFilename)
        Controls.Add(TxtBoxFilename)
        Controls.Add(GroupBox1)
        Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        FormBorderStyle = FormBorderStyle.FixedDialog
        Name = "SaveOnlineImage"
        StartPosition = FormStartPosition.CenterParent
        Text = "Save Selected Image"
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents RadBtnImageFormatBMP As RadioButton
    Friend WithEvents RadBtnImageFormatPNG As RadioButton
    Friend WithEvents RadBtnImageFormatJPG As RadioButton
    Friend WithEvents TxtBoxFilename As TextBox
    Friend WithEvents LblFilename As Label
    Friend WithEvents LblLocation As Label
    Friend WithEvents TxtBoxLocation As TextBox
    Friend WithEvents BtnLocation As Button
    Friend WithEvents BtnSave As Button
End Class
