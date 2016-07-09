using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    class Program
    {
        
        static void Main(string[] args)
        {
            GetCards();            
        }

        static void GetCards()
        {
            Card[] hand = new Card[5];
            hand[0] = new Card(Rank.Five, Suit.Spade);
            hand[1] = new Card(Rank.Seven, Suit.Club);
            hand[2] = new Card(Rank.Two, Suit.Heart);
            hand[3] = new Card(Rank.Three, Suit.Heart);
            hand[4] = new Card(Rank.Ace, Suit.Spade);

            Array.Sort(hand);            
            Rank mainRank, secondaryRank;
            Card.OfAKind(hand, out mainRank, out secondaryRank);
            Console.Read();

        }
        
    }
}
