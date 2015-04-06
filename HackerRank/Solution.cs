﻿using System;

namespace HackerRank
{
	using System.Collections.Generic;
	using System.Linq;

	class Solution
	{
		static void Main(String[] args)
		{
			var t = Console.ReadLine();
			Console.WriteLine(IsPanagram(t) ? "panagram" : "not panagram");
		}

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
