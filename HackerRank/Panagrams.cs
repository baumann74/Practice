using System.Collections.Generic;

namespace HackerRank
{
	using System;
	using System.Linq;

	public class Panagrams
	{

		public static bool IsPanagram(string s)
		{
			var set = new HashSet<char>();
			foreach (var c in s.Where(Char.IsLetter).Select(Char.ToLower))
			{
				set.Add(c);
			}
			return set.Count == 26;
		}
	}
}
