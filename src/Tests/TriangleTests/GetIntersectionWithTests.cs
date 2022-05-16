using Graphic.Geometry;
using Graphic.Geometry.Shapes;
using NUnit.Framework;

namespace Graphic.Tests.TriangleTests;

[TestFixture]
public class GetIntersectionWithTests
{
    public static IEnumerable<TestCaseData> Triangle_GetIntersectionWith_ReturnsCorrectFoundPoint_TestData
    {
        get
        {
            yield return new TestCaseData(
                Point.FromXYZ(1, 1, -1),
                Vector.FromXYZ(-1, -1, 1),
                Point.FromXYZ(0, 0, 0), Point.FromXYZ(10, 10, 0), Point.FromXYZ(0, 10, 0),
                Point.FromXYZ(0, 0, 0));
            
            yield return new TestCaseData(
                Point.FromXYZ(3, 3, -1),
                Vector.FromXYZ(-2, -2, 5),
                Point.FromXYZ(0, 0, 0), Point.FromXYZ(10, 10, 0), Point.FromXYZ(0, 10, 0),
                Point.FromXYZ(2.6, 2.6, 0));
            
            yield return new TestCaseData(
                Point.FromXYZ(3, 3, -1),
                Vector.FromXYZ(1, 2, 0.5),
                Point.FromXYZ(0, 0, 0), Point.FromXYZ(10, 10, 0), Point.FromXYZ(0, 10, 0),
                Point.FromXYZ(5, 7, 0));
            
            yield return new TestCaseData(
                Point.FromXYZ(3, 3, -1),
                Vector.FromXYZ(-1, -1, 0.5),
                Point.FromXYZ(0, 0, 0), Point.FromXYZ(10, 10, 0), Point.FromXYZ(0, 10, 0),
                Point.FromXYZ(1, 1, 0));
            
            yield return new TestCaseData(
                Point.FromXYZ(4, 5, -1),
                Vector.FromXYZ(-1, -1, 1),
                Point.FromXYZ(0, 0, 0), Point.FromXYZ(10, 10, 0), Point.FromXYZ(0, 10, 0),
                Point.FromXYZ(3, 4, 0));
        }
    }
    
    [Test]
    [TestCaseSource(nameof(Triangle_GetIntersectionWith_ReturnsCorrectFoundPoint_TestData))]
    public void Triangle_GetIntersectionWith_ReturnsCorrectFoundPoint(Point rayOrigin, Vector ray, Point one, Point two, Point three, Point intersection)
    {
        var triangle = Triangle.FromPoints(one, two, three);
        
        var foundIntersection = triangle.GetIntersectionWith(rayOrigin, ray);
        
        Assert.IsNotNull(foundIntersection);
        Assert.IsTrue(foundIntersection!.IsEqualTo(intersection));
    }
    
    public static IEnumerable<TestCaseData> Triangle_GetIntersectionWith_ReturnsNull_TestData
    {
        get
        {
            yield return new TestCaseData(
                Point.FromXYZ(1, 1, 0),
                Vector.FromXYZ(-1, -1, 0),
                Point.FromXYZ(0, 0, 0), Point.FromXYZ(10, 10, 0), Point.FromXYZ(0, 10, 0));
            
            yield return new TestCaseData(
                Point.FromXYZ(12, 12, 12),
                Vector.FromXYZ(0, 0, 5),
                Point.FromXYZ(0, 0, 0), Point.FromXYZ(10, 10, 0), Point.FromXYZ(0, 10, 0));
            
            yield return new TestCaseData(
                Point.FromXYZ(1, 1, 12),
                Vector.FromXYZ(-2, -1, -5),
                Point.FromXYZ(0, 0, 0), Point.FromXYZ(10, 10, 0), Point.FromXYZ(0, 10, 0));
            
            yield return new TestCaseData(
                Point.FromXYZ(1, 1, 12),
                Vector.FromXYZ(0, 0, 0),
                Point.FromXYZ(0, 0, 0), Point.FromXYZ(10, 10, 0), Point.FromXYZ(0, 10, 0));
        }
    }
    
    [Test]
    [TestCaseSource(nameof(Triangle_GetIntersectionWith_ReturnsNull_TestData))]
    public void Triangle_GetIntersectionWith_ReturnsNull(Point rayOrigin, Vector ray, Point one, Point two, Point three)
    {
        var triangle = Triangle.FromPoints(one, two, three);
        
        var foundIntersection = triangle.GetIntersectionWith(rayOrigin, ray);
        
        Assert.IsNull(foundIntersection);
    }
}
