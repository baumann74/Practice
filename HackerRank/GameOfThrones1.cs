
using System.Collections.Generic;
using System.Linq;

namespace HackerRank
{
	public class GameOfThrones1
	{

		public static string Solve(string s)
		{
			var map = new Dictionary<char, int>();
			s.ToCharArray().ToList().ForEach(x =>
			{
				int value;
				map[x] = map.TryGetValue(x, out value) ? ++value : 1;
			});
			var evens = map.Count(x => x.Value%2 == 0);
			var odds = map.Count(x => x.Value % 2 == 1);
			return evens >= 1 & odds <= 1 ? "YES" : "NO";
		}
	}
}
