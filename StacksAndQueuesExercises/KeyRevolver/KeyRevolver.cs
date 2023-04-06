public class KeyRevolver
{
    public static void Main()
    {
        int bulletPrice = int.Parse(Console.ReadLine());
        int gunBarrel = int.Parse(Console.ReadLine());

        int[] inputBullets = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int[] inputLocks = Console.ReadLine() 
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int intelligence = int.Parse(Console.ReadLine());

        Stack<int> bullets = new Stack<int>(inputBullets);
        Queue<int> locks = new Queue<int>(inputLocks);

        int bulletsCount = 0;
        int bulletsFired = 0;

        while (bullets.Count > 0 && locks.Count > 0)
        {
            int currentBullet = bullets.Pop();
            int currentLock = locks.Peek();
            bulletsCount++;
            bulletsFired++;

            if (currentBullet <= currentLock)
            {
                locks.Dequeue();
                Console.WriteLine("Bang!");
            }
            else if (currentBullet > currentLock)
            {
                Console.WriteLine("Ping!");
            }

            if (bulletsFired == gunBarrel && bullets.Count > 0)
            {
                bulletsFired = 0;
                Console.WriteLine("Reloading!");
            }
        }

        if (bullets.Count == 0 && locks.Count > 0)
        {
            Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
        }
        else if (locks.Count == 0)
        {
            int bulletCost = bulletsCount * bulletPrice;
            int earned = intelligence - bulletCost;
            Console.WriteLine($"{bullets.Count} bullets left. Earned ${earned}");
        }
    }
}