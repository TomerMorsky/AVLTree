using System;
using System.Collections.Generic;
using System.Text;

namespace AVLTree
{
    public static class NearestRightPoint
    {
        private static double min_diff;
        private static Point closestPoint;

        public static Point GetNearestRightPoint(Node<Point> ptr, double k)
        {
            MaxDiffUtil(ptr, k);
            if (closestPoint.X == k)
                return new Point(0, 0); // Ex2 says if its on the line - return (0,0)

            return closestPoint;
        }

        private static void MaxDiffUtil(Node<Point> ptr, double k)
        {
            if (ptr == null)
            {
                return;
            }

            // If k itself is present 
            if (ptr.data.X == k)
            {
                closestPoint = ptr.data;
                return;
            }

            // update min_diff and min_diff_key by checking 
            // current node value 
            if (min_diff > Math.Abs(ptr.data.X - k))
            {
                min_diff = Math.Abs(ptr.data.X - k);
                closestPoint = ptr.data;
            }

            // if k is less than ptr.key then move in 
            // left subtree else in right subtree 
            if (k < ptr.data.X)
            {
                MaxDiffUtil(ptr.left, k);
            }
            else
            {
                MaxDiffUtil(ptr.right, k);
            }
        }
    }
}