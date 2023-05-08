using System;
using System.Linq;
using System.Collections.Generic;

namespace BeaverAtWork
{
    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            char[,] pond = new char[n, n];
            int myRow = 0;
            int myCol = 0;
            int branchesCount = 0;
            var branchesColected = new Stack<char>();

            for (int row = 0; row < pond.GetLength(0); row++)
            {
                char[] items = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse).ToArray();

                for (int col = 0; col < pond.GetLength(1); col++)
                {
                    pond[row, col] = items[col];

                    if (pond[row, col] == 'B')
                    {
                        myRow = row;
                        myCol = col;
                    }
                    else if (IsBranch(pond, row, col))
                    {
                        branchesCount++;
                    }
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "end")
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

                if (IsOutside(pond, myRow + row, myCol + col))
                {
                    if (branchesColected.Count > 0)
                    {
                        branchesColected.Pop();
                    }
                    continue;
                }

                pond[myRow, myCol] = '-';
                myRow += row;
                myCol += col;

                if (pond[myRow, myCol] == '-')
                {
                    pond[myRow, myCol] = 'B';
                    continue;
                }
                else if (IsBranch(pond, myRow, myCol))
                {
                    branchesColected.Push(pond[myRow, myCol]);
                    branchesCount--;
                    pond[myRow, myCol] = 'B';
                }
                else if (pond[myRow, myCol] == 'F')
                {
                    pond[myRow, myCol] = '-';

                    if (command == "up")
                    {
                        if (myRow == 0)
                        {
                            myRow = pond.GetLength(0) - 1;
                        }
                        else
                        {
                            myRow = 0;
                        }
                    }
                    else if (command == "down")
                    {
                        if (myRow == pond.GetLength(0) - 1)
                        {
                            myRow = 0;
                        }
                        else
                        {
                            myRow = pond.GetLength(0) - 1;
                        }
                    }
                    else if (command == "left")
                    {
                        if (myCol == 0)
                        {
                            myCol = pond.GetLength(1) - 1;
                        }
                        else
                        {
                            myCol = 0;
                        }
                    }
                    else if (command == "right")
                    {
                        if (myCol == pond.GetLength(1) - 1)
                        {
                            myCol = 0;
                        }
                        else
                        {
                            myCol = pond.GetLength(1) - 1;
                        }
                    }

                    if (IsBranch(pond, myRow, myCol))
                    {
                        branchesColected.Push(pond[myRow, myCol]);
                        branchesCount--;
                    }

                    pond[myRow, myCol] = 'B';
                }

                if (branchesCount == 0)
                {
                    break;
                }
            }

            if (branchesCount == 0 && branchesColected.Count > 0)
            {
                var result = new List<char>();

                foreach (var branch in branchesColected)
                {
                    result.Add(branch);
                }
                result.Sort();
                Console.WriteLine($"The Beaver successfully collect {result.Count} wood branches: {string.Join(", ", result)}.");
            }
            else
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {branchesCount} branches left.");
            }

            PrintThePond(pond);
        }

        static bool IsBranch(char[,] pond, int row, int col)
        {
            bool isBranch = false;

            if (char.IsLetter(pond[row, col]))
            {
                if (char.IsLower(pond[row, col]))
                {
                    isBranch = true;
                }
            }
            return isBranch;
        }
        static bool IsOutside<T>(T[,] pond, int row, int col)
        {
            return row < 0 || col < 0
                || row >= pond.GetLength(0)
                || col >= pond.GetLength(1);
        }
        static void PrintThePond<T>(T[,] pond)
        {
            for (int row = 0; row < pond.GetLength(0); row++)
            {
                for (int col = 0; col < pond.GetLength(1); col++)
                {
                    Console.Write(pond[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}