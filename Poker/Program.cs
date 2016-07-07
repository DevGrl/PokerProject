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
            Card[] hand = new Card[2];
            hand[0] = new Card(Rank.Ace, Suit.Club);
            hand[1] = new Card(Rank.Four, Suit.Diamond);

            Console.Read();
            
        }

        
    }
}
