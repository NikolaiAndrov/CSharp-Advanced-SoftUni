public class CupsAndBottles
{
    public static void Main()
    {
        int[] cupsInput = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int[] inputBottles = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        Queue<int> cups = new Queue<int>(cupsInput);
        Stack<int> bottles = new Stack<int>(inputBottles);
        int wastedLittres = 0;

        while (cups.Count > 0 && bottles.Count > 0)
        {
            int currentCup = cups.Peek();
            int currentBottle = bottles.Pop();

            if (currentCup - currentBottle <= 0)
            {
                wastedLittres += currentBottle - currentCup;
                cups.Dequeue();
                continue;
            }

            currentCup -= currentBottle;

            while (currentCup > 0 && bottles.Count > 0)
            {
                int antotherBottle = bottles.Pop();

                if (currentCup - antotherBottle <= 0)
                {
                    wastedLittres += antotherBottle - currentCup;
                    cups.Dequeue();
                    break;
                }

                currentCup -= antotherBottle;
            }
        }

        if (bottles.Count > 0 && cups.Count == 0)
        {
            Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
        }
        else if (cups.Count > 0 && bottles.Count == 0)
        {
            Console.WriteLine($"Cups: {string.Join(" ", cups)}");
        }
        else if (bottles.Count > 0 && cups.Count > 0)
        {
            Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
            Console.WriteLine($"Cups: {string.Join(" ", cups)}");
        }

        Console.WriteLine($"Wasted litters of water: {wastedLittres}");
    }
}