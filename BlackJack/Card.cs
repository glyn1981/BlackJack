namespace BlackJack
{

    /// <summary>
    /// Class that represents an individual card.
    /// </summary>
    public class Card : ICard
    {
        public string Suit { get; set; }
        public string Rank { get; set; }

        public Card(string suit, string rank)
        {
            Suit = suit;
            Rank = rank;
        }

        /// <summary>
        /// Function to get the numercial value of the card.
        /// </summary>
        public int Score
        {
            get
            {
                switch (Rank)
                {
                    case "2": return 2;
                    case "3": return 3;
                    case "4": return 4;
                    case "5": return 5;
                    case "6": return 6;
                    case "7": return 7;
                    case "8": return 8;
                    case "9": return 9;
                    case "10":
                    case "Jack":
                    case "Queen":
                    case "King": return 10;
                    case "Ace": return 11; // Ace can also be counted as 1, but we'll handle that in scoring logic
                    default: return 0; // If the rank is not recognized, return 0
                }
            }
        }
        /// <summary>
        /// Function to render out the card name.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Rank} of {Suit}";
        }
    }
}
