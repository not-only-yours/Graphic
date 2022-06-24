using Core.Geometry;

namespace Core.Scenery;

public class Camera
{
    public Point Origin { get; private set; }
    public Vector Direction { get; private set; }
    public int Fov { get; private set; }
    public int SizeInPixels { get; private set; }

    private Camera(Point origin, Vector direction, int fov, int sizeInPixels)
    {
        Origin = origin;
        Direction = direction;
        Fov = fov;
        SizeInPixels = sizeInPixels;
    }

    public static Camera CreateNew(Point origin, Vector direction, int fov, int sizeInPixels) =>
        new Camera(origin, direction, fov, sizeInPixels);

    public static Camera CreateDefault()
    {
        var cameraOrigin = Point.FromXYZ(0, 0, 1.5);
        var cameraDirection = Vector.FromXYZ(0, 0, -1);
            
        return new Camera(
            cameraOrigin,
            cameraDirection,
            60,
            200);
    }

    // https://stackoverflow.com/questions/49236966/raytracer-high-fov-distortion
    // https://stackoverflow.com/questions/13554252/calculation-for-ray-generation-in-ray-tracer
    public Vector GetRayOfPixel(int i, int j)
    {
        var fovScale = MathF.Tan(MathF.PI / 180f * Fov / 2);

        // i + 0.5 = move to the center of pixel
        // / size = percentage of the way across the frame
        // 2 * .. - 1 = restrict view by range (-1; 1) 
        var x = (2 * (i + 0.5f) / SizeInPixels - 1) * fovScale;
        var y = (1 - 2 * (j + 0.5f) / SizeInPixels) * fovScale;

        return Vector.FromXYZ(x, y, Direction.Z);
    }
}