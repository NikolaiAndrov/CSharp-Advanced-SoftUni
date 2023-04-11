public class Miner
{
    public static void Main()
    {
        int size = int.Parse(Console.ReadLine());
        char[,] field = new char[size,size];
        string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

        int coals = 0;
        int startRow = 0;
        int startCol = 0;

        for (int row = 0; row < field.GetLength(0); row++)
        {
            char[] elements = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse)
                .ToArray();

            for (int col = 0; col < field.GetLength(1); col++)
            {
                field[row, col] = elements[col];

                if (elements[col] == 'c')
                {
                    coals++;
                }
                else if (elements[col] == 's')
                {
                    startRow = row;
                    startCol = col;
                }
            }
        }

        foreach (var command in commands)
        {
            int row = 0;
            int col = 0;

            if (command == "left")
            {
                col = -1;
            }
            else if (command == "right")
            {
                col = 1;
            }
            else if (command == "up")
            {
                row = -1;
            }
            else if (command == "down")
            {
                row = 1;
            }

            if (NotValid(field, startRow + row, startCol + col))
            {
                continue;
            }

            startRow += row;
            startCol += col;

            if (field[startRow, startCol] == '*')
            {
                continue;
            }
            else if (field[startRow, startCol] == 'e')
            {
                Console.WriteLine($"Game over! ({startRow}, {startCol})");
                Environment.Exit(0);
            }
            else if (field[startRow, startCol] == 'c')
            {
                field[startRow, startCol] = '*';
                coals--;

                if (coals == 0)
                {
                    Console.WriteLine($"You collected all coals! ({startRow}, {startCol})");
                    Environment.Exit(0);
                }
            }
        }

        Console.WriteLine($"{coals} coals left. ({startRow}, {startCol})");
    }

    static bool NotValid(char[,] field, int startRow, int startCol)
    {
        bool notValid = false;

        if (startRow < 0 || startCol < 0 ||
            startRow >= field.GetLength(0) ||
            startCol >= field.GetLength(1))
        {
            notValid = true;
        }

        return notValid;
    }
}