public class CustomMinFunction
{
    public static void Main()
    {
        Func<int[], int> getMin = numbers =>
        {
            int min = int.MaxValue;

            foreach (int number in numbers)
            {
                if (number < min)
                {
                    min = number;
                }
            }

            return min;
        };

        var numbers = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int minNumber = getMin(numbers);
        Console.WriteLine(minNumber);
    }
}