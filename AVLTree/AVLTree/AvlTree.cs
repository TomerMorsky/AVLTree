using System;
using System.Collections.Generic;
using System.Text;

namespace AVLTree
{
    public class AvlTree<T> where T : IComparable<T>
    {
        #region Fields

        public Node<T> Root { get; set; }

        #endregion

        #region C'tor

        public AvlTree(){}

        #endregion

        #region Public methods

        public void Add(T data)
        {
            Node<T> newItem = new Node<T>(data);
            if (Root == null)
                Root = newItem;
            else
                Root = RecursiveInsert(Root, newItem);
        }

        public void DisplayTree()
        {
            if (Root == null)
            {
                Console.WriteLine("Tree is empty");
                return;
            }
            InOrderDisplayTree(Root);
            Console.WriteLine();
        }

        #endregion

        #region Private methods

        private Node<T> RecursiveInsert(Node<T> current, Node<T> nodeToInsert)
        {
            if (current == null)
            {
                current = nodeToInsert;
                return current;
            }
            else if (nodeToInsert.data.CompareTo(current.data) < 0)
            {
                current.left = RecursiveInsert(current.left, nodeToInsert);
                current = BalanceTree(current);
            }
            else if (nodeToInsert.data.CompareTo(current.data) > 0)
            {
                current.right = RecursiveInsert(current.right, nodeToInsert);
                current = BalanceTree(current);
            }
            return current;
        }
        private Node<T> BalanceTree(Node<T> current)
        {
            int balanceFactor = GetBalanceFactor(current);
            if (balanceFactor > 1)
            {
                if (GetBalanceFactor(current.left) > 0)
                {
                    current = RotateLL(current);
                }
                else
                {
                    current = RotateLR(current);
                }
            }
            else if (balanceFactor < -1)
            {
                if (GetBalanceFactor(current.right) > 0)
                {
                    current = RotateRL(current);
                }
                else
                {
                    current = RotateRR(current);
                }
            }
            return current;
        }
        
        private void InOrderDisplayTree(Node<T> current)
        {
            if (current != null)
            {
                InOrderDisplayTree(current.left);
                Console.Write("({0}) ", current.data);
                InOrderDisplayTree(current.right);
            }
        }
        private int GetHeight(Node<T> current)
        {
            int height = 0;
            if (current != null)
            {
                int leftHeight = GetHeight(current.left);
                int rightHeight = GetHeight(current.right);
                int maxHeight = Math.Max(leftHeight, rightHeight);

                height = maxHeight + 1;
            }
            return height;
        }
        private int GetBalanceFactor(Node<T> current)
        {
            int leftHeight = GetHeight(current.left);
            int rightHeight = GetHeight(current.right);
            int balanceFactor = leftHeight - rightHeight;
            return balanceFactor;
        }
        private Node<T> RotateRR(Node<T> parent)
        {
            Node<T> pivot = parent.right;
            parent.right = pivot.left;
            pivot.left = parent;
            return pivot;
        }
        private Node<T> RotateLL(Node<T> parent)
        {
            Node<T> pivot = parent.left;
            parent.left = pivot.right;
            pivot.right = parent;
            return pivot;
        }
        private Node<T> RotateLR(Node<T> parent)
        {
            Node<T> pivot = parent.left;
            parent.left = RotateRR(pivot);
            return RotateLL(parent);
        }
        private Node<T> RotateRL(Node<T> parent)
        {
            Node<T> pivot = parent.right;
            parent.right = RotateLL(pivot);
            return RotateRR(parent);
        }

        #endregion
    }
}