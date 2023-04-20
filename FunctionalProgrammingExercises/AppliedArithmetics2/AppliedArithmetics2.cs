public class AppliedArithmetics2
{
    public static void Main()
    {
        Action<int[]> printCollection = collection => Console.WriteLine(string.Join(" ", collection));

        int[] nums = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        string input;
        while ((input = Console.ReadLine()) != "end")
        {
            if (input == "print")
            {
                printCollection(nums);
                continue;
            }

            Func<int, int> arithmetics = Function(input);
            nums = nums.Select(arithmetics).ToArray();
        }
    }

    static Func<int, int> Function(string input)
    {
        if (input == "add")
        {
            return x => x + 1;
        }
        else if (input == "subtract")
        {
            return x => x - 1;
        }
        else if (input == "multiply")
        {
            return x => x * 2;
        }

        return null;
    }
}