using Core.Geometry;
using Core.Geometry.Shapes;
using Core.Geometry.Shapes.Abstract;

namespace Core.RayTracing;

public class TraceResult
{
    public double Shading { get; private set; }
    public bool HasIntersection() => _intersection != null;

    private Intersection? _intersection { get; set; }
    

    private TraceResult(Intersection? intersection, double shading)
    {
        _intersection = intersection;
        Shading = shading;
    }

    public static TraceResult FromIntersectionAndLightSource(Intersection? intersection, Vector lightSource)
    {
        if (intersection != null)
        {
            return FromIntersection(intersection, lightSource);
        }
        else
        {
            return FromMissingIntersection();
        }
    }

    private static TraceResult FromIntersection(Intersection intersection, Vector lightSource)
    {
        var shading = (-lightSource).Dot(intersection.Normal);
        return new TraceResult(intersection, shading); 
    }

    private static TraceResult FromMissingIntersection()
    {
        return new TraceResult(null, -3);
    }

    public static TraceResult FromInShadow(Intersection? intersection)
    {
        return new TraceResult(intersection, 0);
    }

    public override string ToString()
    {
        return $"TraceResult({_intersection?.Point}, {Shading})";
    }
}