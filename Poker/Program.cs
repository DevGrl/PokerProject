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
            Card[] hand = new Card[3];
            hand[0] = new Card(Rank.Five, Suit.Club);
            hand[1] = new Card(Rank.Five, Suit.Club);
            hand[2] = new Card(Rank.Five, Suit.Heart);

            Array.Sort(hand);

            foreach (var item in hand)
            {
                Console.WriteLine(item.Rank);
            }

            //Console.WriteLine("IsStraight: " + Card.IsStraight(hand));
            //Console.WriteLine("IsStraightFlush: " + Card.IsStraightFlush(hand));
            //Console.WriteLine("IsFlush: " + Card.IsFlush(hand));
            Console.WriteLine("OfAKind: " + Card.OfAKind(hand));
            

            Console.Read();

        }
        
    }
}
