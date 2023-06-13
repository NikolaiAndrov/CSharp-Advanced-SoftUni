namespace Bombs
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Queue<int> bombEffect = new Queue<int>(Console.ReadLine().Split(", ").Select(int.Parse));
            Stack<int> bombCasing = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse));
            Dictionary<string, int> bombCount = new Dictionary<string, int>
            {
                { "Datura Bombs", 0 },
                { "Cherry Bombs", 0 },
                { "Smoke Decoy Bombs", 0 }
            };
            bool allBombsCreated = false;

            while (bombEffect.Count > 0 && bombCasing.Count > 0)
            {
                int currentBombEffect = bombEffect.Peek();
                int currentBombCasing = bombCasing.Peek();
                int bombSum = currentBombEffect + currentBombCasing;

                if (bombSum == 40)
                {
                    bombCount["Datura Bombs"]++;
                    bombEffect.Dequeue();
                    bombCasing.Pop();
                }
                else if (bombSum == 60)
                {
                    bombCount["Cherry Bombs"]++;
                    bombEffect.Dequeue();
                    bombCasing.Pop();
                }
                else if (bombSum == 120)
                {
                    bombCount["Smoke Decoy Bombs"]++;
                    bombEffect.Dequeue();
                    bombCasing.Pop();
                }
                else
                {
                    currentBombCasing -= 5;
                    bombCasing.Pop();
                    bombCasing.Push(currentBombCasing);
                }

                if (bombCount.ContainsKey("Datura Bombs") && bombCount["Datura Bombs"] >= 3 &&
                   bombCount.ContainsKey("Cherry Bombs") && bombCount["Cherry Bombs"] >= 3 &&
                    bombCount.ContainsKey("Smoke Decoy Bombs") && bombCount["Smoke Decoy Bombs"] >= 3)
                {
                    allBombsCreated = true;
                    break;
                }
            }

            if (allBombsCreated)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (bombEffect.Count == 0)
            {
                Console.WriteLine("Bomb Effects: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ", bombEffect)}");
            }

            if (bombCasing.Count == 0)
            {
                Console.WriteLine("Bomb Casings: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", bombCasing)}");
            }

            foreach (var bomb in bombCount.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{bomb.Key}: {bomb.Value}");
            }
        }
    }
}
