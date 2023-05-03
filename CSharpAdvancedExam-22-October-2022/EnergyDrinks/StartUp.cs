namespace EnergyDrinks
{
    public class StartUp
    {
        public static void Main()
        {
            var inputCaffeine = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var caffeine = new Stack<int>(inputCaffeine);

            var inputEnergyDrinks = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var energyDrinks = new Queue<int>(inputEnergyDrinks);

            int totalCaffeine = 0;

            while (caffeine.Count > 0 && energyDrinks.Count > 0)
            {
                int currentCaffeine = caffeine.Pop();
                int currentEnergyDrink = energyDrinks.Dequeue();
                int multiplication = currentCaffeine * currentEnergyDrink;

                if (multiplication + totalCaffeine <= 300)
                {
                    totalCaffeine += multiplication;
                    continue;
                }

                energyDrinks.Enqueue(currentEnergyDrink);

                if (totalCaffeine - 30 >= 0)
                {
                    totalCaffeine -= 30;
                }
            }

            if (energyDrinks.Count > 0)
            {
                Console.WriteLine($"Drinks left: {string.Join(", ", energyDrinks)}");
            }
            else
            {
                Console.WriteLine($"At least Stamat wasn't exceeding the maximum caffeine.");
            }

            Console.WriteLine($"Stamat is going to sleep with {totalCaffeine} mg caffeine.");
        }
    }
}