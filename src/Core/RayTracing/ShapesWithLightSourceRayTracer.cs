using Core.Geometry;
using Core.Geometry.Shapes;
using Core.Scenery;

namespace Core.RayTracing;

public class ShapesWithLightSourceRayTracer : IRayTracer
{
    private readonly List<Shape> _shapes;
    private readonly Camera _camera;
    private readonly Vector _lightSource;
    
    public ShapesWithLightSourceRayTracer(List<Shape> shapes, Camera camera, Vector lightSource)
    {
        _shapes = shapes;
        _camera = camera;
        _lightSource = lightSource;
    }
        
    public char Trace(Point point)
    {
        var cameraToPoint = point - _camera.Origin;
            
        var nearestShape = _shapes.MinBy(s => s.GetDistanceTo(point));

        var hasIntersection = nearestShape.GetIntersectionWith(_camera.Origin, cameraToPoint) != null;
            
        if (hasIntersection)
        {
            return cameraToPoint.GetUnitVector().Dot(_lightSource) switch
            {
                < 0 => ' ',
                >= 0 and <= 0.2 => '.',
                > 0.2 and <= 0.5 => '*',
                > 0.5 and <= 0.8 => '0',
                > 0.8 => '#',
                _ => throw new ArgumentOutOfRangeException()
            };
        }
        else
        {
            return ' ';
        }
    }
}