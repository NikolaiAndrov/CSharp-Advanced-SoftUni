public class SquaresInMatrix
{
    public static void Main()
    {
        int[] matrixDimensions = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int rows = matrixDimensions[0];
        int cols = matrixDimensions[1];
        char[,] matrix = new char[rows, cols];

        FillMatrix(matrix);
        int equalSquaresCount = GetEqualSquaresCount(matrix);
        Console.WriteLine(equalSquaresCount);
    }

    static int GetEqualSquaresCount(char[,] matrix)
    {
        int count = 0;

        for (int row = 0; row < matrix.GetLength(0) - 1; row++)
        {
            for (int col = 0; col < matrix.GetLength(1) - 1; col++)
            {
                if (matrix[row, col] == matrix[row, col + 1] &&
                    matrix[row, col] == matrix[row + 1, col] &&
                    matrix[row, col] == matrix[row + 1, col + 1])
                {
                    count++;
                }
            }
        }

        return count;
    }
    static void FillMatrix(char[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            char[] elements = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse)
                .ToArray();

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = elements[col];
            }
        }
    }
}