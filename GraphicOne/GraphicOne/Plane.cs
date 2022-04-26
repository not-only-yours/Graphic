namespace GraphicOne
{
    public class Plane
    {
        private Point PointOne;
        private Point PointTwo;
        private Point PointThree;
        private Vector OneTwo;
        private Vector OneThree;

        public Plane(Point pointOne, Point pointTwo, Point pointThree)
        {
            PointOne = pointOne;
            PointTwo = pointTwo;
            PointThree = pointThree;

            OneTwo = new Vector(
                pointOne,
                pointTwo,
                pointTwo.getX() - pointOne.getX(),
                pointTwo.getY() - pointOne.getY(),
                pointTwo.getZ() - pointOne.getZ()
            );

            OneThree = new Vector(
                pointOne,
                pointThree,
                pointThree.getX() - pointOne.getX(),
                pointThree.getY() - pointOne.getY(),
                pointThree.getZ() - pointOne.getZ()
            );
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
        public Vector getFirstVector()
        {
            return OneTwo;
        }
        public Vector getSecondVector()
        {
            return OneThree;
        }
    }
}