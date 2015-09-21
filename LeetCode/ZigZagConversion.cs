﻿
using System.Collections.Generic;
using System.Linq;

namespace LeetCode
{
	// https://leetcode.com/problems/zigzag-conversion/

	public class ZigZagConversion
	{
		public string Convert(string s, int numRows)
		{
			if (numRows == 1) return s;
			var rows = new List<string>(new string[numRows]);
			var max = (numRows - 1);
			for (var i = 0; i < s.Length; i++)
			{
				var counter = i / max;
				if (counter % 2 == 0)
				{
					rows[i % max] += s[i];
				}
				else
				{
					rows[max - (i % max)] += s[i];
				}
			}
			return rows.Aggregate("", (aggregate, current) => aggregate + current);
		}
	}
}
