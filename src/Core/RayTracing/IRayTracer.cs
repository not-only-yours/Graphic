using Core.Geometry;

namespace Core.RayTracing;

public interface IRayTracer
{
    public TraceResult Trace(Point origin, Vector direction);
}