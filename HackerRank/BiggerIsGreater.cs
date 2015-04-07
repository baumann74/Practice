
namespace HackerRank
{
	using System;
	using System.Linq;
	using System.Text;

	public class BiggerIsGreater
	{
		// http://www.nayuki.io/page/next-lexicographical-permutation-algorithm

		public static string Solution(string s)
		{
			var pivot = FindPivotIndex(s);
			return Validate_pivot(
				pivot,
				x =>
					{
						var indexToSwap = Find_smallest_value_in_suffix_greather_than_pivot(s, pivot);
						var swappedString = Swap(s, pivot, indexToSwap);
						return Reverse_suffix(swappedString, pivot);
					},
				x => "no answer");
		}

		private static string Validate_pivot(int pivot, Func<int, string> onValid, Func<int, string> onInvalid)
		{
			return (pivot == -1) ? onInvalid(pivot) : onValid(pivot);
		}

		private static int FindPivotIndex(string s)
		{
			var i = s.Length - 1;
			while (i > 0 && s[i - 1] >= s[i])
			{
				i--;
			}
			return i == 0 ? -1 : i - 1;
		}

		private static int Find_smallest_value_in_suffix_greather_than_pivot(string s, int pivot)
		{
			var i = s.Length - 1;
			while (i > 0 && s[i] <= s[pivot])
			{
				i--;
			}
			return i;
		}

		private static string Reverse_suffix(string s, int pivot)
		{
			var suffix = s.Substring(pivot + 1);
			var reversedSuffix = suffix.Reverse().Aggregate("", (s1, c1) => s1 + c1);
			var builder = new StringBuilder(s);
			builder.Remove(pivot +1, suffix.Length);
			builder.Append(reversedSuffix);
			return builder.ToString();
		}

		private static string Swap(string s, int x, int y)
		{
			var result = s.ToCharArray();
			var temp = result[x];
			result[x] = result[y];
			result[y] = temp;
			return result.Aggregate("", (s1, c1) => s1 + c1);
		}
	}
}
