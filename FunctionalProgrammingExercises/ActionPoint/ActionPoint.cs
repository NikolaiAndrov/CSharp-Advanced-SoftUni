public class ActionPoint
{
    public static void Main()
    {
        Action<string[]> printCollection = x => Console.WriteLine(string.Join(Environment.NewLine, x));
        var collection = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
        printCollection(collection);
    }
}