using System.Linq;

namespace LeetCode
{
	// https://leetcode.com/problems/single-number/

	public class SingleNumberSolver
	{
		public int SingleNumber(int[] nums)
		{
			var list = nums.ToList();
			list.Sort();
			for (var i = 0; i < list.Count - 1; i = i + 2)
			{
				if (list[i] != list[i + 1]) return list[i];
			}
			return list[list.Count - 1];
		}
	}
}
