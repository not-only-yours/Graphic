using Graphic.Geometry.Shapes;
using NUnit.Framework;

namespace Graphic;

public class Screen
{
    public int Height { get; private set; }
    public int Width { get; private set; }
    
    private char[,] _chars;

    private Screen(int height, int width)
    {
        Height = height;
        Width = width;
        _chars = new char[height, width];
    }

    public static Screen FromResolution(int resolution) => new(resolution, resolution);

    // public static Screen FromResolutionAndCamera(int resolution, Camera camera)
    // {
    //     var planeCenter = camera.Origin.MoveInDirection(camera.Direction, camera.Distance);
    //
    //     return new Screen(resolution, resolution, Plane.FromCenterAndNormal(planeCenter, camera.Direction));
    // }
    
    public void SetChar(int i, int j, char c)
    {
        _chars[i, j] = c;
    }
    
    public void Reset()
    {
        _chars = new char[Height, Width];
    }
    
    public void Draw()
    {
        for (var i = 0; i < Height; i++)
        {
            for (var j = 0; j < Width; j++)
            {
                Console.Write(_chars[i, j] + " ");
            } 
            Console.WriteLine();
        }
    }
}