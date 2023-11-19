using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_and_Data_Structure_1
{
    class ALDS1_9_B
    {
        private int n = 0;
        private long[] maxHeap;

        public ALDS1_9_B(int n)
        {
            this.n = n;
            maxHeap = new long[n + 1];
            long[] list = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
            for(int i = 0; i < list.Length; i++)
            {
                maxHeap[i + 1] = list[i];
            }
        }

        private void Swap(int i, int j)
        {
            long k = maxHeap[i];
            maxHeap[i] = maxHeap[j];
            maxHeap[j] = k;
        }

        private void MaxHeapify(int i)
        {
            int l = i * 2;
            int r = i * 2 + 1;
            int largest = i;
            if (l < n + 1 && maxHeap[l] > maxHeap[largest]) largest = l;
            if (r < n + 1 && maxHeap[r] > maxHeap[largest]) largest = r;
            if(largest != i)
            {
                Swap(i, largest);
                MaxHeapify(largest);
            }
        }

        private void BuildMaxHeap()
        {
            for(int i = n / 2; i > 0; i--)
            {
                MaxHeapify(i);
            }
        }

        public void Print()
        {
            BuildMaxHeap();
            for(int i = 1; i < n + 1; i++)
            {
                Console.Write(" {0}", maxHeap[i]);
            }
            Console.WriteLine();
        }
    }
}
