using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_and_Data_Structure_1
{
    class ALDS1_10_B
    {
        private int n = 0;
        private int[] matrix;
        private int[,] dp;

        public ALDS1_10_B(int n)
        {
            this.n = n;
            matrix = new int[n + 1];
            for(int i = 0; i < n; i++)
            {
                int[] line = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                matrix[i] = line[0];
                matrix[i + 1] = line[1];
            }
            Console.WriteLine(calculate());
        }

        private int calculate()
        {
            dp = new int[n + 1, n + 1];
            for(int i = 2; i <= n; i++)
            {
                for(int j = 1; j <= n - i + 1; j++)
                {
                    int k = i + j - 1;
                    dp[j, k] = int.MaxValue;
                    for(int l = j; l < k; l++)
                    {
                        dp[j, k] = Math.Min(dp[j, k], dp[j, l] + dp[l + 1, k] + matrix[j - 1] * matrix[l] * matrix[k]);
                    }
                }
            }
            return dp[1, n];
        }
    }
}
