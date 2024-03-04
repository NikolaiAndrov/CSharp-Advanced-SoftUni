namespace RecursiveArraySum2._0
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int[] nums = Console.ReadLine()
				.Split(" ", StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToArray();

			int sum = SumArray(nums, 0);
			Console.WriteLine(sum);
		}

		private static int SumArray(int[] nums, int index)
		{
			if (index == nums.Length)
			{
				return 0;
			}

			int num = nums[index];
			int next = SumArray(nums, index + 1);

			int sum = num + next;

			return sum;
		}
	}
}
