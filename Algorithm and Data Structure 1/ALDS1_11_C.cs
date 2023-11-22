using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_and_Data_Structure_1
{
    class ALDS1_11_C
    {
        private int n = 0;
        private int[][] nodes;
        private int[] distance;
        private Queue<int> que;

        public ALDS1_11_C(int n)
        {
            this.n = n;
            nodes = new int[n][];
            distance = new int[n];
            que = new Queue<int>();
        }

        private void BreadthFirstSearch()
        {
            que.Enqueue(0);
            int dis = 0;
            while(que.Count > 0)
            {
                int cnt = que.Count;
                for(int i = 0; i < cnt; i++)
                {
                    int p = que.Dequeue();
                    distance[p] = dis;
                    for(int j = 0; j < nodes[p].Length; j++)
                    {
                        if (distance[nodes[p][j]] == -1 && !que.Contains(nodes[p][j])) que.Enqueue(nodes[p][j]);
                    }
                }
                dis++;
            }
        }

        public void Print()
        {
            for(int i = 0; i < n; i++)
            {
                int[] line = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                distance[i] = -1;
                nodes[line[0] - 1] = new int[line[1]];
                for(int j = 0; j < line[1]; j++)
                {
                    nodes[line[0] - 1][j] = line[2 + j] - 1;
                }
            }
            BreadthFirstSearch();
            for(int i = 0; i < n; i++)
            {
                Console.WriteLine("{0} {1}", i + 1, distance[i]);
            }
        }
    }
}
