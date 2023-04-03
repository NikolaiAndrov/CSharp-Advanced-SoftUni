public class HotPotato
{
    public static void Main()
    {
        var inputKids = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries);

        var kids = new Queue<string>(inputKids);

        var n = int.Parse(Console.ReadLine());
        var passes = 1;

        while (kids.Count > 1)
        {
            var kid = kids.Dequeue();

            if (passes == n)
            {
                Console.WriteLine($"Removed {kid}");
                passes = 1;
                continue;
            }

            kids.Enqueue(kid);
            passes++;
        }

        Console.WriteLine($"Last is {kids.Dequeue()}");
    }
}