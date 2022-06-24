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
    public override Intersection? GetIntersectionWith(Point rayOrigin, Vector rayDirection)
    {
        Vector originToCenter = rayOrigin - Center;
        double a = rayDirection.Dot(rayDirection);
        double b = 2 * rayDirection.Dot(originToCenter);
        double c = originToCenter.Dot(originToCenter) - Radius * Radius;
        double discriminant = b * b - 4 * a * c;
        
        if (discriminant < 0.0f)
        {
            // No Intersection
            return null;
        }
        else if (discriminant == 0)
        {
            if (rayDirection.IsZero()) return null;

            var t = (-0.5 * b / a);
            var point = rayOrigin + rayDirection * t;
            
            // Only one intersection
            return Intersection.Found(
                point,
                t,
                point - Center);
        }
        else
        {
            double t = (-b + Math.Sqrt(discriminant)) / (2 * a);
            double t2 = -b / a - t;
            // TODO: compare to tMax (pass as param)
            if (Math.Abs(t2) < Math.Abs(t)) t = t2;

            if (t < 0) return null;
            
            var point = rayOrigin + rayDirection * t;

            return Intersection.Found(
                point,
                t,
                point - Center);
        }
    }

    public override void Transform(Matrix4x4 transformationMatrix)
    {
        throw new NotImplementedException();
    }

    public override string ToString()
    {
        return $"Sphere(Center={Center}, Radius={Radius})";
    }
}
