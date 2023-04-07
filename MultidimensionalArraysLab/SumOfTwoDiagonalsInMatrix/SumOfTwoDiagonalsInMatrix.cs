public class SumOfTwoDiagonalsInMatrix
{
    public static void Main()
    {
        int matrixDimensions = int.Parse(Console.ReadLine());
        int[,] matrix = new int[matrixDimensions, matrixDimensions];

        for (int row = 0; row < matrixDimensions; row++)
        {
            for (int col = 0; col < matrixDimensions; col++)
            {
                matrix[row, col] = row + col;
            }
        }

        PrintMatrix(matrix);
        Console.WriteLine();
        PrintFirstDiagonalAndSum(matrix);
        Console.WriteLine();
        PrintSecondtDiagonalAndSum(matrix);
    }

    static void PrintSecondtDiagonalAndSum(int[,] matrix)
    {
        Console.Write("Second Diagonal: ");
        int sum = 0;

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            Console.Write(matrix[i, matrix.GetLength(0) - 1 - i] + " ");
            sum += matrix[i, matrix.GetLength(0) - 1 - i];
        }
        Console.WriteLine();
        Console.WriteLine($"The sum is: {sum}");
    }
    static void PrintFirstDiagonalAndSum(int[,] matrix)
    {
        Console.Write("First Diagonal: ");
        int sum = 0;

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            Console.Write(matrix[i, i] + " ");
            sum += matrix[i, i];
        }
        Console.WriteLine();
        Console.WriteLine($"The sum is: {sum}");
    }
    static void PrintMatrix(int[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (matrix[row, col] < 10)
                {
                    Console.Write(" ");
                }
                Console.Write(matrix[row, col] + " ");
            }
            Console.WriteLine();
        }
    }
}