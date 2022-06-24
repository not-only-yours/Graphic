using System;
using System.Collections.Generic;
using Core.Geometry;
using Core.Geometry.Shapes;
using Core.Matrices;
using NUnit.Framework;

namespace Core.Tests.PointTests;

public class PointTransformTests
{
    public static IEnumerable<TestCaseData> Point_Transform_TestData
    {
        get
        {
            yield return new TestCaseData(
                Matrix4x4.CreateNew(
                    0, 1, 2, 3,
                    1, 0, 1, 2,
                    2, 1, 0, 1,
                    3, 2, 1, 0),
                Point.FromXYZ(2, 0, 1),
                Point.FromXYZ(5, 5, 5)
            );
            yield return new TestCaseData(
                Matrix4x4.CreateNew(
                    1, 1, 4, 4,
                    2, 2, 3, 3,
                    3, 3, 2, 2,
                    4, 4, 1, 1),
                Point.FromXYZ(2, 0, 3),
                Point.FromXYZ(18, 16, 14)
            );
            yield return new TestCaseData(
                Matrix4x4.CreateNew(
                    0, 1, 0, 1,
                    1, 0, 1, 0,
                    0, 1, 0, 1,
                    1, 0, 1, 0),
                Point.FromXYZ(1, 1, 0),
                Point.FromXYZ(2, 1, 2)
            );
            yield return new TestCaseData(
                Matrix4x4.CreateNew(
                    16, 15, 14, 13,
                    5, 4, 3, 12,
                    6, 1, 2, 11,
                    7, 8, 9, 10),
                Point.FromXYZ(1, 2, 3),
                Point.FromXYZ(101, 34, 25)
            );
            yield return new TestCaseData(
                Matrix4x4.CreateNew(
                    0, 0, 0, 0,
                    0, 0, 0, 0,
                    0, 0, 0, 0,
                    0, 0, 0, 0),
                Point.FromXYZ(1, 1, 1),
                Point.FromXYZ(0, 0, 0)
            );
        }
    }
    
    [Test]
    [TestCaseSource(nameof(Point_Transform_TestData))]
    public void Point_Transform_ReturnsCorrectPoint(Matrix4x4 m , Point point, Point result)
    {
        point.Transform(m);
        Assert.IsTrue(point!.IsEqualTo(result));
    }
    
}