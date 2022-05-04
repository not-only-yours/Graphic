using Graphic.Geometry.Shapes;

namespace Graphic
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // var triangleOne = Point.FromXYZ(0, 0, 0);
            // var triangleTwo = Point.FromXYZ(10, 10, 0);
            // var triangleThree = Point.FromXYZ(0, 10, 0);
            //
            // var rayOne = Point.FromXYZ(12, 12, 12);
            // var r = Ray.FromPointAndXYZ(rayOne, 0,0, 5);
            //
            // // Plane p = new Plane(one, two, three);
            // // Vector.printVector(NormalVector.normalVector(p));
            //
            //
            // Triangle t = new Triangle(triangleOne, triangleTwo, triangleThree);
            // Cross.rayTriangleIntersection(r, t);
            // var sphere = Sphere.FromCentreAndRadius(Point.FromXYZ(0, 0, 0), 10);
            // var startPoint = Point.FromXYZ(12, 0, 0);
            // sphere.GetIntersectionWith(startPoint, Vector.FromPoints(startPoint, Point.FromXYZ(11, 0, 0)));
            
            // var cameraOrigin = Point.FromXYZ(0, 0, 10);
            // var lightRay = Vector.FromXYZ(0,1,-2); 
            // var sphere = Sphere.FromCentreAndRadius(Point.FromXYZ(10,10,10), 5);
            //
            // var display = Display.FromResolution(20);
            //
            // display.RayTracing(cameraOrigin, lightRay, sphere);

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