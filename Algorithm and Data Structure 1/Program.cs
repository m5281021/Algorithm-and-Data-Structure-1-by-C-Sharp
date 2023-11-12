using Algorithm_and_Data_Structure_1;

internal class Program
{
    private static void Main(string[] args)
    {
        string[] str = Console.ReadLine().Split(' ');
        int n = int.Parse(str[0]);
        int k = int.Parse(str[1]);
        List<int> list = new List<int>();
        for(int i = 0; i < n; i++)
        {
            list.Add(int.Parse(Console.ReadLine()));
        }
        ALDS1_4_D alds1 = new ALDS1_4_D(n, k, list);
        Console.WriteLine(alds1.Solve());
    }
}