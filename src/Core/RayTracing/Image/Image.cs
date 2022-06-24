namespace Core.RayTracing.Image;

public class Image<P> where P : IPixel
{
    public int Height { get; private set; }
    public int Width { get; private set; }
    private P[,] _pixels { get; set; }

    private Image(int height, int width)
    {
        Height = height;
        Width = width;
        _pixels = new P[height, width];
    }

    public static Image<P> FromResolution(int resolution) => new(resolution, resolution);

    public static Image<P> FromTraceResults(TraceResult[,] traceResults, Func<TraceResult, P> pixelBuilder)
    {
        var image = new Image<P>(traceResults.GetLength(0), traceResults.GetLength(1));
        
        for (int i = 0; i < image.Height; i++)
        {
            for (int j = 0; j < image.Width; j++)
            {
                image[i, j] = pixelBuilder(traceResults[i, j]);
            }
        }

        return image;
    }

    // public static Screen FromResolutionAndCamera(int resolution, Camera camera)
    // {
    //     var planeCenter = camera.Origin.MoveInDirection(camera.Direction, camera.Distance);
    //
    //     return new Screen(resolution, resolution, Plane.FromCenterAndNormal(planeCenter, camera.Direction));
    // }
    
    public P this[int x, int y]
    {
        get => _pixels[x, y];
        set => _pixels[x, y] = value;
    }
    
    
}