namespace Graphic.Geometry.Shapes;

public abstract class Shape
{
    public abstract Point? GetIntersectionWith(Point origin, Vector ray);
}