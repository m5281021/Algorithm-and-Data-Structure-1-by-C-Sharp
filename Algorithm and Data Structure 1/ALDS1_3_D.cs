using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_and_Data_Structure_1
{
    class ALDS1_3_D
    {
        private string str;
        private Stack<int> stack;
        private Stack<(int, int)> area;

        public ALDS1_3_D(string str)
        {
            this.str = str;
            stack = new Stack<int>();
            area = new Stack<(int, int)>();
        }

        public Stack<int> Stack
        {
            get { return stack; }
            set { stack = value; }
        }

        public Stack<(int, int)> Area
        {
            get { return area; }
            set { area = value; }
        }

        public void Calculate()
        {
            for(int i = 0; i < str.Length; i++)
            {
                if (str[i] == '\\')
                {
                    stack.Push(i);
                }
                else if (str[i] == '/' && stack.Count > 0)
                {
                    int j = stack.Pop();
                    int a = i - j;
                    while(Area.Count > 0 && Area.Peek().Item1 > j)
                    {
                        a += Area.Peek().Item2;
                        Area.Pop();
                    }
                    var t = (j, a);
                    Area.Push(t);
                }
            }
            int sum = 0;
            string output = "";
            foreach(var v in area)
            {
                sum += v.Item2;
                output = " " + v.Item2 + output;
            }
            output = area.Count() + output;
            Console.WriteLine(sum);
            Console.WriteLine(output);

        }
    }
}
