using Core.Geometry;
using Core.Geometry.Shapes;
using Core.Geometry.Shapes.Abstract;
using Core.Matrices;

namespace Core.Reader;

public class Mesh : ITransformable
{
    public readonly List<Point> Vertices;
    public readonly List<Vector> Normals;
    public readonly List<Face> Faces;

    private Mesh(List<Point> vertices, List<Vector> normals, List<Face> faces)
    {
        Vertices = vertices;
        Normals = normals;
        Faces = faces;
    }

    public static Mesh CreateNew(List<Point> vertices, List<Vector> normals, List<Face> faces) =>
        new(vertices, normals, faces);
    
    public void Transform(Matrix4x4 transformation)
    {
        foreach (var vertex in Vertices)
        {
            vertex.Transform(transformation);
        }
        
        foreach (var normal in Normals)
        {
            normal.Transform(transformation);
        }
    }

    public IEnumerable<Triangle> GetTriangles()
    {
        return Faces.Select(f => f.ToTriangle(Vertices, Normals));
    }
}
