using Core.Geometry;
using Core.RayTracing;

namespace Core.Scenery;

public class Scene
{
    public Camera Camera { get; private set; }
    public Screen Screen { get; private set; }
    // public Plane Viewpoint { get; private set; }
    
    // TODO: initialize from constructor
    // public Point? LightSource { get; private set; }
    // public List<Shape> Shapes { get; private set; }

    public Scene(Camera camera, Screen screen)
    {
        Camera = camera;
        Screen = screen;
    }

    public void RayTrace(IRayTracer rayTracer)
    {
        Screen.Reset();
        
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
                var tracingResult = rayTracer.Trace(point);
                Screen.SetChar(i, j, tracingResult);
            }
        }
        
        Screen.Draw();
    }
}