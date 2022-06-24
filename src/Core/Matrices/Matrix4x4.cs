using Core.Geometry;

namespace Core.Matrices;

public class Matrix4x4
{
    public float M11, M12, M13, M14;
    public float M21, M22, M23, M24;
    public float M31, M32, M33, M34;
    public float M41, M42, M43, M44;
    
    private Matrix4x4(
        float m11, float m12, float m13, float m14,
        float m21, float m22, float m23, float m24,
        float m31, float m32, float m33, float m34,
        float m41, float m42, float m43, float m44
    )
    {
        M11 = m11; M12 = m12; M13 = m13; M14 = m14;
        M21 = m21; M22 = m22; M23 = m23; M24 = m24;
        M31 = m31; M32 = m32; M33 = m33; M34 = m34;
        M41 = m41; M42 = m42; M43 = m43; M44 = m44;
    }

    public static Matrix4x4 CreateNew(
        float m11, float m12, float m13, float m14,
        float m21, float m22, float m23, float m24,
        float m31, float m32, float m33, float m34,
        float m41, float m42, float m43, float m44)
    {
        return new Matrix4x4(
            m11, m12, m13, m14,
            m21, m22, m23, m24,
            m31, m32, m33, m34,
            m41, m42, m43, m44);
    }
    
    // https://assignmentpoint.com/matrix-transformation/
    public static Matrix4x4 CreateTranslation(float tx, float ty, float tz)
    {
        return new Matrix4x4(
            1, 0, 0, tx,
            0, 1, 0, ty,
            0, 0, 1, tz,
            0, 0, 0, 1);
    }
    
    public static Matrix4x4 CreateScale(float sx, float sy, float sz)
    {
        return new Matrix4x4(
            sx, 0, 0, 0,
            0, sy, 0, 0,
            0, 0, sz, 0,
            0, 0, 0, 1);
    }
    
    public static Matrix4x4 CreateXRotation(float angle)
    {
        var cos = Convert.ToSingle(MathF.Cos(angle));
        var sin = Convert.ToSingle(Math.Sin(angle));
        
        return new Matrix4x4(
            1, 0,   0,    0,
            0, cos, -sin, 0,
            0, sin, cos,  0,
            0, 0,   0,    1);
    }
    
    public static Matrix4x4 CreateYRotation(float angle)
    {
        var cos = MathF.Cos(angle);
        var sin = MathF.Sin(angle);
        
        return new Matrix4x4(
            cos,  0, sin, 0,
            0,    1, 0,   0,
            -sin, 0, cos, 0,
            0,    0, 0,   1);
    }
    
    public static Matrix4x4 CreateZRotation(float angle)
    {
        var cos = Convert.ToSingle(Math.Cos(angle));
        var sin = Convert.ToSingle(Math.Sin(angle));
        
        return new Matrix4x4(
            cos, -sin, 0, 0,
            sin, cos,  0, 0,
            0,   0,    1, 0,
            0,   0,    0, 1);
    }
    
    public static Matrix4x4 operator *(Matrix4x4 one, Matrix4x4 two) =>
        Matrix4x4.CreateNew(
            one.M11 * two.M11 + one.M12 * two.M21 + one.M13 * two.M31 + one.M14 * two.M41,
            one.M11 * two.M12 + one.M12 * two.M22 + one.M13 * two.M32 + one.M14 * two.M42,
            one.M11 * two.M13 + one.M12 * two.M23 + one.M13 * two.M33 + one.M14 * two.M43,
            one.M11 * two.M14 + one.M12 * two.M24 + one.M13 * two.M34 + one.M14 * two.M44,

            one.M21 * two.M11 + one.M22 * two.M21 + one.M23 * two.M31 + one.M24 * two.M41,
            one.M21 * two.M12 + one.M22 * two.M22 + one.M23 * two.M32 + one.M24 * two.M42,
            one.M21 * two.M13 + one.M22 * two.M23 + one.M23 * two.M33 + one.M24 * two.M43,
            one.M21 * two.M14 + one.M22 * two.M24 + one.M23 * two.M34 + one.M24 * two.M44,

            one.M31 * two.M11 + one.M32 * two.M21 + one.M33 * two.M31 + one.M34 * two.M41,
            one.M31 * two.M12 + one.M32 * two.M22 + one.M33 * two.M32 + one.M34 * two.M42,
            one.M31 * two.M13 + one.M32 * two.M23 + one.M33 * two.M33 + one.M34 * two.M43,
            one.M31 * two.M14 + one.M32 * two.M24 + one.M33 * two.M34 + one.M34 * two.M44,

            one.M41 * two.M11 + one.M42 * two.M21 + one.M43 * two.M31 + one.M44 * two.M41,
            one.M41 * two.M12 + one.M42 * two.M22 + one.M43 * two.M32 + one.M44 * two.M42,
            one.M41 * two.M13 + one.M42 * two.M23 + one.M43 * two.M33 + one.M44 * two.M43,
            one.M41 * two.M14 + one.M42 * two.M24 + one.M43 * two.M34 + one.M44 * two.M44
        );

    
    // public static Vector operator *(Matrix4x4 one, Vector two) =>
    //     Vector.FromXYZ(
    //         one.M11 * two.X + one.M12 * two.Y + one.M13 * two.Z,
    //         one.M21 * two.X + one.M22 * two.Y + one.M23 * two.Z,
    //         one.M31 * two.X + one.M32 * two.Y + one.M33 * two.Z
    //     );
    //
    // public static Point operator *(Matrix4x4 one, Point two) =>
    //     Point.FromXYZ(
    //         one.M11 * two.X + one.M12 * two.Y + one.M13 * two.Z + one.M14,
    //         one.M21 * two.X + one.M22 * two.Y + one.M23 * two.Z + one.M24,
    //         one.M31 * two.X + one.M32 * two.Y + one.M33 * two.Z + one.M34
    //     );
}