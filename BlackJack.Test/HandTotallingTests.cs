namespace BlackJack.Test
{
    public class HandTotallingTests
    {
        /// <summary>
        /// Test for a hand with an Ace, King, and Queen, which should total 21.
        /// </summary>
        [Fact]
        public void AceKingQueen_ShouldBe21()
        {
            LinkedList<Card> hand = new LinkedList<Card>();
            hand.AddLast(new Card("Hearts", "Ace"));
            hand.AddLast(new Card("Diamonds", "King"));
            hand.AddLast(new Card("Clubs", "Queen"));
            DeckTotaller totaller = new DeckTotaller();
            Assert.Equal(21, totaller.TotalScore(hand.ToList()));
        }

        /// <summary>
        /// Test for a hand with an Ace, 10, and 10, which should total 21.
        /// </summary>
        [Fact]
        public void AceTenTen_ShouldBe21()
        {
            LinkedList<Card> hand = new LinkedList<Card>();
            hand.AddLast(new Card("Hearts", "Ace"));
            hand.AddLast(new Card("Diamonds", "10"));
            hand.AddLast(new Card("Clubs", "10"));
            DeckTotaller totaller = new DeckTotaller();
            Assert.Equal(21, totaller.TotalScore(hand.ToList()));
        }

        /// <summary>
        /// Test for a hand with three 2s, which should total 6.
        /// </summary>
        [Fact]
        public void TwoTwoTwo_ShouldBe6()
        {
            LinkedList<Card> hand = new LinkedList<Card>();
            hand.AddLast(new Card("Hearts", "2"));
            hand.AddLast(new Card("Diamonds", "2"));
            hand.AddLast(new Card("Clubs", "2"));
            DeckTotaller totaller = new DeckTotaller();
            Assert.Equal(6, totaller.TotalScore(hand.ToList()));
        }

        /// <summary>
        /// Test for a hand with an Ace, 2, and 2, which should total 15.
        /// </summary>
        [Fact]

        public void AceTwoTwo_ShouldBe15()
        {
            LinkedList<Card> hand = new LinkedList<Card>();
            hand.AddLast(new Card("Hearts", "Ace"));
            hand.AddLast(new Card("Diamonds", "2"));
            hand.AddLast(new Card("Clubs", "2"));
            DeckTotaller totaller = new DeckTotaller();
            Assert.Equal(15, totaller.TotalScore(hand.ToList()));
        }
        /// <summary>
        /// Test for a hand with two Aces and a 9, which should be counted as 21.
        /// </summary>

        [Fact]
        public void AceAce9_ShouldBe21()
        {
            LinkedList<Card> hand = new LinkedList<Card>();
            hand.AddLast(new Card("Hearts", "Ace"));
            hand.AddLast(new Card("Diamonds", "Ace"));
            hand.AddLast(new Card("Clubs", "9"));
            DeckTotaller totaller = new DeckTotaller();
            Assert.Equal(21, totaller.TotalScore(hand.ToList()));
        }
        /// <summary>
        /// Test for two Aces and a 10, which should be counted as 12.
        /// </summary>
        [Fact]
        public void AceAce10_ShouldBe12()
        {
            LinkedList<Card> hand = new LinkedList<Card>();
            hand.AddLast(new Card("Hearts", "Ace"));
            hand.AddLast(new Card("Diamonds", "Ace"));
            hand.AddLast(new Card("Clubs", "10"));
            DeckTotaller totaller = new DeckTotaller();
            Assert.Equal(12, totaller.TotalScore(hand.ToList()));
        }
        /// <summary>
        /// Test for a hand with four Aces, which should be counted as 14.
        /// </summary>
        [Fact]
        public void FourAces_ShouldBe14()
        {
            LinkedList<Card> hand = new LinkedList<Card>();
            hand.AddLast(new Card("Hearts", "Ace"));
            hand.AddLast(new Card("Diamonds", "Ace"));
            hand.AddLast(new Card("Spades", "Ace"));
            hand.AddLast(new Card("Clubs", "Ace"));

            DeckTotaller totaller = new DeckTotaller();
            Assert.Equal(14, totaller.TotalScore(hand.ToList()));
        }

        /// <summary>
        /// Test for a hand with three 10s, which should be counted as 30 (bust).
        /// </summary>
        [Fact]
        public void TenTenTen_ShouldBeBustAnd30()
        {
            LinkedList<Card> hand = new LinkedList<Card>();
            hand.AddLast(new Card("Hearts", "10"));
            hand.AddLast(new Card("Diamonds", "10"));
            hand.AddLast(new Card("Clubs", "10"));
            DeckTotaller totaller = new DeckTotaller();
            Assert.Equal(30, totaller.TotalScore(hand.ToList()));
        }


        /// <summary>
        /// Empty hand should return a score of 0.
        /// </summary>
        [Fact]
        public void EmptyHand()
        {
            LinkedList<Card> hand = new LinkedList<Card>();
            DeckTotaller totaller = new DeckTotaller();
            Assert.Equal(0, totaller.TotalScore(hand.ToList()));
        }
        /// <summary>
        /// Large hand with multiple cards should return the correct total score.
        /// </summary>
        [Fact]
        public void LargeHand()
        {
            LinkedList<Card> hand = new LinkedList<Card>();
            hand.AddLast(new Card("Hearts", "2"));
            hand.AddLast(new Card("Diamonds", "2"));
            hand.AddLast(new Card("Clubs", "2"));
            hand.AddLast(new Card("Spades", "2"));
            hand.AddLast(new Card("Hearts", "3"));
            hand.AddLast(new Card("Diamonds", "3"));
            hand.AddLast(new Card("Clubs", "3"));
            hand.AddLast(new Card("Spades", "3"));

            DeckTotaller totaller = new DeckTotaller();
            Assert.Equal(20, totaller.TotalScore(hand.ToList()));
        }

        /// <summary>
        /// Larger hand with multiple cards should return the correct total score.
        /// </summary>
        [Fact]
        public void LargerHand()
        {
            LinkedList<Card> hand = new LinkedList<Card>();
            hand.AddLast(new Card("Hearts", "2"));
            hand.AddLast(new Card("Diamonds", "2"));
            hand.AddLast(new Card("Clubs", "2"));
            hand.AddLast(new Card("Spades", "2"));
            hand.AddLast(new Card("Hearts", "3"));
            hand.AddLast(new Card("Diamonds", "3"));
            hand.AddLast(new Card("Clubs", "3"));
            hand.AddLast(new Card("Spades", "3"));
            hand.AddLast(new Card("Hearts", "4"));
            hand.AddLast(new Card("Diamonds", "4"));
            hand.AddLast(new Card("Clubs", "4"));
            hand.AddLast(new Card("Spades", "4"));

            DeckTotaller totaller = new DeckTotaller();
            Assert.Equal(36, totaller.TotalScore(hand.ToList()));
        }


        /// <summary>
        /// Test for a hand with three face card, which should be counted as 30 (bust).
        /// </summary>
        [Fact]
        public void JackQueenKing_ShouldBeBustAnd30()
        {
            LinkedList<Card> hand = new LinkedList<Card>();
            hand.AddLast(new Card("Hearts", "Jack"));
            hand.AddLast(new Card("Diamonds", "King"));
            hand.AddLast(new Card("Clubs", "Queen"));
            DeckTotaller totaller = new DeckTotaller();
            Assert.Equal(30, totaller.TotalScore(hand.ToList()));
        }


    }
}