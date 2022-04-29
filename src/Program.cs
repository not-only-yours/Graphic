using System;

namespace Graphic
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var triangleOne = Point.FromXYZ(0, 0, 0);
            var triangleTwo = Point.FromXYZ(10, 10, 0);
            var triangleThree = Point.FromXYZ(0, 10, 0);
            
            var rayOne = Point.FromXYZ(12, 12, 12);
            var r = Ray.FromPointAndXYZ(rayOne, 0,0, 5);
            
            // Plane p = new Plane(one, two, three);
            // Vector.printVector(NormalVector.normalVector(p));
            
            
            Triangle t = new Triangle(triangleOne, triangleTwo, triangleThree);
            Cross.rayTriangleIntersection(r, t);
        }
    }
}