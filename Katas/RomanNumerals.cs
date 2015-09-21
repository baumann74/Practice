
using System;
using System.Collections.Generic;
using System.Linq;

namespace Katas
{
	public class RomanNumerals
	{
		private static readonly Dictionary<int, string> FactorToRoman = new Dictionary<int, string> 
		{
			{ 0, "" }, { 1, "I" }, { 2, "II" }, { 3, "III" }, { 4, "IV" }, { 5, "V" }, { 6, "VI" }, { 7, "VII" }, { 8, "VIII" }, { 9, "IX" },
			{ 10, "X" }, { 20, "XX" }, { 30, "XXX" }, { 40, "XL" }, { 50, "L" }, { 60, "LX" }, { 70, "LXX" }, { 80, "LXXX" }, { 90, "XC" }, 
			{ 100, "C" }, { 200, "CC" }, { 300, "CCC" }, { 400, "CD" }, { 500, "D" }, { 600, "DC" }, { 700, "DCC" }, { 800, "DCCC" }, { 900, "CM" }, 
			{ 1000, "M" }, { 2000, "MM" }, { 3000, "MMM" } 
		};

		public string To_roman(int arabic)
		{
			var factors = Split_into_factors(arabic);
			var romanNumeralsList = Convert_factors_to_roman(factors);
			return Assemple_roman(romanNumeralsList);
		}

		private static IEnumerable<int> Split_into_factors(int arabic)
		{
			var result = new List<int>();
			while (arabic > 0)
			{
				result.Add(arabic % 10);
				arabic = arabic / 10;
			}
			return result;
		}

		private static IEnumerable<string> Convert_factors_to_roman(IEnumerable<int> factors)
		{
			var result = new List<string>();
			var multiplier = 1;
			foreach (var factor in factors)
			{
				result.Add(FactorToRoman[factor * multiplier]);
				multiplier *= 10;
			}
			return result;
		}

		private static string Assemple_roman(IEnumerable<string> romanNumeralsList)
		{
			return String.Join("", romanNumeralsList.Reverse());
		}
	}
}
