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
			Console.WriteLine(Solve(n, m, list.ToArray()));
		}

		public static long Solve(int n, int m, int[] coins)
		{
			cache = new long[n + 1, coins.Length + 1];
			var sortedCoins = coins.ToList();
			sortedCoins.Sort();
			return Calculate(n, m, sortedCoins.ToArray());
		}

		private static long[,] cache;

		private static long Calculate(int n, int m, int[] coins)
		{
			if (n == 0) return 1;
			if (m == 0 || n < 0) return 0;
			if (cache[n, m] != 0) return cache[n, m];
			cache[n, m] = Calculate(n - coins[m - 1], m, coins) + Calculate(n, m - 1, coins);
			return cache[n, m];
		}
	}
}
