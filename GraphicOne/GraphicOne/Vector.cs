namespace GraphicOne
{
    public class Vector
    {
        private Point startPoint;
        private Point endPoint;

        public Vector(Point startPoint, Point endPoint)
        {
            this.startPoint = startPoint;
            this.endPoint = endPoint;
        }

        public Vector(int startPointX, int startPointY, int endPointX, int endPointY)
        {
            startPoint = new Point(startPointX, startPointY);
            endPoint = new Point(endPointX, endPointY);
        }

        public Point[] getVector()
        {
            return new Point[] {startPoint, endPoint};
        }

        public Point getStartVector()
        {
            return startPoint;
        }
        
        public Point getEndVector()
        {
            return endPoint;
        }
        
        public static Vector divideVectors(Vector one, Vector two)
        {
            return new Vector(
                two.startPoint.getX() - one.startPoint.getX(),
                two.startPoint.getY() - one.startPoint.getY(),
                two.endPoint.getX() - two.endPoint.getX(),
                two.endPoint.getY() - two.endPoint.getY());
        }
    }
}