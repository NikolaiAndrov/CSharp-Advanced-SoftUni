public class MatrixShuffling
{
    public static void Main()
    {
        int[] matrixDimensions = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int rows = matrixDimensions[0];
        int cols = matrixDimensions[1];

        string[,] matrix = new string[rows, cols];
        FillMatrix(matrix);

        string input;

        while ((input = Console.ReadLine()) != "END")
        {
            string[] commandInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string command = commandInfo[0];

            if (command != "swap" || commandInfo.Length != 5)
            {
                Console.WriteLine("Invalid input!");
                continue;
            }

            int row1 = int.Parse(commandInfo[1]);
            int col1 = int.Parse(commandInfo[2]);
            int row2 = int.Parse(commandInfo[3]);
            int col2 = int.Parse(commandInfo[4]);

            if (NotValid(matrix, row1, col1, row2, col2))
            {
                Console.WriteLine("Invalid input!");
                continue;
            }

            SwapAndPrintElements(matrix, row1, col1, row2, col2);
        }
    }

    static void SwapAndPrintElements(string[,] matrix, int row1, int col1, int row2, int col2)
    {
        string tempElement = matrix[row1, col1];
        matrix[row1, col1] = matrix[row2, col2];
        matrix[row2, col2] = tempElement;

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write(matrix[row, col] + " ");
            }
            Console.WriteLine();
        }
    }
    static bool NotValid(string[,] matrix, int row1, int col1, int row2, int col2)
    {
        bool notValid = false;

        if (row1 < 0 || row1 >= matrix.GetLength(0) ||
            col1 < 0 || col1 >= matrix.GetLength(1) ||
            row2 < 0 || row2 >= matrix.GetLength(0) ||
            col2 < 0 || col2 >= matrix.GetLength(1))
        {
            notValid = true;
        }

        return notValid;
    }
    static void FillMatrix(string[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            string[] elements = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = elements[col];
            }
        }
    }
}