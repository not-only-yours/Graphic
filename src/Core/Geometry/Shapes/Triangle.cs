using System.Collections;

namespace Core.Geometry.Shapes;

public class Triangle : Shape
{
    public Point One { get; private set; }
    public Point Two { get; private set; }
    public Point Three { get; private set; }
    
    public ArrayList Normal { get; private set; }
    
    private Triangle(Point one, Point two, Point three) {
        One = one;
        Two = two;
        Three = three;
    }
    
    private Triangle(Point one, Point two, Point three, ArrayList normal) {
        One = one;
        Two = two;
        Three = three;
        Normal = normal;
    }

    public static Triangle FromPoints(Point one, Point two, Point three)
    {
        return new Triangle(one, two, three);
    }
    
    public static Triangle FromPointsAndNormal(Point one, Point two, Point three, ArrayList normal)
    {
        return new Triangle(one, two, three, normal);
    }
    
    public Vector GetNormalVector()
    {
        var oneTwo = Vector.FromPoints(One, Two);
        
        var oneThree = Vector.FromPoints(One, Three);

        return oneTwo.Cross(oneThree);
    }

    // https://en.wikipedia.org/wiki/M%C3%B6ller%E2%80%93Trumbore_intersection_algorithm
    public override Point? GetIntersectionWith(Point rayOrigin, Vector ray)
    {
        const double eps = 0.0000001;
        
        Point vertex0 = One;
        Point vertex1 = Two;
        Point vertex2 = Three;
        
        Vector edge1 = vertex1 - vertex0;
        Vector edge2 = vertex2 - vertex0;
        
        Vector h = Vector.Empty();
        Vector s = Vector.Empty();
        Vector q = Vector.Empty();
        
        double a, f, u, v;

        h = ray.Cross(edge2);
        a = edge1.Dot(h);
        
        if (a is > -eps and < eps)
        {
            return null;
        } 
        
        f = 1.0 / a;
        s = rayOrigin - vertex0;
        u = f * s.Dot(h);
        
        if (u is < 0.0 or > 1.0)
        {
            return null;
        }
        
        q = s.Cross(edge1);
        v = f * ray.Dot(q);
        
        if (v < 0.0 || u + v > 1.0)
        {
            return null;
        }
        
        var t = Math.Abs(f * edge2.Dot(q));
        
        if (t > eps) // ray intersection
        {
            var answer = rayOrigin + ray * t;
            return answer;
        }
        
        return null;
    }

    public override double GetDistanceTo(Point point)
    {
        throw new NotImplementedException();
    }
    
    public override string ToString()
    {
        return $"Triangle(One={One}, Two={Two}, Three={Three})";
    }
}