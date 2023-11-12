using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_and_Data_Structure_1
{
    class ALDS1_6_A
    {
        private int[] list;
        private int[] list2;
        private int[] C = new int[10001];

        public ALDS1_6_A(int[] list)
        {
            this.list = list;
            list2 = new int[list.Length];
        }

        public void CountingSort()
        {
            int max = 0;
            for(int i = 0; i < list.Length; i++)
            {
                max = Math.Max(max, list[i]);
                C[list[i]]++;
            }
            for(int i = 1; i < max + 1; i++)
            {
                C[i] += C[i - 1];
            }
            for(int i = list.Length - 1; i >= 0; i--)
            {
                C[list[i]]--;
                list2[C[list[i]]] = list[i];
            }
            Console.WriteLine(string.Join(" ", list2.Select(x => x.ToString()).ToArray()));
        }
    }
}
