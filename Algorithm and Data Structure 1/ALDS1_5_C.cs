using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_and_Data_Structure_1
{
    class ALDS1_5_C
    {
        private int n = 0;
        private (double, double) left = (0, 0);
        private (double, double) right = (100, 0);

        public ALDS1_5_C(int n)
        {
            this.n = n;
        }

        public int N
        {
            get { return n; }
            set { n = value; }
        }

        public (double, double) Left
        {
            get { return left; }
            set { left = value; }
        }

        public (double, double) Right
        {
            get { return right; }
            set { right = value; }
        }

        private void KochCurve(int rest, (double, double) l, (double, double) r)
        {
            if (rest == 0) Console.WriteLine("{0:F8} {1:F8}", l.Item1, l.Item2);
            else
            {
                double x = r.Item1 - l.Item1;
                double y = r.Item2 - l.Item2;
                KochCurve(rest - 1, l, (l.Item1 + x / 3, l.Item2 + y / 3));
                KochCurve(rest - 1, (l.Item1 + x / 3, l.Item2 + y / 3), (l.Item1 + x / 2 - y * Math.Sqrt(3) / 6, l.Item2 + y / 2 + x * Math.Sqrt(3) / 6));
                KochCurve(rest - 1, (l.Item1 + x / 2 - y * Math.Sqrt(3) / 6, l.Item2 + y / 2 + x * Math.Sqrt(3) / 6), (r.Item1 - x / 3, r.Item2 - y / 3));
                KochCurve(rest - 1, (r.Item1 - x / 3, r.Item2 - y / 3), r);
            }
            if(rest == n) Console.WriteLine("{0:F8} {1:F8}", r.Item1, r.Item2);
        }

        public void Print()
        {
            KochCurve(n, left, right);
        }
    }
}