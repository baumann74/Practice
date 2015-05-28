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
				var parameters = Console.ReadLine().Split(' ');
				var length = int.Parse(parameters[0]);
				var sum = int.Parse(parameters[1]);
				var list = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
				Console.WriteLine(Solve(sum, length, list));
			}
		}

		public static long Solve(int n, int length, int[] coins)
		{
			cache = new long[n + 1, coins.Length + 1];
			return Calculate(0, coins.Length, coins, n);
		}

		private static long[,] cache;

		private static long Calculate(int accuSum, int index, int[] coins, int expectedSum)
		{
			if (accuSum > expectedSum) return -1;
			if (accuSum == expectedSum || index == 0) return accuSum;
			if (cache[accuSum, index] != 0) return cache[accuSum, index];
			cache[accuSum, index] = Math.Max(
				Calculate(accuSum + coins[index - 1], index, coins, expectedSum),
				Calculate(accuSum, index - 1, coins, expectedSum));
			return cache[accuSum, index];
		}
	}
}
