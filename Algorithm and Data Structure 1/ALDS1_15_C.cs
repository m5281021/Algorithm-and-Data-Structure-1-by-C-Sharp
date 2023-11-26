using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_and_Data_Structure_1
{
    class ALDS1_15_C
    {
        private int n = 0;
        private Tuple<int, int>[] schedule;

        public ALDS1_15_C(int n)
        {
            this.n = n;
            schedule = new Tuple<int, int>[n];
            for(int i = 0; i < n; i++)
            {
                int[] times = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                schedule[i] = new Tuple<int, int>(times[0], times[1]);
            }
            Console.WriteLine(Calculate());
        }

        private int Calculate()
        {
            int sum = 0;
            int now = 0;
            foreach(var v in schedule.OrderBy(x => x.Item2).ThenBy(x => x.Item1))
            {
                if (v.Item1 > now)
                {
                    now = v.Item2;
                    sum++;
                }
            }
            return sum;
        }
    }
}
