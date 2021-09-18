using System;

namespace AVLTree
{
    class Program
    {
        static void Main(string[] args)
        {
            //EX1
            AvlTree<Point> tree = BuildTree();

            tree.DisplayTree();

            //EX2
            Console.WriteLine("Enter the x0 value: ");
            double inputNumber = double.Parse(Console.ReadLine());

            var point = NearestRightPointManager.NearestRightPoint(tree.Root, inputNumber);

            Console.WriteLine("The nearest right value is " + point.ToString());
            Console.ReadLine();
        }

        public static AvlTree<Point> BuildTree()
        {
            AvlTree<Point> tree = new AvlTree<Point>();

            var ramdomPoints = GetRandomPointsArray(0, 100, 20);

            // Will get into the tree by the X cordinate
            // (Point is an IComparable and it compared to other points by its X)
            for (int i = 0; i < ramdomPoints.Length; i++)
                tree.Add(ramdomPoints[i]);

            return tree;
        }

        private static Point[] GetRandomPointsArray(double minimum, double maximum, int amountOfPoints)
        {
            Random random = new Random();
            Point[] randomPoints = new Point[amountOfPoints];

            for (int i = 0; i < amountOfPoints; i++)
            {
                var x = (int)(random.NextDouble() * (maximum - minimum) + minimum);
                var y = (int)(random.NextDouble() * (maximum - minimum) + minimum);
                randomPoints[i] = new Point(x, y);
            }

            return randomPoints;
        }

    }
}