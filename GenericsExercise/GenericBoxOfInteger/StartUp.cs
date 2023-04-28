namespace GenericBoxOfInteger
{
    public class StartUp
    {
        public static void Main()
        {
            Box<int> box = new Box<int>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int item = int.Parse(Console.ReadLine());
                box.Add(item);
            }

            int[] indexesToSwap = Console.ReadLine().Split().Select(int.Parse).ToArray();
            box.Swap(indexesToSwap[0], indexesToSwap[1]);

            Console.WriteLine(box);
        }
    }
}