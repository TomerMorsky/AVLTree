using System;
using System.Collections.Generic;
using System.Text;

namespace AVLTree
{
    public class Node<T> where T : IComparable<T>
    {
        public T data;
        public Node<T> left;
        public Node<T> right;
        public Node(T data)
        {
            this.data = data;
        }
    }

/*  for the compareto
      a.compareTo(b) < 0 // a < b

      a.compareTo(b) > 0 // a > b

      a.compareTo(b) == 0 // a == b
*/
}