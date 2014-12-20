using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace GameStructure
{

    [StructLayout(LayoutKind.Sequential)]
    public struct Vector
    {

        public static Vector Zero = new Vector(0, 0, 0);
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        //Constructor
        public Vector(double x, double y, double z)
            : this()
        {
            X = x;
            Y = y;
            Z = z;
        }

        //returns the Length
        public double Length()
        {
            return Math.Sqrt(LengthSquared());
        }

        //Returns the length squared
        //Used for the Length()
        public double LengthSquared()
        {
            return (X * X + Y * Y + Z * Z);
        }

        //Used to compare two vectors returns true if they are equal
        public bool Equals(Vector v)
        {
            return (X == v.X) && (Y == v.Y) && (Z == v.Z);
        }

        //Used for making the = operator
        public override int GetHashCode()
        {
            return (int)X ^ (int)Y ^ (int)Z;
        }

        //Lets us use == to compare two vectors
        public static bool operator ==(Vector v1, Vector v2)
        {
            // If they're the same object or both null, return true.
            if (System.Object.ReferenceEquals(v1, v2))
            {
                return true;
            }

            // If one is null, but not both, return false.
            if (v1 == null || v2 == null)
            {
                return false;
            }

            return v1.Equals(v2);
        }

        //overrids the equals method
        public override bool Equals(object obj)
        {
            if (obj is Vector)
            {
                return Equals((Vector)obj);
            }
            return base.Equals(obj);
        }

        //overides the != method
        public static bool operator !=(Vector v1, Vector v2)
        {
            return !v1.Equals(v2);
        }

        //Addition
        public Vector Add(Vector r)
        {
            return new Vector(X + r.X, Y + r.Y, Z + r.Z);
        }

        //Overides the + symbol
        public static Vector operator +(Vector v1, Vector v2)
        {
            return v1.Add(v2);
        }

        //Subtraction
        public Vector Subtract(Vector r)
        {
            return new Vector(X - r.X, Y - r.Y, Z - r.Z);
        }

        //Overides the - symbol
        public static Vector operator -(Vector v1, Vector v2)
        {
            return v1.Subtract(v2);
        }

        //Scalar multiplication (NOT Cross Product!)
        public Vector Multiply(double v)
        {
            return new Vector(X * v, Y * v, Z * v);
        }

        //Overrides the * opperation
        //Note s must be a double
        public static Vector operator *(Vector v, double s)
        {
            return v.Multiply(s);
        }

        //returns the normal vecor (length = 1)
        public Vector Normalize(Vector v)
        {
            double r = v.Length();
            if (r != 0.0)       // guard against divide by zero
            {
                return new Vector(v.X / r, v.Y / r, v.Z / r); // normalize and return
            }
            else
            {
                return new Vector(0, 0, 0);
            }
        }

        //Computes the dot product
        public double DotProduct(Vector v)
        {
            return (v.X * X) + (Y * v.Y) + (Z * v.Z);
        }

        //* operator for the dot product
        public static double operator *(Vector v1, Vector v2)
        {
            return v1.DotProduct(v2);
        }

        //Computes the Cross Product
        public Vector CrossProduct(Vector v)
        {
            double nx = Y * v.Z - Z * v.Y;
            double ny = Z * v.X - X * v.Z;
            double nz = X * v.Y - Y * v.X;
            return new Vector(nx, ny, nz);
        }

        //ToString method
        public override string ToString()
        {
            return string.Format("X:{0}, Y:{1}, Z:{2}", X, Y, Z);
        }


    }
}

