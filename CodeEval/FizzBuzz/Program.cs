namespace CodeEval.FizzBuzz
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;

	public class Program
	{

		// Integration
		public static void Main(string[] args)
		{
			var records = ParseFile(args[0]);
			records.ToList().ForEach(x => ProcessRecord(x.FirstDivider, x.SecondDivider, x.Count));
		}

		// Operation
		private static IEnumerable<dynamic> ParseFile(string fileName)
		{
			var lines = File.ReadAllLines(fileName);
			foreach (var values in lines.Select(line => line.Split(' ')))
			{
				yield return new { FirstDivider = int.Parse(values[0]), SecondDivider = int.Parse(values[1]), Count = int.Parse(values[2]) };
			}
		}

		// Integration
		private static void ProcessRecord(int firstDivider, int secondDivider, int count)
		{
			GenerateNumbers(count, number =>
				CategorizeNumbers(number, firstDivider, secondDivider,
					() => Print(number, "FB"),
					() => Print(number, "F"),
					() => Print(number, "B"),
					() => Print(number, "" + number)));
		}

		// Operation
		private static void GenerateNumbers(int count, Action<int> onNumber)
		{
			for (var i = 1; i <= count; i++)
			{
				onNumber(i);
			}
		}

		// Operation
		private static void CategorizeNumbers(int number,
												int firstDivider,
												int secondDivider,
												Action onFizzBuzz,
												Action onFizz,
												Action onBuzz,
												Action onNumber)
		{
			if (number % firstDivider == 0 && number % secondDivider == 0) onFizzBuzz();
			else if (number % firstDivider == 0) onFizz();
			else if (number % secondDivider == 0) onBuzz();
			else onNumber();
		}

		// Operation
		private static void Print(int number, string s)
		{
			var space = number == 1 ? "" : " ";
			Console.Write(space + s);
		}
	}
}
