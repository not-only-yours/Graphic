using Core.Geometry.Shapes.Abstract;
using Core.Matrices;

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
            X = transformation.M11 * X + transformation.M12 * Y + transformation.M13 * Z + transformation.M14;
            Y = transformation.M21 * X + transformation.M22 * Y + transformation.M23 * Z + transformation.M24;
            Z = transformation.M31 * X + transformation.M32 * Y + transformation.M33 * Z + transformation.M34;
        }

        public bool IsEqualTo(Point other, double epsilon = 0.01)
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