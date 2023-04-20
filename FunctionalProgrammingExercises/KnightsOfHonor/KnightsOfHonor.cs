public class KnightsOfHonor
{
    public static void Main()
    {
        Action<List<string>> printCollection = collection => collection.ForEach(x => Console.WriteLine($"Sir {x}"));
        List<string> names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
        printCollection(names);
    }
}