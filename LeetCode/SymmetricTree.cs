namespace LeetCode
{
	public class SymmetricTree
	{
		public bool IsSymmetric(TreeNode root)
		{
			if (root == null) return true;
			if (root.left == null && root.right == null) return true;
			if (root.left == null || root.right == null) return false;
			return IsSymmetricHelper(root.left, root.right);
		}

		public bool IsSymmetricHelper(TreeNode left, TreeNode right)
		{
			if (left == null && right == null) return true;
			if (left == null || right == null) return false;
			return left.val == right.val && IsSymmetricHelper(left.left, right.right) && IsSymmetricHelper(left.right, right.left);
		}
	}

/**
		public bool IsSymmetric(TreeNode root)
		{
			if (root == null) return true;
			var leftList = new List<int?>();
			var rightList = new List<int?>();
			if (root.left != null)
			{
				TraverseLeft(root.left, leftList);	
			}
			if (root.right != null)
			{
				TraverseRight(root.right, rightList);	
			}
			return leftList.Count == rightList.Count && leftList.SequenceEqual(rightList);
		}

		private static void TraverseLeft(TreeNode root, List<int?> list)
		{
			if (root == null)
			{
				list.Add(null);
				return;
			}
			if (root.left == null && root.right == null)
			{
				list.Add(root.val);
				return;
			}
			list.Add(root.val);
			TraverseLeft(root.left, list);
			TraverseLeft(root.right, list);
		}

		private static void TraverseRight(TreeNode root, List<int?> list)
		{
			if (root == null)
			{
				list.Add(null);
				return;
			}
			if (root.left == null && root.right == null)
			{
				list.Add(root.val);
				return;
			}
			list.Add(root.val);
			TraverseRight(root.right, list);
			TraverseRight(root.left, list);
		}
	}
 */ 
}
