// using Core.Geometry;
// using Core.Geometry.Shapes;
// using Core.Scenery;
//
// namespace Core.RayTracing;
//
// public class SphereWithLightSourceRayTracer : IRayTracer
// {
//     private readonly Sphere _sphere;
//     private readonly Camera _camera;
//     private readonly Vector _lightSource;
//     
//     public SphereWithLightSourceRayTracer(Sphere sphere, Camera camera, Vector lightSource)
//     {
//         _sphere = sphere;
//         _camera = camera;
//         _lightSource = lightSource;
//     }
//         
//     public TraceResult Trace(Point point)
//     {
//         var cameraToPoint = point - _camera.Origin;
//             
//         var intersection = _sphere.GetIntersectionWith(_camera.Origin, cameraToPoint);
//
//         return TraceResult.FromIntersectionAndLightSource(intersection, _lightSource);
//             
//         // if (hasIntersection)
//         // {
//         //     // return cameraToPoint.GetUnitVector().Dot(_lightSource) switch
//         //     // {
//         //     //     < 0 => ' ',
//         //     //     >= 0 and <= 0.2 => '.',
//         //     //     > 0.2 and <= 0.5 => '*',
//         //     //     > 0.5 and <= 0.8 => '0',
//         //     //     > 0.8 => '#',
//         //     //     _ => throw new ArgumentOutOfRangeException()
//         //     // };
//         //
//         // }
//         // else
//         // {
//         //    return ' ';
//         // }
//     }
// }