using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_and_Data_Structure_1
{
    class ALDS1_6_D
    {
        private int[] a;
        private int[] b;
        private int min;
        private int[] t;
        private bool[] v;

        public ALDS1_6_D(int[] a)
        {
            this.a = a;
            b = new int[a.Length];
            min = 100000;
            t = new int[10001];
            v = new bool[a.Length];
        }

        private void Merge(int l, int m, int r)
        {
            int L = m - l;
            int[] left = new int[L + 1];
            for(int i = 0; i < L; i++)
            {
                left[i] = b[i + l];
            }
            left[L] = Int32.MaxValue;
            int R = r - m;
            int[] right = new int[R + 1];
            for(int i = 0; i < R; i++)
            {
                right[i] = b[i + m];
            }
            right[R] = Int32.MaxValue;
            int j = 0;
            int k = 0;
            for(int i = l; i < r; i++)
            {
                if (left[j] <= right[k])
                {
                    b[i] = left[j];
                    j++;
                }
                else
                {
                    b[i] = right[k];
                    k++;
                }
            }
        }

        private void MergeSort(int l, int r)
        {
            if(l + 1 < r)
            {
                int m = (l + r) / 2;
                MergeSort(l, m);
                MergeSort(m, r);
                Merge(l, m, r);
            }
        }

        public int MinimumCostSort()
        {
            for(int i = 0; i < a.Length; i++)
            {
                b[i] = a[i];
                min = Math.Min(min, a[i]);
                v[i] = false;
            }
            MergeSort(0, b.Length);
            for(int i = 0; i < b.Length; i++)
            {
                t[b[i]] = i;
            }
            int answer = 0;
            for(int i = 0; i < a.Length; i++)
            {
                if (v[i]) continue;
                int cur = i;
                int sum = 0;
                int m = 10000;
                int n = 0;
                while(true)
                {
                    v[cur] = true;
                    n++;
                    int x = a[cur];
                    m = Math.Min(m, x);
                    sum += x;
                    cur = t[x];
                    if (v[cur]) break;
                }
                answer += Math.Min(sum + (n - 2) * m, sum + m + min * (n + 1));
            }
            return answer;
        }
    }
}
