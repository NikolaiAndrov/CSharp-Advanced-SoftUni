public class MaximumAndMinimumElement
{
    public static void Main()
    {
        Stack<int> numbers = new Stack<int>();
        var commandsCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < commandsCount; i++)
        {
            int[] commandNumbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            if (commandNumbers[0] == 1)
            {
                numbers.Push(commandNumbers[1]);
            }
            else if (commandNumbers[0] == 2)
            {
                if (numbers.Any())
                {
                    numbers.Pop();
                }
            }
            else if (commandNumbers[0] == 3)
            {
                if (numbers.Any())
                {
                    Console.WriteLine(numbers.Max());
                }
            }
            else if (commandNumbers[0] == 4)
            {
                if (numbers.Any())
                {
                    Console.WriteLine(numbers.Min());
                }
            }
        }

        Console.WriteLine(string.Join(", ", numbers));
    }
}