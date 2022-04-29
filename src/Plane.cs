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
    }
}