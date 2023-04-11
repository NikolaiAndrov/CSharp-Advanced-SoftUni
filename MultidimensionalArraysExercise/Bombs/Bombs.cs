public class Bombs
{
    public static void Main()
    {
        int size = int.Parse(Console.ReadLine());
        int[,] bombs = new int[size, size];
        FillMatrix(bombs);
        DetonateBombs(bombs);
        PrintAliveCellsAndSum(bombs);
        PrintBombs(bombs);
    }

    static void PrintBombs(int[,] bombs)
    {
        for (int row = 0; row < bombs.GetLength(0); row++)
        {
            for (int col = 0; col < bombs.GetLength(1); col++)
            {
                Console.Write(bombs[row, col] + " ");
            }
            Console.WriteLine();
        }
    }
    static void PrintAliveCellsAndSum(int[,] bombs)
    {
        int cells = 0;
        int sum = 0;

        for (int row = 0; row < bombs.GetLength(0); row++)
        {
            for (int col = 0; col < bombs.GetLength(1); col++)
            {
                if (bombs[row, col] > 0)
                {
                    cells++;
                    sum += bombs[row, col];
                }
            }
        }

        Console.WriteLine($"Alive cells: {cells}");
        Console.WriteLine($"Sum: {sum}");
    }
    static void DetonateBombs(int[,] bombs)
    {
        int[] bombsCoordinates = Console.ReadLine()
            .Split(new char[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        for (int i = 0; i < bombsCoordinates.Length; i+=2)
        {
            int bombRow = bombsCoordinates[i];
            int bombCol = bombsCoordinates[i+1];

            if (bombs[bombRow, bombCol] <= 0)
            {
                continue;
            }

            if (IsValid(bombs, bombRow - 1, bombCol - 1))
            {
                bombs[bombRow - 1, bombCol - 1] -= bombs[bombRow, bombCol];
            }

            if (IsValid(bombs, bombRow - 1, bombCol))
            {
                bombs[bombRow - 1, bombCol] -= bombs[bombRow, bombCol];
            }

            if (IsValid(bombs, bombRow - 1, bombCol + 1))
            {
                bombs[bombRow - 1, bombCol + 1] -= bombs[bombRow, bombCol];
            }

            if (IsValid(bombs, bombRow, bombCol - 1))
            {
                bombs[bombRow, bombCol - 1] -= bombs[bombRow, bombCol];
            }

            if (IsValid(bombs, bombRow, bombCol + 1))
            {
                bombs[bombRow, bombCol + 1] -= bombs[bombRow, bombCol];
            }

            if (IsValid(bombs, bombRow + 1, bombCol - 1))
            {
                bombs[bombRow + 1, bombCol - 1] -= bombs[bombRow, bombCol];
            }

            if (IsValid(bombs, bombRow + 1, bombCol))
            {
                bombs[bombRow + 1, bombCol] -= bombs[bombRow, bombCol];
            }

            if (IsValid(bombs, bombRow + 1, bombCol + 1))
            {
                bombs[bombRow + 1, bombCol + 1] -= bombs[bombRow, bombCol];
            }

            bombs[bombRow, bombCol] = 0;
        }
    }
    static bool IsValid(int[,] bombs, int row, int col)
    {
        return row >= 0 && col >= 0 && 
            row < bombs.GetLength(0) &&
            col < bombs.GetLength(1) &&
            bombs[row, col] > 0;
    }
    static void FillMatrix(int[,] bombs)
    {
        for (int row = 0; row < bombs.GetLength(0); row++)
        {
            int[] items = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            for (int col = 0; col < bombs.GetLength(1); col++)
            {
                bombs[row, col] = items[col];
            }
        }
    }
}