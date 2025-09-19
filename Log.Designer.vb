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
        tipInfo = New Skye.UI.ToolTip(components)
        TxbxSearch = New TextBox()
        LblSearch = New Skye.UI.Label()
        SuspendLayout()
        ' 
        ' RTxBoxLog
        ' 
        RTxBoxLog.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        RTxBoxLog.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        RTxBoxLog.Location = New Point(14, 36)
        RTxBoxLog.Margin = New Padding(4, 3, 4, 3)
        RTxBoxLog.Name = "RTxBoxLog"
        RTxBoxLog.ShortcutsEnabled = False
        RTxBoxLog.Size = New Size(905, 395)
        RTxBoxLog.TabIndex = 0
        RTxBoxLog.Text = ""
        tipInfo.SetToolTipIcon(RTxBoxLog, Nothing)
        RTxBoxLog.WordWrap = False
        ' 
        ' BtnDelete
        ' 
        BtnDelete.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        BtnDelete.Image = My.Resources.Resources.ImageDeleteLog32
        BtnDelete.Location = New Point(13, 484)
        BtnDelete.Margin = New Padding(4, 3, 4, 3)
        BtnDelete.Name = "BtnDelete"
        BtnDelete.Size = New Size(48, 48)
        BtnDelete.TabIndex = 2
        BtnDelete.TabStop = False
        tipInfo.SetToolTip(BtnDelete, "Delete Log")
        tipInfo.SetToolTipIcon(BtnDelete, Nothing)
        BtnDelete.UseVisualStyleBackColor = True
        ' 
        ' BtnClose
        ' 
        BtnClose.Anchor = AnchorStyles.Bottom
        BtnClose.Image = My.Resources.Resources.ImageOK64
        BtnClose.Location = New Point(434, 468)
        BtnClose.Margin = New Padding(4, 3, 4, 3)
        BtnClose.Name = "BtnClose"
        BtnClose.Size = New Size(64, 64)
        BtnClose.TabIndex = 3
        BtnClose.TabStop = False
        tipInfo.SetToolTip(BtnClose, "Close (CtrlW)")
        tipInfo.SetToolTipIcon(BtnClose, Nothing)
        BtnClose.UseVisualStyleBackColor = True
        ' 
        ' btnRefresh
        ' 
        btnRefresh.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnRefresh.Image = My.Resources.Resources.ImageRefreshLog32
        btnRefresh.Location = New Point(872, 484)
        btnRefresh.Margin = New Padding(4, 3, 4, 3)
        btnRefresh.Name = "btnRefresh"
        btnRefresh.Size = New Size(48, 48)
        btnRefresh.TabIndex = 4
        btnRefresh.TabStop = False
        tipInfo.SetToolTip(btnRefresh, "Refresh Log")
        tipInfo.SetToolTipIcon(btnRefresh, Nothing)
        btnRefresh.UseVisualStyleBackColor = True
        ' 
        ' Lblnfo
        ' 
        Lblnfo.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Lblnfo.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Lblnfo.Location = New Point(14, 435)
        Lblnfo.Margin = New Padding(4, 0, 4, 0)
        Lblnfo.Name = "Lblnfo"
        Lblnfo.Size = New Size(905, 29)
        Lblnfo.TabIndex = 1
        Lblnfo.Text = "File Info"
        Lblnfo.TextAlign = ContentAlignment.MiddleCenter
        tipInfo.SetToolTipIcon(Lblnfo, Nothing)
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
        ' TxbxSearch
        ' 
        TxbxSearch.BackColor = SystemColors.Control
        TxbxSearch.BorderStyle = BorderStyle.None
        TxbxSearch.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TxbxSearch.ForeColor = SystemColors.ControlDark
        TxbxSearch.Location = New Point(16, 13)
        TxbxSearch.Name = "TxbxSearch"
        TxbxSearch.Size = New Size(406, 18)
        TxbxSearch.TabIndex = 5
        TxbxSearch.Text = "Search Log"
        tipInfo.SetToolTipIcon(TxbxSearch, Nothing)
        ' 
        ' LblSearch
        ' 
        LblSearch.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        LblSearch.AutoSize = True
        LblSearch.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LblSearch.ForeColor = Color.Red
        LblSearch.Location = New Point(788, 13)
        LblSearch.Name = "LblSearch"
        LblSearch.Size = New Size(131, 17)
        LblSearch.TabIndex = 6
        LblSearch.Text = "Searching the Log..."
        LblSearch.TextAlign = ContentAlignment.MiddleRight
        tipInfo.SetToolTipIcon(LblSearch, Nothing)
        LblSearch.Visible = False
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
        KeyPreview = True
        Margin = New Padding(4, 3, 4, 3)
        MinimumSize = New Size(697, 340)
        Name = "Log"
        StartPosition = FormStartPosition.Manual
        Text = "Log"
        tipInfo.SetToolTipIcon(Me, Nothing)
        ResumeLayout(False)
        PerformLayout()

    End Sub

    Friend WithEvents Lblnfo As Skye.UI.Label
    Friend WithEvents RTxBoxLog As RichTextBox
    Friend WithEvents BtnDelete As Button
    Friend WithEvents BtnClose As Button
    Friend WithEvents btnRefresh As Button
    Friend WithEvents tipInfo As Skye.UI.ToolTip
    Friend WithEvents TxbxSearch As TextBox
    Friend WithEvents LblSearch As Skye.UI.Label
End Class
