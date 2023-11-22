using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_and_Data_Structure_1
{
    class ALDS1_11_A
    {
        private int n = 0;
        private bool[,] G;

        public ALDS1_11_A(int n)
        {
            this.n = n;
            G = new bool[n, n];
        }

        public void Print()
        {
            for(int i = 0; i < n; i++)
            {
                int[] line = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                for(int j = 0; j < line[1]; j++)
                {
                    G[line[0] - 1, line[2 + j] - 1] = true;
                }
            }
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    if (G[i, j]) Console.Write(1);
                    else Console.Write(0);
                    if (j != n - 1) Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
    }
}
