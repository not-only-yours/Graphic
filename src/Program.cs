using Graphic.Geometry;
using Graphic.Geometry.Shapes;

namespace Graphic
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // 4.1
            var scene = Scene.CreateNew();
            
            var sphere = Sphere.FromCentreAndRadius(Point.FromXYZ(0, 0, 20), 10);
            
            scene.DrawRayTracing(sphere);
            
            // 4.2
            var lightSource = Vector.FromXYZ(5, 5, 1); 
            
            scene.DrawRayTracing(lightSource, sphere);
            
            // 5
            var sphere2 = Sphere.FromCentreAndRadius(Point.FromXYZ(5, 0, 15), 7);
            
            scene.DrawRayTracing(lightSource, new List<Shape>() {sphere, sphere2});
        }
    }
}