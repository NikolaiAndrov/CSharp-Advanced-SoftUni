public class SquareWithMaximumSum
{
    public static void Main()
    {
        int[] matrixDimensions = Console.ReadLine()
            .Split(", ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int rows = matrixDimensions[0];
        int cols = matrixDimensions[1];

        int[,] matrix = new int[rows, cols];

        for (int row = 0; row < rows; row++)
        {
            int[] matrixElements = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            for (int col = 0; col < cols; col++)
            {
                matrix[row, col] = matrixElements[col];
            }
        }

        int maxSum = int.MinValue;
        int row1 = 0;
        int row2 = 0;
        int col1 = 0;
        int col2 = 0;

        for (int row = 0; row < rows - 1; row++)
        {
            for (int col = 0; col < cols - 1; col++)
            {
                int currentSum = 0;
                currentSum += matrix[row, col];
                currentSum += matrix[row, col + 1];
                currentSum += matrix[row + 1, col];
                currentSum += matrix[row + 1, col + 1];

                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                    row1 = row;
                    row2 = row + 1;
                    col1 = col;
                    col2 = col + 1;
                }
            }
        }

        Console.Write(matrix[row1, col1] + " ");
        Console.WriteLine(matrix[row1, col2]);
        Console.Write(matrix[row2, col1] + " ");
        Console.WriteLine(matrix[row2, col2]);
        Console.WriteLine(maxSum);
    }
}