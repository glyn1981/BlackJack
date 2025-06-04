namespace BlackJack
{
    /// <summary>
    /// Game class, contains the logic for the game of blackjack.
    /// </summary>
    /// <param name="cardRenderer"></param>
    /// <param name="deck"></param>
    /// <param name="deckTotaller"></param>
    public class Game(ICardRenderer cardRenderer, IDeck deck, IDeckTotaller deckTotaller, IUiHandler uiHandler) : IGame
    {
        private ICardRenderer _cardRenderer = cardRenderer;
        private IDeck _deck = deck;
        private IDeckTotaller _deckTotaller = deckTotaller;
        private IUiHandler _uiHandler = uiHandler;
        public List<Card> PlayerHand { get; set; } = new List<Card>();
        public List<Card> DealerHand { get; set; } = new List<Card>();
        public GameState State { get; set; }
        public int DealerWins = 0;
        public int PlayerWins = 0;

        public void NewGame()
        {
            InitializeDeck();
            DealInitialCards();
            PlayerPlays();     
            DealerPlays();
        }

        private void InitializeDeck()
        {
            PlayerHand = new List<Card>();
            DealerHand = new List<Card>();
            State = GameState.InProgress;

            _deck.InitializeDeck();
            _deck.Shuffle();
        }

        private void DealInitialCards()
        {
            // Deal two cards to player and dealer
            PlayerHand.Add(_deck.Deal());
            DealerHand.Add(_deck.Deal());
            PlayerHand.Add(_deck.Deal());
            DealerHand.Add(_deck.Deal());
        }

        public void PlayerPlays()
        {
            //enter into a loop to allow the player to hit or stand until they bust or stand.
            while (State != GameState.PlayerFinished && _deckTotaller.TotalScore(PlayerHand) <= 21)
            {
                _cardRenderer.RenderHand(PlayerHand);
                _uiHandler.WriteMessage($"Your current hand:{_deckTotaller.TotalScore(PlayerHand)}");

                //we want to render out only the dealers first card, so 
                //we need a new list of cards, to add just the first card to.

                  _uiHandler.WriteMessage($"Dealers Card");
                List<Card> dealerCard = new List<Card>();
                dealerCard.Add(DealerHand.First());
                _cardRenderer.RenderHand(dealerCard);

                if (_deckTotaller.TotalScore(PlayerHand) == 21)
                {
                      _uiHandler.WriteMessage("Blackjack! You win!");
                    State = GameState.PlayerWon;
                    PlayerWins += 1;
                    return;
                }
                  _uiHandler.WriteMessage("Do you want to hit or stand? (h/s)");
                string? choice = _uiHandler.ReadInput()?.ToLower();

                if (choice != null)
                {
                    if (choice == "h")
                    {
                        PlayerHand.Add(_deck.Deal()); // Deal a card from the deck
                    }
                    if (choice == "s")
                    {
                        State = GameState.PlayerFinished;
                        break; // Player stands, exit the loop
                    }
                }


            }
            if (_deckTotaller.TotalScore(PlayerHand) > 21)
            {
                _cardRenderer.RenderHand(PlayerHand);
                _uiHandler.WriteMessage("You bust! Dealer wins!");
                State = GameState.DealerWon;
                DealerWins += 1;
                return;
            }
        }

        public void PlayGame()
        {
            do
            {
                NewGame();
                _uiHandler.WriteMessage("Do you want to play again Y/N");
            }
            while (_uiHandler.ReadInput()?.Trim().ToLower() == "y");

              _uiHandler.WriteMessage("Thanks for playing!");
        }

        public void DealerPlays()
        {

              _uiHandler.WriteMessage("Dealers turn");

            decimal dealerScore = _deckTotaller.TotalScore(DealerHand);

            while (dealerScore < 17 && State == GameState.PlayerFinished)
            {
                DealerHand.Add(_deck.Deal());
                dealerScore = _deckTotaller.TotalScore(DealerHand);
            }
            _cardRenderer.RenderHand(DealerHand);

            if (dealerScore > 21)
            {
                  _uiHandler.WriteMessage("Dealer busts! You win!");
                State = GameState.PlayerWon;
                PlayerWins += 1;
            }
            else
            {
                if (dealerScore > _deckTotaller.TotalScore(PlayerHand))
                {
                      _uiHandler.WriteMessage($"Dealer wins!: {dealerScore} vs {_deckTotaller.TotalScore(PlayerHand)} ");
                    State = GameState.DealerWon;
                    DealerWins += 1; // Increment dealer score to avoid confusion in output, not necessary for logic
                }
                else if (dealerScore < _deckTotaller.TotalScore(PlayerHand))
                {
                      _uiHandler.WriteMessage($"You win!: {dealerScore} vs {_deckTotaller.TotalScore(PlayerHand)} ");
                    State = GameState.PlayerWon;
                    PlayerWins += 1;
                }
                else
                {
                      _uiHandler.WriteMessage($"Its a Draw!: {dealerScore} vs {_deckTotaller.TotalScore(PlayerHand)} ");
                    State = GameState.Draw;
                }
            }

            _uiHandler.WriteMessage($"Player Wins:{PlayerWins} - Dealer Wins:{DealerWins}");

        }


    }
}