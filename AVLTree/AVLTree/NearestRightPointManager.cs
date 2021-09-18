using System;
using System.Collections.Generic;
using System.Text;

namespace AVLTree
{
    public static class NearestRightPointManager
    {
        private static double minDifference;
        private static Point rightClosestPoint;

        public static Point NearestRightPoint(Node<Point> ptr, double x0)
        {
            minDifference = double.MaxValue;

            rightClosestPoint = new Point(0, 0);

            CalculateNearestRightPoint(ptr, x0);

            return rightClosestPoint;
        }

        private static void CalculateNearestRightPoint(Node<Point> ptr, double x0)
        {
            if (ptr == null)
                return;

            if (ptr.data.X < x0)
                CalculateNearestRightPoint(ptr.right, x0);

            if (ptr.data.X == x0)
                return;

            if ((ptr.data.X - x0) > 0 && minDifference > (ptr.data.X - x0))
            {
                minDifference = Math.Abs(ptr.data.X - x0);
                rightClosestPoint = ptr.data;
            }

            if (x0 < ptr.data.X)
            {
                CalculateNearestRightPoint(ptr.left, x0);
            }
            else
            {
                CalculateNearestRightPoint(ptr.right, x0);
            }
        }
    }
}