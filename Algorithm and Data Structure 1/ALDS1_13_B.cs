using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_and_Data_Structure_1
{
    class puzzle
    {
        private string numbers;
        private int x;
        private int y;
        private int step;

        public puzzle(string numbers, int x, int y, int step)
        {
            this.numbers = numbers;
            this.x = x;
            this.y = y;
            this.step = step;
        }

        public string Numbers
        {
            get { return numbers; }
            set { numbers = value; }
        }

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public int Step
        {
            get { return step; }
            set { step = value; }
        }

        public void Swap(int x, int y, int nx, int ny)
        {
            int[] num = new int[9];
            for(int i = 0; i < 9; i++)
            {
                num[i] = numbers[i] - '0';
            }
            num[x * 3 + y] = num[nx * 3 + ny];
            num[nx * 3 + ny] = 0;
            numbers = string.Join("", num.Select(arr => arr.ToString()).ToArray());
        }
    }

    class ALDS1_13_B
    {
        private int[] dx = new int[4] { -1, 0, 1, 0 };
        private int[] dy = new int[4] { 0, -1, 0, 1 };

        public ALDS1_13_B(string init, int x, int y)
        {
            puzzle p = new puzzle(init, x, y, 0);
            Console.WriteLine(BFS(p));
        }

        private int BFS(puzzle s)
        {
            Queue<puzzle> queue = new Queue<puzzle>();
            HashSet<string> set = new HashSet<string>();
            queue.Enqueue(s);
            set.Add(s.Numbers);
            while(queue.Count > 0)
            {
                puzzle p = queue.Dequeue();
                if (p.Numbers == "123456780") return p.Step;
                int x = p.X;
                int y = p.Y;
                for(int i = 0; i < 4; i++)
                {
                    int nx = x + dx[i];
                    int ny = y + dy[i];
                    if (nx < 0 || ny < 0 || nx >= 3 || ny >= 3) continue;
                    puzzle q = new puzzle(p.Numbers, nx, ny, p.Step + 1);
                    q.Swap(x, y, nx, ny);
                    if(!set.Contains(q.Numbers))
                    {
                        set.Add(q.Numbers);
                        queue.Enqueue(q);
                    }
                }
            }
            return -1;
        }
    }
}
