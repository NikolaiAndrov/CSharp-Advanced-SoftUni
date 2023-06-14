namespace FlowerWreaths
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Stack<int> lilies = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse));
            Queue<int> roses = new Queue<int>(Console.ReadLine().Split(", ").Select(int.Parse));
            int wreaths = 0;
            int remainingFlowers = 0;

            while (lilies.Count> 0 && roses.Count > 0)
            {
                int lily = lilies.Peek();
                int rose = roses.Peek();
                int flowers = lily + rose;

                if (flowers == 15)
                {
                    wreaths++;
                    lilies.Pop();
                    roses.Dequeue();
                }
                else if (flowers < 15)
                {
                    remainingFlowers += flowers;
                    lilies.Pop();
                    roses.Dequeue();
                }
                else if (flowers > 15)
                {
                    lily -= 2;
                    lilies.Pop();
                    lilies.Push(lily);
                }
            }

            remainingFlowers /= 15;
            wreaths += remainingFlowers;

            if (wreaths >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreaths} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 -wreaths} wreaths more!");
            }
        }
    }
}
