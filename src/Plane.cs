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
        
        // https://www.mathsisfun.com/algebra/vectors-cross-product.html
        public Ray GetNormalRay()
        {
            var oneTwo = Vector.FromPoints(PointOne, PointTwo);
            
            var oneThree = Vector.FromPoints(PointOne, PointThree);

            return Ray.FromPointAndXYZ(
                PointOne,
                oneTwo.Y * oneThree.Z - oneTwo.Z * oneThree.Y,
                oneTwo.Z * oneThree.X - oneTwo.X * oneThree.Z,
                oneTwo.X * oneThree.Y - oneTwo.Y * oneThree.X
            );
        }
    }
}