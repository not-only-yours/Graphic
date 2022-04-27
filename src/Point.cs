namespace Graphic
{
    public class Point
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

        public static Point FromXYZ(double x, double y, double z)
        {
            return new Point(x, y, z);
        }

        public static Point operator +(Point one, Point two)
        {
            return FromXYZ(one.X + two.X, one.Y + two.Y, one.Z + two.Z);
        }
        
        public static Point operator -(Point one, Point two)
        {
            return FromXYZ(one.X - two.X, one.Y - two.Y, one.Z - two.Z);
        }
    }
}