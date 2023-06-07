namespace Survivor
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            string[][] beach = new string[size][];

            for (int row = 0; row < beach.Length; row++)
            {
                beach[row] = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            int tokens = 0;
            int opponentTokens = 0;

            string input;

            while ((input = Console.ReadLine()) != "Gong")
            {
                string[] commaandInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = commaandInfo[0];
                int row = int.Parse(commaandInfo[1]);
                int col = int.Parse(commaandInfo[2]);

                if (command == "Find")
                {
                    if (IsOutside(beach, row, col))
                    {
                        continue;
                    }

                    if (beach[row][col] == "T")
                    {
                        tokens++;
                        beach[row][col] = "-";
                    }
                }
                else if (command == "Opponent")
                {
                    if (IsOutside(beach, row, col))
                    {
                        continue;
                    }

                    if (beach[row][col] == "T")
                    {
                        opponentTokens++;
                        beach[row][col] = "-";
                    }

                    string direction = commaandInfo[3];

                    for (int i = 0; i < 3; i++)
                    {
                        if (direction == "up")
                        {
                            row--;
                        }
                        else if (direction == "down")
                        {
                            row++;
                        }
                        else if (direction == "left")
                        {
                            col--;
                        }
                        else if (direction == "right")
                        {
                            col++;
                        }

                        if (IsOutside(beach, row, col))
                        {
                            break;
                        }

                        if (beach[row][col] == "T")
                        {
                            opponentTokens++;
                            beach[row][col] = "-";
                        }
                    }
                }
            }

            for (int row = 0; row < beach.Length; row++)
            {
                Console.WriteLine(string.Join(" ", beach[row]));
            }

            Console.WriteLine($"Collected tokens: {tokens}");
            Console.WriteLine($"Opponent's tokens: {opponentTokens}");
        }

        static bool IsOutside<T>(T[][] beach, int row, int col)
            => row < 0 || row >= beach.Length ||
               col < 0 || col >= beach[row].Length; 
    }
}