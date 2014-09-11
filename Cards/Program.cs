using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();
            deck.Shuffle();
            PokerPlayer pp = new PokerPlayer("New");
           // pp.Cards = deck.Deal(5);

            List<Card> Crd = new List<Card>();
            Crd.Add(new Card(Suit.Clubs, Rank.Seven));
            Crd.Add(new Card(Suit.Diamonds, Rank.Five));
            Crd.Add(new Card(Suit.Hearts, Rank.Queen));
            Crd.Add(new Card(Suit.Clubs, Rank.Ace));
            Crd.Add(new Card(Suit.Diamonds, Rank.Ten));
            pp.Cards = Crd;

            pp.GetHandRank();
            pp.ShowHand();
            Console.ReadLine();

        }
    }
}
