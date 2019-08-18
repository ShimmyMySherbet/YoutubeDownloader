Public Class BackgroundRenderer
    Public BackgroundColor As Color
    Public BackgroundImage As Image
    Public Transparency As Double
    Public Sub New(BkCl As Color, BkImg As Image, BkTrns As Double)
        BackgroundColor = BkCl
        BackgroundImage = BkImg
        Transparency = BkTrns
    End Sub
    Public Function Render() As Image
        Dim DrawingBitmap As Bitmap = BackgroundImage.Clone
        'Dim DrawingBitmap As New Bitmap(BackgroundImage.Size.Width, BackgroundImage.Size.Height)
        Dim RenderGraphics As Graphics = Graphics.FromImage(DrawingBitmap)
        RenderGraphics.CompositingMode = Drawing2D.CompositingMode.SourceOver
        RenderGraphics.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
        RenderGraphics.InterpolationMode = Drawing2D.InterpolationMode.High
        RenderGraphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        RenderGraphics.DrawImage(BackgroundImage, New Point(0, 0))
        Dim val As Double = ((Transparency / 100) * 255)
        Dim Newc As Color = Color.FromArgb(val, BackgroundColor)
        Dim newcp As New Pen(Newc)
        Dim newcb As Brush = newcp.Brush
        RenderGraphics.FillRectangle(newcb, New RectangleF(0, 0, DrawingBitmap.Width, DrawingBitmap.Height))
        RenderGraphics.Save()
        Return DrawingBitmap
    End Function
End Class
