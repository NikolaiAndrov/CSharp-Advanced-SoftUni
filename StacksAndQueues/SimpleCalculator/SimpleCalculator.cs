public class SimpleCalculator
{
    public static void Main()
    {
        var expression = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Reverse()
            .ToArray();

        var stack = new Stack<string>(expression);
        var result = int.Parse(stack.Pop());

        while (stack.Count > 0)
        {
            var item = stack.Pop();

            if (item == "+")
            {
                var n = int.Parse(stack.Pop());
                result += n;
            }
            else if (item == "-")
            {
                var n = int.Parse(stack.Pop());
                result -= n;
            }
        }

        Console.WriteLine(result);
    }
}