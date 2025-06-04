// See https://aka.ms/new-console-template for more information
using BlackJack;

//setup the dependencies for the game.
ICardRenderer cardRenderer = new CardRenderer();
IDeck deck = new Deck();
IDeckTotaller deckTotaller = new DeckTotaller();
IGame game = new Game(cardRenderer, deck, deckTotaller);


Console.WriteLine("Game initialized with a shuffled deck of cards.");
Console.OutputEncoding = System.Text.Encoding.UTF8;
game.PlayGame();


