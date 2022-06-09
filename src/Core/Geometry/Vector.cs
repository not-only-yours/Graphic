namespace Core.Geometry
{
    public class Vector
    {
        public double X { get; private set; }
        public double Y { get; private set; }
        public double Z { get; private set; }
        
        private Vector(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
       
        public static Vector FromPoints(Point startPoint, Point endPoint) => new(
                endPoint.X - startPoint.X,
                endPoint.Y - startPoint.Y,
                endPoint.Z - startPoint.Z);
        public static Vector FromXYZ(double x, double y, double z) => new(x, y, z);
        public static Vector Empty() => new(0, 0, 0);
        
        public static Vector operator *(Vector one, double two) => FromXYZ(one.X * two, one.Y * two, one.Z * two);

        public double Dot(Vector vector)
        {
            return X * vector.X + Y * vector.Y + Z * vector.Z;
        }
        
        // https://www.mathsisfun.com/algebra/vectors-cross-product.html
        public Vector Cross(Vector vector)
        {
            return FromXYZ(
                Y * vector.Z - Z * vector.Y,
                Z * vector.X - X * vector.Z,
                X * vector.Y - Y * vector.X
            );
        }

        public bool IsZero()
        {
            return X == 0.0 && Y == 0.0 && Z == 0.0;
        }
        
        public double GetLength()
        {
            return Math.Sqrt(X * X + Y * Y + Z * Z);
        }

        public Vector GetUnitVector()
        {
            return this * (1 / GetLength());
        }
        
        public override string ToString()
        {
            return $"Vector(X={X}, Y={Y}, Z={Z})";
        }
    }
}