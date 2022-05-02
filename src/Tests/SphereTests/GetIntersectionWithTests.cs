using NUnit.Framework;

namespace Graphic.Tests.SphereTests;

public class GetIntersectionWithTests
{
    public static IEnumerable<TestCaseData> Sphere_GetIntersectionWith_ReturnsCorrectFoundPoint_TestData
    {
        get
        {
            // Outside
            // From (-1,-1,-1) in all 3 planes (XY, XZ, YZ)
            yield return new TestCaseData(
                Point.FromXYZ(-1, -1, -1),
                Vector.FromXYZ(1, 1, 0),
                Sphere.FromCentreAndRadius(Point.FromXYZ(0, 0, 0), 1),
                Point.FromXYZ(0, 0, -1));
            
            yield return new TestCaseData(
                Point.FromXYZ(-1, -1, -1),
                Vector.FromXYZ(1, 0, 1),
                Sphere.FromCentreAndRadius(Point.FromXYZ(0, 0, 0), 1),
                Point.FromXYZ(0, -1, 0));
            
            yield return new TestCaseData(
                Point.FromXYZ(-1, -1, -1),
                Vector.FromXYZ(0, 1, 1),
                Sphere.FromCentreAndRadius(Point.FromXYZ(0, 0, 0), 1),
                Point.FromXYZ(-1, 0, 0));
            
            // On the sphere
            yield return new TestCaseData(
                Point.FromXYZ(1, 0, 0),
                Vector.FromXYZ(1, 1, 1),
                Sphere.FromCentreAndRadius(Point.FromXYZ(0, 0, 0), 1),
                Point.FromXYZ(1, 0, 0));
            
            yield return new TestCaseData(
                Point.FromXYZ(0, 1, 0),
                Vector.FromXYZ(1, 1, 1),
                Sphere.FromCentreAndRadius(Point.FromXYZ(0, 0, 0), 1),
                Point.FromXYZ(0, 1, 0));
            
            yield return new TestCaseData(
                Point.FromXYZ(0, 0, 1),
                Vector.FromXYZ(1, 1, 1),
                Sphere.FromCentreAndRadius(Point.FromXYZ(0, 0, 0), 1),
                Point.FromXYZ(0, 0, 1));
            
            // Inside
            // From the sphere center
            yield return new TestCaseData(
                 Point.FromXYZ(0, 0, 0),
                 Vector.FromXYZ(1, 0, 0),
                 Sphere.FromCentreAndRadius(Point.FromXYZ(0, 0, 0), 1),
                 Point.FromXYZ(1, 0, 0));
        }
    }
    
    [Test]
    [TestCaseSource(nameof(Sphere_GetIntersectionWith_ReturnsCorrectFoundPoint_TestData))]
    public void Sphere_GetIntersectionWith_ReturnsCorrectFoundPoint(Point rayOrigin, Vector ray, Sphere sphere, Point intersection)
    {
        var foundIntersection = sphere.GetIntersectionWith(rayOrigin, ray);
        
        Assert.IsNotNull(foundIntersection);
        Assert.IsTrue(foundIntersection!.IsEqualTo(intersection));
    }
    
    public static IEnumerable<TestCaseData> Sphere_GetIntersectionWith_ReturnsNull_TestData
    {
        get
        {
            // Outside
            // From (-1,-1,-1) in all 3 planes (XY, XZ, YZ)
            yield return new TestCaseData(
                Point.FromXYZ(-1, -1, -1),
                Vector.FromXYZ(1, 0, 0),
                Sphere.FromCentreAndRadius(Point.FromXYZ(0, 0, 0), 1));
            
            yield return new TestCaseData(
                Point.FromXYZ(-1, -1, -1),
                Vector.FromXYZ(0, 1, 0),
                Sphere.FromCentreAndRadius(Point.FromXYZ(0, 0, 0), 1));
            
            yield return new TestCaseData(
                Point.FromXYZ(-1, -1, -1),
                Vector.FromXYZ(0, 0, 1),
                Sphere.FromCentreAndRadius(Point.FromXYZ(0, 0, 0), 1));
            
            // Inside
            // From the sphere center
            yield return new TestCaseData(
                Point.FromXYZ(0, 0, 0),
                Vector.FromXYZ(0, 0, 0),
                Sphere.FromCentreAndRadius(Point.FromXYZ(0, 0, 0), 1));
        }
    }
    
    [Test]
    [TestCaseSource(nameof(Sphere_GetIntersectionWith_ReturnsNull_TestData))]
    public void Sphere_GetIntersectionWith_ReturnsNull(Point rayOrigin, Vector ray, Sphere sphere)
    {
        var foundIntersection = sphere.GetIntersectionWith(rayOrigin, ray);
        
        Assert.IsNull(foundIntersection);
    }
}