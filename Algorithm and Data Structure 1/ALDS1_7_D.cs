using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_and_Data_Structure_1
{
    class createdNode
    {
        private int n;
        private int parent;
        private int left;
        private int right;

        public createdNode(int n)
        {
            this.n = n;
            parent = -1;
            left = -1;
            right = -1;
        }

        public int N
        {
            get { return n; }
            set { n = value; }
        }

        public int Parent
        {
            get { return parent; }
            set { parent = value; }
        }

        public int Left
        {
            get { return left; }
            set { left = value; }
        }

        public int Right
        {
            get { return right; }
            set { right = value; }
        }
    }
    class ALDS1_7_D
    {
        private int n = 0;
        private int p = 0;
        private int[] preorder;
        private int[] inorder;
        private string[] postorder;
        private createdNode[] nodes;

        public ALDS1_7_D(int n, int[] preorder, int[] inorder)
        {
            this.n = n;
            this.preorder = preorder;
            this.inorder = inorder;
            postorder = new string[n];
            nodes = new createdNode[41];
            for (int i = 0; i < nodes.Length; i++)
            {
                nodes[i] = new createdNode(i);
            }
        }

        public int N
        {
            get { return n; }
            set { n = value; }
        }

        public int[] Preorder
        {
            get { return preorder; }
            set { preorder = value; }
        }

        public int[] Inorder
        {
            get { return inorder; }
            set { inorder = value; }
        }

        public string[] Postorder
        {
            get { return postorder; }
            set { postorder = value; }
        }

        public createdNode[] Nodes
        {
            get { return nodes; }
            set { nodes = value; }
        }

        private int CreateNode(int cur, int left, int right)
        {
            if (cur == n) return n;
            int partition = -1;
            for(int i = left; i < right; i++)
            {
                if (preorder[cur] == inorder[i])
                {
                    partition = i;
                    break;
                }
            }
            bool flag = false;
            int next = cur + 1;
            if (next == n) return n;
            for(int i = left; i < partition; i++)
            {
                if (preorder[next] == inorder[i])
                {
                    flag = true;
                    break;
                }
            }
            if(flag)
            {
                nodes[preorder[cur]].Left = preorder[next];
                nodes[preorder[next]].Parent = preorder[cur];
                next = CreateNode(next, left, partition);
            }
            if (next == n) return n;
            flag = false;
            for(int i = partition + 1; i < right; i++)
            {
                if (preorder[next] == inorder[i])
                {
                    flag = true;
                    break;
                }
            }
            if(flag)
            {
                nodes[preorder[cur]].Right = preorder[next];
                nodes[preorder[next]].Parent = preorder[cur];
                next = CreateNode(next, partition, right);
            }
            return next;
        }

        private void PostorderTreeWalk(int cur)
        {
            if (nodes[cur].Left != -1) PostorderTreeWalk(nodes[cur].Left);
            if (nodes[cur].Right != -1) PostorderTreeWalk(nodes[cur].Right);
            postorder[p++] = nodes[cur].N.ToString();
        }

        public void Print()
        {
            CreateNode(0, 0, n);
            PostorderTreeWalk(preorder[0]);
            Console.WriteLine(string.Join(" ", postorder));
        }
    }
}
