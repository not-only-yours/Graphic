namespace Graphic;

public class Rectangle
{
    public Point One { get; private set; }
    public Point Two { get; private set; }
    public Point Three { get; private set; }
    public Point Four { get; private set; }

    private Rectangle(Point one, Point two, Point three, Point four) {
        One = one;
        Two = two;
        Three = three;
        Four = four;
    }

    public static Rectangle FromPoints(Point one, Point two, Point three, Point four)
    {
        return new Rectangle(one, two, three, four);
    }
    
    public Vector GetNormalVector()
    {
        var oneTwo = Vector.FromPoints(One, Two);
        
        var oneThree = Vector.FromPoints(One, Three);

        return oneTwo.Cross(oneThree);
    }
    
    
    public Point? GetIntersectionWith(Point origin, Vector ray)
    {
        //https://stackoverflow.com/questions/36180741/intersection-of-ray-and-rectangle-in-c
        
        var n = GetNormalVector();
        var oneTwo = Vector.FromPoints(One, Two);
        var d = oneTwo.Dot(Vector.FromXYZ(oneTwo.X,oneTwo.Y,oneTwo.Z));
        var t = -(d + origin.Z * n.Z + origin.Y * n.Y + origin.X * n.X) / (ray.Z * n.Z + ray.Y * n.Y + ray.X * n.X);
        
        var PointOfIntersettion = origin + ray * t;
        var V1 = Vector.FromPoints(One, Two);
        var V2 = Vector.FromPoints(One, Four);
        var hitVector = Vector.FromPoints(PointOfIntersettion, One);
        
        var normV1 = V1.norm();
        var normV2 = V2.norm();
        
        var lengthV1 = V1.length();
        var lengthV2 = V1.length();

        var a = normV1.Dot(hitVector);
        var b = normV2.Dot(hitVector);
        
        return (0.0f <= a && a <= lengthV1 && 0.0f <= b && b <= lengthV2) ? PointOfIntersettion : null;
    }
    
}