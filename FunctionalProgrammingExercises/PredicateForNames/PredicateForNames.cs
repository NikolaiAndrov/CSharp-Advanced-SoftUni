public class PredicateForNames
{
    public static void Main()
    {
        Func<string, int, bool> filterByLen = (name, n) => name.Length <= n;
        Action<string[]> printCollection = collection => Console.WriteLine(string.Join(Environment.NewLine, collection));

        int len = int.Parse(Console.ReadLine());

        string[] names = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Where(x => filterByLen(x, len))
            .ToArray();
        
        printCollection(names);
    }
}