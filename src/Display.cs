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
                // Console.WriteLine((0 + j)+" "+ (displayLength - j - 1)+ " "+ i);
                rays.Add(Vector.FromPoints(camera, Point.FromXYZ(0 + j, displayLength - j - 1, i)));
            }
        }
    }


    public void RayTracing(Point camera, Sphere s)
    {
        char[,] answer = new char[displayHeight, displayLength];
        foreach (Vector v in rays)
        {
            // Console.WriteLine(v.ToString()); 
            if (s.GetIntersectionWith(camera, v) != null)
            {
                answer[(int) (v.Z + camera.Z), (int) (v.X + camera.X)] = '#';
            }
            else
            {
                answer[(int) (v.Z + camera.Z), (int) (v.X + camera.X)] = ' ';
            }
        }

        PrintResult(answer);
    }

    public void RayTracing(Point camera, Vector light, Sphere s)
    {
        char[,] answer = new char[displayHeight, displayLength];
        foreach (Vector v in rays)
        {
            // Console.WriteLine(v.ToString()); 
            var ans = v.norm().Dot(light);
                //Console.WriteLine(ans);
            if (s.GetIntersectionWith(camera, v) != null)
            {
                answer[(int) (v.Z + camera.Z), (int) (v.X + camera.X)] = ans switch
                {
                    < 0 => ' ',
                    >= 0 and <= 0.2 => '.',
                    > 0.2 and <= 0.5 => '*',
                    > 0.5 and <= 0.8 => '0',
                    > 0.8 => '#',
                    _ => answer[(int) (v.Z + camera.Z), (int) (v.X + camera.X)]
                };

            }
            else
            {
                answer[(int) (v.Z + camera.Z), (int) (v.X + camera.X)] = ' ';
            }
        }
        PrintResult(answer);
    }

    public void PrintResult(char[,] answer)
    {
        for (int i = 0; i < displayHeight; i++)
        {
            for (int j = 0; j < displayLength; j++)
            {
                Console.Write(answer[i,j] + " ");
            } 
            Console.WriteLine();
        }
    }
}