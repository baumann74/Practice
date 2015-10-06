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

		[TestCase]
		public void LowestCommonAncestorSolver1()
		{
			var node7 = new TreeNode(7);
			var node4 = new TreeNode(4);
			var node2 = new TreeNode(2) {left = node7, right = node4};
			var node6 = new TreeNode(6);
			var node5 = new TreeNode(5) {left = node6, right = node2};
			var node0 = new TreeNode(0);
			var node8 = new TreeNode(8);
			var node1 = new TreeNode(1) {left = node0, right = node8};
			var node3 = new TreeNode(3) {left = node5, right = node1};
			var solver = new LowestCommonAncestorSolver();

			Assert.AreEqual(node5, solver.LowestCommonAncestor(node3, node6, node4));
			Assert.AreEqual(node3, solver.LowestCommonAncestor(node3, node5, node1));
			Assert.AreEqual(node5, solver.LowestCommonAncestor(node3, node5, node4));
		}

		[TestCase]
		public void LowestCommonAncestorSolver2()
		{
			var node2 = new TreeNode(2);
			var node3 = new TreeNode(3);

			var node1 = new TreeNode(1) { left = node2, right = node3 };
			var solver = new LowestCommonAncestorSolver();

			Assert.AreEqual(node1, solver.LowestCommonAncestor(node1, node2, node3));
		}

		[TestCase]
		public void LowestCommonAncestorSolver3()
		{
			var node2 = new TreeNode(2);
			var node3 = new TreeNode(3);

			var node1 = new TreeNode(1) { left = node2, right = node3 };
			var solver = new LowestCommonAncestorSolver();

			Assert.AreEqual(node1, solver.LowestCommonAncestor(node1, node3, node2));
		}
	}
}
