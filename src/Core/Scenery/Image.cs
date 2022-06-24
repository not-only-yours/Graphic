using Core.RayTracing;

namespace Core.Scenery;

public class Image
{
    public int Height { get; private set; }
    public int Width { get; private set; }
    private TraceResult[,] _pixels { get; set; }

    private Image(int height, int width)
    {
        Height = height;
        Width = width;
        _pixels = new TraceResult[height, width];
    }

    public static Image FromResolution(int resolution) => new(resolution, resolution);

    // public static Screen FromResolutionAndCamera(int resolution, Camera camera)
    // {
    //     var planeCenter = camera.Origin.MoveInDirection(camera.Direction, camera.Distance);
    //
    //     return new Screen(resolution, resolution, Plane.FromCenterAndNormal(planeCenter, camera.Direction));
    // }
    
    public TraceResult this[int x, int y]
    {
        get => _pixels[x, y];
        set => _pixels[x, y] = value;
    }
    
    
}