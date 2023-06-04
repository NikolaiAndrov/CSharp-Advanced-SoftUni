namespace Armory
{
    using System;
    
    public class StartUp
    {
        public static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];

            int armyOfficerRow = 0;
            int armyOfficerCol = 0;

            int mirrorRow1 = -1;
            int mirrorCol1 = -1;
            int mirrorRow2 = -1;
            int mirrorCol2 = -1;

            bool isFirstMirror = true;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] items = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = items[col];

                    if (items[col] == 'A')
                    {
                        armyOfficerRow = row;
                        armyOfficerCol = col;
                    }
                    else if (items[col] == 'M')
                    {
                        if (isFirstMirror)
                        {
                            mirrorRow1 = row;
                            mirrorCol1 = col;
                            isFirstMirror = false;
                        }
                        else
                        {
                            mirrorRow2 = row;
                            mirrorCol2 = col;
                        }
                    }
                }
            }

            int goldCoins = 0;
            bool isArmyOfficerLeft = false;

            while (goldCoins < 65)
            {
                string direction = Console.ReadLine();
                int currentRow = 0;
                int currentCol = 0;

                if (direction == "up")
                {
                    currentRow = -1;
                }
                else if (direction == "down")
                {
                    currentRow = 1;
                }
                else if (direction == "left")
                {
                    currentCol = -1;
                }
                else if (direction == "right")
                {
                    currentCol = 1;
                }

                matrix[armyOfficerRow, armyOfficerCol] = '-';

                if (IsOutOfRange(matrix, armyOfficerRow + currentRow, armyOfficerCol + currentCol))
                {
                    isArmyOfficerLeft = true;
                    break;
                }

                armyOfficerRow += currentRow;
                armyOfficerCol += currentCol;

                if (matrix[armyOfficerRow, armyOfficerCol] == '-')
                {
                    matrix[armyOfficerRow, armyOfficerCol] = 'A';
                }
                else if (char.IsDigit(matrix[armyOfficerRow, armyOfficerCol]))
                {
                    int goldCoin = int.Parse(matrix[armyOfficerRow, armyOfficerCol].ToString());
                    goldCoins += goldCoin;
                    matrix[armyOfficerRow, armyOfficerCol] = 'A';
                }
                else if (matrix[armyOfficerRow, armyOfficerCol] == 'M')
                {
                    if (armyOfficerRow == mirrorRow1 && armyOfficerCol == mirrorCol1)
                    {
                        matrix[armyOfficerRow, armyOfficerCol] = '-';
                        armyOfficerRow = mirrorRow2;
                        armyOfficerCol = mirrorCol2;
                        matrix[armyOfficerRow, armyOfficerCol] = 'A';
                    }
                    else if (armyOfficerRow == mirrorRow2 && armyOfficerCol == mirrorCol2)
                    {
                        matrix[armyOfficerRow, armyOfficerCol] = '-';
                        armyOfficerRow = mirrorRow1;
                        armyOfficerCol = mirrorCol1;
                        matrix[armyOfficerRow, armyOfficerCol] = 'A';
                    }
                }
            }

            if (isArmyOfficerLeft)
            {
                Console.WriteLine("I do not need more swords!");
            }
            else
            {
                Console.WriteLine("Very nice swords, I will come back for more!");
            }

            Console.WriteLine($"The king paid {goldCoins} gold coins.");

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLongLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
        static bool IsOutOfRange<T>(T[,] matrix, int row, int col)
            => row < 0 || row >= matrix.GetLength(0) ||
            col < 0 || col >= matrix.GetLength(1);
    }
}