Public Class Max7456Panel
    Dim Symbol(16, 16) As System.Windows.Forms.PictureBox
    Dim PanelSymbol(15, 15) As Object
    Dim PointSize As Single = 1.5
    Dim PreviosSelectionX As Integer
    Dim PreviosSelectionY As Integer
    Dim Max7456Symbol(11, 17) As PointColor

    Public Event SymbolChange(ByVal Max7456Symbol As Object, x As Integer, y As Integer)
    Public Event Copy(x As Integer, y As Integer)
    Public Event Paste(x As Integer, y As Integer)
    Public Event Write(ByVal Max7456Symbol As Object, Max7456SymbolNum As Integer)
    Public Event Read(x As Integer, y As Integer)

    Private Sub Max7456Panel_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        For y = 0 To 16
            For x = 0 To 16
                RemoveHandler Me.Symbol(x, y).MouseDown, AddressOf MyKeyMouseDown
            Next x
        Next y
    End Sub

    Private Sub Max7456Panel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim x As Integer
        Dim y As Integer
        Dim ImageWidth As Single = PointSize * 12
        Dim ImageHeight As Single = PointSize * 18
        Dim Str As String = "0123456789ABCDEF"
        ContextMenuPanel.Items(1).Enabled = False
        For y = 0 To 16
            For x = 0 To 16
                Me.Symbol(x, y) = New System.Windows.Forms.PictureBox

                Me.Symbol(x, y).BorderStyle = Windows.Forms.BorderStyle.FixedSingle
                Me.Controls.Add(Me.Symbol(x, y))
                Me.Symbol(x, y).Name = x & "_" & y
                Me.Symbol(x, y).Size = New System.Drawing.Size(ImageWidth, ImageHeight)
                Me.Symbol(x, y).Location = New System.Drawing.Point(ImageWidth * x + 2 * x, ImageHeight * y + 2 * y)
                Me.Symbol(x, y).Margin = New System.Windows.Forms.Padding(0)

                If y = 0 And x > 0 Then
                    Me.Symbol(x, y).Image = TextToPicture(Mid(Str, x, 1), ImageWidth, ImageHeight)
                    Me.Symbol(x, y).BorderStyle = Windows.Forms.BorderStyle.None
                ElseIf x = 0 And y > 0 Then
                    Me.Symbol(x, y).Image = TextToPicture(Mid(Str, y, 1), ImageWidth, ImageHeight)
                    Me.Symbol(x, y).BorderStyle = Windows.Forms.BorderStyle.None
                ElseIf x = 0 And y = 0 Then
                    Me.Symbol(x, y).BorderStyle = Windows.Forms.BorderStyle.None
                Else
                    Me.Symbol(x, y).BorderStyle = Windows.Forms.BorderStyle.FixedSingle
                    Me.Symbol(x, y).SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
                    Me.Symbol(x, y).BackColor = Max7456_Transparent
                End If
                AddHandler Me.Symbol(x, y).MouseDown, AddressOf MyKeyMouseDown
            Next x
        Next y
        Me.BackColor = SystemColors.Control
        Me.Size = New System.Drawing.Size(ImageWidth * 17 + 2 * 16, ImageHeight * 17 + 2 * 16)
    End Sub
    

    Private Function TextToPicture(ByVal ButtonText As String, ByVal ImageWidth As Integer, ByVal ImageHeight As Integer) As Image
        Dim TextLeft As Integer
        Dim TextTop As Integer
        Dim myColor As Color = SystemColors.Control
        Dim myBrush As Brush = New SolidBrush(myColor)

        txt.Text = ButtonText
        TextLeft = CInt(ImageWidth / 2 - txt.Width / 2)
        TextTop = CInt(ImageHeight / 2 - Me.Font.Height / 2)
        Dim br As New SolidBrush(Color.Black)
        Dim bm_dest As New Bitmap(CInt(ImageWidth), CInt(ImageHeight))
        Dim flag As New Bitmap(CInt(ImageWidth), CInt(ImageHeight))
        Dim flagGraphics As Graphics = Graphics.FromImage(flag)
        flagGraphics.FillRectangle(myBrush, 0, 0, CInt(ImageWidth), CInt(ImageHeight))

        Dim gr_dest As Graphics = Graphics.FromImage(bm_dest)
        gr_dest.DrawImage(flag, 0, 0, ImageWidth, ImageHeight)
        gr_dest.DrawString(ButtonText, Me.txt.Font, br, TextLeft, TextTop)
        TextToPicture = bm_dest
        gr_dest.Dispose()
    End Function

    Public Sub LoadSymbol(x As Integer, y As Integer, Max7456Symbol As Object)
        PanelSymbol(x, y) = Max7456Symbol.clone
        Symbol(x + 1, y + 1).Image = Picture(Max7456Symbol)
    End Sub

    Public Function GetSymbol() As Object
        GetSymbol = PanelSymbol
    End Function

    Public Function GetSymbol(x As Integer, y As Integer) As Object
        GetSymbol = PanelSymbol(x, y)
    End Function

    Private Sub MyKeyMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim Temp() As String
        Temp = Split(sender.name, "_")

        Max7456Symbol = PanelSymbol(CInt(Temp(0)) - 1, CInt(Temp(1)) - 1)

        If Max7456Symbol Is Nothing Then
            MsgBox("Symbols are not loaded.")
            Exit Sub
        End If

        If e.Button = Windows.Forms.MouseButtons.Right Then
            ContextMenuPanel.Tag = CInt(Temp(0)) - 1 & "_" & CInt(Temp(1)) - 1

            ContextMenuPanel.Show(sender, e.Location)
            Exit Sub
        ElseIf e.Button = Windows.Forms.MouseButtons.Left Then
            sender.BorderStyle = Windows.Forms.BorderStyle.Fixed3D
            If PreviosSelectionX <> 0 And PreviosSelectionY <> 0 Then
                Symbol(PreviosSelectionX, PreviosSelectionY).BorderStyle = Windows.Forms.BorderStyle.FixedSingle
            End If
            PreviosSelectionX = CInt(Temp(0))
            PreviosSelectionY = CInt(Temp(1))
            RaiseEvent SymbolChange(Max7456Symbol, PreviosSelectionX - 1, PreviosSelectionY - 1)
        End If
    End Sub

    Public Sub SetSelectSymbol(x As Integer, y As Integer)
        Symbol(x, y).BorderStyle = Windows.Forms.BorderStyle.Fixed3D
        If PreviosSelectionX <> 0 And PreviosSelectionY <> 0 Then
            Symbol(PreviosSelectionX, PreviosSelectionY).BorderStyle = Windows.Forms.BorderStyle.FixedSingle
        End If
        PreviosSelectionX = x
        PreviosSelectionY = y
    End Sub

    Public Sub UnselectSymbol()
        If PreviosSelectionX <> 0 And PreviosSelectionY <> 0 Then
            Symbol(PreviosSelectionX, PreviosSelectionY).BorderStyle = Windows.Forms.BorderStyle.FixedSingle
        End If
        PreviosSelectionX = 0
        PreviosSelectionY = 0
    End Sub

    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        Dim Temp() As String
        Temp = Split(sender.owner.tag, "_")
        RaiseEvent Copy(CInt(Temp(0)), CInt(Temp(1)))
        ContextMenuPanel.Items(1).Enabled = True
    End Sub

    Private Sub PasteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasteToolStripMenuItem.Click
        Dim Temp() As String
        Temp = Split(sender.owner.tag, "_")
        RaiseEvent Paste(CInt(Temp(0)), CInt(Temp(1)))
    End Sub

    Private Sub WriteToMAX7456ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WriteToMAX7456ToolStripMenuItem.Click
        Dim Temp() As String
        Dim Num As Integer

        Temp = Split(sender.owner.tag, "_")

        Max7456Symbol = PanelSymbol(CInt(Temp(0)), CInt(Temp(1)))
        Num = (CInt(Temp(1))) * 16 + (CInt(Temp(0)))
        RaiseEvent Write(Max7456Symbol, Num)
    End Sub

    Private Sub ReadFromMAX7456ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReadFromMAX7456ToolStripMenuItem.Click
        Dim Temp() As String
        Temp = Split(sender.owner.tag, "_")
        RaiseEvent Read(CInt(Temp(0)), CInt(Temp(1)))
    End Sub
End Class
