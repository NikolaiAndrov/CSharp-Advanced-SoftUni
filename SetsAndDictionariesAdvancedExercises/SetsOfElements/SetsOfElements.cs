public class SetsOfElements
{
    public static void Main()
    {
        int[] size = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int n = size[0];
        int m = size[1];

        HashSet<int> setN = new HashSet<int>();
        HashSet<int> setM = new HashSet<int>();

        for (int i = 0; i < n; i++)
        {
            int num = int.Parse(Console.ReadLine());
            setN.Add(num);
        }

        for (int i = 0; i < m; i++)
        {
            int num = int.Parse(Console.ReadLine());
            setM.Add(num);
        }

        List<int> nums = setN.Intersect(setM).ToList();
        Console.WriteLine(string.Join(" ", nums));
    }
}