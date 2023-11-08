using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_and_Data_Structure_1
{
    class ALDS1_1_B
    {
        private int a = 0;
        private int b = 0;

        public ALDS1_1_B(int a, int b)
        {
            this.a = a;
            this.b = b;
        }

        public int A
        {
            get { return a; }
            set { a = value; }
        }

        public int B
        {
            get { return b; }
            set { b = value; }
        }

        public int GreatestCommonDivisor()
        {
            if(a > b)
            {
                int c = b;
                b = a;
                a = c;
            }
            while(b % a != 0)
            {
                int c = b % a;
                b = a;
                a = c;
            }
            return a;
        }
    }
}
