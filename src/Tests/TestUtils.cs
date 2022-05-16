namespace Graphic.Tests;

public static class TestUtils
{
    public static bool IsArrayEquals<T>(T[,] arr1, T[,] arr2)
    {
        if (arr1.GetLength(0) != arr2.GetLength(0) || arr1.GetLength(1) != arr2.GetLength(1))
        {
            return false;
        }

        var height = arr1.GetLength(0);
        var width = arr1.GetLength(1);

        for (var i = 0; i < height; i++)
        {
            for (var j = 0; j < width; j++)
            {
                if (!arr1[i, j]!.Equals(arr2[i, j])) return false;
            }
        }

        return true;
    }
}