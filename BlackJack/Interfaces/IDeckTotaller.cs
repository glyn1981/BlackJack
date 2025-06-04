
namespace BlackJack
{
    /// <summary>
    /// Interface for DeckTotaller class.
    /// </summary>
    public interface IDeckTotaller
    {
        int TotalScore(List<Card> hand);
    }
}