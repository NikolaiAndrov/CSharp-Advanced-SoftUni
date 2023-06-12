namespace Cooking
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Queue<int> liquids = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Stack<int> ingredients = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            Dictionary<string, int> food = new Dictionary<string, int>
            {
                { "Bread", 0},
                { "Cake", 0},
                { "Pastry", 0},
                { "Fruit Pie", 0}
            };

            while (liquids.Count > 0 && ingredients.Count > 0)
            {
                int currentLiquid = liquids.Dequeue();
                int currentIngredient = ingredients.Pop();
                int sum = currentLiquid + currentIngredient;

                if (sum == 25)
                {
                    food["Bread"]++;
                }
                else if (sum == 50)
                {
                    food["Cake"]++;
                }
                else if (sum == 75)
                {
                    food["Pastry"]++;
                }
                else if (sum == 100)
                {
                    food["Fruit Pie"]++;
                }
                else
                {
                    currentIngredient += 3;
                    ingredients.Push(currentIngredient);
                }
            }

            if (food["Bread"] > 0 && food["Cake"] > 0 &&
                food["Pastry"] > 0 && food["Fruit Pie"] > 0)
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }

            if (liquids.Count == 0)
            {
                Console.WriteLine("Liquids left: none");
            }
            else
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", liquids)}");
            }

            if (ingredients.Count == 0)
            {
                Console.WriteLine("Ingredients left: none");
            }
            else
            {
                Console.WriteLine($"Ingredients left: {string.Join(", ", ingredients)}");
            }

            foreach (var item in food.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
