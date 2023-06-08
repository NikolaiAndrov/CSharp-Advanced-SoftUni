namespace NavyBattle
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] battlefield = new char[n, n];

            int submarineRow = 0;
            int submarineCol = 0;

            for (int row = 0; row < battlefield.GetLength(0); row++)
            {
                char[] items = Console.ReadLine().ToCharArray();

                for (int col = 0; col < battlefield.GetLength(1); col++)
                {
                    battlefield[row, col] = items[col];

                    if (items[col] == 'S')
                    {
                        submarineRow = row;
                        submarineCol = col;
                    }
                }
            }

            int mines = 0;
            int cruisers = 0;

            while (true)
            {
                string direction = Console.ReadLine();
                battlefield[submarineRow, submarineCol] = '-';

                if (direction == "up")
                {
                    submarineRow--;
                }
                else if (direction == "down")
                {
                    submarineRow++;
                }
                else if (direction == "left")
                {
                    submarineCol--;
                }
                else if (direction == "right")
                {
                    submarineCol++;
                }

                if (battlefield[submarineRow, submarineCol] == '-')
                {
                    battlefield[submarineRow, submarineCol] = 'S';
                }
                else if (battlefield[submarineRow, submarineCol] == '*')
                {
                    mines++;
                    battlefield[submarineRow, submarineCol] = 'S';

                    if (mines == 3)
                    {
                        Console.WriteLine($"Mission failed, U-9 disappeared! Last known coordinates [{submarineRow}, {submarineCol}]!");
                        break;
                    }
                }
                else if (battlefield[submarineRow, submarineCol] == 'C')
                {
                    cruisers++;
                    battlefield[submarineRow, submarineCol] = 'S';

                    if( cruisers == 3)
                    {
                        Console.WriteLine("Mission accomplished, U-9 has destroyed all battle cruisers of the enemy!");
                        break;
                    }
                }
            }

            for (int row = 0; row < battlefield.GetLength(0); row++)
            {
                for (int col = 0; col < battlefield.GetLength(1); col++)
                {
                    Console.Write(battlefield[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}