public class FindEvensOrOdds
{
    public static void Main()
    {
        Predicate<int> isEven = x => x % 2 == 0;

        int[] range = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        string numbersType = Console.ReadLine();

        List<int> numbers = new List<int>();

        for (int i = range[0]; i <= range[1]; i++)
        {
            if (numbersType == "even")
            {
                if (isEven(i))
                {
                    numbers.Add(i);
                }
            }
            else if (numbersType == "odd")
            {
                if (!isEven(i))
                {
                    numbers.Add(i);
                }
            }
        }

        Action<List<int>> printCollection = collection => Console.WriteLine(string.Join(" ", collection));
        printCollection(numbers);
    }
}