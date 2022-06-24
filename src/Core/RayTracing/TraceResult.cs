using Core.Geometry;
using Core.Geometry.Shapes;
using Core.Geometry.Shapes.Abstract;

namespace Core.RayTracing;

public class TraceResult
{
    public Intersection Intersection { get; private set; }
    public double Shading { get; private set; }

    private TraceResult(double shading)
    {
        Shading = shading;
    }

    public static TraceResult FromIntersectionAndLightSource(Intersection? intersection, Vector lightSource)
    {
        // cameraToPoint.GetUnitVector().Dot(_lightSource)
        if (intersection != null)
        {
            // Console.WriteLine("Found " + intersection.Normal!.Dot(lightSource));
            return new TraceResult(intersection.Normal!.Dot(lightSource));
        }
        else
        {
            return new TraceResult(0);
        }
    }

    public static TraceResult InShadow()
    {
        return new TraceResult(0);
    }

    public override string ToString()
    {
        return $"TraceResult({Intersection?.Point}, {Shading})";
    }
}