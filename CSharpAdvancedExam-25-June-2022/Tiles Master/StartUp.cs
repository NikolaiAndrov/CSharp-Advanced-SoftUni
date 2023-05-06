using System;
using System.Linq;
using System.Collections.Generic;

namespace Tiles_Master
{
    public class StartUp
    {
        public static void Main()
        {
            var whiteTiles = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            var greyTiles = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            var areasCount = new Dictionary<string, int>();

            while (whiteTiles.Count > 0 && greyTiles.Count > 0)
            {
                var white = whiteTiles.Pop();
                var grey = greyTiles.Dequeue();

                if (white == grey)
                {
                    var sum = white + grey;

                    if (sum == 40)
                    {
                        if (!areasCount.ContainsKey("Sink"))
                        {
                            areasCount["Sink"] = 0;
                        }
                        areasCount["Sink"]++;
                    }
                    else if (sum == 50)
                    {
                        if (!areasCount.ContainsKey("Oven"))
                        {
                            areasCount["Oven"] = 0;
                        }
                        areasCount["Oven"]++;
                    }
                    else if (sum == 60)
                    {
                        if (!areasCount.ContainsKey("Countertop"))
                        {
                            areasCount["Countertop"] = 0;
                        }
                        areasCount["Countertop"]++;
                    }
                    else if (sum == 70)
                    {
                        if (!areasCount.ContainsKey("Wall"))
                        {
                            areasCount["Wall"] = 0;
                        }
                        areasCount["Wall"]++;
                    }
                    else
                    {
                        if (!areasCount.ContainsKey("Floor"))
                        {
                            areasCount["Floor"] = 0;
                        }
                        areasCount["Floor"]++;
                    }

                    continue;
                }

                white /= 2;
                whiteTiles.Push(white);
                greyTiles.Enqueue(grey);
            }

            if (whiteTiles.Count == 0)
            {
                Console.WriteLine($"White tiles left: none");
            }
            else
            {
                Console.WriteLine($"White tiles left: {string.Join(", ", whiteTiles)}");
            }

            if (greyTiles.Count == 0)
            {
                Console.WriteLine("Grey tiles left: none");
            }
            else
            {
                Console.WriteLine($"Grey tiles left: {string.Join(", ", greyTiles)}");
            }

            foreach (var tile in areasCount.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{tile.Key}: {tile.Value}");
            }
        }
    }
}