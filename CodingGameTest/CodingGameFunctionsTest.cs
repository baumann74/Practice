using CodingGame;

using NUnit.Framework;

using Assert = NUnit.Framework.Assert;

namespace CodingGameTest
{
	[TestFixture]
	public class CodingGameFunctionsTest
	{
		[Test]
		public void ChuckNorrisTest()
		{
			Assert.AreEqual("0 0 00 0000 0 00", CodingGameFunctions.ChuckNorris("C"));
			Assert.AreEqual("0 0 00 0000 0 000 00 0000 0 00", CodingGameFunctions.ChuckNorris("CC"));
			Assert.AreEqual("00 0 0 0 00 00 0 0 00 0 0 0", CodingGameFunctions.ChuckNorris("%"));
			Assert.AreEqual("00 0 0 0 00 00 0 0 00 0 0 0", CodingGameFunctions.ChuckNorris("%"));
		}

		[TestCase(new[] { 1, -2, -8, 4, 5 }, 1)]
		[TestCase(new[] { -12, -5, -1337 }, -5)]
		[TestCase(new[] { 42 -5, 12, 21, 5, 24 }, 5)]
		[TestCase(new[] { 42 -5, 12, 21, 5, 24 }, 5)]
		[TestCase(new[] { 42, 5, 12, 21, -5, 24 }, 5)]
		[TestCase(new[] { -5 ,-4, -2, 12, -40, 4, 2, 18, 11, 5 }, 2)]
		public void Temperatures(int[] input, int result)
		{
			Assert.AreEqual(result, CodingGameFunctions.Temperatures(input));
		}
	}
}
