<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        Me.components = New System.ComponentModel.Container()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.GoogleOCRToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OCRToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyToClipboardToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ReselectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DiscardToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Pan = New System.Windows.Forms.Panel()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GoogleOCRToolStripMenuItem, Me.OCRToolStripMenuItem, Me.CopyToClipboardToolStripMenuItem, Me.SaveToFileToolStripMenuItem, Me.ToolStripSeparator1, Me.ReselectToolStripMenuItem, Me.DiscardToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(172, 142)
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
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(168, 6)
        '
        'ReselectToolStripMenuItem
        '
        Me.ReselectToolStripMenuItem.Name = "ReselectToolStripMenuItem"
        Me.ReselectToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.ReselectToolStripMenuItem.Text = "Reselect"
        '
        'DiscardToolStripMenuItem
        '
        Me.DiscardToolStripMenuItem.Name = "DiscardToolStripMenuItem"
        Me.DiscardToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.DiscardToolStripMenuItem.Text = "Discard"
        '
        'Pan
        '
        Me.Pan.Location = New System.Drawing.Point(0, 0)
        Me.Pan.Name = "Pan"
        Me.Pan.Size = New System.Drawing.Size(200, 100)
        Me.Pan.TabIndex = 1
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.Pan)
        Me.Name = "Form2"
        Me.Text = "Form2"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents OCRToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CopyToClipboardToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveToFileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ReselectToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DiscardToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GoogleOCRToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Pan As Panel
End Class
