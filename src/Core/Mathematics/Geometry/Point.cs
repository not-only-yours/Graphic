using Core.Geometry.Shapes.Abstract;
using Core.Matrices;
using Microsoft.VisualBasic;

namespace Core.Geometry
{
    public class Point : ITransformable
    {
        public double X { get; private set; }
        public double Y { get; private set; }
        public double Z { get; private set; }
        
        private Point(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        
        public static Point FromXYZ(double x, double y, double z) => new(x, y, z);
        
        public static Point operator +(Point one, Vector two) => FromXYZ(one.X + two.X, one.Y + two.Y, one.Z + two.Z);
        public static Point operator -(Point one, Vector two) => FromXYZ(one.X - two.X, one.Y - two.Y, one.Z - two.Z);
        public static Vector operator -(Point one, Point two) => Vector.FromXYZ(one.X - two.X, one.Y - two.Y, one.Z - two.Z);

        public Point MoveInDirection(Vector direction, double distance)
        {
            return this + direction.GetUnitVector() * distance;
        }

        public void Transform(Matrix4x4 transformation)
        {
            // Console.WriteLine(X + " " + transformation.M11);
            var x = X;
            var y = Y;
            var z = Z;
            X = transformation.M11 * x + transformation.M12 * y + transformation.M13 * z + transformation.M14;
            Y = transformation.M21 * x + transformation.M22 * y + transformation.M23 * z + transformation.M24;
            Z = transformation.M31 * x + transformation.M32 * y + transformation.M33 * z + transformation.M34;
        }

        public bool IsEqualTo(Point other, double epsilon = Mathematics.Constants.Eps)
        {
            return Math.Abs(X - other.X) < epsilon &&
                   Math.Abs(Y - other.Y) < epsilon &&
                   Math.Abs(Z - other.Z) < epsilon;
        } 
        
        public override string ToString()
        {
            return $"Point(X={X}, Y={Y}, Z={Z})";
        }

        public double DistanceTo(Point p)
        {
            return Math.Sqrt(Math.Pow((p.X - X), 2) + Math.Pow((p.Y - Y), 2) + Math.Pow((p.Z - Z), 2));
        }
    }
}