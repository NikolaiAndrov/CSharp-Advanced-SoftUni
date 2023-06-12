namespace Garden
{
    using System;
    using System.Linq;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int n = size[0];
            int m = size[1];

            int[,] garden = new int[n, m];
            string input;

            while ((input = Console.ReadLine()) != "Bloom Bloom Plow")
            {
                int[] cordinates = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int row = cordinates[0];
                int col = cordinates[1];

                if (row < 0 || row >= garden.GetLength(0) ||
                    col < 0 || col >= garden.GetLength(1))
                {
                    Console.WriteLine("Invalid coordinates.");
                    continue;
                }

                garden[row, col] = 1;

                for (int irow = 0; irow < garden.GetLength(0); irow++)
                {
                    if (irow == row)
                    {
                        continue;
                    }
                    garden[irow, col] += 1;
                    garden[row, irow] += 1;
                }
            }

            for (int row = 0; row < garden.GetLength(0); row++)
            {
                for (int col = 0; col < garden.GetLength(1); col++)
                {
                    Console.Write(garden[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
