using Core.Geometry;
using Core.Geometry.Shapes;
using Core.Geometry.Shapes.Abstract;
using Core.Mathematics;

namespace Core.RayTracing.RayTracers;

public class ShadowsRayTracer : IRayTracer
{
    private readonly IEnumerable<Shape> _shapes;
    private readonly Vector _lightSource;
    
    public ShadowsRayTracer(IEnumerable<Shape> shapes, Vector lightSource)
    {
        _shapes = shapes;
        _lightSource = lightSource;
    }
        
    public TraceResult Trace(Point origin, Vector direction)
    {
        Intersection? nearestIntersection = null;
        
        foreach (var shape in _shapes)
        {
            var shapeIntersection = shape.GetIntersectionWith(origin, direction); //TODO: pass nearestIntersection to abort early inside GetIntersectionWith
            
            if (
                shapeIntersection != null && 
                (shapeIntersection.Distance < nearestIntersection?.Distance || nearestIntersection == null))
            {
                nearestIntersection = shapeIntersection;
            }
        }

        if (nearestIntersection == null) return TraceResult.FromIntersectionAndLightSource(null, _lightSource);

        var shadowRayOrigin = nearestIntersection.Point + nearestIntersection.Normal * Constants.Eps;
        var shadowRayDirection = -_lightSource;
        
        var inShadow = _shapes.Select(shape => shape.GetIntersectionWith(shadowRayOrigin, shadowRayDirection)).Any(intersection => intersection != null);
        if (inShadow) return TraceResult.FromInShadow(nearestIntersection);
        
        return TraceResult.FromIntersectionAndLightSource(nearestIntersection, _lightSource);
    }
}