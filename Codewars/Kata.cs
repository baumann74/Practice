

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
	}
}
