namespace Graphic
{
    public class Ray
    {
        public Point StartPoint { get; private set; }
        public double X { get; private set; }
        public double Y { get; private set; }
        public double Z { get; private set; }
        
        private Ray(Point start,double x, double y, double z)
        {
            StartPoint = start;
            X = x;
            Y = y;
            Z = z;
        }
        
        public static Ray FromPointAndXYZ(Point start, double x, double y, double z)
        {
            return new Ray(
                start,
                x,
                y,
                z);
        }
        
        public static double Dot(Ray one, Point two)
        {
            return one.X * two.X + one.Y * two.Y + one.Z * two.Z;
        }

         public override string ToString()
         {
             return $"{X} {Y} {Z}";
         }
    }
}