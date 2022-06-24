using System;
using System.Collections.Generic;
using Core.Geometry;
using Core.Geometry.Shapes;
using NUnit.Framework;

namespace Core.Tests.SphereTests;

public class GetIntersectionWithTests
{
    public static IEnumerable<TestCaseData> Sphere_GetIntersectionWith_ReturnsIntersection_TestData
    {
        get
        {
            // Outside
            yield return new TestCaseData(
                Sphere.FromCentreAndRadius(Point.FromXYZ(0, 0, 0), 1),
                Vector.FromXYZ(0, 0, -1),
                Point.FromXYZ(0,0,2),
                Point.FromXYZ(0, 0, 1));
            
            yield return new TestCaseData(
                Sphere.FromCentreAndRadius(Point.FromXYZ(0, 0, 0), 1),
                Vector.FromXYZ(-1, 0, 0),
                Point.FromXYZ(5,0,0),
                Point.FromXYZ(1, 0, 0));
            
            // On the sphere
            yield return new TestCaseData(
                Sphere.FromCentreAndRadius(Point.FromXYZ(0, 0, 0), 1),
                Vector.FromXYZ(0, 3, 0),
                Point.FromXYZ(0,-1,0),
                Point.FromXYZ(0, -1, 0));
            
            // Inside
            yield return new TestCaseData(
                Sphere.FromCentreAndRadius(Point.FromXYZ(0, 0, 0), 1),
                Vector.FromXYZ(5, 0, 0),
                Point.FromXYZ(0,0,0),
                Point.FromXYZ(1, 0, 0));
        }
    }
    
    
    
    [Test]
    [TestCaseSource(nameof(Sphere_GetIntersectionWith_ReturnsIntersection_TestData))]
    public void Sphere_GetIntersectionWith_ReturnsCorrectFoundPoint(Sphere sphere, Vector ray, Point rayOrigin, Point intersection)
    {

        var foundIntersection = sphere.GetIntersectionWith(rayOrigin, ray);
        Console.WriteLine(foundIntersection.Point.ToString());
        Assert.IsNotNull(foundIntersection);
        Assert.IsTrue(foundIntersection.Point!.IsEqualTo(intersection));
    }
    
    public static IEnumerable<TestCaseData> Sphere_GetIntersectionWith_ReturnsNull_TestData
    {
        get
        {
            // Outside
            yield return new TestCaseData(
                Sphere.FromCentreAndRadius(Point.FromXYZ(0, 0, 0), 1),
                Vector.FromXYZ(0, 0, 1),
                Point.FromXYZ(0,5,0),
                Point.FromXYZ(0, 0, 0));
            
            yield return new TestCaseData(
                Sphere.FromCentreAndRadius(Point.FromXYZ(0, 0, 0), 1),
                Vector.FromXYZ(1, 0, 0),
                Point.FromXYZ(0,5,0),
                Point.FromXYZ(0, 0, 0));
            
            yield return new TestCaseData(
                Sphere.FromCentreAndRadius(Point.FromXYZ(0, 0, 0), 1),
                Vector.FromXYZ(0, -3, 0),
                Point.FromXYZ(0,0,-5),
                Point.FromXYZ(0, 0, 0));
        }
    }
    
    [Test]
    [TestCaseSource(nameof(Sphere_GetIntersectionWith_ReturnsNull_TestData))]
    public void Sphere_GetIntersectionWith_ReturnsNullSphere(Sphere sphere, Vector ray, Point rayOrigin, Point intersection)
    {

        var foundIntersection = sphere.GetIntersectionWith(rayOrigin, ray);
        
        Assert.IsNull(foundIntersection);
    }
}