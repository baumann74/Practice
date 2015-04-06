
using System.Linq;

namespace HackerRank
{
	public class UtopianTree
	{

		public static int Solve(int cycles)
		{
			return Enumerable.Range(0, cycles).Aggregate(1, (aggr, cycle) => 
				(cycle % 2 == 0) ? aggr * 2 : aggr + 1);
		}
	}
}
