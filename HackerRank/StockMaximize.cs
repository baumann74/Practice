using System.Diagnostics;
using System.Linq;

namespace HackerRank
{
	public class StockMaximize
	{
		private static long[,] cache;

		public static long Solve(long n, int[] list)
		{
			cache = new long[n, n];
			return Helper(0, list, 0, 0);
		}

		private static long Helper(long t, int[] list, long noOfStocks, long accuValue)
		{
			if (t == list.Length) return accuValue;
			if (cache[t, noOfStocks] != 0) 
			{
				Debug.WriteLine("{0} {1}: {2}", t, noOfStocks, cache[t, noOfStocks]);
				return cache[t, noOfStocks];
			}
			var buy = Helper(t + 1, list, noOfStocks + 1, accuValue - list[t]);
			var sell = Helper(t + 1, list, 0, accuValue + list[t] * noOfStocks);
			var nothing = Helper(t + 1, list, noOfStocks, accuValue);
			var options = new[] {buy, sell, nothing};
			var max = options.Max();
			if (max > 0)
			{
				cache[t, noOfStocks] = max;
			}
			return max;
		}
	}
}
