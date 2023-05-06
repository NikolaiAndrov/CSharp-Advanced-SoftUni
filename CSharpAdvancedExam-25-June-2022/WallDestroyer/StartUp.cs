using System;
using System.Linq;
using System.Collections.Generic;

namespace WallDestroyer
{
    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            char[,] wall = new char[n, n];
            int myRow = 0;
            int myCol = 0;

            for (int row = 0; row < wall.GetLength(0); row++)
            {
                char[] items = Console.ReadLine().ToCharArray();

                for (int col = 0; col < wall.GetLength(1); col++)
                {
                    wall[row, col] = items[col];

                    if (items[col] == 'V')
                    {
                        myRow = row;
                        myCol = col;
                    }
                }
            }

            int holesCount = 0;
            int rodsCount = 0;
            bool isFirstStep = true;

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                int row = 0;
                int col = 0;

                if (command == "up")
                {
                    row = -1;
                }
                else if (command == "down")
                {
                    row = 1;
                }
                else if (command == "left")
                {
                    col = -1;
                }
                else if (command == "right")
                {
                    col = 1;
                }

                if (OutOfRange(wall, myRow + row, myCol + col))
                {
                    continue;
                }

                if (isFirstStep)
                {
                    holesCount++;
                    isFirstStep = false;
                }

                if (wall[myRow + row, myCol + col] == 'R')
                {
                    Console.WriteLine("Vanko hit a rod!");
                    rodsCount++;
                    continue;
                }

                wall[myRow, myCol] = '*';
                myRow += row;
                myCol += col;

                if (wall[myRow, myCol] == '-')
                {
                    holesCount++;
                    wall[myRow, myCol] = 'V';
                }
                else if (wall[myRow, myCol] == 'C')
                {
                    holesCount++;
                    wall[myRow, myCol] = 'E';
                    Console.WriteLine($"Vanko got electrocuted, but he managed to make {holesCount} hole(s).");
                    break;
                }
                else if (wall[myRow, myCol] == '*')
                {
                    Console.WriteLine($"The wall is already destroyed at position [{myRow}, {myCol}]!");
                    wall[myRow, myCol] = 'V';
                }
            }

            if (command == "End")
            {
                Console.WriteLine($"Vanko managed to make {holesCount} hole(s) and he hit only {rodsCount} rod(s).");
            }

            PrintWall(wall);
        }

        static bool OutOfRange<T>(T[,] wall, int row, int col)
        {
            return row < 0 || col < 0
                || row >= wall.GetLength(0)
                || col >= wall.GetLength(1);
        }
        static void PrintWall<T>(T[,] wall)
        {
            for (int row = 0; row < wall.GetLength(0); row++)
            {
                for (int col = 0; col < wall.GetLength(1); col++)
                {
                    Console.Write(wall[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}