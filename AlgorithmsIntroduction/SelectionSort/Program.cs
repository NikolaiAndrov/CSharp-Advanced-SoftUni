namespace SelectionSort
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
				int index = i;
				int min = int.MaxValue;

				for (int j = i + 1; j < nums.Length; j++)
				{
					if (nums[j] < nums[i] && nums[j] < min)
					{
						index = j;
						min = nums[j];
					}
				}

				int temp = nums[i];
				nums[i] = nums[index];
				nums[index] = temp;
            }

			Console.WriteLine(string.Join(" ", nums));
        }
	}
}
