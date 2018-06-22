Imports System
Imports System.IO.Ports
Imports System.Runtime.CompilerServices
Imports System.Threading


Friend Class ArduinoSTK
    Inherits SerialPort
    ' Events
    Public Delegate Sub ProgressEventHandler(progress As Integer)

    Public Event Progress As ProgressEventHandler


    ' Methods
    Public Shadows Function Close() As Boolean
        Try
            Dim buffer As Byte() = New Byte() {&H51, &H20}
            MyBase.Write(buffer, 0, buffer.Length)
        Catch obj1 As Exception
        End Try
        If MyBase.IsOpen Then
            MyBase.Close()
        End If
        MyBase.DtrEnable = False
        MyBase.RtsEnable = False
        Return True
    End Function

    Public Function connectAP() As Boolean
        If MyBase.IsOpen Then
            Dim num As Integer = 0
            Do While (num < 50)
                MyBase.DiscardInBuffer()
                MyBase.Write(New Byte() {&H30, &H20}, 0, 2)
                num += 1
                Thread.Sleep(50)
                Console.WriteLine("btr {0}", MyBase.BytesToRead)
                If (MyBase.BytesToRead >= 2) Then
                    Dim num2 As Byte = CByte(MyBase.ReadByte)
                    Dim num3 As Byte = CByte(MyBase.ReadByte)
                    If ((num2 = 20) AndAlso (num3 = &H10)) Then
                        Return True
                    End If
                End If
            Loop
        End If
        Return False
    End Function

    Public Function download(ByVal length As Short) As Byte()
        If Not MyBase.IsOpen Then
            Throw New Exception
        End If
        Dim buffer As Byte() = New Byte(length - 1) {}
        Dim buffer3 As Byte() = New Byte() {&H74, 0, 0, &H45, &H20}
        buffer3(1) = CByte((length >> 8))
        buffer3(2) = CByte((length And &HFF))
        Dim buffer2 As Byte() = buffer3
        MyBase.Write(buffer2, 0, buffer2.Length)
        If (MyBase.ReadByte = 20) Then
            Dim i As Integer
            For i = 0 To length - 1
                buffer(i) = CByte(MyBase.ReadByte)
            Next i
            If (MyBase.ReadByte <> &H10) Then
                Me.down_flag = False
                Return buffer
            End If
        Else
            Me.down_flag = False
            Return buffer
        End If
        Me.down_flag = True
        Return buffer
    End Function

    Public Function downloadflash(ByVal length As Short) As Byte()
        If Not MyBase.IsOpen Then
            Throw New Exception("Port Not Open")
        End If
        Dim buffer As Byte() = New Byte(length - 1) {}
        MyBase.ReadTimeout = &H3E8
        Dim buffer3 As Byte() = New Byte() {&H74, 0, 0, 70, &H20}
        buffer3(1) = CByte((length >> 8))
        buffer3(2) = CByte((length And &HFF))
        Dim buffer2 As Byte() = buffer3
        MyBase.Write(buffer2, 0, buffer2.Length)
        If (MyBase.ReadByte <> 20) Then
            Throw New Exception("Lost Sync 0x14")
        End If
        Dim i As Integer = length
        Do While (i > 0)
            i = (i - MyBase.Read(buffer, (length - i), i))
        Loop
        If (MyBase.ReadByte <> &H10) Then
            Throw New Exception("Lost Sync 0x10")
        End If
        Return buffer
    End Function

    Public Function keepalive() As Boolean
        MyBase.DtrEnable = False
        Thread.Sleep(50)
        MyBase.DtrEnable = True
        Thread.Sleep(50)
        Return Me.connectAP
    End Function

    Public Shadows Sub Open()
        MyBase.Open()
        MyBase.DtrEnable = False
        MyBase.RtsEnable = False
        Thread.Sleep(50)
        MyBase.DtrEnable = True
        MyBase.RtsEnable = True
        Thread.Sleep(50)
    End Sub

    Public Function setaddress(ByVal address As Integer) As Boolean
        If Not MyBase.IsOpen Then
            Return False
        End If
        If ((address Mod 2) = 1) Then
            Throw New Exception("Address must be an even number")
        End If
        Console.WriteLine(("Sending address   " & CUShort((address / 2))))
        address = (address / 2)
        address = CUShort(address)
        Dim buffer As Byte() = New Byte() {&H55, CByte((address And &HFF)), CByte((address >> 8)), &H20}
        MyBase.Write(buffer, 0, buffer.Length)
        Return Me.sync
    End Function

    Public Function sync() As Boolean
        If MyBase.IsOpen Then
            MyBase.ReadTimeout = &H3E8
            Dim num As Integer = 0
            Do While (MyBase.BytesToRead < 1)
                num += 1
                Thread.Sleep(1)
                If (num > &H3E8) Then
                    Return False
                End If
            Loop
            Dim i As Integer
            For i = 0 To 10 - 1
                If (MyBase.BytesToRead >= 2) Then
                    Dim num3 As Byte = CByte(MyBase.ReadByte)
                    Dim num4 As Byte = CByte(MyBase.ReadByte)
                    Console.WriteLine("bytes {0:X} {1:X}", num3, num4)
                    If ((num3 = 20) AndAlso (num4 = &H10)) Then
                        Return True
                    End If
                End If
                Console.WriteLine("btr {0}", MyBase.BytesToRead)
                Thread.Sleep(20)
            Next i
        End If
        Return False
    End Function

    Public Function upload(ByVal data As Byte(), ByVal startfrom As Short, ByVal length As Short, ByVal startaddress As Short) As Boolean
        If Not MyBase.IsOpen Then
            Return False
        End If
        Dim num As Integer = (length / &H100)
        Dim num2 As Integer = length
        Dim count As Integer = 0
        Dim i As Integer = 0
        Do While (i <= num)
            If (num2 > &H100) Then
                count = &H100
            Else
                count = num2
            End If
            If (count = 0) Then
                Return True
            End If
            Me.setaddress(startaddress)
            startaddress = CShort((startaddress + CShort(count)))
            Dim buffer As Byte() = New Byte() {100, CByte((count >> 8)), CByte((count And &HFF)), &H45}
            MyBase.Write(buffer, 0, buffer.Length)
            Console.WriteLine(((startfrom + (length - num2)) & " - " & count))
            MyBase.Write(data, (startfrom + (length - num2)), count)
            buffer = New Byte() {&H20}
            MyBase.Write(buffer, 0, buffer.Length)
            num2 = (num2 - count)
            If Not Me.sync Then
                Console.WriteLine(String.Concat(New Object() {"No Sync in loop count ", i, " of ", num}))
                Return False
            End If
            i += 1
        Loop
        Return True
    End Function

    Public Function uploadflash(ByVal data As Byte(), ByVal startfrom As Integer, ByVal length As Integer, ByVal startaddress As Integer) As Boolean
        If Not MyBase.IsOpen Then
            Return False
        End If
        Dim num As Integer = (length / &H100)
        Dim num2 As Integer = length
        Dim count As Integer = 0
        Dim i As Integer = 0
        Do While (i <= num)
            If (num2 > &H100) Then
                count = &H100
            Else
                count = num2
            End If
            If (count = 0) Then
                Return True
            End If
            Me.setaddress(startaddress)
            startaddress = (startaddress + count)
            Dim buffer As Byte() = New Byte() {100, CByte((count >> 8)), CByte((count And &HFF)), 70}
            MyBase.Write(buffer, 0, buffer.Length)
            Console.WriteLine(((startfrom + (length - num2)) & " - " & count))
            MyBase.Write(data, (startfrom + (length - num2)), count)
            buffer = New Byte() {&H20}
            MyBase.Write(buffer, 0, buffer.Length)
            num2 = (num2 - count)

            RaiseEvent Progress(CInt(Math.Truncate((CSng(startaddress) / CSng(length)) * 100)))
            If Not Me.sync Then
                Console.WriteLine("No Sync")
                RaiseEvent Progress(0)
                Return False
            End If
            i += 1
        Loop
        Return True
    End Function


    ' Fields
    Public down_flag As Boolean

    ' Nested Types

End Class


