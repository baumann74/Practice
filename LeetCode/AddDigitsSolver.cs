
using System.Collections.Generic;
using System.Linq;

namespace LeetCode
{
	public class AddDigitsSolver
	{
		public static int AddDigits(int num)
		{
			var digits = num.ToString().ToCharArray();
			var sum = GetSumOfDigits(digits);
			while (sum > 9)
			{
				digits = sum.ToString().ToCharArray();
				sum = GetSumOfDigits(digits);				
			}
			return sum;
		}

		private static int GetSumOfDigits(IEnumerable<char> chars)
		{
			return chars.Aggregate(0, (current, item) => current + int.Parse(item + ""));
		}
	}
}
