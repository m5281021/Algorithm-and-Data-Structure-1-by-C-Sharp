using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_and_Data_Structure_1
{
    class ALDS1_14_D
    {
        private string str;
        private int n = 0;
        private int[] sa;
        private int[] rank;
        private int k = 0;

        public ALDS1_14_D(string str)
        {
            this.str = str;
            n = str.Length;
            sa = new int[n + 1];
            rank = new int[n + 1];
            Constract_SA();
            Answer();
        }

        private int Compare(int i, int j)
        {
            if (rank[i] != rank[j]) return rank[i] - rank[j];
            else
            {
                int a = -1;
                if(i + k <= n) a = rank[i + k];
                int b = -1;
                if(j + k <= n) b = rank[j + k];
                return a - b;
            }
        }

        private void Constract_SA()
        {
            for(int i = 0; i < n + 1; i++)
            {
                sa[i] = i;
                if (i < n) rank[i] = str[i];
                else rank[i] = -1;
            }
            for(k = 1; k < n + 1; k *= 2)
            {
                Array.Sort(sa, Compare);
                int[] tem = new int[n + 1];
                tem[sa[0]] = 0;
                for(int i = 1; i < n + 1; i++)
                {
                    if (Compare(sa[i - 1], sa[i]) < 0) tem[sa[i]] = tem[sa[i - 1]] + 1;
                    else tem[sa[i]] = tem[sa[i - 1]];
                }
                for(int i = 0; i < n + 1; i++)
                {
                    rank[i] = tem[i];
                }
            }
        }

        private void Answer()
        {
            int m = int.Parse(Console.ReadLine());
            for(int i = 0; i < m; i++)
            {
                string target = Console.ReadLine();
                int len = target.Length;
                int l = 0;
                int r = n;
                while(l + 1 < r)
                {
                    int mid = (l + r) / 2;
                    int index = sa[mid];
                    if (string.CompareOrdinal(str, index, target, 0, len) < 0) l = mid;
                    else r = mid;
                }
                if (string.CompareOrdinal(str, sa[r], target, 0, len) == 0) Console.WriteLine(1);
                else Console.WriteLine(0);
            }
        }
    }
}
