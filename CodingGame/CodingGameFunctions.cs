using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingGame
{
	public static class CodingGameFunctions
	{
		// *********************************************************************
		// https://www.codingame.com/ide/4448139a14e6fab57eb79a474cd979c6442811a
		// Chuck Norris

		public static string ChuckNorris(string s)
		{
			var binaryString = Get_binary_string(s);
			var units = Get_units(binaryString);
			var converted_units = units.Select(Convert_unit);
			return string.Join(" ", converted_units);
		}

		private static string Get_binary_string(string s)
		{
			var bytes = Encoding.ASCII.GetBytes(s);
			var bytesAsBinary = bytes.Select(x => Convert.ToString(x, 2).PadLeft(7, '0'));
			return bytesAsBinary.Aggregate("", (current, item) => current + item);
		}

		private static IEnumerable<string> Get_units(string binaryString)
		{
			var units = new List<string>();
			var previous = binaryString[0];
			var currentUnit = "" + previous;
			for (var i = 1; i < binaryString.Length; i++)
			{
				var bit = binaryString[i];
				if (bit == previous)
				{
					currentUnit = currentUnit + bit;
				}
				else
				{
					units.Add(currentUnit);
					currentUnit = "" + bit;
				}
				previous = bit;
			}
			units.Add(currentUnit);
			return units;
		}

		private static string Convert_unit(string s)
		{
			var result = s[0] == '1' ? "0" : "00";
			return result + " " + new string('0', s.Length);
		}

		// *********************************************************************
		// https://www.codingame.com/ide/4516290e53ef5388dd057e579513ed7a0d84aa0
		// Temperatures

		public static int Temperatures(int[] temps)
		{
			return temps.ToList().OrderBy(Math.Abs).ThenByDescending(x => x).First();
		}
	}
}
