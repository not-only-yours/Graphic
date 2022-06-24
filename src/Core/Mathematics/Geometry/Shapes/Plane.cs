using Core.Geometry.Shapes.Abstract;
using Core.Matrices;

namespace Core.Geometry.Shapes
{
    public class Plane : Shape
    {
        public double X { get; }
        public double Y { get; }
        public double Z { get; }
        public double D { get; }
        
        public Point Center { get; }
        public Vector Normal { get; }

        private Plane(double x, double y, double z, double d, Point center, Vector normal)
        {
            X = x;
            Y = y;
            Z = z;
            D = d;
            Center = center;
            Normal = normal;
        }

        // https://math.stackexchange.com/questions/2912365/vectors-find-the-equation-of-the-plane-in-xyz-space-through-the-point-p-3-2-3
        public static Plane FromCenterAndNormal(Point center, Vector normal)
        {
            return new Plane(
                center.X,
                center.Y,
                center.Z,
                center.X * normal.X + center.Y * normal.Y + center.Z * normal.Z,
                center,
                normal);
        }
        
        // https://stackoverflow.com/questions/23975555/how-to-do-ray-plane-intersection
        public override Intersection? GetIntersectionWith(Point origin, Vector ray)
        {
            var top = -(D + origin.Z * Z + origin.Y * Y + origin.X * X);
            var down = ray.Z * Z + ray.Y * Y + ray.X * X;
            var t =  top / down;
            return down != 0 ? 
                Intersection.Found(origin + ray * t, t, Normal * -1) 
                : null;
        }

        // public override double GetDistanceTo(Point point)
        // {
        //     var d = Math.Abs(X * point.X + Y * point.Y + Z * point.Z + D);
        //     var e = Math.Sqrt(X * X + Y * Y + Z * Z);
        //     return d / e;
        // }

        public override void Transform(Matrix4x4 transformationMatrix)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"Plane(X={X}, Y={Y}, Z={Z}, D={D})";
        }
    }
}