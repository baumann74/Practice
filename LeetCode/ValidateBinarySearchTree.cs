
namespace LeetCode
{
	public class ValidateBinarySearchTree
	{
		public bool IsValidBST(TreeNode root)
		{
			return IsValidBSTHelper(root, long.MinValue, long.MaxValue);
		}

		private static bool IsValidBSTHelper(TreeNode node, long min, long max)
		{
			if (node == null) return true;
			if (node.val < min || node.val > max) return false;
			if (node.left == null && node.right == null) return true;
			return IsValidBSTHelper(node.left, min, ((long)node.val) - 1) && IsValidBSTHelper(node.right, ((long)node.val) + 1, max);
		}
	}
}
