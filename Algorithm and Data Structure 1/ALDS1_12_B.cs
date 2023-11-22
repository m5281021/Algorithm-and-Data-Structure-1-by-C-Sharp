using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_and_Data_Structure_1
{
    class ALDS1_12_B
    {
        private int n = 0;
        private int[,] g;
        private int[] distance;
        private bool[] flag;

        public ALDS1_12_B(int n)
        {
            this.n = n;
            g = new int[n, n];
            distance = new int[n];
            flag = new bool[n];
            for(int i = 0; i < n; i++)
            {
                distance[i] = -1;
                for(int j = 0; j < n; j++)
                {
                    g[i, j] = int.MaxValue;
                }
            }
            for(int i = 0; i < n; i++)
            {
                int[] line = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                for(int j = 0; j < line[1]; j++)
                {
                    g[line[0], line[(j + 1) * 2]] = line[(j + 1) * 2 + 1];
                }
            }
        }

        private void Calculate()
        {
            flag[0] = true;
            distance[0] = 0;
            for(int i = 0; i < n - 1; i++)
            {
                int min = int.MaxValue;
                int to = -1;
                for(int j = 0; j < n; j++)
                {
                    if (flag[j])
                    {
                        for(int k = 0; k < n; k++)
                        {
                            if (flag[k]) continue;
                            if (g[j, k] < min && g[j, k] + distance[j] < min)
                            {
                                min = g[j, k] + distance[j];
                                to = k;
                            }
                        }
                    }
                }
                flag[to] = true;
                distance[to] = min;
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
