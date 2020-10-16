using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardLibrary
{
    public class Deck
    {
        private Card[] cards;
        private int deckSize;
        private Card trumpCard = new Card();
        public int DeckSize
        {
            get
            {
                return deckSize;
            }
        }

        public Deck()
        {
            deckSize = 52;
            cards = new Card[deckSize];
            for(int suitVal = 0; suitVal < 4; suitVal++)
            {
                for(int rankVal = 2; rankVal <= 14; rankVal++)
                {
                    cards[suitVal * 13 + rankVal - 2] = new Card((Suit)suitVal, (Rank)rankVal);
                }
            }
        }

        public Deck(int numCards)
        {
            int minRank = 0;
            if(numCards == 52)
            {
                minRank = 2;
            }
            else if(numCards == 36)
            {
                minRank = 6;
            }
            else if(numCards == 20)
            {
                minRank = 10;
            }
            else
            {
                throw new ArgumentOutOfRangeException("numcards", 
                        "You cannot create a deck with " + numCards + " cards.");
            }

            deckSize = numCards;
            cards = new Card[numCards];
            for (int suitVal = 0; suitVal < 4; suitVal++)
            {
                for (int rankVal = minRank; rankVal <= 14; rankVal++)
                {
                    cards[(suitVal * (numCards/4)) + rankVal-(15-(numCards/4))] = new Card((Suit)suitVal, (Rank)rankVal);
                }
            }

        }

        /// <summary>
        /// Return a card and remove it from the deck
        /// </summary>
        /// <param name="cardNum"></param>
        /// <returns></returns>
        public Card DrawCard(int cardNum)
        {
            
            if (cardNum >= 0 && cardNum <= (deckSize - 1))
                try
                {
                    deckSize--;
                    List<Card> tempDeck = new List<Card>(cards);
                    Card returnCard = tempDeck[cardNum];
                    tempDeck.RemoveAt(cardNum);
                    cards = tempDeck.ToArray();
                    return returnCard;
                }
                catch (Exception e)
                {
                    return null;
                }
            else
                throw (new System.ArgumentOutOfRangeException("cardNum", cardNum, "Value must be between 0 and " + (deckSize-1)));
        }


        public Card getTrump()
        {
            //draw top card for trump
            Card trumpCard = this.DrawCard(0);
            //move trump card to bottom of deck
            List<Card> tempDeck = new List<Card>(cards);
            tempDeck.Add(trumpCard);
            deckSize++;
            cards = tempDeck.ToArray();
            //return trump card
            return trumpCard;
        }

        

        public void Shuffle()
        {
            Card[] newDeck = new Card[deckSize];
            bool[] assigned = new bool[deckSize];
            Random sourceGen = new Random();
            for(int i = 0; i<deckSize; i++)
            {
                int destCard = 0;
                bool foundCard = false;
                while(foundCard == false)
                {
                    destCard = sourceGen.Next(deckSize);
                    if (assigned[destCard] == false)
                        foundCard = true;
                }
                assigned[destCard] = true;
                newDeck[destCard] = cards[i];
            }
            newDeck.CopyTo(cards, 0);
        }

        public string deckstatus()
        {
            string x = "";
            for (int i = 0; i < cards.Length; i++)
            {
                x += cards[i].ToString() + "\n";
            }
            return x;
        }
    }
}