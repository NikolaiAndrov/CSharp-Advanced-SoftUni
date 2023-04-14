public class PeriodicTable
{
    public static void Main()
    {
        SortedSet<string> elements = new SortedSet<string>();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] inputElements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var element in inputElements)
            {
                elements.Add(element);
            }
        }

        Console.WriteLine(string.Join(" ", elements));
    }
}