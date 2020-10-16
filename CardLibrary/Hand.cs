using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardLibrary
{
    public class Hand
    {
        private Card[] cards;
        private int handSize;
        public int HandSize
        {
            get
            {
                return handSize;
            }
        }

        public Hand(Card[] handCards)
        {
            handSize = handCards.Length;
            cards = handCards;
        }
        
        public Hand()
        {
            handSize = 0;
        }
        
        public void orderCards(Suit trump)
        {
            //order by rank
            for(int i = cards.Length-1; i>=0; i--)
            {
                for(int j = 0; j <i; j++)
                {
                    if(cards[j].rank > cards[j+1].rank)
                    {
                        Card tempCard = cards[j];
                        cards[j] = cards[j+1];
                        cards[j+1] = tempCard;
                    }
                }
            }
            //order trumps
            for (int i = cards.Length - 1; i >= 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (cards[j].suit == trump && cards[j+1].suit != trump)
                    {
                        Card tempCard = cards[j];
                        cards[j] = cards[j + 1];
                        cards[j + 1] = tempCard;
                    }
                }
            }
        }

        public Card GetCard(int cardNum)
        {
            if (cardNum >= 0 && cardNum <= (handSize - 1))
                return cards[cardNum];
            else
                throw (new System.ArgumentOutOfRangeException("cardNum", cardNum, "Value must be between 0 and " + (handSize - 1)));
        }

        public int GetCardNo(Card cardToGet)
        {
            int cardno = -1;
            for(int i = 0; i<handSize; i++)
            {
                if(cards[i] == cardToGet)
                {
                    cardno = i;
                }
                
            }
            if (cardno != -1)
            {
                return cardno;
            }
            else
                throw new Exception();
        }

        //pick up one card
        public void PickUp(Card card)
        {
            //add card to hand
            List<Card> tempHand = new List<Card>();
            if (cards != null)
            {
                tempHand = new List<Card>(cards);
            }
            tempHand.Add(card);
            cards = tempHand.ToArray();
            handSize++;
        }

        //pick up an array of cards
        public void PickUp(Card[] card)
        {
            //add cards to hand
            List<Card> tempHand = new List<Card>(cards);
            for (int i = 0; i < card.Length; i++)
            {
                tempHand.Add(card[i]);
            }
            cards = tempHand.ToArray();
            handSize = cards.Length;
        }

        //pick up a Hand
        public void PickUp(Hand hand)
        {
            //add cards to hand
            List<Card> tempHand = new List<Card>(cards);
            for (int i = 0; i < hand.HandSize; i++)
            {
                tempHand.Add(hand.GetCard(i));
            }
            cards = tempHand.ToArray();
            handSize = cards.Length;
        }

        public Card PlayCard(int cardNum)
        {
            if (cardNum >= 0 && cardNum <= (handSize - 1))
                try
                {
                    handSize--;
                    List<Card> tempHand = new List<Card>(cards);
                    Card returnCard = tempHand[cardNum];
                    tempHand.RemoveAt(cardNum);
                    cards = tempHand.ToArray();
                    return returnCard;
                }
                catch (Exception e)
                {
                    return null;
                }
            else
                throw (new System.ArgumentOutOfRangeException("cardNum", cardNum, "Value must be between 0 and " + (handSize - 1)));
        }


        override public string ToString()
        {
            string handString = "";

            for(int i = 0; i<handSize; i++)
            {
                handString += cards[i].ToString() + "\n";
            }
            return handString;
        }

        public void FlipHand()
        {
            for(int i = 0; i<handSize; i++)
            {
                this.GetCard(i).FaceUp = false;
            }
        }
    }
}
