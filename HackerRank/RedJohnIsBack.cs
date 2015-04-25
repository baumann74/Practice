
namespace HackerRank
{
	using System;
	using System.Diagnostics;

	public class RedJohnIsBack
	{
		public static int Solution(int t)
		{
			return Helper(new int[4, t]);
		}

		public static int Helper(int[,] wall)
		{
			if (Is_wall_covered(wall))
			{
				PrintWall(wall);
				return 1;
			}
			var result = 0;
			var horizontalPos = Next_horizontal_position(wall);
			if (horizontalPos.Item1 != -1)
			{
				var newWall = Put_horizontal_brick(wall, horizontalPos.Item1, horizontalPos.Item2);
				result += Helper(newWall);
			}
			var verticalPos = Next_vertical_position(wall);
			if (verticalPos != -1)
			{
				var newWall = Put_vertical_brick(wall, verticalPos);
				result += Helper(newWall);
			}
			return result;
		}

		public static int Next_vertical_position(int[,] wall)
		{
			for (var i = 0; i < wall.GetLength(1); i++)
			{
				if (Is_vertical_brick_valid(wall, i)) return i;
			}
			return -1;
		}

		public static bool Is_vertical_brick_valid(int[,] wall, int column)
		{
			for (var i = 0; i < 4; i++)
			{
				if (wall[i, column] != 0) return false;
			}
			return true;
		}

		public static Tuple<int, int> Next_horizontal_position(int[,] wall)
		{
			for (var i = 0; i < 4; i++)
			{
				for (var j = 0; j < wall.GetLength(1) - 4; j++)
				{
					if (Is_horizontal_brick_valid(wall, i, j)) return Tuple.Create(i, j);
				}
			}
			return Tuple.Create(-1, -1);
		}

		public static bool Is_horizontal_brick_valid(int[,] wall, int row, int column)
		{
			if (column + 4 > wall.GetLength(1)) return false;
			if (row > 3) return false;
			for (var i = column; i < column + 4; i++)
			{
				if (wall[row, i] != 0) return false;
			}
			return true;
		}

		private static int[,] Put_horizontal_brick(int[,] wall, int row, int column)
		{
			var result = (int[,])wall.Clone();
			for (var i = column; i < column + 4; i++)
			{
				result[row, i] = 2;
			}
			return result;
		}

		private static int[,] Put_vertical_brick(int[,] wall, int column)
		{
			var result = (int[,])wall.Clone();
			for (var i = 0; i < 4; i++)
			{
				result[i, column] = 1;
			}
			return result;
		}

		public static bool Is_wall_covered(int[,] wall)
		{
			for (var i = 0; i < 4; i++)
			{
				for (var j = 0; j < wall.GetLength(1); j++)
				{
					if (wall[i, j] == 0) return false;
				}
			}
			return true;
		}

		private static void PrintWall(int[,] wall)
		{
			Debug.WriteLine("******************");
			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < wall.GetLength(1); j++)
				{
					Debug.Write(wall[i, j]);
				}
				Debug.WriteLine("");
			}
			Debug.WriteLine("******************");
		}
	}
}
