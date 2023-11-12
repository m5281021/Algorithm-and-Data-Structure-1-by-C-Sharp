using Algorithm_and_Data_Structure_1;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.ReadLine();
        int[] list = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        ALDS1_6_A alds1 = new ALDS1_6_A(list);
        alds1.CountingSort();
    }
}