using Algorithm_and_Data_Structure_1;

internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        List<int> list = new List<int>();
        for(int i = 0; i < n; i++)
        {
            list.Add(int.Parse(Console.ReadLine()));
        }
        ALDS1_2_D alds1 = new ALDS1_2_D(n, list);
        alds1.shellSort();
        List<int> g = alds1.G;
        Console.WriteLine(g.Count);
        for(int i = 0; i < g.Count; i++)
        {
            Console.Write(g[i]);
            if (i != g.Count - 1) Console.Write(' ');
        }
        Console.WriteLine();
        Console.WriteLine(alds1.Cnt);
        list.ForEach(i => Console.WriteLine(i));
    }
}