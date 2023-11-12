using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_and_Data_Structure_1
{
    class ALDS1_5_B
    {
        private List<int> list;
        private int cnt = 0;

        public ALDS1_5_B(List<int> list)
        {
            this.list = list;
        }

        public List<int> List
        {
            get { return list; }
            set { list = value; }
        }

        public int Count
        {
            get { return cnt; }
            set { cnt = value; }
        }

        public void Merge(int l, int m, int r)
        {
            int L = m - l;
            List<int> left = new List<int>();
            for(int i = 0; i < L; i++)
            {
                left.Add(list[i + l]);
            }
            left.Add(Int32.MaxValue);
            int R = r - m;
            List<int> right = new List<int>();
            for(int i = 0; i < R; i++)
            {
                right.Add(list[i + m]);
            }
            right.Add(Int32.MaxValue);
            int j = 0;
            int k = 0;
            for(int i = l; i < r; i++)
            {
                cnt++;
                if (left[j] < right[k])
                {
                    list[i] = left[j];
                    j++;
                }
                else
                {
                    list[i] = right[k];
                    k++;
                }
            }
        }

        public void MergeSort(int l, int r)
        {
            if(l + 1 < r)
            {
                int m = (l + r) / 2;
                MergeSort(l, m);
                MergeSort(m, r);
                Merge(l, m, r);
            }
        }

        public void Print()
        {
            MergeSort(0, list.Count);
            for(int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i]);
                if (i != list.Count - 1) Console.Write(" ");
            }
            Console.WriteLine();
            Console.WriteLine(cnt);
        }
    }
}
