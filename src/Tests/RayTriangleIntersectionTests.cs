using NUnit.Framework;

namespace Graphic.Tests;

[TestFixture]
public class RayTriangleIntersectionTests
{
    public static IEnumerable<TestCaseData> TriangleGetIntersectionWithIsCorrectTestData
    {
        get
        {
            yield return new TestCaseData(
                Point.FromXYZ(1, 1, -1),
                Vector.FromXYZ(-1, -1, 1),
                Point.FromXYZ(0, 0, 0), Point.FromXYZ(10, 10, 0), Point.FromXYZ(0, 10, 0),
                Point.FromXYZ(0, 0, 0));
        }
    }
    
    [Test]
    [TestCaseSource(nameof(TriangleGetIntersectionWithIsCorrectTestData))]
    public void Triangle_GetIntersectionWith_IsCorrect(Point rayOrigin, Vector ray, Point one, Point two, Point three, Point intersection)
    {
        var triangle = Triangle.FromPoints(one, two, three);
        
        var foundIntersection = triangle.GetIntersectionWith(rayOrigin, ray);
        
        Assert.IsNotNull(foundIntersection);
        Assert.IsTrue(foundIntersection!.IsEqualTo(intersection));
    }
    
    // [Test]
    // public void IntersectionIs1()
    // {
    //     var rayOrigin = Point.FromXYZ(1, 1, -1);
    //     var ray = Vector.FromXYZ(-1,-1, 1);
    //     
    //     var triangle = Triangle.FromPoints(
    //         Point.FromXYZ(0, 0, 0),
    //         Point.FromXYZ(10, 10, 0),
    //         Point.FromXYZ(0, 10, 0));
    //     
    //     var intersection = triangle.GetIntersectionWith(rayOrigin, ray);
    //     
    //     Assert.IsNotNull(intersection);
    //     Assert.That(intersection, Is.EqualTo(Point.FromXYZ(0, 0, 0)));
    // }
    
    // [Test]
    // public void IntersectionIs2()
    // {
    //     var triangleOne = Point.FromXYZ(0, 0, 0);
    //     var triangleTwo = Point.FromXYZ(10, 10, 0);
    //     var triangleThree = Point.FromXYZ(0, 10, 0);
    //         
    //     var rayOne = Point.FromXYZ(3, 3, -1);
    //     var r = Ray.FromPointAndXYZ(rayOne, -2,-2, 5);
    //     
    //     var t = new Triangle(triangleOne, triangleTwo, triangleThree);
    //     var answer = isPointEquals(Cross.rayTriangleIntersection(r, t), Point.FromXYZ(2.6, 2.6, 0));
    //     Assert.IsTrue(answer, "Should be (2.6, 2.6, 0)");
    // }
    //
    // [Test]
    // public void IntersectionIs3()
    // {
    //     var triangleOne = Point.FromXYZ(0, 0, 0);
    //     var triangleTwo = Point.FromXYZ(10, 10, 0);
    //     var triangleThree = Point.FromXYZ(0, 10, 0);
    //         
    //     var rayOne = Point.FromXYZ(3, 3, -1);
    //     var r = Ray.FromPointAndXYZ(rayOne, 1,2, 0.5);
    //     
    //     var t = new Triangle(triangleOne, triangleTwo, triangleThree);
    //     var answer = isPointEquals(Cross.rayTriangleIntersection(r, t), Point.FromXYZ(5, 7, 0));
    //     Assert.IsTrue(answer, "Should be (5, 7, 0)");
    // }
    //
    // [Test]
    // public void IntersectionIs4()
    // {
    //     var triangleOne = Point.FromXYZ(0, 0, 0);
    //     var triangleTwo = Point.FromXYZ(10, 10, 0);
    //     var triangleThree = Point.FromXYZ(0, 10, 0);
    //         
    //     var rayOne = Point.FromXYZ(3, 3, -1);
    //     var r = Ray.FromPointAndXYZ(rayOne, -1,-1, 0.5);
    //     
    //     var t = new Triangle(triangleOne, triangleTwo, triangleThree);
    //     var answer = isPointEquals(Cross.rayTriangleIntersection(r, t), Point.FromXYZ(1, 1, 0));
    //     Assert.IsTrue(answer, "Should be (1, 1, 0)");
    // }
    //
    // [Test]
    // public void IntersectionIs5()
    // {
    //     var triangleOne = Point.FromXYZ(0, 0, 0);
    //     var triangleTwo = Point.FromXYZ(10, 10, 0);
    //     var triangleThree = Point.FromXYZ(0, 10, 0);
    //         
    //     var rayOne = Point.FromXYZ(4, 5, -1);
    //     var r = Ray.FromPointAndXYZ(rayOne, -1,-1, 1);
    //     
    //     var t = new Triangle(triangleOne, triangleTwo, triangleThree);
    //     var answer = isPointEquals(Cross.rayTriangleIntersection(r, t), Point.FromXYZ(3, 4, 0));
    //     Assert.IsTrue(answer, "Should be (3,4,0)");
    // }
    //
    //
    //
    // [Test]
    // public void TriangleParallelToRay()
    // {
    //     var triangleOne = Point.FromXYZ(0, 0, 0);
    //     var triangleTwo = Point.FromXYZ(10, 10, 0);
    //     var triangleThree = Point.FromXYZ(0, 10, 0);
    //         
    //     var rayOne = Point.FromXYZ(1, 1, 0);
    //     var r = Ray.FromPointAndXYZ(rayOne, -1,-1, 0);
    //     
    //     var t = new Triangle(triangleOne, triangleTwo, triangleThree);
    //     var answer = isPointEquals(Cross.rayTriangleIntersection(r, t), Point.noCoords());
    //     Assert.IsTrue(answer, "Should be empty. This ray is parallel to this triangle.");
    // }
    //
    // [Test]
    // public void IntersectionNo()
    // {
    //     var triangleOne = Point.FromXYZ(0, 0, 0);
    //     var triangleTwo = Point.FromXYZ(10, 10, 0);
    //     var triangleThree = Point.FromXYZ(0, 10, 0);
    //         
    //     var rayOne = Point.FromXYZ(12, 12, 12);
    //     var r = Ray.FromPointAndXYZ(rayOne, 0,0, 5);
    //     
    //     var t = new Triangle(triangleOne, triangleTwo, triangleThree);
    //     var answer = isPointEquals(Cross.rayTriangleIntersection(r, t), Point.noCoords());
    //     Assert.IsTrue(answer, "Should be empty. This ray is parallel to this triangle.");
    // }
    //
    // [Test]
    // public void IntersectionNo2()
    // {
    //     var triangleOne = Point.FromXYZ(0, 0, 0);
    //     var triangleTwo = Point.FromXYZ(10, 10, 0);
    //     var triangleThree = Point.FromXYZ(0, 10, 0);
    //         
    //     var rayOne = Point.FromXYZ(1, 1, 12);
    //     var r = Ray.FromPointAndXYZ(rayOne, -2,-1, -5);
    //     
    //     var t = new Triangle(triangleOne, triangleTwo, triangleThree);
    //     var answer = isPointEquals(Cross.rayTriangleIntersection(r, t), Point.noCoords());
    //     Assert.IsTrue(answer, "Should be empty. This ray is parallel to this triangle.");
    // }
    //
    // [Test]
    // public void IntersectionNoRay()
    // {
    //     var triangleOne = Point.FromXYZ(0, 0, 0);
    //     var triangleTwo = Point.FromXYZ(10, 10, 0);
    //     var triangleThree = Point.FromXYZ(0, 10, 0);
    //         
    //     var rayOne = Point.FromXYZ(1, 1, 12);
    //     var r = Ray.FromPointAndXYZ(rayOne, 0,0, 0);
    //     
    //     var t = new Triangle(triangleOne, triangleTwo, triangleThree);
    //     var answer = isPointEquals(Cross.rayTriangleIntersection(r, t), Point.noCoords());
    //     Assert.IsTrue(answer, "Should be empty. This ray is point");
    // }
    //
    // [Test]
    // public void IntersectionNoTriangle()
    // {
    //     var triangleOne = Point.FromXYZ(0, 0, 0);
    //     var triangleTwo = Point.FromXYZ(10, 10, 0);
    //     var triangleThree = Point.FromXYZ(0, 0, 0);
    //         
    //     var rayOne = Point.FromXYZ(1, 1, 12);
    //     var r = Ray.FromPointAndXYZ(rayOne, -1,-1, 5);
    //     
    //     var t = new Triangle(triangleOne, triangleTwo, triangleThree);
    //     var answer = isPointEquals(Cross.rayTriangleIntersection(r, t), Point.noCoords());
    //     Assert.IsTrue(answer, "Should be empty. This triangle is line segment");
    // }
}
