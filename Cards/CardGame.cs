using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards
{
    public enum HandRank {HighCard, OnePair, TwoPairs, ThreeOfTheKind, Straight, Flush, FullHouse, FourOfAKind, StraightFlush, RoyalFlush}
   // public enum 
    class PokerPlayer
    {  
        public List<Card> Cards { get; set; }
        public string Name { get; set; }
        public HandRank HandRank { get; set; }
        public Rank HighRank { get; set; }
        public Suit CardSuit { get; set; }

        public string OutPut { get; set; }

        public PokerPlayer(string Name)
        {
            this.Name = Name;
            Cards = new List<Card>();
        }

        public void ShowHand()
        {
            GetHandRank();
            string st = "";
            foreach (var item in Cards)
            {
                st += item.Rank + " " + item.Suit + "   ";
            }
            st += "\n" + OutPut;
            Console.WriteLine(st);
        }

        public HandRank GetHandRank()
        {

            HighRank = HighCard(); 

            if (HasRoyalFlush())
                { HandRank = HandRank.RoyalFlush;
                CardSuit = Cards[0].Suit;
                OutPut = "Royal Flush" + " of " + CardSuit;
                }
            else if (HasStraightFlush())
                {
                    HandRank = HandRank.StraightFlush;
                    CardSuit = Cards[0].Suit;
                    OutPut = "Straight Flush" + " of " + CardSuit;
                }
            else if (HasFourOfAKind())
                {
                    HandRank = HandRank.FourOfAKind;
                    var value = Cards.Select(x => x.Rank).GroupBy(x => x).Where(x=> x.Count()==4).ToList().First().Key;
                    OutPut = "Four" + " of a " + value;
                   
                }
            else if (HasFullHouse())
                {
                    HandRank = HandRank.FullHouse;
                    var value = Cards.Select(x => x.Rank).GroupBy(x => x).ToList().First().Key;
                    OutPut = "Full House: " + " of " + value;
                    value = Cards.Select(x => x.Rank).GroupBy(x => x).ToList().Last().Key;
                    OutPut += " and " + value;
                }
            else if (HasFlush())
                {
                    HandRank = HandRank.Flush;
                    CardSuit = Cards[0].Suit;
                    OutPut = "Flush" + " of " + CardSuit;
                }
            else if (HasStraight())
                {
                    HandRank = HandRank.Straight;
                    CardSuit = Cards[0].Suit;
                    OutPut = "Straight from " + Cards.OrderBy(x => x.Rank).First().Rank + " to " + Cards.OrderBy(x => x.Rank).Last().Rank;
                }
            else if (HasThreeOFAKind())
                {
                    HandRank = HandRank.ThreeOfTheKind;
                    var value = Cards.Select(x => x.Rank).GroupBy(x => x).Where(x => x.Count() == 3).ToList().First().Key;
                    OutPut = "Free" + " of a " + value;
                }
            else if (HasTwoPairs())
                {
                    HandRank = HandRank.TwoPairs;
                    var value = Cards.Select(x => x.Rank).GroupBy(x => x).Where(x => x.Count() == 2).ToList().First().Key;
                    OutPut = "Two Pairs" + " of " + value;
                    value = Cards.Select(x => x.Rank).GroupBy(x => x).Where(x => x.Count() == 2).ToList().Last().Key;
                    OutPut += " and " + value;
                }
            else if (HasOnePair())
                {
                    HandRank = HandRank.OnePair;
                    var value = Cards.Select(x => x.Rank).GroupBy(x => x).Where(x => x.Count() == 2).ToList().First().Key;
                    OutPut = "One Pair" + " of " + value;
                }
            else
                {   
                    HandRank = HandRank.HighCard;
                    OutPut = "High card " + HighRank;
                }
            return HandRank;
        }

        public bool HasFlush()
        {
            return this.Cards.Select(x => x.Suit).Distinct().Count() == 1;
        }

        public bool HasOnePair()
        {
            return this.Cards.Select(x => x.Rank).Distinct().Count() == 4;
        }

        public bool HasTwoPairs()
        {
            var sel = Cards.Select(x => x.Rank).GroupBy(x => x).Where(x => x.Count() == 2).ToList().Count == 2;
            return sel;
        }

        public bool HasThreeOFAKind()
        {
             var sel = Cards.Select(x => x.Rank).GroupBy(x=> x).Where(x => x.Count()==3).ToList().Count == 1;
             return sel;
        }

        public bool HasStraight()
        {
            bool _value = false;
            var value = Cards.Select(x => x.Rank).OrderBy(x => x).Distinct().ToList();
            if (value.Count == 5)
            {
                int lowInd = (int)value[0];
                int highInd = (int)value[4];
                if (highInd - lowInd == 4) _value = true;
            }
            return _value;
        }

        public bool HasFullHouse()
        {
            bool value = false;
            if (Cards.GroupBy(x => x.Rank).Where(x => x.Count() == 2).Any() &&
                Cards.GroupBy(x => x.Rank).Where(x => x.Count() == 3).Any())
                    {
                        value = true;
                    }
            return value;
        }

        public bool HasFourOfAKind()
        {
            bool value = false;
            if (Cards.GroupBy(x => x.Rank).Where(x => x.Count() == 1).Any() &&
               Cards.GroupBy(x => x.Rank).Where(x => x.Count() == 4).Any())
            {
                value = true;
            }
            return value;
        }

        public Rank HighCard()
        {
            return Cards.Select(x => x.Rank).Distinct().OrderBy(x => x).Last();
        }

        public bool HasStraightFlush()
        {
            if (HasFlush() && HasStraight()) return true;
            else return false;
        }

        public bool HasRoyalFlush()
        {
          if (HasStraight() && HighCard() == Rank.Ace) return true;
            else return false;
        }

    }

    class CardGame
    {
    }
}


// DEBUG TOOLS
//List<Card> Crd = new List<Card>();
//Crd.Add(new Card(Suit.Clubs, Rank.Ace));
//Crd.Add(new Card(Suit.Clubs, Rank.Ace));
//Crd.Add(new Card(Suit.Diamonds, Rank.Ace));
//Crd.Add(new Card(Suit.Diamonds, Rank.Five));
//Crd.Add(new Card(Suit.Spades, Rank.Five));
