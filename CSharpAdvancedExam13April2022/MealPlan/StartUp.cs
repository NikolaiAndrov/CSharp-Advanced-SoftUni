using System;
using System.Linq;
using System.Collections.Generic;

namespace MealPlan
{
    public class StartUp
    {
        public static void Main()
        {
            var meals = new Queue<string>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries));

            var calories = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            var mealTable = new Dictionary<string, int>();
            mealTable.Add("salad", 350);
            mealTable.Add("soup", 490);
            mealTable.Add("pasta", 680);
            mealTable.Add("steak", 790);

            var mealsEaten = 0;
            bool eatEnough = false;

            while (meals.Count > 0 && calories.Count > 0)
            {
                var currentMeal = meals.Dequeue();
                var currentCalories = calories.Pop();
                var caloriesToExtract = mealTable[currentMeal];
                var diff = caloriesToExtract - currentCalories;

                if (diff == 0)
                {
                    mealsEaten++;
                    continue;
                }

                if (diff < 0)
                {
                    calories.Push(currentCalories - caloriesToExtract);
                    mealsEaten++;
                    continue;
                }

                if (diff > 0 && calories.Count == 0)
                {
                    mealsEaten++;
                    eatEnough = true;
                    break;
                }

                while (diff > 0 && calories.Count > 0)
                {
                    var internalCalories = calories.Pop();

                    if (diff - internalCalories == 0)
                    {
                        mealsEaten++;
                        diff -= internalCalories;
                    }
                    else if (diff - internalCalories < 0)
                    {
                        mealsEaten++;
                        calories.Push(internalCalories - diff);
                        diff -= internalCalories;
                    }
                }
            }

            if (!eatEnough)
            {
                Console.WriteLine($"John had {mealsEaten} meals.");
                Console.WriteLine($"For the next few days, he can eat {string.Join(", ", calories)} calories.");
            }
            else if (eatEnough)
            {
                Console.WriteLine($"John ate enough, he had {mealsEaten} meals.");
                Console.WriteLine($"Meals left: {string.Join(", ", meals)}.");
            }
        }
    }
}