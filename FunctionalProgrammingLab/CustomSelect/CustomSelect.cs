public class CustomSelect
{
    public static void Main()
    {
        List<int> nums = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

        List<int> result = Select2(nums, x => x * x);

        Console.WriteLine(string.Join(" ", result));
    }

    static List<int> Select2(List<int> nums, Func<int, int> selector)
    {
        List<int> result = new List<int>();

        foreach (int num in nums)
        {
            result.Add(selector(num));
        }

        return result;
    }
}