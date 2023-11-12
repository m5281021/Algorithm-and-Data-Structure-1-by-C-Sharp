using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_and_Data_Structure_1
{
    class ALDS1_4_D
    {
        private int n = 0;
        private int k = 0;
        private List<int> list;

        public ALDS1_4_D(int n, int k, List<int> list)
        {
            this.n = n;
            this.k = k;
            this.list = list;
        }

        public int N
        {
            get { return n; }
            set { n = value; }
        }

        public int K
        {
            get { return k; }
            set { k = value; }
        }

        public List<int> List
        {
            get { return list; }
            set { list = value; }
        }

        public int Check(int p)
        {
            int i = 0;
            for(int j = 0; j < k; j++)
            {
                int sum = 0;
                while(sum + list[i] <= p)
                {
                    sum += list[i];
                    i++;
                    if (i == n) return n;
                }
            }
            return i;
        }

        public int Solve()
        {
            int l = 0;
            int r = 1000000000;
            while(l + 1 < r)
            {
                int m = (l + r) / 2;
                int v = Check(m);
                if (v >= n) r = m;
                else l = m;
            }
            return r;
        }
    }
}
