public class AppliedArithmetics
{
    public static void Main()
    {
        Action<List<int>> printCollection = collection => Console.WriteLine(string.Join(" ", collection));

        List<int> numbers = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

        string input;

        while ((input = Console.ReadLine()) != "end")
        {
            if (input == "add")
            {
                numbers = Arithmetics(numbers, x => x + 1);
            }
            else if (input == "multiply")
            {
                numbers = Arithmetics(numbers, x => x * 2);
            }
            else if (input == "subtract")
            {
                numbers = Arithmetics(numbers, x => x - 1);
            }
            else if (input == "print")
            {
                printCollection(numbers);
            }
        }
    }

    static List<int> Arithmetics(List<int> numbers, Func<int, int> function)
    {
        List<int> result = new List<int>();

        foreach (int number in numbers)
        {
            result.Add(function(number));
        }

        return result;
    }
}