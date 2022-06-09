namespace Core.Geometry.Shapes;

public class Cylinder : Shape
{
    public Point Center { get; private set; }
    public double Radius { get; private set; }
    public double Height { get; private set; }
    
    
    private Cylinder(Point center, double radius, double height)
    {
        Center = center;
        Radius = radius;
        Height = height;
    }

    public static Cylinder FromCentreHeightAndRadius(Point center, double radius, double height) => new(center, radius, height);

    public override Point? GetIntersectionWith(Point origin, Vector ray)
    {
        var a = (ray.X * ray.X) + (ray.Z * ray.Z);
        var b = 2*(ray.X*(origin.X-Center.X) + ray.Z*(origin.Z-Center.Z));
        var c = (origin.X - Center.X) * (origin.X - Center.X) + (origin.Z - Center.Z) * (origin.Z - Center.Z) - (Radius*Radius);
    
        var delta = b*b - 4*(a*c);
        if(Math.Abs(delta) < 0.001) return null; 
        if(delta < 0.0) return null;
    
        var t1 = (-b - Math.Sqrt(delta))/(2*a);
        var t2 = (-b + Math.Sqrt(delta))/(2*a);

        var t = t1>t2 ? t2 : t1;
    
        var r = origin.Y + t*ray.Y;
    
        if ((r >= Center.Y) && (r <= Center.Y + Height))return origin + ray * t;
        else return null;
    }

    public override double GetDistanceTo(Point point)
    {
        throw new NotImplementedException();
    }
}