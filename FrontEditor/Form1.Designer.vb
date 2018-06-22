<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Форма переопределяет dispose для очистки списка компонентов.
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
    ' <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.CharacterListGroup = New System.Windows.Forms.GroupBox()
        Me.Max7456Panel1 = New FrontEditor.Max7456Panel()
        Me.EditCharacterGroup = New System.Windows.Forms.GroupBox()
        Me.SaveCharacter = New System.Windows.Forms.Button()
        Me.Max7456TransparentBtn = New System.Windows.Forms.PictureBox()
        Me.Max7456BlackBtn = New System.Windows.Forms.PictureBox()
        Me.Max7456WhiteBtn = New System.Windows.Forms.PictureBox()
        Me.Max74561 = New FrontEditor.Max7456()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveAsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CharacterListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PasteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MAX7456ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReadFromMAX7456CharacterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReadFromMAX7456AllCharacterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.WriteToMAX7456CharacterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WriteToMAX7456AllCharacterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ShowAllCharacterMAX7456ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.UpdateFrToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.CharacterPreviewBox = New System.Windows.Forms.GroupBox()
        Me.ClearCharacterPreview = New System.Windows.Forms.Button()
        Me.CharacterFix = New System.Windows.Forms.CheckBox()
        Me.ShowGrid = New System.Windows.Forms.CheckBox()
        Me.ScalleBox = New System.Windows.Forms.ComboBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Port = New System.Windows.Forms.ComboBox()
        Me.StatusPanel = New System.Windows.Forms.Panel()
        Me.Status = New System.Windows.Forms.Label()
        Me.StatusProgress = New System.Windows.Forms.ProgressBar()
        Me.CharacterListGroup.SuspendLayout()
        Me.EditCharacterGroup.SuspendLayout()
        CType(Me.Max7456TransparentBtn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Max7456BlackBtn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Max7456WhiteBtn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.CharacterPreviewBox.SuspendLayout()
        Me.StatusPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'CharacterListGroup
        '
        Me.CharacterListGroup.Controls.Add(Me.Max7456Panel1)
        Me.CharacterListGroup.Location = New System.Drawing.Point(0, 25)
        Me.CharacterListGroup.Name = "CharacterListGroup"
        Me.CharacterListGroup.Size = New System.Drawing.Size(340, 506)
        Me.CharacterListGroup.TabIndex = 6
        Me.CharacterListGroup.TabStop = False
        Me.CharacterListGroup.Text = "Character List"
        '
        'Max7456Panel1
        '
        Me.Max7456Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Max7456Panel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Max7456Panel1.Location = New System.Drawing.Point(0, 14)
        Me.Max7456Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Max7456Panel1.Name = "Max7456Panel1"
        Me.Max7456Panel1.Size = New System.Drawing.Size(338, 491)
        Me.Max7456Panel1.TabIndex = 2
        '
        'EditCharacterGroup
        '
        Me.EditCharacterGroup.Controls.Add(Me.SaveCharacter)
        Me.EditCharacterGroup.Controls.Add(Me.Max7456TransparentBtn)
        Me.EditCharacterGroup.Controls.Add(Me.Max7456BlackBtn)
        Me.EditCharacterGroup.Controls.Add(Me.Max7456WhiteBtn)
        Me.EditCharacterGroup.Controls.Add(Me.Max74561)
        Me.EditCharacterGroup.Enabled = False
        Me.EditCharacterGroup.Location = New System.Drawing.Point(345, 25)
        Me.EditCharacterGroup.Name = "EditCharacterGroup"
        Me.EditCharacterGroup.Size = New System.Drawing.Size(190, 506)
        Me.EditCharacterGroup.TabIndex = 7
        Me.EditCharacterGroup.TabStop = False
        Me.EditCharacterGroup.Text = "Edit Character:"
        '
        'SaveCharacter
        '
        Me.SaveCharacter.Location = New System.Drawing.Point(14, 460)
        Me.SaveCharacter.Name = "SaveCharacter"
        Me.SaveCharacter.Size = New System.Drawing.Size(161, 36)
        Me.SaveCharacter.TabIndex = 1
        Me.SaveCharacter.Text = "Save Character"
        Me.SaveCharacter.UseVisualStyleBackColor = True
        '
        'Max7456TransparentBtn
        '
        Me.Max7456TransparentBtn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Max7456TransparentBtn.Location = New System.Drawing.Point(125, 300)
        Me.Max7456TransparentBtn.Name = "Max7456TransparentBtn"
        Me.Max7456TransparentBtn.Size = New System.Drawing.Size(36, 36)
        Me.Max7456TransparentBtn.TabIndex = 3
        Me.Max7456TransparentBtn.TabStop = False
        '
        'Max7456BlackBtn
        '
        Me.Max7456BlackBtn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Max7456BlackBtn.Location = New System.Drawing.Point(73, 300)
        Me.Max7456BlackBtn.Name = "Max7456BlackBtn"
        Me.Max7456BlackBtn.Size = New System.Drawing.Size(36, 36)
        Me.Max7456BlackBtn.TabIndex = 2
        Me.Max7456BlackBtn.TabStop = False
        '
        'Max7456WhiteBtn
        '
        Me.Max7456WhiteBtn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Max7456WhiteBtn.Location = New System.Drawing.Point(21, 300)
        Me.Max7456WhiteBtn.Name = "Max7456WhiteBtn"
        Me.Max7456WhiteBtn.Size = New System.Drawing.Size(36, 36)
        Me.Max7456WhiteBtn.TabIndex = 1
        Me.Max7456WhiteBtn.TabStop = False
        '
        'Max74561
        '
        Me.Max74561.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Max74561.EditorColor = FrontEditor.Max7456.PointColorEditor.All
        Me.Max74561.Location = New System.Drawing.Point(3, 16)
        Me.Max74561.Margin = New System.Windows.Forms.Padding(0)
        Me.Max74561.Name = "Max74561"
        Me.Max74561.PointBorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Max74561.PointSize = 15
        Me.Max74561.Size = New System.Drawing.Size(180, 270)
        Me.Max74561.TabIndex = 0
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.CharacterListToolStripMenuItem, Me.MAX7456ToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1008, 24)
        Me.MenuStrip1.TabIndex = 8
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripMenuItem, Me.SaveToolStripMenuItem, Me.SaveAsToolStripMenuItem})
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(37, 20)
        Me.ToolStripMenuItem1.Text = "File"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(123, 22)
        Me.OpenToolStripMenuItem.Text = "Open"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(123, 22)
        Me.SaveToolStripMenuItem.Text = "Save"
        '
        'SaveAsToolStripMenuItem
        '
        Me.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem"
        Me.SaveAsToolStripMenuItem.Size = New System.Drawing.Size(123, 22)
        Me.SaveAsToolStripMenuItem.Text = "Save As..."
        '
        'CharacterListToolStripMenuItem
        '
        Me.CharacterListToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyToolStripMenuItem, Me.PasteToolStripMenuItem})
        Me.CharacterListToolStripMenuItem.Enabled = False
        Me.CharacterListToolStripMenuItem.Name = "CharacterListToolStripMenuItem"
        Me.CharacterListToolStripMenuItem.Size = New System.Drawing.Size(91, 20)
        Me.CharacterListToolStripMenuItem.Text = "Character List"
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
        Me.CopyToolStripMenuItem.Text = "Copy"
        '
        'PasteToolStripMenuItem
        '
        Me.PasteToolStripMenuItem.Enabled = False
        Me.PasteToolStripMenuItem.Name = "PasteToolStripMenuItem"
        Me.PasteToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys)
        Me.PasteToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
        Me.PasteToolStripMenuItem.Text = "Paste"
        '
        'MAX7456ToolStripMenuItem
        '
        Me.MAX7456ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReadFromMAX7456CharacterToolStripMenuItem, Me.ReadFromMAX7456AllCharacterToolStripMenuItem, Me.ToolStripSeparator1, Me.WriteToMAX7456CharacterToolStripMenuItem, Me.WriteToMAX7456AllCharacterToolStripMenuItem, Me.ToolStripSeparator2, Me.ShowAllCharacterMAX7456ToolStripMenuItem, Me.ToolStripSeparator3, Me.UpdateFrToolStripMenuItem})
        Me.MAX7456ToolStripMenuItem.Name = "MAX7456ToolStripMenuItem"
        Me.MAX7456ToolStripMenuItem.Size = New System.Drawing.Size(42, 20)
        Me.MAX7456ToolStripMenuItem.Text = "OSD"
        '
        'ReadFromMAX7456CharacterToolStripMenuItem
        '
        Me.ReadFromMAX7456CharacterToolStripMenuItem.Name = "ReadFromMAX7456CharacterToolStripMenuItem"
        Me.ReadFromMAX7456CharacterToolStripMenuItem.Size = New System.Drawing.Size(253, 22)
        Me.ReadFromMAX7456CharacterToolStripMenuItem.Text = "Read Character from MAX7456"
        '
        'ReadFromMAX7456AllCharacterToolStripMenuItem
        '
        Me.ReadFromMAX7456AllCharacterToolStripMenuItem.Name = "ReadFromMAX7456AllCharacterToolStripMenuItem"
        Me.ReadFromMAX7456AllCharacterToolStripMenuItem.Size = New System.Drawing.Size(253, 22)
        Me.ReadFromMAX7456AllCharacterToolStripMenuItem.Text = "Read All Character from MAX7456"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(250, 6)
        '
        'WriteToMAX7456CharacterToolStripMenuItem
        '
        Me.WriteToMAX7456CharacterToolStripMenuItem.Name = "WriteToMAX7456CharacterToolStripMenuItem"
        Me.WriteToMAX7456CharacterToolStripMenuItem.Size = New System.Drawing.Size(253, 22)
        Me.WriteToMAX7456CharacterToolStripMenuItem.Text = "Write Character to MAX7456"
        '
        'WriteToMAX7456AllCharacterToolStripMenuItem
        '
        Me.WriteToMAX7456AllCharacterToolStripMenuItem.Name = "WriteToMAX7456AllCharacterToolStripMenuItem"
        Me.WriteToMAX7456AllCharacterToolStripMenuItem.Size = New System.Drawing.Size(253, 22)
        Me.WriteToMAX7456AllCharacterToolStripMenuItem.Text = "Write All Character to MAX7456"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(250, 6)
        '
        'ShowAllCharacterMAX7456ToolStripMenuItem
        '
        Me.ShowAllCharacterMAX7456ToolStripMenuItem.Name = "ShowAllCharacterMAX7456ToolStripMenuItem"
        Me.ShowAllCharacterMAX7456ToolStripMenuItem.Size = New System.Drawing.Size(253, 22)
        Me.ShowAllCharacterMAX7456ToolStripMenuItem.Text = "Show All Character MAX7456"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(250, 6)
        '
        'UpdateFrToolStripMenuItem
        '
        Me.UpdateFrToolStripMenuItem.Name = "UpdateFrToolStripMenuItem"
        Me.UpdateFrToolStripMenuItem.Size = New System.Drawing.Size(253, 22)
        Me.UpdateFrToolStripMenuItem.Text = "Update Firmware"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'CharacterPreviewBox
        '
        Me.CharacterPreviewBox.Controls.Add(Me.ClearCharacterPreview)
        Me.CharacterPreviewBox.Controls.Add(Me.CharacterFix)
        Me.CharacterPreviewBox.Controls.Add(Me.ShowGrid)
        Me.CharacterPreviewBox.Controls.Add(Me.ScalleBox)
        Me.CharacterPreviewBox.Location = New System.Drawing.Point(540, 25)
        Me.CharacterPreviewBox.Name = "CharacterPreviewBox"
        Me.CharacterPreviewBox.Size = New System.Drawing.Size(468, 506)
        Me.CharacterPreviewBox.TabIndex = 10
        Me.CharacterPreviewBox.TabStop = False
        Me.CharacterPreviewBox.Text = "Character Preview"
        '
        'ClearCharacterPreview
        '
        Me.ClearCharacterPreview.Location = New System.Drawing.Point(215, 17)
        Me.ClearCharacterPreview.Name = "ClearCharacterPreview"
        Me.ClearCharacterPreview.Size = New System.Drawing.Size(69, 22)
        Me.ClearCharacterPreview.TabIndex = 9
        Me.ClearCharacterPreview.Text = "Clear"
        Me.ClearCharacterPreview.UseVisualStyleBackColor = True
        '
        'CharacterFix
        '
        Me.CharacterFix.AutoSize = True
        Me.CharacterFix.Location = New System.Drawing.Point(159, 19)
        Me.CharacterFix.Name = "CharacterFix"
        Me.CharacterFix.Size = New System.Drawing.Size(39, 17)
        Me.CharacterFix.TabIndex = 8
        Me.CharacterFix.Text = "Fix"
        Me.CharacterFix.UseVisualStyleBackColor = True
        '
        'ShowGrid
        '
        Me.ShowGrid.AutoSize = True
        Me.ShowGrid.Location = New System.Drawing.Point(78, 19)
        Me.ShowGrid.Name = "ShowGrid"
        Me.ShowGrid.Size = New System.Drawing.Size(75, 17)
        Me.ShowGrid.TabIndex = 7
        Me.ShowGrid.Text = "Show Grid"
        Me.ShowGrid.UseVisualStyleBackColor = True
        '
        'ScalleBox
        '
        Me.ScalleBox.FormattingEnabled = True
        Me.ScalleBox.Items.AddRange(New Object() {"x1", "x2", "x3"})
        Me.ScalleBox.Location = New System.Drawing.Point(5, 18)
        Me.ScalleBox.Name = "ScalleBox"
        Me.ScalleBox.Size = New System.Drawing.Size(61, 21)
        Me.ScalleBox.TabIndex = 6
        '
        'ToolTip1
        '
        Me.ToolTip1.AutomaticDelay = 100
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(152, 22)
        Me.ToolStripMenuItem3.Text = "1"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(152, 22)
        Me.ToolStripMenuItem4.Text = "2"
        '
        'Port
        '
        Me.Port.FormattingEnabled = True
        Me.Port.Location = New System.Drawing.Point(723, 1)
        Me.Port.Name = "Port"
        Me.Port.Size = New System.Drawing.Size(79, 21)
        Me.Port.TabIndex = 12
        '
        'StatusPanel
        '
        Me.StatusPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.StatusPanel.Controls.Add(Me.Status)
        Me.StatusPanel.Controls.Add(Me.Port)
        Me.StatusPanel.Controls.Add(Me.StatusProgress)
        Me.StatusPanel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.StatusPanel.Location = New System.Drawing.Point(0, 538)
        Me.StatusPanel.Name = "StatusPanel"
        Me.StatusPanel.Size = New System.Drawing.Size(1008, 24)
        Me.StatusPanel.TabIndex = 4
        '
        'Status
        '
        Me.Status.Location = New System.Drawing.Point(1, 1)
        Me.Status.Name = "Status"
        Me.Status.Size = New System.Drawing.Size(714, 21)
        Me.Status.TabIndex = 13
        Me.Status.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'StatusProgress
        '
        Me.StatusProgress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.StatusProgress.Location = New System.Drawing.Point(806, 1)
        Me.StatusProgress.Name = "StatusProgress"
        Me.StatusProgress.Size = New System.Drawing.Size(198, 21)
        Me.StatusProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.StatusProgress.TabIndex = 0
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 562)
        Me.Controls.Add(Me.StatusPanel)
        Me.Controls.Add(Me.CharacterPreviewBox)
        Me.Controls.Add(Me.EditCharacterGroup)
        Me.Controls.Add(Me.CharacterListGroup)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MinimumSize = New System.Drawing.Size(1024, 600)
        Me.Name = "Form1"
        Me.Text = "Max7456 Font Editor"
        Me.CharacterListGroup.ResumeLayout(False)
        Me.EditCharacterGroup.ResumeLayout(False)
        CType(Me.Max7456TransparentBtn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Max7456BlackBtn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Max7456WhiteBtn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.CharacterPreviewBox.ResumeLayout(False)
        Me.CharacterPreviewBox.PerformLayout()
        Me.StatusPanel.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Max74561 As FrontEditor.Max7456
    Friend WithEvents Max7456Panel1 As FrontEditor.Max7456Panel
    Friend WithEvents CharacterListGroup As System.Windows.Forms.GroupBox
    Friend WithEvents EditCharacterGroup As System.Windows.Forms.GroupBox
    Friend WithEvents SaveCharacter As System.Windows.Forms.Button
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveAsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents CharacterPreviewBox As System.Windows.Forms.GroupBox
    Friend WithEvents ScalleBox As System.Windows.Forms.ComboBox
    Friend WithEvents ShowGrid As System.Windows.Forms.CheckBox
    Friend WithEvents CharacterFix As System.Windows.Forms.CheckBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ClearCharacterPreview As System.Windows.Forms.Button
    Friend WithEvents Max7456TransparentBtn As System.Windows.Forms.PictureBox
    Friend WithEvents Max7456BlackBtn As System.Windows.Forms.PictureBox
    Friend WithEvents Max7456WhiteBtn As System.Windows.Forms.PictureBox
    Friend WithEvents CharacterListToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PasteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MAX7456ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WriteToMAX7456CharacterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Port As System.Windows.Forms.ComboBox
    Friend WithEvents StatusPanel As System.Windows.Forms.Panel
    Friend WithEvents StatusProgress As System.Windows.Forms.ProgressBar
    Friend WithEvents Status As System.Windows.Forms.Label
    Friend WithEvents WriteToMAX7456AllCharacterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReadFromMAX7456CharacterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReadFromMAX7456AllCharacterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ShowAllCharacterMAX7456ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents UpdateFrToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem



End Class
