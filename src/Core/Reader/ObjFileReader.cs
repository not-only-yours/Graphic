using System.Collections;
using Core.Geometry;
using Core.Geometry.Shapes;

namespace Core.Reader;

public class ObjFileReader
{
    private string _path;

    private ObjFileReader(string path)
    {
        _path = path;
    }

    public static ObjFileReader CreateFromPath(string path) => new(path);
    
    public Mesh Read()
    {
        var points = new List<Point>();
        var normals = new List<Vector>();
        var faces = new List<Face>();
        
        foreach (var line in File.ReadLines(_path))
        {  
            var parts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 0) continue;
            switch (parts[0])
            {
                case "v":
                    points.Add(ParseVertex(parts));
                    break;
                case "vn":
                    normals.Add(ParseNormal(parts));
                    break;
                case "f":
                    faces.Add(ParseFace(parts));
                    break;
            }
        }

        return Mesh.CreateNew(points, normals, faces);
    }


    private static Point ParseVertex(string[] parts)
    {
        return Point.FromXYZ(Convert.ToDouble(parts[1]), Convert.ToDouble(parts[2]), Convert.ToDouble(parts[3]));
    }

    private static Vector ParseNormal(string[] parts)
    {
        return Vector.FromXYZ(Convert.ToDouble(parts[1]), Convert.ToDouble(parts[2]), Convert.ToDouble(parts[3]));
    }

    private static Face ParseFace(string[] parts)
    {
        var points = new List<int>();
        var normals = new List<int>();
        for (int i = 1; i < parts.Length; i++)
        {
            var part = parts[i];
            //Console.WriteLine(buffer[i] + " " + buffer[i].Split("/").Length);
            var faceParts = part.Split("/");
            // points.Add(meshPoints[Convert.ToInt32(faceParts[0]) - 1]);
            // normals.Add(meshNormals[Convert.ToInt32(faceParts[2]) - 1]);
            points.Add(Convert.ToInt32(faceParts[0]) - 1);
            normals.Add(Convert.ToInt32(faceParts[2]) - 1);
        }
        //Console.WriteLine(points[0] + " " + points[1] + " " + points[2]);
        return new Face(points[0], points[1], points[2], normals[0], normals[1], normals[2]);
    }
}