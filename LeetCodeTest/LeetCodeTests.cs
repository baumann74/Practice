using LeetCode;
using NUnit.Framework;

namespace LeetCodeTest
{
	[TestFixture]
	public class LeetCodeTests
	{
		[TestCase("PAHNAPLSIIGYIR", "PAYPALISHIRING", 3)]
		[TestCase("A", "A", 1)]
		public void ZigZagConversionTest(string expected, string input, int rows)
		{
			var solution = new ZigZagConversion();
			Assert.AreEqual(expected, solution.Convert(input, rows));
		}

		[TestCase]
		public void CourseScheduleTest()
		{
			var solution = new CourseSchedule();
			Assert.AreEqual(true, solution.CanFinish(2, new[,] { { 1, 0 } }));
			Assert.AreEqual(false, solution.CanFinish(2, new[,] { { 1, 0 }, { 0, 1 } })); 
		}
	}
}
