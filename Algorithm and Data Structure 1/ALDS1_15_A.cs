using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_and_Data_Structure_1
{
    class ALDS1_15_A
    {
        private int[] cents = new int[4] { 1, 5, 10, 25 };
        private int n = 0;

        public ALDS1_15_A(int n)
        {
            this.n = n;
            Console.WriteLine(Calculate());
        }

        private int Calculate()
        {
            int coins = 0;
            for(int i = 3; i >= 0 ; i--)
            {
                coins += n / cents[i];
                n %= cents[i];
            }
            return coins;
        }
    }
}
