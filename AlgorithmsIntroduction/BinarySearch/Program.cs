namespace BinarySearch
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int[] nums = Console.ReadLine()
				.Split(" ", StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToArray();

			int num = int.Parse(Console.ReadLine());

			int index = FindIndexOfNumber(nums, num);

            Console.WriteLine(index);
        }

		static int FindIndexOfNumber(int[] nums, int num)
		{
			int low = 0;
			int high = nums.Length - 1;

			while (low <= high)
			{
				int mid = (low + high) / 2;
				int midNum = nums[mid];

				if (num > midNum)
				{
					low = mid + 1;
				}
				else if (num < midNum)
				{
					high = mid - 1;
				}
				else
				{
					return mid;
				}
			}

			return -1;
		}
	}
}
