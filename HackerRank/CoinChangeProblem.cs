using System.Collections.Generic;

namespace HackerRank
{
	using System.Diagnostics;
	using System.Linq;

	public class CoinChangeProblem
	{

		public static int Solve(int n, int[] coins)
		{
			return Calculate(n, coins, new List<int>(), 0);
		}

		private static readonly Dictionary<string, int> cache = new Dictionary<string, int>();

		private static int Calculate(int n, int[] coinsAvailable, List<int> coinsUsed, int sum)
		{
			var key = coinsUsed.OrderBy(x => x).Aggregate("", (s, c) => s + c);
			Debug.WriteLine("Look for: " + key);
			if (cache.ContainsKey(key))
			{
				int cachedRes;
				cache.TryGetValue(key, out cachedRes);
				Debug.WriteLine("Hit cache: " + key + " " + cachedRes);
				return 0;
			}
			if (n == sum)
			{
				Debug.Write("****** Found coins:");
				foreach (var coin in coinsUsed)
				{
					Debug.Write(coin);
				}
				Debug.WriteLine("\n");
				return 1;
			}
			if (sum > n) return 0;
			var result = 0;
			for (var i = 0; i < coinsAvailable.Length; i++)
			{
				var coin = coinsAvailable[i];
				var newCoinsUsed = new List<int>();
				newCoinsUsed.AddRange(coinsUsed);
				newCoinsUsed.Add(coin);
				var cacheKey = newCoinsUsed.OrderBy(x => x).Aggregate("", (s, c) => s + c);
				result += Calculate(n, coinsAvailable, newCoinsUsed, sum + coin);
				if (!cache.ContainsKey(cacheKey))
				{
					Debug.WriteLine("Cache:" + cacheKey);
					cache.Add(cacheKey, result);
				}
			}
			return result;
		}
	}
}
