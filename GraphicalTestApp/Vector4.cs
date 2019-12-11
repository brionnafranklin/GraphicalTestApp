using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    //stores 4 seperate numbers
    class Vector4
    {
        //declares x
        public float x;
        //declares y
        public float y;
        //declares z
        public float z;
        //declares w
        public float w;

        //sets the values of the vector to default to 0
        public Vector4()
        {
            x = 0;
            y = 0;
            z = 0;
            w = 0;
        }

        //sets the values of the vector to the values it takes in
        public Vector4(float newX, float newY, float newZ, float newW)
        {
            x = newX;
            y = newY;
            z = newZ;
            w = newW;
        }

        //lists the values in the vector
        public override string ToString()
        {
            return "{ " + x + ", " + y + ",  " + z + y + ",  " + " }";
        }

        //changes how addition between two vectors works so that it's done correctly
        public static Vector4 operator +(Vector4 lhs, Vector4 rhs)
        {
            return new Vector4(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z, lhs.w + rhs.w);
        }

        //changes how subtraction between two vectors works so that it's done correctly
        public static Vector4 operator -(Vector4 lhs, Vector4 rhs)
        {
            return new Vector4(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z, lhs.w - rhs.w);
        }

        //changes how multiplication between a vector and a number (scaler) works so that it's done correctly
        public static Vector4 operator *(Vector4 vector, float scaler)
        {
            return new Vector4(vector.x * scaler, vector.y * scaler, vector.z * scaler, vector.w * scaler);
        }

        //changes how multiplication between a number (scaler) and a vector works so that it's done correctly
        public static Vector4 operator *(float scaler, Vector4 vector)
        {
            return new Vector4(scaler * vector.x, scaler * vector.y, scaler * vector.z, scaler * vector.w);
        }

        //changes how division between a vector and a number(scaler) works so that it's done correctly
        public static Vector4 operator /(Vector4 vector, float scaler)
        {
            return new Vector4(vector.x / scaler, vector.y / scaler, vector.z / scaler, vector.w / scaler);
        }

        //changes how division between a number (scaler) and a vector works so that it's done correctly
        public static Vector4 operator /(float scaler, Vector4 vector)
        {
            return new Vector4(scaler / vector.x, scaler / vector.y, scaler / vector.z, scaler / vector.w);
        }

        //returns the square of the magnitude of the vector
        public float MagnitudeSqr()
        {
            return (x * x + y * y + z * z + w * w);
        }

        //returns the magnitude of the vector
        public float Magnitude()
        {
            return (float)Math.Sqrt(x * x + y * y + z * z + w * w);
        }

        //returns the distance between two vectors
        public float Distance(Vector4 other)
        {
            float diffX = x - other.x;
            float diffY = y - other.y;
            float diffZ = z - other.z;
            float diffW = w - other.w;
            return (float)Math.Sqrt(diffX * diffX + diffY * diffY + diffZ * diffZ + diffW * diffW);
        }

        //returns the distance between two vectors squared
        public float DistanceSqr(Vector4 other)
        {
            float diffX = x - other.x;
            float diffY = y - other.y;
            float diffZ = z - other.z;
            float diffW = w - other.w;
            return (diffX * diffX + diffY * diffY);
        }

        //divides each value in the vector by the magnitude
        public void Normalize()
        {
            float m = Magnitude();
            x /= m;
            y /= m;
            z /= m;
            w /= m;
        }

        //returns the vector divided by the magnitude
        public Vector4 GetNormalised()
        {
            return (this / Magnitude());
        }

        //returns the dot product two vectors
        public float Dot(Vector4 rhs)
        {
            return x * rhs.x + y * rhs.y + z * rhs.z + w * rhs.w;
        }

        //returns the crossproduct of two vectors
        public Vector4 Cross(Vector4 rhs)
        {
            return new Vector4(y * rhs.z - z * rhs.y, z * rhs.x - x * rhs.z, x * rhs.y - y * rhs.x, 0);
        }
    }
}
