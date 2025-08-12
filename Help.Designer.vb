<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Help
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Help))
        BtnClose = New Button()
        RTxBoxHelp = New RichTextBox()
        LblVersion = New My.Components.LabelCSY()
        SuspendLayout()
        ' 
        ' BtnClose
        ' 
        BtnClose.Anchor = AnchorStyles.Bottom
        BtnClose.Image = My.Resources.Resources.ImageOK64
        BtnClose.Location = New Point(434, 475)
        BtnClose.Margin = New Padding(4, 3, 4, 3)
        BtnClose.Name = "BtnClose"
        BtnClose.Size = New Size(64, 64)
        BtnClose.TabIndex = 2
        BtnClose.UseVisualStyleBackColor = True
        ' 
        ' RTxBoxHelp
        ' 
        RTxBoxHelp.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        RTxBoxHelp.BorderStyle = BorderStyle.None
        RTxBoxHelp.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        RTxBoxHelp.Location = New Point(14, 14)
        RTxBoxHelp.Margin = New Padding(4, 3, 4, 3)
        RTxBoxHelp.Name = "RTxBoxHelp"
        RTxBoxHelp.ReadOnly = True
        RTxBoxHelp.ShortcutsEnabled = False
        RTxBoxHelp.Size = New Size(905, 422)
        RTxBoxHelp.TabIndex = 3
        RTxBoxHelp.Text = ""
        ' 
        ' LblVersion
        ' 
        LblVersion.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        LblVersion.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LblVersion.Location = New Point(14, 442)
        LblVersion.Margin = New Padding(4, 0, 4, 0)
        LblVersion.Name = "LblVersion"
        LblVersion.Size = New Size(905, 25)
        LblVersion.TabIndex = 1
        LblVersion.Text = "LabelCSY2"
        LblVersion.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Help
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(933, 551)
        Controls.Add(RTxBoxHelp)
        Controls.Add(BtnClose)
        Controls.Add(LblVersion)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        KeyPreview = True
        Margin = New Padding(4, 3, 4, 3)
        MinimumSize = New Size(697, 340)
        Name = "Help"
        StartPosition = FormStartPosition.CenterParent
        Text = "Help & About"
        ResumeLayout(False)

    End Sub
    Friend WithEvents LblVersion As My.Components.LabelCSY
    Friend WithEvents BtnClose As Button
    Friend WithEvents RTxBoxHelp As RichTextBox
End Class
