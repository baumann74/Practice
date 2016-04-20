﻿using NUnit.Framework;
using System;

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

		[TestFixture]
		public class BraceTests
		{

			[Test]
			public void Test1()
			{
				Assert.AreEqual(true, Kata.Brace.validBraces("()"));
			}

			[Test]
			public void Test2()
			{

				Assert.AreEqual(false, Kata.Brace.validBraces("[(])"));
			}

			[Test]
			public void Test3()
			{
				Assert.AreEqual(true, Kata.Brace.validBraces("(){}[]"));
			}

			[Test]
			public void Test4()
			{
				Assert.AreEqual(true, Kata.Brace.validBraces("([{}])"));
			}

			[Test]
			public void Test5()
			{
				Assert.AreEqual(false, Kata.Brace.validBraces("[({})](]"));
			}

			[Test]
			public void Test6()
			{
				Assert.AreEqual(false, Kata.Brace.validBraces("(}"));
			}

			[Test]
			public void Test7()
			{
				Assert.AreEqual(false, Kata.Brace.validBraces("}"));
			}

			[Test]
			public void Test8()
			{
				Assert.AreEqual(true, Kata.Brace.validBraces("[][][]"));
			}

			[Test]
			public void Test9()
			{
				Assert.AreEqual(false, Kata.Brace.validBraces("}}]]))}])"));
			}

			[Test]
			public void Test10()
			{
				Assert.AreEqual(false, Kata.Brace.validBraces("(((({{"));
			}
		}

		[TestFixture]
		public class SumStringsTest
		{
			[Test]
			public void test()
			{
				Assert.AreEqual("579", Kata.KataSumString.SumStrings("123", "456"));
			}
		}

		[TestFixture]
		public class SuzukiTesting
		{
			private static readonly Tuple<int, string>[] grp1 =
			{
				new Tuple<int,string>(2,"tofu"),
				new Tuple<int,string>(2,"potato"),
				new Tuple<int,string>(2,"cucumber"),
				new Tuple<int,string>(2,"cabbage"),
				new Tuple<int,string>(1,"turnip"),
				new Tuple<int,string>(1,"pepper"),
				new Tuple<int,string>(1,"onion"),
				new Tuple<int,string>(1,"mushroom"),
				new Tuple<int,string>(1,"celery"),
				new Tuple<int,string>(1,"carrot")
			  };

			private static readonly string str1 =
			  "potato tofu cucumber cabbage turnip pepper onion carrot celery mushroom potato tofu cucumber cabbage";

			private static readonly Tuple<int, string>[] grp2 =
			{
				new Tuple<int,string>(15,"turnip"),
				new Tuple<int,string>(14,"mushroom"),
				new Tuple<int,string>(13,"cabbage"),
				new Tuple<int,string>(10,"carrot"),
				new Tuple<int,string>(9,"potato"),
				new Tuple<int,string>(7,"onion"),
				new Tuple<int,string>(6,"tofu"),
				new Tuple<int,string>(6,"pepper"),
				new Tuple<int,string>(5,"cucumber"),
				new Tuple<int,string>(4,"celery")
			  };

			private static readonly string str2 =
			  "mushroom chopsticks chopsticks turnip mushroom carrot mushroom cabbage mushroom carrot tofu pepper cabbage " +
			  "potato cucumber mushroom mushroom potato turnip chopsticks cabbage celery celery turnip pepper chopsticks " +
			  "potato potato onion cabbage cucumber onion pepper onion cabbage potato tofu carrot cabbage cabbage turnip " +
			  "mushroom cabbage cabbage cucumber cabbage chopsticks turnip pepper onion pepper onion mushroom turnip carrot " +
			  "carrot tofu onion tofu chopsticks chopsticks chopsticks mushroom cucumber chopsticks carrot potato cabbage cabbage " +
			  "carrot mushroom chopsticks mushroom celery turnip onion carrot turnip cucumber carrot potato mushroom turnip " +
			  "mushroom cabbage tofu turnip turnip turnip mushroom tofu potato pepper turnip potato turnip celery carrot turnip";

			[Test]
			public void FixedTest1()
			{
				var result = Kata.Suzuki.CountVegetables(str1);
				Assert.AreEqual(grp1, result);
			}

			[Test]
			public void FixedTest2()
			{
				var result = Kata.Suzuki.CountVegetables(str2);
				Assert.AreEqual(grp2, result);
			}
		}
	}
}