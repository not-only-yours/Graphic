using System;
using System.Reflection;

namespace GraphicOne
{
    public class Point
    {
        private int X;
        private int Y;

        public Point(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public int[] getPoint()
        {
            return new int[] {X, Y};
        }

        public int getX()
        {
            return X;
        }
        
        public int getY()
        {
            return Y;
        }
    }
}