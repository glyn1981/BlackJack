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
		IUiHandler _uiHandler;

		public CardRenderer(IUiHandler uiHandler)
		{
			_uiHandler = uiHandler;
		}
		/// <summary>
		/// Render the Hand out to the Console
		/// </summary>
		/// <param name="hand">The collection of cards.</param>
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
			$"│    {suitSymbol}    │",
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
						string line = cardLines[j][i];
						int suitIndex = line.IndexOf('♥');
						if (suitIndex == -1) suitIndex = line.IndexOf('♦');
						if (suitIndex == -1) suitIndex = line.IndexOf('♣');
						if (suitIndex == -1) suitIndex = line.IndexOf('♠');
						if (suitIndex != -1)
						{
							_uiHandler.Write(line.Substring(0, suitIndex));
							Console.ForegroundColor = suitColors[j];
							_uiHandler.Write(line[suitIndex].ToString());
							Console.ResetColor();
							_uiHandler.Write(line.Substring(suitIndex + 1) + " ");
						}
						else
						{
							_uiHandler.Write(line + " ");
						}
					}
					else
					{
						_uiHandler.Write(cardLines[j][i] + " ");
					}
				}
				// Only one line break per row, after all cards in that row are printed
				_uiHandler.WriteLine();
			}
		}
	}
}
