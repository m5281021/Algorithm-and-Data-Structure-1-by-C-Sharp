using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_and_Data_Structure_1
{
    class ALDS1_10_C
    {
        public ALDS1_10_C(int n)
        {
            for(int i = 0; i < n; i++)
            {
                string s = Console.ReadLine();
                string t = Console.ReadLine();
                Console.WriteLine(LCS(s, t));
            }
        }

        private int LCS(string s, string t)
        {
            int[,] dp = new int[s.Length + 1, t.Length + 1];
            dp[0, 0] = 0;
            for(int i = 0; i < s.Length + 1; i++)
            {
                for(int j = 0; j < t.Length + 1; j++)
                {
                    if (i == 0 || j == 0) dp[i, j] = 0;
                    else
                    {
                        if (s[i - 1] == t[j - 1]) dp[i, j] = dp[i - 1, j - 1] + 1;
                        else dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                    }
                }
            }
            return dp[s.Length, t.Length];
        }
    }
}
