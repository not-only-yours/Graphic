using Core.Geometry;

namespace Core.RayTracing.RayTracers;

public interface IRayTracer
{
    public TraceResult Trace(Point origin, Vector direction);
}