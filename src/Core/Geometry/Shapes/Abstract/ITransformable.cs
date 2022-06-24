using Core.Matrices;

namespace Core.Geometry.Shapes.Abstract;

public interface ITransformable
{
    public abstract void Transform(Matrix4x4 transformation);
}