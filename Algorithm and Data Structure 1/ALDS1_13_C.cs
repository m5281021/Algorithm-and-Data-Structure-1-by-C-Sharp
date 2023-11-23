using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_and_Data_Structure_1
{
    class p
    {
        private int[] numbers;
        private int x;
        private int y;
        private int md;

        public p(int[] numbers, int x, int y)
        {
            this.numbers = numbers;
            this.x = x;
            this.y = y;
        }

        public p(int[] numbers, int x, int y, int md)
        {
            this.numbers = (int[])numbers.Clone();
            this.x = x;
            this.y = y;
            this.md = md;
        }

        public int[] Numbers
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

        public int MD
        {
            get { return md; }
            set { md = value; }
        }

        public void Swap(int a, int b)
        {
            int c = numbers[a];
            numbers[a] = numbers[b];
            numbers[b] = c;
        }

        public static int GetAllMD(p p, int[,] MDT)
        {
            int sum = 0;
            for(int i = 0; i < 16; i++)
            {
                if (p.Numbers[i] == 16) continue;
                sum += MDT[i, p.Numbers[i] - 1];
            }
            return sum;
        }
    }

    class ALDS1_13_C
    {
        private int[] dx = new int[4] { 0, -1, 0, 1 };
        private int[] dy = new int[4] { 1, 0, -1, 0 };
        private char[] dir = new char[4] { 'r', 'd', 'l', 'u' };
        private int[,] MDT;
        private int[] path = new int[100];

        public ALDS1_13_C(int[] arr, int x, int y)
        {
            p init = new p(arr, x, y);
            MDT = new int[16, 16];
            for(int i = 0; i < 16; i++)
            {
                for(int j = 0; j < 16; j++)
                {
                    MDT[i, j] = Math.Abs(i / 4 - j / 4) + Math.Abs(i % 4 - j % 4);
                }
            }
            Console.WriteLine(IterativeDeepening(init).Length);
        }

        private bool DFS(p state, int depth, int prev, int limit)
        {
            if (state.MD == 0)
            {
                return true;
            }
            if (depth + state.MD > limit) return false;
            int x = state.X;
            int y = state.Y;
            for(int i = 0; i < 4; i++)
            {
                int nx = x + dx[i];
                int ny = y + dy[i];
                if (nx < 0 || ny < 0 || nx >= 4 || ny >= 4) continue;
                if (Math.Max(prev, i) - Math.Min(prev, i) == 2) continue;
                p tmp = new p(state.Numbers, state.X, state.Y, state.MD);
                state.MD -= MDT[nx * 4 + ny, state.Numbers[nx * 4 + ny] - 1];
                state.MD += MDT[x * 4 + y, state.Numbers[nx * 4 + ny] - 1];
                state.Swap(nx * 4 + ny, x * 4 + y);
                state.X = nx;
                state.Y = ny;
                if(DFS(state, depth + 1, i, limit))
                {
                    path[depth] = i;
                    return true;
                }
                state = tmp;
            }
            return false;
        }

        private string IterativeDeepening(p init)
        {
            init.MD = p.GetAllMD(init, MDT);

            for(int limit = init.MD; limit < 100; limit++)
            {
                p state = new p(init.Numbers, init.X, init.Y, init.MD);
                if(DFS(state, 0, -100, limit))
                {
                    string ans = "";
                    for(int i = 0; i < limit; i++)
                    {
                        ans += dir[path[i]];
                    }
                    return ans;
                }
            }
            return "unsolvable";
        }
    }
}
