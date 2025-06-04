
namespace BlackJack
{
    /// <summary>
    /// Interface for Game class.
    /// </summary>
    public interface IGame
    {
        List<Card> DealerHand { get; set; }
        List<Card> PlayerHand { get; set; }
        GameState State { get; set; }

        void DealerPlays();
        void NewGame();
        void PlayGame();
    }
}