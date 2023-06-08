namespace ReVolt
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            int commandsCount = int.Parse(Console.ReadLine());

            char[,] matrix = new char[size, size];

            int playerRow = 0;
            int playerCol = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] items = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = items[col];

                    if (items[col] == 'f')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            bool playerWins = false;

            for (int i = 0; i < commandsCount; i++)
            {
                string command = Console.ReadLine();
                int row = 0;
                int col = 0;

                matrix[playerRow, playerCol] = '-';

                ChangeDirection(command, ref playerRow, ref playerCol);

                if (IsOutside(matrix, playerRow, playerCol))
                {
                    OutsideChanges(matrix, ref playerRow, ref playerCol);
                }

                if (matrix[playerRow, playerCol] == '-')
                {
                    matrix[playerRow, playerCol] = 'f';
                }
                else if (matrix[playerRow, playerCol] == 'F')
                {
                    matrix[playerRow, playerCol] = 'f';
                    playerWins = true;
                    break;
                }
                else if (matrix[playerRow, playerCol] == 'T')
                {
                    if (command == "up")
                    {
                        playerRow++;
                    }
                    else if (command == "down")
                    {
                        playerRow--;
                    }
                    else if (command == "left")
                    {
                        playerCol++;
                    }
                    else if (command == "right")
                    {
                        playerCol--;
                    }

                    if (IsOutside(matrix, playerRow, playerCol))
                    {
                        OutsideChanges(matrix, ref playerRow, ref playerCol);
                    }

                    matrix[playerRow, playerCol] = 'f';
                }
                else if (matrix[playerRow, playerCol] == 'B')
                {
                    ChangeDirection(command, ref playerRow, ref playerCol);

                    if (IsOutside(matrix, playerRow, playerCol))
                    {
                        OutsideChanges(matrix, ref playerRow, ref playerCol);
                    }

                    if (matrix[playerRow, playerCol] == 'F')
                    {
                        matrix[playerRow, playerCol] = 'f';
                        playerWins = true;
                        break;
                    }

                    matrix[playerRow, playerCol] = 'f';
                }
            }

            if (playerWins)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine("Player lost!");
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        static void ChangeDirection(string command, ref int playerRow, ref int playerCol)
        {
            if (command == "up")
            {
                playerRow--;
            }
            else if (command == "down")
            {
                playerRow++;
            }
            else if (command == "left")
            {
                playerCol--;
            }
            else if (command == "right")
            {
                playerCol++;
            }
        }
        static void OutsideChanges<T>(T[,] matrix, ref int playerRow, ref int playerCol)
        {
            if (playerRow < 0)
            {
                playerRow = matrix.GetLength(0) - 1;
            }
            else if (playerRow == matrix.GetLength(0))
            {
                playerRow = 0;
            }
            else if (playerCol < 0)
            {
                playerCol = matrix.GetLength(1) - 1;
            }
            else if (playerCol == matrix.GetLength(1))
            {
                playerCol = 0;
            }
        }

        static bool IsOutside<T>(T[,] matrix, int row, int col)
            => row < 0 || row >= matrix.GetLength(0) ||
               col < 0 || col >= matrix.GetLength(1);
    }
}
