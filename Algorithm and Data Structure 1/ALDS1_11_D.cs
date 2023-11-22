using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_and_Data_Structure_1
{
    class ALDS1_11_D
    {
        private int n = 0;
        private List<int>[] g;
        private int[] colour;

        public ALDS1_11_D(int n, int m)
        {
            this.n = n;
            colour = new int[n];
            g = new List<int>[n];
            for(int i = 0; i < n; i++)
            {
                colour[i] = -1;
                g[i] = new List<int>();
            }
            for(int i = 0; i < m; i++)
            {
                int[] line = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                g[line[0]].Add(line[1]);
                g[line[1]].Add(line[0]);
            }
            int c = 0;
            for(int i = 0; i < n; i++)
            {
                if (colour[i] != -1) continue;
                Grouping(i, c);
                c++;
            }
        }

        private void Grouping(int i, int c)
        {
            colour[i] = c;
            for(int j = 0; j < g[i].Count; j++)
            {
                if (colour[g[i][j]] == -1)Grouping(g[i][j], c);
            }
        }

        public void Answer(int q)
        {
            for(int i = 0; i < q; i++)
            {
                int[] target = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                if (colour[target[0]] == colour[target[1]]) Console.WriteLine("yes");
                else Console.WriteLine("no");
            }
        }
    }
}
