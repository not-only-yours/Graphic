using System;

namespace GraphicOne
{
    public static class NormalVector
    {
        public static Vector normalVector(Plane p)
        {
            //https://www.mathsisfun.com/algebra/vectors-cross-product.html
            //Console.WriteLine(p.getFirstVector().getY() * p.getSecondVector().getZ());
            //Console.WriteLine(p.getFirstVector().getZ() * p.getSecondVector().getY());
            return new Vector(
                p.getPointOne(),
                p.getFirstVector().getY() * p.getSecondVector().getZ() -
                p.getFirstVector().getZ() * p.getSecondVector().getY(),
                p.getFirstVector().getZ() * p.getSecondVector().getX() -
                p.getFirstVector().getX() * p.getSecondVector().getZ(),
                p.getFirstVector().getX() * p.getSecondVector().getY() -
                p.getFirstVector().getY() * p.getSecondVector().getX()
            );
        }
    }
}
