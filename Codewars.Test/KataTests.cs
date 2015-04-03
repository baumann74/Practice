using NUnit.Framework;

namespace Codewars.Test
{
	[TestFixture]
	public class KataTests
	{

		[Test]
		public void GetMissingElement_EightIsMissing()
		{
			Assert.AreEqual(8, Kata.GetMissingElement(new int[9] { 0, 5, 1, 3, 2, 9, 7, 6, 4 }));
		}

		[Test]
		public void GetMissingElement_ThreeIsMissing()
		{
			Assert.AreEqual(3, Kata.GetMissingElement(new int[9] { 9, 2, 4, 5, 7, 0, 8, 6, 1 }));
		}

		[Test]
		public void MultipleOf3And5()
		{
			Assert.AreEqual(23, Kata.MultipleOf3And5(10));
		}

		[TestFixture]
		public class GoodVsEvil
		{
			[Test]
			public static void EvilShouldWin()
			{
				Assert.AreEqual("Battle Result: Evil eradicates all trace of Good", Kata.GoodVsEvil("1 1 1 1 1 1", "1 1 1 1 1 1 1"));
			}

			[Test]
			public static void GoodShouldTriumph()
			{
				Assert.AreEqual("Battle Result: Good triumphs over Evil", Kata.GoodVsEvil("0 0 0 0 0 10", "0 1 1 1 1 0 0"));
			}

			[Test]
			public static void ShouldBeATie()
			{
				Assert.AreEqual("Battle Result: No victor on this battle field", Kata.GoodVsEvil("1 0 0 0 0 0", "1 0 0 0 0 0 0"));
			}
		}
	}
}
