using Core.Geometry;
using Core.Scenery;

namespace Core.Writer;

public class PpmWriter : IWriter
{
    private readonly string _outputPath;

    public PpmWriter(string outputPath)
    {
        _outputPath = outputPath;
    }
    
    public void Write(Image image)
    {
        var writer = new StreamWriter(_outputPath);
        writer.WriteLine("P3");
        writer.WriteLine($"{image.Width}  {image.Height}");
        writer.WriteLine("255");
        
        var grayMultiplier = Vector.FromXYZ(255, 255, 255);   
        
        for (var i = 0; i < image.Height; i++)
        {
            for (var j = 0; j < image.Width; j++)
            {
                var shading = image[i, j].Shading;
                writer.WriteLine((int)(grayMultiplier * shading).X + " " + (int)(grayMultiplier * shading).Y + " " + (int)(grayMultiplier * shading).Z);
                // switch (shading)
                // {
                //     case < 0:
                //         writer.WriteLine((int)(grayMultiplier * shading).X + " " + (int)(grayMultiplier * 0).Y + " " + (int)(grayMultiplier * 0).Z);
                //         break;
                //     case >= 0 and <= 0.2:
                //         writer.WriteLine((int)(grayMultiplier * shading).X + " " + (int)(grayMultiplier * 0.1).Y + " " + (int)(grayMultiplier * 0.1).Z);
                //         break;
                //     case > 0.2 and <= 0.5:
                //         writer.WriteLine((int)(grayMultiplier * shading).X + " " + (int)(grayMultiplier * 0.35).Y + " " + (int)(grayMultiplier * 0.35).Z);
                //         break;
                //     case > 0.5 and <= 0.8:
                //         writer.WriteLine((int)(grayMultiplier * 0.65).X + " " + (int)(grayMultiplier * 0.65).Y + " " + (int)(grayMultiplier * 0.65).Z);
                //         break;
                //     case > 0.8:
                //         writer.WriteLine((int)(grayMultiplier * 1).X + " " + (int)(grayMultiplier * 1).Y + " " + (int)(grayMultiplier * 1).Z);
                //         break;
                // }
            }
        }
        writer.Flush();
        writer.Close();
    }
}