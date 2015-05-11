﻿using System;
using System.Linq;

namespace HackerRank
{

	class Solution
	{
		static void Main(String[] args)
		{
			var t = int.Parse(Console.ReadLine());
			for (var i = 0; i < t; i++)
			{
				var n = int.Parse(Console.ReadLine());
				var list = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
				Console.WriteLine(string.Format("{0} {1}", 
					Solve_contiguous(n, list), 
					Solve_non_contigous(n, list)));
			}
		}

		public static int Solve_contiguous(int n, int[] list)
		{
			var max_continue = 0;
			var max_sofar = 0;
			var allNegative = true;

			for (var i = 0; i < n; i++)
			{
				max_continue = max_continue + list[i];
				if (max_continue < 0)
				{
					max_continue = 0; // start over. 
				}
				if (max_continue > max_sofar)
				{
					max_sofar = max_continue;
					allNegative = false;
				}
			}
			return allNegative ? list.Max() : max_sofar;
		}

		public static int Solve_non_contigous(int n, int[] list)
		{
			return list.All(x => x < 0) ? list.Max() : list.Where(x => x > 0).Sum();
		}
	}
}
