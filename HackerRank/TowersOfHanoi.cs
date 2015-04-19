using System.Collections.Generic;

namespace HackerRank
{
	public class TowersOfHanoi
	{

		public static IEnumerable<string> FindMoves(int n)
		{
			var result = new List<string>();
			FindMoves(n, 1, 3, 2, result);
			return result;
		}

		public static void FindMoves(int n, int from, int to, int temp, List<string> result)
		{
			if (n == 1)
			{
				result.Add(string.Format("MOVE T{0} T{1}", from, to));
				return;
			}
			FindMoves(n - 1, from, temp, to, result);
			result.Add(string.Format("MOVE T{0} T{1}", from, to));
			FindMoves(n - 1, temp, to, from, result);
		}
	}
}
