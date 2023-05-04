namespace BlindMan_sBuff
{
    public class StartUp
    {
        public static void Main()
        {
            int[] dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string[,] playground = new string[dimensions[0], dimensions[1]];
            int myRow = 0;
            int myCol = 0;
            FillPlayground(playground, ref myRow, ref myCol);

            int touchedPeople = 0;
            int steps = 0;
            PlayTheGame(playground, myRow, myCol, ref touchedPeople, ref steps);
            PrintFinish(steps, touchedPeople);
        }

        static void PrintFinish(int steps, int touchedPeople)
        {
            Console.WriteLine("Game over!");
            Console.WriteLine($"Touched opponents: {touchedPeople} Moves made: {steps}");
        }
        static void PlayTheGame(string[,] playground, int myRow, int myCol, ref int touchedPeople, ref int steps)
        {
            playground[myRow, myCol] = "-";
            string command;
            while ((command = Console.ReadLine()) != "Finish")
            {
                if (touchedPeople == 3)
                {
                    break;
                }

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

                if (OutOfRangeOrObstacles(playground, myRow + row, myCol + col))
                {
                    continue;
                }

                myRow += row;
                myCol += col;

                if (playground[myRow, myCol] == "P")
                {
                    touchedPeople++;
                    steps++;
                    playground[myRow, myCol] = "-";
                }
                else if (playground[myRow, myCol] == "-")
                {
                    steps++;
                }
            }
        }

        static bool OutOfRangeOrObstacles(string[,] playground, int row, int col)
        {
            return row < 0 || col < 0
                || row >= playground.GetLength(0)
                || col >= playground.GetLength(1)
                || playground[row, col] == "O";
        }

        static void FillPlayground(string[,] playground, ref int myRow, ref int myCol)
        {
            for (int row = 0; row < playground.GetLength(0); row++)
            {
                string[] items = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < playground.GetLength(1); col++)
                {
                    playground[row,col] = items[col];

                    if (items[col] == "B")
                    {
                        myRow = row;
                        myCol = col;
                    }
                }
            }
        }
    }
}