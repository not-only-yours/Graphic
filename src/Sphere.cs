namespace Graphic;

public class Sphere
{
    public Point Center { get; private set; }
    public double Radius { get; private set; }
    
    private Sphere(Point center, double radius)
    {
        Center = center;
        Radius = radius;
    }

    public static Sphere FromCentreAndRadium(Point center, double radius) => new(center, radius);

    public Point? IsIntersectionWith(Point rayOrigin, Vector ray)
    {
        Vector CenterToRayOrigin = Vector.FromPoints(Center, rayOrigin);
        double p = ray.Dot(CenterToRayOrigin);
        double q = CenterToRayOrigin.Dot(CenterToRayOrigin) - (Radius * Radius);
        double discriminant = (p * p) - q;
        if (discriminant < 0.0f)
        {
            Console.WriteLine("No Intersection");
            return null;
        }
        double dRoot = Math.Sqrt(discriminant);
        
        if (dRoot == 0)
        {
            double dist = -p;
            Console.WriteLine("Only one point");
            return Point.FromXYZ(rayOrigin.X + ray.X * dist, rayOrigin.Y + ray.Y * dist, rayOrigin.Z + ray.Z * dist);
        }
        else
        {
            double dist1 = -p - dRoot;
            double dist2 = -p + dRoot;
            //returned only front point
            return dist1 < dist2 ? 
                Point.FromXYZ(rayOrigin.X + ray.X * dist1, rayOrigin.Y + ray.Y * dist1, rayOrigin.Z + ray.Z * dist1) : 
                Point.FromXYZ(rayOrigin.X + ray.X * dist2, rayOrigin.Y + ray.Y * dist2, rayOrigin.Z + ray.Z * dist2);
        }
    }
}
