using System.Text;

namespace Katas.TennisGame
{
	public class Game
	{
		private IGameState gameState;
		//		private readonly PointsMap pointsMap = new PointsMap();
		//		private readonly Player player1;
		//		private readonly Player player2;

		public Game()
		{
		}

		public void ChangeGameState(IGameState newState)
		{

		}

		//		public Game(Player player1, Player player2)
		//		{
		//			this.player1 = player1;
		//			this.player2 = player2;
		//		}




		public void PlayerOneWins()
		{
			//			player1.WonPoint(player2.GetPoints());
			//			if (player1.HasGamePoint(player2))
			//			{
			//				player1.WonGame();
			//				player2.LostGame();
			//			}
			//			else
			//			{
			//				player1.WonPoint();
			//				player2.LostPoint();
			//			}
		}

		public void PlayerTwoWins()
		{
			//			player2.WonPoint();
			//			player1.LostPoint();
		}

		public string Score()
		{
			var result = new StringBuilder();
			//			result.Append(string.Format("{0}-{1} - ", player1.GetSets(), player2.GetSets()));
			//			result.Append(string.Format("{0}-{1} - ", player1.GetGames(), player2.GetGames()));
			//			result.Append(player1.GetPoints());
			return result.ToString();
		}

		static void Main(string[] args)
		{

		}
	}
}
