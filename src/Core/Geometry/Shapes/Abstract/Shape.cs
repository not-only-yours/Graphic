using Core.Matrices;

namespace Core.Geometry.Shapes.Abstract;

public abstract class Shape : IIntersectable, ITransformable
{
    public abstract void Transform(Matrix4x4 transformation);
    public abstract Intersection? GetIntersectionWith(Point origin, Vector ray);
    public abstract override string ToString();
}