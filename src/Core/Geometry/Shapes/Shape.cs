namespace Core.Geometry.Shapes;

public abstract class Shape
{
    public abstract Point? GetIntersectionWith(Point origin, Vector ray);
    public abstract double GetDistanceTo(Point point);
    public abstract override string ToString();
}