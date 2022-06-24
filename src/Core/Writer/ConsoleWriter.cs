using Core.RayTracing.Image;
using Core.Scenery;

namespace Core.Writer;

public class ConsoleWriter : IWriter<CharPixel>
{
    public void Write(Image<CharPixel> image)
    {
        for (var i = 0; i < image.Height; i++)
        {
            for (var j = 0; j < image.Width; j++)
            {
                Console.Write(image[i, j].Char + " ");
            }
            Console.WriteLine();
        }
    }
}