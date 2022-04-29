using System;
using Graphic;
using NUnit.Framework;

namespace TestingRayTriangleIntersection;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    public bool isPointEquals(Point a, Point b)
    {
        return Math.Abs(a.X - b.X) < 0.01 && Math.Abs(a.Y - b.Y) < 0.01 && Math.Abs(a.Z - b.Z) < 0.01;
    }

    [Test]
    public void IntersectionIs1()
    {
        var triangleOne = Point.FromXYZ(0, 0, 0);
        var triangleTwo = Point.FromXYZ(10, 10, 0);
        var triangleThree = Point.FromXYZ(0, 10, 0);
            
        var rayOne = Point.FromXYZ(1, 1, -1);
        var r = Ray.FromPointAndXYZ(rayOne, -1,-1, 1);
        
        var t = new Triangle(triangleOne, triangleTwo, triangleThree);
        var answer = isPointEquals(Cross.rayTriangleIntersection(r, t), Point.FromXYZ(0, 0, 0));
        Assert.IsTrue(answer, "Should be (0,0,0)");
    }
    
    [Test]
    public void IntersectionIs2()
    {
        var triangleOne = Point.FromXYZ(0, 0, 0);
        var triangleTwo = Point.FromXYZ(10, 10, 0);
        var triangleThree = Point.FromXYZ(0, 10, 0);
            
        var rayOne = Point.FromXYZ(3, 3, -1);
        var r = Ray.FromPointAndXYZ(rayOne, -2,-2, 5);
        
        var t = new Triangle(triangleOne, triangleTwo, triangleThree);
        var answer = isPointEquals(Cross.rayTriangleIntersection(r, t), Point.FromXYZ(2.6, 2.6, 0));
        Assert.IsTrue(answer, "Should be (2.6, 2.6, 0)");
    }

    [Test]
    public void IntersectionIs3()
    {
        var triangleOne = Point.FromXYZ(0, 0, 0);
        var triangleTwo = Point.FromXYZ(10, 10, 0);
        var triangleThree = Point.FromXYZ(0, 10, 0);
            
        var rayOne = Point.FromXYZ(3, 3, -1);
        var r = Ray.FromPointAndXYZ(rayOne, 1,2, 0.5);
        
        var t = new Triangle(triangleOne, triangleTwo, triangleThree);
        var answer = isPointEquals(Cross.rayTriangleIntersection(r, t), Point.FromXYZ(5, 7, 0));
        Assert.IsTrue(answer, "Should be (5, 7, 0)");
    }

    [Test]
    public void IntersectionIs4()
    {
        var triangleOne = Point.FromXYZ(0, 0, 0);
        var triangleTwo = Point.FromXYZ(10, 10, 0);
        var triangleThree = Point.FromXYZ(0, 10, 0);
            
        var rayOne = Point.FromXYZ(3, 3, -1);
        var r = Ray.FromPointAndXYZ(rayOne, -1,-1, 0.5);
        
        var t = new Triangle(triangleOne, triangleTwo, triangleThree);
        var answer = isPointEquals(Cross.rayTriangleIntersection(r, t), Point.FromXYZ(1, 1, 0));
        Assert.IsTrue(answer, "Should be (1, 1, 0)");
    }

    [Test]
    public void IntersectionIs5()
    {
        var triangleOne = Point.FromXYZ(0, 0, 0);
        var triangleTwo = Point.FromXYZ(10, 10, 0);
        var triangleThree = Point.FromXYZ(0, 10, 0);
            
        var rayOne = Point.FromXYZ(4, 5, -1);
        var r = Ray.FromPointAndXYZ(rayOne, -1,-1, 1);
        
        var t = new Triangle(triangleOne, triangleTwo, triangleThree);
        var answer = isPointEquals(Cross.rayTriangleIntersection(r, t), Point.FromXYZ(3, 4, 0));
        Assert.IsTrue(answer, "Should be (3,4,0)");
    }


    
    [Test]
    public void TriangleParallelToRay()
    {
        var triangleOne = Point.FromXYZ(0, 0, 0);
        var triangleTwo = Point.FromXYZ(10, 10, 0);
        var triangleThree = Point.FromXYZ(0, 10, 0);
            
        var rayOne = Point.FromXYZ(1, 1, 0);
        var r = Ray.FromPointAndXYZ(rayOne, -1,-1, 0);
        
        var t = new Triangle(triangleOne, triangleTwo, triangleThree);
        var answer = isPointEquals(Cross.rayTriangleIntersection(r, t), Point.noCoords());
        Assert.IsTrue(answer, "Should be empty. This ray is parallel to this triangle.");
    }
    
    [Test]
    public void IntersectionNo()
    {
        var triangleOne = Point.FromXYZ(0, 0, 0);
        var triangleTwo = Point.FromXYZ(10, 10, 0);
        var triangleThree = Point.FromXYZ(0, 10, 0);
            
        var rayOne = Point.FromXYZ(12, 12, 12);
        var r = Ray.FromPointAndXYZ(rayOne, 0,0, 5);
        
        var t = new Triangle(triangleOne, triangleTwo, triangleThree);
        var answer = isPointEquals(Cross.rayTriangleIntersection(r, t), Point.noCoords());
        Assert.IsTrue(answer, "Should be empty. This ray is parallel to this triangle.");
    }
    
    [Test]
    public void IntersectionNo2()
    {
        var triangleOne = Point.FromXYZ(0, 0, 0);
        var triangleTwo = Point.FromXYZ(10, 10, 0);
        var triangleThree = Point.FromXYZ(0, 10, 0);
            
        var rayOne = Point.FromXYZ(1, 1, 12);
        var r = Ray.FromPointAndXYZ(rayOne, -2,-1, -5);
        
        var t = new Triangle(triangleOne, triangleTwo, triangleThree);
        var answer = isPointEquals(Cross.rayTriangleIntersection(r, t), Point.noCoords());
        Assert.IsTrue(answer, "Should be empty. This ray is parallel to this triangle.");
    }
    
    [Test]
    public void IntersectionNoRay()
    {
        var triangleOne = Point.FromXYZ(0, 0, 0);
        var triangleTwo = Point.FromXYZ(10, 10, 0);
        var triangleThree = Point.FromXYZ(0, 10, 0);
            
        var rayOne = Point.FromXYZ(1, 1, 12);
        var r = Ray.FromPointAndXYZ(rayOne, 0,0, 0);
        
        var t = new Triangle(triangleOne, triangleTwo, triangleThree);
        var answer = isPointEquals(Cross.rayTriangleIntersection(r, t), Point.noCoords());
        Assert.IsTrue(answer, "Should be empty. This ray is point");
    }
    
    [Test]
    public void IntersectionNoTriangle()
    {
        var triangleOne = Point.FromXYZ(0, 0, 0);
        var triangleTwo = Point.FromXYZ(10, 10, 0);
        var triangleThree = Point.FromXYZ(0, 0, 0);
            
        var rayOne = Point.FromXYZ(1, 1, 12);
        var r = Ray.FromPointAndXYZ(rayOne, -1,-1, 5);
        
        var t = new Triangle(triangleOne, triangleTwo, triangleThree);
        var answer = isPointEquals(Cross.rayTriangleIntersection(r, t), Point.noCoords());
        Assert.IsTrue(answer, "Should be empty. This triangle is line segment");
    }
}
