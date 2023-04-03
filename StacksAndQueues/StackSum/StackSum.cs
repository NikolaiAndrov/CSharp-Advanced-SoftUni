public class StackSum
{
    public static void Main()
    {
        var inputNums = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        var result = new Stack<int>(inputNums);

        string input;

        while ((input = Console.ReadLine().ToLower()) != "end")
        {
            var commandInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var command = commandInfo[0];

            if (command == "add")
            {
                var n1 = int.Parse(commandInfo[1]);
                var n2 = int.Parse(commandInfo[2]);

                result.Push(n1);
                result.Push(n2);
            }
            else if (command == "remove")
            {
                var n = int.Parse(commandInfo[1]);

                if (result.Count >= n)
                {
                    for (int i = 0; i < n; i++)
                    {
                        result.Pop();
                    }
                }
            }
        }

        var sum = GetSum(result);
        Console.WriteLine($"Sum: {sum}");
    }

    static int GetSum(Stack<int> result)
    {
        var sum = 0;

        while (result.Count > 0)
        {
            sum += result.Pop();
        }

        return sum;
    }
}