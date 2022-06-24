using Core.Geometry;
using Core.Matrices;
using Core.RayTracing;
using Core.RayTracing.Image;
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
            
            var mesh = ObjFileReader.CreateFromPath(source).Read();

            var transformation =
                Matrix4x4.CreateYRotation(-90 * (MathF.PI / 180f))*
                Matrix4x4.CreateZRotation(-45 * (MathF.PI / 180f));
                //* Matrix4x4.CreateScale(scale, scale, scale)
            
            mesh.Transform(transformation);
            
            var tracer = new ShapesWithLightSourceRayTracer(mesh.GetTriangles(), camera, lightSource);
            
            // var tracer = new ShapesWithLightSourceRayTracer(new List<Shape>() {Sphere.FromCentreAndRadius(Point.FromXYZ(0, 0, 0), 0.2)}, camera, lightSource);
            
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
    }
}