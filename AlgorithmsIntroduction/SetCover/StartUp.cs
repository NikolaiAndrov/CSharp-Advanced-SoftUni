namespace SetCover
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	class StartUp
    {
        static void Main(string[] args)
        {
            List<int> universe = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int setCount = int.Parse(Console.ReadLine());

            List<int[]> sets = new List<int[]>();

            for (int i = 0; i < setCount; i++)
            {
                int[] set = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                sets.Add(set);
            }

            List<int[]> setsResult = ChooseSets(sets, universe);

            Console.WriteLine($"Sets to take ({setsResult.Count}):");

            foreach (var set in setsResult)
            {
                Console.WriteLine($"{{ {string.Join(", ", set)} }}");
            }
		}

        public static List<int[]> ChooseSets(IList<int[]> sets, IList<int> universe)
        {
            List<int[]> setsResult = new List<int[]>();

            while (sets.Count > 0 && universe.Count > 0)
            {
                int[] largestSet = sets
                    .OrderByDescending(s => s.Count(s => universe.Contains(s)))
                    .FirstOrDefault();

                if (largestSet == null)
                {
                    break;
                }

                setsResult.Add(largestSet);
                sets.Remove(largestSet);

                foreach (var num in largestSet)
                {
                    universe.Remove(num);
                }
            }

            return setsResult;
        }
    }
}
