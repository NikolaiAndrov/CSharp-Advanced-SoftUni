namespace Blacksmith
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class StartUp
    {
        public static void Main()
        {
            Queue<int> inputSteel = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Stack<int> inputCarbon = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            Dictionary<string, int> swords = new Dictionary<string, int>();

            while (inputSteel.Count > 0 && inputCarbon.Count > 0)
            {
                int currentSteel = inputSteel.Dequeue();
                int currentCarbon = inputCarbon.Pop();
                int sum = currentSteel + currentCarbon;

                if (sum == 70)
                {
                    if (!swords.ContainsKey("Gladius"))
                    {
                        swords["Gladius"] = 0;
                    }
                    swords["Gladius"]++;
                }
                else if (sum == 80)
                {
                    if (!swords.ContainsKey("Shamshir"))
                    {
                        swords["Shamshir"] = 0;
                    }
                    swords["Shamshir"]++;
                }
                else if (sum == 90)
                {
                    if (!swords.ContainsKey("Katana"))
                    {
                        swords["Katana"] = 0;
                    }
                    swords["Katana"]++;
                }
                else if (sum == 110)
                {
                    if (!swords.ContainsKey("Sabre"))
                    {
                        swords["Sabre"] = 0;
                    }
                    swords["Sabre"]++;
                }
                else if (sum == 150)
                {
                    if (!swords.ContainsKey("Broadsword"))
                    {
                        swords["Broadsword"] = 0;
                    }
                    swords["Broadsword"]++;
                }
                else
                {
                    currentCarbon += 5;
                    inputCarbon.Push(currentCarbon);
                }
            }

            if (swords.Count > 0)
            {
                Console.WriteLine($"You have forged {swords.Values.Sum()} swords.");
            }
            else
            {
                Console.WriteLine("You did not have enough resources to forge a sword.");
            }

            if (inputSteel.Count == 0)
            {
                Console.WriteLine("Steel left: none");
            }
            else
            {
                Console.WriteLine($"Steel left: {string.Join(", ", inputSteel)}");
            }

            if (inputCarbon.Count == 0)
            {
                Console.WriteLine("Carbon left: none");
            }
            else
            {
                Console.WriteLine($"Carbon left: {string.Join(", ", inputCarbon)}");
            }

            foreach (var sword in swords.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{sword.Key}: {sword.Value}");
            }
        }
    }
}