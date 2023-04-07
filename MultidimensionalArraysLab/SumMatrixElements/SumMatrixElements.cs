public class SumMatrixElements
{
    public static void Main()
    {
        int[,] matrix = ReaMatrixFromConsole();
        int sum = GetMatrixSum(matrix);
        Console.WriteLine(matrix.GetLength(0));
        Console.WriteLine(matrix.GetLength(1));
        Console.WriteLine(sum);
    }

    static int[,] ReaMatrixFromConsole()
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

        return matrix;
    }
    static int GetMatrixSum(int[,] matrix)
    {
        int sum = 0;

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                sum += matrix[row, col];
            }
        }

        return sum;
    }
}