namespace Snake
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int len = int.Parse(Console.ReadLine());
            char[,] field = new char[len, len];

            int snakeRow = 0;
            int snakeCol = 0;

            int burrowRow1 = 0;
            int burrowCol1 = 0;
            int burrowRow2 = 0;
            int burrowCol2= 0;

            bool isFirst = true;

            for (int row = 0; row < field.GetLength(0); row++)
            {
                char[] items = Console.ReadLine().ToCharArray();

                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = items[col];

                    if (items[col] == 'S')
                    {
                        snakeRow = row;
                        snakeCol = col;
                    }

                    if (items[col] == 'B' && isFirst)
                    {
                        burrowRow1 = row;
                        burrowCol1 = col;
                        isFirst = false;
                    }
                    else if (items[col] == 'B' && !isFirst)
                    {
                        burrowRow2 = row;
                        burrowCol2 = col;
                    }
                }
            }

            int foodQuantity = 0;

            while (foodQuantity < 10)
            {
                string command = Console.ReadLine();
                field[snakeRow, snakeCol] = '.';

                if (command == "up")
                {
                    snakeRow--;
                }
                else if (command == "down")
                {
                    snakeRow++;
                }
                else if (command == "left")
                {
                    snakeCol--;
                }
                else if (command == "right")
                {
                    snakeCol++;
                }

                if (snakeRow < 0 || snakeRow >= field.GetLength(0) ||
                    snakeCol < 0 || snakeCol >= field.GetLength(1))
                {
                    break;
                }

                if (field[snakeRow, snakeCol] == '-')
                {
                    field[snakeRow, snakeCol] = 'S';
                }
                else if (field[snakeRow, snakeCol] == '*')
                {
                    foodQuantity++;
                    field[snakeRow, snakeCol] = 'S';
                }
                else if (field[snakeRow, snakeCol] == 'B')
                {
                    field[snakeRow, snakeCol] = '.';

                    if (snakeRow == burrowRow1 && snakeCol == burrowCol1)
                    {
                        snakeRow = burrowRow2;
                        snakeCol = burrowCol2;
                        field[snakeRow, snakeCol] = 'S';
                    }
                    else if (snakeRow == burrowRow2 && snakeCol == burrowCol2)
                    {
                        snakeRow = burrowRow1;
                        snakeCol = burrowCol1;
                        field[snakeRow, snakeCol] = 'S';
                    }
                }
            }

            if (foodQuantity < 10)
            {
                Console.WriteLine("Game over!");
            }
            else
            {
                Console.WriteLine("You won! You fed the snake.");
            }

            Console.WriteLine($"Food eaten: {foodQuantity}");

            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    Console.Write(field[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
