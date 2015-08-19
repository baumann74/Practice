using System;
using System.Collections.Generic;
using System.Linq;

namespace Misc
{
	// http://blackrabbitcoder.net/archive/2015/04/07/little-puzzlersndashlargest-puddle-on-a-bar-chart.aspx

	public class LargestPuddle
	{
		public int Calculate(int[] input)
		{
			var previous = 0;
			var currentStart = 0;
			var currentPoolList = new List<int>();
			var maxPoolSoFar = 0;

			for (var i = 0; i < input.Length; i++)
			{
				var current = input[i];
				if (current < previous)
				{
					if (currentStart == 0)
					{
						currentStart = previous;	
					}
					currentPoolList.Add(current);
				}
				else if (current > previous && currentStart > 0)
				{
					if (current >= currentStart || i == input.Length - 1)
					{
						var poolHeight = Math.Min(currentStart, current);
						var sum = currentPoolList.Sum(x => poolHeight - x);
						if (sum > maxPoolSoFar)
						{
							maxPoolSoFar = sum;
						}
						currentStart = 0;
						currentPoolList.Clear();
					}
					else
					{
						currentPoolList.Add(current);
					}
				}
				previous = current;
			}
			return maxPoolSoFar;
		}
	}
}
