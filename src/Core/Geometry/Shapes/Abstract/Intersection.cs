namespace Core.Geometry.Shapes.Abstract;

public class Intersection
{
    public Point Point { get; private set; }
    public double Distance { get; private set; }
    public Vector Normal { get; private set; }

    private Intersection(Point point, double distance, Vector normal)
    {
        Point = point;
        Distance = distance;
        Normal = normal.GetUnitVector();
    }

    public static Intersection Found(Point point, double distance, Vector normal) => new(point, distance, normal);
}