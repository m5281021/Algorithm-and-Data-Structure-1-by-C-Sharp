using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_and_Data_Structure_1
{
    class ALDS1_3_C
    {
        private int n = 0;
        private ALDS1_3_C pre;
        private ALDS1_3_C next;

        public ALDS1_3_C()
        {
            n = 0;
            pre = this;
            next = this;
        }

        public ALDS1_3_C(int n, ALDS1_3_C pre, ALDS1_3_C next)
        {
            this.n = n;
            this.pre = pre;
            this.next = next;
        }

        public int N
        {
            get { return n; }
            set { n = value; }
        }

        public ALDS1_3_C Pre
        {
            get { return pre; }
            set { pre = value; }
        }

        public ALDS1_3_C Next
        {
            get { return next; }
            set { next = value; }
        }

        public void Print()
        {
            for(ALDS1_3_C alds1 = next; alds1 != this; alds1 = alds1.Next)
            {
                Console.Write(alds1.N);
                if (alds1.Next != this) Console.Write(" ");
            }
            Console.WriteLine();
        }

        public void Insert(int a)
        {
            ALDS1_3_C alds1 = new ALDS1_3_C(a, this, next);
            next.Pre = alds1;
            next = alds1;
        }

        public void Delete(int a)
        {
            for(ALDS1_3_C alds1 = next; alds1 != this; alds1 = alds1.Next)
            {
                if(alds1.N == a)
                {
                    alds1.Next.Pre = alds1.Pre;
                    alds1.Pre.Next = alds1.Next;
                    break;
                }
            }
        }

        public void DeleteFirst()
        {
            next.Next.Pre = this;
            next = next.Next;
        }

        public void DeleteLast()
        {
            pre.Pre.Next = this;
            pre = pre.Pre;
        }
    }
}
