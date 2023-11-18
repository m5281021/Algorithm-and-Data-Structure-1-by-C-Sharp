using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_and_Data_Structure_1
{
    class binarySearchTree2
    {
        private int n = 0;
        private binarySearchTree2 left;
        private binarySearchTree2 right;
        private binarySearchTree2 parent;

        public binarySearchTree2(int n, binarySearchTree2 parent)
        {
            this.n = n;
            this.parent = parent;
        }

        public int N
        {
            get { return n; }
            set { n = value; }
        }

        public binarySearchTree2 Left
        {
            get { return left; }
            set { left = value; }
        }

        public binarySearchTree2 Right
        {
            get { return right; }
            set { right = value; }
        }

        public binarySearchTree2 Parent
        {
            get { return parent; }
            set { parent = value; }
        }
    }

    class ALDS1_8_B
    {
        private int n = 0;
        private binarySearchTree2 root;

        public ALDS1_8_B(int n)
        {
            this.n = n;
        }

        private void Insert(int p)
        {
            binarySearchTree2 y = null;
            binarySearchTree2 x = root;
            while (x != null)
            {
                y = x;
                if (p < x.N)
                {
                    x = x.Left;
                }
                else
                {
                    x = x.Right;
                }
            }
            binarySearchTree2 z = new binarySearchTree2(p, y);
            if (y == null)
            {
                root = z;
            }
            else if (z.N < y.N)
            {
                y.Left = z;
            }
            else
            {
                y.Right = z;
            }
        }

        private void InorderTreeWalk(binarySearchTree2 node)
        {
            if (node.Left != null) InorderTreeWalk(node.Left);
            Console.Write(" {0}", node.N);
            if (node.Right != null) InorderTreeWalk(node.Right);
        }

        private void PreorderTreeWalk(binarySearchTree2 node)
        {
            Console.Write(" {0}", node.N);
            if (node.Left != null) PreorderTreeWalk(node.Left);
            if (node.Right != null) PreorderTreeWalk(node.Right);
        }

        private void Find(int p)
        {
            binarySearchTree2 node = root;
            while(node != null)
            {
                if(node.N == p)
                {
                    Console.WriteLine("yes");
                    return;
                }
                if(p < node.N)
                {
                    node = node.Left;
                }
                else
                {
                    node = node.Right;
                }
            }
            Console.WriteLine("no");
        }

        public void Print()
        {
            for (int i = 0; i < n; i++)
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
                else if (str[0] == "find")
                {
                    Find(int.Parse(str[1]));
                }
            }
        }
    }
}
