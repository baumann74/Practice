
namespace LeetCode
{
	public class LowestCommonAncestorSolver
	{
		public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
		{
			if (root == null) return null;
			if (root == p) return p;
			if (root == q) return q;
			if (root.left == null && root.right == null) return null;
			var left = LowestCommonAncestor(root.left, p, q);
			var right = LowestCommonAncestor(root.right, p, q);
			if (left == p && right == q || left == q && right == p) return root;
			return left ?? right;
		}
	}
}
