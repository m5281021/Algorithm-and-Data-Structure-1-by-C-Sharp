using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_and_Data_Structure_1
{
    class ALDS1_4_A
    {
        private List<int> s;
        private List<int> t;

        public ALDS1_4_A(List<int> s, List<int> t)
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
                if (s.Contains(t[i])) sum++;
            }
            return sum;
        }
    }
}
