using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    //stores numbers in a 4 by 4 matrix
    class Matrix4
    {
        //declares each spot in the matrix
        public float m11, m12, m13, m14, m21, m22, m23, m24, m31, m32, m33, m34, m41, m42, m43, m44;

        //sets the identity matrix to default
        public Matrix4()
        {
            m11 = 1; m12 = 0; m13 = 0; m14 = 0;
            m21 = 0; m22 = 1; m23 = 0; m24 = 0;
            m31 = 0; m32 = 0; m33 = 1; m34 = 0;
            m41 = 0; m42 = 0; m43 = 0; m44 = 1;
        }

        //sets matrix to inputted values
        public Matrix4(float m11, float m12, float m13, float m14, float m21, float m22, float m23, float m24, float m31, float m32, float m33, float m34, float m41, float m42, float m43, float m44)
        {
            this.m11 = m11; this.m12 = m12; this.m13 = m13; this.m14 = m14;
            this.m21 = m21; this.m22 = m22; this.m23 = m23; this.m24 = m24;
            this.m31 = m31; this.m32 = m32; this.m33 = m33; this.m34 = m34;
            this.m41 = m41; this.m42 = m42; this.m43 = m43; this.m44 = m44;
        }

        //returns a new matrix with values of the original
        public Matrix4 GetTransposed()
        {
            return new Matrix4(m11, m12, m13, m14, m21, m22, m23, m24, m31, m32, m33, m34, m41, m42, m43, m44);
        }

        //sets the values in the matrix to that of an inputted matrix
        public Matrix4(Matrix4 matrix_4)
        {
            matrix_4.m11 = m11; matrix_4.m12 = m12; matrix_4.m13 = m13; matrix_4.m14 = m14;
            matrix_4.m21 = m21; matrix_4.m22 = m22; matrix_4.m23 = m23; matrix_4.m24 = m24;
            matrix_4.m31 = m31; matrix_4.m32 = m32; matrix_4.m33 = m33; matrix_4.m34 = m34;
            matrix_4.m41 = m41; matrix_4.m42 = m42; matrix_4.m43 = m43; matrix_4.m44 = m44;
        }

        //lists the values in the matrix
        public override string ToString()
        {
            return "{ " + m11 + ", " + m12 + ", " + m13 + ", " + m14 + ", " + m21 + ", " + m22 + ", " + m23 + ", " + m24 + ", " + m31 + ", " + m32 + ", " + m33 + ", " + m34 + ", " + m41 + ", " + m42 + ", " + m43 + ", " + m44 + " }";
        }

        //makes it so multiplying matrices together works correctly
        public static Matrix4 operator *(Matrix4 lhs, Matrix4 rhs)
        {
            return new Matrix4(
                lhs.m11 * rhs.m11 + lhs.m12 * rhs.m21 + lhs.m13 * rhs.m31 + lhs.m14 * rhs.m41,
                lhs.m11 * rhs.m12 + lhs.m12 * rhs.m22 + lhs.m13 * rhs.m32 + lhs.m14 * rhs.m42,
                lhs.m11 * rhs.m13 + lhs.m12 * rhs.m23 + lhs.m13 * rhs.m33 + lhs.m14 * rhs.m43,
                lhs.m11 * rhs.m14 + lhs.m12 * rhs.m24 + lhs.m13 * rhs.m34 + lhs.m14 * rhs.m44,

                lhs.m21 * rhs.m11 + lhs.m22 * rhs.m21 + lhs.m23 * rhs.m31 + lhs.m24 * rhs.m41,
                lhs.m21 * rhs.m12 + lhs.m22 * rhs.m22 + lhs.m23 * rhs.m32 + lhs.m24 * rhs.m42,
                lhs.m21 * rhs.m13 + lhs.m22 * rhs.m23 + lhs.m23 * rhs.m33 + lhs.m24 * rhs.m43,
                lhs.m21 * rhs.m14 + lhs.m22 * rhs.m24 + lhs.m23 * rhs.m34 + lhs.m24 * rhs.m44,

                lhs.m31 * rhs.m11 + lhs.m32 * rhs.m21 + lhs.m33 * rhs.m31 + lhs.m34 * rhs.m41,
                lhs.m31 * rhs.m12 + lhs.m32 * rhs.m22 + lhs.m33 * rhs.m32 + lhs.m34 * rhs.m42,
                lhs.m31 * rhs.m13 + lhs.m32 * rhs.m23 + lhs.m33 * rhs.m33 + lhs.m34 * rhs.m43,
                lhs.m31 * rhs.m14 + lhs.m32 * rhs.m24 + lhs.m33 * rhs.m34 + lhs.m34 * rhs.m44,

                lhs.m41 * rhs.m11 + lhs.m42 * rhs.m21 + lhs.m43 * rhs.m31 + lhs.m44 * rhs.m41,
                lhs.m41 * rhs.m12 + lhs.m42 * rhs.m22 + lhs.m43 * rhs.m32 + lhs.m44 * rhs.m42,
                lhs.m41 * rhs.m13 + lhs.m42 * rhs.m23 + lhs.m43 * rhs.m33 + lhs.m44 * rhs.m43,
                lhs.m41 * rhs.m14 + lhs.m42 * rhs.m24 + lhs.m43 * rhs.m34 + lhs.m44 * rhs.m44);
        }

        //makes it so multiplying matrices by vectors works correctly
        public static Vector4 operator *(Matrix4 lhs, Vector4 rhs)
        {
            return new Vector4(
                lhs.m11 * rhs.x + lhs.m12 * rhs.y + lhs.m13 * rhs.z + lhs.m14 * rhs.w,
                lhs.m21 * rhs.x + lhs.m22 * rhs.y + lhs.m23 * rhs.z + lhs.m24 * rhs.w,
                lhs.m31 * rhs.x + lhs.m32 * rhs.y + lhs.m33 * rhs.z + lhs.m34 * rhs.w,
                lhs.m41 * rhs.x + lhs.m42 * rhs.y + lhs.m43 * rhs.z + lhs.m44 * rhs.w);

        }

        //sets m11, m22, and m33 to inputted values in order to change the scale
        public void SetScaled(float x, float y, float z)
        {
            m11 = x; m12 = 0; m13 = 0; m14 = 0;
            m21 = 0; m22 = y; m23 = 0; m24 = 0;
            m31 = 0; m32 = 0; m33 = z; m34 = 0;
            m41 = 0; m42 = 0; m43 = 0; m44 = 1;
        }

        //sets m11, m22, and m33 using the inputted vector in order to change the scale
        public void SetScaled(Vector4 v)
        {
            m11 = v.x; m12 = 0; m13 = 0; m14 = 0;
            m21 = 0; m22 = v.y; m23 = 0; m24 = 0;
            m31 = 0; m32 = 0; m33 = v.z; m34 = 0;
            m41 = 0; m42 = 0; m43 = 0; m44 = 1;
        }

        //sets the values in the matrix to that of an inputted matrix
        public Matrix4 Set(Matrix4 m)
        {
            //i have no idea what goes here. it needs to set m to the input matrix? i think?
            return m = new Matrix4();
        }

        //sets matrix to inputted values
        public Matrix4 Set(float m11, float m12, float m13, float m14, float m21, float m22, float m23, float m24, float m31, float m32, float m33, float m34, float m41, float m42, float m43, float m44)
        {
            //i have no idea what goes here. it needs to set m to the input matrix? i think?
            return new Matrix4(m11, m12, m13, m14, m21, m22, m23, m24, m31, m32, m33, m34, m41, m42, m43, m44);
        }

        //sets the scale of the matrix using 3 inputted values
        void Scale(float x, float y, float z)
        {
            Matrix4 m = new Matrix4(); m.SetScaled(x, y, z);

            Set(this * m);
        }

        //sets the scale of the matrix using a inputted vector
        void Scale(Vector4 v)
        {
            Matrix4 m = new Matrix4();
            m.SetScaled(v.x, v.y, v.z);
            Set(this * m);
        }

        //sets rotation on the x axis
        public void SetRotateX(double radians)
        {
            Set(m11, m12, m13, m14,
                m21, (float)Math.Cos(radians), (float)-Math.Sin(radians), m24,
                m31, (float)Math.Sin(radians), (float)Math.Cos(radians), m34,
                m41, m42, m43, m44);
        }

        //sets rotation on the y axis
        public void SetRotateY(double radians)
        {
            Set((float)Math.Cos(radians), m12, (float)Math.Sin(radians), m14,
                m21, m22, m23, m24,
                (float)-Math.Sin(radians), m32, (float)Math.Cos(radians), m34,
                m41, m42, m43, m44);
        }

        //sets rotation on the z axis
        public void SetRotateZ(double radians)
        {
            Set((float)Math.Cos(radians), (float)-Math.Sin(radians), m13, m14,
                (float)Math.Sin(radians), (float)Math.Cos(radians), m23, m24,
                m31, m32, m33, m34,
                m41, m42, m43, m44);
        }

        //rotates on the x axis
        public void RotateX(double radians)
        {
            Matrix4 m = new Matrix4();
            m.SetRotateX(radians);

            Set(this * m);
        }

        //rotates on the y axis
        public void RotateY(double radians)
        {
            Matrix4 m = new Matrix4();
            m.SetRotateY(radians);

            Set(this * m);
        }

        //rotates on the z axis
        public void RotateZ(double radians)
        {
            Matrix4 m = new Matrix4();
            m.SetRotateZ(radians);

            Set(this * m);
        }

        //sets the euler of the matrix usig pitch, yaw, and roll
        void SetEuler(float pitch, float yaw, float roll)
        {

            Matrix4 x = new Matrix4();
            Matrix4 y = new Matrix4(); Matrix4 z = new Matrix4();
            x.SetRotateX(pitch);
            y.SetRotateY(yaw);
            z.SetRotateZ(roll);

            // combine rotations in a specific order     
            Set(z * y * x);
        }

        //sets the translation of the matrix to the inputted value
        public void SetTranslation(float x, float y, float z)
        {
            m14 = x; m24 = y; m34 = z; m44 = 1;
        }

        //translates the matrix by the inputted values
        public void Translate(float x, float y, float z)
        {
            //apply vector offset
            m14 += x; m24 += y; m34 += z;
        }
    }
}
