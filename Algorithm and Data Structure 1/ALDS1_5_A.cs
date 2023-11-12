using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_and_Data_Structure_1
{
    class ALDS1_5_A
    {
        private List<int> a;
        private List<int> m;

        public ALDS1_5_A(List<int> a, List<int> m)
        {
            this.a = a;
            this.m = m;
        }

        public List<int> A
        {
            get { return a; }
            set { a = value; }
        }

        public List<int> M
        {
            get { return m; }
            set { m = value; }
        }

        public bool Calculate(int i, int n)
        {
            if (n == 0) return true;
            if (i == a.Count) return false;
            return Calculate(i + 1, n - a[i]) || Calculate(i + 1, n);
        }

        public void Judge()
        {
            for(int i = 0; i < m.Count; i++)
            {
                if (Calculate(0, m[i])) Console.WriteLine("yes");
                else Console.WriteLine("no");
            }
        }
    }
}
