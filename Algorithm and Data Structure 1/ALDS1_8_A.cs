using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_and_Data_Structure_1
{
    class binarySearchTree1
    {
        private int n = 0;
        private binarySearchTree1 left;
        private binarySearchTree1 right;
        private binarySearchTree1 parent;

        public binarySearchTree1(int n, binarySearchTree1 parent)
        {
            this.n = n;
            this.parent = parent;
        }

        public int N
        {
            get { return n; }
            set { n = value; }
        }

        public binarySearchTree1 Left
        {
            get { return left; }
            set { left = value; }
        }

        public binarySearchTree1 Right
        {
            get { return right; }
            set { right = value; }
        }

        public binarySearchTree1 Parent
        {
            get { return parent; }
            set { parent = value; }
        }
    }

    class ALDS1_8_A
    {
        private int n = 0;
        private binarySearchTree1 root;

        public ALDS1_8_A(int n)
        {
            this.n = n;
        }

        private void Insert(int p)
        {
            binarySearchTree1 y = null;
            binarySearchTree1 x = root;
            while(x != null)
            {
                y = x;
                if(p < x.N)
                {
                    x = x.Left;
                }
                else
                {
                    x = x.Right;
                }
            }
            binarySearchTree1 z = new binarySearchTree1(p, y);
            if(y == null)
            {
                root = z;
            }
            else if(z.N < y.N)
            {
                y.Left = z;
            }
            else
            {
                y.Right = z;
            }
        }

        private void InorderTreeWalk(binarySearchTree1 node)
        {
            if (node.Left != null) InorderTreeWalk(node.Left);
            Console.Write(" {0}", node.N);
            if (node.Right != null) InorderTreeWalk(node.Right);
        }

        private void PreorderTreeWalk(binarySearchTree1 node)
        {
            Console.Write(" {0}", node.N);
            if (node.Left != null) PreorderTreeWalk(node.Left);
            if (node.Right != null) PreorderTreeWalk(node.Right);
        }

        public void Print()
        {
            for(int i = 0; i < n; i++)
            {
                string[] str = Console.ReadLine().Split(' ').ToArray();
                if (str[0] == "insert")
                {
                    Insert(int.Parse(str[1]));
                }
                else if (str[0] == "print")
                {
                    if (root != null) InorderTreeWalk(root);
                    Console.WriteLine();
                    if (root != null) PreorderTreeWalk(root);
                    Console.WriteLine();
                }
            }
        }
    }
}
