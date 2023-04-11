public class SnakeMoves
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
        PrintMatrix(matrix);
    }

    static void PrintMatrix(char[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write(matrix[row, col]);
            }
            Console.WriteLine();
        }
    }
    static void FillMatrix(char[,] matrix)
    {
        string snake = Console.ReadLine();

        int i = 0;

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (row % 2 == 0)
                {
                    matrix[row, col] = snake[i];
                    i++;

                    if (i == snake.Length)
                    {
                        i = 0;
                    }
                }
                else if (row % 2 != 0)
                {
                    matrix[row, matrix.GetLength(1) - 1 - col] = snake[i];
                    i++;

                    if (i == snake.Length)
                    {
                        i = 0;
                    }
                }
            }
        }
    }
}