

using System.Linq;

namespace Codewars
{
	public class Kata
	{
		// http://www.codewars.com/kata/5299413901337c637e000004/train/csharp

		public static int GetMissingElement(int[] superImportantArray)
		{
			return Enumerable.Range(0, 9).Except(superImportantArray).First();
		}

		// http://www.codewars.com/kata/514b92a657cdc65150000006/train/csharp

		public static int MultipleOf3And5(int value)
		{
			return Enumerable.Range(0, value).Where(x => x%3 == 0 || x%5 == 0).Sum();
		}

		// http://www.codewars.com/kata/52761ee4cffbc69732000738/train/csharp

		public static string GoodVsEvil(string good, string evil)
		{
			var goodList = ConvertToList(good);
			var goodCount = CalculateGood(goodList);
			var evilList = ConvertToList(evil);
			var evilCount = CalculateEvil(evilList);
			return GetGoodVsEvilResult(goodCount, evilCount);
		}

		private static int[] ConvertToList(string s)
		{
			return s.Split(' ').Select(int.Parse).ToArray();
		}

		private static int CalculateGood(int[] l)
		{
			return l[0] + 2*l[1] + 3*l[2] + 3*l[3] + 4*l[4] + 10*l[5];
		}

		private static int CalculateEvil(int[] l)
		{
			return l[0] + 2 * l[1] + 2 * l[2] + 2 * l[3] + 3 * l[4] + 5 * l[5] + 10 * l[6];
		}

		private static string GetGoodVsEvilResult(int goodCount, int badCount)
		{
			if (goodCount == badCount) return "Battle Result: No victor on this battle field";
			return goodCount > badCount 
				? "Battle Result: Good triumphs over Evil" 
				: "Battle Result: Evil eradicates all trace of Good";
		}
	}
}
