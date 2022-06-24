using Core.Geometry;
using Core.Geometry.Shapes;
using Core.Geometry.Shapes.Abstract;
using Core.Matrices;
using Core.RayTracing;
using Core.RayTracing.Image;
using Core.RayTracing.RayTracers;
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
        
            var camera = Camera.CreateDefault();
            var scene = new Scene(camera);
            var lightSource = Vector.FromXYZ(1, -1, -1).GetUnitVector();
            // From top, to right, from camera
        
            var mesh = ObjFileReader.CreateFromPath(source).Read();
        
            var transformation =
                Matrix4x4.CreateYRotation(-90 * (MathF.PI / 180f)) *
                Matrix4x4.CreateZRotation(-45 * (MathF.PI / 180f));
            //* Matrix4x4.CreateScale(scale, scale, scale)
        
            mesh.Transform(transformation);
        
            var shapes = mesh.GetTriangles();
            Shape sphere = Sphere.FromCentreAndRadius(Point.FromXYZ(-0.4, 0.4, 0), 0.15);
        
            // var tracer = new DefaultRayTracer(shapes.Append(sphere), lightSource);
            var tracer = new ShadowsRayTracer(shapes.Append(sphere), lightSource);
        
            var traceResults = scene.RayTrace(tracer);
        
            if (destination == "console")
            {
                var image = Image<CharPixel>.FromTraceResults(traceResults, CharPixel.FromTraceResult);
                var writer = new ConsoleWriter();
                writer.Write(image);
            }
            else
            {
                var image = Image<ColoredPixel>.FromTraceResults(traceResults, ColoredPixel.FromTraceResult);
                var writer = new PpmWriter(destination);
                writer.Write(image);
            }
        }

        // public static void Main(string[] args)
        // {
        //     Console.WindowWidth = 260;
        //     
        //     var destination = args[1].Split('=')[1];
        //     
        //     var camera = Camera.CreateDefault();
        //     var scene = new Scene(camera);
        //     var lightSource = Vector.FromXYZ(1, 0, 0).GetUnitVector();
        //     // From top, to right, from camera
        //
        //     Shape sphere1 = Sphere.FromCentreAndRadius(Point.FromXYZ(-0.5, 0, 0), 0.2); //from -0.5 to 0.5
        //     
        //     // Console.WriteLine(sphere1.GetIntersectionWith(Point.FromXYZ(-0.7, 0, 0), Vector.FromXYZ(-1, , 0)));
        //     
        //     Shape sphere2 = Sphere.FromCentreAndRadius(Point.FromXYZ(0.5, 0, 0), 0.5);
        //     
        //     // Console.WriteLine(sphere2.GetIntersectionWith(Point.FromXYZ(-0.6684447491900706, 0.024160631922801358, 0.10508392044164094), Vector.FromXYZ(-1, 0, 0))?.Point); //->  = Sphere(Center=Point(X=0.5, Y=0, Z=0), Radius=0.75) Point(X=-0.24220861860376286, Y=0.024160631922801358, Z=0.10508392044164094)
        //     // var i = sphere2.GetIntersectionWith(Point.FromXYZ(-100, 0, 0), Vector.FromXYZ(-1, 0, 0));
        //     // Console.WriteLine("aa " + i?.Point + " " + i?.Distance);
        //     
        //     // var tracer = new DefaultRayTracer(shapes.Append(sphere), lightSource);
        //     var tracer = new ShadowsRayTracer(new List<Shape>(){sphere1, sphere2}, lightSource);
        //     
        //     var traceResults = scene.RayTrace(tracer);
        //     
        //     var image = Image<ColoredPixel>.FromTraceResults(traceResults, ColoredPixel.FromTraceResult);
        //     var writer = new PpmWriter(destination);
        //     writer.Write(image);
        // }
    }
}