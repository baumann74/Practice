﻿using System;

namespace HackerRank
{

	class Solution
	{
		static void Main(String[] args) 
		{
			var n = int.Parse(Console.ReadLine());
			for (var i = 0; i < n; i++)
			{
				var j = int.Parse(Console.ReadLine());
				Console.WriteLine(Solve(j));
			}
		}

		private static long Solve(int t)
		{
			var combinations = GetBrickCombinations(t);
			return Prime_numbers(combinations);
		}

		private static int GetBrickCombinations(int t)
		{
			if (t < 0) return 0;
			if (t <= 3) return 1;
			return GetBrickCombinations(t - 1) + GetBrickCombinations(t - 4);
		}

		private static int Prime_numbers(int num)
		{
			var result = 0;
			for (var i = 2; i <= num; i++)
			{
				if (Is_Prime(i))
				{
					result++;
				}
			}
			return result;
		}

		private static bool Is_Prime(int num)
		{
			if (num <= 1) return false;
			for (var i = 2; i <= Math.Sqrt(num); i++)
			{
				if (num % i == 0) return false;
			}
			return true;
		}
	}
}
