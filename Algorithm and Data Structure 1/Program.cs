using Algorithm_and_Data_Structure_1;

internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int[] preorder = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int[] inorder = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        ALDS1_7_D alds1 = new ALDS1_7_D(n, preorder, inorder);
        alds1.Print();
    }
}