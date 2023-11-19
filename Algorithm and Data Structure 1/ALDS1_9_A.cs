using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_and_Data_Structure_1
{
    class ALDS1_9_A
    {
        private int n = 0;
        private long[] heap;

        public ALDS1_9_A(int n)
        {
            this.n = n;
            heap = new long[n + 1];
            long[] list = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
            for(int i = 0; i < list.Length; i++)
            {
                heap[i + 1] = list[i];
            }
        }

        public void Print()
        {
            for(int i = 1; i < n + 1; i++)
            {
                Console.Write("node {0}: ", i);
                Console.Write("key = {0}, ", heap[i]);
                if (i / 2 > 0) Console.Write("parent key = {0}, ", heap[i / 2]);
                if (i * 2 < n + 1) Console.Write("left key = {0}, ", heap[i * 2]);
                if (i * 2 + 1 < n + 1) Console.Write("right key = {0}, ", heap[i * 2 + 1]);
                Console.WriteLine();
            }
        }
    }
}
