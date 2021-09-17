using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace AVLTree
{
    public class Point : IComparable<Point>
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        //check only the X field!! - for the specific exercise
        public override bool Equals(object obj)
        {
            return obj is Point point &&
                   X == point.X;
        }

        //check only the X field!! - for the specific exercise
        public int CompareTo([AllowNull] Point other)
        {
            if (other == null) return 1;

            return X.CompareTo(other.X);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}