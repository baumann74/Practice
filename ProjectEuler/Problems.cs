using System.Linq;

namespace ProjectEuler
{
	public class Problems
	{

		public static long Largest_palindrome_product()
		{
			return 
				(from x in Enumerable.Range(100, 900)
				from y in Enumerable.Range(100, 900)
				where Is_palindrome(x * y)
				select x * y)
				.Max();
		}

		private static bool Is_palindrome(long n)
		{
			var r = long.Parse(n.ToString().Reverse().Aggregate("", (a, c) => (a + c)));
			return r == n;
		}
	}
}
