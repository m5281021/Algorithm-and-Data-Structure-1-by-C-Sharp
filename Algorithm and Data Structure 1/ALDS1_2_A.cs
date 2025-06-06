﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_and_Data_Structure_1
{
    class ALDS1_2_A
    {
        private int n = 0;
        private List<int> list;
        private int count = 0;

        public ALDS1_2_A(int n, List<int> list)
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

        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        private void Swap(int a, int b)
        {
            int c = list[a];
            list[a] = list[b];
            list[b] = c;
            count++;
        }

        public void BubbleSort()
        {
            for(int i = 1; i < list.Count; i++)
            {
                for(int j = list.Count - 1; j >= i; j--)
                {
                    if (list[j] < list[j - 1])
                    {
                        Swap(j, j - 1);
                    }
                }
            }
        }
    }
}
