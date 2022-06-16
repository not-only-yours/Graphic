using System.Collections;
using System.Diagnostics;
using Core.Geometry;
using Core.Geometry.Shapes;

namespace Core;

public class FileReader
{
    private String LocalFile;
    public ArrayList PointList { get; private set; }
    public ArrayList NormalList { get; private set; }
    public ArrayList FigureList { get; private set; }

    private FileReader(String file)
    {
        LocalFile = file;
        PointList = new ArrayList();
        NormalList = new ArrayList();
        FigureList = new ArrayList();
    }

    public static FileReader CreateReader(String a) => new(a);
    
    public void ReadOBJ()
    {
        
        foreach (string line in System.IO.File.ReadLines(LocalFile))
        {  
            string[] parts = line.Split(' ');
            switch (parts[0])
            {
                case "v":
                    ParseVertex(parts.Skip(1).ToArray());
                    break;
                case "vn":
                    ParseNormal(parts.Skip(1).ToArray());
                    break;
                case "f":
                    ParseFigure(parts.Skip(1).ToArray());
                    break;
            }

        }
    }


    public void ParseVertex(string[] buffer)
    {
        Point p = Point.FromXYZ(Convert.ToDouble(buffer[0]), Convert.ToDouble(buffer[1]), Convert.ToDouble(buffer[2]));
        PointList.Add(p);
    }

    public void ParseNormal(string[] buffer)
    {
        Vector p = Vector.FromXYZ(Convert.ToDouble(buffer[0]), Convert.ToDouble(buffer[1]), Convert.ToDouble(buffer[2]));
        NormalList.Add(p);
    }

    public void ParseFigure(string[] buffer)
    {
        ArrayList points = new ArrayList();
        ArrayList normals = new ArrayList();
        for (int i = 0; i < buffer.Length; i++)
        {
            //Console.WriteLine(buffer[i] + " " + buffer[i].Split("/").Length);
            var b = buffer[i].Split("/");
            points.Add(PointList[Convert.ToInt32(b[0]) - 1]);
            normals.Add(NormalList[Convert.ToInt32(b[2]) - 1]);
        }
        //Console.WriteLine(points[0] + " " + points[1] + " " + points[2]);
        FigureList.Add(Triangle.FromPointsAndNormal((Point) points[0], (Point) points[1], (Point)  points[2],  normals));
    }
}