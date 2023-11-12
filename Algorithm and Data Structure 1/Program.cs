using Algorithm_and_Data_Structure_1;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.ReadLine();
        List<int> list = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
        ALDS1_5_D alds1 = new ALDS1_5_D(list);
        alds1.Print();
    }
}