using Core.Geometry;
using Core.Geometry.Shapes.Abstract;

namespace Core.RayTracing.RayTracers;

public class DefaultRayTracer : IRayTracer
{
    private readonly IEnumerable<Shape> _shapes;
    private readonly Vector _lightSource;
    
    public DefaultRayTracer(IEnumerable<Shape> shapes, Vector lightSource)
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

        return TraceResult.FromIntersectionAndLightSource(nearestIntersection, _lightSource);
    }
}