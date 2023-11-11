using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_and_Data_Structure_1
{
    class ALDS1_3_A
    {
        private Stack<int> stack = new Stack<int>();
        private List<string> list;

        public ALDS1_3_A(List<string> list)
        {
            this.list = list;
        }

        public Stack<int> Stack
        {
            get { return stack; }
            set { stack = value; }
        }

        public List<string> List
        {
            get { return list; }
            set { list = value; }
        }

        public int Calculate()
        {
            for(int i = 0; i < list.Count; i++)
            {
                if (list[i] == "+")
                {
                    int a = stack.Pop();
                    int b = stack.Pop();
                    stack.Push(b + a);
                }
                else if (list[i] == "-")
                {
                    int a = stack.Pop();
                    int b = stack.Pop();
                    stack.Push(b - a);
                }
                else if (list[i] == "*")
                {
                    int a = stack.Pop();
                    int b = stack.Pop();
                    stack.Push(b * a);
                }
                else
                {
                    stack.Push(int.Parse(list[i]));
                }
            }
            return stack.Pop();
        }
    }
}
