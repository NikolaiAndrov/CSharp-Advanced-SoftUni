public class PrintEvenNumbers
{
    public static void Main()
    {
        var inputNums = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        var evenNums = new Queue<int>(inputNums.Where(x => x % 2 == 0));

        Console.WriteLine(string.Join(", ", evenNums));
    }
}