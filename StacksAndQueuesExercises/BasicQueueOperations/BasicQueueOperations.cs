public class BasicQueueOperations
{
    public static void Main()
    {
        int[] commandNumbers = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int numbersToEnqueue = commandNumbers[0];
        int numbersToDequeue = commandNumbers[1];
        int searchedElement = commandNumbers[2];

        int[] inputNumbers = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        Queue<int> numbers = new Queue<int>();

        for (int i = 0; i < numbersToEnqueue; i++)
        {
            numbers.Enqueue(inputNumbers[i]);
        }

        for (int i = 0;i < numbersToDequeue; i++)
        {
            numbers.Dequeue();
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