using System;

namespace Katas.TennisGame
{
	public class RegularGameState : IGameState
	{
		private int playerOnePoints;
		private int playerTwoPoints;
		private Game game;

		public RegularGameState(int playerOnePoints, int playerTwoPoints, Game game)
		{
			this.playerOnePoints = playerOnePoints;
			this.playerTwoPoints = playerTwoPoints;
			this.game = game;
		}

		public void PlayerOneWins()
		{
			throw new NotImplementedException();
		}

		//		private bool IsNextPointGamePointForPlayerOne()
		//		{
		//
		//		}

		public void PlayerTwoWins()
		{
			throw new NotImplementedException();
		}

		public string GetScore()
		{
			throw new NotImplementedException();
		}
	}
}
