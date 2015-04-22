using System.Collections.Generic;

namespace HackerRank
{
	using System;
	using System.Linq;

	public class CoinChangeProblem
	{

		public static long Solve(int n, int[] coins)
		{
			cache.Clear();
			return Calculate(n, coins, new List<int>(), 0, CreateCacheString);
		}

		private static readonly HashSet<string> cache = new HashSet<string>();

		private static long Calculate(int n, int[] coinsAvailable, IList<int> coinsUsed, long sum, Func<IList<int>, string> toCacheKey)
		{
			var cacheKey = toCacheKey(coinsUsed);
//			Debug.WriteLine(cacheKey);
			if (cache.Contains(toCacheKey(coinsUsed)))
			{
//				Debug.Write("Cache hit: ");
				coinsUsed.ToList().ForEach(Console.Write);
//				Debug.WriteLine("");
				return 0;
			}
			if (n == sum)
			{
//				Debug.Write("Correct: ");
				coinsUsed.ToList().ForEach(Console.Write);
//				Debug.WriteLine("");
				cache.Add(cacheKey);
				return 1;
			}
			if (sum > n) return 0;
			var result = 0L;
			foreach (var coin in coinsAvailable)
			{
				var newCoinsUsed = new List<int>();
				newCoinsUsed.AddRange(coinsUsed);
				newCoinsUsed.Add(coin);
				result += Calculate(n, coinsAvailable, newCoinsUsed, sum + coin, toCacheKey);
			}
//			Debug.WriteLine("Add to cache: " + cacheKey + " " + result);
			cache.Add(cacheKey);

			return result;
		}

		private static string CreateCacheString(IList<int> list)
		{
			return list.OrderBy(x => x).Aggregate("", (s, c) => s + c);
		}
	}
}
