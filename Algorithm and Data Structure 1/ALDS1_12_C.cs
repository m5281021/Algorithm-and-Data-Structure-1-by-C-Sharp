using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_and_Data_Structure_1
{
    class place
    {
        private int cost;
        private int to;

        public place(int cost, int to)
        {
            this.cost = cost;
            this.to = to;
        }

        public int Cost
        {
            get { return cost; }
            set { cost = value; }
        }

        public int To
        {
            get { return to; }
            set { to = value; }
        }
    }

    class ALDS1_12_C
    {
        private int n = 0;
        private List<place>[] vector;
        private int[] distance;
        private bool[] flag;
        private place[] nodes;
        private int v = 0;

        public ALDS1_12_C(int n)
        {
            this.n = n;
            vector = new List<place>[n];
            distance = new int[n];
            flag = new bool[n];
            nodes = new place[n * n + 1];
            for(int i = 0; i < n; i++)
            {
                int[] line = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                vector[line[0]] = new List<place>();
                distance[line[0]] = int.MaxValue;
                for(int j = 0; j < line[1]; j++)
                {
                    vector[line[0]].Add(new place(line[2 * (j + 1) + 1], line[2 * (j + 1)]));
                }
            }
        }

        private void Swap(int x, int y)
        {
            place z = nodes[x];
            nodes[x] = nodes[y];
            nodes[y] = z;
        }

        private void DownMinHeap(int x)
        {
            int left = x * 2;
            int right = x * 2 + 1;
            int smallest = x;
            if (left < v + 1 && nodes[smallest].Cost > nodes[left].Cost) smallest = left;
            if(right < v + 1 && nodes[smallest].Cost > nodes[right].Cost) smallest = right;
            if(smallest != x)
            {
                Swap(smallest, x);
                DownMinHeap(smallest);
            }
        }

        private void UpMinHeap(int x)
        {
            int parent = x / 2;
            if (parent < 1) return;
            if (nodes[x].Cost < nodes[parent].Cost)
            {
                Swap(parent, x);
                UpMinHeap(parent);
            }
        }

        private void BuildMinHeap()
        {
            for(int i = v / 2; i > 0; i--)
            {
                DownMinHeap(i);
            }
        }

        private place Extract()
        {
            place min = nodes[1];
            nodes[1] = nodes[v--];
            DownMinHeap(1);
            return min;
        }

        private void Calculate()
        {
            nodes[++v] = new place(0, 0);
            distance[0] = 0;
            flag[0] = false;
            BuildMinHeap();
            while(v != 0)
            {
                place min = Extract();
                flag[min.To] = true;
                if (min.Cost > distance[min.To]) continue;
                for(int j = 0; j < vector[min.To].Count; j++)
                {
                    if (flag[vector[min.To][j].To]) continue;
                    if (distance[min.To] + vector[min.To][j].Cost < distance[vector[min.To][j].To])
                    {
                        distance[vector[min.To][j].To] = distance[min.To] + vector[min.To][j].Cost;
                        nodes[++v] = new place(distance[vector[min.To][j].To], vector[min.To][j].To);
                        UpMinHeap(v);
                    }
                }
            }
        }

        public void Print()
        {
            Calculate();
            for(int i = 0; i < n; i++)
            {
                Console.WriteLine("{0} {1}", i, distance[i]);
            }
        }
    }
}
