<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Log
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Log))
        BtnDelete = New Button()
        BtnClose = New Button()
        Lblnfo = New Skye.UI.Label()
        tipInfo = New Skye.UI.ToolTipEX(components)
        LogViewer = New Skye.UI.Log.LogViewerControl()
        tipAlert = New Skye.UI.ToolTipEX(components)
        SuspendLayout()
        ' 
        ' BtnDelete
        ' 
        BtnDelete.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        tipAlert.SetImage(BtnDelete, Nothing)
        BtnDelete.Image = My.Resources.Resources.ImageDeleteLog32
        tipInfo.SetImage(BtnDelete, Nothing)
        BtnDelete.Location = New Point(13, 484)
        BtnDelete.Margin = New Padding(4, 3, 4, 3)
        BtnDelete.Name = "BtnDelete"
        BtnDelete.Size = New Size(48, 48)
        BtnDelete.TabIndex = 2
        BtnDelete.TabStop = False
        tipInfo.SetText(BtnDelete, "Delete Log")
        tipAlert.SetText(BtnDelete, Nothing)
        BtnDelete.UseVisualStyleBackColor = True
        ' 
        ' BtnClose
        ' 
        BtnClose.Anchor = AnchorStyles.Bottom
        tipAlert.SetImage(BtnClose, Nothing)
        BtnClose.Image = My.Resources.Resources.ImageOK96
        tipInfo.SetImage(BtnClose, Nothing)
        BtnClose.Location = New Point(434, 468)
        BtnClose.Margin = New Padding(4, 3, 4, 3)
        BtnClose.Name = "BtnClose"
        BtnClose.Size = New Size(64, 64)
        BtnClose.TabIndex = 3
        BtnClose.TabStop = False
        tipInfo.SetText(BtnClose, "Close (CtrlW)")
        tipAlert.SetText(BtnClose, Nothing)
        BtnClose.UseVisualStyleBackColor = True
        ' 
        ' Lblnfo
        ' 
        Lblnfo.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        tipAlert.SetImage(Lblnfo, Nothing)
        tipInfo.SetImage(Lblnfo, Nothing)
        Lblnfo.Location = New Point(14, 435)
        Lblnfo.Margin = New Padding(4, 0, 4, 0)
        Lblnfo.Name = "Lblnfo"
        Lblnfo.Size = New Size(905, 29)
        Lblnfo.TabIndex = 1
        tipInfo.SetText(Lblnfo, Nothing)
        Lblnfo.Text = "File Info"
        tipAlert.SetText(Lblnfo, Nothing)
        Lblnfo.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' tipInfo
        ' 
        tipInfo.BackColor = Color.White
        tipInfo.BorderColor = Color.Gainsboro
        tipInfo.BorderThickness = 2
        tipInfo.FadeInRate = 25
        tipInfo.FadeOutRate = 25
        tipInfo.Font = New Font("Segoe UI", 12F)
        tipInfo.ShadowAlpha = 0
        tipInfo.ShadowThickness = 0
        tipInfo.ShowDelay = 100
        ' 
        ' LogViewer
        ' 
        LogViewer.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        tipInfo.SetImage(LogViewer, Nothing)
        tipAlert.SetImage(LogViewer, Nothing)
        LogViewer.Location = New Point(13, 13)
        LogViewer.Margin = New Padding(4)
        LogViewer.Name = "LogViewer"
        LogViewer.Size = New Size(907, 418)
        LogViewer.TabIndex = 4
        tipInfo.SetText(LogViewer, Nothing)
        tipAlert.SetText(LogViewer, Nothing)
        ' 
        ' tipAlert
        ' 
        tipAlert.BackColor = Color.White
        tipAlert.BorderColor = Color.Gainsboro
        tipAlert.BorderThickness = 2
        tipAlert.FadeInRate = 25
        tipAlert.FadeOutRate = 25
        tipAlert.Font = New Font("Segoe UI", 12F)
        tipAlert.HideDelay = 5000
        tipAlert.ShadowAlpha = 0
        tipAlert.ShadowThickness = 0
        tipAlert.ShowDelay = 100
        ' 
        ' Log
        ' 
        AutoScaleDimensions = New SizeF(9F, 21F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(933, 544)
        Controls.Add(LogViewer)
        Controls.Add(BtnClose)
        Controls.Add(BtnDelete)
        Controls.Add(Lblnfo)
        Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        tipAlert.SetImage(Me, Nothing)
        tipInfo.SetImage(Me, Nothing)
        KeyPreview = True
        Margin = New Padding(4, 3, 4, 3)
        MinimumSize = New Size(697, 340)
        Name = "Log"
        StartPosition = FormStartPosition.Manual
        tipInfo.SetText(Me, Nothing)
        tipAlert.SetText(Me, Nothing)
        Text = "Log"
        ResumeLayout(False)

    End Sub

    Friend WithEvents Lblnfo As Skye.UI.Label
    Friend WithEvents BtnDelete As Button
    Friend WithEvents BtnClose As Button
    Friend WithEvents tipInfo As Skye.UI.ToolTipEX
    Friend WithEvents tipAlert As Skye.UI.ToolTipEX
    Friend WithEvents LogViewer As Skye.UI.Log.LogViewerControl
End Class
