public class SumMatrixColumns
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
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            for (int col = 0; col < cols; col++)
            {
                matrix[row, col] = matrixElements[col];
            }
        }

        for (int col = 0; col < cols; col++)
        {
            int sum = 0;

            for (int row = 0; row < rows; row++)
            {
                sum += matrix[row, col];
            }

            Console.WriteLine(sum);
        }
    }
}