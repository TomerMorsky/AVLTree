using System;
using System.Collections.Generic;
using System.Text;

namespace AVLTree
{
    public class AVL<T> where T : IComparable<T>
    {
        #region Fields

        private Node<T> root;

        #endregion

        #region C'tor

        public AVL(){}

        #endregion

        #region Public methods

        public void Add(T data)
        {
            Node<T> newItem = new Node<T>(data);
            if (root == null)
                root = newItem;
            else
                root = RecursiveInsert(root, newItem);
        }
       
        public void Delete(T target)
        {
            root = Delete(root, target);
        }

        public void Find(T key)
        {
            if (Find(key, root).data.Equals(key))
            {
                Console.WriteLine("{0} was found!", key);
            }
            else
            {
                Console.WriteLine("Nothing found!");
            }
        }

        public void DisplayTree()
        {
            if (root == null)
            {
                Console.WriteLine("Tree is empty");
                return;
            }
            InOrderDisplayTree(root);
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

        private Node<T> Delete(Node<T> current, T target)
        {
            Node<T> parent;
            if (current == null)
            { return null; }
            else
            {
                //left subtree
                if (target.CompareTo(current.data) < 0)
                {
                    current.left = Delete(current.left, target);
                    if (GetBalanceFactor(current) == -2)//here
                    {
                        if (GetBalanceFactor(current.right) <= 0)
                        {
                            current = RotateRR(current);
                        }
                        else
                        {
                            current = RotateRL(current);
                        }
                    }
                }
                //right subtree
                else if (target.CompareTo(current.data) > 0)
                {
                    current.right = Delete(current.right, target);
                    if (GetBalanceFactor(current) == 2)
                    {
                        if (GetBalanceFactor(current.left) >= 0)
                        {
                            current = RotateLL(current);
                        }
                        else
                        {
                            current = RotateLR(current);
                        }
                    }
                }
                //if target is found
                else
                {
                    if (current.right != null)
                    {
                        //delete its inorder successor
                        parent = current.right;
                        while (parent.left != null)
                        {
                            parent = parent.left;
                        }
                        current.data = parent.data;
                        current.right = Delete(current.right, parent.data);
                        if (GetBalanceFactor(current) == 2)//rebalancing
                        {
                            if (GetBalanceFactor(current.left) >= 0)
                            {
                                current = RotateLL(current);
                            }
                            else { current = RotateLR(current); }
                        }
                    }
                    else
                    {   //if current.left != null
                        return current.left;
                    }
                }
            }
            return current;
        }
        
        private Node<T> Find(T target, Node<T> current)
        {

            if (target.CompareTo(current.data) < 0)
            {
                if (target.Equals(current.data))
                {
                    return current;
                }
                else
                    return Find(target, current.left);
            }
            else
            {
                if (target.Equals(current.data))
                {
                    return current;
                }
                else
                    return Find(target, current.right);
            }

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