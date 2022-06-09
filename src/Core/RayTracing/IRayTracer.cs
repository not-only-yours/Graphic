using Core.Geometry;

namespace Core.RayTracing;

public interface IRayTracer
{
    public char Trace(Point point);
}