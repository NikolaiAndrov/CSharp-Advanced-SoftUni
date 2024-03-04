namespace Recursion
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());
            Console.WriteLine(Factorial(n));
        }

		public static int Factorial(int n) 
		{
			if (n == 1)
			{
				return 1;
			}

			int result = n * Factorial(n - 1);

			return result;
        }
	}
}
