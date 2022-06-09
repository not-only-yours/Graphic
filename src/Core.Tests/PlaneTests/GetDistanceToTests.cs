using System;
using System.Collections.Generic;
using Core.Geometry;
using Core.Geometry.Shapes;
using NUnit.Framework;

namespace Core.Tests.PlaneTests;

public class GetDistanceToTests
{
    // https://keisan.casio.com/exec/system/1223614315
    public static IEnumerable<TestCaseData> Plane_GetDistanceTo_ReturnsCorrectDistance_TestData
    {
        get
        {
            // Outside
            yield return new TestCaseData(
                Plane.FromCenterAndNormal(Point.FromXYZ(1, 1, 1), Vector.FromXYZ(1, 0, 0)),
                Point.FromXYZ(1, 1, 2),
                2.886);
            
            yield return new TestCaseData(
                Plane.FromCenterAndNormal(Point.FromXYZ(1, 1, 1), Vector.FromXYZ(1, 0, 0)),
                Point.FromXYZ(-1, 1, -2),
                0.577);
            
            // On the plane
            yield return new TestCaseData(
                Plane.FromCenterAndNormal(Point.FromXYZ(1, 1, 1), Vector.FromXYZ(1, 0, 0)),
                Point.FromXYZ(0, 0, -1),
                0);
        }
    }
    
    [Test]
    [TestCaseSource(nameof(Plane_GetDistanceTo_ReturnsCorrectDistance_TestData))]
    public void Plane_GetDistanceTo_ReturnsCorrectDistance(Plane plane, Point point, double distance)
    {
        var foundDistance = plane.GetDistanceTo(point);
        
        Assert.IsTrue(Math.Abs(foundDistance - distance) < 0.001);
    }
}