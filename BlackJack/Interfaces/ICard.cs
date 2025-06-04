namespace BlackJack
{
    /// <summary>
    /// Interface for Card class.
    /// </summary>
    public interface ICard
    {
        string Rank { get; set; }
        string Suit { get; set; }
        int Score { get; }


    }
}