using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_and_Data_Structure_1
{
    class ALDS1_6_C
    {
        private Tuple<char, int>[] list;
        private Tuple<char, int>[] list2;

        public ALDS1_6_C(Tuple<char, int>[] list)
        {
            this.list = list;
            list2 = (Tuple<char, int>[])list.Clone();
        }

        public Tuple<char, int>[] List
        {
            get { return list; }
            set { list = value; }
        }

        private void Swap(int a, int b)
        {
            Tuple<char, int> c = list[a];
            list[a] = list[b];
            list[b] = c;
        }

        private int Partition(int p, int r)
        {
            Tuple<char, int> x = list[r];
            int i = p;
            for(int j = p; j < r; j++)
            {
                if (list[j].Item2 <= x.Item2)
                {
                    Swap(i, j);
                    i++;
                }
            }
            Swap(i, r);
            return i;
        }

        private void QuickSort(int p, int r)
        {
            if(p < r)
            {
                int q = Partition(p, r);
                QuickSort(p, q - 1);
                QuickSort(q + 1, r);
            }
        }

        private void Merge(int l, int m, int r)
        {
            int L = m - l;
            Tuple<char, int>[] left = new Tuple<char, int>[L + 1];
            for(int i = 0; i < L; i++)
            {
                left[i] = list2[i + l];
            }
            left[L] = new Tuple<char, int>('\0', Int32.MaxValue);
            int R = r - m;
            Tuple<char, int>[] right = new Tuple<char, int>[R + 1];
            for(int i = 0; i < R; i++)
            {
                right[i] = list2[i + m];
            }
            right[R] = new Tuple<char, int>('\0', Int32.MaxValue);
            int j = 0;
            int k = 0;
            for(int i = l; i < r; i++)
            {
                if (left[j].Item2 <= right[k].Item2)
                {
                    list2[i] = left[j];
                    j++;
                }
                else
                {
                    list2[i] = right[k];
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

        public void Print()
        {
            QuickSort(0, list.Length - 1);
            MergeSort(0, list2.Length);
            bool flag = true;
            for(int i = 0; i < list.Length; i++)
            {
                if (list[i] != list2[i]) flag = false;
            }
            if (flag) Console.WriteLine("Stable");
            else Console.WriteLine("Not stable");
            for(int i = 0; i < list.Length; i++)
            {
                Console.WriteLine("{0} {1}", list[i].Item1, list[i].Item2);
            }
        }
    }
}
