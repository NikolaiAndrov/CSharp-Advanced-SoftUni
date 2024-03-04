namespace RecursiveArraySum
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int[] array = Console.ReadLine()
				.Split(" ", StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToArray();

			int sum = ArraySum(array);
			Console.WriteLine(sum);
		}

		static int ArraySum(int[] array)
		{
			if (array.Length == 1)
			{
				return array[0];
			}

			int[] restArray = array.Skip(1).ToArray();
			int restArraySum = ArraySum(restArray);

			return array[0] + restArraySum;
		}
	}
}
