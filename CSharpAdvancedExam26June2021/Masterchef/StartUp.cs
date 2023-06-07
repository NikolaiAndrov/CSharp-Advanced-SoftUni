namespace Masterchef
{

    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Queue<int> ingredients = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Stack<int> freshness = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            Dictionary<string, int> meals = new Dictionary<string, int>();

            while (ingredients.Count > 0 && freshness.Count > 0)
            {
                int currentIngredient = ingredients.Dequeue();

                if (currentIngredient == 0)
                {
                    continue;
                }

                int currentFreshness = freshness.Pop();

                int multiplication = currentIngredient * currentFreshness;

                if (multiplication == 150)
                {
                    if (!meals.ContainsKey("Dipping sauce"))
                    {
                        meals["Dipping sauce"] = 0;
                    }

                    meals["Dipping sauce"]++;
                }
                else if (multiplication == 250)
                {
                    if (!meals.ContainsKey("Green salad"))
                    {
                        meals["Green salad"] = 0;
                    }

                    meals["Green salad"]++;
                }
                else if (multiplication == 300)
                {
                    if (!meals.ContainsKey("Chocolate cake"))
                    {
                        meals["Chocolate cake"] = 0;
                    }

                    meals["Chocolate cake"]++;
                }
                else if (multiplication == 400)
                {
                    if (!meals.ContainsKey("Lobster"))
                    {
                        meals["Lobster"] = 0;
                    }

                    meals["Lobster"]++;
                }
                else
                {
                    currentIngredient += 5;
                    ingredients.Enqueue(currentIngredient);
                }
            }

            if (meals.Count == 4)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }

            if (ingredients.Count > 0)
            {
                Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
            }

            foreach (var meal in meals.OrderBy(x => x.Key))
            {
                Console.WriteLine($" # {meal.Key} --> {meal.Value}");
            }
        }
    }
}