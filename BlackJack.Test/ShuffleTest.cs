namespace BlackJack.Test
{
    public class ShuffleTest
    {
        [Fact]
        public void ShuffleCheck()
        {
            //create a new deck and initialise it
            Deck deck = new Deck();
            deck.InitializeDeck();

            //create a copy of the deck.
            Deck copyDeck = new Deck(deck);
            copyDeck.Clone();

            //now shuffle the original deck
            deck.Shuffle();

            //the two should now not be the same,
            //since one was shuffled.
            Assert.NotEqual(copyDeck, deck);




        }
    }
}