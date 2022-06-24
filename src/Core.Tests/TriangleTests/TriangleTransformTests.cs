using System;
using System.Collections.Generic;
using Core.Geometry;
using Core.Geometry.Shapes;
using Core.Matrices;
using NUnit.Framework;

namespace Core.Tests.TriangleTests;

public class TriangleTransformTests
{
    public static IEnumerable<TestCaseData> Triangle_Transform_TestData
    {
        get
        {
            yield return new TestCaseData(
                Matrix4x4.CreateNew(
                    1, 0, 0, 0,
                    0, 2, 3, 0,
                    0, 0, 4, 0,
                    3, 5, 0, 0),
                Point.FromXYZ(1, 2, 0),
                Point.FromXYZ(10, 10, 0),
                Point.FromXYZ(0, 10, 0),
                Vector.FromXYZ(0, 2, 3),
                Vector.FromXYZ(1, 0, 1),
                Vector.FromXYZ(5, 5, 0),
                Triangle.FromPointsAndNormals(
                    Point.FromXYZ(1,4,0),
                    Point.FromXYZ(10,20,0),
                    Point.FromXYZ(0,20,0),
                    Vector.FromXYZ(0, 0.7348034446274879, 0.6782801027330658),
                    Vector.FromXYZ(0.19611613513818404, 0.5883484054145521, 0.7844645405527362),
                    Vector.FromXYZ(0.4472135954999579, 0.8944271909999159, 0))
                );
            yield return new TestCaseData(
                Matrix4x4.CreateNew(
                    1, 0, 0, 6,
                    3, 0, 5, 0,
                    4, 5, 0, 0,
                    0, 1, 0, 2),
                Point.FromXYZ(4, 0, 0),
                Point.FromXYZ(10, 10, 0),
                Point.FromXYZ(10, 10, 0),
                Vector.FromXYZ(0, 3, 3),
                Vector.FromXYZ(5, 0, 4),
                Vector.FromXYZ(5, 5, 0),
                Triangle.FromPointsAndNormals(
                    Point.FromXYZ(10,12,16),
                    Point.FromXYZ(16,30,90),
                    Point.FromXYZ(16,30,90),
                    Vector.FromXYZ(0, 0.7071067811865475, 0.7071067811865475),
                    Vector.FromXYZ(0.12309149097933272, 0.8616404368553291, 0.4923659639173309),
                    Vector.FromXYZ(0.10482848367219183, 0.3144854510165755, 0.9434563530497264))
                );
            yield return new TestCaseData(
                Matrix4x4.CreateNew(
                    0, 0, 0, 4,
                    0, 0, 6, 0,
                    7, 0, 6, 0,
                    1, 2, 0, 3),
                Point.FromXYZ(1, 0, 4), 
                Point.FromXYZ(1, 1, 0), 
                Point.FromXYZ(0, 10, 4),
                Vector.FromXYZ(0, 1, 3),
                Vector.FromXYZ(3, 3, 0),
                Vector.FromXYZ(2, 2, 2),
                Triangle.FromPointsAndNormals(
                    Point.FromXYZ(4, 24, 31),
                    Point.FromXYZ(4, 0, 7),
                    Point.FromXYZ(4, 24, 24),
                    Vector.FromXYZ(0, 0.7071067811865476, 0.7071067811865476),
                    Vector.FromXYZ(0, 0, 1),
                    Vector.FromXYZ(0, 0.4190581774617469, 0.9079593845004517))
                );
            yield return new TestCaseData(
                Matrix4x4.CreateNew(
                    1, 2, 3, 4,
                    8, 7, 6, 5,
                    8, 7, 6, 5,
                    1, 2, 3, 4),
                Point.FromXYZ(1, 2, 3), 
                Point.FromXYZ(1, 1, 0), 
                Point.FromXYZ(3, 3, 3),
                Vector.FromXYZ(2, 0, 1),
                Vector.FromXYZ(1, 2, 1),
                Vector.FromXYZ(3, 0, 0),
                Triangle.FromPointsAndNormals(
                    Point.FromXYZ(18, 45, 45),
                    Point.FromXYZ(7, 20, 20),
                    Point.FromXYZ(22, 68, 68),
                    Vector.FromXYZ(0.1586702039938442, 0.6981488975729145, 0.6981488975729145),
                    Vector.FromXYZ(0.19802950859533489, 0.6931032800836721, 0.6931032800836721),
                    Vector.FromXYZ(0.08804509063256238, 0.7043607250604991, 0.7043607250604991))
                );
            yield return new TestCaseData(
                Matrix4x4.CreateNew(
                    0, 0, 8, 9,
                    5, 6, 7, 0,
                    4, 3, 2, 0,
                    0, 0, 0, 1),
                Point.FromXYZ(1, 0, 2), 
                Point.FromXYZ(1, 1, 0), 
                Point.FromXYZ(0, 10, 2),
                Vector.FromXYZ(3, 3, 0),
                Vector.FromXYZ(4, 0, 4),
                Vector.FromXYZ(5, 5, 5),
                Triangle.FromPointsAndNormals(
                    Point.FromXYZ(25,19,8),
                    Point.FromXYZ(9,11,7),
                    Point.FromXYZ(25,74,34),
                    Vector.FromXYZ(0, 0.8436614877321076, 0.536875492193159),
                    Vector.FromXYZ(0.5121475197315839, 0.7682212795973759, 0.3841106397986879),
                    Vector.FromXYZ(0.3694056772316881, 0.8311627737712982, 0.4155813868856491))
                    
            );
        }
    }
    
    [Test]
    [TestCaseSource(nameof(Triangle_Transform_TestData))]
    public void Triangle_Transformation_ReturnsCorrectTriangle(Matrix4x4 m , Point one, Point two, Point three,Vector normal1,Vector normal2,Vector normal3, Triangle result)
    {
        var triangle = Triangle.FromPointsAndNormals(one, two, three, normal1, normal2, normal3);
        
        triangle.Transform(m);
        Console.WriteLine(triangle);
        Assert.IsTrue(triangle.IsEqualTo(result));
    }
}