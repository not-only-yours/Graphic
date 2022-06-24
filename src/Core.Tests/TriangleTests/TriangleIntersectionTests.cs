using System.Collections.Generic;
using Core.Geometry;
using Core.Geometry.Shapes;
using NUnit.Framework;

namespace Core.Tests.TriangleTests;

public class TriangleIntersectionTests
{
    public static IEnumerable<TestCaseData> Triangle_GetIntersectionWith_ReturnsIntersection_TestData
    {
        get
        {
            yield return new TestCaseData(
                Point.FromXYZ(1, 1, -1),
                Vector.FromXYZ(-1, -1, 1),
                Point.FromXYZ(0, 0, 0), Point.FromXYZ(10, 10, 0), Point.FromXYZ(0, 10, 0),
                Vector.FromXYZ(0, 0, 0),
                Vector.FromXYZ(0, 0, 0),
                Vector.FromXYZ(0, 0, 0),
                Point.FromXYZ(0, 0, 0));
            
            yield return new TestCaseData(
                Point.FromXYZ(3, 3, -1),
                Vector.FromXYZ(-2, -2, 5),
                Point.FromXYZ(0, 0, 0), Point.FromXYZ(10, 10, 0), Point.FromXYZ(0, 10, 0),
                Vector.FromXYZ(0, 0, 0),
                Vector.FromXYZ(0, 0, 0),
                Vector.FromXYZ(0, 0, 0),
                Point.FromXYZ(2.6, 2.6, 0));
            
            yield return new TestCaseData(
                Point.FromXYZ(3, 3, -1),
                Vector.FromXYZ(1, 2, 0.5),
                Point.FromXYZ(0, 0, 0), Point.FromXYZ(10, 10, 0), Point.FromXYZ(0, 10, 0),
                Vector.FromXYZ(0, 0, 0),
                Vector.FromXYZ(0, 0, 0),
                Vector.FromXYZ(0, 0, 0),
                Point.FromXYZ(5, 7, 0));
            
            yield return new TestCaseData(
                Point.FromXYZ(3, 3, -1),
                Vector.FromXYZ(-1, -1, 0.5),
                Point.FromXYZ(0, 0, 0), Point.FromXYZ(10, 10, 0), Point.FromXYZ(0, 10, 0),
                Vector.FromXYZ(0, 0, 0),
                Vector.FromXYZ(0, 0, 0),
                Vector.FromXYZ(0, 0, 0),
                Point.FromXYZ(1, 1, 0));
            
            yield return new TestCaseData(
                Point.FromXYZ(4, 5, -1),
                Vector.FromXYZ(-1, -1, 1),
                Point.FromXYZ(0, 0, 0), Point.FromXYZ(10, 10, 0), Point.FromXYZ(0, 10, 0),
                Vector.FromXYZ(0, 0, 0),
                Vector.FromXYZ(0, 0, 0),
                Vector.FromXYZ(0, 0, 0),
                Point.FromXYZ(3, 4, 0));
        }
    }
    
    [Test]
    [TestCaseSource(nameof(Triangle_GetIntersectionWith_ReturnsIntersection_TestData))]
    public void Triangle_GetIntersectionWith_ReturnsCorrectFoundPoint(Point rayOrigin, Vector ray, Point one, Point two, Point three,Vector normal1,Vector normal2,Vector normal3, Point intersection)
    {
        var triangle = Triangle.FromPointsAndNormals(one, two, three, normal1, normal2, normal3);
        
        var foundIntersection = triangle.GetIntersectionWith(rayOrigin, ray, null);
        
        Assert.IsNotNull(foundIntersection);
        Assert.IsTrue(foundIntersection.Point!.IsEqualTo(intersection));
    }
    
    public static IEnumerable<TestCaseData> Triangle_GetIntersectionWith_ReturnsNull_TestData
    {
        get
        {
            yield return new TestCaseData(
                Point.FromXYZ(1, 1, 1),
                Vector.FromXYZ(1, 0, 0),
                Point.FromXYZ(0, 0, 0), Point.FromXYZ(0, 10, 0), Point.FromXYZ(10, 0, 0),
                Vector.FromXYZ(0, 0, 0),
                Vector.FromXYZ(0, 0, 0),
                Vector.FromXYZ(0, 0, 0));
            
            yield return new TestCaseData(
                Point.FromXYZ(1, 1, 1),
                Vector.FromXYZ(1, 0, 0),
                Point.FromXYZ(0, 0, 0), Point.FromXYZ(0, 10, 0), Point.FromXYZ(10, 0, 0),
                Vector.FromXYZ(0, 0, 0),
                Vector.FromXYZ(0, 0, 0),
                Vector.FromXYZ(0, 0, 0));
            
            yield return new TestCaseData(
                Point.FromXYZ(1, 1, 1),
                Vector.FromXYZ(0, 1, 0),
                Point.FromXYZ(0, 0, 0), Point.FromXYZ(0, 10, 0), Point.FromXYZ(10, 0, 0),
                Vector.FromXYZ(0, 0, 0),
                Vector.FromXYZ(0, 0, 0),
                Vector.FromXYZ(0, 0, 0));
            
            yield return new TestCaseData(
                Point.FromXYZ(15, 15, 0),
                Vector.FromXYZ(1, 0, 0),
                Point.FromXYZ(0, 0, 0), Point.FromXYZ(0, 10, 0), Point.FromXYZ(10, 0, 0),
                Vector.FromXYZ(0, 0, 0),
                Vector.FromXYZ(0, 0, 0),
                Vector.FromXYZ(0, 0, 0));
            
            yield return new TestCaseData(
                Point.FromXYZ(15, 15, 1),
                Vector.FromXYZ(0, 0, 1),
                Point.FromXYZ(0, 0, 0), Point.FromXYZ(0, 10, 0), Point.FromXYZ(10, 0, 0),
                Vector.FromXYZ(0, 0, 0),
                Vector.FromXYZ(0, 0, 0),
                Vector.FromXYZ(0, 0, 0));
        }
    }
    
    [Test]
    [TestCaseSource(nameof(Triangle_GetIntersectionWith_ReturnsNull_TestData))]
    public void Triangle_GetIntersectionWith_ReturnsNull(Point rayOrigin, Vector ray, Point one, Point two, Point three, Vector normal1,Vector normal2,Vector normal3)
    {
        var triangle = Triangle.FromPointsAndNormals(one, two, three, normal1, normal2, normal3);
        
        var foundIntersection = triangle.GetIntersectionWith(rayOrigin, ray, null);
        
        Assert.IsNull(foundIntersection);
    }
}