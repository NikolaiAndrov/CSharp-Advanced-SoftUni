namespace DiagonalSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] nums = new int[3, 3]
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 9, 8, 9 }
            };

            Console.WriteLine(DiagonalDifference(nums));
        }

        public static int DiagonalDifference(int[,] nums)
        {
            int leftDiagonalSum = 0;
            int rightDiagonalSum = 0;

            for (int row = 0; row < nums.GetLength(0); row++)
            {
                leftDiagonalSum += nums[row, row];
                rightDiagonalSum += nums[row, nums.GetLength(0) - 1 - row];
            }

            int absValue = Math.Abs(leftDiagonalSum - rightDiagonalSum);
            return absValue;
        }

    }
}
