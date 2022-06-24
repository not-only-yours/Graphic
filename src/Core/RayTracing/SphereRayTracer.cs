// using Core.Geometry;
// using Core.Geometry.Shapes;
// using Core.Scenery;
//
// namespace Core.RayTracing;
//
// public class SphereRayTracer : IRayTracer
// {
//     private readonly Sphere _sphere;
//     private readonly Camera _camera;
//     
//     public SphereRayTracer(Sphere sphere, Camera camera)
//     {
//         _sphere = sphere;
//         _camera = camera;
//     }
//         
//     public char Trace(Point point)
//     {
//         var hasIntersection = _sphere.GetIntersectionWith(_camera.Origin, point - _camera.Origin) != null;
//
//         return hasIntersection ? '#' : ' ';
//     }
// }