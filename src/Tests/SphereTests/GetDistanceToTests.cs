using Graphic.Geometry;
using Graphic.Geometry.Shapes;
using NUnit.Framework;

namespace Graphic.Tests.SphereTests;

public class GetDistanceToTests
{
    public static IEnumerable<TestCaseData> Sphere_GetDistanceTo_ReturnsCorrectDistance_TestData
    {
        get
        {
            // Outside
            yield return new TestCaseData(
                Sphere.FromCentreAndRadius(Point.FromXYZ(0, 0, 0), 1),
                Point.FromXYZ(0, 0, 2),
                1.0);
            
            yield return new TestCaseData(
                Sphere.FromCentreAndRadius(Point.FromXYZ(0, 0, 0), 1),
                Point.FromXYZ(0, 0, 10),
                9.0);
            
            // On the sphere
            yield return new TestCaseData(
                Sphere.FromCentreAndRadius(Point.FromXYZ(0, 0, 0), 1),
                Point.FromXYZ(0, 0, 1),
                0.0);
            
            // Inside
            yield return new TestCaseData(
                Sphere.FromCentreAndRadius(Point.FromXYZ(0, 0, 0), 1),
                Point.FromXYZ(0, 0, 0),
                1.0);
        }
    }
    
    [Test]
    [TestCaseSource(nameof(Sphere_GetDistanceTo_ReturnsCorrectDistance_TestData))]
    public void Sphere_GetDistanceTo_ReturnsCorrectDistance(Sphere sphere, Point point, double distance)
    {
        var foundDistance = sphere.GetDistanceTo(point);
        
        Assert.IsTrue(Math.Abs(foundDistance - distance) < 0.001);
    }
}