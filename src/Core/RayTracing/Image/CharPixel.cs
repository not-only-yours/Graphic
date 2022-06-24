namespace Core.RayTracing.Image;

public class CharPixel : IPixel
{
    public char Char { get; }
    
    private CharPixel(char c)
    {
        Char = c;
    }

    
    public static CharPixel FromTraceResult(TraceResult traceResult)
    {
        if (traceResult.HasIntersection())
        {
            var c = traceResult.Shading switch
            {
                < 0 => ' ',
                >= 0 and <= 0.2 => '.',
                > 0.2 and <= 0.5 => '*',
                > 0.5 and <= 0.8 => '0',
                > 0.8 => '#',
                _ => throw new ArgumentOutOfRangeException()
            };
            return new CharPixel(c);
        }
        else
        {
            return new CharPixel(' ');
        }
    }
}