using Core.Geometry;
using Core.Geometry.Shapes;
using Core.RayTracing;
using Core.Scenery;

namespace Core
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var cameraOrigin = Point.FromXYZ(0, 0, 0);
            var distanceFromCameraToViewpoint = 10.0;
            var cameraDirection = Vector.FromXYZ(0, 0, 1);
        
            // Viewpoint = Plane.FromCenterAndNormal(
            //     cameraOrigin + cameraDirection * distanceFromCameraToViewpoint,
            //     cameraDirection);
        
            var camera = Camera.CreateNew(
                cameraOrigin,
                cameraDirection,
                distanceFromCameraToViewpoint);
            
            var screen = Screen.FromResolution(60);
            
            
            // 4.1
            var scene = new Scene(camera, screen);
            
            var sphere = Sphere.FromCentreAndRadius(Point.FromXYZ(0, 0, 20), 10);
            
            scene.RayTrace(new SphereRayTracer(sphere, camera));
            
            // 4.2
            var lightSource = Vector.FromXYZ(5, 5, 1); 
            
            scene.RayTrace(new SphereWithLightSourceRayTracer(sphere, camera, lightSource));
            
            // 5
            var sphere2 = Sphere.FromCentreAndRadius(Point.FromXYZ(5, 0, 15), 7);
            
            scene.RayTrace(new ShapesWithLightSourceRayTracer(new List<Shape>() {sphere, sphere2}, camera, lightSource));
        
            //Lab 2
            scene.GenerateRayTracePicture("/Users/nikita_dir/Documents/projects/Graphic/src/test.ppm");
            var reader = FileReader.CreateReader("/Users/nikita_dir/Downloads/car.obj");
            String s = "aa//aa";
            reader.ReadOBJ();
            
        }
    }
}