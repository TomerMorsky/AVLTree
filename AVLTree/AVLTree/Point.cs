using System;
using System.Collections.Generic;
using System.Text;

namespace AVLTree
{
    public class Point : IComparable
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        //Compare just the X field!!
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Point otherPoint = obj as Point;
            if (otherPoint != null)
                return this.X.CompareTo(otherPoint.X);
            else
                throw new ArgumentException("Object is not a Temperature");
        }

        //check only the X field!!
        public override bool Equals(object obj)
        {
            return obj is Point point &&
                   X == point.X;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}