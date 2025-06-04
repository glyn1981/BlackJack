namespace BlackJack
{
    /// <summary>
    /// Interface for CardRenderer class.
    /// </summary>
    public interface ICardRenderer
    {
        void RenderCard(Card card);
        void RenderHand(List<Card> hand);
    }
}