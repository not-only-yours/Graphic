using System;

namespace GraphicOne
{
    public class Vector
    {
        private Point startPoint;
        private Point endPoint;
        private double X;
        private double Y;
        private double Z;

        public Vector(Point startPoint, Point endPoint)
        {
            this.startPoint = startPoint;
            this.endPoint = endPoint;
            X = endPoint.getX() - startPoint.getX();
            Y = endPoint.getY() - startPoint.getY();
            Z = endPoint.getZ() - startPoint.getZ();
        }

        public Vector(double startPointX, double startPointY, double startPointZ, double endPointX, double endPointY , double endPointZ)
        {
            startPoint = new Point(startPointX, startPointY, startPointZ);
            endPoint = new Point(endPointX, endPointY, endPointZ);
            X = endPointX - startPointX;
            Y = endPointY - startPointY;
            Z = endPointZ - startPointZ;
        }



        public Vector(Point start, Point end, double X, double Y, double Z)
        {
            startPoint = start;
            endPoint = end;
            this.X = X;
            this.Y = Y;
            this.Z = Z;
        }

        public Vector(Point start,  double X, double Y, double Z)
        {
            startPoint = start;
            this.X = X;
            this.Y = Y;
            this.Z = Z;
        }

        public double[] getVector()
        {
            return new double[] {X, Y, Z};
        }

        public Point getStartVector()
        {
            return startPoint;
        }

        public Point getEndVector()
        {
            return endPoint;
        }

        public double getX()
        {
            return X;
        }
        public double getY()
        {
            return Y;
        }
        public double getZ()
        {
            return Z;
        }

        public static Vector sumofVectors(Vector one, Vector two)
        {
            return new Vector(
                one.X + two.X,
                one.Y + two.Y,
                one.Z + two.Z,
                one.X + two.X,
                one.Y + two.Y,
                one.Z + two.Z);
        }

        public static Vector subtractionVectors(Vector one, Vector two)
        {
            return new Vector(
                one.X - two.X,
                one.Y - two.Y,
                one.Z - two.Z,
                one.X - two.X,
                one.Y - two.Y,
                one.Z - two.Z
            );
        }

        public static void printVector(Vector v)
        {
            Console.Write(v.X + " " + v.Y + " " + v.Z);
        }
    }
}