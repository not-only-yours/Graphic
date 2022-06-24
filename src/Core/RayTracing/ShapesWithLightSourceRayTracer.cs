using Core.Geometry;
using Core.Geometry.Shapes;
using Core.Geometry.Shapes.Abstract;
using Core.Scenery;

namespace Core.RayTracing;

public class ShapesWithLightSourceRayTracer : IRayTracer
{
    private readonly IEnumerable<Shape> _shapes;
    private readonly Camera _camera;
    private readonly Vector _lightSource;
    
    public ShapesWithLightSourceRayTracer(IEnumerable<Shape> shapes, Camera camera, Vector lightSource)
    {
        _shapes = shapes;
        _camera = camera;
        _lightSource = lightSource;
    }
        
    public TraceResult Trace(Point origin, Vector direction)
    {
        // var cameraToPoint = point - _camera.Origin;

        Intersection? nearestIntersection = null;
        
        foreach (var shape in _shapes)
        {
            var shapeIntersection = shape.GetIntersectionWith(origin, direction); //TODO: pass nearestIntersection to abort early inside GetIntersectionWith
            // if (shapeIntersection != null)
            // {
            //     if (nearestIntersection?.Distance > shapeIntersection.Distance) continue;
            //     nearestIntersection = shapeIntersection;
            // }
            
            // Console.WriteLine("D " + nearestIntersection?.Distance);
            
            if (
                shapeIntersection != null && 
                (shapeIntersection.Distance < nearestIntersection?.Distance || nearestIntersection == null))
            {
                nearestIntersection = shapeIntersection;
            }
        }

        // if (point.X == 0 && point.Y == 0)
        // {
        //     Console.WriteLine(nearestIntersection.Point + " " + nearestIntersection.IsFound());
        // }
        
        return TraceResult.FromIntersectionAndLightSource(nearestIntersection, _lightSource);
            
        // if (hasIntersection)
        // {
        //     return cameraToPoint.GetUnitVector().Dot(_lightSource) switch
        //     {
        //         < 0 => ' ',
        //         >= 0 and <= 0.2 => '.',
        //         > 0.2 and <= 0.5 => '*',
        //         > 0.5 and <= 0.8 => '0',
        //         > 0.8 => '#',
        //         _ => throw new ArgumentOutOfRangeException()
        //     };
        // }
        // else
        // {
        //     return ' ';
        // }
    }
}