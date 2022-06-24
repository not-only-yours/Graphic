using System.Collections;
using Core.Geometry.Shapes.Abstract;
using Core.Mathematics;
using Core.Matrices;

namespace Core.Geometry.Shapes;

public class Triangle : Shape
{
    public Point One { get; private set; }
    public Point Two { get; private set; }
    public Point Three { get; private set; }
    
    public Vector N0 { get; private set; }
    public Vector N1 { get; private set; }
    public Vector N2 { get; private set; }
    
    private Triangle(Point one, Point two, Point three) {
        One = one;
        Two = two;
        Three = three;
    }
    
    private Triangle(Point one, Point two, Point three, Vector n0, Vector n1, Vector n2) {
        One = one;
        Two = two;
        Three = three;
        N0 = n0;
        N1 = n1;
        N2 = n2;
    }

    public static Triangle FromPointsAndNormals(Point one, Point two, Point three, Vector n0, Vector n1, Vector n2)
    {
        return new Triangle(one, two, three, n0, n1, n2);
    }
    
    public Vector GetNormalVector()
    {
        var oneTwo = Vector.FromPoints(One, Two);
        
        var oneThree = Vector.FromPoints(One, Three);

        return oneTwo.Cross(oneThree);
    }

    // https://en.wikipedia.org/wiki/M%C3%B6ller%E2%80%93Trumbore_intersection_algorithm
    public override Intersection? GetIntersectionWith(Point rayOrigin, Vector rayDirection)
    {
        Point vertex0 = One;
        Point vertex1 = Two;
        Point vertex2 = Three;
        
        Vector edge1 = vertex1 - vertex0;
        Vector edge2 = vertex2 - vertex0;
        
        Vector p = Vector.Empty();
        Vector t = Vector.Empty();
        Vector q = Vector.Empty();
        
        double det, invDet, u, v;

        p = rayDirection.Cross(edge2);
        det = edge1.Dot(p);
        
        if (Math.Abs(det) < Constants.Eps)
        {
            return null;
        } 
        
        invDet = 1.0 / det;
        t = rayOrigin - vertex0;
        u = t.Dot(p) * invDet;
        
        if (u is < 0.0 or > 1.0)
        {
            return null;
        }
        
        q = t.Cross(edge1);
        v = rayDirection.Dot(q) * invDet;
        
        if (v < 0.0 || u + v > 1.0)
        {
            return null;
        }
        
        var distance = invDet * edge2.Dot(q);

        if (distance > Constants.Eps)
        {
            return Intersection.Found(
                rayOrigin + rayDirection * distance,
                distance,
                N0 * (1 - u - v) + N1 * u + N2 * v);
        }
        else
        {
            return null;
        }
    }

    public override void Transform(Matrix4x4 transformation)
    {
        // One = One.Tr transformation * One;
        One.Transform(transformation);
        Two.Transform(transformation);
        Three.Transform(transformation);

        N0.Transform(transformation);
        N0 = N0.GetUnitVector();
        N1.Transform(transformation);
        N1 = N1.GetUnitVector();
        N2.Transform(transformation);
        N2 = N2.GetUnitVector();
    }

    public override string ToString()
    {
        return $"Triangle(One={One}, Two={Two}, Three={Three})";
    }
    
    public bool IsEqualTo(Triangle other)
    {
        return One.IsEqualTo(other.One) &&
               Two.IsEqualTo(other.Two) &&
               Three.IsEqualTo(other.Three) &&
               N0.IsEqualTo(other.N0) &&
               N1.IsEqualTo(other.N1) &&
               N2.IsEqualTo(other.N2);
    } 
}