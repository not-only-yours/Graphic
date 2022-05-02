namespace Graphic
{
    public class Plane
    {
        public Point PointOne { get; private set; }
        public Point PointTwo { get; private set; }
        public Point PointThree { get; private set; }

        public Plane(Point pointOne, Point pointTwo, Point pointThree)
        {
            PointOne = pointOne;
            PointTwo = pointTwo;
            PointThree = pointThree;
        }

        public Point[] ToPoints()
        {
            return new Point[] { PointOne, PointTwo, PointThree };
        }
        
        public Vector GetNormalVector()
        {
            var oneTwo = Vector.FromPoints(PointOne, PointTwo);
            
            var oneThree = Vector.FromPoints(PointOne, PointThree);

            return oneTwo.Cross(oneThree);
        }

        public Point? GetIntersectionWith(Point origin, Vector ray)
        {
            //https://stackoverflow.com/questions/23975555/how-to-do-ray-plane-intersection
            var n = GetNormalVector();
            var oneTwo = Vector.FromPoints(PointOne, PointTwo);
            
            var d = oneTwo.Dot(Vector.FromXYZ(oneTwo.X,oneTwo.Y,oneTwo.Z));
            var t = -(d + origin.Z * n.Z + origin.Y * n.Y + origin.X * n.X) / (ray.Z * n.Z + ray.Y * n.Y + ray.X * n.X);
            return origin + ray * t;
        }
    }
}