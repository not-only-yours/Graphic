namespace Core.Scenery;

public class Screen
{
    public int Height { get; private set; }
    public int Width { get; private set; }
    public char[,] Chars { get; private set; }

    private Screen(int height, int width)
    {
        Height = height;
        Width = width;
        Chars = new char[height, width];
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
        Chars[i, j] = c;
    }
    
    public void Reset()
    {
        Chars = new char[Height, Width];
    }
    
    public void Draw()
    {
        for (var i = 0; i < Height; i++)
        {
            for (var j = 0; j < Width; j++)
            {
                Console.Write(Chars[i, j] + " ");
            } 
            Console.WriteLine();
        }
    }
}