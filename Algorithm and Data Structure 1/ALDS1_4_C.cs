using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_and_Data_Structure_1
{
    class ALDS1_4_C
    {
        private HashSet<string> hash;

        public ALDS1_4_C()
        {
            hash = new HashSet<string>();
        }

        public HashSet<string> Hash
        {
            get { return hash; }
            set { hash = value; }
        }

        public void Insert(string str)
        {
            hash.Add(str);
        }

        public void Find(string str)
        {
            if (hash.Contains(str)) Console.WriteLine("yes");
            else Console.WriteLine("no");
        }
    }
}
