
namespace BlackJack
{
    // A class that calculates the total score of a hand of cards in Blackjack.
    public class DeckTotaller : IDeckTotaller
    {
        /// <summary>
        /// Function to calculate the value of the hand.
        /// </summary>
        /// <param name="hand"></param>
        /// <returns></returns>
        public int TotalScore(List<Card> hand)
        {
            int total = 0;
            int acesCount = 0;
            foreach (var card in hand)
            {
                total += card.Score;
                if (card.Rank == "Ace")
                {
                    acesCount++;
                }
            }
            // Adjust for Aces if total exceeds 21
            while (total > 21 && acesCount > 0)
            {
                total -= 10; // Treat Ace as 1 instead of 11
                acesCount--;
            }
            return total;
        }

    }
}
