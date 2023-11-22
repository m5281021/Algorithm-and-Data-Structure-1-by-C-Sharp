using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_and_Data_Structure_1
{
    class ALDS1_12_A
    {
        private int n = 0;
        private int[,] g;
        private int cost = 0;
        private bool[] flag;
        
        public ALDS1_12_A(int n)
        {
            this.n = n;
            g = new int[n, n];
            flag = new bool[n];
            for(int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine().Split(' ');
                int k = 0;
                for(int j = 0; j < line.Length; j++)
                {
                    if (line[j] == "") continue;
                    int v = int.Parse(line[j]);
                    if (v == -1) g[i, k++] = int.MaxValue;
                    else g[i, k++] = v;
                }
            }
        }

        private void Minimize()
        {
            flag[0] = true;
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
                            if(min > g[j, k])
                            {
                                min = g[j, k];
                                to = k;
                            }
                        }
                    }
                }
                flag[to] = true;
                cost += min;
            }
        }

        public void Print()
        {
            Minimize();
            Console.WriteLine(cost);
        }
    }
}
