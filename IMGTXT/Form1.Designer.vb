<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.IconMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CaptureToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NotifyIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.RightClickMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.GoogleOCRToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OCRToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyToClipboardToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.DiscardToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IconMenu.SuspendLayout()
        Me.RightClickMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'IconMenu
        '
        Me.IconMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CaptureToolStripMenuItem, Me.SettingsToolStripMenuItem, Me.ToolStripSeparator1, Me.ExitToolStripMenuItem})
        Me.IconMenu.Name = "ContextMenuStrip1"
        Me.IconMenu.Size = New System.Drawing.Size(118, 76)
        '
        'CaptureToolStripMenuItem
        '
        Me.CaptureToolStripMenuItem.Name = "CaptureToolStripMenuItem"
        Me.CaptureToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.CaptureToolStripMenuItem.Text = "Capture"
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.SettingsToolStripMenuItem.Text = "Settings"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(114, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.ExitToolStripMenuItem.Text = "Exit APP"
        '
        'NotifyIcon
        '
        Me.NotifyIcon.ContextMenuStrip = Me.IconMenu
        Me.NotifyIcon.Icon = CType(resources.GetObject("NotifyIcon.Icon"), System.Drawing.Icon)
        Me.NotifyIcon.Text = "NotifyIcon"
        Me.NotifyIcon.Visible = True
        '
        'RightClickMenu
        '
        Me.RightClickMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GoogleOCRToolStripMenuItem, Me.OCRToolStripMenuItem, Me.CopyToClipboardToolStripMenuItem, Me.SaveToFileToolStripMenuItem, Me.ToolStripSeparator2, Me.DiscardToolStripMenuItem})
        Me.RightClickMenu.Name = "ContextMenuStrip1"
        Me.RightClickMenu.Size = New System.Drawing.Size(172, 120)
        '
        'GoogleOCRToolStripMenuItem
        '
        Me.GoogleOCRToolStripMenuItem.Name = "GoogleOCRToolStripMenuItem"
        Me.GoogleOCRToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.GoogleOCRToolStripMenuItem.Text = "Google OCR"
        '
        'OCRToolStripMenuItem
        '
        Me.OCRToolStripMenuItem.Name = "OCRToolStripMenuItem"
        Me.OCRToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.OCRToolStripMenuItem.Text = "Baidu OCR"
        '
        'CopyToClipboardToolStripMenuItem
        '
        Me.CopyToClipboardToolStripMenuItem.Name = "CopyToClipboardToolStripMenuItem"
        Me.CopyToClipboardToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.CopyToClipboardToolStripMenuItem.Text = "Copy to Clipboard"
        '
        'SaveToFileToolStripMenuItem
        '
        Me.SaveToFileToolStripMenuItem.Name = "SaveToFileToolStripMenuItem"
        Me.SaveToFileToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.SaveToFileToolStripMenuItem.Text = "Save to file"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(168, 6)
        '
        'DiscardToolStripMenuItem
        '
        Me.DiscardToolStripMenuItem.Name = "DiscardToolStripMenuItem"
        Me.DiscardToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.DiscardToolStripMenuItem.Text = "Discard"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(134, 111)
        Me.ContextMenuStrip = Me.RightClickMenu
        Me.ControlBox = False
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.ShowIcon = False
        Me.TopMost = True
        Me.IconMenu.ResumeLayout(False)
        Me.RightClickMenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents IconMenu As ContextMenuStrip
    Friend WithEvents CaptureToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents SettingsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NotifyIcon As NotifyIcon
    Friend WithEvents RightClickMenu As ContextMenuStrip
    Friend WithEvents GoogleOCRToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OCRToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CopyToClipboardToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveToFileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents DiscardToolStripMenuItem As ToolStripMenuItem
End Class
