using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_and_Data_Structure_1
{
    class ALDS1_11_B
    {
        private int n = 0;
        private int[][] nodes;
        private int[,] order;
        private bool[] arrived;
        private int cnt = 1;

        public ALDS1_11_B(int n)
        {
            this.n = n;
            nodes = new int[n][];
            order = new int[n, 2];
            arrived = new bool[n];
        }

        private void DepthFirstSearch(int i)
        {
            if (arrived[i]) return;
            arrived[i] = true;
            order[i, 0] = cnt++;
            for(int j = 0; j < nodes[i].Length; j++)
            {
                DepthFirstSearch(nodes[i][j]);
            }
            order[i, 1] = cnt++;
        }

        public void Print()
        {
            for(int i = 0; i < n; i++)
            {
                int[] line = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                nodes[line[0] - 1] = new int[line[1]];
                for(int j = 0; j < line[1]; j++)
                {
                    nodes[line[0] - 1][j] = line[2 + j] - 1;
                }
            }
            for(int i = 0; i < n; i++) DepthFirstSearch(i);
            for(int i = 0; i < n; i++)
            {
                Console.WriteLine("{0} {1} {2}", i + 1, order[i, 0], order[i, 1]);
            }
        }
    }
}
