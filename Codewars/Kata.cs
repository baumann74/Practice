

using System.Linq;
using System.Numerics;

namespace Codewars
{
	using System;
	using System.Collections.Generic;

	public class Kata
	{

		// ********************************************************
		// http://www.codewars.com/kata/5299413901337c637e000004/train/csharp

		public static int GetMissingElement(int[] superImportantArray)
		{
			return Enumerable.Range(0, 9).Except(superImportantArray).First();
		}


		// ********************************************************
		// http://www.codewars.com/kata/514b92a657cdc65150000006/train/csharp

		public static int MultipleOf3And5(int value)
		{
			return Enumerable.Range(0, value).Where(x => x%3 == 0 || x%5 == 0).Sum();
		}


		// ********************************************************
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


		// ********************************************************
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
		}

		public static int IqTest(string numbers)
		{
			return numbers.Split(' ')
				.Select((s, i) => new {s, i})
				.Where(y => int.Parse(y.s) % 2 == 1)
				.Select(t => t.i + 1)
				.Single();
		}


		// ********************************************************
		// http://www.codewars.com/kata/55251c0d2142d7b4ab000aef/train/csharp

		public class NumberOfStepsImpl
		{
			private static int[,] cache;

			public static int NumberOfSteps(int n, int m)
			{
				cache = new int[n + 1, n + 1];
				var result = NumberOfStepsHelper(n, m, 0);
				return (result == Int32.MaxValue) ? -1 : result;
			}

			private static int NumberOfStepsHelper(int n, int m, int steps)
			{
				if (n < 0) return Int32.MaxValue;
				if (n == 0)
				{
					return (steps % m == 0) ? steps : Int32.MaxValue;
				}
				if (cache[n, steps] != 0) return cache[n, steps];
				cache[n, steps] = Math.Min(NumberOfStepsHelper(n - 2, m, steps + 1),
					NumberOfStepsHelper(n - 1, m, steps + 1));
				return cache[n, steps];
			}

			public static List<int> SqInRect(int lng, int wdth)
			{
				if (lng == wdth) return null;
				var resultList = new List<int>();
				SqInRectHelper(lng, wdth, resultList);
				return resultList;
			}

			public static void SqInRectHelper(int lng, int wdth, List<int> resultList)
			{
				if (lng == 0) return;
				if (wdth > lng)
				{
					SqInRectHelper(wdth, lng, resultList);
					return;
				}
				resultList.Add(wdth);
				SqInRectHelper(lng - wdth, wdth, resultList);
			}
		}


		// ********************************************************
		// http://www.codewars.com/kata/decode-the-morse-code/train/csharp

		public class MorseCodeDecoder
		{
			private static string Get(string c)
			{
				return c + "";
			}

			public static string Decode(string morseCode)
			{
				var words = morseCode.Trim().Split(new [] {"  "}, StringSplitOptions.RemoveEmptyEntries).ToList();
				var morsedList = words.Select(word => string.Join("", word.Split(' ').Select(Get)));
				return string.Join(" ", morsedList);
			}
		}

		public class MorseCodeDecoderBetter
		{
			private static string Get(string c)
			{
				return c + "";
			}

			public static string Decode(string morseCode)
			{
				// Integration because it is just a number of method calls.
				return string.Join(" ",
					morseCode
					.Trim()
					.Split(new[] { "  " }, StringSplitOptions.RemoveEmptyEntries)
					.Select(TranslateWord));
			}

			private static string TranslateWord(string morse)
			{
				return string.Join("", morse.Split(' ').Select(Get));
			}
		}


		// ********************************************************
		// http://www.codewars.com/kata/541af676b589989aed0009e7


		public class CountingChangeCombinations
		{
			private static int[,] cache;

			public static int CountCombinations(int money, int[] coins)
			{
				cache = new int[coins.Count(), money];
				return CountCombinationsHelper(money, coins, 0, 0);
			}

			public static int CountCombinationsHelper(int money, int[] coins, int index, int sum)
			{
				if (sum == money) return 1;
				if (sum > money) return 0;
				if (index >= coins.Count()) return 0;
				var cacheValue = cache[index, sum];
				if (cacheValue != 0)
				{
					return cacheValue;
				}
				cache[index, sum] = 
					CountCombinationsHelper(money, coins, index, sum + coins[index]) +
					   CountCombinationsHelper(money, coins, index + 1, sum);
				return cache[index, sum];
			}
		}


		// ********************************************************
		// http://www.codewars.com/kata/541af676b589989aed0009e7
		// Invert binary tree

		public static class InvertTreeClass
		{
			public static TreeNode InvertTree(TreeNode root)
			{
				if (root == null) return null;
				return new TreeNode()
				{
					Value = root.Value, 
					Left = InvertTree(root.Right), 
					Right = InvertTree(root.Left)
				};
			}
		}

		// ********************************************************
		//http://www.codewars.com/kata/51b6249c4612257ac0000005
		// Roman decoder

		public class RomanDecode
		{
			private static readonly Dictionary<string, int> RomanNumeralMap = new Dictionary<string, int>
			{
				{ "M", 1000 },
				{ "CM", 900 },
				{ "D", 500 },
				{ "CD", 400 },
				{ "C", 100 },
				{ "XC", 90 },
				{ "L", 50 },
				{ "XL", 40 },
				{ "X", 10 },
				{ "IX", 9 },
				{ "V", 5 },
				{ "IV", 4 },
				{ "I", 1 },
			};

			public static int Solution(string roman)
			{
				var result = 0;
				var index = 0;
				while (index < roman.Length)
				{
					int value;
					if (index <= roman.Length - 2 && RomanNumeralMap.TryGetValue(roman.Substring(index, 2), out value))
					{
						result = result + value;
						index = index + 2;
					}
					else
					{
						result = result + RomanNumeralMap[roman[index++].ToString()];
					}
				}
				return result;
			}
		}

		public class RomanDecodeBetter
		{
			private static readonly Dictionary<char, int> Literals = new Dictionary<char, int>
			{
				{'I', 1},
				{'V', 5},
				{'X', 10},
				{'L', 50},
				{'C', 100},
				{'D', 500},
				{'M', 1000}
			};

			public static int Solution(string roman)
			{
				var result = 0;
				var previous = 0;

				foreach (var c in roman.Reverse())
				{
					int value = Literals[c];

					if (value < previous)
					{
						result -= value;
					}
					else
					{
						result += value;
						previous = value;
					}
				}
				return result;
			}
		}

		// ********************************************************
		// http://www.codewars.com/kata/square-into-squares-protect-trees/train/csharp
		// Square into Squares. Protect trees!

		public class Decompose
		{

			public string decompose(long n)
			{
				var list = new List<long>();
				DecomposeHelper(n * n, n - 1, list);
				list.Reverse();
				return list.Any() ? string.Join(" ", list) : null;
			}

			private static bool DecomposeHelper(long n, long value, List<long> list)
			{
				if (n == 0) return true;
				if (n == 1 && !list.Contains(1))
				{
					list.Add(1);
					return true;
				}
				if (new[] {2L, 3L}.Contains(n)) return false;
				for (var i = value; i > 0; i--)
				{
					if (list.Contains(i)) return false;
					list.Add(i);
					var nextN = n - (i*i);
					var works = DecomposeHelper(nextN, (long)Math.Floor(Math.Sqrt(nextN)), list);
					if (works) return true;
					list.Remove(i);
				}
				return false;
			}
		}

		// ********************************************************
		// http://www.codewars.com/kata/5277c8a221e209d3f6000b56/train/csharp
		// Valid Braces.

		public class Brace
		{
			private static readonly char[] Start = { '(', '{', '[' };
			private static readonly Stack<char> Stack = new Stack<char>();

			public static bool validBraces(String braces)
			{
				Console.WriteLine(braces);
				Stack.Clear();
				var chars = braces.ToCharArray();
				foreach (var c in chars)
				{
					if (Start.Contains(c))
					{
						Stack.Push(c);
					}
					else
					{
						var isCorrect = Stack.Any() && IsMatch(Stack.Pop(), c);
						if (!isCorrect) return false;
					}
				}
				return !Stack.Any();
			}

			private static bool IsMatch(char start, char end)
			{
				switch (end)
				{
					case ')' :return start == '(';
					case '}': return start == '{';
					case ']': return start == '[';
					default:
						throw new Exception("Unknown c: " + end);
				}
			}
		}

		// ********************************************************
		// http://www.codewars.com/kata/5324945e2ece5e1f32000370/train/csharp
		// Sum Strings as Numbers.


		public static class KataSumString
		{
			public static string SumStrings(string a, string b)
			{
				BigInteger number1;
				BigInteger number2;
				var s1 = BigInteger.TryParse(a, out number1);
				var s2 = BigInteger.TryParse(b, out number2);
				number1 = s1 ? number1 : 0;
				number2 = s2 ? number2 : 0;
				var number = number1 + number2;
				return number.ToString();
				// Better 
				//return (Convert.ToInt32(a) + Convert.ToInt32(b)).ToString();
			}
		}
	}
}
