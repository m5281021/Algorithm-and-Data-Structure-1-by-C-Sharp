using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_and_Data_Structure_1
{
    class ALDS1_10_D
    {
        private double[,] dp;
        private double[] p;
        private double[] q;
        private double[] tp;
        private double[] tq;

        public ALDS1_10_D(int n)
        {
            dp = new double[n + 2, n + 2];
            double[] list = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            double[] list2 = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            p = new double[n + 2];
            q = new double[n + 2];
            tp = new double[n + 2];
            tq = new double[n + 2];
            for(int i = 1; i < n + 2; i++)
            {
                if(i != 1) p[i] = list[i - 2];
                q[i] = list2[i - 1];
                tp[i] = tp[i - 1] + p[i];
                tq[i] = tq[i - 1] + q[i];
            }
            Console.WriteLine("{0:F8}", 1.0 + calculate(1, n + 1));
        }

        public double calculate(int l, int r)
        {
            if (dp[l, r] != 0) return dp[l, r];
            if (l == r) return dp[l, r] = 0;
            dp[l, r] = double.MaxValue;
            double total = tq[r] - tq[l - 1] + tp[r] - tp[l];
            for(int i = l + 1; i <= r; i++)
            {
                double left = tq[i - 1] - tq[l - 1] + tp[i - 1] - tp[l];
                double right = total - left - p[i];
                double under = (calculate(l, i - 1) + 1) * (left / total) + (calculate(i, r) + 1) * (right / total);
                dp[l, r] = Math.Min(under, dp[l, r]);
            }
            return dp[l, r];
        }
    }
}
