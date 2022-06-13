using System.Collections;
using System.Diagnostics;
using Core.Geometry;
using Core.Geometry.Shapes;

namespace Core;

public class FileReader
{
    private String LocalFile;
    public ArrayList PointList { get; private set; }
    public ArrayList NormalList { get; private set; }
    public ArrayList TriangleList { get; private set; }
    
    private FileReader(String file)
    {
        LocalFile = file;
    }

    public static FileReader CreateReader(String a) => new(a);
    
    public void ReadOBJ()
    {
        
        foreach (string line in System.IO.File.ReadLines(LocalFile))
        {  
            string[] parts = line.Split(' ');
            
        }
    }
}