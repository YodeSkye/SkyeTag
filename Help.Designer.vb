﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Help))
        BtnClose = New Button()
        RTxBoxHelp = New RichTextBox()
        LblVersion = New Skye.UI.Label()
        tipInfo = New Skye.UI.ToolTip(components)
        SuspendLayout()
        ' 
        ' BtnClose
        ' 
        BtnClose.Anchor = AnchorStyles.Bottom
        BtnClose.Image = My.Resources.Resources.ImageOK64
        BtnClose.Location = New Point(410, 375)
        BtnClose.Margin = New Padding(4, 3, 4, 3)
        BtnClose.Name = "BtnClose"
        BtnClose.Size = New Size(64, 73)
        BtnClose.TabIndex = 2
        tipInfo.SetToolTip(BtnClose, "Close (CtrlW)")
        tipInfo.SetToolTipIcon(BtnClose, Nothing)
        BtnClose.UseVisualStyleBackColor = True
        ' 
        ' RTxBoxHelp
        ' 
        RTxBoxHelp.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        RTxBoxHelp.BorderStyle = BorderStyle.None
        RTxBoxHelp.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        RTxBoxHelp.Location = New Point(14, 16)
        RTxBoxHelp.Margin = New Padding(4, 3, 4, 3)
        RTxBoxHelp.Name = "RTxBoxHelp"
        RTxBoxHelp.ReadOnly = True
        RTxBoxHelp.ShortcutsEnabled = False
        RTxBoxHelp.Size = New Size(856, 315)
        RTxBoxHelp.TabIndex = 3
        RTxBoxHelp.Text = ""
        tipInfo.SetToolTipIcon(RTxBoxHelp, Nothing)
        ' 
        ' LblVersion
        ' 
        LblVersion.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        LblVersion.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LblVersion.Location = New Point(14, 338)
        LblVersion.Margin = New Padding(4, 0, 4, 0)
        LblVersion.Name = "LblVersion"
        LblVersion.Size = New Size(856, 28)
        LblVersion.TabIndex = 1
        LblVersion.Text = "LabelCSY2"
        LblVersion.TextAlign = ContentAlignment.MiddleCenter
        tipInfo.SetToolTipIcon(LblVersion, Nothing)
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
        ' Help
        ' 
        AutoScaleDimensions = New SizeF(7F, 17F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(884, 461)
        Controls.Add(RTxBoxHelp)
        Controls.Add(BtnClose)
        Controls.Add(LblVersion)
        Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        KeyPreview = True
        Margin = New Padding(4, 3, 4, 3)
        MinimumSize = New Size(600, 300)
        Name = "Help"
        StartPosition = FormStartPosition.CenterParent
        Text = "Help & About"
        tipInfo.SetToolTipIcon(Me, Nothing)
        ResumeLayout(False)

    End Sub
    Friend WithEvents LblVersion As Skye.UI.Label
    Friend WithEvents BtnClose As Button
    Friend WithEvents RTxBoxHelp As RichTextBox
    Friend WithEvents tipInfo As Skye.UI.ToolTip
End Class
