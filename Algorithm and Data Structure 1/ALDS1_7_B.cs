using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_and_Data_Structure_1
{
    class binaryNode
    {
        private int n = 0;
        private int parent = -1;
        private int sibling = -1;
        private int degree = 0;
        private int depth = 0;
        private int height = 0;
        private string type = "";
        private int left = -1;
        private int right = -1;

        public binaryNode(int n)
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

        public int Sibling
        {
            get { return sibling; }
            set { sibling = value; }
        }

        public int Degree
        {
            get { return degree; }
            set { degree = value; }
        }

        public int Depth
        {
            get { return depth; }
            set { depth = value; }
        }

        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
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
    class ALDS1_7_B
    {
        private int n = 0;
        private binaryNode[] nodes;

        public ALDS1_7_B(int n)
        {
            this.n = n;
            nodes = new binaryNode[n];
            for(int i = 0; i < n; i++)
            {
                nodes[i] = new binaryNode(i);
            }
        }

        private int SearchTree(int i)
        {
            if (nodes[i].Parent == -1)
            {
                nodes[i].Type = "root";
                nodes[i].Depth = 0;
            }
            else if (nodes[i].Degree > 0)
            {
                nodes[i].Type = "internal node";
                nodes[i].Depth = nodes[nodes[i].Parent].Depth + 1;
            }
            else
            {
                nodes[i].Type = "leaf";
                nodes[i].Depth = nodes[nodes[i].Parent].Depth + 1;
            }
            int max = -1;
            if (nodes[i].Left != -1)
            {
                max = Math.Max(max, SearchTree(nodes[i].Left));
                nodes[nodes[i].Left].Sibling = nodes[i].Right;
            }
            if (nodes[i].Right != -1)
            {
                max = Math.Max(max, SearchTree(nodes[i].Right));
                nodes[nodes[i].Right].Sibling = nodes[i].Left;
            }
            return nodes[i].Height = max + 1;
        }

        private void Search()
        {
            int i = 0;
            while (nodes[i].Parent != -1) i = nodes[i].Parent;
            SearchTree(i);
        }

        public void Print()
        {
            for (int i = 0; i < n; i++)
            {
                int[] ints = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                if (ints[1] != -1)
                {
                    nodes[ints[0]].Left = ints[1];
                    nodes[ints[0]].Degree++;
                    nodes[ints[1]].Parent = nodes[ints[0]].N;
                }
                if (ints[2] != -1)
                {
                    nodes[ints[0]].Right = ints[2];
                    nodes[ints[0]].Degree++;
                    nodes[ints[2]].Parent = nodes[ints[0]].N;
                }
            }
            Search();
            foreach(var v in nodes)
            {
                Console.WriteLine("node {0}: parent = {1}, sibling = {2}, degree = {3}, depth = {4}, height = {5}, {6}", v.N, v.Parent, v.Sibling, v.Degree, v.Depth, v.Height, v.Type);
            }
        }
    }
}
