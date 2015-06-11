using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRank
{

	class Solution
	{
		static void Main(String[] args)
		{
			Console.WriteLine(Solve(Console.ReadLine()));
		}

		public static string Solve(string s)
		{
			return Find_permutations(s).Any(Is_palindrome) ? "YES" : "NO";
		}

		public static bool Is_palindrome(string input)
		{
			var reverse = input.Reverse().Aggregate("", (s, c) => s + c);
			return input == reverse;
		}

		public static IList<string> Find_permutations(string s)
		{
			if (s.Length == 1)
			{
				return new[] { s };
			}
			var result = new List<string>();
			for (var i = 0; i < s.Length; i++)
			{
				var rest = s.Substring(0, i) + s.Substring(i + 1);
				foreach (var per in Find_permutations(rest))
				{
					result.Add(s[i] + per);
				}
			}
			return result;
		}
	}
}
