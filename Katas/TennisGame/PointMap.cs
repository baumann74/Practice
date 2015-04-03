using System;
using System.Collections.Generic;

namespace Katas.TennisGame
{
	public class PointsMap
	{
		private readonly Dictionary<Tuple<int, int>, string> pointsMap = new Dictionary<Tuple<int, int>, string>();

		public PointsMap()
		{
			pointsMap.Add(new Tuple<int, int>(0, 0), "0-0");
			pointsMap.Add(new Tuple<int, int>(1, 0), "15-0");
			pointsMap.Add(new Tuple<int, int>(1, 1), "15-All");
			pointsMap.Add(new Tuple<int, int>(0, 1), "0-15");
			pointsMap.Add(new Tuple<int, int>(2, 0), "30-0");
			pointsMap.Add(new Tuple<int, int>(2, 1), "30-15");
			pointsMap.Add(new Tuple<int, int>(2, 2), "30-All");
			pointsMap.Add(new Tuple<int, int>(0, 2), "0-30");
			pointsMap.Add(new Tuple<int, int>(1, 2), "15-30");
			pointsMap.Add(new Tuple<int, int>(3, 0), "40-0");
			pointsMap.Add(new Tuple<int, int>(3, 1), "40-15");
			pointsMap.Add(new Tuple<int, int>(3, 2), "40-30");
			pointsMap.Add(new Tuple<int, int>(3, 3), "Deuce");
			pointsMap.Add(new Tuple<int, int>(2, 3), "30-40");
			pointsMap.Add(new Tuple<int, int>(1, 3), "15-40");
			pointsMap.Add(new Tuple<int, int>(0, 3), "0-40");
			pointsMap.Add(new Tuple<int, int>(4, 3), "Adv. player1");
			pointsMap.Add(new Tuple<int, int>(3, 4), "Adv. player2");
		}

		public string Get(int player1, int player2)
		{
			return pointsMap[new Tuple<int, int>(player1, player2)];
		}
	}
}
