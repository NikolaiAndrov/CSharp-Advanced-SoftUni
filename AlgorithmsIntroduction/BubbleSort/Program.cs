namespace BubbleSort
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int[] nums = Console.ReadLine()
				.Split(" ", StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToArray();

			for (int i = 0; i < nums.Length; i++)
			{
				for (int j = i + 1; j < nums.Length; j++)
				{
					if (nums[j] < nums[i])
					{
						int temp = nums[i];
						nums[i] = nums[j];
						nums[j] = temp;
					}
				}
			}

			Console.WriteLine(string.Join(" ", nums));
		}
	}
}
