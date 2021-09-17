using System;

namespace AVLTree
{
    class Program
    {
        static void Main(string[] args)
        {
            AVL<Point> tree = new AVL<Point>();
            var ramdomPoints = GetRandomPointsArray(0, 100, 20);

            // Will get into the tree by the X cordinate
            // (Point is an IComparable and it compared to other points by its X)
            for (int i = 0; i < ramdomPoints.Length; i++)
                tree.Add(ramdomPoints[i]); 

            tree.DisplayTree();
        }

        private static Point[] GetRandomPointsArray(double minimum, double maximum, int amountOfPoints)
        {
            Random random = new Random();
            Point[] randomPoints = new Point[amountOfPoints];

            for (int i = 0; i < amountOfPoints; i++)
            {
                var x = random.NextDouble() * (maximum - minimum) + minimum;
                var y = random.NextDouble() * (maximum - minimum) + minimum;
                randomPoints[i] = new Point(x, y);
            }

            return randomPoints;
        }
    }
}