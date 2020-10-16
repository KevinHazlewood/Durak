namespace DurakClient
{
    partial class frmDurak
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDurak));
            this.btnReset = new System.Windows.Forms.Button();
            this.btn52Deck = new System.Windows.Forms.Button();
            this.btn20Deck = new System.Windows.Forms.Button();
            this.pnlPlayer1 = new System.Windows.Forms.Panel();
            this.pnlPlay = new System.Windows.Forms.Panel();
            this.pnlPlayer2 = new System.Windows.Forms.Panel();
            this.pnlTrumpCard = new System.Windows.Forms.Panel();
            this.lblTrumpCard = new System.Windows.Forms.Label();
            this.pnlDeck = new System.Windows.Forms.Panel();
            this.lblDeck = new System.Windows.Forms.Label();
            this.btnEndTurn1 = new System.Windows.Forms.Button();
            this.lblAttacker = new System.Windows.Forms.Label();
            this.lblRemainingCounter = new System.Windows.Forms.Label();
            this.lblCardsRemaining = new System.Windows.Forms.Label();
            this.lblDiscardCounter = new System.Windows.Forms.Label();
            this.btnPickUp = new System.Windows.Forms.Button();
            this.lblGameplay = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.btn36Deck = new System.Windows.Forms.Button();
            this.btnInstruction = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(16, 15);
            this.btnReset.Margin = new System.Windows.Forms.Padding(4);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(165, 62);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "Reset / New Game";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btn52Deck
            // 
            this.btn52Deck.Location = new System.Drawing.Point(16, 84);
            this.btn52Deck.Margin = new System.Windows.Forms.Padding(4);
            this.btn52Deck.Name = "btn52Deck";
            this.btn52Deck.Size = new System.Drawing.Size(165, 28);
            this.btn52Deck.TabIndex = 3;
            this.btn52Deck.Text = "52 Card Deck";
            this.btn52Deck.UseVisualStyleBackColor = true;
            this.btn52Deck.Click += new System.EventHandler(this.btn52Deck_Click);
            // 
            // btn20Deck
            // 
            this.btn20Deck.Location = new System.Drawing.Point(16, 121);
            this.btn20Deck.Margin = new System.Windows.Forms.Padding(4);
            this.btn20Deck.Name = "btn20Deck";
            this.btn20Deck.Size = new System.Drawing.Size(165, 28);
            this.btn20Deck.TabIndex = 4;
            this.btn20Deck.Text = "20 Card Deck";
            this.btn20Deck.UseVisualStyleBackColor = true;
            this.btn20Deck.Click += new System.EventHandler(this.btn20Deck_Click);
            // 
            // pnlPlayer1
            // 
            this.pnlPlayer1.BackColor = System.Drawing.Color.Transparent;
            this.pnlPlayer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPlayer1.Location = new System.Drawing.Point(288, 39);
            this.pnlPlayer1.Margin = new System.Windows.Forms.Padding(4);
            this.pnlPlayer1.Name = "pnlPlayer1";
            this.pnlPlayer1.Size = new System.Drawing.Size(665, 162);
            this.pnlPlayer1.TabIndex = 5;
            // 
            // pnlPlay
            // 
            this.pnlPlay.BackColor = System.Drawing.Color.Transparent;
            this.pnlPlay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPlay.Location = new System.Drawing.Point(288, 235);
            this.pnlPlay.Margin = new System.Windows.Forms.Padding(4);
            this.pnlPlay.Name = "pnlPlay";
            this.pnlPlay.Size = new System.Drawing.Size(665, 162);
            this.pnlPlay.TabIndex = 6;
            // 
            // pnlPlayer2
            // 
            this.pnlPlayer2.BackColor = System.Drawing.Color.Transparent;
            this.pnlPlayer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPlayer2.Location = new System.Drawing.Point(288, 438);
            this.pnlPlayer2.Margin = new System.Windows.Forms.Padding(4);
            this.pnlPlayer2.Name = "pnlPlayer2";
            this.pnlPlayer2.Size = new System.Drawing.Size(665, 162);
            this.pnlPlayer2.TabIndex = 7;
            // 
            // pnlTrumpCard
            // 
            this.pnlTrumpCard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.pnlTrumpCard.BackColor = System.Drawing.Color.Transparent;
            this.pnlTrumpCard.Location = new System.Drawing.Point(52, 267);
            this.pnlTrumpCard.Margin = new System.Windows.Forms.Padding(4);
            this.pnlTrumpCard.Name = "pnlTrumpCard";
            this.pnlTrumpCard.Size = new System.Drawing.Size(95, 118);
            this.pnlTrumpCard.TabIndex = 8;
            // 
            // lblTrumpCard
            // 
            this.lblTrumpCard.BackColor = System.Drawing.Color.LightGray;
            this.lblTrumpCard.ForeColor = System.Drawing.Color.Black;
            this.lblTrumpCard.Location = new System.Drawing.Point(52, 235);
            this.lblTrumpCard.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTrumpCard.Name = "lblTrumpCard";
            this.lblTrumpCard.Size = new System.Drawing.Size(95, 28);
            this.lblTrumpCard.TabIndex = 9;
            this.lblTrumpCard.Text = "Trump Card";
            this.lblTrumpCard.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlDeck
            // 
            this.pnlDeck.BackColor = System.Drawing.Color.Transparent;
            this.pnlDeck.Location = new System.Drawing.Point(53, 466);
            this.pnlDeck.Margin = new System.Windows.Forms.Padding(4);
            this.pnlDeck.Name = "pnlDeck";
            this.pnlDeck.Size = new System.Drawing.Size(95, 118);
            this.pnlDeck.TabIndex = 10;
            // 
            // lblDeck
            // 
            this.lblDeck.BackColor = System.Drawing.Color.LightGray;
            this.lblDeck.ForeColor = System.Drawing.Color.Black;
            this.lblDeck.Location = new System.Drawing.Point(53, 434);
            this.lblDeck.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDeck.Name = "lblDeck";
            this.lblDeck.Size = new System.Drawing.Size(95, 28);
            this.lblDeck.TabIndex = 11;
            this.lblDeck.Text = "Deck";
            this.lblDeck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnEndTurn1
            // 
            this.btnEndTurn1.Enabled = false;
            this.btnEndTurn1.Location = new System.Drawing.Point(961, 505);
            this.btnEndTurn1.Margin = new System.Windows.Forms.Padding(4);
            this.btnEndTurn1.Name = "btnEndTurn1";
            this.btnEndTurn1.Size = new System.Drawing.Size(165, 28);
            this.btnEndTurn1.TabIndex = 13;
            this.btnEndTurn1.Text = "End Turn";
            this.btnEndTurn1.UseVisualStyleBackColor = true;
            this.btnEndTurn1.Click += new System.EventHandler(this.btnEndTurn1_Click);
            // 
            // lblAttacker
            // 
            this.lblAttacker.AutoSize = true;
            this.lblAttacker.Location = new System.Drawing.Point(965, 286);
            this.lblAttacker.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAttacker.Name = "lblAttacker";
            this.lblAttacker.Size = new System.Drawing.Size(0, 17);
            this.lblAttacker.TabIndex = 14;
            // 
            // lblRemainingCounter
            // 
            this.lblRemainingCounter.AutoSize = true;
            this.lblRemainingCounter.Location = new System.Drawing.Point(156, 626);
            this.lblRemainingCounter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRemainingCounter.Name = "lblRemainingCounter";
            this.lblRemainingCounter.Size = new System.Drawing.Size(0, 17);
            this.lblRemainingCounter.TabIndex = 15;
            // 
            // lblCardsRemaining
            // 
            this.lblCardsRemaining.AutoSize = true;
            this.lblCardsRemaining.Location = new System.Drawing.Point(16, 626);
            this.lblCardsRemaining.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCardsRemaining.Name = "lblCardsRemaining";
            this.lblCardsRemaining.Size = new System.Drawing.Size(120, 17);
            this.lblCardsRemaining.TabIndex = 16;
            this.lblCardsRemaining.Text = "Cards Remaining:";
            // 
            // lblDiscardCounter
            // 
            this.lblDiscardCounter.AutoSize = true;
            this.lblDiscardCounter.Location = new System.Drawing.Point(156, 663);
            this.lblDiscardCounter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDiscardCounter.Name = "lblDiscardCounter";
            this.lblDiscardCounter.Size = new System.Drawing.Size(0, 17);
            this.lblDiscardCounter.TabIndex = 18;
            // 
            // btnPickUp
            // 
            this.btnPickUp.Enabled = false;
            this.btnPickUp.Location = new System.Drawing.Point(961, 369);
            this.btnPickUp.Margin = new System.Windows.Forms.Padding(4);
            this.btnPickUp.Name = "btnPickUp";
            this.btnPickUp.Size = new System.Drawing.Size(165, 28);
            this.btnPickUp.TabIndex = 19;
            this.btnPickUp.Text = "Pick Up Cards";
            this.btnPickUp.UseVisualStyleBackColor = true;
            this.btnPickUp.Click += new System.EventHandler(this.btnPickUp_Click);
            // 
            // lblGameplay
            // 
            this.lblGameplay.Location = new System.Drawing.Point(288, 410);
            this.lblGameplay.Name = "lblGameplay";
            this.lblGameplay.Size = new System.Drawing.Size(665, 17);
            this.lblGameplay.TabIndex = 20;
            this.lblGameplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblGameplay.Visible = false;
            // 
            // lblError
            // 
            this.lblError.Location = new System.Drawing.Point(288, 604);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(665, 17);
            this.lblError.TabIndex = 21;
            this.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblError.Visible = false;
            // 
            // btn36Deck
            // 
            this.btn36Deck.Location = new System.Drawing.Point(19, 157);
            this.btn36Deck.Margin = new System.Windows.Forms.Padding(4);
            this.btn36Deck.Name = "btn36Deck";
            this.btn36Deck.Size = new System.Drawing.Size(165, 28);
            this.btn36Deck.TabIndex = 22;
            this.btn36Deck.Text = "36 Card Deck";
            this.btn36Deck.UseVisualStyleBackColor = true;
            this.btn36Deck.Click += new System.EventHandler(this.btn36Deck_Click);
            // 
            // btnInstruction
            // 
            this.btnInstruction.Location = new System.Drawing.Point(1069, 50);
            this.btnInstruction.Name = "btnInstruction";
            this.btnInstruction.Size = new System.Drawing.Size(175, 43);
            this.btnInstruction.TabIndex = 23;
            this.btnInstruction.Text = "Learn How To Play";
            this.btnInstruction.UseVisualStyleBackColor = true;
            this.btnInstruction.Click += new System.EventHandler(this.btnInstruction_Click);
            // 
            // frmDurak
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1353, 681);
            this.Controls.Add(this.btnInstruction);
            this.Controls.Add(this.btn36Deck);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.lblGameplay);
            this.Controls.Add(this.btnPickUp);
            this.Controls.Add(this.lblDiscardCounter);
            this.Controls.Add(this.lblCardsRemaining);
            this.Controls.Add(this.lblRemainingCounter);
            this.Controls.Add(this.lblAttacker);
            this.Controls.Add(this.btnEndTurn1);
            this.Controls.Add(this.lblDeck);
            this.Controls.Add(this.pnlDeck);
            this.Controls.Add(this.lblTrumpCard);
            this.Controls.Add(this.pnlTrumpCard);
            this.Controls.Add(this.pnlPlayer2);
            this.Controls.Add(this.pnlPlay);
            this.Controls.Add(this.pnlPlayer1);
            this.Controls.Add(this.btn20Deck);
            this.Controls.Add(this.btn52Deck);
            this.Controls.Add(this.btnReset);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(1371, 728);
            this.MinimumSize = new System.Drawing.Size(1371, 728);
            this.Name = "frmDurak";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Durak";
            this.Load += new System.EventHandler(this.frmDurak_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btn52Deck;
        private System.Windows.Forms.Button btn20Deck;
        private System.Windows.Forms.Panel pnlPlayer1;
        private System.Windows.Forms.Panel pnlPlay;
        private System.Windows.Forms.Panel pnlPlayer2;
        private System.Windows.Forms.Panel pnlTrumpCard;
        private System.Windows.Forms.Label lblTrumpCard;
        private System.Windows.Forms.Panel pnlDeck;
        private System.Windows.Forms.Label lblDeck;
        private System.Windows.Forms.Button btnEndTurn1;
        private System.Windows.Forms.Label lblAttacker;
        private System.Windows.Forms.Label lblRemainingCounter;
        private System.Windows.Forms.Label lblCardsRemaining;
        private System.Windows.Forms.Label lblDiscardCounter;
        private System.Windows.Forms.Button btnPickUp;
        private System.Windows.Forms.Label lblGameplay;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btn36Deck;
        private System.Windows.Forms.Button btnInstruction;
    }
}

