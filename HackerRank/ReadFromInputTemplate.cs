using System;

namespace HackerRank
{
	class ReadFromInputTemplate
	{
		private static void MainTemp(String[] args)
		{
			var t = int.Parse(Console.ReadLine());
			for (var i = 0; i < t; i++)
			{
				var elements = Console.ReadLine();
				var splitElements = elements.Split(' ');
				var val1 = int.Parse(splitElements[0]);
				var val2 = int.Parse(splitElements[1]);
				Console.WriteLine(solveMeSecond(val1, val2));
			}
		}

		static int solveMeSecond(int a, int b)
		{
			return a + b;
		}
	}
}
