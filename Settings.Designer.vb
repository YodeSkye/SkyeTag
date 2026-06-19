Friend Partial Class Settings
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
    Private Sub InitializeComponent
        components = New ComponentModel.Container()
        btnClose = New Button()
        chkboxSaveMetrics = New CheckBox()
        tipInfo = New Skye.UI.ToolTipEX(components)
        CoBoxTheme = New Skye.UI.ComboBox()
        ChkBoxThemeAuto = New CheckBox()
        LblTheme = New Skye.UI.Label()
        SuspendLayout()
        ' 
        ' btnClose
        ' 
        btnClose.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        btnClose.FlatAppearance.BorderColor = SystemColors.Info
        btnClose.FlatAppearance.BorderSize = 2
        btnClose.FlatAppearance.MouseDownBackColor = Color.GhostWhite
        btnClose.FlatAppearance.MouseOverBackColor = SystemColors.Info
        btnClose.Image = My.Resources.Resources.ImageOK64
        tipInfo.SetImage(btnClose, Nothing)
        btnClose.Location = New Point(160, 142)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(64, 64)
        btnClose.TabIndex = 0
        tipInfo.SetText(btnClose, "Close (CtrlW)")
        btnClose.TextAlign = ContentAlignment.MiddleRight
        btnClose.UseMnemonic = False
        ' 
        ' chkboxSaveMetrics
        ' 
        tipInfo.SetImage(chkboxSaveMetrics, Nothing)
        chkboxSaveMetrics.Location = New Point(12, 12)
        chkboxSaveMetrics.Name = "chkboxSaveMetrics"
        chkboxSaveMetrics.Size = New Size(212, 26)
        chkboxSaveMetrics.TabIndex = 15
        tipInfo.SetText(chkboxSaveMetrics, "Save Window Location && Size On Exit")
        chkboxSaveMetrics.Text = "Save Window Metrics"
        chkboxSaveMetrics.TextAlign = ContentAlignment.BottomLeft
        chkboxSaveMetrics.UseVisualStyleBackColor = True
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
        ' CoBoxTheme
        ' 
        CoBoxTheme.DropDownStyle = ComboBoxStyle.DropDownList
        CoBoxTheme.FormattingEnabled = True
        tipInfo.SetImage(CoBoxTheme, Nothing)
        CoBoxTheme.Location = New Point(12, 71)
        CoBoxTheme.Name = "CoBoxTheme"
        CoBoxTheme.Size = New Size(152, 30)
        CoBoxTheme.TabIndex = 16
        tipInfo.SetText(CoBoxTheme, Nothing)
        ' 
        ' ChkBoxThemeAuto
        ' 
        ChkBoxThemeAuto.AutoSize = True
        tipInfo.SetImage(ChkBoxThemeAuto, Nothing)
        ChkBoxThemeAuto.Location = New Point(12, 101)
        ChkBoxThemeAuto.Name = "ChkBoxThemeAuto"
        ChkBoxThemeAuto.Size = New Size(182, 25)
        ChkBoxThemeAuto.TabIndex = 17
        tipInfo.SetText(ChkBoxThemeAuto, Nothing)
        ChkBoxThemeAuto.Text = "Theme With Windows"
        ChkBoxThemeAuto.UseVisualStyleBackColor = True
        ' 
        ' LblTheme
        ' 
        tipInfo.SetImage(LblTheme, Nothing)
        LblTheme.Location = New Point(12, 51)
        LblTheme.Name = "LblTheme"
        LblTheme.Size = New Size(100, 23)
        LblTheme.TabIndex = 18
        LblTheme.Text = "Theme"
        tipInfo.SetText(LblTheme, Nothing)
        ' 
        ' Settings
        ' 
        AutoScaleMode = AutoScaleMode.None
        AutoSizeMode = AutoSizeMode.GrowAndShrink
        ClientSize = New Size(384, 218)
        Controls.Add(CoBoxTheme)
        Controls.Add(btnClose)
        Controls.Add(chkboxSaveMetrics)
        Controls.Add(LblTheme)
        Controls.Add(ChkBoxThemeAuto)
        Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        FormBorderStyle = FormBorderStyle.FixedDialog
        Icon = My.Resources.Resources.iconApp
        tipInfo.SetImage(Me, Nothing)
        KeyPreview = True
        MaximizeBox = False
        MinimizeBox = False
        MinimumSize = New Size(400, 200)
        Name = "Settings"
        SizeGripStyle = SizeGripStyle.Hide
        StartPosition = FormStartPosition.Manual
        tipInfo.SetText(Me, Nothing)
        ResumeLayout(False)
        PerformLayout()

    End Sub
    Private WithEvents chkboxSaveMetrics As System.Windows.Forms.CheckBox
    Private WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents tipInfo As Skye.UI.ToolTipEX
    Friend WithEvents CoBoxTheme As Skye.UI.ComboBox
    Friend WithEvents ChkBoxThemeAuto As CheckBox
    Friend WithEvents LblTheme As Skye.UI.Label
End Class