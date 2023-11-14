using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_and_Data_Structure_1
{
    class node
    {
        private int n = 0;
        private node parent;
        private int parentn = -1;
        private int depth = 0;
        private string type;
        private node[] children;

        public node(int n)
        {
            this.n = n;
        }
        
        public int N
        {
            get { return n; }
            set { n = value; }
        }

        public node Parent
        {
            get { return parent; }
            set { parent = value; }
        }

        public int Parentn
        {
            get { return parentn; }
            set { parentn = value; }
        }

        public int Depth
        {
            get { return depth; }
            set { depth = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public node[] Children
        {
            get { return children; }
            set { children = value; }
        }

    }

    class ALDS1_7_A
    {
        private int n = 0;
        private node[] nodes;

        public ALDS1_7_A(int n)
        {
            this.n = n;
            nodes = new node[n];
            for (int i = 0; i < n; i++)
            {
                nodes[i] = new node(i);
            }
        }

        private void SearchTree(node no)
        {
            if (no.Parent == null)
            {
                no.Type = "root";
                no.Depth = 0;
            }
            else if (no.Children.Length > 0)
            {
                no.Type = "internal node";
                no.Depth = no.Parent.Depth + 1;
            }
            else
            {
                no.Type = "leaf";
                no.Depth = no.Parent.Depth + 1;
            }
            for(int i = 0; i < no.Children.Length; i++)
            {
                SearchTree(no.Children[i]);
            }
        }

        private void Search()
        {
            node no = nodes[0];
            while(no.Parent != null) no = no.Parent;
            SearchTree(no);
        }

        public void Print()
        {
            for(int i = 0; i < n; i++)
            {
                int[] ints = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                nodes[ints[0]].Children = new node[ints[1]];
                for (int j = 0; j < ints[1]; j++)
                {
                    nodes[ints[0]].Children[j] = nodes[ints[j + 2]];
                    nodes[ints[j + 2]].Parent = nodes[ints[0]];
                    nodes[ints[j + 2]].Parentn = nodes[ints[0]].N;
                }
            }
            Search();
            foreach(var v in nodes)
            {
                Console.WriteLine("node {0}: parent = {1}, depth = {2}, {3}, [{4}]", v.N, v.Parentn, v.Depth, v.Type, string.Join(", ", v.Children.Select(x => x.N.ToString()).ToArray()));
            }
        }
    }
}
