public class ReverseAndExclude
{
    public static void Main()
    {
        Func<int, int, bool> compareNums = (x, y) =>  x % y != 0;
        Action<int[]> printCollection = collection => Console.WriteLine(string.Join(" ", collection));

        int[] inputNums = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse) 
            .Reverse()
            .ToArray();

        int actionNum = int.Parse(Console.ReadLine());

        int[] nums = inputNums.Where(x => compareNums(x, actionNum)).ToArray();
      
        printCollection(nums);
    }
}