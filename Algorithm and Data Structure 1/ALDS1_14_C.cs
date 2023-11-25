using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_and_Data_Structure_1
{
    class ALDS1_14_C
    {
        private const long b = 10000007;
        private string[] s;
        private string[] t;
        private int h = 0;
        private int w = 0;
        private int r = 0;
        private int c = 0;

        public ALDS1_14_C(string[] s, string[] t, int h, int w, int r, int c)
        {
            this.s = s;
            this.t = t;
            this.h = h;
            this.w = w;
            this.r = r;
            this.c = c;
            Calculate();
        }

        private void Calculate()
        {
            string[] ans = new string[(h + 1 - r) * (w + 1 - c)];
            int len = 0;
            if (h < r || w < c) return;
            long pow = 1;
            long[] sh = new long[r];
            long[] sbh = new long[h];
            long[] th = new long[r];
            for (int i = 0; i < c; i++)
            {
                pow *= b;
                for(int j = 0; j < r; j++)
                {
                    sh[j] = sh[j] * b + s[j][i];
                    sbh[j] = sbh[j] * b + s[j][i];
                    th[j] = th[j] * b + t[j][i];
                }
                for(int j = r; j < h; j++)
                {
                    sbh[j] = sbh[j] * b + s[j][i];
                }
            }
            for (int i = 0; i < h + 1 - r; i++)
            {
                for (int j = 0; j < w + 1 - c; j++)
                {
                    bool flag = true;
                    for(int k = 0; k < r; k++)
                    {
                        if (sh[k] != th[k]) flag = false;
                        if (j + c < w) sh[k] = sh[k] * b + s[i + k][j + c] - pow * s[i + k][j];
                    }
                    if (flag) ans[len++] = new string(i.ToString() + " " + j.ToString());
                }
                if(i + r < h)
                {
                    for(int j = 0; j < r; j++)
                    {
                        sh[j] = sbh[i + 1 + j];
                    }
                }
            }
            if (len == 0) return;
            Console.WriteLine(string.Join("\n", ans, 0, len));
        }
    }
}
