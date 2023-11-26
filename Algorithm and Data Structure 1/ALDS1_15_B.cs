using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_and_Data_Structure_1
{
    class ALDS1_15_B
    {
        private int n = 0;
        private int w = 0;
        private Tuple<int, int, double>[] items;

        public ALDS1_15_B(int n, int w)
        {
            this.n = n;
            this.w = w;
            items = new Tuple<int, int, double>[n];
            for(int i = 0; i < n; i++)
            {
                int[] line = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                items[i] = new Tuple<int, int, double>(line[0], line[1], (double)line[0] / line[1]);
            }
            Console.WriteLine(Calculate());
        }

        private decimal Calculate()
        {
            int rest = w;
            decimal sum = 0;
            foreach(var item in items.OrderByDescending(x => x.Item3))
            {
                if(rest > item.Item2)
                {
                    sum += item.Item1;
                    rest -= item.Item2;
                }
                else if(rest == item.Item2)
                {
                    sum += item.Item1;
                    rest = 0;
                    break;
                }
                else
                {
                    sum += (decimal)rest * item.Item1 / item.Item2;
                    rest = 0;
                    break;
                }
            }
            return sum;
        }
    }
}
