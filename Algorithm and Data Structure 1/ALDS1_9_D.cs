using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_and_Data_Structure_1
{
    /*
     * Heap Sort does the following things.
     * 1. making Max Heap.
     * 2. defining Heap Size as N.
     * 3. repeating the following things if the Heap Size is more than 1.
     *      1. swaping the first node with the last node in Heap.
     *      2. decreasing the Heap Size.
     *      3. doing down-heap for the first node.
     * 4. the array is sorted.
     * 
     * reversing the above process to solve this problem.
     * Then, the above down-heap for Max Heap is used.
     * However, in this problem, up-heap for Min Heap is used.
     */
    class ALDS1_9_D
    {
        private int n = 0;
        private long[] heap;

        public ALDS1_9_D(int n)
        {
            this.n = n;
            heap = new long[n + 1];
            long[] list = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
            for(int i = 0; i < list.Length; i++)
            {
                heap[i + 1] = list[i];
            }
        }

        private void Swap(int i, int j)
        {
            long k = heap[i];
            heap[i] = heap[j];
            heap[j] = k;
        }

        private void UpHeap(int i)
        {
            int parent = i / 2;
            if (parent < 1) return;
            if (heap[i] < heap[parent])
            {
                Swap(i, parent);
                UpHeap(parent);
            }
        }

        public void Print()
        {
            Array.Sort(heap, 1, n);
            int size = 1;
            while(size < n)
            {
                UpHeap(size);
                size++;
                Swap(1, size);
            }
            Console.WriteLine(string.Join(" ", heap.Select(x => x.ToString()).ToArray(), 1, n));
        }
    }
}
