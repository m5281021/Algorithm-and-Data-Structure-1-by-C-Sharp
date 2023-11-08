using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_and_Data_Structure_1
{
    class ALDS1_1_A
    {
        private int n = 0;
        private List<int> list;

        public ALDS1_1_A(int n, List<int> list)
        {
            this.n = n;
            this.list = list;
        }

        public int N
        {
            get { return n; }
            set { n = value; }
        }

        public List<int> List
        {
            get { return list; }
            set { list = value; }
        }

        public void InsertionSort()
        {
            for (int i = 0; i < list.Count; i++)
            {
                var v = list[i];
                var j = i - 1;
                while (j >= 0 && list[j] > v)
                {
                    list[j + 1] = list[j];
                    j--;
                }
                list[j + 1] = v;
                for (int k = 0; k < list.Count; k++)
                {
                    Console.Write(list[k]);
                    if (k != list.Count - 1) Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
    }
}