public class PascalTriangle
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        if (n == 1)
        {
            Console.WriteLine(1);
            Environment.Exit(0);
        }

        long[][] pascal = new long[n][];
        pascal[0] = new long[1] { 1 };
        pascal[1] = new long[2] { 1, 1};

        for (int row = 2; row < n; row++)
        {
            pascal[row] = new long[row + 1];
            pascal[row][0] = 1;
            pascal[row][pascal[row].Length - 1] = 1; 

            for (int col = 1; col < pascal[row].Length - 1; col++)
            {
                pascal[row][col] += pascal[row - 1][col - 1] + pascal[row - 1][col];
            }
        }

        for (int i = 0; i < pascal.Length; i++)
        {
            Console.WriteLine(string.Join(" ", pascal[i]));
        }
    }
}