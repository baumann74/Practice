using FluentAssertions;
using Katas.RomanNumerals;
using NUnit.Framework;
using System.Collections.Generic;
using System.Reflection;

namespace KatasTest.RomanNumeralsTests
{

	[TestFixture]
	public class RomanNumeralsTests
	{

		[TestCase(4, "IV")]
		[TestCase(1904, "MCMIV")]
		[TestCase(1954, "MCMLIV")]
		[TestCase(1990, "MCMXC")]
		[TestCase(2014, "MMXIV")]
		public void To_roman(int arabic, string roman)
		{
			// arrange
			var sut = new RomanNumerals();

			// act/assert
			sut.To_roman(arabic).Should().Be(roman);

		}

		[Test]
		public void Split_into_factors()
		{
			// arrange
			var mi = typeof(RomanNumerals).GetMethod("Split_into_factors", BindingFlags.NonPublic | BindingFlags.Static);
			var sut = new RomanNumerals();

			// act
			var result = mi.Invoke(sut, new object[] { 1904 }) as IList<int>;

			// assert
			result.Should().BeEquivalentTo(new[] { 1, 9, 0, 4 });
		}

		[Test]
		public void ConvertFactorsToRoman()
		{
			// arrange
			var mi = typeof(RomanNumerals).GetMethod("Convert_factors_to_roman", BindingFlags.NonPublic | BindingFlags.Static);
			var sut = new RomanNumerals();

			// act
			var result = mi.Invoke(sut, new object[] { new List<int> { 4, 0, 9, 1 } }) as IEnumerable<string>;

			// assert
			result.Should().BeEquivalentTo(new[] { "IV", "", "CM", "M"  });
		}

		[Test]
		public void AssembleRoman()
		{
			// arrange
			var mi = typeof(RomanNumerals).GetMethod("AssempleRoman", BindingFlags.NonPublic | BindingFlags.Static);
			var sut = new RomanNumerals();

			// act
			var result = mi.Invoke(sut, new object[] { new List<string> { "IV", "", "CM", "M"} }) as string;

			// assert
			result.Should().BeEquivalentTo("MCMIV");
		}

	}
}
