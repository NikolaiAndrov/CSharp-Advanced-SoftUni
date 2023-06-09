namespace SuperMario
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int hp = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            char[][] maze = new char[n][];
            int marioRow = 0;
            int marioCol = 0;

            for (int row = 0; row < maze.Length; row++)
            {
                maze[row] = Console.ReadLine().ToCharArray();

                for (int col = 0; col < maze[row].Length; col++)
                {
                    if (maze[row][col] == 'M')
                    {
                        marioRow = row;
                        marioCol = col;
                    }
                }
            }

            while (true)
            {
                string[] commandInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string direction = commandInfo[0];
                int enemyRow = int.Parse(commandInfo[1]);
                int enemyCol = int.Parse(commandInfo[2]);
                maze[enemyRow][enemyCol] = 'B';

                int row = 0;
                int col = 0;
                if (direction == "W")
                {
                    row = -1;
                }
                else if (direction == "S")
                {
                    row = 1;
                }
                else if (direction == "D")
                {
                    col = 1;
                }
                else if (direction == "A")
                {
                    col = -1;
                }

                hp--;

                if (IsOutside(maze, marioRow + row, marioCol + col))
                {
                    if (hp <= 0)
                    {
                        maze[marioRow][marioCol] = 'X';
                        Console.WriteLine($"Mario died at {marioRow};{marioCol}.");
                        break;
                    }

                    continue;
                }

                maze[marioRow][marioCol] = '-';
                marioRow += row;
                marioCol += col;

                if (hp <= 0)
                {
                    maze[marioRow][marioCol] = 'X';
                    Console.WriteLine($"Mario died at {marioRow};{marioCol}.");
                    break;
                }

                if (maze[marioRow][marioCol] == '-')
                {
                    maze[marioRow][marioCol] = 'M';
                }
                else if (maze[marioRow][marioCol] == 'B')
                {
                    hp -= 2;
                    if (hp <= 0)
                    {
                        maze[marioRow][marioCol] = 'X';
                        Console.WriteLine($"Mario died at {marioRow};{marioCol}.");
                        break;
                    }

                    maze[marioRow][marioCol] = 'M';
                }
                else if (maze[marioRow][marioCol] == 'P')
                {
                    maze[marioRow][marioCol] = '-';
                    Console.WriteLine($"Mario has successfully saved the princess! Lives left: {hp}");
                    break;
                }
            }

            for (int row = 0; row < maze.Length; row++)
            {
                Console.WriteLine(string.Join("", maze[row]));
            }
        }

        static bool IsOutside<T>(T[][] maze, int row, int col)
            => row < 0 || row >= maze.Length ||
               col < 0 || col >= maze[row].Length;
    }
}
