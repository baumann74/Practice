
namespace HackerRank
{
	public static class TaumAndBday
	{

		public static long Solve(long b, long w, long x, long y, long z)
		{
			var blackCost = x < (y + z) ? (b * x) : (b * y + b * z);
			var whiteCost = y < (x + z) ? (w * y) : (w * x + w * z);
			return blackCost + whiteCost;
		}
	}
}
