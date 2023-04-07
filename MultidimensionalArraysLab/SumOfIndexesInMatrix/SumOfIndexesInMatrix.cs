public class SumOfIndexesInMatrix
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

        for (int row = 0; row < matrixDimensions; row++)
        {
            for (int col = 0; col < matrixDimensions; col++)
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