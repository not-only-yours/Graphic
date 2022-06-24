using Core.Scenery;

namespace Core.Writer;

public class ConsoleWriter : IWriter
{
    public void Write(Image image)
    {
        for (var i = 0; i < image.Height; i++)
        {
            for (var j = 0; j < image.Width; j++)
            {
                var shadingChar =(image[i, j].Shading) switch
                {
                    < 0 => ' ',
                    >= 0 and <= 0.2 => '.',
                    > 0.2 and <= 0.5 => '*',
                    > 0.5 and <= 0.8 => '0',
                    > 0.8 => '#',
                    _ => throw new ArgumentOutOfRangeException()
                };
                 
                Console.Write(shadingChar + " ");
            }
            Console.WriteLine();
        }
    }
}