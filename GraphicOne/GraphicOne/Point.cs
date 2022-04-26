using System;
using System.Reflection;

namespace GraphicOne
{
    public class Point
    {
        private double X;
        private double Y;
        private double Z;

        public Point(double X, double Y, double Z)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
        }

        public double[] getPoint()
        {
            return new double[] {X, Y, Z};
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
    }
}