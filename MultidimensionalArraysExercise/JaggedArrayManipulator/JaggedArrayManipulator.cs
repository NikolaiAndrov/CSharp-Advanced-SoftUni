public class JaggedArrayManipulator
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        double[][] nums = new double[n][];
        FillArray(nums);
        MultiplyOrDivide(nums);
        GetCommands(nums);
        PrintElements(nums);
    }

    static void PrintElements(double[][] nums)
    {
        for (int row = 0; row < nums.Length; row++)
        {
            for (int col = 0; col < nums[row].Length; col++)
            {
                Console.Write(nums[row][col] + " ");
            }
            Console.WriteLine();
        }
    }
    static void GetCommands(double[][] nums)
    {
        string input;

        while ((input = Console.ReadLine()) != "End")
        {
            string[] commandInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string command = commandInfo[0];
            int row = int.Parse(commandInfo[1]);
            int col = int.Parse(commandInfo[2]);
            int value = int.Parse(commandInfo[3]);

            if (NotValidIndexes(nums, row, col))
            {
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
    }

    static bool NotValidIndexes(double[][] nums, int row, int col)
    {
        bool notValid = false;

        if (row < 0 || row >= nums.Length ||
            col < 0 || col >= nums[row].Length)
        {
            notValid = true;
        }

        return notValid;
    }
    static void MultiplyOrDivide(double[][] nums)
    {
        for (int row = 0; row < nums.Length - 1; row++)
        {
            if (nums[row].Length == nums[row + 1].Length)
            {
                for (int col = 0; col < nums[row].Length; col++)
                {
                    nums[row][col] *= 2;
                    nums[row + 1][col] *= 2;
                }
            }
            else
            {
                for (int col = 0; col < nums[row].Length; col++)
                {
                    nums[row][col] /= 2;
                }

                for (int col = 0; col < nums[row + 1].Length; col++)
                {
                    nums[row + 1][col] /= 2;
                }
            }
        }
    }
    static void FillArray(double[][] nums)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            nums[i] = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse) 
                .ToArray();
        }
    }
}