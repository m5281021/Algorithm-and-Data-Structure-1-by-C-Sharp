using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_and_Data_Structure_1
{
    class ALDS1_14_A
    {
        private string t;
        private string p;

        public ALDS1_14_A(string t, string p)
        {
            this.t = t;
            this.p = p;
            Search();
        }

        private void Search()
        {
            for(int i = 0; i < t.Length - p.Length + 1; i++)
            {
                string str = t.Substring(i, p.Length);
                if (str == p) Console.WriteLine(i);
            }
        }
    }
}
