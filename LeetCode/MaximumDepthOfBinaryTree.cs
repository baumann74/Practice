using System;

namespace LeetCode
{
	public class MaximumDepthOfBinaryTree
	{
		public int MaxDepth(TreeNode root)
		{
			if (root == null) return 0;
			if (root.left == null && root.right == null) return 1;
			return 1 + Math.Max(MaxDepth(root.left), MaxDepth(root.right));
		}
	}
}
