
using FluentAssertions;

namespace KatasTest.TennisGameTest
{
	using Katas.TennisGame;
	using NUnit.Framework;

	[TestFixture]
	public class GameTest
	{
//		[Test]
		public void FifteenLove()
		{
			// arrange
			var game = new Game();

			// act
			game.PlayerOneWins();

			// assert
			game.Score().Should().Be("0-0 - 0-0 - 15-0");
		}

//		[Test]
		public void LoveFifteen()
		{
			// arrange
			var game = new Game();

			// act
			game.PlayerTwoWins();

			// assert 
			game.Score().Should().Be("0-0 - 0-0 - 0-15");
		}

//		[Test]
		public void ThirtyFifteen()
		{
			// arrange
			var game = new Game();

			// act
			game.PlayerOneWins();
			game.PlayerTwoWins();
			game.PlayerOneWins();

			// assert
			game.Score().Should().Be("0-0 - 0-0 - 30-15");
		}

//		[Test]
		public void FifteenThirty()
		{
			// arrange
			var game = new Game();

			// act
			game.PlayerOneWins();
			game.PlayerTwoWins();
			game.PlayerOneWins();

			// assert
			game.Score().Should().Be("0-0 - 0-0 - 30-15");
		}

//		[Test]
		public void ThirtyAll()
		{
			// arrange
			var game = new Game();

			// act
			game.PlayerOneWins();
			game.PlayerTwoWins();
			game.PlayerOneWins();
			game.PlayerTwoWins();

			// assert
			game.Score().Should().Be("0-0 - 0-0 - 30-All");
		}

//		[Test]
		public void LoveFourty()
		{
			// arrange
			var game = new Game();

			// act
			game.PlayerTwoWins();
			game.PlayerTwoWins();
			game.PlayerTwoWins();

			// assert
			game.Score().Should().Be("0-0 - 0-0 - 0-40");
		}

//		[Test]
		public void FourtyLove()
		{
			// arrange
			var game = new Game();

			// act
			game.PlayerOneWins();
			game.PlayerOneWins();
			game.PlayerOneWins();

			// assert
			game.Score().Should().Be("0-0 - 0-0 - 40-0");
		}

//		[Test]
		public void FourtyThirty()
		{
			// arrange
			var game = new Game();

			// act
			game.PlayerOneWins();
			game.PlayerTwoWins();
			game.PlayerTwoWins();
			game.PlayerOneWins();
			game.PlayerOneWins();

			// assert
			game.Score().Should().Be("0-0 - 0-0 - 40-30");
		}

//		[Test]
		public void Deuce()
		{
			// arrange
			var game = new Game();

			// act
			game.PlayerOneWins();
			game.PlayerTwoWins();
			game.PlayerTwoWins();
			game.PlayerOneWins();
			game.PlayerOneWins();
			game.PlayerTwoWins();

			// assert
			game.Score().Should().Be("0-0 - 0-0 - Deuce");
		}

//		[Test]
		public void AdvPlayer1()
		{
			// arrange
			var game = new Game();

			// act
			game.PlayerOneWins();
			game.PlayerTwoWins();
			game.PlayerTwoWins();
			game.PlayerOneWins();
			game.PlayerOneWins();
			game.PlayerTwoWins();
			game.PlayerOneWins();

			// assert
			game.Score().Should().Be("0-0 - 0-0 - Adv. player1");
		}

//		[Test]
		public void AdvPlayer2()
		{
			// arrange
			var game = new Game();

			// act
			game.PlayerOneWins();
			game.PlayerTwoWins();
			game.PlayerTwoWins();
			game.PlayerOneWins();
			game.PlayerOneWins();
			game.PlayerTwoWins();
			game.PlayerTwoWins();

			// assert
			game.Score().Should().Be("0-0 - 0-0 - Adv. player2");
		}

//		[Test]
		public void DeuceAfterAdv()
		{
			// arrange
			//			var game = new Game(new Player(0, 0, 3), new Player(0, 0, 4));
			//
			//			// act
			//			game.Player1WonPoint();
			//
			//			// assert
			//			game.Score().Should().Be("0-0 - 0-0 - Deuce");
		}

//		[Test]
		public void GameAfterForty()
		{
			// arrange
			var game = new Game();

			// act
			game.PlayerOneWins();
			game.PlayerOneWins();
			game.PlayerOneWins();
			game.PlayerOneWins();

			// assert
			game.Score().Should().Be("0-0 - 1-0 - 0-0");
		}
	}
}
