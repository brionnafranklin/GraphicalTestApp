using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    //stores numbers in a 3 by 3 matrix
    class Matrix3
    {
        //declares each spot in the matrix
        public float m11, m12, m13, m21, m22, m23, m31, m32, m33;

        //sets the identity matrix to default
        public Matrix3()
        {
            m11 = 1; m12 = 0; m13 = 0;
            m21 = 0; m22 = 1; m23 = 0;
            m31 = 0; m32 = 0; m33 = 1;
        }

        //sets matrix to inputted values
        public Matrix3(float m11, float m12, float m13, float m21, float m22, float m23, float m31, float m32, float m33)
        {
            this.m11 = m11; this.m12 = m12; this.m13 = m13;
            this.m21 = m21; this.m22 = m22; this.m23 = m23;
            this.m31 = m31; this.m32 = m32; this.m33 = m33;
        }

        //sets m11, m22, and m33 to inputted values in order to change the scale
        public void SetScaled(float x, float y, float z)
        {
            m11 = x; m12 = 0; m13 = 0;
            m21 = 0; m22 = y; m23 = 0;
            m31 = 0; m32 = 0; m33 = z;
        }

        //sets m11, m22, and m33 using the inputted vector in order to change the scale
        public void SetScaled(Vector3 v)
        {
            m11 = v.x; m12 = 0; m13 = 0;
            m21 = 0; m22 = v.y; m23 = 0;
            m31 = 0; m32 = 0; m33 = v.z;
        }

        //returns a new matrix with values of the original
        public Matrix3 GetTransposed()
        {
            return new Matrix3(m11, m12, m13, m21, m22, m23, m31, m32, m33);
        }

        //sets the values in the matrix to that of an inputted matrix
        public Matrix3(Matrix3 matrix_3)
        {
            matrix_3.m11 = m11; matrix_3.m12 = m12; matrix_3.m13 = m13;
            matrix_3.m21 = m21; matrix_3.m22 = m22; matrix_3.m23 = m23;
            matrix_3.m31 = m31; matrix_3.m32 = m32; matrix_3.m33 = m33;
        }

        //lists the values in the matrix
        public override string ToString()
        {
            return "{ " + m11 + ", " + m12 + ", " + m13 + ", " + m21 + ", " + m22 + ", " + m23 + ", " + m31 + ", " + m32 + ", " + m33 + " }";
        }

        //makes it so multiplying matrices together works correctly
        public static Matrix3 operator *(Matrix3 lhs, Matrix3 rhs)
        {
            return new Matrix3(
                lhs.m11 * rhs.m11 + lhs.m12 * rhs.m21 + lhs.m13 * rhs.m31,
                lhs.m11 * rhs.m12 + lhs.m12 * rhs.m22 + lhs.m13 * rhs.m32,
                lhs.m11 * rhs.m13 + lhs.m12 * rhs.m23 + lhs.m13 * rhs.m33,

                lhs.m21 * rhs.m11 + lhs.m22 * rhs.m21 + lhs.m23 * rhs.m31,
                lhs.m21 * rhs.m12 + lhs.m22 * rhs.m22 + lhs.m23 * rhs.m32,
                lhs.m21 * rhs.m13 + lhs.m22 * rhs.m23 + lhs.m23 * rhs.m33,

                lhs.m31 * rhs.m11 + lhs.m32 * rhs.m21 + lhs.m33 * rhs.m31,
                lhs.m31 * rhs.m12 + lhs.m32 * rhs.m22 + lhs.m33 * rhs.m32,
                lhs.m31 * rhs.m13 + lhs.m32 * rhs.m23 + lhs.m33 * rhs.m33);
        }

        //makes it so multiplying matrices by vectors works correctly
        public static Vector3 operator *(Matrix3 lhs, Vector3 rhs)
        {
            return new Vector3(
                lhs.m11 * rhs.x + lhs.m12 * rhs.y + lhs.m13 * rhs.z,
                lhs.m21 * rhs.x + lhs.m22 * rhs.y + lhs.m23 * rhs.z,
                lhs.m31 * rhs.x + lhs.m32 * rhs.y + lhs.m33 * rhs.z);
        }

        //sets the values in the matrix to that of an inputted matrix
        public void Set(Matrix3 matrix_3)
        {
            m11 = matrix_3.m11; m12 = matrix_3.m12; m13 = matrix_3.m13;
            m21 = matrix_3.m21; m22 = matrix_3.m22; m23 = matrix_3.m23;
            m31 = matrix_3.m31; m32 = matrix_3.m32; m33 = matrix_3.m33;
        }

        //sets matrix to inputted values
        public void Set(float m11, float m12, float m13, float m21, float m22, float m23, float m31, float m32, float m33)
        {
            this.m11 = m11; this.m12 = m12; this.m13 = m13;
            this.m21 = m21; this.m22 = m22; this.m23 = m23;
            this.m31 = m31; this.m32 = m32; this.m33 = m33;
        }
        
        //sets the scale of the matrix using 3 inputted values
        public void Scale(float x, float y, float z)
        {
            Matrix3 m = new Matrix3();
            m.SetScaled(x, y, z);
            Set(this * m);
        }

        //sets the scale of the matrix using a inputted vector
        public void Scale(Vector3 v)
        {
            Matrix3 m = new Matrix3();
            m.SetScaled(v.x, v.y, v.z);
            Set(this * m);
        }

        //sets rotation on the x axis
        public void SetRotateX(double radians)
        {
            Set(m11, m12, m13,
                m21, (float)Math.Cos(radians), (float)-Math.Sin(radians),
                m31, (float)Math.Sin(radians), (float)Math.Cos(radians));
        }

        //sets rotation on the y axis
        public void SetRotateY(double radians)
        {
            Set((float)Math.Cos(radians), m12, (float)Math.Sin(radians),
                m21, m22, m23,
                (float)-Math.Sin(radians), m32, (float)Math.Cos(radians));
        }

        //sets rotation on the z axis
        public void SetRotateZ(double radians)
        {
            Set((float)Math.Cos(radians), (float)-Math.Sin(radians), m13,
                (float)Math.Sin(radians), (float)Math.Cos(radians), m23,
                m31, m32, m33);
        }

        //rotates on the x axis
        public void RotateX(double radians)
        {
            Matrix3 m = new Matrix3();
            m.SetRotateX(radians);

            Set(this * m);
        }

        //rotates on the y axis
        public void RotateY(double radians)
        {
            Matrix3 m = new Matrix3();
            m.SetRotateY(radians);

            Set(this * m);
        }

        //rotates on the z axis
        public void RotateZ(double radians)
        {
            Matrix3 m = new Matrix3();
            m.SetRotateZ(radians);

            Set(this * m);
        }

        //sets the euler of the matrix usig pitch, yaw, and roll
        public void SetEuler(float pitch, float yaw, float roll)
        {

            Matrix3 x = new Matrix3();
            Matrix3 y = new Matrix3();
            Matrix3 z = new Matrix3();
            x.SetRotateX(pitch);
            y.SetRotateY(yaw);
            z.SetRotateZ(roll);

            // combine rotations in a specific order     
            Set(z * y * x);
        }

        //sets the translation of the matrix to the inputted value
        public void SetTranslation(float x, float y, float z)
        {
            m13 = x; m23 = y; m33 = z;
        }

        //translates the matrix by the inputted values
        public void Translate(float x, float y, float z)
        {
            //apply vector offset
            m13 += x; m23 += y; m33 += z;
        }
    }
}
