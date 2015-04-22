using System;

namespace HackerRank
{
	using System.Collections.Generic;
	using System.Linq;

	class Solution
	{
		static void Main(String[] args)
		{
			var splitElements = Console.ReadLine().Split(' ');
			var n = int.Parse(splitElements[0]);
			var m = int.Parse(splitElements[1]);
			var coins = Console.ReadLine().Split(' ');
			var list = new List<int>();
			for (var i = 0; i < m; i++)
			{
				list.Add(int.Parse(coins[i]));
			}
			Console.WriteLine(Solve(n, list.ToArray()));
		}

		public static int Solve(int n, int[] coins)
		{
			cache.Clear();
			return Calculate(n, coins, new List<int>(), 0, CreateCacheString);
		}

		private static readonly HashSet<string> cache = new HashSet<string>();

		private static int Calculate(int n, int[] coinsAvailable, IList<int> coinsUsed, int sum, Func<IList<int>, string> toCacheKey)
		{
			if (cache.Contains(toCacheKey(coinsUsed))) return 0;
			if (n == sum) return 1;
			if (sum > n) return 0;
			var result = 0;
			foreach (var coin in coinsAvailable)
			{
				var newCoinsUsed = new List<int>();
				newCoinsUsed.AddRange(coinsUsed);
				newCoinsUsed.Add(coin);
				var cacheKey = toCacheKey(newCoinsUsed);
				result += Calculate(n, coinsAvailable, newCoinsUsed, sum + coin, toCacheKey);
				if (!cache.Contains(cacheKey))
				{
					cache.Add(cacheKey);
				}
			}
			return result;
		}

		private static string CreateCacheString(IList<int> list)
		{
			return list.OrderBy(x => x).Aggregate("", (s, c) => s + c);
		}
	}
}
