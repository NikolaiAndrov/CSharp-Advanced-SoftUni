using System;
using System.Linq;
using System.Collections.Generic;

namespace BakeryShop
{
    public class StartUp
    {
        public static void Main()
        {
            var water = new Queue<double>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse));

            var flour = new Stack<double>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse));

            var bakedProducts = new Dictionary<string, int>();

            while (water.Count > 0 && flour.Count > 0)
            {
                double currentWater = water.Dequeue();
                double currentFlour = flour.Pop();
                double sum = currentWater + currentFlour;
                double waterPercent = (currentWater * 100) / sum;
                double flourPercent = (currentFlour * 100) / sum;

                if (waterPercent == 50 && flourPercent == 50)
                {
                    IncreaseCroissantCount(bakedProducts);
                }
                else if (waterPercent == 40 && flourPercent == 60)
                {
                    if (!bakedProducts.ContainsKey("Muffin"))
                    {
                        bakedProducts["Muffin"] = 0;
                    }
                    bakedProducts["Muffin"]++;
                }
                else if (waterPercent == 30 && flourPercent == 70)
                {
                    if (!bakedProducts.ContainsKey("Baguette"))
                    {
                        bakedProducts["Baguette"] = 0;
                    }
                    bakedProducts["Baguette"]++;
                }
                else if (waterPercent == 20 && flourPercent == 80)
                {
                    if (!bakedProducts.ContainsKey("Bagel"))
                    {
                        bakedProducts["Bagel"] = 0;
                    }
                    bakedProducts["Bagel"]++;
                }
                else
                {
                    while (currentFlour < currentWater && flour.Count > 0)
                    {
                        currentFlour += flour.Pop();
                    }

                    double diff = currentFlour - currentWater;
                    currentFlour -= diff;
                    flour.Push(diff);
                    IncreaseCroissantCount(bakedProducts);
                }
            }

            foreach (var product in bakedProducts.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{product.Key}: {product.Value}");
            }

            if (water.Count == 0)
            {
                Console.WriteLine("Water left: None");
            }
            else
            {
                Console.WriteLine($"Water left: {string.Join(", ", water)}");
            }

            if (flour.Count == 0)
            {
                Console.WriteLine("Flour left: None");
            }
            else
            {
                Console.WriteLine($"Flour left: {string.Join(", ", flour)}");
            }
        }

        static void IncreaseCroissantCount(Dictionary<string, int> bakedProducts)
        {
            if (!bakedProducts.ContainsKey("Croissant"))
            {
                bakedProducts["Croissant"] = 0;
            }
            bakedProducts["Croissant"]++;
        }
    }
}