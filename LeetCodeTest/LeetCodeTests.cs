using LeetCode;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCodeTest
{
	[TestClass]
	public class LeetCodeTests
	{
		[TestMethod]
		public void ZigZagConversionTest()
		{
			var solution = new ZigZagConversion();
			Assert.AreEqual("PAHNAPLSIIGYIR", solution.Convert("PAYPALISHIRING", 3));
		}

		[TestMethod]
		public void ZigZagConversionTest1()
		{
			var solution = new ZigZagConversion();
			Assert.AreEqual("A", solution.Convert("A", 1));
		}

	}
}
