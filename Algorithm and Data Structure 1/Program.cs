using Algorithm_and_Data_Structure_1;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] array = new int[16];
        int x = 0;
        int y = 0;
        for(int i = 0; i < 4; i++)
        {
            int[] line = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            for(int j = 0; j < 4; j++)
            {
                array[i * 4 + j] = line[j];
                if (line[j] == 0)
                {
                    array[i * 4 + j] = 16;
                    x = i;
                    y = j;
                }
            }
        }
        ALDS1_13_C alds1 = new ALDS1_13_C(array, x, y);
    }
}