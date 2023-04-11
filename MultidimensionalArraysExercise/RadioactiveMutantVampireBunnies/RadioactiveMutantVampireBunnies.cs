public class RadioactiveMutantVampireBunnies
{
    public static void Main()
    {
        int[] dimensions = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int rows = dimensions[0];
        int cols = dimensions[1];
        char[,] matrix = new char[rows, cols];
        
        int startingRow = 0;
        int startingCol = 0;

        for (int row = 0; row < rows; row++)
        {
            string elements = Console.ReadLine();

            for (int col = 0; col < cols; col++)
            {
                matrix[row, col] = elements[col];

                if (elements[col] == 'P')
                {
                    startingRow = row;
                    startingCol = col;
                }
            }
        }

        string commands = Console.ReadLine();

        bool playerWins = false;
        bool playerDies = false;

        foreach (var command in commands)
        {
            int row = 0;
            int col = 0;

            if (command == 'L')
            {
                col = -1;
            }
            else if (command == 'R')
            {
                col = 1;
            }
            else if (command == 'U')
            {
                row = -1;
            }
            else if (command == 'D')
            {
                row = 1;
            }

            if (startingRow + row < 0 ||
                startingRow + row >= matrix.GetLength(0) ||
                startingCol + col < 0 ||
                startingCol + col >= matrix.GetLength(1))
            {
                playerWins = true;
                matrix[startingRow, startingCol] = '.';
                SpreadOrKill(matrix);
                break;
            }

            matrix[startingRow, startingCol] = '.';
            startingRow += row;
            startingCol += col;

            if (matrix[startingRow, startingCol] == 'B')
            {
                playerDies = true;
                SpreadOrKill(matrix);
                break;
            }
            else
            {
                matrix[startingRow, startingCol] = 'P';
            }

            if (SpreadOrKill(matrix))
            {
                playerDies = true;
                break;
            }
            
        }

        if (playerWins)
        {
            PrintMatrix(matrix);
            Console.WriteLine($"won: {startingRow} {startingCol}");
        }
        else
        {
            PrintMatrix(matrix);
            Console.WriteLine($"dead: {startingRow} {startingCol}");
        }
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
    static bool SpreadOrKill(char[,] matrix)
    {
        bool isDead = false;
        List<int[]> bunnyIndexes = new List<int[]>();

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (matrix[row, col] == 'B')
                {
                    bunnyIndexes.Add(new int[] {row, col});
                }
            }
        }

        foreach (var bunny in bunnyIndexes)
        {
            int bunnyRow = bunny[0];
            int bunnyCol = bunny[1];

            //up
            if (IsValid(matrix, bunnyRow - 1, bunnyCol))
            {
                if (matrix[bunnyRow - 1, bunnyCol] == 'P')
                {
                    isDead = true;
                }

                matrix[bunnyRow - 1, bunnyCol] = 'B';
            }

            //down
            if (IsValid(matrix, bunnyRow + 1, bunnyCol))
            {
                if (matrix[bunnyRow + 1, bunnyCol] == 'P')
                {
                    isDead = true;
                }

                matrix[bunnyRow + 1, bunnyCol] = 'B';
            }

            //right
            if (IsValid(matrix, bunnyRow, bunnyCol + 1))
            {
                if (matrix[bunnyRow, bunnyCol + 1] == 'P')
                {
                    isDead = true;
                }

                matrix[bunnyRow, bunnyCol + 1] = 'B';
            }

            //left
            if (IsValid(matrix, bunnyRow, bunnyCol - 1))
            {
                if (matrix[bunnyRow, bunnyCol - 1] == 'P')
                {
                    isDead = true;
                }

                matrix[bunnyRow, bunnyCol - 1] = 'B';
            }
        }

        return isDead;
    }

    static bool IsValid(char[,] matrix, int row, int col)
    {
        return row >= 0 && col >= 0 &&
            row < matrix.GetLength(0) &&
            col < matrix.GetLength(1);
    }
}