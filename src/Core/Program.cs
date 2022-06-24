using Core.Geometry;
using Core.Geometry.Shapes;
using Core.Matrices;
using Core.RayTracing;
using Core.Reader;
using Core.Scenery;
using Core.Writer;

namespace Core
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var source = args[0].Split('=')[1];
            var destination = args[1].Split('=')[1];

            // var objFileReader = ObjFileReader.CreateFromPath(source);
            // var mesh = objFileReader.Read();
            
            var camera = Camera.CreateDefault();
            var scene = new Scene(camera);
            var lightSource = Vector.FromXYZ(1, -1, -1);
            
            // var lightSource = Vector.FromXYZ(0, 0, 1);

            var mesh = ObjFileReader.CreateFromPath(source).Read();

            var scale = 0.75f;
            
            Console.WriteLine("before " + mesh.Vertices[0]);
            mesh.Transform(
                Matrix4x4.CreateYRotation(45 * (MathF.PI / 180f)) *
                Matrix4x4.CreateXRotation(45 * (MathF.PI / 180f))
                // Matrix4x4.CreateScale(scale, scale, scale)
            );
            // We are building faces before transformation are applied. It is incorrect. Faces should be constructed after .Transform method is called
            Console.WriteLine("after " + mesh.Vertices[0]);
            
            var tracer = new ShapesWithLightSourceRayTracer(mesh.GetTriangles(), camera, lightSource);
            
            // var tracer = new ShapesWithLightSourceRayTracer(new List<Shape>() {Sphere.FromCentreAndRadius(Point.FromXYZ(0, 0, 0), 0.2)}, camera, lightSource);
            
            // var tracer = new ShapesWithLightSourceRayTracer(new List<Shape>()
            // {
            //     Triangle.FromPointsAndNormals(
            //         Point.FromXYZ(0.05, 0, 0),
            //         Point.FromXYZ(0, 0.05, 0),
            //         Point.FromXYZ(0, 0, 0),
            //         Vector.FromXYZ(0.1, 0.1, 0.1),
            //         Vector.FromXYZ(0.1, 0.1, 0.1),
            //         Vector.FromXYZ(0.1, 0.1, 0.1))
            // }, camera, lightSource);

            var image = scene.RayTrace(tracer);

            if (destination == "console")
            {
                var writer = new ConsoleWriter();
                writer.Write(image);
            }
            else
            {
                var writer = new PpmWriter(destination);
                writer.Write(image);
            }
        
            //Lab 2
            // scene.GenerateRayTracePicture("/Users/nikita_dir/Documents/projects/Graphic/src/test.ppm");
            // var reader = FileReader.CreateReader("/Users/nikita_dir/Downloads/car.obj");
            // String s = "aa//aa";
            // reader.ReadOBJ();
            
        }

        // private static void Lab1()
        // {
        //     var cameraOrigin = Point.FromXYZ(0, 0, 0);
        //     var distanceFromCameraToViewpoint = 10.0;
        //     var cameraDirection = Vector.FromXYZ(0, 0, 1);
        //
        //     // Viewpoint = Plane.FromCenterAndNormal(
        //     //     cameraOrigin + cameraDirection * distanceFromCameraToViewpoint,
        //     //     cameraDirection);
        //
        //     var camera = Camera.CreateNew(
        //         cameraOrigin,
        //         cameraDirection,
        //         distanceFromCameraToViewpoint);
        //     
        //     var screen = Screen.FromResolution(60);
        //     
        //     
        //     // 4.1
        //     var scene = new Scene(camera, screen);
        //     
        //     var sphere = Sphere.FromCentreAndRadius(Point.FromXYZ(0, 0, 20), 10);
        //     
        //     scene.RayTrace(new SphereRayTracer(sphere, camera));
        //     
        //     // 4.2
        //     var lightSource = Vector.FromXYZ(5, 5, 1); 
        //     
        //     scene.RayTrace(new SphereWithLightSourceRayTracer(sphere, camera, lightSource));
        //     
        //     // 5
        //     var sphere2 = Sphere.FromCentreAndRadius(Point.FromXYZ(5, 0, 15), 7);
        //     
        //     scene.RayTrace(new ShapesWithLightSourceRayTracer(new List<Shape>() {sphere, sphere2}, camera, lightSource));
        // }
    }
}