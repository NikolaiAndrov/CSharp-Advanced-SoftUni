public class FastFood
{
    public static void Main()
    {
        int foodQuantity = int.Parse(Console.ReadLine());

        int[] inputOrders = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        Queue<int> orders = new Queue<int>(inputOrders);

        Console.WriteLine(orders.Max());

        while (true)
        {
            if (orders.Count == 0)
            {
                Console.WriteLine("Orders complete");
                Environment.Exit(0);
            }

            if (foodQuantity - orders.Peek() >= 0)
            {
                foodQuantity -= orders.Dequeue();
            }
            else if (foodQuantity - orders.Peek() < 0)
            {
                Console.WriteLine($"Orders left: {string.Join(" ", orders)}");
                Environment.Exit(0);
            }
        }
    }
}