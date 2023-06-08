namespace Lootbox
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            Queue<int> box1 = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Stack<int> box2 = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            
            int totalSum = 0;

            while (box1.Count > 0 && box2.Count > 0)
            {
                int item1 = box1.Peek();
                int item2 = box2.Pop();
                int sum = item1 + item2;

                if (sum % 2 == 0)
                {
                    totalSum += sum;
                    box1.Dequeue();
                    continue;
                }

                box1.Enqueue(item2);
            }

            if (box1.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }

            if (box2.Count == 0)
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if (totalSum >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {totalSum}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {totalSum}");
            }
        }
    }
}
