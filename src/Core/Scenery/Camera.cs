using Core.Geometry;

namespace Core.Scenery;

public class Camera
{
    public Point Origin { get; private set; }
    public Vector Direction { get; private set; }
    public double Distance { get; private set; }

    private Camera(Point origin, Vector direction, double distance)
    {
        Origin = origin;
        Direction = direction;
        Distance = distance;
    }

    public static Camera CreateNew(Point origin, Vector direction, double distance)
    {
        return new Camera(origin, direction, distance);
    }
}