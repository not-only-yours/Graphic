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
            return FromPointAndXYZ(
                start,
                x,
                y,
                z);
        }

        // public override string ToString()
        // {
        //     return $"{X} {Y} {Z}";
        // }
    }
}