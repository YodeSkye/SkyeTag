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
        SuspendLayout()
        ' 
        ' btnClose
        ' 
        btnClose.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        btnClose.FlatAppearance.BorderColor = SystemColors.Info
        btnClose.FlatAppearance.BorderSize = 2
        btnClose.FlatAppearance.MouseDownBackColor = Color.GhostWhite
        btnClose.FlatAppearance.MouseOverBackColor = SystemColors.Info
        tipInfo.SetImage(btnClose, Nothing)
        btnClose.Image = My.Resources.Resources.ImageOK64
        btnClose.Location = New Point(160, 88)
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
        chkboxSaveMetrics.Size = New Size(152, 21)
        chkboxSaveMetrics.TabIndex = 15
        chkboxSaveMetrics.Text = "Save Window Metrics"
        tipInfo.SetText(chkboxSaveMetrics, "Save Window Location && Size On Exit")
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
        ' Settings
        ' 
        AutoScaleMode = AutoScaleMode.None
        AutoSizeMode = AutoSizeMode.GrowAndShrink
        ClientSize = New Size(384, 164)
        Controls.Add(btnClose)
        Controls.Add(chkboxSaveMetrics)
        Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
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
        ResumeLayout(False)

    End Sub
    Private WithEvents chkboxSaveMetrics As System.Windows.Forms.CheckBox
    Private WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents tipInfo As Skye.UI.ToolTipEX
End Class