<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Max7456Panel
    Inherits System.Windows.Forms.UserControl

    'Пользовательский элемент управления (UserControl) переопределяет метод Dispose для очистки списка компонентов.
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

    'Является обязательной для конструктора форм Windows Forms
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
    'Для ее изменения используйте конструктор форм Windows Form.  
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.txt = New System.Windows.Forms.Label()
        Me.ContextMenuPanel = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PasteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.WriteToMAX7456ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReadFromMAX7456ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'txt
        '
        Me.txt.AutoSize = True
        Me.txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txt.Location = New System.Drawing.Point(28, 17)
        Me.txt.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.txt.Name = "txt"
        Me.txt.Size = New System.Drawing.Size(49, 16)
        Me.txt.TabIndex = 0
        Me.txt.Text = "Label1"
        Me.txt.Visible = False
        '
        'ContextMenuPanel
        '
        Me.ContextMenuPanel.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyToolStripMenuItem, Me.PasteToolStripMenuItem, Me.ToolStripSeparator1, Me.WriteToMAX7456ToolStripMenuItem, Me.ReadFromMAX7456ToolStripMenuItem})
        Me.ContextMenuPanel.Name = "ContextMenuPanel"
        Me.ContextMenuPanel.Size = New System.Drawing.Size(183, 120)
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(182, 22)
        Me.CopyToolStripMenuItem.Text = "Copy"
        '
        'PasteToolStripMenuItem
        '
        Me.PasteToolStripMenuItem.Enabled = False
        Me.PasteToolStripMenuItem.Name = "PasteToolStripMenuItem"
        Me.PasteToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys)
        Me.PasteToolStripMenuItem.Size = New System.Drawing.Size(182, 22)
        Me.PasteToolStripMenuItem.Text = "Paste"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(179, 6)
        '
        'WriteToMAX7456ToolStripMenuItem
        '
        Me.WriteToMAX7456ToolStripMenuItem.Name = "WriteToMAX7456ToolStripMenuItem"
        Me.WriteToMAX7456ToolStripMenuItem.Size = New System.Drawing.Size(182, 22)
        Me.WriteToMAX7456ToolStripMenuItem.Text = "Write to MAX7456"
        '
        'ReadFromMAX7456ToolStripMenuItem
        '
        Me.ReadFromMAX7456ToolStripMenuItem.Name = "ReadFromMAX7456ToolStripMenuItem"
        Me.ReadFromMAX7456ToolStripMenuItem.Size = New System.Drawing.Size(182, 22)
        Me.ReadFromMAX7456ToolStripMenuItem.Text = "Read from MAX7456"
        '
        'Max7456Panel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8!, 16!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.Controls.Add(Me.txt)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204,Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Max7456Panel"
        Me.Size = New System.Drawing.Size(817, 820)
        Me.ContextMenuPanel.ResumeLayout(false)
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents txt As System.Windows.Forms.Label
    Friend WithEvents ContextMenuPanel As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CopyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PasteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents WriteToMAX7456ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReadFromMAX7456ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
