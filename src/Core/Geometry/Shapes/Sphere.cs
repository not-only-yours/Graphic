using Core.Geometry.Shapes.Abstract;
using Core.Matrices;

namespace Core.Geometry.Shapes;

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
    public override Intersection? GetIntersectionWith(Point origin, Vector ray)
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

            var point1 = origin + ray * (-0.5 * b / a);
            
            // Only one intersection
            return Intersection.Found(
                point1,
                point1.DistanceTo(Center),
                point1 - Center);
        }
        
        double t = (-b + Math.Sqrt(discriminant)) / (2 * a);
        double t2 = -b / a - t;
        // TODO: compare to tMax (pass as param)
        if (Math.Abs(t2) < Math.Abs(t)) t = t2;

        var point = origin + ray * t;
        
        return a!=0 ? Intersection.Found(
            point,
            point.DistanceTo(Center),
            point - Center)
                : null;
    }

    // public override double GetDistanceTo(Point point)
    // {
    //     return Math.Abs(Center.DistanceTo(point) - Radius);
    // }

    public override void Transform(Matrix4x4 transformationMatrix)
    {
        throw new NotImplementedException();
    }

    public override string ToString()
    {
        return $"Sphere(Center={Center}, Radius={Radius})";
    }
}
