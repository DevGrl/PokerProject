using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public enum HandType
    {
        HighCard,
        Pair,
        TwoPair,
        ThreeOfAKind,
        Straight, //5 consecutive numbers
        Flush, //all same suit, rank doesn't matter
        FullHouse, //2 of a kind, 3 of a kind
        FourOfAKind,
        StraightFlush //Same suit, 5 consecutive numbers
    }

    public enum Suit
    { 
        Club,
        Diamond,
        Heart,
        Spade
    }

    public enum Rank
    {
        Ace,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Eleven,
        Jack,
        Queen,
        King
    }

    public class Card: IComparable<Card> 
    {
        public Rank Rank { get; set; }
        public Suit Suit { get; set; }

        public Card(Rank rank, Suit suit)
        {
            this.Rank = rank;
            this.Suit = suit;
        }

        /* static void Play()
        {
            //Get one set of cards
            //Get another set of cards
            //get hand tpe for each
            //if different, declare winner
            //else do ie break and declare winner
        }
        //public static string[] GetCardsFromConsole()
        //{
        //    //Will need to add error checking to ensure 5 cards were input
        //    //Eventually create a deck of cards and give the user 5 instead of taking input

        //    Console.WriteLine("Type 5 cards in the form 2C 5H KS ...");
        //    string input = Console.ReadLine();
        //    string[] cards = input.Split(' ');
        //    return cards;
        //}

        static HandType WhatKindOfHandIsIt(string[] card)
        {
            //if (IsStraightFlush(card))
                return HandType.StraightFlush;
        }*/

        public int CompareTo(Card other)
        {
            //1 = first element greater
            //0 = elements are equal
            //-1 = first element smaller
            //Flush - all same suit
            if (this.Rank > other.Rank) { return 1; }
            if (this.Rank == other.Rank) { return 0; }
            if (this.Rank < other.Rank) { return -1; }

            return 0;
            //throw new NotImplementedException();
        }
        
        public static bool IsFlush(Card[] hand)
        {
            //All cards are same suit
            for (int i = 0; i < hand.Length - 1;)
            {
                if (hand[i].Suit == hand[i + 1].Suit) i++;
                else return false;
            }
            return true;
        }

        public static bool IsStraight(Card[] hand)
        {             
            return CheckStraight(hand);           
        }

        public static bool IsStraightFlush(Card[] hand)
        {
            bool result = CheckStraight(hand) ? IsFlush(hand) : false;
            return result;
        }

        public static bool CheckStraight(Card[] hand)
        {
            //Cards are in sequential order
            for (int i = 0; i < hand.Length - 1;)
            {
                if (hand[i].Rank + 1 == hand[i + 1].Rank) i++;
                else return false;
            }

            return true;
        }

        public static void OfAKind(Card[] hand, out Rank mainRank, out Rank secondaryRank)
        {
            Dictionary<Rank, int> cardNumbers = new Dictionary<Rank, int>();
            
            for (int i = 0; i <= hand.Length-1; i++)
            {
                if (cardNumbers.ContainsKey(hand[i].Rank))
                {
                    cardNumbers[hand[i].Rank] += 1;
                }
                else
                {
                    cardNumbers.Add(hand[i].Rank, 1);
                }
            }

            //if max value = 3 and cardNumbers contains value = 2, then FullHouse
            //if max value = 3, then 3 of a kind
            //if max value = 4, then 4 of a kind
            //if max value = 2, a pair
            //default is high card

            //Get the two largest values from cardNumbers
            int maxValue = cardNumbers.Values.Max();                        
            Rank mRank, sRank = new Rank();
            HandType type = new HandType();
            mRank = cardNumbers.FirstOrDefault(x => x.Value == maxValue).Key;

            switch (maxValue)
            {
                case 2:
                    type = HandType.Pair;
                    break;
                case 3:
                    if(cardNumbers.ContainsValue(2))
                    {
                         type = HandType.FullHouse;
                         sRank = cardNumbers.FirstOrDefault(x => x.Value == 2).Key;
                    }
                    else
                    {
                        type = HandType.ThreeOfAKind;
                    }                    
                    break;
                case 4:
                    type = HandType.FourOfAKind;
                    break;
                default:
                    type = HandType.HighCard;
                    //High cards is the card where the enum value of the Rank is highest
                    //or get the value of the last card in the hand
                     //mRank = Enum.GetValues(typeof(Rank)).Cast<Rank>().Max();
                    mRank = hand[hand.Length - 1].Rank;
                    break;
            }//end switch

            mainRank = mRank;
            secondaryRank = sRank;
            if (type == HandType.FullHouse)
            {
                Console.WriteLine("You have a {0} of (3){1} and (2){2}", type, mRank, sRank);
            }
            else
            {
                Console.WriteLine("You have a {0} of {1}", type, mRank);
            }
            
        }

        }
}
