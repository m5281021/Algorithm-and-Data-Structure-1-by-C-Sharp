using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_and_Data_Structure_1
{
    class binarySearchTree3
    {
        private int n = 0;
        private binarySearchTree3 left;
        private binarySearchTree3 right;
        private binarySearchTree3 parent;

        public binarySearchTree3(int n, binarySearchTree3 parent)
        {
            this.n = n;
            this.parent = parent;
        }

        public int N
        {
            get { return n; }
            set { n = value; }
        }

        public binarySearchTree3 Left
        {
            get { return left; }
            set { left = value; }
        }

        public binarySearchTree3 Right
        {
            get { return right; }
            set { right = value; }
        }

        public binarySearchTree3 Parent
        {
            get { return parent; }
            set { parent = value; }
        }
    }

    class ALDS1_8_C
    {
        private int n = 0;
        private binarySearchTree3 root;

        public ALDS1_8_C(int n)
        {
            this.n = n;
        }

        private void Insert(int p)
        {
            binarySearchTree3 y = null;
            binarySearchTree3 x = root;
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
            binarySearchTree3 z = new binarySearchTree3(p, y);
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

        private void InorderTreeWalk(binarySearchTree3 node)
        {
            if (node.Left != null) InorderTreeWalk(node.Left);
            Console.Write(" {0}", node.N);
            if (node.Right != null) InorderTreeWalk(node.Right);
        }

        private void PreorderTreeWalk(binarySearchTree3 node)
        {
            Console.Write(" {0}", node.N);
            if (node.Left != null) PreorderTreeWalk(node.Left);
            if (node.Right != null) PreorderTreeWalk(node.Right);
        }

        private void Find(int p)
        {
            binarySearchTree3 node = root;
            while (node != null)
            {
                if (node.N == p)
                {
                    Console.WriteLine("yes");
                    return;
                }
                if (p < node.N)
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

        private binarySearchTree3 ChangePlace(binarySearchTree3 node)
        {
            if(node.Right != null)
            {
                node = node.Right;
                while (node.Left != null) node = node.Left;
                return node;
            }
            else
            {
                binarySearchTree3 parent = node.Parent;
                while(parent != null)
                {
                    if (parent.Right != node) break;
                    node = parent;
                    parent = parent.Parent;
                }
                return parent;
            }
        }

        private void Delete(int p)
        {
            binarySearchTree3 node = root;
            bool flag = false;
            while(node != null)
            {
                if (node.N == p)
                {
                    break;
                }
                if (p < node.N)
                {
                    node = node.Left;
                    flag = false;
                }
                else
                {
                    node = node.Right;
                    flag = true;
                }
            }
            if(node == null)
            {
                return;
            }
            binarySearchTree3 target;
            if (node.Left == null || node.Right == null)
            {
                target = node;
            }
            else target = ChangePlace(node);
            binarySearchTree3 next;
            if (target.Left != null) next = target.Left;
            else next = target.Right;
            if (next != null) next.Parent = target.Parent;
            if (target.Parent == null) root = next;
            else if (target.Parent.Right == target) target.Parent.Right = next;
            else target.Parent.Left = next;
            if (node != target) node.N = target.N;
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
                else if (str[0] == "delete")
                {
                    Delete(int.Parse(str[1]));
                }
            }
        }
    }
}
