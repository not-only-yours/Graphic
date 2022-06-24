using Core.RayTracing.Image;
using Core.Scenery;

namespace Core.Writer;

public interface IWriter<P> where P : IPixel
{
    public void Write(Image<P> image);
}