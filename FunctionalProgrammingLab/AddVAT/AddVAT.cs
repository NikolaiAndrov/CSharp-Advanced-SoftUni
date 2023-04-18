public class AddVAT
{
    public static void Main()
    {
        var nums = Console.ReadLine()
            .Split(", ", StringSplitOptions.RemoveEmptyEntries)
            .Select(double.Parse)
            .Select(x => x * 1.2)
            .ToArray();

        foreach (var num in nums)
        {
            Console.WriteLine($"{num:f2}");
        }
    }
}