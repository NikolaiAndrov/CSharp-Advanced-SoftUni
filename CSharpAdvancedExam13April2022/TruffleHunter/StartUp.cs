using System;
using System.Linq;
using System.Collections.Generic;

namespace TruffleHunter
{
    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            string[,] field = new string[n, n];
            FillTheField(field);

            var trufelsCounter = new Dictionary<string, int>();
            GetTrufelsType(trufelsCounter);

            int boarTrufelsCounter = 0;

            GetCommands(field, trufelsCounter, ref boarTrufelsCounter);
            PrintResult(field, trufelsCounter, boarTrufelsCounter);
        }

        static void PrintResult(string[,] field ,Dictionary<string, int> trufelsCounte, int boarTrufelsCounter)
        {
            Console.WriteLine($"Peter manages to harvest {trufelsCounte["B"]} black, {trufelsCounte["S"]} summer, and {trufelsCounte["W"]} white truffles.");
            Console.WriteLine($"The wild boar has eaten {boarTrufelsCounter} truffles.");
            PrintMatrix(field);
        }

        static void GetCommands(string[,] field, Dictionary<string, int> trufelsCounter, ref int boarTrufelsCounter)
        {
            string input;
            while ((input = Console.ReadLine()) != "Stop the hunt")
            {
                string[] commandInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = commandInfo[0];
                int row = int.Parse(commandInfo[1]);
                int col = int.Parse(commandInfo[2]);

                if (command == "Collect")
                {
                    if (IsInField(field, row, col)
                        && IsTrufelFound(field, row, col))
                    {
                        trufelsCounter[field[row, col]]++;
                        field[row, col] = "-";
                    }
                }
                else if (command == "Wild_Boar")
                {
                    string direction = commandInfo[3];
                    int currentRow = 0;
                    int currentCol = 0;

                    if (direction == "up")
                    {
                        currentRow = -2;
                    }
                    else if (direction == "down")
                    {
                        currentRow = 2;
                    }
                    else if (direction == "left")
                    {
                        currentCol = -2;
                    }
                    else if (direction == "right")
                    {
                        currentCol = 2;
                    }

                    if (IsTrufelFound(field, row, col))
                    {
                        boarTrufelsCounter++;
                        field[row, col] = "-";
                    }

                    while (true)
                    {
                        if (!IsInField(field, row + currentRow, col + currentCol))
                        {
                            break;
                        }

                        row += currentRow;
                        col += currentCol;

                        if (IsTrufelFound(field, row, col))
                        {
                            boarTrufelsCounter++;
                            field[row, col] = "-";
                        }
                    }
                }
            }
        }

        static bool IsTrufelFound(string[,] field, int row, int col)
        {
            return field[row, col] == "B"
                   || field[row, col] == "S"
                   || field[row, col] == "W";
        }

        static bool IsInField<T>(T[,] field, int row, int col)
        {
            return row >= 0 && col >= 0
                && row < field.GetLength(0)
                && col < field.GetLength(1);
        }

        static void GetTrufelsType(Dictionary<string, int> trufelsCounter)
        {
            trufelsCounter.Add("B", 0);
            trufelsCounter.Add("S", 0);
            trufelsCounter.Add("W", 0);
        }

        static void FillTheField(string[,] field)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                string[] items = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = items[col];
                }
            }
        }

        static void PrintMatrix<T>(T[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}