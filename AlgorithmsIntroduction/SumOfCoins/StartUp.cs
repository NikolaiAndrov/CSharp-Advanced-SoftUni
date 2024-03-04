namespace SumOfCoins
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	public class StartUp
    {
        public static void Main(string[] args)
        {
            List<int> coins = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToList();

            int sum = int.Parse(Console.ReadLine());

			Dictionary<int, int> coinsTaken = ChooseCoins(coins, sum);
            int coinsCount = coinsTaken.Sum(c => c.Value);

            Console.WriteLine($"Number of coins to take: {coinsCount}");

            foreach (var coin in coinsTaken)
            {
                Console.WriteLine($"{coin.Value} coin(s) with value {coin.Key}");
            }
		}

        public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
        {
            coins = coins.OrderBy(x => x).ToList();
            Dictionary<int, int> coinsTaken = new Dictionary<int, int>();
            int index = coins.Count - 1;

            while (targetSum > 0)
            {
                if (index < 0)
                {
                    break;
                }

                int currentCoin = coins[index];
                int coinsNeeded = targetSum / currentCoin;

                if (coinsNeeded < 1)
                {
                    index--;
                    continue;
                }

                coinsTaken[currentCoin] = coinsNeeded;
                targetSum -= coinsNeeded * currentCoin;
            }

            if (targetSum > 0 && index < 0)
            {
                throw new InvalidOperationException();
            }

            return coinsTaken;
        }
    }
}