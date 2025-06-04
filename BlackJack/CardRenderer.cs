using static BlackJack.Game;

namespace BlackJack
{
    /// <summary>
    /// Class for rendering the cards to the console.
    /// </summary>
    public class CardRenderer : ICardRenderer
    {
        /// <summary>
        /// render an individual card.
        /// </summary>
        /// <param name="card"></param>
        public void RenderCard(Card card)
        {
            RenderHand(new List<Card> { card });
        }

        /// <summary>
        /// Render the complete hand of cards.
        /// </summary>
        /// <param name="hand"></param>
        public void RenderHand(List<Card> hand)
        {
            if (hand == null || hand.Count == 0)
                return;

            List<string[]> cardLines = new List<string[]>();
            List<ConsoleColor> suitColors = new List<ConsoleColor>();

            foreach (var card in hand)
            {
                string suitSymbol = card.Suit switch
                {
                    "Hearts" => "♥",
                    "Diamonds" => "♦",
                    "Clubs" => "♣",
                    "Spades" => "♠",
                    _ => "?"
                };

                // Choose color for the suit
                ConsoleColor suitColor = card.Suit switch
                {
                    "Hearts" => ConsoleColor.Red,
                    "Diamonds" => ConsoleColor.Red,
                    _ => ConsoleColor.Gray
                };
                suitColors.Add(suitColor);

                string rankSymbol = card.Rank switch
                {
                    "King" => "K",
                    "Queen" => "Q",
                    "Jack" => "J",
                    "Ace" => "A",
                    _ => card.Rank
                };

                string rankLeft = rankSymbol.Length == 2 ? rankSymbol : rankSymbol.PadRight(2);
                string rankRight = rankSymbol.Length == 2 ? rankSymbol : rankSymbol.PadLeft(2);

                string[] lines = new string[]
                {
                    "┌─────────┐",
                    $"│{rankLeft}       │",
                    "│         │",
                    $"│    {suitSymbol}    │", // We'll colorize this line
                    "│         │",
                    $"│       {rankRight}│",
                    "└─────────┘"
                };
                cardLines.Add(lines);
            }

            // Print each line for all cards, right-to-left
            for (int i = 0; i < cardLines[0].Length; i++)
            {
                for (int j = cardLines.Count - 1; j >= 0; j--)
                {
                    if (i == 3) // Suit line
                    {
                        // Split the line to color only the suit symbol
                        string line = cardLines[j][i];
                        int suitIndex = line.IndexOf('♥');
                        if (suitIndex == -1) suitIndex = line.IndexOf('♦');
                        if (suitIndex == -1) suitIndex = line.IndexOf('♣');
                        if (suitIndex == -1) suitIndex = line.IndexOf('♠');
                        if (suitIndex != -1)
                        {
                            // Write before suit
                            Console.Write(line.Substring(0, suitIndex));
                            // Set color and write suit
                            Console.ForegroundColor = suitColors[j];
                            Console.Write(line[suitIndex]);
                            Console.ResetColor();
                            // Write after suit
                            Console.Write(line.Substring(suitIndex + 1) + " ");
                        }
                        else
                        {
                            Console.Write(line + " ");
                        }
                    }
                    else
                    {
                        Console.Write(cardLines[j][i] + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}