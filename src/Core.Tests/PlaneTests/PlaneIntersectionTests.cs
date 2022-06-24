using System;
using System.Collections.Generic;
using Core.Geometry;
using Core.Geometry.Shapes;
using NUnit.Framework;

namespace Core.Tests.PlaneTests;

public class PlaneIntersectionTests
{
    public static IEnumerable<TestCaseData> Plane_PlaneIntersection_ReturnsPointOfIntersection_TestData
    {
        get
        {
            // Outside
            yield return new TestCaseData(
                Plane.FromCenterAndNormal(Point.FromXYZ(1, 1, 1), Vector.FromXYZ(1, 0, 0)),
                Point.FromXYZ(0, 0, 0),
                Vector.FromXYZ(1, 1, 2),
                Point.FromXYZ(-0.25, -0.25, -0.5));
            
            yield return new TestCaseData(
                Plane.FromCenterAndNormal(Point.FromXYZ(1, 1, 1), Vector.FromXYZ(1, 0, 0)),
                Point.FromXYZ(0, 0, 0),
                Vector.FromXYZ(-1, 1, -2),
                Point.FromXYZ(-0.5, 0.5, -1));
            
            // On the plane
            yield return new TestCaseData(
                Plane.FromCenterAndNormal(Point.FromXYZ(1, 1, 1), Vector.FromXYZ(1, 0, 0)),
                Point.FromXYZ(0, 0, 0),
                Vector.FromXYZ(0, 0, -1),
                Point.FromXYZ(0, 0, -1));
        }
    }

    [Test]
    [TestCaseSource(nameof(Plane_PlaneIntersection_ReturnsPointOfIntersection_TestData))]
    public void Plane_GetDistanceTo_ReturnsCorrectDistance(Plane plane,Point point, Vector direction, Point intersection)
    {
        var foundIntersection = plane.GetIntersectionWith(point, direction, null);
        Assert.IsNotNull(foundIntersection.Point);
        Assert.IsTrue(foundIntersection.Point.ToString().Equals(intersection.ToString()));
    }
    
    public static IEnumerable<TestCaseData> Plane_PlaneIntersection_ReturnsNull_TestData
    {
        get
        {
            // Outside
            yield return new TestCaseData(
                Plane.FromCenterAndNormal(Point.FromXYZ(0, 0, 0), Vector.FromXYZ(1, 0, 0)),
                Point.FromXYZ(2, 2, 2),
                Vector.FromXYZ(1, 0, 0),
                Point.FromXYZ(0, 0, 0));
            
            yield return new TestCaseData(
                Plane.FromCenterAndNormal(Point.FromXYZ(0, 0, 0), Vector.FromXYZ(1, 0, 0)),
                Point.FromXYZ(1, 1, 1),
                Vector.FromXYZ(1, 1, 1),
                Point.FromXYZ(0, 0, 0));
            
            // On the plane
            yield return new TestCaseData(
                Plane.FromCenterAndNormal(Point.FromXYZ(0, 0, 0), Vector.FromXYZ(1, 0, 0)),
                Point.FromXYZ(0, 0, 0),
                Vector.FromXYZ(0, 0, -1),
                Point.FromXYZ(0, 0, 0));
        }
    }
    
    [Test]
    [TestCaseSource(nameof(Plane_PlaneIntersection_ReturnsNull_TestData))]
    public void Plane_GetIntersectionWith_ReturnsNull(Plane plane,Point point, Vector direction, Point intersection)
    {
        var foundIntersection = plane.GetIntersectionWith(point, direction, null);
        Assert.IsNull(foundIntersection);
    }
}