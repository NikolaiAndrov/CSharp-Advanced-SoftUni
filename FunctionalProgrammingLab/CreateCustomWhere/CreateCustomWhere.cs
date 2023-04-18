public class CreateCustomWhere
{
    public static void Main()
    {
        List<int> nums = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

        List<int> result = CustomWhere(nums, x => x % 2 == 0);
        Console.WriteLine(string.Join(" ", result));
    }

    static List<int> CustomWhere(List<int> nums, Func<int, bool> function)
    {
        List<int > result = new List<int>();

        foreach (int num in nums)
        {
            if (function(num))
            {
                result.Add(num);
            }
        }

        return result;
    }
}