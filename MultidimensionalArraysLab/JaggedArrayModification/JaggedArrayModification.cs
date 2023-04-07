public class JaggedArrayModification
{
    public static void Main()
    {
        int rows = int.Parse(Console.ReadLine());
        int[][] nums = new int[rows][];

        for (int row = 0; row < rows; row++)
        {
            nums[row] = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }

        string input;

        while ((input = Console.ReadLine()) != "END")
        {
            string[] commandInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string command = commandInfo[0];
            int row = int.Parse(commandInfo[1]);
            int col = int.Parse(commandInfo[2]);
            int value = int.Parse(commandInfo[3]);

            if (row < 0 || row >= nums.Length || col < 0 || col >= nums[row].Length)
            {
                Console.WriteLine("Invalid coordinates");
                continue;
            }

            if (command == "Add")
            {
                nums[row][col] += value;
            }
            else if (command == "Subtract")
            {
                nums[row][col] -= value;
            }
        }

        for (int i = 0; i < nums.Length; i++)
        {
            Console.WriteLine(string.Join(" ", nums[i]));
        }
    }
}