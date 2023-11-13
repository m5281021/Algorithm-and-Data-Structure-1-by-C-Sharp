using Algorithm_and_Data_Structure_1;

internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int[] a = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        ALDS1_6_D alds1 = new ALDS1_6_D(a);
        Console.WriteLine(alds1.MinimumCostSort());
    }
}