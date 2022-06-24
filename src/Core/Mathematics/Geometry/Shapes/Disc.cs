using Core.Geometry.Shapes.Abstract;
using Core.Mathematics;
using Core.Matrices;

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

    public override Intersection? GetIntersectionWith(Point origin, Vector ray, Intersection? foundIntersection)
    {
        // https://stackoverflow.com/questions/23975555/how-to-do-ray-plane-intersection
        var denom = Normal.Dot(ray);
        if (Math.Abs(denom) > Constants.Eps)
        {
            var t = (Center - origin).Dot(Normal) / denom;
            if (t >= 0) return Intersection.Found(
                origin + ray * t,
                0,
                Vector.Empty()); // you might want to allow an epsilon here too 
                //TODO: fix
        }

        return null;
    }

    public override void Transform(Matrix4x4 transformationMatrix)
    {
        throw new NotImplementedException();
    }

    public override string ToString()
    {
        return $"Disc(Center={Center}, RadiusSmall={RadiusSmall}, RadiusBig={RadiusBig}, Normal={Normal})";
    }
}