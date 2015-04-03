

namespace Katas.TennisGame
{
	public class Player
	{
		private int points;
		private int sets;
		private int games;

		public Player(int points, int sets = 0, int games = 0)
		{
			this.points = points;
			this.sets = sets;
			this.games = games;
		}

		public void WinsPoint()
		{
			//			points = points.Won();
		}

		public void LostPoint(Player otherPlayer)
		{
			//			points = points.Lost();
		}

		public bool HasGamePoint(Player otherPlayer)
		{
			return false;
			//			return (points.IsGamePoint() && !otherPlayer.GetPoints().IsGamePoint());
		}

		//		public void WonGame()
		//		{
		//			games++;
		//			points = 0;
		//		}
		//
		//		public void LostGame()
		//		{
		//			points = 0;
		//		}
		//
		//		public bool HasGamePoint(Player otherPlayer)
		//		{
		//			return points == 3 && otherPlayer.GetPoints() > 3 || HasAdvantage();
		//		}
		//
		//		private bool HasAdvantage()
		//		{
		//			return points == 4;
		//		}
	}
}
