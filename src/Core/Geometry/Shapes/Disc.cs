namespace Core.Geometry.Shapes;

public class Disc : Shape
{
    public Point Center { get; }
    public double RadiusSmall { get; }
    public double RadiusBig { get; }
    
    public Vector Normal { get; }
    
    
    private Disc(Point center, double radiusS, double radiusB, Vector normal)
    {
        Center = center;
        RadiusSmall = radiusS;
        RadiusBig = radiusB;
        Normal = normal;
    }

    public static Disc FromCentreNormalAndTwoRadius(Point center, double radiusS, double radiusB, Vector normal) => new(center, radiusS, radiusB, normal);

    public override Point? GetIntersectionWith(Point origin, Vector ray)
    {
        // https://stackoverflow.com/questions/23975555/how-to-do-ray-plane-intersection
        var denom = Normal.Dot(ray);
        if (Math.Abs(denom) > 0.0001f) // your favorite epsilon
        {
            var t = (Center - origin).Dot(Normal) / denom;
            if (t >= 0) return origin + ray * t; // you might want to allow an epsilon here too
        }

        return null;
    }

    public override double GetDistanceTo(Point point)
    {
        throw new NotImplementedException();
    }
}