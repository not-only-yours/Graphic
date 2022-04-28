using System;

namespace Graphic
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Point triangleOne = Point.FromXYZ(0, 0, 0);
            Point triangleTwo = Point.FromXYZ(10, 10, 0);
            Point triangleThree = Point.FromXYZ(0, 10, 0);
            
            Point rayOne = Point.FromXYZ(0, 0, -2);
            Ray r = Ray.FromPointAndXYZ(rayOne, 3,7, 5);
            
            // Plane p = new Plane(one, two, three);
            // Vector.printVector(NormalVector.normalVector(p));
            
            
            Triangle t = new Triangle(triangleOne, triangleTwo, triangleThree);
            Cross.rayTriangleIntersection(r, t);
        }
    }
}