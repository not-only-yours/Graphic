using Core.Geometry;
using Core.RayTracing;
using Core.RayTracing.Image;

namespace Core.Scenery;

public class Scene
{
    public Camera Camera { get; private set; }
    // public Screen Screen { get; private set; }
    // public Plane Viewpoint { get; private set; }
   
    
    // TODO: initialize from constructor
    // public Point? LightSource { get; private set; }
    // public List<Shape> Shapes { get; private set; }

    public Scene(Camera camera)
    {
        Camera = camera;
    }

    public TraceResult[,] RayTrace(IRayTracer rayTracer)
    {
        var results = new TraceResult[Camera.SizeInPixels, Camera.SizeInPixels];
        
        // Console.WriteLine(Camera.GetPointOfPixel(0, 0));
        // Console.WriteLine(Camera.GetPointOfPixel(Camera.SizeInPixels - 1, Camera.SizeInPixels - 1));
        
        for (var i = 0; i < Camera.SizeInPixels; i++)
        {
            for (var j = 0; j < Camera.SizeInPixels; j++)
            {
                // Currently viewpoint and points are both hardcoded
                var ray = Camera.GetRayOfPixel(i, j);
                results[i, j] = rayTracer.Trace(Camera.Origin, ray);
            }
        }

        return results;
    }
    
    
}