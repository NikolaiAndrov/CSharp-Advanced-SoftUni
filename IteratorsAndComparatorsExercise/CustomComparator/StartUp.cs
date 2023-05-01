namespace CustomComparator
{
    public class StartUp
    {
        public static void Main()
        {
            Func<int, int, int> func = (x, y) =>
            {
                if (x % 2 == 0 && y % 2 != 0)
                { 
                    return -1;
                }
                else if (x % 2 != 0 && y % 2 == 0)
                {
                    return 1;
                }

                return x.CompareTo(y);
            };

            int[] nums = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Array.Sort(nums, (x, y) => func(x, y));
            Console.WriteLine(string.Join(" ", nums));
        }
    }
}