namespace Graphic;

public class Display
{
    public int displayHeight { get; private set; }
    public int displayLength { get; private set; }
    public Rectangle display { get; private set; }
    public List<Vector> rays { get; private set; }

    public Display(int x, int y, Point camera)
    {
        displayHeight = x;
        displayLength = y;
        
        display = Rectangle.FromPoints(
            Point.FromXYZ(0, displayLength, 0), 
            Point.FromXYZ(displayLength, 0, 0), 
            Point.FromXYZ(0, displayLength, displayHeight),
            Point.FromXYZ(displayLength, 0, displayHeight)
        );
        rays = new List<Vector>();
        for (int i = 0; i < displayLength; i++)
        {
            for (int j = 0; j < displayHeight; j++)
            {
                Console.WriteLine((0 + j)+" "+ (displayLength - j)+ " "+ i);
                rays.Add(Vector.FromPoints(camera, Point.FromXYZ(0 + j, displayLength - j -1, i)));
            } 
        }
    }


    public void RayTracing(Point camera, Sphere s)
    {
        int[,] answer = new int[displayHeight + 1, displayLength + 1];
        foreach (Vector v in rays)
        {
            Console.WriteLine(v.ToString());
            if (s.GetIntersectionWith(camera, v) != null)
            {
                answer[(int)v.Z + 10, (int)v.X] = 1;
            }
            else
            {
                answer[(int)v.Z + 10, (int)v.X] = 0;
            }
        }

        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                Console.Write(answer[i,j]);
            } 
            Console.WriteLine();
        }
    }
}