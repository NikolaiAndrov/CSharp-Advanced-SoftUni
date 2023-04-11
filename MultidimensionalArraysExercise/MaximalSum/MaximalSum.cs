public class MaximalSum
{
    public static void Main()
    {
        int[] matrixDimensions = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int rows = matrixDimensions[0];
        int cols = matrixDimensions[1];

        int[,] matrix = new int[rows, cols];
        FillMatrix(matrix);
        PrintBiggestSquareAndSum(matrix);
    }

    static void PrintBiggestSquareAndSum(int[,] matrix)
    {
        int maxSum = int.MinValue;
        int bigestRow = 0;
        int bigestCol = 0;

        for (int row = 0; row < matrix.GetLength(0) - 2; row++)
        {
            for (int col = 0; col < matrix.GetLength(1) - 2 ; col++)
            {
                int currentSum = 0;

                currentSum += matrix[row, col];
                currentSum += matrix[row, col + 1];
                currentSum += matrix[row, col + 2];
                currentSum += matrix[row + 1, col];
                currentSum += matrix[row + 1, col + 1];
                currentSum += matrix[row + 1, col + 2];
                currentSum += matrix[row + 2, col];
                currentSum += matrix[row + 2, col + 1];
                currentSum += matrix[row + 2, col + 2];

                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                    bigestRow = row;
                    bigestCol = col;
                }
            }
        }

        Console.WriteLine($"Sum = {maxSum}");

        for (int row = bigestRow; row < bigestRow + 3; row++)
        {
            for (int col = bigestCol; col < bigestCol + 3; col++)
            {
                Console.Write(matrix[row, col] + " ");
            }
            Console.WriteLine();
        }
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
                matrix[row, col] = elements[col];
            }
        }
    }
}