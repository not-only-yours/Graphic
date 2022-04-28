namespace Graphic
{
    public class Vector
    {
        public Point StartPoint { get; private set; }
        public Point EndPoint { get; private set; }
        public double X { get; private set; }
        public double Y { get; private set; }
        public double Z { get; private set; }
        
        private Vector(Point start, Point end, double x, double y, double z)
        {
            StartPoint = start;
            EndPoint = end;
            X = x;
            Y = y;
            Z = z;
        }
        
        public static Vector FromStartXYZandEndXYZ(double startX, double startY, double startZ, double endX, double endY , double endZ)
        {
            return new Vector(
                Point.FromXYZ(startX, startY, startZ), 
                Point.FromXYZ(endX, endY, endZ),
                endX - startX,
                endY - startY,
                endZ - startZ);
        }
       
        public static Vector FromPoints(Point startPoint, Point endPoint)
        {
            return new Vector(
                startPoint,
                endPoint,
                endPoint.X - startPoint.X,
                endPoint.Y - startPoint.Y,
                endPoint.Z - startPoint.Z);
        }

        public static Vector operator +(Vector one, Vector two)
        {
            return FromPoints(one.StartPoint + two.StartPoint, one.EndPoint + two.EndPoint);
        }

        public static Vector operator -(Vector one, Vector two)
        {
            return FromPoints(one.StartPoint - two.StartPoint, one.EndPoint - two.EndPoint);
        }
        
        public static double Dot(Vector one, Vector two)
        {
            return one.X * two.X + one.Y * two.Y + one.Z * two.Z;
        }
        
        public static double Dot(Vector one, Ray two)
        {
            return one.X * two.X + one.Y * two.Y + one.Z * two.Z;
        }
        
        public static double Dot(Vector one, Point two)
        {
            return one.X * two.X + one.Y * two.Y + one.Z * two.Z;
        }
        
        public static Point Cross(Point one, Vector two)
        {
            return Point.FromXYZ(
                one.Y * two.Z - one.Z * two.Y,
                one.Z * two.X - one.X * two.Z,
                one.X * two.Y - one.Y * two.X
            );
        }
        
        public static Ray Cross(Ray one, Vector two)
        {
            return Ray.FromPointAndXYZ(
                one.StartPoint,
                one.Y * two.Z - one.Z * two.Y,
                one.Z * two.X - one.X * two.Z,
                one.X * two.Y - one.Y * two.X
            );;
        }

        public override string ToString()
        {
            return $"{X} {Y} {Z}";
        }
    }
}