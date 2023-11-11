using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_and_Data_Structure_1
{
    class ALDS1_3_B
    {
        private int q = 0;
        private Queue<int> time;
        private Queue<string> name;

        public ALDS1_3_B(int q, List<string> process)
        {
            this.q = q;
            time = new Queue<int>();
            name = new Queue<string>();
            for(int i = 0; i < process.Count; i++)
            {
                time.Enqueue(int.Parse(process[i].Split()[1]));
                name.Enqueue(process[i].Split()[0]);
            }
        }

        public int Q
        {
            get { return q; }
            set { q = value; }
        }

        public Queue<int> Time
        {
            get { return time; }
            set { time = value; }
        }

        public Queue<string> Name
        {
            get { return name; }
            set { name = value; }
        }

        public void Calculate()
        {
            int sum = 0;
            while(time.Count > 0)
            {
                int rest = time.Dequeue();
                string n = name.Dequeue();
                if(rest > q)
                {
                    time.Enqueue(rest - q);
                    name.Enqueue(n);
                    sum += q;
                }
                else
                {
                    sum += rest;
                    Console.WriteLine("{0} {1}", n, sum);
                }
            }
        }
    }
}
