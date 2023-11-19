using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_and_Data_Structure_1
{
    class ALDS1_10_A
    {
        private long[] fibonacci;

        public ALDS1_10_A(int n)
        {
            fibonacci = new long[n + 1];
            Console.WriteLine(Fib(n));
        }

        private long Fib(int n)
        {
            for(int i = 0; i <= n; i++)
            {
                if (i == 0) fibonacci[i] = 1;
                else if (i == 1) fibonacci[i] = 1;
                else fibonacci[i] = fibonacci[i - 1] + fibonacci[i - 2];
            }
            return fibonacci[n];
        }
    }
}
