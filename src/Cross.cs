namespace Graphic
{
    public class Cross
    {
        private const double EPSILON = 0.0000001;
        
//        public static bool planeSphereIntersection(Plane p, Sphere s)
//        {
//            https://www.codeproject.com/Articles/19799/Simple-Ray-Tracing-in-C-Part-II-Triangles-Intersec
//        }

        public static Point rayTriangleIntersection(Ray r, Triangle t)
        { 
            // https://en.wikipedia.org/wiki/M%C3%B6ller%E2%80%93Trumbore_intersection_algorithm
            var vertex0 = t.PointOne;
            var vertex1 = t.PointTwo;
            var vertex2 = t.PointThree;
            // Console.WriteLine("Vertex:");
            // Console.WriteLine(vertex0);
            // Console.WriteLine(vertex1);
            // Console.WriteLine(vertex2);
            // Console.WriteLine("-----------------");
            var edge1 = Vector.FromPoints(vertex1, vertex0);
            var edge2 = Vector.FromPoints(vertex2, vertex0);
            // Console.WriteLine("Vectors:");
            // Console.WriteLine(edge1);
            // Console.WriteLine(edge2);
            // Console.WriteLine("-----------------");
            var h = Vector.Cross(r, edge2);
            var a = Vector.Dot(edge1, h);
            // Console.WriteLine($"h:{h}, a:{a}");
            if (a is > -EPSILON and < EPSILON) {
                // Console.WriteLine("This ray is parallel to this triangle.");    // This ray is parallel to this triangle.
                return Point.noCoords();
            } 
            else {
                var f = 1.0 / a;
                // Console.WriteLine($"f:{f}"); 
                var s = Vector.FromPoints(r.StartPoint, vertex0);
                var u = f * Vector.Dot(s, h);
                // Console.WriteLine($"s:{s}, u:{u}");
                if (u is < 0.0 or > 1.0) {
                    Console.WriteLine("No Intersection #1");
                    return Point.noCoords();
                }
                else
                {
                    var q = Vector.Cross(s, edge1);
                    var v = f * Ray.Dot(r, q);
                    // Console.WriteLine($"q:{q}, v:{v}");
                    if (v < 0.0 || u + v > 1.0) {
                        Console.WriteLine("No Intersection #2");
                        return Point.noCoords();
                    }
                    else
                    {
                        var w = f * Vector.Dot(edge2, q);
                        // Console.WriteLine($"w:{w}, dot:{Vector.Dot(edge2, q)}");
                        if (Math.Abs(w) > EPSILON) // ray intersection
                        {
                            var answer = r.StartPoint + Point.FromXYZ(r.X, r.Y, r.Z) * Math.Abs(w);
                            Console.WriteLine($"Answer is: {answer}");
                            return answer;
                        }
                        else
                        {
                            Console.WriteLine("No Intersection #3");
                            return Point.noCoords();
                        } 
                    }
                }
            }
        }
    }
}