
namespace Katas.TennisGame
{
	public interface IGameState
	{
		void PlayerOneWins();

		void PlayerTwoWins();

		string GetScore();
	}
}
