public class EvenTimes
{
    public static void Main()
    {
        Dictionary<int, int> nums = new Dictionary<int, int>();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            int num = int.Parse(Console.ReadLine());

            if (!nums.ContainsKey(num))
            {
                nums[num] = 0;
            }
            nums[num]++;
        }

        foreach (var num in nums)
        {
            if (num.Value % 2 == 0)
            {
                Console.WriteLine(num.Key);
                break;
            }
        }
    }
}