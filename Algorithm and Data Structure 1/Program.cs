using Algorithm_and_Data_Structure_1;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] line = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        ALDS1_11_D alds1 = new ALDS1_11_D(line[0], line[1]);
        int n = int.Parse(Console.ReadLine());
        alds1.Answer(n);
    }
}