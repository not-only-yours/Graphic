namespace Core.RayTracing.Image;

public class ColoredPixel : IPixel
{
    public byte R { get; }
    public byte G { get; }
    public byte B { get; }
    
    private ColoredPixel(byte r, byte g, byte b)
    {
        R = r;
        G = g;
        B = b;
    }

    public static ColoredPixel YellowGreen() => new(154, 205, 50);
    // public static ColoredPixel YellowGreen() => new(70, 130, 180);
    
    public static ColoredPixel FromTraceResult(TraceResult traceResult)
    {
        if (traceResult.HasIntersection())
        {
            var shadingValue = Math.Max(0, traceResult.Shading);
            var rgbValue = (byte)(shadingValue * 255);
            return new ColoredPixel(
                rgbValue, 
                rgbValue,
                rgbValue);
        }
        else
        {
            return ColoredPixel.YellowGreen();
        }
    }
}