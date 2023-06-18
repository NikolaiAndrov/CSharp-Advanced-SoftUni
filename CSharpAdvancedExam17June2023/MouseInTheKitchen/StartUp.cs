namespace MouseInTheKitchen
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(",").Select(int.Parse).ToArray();
            int n = size[0];
            int m = size[1];

            char[][] area = new char[n][];

            int mouseRow = 0;
            int mouseCol = 0;
            int cheese = 0;

            for (int row = 0; row < area.Length; row++)
            {
                area[row] = Console.ReadLine().ToCharArray();

                for (int col = 0; col < area[row].Length; col++)
                {
                    if (area[row][col] == 'M')
                    {
                        mouseRow = row;
                        mouseCol = col;
                    }

                    if (area[row][col] == 'C')
                    {
                        cheese++;
                    }
                }
            }

            while (true)
            {
                string direction = Console.ReadLine();

                if (direction == "danger")
                {
                    Console.WriteLine("Mouse will come back later!");
                    break;
                }

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
                else if (direction == "right")
                {
                    col = 1;
                }
                else if (direction == "left")
                {
                    col = -1;
                }

                if (IsOutside(area, mouseRow + row, mouseCol + col))
                {
                    Console.WriteLine("No more cheese for tonight!");
                    break;
                }

                if (area[mouseRow + row][mouseCol + col] == '@')
                {
                    continue;
                }

                area[mouseRow][mouseCol] = '*';

                mouseRow += row;
                mouseCol += col;

                if (area[mouseRow][mouseCol] == 'T')
                {
                    area[mouseRow][mouseCol] = 'M';
                    Console.WriteLine("Mouse is trapped!");
                    break;
                }
                else if (area[mouseRow][mouseCol] == '*')
                {
                    area[mouseRow][mouseCol] = 'M';
                }
                else if (area[mouseRow][mouseCol] == 'C')
                {
                    area[mouseRow][mouseCol] = 'M';
                    cheese--;

                    if (cheese == 0)
                    {
                        Console.WriteLine("Happy mouse! All the cheese is eaten, good night!");
                        break;
                    }
                }
            }

            for (int row = 0; row < area.Length; row++)
            {
                Console.WriteLine(string.Join("", area[row]));
            }
        }

        static bool IsOutside<T>(T[][] area, int row, int col)
            => row < 0 || row >= area.Length ||
               col < 0 || col >= area[row].Length;
    }
}