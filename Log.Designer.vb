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
        RTxBoxLog = New RichTextBox()
        BtnDelete = New Button()
        BtnClose = New Button()
        btnRefresh = New Button()
        Lblnfo = New Skye.UI.Label()
        TxbxSearch = New TextBox()
        LblSearch = New Skye.UI.Label()
        tipInfo = New Skye.UI.ToolTipEX(components)
        tipAlert = New Skye.UI.ToolTipEX(components)
        SuspendLayout()
        ' 
        ' RTxBoxLog
        ' 
        RTxBoxLog.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        RTxBoxLog.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        tipAlert.SetImage(RTxBoxLog, Nothing)
        tipInfo.SetImage(RTxBoxLog, Nothing)
        RTxBoxLog.Location = New Point(14, 36)
        RTxBoxLog.Margin = New Padding(4, 3, 4, 3)
        RTxBoxLog.Name = "RTxBoxLog"
        RTxBoxLog.ShortcutsEnabled = False
        RTxBoxLog.Size = New Size(905, 395)
        RTxBoxLog.TabIndex = 0
        RTxBoxLog.Text = ""
        RTxBoxLog.WordWrap = False
        ' 
        ' BtnDelete
        ' 
        BtnDelete.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        BtnDelete.Image = My.Resources.Resources.ImageDeleteLog32
        tipInfo.SetImage(BtnDelete, Nothing)
        tipAlert.SetImage(BtnDelete, Nothing)
        BtnDelete.Location = New Point(13, 484)
        BtnDelete.Margin = New Padding(4, 3, 4, 3)
        BtnDelete.Name = "BtnDelete"
        BtnDelete.Size = New Size(48, 48)
        BtnDelete.TabIndex = 2
        BtnDelete.TabStop = False
        tipInfo.SetText(BtnDelete, "Delete Log")
        BtnDelete.UseVisualStyleBackColor = True
        ' 
        ' BtnClose
        ' 
        BtnClose.Anchor = AnchorStyles.Bottom
        BtnClose.Image = My.Resources.Resources.ImageOK64
        tipInfo.SetImage(BtnClose, Nothing)
        tipAlert.SetImage(BtnClose, Nothing)
        BtnClose.Location = New Point(434, 468)
        BtnClose.Margin = New Padding(4, 3, 4, 3)
        BtnClose.Name = "BtnClose"
        BtnClose.Size = New Size(64, 64)
        BtnClose.TabIndex = 3
        BtnClose.TabStop = False
        tipInfo.SetText(BtnClose, "Close (CtrlW)")
        BtnClose.UseVisualStyleBackColor = True
        ' 
        ' btnRefresh
        ' 
        btnRefresh.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnRefresh.Image = My.Resources.Resources.ImageRefreshLog32
        tipInfo.SetImage(btnRefresh, Nothing)
        tipAlert.SetImage(btnRefresh, Nothing)
        btnRefresh.Location = New Point(872, 484)
        btnRefresh.Margin = New Padding(4, 3, 4, 3)
        btnRefresh.Name = "btnRefresh"
        btnRefresh.Size = New Size(48, 48)
        btnRefresh.TabIndex = 4
        btnRefresh.TabStop = False
        tipInfo.SetText(btnRefresh, "Refresh Log")
        btnRefresh.UseVisualStyleBackColor = True
        ' 
        ' Lblnfo
        ' 
        Lblnfo.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Lblnfo.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        tipAlert.SetImage(Lblnfo, Nothing)
        tipInfo.SetImage(Lblnfo, Nothing)
        Lblnfo.Location = New Point(14, 435)
        Lblnfo.Margin = New Padding(4, 0, 4, 0)
        Lblnfo.Name = "Lblnfo"
        Lblnfo.Size = New Size(905, 29)
        Lblnfo.TabIndex = 1
        Lblnfo.Text = "File Info"
        Lblnfo.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' TxbxSearch
        ' 
        TxbxSearch.BackColor = SystemColors.Control
        TxbxSearch.BorderStyle = BorderStyle.None
        TxbxSearch.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TxbxSearch.ForeColor = SystemColors.ControlDark
        tipAlert.SetImage(TxbxSearch, Nothing)
        tipInfo.SetImage(TxbxSearch, Nothing)
        TxbxSearch.Location = New Point(16, 13)
        TxbxSearch.Name = "TxbxSearch"
        TxbxSearch.Size = New Size(406, 18)
        TxbxSearch.TabIndex = 5
        TxbxSearch.Text = "Search Log"
        ' 
        ' LblSearch
        ' 
        LblSearch.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        LblSearch.AutoSize = True
        LblSearch.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LblSearch.ForeColor = Color.Red
        tipAlert.SetImage(LblSearch, Nothing)
        tipInfo.SetImage(LblSearch, Nothing)
        LblSearch.Location = New Point(788, 13)
        LblSearch.Name = "LblSearch"
        LblSearch.Size = New Size(131, 17)
        LblSearch.TabIndex = 6
        LblSearch.Text = "Searching the Log..."
        LblSearch.TextAlign = ContentAlignment.MiddleRight
        LblSearch.Visible = False
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
        ' tipAlert
        ' 
        tipAlert.BackColor = Color.White
        tipAlert.BorderColor = Color.Gainsboro
        tipAlert.FadeInRate = 25
        tipAlert.FadeOutRate = 25
        tipAlert.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        tipAlert.HideDelay = 5000
        tipAlert.ShowBorder = False
        tipAlert.ShowDelay = 100
        ' 
        ' Log
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(933, 544)
        Controls.Add(LblSearch)
        Controls.Add(TxbxSearch)
        Controls.Add(btnRefresh)
        Controls.Add(BtnClose)
        Controls.Add(BtnDelete)
        Controls.Add(RTxBoxLog)
        Controls.Add(Lblnfo)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        tipAlert.SetImage(Me, Nothing)
        tipInfo.SetImage(Me, Nothing)
        KeyPreview = True
        Margin = New Padding(4, 3, 4, 3)
        MinimumSize = New Size(697, 340)
        Name = "Log"
        StartPosition = FormStartPosition.Manual
        Text = "Log"
        ResumeLayout(False)
        PerformLayout()

    End Sub

    Friend WithEvents Lblnfo As Skye.UI.Label
    Friend WithEvents RTxBoxLog As RichTextBox
    Friend WithEvents BtnDelete As Button
    Friend WithEvents BtnClose As Button
    Friend WithEvents btnRefresh As Button
    Friend WithEvents TxbxSearch As TextBox
    Friend WithEvents LblSearch As Skye.UI.Label
    Friend WithEvents tipInfo As Skye.UI.ToolTipEX
    Friend WithEvents tipAlert As Skye.UI.ToolTipEX
End Class
