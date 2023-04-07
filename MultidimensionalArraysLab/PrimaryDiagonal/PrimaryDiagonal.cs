public class PrimaryDiagonal
{
    public static void Main()
    {
        int matrixDimensions = int.Parse(Console.ReadLine());
        int[,] matrix = new int[matrixDimensions, matrixDimensions];

        for (int row = 0; row < matrixDimensions; row++)
        {
            int[] matrixElements = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            for (int col = 0; col < matrixDimensions; col++)
            {
                matrix[row, col] = matrixElements[col];
            }
        }

        int sum = 0;

        for (int i = 0; i < matrixDimensions; i++)
        {
            sum += matrix[i, i];
        }

        Console.WriteLine(sum);
    }
}