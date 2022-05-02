namespace Graphic
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

        // public static Vector operator +(Vector one, Vector two) => FromPoints(one.StartPoint + two.StartPoint, one.EndPoint + two.EndPoint);
        // public static Vector operator -(Vector one, Vector two)
        // {
        //     return FromPoints(one.StartPoint - two.StartPoint, one.EndPoint - two.EndPoint);
        // }
        //
        // public static double Dot(Vector one, Vector two)
        // {
        //     return one.X * two.X + one.Y * two.Y + one.Z * two.Z;
        // }
        //
        
        //
        // public static double Dot(Vector one, Point two)
        // {
        //     return one.X * two.X + one.Y * two.Y + one.Z * two.Z;
        // }
        //
        // 
        //
        
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
        
        public override string ToString()
        {
            return $"{X} {Y} {Z}";
        }

        public double length()
        {
            return Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2) + Math.Pow(Z, 2));
        }
        
        public Vector norm()
        {
            //https://stackoverflow.com/questions/36180741/intersection-of-ray-and-rectangle-in-c
            return this * (1 / Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2) + Math.Pow(Z, 2)));
        }
    }
}