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
        btnClose = New Button()
        tipInfo = New Skye.UI.ToolTip()
        chkboxSaveMetrics = New CheckBox()
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
        btnClose.Location = New Point(160, 88)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(64, 64)
        btnClose.TabIndex = 0
        btnClose.TextAlign = ContentAlignment.MiddleRight
        tipInfo.SetToolTip(btnClose, "Close (CtrlW)")
        tipInfo.SetToolTipIcon(btnClose, Nothing)
        btnClose.UseMnemonic = False
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
        ' chkboxSaveMetrics
        ' 
        chkboxSaveMetrics.Location = New Point(12, 12)
        chkboxSaveMetrics.Name = "chkboxSaveMetrics"
        chkboxSaveMetrics.Size = New Size(152, 21)
        chkboxSaveMetrics.TabIndex = 15
        chkboxSaveMetrics.Text = "Save Window Metrics"
        tipInfo.SetToolTip(chkboxSaveMetrics, "Save Window Location && Size On Exit")
        tipInfo.SetToolTipIcon(chkboxSaveMetrics, Nothing)
        chkboxSaveMetrics.UseVisualStyleBackColor = True
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
        KeyPreview = True
        MaximizeBox = False
        MinimizeBox = False
        MinimumSize = New Size(400, 200)
        Name = "Settings"
        SizeGripStyle = SizeGripStyle.Hide
        StartPosition = FormStartPosition.Manual
        tipInfo.SetToolTipIcon(Me, Nothing)
        ResumeLayout(False)

    End Sub
    Private WithEvents chkboxSaveMetrics As System.Windows.Forms.CheckBox
    Friend WithEvents tipInfo As Skye.UI.ToolTip
    Private WithEvents btnClose As System.Windows.Forms.Button
End Class