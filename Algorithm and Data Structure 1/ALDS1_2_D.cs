using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_and_Data_Structure_1
{
    class ALDS1_2_D
    {
        private int n = 0;
        private List<int> list;
        private int cnt = 0;
        private List<int> g;

        public ALDS1_2_D(int n, List<int> list)
        {
            this.n = n;
            this.list = list;
            g = new List<int>();
        }

        public int N
        {
            get { return n; }
            set { n = value; }
        }

        public List<int> List
        {
            get { return list; }
            set { list = value; }
        }

        public int Cnt
        {
            get { return cnt; }
            set { cnt = value; }
        }

        public List<int> G
        {
            get { return g; }
            set { g = value; }
        }

        private void InsertionSort(int g)
        {
            for(int i = g; i < n; i++)
            {
                int a = list[i];
                int j = i - g;
                while(j >= 0 && list[j] > a)
                {
                    list[j + g] = list[j];
                    j = j - g;
                    cnt++;
                }
                list[j + g] = a;
            }
        }

        public void shellSort()
        {
            int m = (int)Math.Sqrt(n);
            if (m > 100) m = 100;
            if (m < 1) m = 1;
            for(int i = 0; i < m; i++)
            {
                g.Add((m - i) * (m - i));
                InsertionSort((m - i) * (m - i));
            }
        }
    }
}
