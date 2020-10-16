/*
    Name:       Kevin Hazlewood, Riyaz Nausath
    Due Date:   April 18 2019
    File:       CardBox.cs
    Description: 
    This is the cardbox class for our durak game, which will be used to generate the pictures used
    for the cards within the game

    Sources:
 
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CardLibrary;


namespace DurakClient
{
    public partial class CardBox : UserControl
    {

        //Component Designer Generated Code 
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PictureBox CardBoxControl;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        private void InitializeComponent()
        {
            this.CardBoxControl = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.CardBoxControl)).BeginInit();
            this.SuspendLayout();
            // 
            // CardBoxControl
            // 
            this.CardBoxControl.Image = global::DurakClient.Properties.Resources.blue_back;
            this.CardBoxControl.Location = new System.Drawing.Point(0, 0);
            this.CardBoxControl.Name = "CardBoxControl";
            this.CardBoxControl.Size = new System.Drawing.Size(71, 96);
            this.CardBoxControl.TabIndex = 0;
            this.CardBoxControl.TabStop = false;
            this.CardBoxControl.Click += new System.EventHandler(this.CarBoxControl_Click);
            // 
            // CardBox
            // 
            this.Controls.Add(this.CardBoxControl);
            this.Name = "CardBox";
            this.Size = new System.Drawing.Size(71, 96);
            ((System.ComponentModel.ISupportInitialize)(this.CardBoxControl)).EndInit();
            this.ResumeLayout(false);

        }

        private Card card = new Card();

        public event EventHandler CardClicked;

        public CardBox()
        {
            InitializeComponent();
            StartingCardImage();

        }
        public CardBox(Card card)
        {
            
            InitializeComponent();
            StartingCardImage();
            Card = card;
        }

        public Card Card
        {
            get
            {
                return card;
            }
            set
            {
                card = value;
                UpdateCardImage();
            }
        }

        public Suit getSuit()
        {
            return card.getSuit();

        }
        public Rank getRank()
        {
            return card.getRank();
        }


        private void StartingCardImage()
        {
            string fileName = "blue_back";
            CardBoxControl.Image = (Image)Properties.Resources.ResourceManager.GetObject(fileName);
            CardBoxControl.Refresh();


        }
        private void UpdateCardImage()
        {

            string fileName = "";
            fileName = getRank().ToString() + "_of_" + getSuit().ToString();
            if(card.FaceUp == false)
            {
                fileName = "blue_back";
            }

            CardBoxControl.Image = (Image)Properties.Resources.ResourceManager.GetObject(fileName);
            CardBoxControl.Refresh();
        }

        protected virtual void OnCardClicked(EventArgs e)
        {
            if (CardClicked != null)
                CardClicked(this, e);
        }
        private void CarBoxControl_Click(object sender, EventArgs e)
        {
            OnCardClicked(EventArgs.Empty); // Raise card clicked event
        }
    }
}
