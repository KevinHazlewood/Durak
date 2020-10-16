using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using CardLibrary;

namespace CardLibrary
{
    public class Card : ICloneable
    {
        public readonly Rank rank;
        public readonly Suit suit;

        public static Suit trump = Suit.clubs;
        public Card()
        {
        }

        public Card(Suit newSuit, Rank newRank)
        {
            suit = newSuit;
            rank = newRank;
        }

        public override String ToString()
        {
            return "The " + rank + " of " + suit;
        }

        public Suit getSuit()
        {
            return suit;
        }
        public Rank getRank()
        {
            return rank;
        }
        public object Clone()
        {
            return MemberwiseClone();
        }

        private bool faceUp = true;
        public bool FaceUp
        {
            get { return faceUp; }
            set { faceUp = value; }

        }

    }

}