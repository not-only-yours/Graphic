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

    public Point? GetIntersectionWith(Point rayOrigin, Vector ray)
    {
        Vector centerToRayOrigin = Vector.FromPoints(Center, rayOrigin);
        double p = ray.Dot(centerToRayOrigin);
        double q = centerToRayOrigin.Dot(centerToRayOrigin) - Radius * Radius;
        double discriminant = p * p - q;
        
        if (discriminant < 0.0f)
        {
            // No Intersection
            return null;
        }
        
        double dRoot = Math.Sqrt(discriminant);
        
        if (dRoot == 0)
        {
            // Only one intersection
            double dist = -p;
            return Point.FromXYZ(rayOrigin.X + ray.X * dist, rayOrigin.Y + ray.Y * dist, rayOrigin.Z + ray.Z * dist);
        }
        
        double dist1 = -p - dRoot;
        double dist2 = -p + dRoot;
        //returned only front point
        return dist1 < dist2 ? 
            Point.FromXYZ(rayOrigin.X + ray.X * dist1, rayOrigin.Y + ray.Y * dist1, rayOrigin.Z + ray.Z * dist1) : 
            Point.FromXYZ(rayOrigin.X + ray.X * dist2, rayOrigin.Y + ray.Y * dist2, rayOrigin.Z + ray.Z * dist2);
    }
}
