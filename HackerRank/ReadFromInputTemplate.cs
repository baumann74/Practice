using System;

namespace HackerRank
{
	using System.IO;
	using System.Linq;

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

		private static void ParseFile()
		{
			var lines = File.ReadAllLines(@"C:\Users\abu\Desktop\BiggerIsGreater.txt").ToList();
			var solution = File.ReadAllLines(@"C:\Users\abu\Desktop\BiggerIsGreater-solution.txt").ToList();
			var t = int.Parse(lines[0]);
			for (var i = 1; i < t; i++)
			{
				var value = BiggerIsGreater(lines[i]);
				var expectedValue = solution[i - 1];
				if (value != expectedValue)
				{
					Console.WriteLine(i + ": " + lines[i] + " # " + value + " # " + expectedValue);
					Console.ReadLine();
				}
			}
		}

		public static string BiggerIsGreater(string s)
		{
			return "";
		}

	}
}
