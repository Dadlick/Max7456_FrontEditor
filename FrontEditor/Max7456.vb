Public Class Max7456
    Dim Symbol(11, 17) As System.Windows.Forms.PictureBox
    Dim Max7456Symbol_(11, 17) As PointColor
    Dim PointSize_ As Integer = 10
    Dim PointBorderStyle_ As System.Windows.Forms.BorderStyle = Windows.Forms.BorderStyle.FixedSingle
    Dim PointColorEditor_ As PointColorEditor = PointColorEditor.All

    Public Enum PointColorEditor
        All = 0
        Black = 1
        White = 2
        Transparent = 3
    End Enum

    Public Event PointChange(ByVal Max7456Symbol As Object)

    Private Sub Max7456_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        Dim x As Integer
        Dim y As Integer
        For y = 0 To 17
            For x = 0 To 11
                RemoveHandler Me.Symbol(x, y).MouseDown, AddressOf MyKeyMouseDown
                RemoveHandler Me.Symbol(x, y).MouseMove, AddressOf MyKeyMouseMove
            Next x
        Next y
    End Sub
    Private Sub Max7456_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim x As Integer
        Dim y As Integer

        For y = 0 To 17
            For x = 0 To 11
                Me.Symbol(x, y) = New PictureBox
                Me.Controls.Add(Me.Symbol(x, y))
                Me.Symbol(x, y).Name = x & "_" & y
                Me.Symbol(x, y).Size = New System.Drawing.Size(PointSize_, PointSize_)
                Me.Symbol(x, y).Location = New System.Drawing.Point(PointSize_ * x, PointSize_ * y)
                Me.Symbol(x, y).Margin = New System.Windows.Forms.Padding(0)
                Me.Symbol(x, y).BorderStyle = PointBorderStyle_
                Me.Symbol(x, y).BackColor = Max7456_Transparent
                Me.Max7456Symbol_(x, y) = PointColor.Transparent

                AddHandler Me.Symbol(x, y).MouseMove, AddressOf MyKeyMouseMove
                AddHandler Me.Symbol(x, y).MouseDown, AddressOf MyKeyMouseDown

            Next x
        Next y
        Me.Size = New System.Drawing.Size(PointSize_ * 12, PointSize_ * 18)
    End Sub

    Private Sub MyKeyMouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim x As Integer
        Dim y As Integer

        If e.Button = Windows.Forms.MouseButtons.Left And PointColorEditor_ <> PointColorEditor.All Then
            x = Int((e.Location.X + sender.Location.X) / PointSize_)
            y = Int((e.Location.Y + sender.Location.y) / PointSize_)

            Select Case PointColorEditor_
                Case PointColorEditor.Black
                    Symbol(x, y).BackColor = Max7456_Black
                    Max7456Symbol_(x, y) = PointColor.Black
                Case PointColorEditor.White
                    Symbol(x, y).BackColor = Max7456_White
                    Max7456Symbol_(x, y) = PointColor.White
                Case PointColorEditor.Transparent
                    Symbol(x, y).BackColor = Max7456_Transparent
                    Max7456Symbol_(x, y) = PointColor.Transparent
            End Select
        End If
    End Sub

    Private Sub MyKeyMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim Temp() As String
        Dim pointColor As PointColor

        If e.Button = Windows.Forms.MouseButtons.Right Then
            ContextMenuStrip1.Show(sender, e.Location)

        ElseIf e.Button = Windows.Forms.MouseButtons.Left Then
            Temp = Split(sender.name, "_")
            Select Case PointColorEditor_
                Case PointColorEditor.All
                    If sender.BackColor = Max7456_Transparent Then
                        sender.BackColor = Max7456_Black
                        pointColor = pointColor.Black
                    ElseIf sender.BackColor = Max7456_Black Then
                        sender.BackColor = Max7456_White
                        pointColor = pointColor.White
                    ElseIf sender.BackColor = Max7456_White Then
                        sender.BackColor = Max7456_Transparent
                        pointColor = pointColor.Transparent
                    End If
                Case PointColorEditor.Black
                    sender.BackColor = Max7456_Black
                    pointColor = pointColor.Black
                Case PointColorEditor.White
                    sender.BackColor = Max7456_White
                    pointColor = pointColor.White
                Case PointColorEditor.Transparent
                    sender.BackColor = Max7456_Transparent
                    pointColor = pointColor.Transparent
            End Select
            Max7456Symbol_(CInt(Temp(0)), CInt(Temp(1))) = pointColor
        End If

    End Sub

    Public Function GetSymbol() As Object
        GetSymbol = Max7456Symbol_
    End Function

    Public Sub LoadSymbol(Max7456Symbol As Object)
        Dim x As Integer
        Dim y As Integer

        For y = 0 To 17
            For x = 0 To 11
                Select Case Max7456Symbol(x, y)
                    Case PointColor.Black
                        Me.Symbol(x, y).BackColor = Max7456_Black
                    Case PointColor.White
                        Me.Symbol(x, y).BackColor = Max7456_White
                    Case PointColor.Transparent
                        Me.Symbol(x, y).BackColor = Max7456_Transparent
                End Select

            Next x
        Next y
        Max7456Symbol_ = Max7456Symbol.clone
    End Sub

    Public Sub Clear()
        Dim x As Integer
        Dim y As Integer

        For y = 0 To 17
            For x = 0 To 11
                Me.Symbol(x, y).BackColor = Max7456_Transparent
            Next x
        Next y
        Max7456Symbol_ = Nothing
    End Sub

    Public Property PointSize As Integer
        Get
            Return PointSize_
        End Get
        Set(ByVal value As Integer)
            PointSize_ = value
        End Set
    End Property


    Public Property EditorColor As PointColorEditor
        Get
            Return PointColorEditor_
        End Get
        Set(ByVal value As PointColorEditor)
            PointColorEditor_ = value
        End Set
    End Property

    Public Property PointBorderStyle As System.Windows.Forms.BorderStyle
        Get
            Return PointBorderStyle_
        End Get
        Set(ByVal value As System.Windows.Forms.BorderStyle)
            PointBorderStyle_ = value
        End Set
    End Property


    Private Sub SetAllWhiteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetAllWhiteToolStripMenuItem.Click
        For y = 0 To 17
            For x = 0 To 11
                Me.Symbol(x, y).BackColor = Max7456_White
                Max7456Symbol_(x, y) = PointColor.White
            Next x
        Next y
    End Sub

    Private Sub SetAllBlckToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetAllBlckToolStripMenuItem.Click
        For y = 0 To 17
            For x = 0 To 11
                Me.Symbol(x, y).BackColor = Max7456_Black
                Max7456Symbol_(x, y) = PointColor.Black
            Next x
        Next y
    End Sub

    Private Sub SetAllTransparentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetAllTransparentToolStripMenuItem.Click
        For y = 0 To 17
            For x = 0 To 11
                Me.Symbol(x, y).BackColor = Max7456_Transparent
                Max7456Symbol_(x, y) = PointColor.Transparent
            Next x
        Next y
    End Sub

    Private Sub InversrColorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InversrColorToolStripMenuItem.Click
        For y = 0 To 17
            For x = 0 To 11
                If Max7456Symbol_(x, y) = PointColor.Black Then
                    Me.Symbol(x, y).BackColor = Max7456_White
                    Max7456Symbol_(x, y) = PointColor.White
                ElseIf Max7456Symbol_(x, y) = PointColor.White Then
                    Me.Symbol(x, y).BackColor = Max7456_Black
                    Max7456Symbol_(x, y) = PointColor.Black
                End If
            Next x
        Next y
    End Sub

    Private Sub FlipVerticalyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FlipVerticalyToolStripMenuItem.Click
        Dim TempColor As PointColor
        For y = 0 To 8
            For x = 0 To 11
                TempColor = Max7456Symbol_(x, y)
                Max7456Symbol_(x, y) = Max7456Symbol_(x, 17 - y)
                Max7456Symbol_(x, 17 - y) = TempColor
            Next x
        Next y
        LoadSymbol(Max7456Symbol_)
    End Sub

    Private Sub FlipHorizontallyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FlipHorizontallyToolStripMenuItem.Click
        Dim TempColor As PointColor
        For x = 0 To 5
            For y = 0 To 17
                TempColor = Max7456Symbol_(x, y)
                Max7456Symbol_(x, y) = Max7456Symbol_(11 - x, y)
                Max7456Symbol_(11 - x, y) = TempColor
            Next y
        Next x
        LoadSymbol(Max7456Symbol_)
    End Sub
End Class
