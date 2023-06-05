namespace TheSquirrel
{
    public class StartUp
    {
        public static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            int squirrelRow = 0;
            int squirrelCol = 0;

            int[,] matrix = new int[size, size];

            for (int row = 0; row < matrix.GetLongLength(0); row++)
            {
                char[] items = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrix.GetLongLength(1); col++)
                {
                    matrix[row, col] = items[col];

                    if (items[col] == 's')
                    {
                        squirrelRow = row;
                        squirrelCol = col;
                    }
                }
            }

            int hazelnutCount = 0;
            bool flag = false;

            foreach (var command in commands)
            {
                int currentRow = 0;
                int currentCol = 0;

                if (command == "left")
                {
                    currentCol = -1;
                }
                else if (command == "right")
                {
                    currentCol = 1;
                }
                else if (command == "down")
                {
                    currentRow = 1;
                }
                else if (command == "up")
                {
                    currentRow = -1;
                }


                if (IsOutside(matrix, squirrelRow + currentRow, squirrelCol + currentCol))
                {
                    Console.WriteLine("The squirrel is out of the field.");
                    flag = true;
                    break;
                }

                squirrelRow += currentRow;
                squirrelCol += currentCol;

                if (matrix[squirrelRow, squirrelCol] == 'h')
                {
                    hazelnutCount++;
                    matrix[squirrelRow, squirrelCol] = '*';
                }
                else if (matrix[squirrelRow, squirrelCol] == 't')
                {
                    Console.WriteLine("Unfortunately, the squirrel stepped on a trap...");
                    flag = true; 
                    break;
                }

                if (hazelnutCount == 3)
                {
                    Console.WriteLine("Good job! You have collected all hazelnuts!");
                    flag = true;
                    break;
                }
            }

            if (!flag)
            {
                Console.WriteLine("There are more hazelnuts to collect.");
            }

            Console.WriteLine($"Hazelnuts collected: {hazelnutCount}");
        }

        static bool IsOutside<T>(T[,] matrix, int row, int col)
            => row < 0 || row >= matrix.GetLength(0) ||
            col < 0 || col >= matrix.GetLength(1);
    }
}