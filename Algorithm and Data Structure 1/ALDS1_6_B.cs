using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_and_Data_Structure_1
{
    class ALDS1_6_B
    {
        private List<int> list;

        public ALDS1_6_B(List<int> list)
        {
            this.list = list;
        }

        public List<int> List
        {
            get { return list; }
            set { list = value; }
        }

        private void Swap(int a, int b)
        {
            int c = list[a];
            list[a] = list[b];
            list[b] = c;
        }

        private int Partition()
        {
            int x = list[list.Count - 1];
            int i = 0;
            for(int j = 0; j < list.Count - 1; j++)
            {
                if(list[j] <= x)
                {
                    Swap(i, j);
                    i++;
                }
            }
            Swap(i, list.Count - 1);
            return i;
        }

        public void Print()
        {
            int r = Partition();
            for(int i = 0; i < list.Count; i++)
            {
                if (i == r) Console.Write("[{0}]", list[i]);
                else Console.Write(list[i]);
                if (i != list.Count - 1) Console.Write(" ");
            }
            Console.WriteLine();
        }
    }
}
