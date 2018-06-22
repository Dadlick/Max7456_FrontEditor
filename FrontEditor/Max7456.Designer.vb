<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Max7456
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
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SetAllWhiteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SetAllBlckToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SetAllTransparentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.InversrColorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.FlipVerticalyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FlipHorizontallyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SetAllWhiteToolStripMenuItem, Me.SetAllBlckToolStripMenuItem, Me.SetAllTransparentToolStripMenuItem, Me.ToolStripSeparator1, Me.InversrColorToolStripMenuItem, Me.ToolStripSeparator2, Me.FlipVerticalyToolStripMenuItem, Me.FlipHorizontallyToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(174, 170)
        '
        'SetAllWhiteToolStripMenuItem
        '
        Me.SetAllWhiteToolStripMenuItem.Name = "SetAllWhiteToolStripMenuItem"
        Me.SetAllWhiteToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.SetAllWhiteToolStripMenuItem.Text = "Set All White"
        '
        'SetAllBlckToolStripMenuItem
        '
        Me.SetAllBlckToolStripMenuItem.Name = "SetAllBlckToolStripMenuItem"
        Me.SetAllBlckToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.SetAllBlckToolStripMenuItem.Text = "Set All Black"
        '
        'SetAllTransparentToolStripMenuItem
        '
        Me.SetAllTransparentToolStripMenuItem.Name = "SetAllTransparentToolStripMenuItem"
        Me.SetAllTransparentToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.SetAllTransparentToolStripMenuItem.Text = "Set All Transparent"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(170, 6)
        '
        'InversrColorToolStripMenuItem
        '
        Me.InversrColorToolStripMenuItem.Name = "InversrColorToolStripMenuItem"
        Me.InversrColorToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.InversrColorToolStripMenuItem.Text = "Inverse Colors"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(170, 6)
        '
        'FlipVerticalyToolStripMenuItem
        '
        Me.FlipVerticalyToolStripMenuItem.Name = "FlipVerticalyToolStripMenuItem"
        Me.FlipVerticalyToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.FlipVerticalyToolStripMenuItem.Text = "Flip Vertically"
        '
        'FlipHorizontallyToolStripMenuItem
        '
        Me.FlipHorizontallyToolStripMenuItem.Name = "FlipHorizontallyToolStripMenuItem"
        Me.FlipHorizontallyToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.FlipHorizontallyToolStripMenuItem.Text = "Flip Horizontally"
        '
        'Max7456
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.Name = "Max7456"
        Me.Size = New System.Drawing.Size(148, 148)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents SetAllWhiteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SetAllBlckToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SetAllTransparentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents InversrColorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents FlipVerticalyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FlipHorizontallyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
