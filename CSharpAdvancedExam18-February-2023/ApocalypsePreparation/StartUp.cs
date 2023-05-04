namespace ApocalypsePreparation
{
    public class StartUp
    {
        public static void Main()
        {
            var textiles = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            var medicaments = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            var patch = "Patch";
            var bandage = "Bandage";
            var medKit = "MedKit";
            var healingItemsCount = new Dictionary<string, int>();

            while (textiles.Count > 0 && medicaments.Count > 0)
            {
                var textileItem = textiles.Dequeue();
                var medicamentItem = medicaments.Pop();
                var itemsSum = textileItem + medicamentItem;

                if (itemsSum == 30)
                {
                    if (!healingItemsCount.ContainsKey(patch))
                    {
                        healingItemsCount[patch] = 0;
                    }
                    healingItemsCount[patch]++;
                    continue;
                }
                else if (itemsSum == 40)
                {
                    if (!healingItemsCount.ContainsKey(bandage))
                    {
                        healingItemsCount[bandage] = 0;
                    }
                    healingItemsCount[bandage]++;
                    continue;
                }
                else if(itemsSum == 100)
                {
                    if (!healingItemsCount.ContainsKey(medKit))
                    {
                        healingItemsCount[medKit] = 0;
                    }
                    healingItemsCount[medKit]++;
                    continue;
                }
                else if (itemsSum > 100)
                {
                    if (!healingItemsCount.ContainsKey(medKit))
                    {
                        healingItemsCount[medKit] = 0;
                    }
                    healingItemsCount[medKit]++;
                    var diff = itemsSum - 100;
                    if (medicaments.Count > 0)
                    {
                        var currentItem = medicaments.Pop();
                        currentItem += diff;
                        medicaments.Push(currentItem);
                    }
                    else
                    {
                        medicaments.Push(diff);
                    }
                    continue;
                }

                medicamentItem += 10;
                medicaments.Push(medicamentItem);
            }

            if (textiles.Count == 0 && medicaments.Count == 0)
            {
                Console.WriteLine("Textiles and medicaments are both empty.");
            }
            else if (textiles.Count == 0)
            {
                Console.WriteLine("Textiles are empty.");
            }
            else if (medicaments.Count == 0)
            {
                Console.WriteLine("Medicaments are empty.");
            }

            PrintHealingItems(healingItemsCount);

            if (medicaments.Count > 0)
            {
                Console.WriteLine($"Medicaments left: {string.Join(", ", medicaments)}");
            }

            if (textiles.Count > 0)
            {
                Console.WriteLine($"Textiles left: {string.Join(", ", textiles)}");
            }
        }

        static void PrintHealingItems(Dictionary<string, int> healingItemsCount)
        {
            foreach (var item in healingItemsCount.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
        }
    }
}