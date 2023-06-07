namespace TheBattleOfTheFiveArmies
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            int hp = int.Parse(Console.ReadLine());
            int size = int.Parse(Console.ReadLine());

            char[][] matrix = new char[size][];

            int armyRow = 0;
            int armyCol = 0;

            for (int row = 0; row < size; row++)
            {
                matrix[row] = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'A')
                    {
                        armyRow = row;
                        armyCol = col;
                    }
                }
            }

            while (true)
            {
                string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string direction = commands[0].ToLower();
                int enemyRow = int.Parse(commands[1]);
                int enemyCol = int.Parse(commands[2]);

                int row = 0;
                int col = 0;

                matrix[enemyRow][enemyCol] = 'O';
                hp--;

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

                if (IsOutside(matrix, armyRow + row, armyCol + col))
                {
                    if (hp <= 0)
                    {
                        matrix[armyRow][armyCol] = 'X';
                        Console.WriteLine($"The army was defeated at {armyRow};{armyCol}.");
                        break;
                    }
                    continue;
                }

                matrix[armyRow][armyCol] = '-';

                armyRow += row;
                armyCol += col;

                if (hp <= 0)
                {
                    matrix[armyRow][armyCol] = 'X';
                    Console.WriteLine($"The army was defeated at {armyRow};{armyCol}.");
                    break;
                }

                if (matrix[armyRow][armyCol] == 'O')
                {
                    hp -= 2;

                    if (hp <= 0)
                    {
                        matrix[armyRow][armyCol] = 'X';
                        Console.WriteLine($"The army was defeated at {armyRow};{armyCol}.");
                        break;
                    }
                }
                else if (matrix[armyRow][armyCol] == 'M')
                {
                    matrix[armyRow][armyCol] = '-';
                    Console.WriteLine($"The army managed to free the Middle World! Armor left: {hp}");
                    break;
                }

                matrix[armyRow][armyCol] = 'A'; 
            }

            for (int row = 0; row < matrix.Length; row++)
            {
                Console.WriteLine(string.Join("", matrix[row]));
            }
        }

        static bool IsOutside<T>(T[][] matrix, int row, int col)
            => row < 0 || row >= matrix.Length ||
               col < 0 || col >= matrix[row].Length;
    }
}