namespace BirthdayCelebration
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class StartUp
    {
        public static void Main()
        {
            Queue<int> guests = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Stack<int> food = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            int wastedFood = 0;

            while (guests.Count > 0 && food.Count > 0)
            {
                int currentGuest = guests.Dequeue();
                int currentFood = food.Pop();

                if (currentFood >= currentGuest)
                {
                    wastedFood += currentFood - currentGuest;
                    continue;
                }

                currentGuest -= currentFood;

                while (currentGuest > 0 && food.Count > 0)
                {
                    int internalCurrentFood = food.Pop();
                    currentGuest -= internalCurrentFood;

                    if (currentGuest < 0)
                    {
                        wastedFood += Math.Abs(currentGuest);
                    }
                }
            }

            if (food.Count > 0)
            {
                Console.WriteLine($"Plates: {string.Join(" ", food)}");
            }

            if (guests.Count > 0)
            {
                Console.WriteLine($"Guests: {string.Join(" ", guests)}");
            }

            Console.WriteLine($"Wasted grams of food: {wastedFood}");
        }
    }
}