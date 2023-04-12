public class Largest3Numbers
{
    public static void Main()
    {
        Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .OrderByDescending(x => x)
            .Take(3)
            .ToList()
            .ForEach(x => Console.Write(x + " "));
    }
}