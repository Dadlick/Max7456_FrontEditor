Imports System.IO
Public Class Form1
    Dim Max7456Symbol(11, 17) As PointColor
    Dim CurEditorX As Integer
    Dim CurEditorY As Integer
    Dim PathMCM As String
    Dim SymbolPreviev(7, 4) As System.Windows.Forms.PictureBox
    Dim SymbolPrevievAdd As Boolean = False
    Dim PreviosSelectionX As Integer
    Dim PreviosSelectionY As Integer
    Dim Str As String = "0123456789ABCDEF"
    Dim PathCopy As Copy_
    Private WithEvents comport As New Ports.SerialPort
    Private Delegate Sub UartReceivDelegate(ByVal Info As Form, ByVal ReciveByte() As Byte)

    Structure Copy_
        Dim FromX As Integer
        Dim FromY As Integer
        Dim ToX As Integer
        Dim ToY As Integer
    End Structure

    Private Sub CopySymbol(path As Copy_)
        Max74561.LoadSymbol(Max7456Panel1.GetSymbol(path.FromX, path.FromY))
        EditCharacterGroup.Text = "Edit Character: " & Mid(Str, path.ToY + 1, 1) & Mid(Str, path.ToX + 1, 1)

        Max7456Panel1.SetSelectSymbol(path.ToX + 1, path.ToY + 1)
        CurEditorX = path.ToX
        CurEditorY = path.ToY
        EditCharacterGroup.Enabled = True
        CharacterListToolStripMenuItem.Enabled = True
    End Sub

    Private Sub LoadSymbol(path As String)
        Dim ReadString As String
        Dim Start As Boolean = False
        Dim VisiblePoint As Boolean = True
        Dim NotVisiblePoint As Integer
        Dim Counter As Integer = 1
        Dim PointX As Integer
        Dim PointY As Integer
        Dim X As Integer
        Dim Y As Integer
        Dim ReadPointColor As String
        Dim line As Integer
        Dim progress As Integer
        StatusProgress.Visible = True
        StatusProgress.Value = 0
        Status.Text = path
        Status.Refresh()

        PasteToolStripMenuItem.Enabled = False
        CharacterListToolStripMenuItem.Enabled = False
        Max74561.Clear()
        ClearCharacterPreview_Click(Nothing, Nothing)
        Max7456Panel1.UnselectSymbol()
        Dim sr1 As StreamReader = New StreamReader(path, System.Text.Encoding.GetEncoding(1251))
        While sr1.Peek <> -1
            ReadString = sr1.ReadLine()
            line = line + 1
            progress = CInt(((CSng(line) / CSng(16385)) * 100.0))
            Me.StatusProgress.Value = progress
            Me.Status.Text = ("Loading Character " & progress & " %")
            Me.StatusProgress.Refresh()
            Me.Status.Refresh()
            If Start = True Then
                If VisiblePoint = True Then
                    For i = 1 To 8 Step 2
                        ReadPointColor = Mid(ReadString, i, 2)
                        Select Case ReadPointColor
                            Case "00"
                                Max7456Symbol(PointX, PointY) = PointColor.Black
                            Case "10"
                                Max7456Symbol(PointX, PointY) = PointColor.White
                            Case "01"
                                Max7456Symbol(PointX, PointY) = PointColor.Transparent
                        End Select
                        PointX = PointX + 1
                    Next i

                    If PointX = 12 Then
                        PointY = PointY + 1
                        PointX = 0
                    End If

                    Counter = Counter + 1

                    If Counter = 55 Then
                        Counter = 1
                        PointX = 0
                        PointY = 0
                        VisiblePoint = False
                        If X = 16 Then
                            X = 0
                            Y = Y + 1

                            If Y = 16 Then Exit While
                        End If
                        Max7456Panel1.LoadSymbol(X, Y, Max7456Symbol)
                        X = X + 1
                    End If
                Else
                    NotVisiblePoint = NotVisiblePoint + 1
                    If NotVisiblePoint = 10 Then
                        NotVisiblePoint = 0
                        VisiblePoint = True
                    End If
                End If
            End If

            If ReadString = "MAX7456" Then
                Start = True
            End If

        End While
        sr1.Close()
        StatusProgress.Value = 0
        StatusProgress.Visible = False
        Me.Text = "Max7456 Font Editor - " & FileIO.FileSystem.GetName(path)
        Me.Status.Text = "Done"
    End Sub

    Private Sub SaveSymbol(path As String)
        Dim WriteString As String
        Dim AllSymbol As Object
        Dim PointX As Integer
        Dim PointY As Integer
        Dim X As Integer
        Dim Y As Integer
        Dim sw1 As StreamWriter = New StreamWriter(path, False, System.Text.Encoding.GetEncoding(1251))

        AllSymbol = Max7456Panel1.GetSymbol

        WriteString = "MAX7456"
        sw1.WriteLine(WriteString)

        For Y = 0 To 15
            For X = 0 To 15
                Max7456Symbol = AllSymbol(X, Y)
                For PointY = 0 To 17
                    For PointX = 0 To 11 Step 4
                        WriteString = ""
                        For i = 0 To 3
                            Select Case Max7456Symbol(PointX + i, PointY)
                                Case PointColor.Black
                                    WriteString = WriteString & "00"
                                Case PointColor.White
                                    WriteString = WriteString & "10"
                                Case PointColor.Transparent
                                    WriteString = WriteString & "01"
                            End Select
                        Next i
                        sw1.WriteLine(WriteString)
                    Next PointX
                Next PointY
                For i = 0 To 9
                    WriteString = "01010101"
                    sw1.WriteLine(WriteString)
                Next i
            Next X
        Next Y

        sw1.Close()
        Me.Text = "Max7456 Font Editor - " & FileIO.FileSystem.GetName(path)
    End Sub

    Private Sub Max7456Panel1_Copy(x As Integer, y As Integer) Handles Max7456Panel1.Copy
        PathCopy.FromX = x
        PathCopy.FromY = y
    End Sub

    Private Sub Max7456Panel1_Paste(x As Integer, y As Integer) Handles Max7456Panel1.Paste
        PathCopy.ToX = x
        PathCopy.ToY = y
        CopySymbol(PathCopy)
    End Sub

    Private Sub Max7456Panel1_Read(x As Integer, y As Integer) Handles Max7456Panel1.Read
        Dim Num As Integer
        Dim Value(0) As Byte
        Num = y * 16 + x
        If ComOpen() = True Then
            Try
                comport.ReadTimeout = 300
                Value(0) = 87
                comport.Write(Value, 0, 1)
                Value(0) = Num
                comport.Write(Value, 0, 1)
                System.Threading.Thread.Sleep(40)
                Dim ReciveByte(53) As Byte
                comport.Read(ReciveByte, 0, 54)
                UartRecive(Me, ReciveByte)
                Value(0) = 86 'показать символы
                comport.Write(Value, 0, 1)
                ComClose()
            Catch ex As Exception
                MsgBox("Error opening com port")
            End Try
        End If
    End Sub

    Private Sub ReadFromMAX7456AllCharacterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReadFromMAX7456AllCharacterToolStripMenuItem.Click
        Dim Num As Integer
        Dim Value(0) As Byte
        Dim progress As Integer
        If ComOpen() = True Then
            StatusProgress.Visible = True
            For Y = 0 To 15
                For X = 0 To 15
                    Num = Y * 16 + X
                    Try
                        comport.ReadTimeout = 300
                        Value(0) = 87
                        comport.Write(Value, 0, 1)
                        Value(0) = Num
                        comport.Write(Value, 0, 1)
                        System.Threading.Thread.Sleep(40)
                        progress = CInt((Num / 256) * 100.0)
                        Me.StatusProgress.Value = progress
                        Me.Status.Text = ("Loading Character " & progress & " %")
                        Me.StatusProgress.Refresh()
                        Me.Status.Refresh()
                        Dim ReciveByte(53) As Byte
                        comport.Read(ReciveByte, 0, 54)
                        UartRecive(Me, ReciveByte, X, Y)

                    Catch ex As Exception
                        MsgBox("Error opening com port")
                        Exit Sub
                    End Try
                Next X
            Next Y
            Value(0) = 86 'показать символы
            comport.Write(Value, 0, 1)
            ComClose()
            StatusProgress.Value = 0
            StatusProgress.Visible = False
            Me.Status.Text = "Done"
        End If
    End Sub

    Private Sub UartRecive(ByVal Info As Form, ByVal ReciveByte() As Byte)
        If Info.InvokeRequired Then
            Dim DDD As New UartReceivDelegate(AddressOf UartRecive)
            Info.Invoke(DDD, New Object() {Info, ReciveByte})
        Else
            Max7456Symbol = ConvertMax7456Symbol(ReciveByte)
            Max74561.LoadSymbol(Max7456Symbol)
        End If
    End Sub

    Private Sub UartRecive(ByVal Info As Form, ByVal ReciveByte() As Byte, X As Integer, Y As Integer)
        If Info.InvokeRequired Then
            Dim DDD As New UartReceivDelegate(AddressOf UartRecive)
            Info.Invoke(DDD, New Object() {Info, ReciveByte, X, Y})
        Else
            Max7456Symbol = ConvertMax7456Symbol(ReciveByte)
            Max7456Panel1.LoadSymbol(X, Y, Max7456Symbol)
        End If
    End Sub

    Private Sub Max7456Panel1_SymbolChange(Max7456Symbol As Object, x As Integer, y As Integer) Handles Max7456Panel1.SymbolChange
        CurEditorX = x
        CurEditorY = y
        Max74561.LoadSymbol(Max7456Symbol)
        EditCharacterGroup.Text = "Edit Character: " & Mid(Str, y + 1, 1) & Mid(Str, x + 1, 1)

        EditCharacterGroup.Enabled = True
        CharacterListToolStripMenuItem.Enabled = True

        UpdatePreviewSymbol(Max7456Symbol)
    End Sub

    Private Sub UpdatePreviewSymbol(Max7456Symbol As Object)
        If CharacterFix.Checked = False Then
            SymbolPreviev(PreviosSelectionX, PreviosSelectionY).Image = Picture(Max7456Symbol)
            SymbolPreviev(PreviosSelectionX, PreviosSelectionY).Tag = CurEditorX & "_" & CurEditorY
            ToolTip1.SetToolTip(SymbolPreviev(PreviosSelectionX, PreviosSelectionY), Mid(Str, CurEditorY + 1, 1) & Mid(Str, CurEditorX + 1, 1))
        End If
    End Sub

    Private Sub DoSaveCharacter()
        Dim Temp() As String
        Max7456Panel1.LoadSymbol(CurEditorX, CurEditorY, Max74561.GetSymbol)

        For Y = 0 To 4
            For X = 0 To 7
                Temp = Split(Me.SymbolPreviev(X, Y).Tag, "_")
                If UBound(Temp) = 2 Then
                    If CurEditorX = CInt(Temp(0)) And CurEditorY = CInt(Temp(1)) Then
                        Me.SymbolPreviev(X, Y).Image = Picture(Max74561.GetSymbol)
                        Exit Sub
                    End If
                End If
            Next X
        Next Y

        UpdatePreviewSymbol(Max74561.GetSymbol)
    End Sub


    Private Sub SaveCharacter_Click(sender As Object, e As EventArgs) Handles SaveCharacter.Click
        DoSaveCharacter()
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        OpenFileDialog1.Filter = "Maxim MAX7456 Character Memory File (*.mcm)|*.mcm"
        OpenFileDialog1.FilterIndex = 1
        OpenFileDialog1.RestoreDirectory = True
        OpenFileDialog1.FileName = ""
        If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            PathMCM = OpenFileDialog1.FileName
            LoadSymbol(PathMCM)
        End If
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        SaveSymbol(PathMCM)
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        SaveFileDialog1.Filter = "Maxim MAX7456 Character Memory File (*.mcm)|*.mcm"
        SaveFileDialog1.FilterIndex = 1
        SaveFileDialog1.RestoreDirectory = True
        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
            PathMCM = SaveFileDialog1.FileName
            Status.Text = PathMCM
            SaveSymbol(PathMCM)
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ports As String() = System.IO.Ports.SerialPort.GetPortNames()
        Dim i As Integer
        Dim Scal As Single = 1.5
        Dim IWidth As Single = Scal * 12
        Dim IHeight As Single = Scal * 18
        Dim ComPort_ As String
        For i = 0 To UBound(ports)
            Me.Port.Items.Add(ports(i))
        Next i
        StatusProgress.Visible = False

        For Y = 0 To 4
            For X = 0 To 7
                Me.SymbolPreviev(X, Y) = New PictureBox
                Me.CharacterPreviewBox.Controls.Add(Me.SymbolPreviev(X, Y))
                Me.SymbolPreviev(X, Y).Name = X & "_" & Y
                Me.SymbolPreviev(X, Y).Size = New System.Drawing.Size(IWidth, IHeight)
                Me.SymbolPreviev(X, Y).Location = New System.Drawing.Point(5 + IWidth * X, 50 + IHeight * Y)
                Me.SymbolPreviev(X, Y).Margin = New System.Windows.Forms.Padding(0)
                If X = 0 And Y = 0 Then
                    Me.SymbolPreviev(X, Y).BorderStyle = BorderStyle.Fixed3D
                Else
                    Me.SymbolPreviev(X, Y).BorderStyle = BorderStyle.FixedSingle
                End If
                Me.SymbolPreviev(X, Y).SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
                Me.SymbolPreviev(X, Y).BackColor = Max7456_Transparent
                AddHandler Me.SymbolPreviev(X, Y).MouseDown, AddressOf MyKeyMouseDown
            Next X
        Next Y
        SymbolPrevievAdd = True
        ShowGrid.Checked = True

        Max7456BlackBtn.BackColor = Max7456_Black
        Max7456WhiteBtn.BackColor = Max7456_White
        Max7456TransparentBtn.BackColor = Max7456_Transparent
        ScalleBox.SelectedIndex = 1

        ComPort_ = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\dadlick\FrontEditor", "Com", Nothing)

        If ComPort_ Is Nothing Then
            My.Computer.Registry.CurrentUser.CreateSubKey("Software\dadlick\FrontEditor")
        Else
            Me.Port.SelectedText = ComPort_
        End If

        AddHandler Max74561.SymbolChanged, AddressOf DoSaveCharacter
    End Sub

    Private Sub ScalleBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ScalleBox.SelectedIndexChanged
        If SymbolPrevievAdd = False Then Exit Sub
        Dim Scal As Single
        Select Case ScalleBox.SelectedIndex
            Case 0
                Scal = 1.5
            Case 1
                Scal = 3
            Case 2
                Scal = 4.5
        End Select
        Dim IWidth As Single = Scal * 12
        Dim IHeight As Single = Scal * 18
        For Y = 0 To 4
            For X = 0 To 7
                Me.SymbolPreviev(X, Y).Size = New System.Drawing.Size(IWidth, IHeight)
                Me.SymbolPreviev(X, Y).Location = New System.Drawing.Point(5 + IWidth * X, 50 + IHeight * Y)
            Next X
        Next Y
    End Sub

    Private Sub ShowGrid_CheckedChanged(sender As Object, e As EventArgs) Handles ShowGrid.CheckedChanged
        If ShowGrid.Checked = False Then
            For Y = 0 To 4
                For X = 0 To 7
                    If Me.SymbolPreviev(X, Y).BorderStyle <> BorderStyle.Fixed3D Or CharacterFix.Checked = True Then
                        Me.SymbolPreviev(X, Y).BorderStyle = BorderStyle.None
                    End If
                Next X
            Next Y
        Else
            For Y = 0 To 4
                For X = 0 To 7
                    If Me.SymbolPreviev(X, Y).BorderStyle <> BorderStyle.Fixed3D Or CharacterFix.Checked = True Then
                        Me.SymbolPreviev(X, Y).BorderStyle = BorderStyle.FixedSingle
                    End If
                Next X
            Next Y
        End If
    End Sub

    Private Sub MyKeyMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If CharacterFix.Checked = False Then
            If ShowGrid.Checked = False Then
                SymbolPreviev(PreviosSelectionX, PreviosSelectionY).BorderStyle = Windows.Forms.BorderStyle.None
            Else
                SymbolPreviev(PreviosSelectionX, PreviosSelectionY).BorderStyle = Windows.Forms.BorderStyle.FixedSingle
            End If

            Dim Temp() As String
            Temp = Split(sender.name, "_")
            PreviosSelectionX = CInt(Temp(0))
            PreviosSelectionY = CInt(Temp(1))
            sender.BorderStyle = Windows.Forms.BorderStyle.Fixed3D
        End If
    End Sub

    Private Sub CharacterFix_CheckedChanged(sender As Object, e As EventArgs) Handles CharacterFix.CheckedChanged
        If CharacterFix.Checked = True Then
            ShowGrid_CheckedChanged(Nothing, Nothing)
        End If
    End Sub

    Private Sub ClearCharacterPreview_Click(sender As Object, e As EventArgs) Handles ClearCharacterPreview.Click
        For Y = 0 To 4
            For X = 0 To 7
                Me.SymbolPreviev(X, Y).Image = Nothing
            Next X
        Next Y
        ToolTip1.RemoveAll()
    End Sub

    Private Sub Max7456WhiteBtn_MouseDown(sender As Object, e As MouseEventArgs) Handles Max7456WhiteBtn.MouseDown
        If Max7456WhiteBtn.BorderStyle = BorderStyle.FixedSingle Then
            Max7456WhiteBtn.BorderStyle = BorderStyle.Fixed3D
            Max74561.EditorColor = Max7456.PointColorEditor.White
        Else
            Max7456WhiteBtn.BorderStyle = BorderStyle.FixedSingle
            Max74561.EditorColor = Max7456.PointColorEditor.All
        End If
        Max7456BlackBtn.BorderStyle = BorderStyle.FixedSingle
        Max7456TransparentBtn.BorderStyle = BorderStyle.FixedSingle
    End Sub

    Private Sub Max7456TransparentBtn_MouseDown(sender As Object, e As MouseEventArgs) Handles Max7456TransparentBtn.MouseDown
        If Max7456TransparentBtn.BorderStyle = BorderStyle.FixedSingle Then
            Max7456TransparentBtn.BorderStyle = BorderStyle.Fixed3D
            Max74561.EditorColor = Max7456.PointColorEditor.Transparent
        Else
            Max7456TransparentBtn.BorderStyle = BorderStyle.FixedSingle
            Max74561.EditorColor = Max7456.PointColorEditor.All
        End If
        Max7456BlackBtn.BorderStyle = BorderStyle.FixedSingle
        Max7456WhiteBtn.BorderStyle = BorderStyle.FixedSingle
    End Sub

    Private Sub Max7456BlackBtn_MouseDown(sender As Object, e As MouseEventArgs) Handles Max7456BlackBtn.MouseDown
        If Max7456BlackBtn.BorderStyle = BorderStyle.FixedSingle Then
            Max7456BlackBtn.BorderStyle = BorderStyle.Fixed3D
            Max74561.EditorColor = Max7456.PointColorEditor.Black
        Else
            Max7456BlackBtn.BorderStyle = BorderStyle.FixedSingle
            Max74561.EditorColor = Max7456.PointColorEditor.All
        End If
        Max7456TransparentBtn.BorderStyle = BorderStyle.FixedSingle
        Max7456WhiteBtn.BorderStyle = BorderStyle.FixedSingle
    End Sub

    Private Sub CopyToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        PathCopy.FromX = CurEditorX
        PathCopy.FromY = CurEditorY
        PasteToolStripMenuItem.Enabled = True
    End Sub

    Private Sub PasteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasteToolStripMenuItem.Click
        PathCopy.ToX = CurEditorX
        PathCopy.ToY = CurEditorY
        CopySymbol(PathCopy)
    End Sub

    Function ConvertMax7456Symbol(ReciveByte() As Byte) As Object
        Dim ReadPointColor As String
        Dim binary As String
        Dim PointX As Integer
        Dim PointY As Integer
        Dim Byt As Integer
        Dim Max7456Symbol_(11, 17) As PointColor
        For z = 0 To 53
            Byt = Convert.ToString(ReciveByte(z), 2)
            binary = String.Format("{0:00000000}", Byt)
            For i = 1 To 8 Step 2
                ReadPointColor = Mid(binary, i, 2)
                Select Case ReadPointColor
                    Case "00"
                        Max7456Symbol_(PointX, PointY) = PointColor.Black
                    Case "10"
                        Max7456Symbol_(PointX, PointY) = PointColor.White
                    Case "01"
                        Max7456Symbol_(PointX, PointY) = PointColor.Transparent
                End Select
                PointX = PointX + 1
            Next i

            If PointX = 12 Then
                PointY = PointY + 1
                PointX = 0
            End If

        Next z
        Return Max7456Symbol_
    End Function

    Private Sub WriteMax7456Symbol(symbol As Object, SimbolNum As Integer)
        Dim binary As String
        Dim Value(0) As Byte
        Try
            Value(0) = 83
            comport.Write(Value, 0, 1)
            Value(0) = SimbolNum
            comport.Write(Value, 0, 1)

            For PointY = 0 To 17
                For PointX = 0 To 11 Step 4
                    binary = ""
                    For i = 0 To 3
                        Select Case symbol(PointX + i, PointY)
                            Case PointColor.Black
                                binary = binary & "00"
                            Case PointColor.White
                                binary = binary & "10"
                            Case PointColor.Transparent
                                binary = binary & "01"
                        End Select
                    Next i
                    Value(0) = Convert.ToInt32(binary, 2)
                    comport.Write(Value, 0, 1)
                Next PointX
            Next PointY
            For i = 0 To 9
                Value(0) = 85
                comport.Write(Value, 0, 1)
            Next i
        Catch ex As Exception
            MsgBox("Error opening com port")
        End Try
    End Sub

    Private Sub Max7456Panel1_Write(Max7456Symbol As Object, Max7456SymbolNum As Integer) Handles Max7456Panel1.Write
        If ComOpen() = True Then
            Dim Value(0) As Byte
            WriteMax7456Symbol(Max7456Symbol, Max7456SymbolNum)
            Value(0) = 86 'показать символы
            comport.Write(Value, 0, 1)
            ComClose()
        End If
    End Sub
    Private Function ComOpen() As Boolean
        If comport.IsOpen = True Then
            comport.Close()
        End If
        Try
            comport.PortName = Me.Port.Text
            comport.BaudRate = 115200
            comport.DataBits = 8
            comport.Parity = Ports.Parity.None
            comport.StopBits = Ports.StopBits.One
            comport.Open()
            ComOpen = True
        Catch ex As Exception
            ComOpen = False
            Me.Status.Text = "Error opening com port"
            MsgBox("Error opening com port")
        End Try
    End Function
    Private Sub ComClose()
        If comport.IsOpen = True Then
            comport.Close()
        End If
    End Sub

    Private Sub sp_Progress(ByVal progress As Integer)
        Me.Status.Text = ("Uploading " & progress & " %")
        Me.StatusProgress.Value = progress
    End Sub

    Private Function readIntelHEXv2(sr As StreamReader) As Byte()
        Dim FLASH As Byte() = New Byte(sr.BaseStream.Length / 2 - 1) {}
        Dim optionoffset As Integer = 0
        Dim total As Integer = 0

        While Not sr.EndOfStream
            Dim line As String = sr.ReadLine()
            If line.StartsWith(":") Then
                Dim length As Integer = Convert.ToInt32(line.Substring(1, 2), 16)
                Dim address As Integer = Convert.ToInt32(line.Substring(3, 4), 16)
                Dim [option] As Integer = Convert.ToInt32(line.Substring(7, 2), 16)
                Debug.Print("len {0} add {1} opt {2}", length, address, [option])

                If [option] = 0 Then
                    Dim data As String = line.Substring(9, length * 2)
                    For i As Integer = 0 To length - 1
                        Dim byte1 As Byte = Convert.ToByte(data.Substring(i * 2, 2), 16)
                        FLASH(optionoffset + address) = byte1
                        address += 1
                        If (optionoffset + address) > total Then
                            total = optionoffset + address
                        End If
                    Next
                ElseIf [option] = 2 Then
                    optionoffset += CInt(Convert.ToUInt16(line.Substring(9, 4), 16)) << 4
                End If
                Dim checksum As Integer = Convert.ToInt32(line.Substring(line.Length - 2, 2), 16)
            End If
        End While

        Array.Resize(Of Byte)(FLASH, total)

        Return FLASH
    End Function

    Private Sub WriteToMAX7456AllCharacterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WriteToMAX7456AllCharacterToolStripMenuItem.Click
        Dim Num As Integer
        Dim AllSymbol As Object
        Dim progress As Integer
        Dim ReciveByte(1) As Byte
        AllSymbol = Max7456Panel1.GetSymbol
        If ComOpen() = True Then
            Dim Value(0) As Byte
            Me.StatusProgress.Visible = True
            comport.ReadTimeout = 100
            For Y = 0 To 15
                For X = 0 To 15
                    Max7456Symbol = AllSymbol(X, Y)
                    Num = Y * 16 + X
                    WriteMax7456Symbol(Max7456Symbol, Num)
                    progress = CInt((Num / 256) * 100.0)
                    Me.StatusProgress.Value = progress
                    Me.Status.Text = ("Uploading Character " & progress & " %")
                    Me.StatusProgress.Refresh()
                    Me.Status.Refresh()
                    System.Threading.Thread.Sleep(25)
                Next X
            Next Y
            Value(0) = 86 'показать символы
            comport.Write(Value, 0, 1)
            ComClose()
        End If
        Me.StatusProgress.Visible = False
        Me.Status.Text = "Done"
    End Sub

    Private Sub ReadFromMAX7456CharacterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReadFromMAX7456CharacterToolStripMenuItem.Click
        Max7456Panel1_Read(CurEditorX, CurEditorY)
    End Sub

    Private Sub ShowAllCharacterMAX7456ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowAllCharacterMAX7456ToolStripMenuItem.Click
        Dim Value(0) As Byte
        If ComOpen() = True Then
            Value(0) = 86 'показать символы
            comport.Write(Value, 0, 1)
            ComClose()
        End If
    End Sub

    Private Sub UpdateFrToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateFrToolStripMenuItem.Click
        Dim buffer As Byte()
        Dim ostk As ArduinoSTK
        Me.Status.Text = ""
        Dim dialog As New OpenFileDialog
        dialog.Filter = "*.hex|*.hex"
        dialog.ShowDialog()
        If Not (dialog.FileName <> "") Then
            GoTo Label_0206
        End If
        Dim flag As Boolean = False
        Me.StatusProgress.Visible = True
        Try
            Me.Status.Text = "Reading Hex File"
            buffer = Me.readIntelHEXv2(New StreamReader(dialog.FileName))
        Catch obj1 As Exception
            MessageBox.Show("Bad Hex File")
            Return
        End Try
        Try
            If Me.comport.IsOpen Then
                Me.comport.Close()
            End If
            ostk = New ArduinoSTK
            ostk.PortName = Me.Port.Text
            ostk.BaudRate = 57600
            ostk.DataBits = 8
            ostk.StopBits = Ports.StopBits.One
            ostk.Parity = Ports.Parity.None
            ostk.DtrEnable = False
            ostk.RtsEnable = False

            ostk.Open()
        Catch obj2 As Exception
            MessageBox.Show("Error opening com port", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            Return
        End Try
        Me.Status.Text = "Connecting to Board"
        If ostk.connectAP Then
            AddHandler ostk.Progress, New ArduinoSTK.ProgressEventHandler(AddressOf Me.sp_Progress)
            Try
                Dim i As Integer
                For i = 0 To 3 - 1
                    flag = ostk.uploadflash(buffer, 0, buffer.Length, 0)
                    If flag Then
                        Exit For
                    End If
                    If ostk.keepalive Then
                        Console.WriteLine(("keepalive successful (iter " & i & ")"))
                    Else
                        Console.WriteLine(("keepalive fail (iter " & i & ")"))
                    End If
                Next i
                GoTo Label_01BC
            Catch exception As Exception
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                GoTo Label_01BC
            End Try
        End If
        MessageBox.Show("Failed to talk to bootloader")
Label_01BC:
        ostk.Close()
        If flag Then
            Me.Status.Text = "Done"
            MessageBox.Show("Done!")
        Else
            MessageBox.Show("Upload failed. Lost sync. Try using Arduino to upload instead", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.Status.Text = "Failed"
        End If
Label_0206:
        Me.StatusProgress.Value = 0
        Me.StatusProgress.Visible = False
    End Sub

    Private Sub WriteToMAX7456CharacterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WriteToMAX7456CharacterToolStripMenuItem.Click
        Dim Num As Integer
        Num = CurEditorY * 16 + CurEditorX
        Max7456Panel1_Write(Max7456Panel1.GetSymbol(CurEditorX, CurEditorY), Num)
    End Sub

    Private Sub Port_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Port.SelectedIndexChanged
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\dadlick\FrontEditor", "Com", Me.Port.Text)
    End Sub
End Class
