using System;
using System.Collections.Generic;
using System.Text;

namespace Katas
{

	public class PrintDiamond
	{

		public string Print(Char c)
		{
			var top = Build_top(c);
			var middle = Build_middle(c);
			var bottom = Build_bottom(c);
			return Assemble_string(top, middle, bottom);
		}

		// integration
		private static IEnumerable<string> Build_top(char c)
		{
			var result = new List<string>();
			var max = Char.ToUpper(c) - 'A';
			for (var i = 0; i <= max - 1; i++)
				Build_row(i, max, result);
			return result;
		}

		// operation
		private static void Build_row(int current, int max, ICollection<string> list)
		{
			var c = Convert.ToString((char)('A' + current));
			if (current == 0)
			{
				list.Add(c.PadLeft(max + 1));
			}
			else
			{
				list.Add(c.PadLeft((max - current) + 1) + c.PadLeft(current*2));
			}
		}

		// operation
		private static string Build_middle(char c)
		{
			var max = Char.ToUpper(c) - 'A';
			var s = Convert.ToString(c);
			return s + s.PadLeft(max * 2);
		}

		// integration
		private static IEnumerable<string> Build_bottom(char c)
		{
			var result = new List<string>();
			var max = Char.ToUpper(c) - 'A';
			for (var i = max - 1; i >= 0; i--)
				Build_row(i, max, result);
			return result;
		}

	 	// operation
		private static string Assemble_string(IEnumerable<string> top, string middle, IEnumerable<string> buttom)
		{
			var stringBuilder = new StringBuilder();
			foreach (var row in top)
			{
				stringBuilder.AppendLine(row);
			}
			stringBuilder.AppendLine(middle);
			foreach (var row in buttom)
			{
				stringBuilder.AppendLine(row);
			}
			return stringBuilder.ToString();
		}
	}
}
