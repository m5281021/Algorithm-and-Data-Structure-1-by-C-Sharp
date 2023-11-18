using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_and_Data_Structure_1
{
    class treap
    {
        private int key = 0;
        private int pri = 0;
        private treap parent;
        private treap left;
        private treap right;

        public treap(int key, int pri)
        {
            this.key = key;
            this.pri = pri;
        }

        public int Key
        {
            get { return key; }
            set { key = value; }
        }

        public int Pri
        {
            get { return pri; }
            set { pri = value; }
        }

        public treap Parent
        {
            get { return parent; }
            set { parent = value; }
        }

        public treap Left
        {
            get { return left; }
            set { left = value; }
        }

        public treap Right
        {
            get { return right; }
            set { right = value; }
        }
    }

    class ALDS1_8_D
    {
        private int m = 0;
        private treap root;

        public ALDS1_8_D(int m)
        {
            this.m = m;
        }

        private treap RightRotate(treap node)
        {
            treap target = node.Left;
            node.Left = target.Right;
            target.Right = node;
            if (node.Parent == null) root = target;
            target.Parent = node.Parent;
            node.Parent = target;
            return target;
        }

        private treap LeftRotate(treap node)
        {
            treap target = node.Right;
            node.Right = target.Left;
            target.Left = node;
            if (node.Parent == null) root = target;
            target.Parent = node.Parent;
            node.Parent = target;
            return target;
        }

        private treap Insert(treap node, int key, int pri)
        {
            if(node == null)
            {
                return new treap(key, pri);
            }
            if(node.Key == key)
            {
                return node;
            }
            if(key < node.Key)
            {
                node.Left = Insert(node.Left, key, pri);
                node.Left.Parent = node;
                if(node.Pri < node.Left.Pri)
                {
                    node = RightRotate(node);
                }
            }
            else
            {
                node.Right = Insert(node.Right, key, pri);
                node.Right.Parent = node;
                if(node.Pri < node.Right.Pri)
                {
                    node = LeftRotate(node);
                }
            }
            return node;
        }

        private treap DeleteKey(treap node, int key)
        {
            if(node.Left == null && node.Right == null)
            {
                return null;
            }
            else if(node.Left == null)
            {
                node = LeftRotate(node);
            }
            else if(node.Right == null)
            {
                node = RightRotate(node);
            }
            else
            {
                if(node.Left.Pri > node.Right.Pri)
                {
                    node = RightRotate(node);
                }
                else
                {
                    node = LeftRotate(node);
                }
            }
            return Delete(node, key);
        }

        private treap Delete(treap node, int key)
        {
            if (node == null)
            {
                return null;
            }
            if(key < node.Key)
            {
                node.Left = Delete(node.Left, key);
            }
            else if(key > node.Key)
            {
                node.Right = Delete(node.Right, key);
            }
            else
            {
                return DeleteKey(node, key);
            }
            return node;
        }
        
        private void Find(int key)
        {
            treap node = root;
            while(node != null)
            {
                if(node.Key == key)
                {
                    Console.WriteLine("yes");
                    return;
                }
                if(key < node.Key)
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

        private void InorderTreeWalk(treap node)
        {
            if (node.Left != null) InorderTreeWalk(node.Left);
            Console.Write(" {0}", node.Key);
            if (node.Right != null) InorderTreeWalk(node.Right);
        }

        private void PreorderTreeWalk(treap node)
        {
            Console.Write(" {0}", node.Key);
            if (node.Left != null) PreorderTreeWalk(node.Left);
            if(node.Right != null) PreorderTreeWalk(node.Right);
        }

        public void Print()
        {
            for (int i = 0; i < m; i++)
            {
                string[] str = Console.ReadLine().Split(' ').ToArray();
                if (str[0] == "insert")
                {
                    root = Insert(root, int.Parse(str[1]), int.Parse(str[2]));
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
                    Delete(root, int.Parse(str[1]));
                }
            }
        }
    }
}
