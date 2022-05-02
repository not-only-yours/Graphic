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
            Point camera = Point.FromXYZ(0, 0, 10);
            Vector light = Vector.FromXYZ(0,1,-2); 
            Sphere s = Sphere.FromCentreAndRadius(Point.FromXYZ(10,10,10), 5);
            
            Display display = new Display(20, 20, camera);
            display.RayTracing(camera,light, s);
        }
    }
}