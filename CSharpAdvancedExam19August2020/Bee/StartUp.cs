namespace Bee
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] territory = new char[n, n];

            int beeRow = 0;
            int beeCol = 0;

            for (int row = 0; row < territory.GetLength(0); row++)
            {
                char[] items = Console.ReadLine().ToCharArray();

                for (int col = 0; col < territory.GetLength(1); col++)
                {
                    territory[row, col] = items[col];

                    if (items[col] == 'B')
                    {
                        beeRow = row;
                        beeCol = col;
                    }
                }
            }

            int flowers = 0;

            string direction;

            while ((direction = Console.ReadLine()) != "End")
            {
                int row = 0;
                int col = 0;

                if (direction == "up")
                {
                    row = -1;
                }
                else if (direction == "down")
                {
                    row = 1;
                }
                else if (direction == "left")
                {
                    col = -1;
                }
                else if (direction == "right")
                {
                    col = 1;
                }

                territory[beeRow, beeCol] = '.';
                beeRow += row;
                beeCol += col;

                if (IsOutside(territory, beeRow, beeCol))
                {
                    Console.WriteLine("The bee got lost!");
                    break;
                }

                if (territory[beeRow, beeCol] == 'O')
                {
                    territory[beeRow, beeCol] = '.';
                    beeRow += row;
                    beeCol += col;

                    if (IsOutside(territory, beeRow, beeCol))
                    {
                        Console.WriteLine("The bee got lost!");
                        break;
                    }
                }

                if (territory[beeRow, beeCol] == '.')
                {
                    territory[beeRow, beeCol] = 'B';
                }
                else if (territory[beeRow, beeCol] == 'f')
                {
                    territory[beeRow, beeCol] = 'B';
                    flowers++;
                }
            }

            if (flowers < 5)
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - flowers} flowers more");
            }
            else
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {flowers} flowers!");
            }

            for (int row = 0; row < territory.GetLength(0); row++)
            {
                for (int col = 0; col < territory.GetLength(1); col++)
                {
                    Console.Write(territory[row, col]);
                }

                Console.WriteLine();
            }
        }

        static bool IsOutside<T>(T[,] matrix, int row, int col)
            => row < 0 || row >= matrix.GetLength(0) ||
               col < 0 || col >= matrix.GetLength(1);
    }
}
