using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    enum HandType
    {
        HighCard,
        Pair,
        TwoPair,
        ThreeOfAKind,
        Straight, //5 consecutive numbers
        Flush, //all same suit
        FullHouse, //2 of a kind, 3 of a kind
        FourOfAKind,
        StraightFlush //Same suit, straight
    }

    enum Suit
    { 
        Club,
        Diamond,
        Heart,
        Spade
    }

    enum Rank
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
        public Rank Rank { get;
            set; }
        public Suit Suit { get; set; }

        public Card(Rank rank, Suit suit)
        {
            rank = this.Rank;
            suit = this.Suit;
        }



        static void Play()
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
        }

        public int CompareTo(Card other)
        {
            throw new NotImplementedException();
        }
    }
}
