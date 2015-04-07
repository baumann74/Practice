﻿

using System.Linq;

namespace Codewars
{
	using System;
	using System.Collections.Generic;

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

		// http://www.codewars.com/kata/55003f75bae8cd78d200127b/train/csharp

		public static bool IsPalindrome(string w)
		{
			var list = w.Trim().Where(Char.IsLetterOrDigit).Select(Char.ToLower).ToArray();
			return list.Reverse().SequenceEqual(list);
		}

		// http://www.codewars.com/kata/palindrome-chain-length/train/csharp

		public static int PalindromeChainLength(long n)
		{
			// Cool solution.
//			var r = long.Parse(n.ToString().Reverse().Aggregate("", (s, c) => s + c));
//			return (n == r) ? 0 : (1 + PalindromeChainLength(r + n));
			return CalculateChain(n, 0, Split_into_digits, Reverse_digits_to_number);
		}

		private static int CalculateChain(
			long n, 
			int count, 
			Func<long, IList<long>> splitToDigits, 
			Func<IEnumerable<long>, long> reverseDigits)
		{
			var digits = Split_into_digits(n);
			if (digits.Reverse().SequenceEqual(digits))
			{
				return count;
			}
			var nextStep = n + reverseDigits(digits);
			return CalculateChain(nextStep, count + 1, splitToDigits, reverseDigits);
		}

		private static long Reverse_digits_to_number(IEnumerable<long> digits)
		{
			var result = 0l;
			var reversedDigits = digits.Reverse().ToList();
			for (var i = 0; i < reversedDigits.Count(); i++)
			{
				result = result + reversedDigits[i] * (long)Math.Pow(10, i);
			}
			return result;
		}

		private static IList<long> Split_into_digits(long n)
		{
			var result = new List<long>();
			while (n > 0)
			{
				result.Add(n % 10);
				n = n / 10;
			}
			return result;
		}

		public static int Factorial(int n)
		{
			if (n < 0 || n > 16) throw new ArgumentOutOfRangeException();
			return n == 0 ? 1 : Enumerable.Range(1, n).Aggregate(1, (a, c) => a * c);
//			return x == 0 ? 1 : x * Factorial(x - 1);
		}
	}
}
