
using System;

namespace LeetCode
{
	public class MaximalSquareSolver
	{

		// Better solution: http://geekswithblogs.net/BlackRabbitCoder/archive/2015/04/27/solution-to-little-puzzlersndashlargest-square-of-lsquo1rsquos-in-a-matrix.aspx
		public int MaximalSquare(char[,] matrix)
		{
			var max = 0;
			for (var i = 0; i < matrix.GetLength(0); i++)
			{
				for (var j = 0; j < matrix.GetLength(1); j++)
				{
					var size = 1;
					var isSquare = false;
					do
					{
						isSquare = CheckSquare(matrix, i, j, size);
						if (isSquare)
						{
							max = Math.Max(max, size * size);	
						}
						size++;
					} while (isSquare);
				}
			}
			return max;
		}

		private static bool CheckSquare(char[,] matrix, int row, int col, int size)
		{
			if (row + size > matrix.GetLength(0) || col + size > matrix.GetLength(1)) return false;
			for (var i = row; i < row + size; i++)
			{
				for (var j = col; j < col + size; j++)
				{
					if (matrix[i, j] == '0') return false;
				}
			}
			return true;
		}
	}
}
