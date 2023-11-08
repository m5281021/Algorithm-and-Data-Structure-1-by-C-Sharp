using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_and_Data_Structure_1
{
    class ALDS1_1_C
    {
        private bool[] npri = new bool[100000010];

        public ALDS1_1_C()
        {
            npri[0] = true;
            npri[1] = true;
            for (int i = 2; i < (int)Math.Sqrt(100000010); i++)
            {
                if (npri[i]) continue;
                for (int j = i * i; j < 100000010; j += i)
                {
                    npri[j] = true;
                }
            }
        }

        public int PrimeNumbers(List<int> list)
        {
            int count = 0;
            list.ForEach(i =>
            {
                if (!npri[i]) count++;
            }
            );
            return count;
        }
    }
}