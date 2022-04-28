namespace Graphic;

public class Sphere
{
    public Point centre { get; private set; }
    public double radius { get; private set; }
    
    public Sphere(Point centre, double radius)
    {
        this.centre = centre;
        this.radius = radius;
    }
}