
namespace HackerRank
{
	using System.Linq;

	public class CoinChangeProblem
	{

		public static long Solve(int n, int[] coins)
		{
			cache = new long[n + 1, coins.Length + 1];
			var sortedCoins = coins.ToList();
			sortedCoins.Sort();
			return Calculate(n, coins.Length, sortedCoins.ToArray());
		}

		private static long[,] cache;

		private static long Calculate(int n, int m, int[] coins)
		{
			if (n == 0) return 1;
			if (m == 0 || n < 0) return 0;
			if (cache[n, m] != 0) return cache[n, m];
			cache[n,m] = Calculate(n - coins[m - 1], m, coins) + Calculate(n, m - 1, coins);
			return cache[n, m];
		}
	}
}
