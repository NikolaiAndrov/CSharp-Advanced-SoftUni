public class SymbolInMatrix
{
    public static void Main()
    {
        int matrixDimensions = int.Parse(Console.ReadLine());
        char[,] matrix = new char[matrixDimensions, matrixDimensions];

        for (int row = 0; row < matrixDimensions; row++)
        {
            string matrixElements = Console.ReadLine();
                
            for (int col = 0; col < matrixDimensions; col++)
            {
                matrix[row, col] = (char)matrixElements[col];
            }
        }

        char elementNeeded = char.Parse(Console.ReadLine());

        for (int row = 0; row < matrixDimensions; row++)
        {
            for (int col = 0; col < matrixDimensions; col++)
            {
                if (matrix[row, col] == elementNeeded)
                {
                    Console.WriteLine($"({row}, {col})");
                    Environment.Exit(0);
                }
            }
        }

        Console.WriteLine($"{elementNeeded} does not occur in the matrix");
    }
}