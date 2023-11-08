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
        ALDS1_1_D alds1 = new ALDS1_1_D(n, list);
        Console.WriteLine(alds1.MaximumProfit());
    }
}