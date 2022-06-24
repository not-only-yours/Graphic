using Core.Geometry;
using Core.Geometry.Shapes;

namespace Core.Reader;

public class Face
{
    public int V0Idx { get; }
    public int V1Idx { get; }
    public int V2Idx { get; }
    public int N0Idx { get; }
    public int N1Idx { get; }
    public int N2Idx { get; }

    public Face(int v0Idx, int v1Idx, int v2Idx, int n0Idx, int n1Idx, int n2Idx)
    {
        V0Idx = v0Idx;
        V1Idx = v1Idx;
        V2Idx = v2Idx;
        N0Idx = n0Idx;
        N1Idx = n1Idx;
        N2Idx = n2Idx;
    }

    public Triangle ToTriangle(List<Point> vertices, List<Vector> normals)
    {
        return Triangle.FromPointsAndNormals(
            vertices[V0Idx], vertices[V1Idx], vertices[V2Idx],
            normals[N0Idx], normals[N1Idx], normals[N2Idx]);
    }
}