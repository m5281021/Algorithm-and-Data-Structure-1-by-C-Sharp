using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_and_Data_Structure_1
{
    class ALDS1_9_C
    {
        private int n = 0;
        private long[] priqueue;

        public ALDS1_9_C()
        {
            priqueue = new long[2000010];
            Execute();
        }

        private void Swap(int i, int j)
        {
            long k = priqueue[i];
            priqueue[i] = priqueue[j];
            priqueue[j] = k;
        }

        private void MaxHeapify(int i)
        {
            int l = i * 2;
            int r = i * 2 + 1;
            int largest = i;
            if (l < n + 1 && priqueue[l] > priqueue[largest]) largest = l;
            if (r < n + 1 && priqueue[r] > priqueue[largest]) largest = r;
            if (largest != i)
            {
                Swap(i, largest);
                MaxHeapify(largest);
            }
        }

        private void BuildMaxHeap()
        {
            for (int i = n / 2; i > 0; i--)
            {
                MaxHeapify(i);
            }
        }

        private void Insert(long l)
        {
            n++;
            priqueue[n] = l;
            int i = n / 2;
            while(i > 0)
            {
                MaxHeapify(i);
                i /= 2;
            }
        }

        private void Extract()
        {
            Swap(1, n);
            Console.WriteLine(priqueue[n]);
            n--;
            MaxHeapify(1);
        }

        private void Execute()
        {
            while(true)
            {
                string[] command = Console.ReadLine().Split(' ');
                if (command[0] == "end") break;
                else if (command[0] == "insert") Insert(long.Parse(command[1]));
                else if (command[0] == "extract") Extract();
            }
        }
    }
}
