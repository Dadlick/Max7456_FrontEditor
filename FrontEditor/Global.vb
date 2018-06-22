Module Type

    Public Max7456_White As System.Drawing.Color = Color.White
    Public Max7456_Black As System.Drawing.Color = Color.Black
    Public Max7456_Transparent As System.Drawing.Color = Color.DeepSkyBlue

    Public Enum PointColor
        Black = 0
        White = 1
        Transparent = 2
    End Enum


    Public Function Picture(Max7456Symbol As Object) As Image
        Dim x As Integer
        Dim y As Integer
        Dim PenColor As System.Drawing.Color

        Dim bm_dest As New Bitmap(96, 144)

        For y = 0 To 17
            For x = 0 To 11
                Select Case Max7456Symbol(x, y)
                    Case PointColor.Black
                        PenColor = Max7456_Black
                    Case PointColor.White
                        PenColor = Max7456_White
                    Case PointColor.Transparent
                        PenColor = Max7456_Transparent
                End Select
                For y1 = y * 8 To y * 8 + 7
                    For x1 = x * 8 To x * 8 + 7
                        bm_dest.SetPixel(x1, y1, PenColor)
                    Next x1
                Next y1
            Next x
        Next y

        Picture = bm_dest

    End Function
End Module
