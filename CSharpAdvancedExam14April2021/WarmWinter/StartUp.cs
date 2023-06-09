namespace WarmWinter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Stack<int> hats = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            Queue<int> scarfs = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            List<int> sumPairs = new List<int>();

            while (hats.Count > 0 && scarfs.Count > 0)
            {
                int currentHat = hats.Peek();
                int currentScarf = scarfs.Peek();

                if (currentHat > currentScarf)
                {
                    sumPairs.Add(currentHat + currentScarf);
                    hats.Pop();
                    scarfs.Dequeue();
                    continue;
                }
                else if (currentHat == currentScarf)
                {
                    hats.Pop();
                    currentHat += 1;
                    hats.Push(currentHat);
                    scarfs.Dequeue();
                    continue;
                }

                while (hats.Count > 0)
                {
                    int internalHat = hats.Peek();

                    if (internalHat > currentScarf)
                    {
                        sumPairs.Add(internalHat + currentScarf);
                        hats.Pop();
                        scarfs.Dequeue();
                        break;
                    }
                    else if (internalHat == currentScarf)
                    {
                        hats.Pop();
                        internalHat += 1;
                        hats.Push(internalHat);
                        scarfs.Dequeue();
                        break;
                    }

                    hats.Pop();
                }
            }

            Console.WriteLine($"The most expensive set is: {sumPairs.Max()}");
            Console.WriteLine(string.Join(" ", sumPairs));
        }
    }
}
