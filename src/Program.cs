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
            var sphere = Sphere.FromCentreAndRadium(Point.FromXYZ(0, 0, 0), 10);
            var startPoint = Point.FromXYZ(12, 0, 0);
            sphere.IsIntersectionWith(startPoint, Vector.FromPoints(startPoint, Point.FromXYZ(11, 0, 0)));
        }
    }
}