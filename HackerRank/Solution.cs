using System;
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
				Console.WriteLine(Solve(n, list));
			}
		}

		public static int Solve(int n, int[] list)
		{
			return Helper(0, list, 0, 0);
		}

		private static int Helper(int t, int[] list, int noOfStocks, int accuValue)
		{
			if (t == list.Length) return accuValue;
			var buy = Helper(t + 1, list, noOfStocks + 1, accuValue - list[t]);
			var sell = Helper(t + 1, list, 0, accuValue + list[t] * noOfStocks);
			var nothing = Helper(t + 1, list, noOfStocks, accuValue);
			var options = new[] { buy, sell, nothing };
			return options.Max();
		}
	}
}
