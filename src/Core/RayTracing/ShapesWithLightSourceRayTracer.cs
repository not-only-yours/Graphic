using Core.Geometry;
using Core.Geometry.Shapes;
using Core.Geometry.Shapes.Abstract;
using Core.Scenery;

namespace Core.RayTracing;

public class ShapesWithLightSourceRayTracer : IRayTracer
{
    private readonly IEnumerable<Shape> _shapes;
    private readonly Vector _lightSource;
    
    public ShapesWithLightSourceRayTracer(IEnumerable<Shape> shapes, Vector lightSource)
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