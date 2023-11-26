using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_and_Data_Structure_1
{
    class priQueue<T, S> where S : IComparable<S>
    {
        private List<T> buffer;
        private List<S> buffer2;

        public priQueue()
        {
            buffer = new List<T>();
            buffer2 = new List<S>();
        }

        public int Count
        {
            get { return buffer.Count; }
        }

        private void Swap(int i, int j)
        {
            T k = buffer[i];
            buffer[i] = buffer[j];
            buffer[j] = k;
            S l = buffer2[i];
            buffer2[i] = buffer2[j];
            buffer2[j] = l;
        }

        private void DownHeap(int i)
        {
            int l = i * 2 + 1;
            int r = i * 2 + 2;
            int largest = i;
            if (l < buffer2.Count && buffer2[largest].CompareTo(buffer2[l]) > 0) largest = l;
            if (r < buffer2.Count && buffer2[largest].CompareTo(buffer2[r]) > 0) largest = r;
            if (largest != i)
            {
                Swap(i, largest);
                DownHeap(largest);
            }
        }

        private void UpHeap(int i)
        {
            int p = (i - 1) / 2;
            if(p >= 0 && buffer2[i].CompareTo(buffer2[p]) < 0)
            {
                Swap(i, p);
                UpHeap(p);
            }
        }

        public void Enqueue(T t, S s)
        {
            buffer.Add(t);
            buffer2.Add(s);
            UpHeap(buffer.Count - 1);
        }

        public T Dequeue()
        {
            T t = buffer[0];
            buffer[0] = buffer[buffer.Count - 1];
            buffer2[0] = buffer2[buffer2.Count - 1];
            buffer.RemoveAt(buffer.Count - 1);
            buffer2.RemoveAt(buffer2.Count - 1);
            DownHeap(0);
            return t;
        }
    }

    class ALDS1_15_D
    {
        private string s;
        private int[] count;
        private int[] huffman;

        public ALDS1_15_D(string s)
        {
            count = new int[26];
            huffman = new int[26];
            this.s = s;
            Console.WriteLine(Calculate());
        }

        private int Calculate()
        {
            for(int i = 0; i < s.Length; i++)
            {
                count[s[i] - 'a']++;
            }
            priQueue<Tuple<string, int>, int> pq = new priQueue<Tuple<string, int>, int>();
            for(int i = 0; i < count.Length; i++)
            {
                if (count[i] == 0) continue;
                pq.Enqueue(new Tuple<string, int>((char)('a' + i) + "", count[i]), count[i]);
            }
            if(pq.Count == 1)
            {
                return s.Length;
            }
            while(pq.Count > 0)
            {
                Tuple<string, int> left = pq.Dequeue();
                if (pq.Count == 0) break;
                Tuple<string, int> right = pq.Dequeue();
                for (int i = 0; i < left.Item1.Length; i++)
                {
                    huffman[left.Item1[i] - 'a']++;
                }
                for (int i = 0; i < right.Item1.Length; i++)
                {
                    huffman[right.Item1[i] - 'a']++;
                }
                string str = left.Item1 + right.Item1;
                int pri = left.Item2 + right.Item2;
                pq.Enqueue(new Tuple<string, int>(str, pri), pri);
            }
            int sum = 0;
            for(int i = 0; i < s.Length; i++)
            {
                sum += huffman[s[i] - 'a'];
            }
            return sum;
        }
    }
}
