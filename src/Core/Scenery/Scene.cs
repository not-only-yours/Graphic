using Core.Geometry;
using Core.RayTracing;

namespace Core.Scenery;

public class Scene
{
    public Camera Camera { get; private set; }
    public Screen Screen { get; private set; }
    // public Plane Viewpoint { get; private set; }
    private Vector RGB_Gray = Vector.FromXYZ(255, 255, 255);
    
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
    
    public void GenerateRayTracePicture(String outputFile)
    {
        var writer = new StreamWriter(outputFile);
        writer.WriteLine("P3");
        writer.WriteLine($"{Screen.Width}  {Screen.Height}");
        writer.WriteLine("255");
        for (var x = 0; x < Screen.Height; x++)
        {
            for (var y = 0; y < Screen.Width; y++)
            {
                switch (Screen.Chars[x, y])
                {
                    case ' ':
                        writer.WriteLine((int)(RGB_Gray * 0).X + " " + (int)(RGB_Gray * 0).Y + " " + (int)(RGB_Gray * 0).Z);
                        break;
                    case '.':
                        writer.WriteLine((int)(RGB_Gray * 0.1).X + " " + (int)(RGB_Gray * 0.1).Y + " " + (int)(RGB_Gray * 0.1).Z);
                        break;
                    case '*':
                        writer.WriteLine((int)(RGB_Gray * 0.35).X + " " + (int)(RGB_Gray * 0.35).Y + " " + (int)(RGB_Gray * 0.35).Z);
                        break;
                    case '0':
                        writer.WriteLine((int)(RGB_Gray * 0.65).X + " " + (int)(RGB_Gray * 0.65).Y + " " + (int)(RGB_Gray * 0.65).Z);
                        break;
                    case '#':
                        writer.WriteLine((int)(RGB_Gray * 1).X + " " + (int)(RGB_Gray * 1).Y + " " + (int)(RGB_Gray * 1).Z);
                        break;
                }
            }
        }
        writer.Flush();
        writer.Close();
    }
}