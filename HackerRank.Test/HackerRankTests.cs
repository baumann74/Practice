﻿
using FluentAssertions;
using NUnit.Framework;

namespace HackerRank.Test
{
	using System.Diagnostics;

	[TestFixture]
	public class HackerRankTests
	{
		[TestCase(0, 1)]
		[TestCase(1, 2)]
		[TestCase(4, 7)]
		public void UtopianTree(int cycles, int result)
		{
			HackerRank.UtopianTree.Solve(cycles).Should().Be(result);
		}

		[TestCase(10, 10, 1, 1, 1, 20)]
		[TestCase(5, 9, 2, 3, 4, 37)]
		[TestCase(3, 6, 9, 1, 1, 12)]
		[TestCase(7, 7, 4, 2, 1, 35)]
		[TestCase(3, 3, 1, 9, 2, 12)]
		[TestCase(11152, 43844, 788543, 223872, 972572, 18609275504)]
		public void TaumAndBday(long b, long w, long x, long y, long z, long result)
		{
			HackerRank.TaumAndBday.Solve(b, w, x, y, z).Should().Be(result);
		}

		[TestCase("We promptly judged antique ivory buckles for the next prize", true)]
		[TestCase("We promptly judged antique ivory buckles for the prize", false)]
		public void Panagrams(string s, bool result)
		{
			HackerRank.Panagrams.IsPanagram(s).Should().Be(result);
		}

		[TestCase("ab", "ba")]
		[TestCase("bb", "no answer")]
		[TestCase("hefg", "hegf")]
		[TestCase("zedawdvyyfumwpupuinbdbfndyehircmylbaowuptgmw", "zedawdvyyfumwpupuinbdbfndyehircmylbaowuptgwm")]
		[TestCase("ocsmerkgidvddsazqxjbqlrrxcotrnfvtnlutlfcafdlwiismslaytqdbvlmcpapfbmzxmftrkkqvkpflxpezzapllerxyzlcf",
			"ocsmerkgidvddsazqxjbqlrrxcotrnfvtnlutlfcafdlwiismslaytqdbvlmcpapfbmzxmftrkkqvkpflxpezzapllerxyzlfc")]
		[TestCase("ehxxdsuhoowxpbxiwxjrhe", "ehxxdsuhoowxpbxiwxrehj")]
		[TestCase("jrhe", "rehj")]
		[TestCase("pqommldkafmnwzidydgjghxcbnwyjdxpvmkztdfmcxlkargafjzeye", "pqommldkafmnwzidydgjghxcbnwyjdxpvmkztdfmcxlkargafjzyee")]
		[TestCase("eye", "yee")]
		public void BiggerIsGreater(string s, string result)
		{
			HackerRank.BiggerIsGreater.Solution(s).Should().Be(result);
		}

		[TestCase(2, new[] { "MOVE T1 T2", "MOVE T1 T3", "MOVE T2 T3" })]
		[TestCase(3, new[] {       
			"MOVE T1 T3",
			"MOVE T1 T2",
			"MOVE T3 T2",
			"MOVE T1 T3",
			"MOVE T2 T1",
			"MOVE T2 T3",
			"MOVE T1 T3"
		})]
		public void TowerOfHanoi(int n, string[] result)
		{
			TowersOfHanoi.FindMoves(n).Should().BeEquivalentTo(result);
		}


		[TestCase(4, new[] {1, 2, 3}, 4)]
		[TestCase(10, new[] {2, 5, 3,6}, 5)]
//		[TestCase(166, new[] {5, 37, 8, 39, 33, 17, 22, 32, 13, 7, 10, 35, 40, 2, 43, 49, 46, 19, 41, 1, 12, 11, 28}, 96190959)]
		public void CoinChangeProblem(int n, int[] coins, long result)
		{
			HackerRank.CoinChangeProblem.Solve(n, coins).Should().Be(result);
			Debug.WriteLine("Test");
		}
	}
}