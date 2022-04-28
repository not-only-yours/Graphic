namespace Graphic;

public class Triangle
{
    public Point PointOne { get; private set; }
    public Point PointTwo { get; private set; }
    public Point PointThree { get; private set; }
    
    public Triangle(Point pointOne, Point pointTwo, Point pointThree) {
        PointOne = pointOne;
        PointTwo = pointTwo;
        PointThree = pointThree;
    }
    
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