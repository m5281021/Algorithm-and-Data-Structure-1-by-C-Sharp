using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_and_Data_Structure_1
{
    class ALDS1_14_B
    {
        private const long b = 10000007;
        private string s;
        private string t;

        public ALDS1_14_B(string s, string t)
        {
            this.s = s;
            this.t = t;
            Calculate();
        }

        private void Calculate()
        {
            int[] ans = new int[s.Length];
            int len = 0;
            if (s.Length < t.Length) return;
            long pow = 1;
            long sh = 0;
            long th = 0;
            for (int i = 0; i < t.Length; i++)
            {
                pow *= b;
                sh = sh * b + s[i];
                th = th * b + t[i];
            }
            for (int i = 0; i < s.Length + 1 - t.Length; i++)
            {
                if (sh == th) ans[len++] = i;
                if (i + t.Length < s.Length) sh = sh * b + s[i + t.Length] - pow * s[i];
            }
            if (len == 0) return;
            Console.WriteLine(string.Join("\n", ans.Select(x => x.ToString()).ToArray(), 0, len));
        }
    }
}
