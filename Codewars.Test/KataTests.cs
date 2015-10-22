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

		[TestFixture]
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

		[TestFixture]
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

		[TestFixture]
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

		[TestFixture]
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

		[TestFixture]
		public class InvertBinaryTestClass
		{
			[Test]
			public void TestFromExample()
			{
				var root1 = new TreeNode
				{
					Value = 4,
					Left = new TreeNode
					{
						Value = 2,
						Left = new TreeNode { Value = 1 },
						Right = new TreeNode { Value = 3 }
					},
					Right = new TreeNode
					{
						Value = 7,
						Left = new TreeNode { Value = 6 },
						Right = new TreeNode { Value = 9 }
					}
				};

				var root2 = new TreeNode
				{
					Value = 4,
					Left = new TreeNode
					{
						Value = 7,
						Left = new TreeNode { Value = 9 },
						Right = new TreeNode { Value = 6 }
					},
					Right = new TreeNode
					{
						Value = 2,
						Left = new TreeNode { Value = 3 },
						Right = new TreeNode { Value = 1 }
					}
				};

				CompareTrees(Kata.InvertTreeClass.InvertTree(root1), root2);
			}

			private static void CompareTrees(TreeNode root1, TreeNode root2)
			{
				if (root1 == null && root2 == null)
					return;

				Assert.False(root1 == null && root2 != null);
				Assert.False(root1 != null && root2 == null);
				Assert.AreEqual(root1.Value, root2.Value);

				CompareTrees(root1.Left, root2.Left);
				CompareTrees(root1.Right, root2.Right);
			}
		}

		[TestFixture]
		public class RomanDecodeTests
		{
			[TestCase(1, "I")]
			[TestCase(2, "II")]
			[TestCase(4, "IV")]
			[TestCase(707, "DCCVII")]
			[TestCase(1990, "MCMXC")]
			[TestCase(2008, "MMVIII")]
			[TestCase(1666, "MDCLXVI")]
			public void Test(int expected, string roman)
			{
				Assert.AreEqual(expected, Kata.RomanDecode.Solution(roman));
			}
		}

		[TestFixture]
		public class DecomposeTests
		{

			[Test]
			public void Test1()
			{
				var d = new Kata.Decompose();
				Assert.AreEqual("1 2 4 10", d.decompose(11));
				Assert.AreEqual("1 3 5 8 49", d.decompose(50));
				Assert.AreEqual(null, d.decompose(4));
			}
		}
	}
}