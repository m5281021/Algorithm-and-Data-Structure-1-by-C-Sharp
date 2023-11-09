using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_and_Data_Structure_1
{
    class ALDS1_2_C
    {
        private int n = 0;
        private List<string> list1;
        private List<string> list2;
        
        public ALDS1_2_C(int n, List<string> list1, List<string> list2)
        {
            this.n = n;
            this.list1 = list1;
            this.list2 = list2;
        }

        public int N
        {
            get { return n; }
            set { n = value; }
        }

        public List<string> List1
        {
            get { return list1; }
            set { list1 = value; }
        }

        public List<string> List2
        {
            get { return list2; }
            set { list2 = value; }
        }

        private void Swap(List<string> list, int a, int b)
        {
            string str = list[a];
            list[a] = list[b];
            list[b] = str;
        }

        public void BubbleSort()
        {
            for(int i = 1; i < list1.Count; i++)
            {
                for(int j = list1.Count - 1; j >= i; j--)
                {
                    if ((int)Char.GetNumericValue(list1[j][1]) < (int)Char.GetNumericValue(list1[j - 1][1]))
                    {
                        Swap(list1, j, j - 1);
                    }
                }
            }
        }

        public void SelectionSort()
        {
            for (int i = 0; i < list2.Count - 1; i++)
            {
                int mini = i;
                for (int j = i; j < list2.Count; j++)
                {
                    if ((int)Char.GetNumericValue(list2[mini][1]) > (int)Char.GetNumericValue(list2[j][1])) mini = j;
                }
                if (mini != i) Swap(list2, mini, i);
            }
        }

        public void Judge(List<string> list)
        {
            bool flag = true;
            for(int i = 0; i < n; i++)
            {
                if (list1[i] != list[i]) flag = false;
            }
            if (flag) Console.WriteLine("Stable");
            else Console.WriteLine("Not stable");
        }
    }
}
