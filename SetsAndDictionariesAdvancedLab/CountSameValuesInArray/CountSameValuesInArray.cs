public class CountSameValuesInArray
{
    public static void Main()
    {
        double[] nums = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(double.Parse)
            .ToArray();

        Dictionary<double, int> numsCounter = new Dictionary<double, int>();

        foreach (var num in nums)
        {
            if (!numsCounter.ContainsKey(num))
            {
                numsCounter[num] = 0;
            }
            numsCounter[num]++;
        }

        PrintNumsCount(numsCounter);
    }

    static void PrintNumsCount(Dictionary<double, int> numsCounter)
    {
        foreach (var num in numsCounter)
        {
            Console.WriteLine($"{num.Key} - {num.Value} times");
        }
    }
}