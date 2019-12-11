using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    //stores 3 seperate numbers
    class Vector3
    {
        //declares x
        public float x;
        //declares y
        public float y;
        //declares z
        public float z;

        //sets the values of the vector to default to 0
        public Vector3()
        {
            x = 0;
            y = 0;
            z = 0;
        }

        //sets the values of the vector to the values it takes in
        public Vector3(float newX, float newY, float newZ)
        {
            x = newX;
            y = newY;
            z = newZ;
        }

        //lists the values in the vector
        public override string ToString()
        {
            return "{ " + x + ", " + y + ",  " + z + " }";
        }

        //changes how addition between two vectors works so that it's done correctly
        public static Vector3 operator +(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z);
        }

        //changes how subtraction between two vectors works so that it's done correctly
        public static Vector3 operator -(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z);
        }

        //changes how multiplication between a vector and a number (scaler) works so that it's done correctly
        public static Vector3 operator *(Vector3 vector, float scaler)
        {
            return new Vector3(vector.x * scaler, vector.y * scaler, vector.z * scaler);
        }

        //changes how multiplication between a number (scaler) and a vector works so that it's done correctly
        public static Vector3 operator *(float scaler, Vector3 vector)
        {
            return new Vector3(scaler * vector.x, scaler * vector.y, scaler * vector.z);
        }

        //changes how division between a vector and a number(scaler) works so that it's done correctly
        public static Vector3 operator /(Vector3 vector, float scaler)
        {
            return new Vector3(vector.x / scaler, vector.y / scaler, vector.z / scaler);
        }

        //changes how division between a number (scaler) and a vector works so that it's done correctly
        public static Vector3 operator /(float scaler, Vector3 vector)
        {
            return new Vector3(scaler / vector.x, scaler / vector.y, scaler / vector.z);
        }

        //returns the dot product two vectors
        public float Dot(Vector3 rhs)
        {
            return x * rhs.x + y * rhs.y + z * rhs.z;
        }

        //returns the crossproduct of two vectors
        public Vector3 Cross(Vector3 rhs)
        {
            return new Vector3(y * rhs.z - z * rhs.y, z * rhs.x - x * rhs.z, x * rhs.y - y * rhs.x);
        }

        //returns the square of the magnitude of the vector
        public float MagnitudeSqr()
        {
            return (x * x + y * y + z * z);
        }

        //returns the magnitude of the vector
        public float Magnitude()
        {
            return (float)Math.Sqrt(x * x + y * y + z * z);
        }

        //returns the distance between two vectors
        public float Distance(Vector3 other)
        {
            float diffX = x - other.x;
            float diffY = y - other.y;
            float diffZ = z - other.z;
            return (float)Math.Sqrt(diffX * diffX + diffY * diffY + diffZ * diffZ);
        }

        //returns the distance between two vectors squared
        public float DistanceSqr(Vector3 other)
        {
            float diffX = x - other.x;
            float diffY = y - other.y;
            float diffZ = z - other.z;
            return (diffX * diffX + diffY * diffY);
        }

        //divides each value in the vector by the magnitude
        public void Normalize()
        {
            float m = Magnitude();
            x /= m;
            y /= m;
            z /= m;
        }

        //returns the vector divided by the magnitude
        public Vector3 GetNormalised()
        {
            return (this / Magnitude());
        }

        //returns the vector that is perpendicular to the vector
        public Vector3 Perpendicular()
        {
            return new Vector3(-x, -y, -z);
        }

        //returns the angle between two vectors
        public float Angle(Vector3 other)
        {
            Vector3 a = GetNormalised();
            Vector3 b = other.GetNormalised();
            float d = a.x * b.x + a.y * b.y + a.z * b.z;
            return (float)Math.Acos(d);
        }

        //returns a vector with the minimum values from each inputted vectors
        public static Vector3 Min(Vector3 a, Vector3 b)
        {
            return new Vector3(Math.Min(a.x, b.x), Math.Min(a.y, b.y), Math.Min(a.z, b.z));
        }

        //returns a vector with the maximum values from each inputted vectors
        public static Vector3 Max(Vector3 a, Vector3 b)
        {
            return new Vector3(Math.Max(a.x, b.x), Math.Max(a.y, b.y), Math.Max(a.z, b.z));
        }

        //clamps a vector between two other vectors
        public static Vector3 Clamp(Vector3 t, Vector3 a, Vector3 b)
        {
            return Max(a, Min(b, t));
        }
    }
}
