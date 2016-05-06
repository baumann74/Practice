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
			Assert.AreEqual(true, solution.CanFinish(2, new[,] {{1, 0}}));
			Assert.AreEqual(false, solution.CanFinish(2, new[,] {{1, 0}, {0, 1}}));
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

			var node1 = new TreeNode(1) {left = node2, right = node3};
			var solver = new LowestCommonAncestorSolver();

			Assert.AreEqual(node1, solver.LowestCommonAncestor(node1, node2, node3));
		}

		[TestCase]
		public void LowestCommonAncestorSolver3()
		{
			var node2 = new TreeNode(2);
			var node3 = new TreeNode(3);

			var node1 = new TreeNode(1) {left = node2, right = node3};
			var solver = new LowestCommonAncestorSolver();

			Assert.AreEqual(node1, solver.LowestCommonAncestor(node1, node3, node2));
		}

		[TestCase]
		public void ValidateBinarySearchTree_true()
		{
			var node2 = new TreeNode(2);
			var node4 = new TreeNode(4);
			var node6 = new TreeNode(6);
			var node3 = new TreeNode(3) {left = node2, right = node4};
			var node7 = new TreeNode(7) {left = node6};
			var node5 = new TreeNode(5) {left = node3, right = node7};


			var solver = new ValidateBinarySearchTree();

			Assert.AreEqual(true, solver.IsValidBST(node5));
		}

		[TestCase]
		public void ValidateBinarySearchTree_false1()
		{
			var node2 = new TreeNode(2);
			var node6 = new TreeNode(6);
			var node7 = new TreeNode(7);
			var node3 = new TreeNode(3) {left = node2, right = node6};
			var node8 = new TreeNode(8) {left = node7};
			var node5 = new TreeNode(5) {left = node3, right = node8};

			var solver = new ValidateBinarySearchTree();

			Assert.AreEqual(false, solver.IsValidBST(node5));
		}

		[TestCase]
		public void ValidateBinarySearchTree_false2()
		{
			var node1 = new TreeNode(-2147483648);
			var node2 = new TreeNode(-2147483648) {left = node1};

			var solver = new ValidateBinarySearchTree();

			Assert.AreEqual(false, solver.IsValidBST(node2));
		}

		[TestCase]
		public void MaximalSquare1()
		{
			var matrix = new [,]
			{
				{'1', '0', '1', '0', '0'},
				{'1', '0', '1', '1', '1'},
				{'1', '1', '1', '1', '1'},
				{'1', '0', '1', '1', '0'},
			};
			var solver = new MaximalSquareSolver();

			Assert.AreEqual(4, solver.MaximalSquare(matrix));
		}

		[TestCase]
		public void MaximalSquare2()
		{
			var matrix = new[,]
			{
				{'1', '1', '1', '0', '0'},
				{'1', '1', '1', '1', '1'},
				{'1', '1', '1', '1', '1'},
				{'1', '0', '1', '1', '0'},
			};
			var solver = new MaximalSquareSolver();

			Assert.AreEqual(9, solver.MaximalSquare(matrix));
		}

		[TestCase]
		public void MaximalSquare3()
		{
			var matrix = new[,]
			{
				{'0', '0', '1', '0', '0'},
				{'1', '1', '1', '1', '1'},
				{'1', '0', '1', '0', '1'},
				{'1', '0', '1', '1', '0'},
			};
			var solver = new MaximalSquareSolver();

			Assert.AreEqual(1, solver.MaximalSquare(matrix));
		}

		[TestCase]
		public void MaximalSquare4()
		{
			var matrix = new[,]
			{
				{'1', '1', '1', '1', '0'},
				{'1', '1', '1', '1', '1'},
				{'1', '1', '1', '1', '1'},
				{'1', '1', '1', '1', '0'},
			};
			var solver = new MaximalSquareSolver();

			Assert.AreEqual(16, solver.MaximalSquare(matrix));
		}

		[TestCase]
		public void MaximalSquare5()
		{
			var matrix = new[,]
			{
				{'0', '0', '0', '1'},
				{'1', '1', '0', '1'},
				{'1', '1', '1', '1'},
				{'0', '1', '1', '1'},
				{'0', '1', '1', '1'}
			};
			var solver = new MaximalSquareSolver();

			Assert.AreEqual(9, solver.MaximalSquare(matrix));
		}

		[TestCase]
		public void IsSymmetric1()
		{
			var node3l = new TreeNode(3);
			var node4l = new TreeNode(4);
			var node2l = new TreeNode(2) {left = node3l, right = node4l};
			var node3r = new TreeNode(3);
			var node4r = new TreeNode(4);
			var node2r = new TreeNode(2) { left = node4r, right = node3r };
			var node1 = new TreeNode(1) {left = node2l, right = node2r};

			var solver = new SymmetricTree();

			Assert.AreEqual(true, solver.IsSymmetric(node1));
		}

		[TestCase]
		public void IsSymmetric2()
		{
			var node3l = new TreeNode(3);
			var node2l = new TreeNode(2) { right = node3l };
			var node3r = new TreeNode(3);
			var node2r = new TreeNode(2) { right = node3r};
			var node1 = new TreeNode(1) { left = node2l, right = node2r };

			var solver = new SymmetricTree();

			Assert.AreEqual(false, solver.IsSymmetric(node1));
		}

		[TestCase(38, 2)]
		public void AddDigits(int input, int expected)
		{
			Assert.AreEqual(expected, AddDigitsSolver.AddDigits(input));
		}

		[TestCase]
		public void MaximumDepthOfBinaryTree1()
		{
			var node1 = new TreeNode(1);
			var solver = new MaximumDepthOfBinaryTree();
			Assert.AreEqual(1, solver.MaxDepth(node1));
		}

		[TestCase]
		public void MaximumDepthOfBinaryTree2()
		{
			var node2 = new TreeNode(2);
			var node3 = new TreeNode(3);
			var node1 = new TreeNode(1) { left = node2, right = node3};
			var solver = new MaximumDepthOfBinaryTree();
			Assert.AreEqual(2, solver.MaxDepth(node1));
		}

		[TestCase]
		public void MaximumDepthOfBinaryTree3()
		{
			var node3 = new TreeNode(3);
			var node2 = new TreeNode(2) { left = node3};
			var node1 = new TreeNode(1) { left = node2 };
			var solver = new MaximumDepthOfBinaryTree();
			Assert.AreEqual(3, solver.MaxDepth(node1));
		}
	}
}
