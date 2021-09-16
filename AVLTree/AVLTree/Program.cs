using System;

namespace AVLTree
{
    class Program
    {
        static void Main(string[] args)
        {
            AVL<int> tree = new AVL<int>();
            tree.Add(5);
            tree.Add(3);
            tree.Add(7);
            tree.Add(2);
        
            tree.DisplayTree();
            Console.WriteLine("Hello World!");
        }
    }
}
