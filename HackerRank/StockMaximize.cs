
namespace HackerRank
{
	public class StockMaximize
	{
		public static long Solve(long n, int[] list)
		{
			var profit = 0L;
			var currentMax = 0L;
			for (var i = list.Length - 1; i >=0; i--)
			{
				var stockValue = list[i];
				if (stockValue > currentMax)
				{
					currentMax = stockValue;
				}
				profit += currentMax - stockValue;
			}
			return profit;
		}
	}
}
