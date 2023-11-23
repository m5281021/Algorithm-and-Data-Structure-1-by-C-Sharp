using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_and_Data_Structure_1
{
    class ALDS1_13_A
    {
        private int[] row;
        private bool[] col;
        private bool[] dpos;
        private bool[] dneg;
        private int time = 0;

        public ALDS1_13_A(int n)
        {
            row = new int[8];
            col = new bool[8];
            dpos = new bool[15];
            dneg = new bool[15];
            for (int i = 0; i < 8; i++)
            {
                row[i] = -1;
            }
            for (int i = 0; i < n; i++)
            {
                int[] pos = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                int y = pos[0];
                int x = pos[1];
                row[y] = x;
                col[x] = true;
                dpos[x + y] = true;
                dneg[x - y + 7] = true;
            }
            Solve(0);
        }

        private void Print()
        {
            for(int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    if (row[i] == j) Console.Write("Q");
                    else Console.Write(".");
                }
                Console.WriteLine();
            }
        }

        private void Solve(int y)
        {
            if (y == 8)
            {
                Print();
                return;
            }
            if (row[y] != -1)
            {
                Solve(y + 1);
                return;
            }
            for(int x = 0; x < 8; x++)
            {
                if (col[x] || dpos[x + y] || dneg[x - y + 7]) continue;
                row[y] = x;
                col[x] = true;
                dpos[x + y] = true;
                dneg[x - y + 7] = true;
                Solve(y + 1);
                row[y] = -1;
                col[x] = false;
                dpos[x + y] = false;
                dneg[x - y + 7] = false;
            }
        }
    }
}
