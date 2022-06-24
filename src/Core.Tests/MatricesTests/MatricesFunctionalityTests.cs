using System;
using System.Collections.Generic;
using Core.Matrices;
using NUnit.Framework;

namespace Core.Tests.MatricesTests;

public class MatricesFunctionalityTests
{
    public static IEnumerable<TestCaseData> Matrices_Multi_TestData
    {
        get
        {
            yield return new TestCaseData(
                Matrix4x4.CreateNew(
                    0, 1, 2, 3,
                    1, 0, 1, 2,
                    2, 1, 0, 1,
                    3, 2, 1, 0),
                Matrix4x4.CreateNew(
                    0, 1, 2, 3,
                    1, 0, 1, 2,
                    2, 1, 0, 1,
                    3, 2, 1, 0),
                Matrix4x4.CreateNew(
                    14, 8, 4, 4,
                    8, 6, 4, 4,
                    4, 4, 6, 8,
                    4, 4, 8, 14)
            );
            yield return new TestCaseData(
                Matrix4x4.CreateNew(
                    1, 1, 4, 4,
                    2, 2, 3, 3,
                    3, 3, 2, 2,
                    4, 4, 1, 1),
                Matrix4x4.CreateNew(
                    0, 1, 2, 3,
                    1, 0, 1, 2,
                    2, 1, 0, 1,
                    3, 2, 1, 0),
                Matrix4x4.CreateNew(
                    21, 13, 7, 9,
                    17, 11, 9, 13,
                    13, 9, 11, 17,
                    9, 7, 13, 21)
            );
            yield return new TestCaseData(
                Matrix4x4.CreateNew(
                    0, 1, 0, 1,
                    1, 0, 1, 0,
                    0, 1, 0, 1,
                    1, 0, 1, 0),
                Matrix4x4.CreateNew(
                    0, 1, 2, 3,
                    1, 0, 1, 2,
                    2, 1, 0, 1,
                    3, 2, 1, 0),
                Matrix4x4.CreateNew(
                    4, 2, 2, 2,
                    2, 2, 2, 4,
                    4, 2, 2, 2,
                    2, 2, 2, 4)
            );
            yield return new TestCaseData(
                Matrix4x4.CreateNew(
                    16, 15, 14, 13,
                    5, 4, 3, 12,
                    6, 1, 2, 11,
                    7, 8, 9, 10),
                Matrix4x4.CreateNew(
                    0, 1, 2, 3,
                    1, 0, 1, 2,
                    2, 1, 0, 1,
                    3, 2, 1, 0),
                Matrix4x4.CreateNew(
                    82, 56, 60, 92,
                    46, 32, 26, 26,
                    38, 30, 24, 22,
                    56, 36, 32, 46)
            );
            yield return new TestCaseData(
                Matrix4x4.CreateNew(
                    0, 0, 0, 0,
                    0, 0, 0, 0,
                    0, 0, 0, 0,
                    0, 0, 0, 0),
                Matrix4x4.CreateNew(
                    0, 1, 2, 3,
                    1, 0, 1, 2,
                    2, 1, 0, 1,
                    3, 2, 1, 0),
                Matrix4x4.CreateNew(
                    0, 0, 0, 0,
                    0, 0, 0, 0,
                    0, 0, 0, 0,
                    0, 0, 0, 0)
            );
        }
    }
    
    [Test]
    [TestCaseSource(nameof(Matrices_Multi_TestData))]
    public void Matrices_Multi_ReturnsCorrectMatrice(Matrix4x4 m , Matrix4x4 m2, Matrix4x4 result)
    {
        var ans = m * m2;
        Console.WriteLine(ans);
        Assert.IsTrue(ans!.IsEqualTo(result));
    }
}