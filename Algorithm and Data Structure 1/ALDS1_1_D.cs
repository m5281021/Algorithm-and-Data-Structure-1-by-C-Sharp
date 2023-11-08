using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_and_Data_Structure_1
{
    class ALDS1_1_D
    {
        private int n = 0;
        private List<int> list;

        public ALDS1_1_D(int n, List<int> list)
        {
            this.n = n;
            this.list = list;
        }

        public int MaximumProfit()
        {
            int max = -2000000000;
            int min = list[0];
            for(int i = 1; i < list.Count; i++)
            {
                max = Math.Max(max, list[i] - min);
                min = Math.Min(min, list[i]);
            }
            return max;
        }
    }
}
