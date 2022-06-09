using Core.Geometry;
using Core.Geometry.Shapes;

namespace Core.Scenery;

public class Scene
{
    public Camera Camera { get; private set; }
    public Screen Screen { get; private set; }
    // public Plane Viewpoint { get; private set; }
    
    // TODO: initialize from constructor
    // public Point? LightSource { get; private set; }
    // public List<Shape> Shapes { get; private set; }

    private Scene()
    {
        var cameraOrigin = Point.FromXYZ(0, 0, 0);
        var distanceFromCameraToViewpoint = 10.0;
        var cameraDirection = Vector.FromXYZ(0, 0, 1);
        
        // Viewpoint = Plane.FromCenterAndNormal(
        //     cameraOrigin + cameraDirection * distanceFromCameraToViewpoint,
        //     cameraDirection);
        
        Camera = Camera.CreateNew(
            cameraOrigin,
            cameraDirection,
            distanceFromCameraToViewpoint);
        
        Screen = Screen.FromResolution(60);
    }

    public static Scene CreateNew() => new();

    public IEnumerable<(Point point, int i, int j)> GetViewpointPoints()
    {
        var points = new List<(Point point, int i, int j)>();

        var viewpointCenter = Camera.Origin + Camera.Direction * Camera.Distance;

        // TODO: scale image
        var leftX = viewpointCenter.X - Screen.Height / 2.0;
        var leftY = viewpointCenter.Y - Screen.Width / 2.0;
        
        for (var i = 0; i < Screen.Height; i++)
        {
            for (var j = 0; j < Screen.Width; j++)
            {
                // Currently viewpoint and points are both hardcoded
                var point = Point.FromXYZ(leftX + i, leftY + j, viewpointCenter.Z);
                points.Add((point, i, j));
            }
        }

        return points;
    }
    
    public void DrawRayTracing(Sphere sphere)
    {
        Screen.Reset();
        
        foreach (var point in GetViewpointPoints())
        {
            var hasIntersection = sphere.GetIntersectionWith(Camera.Origin, point.point - Camera.Origin) != null;

            Screen.SetChar(point.i, point.j, hasIntersection ? '#' : ' ');
        }

        Screen.Draw();
    }

    public void DrawRayTracing(Vector lightSource, Sphere sphere)
    {
        Screen.Reset();
        
        foreach (var point in GetViewpointPoints())
        {
            var cameraToPoint = point.point - Camera.Origin;
            
            var hasIntersection = sphere.GetIntersectionWith(Camera.Origin, cameraToPoint) != null;
            
            if (hasIntersection)
            {
                var ch = cameraToPoint.GetUnitVector().Dot(lightSource) switch
                {
                    < 0 => ' ',
                    >= 0 and <= 0.2 => '.',
                    > 0.2 and <= 0.5 => '*',
                    > 0.5 and <= 0.8 => '0',
                    > 0.8 => '#',
                    _ => throw new ArgumentOutOfRangeException()
                };

                Screen.SetChar(point.i, point.j, ch);

            }
            else
            {
                Screen.SetChar(point.i, point.j, ' ');
            }
        }
        
        Screen.Draw();
    }
    
    public void DrawRayTracing(Vector lightSource, List<Shape> shapes)
    {
        Screen.Reset();

        foreach (var point in GetViewpointPoints())
        {
            var cameraToPoint = point.point - Camera.Origin;
            
            shapes.Sort((s1, s2) => s1.GetDistanceTo(point.point).CompareTo(s2.GetDistanceTo(point.point)));
            var nearestShape = shapes.First();

            var hasIntersection = nearestShape.GetIntersectionWith(Camera.Origin, cameraToPoint) != null;
            
            if (hasIntersection)
            {
                var ch = cameraToPoint.GetUnitVector().Dot(lightSource) switch
                {
                    < 0 => ' ',
                    >= 0 and <= 0.2 => '.',
                    > 0.2 and <= 0.5 => '*',
                    > 0.5 and <= 0.8 => '0',
                    > 0.8 => '#',
                    _ => throw new ArgumentOutOfRangeException()
                };

                Screen.SetChar(point.i, point.j, ch);

            }
            else
            {
                Screen.SetChar(point.i, point.j, ' ');
            }
        }
        
        Screen.Draw();
    }
}