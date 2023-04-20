public class ListOfPredicates
{
    public static void Main()
    {
        Func<int[], int[], List<int>> filter = (nums, divisors) =>
        {
            var list = new List<int>();
            
            foreach (var num in nums)
            {
                var isDivisible = true;

                foreach (var divisor in divisors)
                {
                    if (num % divisor != 0)
                    {
                        isDivisible = false;
                        break;
                    }
                }

                if (isDivisible)
                {
                    list.Add(num);
                }
            }
            return list;
        };
        Action<List<int>> pritnCollection = collection => Console.WriteLine(string.Join(" ", collection));
        var inputNums = Enumerable.Range(1, int.Parse(Console.ReadLine())).ToArray();
        var divisors = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Distinct().ToArray();
        List<int> list = filter(inputNums, divisors);
        pritnCollection(list);
    }
}