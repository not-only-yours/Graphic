namespace Core.Geometry.Shapes.Abstract;

public interface IIntersectable
{
    public abstract Intersection? GetIntersectionWith(Point origin, Vector ray, Intersection? foundIntersection);
}