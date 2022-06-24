using Core.Geometry;

namespace Core.Scenery;

public class Camera
{
    public Point Origin { get; private set; }
    public Vector Direction { get; private set; }
    public int Fov { get; private set; }
    public int SizeInPixels { get; private set; }

    // private Point _viewpointLeftTop;

    private Camera(Point origin, Vector direction, int fov, int sizeInPixels)
    {
        Origin = origin;
        Direction = direction;
        Fov = fov;
        SizeInPixels = sizeInPixels;

        // var viewpointCenter = Origin + Direction * Distance;
        
        // _viewpointLeftTop = Point.FromXYZ(
        //     viewpointCenter.X - (SizeInPixels / 2.0 * DistancePerPixel),
        //     viewpointCenter.Y - (SizeInPixels / 2.0 * DistancePerPixel),
        //     viewpointCenter.Z);
    }

    public static Camera CreateNew(Point origin, Vector direction, int fov, int sizeInPixels) =>
        new Camera(origin, direction, fov, sizeInPixels);

    public static Camera CreateDefault()
    {
        var cameraOrigin = Point.FromXYZ(0, 0, 1.15);
        var cameraDirection = Vector.FromXYZ(0, 0, -1);
            
        // Viewpoint = Plane.FromCenterAndNormal(
        //     cameraOrigin + cameraDirection * distanceFromCameraToViewpoint,
        //     cameraDirection);
            
        return new Camera(
            cameraOrigin,
            cameraDirection,
            60,
            100);
    }

    public Vector GetRayOfPixel(int i, int j)
    {
        var fovScale = MathF.Tan(MathF.PI / 180f * Fov / 2);

        // from -1 to 1, square, origin in the center
        var xxScreen = (2 * ((i + 0.5f) / SizeInPixels) - 1);
        var yyScreen = (1 - 2 * ((j + 0.5f) / SizeInPixels));

        var xx = xxScreen * fovScale;
        var yy = yyScreen * fovScale;

        var ray = Vector.FromXYZ(xx, yy, -1);

        if (i % 100 == 0 && j % 100 == 0)
        {
            Console.WriteLine(i + " " + j);
        }
        
        // var point = Point.FromXYZ(
        //     _viewpointLeftTop.X + i * DistancePerPixel,
        //     _viewpointLeftTop.Y + j * DistancePerPixel,
        //     _viewpointLeftTop.Z);
        
        return ray;
    }
}