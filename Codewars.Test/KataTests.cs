using NUnit.Framework;

namespace Codewars.Test
{
	[TestFixture]
	public class KataTests
	{
		[Test]
		public void GetMissingElement_EightIsMissing()
		{
			Assert.AreEqual(8, Kata.GetMissingElement(new[] {0, 5, 1, 3, 2, 9, 7, 6, 4}));
		}

		[Test]
		public void GetMissingElement_ThreeIsMissing()
		{
			Assert.AreEqual(3, Kata.GetMissingElement(new[] {9, 2, 4, 5, 7, 0, 8, 6, 1}));
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

		[TestFixture]
		public class PalinDromeTest
		{
			[Test]
			public void GivenAValidPalindromeOutputShouldBeTrue()
			{
				Assert.AreEqual(true, Kata.IsPalindrome("aha"));
			}

			[Test]
			public void GivenAValidPalindromeWithCaseOutputShouldBeTrue()
			{
				Assert.AreEqual(true, Kata.IsPalindrome("ahA"));
			}

			[Test]
			public void GivenAInvalidPalindromeOutputShouldBeFalse()
			{
				Assert.AreEqual(false, Kata.IsPalindrome("hello"));
			}

			[Test]
			public void GivenAValidPalindromeWithSpecialCharactersOutputShouldBeTrue()
			{
				Assert.AreEqual(true, Kata.IsPalindrome("a ha ./?!@#$%^&*(){}[];'\\|<>,"));
			}

			[Test]
			public void GivenAInvlidPalindromeWithSpecialCharactersOutputShouldBeFalse()
			{
				Assert.AreEqual(false, Kata.IsPalindrome("Hello ./?!@#$%^&*(){}[];'\\|<>,"));
			}
		}

		[TestFixture]
		public class PalinddromeChainLengthTest
		{

			[Test]
			public void Given87OutputShouldBe4()
			{
				Assert.AreEqual(4, Kata.PalindromeChainLength(87));
			}

			[Test]
			public void Given89OutputShouldBe24()
			{
				Assert.AreEqual(24, Kata.PalindromeChainLength(89));
			}
		}

		[TestFixture]
		public class FactorialTests
		{
			[Test]
			public void FactorialOf0ShouldBe1()
			{
				Assert.AreEqual(1, Kata.Factorial(0));
			}

			[Test]
			public void FactorialOf1ShouldBe1()
			{
				Assert.AreEqual(1, Kata.Factorial(1));
			}

			[Test]
			public void FactorialOf2ShouldBe2()
			{
				Assert.AreEqual(2, Kata.Factorial(2));
			}

			[Test]
			public void FactorialOf3ShouldBe6()
			{
				Assert.AreEqual(6, Kata.Factorial(3));
			}
		}

		public class IQTests
		{
			[Test]
			public void Test1()
			{
				Assert.AreEqual(3, Kata.IqTest("2 4 7 8 10"));
			}

			[Test]
			public void Test2()
			{
				Assert.AreEqual(1, Kata.IqTest("1 2 2"));
			}
		}

		public class StairsTests
		{
			[Test]
			public void Test1()
			{
				Assert.AreEqual(6, Kata.NumberOfStepsImpl.NumberOfSteps(10, 2));
			}

			[Test]
			public void Test2()
			{
				Assert.AreEqual(-1, Kata.NumberOfStepsImpl.NumberOfSteps(3, 5));
			}
		}

		public class SqInRectTests
		{

			[Test]
			public void Test1()
			{
				int[] r = new int[] { 3, 2, 1, 1 };
				Assert.AreEqual(r, Kata.NumberOfStepsImpl.SqInRect(5, 3));
			}
			[Test]
			public void Test3()
			{
				Assert.AreEqual(null, Kata.NumberOfStepsImpl.SqInRect(5, 5));
			}
		}

		public class CountingChangeCombinationsTests
		{

			[Test]
			public static void SimpleCase()
			{
				Assert.AreEqual(3, Kata.CountingChangeCombinations.CountCombinations(4, new[] { 1, 2 }));
			}

			[Test]
			public static void AnotherSimpleCase()
			{
				Assert.AreEqual(4, Kata.CountingChangeCombinations.CountCombinations(10, new[] { 5, 2, 3 }));
			}

			[Test]
			public static void NoChange()
			{
				Assert.AreEqual(0, Kata.CountingChangeCombinations.CountCombinations(11, new[] { 5, 7 }));
			}
		}
	}
}