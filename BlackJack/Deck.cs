namespace BlackJack
{
    public class Deck : IDeck
    {
        public List<Card> Cards { get; set; } = new List<Card>();

        public Deck()
        {
        }

        // Copy constructor for deep copy
        public Deck(Deck other)
        {
            // Deep copy each card
            Cards = other.Cards.Select(card => new Card(card.Suit, card.Rank)).ToList();
        }

        // Optional: Clone method for convenience
        public Deck Clone()
        {
            return new Deck(this);
        }

        public void InitializeDeck()
        {
            Cards.Clear();
            string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
            string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };
            foreach (var suit in suits)
            {
                foreach (var rank in ranks)
                {
                    Cards.Add(new Card(suit, rank));
                }
            }
        }

        public void Shuffle()
        {
            Random rand = new Random();
            Cards = Cards.OrderBy(x => rand.Next()).ToList();
        }

        public Card Deal()
        {
            if (Cards.Count == 0)
                throw new InvalidOperationException("No cards left in the deck.");
            Card card = Cards[0];
            Cards.RemoveAt(0);
            return card;
        }
    }
}