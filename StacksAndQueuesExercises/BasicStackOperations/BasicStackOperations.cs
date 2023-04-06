public class BasicStackOperations
{
    public static void Main()
    {
        int[] commandNumbers = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int numbersToPush = commandNumbers[0];
        int numbersToPop = commandNumbers[1];
        int searchedElement = commandNumbers[2];

        int[] inputNumbers = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        Stack<int> numbers = new Stack<int>();

        for (int i = 0; i < numbersToPush; i++)
        {
            numbers.Push(inputNumbers[i]);
        }

        for (int i = 0; i < numbersToPop; i++)
        {
            numbers.Pop();
        }

        if (numbers.Contains(searchedElement))
        {
            Console.WriteLine("true");
        }
        else if (numbers.Count > 0)
        {
            Console.WriteLine(numbers.Min());
        }
        else if (numbers.Count == 0)
        {
            Console.WriteLine(0);
        }
    }
}