using System;
using System.Linq;
using System.Collections.Generic;

namespace HelpAMole
{
    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            char[,] playingField = new char[n,n];
            int myRow = 0;
            int myCol = 0;
            int specialPlace1Row = 0;
            int specialPlace1Col = 0;
            int specialPlace2Row = 0;
            int specialPlace2Col = 0;
            bool isFirst = true;

            for (int row = 0; row < n; row++)
            {
                char[] items = Console.ReadLine().ToArray();

                for (int col = 0; col < n; col++)
                {
                    playingField[row,col] = items[col];

                    if (items[col] == 'M')
                    {
                        myRow = row;
                        myCol = col;
                    }
                    else if (items[col] == 'S' && isFirst)
                    {
                        specialPlace1Row = row;
                        specialPlace1Col = col;
                        isFirst = false;
                    }
                    else if (items[col] == 'S' && !isFirst)
                    {
                        specialPlace2Row = row;
                        specialPlace2Col = col;
                    }
                }
            }

            int points = 0;
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                if (points >= 25)
                {
                    break;
                }

                int currentRow = 0;
                int currentCol = 0;

                if (command == "up")
                {
                    currentRow = -1;
                }
                else if (command == "down")
                {
                    currentRow = 1;
                }
                else if (command == "left")
                {
                    currentCol = -1;
                }
                else if (command == "right")
                {
                    currentCol = 1;
                }

                if (OutOfRange(playingField, myRow + currentRow, myCol + currentCol))
                {
                    Console.WriteLine("Don't try to escape the playing field!");
                    continue;
                }

                playingField[myRow, myCol] = '-';
                myRow += currentRow;
                myCol += currentCol;

                if (playingField[myRow, myCol] == '-')
                {
                    playingField[myRow, myCol] = 'M';
                }
                else if (char.IsDigit(playingField[myRow, myCol]))
                {
                    int currentPoints = int.Parse(playingField[myRow, myCol].ToString());
                    points += currentPoints;
                    playingField[myRow, myCol] = 'M';
                }
                else if (playingField[myRow, myCol] == 'S')
                {
                    points -= 3;

                    if (myRow == specialPlace1Row && myCol == specialPlace1Col)
                    {
                        playingField[myRow, myCol] = '-';
                        myRow = specialPlace2Row;
                        myCol = specialPlace2Col;
                        playingField[myRow, myCol] = 'M';
                    }
                    else if (myRow == specialPlace2Row && myCol == specialPlace2Col)
                    {
                        playingField[myRow, myCol] = '-';
                        myRow = specialPlace1Row;
                        myCol = specialPlace1Col;
                        playingField[myRow, myCol] = 'M';
                    }
                }
            }

            if (points >= 25)
            {
                Console.WriteLine("Yay! The Mole survived another game!");
                Console.WriteLine($"The Mole managed to survive with a total of {points} points.");
            }
            else
            {
                Console.WriteLine("Too bad! The Mole lost this battle!");
                Console.WriteLine($"The Mole lost the game with a total of {points} points.");
            }

            PrintMatrix(playingField);
        }

        static void PrintMatrix<T>(T[,] matrix)
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
        static bool OutOfRange<T>(T[,] matrix, int row, int col)
        {
            return row < 0 || col < 0
                || row >= matrix.GetLength(0)
                || col >= matrix.GetLength(1);
        }
    }
}