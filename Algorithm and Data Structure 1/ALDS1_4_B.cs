using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_and_Data_Structure_1
{
    class ALDS1_4_B
    {
        private List<int> s;
        private List<int> t;

        public ALDS1_4_B(List<int> s, List<int> t)
        {
            this.s = s;
            this.t = t;
        }

        public List<int> S
        {
            get { return s; }
            set { s = value; }
        }

        public List<int> T
        {
            get { return t; }
            set { t = value; }
        }

        public int Counting()
        {
            int sum = 0;
            for(int i = 0; i < t.Count; i++)
            {
                int r = s.Count;
                int l = 0;
                while (l + 1 < r)
                {
                    int m = (r + l) / 2;
                    if (t[i] < s[m]) r = m;
                    else l = m;
                }
                if (t[i] == s[l]) sum++;
            }
            return sum;
        }
    }
}
