namespace GraphicOne
{
    public class Plane
    {
        private Point PointOne;
        private Point PointTwo;
        private Point PointThree;

        public Plane(Point pointOne, Point pointTwo, Point pointThree)
        {
            PointOne = pointOne;
            PointTwo = pointTwo;
            PointThree = pointThree;
        }

        public Point[] getPlane()
        {
            return new Point[] {PointOne, PointTwo, PointThree};
        }
        
        public Point getPointOne()
        {
            return PointOne;
        } 
        public Point getPointTwo()
        {
            return PointTwo;
        } 
        public Point getPointThree()
        {
            return PointThree;
        } 
    }
}