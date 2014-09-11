using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards
{
    public enum Rank {Two, Three, Four, Five, Six, Seven, Eigth, Nine, Ten, Jack, Queen, King, Ace}
    public enum Suit { Hearts, Clubs, Spades, Diamonds}
    class Card
    {
        public Suit Suit { get; set; }
        public Rank Rank { get; set; }
        public Card(Suit suit, Rank rank)
        {
            this.Rank = rank;
            this.Suit = suit;
        }
    }

    class Deck
    {
        public List<Card> Cards { get; set; }

        public Deck()
        {
            this.Cards = new List<Card>();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    Card card = new Card((Suit)i, (Rank)j);
                    this.Cards.Add(card);
                }
            }
        
        }
        public void Shuffle()
        {
            Random rnd = new Random();
            List<Card> newlist = new List<Card>();
            for (int i = 0; i < 52; i++)
            {
                int r = rnd.Next(0, Cards.Count);
                newlist.Add(Cards[r]);
                Cards.Remove(Cards[r]);
            }
            Cards = newlist;
        }
        public List<Card> Deal (int numOfCards)
        {
            List<Card> myCards = new List<Card>();
            for (int i = 0; i < numOfCards; i++)
            {
                myCards.Add(Cards[0]);
                Cards.Remove(Cards[0]);
            }
            return myCards;
        }
        public Card TakeOneCard()
        {
            Card myCard = Cards[0];
            Cards.Remove(Cards[0]);
            return myCard;
        }
    }
}
