namespace BlackJack
{
    /// <summary>
    /// Interface for Deck Class.
    /// </summary>
    public interface IDeck
    {
        void InitializeDeck();
        void Shuffle();

        Card Deal();
    }
}