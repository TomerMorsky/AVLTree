using System;

namespace AVLTree
{
    class Program
    {
        static void Main(string[] args)
        {
            AVL<Point> tree = new AVL<Point>();

            tree.Add(new Point(5,0));
            tree.Add(new Point(3, 0));
            tree.Add(new Point(7, 0));
            tree.Add(new Point(2, 0));
        
            tree.DisplayTree();
            Console.WriteLine("Hello World!");
        }
    }
}
