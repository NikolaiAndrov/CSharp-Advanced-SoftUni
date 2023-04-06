public class FashionBoutique
{
    public static void Main()
    {
        int[] inputClothes = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int capacity = int.Parse(Console.ReadLine());

        Stack<int> box = new Stack<int>(inputClothes);
        int shelves = 0;
        int sum = 0;

        while (box.Count > 0)
        {
            if (box.Peek() + sum < capacity)
            {
                sum += box.Pop();
            }
            else if (box.Peek() + sum == capacity)
            {
                sum += box.Pop();
                shelves++;
                sum = 0;
            }
            else if (box.Peek() + sum > capacity)
            {
                shelves++;
                sum = 0;
            }

            if (box.Count == 0 && sum > 0)
            {
                shelves++;
            }
        }

        Console.WriteLine(shelves);
    }
}