using System;
using System.Linq;
using System.Collections.Generic;
namespace BaristaContest
{
    public class StartUp
    {
        public static void Main()
        {
            var coffee = new Queue<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            var milk = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            
            var drinksCounter = new Dictionary<string, int>();

            while (coffee.Count > 0 && milk.Count > 0)
            {
                var currentCoffee = coffee.Dequeue();
                var currentMilk = milk.Pop();
                var sum = currentCoffee + currentMilk;

                if (sum == 50)
                {
                    if (!drinksCounter.ContainsKey("Cortado"))
                    {
                        drinksCounter["Cortado"] = 0;
                    }
                    drinksCounter["Cortado"]++;
                }
                else if (sum == 75)
                {
                    if (!drinksCounter.ContainsKey("Espresso"))
                    {
                        drinksCounter["Espresso"] = 0;
                    }
                    drinksCounter["Espresso"]++;
                }
                else if (sum == 100)
                {
                    if (!drinksCounter.ContainsKey("Capuccino"))
                    {
                        drinksCounter["Capuccino"] = 0;
                    }
                    drinksCounter["Capuccino"]++;
                }
                else if(sum == 150)
                {
                    if (!drinksCounter.ContainsKey("Americano"))
                    {
                        drinksCounter["Americano"] = 0;
                    }
                    drinksCounter["Americano"]++;
                }
                else if (sum == 200)
                {
                    if (!drinksCounter.ContainsKey("Latte"))
                    {
                        drinksCounter["Latte"] = 0;
                    }
                    drinksCounter["Latte"]++;
                }
                else
                {
                    currentMilk -= 5;
                    milk.Push(currentMilk);
                }
            }

            if (milk.Count == 0 && coffee.Count == 0)
            {
                Console.WriteLine("Nina is going to win! She used all the coffee and milk!");
            }
            else if(milk.Count > 0 || coffee.Count > 0) 
            {
                Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");
            }

            if (coffee.Count == 0)
            {
                Console.WriteLine("Coffee left: none");
            }
            else
            {
                Console.WriteLine($"Coffee left: {string.Join(", ", coffee)}");
            }

            if (milk.Count == 0)
            {
                Console.WriteLine("Milk left: none");
            }
            else
            {
                Console.WriteLine($"Milk left: {string.Join(", ", milk)}");
            }

            foreach (var drink in drinksCounter.OrderBy(x => x.Value).ThenByDescending(x => x.Key))
            {
                Console.WriteLine($"{drink.Key}: {drink.Value}");
            }
        }
    }
}