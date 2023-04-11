public class DiagonalDifference
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[,] matrix = new int[n,n];
        FillMatrix(matrix);
        int absValue = GetAbsoluteValue(matrix);
        Console.WriteLine(absValue);
    }

    static int GetAbsoluteValue(int[,] matrix)
    {
        int primaryDiagonal = 0;
        int secondaryDiagonalSum = 0;

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            primaryDiagonal += matrix[i, i];
            secondaryDiagonalSum += matrix[i, matrix.GetLength(1) - 1 - i];
        }

        return Math.Abs(primaryDiagonal - secondaryDiagonalSum);
    }
    static void FillMatrix(int[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            int[] elements = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row,col] = elements[col];
            }
        }
    }
}