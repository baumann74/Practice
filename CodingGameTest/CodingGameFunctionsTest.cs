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
	}
}
