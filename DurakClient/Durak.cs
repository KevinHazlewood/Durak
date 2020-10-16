/*
    Name:       Kevin Hazlewood, Riyaz Nausath
    Due Date:   April 18 2019
    File:       Durak.cs
    Description: 
    This is the form class for our game of Durak. This class handles all of
    the methods and event handlers used within our game to control gameplay logic
    and user controls. This class implements the CardLibrary library to use its
    card-related classes and enumerations.

    Sources:
 
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq; 
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CardLibrary;

namespace DurakClient
{
    public partial class frmDurak : Form
    {
        
        public frmDurak()
        {
            InitializeComponent();
        }

        private const int POP = 25;
        static private Size regulareSize = new Size(71, 96);
        
        //Initialize all form-level variables and objects
        Deck gameDeck = new Deck();
        static int DECKSIZE = 36;
        static int HANDSIZE = 6;
        int remainingCards = DECKSIZE;
        static Card[] firstHand = new Card[HANDSIZE];
        static Card[] secondHand = new Card[HANDSIZE];
        static Card[] trumpHand = new Card[1];
        static bool[] isAttacking = new bool[2];
        static bool[] isDefending = new bool[2];
        int attackNum = 0;
        Hand handOne;
        Hand handTwo;
        Suit trump;
        Hand playedCards = new Hand();
        Card lastAttack = new Card();

        /// <summary>
        ///     Button click method for game start/reset button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            //clear out all controls
            pnlDeck.Controls.Clear();
            pnlPlayer1.Controls.Clear();
            pnlPlayer2.Controls.Clear();
            pnlPlay.Controls.Clear();
            pnlTrumpCard.Controls.Clear();
            ResetGame();    //reset game
            lblGameplay.Visible = true; //show gameplay narrative label

            //initialize and shuffle deck
            gameDeck = new Deck(DECKSIZE);
            gameDeck.Shuffle();

            //draw cards in first hand
            for (int i = 0; i < HANDSIZE; i++)
            {
                firstHand[i] = gameDeck.DrawCard(0);
                remainingCards--;
            }
            //draw cards for second hand
            for (int i = 0; i < HANDSIZE; i++)
            {
                secondHand[i] = gameDeck.DrawCard(0);
                remainingCards--;
            }

            //check which player attacks first
            handOne = new Hand(firstHand); //cpu hand
            handTwo = new Hand(secondHand); //player hand
            handOne.FlipHand();//flip over cpu hand

            //get trump cards
            trumpHand[0] = gameDeck.getTrump();
            trump = trumpHand[0].suit;
            //order the two hands
            handOne.orderCards(trump);
            handTwo.orderCards(trump);

            //Determine who goes first (player with lowest trump)
            //Put player who goes first into playerOne, second into playerTwo
            //Compare suits, then values of highest cards in sorted hands
            if (handOne.GetCard(HANDSIZE - 1).suit == trump && handTwo.GetCard(HANDSIZE - 1).suit != trump)
            {//first hand has trump, second hand does not
                isAttacking[0] = true;
                isDefending[0] = false;     //
                isAttacking[1] = false;     //initialize attack/defense flags
                isDefending[1] = true;      //
                lblAttacker.Text = "CPU is Attacking";
                btnEndTurn1.Enabled = false;
                btnPickUp.Enabled = true;
            }
            else if (handTwo.GetCard(HANDSIZE - 1).suit == trump && handOne.GetCard(HANDSIZE - 1).suit != trump)
            {//second hand has trump, first hand does not
                isAttacking[1] = true;
                isDefending[1] = false;     //
                isAttacking[0] = false;     //initialize attack/defense flags
                isDefending[0] = true;      //
                lblAttacker.Text = "You are Attacking";
                btnPickUp.Enabled = false;
            }
            else
            {//both have trump or neither have trump, compare cards
                if (handOne.GetCard(HANDSIZE - 1).rank < handTwo.GetCard(HANDSIZE - 1).rank)
                {//player one has high card
                    isAttacking[0] = true;
                    isDefending[0] = false;     //
                    isAttacking[1] = false;     //initialize attack/defense flags
                    isDefending[1] = true;      //
                    lblAttacker.Text = "CPU is Attacking";
                    btnEndTurn1.Enabled = false;
                    btnPickUp.Enabled = true;
                }
                else
                {//player two has high card
                    isAttacking[1] = true;
                    isDefending[1] = false;     //
                    isAttacking[0] = false;     //initialize attack/defense flags
                    isDefending[0] = true;      //
                    btnEndTurn1.Enabled = true;
                    btnPickUp.Enabled = false;
                    lblAttacker.Text = "You are Attacking";
                }
            }

            //display cards on boards
            ShowCards();
            //shows how many cards are left in the deck
            lblRemainingCounter.Text = remainingCards.ToString();
            
            PlayTurn();//begin first turn
        }

        /// <summary>
        ///     Method to play the CPU's move
        /// </summary>
        public void PlayTurn()
        {
            attackNum=1;    //set attack num
            if (isAttacking[0] == true)//Fire off first move if ai goes first
            {
                //ai attacker logic
                CardBox mycardControl = new CardBox();
                //choose card and play it, and display it
                Card played = handOne.GetCard(AIMakeAttack(handOne, attackNum, playedCards, trump));
                played.FaceUp = true;
                mycardControl.Card = played;
                pnlPlay.Controls.Add(mycardControl);
                
                handOne.PlayCard(AIMakeAttack(handOne, attackNum, playedCards, trump));
                ShowCards();

                lastAttack = played;    //set attack card

                RealignCards(pnlPlay);
            }
        }

        /// <summary>
        /// Reset game method
        /// </summary>
        public void ResetGame()
        {
            pnlDeck.Controls.Clear();
            pnlPlayer1.Controls.Clear();        //
            pnlPlayer2.Controls.Clear();        //reset controls
            pnlTrumpCard.Controls.Clear();      //
            //reset hands and deck
            gameDeck = new Deck(DECKSIZE);
            Card[] firstHand = new Card[HANDSIZE];
            Card[] secondHand = new Card[HANDSIZE];
            playedCards = new Hand();
            gameDeck.Shuffle();

            remainingCards = DECKSIZE;
            lblDiscardCounter.Text = "";
            lblRemainingCounter.Text = remainingCards.ToString();
            lblAttacker.Text = "";
        }

        /// <summary>
        /// Show cards method
        /// </summary>
        public void ShowCards()
        {//call all show card methods
            ShowTrumpCard();
            ShowPlayer1Cards();
            ShowPlayer2Cards();
            ShowDeckCard();
        }

        /// <summary>
        /// Show the card for the deck
        /// </summary>
        private void ShowDeckCard()
        {
            pnlDeck.Controls.Clear();
            CardBox mycardControl = new CardBox();
            pnlDeck.Controls.Add(mycardControl);
        }

        /// <summary>
        /// show player 1's cards
        /// </summary>
        public void ShowPlayer1Cards()
        {
            pnlPlayer1.Controls.Clear();

            Card card = new Card();
            for (int i = 0; i < handOne.HandSize; i++)
            {
                card = handOne.GetCard(i);
                CardBox myCardControl = new CardBox();
                myCardControl.Card = card;
                pnlPlayer1.Controls.Add(myCardControl);
                
            }
            RealignCards(pnlPlayer1);

        }

        /// <summary>
        /// show player 2's cards
        /// </summary>
        public void ShowPlayer2Cards()
        {
            pnlPlayer2.Controls.Clear();

            Card card = new Card();
            for (int i = 0; i < handTwo.HandSize; i++)
            {
                card = handTwo.GetCard(i);
                CardBox myCardControl = new CardBox(card);
                myCardControl.CardClicked += CardBox_Click;
                
                pnlPlayer2.Controls.Add(myCardControl);
                
            }
            RealignCards(pnlPlayer2);
        }

        /// <summary>
        /// show the trump card
        /// </summary>
        public void ShowTrumpCard()
        {
            pnlTrumpCard.Controls.Clear();


            Card trumpCard = new Card();
            trumpCard = trumpHand[0];
            CardBox myCardControl = new CardBox();
            myCardControl.Card = trumpCard;
            pnlTrumpCard.Controls.Add(myCardControl);

        }

        /// <summary>
        /// Realign the cards in a panel
        /// </summary>
        /// <param name="panelHand"></param>
        private void RealignCards(Panel panelHand)
        {
            // Determine the number of cards/controls in the panel.
            int myCount = panelHand.Controls.Count;

            // If there are any cards in the panel
            if (myCount > 0)
            {
                // Determine how wide one card/control is.
                int cardWidth = panelHand.Controls[0].Width;
                // Determine where the left-hand edge of a card/control placed 
                // in the middle of the panel should be  
                int startPoint = (panelHand.Width - cardWidth) / 2;
                // An offset for the remaining cards
                int offset = 0;
                // If there are more than one cards/controls in the panel
                if (myCount > 1)
                {
                    // Determine what the offset should be for each card based on the 
                    // space available and the number of card/controls
                    offset = (panelHand.Width - cardWidth - 2 * POP) / (myCount - 1);
                    // If the offset is bigger than the card/control width, i.e. there is lots of room, 
                    // set the offset to the card width. The cards/controls will not overlap at all.
                    if (offset > cardWidth)
                        offset = cardWidth;


                    // Determine width of all the cards/controls 
                    int allCardsWidth = (myCount - 1) * offset + cardWidth;
                    // Set the start point to where the left-hand edge of the "first" card should be.
                    startPoint = (panelHand.Width - allCardsWidth) / 2;

                }

                // Align the "first" card (which is the last control in the collection)
                panelHand.Controls[myCount - 1].Top = POP;
                System.Diagnostics.Debug.Write(panelHand.Controls[myCount - 1].Top.ToString() + "\n");
                panelHand.Controls[myCount - 1].Left = startPoint;
                // for each of the remaining controls, in reverse order.
                for (int index = myCount - 2; index >= 0; index--)
                {
                    // Align the current card
                    panelHand.Controls[index].Top = POP;
                    panelHand.Controls[index].Left = panelHand.Controls[index + 1].Left + offset;

                }
            }
        }

        /// <summary>
        /// Button to set deck to 52 cards
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn52Deck_Click(object sender, EventArgs e)
        {
            DECKSIZE = 52;
            gameDeck = new Deck(DECKSIZE);
            ResetGame();
        }

        /// <summary>
        /// Button to set deck to 20 cards
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn20Deck_Click(object sender, EventArgs e)
        {
            DECKSIZE = 20;
            gameDeck = new Deck(DECKSIZE);
            ResetGame();
        }

        /// <summary>
        /// Button to set deck to 36 cards
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn36Deck_Click(object sender, EventArgs e)
        {
            DECKSIZE = 36;
            gameDeck = new Deck(DECKSIZE);
            ResetGame();
        }

        /// <summary>
        /// Button to end turn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEndTurn1_Click(object sender, EventArgs e)
        {
            EndTurn(); //call end turn method
        }

        /// <summary>
        /// Pick up button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPickUp_Click(object sender, EventArgs e)
        {//call pick up method
            PickUpCards();
        }

        /// <summary>
        /// When a CardBox is clicked, move to the opposite panel.
        /// </summary>
        void CardBox_Click(object sender, EventArgs e)
        {
            // Convert sender to a CardBox
            CardBox aCarBox = sender as CardBox;
            
            // If the conversion worked
            if (aCarBox != null)
            {
                // if the card is in the player's hand panel...
                if (aCarBox.Parent == pnlPlayer2)
                {
                    lblError.Visible = false; //hide error label
                    if(isAttacking[1])//if player is attacking
                    {
                        if(validAttack(attackNum, handTwo.GetCard(handTwo.GetCardNo(aCarBox.Card)), playedCards))//validate attack attempt
                        {
                            pnlPlayer1.Controls.Remove(aCarBox);// Remove the card from the home panel
                            pnlPlay.Controls.Add(aCarBox); // Add the control to the play panel
                            attackNum++;    //increment attack num
                            btnEndTurn1.Enabled = true;//enable end turn button(only enabled after first attack)
                            lastAttack = handTwo.PlayCard(handTwo.GetCardNo(aCarBox.Card));//update last attack
                            playedCards.PickUp(lastAttack); //put attack into play hand

                            //check for game ended
                            if (handTwo.HandSize == 0 && remainingCards == 0)
                                GameOver();
                            //AI Defends
                            try
                            {
                                CardBox mycardControl = new CardBox();
                                Card played = handOne.GetCard(AIMakeDefense(handOne, lastAttack, trump)); //update card cpu plays
                                played.FaceUp = true; //flip card cpu plays
                                mycardControl.Card = played;    //update cardbox for image
                                pnlPlay.Controls.Add(mycardControl); //add image to play area

                                playedCards.PickUp(handOne.PlayCard(AIMakeDefense(handOne, lastAttack, trump))); //put played card into play hand

                                lblGameplay.Text = "The CPU has defended with " + played; //update gameplay narritive
                                ShowPlayer1Cards(); //update cpu's hand images
                                //check for game end
                                if (handOne.HandSize == 0 && remainingCards == 0)
                                    GameOver();
                            }
                            catch(Exception)
                            {//cpu does not have any valid moves
                                lblGameplay.Text = "The CPU could not defend and has drawn the cards. They will now attack.";
                                PickUpCards(); //cpu picks up played cards
                            }
                        }
                        else
                        {//cpu has no valid moves
                            //display error message
                            lblError.Visible = true;
                            lblError.Text = "You cannot attack with " + aCarBox.Card;
                            lblError.ForeColor = Color.Red;
                        }
                        
                    }
                    else if(isDefending[1])//player is defending
                    {
                        //validate defense from player
                        if(validDefense(lastAttack, handTwo.GetCard(handTwo.GetCardNo(aCarBox.Card)), trump))
                        {
                            pnlPlayer1.Controls.Remove(aCarBox);// Remove the card from the home panel
                            pnlPlay.Controls.Add(aCarBox); // Add the control to the play panel

                            //play card, add to playedCards
                            playedCards.PickUp(handTwo.PlayCard(handTwo.GetCardNo(aCarBox.Card)));
                            attackNum++;    //increment attack num
                            //check for game end
                            if (handTwo.HandSize == 0 && remainingCards == 0)
                                GameOver();

                            //AI Attacks
                            try
                            {
                                //find card used for attack, play it and display it
                                CardBox mycardControl = new CardBox();
                                Card played = handOne.GetCard(AIMakeAttack(handOne, attackNum, playedCards, trump));
                                played.FaceUp = true;
                                mycardControl.Card = played;
                                pnlPlay.Controls.Add(mycardControl);
                                lastAttack = played;

                                playedCards.PickUp(handOne.PlayCard(AIMakeAttack(handOne, attackNum, playedCards, trump)));
                                lblGameplay.Text = "The CPU has attacked with " + lastAttack+". You must now defend."; //update gameplay narrative
                                ShowPlayer1Cards();//show hand
                                //check for game end
                                if (handOne.HandSize == 0 && remainingCards == 0)
                                    GameOver();
                            }
                            catch (Exception)
                            {//cpu has no valid moves
                                lblGameplay.Text = "The CPU has ended their turn. It is now your turn to attack.";
                                EndTurn();
                            }
                        }
                        else
                        {//player's defense is invalid
                            //display error message
                            lblError.Visible = true;
                            lblError.Text = "You cannot defend with " + aCarBox.Card;
                            lblError.ForeColor = Color.Red;
                        }
                    }
                }
                // Realign the cards 
                RealignCards(pnlPlayer1);
                RealignCards(pnlPlay);
            }
        }

        //*************************************
        // SOME DURAK METHODS
        //*************************************
        /// <summary>
        /// //determine if defense is valid
        /// </summary>
        /// <param name="attack"></param>
        /// <param name="defense"></param>
        /// <param name="trump"></param>
        /// <returns></returns>
        static bool validDefense(Card attack, Card defense, Suit trump)
        {
            bool isValid = false;
            if (attack.suit == trump)
            {//if attack is trump
                if (defense.suit == trump && defense.rank > attack.rank)
                {//only valid if defense is also trump, and higher rank
                    isValid = true;
                }
            }
            else
            {//attack not trump
                if (defense.suit == trump || defense.rank > attack.rank && defense.suit == attack.suit)
                {//defense is trump, or is higher rank of same suit
                    isValid = true;
                }
            }
            return isValid;
        }

        /// <summary>
        /// //determine if attack is valid
        /// </summary>
        /// <param name="attackNum"></param>
        /// <param name="attack"></param>
        /// <param name="playedCards"></param>
        /// <returns></returns>
        static bool validAttack(int attackNum, Card attack, Hand playedCards)
        {
            bool isValid = false;
            if (attackNum == 1)
            {//if first attack, any is valid
                isValid = true;
            }
            else
            {//later attacks, validate attack
                for (int i = 0; i < playedCards.HandSize; i++)
                {
                    if (attack.rank == playedCards.GetCard(i).rank)
                    {
                        isValid = true;
                    }
                }
            }

            return isValid;//return whether attack is valid
        }

        /// <summary>
        /// //determines lowest valid defense card for AI, throws exception if no cards can be played
        /// </summary>
        /// <param name="AIHand"></param>
        /// <param name="attack"></param>
        /// <param name="trump"></param>
        /// <returns></returns>
        static int AIMakeDefense(Hand AIHand, Card attack, Suit trump)
        {
            int cardPos = 0;
            Card defenseCard = null;
            AIHand.orderCards(trump);    //ensure cards are ordered
            for (int i = AIHand.HandSize - 1; i >= 0; i--)//loop through hand, highest to lowest
            {
                if (validDefense(attack, AIHand.GetCard(i), trump))
                {//if card is valid, set it as defense
                    defenseCard = AIHand.GetCard(i);
                    cardPos = i;
                }
            }
            if (defenseCard != null)
            {//if card has been assigned
                return cardPos;
            }
            else
            {//else, no valid defense
                throw new Exception();
            }
        }

        /// <summary>
        /// //determines lowest valid attack card for AI, throws exception if no cards can be played
        /// </summary>
        /// <param name="AIHand"></param>
        /// <param name="attackNum"></param>
        /// <param name="playedCards"></param>
        /// <param name="trump"></param>
        /// <returns></returns>
        static int AIMakeAttack(Hand AIHand, int attackNum, Hand playedCards, Suit trump)
        {
            int cardPos = 0;
            Card attackCard = null;
            AIHand.orderCards(trump);    //ensure cards are ordered
            for (int i = AIHand.HandSize - 1; i >= 0; i--)//loop through hand, highest to lowest
            {
                if (validAttack(attackNum, AIHand.GetCard(i), playedCards))
                {//if card is valid attack, set it to attack card
                    attackCard = AIHand.GetCard(i);
                    cardPos = i;
                }
            }
            if (attackCard != null)//if attack card has been assigned
            {
                return cardPos;
            }
            else
            {//else, no valid attacks
                throw new Exception();
            }
        }

        /// <summary>
        /// End the current attacker's turn
        /// </summary>
        public void EndTurn()
        {
            while (handOne.HandSize < HANDSIZE || handTwo.HandSize < HANDSIZE)
            {//loop through hands, filling them up until they are full or deck is empty
                if(remainingCards > 0 && handOne.HandSize < HANDSIZE)
                {//if hand isn't full, draw a card
                    handOne.PickUp(gameDeck.DrawCard(0));
                    remainingCards--;
                }
                if (remainingCards > 0 && handTwo.HandSize < HANDSIZE)
                {//if hand isn't full, draw a card
                    handTwo.PickUp(gameDeck.DrawCard(0));
                    remainingCards--;
                }
                if (remainingCards == 0)//break if there are no cards in the deck to draw
                    break;
            }
            //order the hands, flip cpu's
            handOne.orderCards(trump);
            handTwo.orderCards(trump);
            handOne.FlipHand();
            //update labels
            lblError.Visible = false;
            lblRemainingCounter.Text = remainingCards.ToString();
            playedCards = new Hand();   //reset played cards
            attackNum = 1;  //reset attack number
            isAttacking[0] = !isAttacking[0];
            isAttacking[1] = !isAttacking[1];   //
            isDefending[0] = !isDefending[0];   // Swap attacker and defender
            isDefending[1] = !isDefending[1];   //
            pnlPlay.Controls.Clear();//clear play area
            ShowCards();//show all cards

            btnEndTurn1.Enabled = false;//disable end turn(only enabled after first attack on players attack)
            btnPickUp.Enabled = !btnPickUp.Enabled;//Swap whether pick up button is enabled(only when player is defender)
            //set attacker
            if (isAttacking[0])
            {
                lblAttacker.Text = "CPU is attacking";
                PlayTurn();//Fire off cpu's attack
            }
            else
            {
                lblAttacker.Text = "You are Attacking";
            }
        }

        /// <summary>
        /// Defender picks up cards currently played
        /// </summary>
        public void PickUpCards()
        {
            if(isDefending[0])
            {//ai defending
                handOne.PickUp(playedCards);
            }
            else if(isDefending[1])
            {//player defending
                handTwo.PickUp(playedCards);
            }
            EndTurn();
        }
        
        /// <summary>
        /// End the game
        /// </summary>
        public void GameOver()
        {
            string message = "";    //message for game end
            if(handOne.HandSize==0)
            {
                message = "The CPU has won.";   //set cpu win message
            }
            else if(handTwo.HandSize==0)
            {//set player win message
                message = "Congratulations!! You have won!!!";
            }
            MessageBox.Show(message);   //show game end message
            this.Close();   //end game
        }

        private void frmDurak_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Button to teach user how to use program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInstruction_Click(object sender, EventArgs e)
        {
            string instruction = " HOW TO PLAY\n------------------\n\n" +
                "This program will allow you to play \"Durak\" against a CPU.\n" +
                "To begin, you can click one of the deck size buttons to play with a 20, 36 or 52 card deck. " +
                "If you do not select one, the deck will default to 36 cards.\n" +
                "When you are ready to play, press the New Game button to begin playing\n" +
                "The CPU's hand is on the top, your hand is on the bottom and when a card is played, it will go into the middle.\n" +
                "The cards in the middle will always be listed in order of how recently they were played, from left to right\n" +
                "When it is the CPU's turn to make their move, they will do so automatically, and there will be a narrative box above your" +
                " cards reminding you what move was just made and what you are expected to do.\n" +
                "When it is your turn to play, you must click the card you wish to play. If you click a card that is not allowed to be played" +
                " at that time, you will see an error appear below your cards letting you know.\n" +
                "When you are defending, if you cannot defend, or you do not want to defend, you can click on the \"Pick Up Cards\" button" +
                " to pick up the cards in the middle. This button will be disabled when you are not defending.\n" +
                "When you are attacking, if you cannot make another attack, or you do not want to make another attack, you can click on the" +
                " \"End Turn\" button to end your turn. This button will be disabled when you are not attacking.\n" +
                "The game will alert you and end the game when one player wins.\n" +
                "\nThat's all you need to know! Enjoy the game and have fun!!";
            MessageBox.Show(instruction);
        }
    }
}
