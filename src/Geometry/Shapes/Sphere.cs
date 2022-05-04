namespace Graphic.Geometry.Shapes;

public class Sphere : Shape
{
    public Point Center { get; private set; }
    public double Radius { get; private set; }
    
    private Sphere(Point center, double radius)
    {
        Center = center;
        Radius = radius;
    }

    public static Sphere FromCentreAndRadius(Point center, double radius) => new(center, radius);

    // http://www.cplusplus.com/forum/general/279409/
    public override Point? GetIntersectionWith(Point origin, Vector ray)
    {
        Vector originToCenter = origin - Center;
        double a = ray.Dot(ray);
        double b = 2 * ray.Dot(originToCenter);
        double c = originToCenter.Dot(originToCenter) - Radius * Radius;
        double discriminant = b * b - 4 * a * c;
        
        if (discriminant < 0.0f)
        {
            // No Intersection
            return null;
        }
        
        if (discriminant == 0)
        {
            if (ray.IsZero()) return null;
            
            // Only one intersection
            return origin + ray * (-0.5 * b / a);
        }
        
        double t = (-b + Math.Sqrt(discriminant)) / (2 * a);
        double t2 = -b / a - t;
        if (Math.Abs(t2) < Math.Abs(t)) t = t2;
        return origin + ray * t;
        // Vector centerToRayOrigin = Vector.FromPoints(Center, rayOrigin);
        // double p = ray.Dot(centerToRayOrigin);
        // double q = centerToRayOrigin.Dot(centerToRayOrigin) - Radius * Radius;
        // double discriminant = p * p - q;
        //
        // if (discriminant < 0.0f)
        // {
        //     // No Intersection
        //     return null;
        // }
        //
        // double dRoot = Math.Sqrt(discriminant);
        //
        // if (dRoot == 0)
        // {
        //     // Only one intersection
        //     double dist = -p;
        //     return Point.FromXYZ(rayOrigin.X + ray.X * dist, rayOrigin.Y + ray.Y * dist, rayOrigin.Z + ray.Z * dist);
        // }
        //
        // double dist1 = -p - dRoot;
        // double dist2 = -p + dRoot;
        // //returned only front point
        // return dist1 < dist2 ? 
        //     Point.FromXYZ(rayOrigin.X + ray.X * dist1, rayOrigin.Y + ray.Y * dist1, rayOrigin.Z + ray.Z * dist1) : 
        //     Point.FromXYZ(rayOrigin.X + ray.X * dist2, rayOrigin.Y + ray.Y * dist2, rayOrigin.Z + ray.Z * dist2);
    }
}
