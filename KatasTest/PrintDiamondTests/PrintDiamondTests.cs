using FluentAssertions;
using Katas;
using NUnit.Framework;

namespace KatasTest.PrintDiamondTests
{
	[TestFixture]
	class PrintDiamondTests
	{
		[Test]
		public void Print()
		{
			// arrange
			var su = new PrintDiamond();
			const string expectedString = "    A\r\n" +
										  "   B B\r\n" +
										  "  C   C\r\n" +
										  " D     D\r\n" +
										  "E       E\r\n" +
										  " D     D\r\n" +
										  "  C   C\r\n" +
										  "   B B\r\n" +
										  "    A\r\n";
			// act
			var result = su.Print('E');

			// assert
			result.Should().Be(expectedString);
		}
	}
}
