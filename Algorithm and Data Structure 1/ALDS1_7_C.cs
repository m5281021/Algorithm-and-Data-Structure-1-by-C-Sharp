using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_and_Data_Structure_1
{
    class walkedNode
    {
        private int n = -1;
        private int parent = -1;
        private int left = -1;
        private int right = -1;

        public walkedNode(int n)
        {
            this.n = n;
        }

        public int N
        {
            get { return n; }
            set { n = value; }
        }

        public int Parent
        {
            get { return parent; }
            set { parent = value; }
        }

        public int Left
        {
            get { return left; }
            set { left = value; }
        }

        public int Right
        {
            get { return right; }
            set { right = value; }
        }
    }

    class ALDS1_7_C
    {
        private int n = 0;
        private walkedNode[] nodes;
        private int p = 0;
        private string[] str;

        public ALDS1_7_C(int n)
        {
            this.n = n;
            nodes = new walkedNode[n];
            for(int i = 0; i < n; i++)
            {
                nodes[i] = new walkedNode(i);
            }
            str = new string[n];
        }

        public int N
        {
            get { return n; }
            set { n = value; }
        }

        public walkedNode[] Nodes
        {
            get { return nodes; }
            set { nodes = value; }
        }

        private void PreorderTreeWalk(int i)
        {
            str[p++] = nodes[i].N.ToString();
            if (nodes[i].Left != -1) PreorderTreeWalk(nodes[nodes[i].Left].N);
            if (nodes[i].Right != -1) PreorderTreeWalk(nodes[nodes[i].Right].N);
        }

        private void InorderTreeWalk(int i)
        {
            if (nodes[i].Left != -1) InorderTreeWalk(nodes[nodes[i].Left].N);
            str[p++] = nodes[i].N.ToString();
            if (nodes[i].Right != -1) InorderTreeWalk(nodes[nodes[i].Right].N);
        }

        private void PostorderTreeWalk(int i)
        {
            if (nodes[i].Left != -1) PostorderTreeWalk(nodes[nodes[i].Left].N);
            if (nodes[i].Right != -1) PostorderTreeWalk(nodes[nodes[i].Right].N);
            str[p++] = nodes[i].N.ToString();
        }

        public void Print()
        {
            for(int i = 0; i < n; i++)
            {
                int[] ints = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                if (ints[1] != -1)
                {
                    nodes[ints[0]].Left = ints[1];
                    nodes[ints[1]].Parent = ints[0];
                }
                if (ints[2] != -1)
                {
                    nodes[ints[0]].Right = ints[2];
                    nodes[ints[2]].Parent = ints[0];
                }
            }
            int j = 0;
            while (nodes[j].Parent != -1) j = nodes[j].Parent;
            p = 0;
            Console.WriteLine("Preorder");
            PreorderTreeWalk(j);
            Console.WriteLine(" {0}", string.Join(" ", str));
            p = 0;
            Console.WriteLine("Inorder");
            InorderTreeWalk(j);
            Console.WriteLine(" {0}", string.Join(" ", str));
            p = 0;
            Console.WriteLine("Postorder");
            PostorderTreeWalk(j);
            Console.WriteLine(" {0}", string.Join(" ", str));
        }
    }
}
